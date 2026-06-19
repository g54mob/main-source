using JSAM;
using Loxodon.Framework.Binding;
using UnityEngine;

namespace UI.HUD.SystemInfo
{
	public class SystemInfoMessageSender : MonoBehaviour
	{
		[Header("Icons")]
		[SerializeField]
		private Sprite _saveIcon;

		[SerializeField]
		private Sprite _moneyIcon;

		[Space(5f)]
		[SerializeField]
		private SystemInfoView _systemInfoView;

		private SystemInfoViewModel _systemInfoViewModel;

		private void Start()
		{
			_systemInfoViewModel = _systemInfoView.GetDataContext() as SystemInfoViewModel;
		}

		public void SendSaveMessage()
		{
			_systemInfoViewModel.SendMessage("Game Successfuly Saved!", _saveIcon);
			AudioManager.PlaySound(UILibrarySounds.UINotificationPSStyle);
		}

		public void SendMoneyMessage(double addedValue)
		{
			string arg = "";
			if (addedValue >= 0.0)
			{
				arg = "+";
			}
			_systemInfoViewModel.SendMessage($"{arg}{addedValue} FlyCoins", _moneyIcon);
			AudioManager.PlaySound(UILibrarySounds.UIMoney);
		}
	}
}
