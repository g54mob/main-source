using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "ControllerVibrationConnection", menuName = "SettingsGenerator/Connection/ControllerVibrationConnection", order = 1)]
	public class ControllerVibrationConnectionSO : BoolConnectionSO
	{
		protected ControllerVibrationConnection _connection;

		public override IConnection<bool> GetConnection()
		{
			if (_connection == null)
			{
				Create();
			}
			return _connection;
		}

		public void Create()
		{
			_connection = new ControllerVibrationConnection();
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
