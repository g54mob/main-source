using System.Collections.Generic;
using System.Numerics;
using Assets.Behaviour.Util;
using Assets.Source.Item;
using Assets.Source.Player;
using LightJson;

namespace Assets.Source.World
{
	public class AutoCrafter : AutoWorker
	{
		protected UITimerBar _activeCooldown;

		private float _inactivityDelay;

		protected new CraftingFrame Parent => base.Parent as CraftingFrame;

		public float TimeRequired { get; protected set; }

		public float TimeAccumulated { get; protected set; }

		public int CraftCount { get; protected set; }

		public AutoCrafter(CraftingFrame parent, WorldAnchor slot)
			: base(parent, slot)
		{
			_inactivityDelay = 1f;
		}

		public override void SetupActiveFrame(ActiveWorldFrame frame)
		{
			if (TimeRequired != 0f)
			{
				_activeCooldown = frame.TriggerCooldown(Slot, TimeRequired);
				_activeCooldown.UpdateTimeSpent(TimeAccumulated);
				frame.TriggerGizmoStart(Slot);
			}
		}

		public override void ActiveUpdate(float delta)
		{
			if (_inactivityDelay > 0f)
			{
				_inactivityDelay -= delta;
				return;
			}
			if (TimeRequired == 0f)
			{
				if (!InitStartCrafting())
				{
					_inactivityDelay = 3f;
					return;
				}
				TimeRequired = Parent.GetCraftingTime(handCraft: false);
				TimeAccumulated = 0f;
				_activeCooldown = Parent.ActiveFrame?.TriggerCooldown(Slot, TimeRequired);
				Parent.ActiveFrame?.TriggerGizmoStart(Slot);
			}
			TimeAccumulated += delta;
			if (TimeAccumulated >= TimeRequired)
			{
				Parent.ActiveFrame?.TriggerGizmoStop(Slot);
				if (DoCraftingResult())
				{
					TimeRequired = 0f;
				}
				else
				{
					_inactivityDelay = 1f;
				}
			}
		}

		public void UpdateTimeRequired(float newTime)
		{
			if (TimeRequired > 0f)
			{
				float num = TimeAccumulated / TimeRequired;
				TimeRequired = newTime;
				TimeAccumulated = TimeRequired * num;
				if ((bool)_activeCooldown)
				{
					_activeCooldown.UpdateTime(TimeRequired, TimeAccumulated);
				}
			}
		}

		public virtual bool InitStartCrafting()
		{
			foreach (KeyValuePair<ItemType, BigInteger> result in Parent.GetResults())
			{
				if (!GamePlayer.Current.CanAddInventoryItem(result.Key, result.Value))
				{
					Parent.ActiveFrame?.ShowWarning(Slot, "@WarningStorageFull");
					return false;
				}
			}
			if (!Parent.CanStartCrafting(Slot))
			{
				return false;
			}
			CraftCount = Parent.ConsumeReagentsForCraft(Slot);
			if (CraftCount == 0)
			{
				return false;
			}
			return true;
		}

		protected virtual bool DoCraftingResult()
		{
			IEnumerable<KeyValuePair<ItemType, BigInteger>> results = Parent.GetResults();
			if (Parent.ServitudeLevel > 0 && !GamePlayer.Current.CanAddInventoryItem(ItemType.HumanRemains, CraftCount))
			{
				Parent.ActiveFrame?.ShowWarning(Slot, "@WarningHumanRemains");
				SteamAchievement.Trigger("HumanRemainsFull");
				return false;
			}
			if (Slot.AnchorType != WorldAnchorType.HandCraft)
			{
				foreach (KeyValuePair<ItemType, BigInteger> item in results)
				{
					if (!GamePlayer.Current.CanAddInventoryItem(item.Key, item.Value * CraftCount))
					{
						return false;
					}
				}
			}
			else if ((bool)Parent.ActiveFrame && Parent.ActiveFrame.isActiveAndEnabled)
			{
				UISounds.CraftFinished();
			}
			ExecuteCraftingResult(results);
			return true;
		}

		protected virtual void ExecuteCraftingResult(IEnumerable<KeyValuePair<ItemType, BigInteger>> results)
		{
			Parent.TriggerCraftingResult(Slot);
			if (Parent.ServitudeLevel > 0 && SeededRandom.Global.RandomBool(0.2f * (float)Parent.ServitudeLevel))
			{
				GamePlayer.Current.AddInventoryItem(ItemType.HumanRemains, CraftCount, addToStats: true, this is ManualCrafter);
				SteamStatsManager.ItemProduced(ItemType.HumanRemains, CraftCount, this is ManualCrafter);
				Parent.ActiveFrame?.ShowItemCrafted(Slot, ItemType.HumanRemains, CraftCount, -1f);
			}
			float num = 0f;
			foreach (KeyValuePair<ItemType, BigInteger> result in results)
			{
				double num2 = (double)result.Value * (double)CraftCount * Parent.GetProductivityMultiplier(this is ManualCrafter);
				double num3 = num2 % 1.0;
				num2 -= num3;
				if (SeededRandom.Global.RandomBool(num3))
				{
					num2 += 1.0;
				}
				BigInteger count = new BigInteger(num2);
				GamePlayer.Current.AddInventoryItem(result.Key, count, addToStats: true, this is ManualCrafter);
				SteamStatsManager.ItemProduced(result.Key, count, this is ManualCrafter);
				Parent.OnItemAutocrafted(result.Key, count);
				Parent.ActiveFrame?.ShowItemCrafted(Slot, result.Key, count, num);
				num += 1f;
			}
		}

		public override JsonValue ToJson()
		{
			JsonValue result = base.ToJson();
			result["TimeRequired"] = TimeRequired;
			result["TimeAccumulated"] = TimeAccumulated;
			result["CraftCount"] = CraftCount;
			result["InactivityDelay"] = _inactivityDelay;
			return result;
		}

		public override void LoadFromJson(JsonValue val)
		{
			TimeRequired = (float)val["TimeRequired"].AsNumber;
			TimeAccumulated = (float)val["TimeAccumulated"].AsNumber;
			CraftCount = val["CraftCount"];
			_inactivityDelay = (int)val["InactivityDelay"];
		}
	}
}
