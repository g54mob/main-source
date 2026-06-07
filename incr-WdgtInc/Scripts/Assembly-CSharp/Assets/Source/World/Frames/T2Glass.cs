using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using LightJson;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T2Glass : CraftingFrame
	{
		public const float MaxTemperature = 30f;

		public const float TempReductionPerCraft = 0.3f;

		private FrameUpgrade _tempUpgrade;

		private float _tempTimer;

		public override int AutoWorkerMax => 6;

		public override TechNode RequiredTech => "t2f_glass";

		public float Temperature { get; private set; }

		public T2Glass()
		{
			base.ItemHint = "glass";
			base.PlacementTech = "t2u_glass_placement";
			base.MusicName = "FastLanesLightRain";
			_reagents["sand"] = 1;
			_results["glass"] = 1;
			_firstCost = new List<ItemType> { "iron_ingot", "widget" };
			_baseCost = new List<ItemType> { "iron_ingot", "spinning_widget" };
			_extraCostMultiplier = 1.2000000476837158;
			_baseCraftingTime = 0.7f;
			_tempUpgrade = GetCustomUpgrade(1);
		}

		public override float GetSpeedPenaltyMultiplier()
		{
			return Temperature / 30f;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			int num = 0;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T2Glass)
				{
					num++;
					if (num > 2)
					{
						return 1.0;
					}
				}
			}
			if (num != 2)
			{
				return 1.0;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			_tempTimer -= delta;
			if (_tempTimer < 0f)
			{
				_tempTimer = 0.5f;
				if (HasUpgrade(_tempUpgrade) && Temperature < 26f)
				{
					AddTemperature(Math.Max(1f, GetSpeedMultiplier(handCraft: false)));
				}
			}
		}

		public override void ButtonClicked(WorldAnchor anchor)
		{
			if (anchor.AnchorType == WorldAnchorType.Custom && anchor.Slot == 0)
			{
				AddTemperature(1f);
			}
			else
			{
				base.ButtonClicked(anchor);
			}
		}

		public override bool CanStartCrafting(WorldAnchor slot)
		{
			if (Temperature < 1f)
			{
				base.ActiveFrame?.ShowWarning(slot, "@T2GlassWarning");
				return false;
			}
			return base.CanStartCrafting(slot);
		}

		public override void TriggerCraftingResult(WorldAnchor slot)
		{
			base.TriggerCraftingResult(slot);
			Temperature = Mathf.Max(0f, Temperature - 0.3f);
		}

		public void AddTemperature(float amt)
		{
			Temperature = Mathf.Min(Temperature + amt, 30f);
			float craftingTime = GetCraftingTime(handCraft: false);
			for (int i = 0; i < _workers.Length; i++)
			{
				((AutoCrafter)_workers[i])?.UpdateTimeRequired(craftingTime);
			}
			craftingTime = GetCraftingTime(handCraft: true);
			for (int j = 0; j < _manualCrafters.Length; j++)
			{
				_manualCrafters[j].UpdateTimeRequired(craftingTime);
			}
		}

		public override JsonValue ToJson()
		{
			JsonObject jsonObject = base.ToJson();
			jsonObject["Temperature"] = Temperature;
			return jsonObject;
		}

		protected override void LoadFromJson(JsonValue val)
		{
			base.LoadFromJson(val);
			Temperature = (float)val["Temperature"].AsNumber;
		}
	}
}
