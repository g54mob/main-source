using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "CameraSmoothingConnection", menuName = "SettingsGenerator/Connection/CameraSmoothingConnection", order = 4)]
	public class CameraSmoothingConnectionSO : FloatConnectionSO
	{
		[Tooltip("How the input should be mapped to 0f..1f.\nUseful if you have a range in percent (from 0 to 100) but need output ranging from 0f to 1f.")]
		public float smoothing;

		protected CameraSmoothingConnection _connection;

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
			_connection = new CameraSmoothingConnection(smoothing);
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
