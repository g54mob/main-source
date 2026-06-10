using System;
using NSEipix.Base;

namespace NSMedieval.Controllers
{
	public class SettingsController : MonoSingleton<SettingsController>
	{
		public event Action KeybindingsSavedEvent;

		private SettingsController()
		{
		}

		public void SaveKeybindings(Keybinding[] keybindings)
		{
			MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.SetKeybindings(keybindings);
			this.KeybindingsSavedEvent?.Invoke();
		}
	}
}
