using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.World.AutoWorkers;
using LightJson;
using UnityEngine;

namespace Assets.Source.World
{
	public abstract class FurnaceFrame : CraftingFrame
	{
		protected float _manualLoadTimer;

		protected float _smeltTimer;

		protected int _handAddCount;

		protected int _baseMaxContents;

		protected bool _handCrafted;

		public virtual FrameUpgrade AutoFurnaceUpgrade => null;

		public override int HandCraftButtonCount => 0;

		public virtual float BaseSmeltingTime => 8f;

		public bool IsSmelting => _smeltTimer > 0f;

		public int CurrentContents { get; private set; }

		public virtual float GetSmeltingTime(bool handCraft)
		{
			return BaseSmeltingTime / GetSmeltSpeedMultiplier(handCraft);
		}

		public virtual int GetMaxContents()
		{
			return Mathf.RoundToInt((float)_baseMaxContents * GetMaxContentMultiplier() * GamePlayer.Current.PrestigeMultiplier);
		}

		protected virtual float GetSmeltSpeedMultiplier(bool handCraft)
		{
			return GetUpgradeMultiplier(FrameUpgradeType.Custom, 2);
		}

		protected virtual float GetMaxContentMultiplier()
		{
			return GetUpgradeMultiplier(FrameUpgradeType.Custom, 3);
		}

		public void AddContents(int count = 1)
		{
			CurrentContents += count;
		}

		public override void ButtonClicked(WorldAnchor anchor)
		{
			if (anchor.AnchorType == WorldAnchorType.Custom)
			{
				if (anchor.Slot == 0)
				{
					if (CurrentContents == 0)
					{
						base.ActiveFrame?.ShowWarning(anchor, "Furnace empty");
					}
					else
					{
						StartSmelting(handCrafted: true);
					}
				}
				else if (IsSmelting)
				{
					base.ActiveFrame?.ShowWarning(anchor, "Smelting in progress");
				}
				else if (CurrentContents >= GetMaxContents())
				{
					base.ActiveFrame?.ShowWarning(anchor, "Furnace full");
				}
				else if ((_handAddCount = ConsumeReagentsForCraft(anchor)) > 0)
				{
					float craftingTime = GetCraftingTime(handCraft: true);
					base.ActiveFrame?.TriggerCooldown(anchor, craftingTime);
					base.ActiveFrame?.TriggerGizmoStart(anchor);
					_manualLoadTimer = craftingTime;
				}
			}
			else
			{
				base.ButtonClicked(anchor);
			}
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			if (_manualLoadTimer > 0f)
			{
				_manualLoadTimer -= delta;
				if (_manualLoadTimer < 0f)
				{
					CurrentContents += _handAddCount;
					_handAddCount = 0;
					WorldAnchor worldAnchor = new WorldAnchor(WorldAnchorType.Custom, 1);
					base.ActiveFrame?.EnableButton(worldAnchor);
					base.ActiveFrame?.TriggerGizmoStop(worldAnchor);
				}
			}
			if (_smeltTimer > 0f)
			{
				_smeltTimer -= delta;
				if (!(_smeltTimer < 0f))
				{
					return;
				}
				WorldAnchor worldAnchor2 = new WorldAnchor(WorldAnchorType.Custom, 0);
				foreach (KeyValuePair<ItemType, int> result in GetResults())
				{
					float num = (float)(result.Value * CurrentContents) * GetProductivityMultiplier();
					float num2 = num % 1f;
					num -= num2;
					if (SeededRandom.Global.RandomBool(num2))
					{
						num += 1f;
					}
					int count = Mathf.RoundToInt(num);
					GamePlayer.Current.AddInventoryItem(result.Key, count, addToStats: true, _handCrafted);
					base.ActiveFrame?.ShowItemCrafted(worldAnchor2, result.Key, count);
				}
				if ((bool)base.ActiveFrame)
				{
					UISounds.CraftFinished();
					base.ActiveFrame.EnableButton(worldAnchor2);
					base.ActiveFrame.TriggerGizmoStop(worldAnchor2);
				}
				CurrentContents = 0;
			}
			else if (AutoFurnaceUpgrade != null && HasUpgrade(AutoFurnaceUpgrade) && CurrentContents >= GetMaxContents())
			{
				StartSmelting(handCrafted: false);
			}
		}

		public void StartSmelting(bool handCrafted)
		{
			float smeltingTime = GetSmeltingTime(handCrafted);
			WorldAnchor worldAnchor = new WorldAnchor(WorldAnchorType.Custom, 0);
			base.ActiveFrame?.TriggerCooldown(worldAnchor, smeltingTime);
			base.ActiveFrame?.TriggerGizmoStart(worldAnchor);
			_handCrafted = handCrafted;
			_smeltTimer = smeltingTime;
		}

		public override void SetupActiveFrame(ActiveWorldFrame frame)
		{
			base.SetupActiveFrame(frame);
			if (_smeltTimer > 0f)
			{
				float smeltingTime = GetSmeltingTime(handCraft: true);
				(base.ActiveFrame?.TriggerCooldown(new WorldAnchor(WorldAnchorType.Custom, 0), smeltingTime)).UpdateTimeSpent(smeltingTime - _smeltTimer);
			}
		}

		public override AutoWorker CreateAutoWorker(WorldAnchor slot)
		{
			return new AutoFurnaceLoader(this, slot);
		}

		public override JsonValue ToJson()
		{
			JsonObject jsonObject = base.ToJson();
			jsonObject["CurrentContents"] = CurrentContents;
			jsonObject["ManualLoadTimer"] = _manualLoadTimer;
			jsonObject["SmeltTimer"] = _smeltTimer;
			jsonObject["HandAddCount"] = _handAddCount;
			return jsonObject;
		}

		protected override void LoadFromJson(JsonValue val)
		{
			base.LoadFromJson(val);
			CurrentContents = val["CurrentContents"];
			_manualLoadTimer = (float)val["ManualLoadTimer"].AsNumber;
			_smeltTimer = (float)val["SmeltTimer"].AsNumber;
			_handAddCount = val["HandAddCount"];
		}
	}
}
