using UnityEngine;
using System.Collections;

public class SetResolution: MonoBehaviour {
	public int ScreenWidth;
	public int ScreenHeight;
	void Awake()
	{
		// PC向けビルドだったらサイズ変更
		if (Application.platform == RuntimePlatform.WindowsPlayer ||
		    Application.platform == RuntimePlatform.OSXPlayer ||
		    Application.platform == RuntimePlatform.LinuxPlayer )
		{
			Screen.SetResolution(ScreenWidth, ScreenHeight, false);
		}
	}
	void Start () {
	}
	
	void Update () {
	}
}
