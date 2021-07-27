using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    private int startPos = 80;
    private int goalPos = 360;
    private float posRange = 3.4f;
    private GameObject unitychan;
    private float itemPos;
    private float difference;
    private GameObject coin;
    private GameObject car;
    private GameObject cone;
    
    // Start is called before the first frame update
    void Start()
    {
        //unitychanを代入(unitychanのpositionを得るため)
        this.unitychan = GameObject.Find("unitychan");
        //アイテムの生成予定座標を保持する変数
        itemPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        //itemPosがUnitychanのz軸の座標とそこから50mの範囲の中に含まれる時
        if((unitychan.transform.position.z + startPos) > itemPos　&& (unitychan.transform.position.z + 50.0f) < goalPos){

            int num = Random.Range(1,11);
            if(num <= 2){
                for(float j = -1; j <= 1; j += 0.4f){
                    this.cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + 50.0f);
                }
            } else {
                for(int j = -1; j<= 1; j++){
                    int item = Random.Range(1,11);
                    float offsetZ = Random.Range(-5,6);
                    if(1 <= item && item <= 6){
                        this.coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, offsetZ + unitychan.transform.position.z + 50.0f);
                    } else if(7 <= item && item <= 9){
                        this.car = Instantiate(carPrefab);
                        car.transform.position = new Vector3 (posRange * j, car.transform.position.y, offsetZ  + unitychan.transform.position.z + 50.0f);
                    }
                }
            }
            //次の基準となるUnityちゃんの座標を更新。
            itemPos = itemPos + 15;
        }
    }
}
