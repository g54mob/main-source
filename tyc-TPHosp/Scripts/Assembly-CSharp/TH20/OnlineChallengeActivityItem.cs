using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class OnlineChallengeActivityItem : MonoBehaviour
	{
		[SerializeField]
		private Image _avatarImage;

		[SerializeField]
		private TMP_Text _eventText;

		public void Setup(OnlineChallengeEventLog.ActivityItem item)
		{
			if (item == null)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			if (item.PlayerInfo != null && item.PlayerInfo.OnlinePlayerID != OnlinePlayerID.Nil)
			{
				Sprite avatar = OnlineManager.GetAvatar(item.PlayerInfo.OnlinePlayerID);
				if (avatar != null)
				{
					_avatarImage.overrideSprite = avatar;
					_avatarImage.color = Color.white;
				}
				else
				{
					_avatarImage.overrideSprite = OnlineManager.DefaultAvatarSprite;
					_avatarImage.color = item.PlayerInfo.PlayerColor;
				}
			}
			else if (item.PlayerInfo.IsLocalPlayer)
			{
				_avatarImage.overrideSprite = OnlineManager.DefaultOrganisationSprite;
				_avatarImage.color = Color.white;
			}
			else
			{
				_avatarImage.overrideSprite = OnlineManager.DefaultAvatarSprite;
				_avatarImage.color = item.PlayerInfo.PlayerColor;
			}
			_eventText.text = item.ActivityString;
			_eventText.color = Color.black;
			base.gameObject.SetActive(value: true);
		}
	}
}
