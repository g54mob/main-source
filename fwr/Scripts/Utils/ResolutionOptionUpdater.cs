using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResolutionOptionUpdater : MonoBehaviour
{
	private static DropdownOptionSO resolutionOptionSO;

	private static DisplayInfo lastDisplay;

	public static void UpdateOptions()
	{
		if (resolutionOptionSO == null)
		{
			resolutionOptionSO = Resources.Load<DropdownOptionSO>("Options/resolution");
			if (resolutionOptionSO == null)
			{
				Debug.LogError("Failed to load 'resolution' options resource");
				return;
			}
		}
		DisplayInfo mainWindowDisplayInfo = Screen.mainWindowDisplayInfo;
		if (!lastDisplay.Equals(mainWindowDisplayInfo))
		{
			lastDisplay = mainWindowDisplayInfo;
			resolutionOptionSO.defaultValue = $"{Screen.currentResolution.width}x{Screen.currentResolution.height}";
			DropdownOptionSO dropdownOptionSO = resolutionOptionSO;
			if (dropdownOptionSO.options == null)
			{
				dropdownOptionSO.options = new List<string>();
			}
			resolutionOptionSO.options.Clear();
			resolutionOptionSO.options.AddRange((from r in Screen.resolutions
				orderby r.width * r.height descending
				select $"{r.width}x{r.height}").Distinct());
			string text = OptionHolder.GetString(resolutionOptionSO.optionName, null);
			if (!string.IsNullOrEmpty(text) && !resolutionOptionSO.options.Contains(text))
			{
				resolutionOptionSO.options.Insert(0, text);
			}
			resolutionOptionSO.TriggerOptionChanged();
		}
	}

	private void Update()
	{
		DisplayInfo mainWindowDisplayInfo = Screen.mainWindowDisplayInfo;
		if (!lastDisplay.Equals(mainWindowDisplayInfo))
		{
			UpdateOptions();
		}
	}
}
