using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class CurrentRoomMaxPlayersProperty : PropertyListenerBase
	{
		public Text Text;

		private int _cache;

		private void Update()
		{
		}
	}
}
