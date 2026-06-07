using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Input;
using Jundroo.Juicy;
using Jundroo.SocialPlatforms;

namespace Assets.Scripts.UI
{
	public class TooltipService : ITooltipService
	{
		private Dictionary<string, IGameInput> _gameInputs;

		private bool _ignoreKeyboardShortcuts;

		public TooltipService()
		{
			_ignoreKeyboardShortcuts = SocialExt.IsSteam && (SocialExt.Steam.IsRunningOnSteamDeck() || SocialExt.Steam.IsRunningInBigPicture());
		}

		public string ProcessTooltipText(string text)
		{
			EnsureGameInputsInitialized();
			foreach (Match item in Regex.Matches(text, "\\[.+?\\]"))
			{
				string key = item.Value.ToLower();
				if (_gameInputs.ContainsKey(key))
				{
					IGameInput gameInput = _gameInputs[key];
					string[] array = new string[4]
					{
						_ignoreKeyboardShortcuts ? null : gameInput.GetKeyboardPrimaryBindingText(),
						_ignoreKeyboardShortcuts ? null : gameInput.GetKeyboardSecondaryBindingText(),
						gameInput.GetMouseBindingText(),
						gameInput.GetControllerBindingText()
					};
					if (array[1] == array[0])
					{
						array[1] = null;
					}
					string text2 = string.Join(", ", array.Where((string x) => !string.IsNullOrEmpty(x)).ToArray());
					text = text.Replace(newValue: (!string.IsNullOrEmpty(text2)) ? ("<b>" + text2 + "</b>") : "[not set]", oldValue: item.Value);
				}
			}
			return text;
		}

		private void EnsureGameInputsInitialized()
		{
			if (_gameInputs != null)
			{
				return;
			}
			_gameInputs = new Dictionary<string, IGameInput>();
			foreach (string allActionId in InputWrapper.GetAllActionIds())
			{
				IGameInput gameInput = GameInputs.Instance.FindById(allActionId);
				if (gameInput != null)
				{
					_gameInputs.Add("[" + allActionId.ToLower() + "]", gameInput);
				}
			}
		}
	}
}
