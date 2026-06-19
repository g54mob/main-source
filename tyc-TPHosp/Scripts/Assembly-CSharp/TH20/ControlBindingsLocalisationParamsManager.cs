#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using I2.Loc;
using Rewired;

namespace TH20
{
	public class ControlBindingsLocalisationParamsManager : MustCallDestroy, ILocalizationParamsManager
	{
		private readonly Dictionary<string, string> _actionControlNameMapping = new Dictionary<string, string>();

		public ControlBindingsLocalisationParamsManager()
		{
			LocalizationManager.ParamManagers.Add(this);
		}

		public override void Destroy()
		{
			LocalizationManager.ParamManagers.Remove(this);
			base.Destroy();
		}

		public void UpdateMapping()
		{
			Logging.Info(LogChannels.Localisation, "Updating control bindings localisation parameters");
			_actionControlNameMapping.Clear();
			List<InputAction> list = new List<InputAction>(128);
			IList<ControllerMap> maps = ReInput.players.GetPlayer(0).controllers.maps.GetMaps(ControllerType.Keyboard, 0);
			ControllerMap controllerMap = ((maps.Count > 0) ? maps[0] : null);
			list.AddRange(ReInput.mapping.ActionsInCategory("Default", sort: true));
			list.AddRange(ReInput.mapping.ActionsInCategory("Camera", sort: true));
			list.AddRange(ReInput.mapping.ActionsInCategory("Build Room", sort: true));
			list.AddRange(ReInput.mapping.ActionsInCategory("Main Menu", sort: true));
			list.RemoveAll((InputAction a) => !a.userAssignable);
			foreach (InputAction item in list)
			{
				if (item.type == InputActionType.Button)
				{
					IEnumerator<ActionElementMap> enumerator2 = controllerMap.ButtonMapsWithAction(item.id).GetEnumerator();
					enumerator2.MoveNext();
					ActionElementMap current2 = enumerator2.Current;
					if (current2 != null)
					{
						_actionControlNameMapping.Add(item.descriptiveName, "Misc/KeyCode/" + current2.keyboardKeyCode);
					}
					else
					{
						_actionControlNameMapping.Add(item.descriptiveName, "Misc/UnassignedKey_CS");
					}
					enumerator2.Dispose();
				}
			}
			Logging.Info(LogChannels.Localisation, "{0} parameters found", _actionControlNameMapping.Count);
		}

		string ILocalizationParamsManager.GetParameterValue(string param)
		{
			if (_actionControlNameMapping.TryGetValue(param, out var value))
			{
				return LocalizationManager.GetTranslation(value);
			}
			return null;
		}
	}
}
