using System;
using System.Linq;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class EsaJuice : Level
	{
		private double? _initialDeltaV;

		public override string GetPersistentMessage()
		{
			return $"Delta-V Used: {Score:F2} m/s";
		}

		public override void InitializeRequirements()
		{
			AddLevelRequirement(new ContractRequirement(this, "JUICE"));
			FailLevelIfCraftDestroyed = true;
			_initialDeltaV = null;
			Game.Instance.FlightScene.ViewManager.MapViewManager.ForegroundStateChanged += OnMapViewForgroundStateChanged;
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			double deltaVStage = base.PlayerCraft.FlightData.Performance.DeltaVStage;
			if (!_initialDeltaV.HasValue && deltaVStage > 0.0)
			{
				_initialDeltaV = deltaVStage;
			}
			Score = (_initialDeltaV.HasValue ? ((float)Math.Max(0.0, _initialDeltaV.Value - deltaVStage)) : 0f);
			if (base.AllRequirementsPassed)
			{
				CompleteLevel(success: true, Score);
			}
			else if (base.AnyRequirementFailed)
			{
				CompleteLevel(success: false, 0f);
			}
		}

		private void OnMapViewForgroundStateChanged(bool foreground)
		{
			if (foreground)
			{
				Game.Instance.FlightScene.ViewManager.MapViewManager.ForegroundStateChanged -= OnMapViewForgroundStateChanged;
				MapViewScript mapViewScript = (MapViewScript)Game.Instance.FlightScene.ViewManager.MapViewManager.MapView;
				mapViewScript.TargetingManager.SetNavigationTarget(mapViewScript.ItemRegistry.Planets.First((MapPlanet x) => x.ItemName == "Tydos"));
			}
		}
	}
}
