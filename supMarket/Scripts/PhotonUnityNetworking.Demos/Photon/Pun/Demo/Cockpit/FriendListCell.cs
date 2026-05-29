using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class FriendListCell : MonoBehaviour
	{
		public FriendListView ListManager;

		public Text NameText;

		public GameObject OnlineFlag;

		public GameObject inRoomText;

		public GameObject JoinButton;

		private FriendInfo _info;

		public void RefreshInfo(FriendListView.FriendDetail details)
		{
		}

		public void RefreshInfo(FriendInfo info)
		{
		}

		public void JoinFriendRoom()
		{
		}

		public void RemoveFromList()
		{
		}
	}
}
