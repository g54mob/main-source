using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.OcclusionCulling;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class PlantMapResourceView : MapResourceView<PlantMapResourceInstance>, IAdditionalMenuOwner, IGameDisposable, IDisposable, IOcclusionObject
	{
		[SerializeField]
		protected string deathParticleId;

		[NonSerialized]
		private MaterialPropertyBlock materialPropertyBlock;

		public OcclusionCullingMode OcclusionCullingMode => base.ResourceInstance?.Blueprint.OcclusionCullingMode ?? OcclusionCullingMode.Disabled;

		public bool IsOcclusionCulled
		{
			get
			{
				return base.LayerObjectHide.IsOcclusionCulled;
			}
			set
			{
				base.LayerObjectHide.IsOcclusionCulled = value;
			}
		}

		public Bounds OcclusionLocalSpaceBoundingBox => new Bounds(new Vector3(0f, 0.5f, 0f), new Vector3(1f, 1f, 1f));

		public Vector3 WorldPosition
		{
			get
			{
				if (!(this == null))
				{
					return base.transform.position;
				}
				return Vector3.zero;
			}
		}

		public string DeathParticleId => deathParticleId;

		public event Action<MaterialPropertyBlock> PhaseChangedUpdateMeshEvent;

		public override string GetAdditionalMenuId()
		{
			return "plantMapResource";
		}

		protected override void Start()
		{
			base.Start();
			if (MonoSingleton<OcclusionCullingManager>.IsInstantiated())
			{
				MonoSingleton<OcclusionCullingManager>.Instance.RegisterObject(this);
			}
		}

		protected override void Dispose(bool destroyGameObject)
		{
			base.Dispose(destroyGameObject);
			if (MonoSingleton<OcclusionCullingManager>.IsInstantiated())
			{
				MonoSingleton<OcclusionCullingManager>.Instance.UnregisterObject(this);
			}
		}

		public void ChangeLifePhase()
		{
			PlantAppearance appearance = base.ResourceInstance.GetAppearance();
			if (appearance == null)
			{
				Log.Error("ChangeLifePhase ERROR: Could not found next appearance for plant " + base.ResourceInstance.BlueprintId, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\PlantMapResourceView.cs");
				return;
			}
			PlantAppearance stuntedAppearance = (base.ResourceInstance.IsStunted ? base.ResourceInstance.GetStuntedAppearance() : null);
			ApplyAppearance(appearance, stuntedAppearance);
		}

		public void ApplyAppearance(PlantAppearance appearance, PlantAppearance stuntedAppearance = null)
		{
			if (appearance == null)
			{
				Log.Error("ApplyAppearance ERROR: PlantAppearance cannot be null.", "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\PlantMapResourceView.cs");
				return;
			}
			float num = appearance.Scale;
			if (stuntedAppearance != null)
			{
				num *= stuntedAppearance.Scale;
			}
			base.gameObject.transform.localScale = new Vector3(num, num, num);
			if (materialPropertyBlock == null)
			{
				materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(base.Mesh);
			}
			for (int i = 0; i < appearance.ShaderParameters.Length; i++)
			{
				materialPropertyBlock.SetFloat(appearance.ShaderParameters[i].ParameterId, appearance.ShaderParameters[i].ParameterValue);
			}
			if (stuntedAppearance != null && stuntedAppearance.ShaderParameters != null)
			{
				ShaderParameterPair[] shaderParameters = stuntedAppearance.ShaderParameters;
				foreach (ShaderParameterPair shaderParameterPair in shaderParameters)
				{
					materialPropertyBlock.SetFloat(shaderParameterPair.ParameterId, shaderParameterPair.ParameterValue);
				}
			}
			base.Mesh.SetPropertyBlock(materialPropertyBlock);
			this.PhaseChangedUpdateMeshEvent?.Invoke(materialPropertyBlock);
		}

		public override void Dispose()
		{
			base.Dispose();
			this.PhaseChangedUpdateMeshEvent = null;
		}

		public override WorldObject GetAsWorldObject()
		{
			return base.ResourceInstance;
		}

		public override string GetMultiselectName()
		{
			return "plant_resource";
		}

		public override void OnOrderRefreshed()
		{
			if (!base.HasDisposed && (base.ResourceInstance.PlayerOrder || base.ResourceInstance.CurrentOrder == OrderType.None))
			{
				SetOrderIcon();
			}
		}

		protected override List<InfoPanelStat> GetInfoStats()
		{
			if (base.ResourceInstance.HasDisposed)
			{
				return null;
			}
			List<InfoPanelStat> infoStats = base.GetInfoStats();
			if (base.ResourceInstance.Blueprint.UseSunlight)
			{
				int currentPhase = base.ResourceInstance.CurrentPhase;
				PlantMapResource plantMapResource = base.ResourceInstance.Blueprint;
				if (plantMapResource.UseSunlight && currentPhase >= 0 && currentPhase < plantMapResource.LifePhases.Count && plantMapResource.LifePhases[currentPhase].UseSunLight)
				{
					StatInstance stat = base.ResourceInstance.GetStat(StatType.SunLight);
					if (stat != null)
					{
						infoStats.Add(new InfoPanelStat("plant_sunlight", "/", new IntRange(Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max)), "plant_sunlight_info", StatType.SunLight));
					}
				}
			}
			return infoStats;
		}

		protected override List<string> GetInfos()
		{
			List<string> infos = base.GetInfos();
			infos.Add(base.ResourceInstance.CurrentOrder.HasFlag(OrderType.CutAllVegetation) ? (MonoSingleton<LocalizationController>.Instance.GetText("is_marked_for_cutting") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_true") + "</style>") : (MonoSingleton<LocalizationController>.Instance.GetText("is_marked_for_cutting") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_false") + "</style>"));
			infos.Add(base.ResourceInstance.CurrentOrder.HasFlag(OrderType.Harvesting) ? (MonoSingleton<LocalizationController>.Instance.GetText("is_marked_for_harvest") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_true") + "</style>") : (MonoSingleton<LocalizationController>.Instance.GetText("is_marked_for_harvest") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_false") + "</style>"));
			return infos;
		}

		protected override List<string> GetModifierTooltips()
		{
			List<string> list = new List<string>();
			int count = base.ResourceInstance.Blueprint.LifePhases.Count;
			if (base.ResourceInstance.CurrentPhase < 0 || base.ResourceInstance.CurrentPhase >= count)
			{
				return list;
			}
			if (base.ResourceInstance.IsStunted)
			{
				bool num = base.ResourceInstance.Blueprint.PlantType == PlantType.Tree;
				string text = MonoSingleton<LocalizationController>.Instance.GetText("plant_stunted_info");
				string item = (num ? (text + "\n" + MonoSingleton<LocalizationController>.Instance.GetText("plant_stunted_tree_info")) : text);
				list.Add(item);
			}
			list.Add(string.Empty);
			if (base.ResourceInstance.CurrentPhase < base.ResourceInstance.GetHarvestPhaseIndex())
			{
				list.Add(string.Empty);
			}
			if (base.ResourceInstance.GrowthHaltedTemperature)
			{
				list.Add(string.Empty);
			}
			if (base.ResourceInstance.IsDyingLowTemperature || base.ResourceInstance.IsDyingLowSunlight || base.ResourceInstance.IsDyingHighTemperature || base.ResourceInstance.IsDyingFlooded || base.ResourceInstance.IsDyingNoWater || MonoSingleton<CropBlightManager>.Instance.HasPlantBlight(base.ResourceInstance))
			{
				list.Add(string.Empty);
			}
			if (base.ResourceInstance.Blueprint.UseSunlight)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("plant_receieving_light_info"));
			}
			return list;
		}

		protected override List<string> GetModifiers()
		{
			List<string> list = new List<string>();
			int count = base.ResourceInstance.Blueprint.LifePhases.Count;
			if (base.ResourceInstance.CurrentPhase < 0 || base.ResourceInstance.CurrentPhase >= count)
			{
				return list;
			}
			string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(base.ResourceInstance.Blueprint.LifePhases[base.ResourceInstance.CurrentPhase].LocKeys));
			if (base.ResourceInstance.IsStunted)
			{
				list.Add("<color=#ffeca8>" + MonoSingleton<LocalizationController>.Instance.GetText("plant_stunted") + "</color>");
			}
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("current_phase") + ": <color=#ffeca8>" + text + "</color> " + $"({base.ResourceInstance.GetPhaseProgress():P1})");
			if (base.ResourceInstance.CurrentPhase < base.ResourceInstance.GetHarvestPhaseIndex())
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("max_yield_in") + ": <color=#ffeca8>" + GetTimeUntilHarvest() + "</color>");
			}
			if (base.ResourceInstance.GrowthHaltedTemperature)
			{
				string text2 = MonoSingleton<LocalizationController>.Instance.GetText("low_temperature");
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("growth_halted") + ": <color=#ffeca8>" + text2 + "</color>");
			}
			if (base.ResourceInstance.IsDyingLowTemperature || base.ResourceInstance.IsDyingLowSunlight || base.ResourceInstance.IsDyingHighTemperature || base.ResourceInstance.IsDyingFlooded || base.ResourceInstance.IsDyingNoWater || MonoSingleton<CropBlightManager>.Instance.HasPlantBlight(base.ResourceInstance))
			{
				List<string> list2 = new List<string>();
				if (base.ResourceInstance.IsDyingLowSunlight)
				{
					list2.Add(MonoSingleton<LocalizationController>.Instance.GetText("plant_dying_low_sunlight"));
				}
				if (base.ResourceInstance.IsDyingLowTemperature)
				{
					list2.Add(MonoSingleton<LocalizationController>.Instance.GetText("low_temperature"));
				}
				if (base.ResourceInstance.IsDyingHighTemperature)
				{
					list2.Add(MonoSingleton<LocalizationController>.Instance.GetText("high_temperature"));
				}
				if (base.ResourceInstance.IsDyingFlooded)
				{
					list2.Add(MonoSingleton<LocalizationController>.Instance.GetText("plant_dying_water_level"));
				}
				if (base.ResourceInstance.IsDyingNoWater)
				{
					list2.Add(MonoSingleton<LocalizationController>.Instance.GetText("plant_dying_not_in_water"));
				}
				if (MonoSingleton<CropBlightManager>.Instance.HasPlantBlight(base.ResourceInstance))
				{
					list2.Add(MonoSingleton<LocalizationController>.Instance.GetText("plant_dying_blight"));
				}
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("plant_dying") + ": <color=#ffeca8>" + string.Join(", ", list2) + "</color>");
			}
			if (base.ResourceInstance.Blueprint.UseSunlight)
			{
				int num = (int)(base.ResourceInstance.GetSunIntensity() * 100f);
				list.Add(string.Format("{0}: <color=#ffeca8>{1}%</color>", MonoSingleton<LocalizationController>.Instance.GetText("plant_receiving_light"), num));
			}
			list.AddRange(base.GetModifiers());
			return list;
		}

		protected override List<InfoPanelResource> GetResourcesInfo()
		{
			List<InfoPanelResource> resourcesInfo = base.GetResourcesInfo();
			if (base.ResourceInstance.HasDisposed)
			{
				return resourcesInfo;
			}
			List<ResourceInstance> availableResources = base.ResourceInstance.GetAvailableResources(base.ResourceInstance.GetPossibleOrders());
			if (availableResources == null || availableResources.Count == 0)
			{
				return resourcesInfo;
			}
			float num = 1f;
			if (base.ResourceInstance != null && base.ResourceInstance.Blueprint != null)
			{
				if (base.ResourceInstance.Blueprint.YieldByDifficulty)
				{
					num = GlobalSaveController.CurrentVillageData.GameParametersCurrent.PlantYieldMultiplier;
				}
				if (base.ResourceInstance.IsStunted)
				{
					num *= base.ResourceInstance.Blueprint.StuntedYieldMultiplier;
				}
			}
			float normalizedPercentage = base.ResourceInstance.GetStat(StatType.Health).GetNormalizedPercentage();
			for (int i = 0; i < availableResources.Count; i++)
			{
				ResourceInstance resourceInstance = availableResources[i];
				float num2 = (float)resourceInstance.Amount * num * normalizedPercentage;
				int num3 = (int)Mathf.Clamp(num2, 1f, num2);
				resourcesInfo.Add(new InfoPanelResource(resourceInstance.Blueprint.GetID(), "resource", $" ~{Mathf.RoundToInt(num3)}"));
			}
			return resourcesInfo;
		}

		private string GetTimeUntilHarvest()
		{
			return UiUtils.GetTimeFormatByHours(base.ResourceInstance.GetHoursUntilHarvest(), isDuration: true);
		}
	}
}
