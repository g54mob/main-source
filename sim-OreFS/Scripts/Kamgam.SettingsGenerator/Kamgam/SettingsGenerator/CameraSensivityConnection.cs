using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class CameraSensivityConnection : Connection<float>
	{
		public Vector3 sensivity = new Vector3(0.25f, 0.25f, 0.25f);

		private float value;

		private static Vector3 currentValue;

		public static Vector3 CurrentValue => currentValue;

		public CameraSensivityConnection(Vector3 currSensivity)
		{
			sensivity = currSensivity;
		}

		public override float Get()
		{
			return value;
		}

		public override float GetDefault()
		{
			return 0.25f;
		}

		public override void Set(float volume)
		{
			value = volume;
			currentValue = new Vector3(volume, volume, volume);
		}
	}
}
