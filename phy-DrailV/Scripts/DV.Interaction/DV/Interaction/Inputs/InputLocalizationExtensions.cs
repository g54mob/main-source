using System.Collections.Generic;
using System.Linq;
using DV.Localization;
using I2.Loc;
using Rewired;
using UnityEngine;

namespace DV.Interaction.Inputs
{
	public static class InputLocalizationExtensions
	{
		private static Dictionary<int, string> cachedActionKeybindings = new Dictionary<int, string>();

		private static string Unbound => LocalizationAPI.L("keybinding/unbound");

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			InputManager.KeybindingsChanged += delegate
			{
				cachedActionKeybindings.Clear();
			};
			LocalizationManager.OnLocalizeEvent += delegate
			{
				cachedActionKeybindings.Clear();
			};
		}

		private static int Hash(int actionID, AxisRange axisRange)
		{
			return actionID + ((int)axisRange << 16);
		}

		public static string LocalizeInput(this int actionID, AxisRange axisRange = AxisRange.Full)
		{
			int key = Hash(actionID, axisRange);
			if (cachedActionKeybindings.TryGetValue(key, out var value))
			{
				return value;
			}
			ActionElementMap actionElementMap = InputManager.NewPlayer.controllers.maps.GetAllMaps().SelectMany((ControllerMap m) => m.GetButtonMapsWithAction(actionID)).Where(delegate(ActionElementMap m)
			{
				Pole axisContribution = m.axisContribution;
				int num = (int)axisContribution;
				if (num != 0)
				{
					if (num == 1 && axisRange == AxisRange.Positive)
					{
						goto IL_0026;
					}
				}
				else if (axisRange == AxisRange.Negative)
				{
					goto IL_0026;
				}
				return true;
				IL_0026:
				return false;
			})
				.FirstOrDefault();
			value = ((actionElementMap != null) ? actionElementMap.elementIdentifierName : Unbound);
			cachedActionKeybindings[key] = value;
			return value;
		}
	}
}
