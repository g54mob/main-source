using System.Collections.Generic;
using Assets.Source.Item;

namespace Assets.Source.World
{
	public abstract class CraftingFrame : WorldFrame
	{
		protected Dictionary<ItemType, int> _reagents = new Dictionary<ItemType, int>();

		protected Dictionary<ItemType, int> _results = new Dictionary<ItemType, int>();

		protected float _baseCraftingTime = 1f;

		protected float _autoCraftingTime = 6f;

		protected ManualCrafter[] _manualCrafters;

		public virtual int HandCraftButtonCount => 1;

		public virtual float TimePerClick => 0f;

		public virtual Dictionary<ItemType, int> GetReagents()
		{
			return _reagents;
		}

		public virtual Dictionary<ItemType, int> GetResults()
		{
			return _results;
		}

		public virtual float GetCraftingTime(bool handCraft)
		{
			if (!handCraft)
			{
				return _autoCraftingTime / GetSpeedMultiplier();
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

		public int ConsumeReagentsForCraft(WorldAnchor sourceSlot, float maxCount = -1f)
		{
			if (maxCount == -1f)
			{
				maxCount = GetParallelMultiplier(sourceSlot.AnchorType == WorldAnchorType.HandCraft || sourceSlot.AnchorType == WorldAnchorType.Custom);
			}
			int num = (int)maxCount;
			if (maxCount > (float)num && SeededRandom.Global.RandomBool(maxCount % 1f))
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

		public IEnumerable<KeyValuePair<ItemType, int>> GetRecipeReagents()
		{
			return _reagents;
		}

		public IEnumerable<KeyValuePair<ItemType, int>> GetRecipeResults()
		{
			return _results;
		}

		public int GetRecipeResultCount(ItemType type)
		{
			_results.TryGetValue(type, out var value);
			return value;
		}

		public virtual void TriggerCraftingResult(WorldAnchor slot)
		{
		}
	}
}
