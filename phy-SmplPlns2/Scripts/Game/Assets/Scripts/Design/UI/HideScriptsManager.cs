using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class HideScriptsManager
	{
		private List<HideScript> _hidden = new List<HideScript>();

		private List<HideScript> _shown = new List<HideScript>();

		public static HideScriptsManager HideForScreenshot(Transform transform)
		{
			HideScriptsManager hideScriptsManager = new HideScriptsManager();
			HideScript[] componentsInChildren = transform.GetComponentsInChildren<HideScript>(includeInactive: true);
			foreach (HideScript hideScript in componentsInChildren)
			{
				if (hideScript.HideDuringScreenshot)
				{
					hideScript.gameObject.SetActive(value: false);
					hideScriptsManager._hidden.Add(hideScript);
				}
			}
			return hideScriptsManager;
		}

		public void Restore()
		{
			foreach (HideScript item in _hidden)
			{
				item.gameObject.SetActive(value: true);
			}
			foreach (HideScript item2 in _shown)
			{
				item2.gameObject.SetActive(value: false);
			}
			_hidden.Clear();
			_shown.Clear();
		}
	}
}
