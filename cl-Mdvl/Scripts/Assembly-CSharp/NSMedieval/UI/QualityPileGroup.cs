using NSMedieval.State;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class QualityPileGroup : ResourcePileOverviewGroup
	{
		[SerializeField]
		private TMP_Text resourceQuality;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			string key = ((instance.GetQuality() == ProductQuality.None) ? string.Empty : $"quality_{instance.GetQuality()}");
			resourceQuality.SetText(base.Localize.GetText(key));
		}
	}
}
