using NSEipix.Model;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ScenarioEditIntIconView : ScenarioEditIntView
	{
		[SerializeField]
		private Image icon;

		public void SetDefaults(string path, string colorOVerlay, string label, IntRange minMaxRange, int currentValue, string suffix = "")
		{
			icon.sprite = AssetUtils.GetSprite(path);
			SetDefaults(label, minMaxRange, currentValue, suffix);
		}
	}
}
