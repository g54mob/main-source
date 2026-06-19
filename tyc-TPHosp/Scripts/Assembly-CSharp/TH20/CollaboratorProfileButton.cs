using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class CollaboratorProfileButton : MonoBehaviour
	{
		[SerializeField]
		private PlayerAvatar _avatar;

		[SerializeField]
		private GameObject _addButtonGameObject;

		[SerializeField]
		private GameObject _warningIcon;

		[SerializeField]
		private DynamicButton _addButton;

		[SerializeField]
		private DynamicButton _kickButton;

		[SerializeField]
		private TMP_Text _kickLabel;

		[SerializeField]
		private TMP_Text _waitingForDataLabel;

		public Action OnRequestAddPlayer;

		public Action<OnlinePlayerID> OnRequestKickPlayer;

		[NonSerialized]
		public bool IsLocalPlayerLeader;

		private OnlinePlayerID _onlinePlayerID = OnlinePlayerID.Nil;

		private bool _hasData;

		private bool _isDataDeprecated;

		private void Start()
		{
			if (_addButton != null)
			{
				_addButton.onPrimaryDown.AddListener(OnAddButtonPressed);
			}
			if (_kickButton != null)
			{
				_kickButton.onPrimaryDown.AddListener(OnKickPressed);
			}
			Refresh();
		}

		private void OnDestroy()
		{
			if (_addButton != null)
			{
				_addButton.onPrimaryDown.RemoveListener(OnAddButtonPressed);
			}
			if (_kickButton != null)
			{
				_kickButton.onPrimaryDown.RemoveListener(OnKickPressed);
			}
		}

		public void Setup(OnlinePlayerID playerID, IResearchNetworkState networkState, CollaborativeProjectDataBase data)
		{
			CollaborativeProjectData collaborativeProjectData = data as CollaborativeProjectData;
			_onlinePlayerID = playerID;
			_hasData = collaborativeProjectData != null;
			_isDataDeprecated = collaborativeProjectData?.IsDeprecated ?? false;
			_avatar.SetupForCollaboratorTooltip(networkState, collaborativeProjectData);
			Refresh();
		}

		private void Refresh()
		{
			if (_onlinePlayerID == OnlinePlayerID.Nil)
			{
				_avatar.PlayerID = OnlinePlayerID.Nil;
				GameObjectUtils.SetActive(_avatar.gameObject, isActive: false);
				if (_addButtonGameObject != null)
				{
					GameObjectUtils.SetActive(_addButtonGameObject, isActive: true);
				}
				if (_kickButton != null)
				{
					_kickButton.gameObject.SetActive(value: false);
				}
				if (_waitingForDataLabel != null)
				{
					_waitingForDataLabel.gameObject.SetActive(value: false);
				}
				if (_warningIcon != null)
				{
					GameObjectUtils.SetActive(_warningIcon, isActive: false);
				}
				return;
			}
			if (_kickButton != null)
			{
				_kickButton.gameObject.SetActive(CanKickCollaborator());
			}
			if (_kickLabel != null)
			{
				_kickLabel.text = (_hasData ? ScriptLocalization.Collaborative_GUI.Kick_CS : ScriptLocalization.Collaborative_GUI.Uninvite_CS);
			}
			if (_waitingForDataLabel != null)
			{
				_waitingForDataLabel.gameObject.SetActive(!_hasData);
			}
			_avatar.PlayerID = _onlinePlayerID;
			GameObjectUtils.SetActive(_avatar.gameObject, isActive: true);
			if (_addButtonGameObject != null)
			{
				GameObjectUtils.SetActive(_addButtonGameObject, isActive: false);
			}
			if (_warningIcon != null)
			{
				GameObjectUtils.SetActive(_warningIcon, _isDataDeprecated);
			}
		}

		private void OnAddButtonPressed()
		{
			if (_onlinePlayerID == OnlinePlayerID.Nil)
			{
				OnRequestAddPlayer.InvokeSafe();
			}
		}

		private void OnKickPressed()
		{
			if (_onlinePlayerID != OnlinePlayerID.Nil)
			{
				OnRequestKickPlayer.InvokeSafe(_onlinePlayerID);
			}
		}

		private bool CanKickCollaborator()
		{
			if (IsLocalPlayerLeader && _onlinePlayerID.m_OnlinePlayerID != OnlineManager.GetLocalPlayerID().m_OnlinePlayerID)
			{
				return _onlinePlayerID != OnlinePlayerID.Nil;
			}
			return false;
		}
	}
}
