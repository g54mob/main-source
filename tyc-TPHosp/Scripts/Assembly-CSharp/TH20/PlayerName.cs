using TMPro;
using UnityEngine;

namespace TH20
{
	public class PlayerName : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _label;

		private OnlinePlayerID _playerID;

		public TMP_Text Label => _label;

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
			if (OnlineManager.IsInitializedAndLoggedOn() && !(_label == null))
			{
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(_playerID);
				_label.text = ((playerInfo != null) ? playerInfo.DisplayName : string.Empty);
			}
		}
	}
}
