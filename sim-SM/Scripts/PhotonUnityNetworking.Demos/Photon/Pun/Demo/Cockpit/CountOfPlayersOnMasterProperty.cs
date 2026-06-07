using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class CountOfPlayersOnMasterProperty : PropertyListenerBase
	{
		public Text Text;

		private int _cache;

		private void Update()
		{
		}
	}
}
