using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "VoiceChatModeConnection", menuName = "SettingsGenerator/Connection/VoiceChatModeConnection", order = 4)]
	public class VoiceChatModeConnectionSO : OptionConnectionSO
	{
		protected VoiceChatModeConnection _connection;

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
			_connection = new VoiceChatModeConnection();
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
