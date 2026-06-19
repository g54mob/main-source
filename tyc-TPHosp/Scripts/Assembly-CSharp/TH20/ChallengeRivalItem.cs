using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ChallengeRivalItem : MonoBehaviour
	{
		[SerializeField]
		private DynamicButton _removeButton;

		[SerializeField]
		private Image _avatarImage;

		[SerializeField]
		private TMP_Text _rivalName;

		public Action<OnlinePlayerID> OnRemoveFriend;

		private OnlinePlayerID _onlinePlayerID;

		private RivalFoundationDefinition _rivalDefinition;

		public OnlinePlayerID OnlinePlayerID
		{
			get
			{
				if (_rivalDefinition == null)
				{
					return _onlinePlayerID;
				}
				return _rivalDefinition.DummySteamID;
			}
		}

		public RivalFoundationDefinition RivalFoundation => _rivalDefinition;

		private void OnEnable()
		{
			_removeButton.onPrimaryDown.AddListener(OnRemovePressed);
			if (OnlineManager.IsInitialized())
			{
				OnlineManager.OnPersonaChanged = (Action<OnlinePlayerID>)Delegate.Combine(OnlineManager.OnPersonaChanged, new Action<OnlinePlayerID>(OnPersonaChanged));
			}
		}

		private void OnDisable()
		{
			_removeButton.onPrimaryDown.RemoveListener(OnRemovePressed);
			if (OnlineManager.IsInitialized())
			{
				OnlineManager.OnPersonaChanged = (Action<OnlinePlayerID>)Delegate.Remove(OnlineManager.OnPersonaChanged, new Action<OnlinePlayerID>(OnPersonaChanged));
			}
		}

		private void OnPersonaChanged(OnlinePlayerID onlinePlayerID)
		{
			if (_onlinePlayerID == onlinePlayerID)
			{
				Refresh();
			}
		}

		private void Refresh()
		{
			Sprite avatar = OnlineManager.GetAvatar(_onlinePlayerID);
			_avatarImage.color = ((avatar != null) ? Color.white : Color.clear);
			_avatarImage.overrideSprite = avatar;
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(_onlinePlayerID);
			_rivalName.text = ((playerInfo != null) ? playerInfo.DisplayName : ScriptLocalization.Misc.Unknown_CS);
		}

		public void SetupForFriend(OnlinePlayerID onlinePlayerID)
		{
			_rivalDefinition = null;
			_onlinePlayerID = onlinePlayerID;
			Refresh();
			GameObjectUtils.SetActive(_removeButton.gameObject, isActive: true);
		}

		public void SetupForAI(RivalFoundationDefinition rival)
		{
			_rivalDefinition = rival;
			_onlinePlayerID = OnlinePlayerID.Nil;
			_avatarImage.color = Color.white;
			_avatarImage.overrideSprite = rival.Icon;
			_rivalName.text = rival.FoundationName.Translation;
			GameObjectUtils.SetActive(_removeButton.gameObject, isActive: false);
		}

		public void SetupEmpty()
		{
			_rivalDefinition = null;
			_onlinePlayerID = OnlinePlayerID.Nil;
			_avatarImage.color = Color.clear;
			_avatarImage.overrideSprite = OnlineManager.DefaultAvatarSprite;
			_rivalName.text = string.Empty;
			GameObjectUtils.SetActive(_removeButton.gameObject, isActive: false);
		}

		private void OnRemovePressed()
		{
			OnRemoveFriend.InvokeSafe(_onlinePlayerID);
		}
	}
}
