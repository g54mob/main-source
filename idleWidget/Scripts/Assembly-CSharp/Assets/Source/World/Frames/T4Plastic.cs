using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using LightJson;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T4Plastic : CraftingFrame
	{
		public const float MaxCharge = 10.1f;

		public float Charge;

		private bool _chainCrafting;

		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t4f_plastic";

		public T4Plastic()
		{
			base.ItemHint = "plastic";
			base.PlacementTech = "t4u_plastic_placement";
			base.MusicName = "FugueForOneSyntheticHeart";
			_reagents["oil"] = 1;
			_results["plastic"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "capacitor_widget" };
			_baseCost = new List<ItemType> { "capacitor_widget", "computational_widget" };
			_extraCostMultiplier = 1.3f;
		}

		public override void ButtonClicked(WorldAnchor anchor)
		{
			if (anchor.AnchorType == WorldAnchorType.HandCraft && anchor.Slot == 0)
			{
				if (Charge < 1f)
				{
					base.ActiveFrame?.ShowWarning(anchor, "Low pressure");
					return;
				}
				_chainCrafting = true;
			}
			if (anchor.AnchorType == WorldAnchorType.Custom && !_chainCrafting)
			{
				Charge = Mathf.Min(10.1f, Charge + 0.334f);
			}
			base.ButtonClicked(anchor);
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			if (_chainCrafting)
			{
				Charge -= delta;
				if (Charge >= 1f && !_manualCrafters[0].Active)
				{
					_manualCrafters[0].Start();
				}
				if (!_manualCrafters[0].Active)
				{
					_chainCrafting = false;
				}
			}
		}

		protected override float CalculatePlacementBonus()
		{
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T3Oil)
				{
					return base.PlacementTech.UpgradeMultiplier;
				}
			}
			return 1f;
		}

		public override JsonValue ToJson()
		{
			JsonObject jsonObject = base.ToJson();
			jsonObject["Charge"] = Charge;
			return jsonObject;
		}

		protected override void LoadFromJson(JsonValue val)
		{
			base.LoadFromJson(val);
			Charge = (float)val["Charge"].AsNumber;
		}

		public override void OnAddFrame()
		{
			throw new NotImplementedException();
		}
	}
}
