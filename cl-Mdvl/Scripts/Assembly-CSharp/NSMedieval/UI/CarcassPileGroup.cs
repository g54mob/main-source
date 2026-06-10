using NSMedieval.State;
using NSMedieval.StatsSystem;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class CarcassPileGroup : ResourcePileOverviewGroup
	{
		[SerializeField]
		private TMP_Text resourceFreshness;

		[SerializeField]
		private TMP_Text resourceOwnerName;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			resourceOwnerName.SetText(instance.GetStoredResource()?.LocalizedInheritedName);
			OnFreshnessChanged();
		}

		private void OnFreshnessChanged()
		{
			if (!(resourceFreshness == null) && base.PileInstance != null && !base.PileInstance.HasDisposed)
			{
				resourceFreshness.SetText(GetStatValue(StatType.Freshness));
			}
		}
	}
}
