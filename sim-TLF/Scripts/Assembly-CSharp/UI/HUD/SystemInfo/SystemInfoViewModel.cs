using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace UI.HUD.SystemInfo
{
	public class SystemInfoViewModel : ViewModelBase
	{
		public ObservableList<SystemInfoMessageViewModel> Messages = new ObservableList<SystemInfoMessageViewModel>();

		public void SendMessage(string text, Sprite icon, float time = 2f)
		{
			SystemInfoMessageViewModel item = new SystemInfoMessageViewModel(text, icon, time);
			Messages.Add(item);
		}
	}
}
