using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiningManager : MonoBehaviour {

	int randVal;
	private float timeInterval;
	private bool isCoroutine;
	private int finalAngle;

	public Text winText;
	//private HitBoc ht = new HitBoc();
	public int section;
	float totalAngle;
	public string[] PrizeName;
	public int volta=0;

	private void Start () {
		isCoroutine = true;
		totalAngle = 360 / section;
	}

	private void Update () {

		if (Input.GetMouseButton (0) && isCoroutine) {
			StartCoroutine (Spin());
		}
	}

	private IEnumerator Spin(){

		isCoroutine = false;
		randVal = Random.Range(200, 300);//angles per round

		timeInterval = 0.01f*Time.deltaTime*2;

		for (int i = 0; i < randVal; i++) {

			transform.Rotate (0, 0, (totalAngle/3)); //Start Rotate by 30 degrees


			//To slow Down Wheel
			if (i > Mathf.RoundToInt (randVal * 0.2f))
				timeInterval = 0.5f*Time.deltaTime;
			if (i > Mathf.RoundToInt (randVal * 0.5f))
				timeInterval = 1f*Time.deltaTime;
			if (i > Mathf.RoundToInt (randVal * 0.7f))
				timeInterval = 1.5f*Time.deltaTime;
			if (i > Mathf.RoundToInt (randVal * 0.8f))
				timeInterval = 2f*Time.deltaTime;
			if (i > Mathf.RoundToInt (randVal * 0.9f))
				timeInterval = 2.5f*Time.deltaTime;

			yield return new WaitForSeconds (timeInterval);

		}

		if (Mathf.RoundToInt (transform.eulerAngles.z) % totalAngle != 0) //when the indicator stop between 2 numbers,it will add aditional step 
			transform.Rotate (0, 0, totalAngle/2);
		
		finalAngle = Mathf.RoundToInt (transform.eulerAngles.z);//round off euler angle of wheel value

		print (finalAngle);
		//print (volta);

		//Prize check
		for (int i = 0; i < section; i++) {

			if (finalAngle == i * totalAngle)
				winText.text = PrizeName [i];
		}

	
		isCoroutine = true;
	}//Spin


 
    /*void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject.Destroy(collider.gameObject);
    }*/
}
