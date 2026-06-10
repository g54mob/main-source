using NSMedieval.State;
using NSMedieval.StatsSystem;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class FermentingPileGroup : FoodPileGroup
	{
		[SerializeField]
		private TMP_Text resourceFermentation;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			UpdateFermentation();
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			base.PileInstance.Stats?.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Fermentation, OnFermentationChanged);
		}

		public override bool Unsubscribe()
		{
			if (!base.Unsubscribe())
			{
				return false;
			}
			base.PileInstance.Stats?.Controller.RemoveListener(OnFermentationChanged);
			return true;
		}

		private void OnFermentationChanged(object stat)
		{
			UpdateFermentation();
		}

		private void UpdateFermentation()
		{
			if (!(resourceFermentation == null) && base.PileInstance != null && !base.PileInstance.HasDisposed)
			{
				resourceFermentation.SetText(GetStatValue(StatType.Fermentation));
			}
		}
	}
}
