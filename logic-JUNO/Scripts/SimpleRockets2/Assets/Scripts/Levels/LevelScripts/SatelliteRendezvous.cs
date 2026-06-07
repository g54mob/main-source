using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Levels.Requirements;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class SatelliteRendezvous : Level
	{
		private DockingRequirement _dockRequirement;

		public override string GetPersistentMessage()
		{
			if (!Game.InFlightScene || _dockRequirement == null)
			{
				return "Dock with Satellite";
			}
			if (_dockRequirement.Status == LevelRequirementStatus.Pass)
			{
				return "Docked! (" + Units.GetVolumeString(Score * 1000f) + ")";
			}
			if (_dockRequirement.DockAmount > 0f)
			{
				return "Docking " + Units.GetPercentageString(_dockRequirement.DockAmount) + " (" + Units.GetVolumeString(Score * 1000f) + ")";
			}
			return "Dock with Satellite (" + Units.GetVolumeString(Score * 1000f) + ")";
		}

		public override bool HasRequiredParts(ICraftScript craft, out string missingPartsMessage)
		{
			if (craft.Data.Assembly.Parts.Any((PartData x) => x.GetModifier<DockingPortData>() != null && !x.PartScript.Disconnected))
			{
				missingPartsMessage = string.Empty;
				return true;
			}
			missingPartsMessage = "You need a docking port to dock with the satellite!";
			return false;
		}

		public override void InitializeRequirements()
		{
			_dockRequirement = new DockingRequirement(this, "Satellite");
			AddLevelRequirement(_dockRequirement);
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			Score = FuelUsed / 1000f;
			if (base.AllRequirementsPassed)
			{
				base.Timer.Stop();
				CompleteLevel(success: true, Score);
			}
			else if (base.AnyRequirementFailed)
			{
				base.Timer.Stop();
				CompleteLevel(success: false, 0f);
			}
		}

		protected override void OnFlightSceneReady()
		{
			base.OnFlightSceneReady();
			base.Timer.Start();
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate(int? x)
			{
				if (x == 1)
				{
					Game.Instance.FlightScene.ViewManager.MapViewManager.IsInForeground = true;
				}
				if (x == 0)
				{
					Game.Instance.FlightScene.ViewManager.MapViewManager.IsInForeground = false;
					Game.Instance.FlightScene.FlightSceneUI.SetCurrentTarget(_dockRequirement.TargetCraftNode);
				}
			}, 2);
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			base.DisplayCraftFuelInDesigner = true;
		}
	}
}
