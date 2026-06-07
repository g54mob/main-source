using LocoSim.Implementations.Wheels;
using UnityEngine;

namespace DV.Wheels
{
	public class PoweredWheelRotationViaCode : PoweredWheelRotationBase
	{
		public TransformRotationConfig[] additionalTransformsToRotate;

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			float rPS = GetRPS();
			if (rPS == 0f)
			{
				return;
			}
			float num = float.PositiveInfinity;
			PoweredWheel[] poweredWheels = poweredWheelsManager.poweredWheels;
			foreach (PoweredWheel poweredWheel in poweredWheels)
			{
				float num2 = rPS;
				if (!poweredWheel.IsPowered)
				{
					if (num == float.PositiveInfinity)
					{
						num = GetRollingRPS();
					}
					num2 = num;
				}
				poweredWheel.wheelTransform.Rotate(poweredWheel.localRotationAxis, num2 * 360f * deltaTime, Space.Self);
			}
			TransformRotationConfig[] array = additionalTransformsToRotate;
			for (int i = 0; i < array.Length; i++)
			{
				TransformRotationConfig transformRotationConfig = array[i];
				transformRotationConfig.transformToRotate.Rotate(transformRotationConfig.rotationAxis, rPS * 360f * deltaTime, Space.Self);
			}
		}
	}
}
