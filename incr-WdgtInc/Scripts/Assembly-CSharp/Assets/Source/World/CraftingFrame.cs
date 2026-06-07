using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Buff;
using Assets.Source.Item;
using Assets.Source.Util;

namespace Assets.Source.World
{
	public abstract class CraftingFrame : WorldFrame
	{
		protected Dictionary<ItemType, BigInteger> _reagents = new Dictionary<ItemType, BigInteger>();

		protected Dictionary<ItemType, BigInteger> _results = new Dictionary<ItemType, BigInteger>();

		protected float _baseCraftingTime = 1f;

		protected float _autoCraftingTime = 6f;

		protected ManualCrafter[] _manualCrafters;

		public virtual int HandCraftButtonCount => 1;

		public virtual float TimePerClick => 0f;

		public virtual IEnumerable<KeyValuePair<ItemType, BigInteger>> GetReagents()
		{
			return _reagents;
		}

		public virtual IEnumerable<KeyValuePair<ItemType, BigInteger>> GetResults()
		{
			return _results;
		}

		public virtual float GetCraftingTime(bool handCraft)
		{
			if (!handCraft)
			{
				return _autoCraftingTime / GetSpeedMultiplier(handCraft: false);
			}
			return _baseCraftingTime / GetSpeedPenaltyMultiplier();
		}

		public CraftingFrame()
		{
			_manualCrafters = new ManualCrafter[HandCraftButtonCount];
			for (int i = 0; i < _manualCrafters.Length; i++)
			{
				_manualCrafters[i] = CreateHandCrafter(new WorldAnchor(WorldAnchorType.HandCraft, i));
			}
		}

		public virtual double GetMaxProduction(ItemType type)
		{
			foreach (KeyValuePair<ItemType, BigInteger> result in _results)
			{
				if (result.Key == type)
				{
					return GameMath.Divide(result.Value, GetCraftingTime(handCraft: false)) * (double)AutoWorkerMax * GetProductivityMultiplier(handCraft: false) * GetParallelMultiplier(handCraft: false);
				}
			}
			return 0.0;
		}

		public override void SetupActiveFrame(ActiveWorldFrame frame)
		{
			base.SetupActiveFrame(frame);
			ManualCrafter[] manualCrafters = _manualCrafters;
			for (int i = 0; i < manualCrafters.Length; i++)
			{
				manualCrafters[i].SetupActiveFrame(frame);
			}
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			for (int i = 0; i < _manualCrafters.Length; i++)
			{
				if (_manualCrafters[i] != null)
				{
					_manualCrafters[i].Update(delta);
				}
			}
		}

		public override void ButtonClicked(WorldAnchor anchor)
		{
			base.ButtonClicked(anchor);
			if (anchor.AnchorType == WorldAnchorType.HandCraft)
			{
				DoManualCraft(anchor);
			}
		}

		public virtual bool CanStartCrafting(WorldAnchor slot)
		{
			return true;
		}

		public int ConsumeReagentsForCraft(WorldAnchor sourceSlot, double maxCount = -1.0)
		{
			if (maxCount == -1.0)
			{
				maxCount = GetParallelMultiplier(sourceSlot.AnchorType == WorldAnchorType.HandCraft || sourceSlot.AnchorType == WorldAnchorType.Custom);
			}
			int num = (int)maxCount;
			if (maxCount > (double)num && SeededRandom.Global.RandomBool((float)(maxCount % 1.0)))
			{
				num++;
			}
			return CheckAndPayCost(sourceSlot, GetReagents(), num, addToStats: true);
		}

		public virtual void DoManualCraft(WorldAnchor anchor)
		{
			_manualCrafters[anchor.Slot].Start();
		}

		public virtual ManualCrafter GetManualCrafter(int slot)
		{
			return _manualCrafters[slot];
		}

		public virtual ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			if (TimePerClick > 0f)
			{
				return new ClickerCrafter(this, slot);
			}
			return new ManualCrafter(this, slot);
		}

		public override AutoWorker CreateAutoWorker(WorldAnchor slot)
		{
			return new AutoCrafter(this, slot);
		}

		public BigInteger GetRecipeResultCount(ItemType type)
		{
			_results.TryGetValue(type, out var value);
			return value;
		}

		public virtual void TriggerCraftingResult(WorldAnchor slot)
		{
		}

		public virtual void OnItemAutocrafted(ItemType i, BigInteger count)
		{
		}

		public override bool AddBuff(FrameBuff fb)
		{
			bool flag = base.AddBuff(fb);
			if (flag && fb.GetSpeedMultiplier(this, handCraft: false) != 1.0)
			{
				float craftingTime = GetCraftingTime(handCraft: false);
				for (int i = 0; i < _workers.Length; i++)
				{
					((AutoCrafter)_workers[i])?.UpdateTimeRequired(craftingTime);
				}
			}
			return flag;
		}
	}
}
