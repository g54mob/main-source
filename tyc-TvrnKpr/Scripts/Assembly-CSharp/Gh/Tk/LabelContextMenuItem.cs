using UnityEngine;

namespace Gh.Tk
{
	public class LabelContextMenuItem : ContextMenuItem
	{
		public string LabelKey;

		protected LabelContextMenuItem(string labelKey, string prefabName, TooltipData tooltipData)
			: base(null)
		{
		}

		public LabelContextMenuItem(string labelKey, TooltipData tooltipData = null)
			: base(null)
		{
		}

		public override GameObject CreateGameObject(Transform where)
		{
			return null;
		}
	}
}
