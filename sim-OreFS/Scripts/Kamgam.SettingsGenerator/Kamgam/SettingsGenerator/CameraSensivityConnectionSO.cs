using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "CameraSensivityConnection", menuName = "SettingsGenerator/Connection/CameraSensivityConnection", order = 4)]
	public class CameraSensivityConnectionSO : FloatConnectionSO
	{
		[Tooltip("How the input should be mapped to 0f..1f.\nUseful if you have a range in percent (from 0 to 100) but need output ranging from 0f to 1f.")]
		public Vector3 sensivity = new Vector3(0.25f, 0.25f, 0.25f);

		protected CameraSensivityConnection _connection;

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
			_connection = new CameraSensivityConnection(sensivity);
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
