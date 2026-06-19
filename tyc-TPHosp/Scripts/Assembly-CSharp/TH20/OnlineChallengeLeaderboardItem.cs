using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class OnlineChallengeLeaderboardItem : MonoBehaviour
	{
		[SerializeField]
		private Image _avatar;

		[SerializeField]
		private Image _aiAvatar;

		[SerializeField]
		private TMP_Text _nameLabel;

		[SerializeField]
		private TMP_Text _scoreLabel;

		[SerializeField]
		private Image _backing;

		public void Setup(OnlineChallengeObjective.PlayerInfo playerInfo, float score)
		{
			_nameLabel.text = playerInfo.PlayerName;
			_scoreLabel.text = score.ToString("N0");
			if (_backing != null)
			{
				_backing.color = playerInfo.PlayerColor;
			}
			if (playerInfo.IsAI)
			{
				GameObjectUtils.SetActive(_aiAvatar.gameObject, isActive: true);
				GameObjectUtils.SetActive(_avatar.gameObject, isActive: false);
				if (playerInfo.AIScoreData != null)
				{
					_aiAvatar.overrideSprite = playerInfo.RivalIcon;
					_aiAvatar.color = Color.white;
				}
				else
				{
					_aiAvatar.overrideSprite = OnlineManager.DefaultAvatarSprite;
					_aiAvatar.color = playerInfo.PlayerColor;
				}
				return;
			}
			GameObjectUtils.SetActive(_aiAvatar.gameObject, isActive: false);
			GameObjectUtils.SetActive(_avatar.gameObject, isActive: true);
			if (playerInfo.OnlinePlayerID != OnlinePlayerID.Nil)
			{
				Sprite avatar = OnlineManager.GetAvatar(playerInfo.OnlinePlayerID);
				_avatar.overrideSprite = avatar;
				_avatar.color = Color.white;
			}
			else if (playerInfo.IsLocalPlayer)
			{
				_avatar.overrideSprite = OnlineManager.DefaultOrganisationSprite;
				_avatar.color = Color.white;
			}
			else
			{
				_avatar.overrideSprite = OnlineManager.DefaultAvatarSprite;
				_avatar.color = playerInfo.PlayerColor;
			}
		}
	}
}
