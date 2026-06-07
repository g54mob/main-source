using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "ControllerVibrationIntensityConnection", menuName = "SettingsGenerator/Connection/ControllerVibrationIntensityConnection", order = 4)]
	public class ControllerVibrationIntensityConnectionSO : FloatConnectionSO
	{
		[Tooltip("How the input should be mapped to 0f..1f.\nUseful if you have a range in percent (from 0 to 100) but need output ranging from 0f to 1f.")]
		public float controllerVibrationIntensity = 1f;

		protected ControllerVibrationIntensityConnection _connection;

		public override IConnection<float> GetConnection()
		{
			if (_connection == null)
			{
				Create();
			}
			return _connection;
		}

		public void Create()
		{
			_connection = new ControllerVibrationIntensityConnection(controllerVibrationIntensity);
		}

		public override void DestroyConnection()
		{
			if (_connection != null)
			{
				_connection.Destroy();
			}
			_connection = null;
		}
	}
}
