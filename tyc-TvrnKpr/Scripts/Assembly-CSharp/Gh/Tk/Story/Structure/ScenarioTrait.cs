using System;
using System.Collections.Generic;

namespace Gh.Tk.Story.Structure
{
	[Serializable]
	public struct ScenarioTrait
	{
		public string key;

		private static Dictionary<string, List<string>> _disabledScenarioSettings;

		public string GetCodexKey()
		{
			return null;
		}

		public TooltipData GetTooltipData()
		{
			return null;
		}

		public bool IsSettingAllowed(string attrPropertyName)
		{
			return false;
		}
	}
}
