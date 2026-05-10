using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class CurrentRoomNameProperty : PropertyListenerBase
	{
		public Text Text;

		private string _cache;

		private void Update()
		{
		}
	}
}
