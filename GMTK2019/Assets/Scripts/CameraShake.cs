using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public Camera mainCam;  // the camera which is to be shaked
	float shakeAmount=0;

	void Awake()
	{
		if (mainCam == null) 
		{
			Debug.Log ("No Camera Found");
		}
	}

    // void Update()
    // {
        // if (Input.GetKeyDown(KeyCode.T)) {
            // Shake(0.05f, 0.05f);
        // }
    // }

	public void Shake(float amt, float length)
	{
		shakeAmount = amt;
		InvokeRepeating ("BeginShake",0,0.01f);
		Invoke ("StopShake",length);
	}

	void BeginShake()
	{
		if (shakeAmount > 0) 
		{
			Vector3 mainCamPos = mainCam.transform.position;

			float offSetX = Random.value * shakeAmount * 2 - shakeAmount;
			float offsetY = Random.value * shakeAmount * 2 - shakeAmount;

			mainCamPos.x += offSetX;
			mainCamPos.y += offsetY;

			mainCam.transform.position = mainCamPos;
		}
	}

	void StopShake()
	{
		CancelInvoke ("BeginShake");
		mainCam.transform.localPosition = Vector3.zero;
	}
}
