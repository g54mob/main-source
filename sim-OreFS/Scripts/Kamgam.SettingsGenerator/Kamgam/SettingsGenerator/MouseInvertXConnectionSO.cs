using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "MouseInvertXConnection", menuName = "SettingsGenerator/Connection/MouseInvertXConnection", order = 1)]
	public class MouseInvertXConnectionSO : BoolConnectionSO
	{
		protected MouseInvertXConnection _connection;

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
			_connection = new MouseInvertXConnection();
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
