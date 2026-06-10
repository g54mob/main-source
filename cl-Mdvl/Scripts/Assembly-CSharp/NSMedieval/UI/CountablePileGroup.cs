using NSMedieval.Model;
using NSMedieval.State;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class CountablePileGroup : ResourcePileOverviewGroup
	{
		[SerializeField]
		private TMP_Text resourceCount;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			OnCountChanged();
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			base.PileInstance.OnResourceAddedEvent += OnCountUpdate;
			base.PileInstance.OnResourceTakenEvent += OnCountUpdate;
		}

		public override bool Unsubscribe()
		{
			if (!base.Unsubscribe())
			{
				return false;
			}
			base.PileInstance.OnResourceAddedEvent -= OnCountUpdate;
			base.PileInstance.OnResourceTakenEvent -= OnCountUpdate;
			return true;
		}

		protected virtual void OnCountUpdate(ResourcePileInstance pileInstance, Resource resource, int count)
		{
			if (base.PileInstance == pileInstance)
			{
				OnCountChanged();
				OnValueChanged();
				OnWeightChanged();
			}
		}

		private void OnCountChanged()
		{
			resourceCount.SetText(GetCount().ToString());
		}
	}
}
