using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "CameraShakeConnection", menuName = "SettingsGenerator/Connection/CameraShakeConnection", order = 1)]
	public class CameraShakeConnectionSO : BoolConnectionSO
	{
		protected CameraShakeConnection _connection;

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
			_connection = new CameraShakeConnection();
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
