using System;
using System.Collections.Generic;

namespace NSMedieval.UI
{
	public class PromptPanelData
	{
		private string promptTextKey;

		private bool blurBackground;

		private List<KeyValuePair<string, Action>> buttonActions;

		private List<KeyValuePair<string, CustomButtonAction>> customButtonActions;

		public string PromptTextKey => promptTextKey;

		public List<KeyValuePair<string, Action>> ButtonActions => buttonActions;

		public List<KeyValuePair<string, CustomButtonAction>> CustomButtonActions => customButtonActions;

		public bool BlurBackground => blurBackground;

		public PromptPanelData(string promptText, bool blurBackground = true)
		{
			promptTextKey = promptText;
			this.blurBackground = blurBackground;
		}

		public PromptPanelData(string promptText, List<KeyValuePair<string, Action>> buttonActions, bool blurBackground = true)
		{
			promptTextKey = promptText;
			this.buttonActions = buttonActions;
			this.blurBackground = blurBackground;
		}

		public PromptPanelData(string promptText, List<KeyValuePair<string, CustomButtonAction>> buttonActions, bool blurBackground = true)
		{
			promptTextKey = promptText;
			customButtonActions = buttonActions;
			this.blurBackground = blurBackground;
		}
	}
}
