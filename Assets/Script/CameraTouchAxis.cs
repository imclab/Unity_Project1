﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CameraCameraTouchAxis : MonoBehaviour
{
	public float RotateSpeed = 0.1f;
	public float UpDownSpeed = 0.01f;

	void Update()
	{
		int touchCount = Input.touches
			.Count(t => t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled);
		if (touchCount == 1)
		{
			Touch t = Input.touches.First();
			switch (t.phase)
			{
			case TouchPhase.Moved:
				
				//移動量
				float xDelta = t.deltaPosition.x * RotateSpeed;
				float yDelta = t.deltaPosition.y * UpDownSpeed;
				
				//左右回転
				this.transform.Rotate(0, xDelta, 0, Space.World);
				//上下移動
				this.transform.position += new Vector3(0, -yDelta, 0);
				
				break;
			}
		}
		//this.transform.Rotate ( 0, ( Input.GetAxis ( "Horizontal" ) * 1 ), 0 );
	}
}