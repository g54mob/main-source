using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "ShowControlsConnection", menuName = "SettingsGenerator/Connection/ShowControlsConnection", order = 1)]
	public class ShowControlsConnectionSO : BoolConnectionSO
	{
		protected ShowControlsConnection _connection;

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
			_connection = new ShowControlsConnection();
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
