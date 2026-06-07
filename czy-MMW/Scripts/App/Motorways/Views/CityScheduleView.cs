using Client;
using Factory;
using Factory.Pools;
using Motorways.Models;
using Motorways.Themes;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	public class CityScheduleView : MonoBehaviour, IView, IReusable
	{
		[Dependency]
		private ClockModel _clock;

		[Dependency]
		private CityPlanModel _cityPlan;

		[Dependency]
		private DemandModel _demand;

		[Dependency]
		private IThemeDatabase _themeDatabase;

		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private ISimulation _simulation;

		public const string ShouldShowScheduleView = "ShouldShowScheduleView";

		private bool _showPendingBuildings = true;

		private bool _showReallocatedDemand = true;

		private GUIStyle _style = new GUIStyle();

		private bool ShouldShowDebugScheduleView
		{
			get
			{
				if (FeatureToggle.IsFeatureEnabled(Feature.ScheduleView))
				{
					return true;
				}
				return false;
			}
		}

		public string GetBuildingStateInfo(CityPlanModel.ScheduledBuilding building, Theme theme)
		{
			Color buildingColor = theme.GetBuildingColor(building.groupIndex, ThemeComponentGroupTarget.BuildingBase);
			int num = Mathf.FloorToInt((float)building.time / (5f / 6f) / 24f / 7f);
			int num2 = Mathf.FloorToInt((float)building.time / (5f / 6f) / 24f) % 7;
			string text;
			if (building.grouping == GroupingStyle.Circle)
			{
				text = "Upgrade ";
			}
			else
			{
				text = building.type.ToString();
				if (building.carparkPreference == CarparkPreference.Double)
				{
					text = "Double " + text;
				}
			}
			string text2 = $"Week {num}, Day {num2}-<color=#{ColorUtility.ToHtmlStringRGB(buildingColor)}>{text}-group:{building.groupIndex}</color>";
			if (building.spawnAttempts > 0)
			{
				text2 += $" Retry {building.spawnAttempts} in {(float)(building.time - _clock.ExpansionTime):F1}";
				if (building.type == CityTileType.Demand)
				{
					if (building.spawnAttempts > _constants.MaxFailedBuildingSpawnsBeforeIgnoringWeights)
					{
						text2 = ((building.grouping != GroupingStyle.Circle) ? (text2 + " w\\o weights") : (text2 + " -> to nrml spwn"));
					}
				}
				else if (building.spawnAttempts > _constants.MaxFailedBuildingSpawnsBeforeIgnoringWeights)
				{
					text2 += " w\\o weights";
				}
			}
			return text2;
		}

		private void OnEnable()
		{
			_style.fontSize = 30;
			_style.normal.textColor = Color.red;
			_style.richText = true;
		}

		public void Reset()
		{
			_showPendingBuildings = true;
			_showReallocatedDemand = true;
		}

		TickResult IView.Tick(TimeInterval timeInterval, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}
	}
}
