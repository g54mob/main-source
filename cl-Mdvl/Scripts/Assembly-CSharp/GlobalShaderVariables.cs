using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using UnityEngine;

public class GlobalShaderVariables : MonoSingleton<GlobalShaderVariables>
{
	private Texture2D mapMaskTexture;

	private Texture2D effectMaskTexture;

	private Vector4 mapMaskTextureSize = Vector4.one;

	private Vector4 effectMaskTextureSize = Vector4.one;

	private Vector3 mapSize = Vector3.one;

	private Texture2D emptyEffectMap;

	private float unscaledTimer;

	private World world;

	private readonly Dictionary<string, float> environmentValues = new Dictionary<string, float>();

	private bool environmentValuesInit;

	public event Action<Dictionary<string, float>> EnvironmentUpdateEvent;

	public void UpdateEnvironmentVariables(float rainGlobalShader, float snowGlobalShader, float windStrengthGlobalShader)
	{
		Shader.SetGlobalFloat("_Rain_amount", rainGlobalShader);
		Shader.SetGlobalFloat("_Snow_amount", snowGlobalShader);
		Shader.SetGlobalFloat("_windGlobalStrength", windStrengthGlobalShader);
		if (!environmentValuesInit)
		{
			environmentValuesInit = true;
			environmentValues.Add("RainIntensity", rainGlobalShader);
			environmentValues.Add("SnowIntensity", snowGlobalShader);
			environmentValues.Add("WindIntensity", windStrengthGlobalShader);
		}
		else
		{
			environmentValues["RainIntensity"] = rainGlobalShader;
			environmentValues["SnowIntensity"] = snowGlobalShader;
			environmentValues["WindIntensity"] = windStrengthGlobalShader;
		}
		this.EnvironmentUpdateEvent?.Invoke(environmentValues);
	}

	public void SetEffectMaskTextureEnabled(bool enableEffectMap)
	{
		Shader.SetGlobalTexture("_Terrain_Effect_mask", enableEffectMap ? effectMaskTexture : emptyEffectMap);
	}

	public void SetScreenshotModeEnabled(bool enableScreenshotMode)
	{
		Shader.SetGlobalFloat("_ScreenshotMode", (!enableScreenshotMode) ? 1 : 0);
	}

	public void HideForbiddenZone()
	{
		Shader.SetGlobalInt("_isSelecting", 0);
	}

	private void Start()
	{
		world = MonoSingleton<World>.Instance;
		MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent += OnTimeUpdate;
		MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent += OnChangeBuildingTypeToPlace;
		MonoSingleton<SelectionManager>.Instance.AssignOrderEvent += OnAssignOrder;
		MonoSingleton<SelectionManager>.Instance.RightMouseUpResetOrderEvent += OnResetOrder;
		MonoSingleton<BuildingPlacementManager>.Instance.SelectionCanceledEvent += OnResetOrder;
		MonoSingleton<SceneController>.Instance.UnscaledTick += OnUnscaledTick;
		MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
		MonoSingleton<RaidController>.Instance.RaidSpawnedEvent += OnRaidStarted;
		MonoSingleton<RaidController>.Instance.RaidEndedEvent += OnRaidEnded;
		Shader.SetGlobalInt("_minDistFromEdge", 16);
		Init();
		OnTimeUpdate();
	}

	protected override void OnDestroy()
	{
		if (MonoSingleton<ConstructionController>.IsInstantiated())
		{
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingTypeToPlace;
		}
		if (MonoSingleton<BuildingPlacementManager>.IsInstantiated())
		{
			MonoSingleton<BuildingPlacementManager>.Instance.SelectionCanceledEvent -= OnResetOrder;
		}
		if (MonoSingleton<RaidController>.IsInstantiated())
		{
			MonoSingleton<RaidController>.Instance.RaidSpawnedEvent -= OnRaidStarted;
			MonoSingleton<RaidController>.Instance.RaidEndedEvent -= OnRaidEnded;
		}
		if (MonoSingleton<SelectionManager>.IsInstantiated())
		{
			MonoSingleton<SelectionManager>.Instance.AssignOrderEvent -= OnAssignOrder;
			MonoSingleton<SelectionManager>.Instance.RightMouseUpResetOrderEvent -= OnResetOrder;
		}
		if (MonoSingleton<SceneController>.IsInstantiated())
		{
			MonoSingleton<SceneController>.Instance.UnscaledTick -= OnUnscaledTick;
		}
		if (MonoSingleton<World>.IsInstantiated())
		{
			MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
		}
		if (MonoSingleton<WorldTimeManager>.IsInstantiated())
		{
			MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent -= OnTimeUpdate;
		}
		world = null;
		base.OnDestroy();
	}

	private void OnRaidEnded(ActiveRaidInfo info)
	{
		RefreshNoRaidsActiveVariable();
	}

	private void OnRaidStarted(ActiveRaidInfo __, List<HumanoidInstance> _)
	{
		RefreshNoRaidsActiveVariable();
	}

	private void OnGameLoaded(bool fromSave)
	{
		RefreshNoRaidsActiveVariable();
	}

	private void RefreshNoRaidsActiveVariable()
	{
		bool flag = GlobalSaveController.CurrentVillageData.Raids.Any((ActiveRaidInfo raid) => !raid.HasEnded);
		Shader.SetGlobalInt("_noRaidsActive", flag ? 1 : 0);
	}

	private void Init()
	{
		if (emptyEffectMap == null)
		{
			emptyEffectMap = new Texture2D(1, 1);
			emptyEffectMap.SetPixel(0, 0, new Color(0f, 0f, 0f, 0f));
			emptyEffectMap.Apply();
		}
		SetScreenshotModeEnabled(enableScreenshotMode: false);
	}

	private void OnUnscaledTick(float unscaledDeltaTime)
	{
		unscaledTimer += unscaledDeltaTime;
		if (unscaledTimer > 10f)
		{
			unscaledTimer = 0f;
		}
		Shader.SetGlobalFloat("_unscaledTimeTick", unscaledTimer);
		Vector2 vector = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Shader.SetGlobalVector("_PointerPosition", vector);
	}

	private void OnResetOrder()
	{
		HideForbiddenZone();
	}

	private void OnAssignOrder(OrderType order, AreaType areaOrderType)
	{
		if (order.HasFlag(OrderType.Digging) || order.HasFlag(OrderType.ExpandZone) || areaOrderType == AreaType.Stockpile || areaOrderType == AreaType.Crops)
		{
			Shader.SetGlobalInt("_isSelecting", 1);
		}
		else
		{
			Shader.SetGlobalInt("_isSelecting", 0);
		}
	}

	private void OnChangeBuildingTypeToPlace()
	{
		if (!GlobalSaveController.CurrentVillageData.IsSecondMap)
		{
			Shader.SetGlobalInt("_isSelecting", 1);
		}
	}

	public void SetTerrainMaskTextures(Texture2D mapMaskTexture, Texture2D effectMaskTexture)
	{
		mapSize.x = MonoSingleton<World>.Instance.SizeX;
		mapSize.y = MonoSingleton<World>.Instance.SizeY;
		mapSize.z = MonoSingleton<World>.Instance.SizeZ;
		Shader.SetGlobalVector("_Map_size", mapSize);
		this.mapMaskTexture = mapMaskTexture;
		if (this.mapMaskTexture != null)
		{
			mapMaskTextureSize.z = MonoSingleton<World>.Instance.SizeX;
			mapMaskTextureSize.w = MonoSingleton<World>.Instance.SizeY;
			mapMaskTextureSize.x = 1f / (float)MonoSingleton<World>.Instance.SizeX;
			mapMaskTextureSize.y = 1f / (float)MonoSingleton<World>.Instance.SizeY;
			Shader.SetGlobalTexture("_Terrain_Mask", this.mapMaskTexture);
			Shader.SetGlobalVector("_Terrain_Mask_TexelSize", mapMaskTextureSize);
		}
		this.effectMaskTexture = effectMaskTexture;
		if (this.effectMaskTexture != null)
		{
			effectMaskTextureSize.z = MonoSingleton<World>.Instance.SizeX;
			effectMaskTextureSize.w = MonoSingleton<World>.Instance.SizeZ;
			effectMaskTextureSize.x = 1f / (float)MonoSingleton<World>.Instance.SizeX;
			effectMaskTextureSize.y = 1f / (float)MonoSingleton<World>.Instance.SizeZ;
			Shader.SetGlobalTexture("_Terrain_Effect_mask", this.effectMaskTexture);
			Shader.SetGlobalVector("_Terrain_Effect_mask_TexelSize", effectMaskTextureSize);
		}
	}

	private void OnTimeUpdate()
	{
		float yearCycle = GlobalSaveController.CurrentVillageData.DateAndTime.YearCycle;
		float value = (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesSinceDay / (float)Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().MinutesInDay();
		Shader.SetGlobalFloat("YearCycle", yearCycle);
		Shader.SetGlobalFloat("_YearCycle", yearCycle);
		Shader.SetGlobalFloat("_DayNightCycle", value);
		Shader.SetGlobalFloat("DayNightCycle", value);
	}
}
