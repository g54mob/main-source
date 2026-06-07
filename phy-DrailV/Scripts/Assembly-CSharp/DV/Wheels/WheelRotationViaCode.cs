using UnityEngine;

namespace DV.Wheels
{
	public class WheelRotationViaCode : WheelRotationBase
	{
		public BezierCurve.Axis rotationAxis;

		public Transform[] transformsToRotate;

		private void Update()
		{
			float rPS = GetRPS();
			if (rPS != 0f)
			{
				float num = rPS * 360f * Time.deltaTime;
				Quaternion quaternion = default(Quaternion);
				switch (rotationAxis)
				{
				case BezierCurve.Axis.X:
					quaternion = Quaternion.Euler(num, 0f, 0f);
					break;
				case BezierCurve.Axis.Y:
					quaternion = Quaternion.Euler(0f, num, 0f);
					break;
				case BezierCurve.Axis.Z:
					quaternion = Quaternion.Euler(0f, 0f, num);
					break;
				}
				Transform[] array = transformsToRotate;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].localRotation *= quaternion;
				}
			}
		}
	}
}
