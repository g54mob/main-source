using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "RadiantGIConnection", menuName = "SettingsGenerator/Connection/RadiantGIConnection", order = 4)]
	public class RadiantGIConnectionSO : BoolConnectionSO
	{
		protected RadiantGIConnection _connection;

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
			_connection = new RadiantGIConnection();
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
