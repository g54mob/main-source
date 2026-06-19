using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class PlayerOnlineStatus : MonoBehaviour
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private Sprite _activePlayerSprite;

		[SerializeField]
		private Sprite _inactivePlayerSprite;

		private OnlinePlayerID _playerID;

		public OnlinePlayerID PlayerID
		{
			get
			{
				return _playerID;
			}
			set
			{
				_playerID = value;
				Refresh();
			}
		}

		private void OnEnable()
		{
			Refresh();
		}

		public void Refresh()
		{
			if (OnlineManager.IsInitializedAndLoggedOn() && !(_image == null) && !(_activePlayerSprite == null) && !(_inactivePlayerSprite == null))
			{
				bool flag = false;
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(_playerID);
				if (playerInfo != null)
				{
					flag = playerInfo.IsPlayingGame();
				}
				_image.overrideSprite = (flag ? _activePlayerSprite : _inactivePlayerSprite);
			}
		}
	}
}
