using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundThrow : MonoBehaviour
{
	public GameObject ballObj;             // 生成したいPrefab
	private Vector3 clickPos;             // クリックした位置座標（ｘ、ｙ、ｚ）
	public float speed;                     //    飛ばす力の大きさの値です 
	public Transform canonPos;  //　 弾が出る場所の座標


	void Update()            //　毎フレームごとに、クリックされてるかチェックします
	{
		if (Input.GetMouseButtonDown(0))        // もしマウスで左クリック("0"が左クリックに初期設定してあります)したら・・
		{
			{
				clickPos = Input.mousePosition;          // Vector3でマウスがクリックした位置座標を取得する
				Debug.Log(clickPos);                              //デバッグ：　Z軸の値が０だと表示されません、（ScreenToWorldPointに必要）
				clickPos.z = 10.0f;             // そこでに適当な値をz値に入れます

				Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);
				//Instantiate オブジェクトを作る関数（ オブジェクト名(GameObject), 作る位置(Vector3), オブジェクトの角度(Quaternion)）
				GameObject ball = Instantiate(ballObj, canonPos.position, ballObj.transform.rotation);
				//弾の飛ぶ方向ベクトルbulletDirに、弾の出るcanonPosの位置とマウスのクリックした位置を引き算した値に、
				//(1,1,0)をかけて（Scale）、Z軸の値を0にします、それをnormalizedで「単位ベクトル」に直します
				Vector3 bulletDir = Vector3.Scale((mouseWorldPos - canonPos.position), new Vector3(1, 1, 0)).normalized;
				ball.GetComponent<Rigidbody2D>().AddForce(bulletDir * speed); //AddForceでrigidbodyを付けたballを飛ばします

				//Instantiate（ オブジェクトを作る関数） オブジェクト名(GameObject), 位置(Vector3), 角度(Quaternion)
				// ScreenToWorldPoint(位置(Vector3))：スクリーン座標をワールド座標に変換する、それをカメラ位置にする
				
			}
		}
	}
}