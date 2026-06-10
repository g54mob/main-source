using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class FoodPileGroup : CountablePileGroup
	{
		[SerializeField]
		private TMP_Text resourceFreshness;

		[SerializeField]
		private TMP_Text resourceNutrition;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			UpdateFreshness();
			OnNutritionChanged();
		}

		public override bool Unsubscribe()
		{
			if (!base.Unsubscribe())
			{
				return false;
			}
			base.PileInstance.Stats?.Controller.RemoveListener(OnFreshnessChanged);
			return true;
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			base.PileInstance.Stats?.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Freshness, OnFreshnessChanged);
		}

		protected override void OnCountUpdate(ResourcePileInstance pileInstance, Resource resource, int count)
		{
			base.OnCountUpdate(pileInstance, resource, count);
			OnNutritionChanged();
		}

		private void OnFreshnessChanged(object stat)
		{
			UpdateFreshness();
		}

		private void UpdateFreshness()
		{
			if (!(resourceFreshness == null) && base.PileInstance != null && !base.PileInstance.HasDisposed)
			{
				resourceFreshness.SetText(GetStatValue(StatType.Freshness));
			}
		}

		protected void OnNutritionChanged()
		{
			if (!(resourceNutrition == null) && base.PileInstance != null && !base.PileInstance.HasDisposed && base.PileInstance.BlueprintExists)
			{
				resourceNutrition.SetText($"{base.PileInstance.GetNutrition()}");
			}
		}
	}
}
