using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Extensions;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class BeeSkepPreview : MonoBehaviour
	{
		[NonSerialized]
		private BaseBuildingBlueprint blueprint;

		[NonSerialized]
		private ProductionSpeedMultiplierSkep speedMultiplierSkep;

		[NonSerialized]
		private bool isShown;

		[NonSerialized]
		private object highlightedPlantsLock = new object();

		[NonSerialized]
		private List<PlantMapResourceInstance> highlightedPlants = new List<PlantMapResourceInstance>();

		private float currentTimer;

		[NonSerialized]
		private Vec3Int lastPosition;

		[SerializeField]
		private BaseBuildablePreview skepPreview;

		[NonSerialized]
		private SkepProductionMultiplierData skepMultiplierData;

		private void Awake()
		{
			if (skepPreview == null)
			{
				skepPreview = GetComponent<BaseBuildablePreview>();
			}
			skepPreview.InitializeEvent += Show;
			skepPreview.UpdateEvent += Tick;
		}

		private void OnDestroy()
		{
			skepPreview.InitializeEvent -= Show;
			skepPreview.UpdateEvent -= Tick;
			Hide();
		}

		public void Show(BaseBuildingBlueprint skepBlueprint)
		{
			if (isShown)
			{
				return;
			}
			blueprint = skepBlueprint;
			speedMultiplierSkep = Repository<ProductionComponentsRepository, ProductionComponentBlueprint>.Instance.GetByID(blueprint?.ProductionComponentID)?.ProductionSpeedMultiplierSkep;
			if (speedMultiplierSkep != null)
			{
				float radius = speedMultiplierSkep.Radius;
				if (!radius.IsCloseToZero())
				{
					isShown = true;
					MonoSingleton<SphereRenderManager>.Instance.Show(base.transform, radius, SphereRenderType.SkepRange);
				}
			}
		}

		public void Hide()
		{
			if (!isShown)
			{
				return;
			}
			isShown = false;
			if (MonoSingleton<SphereRenderManager>.IsInstantiated())
			{
				MonoSingleton<SphereRenderManager>.Instance.Hide(SphereRenderType.SkepRange);
			}
			ClearOutlineOnHighlightedPlants();
			if (OutlinePostProcess.IsInstantiated())
			{
				OutlinePostProcess.Instance.OnResetFillColor();
			}
			lock (highlightedPlantsLock)
			{
				highlightedPlants.Clear();
			}
		}

		private bool UpdateSkepInfo(MapNode node)
		{
			speedMultiplierSkep.CalculateMultiplier(node, ref skepMultiplierData);
			OutlinePostProcess.Instance.HoverFillEnabled = true;
			OutlinePostProcess.Instance.FillColor = OutlinePostProcess.Instance.SkepPlantsInRangeFillColor;
			foreach (PlantMapResourceInstance plant in skepMultiplierData.Plants)
			{
				lock (highlightedPlantsLock)
				{
					highlightedPlants.Add(plant);
				}
				PlantMapResourceView selectable = MonoSingleton<PlantResourceManager>.Instance.InstanceView[plant];
				OutlinePostProcess.Instance.SetOutlineOnObject(selectable, selectionOutline: false, hoverFill: true);
			}
			return true;
		}

		private void Tick()
		{
			if (!isShown || (currentTimer > Time.time && MonoSingleton<GameSpeedManager>.Instance.CurrentSpeedIndex != GameSpeedIndex.Pause))
			{
				return;
			}
			Vec3Int gridPosition = GridUtils.GetGridPosition(base.transform.position);
			if (!lastPosition.Equals(gridPosition))
			{
				currentTimer = Time.time + 0.2f;
				lastPosition = gridPosition;
				ClearOutlineOnHighlightedPlants();
				lock (highlightedPlantsLock)
				{
					highlightedPlants.Clear();
				}
				MapNode skepNode = VillageManager.ActiveVillage.Map.GetNode(gridPosition);
				MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(() => UpdateSkepInfo(skepNode), delegate
				{
				});
			}
		}

		private void ClearOutlineOnHighlightedPlants()
		{
			lock (highlightedPlantsLock)
			{
				foreach (PlantMapResourceInstance highlightedPlant in highlightedPlants)
				{
					if (LoadingController.IsSceneTransition)
					{
						break;
					}
					if (highlightedPlant != null && !highlightedPlant.HasDisposed && MonoSingleton<PlantResourceManager>.IsInstantiated() && MonoSingleton<PlantResourceManager>.Instance.InstanceView.ContainsKey(highlightedPlant))
					{
						PlantMapResourceView selectable = MonoSingleton<PlantResourceManager>.Instance.InstanceView[highlightedPlant];
						if (OutlinePostProcess.IsInstantiated())
						{
							OutlinePostProcess.Instance.SetOutlineOnObject(selectable, selectionOutline: false, hoverFill: false);
						}
					}
				}
			}
		}

		public string GetBeeSkepCursorInfo()
		{
			float lastMultiplier = skepMultiplierData.LastMultiplier;
			string text = (lastMultiplier * 100f).ToString("F1");
			string text2 = ((lastMultiplier <= 0.75f) ? ((lastMultiplier <= 0.29f) ? ("<style=DefaultRed>" + text + "%</style>") : ((!(lastMultiplier <= 0.5f)) ? ("<style=DefaultYellow>" + text + "%</style>") : ("<style=DefaultOrange>" + text + "%</style>"))) : ((!(lastMultiplier <= 0.99f)) ? ("<style=DefaultGreen>" + text + "%</style>") : ("<style=DefaultGreenYellow>" + text + "%</style>")));
			string text3 = text2;
			text2 = ((lastMultiplier <= 0.75f) ? ((lastMultiplier <= 0.29f) ? $"<style=DefaultRed>{skepMultiplierData.PlantsCount}</style>" : ((!(lastMultiplier <= 0.5f)) ? $"<style=DefaultYellow>{skepMultiplierData.PlantsCount}</style>" : $"<style=DefaultOrange>{skepMultiplierData.PlantsCount}</style>")) : ((!(lastMultiplier <= 0.99f)) ? $"<style=DefaultGreen>{skepMultiplierData.PlantsCount}</style>" : $"<style=DefaultGreenYellow>{skepMultiplierData.PlantsCount}</style>"));
			string text4 = text2;
			int skepCount = skepMultiplierData.SkepCount;
			text2 = ((skepCount <= 0) ? $"<style=DefaultGreen>{skepMultiplierData.SkepCount}</style>" : ((skepCount > 1) ? $"<style=DefaultRed>{skepMultiplierData.SkepCount}</style>" : $"<style=DefaultYellow>{skepMultiplierData.SkepCount}</style>"));
			string text5 = text2;
			return MonoSingleton<LocalizationController>.Instance.GetText("skep_production_speed") + ": " + text3 + "\n" + MonoSingleton<LocalizationController>.Instance.GetText("plants_around_skep") + ": " + text4 + "\n" + MonoSingleton<LocalizationController>.Instance.GetText("skeps_around_skep") + ": " + text5;
		}
	}
}
