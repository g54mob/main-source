using System;
using CTS.Emotes;
using CTS.StockInventory;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class AgentActionVomitBlood : AgentActionVomit
	{
		private static readonly string _emoteRef = "<sprite=\"Emoji_Machine\" index=\"2\">";

		private static readonly Color _emoteColor = new Color(0.54f, 0.11f, 0.13f);

		private static readonly Resource<StockItemSO> BloodSO = new Resource<StockItemSO>("Scriptables/Stockables/BloodbagOPlus");

		protected override void VomitAtPosition(Vector3 pos)
		{
			base.ActionAgent.Animator.Events.TriggerVFX("VomitBlood");
			JunkObject.Spawn(AgentActionVomit.PfbBloodPuddle, pos, Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 1f));
			base.ActionAgent.VFXManager.Kill(PowerBloodyVomit.HeadLoopVFX);
		}

		public override void OnComplete()
		{
			base.OnComplete();
			base.ActionAgent.VFXManager.Kill(PowerBloodyVomit.HeadLoopVFX);
			base.ActionAgent.Health.Damage(10);
			StockCapacity stockTypeCapacity = Stocks.BarStock.GetStockTypeCapacity(Stocks.VampireStockType);
			int val = stockTypeCapacity.MaxCapacity.Value - stockTypeCapacity.CurrentCapacity;
			val = Math.Min(10, val);
			if (val > 0)
			{
				float quality = ((base.ActionAgent is Customer customer) ? customer.BloodQuality : 5);
				StockStack itemStack = new StockStack(BloodSO, val, quality);
				Stocks.TryAdd(ref itemStack);
				EmoteManagerBBT.Play(base.ActionAgent, $"{_emoteRef} +{val - itemStack.StackCount}").SetBackgroundColor(_emoteColor);
			}
		}

		public override void OnCancel()
		{
			base.OnCancel();
			base.ActionAgent.VFXManager.Kill(PowerBloodyVomit.HeadLoopVFX);
		}
	}
}
