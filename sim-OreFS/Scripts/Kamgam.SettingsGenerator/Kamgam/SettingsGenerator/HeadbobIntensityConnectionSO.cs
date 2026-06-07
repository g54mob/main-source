using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "HeadbobIntensityConnection", menuName = "SettingsGenerator/Connection/HeadbobIntensityConnection", order = 4)]
	public class HeadbobIntensityConnectionSO : FloatConnectionSO
	{
		[Tooltip("How the input should be mapped to 0f..1f.\nUseful if you have a range in percent (from 0 to 100) but need output ranging from 0f to 1f.")]
		public float headbobIntensity = 0.08f;

		protected HeadbobIntensityConnection _connection;

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
			_connection = new HeadbobIntensityConnection(headbobIntensity);
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
