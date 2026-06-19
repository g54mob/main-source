using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class OnlineChallengeRivalSelectItem : MonoBehaviour
	{
		[SerializeField]
		private Image _backingImage;

		[SerializeField]
		private Image _avatarImage;

		[SerializeField]
		private TMP_Text _statusText;

		[SerializeField]
		private Color _tintDefault;

		[SerializeField]
		private Color _tintSelected;

		[SerializeField]
		private Color _tintDisabled;

		public bool IsEnabled = true;

		private OnlineChallengeHomeAdvanced _owner;

		public OnlineChallengeHome.FriendSortItem Friend { get; private set; }

		public void SetupForFriend(OnlineChallengeHomeAdvanced owner, OnlineChallengeHome.FriendSortItem friend, bool isSelected, bool disableIfNotSelected)
		{
			_owner = owner;
			Friend = friend;
			if (Friend.RivalDef != null)
			{
				_avatarImage.overrideSprite = Friend.RivalDef.Icon;
				_statusText.text = Friend.RivalDef.FoundationName.Translation;
			}
			else
			{
				if (Friend.OnlinePlayerID == OnlinePlayerID.Nil)
				{
					_avatarImage.overrideSprite = OnlineManager.DefaultAvatarSprite;
					_statusText.text = string.Empty;
					return;
				}
				Sprite avatar = OnlineManager.GetAvatar(Friend.OnlinePlayerID);
				_avatarImage.overrideSprite = avatar;
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(Friend.OnlinePlayerID);
				_statusText.text = ((playerInfo != null) ? playerInfo.DisplayName : string.Empty);
			}
			IsEnabled = !disableIfNotSelected || isSelected;
			_backingImage.color = ((!IsEnabled) ? _tintDisabled : (isSelected ? _tintSelected : _tintDefault));
		}

		public void OnButtonPressed()
		{
			if (IsEnabled)
			{
				_owner.OnRivalSelected(this);
			}
		}
	}
}
