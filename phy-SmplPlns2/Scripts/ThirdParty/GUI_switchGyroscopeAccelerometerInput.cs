using MSP_Input;
using UnityEngine;

public class GUI_switchGyroscopeAccelerometerInput : MonoBehaviour
{
	private void Start()
	{
	}

	private void OnGUI()
	{
		int width = Screen.width;
		float num = 4f;
		float num2 = (float)width / num;
		float height = 40f;
		float num3 = 5f;
		bool forceAccelerometer = GyroAccel.GetForceAccelerometer();
		string text = (forceAccelerometer ? "use accelerometer" : "use gyroscope");
		if (GUI.Button(new Rect(0f * num2 + num3, 0f + num3, num2 - 2f * num3, height), text))
		{
			GyroAccel.SetForceAccelerometer(!forceAccelerometer);
		}
	}
}
