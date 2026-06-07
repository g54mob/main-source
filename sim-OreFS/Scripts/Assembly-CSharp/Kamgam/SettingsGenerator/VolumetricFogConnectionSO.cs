using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "VolumetricFogConnection", menuName = "SettingsGenerator/Connection/VolumetricFogConnection", order = 4)]
	public class VolumetricFogConnectionSO : BoolConnectionSO
	{
		protected VolumetricFogConnection _connection;

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
			_connection = new VolumetricFogConnection();
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
