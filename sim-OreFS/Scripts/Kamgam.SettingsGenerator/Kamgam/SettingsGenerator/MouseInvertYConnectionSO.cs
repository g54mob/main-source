using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "MouseInvertYConnection", menuName = "SettingsGenerator/Connection/MouseInvertYConnection", order = 1)]
	public class MouseInvertYConnectionSO : BoolConnectionSO
	{
		protected MouseInvertYConnection _connection;

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
			_connection = new MouseInvertYConnection();
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
