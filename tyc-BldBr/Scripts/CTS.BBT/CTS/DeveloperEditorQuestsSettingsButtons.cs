using System;
using CTS.DevConsole;
using UnityEngine;

namespace CTS
{
	public class DeveloperEditorQuestsSettingsButtons : MonoBehaviour
	{
		public void ForceCurrentQuestSuccess()
		{
			DeveloperConsole.ExecuteCommand<CommandForceCurrentMainQuestSuccess>(Array.Empty<string>());
		}

		public void ForceSelectedQuestSuccess()
		{
			DeveloperConsole.ExecuteCommand<CommandForceSelectedQuestSuccess>(Array.Empty<string>());
		}
	}
}
