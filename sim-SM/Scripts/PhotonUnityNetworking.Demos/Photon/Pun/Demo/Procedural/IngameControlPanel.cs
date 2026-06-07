using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Procedural
{
	public class IngameControlPanel : MonoBehaviourPunCallbacks
	{
		private bool isSeedValid;

		private InputField seedInputField;

		private Dropdown worldSizeDropdown;

		private Dropdown clusterSizeDropdown;

		private Dropdown worldTypeDropdown;

		private Button generateWorldButton;

		public void Awake()
		{
		}

		public override void OnJoinedRoom()
		{
		}

		public override void OnMasterClientSwitched(Player newMasterClient)
		{
		}

		public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
		{
		}
	}
}
