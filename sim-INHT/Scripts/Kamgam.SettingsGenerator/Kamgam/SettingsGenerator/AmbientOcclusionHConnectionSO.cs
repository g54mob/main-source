using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "AmbientOcclusionHConnection", menuName = "SettingsGenerator/Connection/AmbientOcclusionHConnection", order = 5)]
	public class AmbientOcclusionHConnectionSO : BoolConnectionSO
	{
		protected AmbientOcclusionHConnection _connection;

		public override IConnection<bool> GetConnection()
		{
			return null;
		}

		public void Create()
		{
		}

		public override void DestroyConnection()
		{
		}
	}
}
