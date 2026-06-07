using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using LightJson;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T3Oil : CraftingFrame
	{
		public const float SafePressure = 220f;

		public const float PressureReductionPerCraft = 2f;

		public const float OverpressureReduction = 100f;

		public const float PressurePerClick = 10f;

		public float Pressure = 55f;

		public bool Overpressure;

		private FrameUpgrade _autoUpgrade;

		private float _autoTimer;

		private float _fakeClickTimer;

		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t3f_oil";

		public T3Oil()
		{
			base.ItemHint = "oil";
			base.PlacementTech = "t3u_oil_placement";
			base.MusicName = "EvolvingCities";
			_results["oil"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "spinning_widget", "glass" };
			_baseCost = new List<ItemType> { "glass", "capacitor_widget" };
			_autoUpgrade = GetCustomUpgrade(1);
		}

		public override float GetSpeedPenaltyMultiplier()
		{
			if (Overpressure)
			{
				return 0.0001f;
			}
			return Mathf.Clamp(Pressure / 220f, 0.0001f, 10f);
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			if (Overpressure)
			{
				Pressure = Mathf.Max(0f, Pressure - 100f * delta);
				if (Pressure == 0f)
				{
					Overpressure = false;
				}
				return;
			}
			if (_fakeClickTimer > 0f)
			{
				_fakeClickTimer -= delta;
			}
			else if (base.ActiveFrame != null && Pressure > 0f && !_manualCrafters[0].Active)
			{
				ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
				if (!_manualCrafters[0].Active)
				{
					_fakeClickTimer = 1.5f;
				}
			}
			_autoTimer -= delta;
			if (_autoTimer < 0f)
			{
				_autoTimer = 0.5f;
				if (HasUpgrade(_autoUpgrade) && Pressure < 210f)
				{
					AddPressure(8f * Math.Max(1f, GetSpeedMultiplier(handCraft: false)), staySafe: true);
				}
			}
		}

		public override void TriggerCraftingResult(WorldAnchor slot)
		{
			base.TriggerCraftingResult(slot);
			Pressure = Mathf.Max(0f, Pressure - 2f);
		}

		public override void ButtonClicked(WorldAnchor anchor)
		{
			base.ButtonClicked(anchor);
			if (anchor.AnchorType == WorldAnchorType.Custom && anchor.Slot == 0)
			{
				if (Overpressure)
				{
					base.ActiveFrame?.ShowWarning(anchor, "@T3OilDepressurizing");
				}
				else
				{
					AddPressure(10f);
				}
			}
		}

		public void AddPressure(float amt, bool staySafe = false)
		{
			Pressure += amt;
			if (staySafe && Pressure > 220f)
			{
				Pressure = 220f;
			}
			if (Pressure > 220f)
			{
				float num = Pressure - 220f;
				if (SeededRandom.Global.RandomBool(num / 100f))
				{
					Overpressure = true;
					base.ActiveFrame?.ShowWarning(new WorldAnchor(WorldAnchorType.Custom, 0), "@T3OilWarning");
				}
			}
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

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			if (WorldMap.Current.GetTerrain(base.Position) == 5)
			{
				return base.PlacementTech.UpgradeMultiplier;
			}
			return 1.0;
		}

		public override JsonValue ToJson()
		{
			JsonObject jsonObject = base.ToJson();
			jsonObject["Pressure"] = Pressure;
			return jsonObject;
		}

		protected override void LoadFromJson(JsonValue val)
		{
			base.LoadFromJson(val);
			Pressure = (float)val["Pressure"].AsNumber;
		}
	}
}
