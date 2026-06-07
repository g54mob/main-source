using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "ShadowResolutionConnection", menuName = "SettingsGenerator/Connection/ShadowResolutionConnection", order = 4)]
	public class ShadowResolutionConnectionSO : OptionConnectionSO
	{
		protected ShadowResolutionConnection _connection;

		public override IConnectionWithOptions<string> GetConnection()
		{
			if (_connection == null)
			{
				Create();
			}
			return _connection;
		}

		public void Create()
		{
			_connection = new ShadowResolutionConnection();
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
