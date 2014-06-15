using UnityEngine;
using System.Collections;

public class CameraDragAxis : MonoBehaviour {

	GameObject maincamera;
	
	enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	RotationAxes axes = RotationAxes.MouseXAndY;
	float sensitivityX = 15F;
	float sensitivityY = 15F;
	float minimumY = -60F;
	float maximumY = 60F;
	float rotationY = 0F;
	
	Vector3 velocity;
	
	bool isLeftDrag = false;
	bool isRightDrag = false;

	// Use this for initialization
	void Start () {
		maincamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {

		if (isLeftDrag == false && isRightDrag == false){
			if (Input.GetMouseButton(0))
				isLeftDrag = true;
			else if(Input.GetMouseButton(1))
				isRightDrag = true;
		}
		else if(isLeftDrag){
			if (Input.GetMouseButton(0) == false)
				isLeftDrag = false;
		}
		else if(isRightDrag){
			if (Input.GetMouseButton(1) == false)
				isRightDrag = false;
		}

		
		if (isLeftDrag)
			Move();
		else if (isRightDrag)
			Rotate();

		maincamera.transform.Translate(new Vector3(0,0,Input.GetAxis("Vertical")*1));
	}
	
	void Rotate(){
		if (axes == RotationAxes.MouseXAndY){
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX){
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
		
	}
	
	void Move(){
		velocity = maincamera.transform.TransformDirection(new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"),0 ));
		maincamera.transform.position += velocity;
	}
}