using System;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class CollaborativeProjectInviteFriendItem : MonoBehaviour
	{
		[SerializeField]
		private PlayerAvatar _avatar;

		[SerializeField]
		private PlayerName _name;

		[SerializeField]
		private DynamicButton _button;

		public Action<OnlinePlayerID> OnSelected;

		private OnlinePlayerID _onlinePlayerID;

		private void OnEnable()
		{
			_button.onPrimaryDown.AddListener(OnClicked);
		}

		private void OnDisable()
		{
			_button.onPrimaryDown.RemoveListener(OnClicked);
		}

		public void Setup(OnlinePlayerID onlinePlayerID)
		{
			_onlinePlayerID = onlinePlayerID;
			_name.PlayerID = onlinePlayerID;
			_avatar.PlayerID = onlinePlayerID;
		}

		private void OnClicked()
		{
			OnSelected.InvokeSafe(_onlinePlayerID);
		}
	}
}
