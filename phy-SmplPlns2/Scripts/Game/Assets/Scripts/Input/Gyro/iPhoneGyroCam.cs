using System;
using UnityEngine;

namespace Assets.Scripts.Input.Gyro
{
	[Serializable]
	public class iPhoneGyroCam : MonoBehaviour
	{
		private Gyroscope gyro;

		private bool gyroBool;

		private Quaternion rotFix;

		protected virtual void Start()
		{
			Transform parent = base.transform.parent;
			GameObject gameObject = new GameObject("camParent");
			gameObject.transform.position = base.transform.position;
			base.transform.parent = gameObject.transform;
			gameObject.transform.parent = parent;
			gyroBool = SystemInfo.supportsGyroscope;
			if (gyroBool)
			{
				gyro = UnityEngine.Input.gyro;
				gyro.enabled = true;
				if (Screen.orientation == ScreenOrientation.LandscapeLeft)
				{
					gameObject.transform.eulerAngles = new Vector3(90f, 90f, 0f);
				}
				else if (Screen.orientation == ScreenOrientation.Portrait)
				{
					gameObject.transform.eulerAngles = new Vector3(90f, 180f, 0f);
				}
				if (Screen.orientation == ScreenOrientation.LandscapeLeft)
				{
					rotFix = new Quaternion(0f, 0f, 0.7071f, 0.7071f);
				}
				else if (Screen.orientation == ScreenOrientation.Portrait)
				{
					rotFix = new Quaternion(0f, 0f, 1f, 0f);
				}
			}
			else
			{
				MonoBehaviour.print("NO GYRO");
			}
		}

		protected virtual void Update()
		{
			if (gyroBool)
			{
				Quaternion localRotation = gyro.attitude * rotFix;
				base.transform.localRotation = localRotation;
			}
		}
	}
}
