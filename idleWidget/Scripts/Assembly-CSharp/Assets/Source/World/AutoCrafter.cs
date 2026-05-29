using System.Collections.Generic;
using Assets.Behaviour.Util;
using Assets.Source.Item;
using Assets.Source.Player;
using LightJson;
using UnityEngine;

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
			foreach (KeyValuePair<ItemType, int> result in Parent.GetResults())
			{
				if (!GamePlayer.Current.CanAddInventoryItem(result.Key, result.Value))
				{
					Parent.ActiveFrame?.ShowWarning(Slot, "Storage full");
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
			Dictionary<ItemType, int> results = Parent.GetResults();
			if (Slot.AnchorType != WorldAnchorType.HandCraft)
			{
				foreach (KeyValuePair<ItemType, int> item in results)
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
			Parent.TriggerCraftingResult(Slot);
			foreach (KeyValuePair<ItemType, int> item2 in results)
			{
				float num = (float)(item2.Value * CraftCount) * Parent.GetProductivityMultiplier();
				float num2 = num % 1f;
				num -= num2;
				if (SeededRandom.Global.RandomBool(num2))
				{
					num += 1f;
				}
				int count = Mathf.RoundToInt(num);
				GamePlayer.Current.AddInventoryItem(item2.Key, count, addToStats: true, this is ManualCrafter);
				SteamStatsManager.ItemProduced(item2.Key, count);
				Parent.ActiveFrame?.ShowItemCrafted(Slot, item2.Key, count);
			}
			return true;
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
