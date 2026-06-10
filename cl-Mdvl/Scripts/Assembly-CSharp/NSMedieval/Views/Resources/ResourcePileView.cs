using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers.Selection.EventData;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.OcclusionCulling;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.RoomDetection;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.StorageUniversal;
using NSMedieval.Tools;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class ResourcePileView : SelectableObject, IObserver, IAdditionalMenuOwner, IGameDisposable, IDisposable
	{
		[SerializeField]
		private HideResource hideResource;

		private readonly string activateParticles = "spawn_pile";

		private int currentMeshResourceAmount;

		[SerializeField]
		protected MeshVariationHandler meshVariationHandler;

		[SerializeField]
		private Transform meshTransform;

		[NonSerialized]
		private StatInstance fermentation;

		[NonSerialized]
		private StatInstance freshenss;

		[NonSerialized]
		private StatInstance health;

		[NonSerialized]
		private ResourcePileIndicatorView indicatorUI;

		[NonSerialized]
		private TooltipViewNew pileTooltipView;

		[NonSerialized]
		private readonly StringBuilder stringBuilder = new StringBuilder(100);

		[field: NonSerialized]
		public ResourcePileInstance ResourcePileInstance { get; private set; }

		private TooltipViewNew PileTooltipView
		{
			get
			{
				if (pileTooltipView == null)
				{
					pileTooltipView = GetComponentInChildren<TooltipViewNew>();
				}
				return pileTooltipView;
			}
		}

		public HideResource HideResource => hideResource;

		public StatInstance Health
		{
			get
			{
				StatInstance obj = health ?? ResourcePileInstance?.GetStat(StatType.Health);
				StatInstance result = obj;
				health = obj;
				return result;
			}
		}

		public StatInstance Freshenss
		{
			get
			{
				StatInstance obj = freshenss ?? ResourcePileInstance?.GetStat(StatType.Freshness);
				StatInstance result = obj;
				freshenss = obj;
				return result;
			}
		}

		public StatInstance Fermentation
		{
			get
			{
				StatInstance obj = fermentation ?? ResourcePileInstance?.GetStat(StatType.Fermentation);
				StatInstance result = obj;
				fermentation = obj;
				return result;
			}
		}

		public override bool Visible => hideResource.Visible;

		public bool HasDisposed { get; protected set; }

		public event Action<IGameDisposable> OnDisposedEvent;

		public virtual void Dispose()
		{
			if (!HasDisposed)
			{
				DetachAllEvents();
				if (ResourcePileInstance != null)
				{
					ResourcePileInstance.OnReservedEvent -= OnReserveeChanged;
					ResourcePileInstance.OnReleasedEvent -= OnReserveeChanged;
					ResourcePileInstance.ForbidChangeEvent -= UpdateIndicator;
					ResourcePileInstance.UrgentHaulChangeEvent -= UpdateIndicator;
					ResourcePileInstance.OnResourceAddedEvent -= OnPileResourceCountChanged;
					ResourcePileInstance.OnResourceTakenEvent -= OnPileResourceCountChanged;
				}
				ResourcePileInstance?.Dispose();
				PickPile();
				DestroySelectableObject();
				if (indicatorUI != null)
				{
					UnityEngine.Object.Destroy(indicatorUI);
					indicatorUI = null;
				}
				HasDisposed = true;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				ResourcePileInstance = null;
				this.OnDisposedEvent = null;
			}
		}

		protected override bool IsSelectionNull()
		{
			if (ResourcePileInstance != null)
			{
				return ResourcePileInstance.HasDisposed;
			}
			return true;
		}

		protected override void Awake()
		{
			base.Awake();
			if (hideResource != null)
			{
				MonoSingleton<OcclusionCullingManager>.Instance.RegisterObject(hideResource);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			using (ProfilerSampleJanitor.Begin("Selection Manager Unsubscribe"))
			{
				if (MonoSingleton<SelectionManager>.IsInstantiated())
				{
					MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent -= OnSelectionHighlight;
					MonoSingleton<SelectionManager>.Instance.AllowOrForbidEvent -= OnForbidOrAllowPile;
					MonoSingleton<SelectionManager>.Instance.UrgentHaulEvent -= OnUrgentHaulPile;
				}
			}
			if (MonoSingleton<OcclusionCullingManager>.IsInstantiated())
			{
				MonoSingleton<OcclusionCullingManager>.Instance.UnregisterObject(hideResource);
			}
		}

		public string GetAdditionalMenuId()
		{
			ResourceInstance resourceInstance = ResourcePileInstance?.GetStoredResource();
			if (resourceInstance == null)
			{
				return "";
			}
			if (resourceInstance is CarcassResourceInstance)
			{
				return "resourcePileCarcass";
			}
			if ((resourceInstance.Blueprint.Category & ResourceCategory.CtgAlcohol) != ResourceCategory.None)
			{
				return "resourcePileAlcohol";
			}
			if ((resourceInstance.Blueprint.Category & ResourceCategory.CtgEdible) != ResourceCategory.None)
			{
				return "resourcePileEdible";
			}
			if ((resourceInstance.Blueprint.Category & ResourceCategory.CtgItem) != ResourceCategory.None)
			{
				return "resourcePileItem";
			}
			return "resourcePile";
		}

		public IGoapTargetable GetAsTarget()
		{
			return ResourcePileInstance;
		}

		public Transform GetGuiOverlayHookTransform()
		{
			return base.transform;
		}

		public bool ShouldMenuFollowHookTransform()
		{
			return true;
		}

		public override WorldObject GetAsWorldObject()
		{
			return ResourcePileInstance;
		}

		public virtual void DetachAllEvents()
		{
			if (MonoSingleton<SelectionManager>.IsInstantiated())
			{
				MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent -= OnSelectionHighlight;
				MonoSingleton<SelectionManager>.Instance.AllowOrForbidEvent -= OnForbidOrAllowPile;
				MonoSingleton<SelectionManager>.Instance.UrgentHaulEvent -= OnUrgentHaulPile;
			}
			if (ResourcePileInstance != null)
			{
				ResourcePileInstance.ForbidChangeEvent -= UpdateIndicator;
				ResourcePileInstance.UrgentHaulChangeEvent -= UpdateIndicator;
				ResourcePileInstance.Stats?.Controller.RemoveListener(OnStatUpdated);
				ResourcePileInstance.OnResourceAddedEvent -= OnPileResourceCountChanged;
				ResourcePileInstance.OnResourceTakenEvent -= OnPileResourceCountChanged;
			}
			if (MonoSingleton<SelectionManager>.IsInstantiated())
			{
				MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent -= OnSelectionHighlight;
				MonoSingleton<SelectionManager>.Instance.AllowOrForbidEvent -= OnForbidOrAllowPile;
				MonoSingleton<SelectionManager>.Instance.UrgentHaulEvent -= OnUrgentHaulPile;
			}
			indicatorUI?.SetIndicator(ResourcePileIndicatorStatus.None);
		}

		internal override void Select()
		{
			base.Select();
			if (base.Selected)
			{
				MonoSingleton<ResourcePileController>.Instance.OnPileSelected(ResourcePileInstance);
			}
		}

		public virtual void Setup(ResourcePileInstance resourcePileInstance)
		{
			indicatorUI = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, NSMedieval.Model.KeyGameObjectPair>.Instance.GetByAddress("resource_pile_indicator"), base.transform.position + Vector3.up * 0.5f, Quaternion.identity, base.transform).GetComponent<ResourcePileIndicatorView>();
			resourcePileInstance.OnReservedEvent += OnReserveeChanged;
			resourcePileInstance.OnReleasedEvent += OnReserveeChanged;
			ResourcePileInstance = resourcePileInstance;
			ResourcePileInstance.ForbidChangeEvent += UpdateIndicator;
			ResourcePileInstance.UrgentHaulChangeEvent += UpdateIndicator;
			resourcePileInstance.Stats.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Freshness, OnStatUpdated);
			resourcePileInstance.Stats.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Fermentation, OnStatUpdated);
			resourcePileInstance.Stats.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Health, OnStatUpdated);
			resourcePileInstance.Stats.Controller.RegisterListener(StatEventType.AttributeModiferAdded, OnStatUpdated);
			resourcePileInstance.OnResourceAddedEvent += OnPileResourceCountChanged;
			resourcePileInstance.OnResourceTakenEvent += OnPileResourceCountChanged;
			MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent += OnSelectionHighlight;
			MonoSingleton<SelectionManager>.Instance.AllowOrForbidEvent += OnForbidOrAllowPile;
			MonoSingleton<SelectionManager>.Instance.UrgentHaulEvent += OnUrgentHaulPile;
			UpdateIndicator(ResourcePileInstance);
			if (MonoSingleton<World>.Instance.IsLoaded)
			{
				TriggerParticles();
			}
			SetupMeshVariations(resourcePileInstance);
			StartCoroutine(UpdateReachablePositions());
		}

		public void ResetMeshTransform()
		{
			try
			{
				meshTransform.localEulerAngles = Vector3.zero;
				meshTransform.localPosition = Vector3.zero;
				meshTransform.localScale = Vector3.one;
			}
			catch (Exception ex)
			{
				Log.Error(ex.StackTrace, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\ResourcePileView.cs");
				throw;
			}
		}

		public void SetupMeshVariations(ResourcePileInstance resourcePileInstance)
		{
			Resource blueprint = resourcePileInstance.Blueprint;
			if (!resourcePileInstance.IsPlacedOnStorageBuilding)
			{
				blueprint.GetPileTransformSettings()?.ApplyToTransform(meshTransform);
			}
			if (blueprint.VariationLists != null)
			{
				UpdateMaterialParameters(blueprint);
				if (blueprint.HasQuality)
				{
					ChangeMeshAccordingToResourceQuality(blueprint);
				}
				else
				{
					ChangeMeshAccordingToResourceAmount(blueprint);
				}
				return;
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\ResourcePileView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(ResourcePileInstance.Blueprint.GetID());
				messageBuilder.AppendLiteral(" variations are null");
			}
			Log.Error(messageBuilder);
		}

		public void SetupMeshVariations(Resource resource)
		{
			resource.GetPileTransformSettings()?.ApplyToTransform(meshTransform);
			if (resource.VariationLists != null)
			{
				UpdateMaterialParameters(resource);
				if (resource.HasQuality)
				{
					ChangeMeshAccordingToResourceQuality(resource);
				}
				else
				{
					ChangeMeshAccordingToResourceAmount(resource);
				}
				return;
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\ResourcePileView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(ResourcePileInstance.Blueprint.GetID());
				messageBuilder.AppendLiteral(" variations are null");
			}
			Log.Error(messageBuilder);
		}

		public override InfoPanelData UpdateCallback()
		{
			if (ResourcePileInstance == null)
			{
				return null;
			}
			if (ResourcePileInstance == null || ResourcePileInstance.HasDisposed || ResourcePileInstance.Blueprint == null || ResourcePileInstance.GetStoredResource() == null)
			{
				return null;
			}
			if (PileTooltipView != null)
			{
				PileTooltipView.RefreshTooltip();
			}
			return GetInfoPanelData();
		}

		public override InfoPanelData GetInfoPanelData()
		{
			if (ResourcePileInstance == null || ResourcePileInstance.HasDisposed)
			{
				return null;
			}
			string blueprintId = ResourcePileInstance.BlueprintId;
			InfoPanelHeader headerData = GetHeaderData();
			InfoPanelBody body = new InfoPanelBody(blueprintId + "_pile", ResourceUtils.GetLocalizedResourcePileName(ResourcePileInstance.Blueprint.GetID()), GetMaterial(), GetInfoStats(), GetModifiers(), GetResourcesInfo(), GetDescriptions(), GetInfos(), GetLifeEventLog(), DecayModifierUtils.GetDecayModifiers(ResourcePileInstance));
			InfoPanelFooter footer = new InfoPanelFooter(GetInfoPanelActions());
			return new InfoPanelData(InfoPanelDataType.General, headerData, body, footer);
		}

		protected LinkedList<LifeEventLogStruct> GetLifeEventLog()
		{
			return ResourcePileInstance?.GetStoredResource()?.LifeEventLogs;
		}

		protected virtual string GetMaterial()
		{
			return string.Empty;
		}

		public override string GetMultiselectName()
		{
			return "resource_pile";
		}

		public override string GetSimpleName()
		{
			return ResourceUtils.GetLocalizedResourceName(ResourcePileInstance.Blueprint);
		}

		protected override void OnPointerEnter(Vector3 pos)
		{
			OrderType orderType = MonoSingleton<SelectionManager>.Instance.OrderType;
			if (orderType == OrderType.None)
			{
				base.OnPointerEnter(pos);
			}
			else if (OrderShouldHighlightMe(orderType))
			{
				base.OnPointerEnter(pos);
			}
		}

		protected virtual string GetResourceName()
		{
			if (ResourcePileInstance == null || ResourcePileInstance.HasDisposed || ResourcePileInstance.Blueprint == null)
			{
				return string.Empty;
			}
			return ResourcePileUtils.GetFormattedPileName(ResourcePileInstance);
		}

		protected InfoPanelHeader GetHeaderData()
		{
			return new InfoPanelHeader(ResourcePileInstance?.BlueprintId + "_pile", GetResourceName(), string.Empty);
		}

		protected List<InfoPanelStat> GetInfoStats()
		{
			List<InfoPanelStat> list = new List<InfoPanelStat>();
			if (Health != null && Health.Max > 0f)
			{
				float num = ResourcePileInstance?.GetStoredResource()?.GetHealthInPercentage() ?? (-1f);
				if (num > -0.5f)
				{
					int num2 = Mathf.RoundToInt(Health.Current);
					int num3 = Mathf.RoundToInt(Health.Max);
					if (num2 == num3 && num < 100f)
					{
						num2--;
					}
					list.Add(new InfoPanelStat("menu_hit_points", "/", new IntRange(num2, num3), StatType.Health));
				}
				else
				{
					list.Add(new InfoPanelStat("menu_hit_points", "/", new IntRange(Mathf.RoundToInt(Health.Current), Mathf.RoundToInt(Health.Max)), StatType.Health));
				}
			}
			if (Freshenss == null)
			{
				return list;
			}
			if (ResourcePileInstance.Blueprint.RottingModifiers != null)
			{
				float num4 = ResourcePileInstance.Blueprint.RottingModifiers.GroundCoefficient;
				if (ResourcePileInstance.Blueprint.RottingModifiers.TemperatureCoefficients != null)
				{
					float[] temperatureCoefficients = ResourcePileInstance.Blueprint.RottingModifiers.TemperatureCoefficients;
					foreach (float num5 in temperatureCoefficients)
					{
						num4 += num5;
					}
				}
				if (num4 > 0f && Freshenss.Max > 0f)
				{
					list.Add(new InfoPanelStat("menu_rot", "%", new IntRange(Mathf.RoundToInt(Freshenss.Current), Mathf.RoundToInt(Freshenss.Max)), string.Empty, Freshenss.StatTrend, StatType.Freshness));
				}
			}
			if (Fermentation == null)
			{
				return list;
			}
			if (ResourcePileInstance.Blueprint.FermentingModifiers != null)
			{
				float num6 = ResourcePileInstance.Blueprint.FermentingModifiers.GroundCoefficient;
				if (ResourcePileInstance.Blueprint.FermentingModifiers.TemperatureCoefficients != null)
				{
					float[] temperatureCoefficients = ResourcePileInstance.Blueprint.FermentingModifiers.TemperatureCoefficients;
					foreach (float num7 in temperatureCoefficients)
					{
						num6 += num7;
					}
				}
				StatTrend trend = (Fermentation.StatTrend.Equals(StatTrend.Down) ? StatTrend.Up : StatTrend.Down);
				if (Fermentation.StatTrend.Equals(StatTrend.None))
				{
					trend = StatTrend.None;
				}
				if (num6 > 0f && Fermentation.Max > 0f)
				{
					list.Add(new InfoPanelStat("menu_ferment", "%", new IntRange(Mathf.RoundToInt(Fermentation.Current), Mathf.RoundToInt(Fermentation.Max)), string.Empty, trend, StatType.Fermentation));
				}
			}
			return list;
		}

		protected virtual List<string> GetModifiers()
		{
			List<string> list = new List<string>();
			if (ResourcePileInstance == null || ResourcePileInstance.HasDisposed || ResourcePileInstance.Blueprint == null || ResourcePileInstance.Stats == null)
			{
				return list;
			}
			if (LocKeyUtils.GetTooltipLines(ResourcePileInstance.Blueprint.LocKeys, out var lines))
			{
				string[] array = lines;
				foreach (string text in array)
				{
					if (text.Equals("resource_tooltip_ice_room"))
					{
						list.Add(MonoSingleton<LocalizationController>.Instance.GetText(text).Replace("<zero_temp>", WorldDate.GetLocalizedTemperature(0f)));
					}
					else
					{
						list.Add(MonoSingleton<LocalizationController>.Instance.GetText(text));
					}
				}
				list.Add(string.Empty);
			}
			float num = ((!(ResourcePileInstance.Blueprint.NutritionPerHp > 0f)) ? ResourcePileInstance.Blueprint.Nutrition : (ResourcePileInstance.Blueprint.NutritionPerHp * ResourcePileInstance.GetStatValue(StatType.Health)));
			if (num > 0f)
			{
				list.Add(string.Format("{0}: <style=AltColor>{1}</style>", MonoSingleton<LocalizationController>.Instance.GetText("menu_nutrition"), (int)num));
			}
			if (ResourcePileInstance.IsForbidden)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("forbidden_resource_info") ?? "");
			}
			Room room = ResourcePileInstance.GetRoom();
			if (room != null)
			{
				string text2 = ColorUtility.ToHtmlStringRGB(room.RoomType.Color);
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("inside") + ": <color=#" + text2 + "><link=\"select_room\"><style=LinkRoom>" + room.GetRoomTypeLocalized() + " (" + room.Impressiveness?.NameLocalized + ")</style></link></color>");
			}
			list.AddIfNotNullOrEmpty(UiUtils.GetReservedByLocalized(ResourcePileInstance));
			return list;
		}

		protected virtual List<string> GetInfos()
		{
			List<string> list = new List<string>();
			ResourceInstance storedResource = ResourcePileInstance.GetStoredResource();
			if (ResourcePileInstance == null || ResourcePileInstance.HasDisposed || ResourcePileInstance.Blueprint == null || storedResource == null)
			{
				return list;
			}
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <style=AltColor>{1}</style>", MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points"), ResourcePileInstance.Blueprint.Hitpoints), ResourcePileInstance.Blueprint.Hitpoints, 0f);
			list.AddIfNotNull(string.Format("{0}: <style=AltColor>{1}, {2}, {3}</style>", MonoSingleton<LocalizationController>.Instance.GetText("global_position"), ResourcePileInstance.WorldPosition.x, ResourcePileInstance.WorldPosition.y, ResourcePileInstance.WorldPosition.z), ResourcePileInstance.WorldPosition);
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <style=AltColor>{1}kg</style>", MonoSingleton<LocalizationController>.Instance.GetText("menu_character_weight"), ResourcePileInstance.Blueprint.Weight), ResourcePileInstance.Blueprint.Weight, 0f);
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <style=AltColor>{1}</style>", MonoSingleton<LocalizationController>.Instance.GetText("max_stack"), ResourcePileInstance.Blueprint.StackingLimit), ResourcePileInstance.Blueprint.StackingLimit, 1f);
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("resource_categories") + ": " + ResourceUtils.GetLocalizedCategories(ResourcePileInstance.Blueprint));
			list.Add(string.Format("{0}: <style=AltColor>{1:F1}</style>", MonoSingleton<LocalizationController>.Instance.GetText("info_panel_wealth"), ResourcePileInstance.GetWealth()));
			list.Add(ResourcePileInstance.IsStoredOnStockpile() ? (MonoSingleton<LocalizationController>.Instance.GetText("is_on_stockpile") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_true") + "</style>") : (MonoSingleton<LocalizationController>.Instance.GetText("is_on_stockpile") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_false") + "</style>"));
			list.Add(MonoSingleton<StorageCommonManager>.Instance.CanStoreAnywhere(storedResource) ? (MonoSingleton<LocalizationController>.Instance.GetText("is_storable_on_some_stockpile") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_true") + "</style>") : (MonoSingleton<LocalizationController>.Instance.GetText("is_storable_on_some_stockpile") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_false") + "</style>"));
			list.Add(MonoSingleton<ResourcePileHaulingManager>.Instance.IsMarkedForHauling(ResourcePileInstance) ? (MonoSingleton<LocalizationController>.Instance.GetText("is_marked_for_hauling") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_true") + "</style>") : (MonoSingleton<LocalizationController>.Instance.GetText("is_marked_for_hauling") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_false") + "</style>"));
			list.AddIfNotNullOrEmpty(GetProducer());
			if (ResourcePileInstance.Blueprint.CaloriesCount > 0f)
			{
				list.Add(string.Format("{0}: <style=AltColor>{1}</style>", MonoSingleton<LocalizationController>.Instance.GetText("fuel_strength"), ResourcePileInstance.Blueprint.CaloriesCount));
			}
			AddBeautyToList(list);
			return list;
		}

		protected string GetProducer()
		{
			string producerName = ResourcePileInstance.GetProducerName();
			if (!string.IsNullOrEmpty(producerName))
			{
				return MonoSingleton<LocalizationController>.Instance.GetText("made_by") + " " + producerName;
			}
			return string.Empty;
		}

		private void AddBeautyToList(List<string> list)
		{
			stringBuilder.Clear();
			stringBuilder.Append(MonoSingleton<LocalizationController>.Instance.GetText("menu_beauty_points"));
			if (ResourcePileInstance.PlacedOnStorage != null && ResourcePileInstance.PlacedOnStorage is WorldObject { GridDataType: not GridDataType.Stockpile })
			{
				if (ResourcePileInstance.Blueprint.HasOnShelfBeauty)
				{
					stringBuilder.Append(" (" + MonoSingleton<LocalizationController>.Instance.GetText("menu_beauty_points_on_shelf") + ")");
				}
			}
			else if (ResourcePileInstance.Blueprint.HasInsideBeauty && ResourcePileInstance.GetRoom() != null)
			{
				stringBuilder.Append(" (" + MonoSingleton<LocalizationController>.Instance.GetText("inside") + ")");
			}
			stringBuilder.Append($": <style=AltColor>{ResourcePileInstance.GetBeautyInput()}</style>");
			list.Add(stringBuilder.ToString());
			ResourceInstance resourceInstance = ResourcePileInstance.GetStorage()?.GetSingleResource();
			if (resourceInstance != null && !resourceInstance.HasDisposed && resourceInstance.Blueprint.EquipmentBlueprint != null)
			{
				float beautyInputEquipped = resourceInstance.Blueprint.EquipmentBlueprint.GetBeautyInputEquipped();
				if (beautyInputEquipped > 0f)
				{
					list.Add(string.Format("{0} ({1}): <style=AltColor>{2}</style>", MonoSingleton<LocalizationController>.Instance.GetText("menu_beauty_points"), MonoSingleton<LocalizationController>.Instance.GetText("equipped"), beautyInputEquipped));
				}
			}
		}

		protected virtual List<InfoPanelAction> GetInfoPanelActions()
		{
			if (TutorialManager.IsTutorialActive)
			{
				return new List<InfoPanelAction>();
			}
			if (ResourcePileInstance == null || ResourcePileInstance.HasDisposed || !ResourcePileInstance.OwnedByPlayer())
			{
				return new List<InfoPanelAction>();
			}
			int currentIndex = (ResourcePileInstance.IsForbidden ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Forbid"), delegate
				{
					ForbidPile(forbid: true);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Allow"), delegate
				{
					ForbidPile(forbid: false);
				})
			};
			if (!ResourcePileInstance.CanBeHauled)
			{
				return new List<InfoPanelAction>
				{
					new InfoPanelAction(objectActions, currentIndex)
				};
			}
			int currentIndex2 = (ResourcePileInstance.IsUrgentHaul ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions2 = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("UrgentHaul"), delegate
				{
					UrgentHaulPile(urgentHaul: true);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
				{
					UrgentHaulPile(urgentHaul: false);
				})
			};
			return new List<InfoPanelAction>
			{
				new InfoPanelAction(objectActions, currentIndex),
				new InfoPanelAction(objectActions2, currentIndex2)
			};
		}

		private void UrgentHaulPile(bool urgentHaul)
		{
			if (ResourcePileInstance != null && !ResourcePileInstance.HasDisposed)
			{
				ResourcePileInstance.IsUrgentHaul = urgentHaul;
			}
		}

		private void ForbidPile(bool forbid)
		{
			if (ResourcePileInstance != null && !ResourcePileInstance.HasDisposed)
			{
				ResourcePileInstance.IsForbidden = forbid;
				UpdateViewImmediate();
			}
		}

		protected virtual List<InfoPanelResource> GetResourcesInfo()
		{
			return new List<InfoPanelResource>();
		}

		protected virtual List<string> GetDescriptions()
		{
			if (string.IsNullOrEmpty(ResourcePileInstance.Blueprint.BuildingBlueprintID))
			{
				return new List<string> { TextFormatting.FormatTextVariables(ResourceUtils.GetLocalizedResourceInfo(ResourcePileInstance.Blueprint.GetID())) };
			}
			return new List<string> { TextFormatting.FormatTextVariables(BuildingUtils.GetLocalizedInfo(ResourcePileInstance.Blueprint.BuildingBlueprintID)) };
		}

		protected virtual void PickPile()
		{
			if ((bool)hideResource)
			{
				hideResource.RemoveFromCache();
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void UpdateIndicator(IForbidable pileInstance)
		{
			if (pileInstance == ResourcePileInstance && ResourcePileInstance != null && !ResourcePileInstance.HasDisposed)
			{
				if (PileTooltipView != null)
				{
					PileTooltipView.RefreshTooltip();
				}
				ResourcePileIndicatorStatus indicator = ResourcePileIndicatorStatus.None;
				if (ResourcePileInstance.IsForbidden)
				{
					indicator = ResourcePileIndicatorStatus.Forbidden;
				}
				else if (ResourcePileInstance.IsUrgentHaul)
				{
					indicator = ResourcePileIndicatorStatus.UrgentHaul;
				}
				indicatorUI.SetIndicator(indicator);
			}
		}

		private void TriggerParticles()
		{
			MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(activateParticles, base.transform.position);
		}

		private void ChangeMeshAccordingToResourceAmount(Resource resource)
		{
			int num = 1;
			if (ResourcePileInstance != null)
			{
				num = ResourcePileInstance.GetStoredResource()?.Amount ?? 0;
			}
			if (num != currentMeshResourceAmount && MeshVariationUtils.GetCountVariations(resource.VariationsById, out var variationList))
			{
				int count = variationList.Variations.Count;
				if (num > 0 && count != 0)
				{
					float num2 = resource.StackingLimit;
					currentMeshResourceAmount = num;
					int num3 = (int)Math.Ceiling(num2 / (float)count);
					int variationIndex = Mathf.Clamp(num / num3, 0, count - 1);
					meshVariationHandler.UpdateVariationByIndex(variationList, variationIndex, null);
				}
			}
		}

		private void ChangeMeshAccordingToResourceQuality(Resource resource)
		{
			if (MeshVariationUtils.GetQualityVariations(resource.VariationsById, out var variationList))
			{
				int variationIndex = 1;
				if (ResourcePileInstance != null)
				{
					variationIndex = Mathf.Clamp((int)(ResourcePileInstance.GetQuality() - 1), 0, EnumValues.ProductionQualities.Length);
				}
				meshVariationHandler.UpdateVariationByIndex(variationList, variationIndex, null);
			}
		}

		private void UpdateMaterialParameters(Resource resource)
		{
			if (!MeshVariationUtils.GetMaterialParameters(resource.VariationsById, out var variationList))
			{
				return;
			}
			if (meshVariationHandler == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(0, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\ResourcePileView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(resource.GetID());
				}
				Log.Error(messageBuilder);
			}
			else
			{
				meshVariationHandler.UpdateAllFromList(variationList, null);
			}
		}

		public void OnPileResourceCountChanged(ResourcePileInstance pile, Resource blueprint, int amount)
		{
			ResourceInstance storedResource = pile.GetStoredResource();
			if (storedResource != null && storedResource.Amount != 0)
			{
				ChangeMeshAccordingToResourceAmount(ResourcePileInstance.Blueprint);
			}
		}

		public void OnPileResourceCountChanged()
		{
			ResourceInstance storedResource = ResourcePileInstance.GetStoredResource();
			if (storedResource != null && storedResource.Amount != 0)
			{
				ChangeMeshAccordingToResourceAmount(ResourcePileInstance.Blueprint);
			}
		}

		private void OnReserveeChanged(IReservable item, IGoapAgentOwner agent)
		{
			if (base.Selected)
			{
				_ = ResourcePileInstance;
			}
		}

		private bool OrderShouldHighlightMe(OrderType orderType)
		{
			OrderAllowType orderAllowType = MonoSingleton<SelectionManager>.Instance.OrderAllowType;
			if (orderType == OrderType.Cancel && ResourcePileInstance.IsUrgentHaul)
			{
				return true;
			}
			if (orderType == OrderType.UrgentHaul && !ResourcePileInstance.IsUrgentHaul)
			{
				return true;
			}
			if (orderType == OrderType.Allow && ResourcePileInstance.IsForbidden)
			{
				return orderAllowType.HasFlag(OrderAllowType.Piles);
			}
			if (orderType == OrderType.Forbid && !ResourcePileInstance.IsForbidden)
			{
				return orderAllowType.HasFlag(OrderAllowType.Piles);
			}
			return false;
		}

		private void OnSelectionHighlight(OrderEventData eventData)
		{
			if (base.gameObject == null || base.transform == null)
			{
				if (MonoSingleton<SelectionManager>.IsInstantiated())
				{
					MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent -= OnSelectionHighlight;
				}
			}
			else
			{
				if ((int)(base.transform.position.y / (float)World.MapBlockHeight) > MonoSingleton<World>.Instance.ElevationLevel || ResourcePileInstance == null || ResourcePileInstance.HasDisposed || !ResourcePileInstance.OwnedByPlayer() || !OrderShouldHighlightMe(eventData.OrderType))
				{
					return;
				}
				if (SelectionManager.IsWithinSelectionBounds(base.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y))
				{
					if (!eventData.AffectOnlyOneLayer || (int)base.transform.position.y == (int)eventData.Y)
					{
						ShowHighlight();
					}
				}
				else
				{
					HideHighlight();
				}
			}
		}

		private void OnForbidOrAllowPile(OrderEventData eventData)
		{
			if (ResourcePileInstance == null || ResourcePileInstance.HasDisposed || !ResourcePileInstance.OwnedByPlayer() || !ObjectIsSelectedByOrder(eventData) || !eventData.OrderAllowType.HasFlag(OrderAllowType.Piles))
			{
				return;
			}
			if (eventData.OrderType.Equals(OrderType.Allow))
			{
				ResourcePileInstance.IsForbidden = false;
				return;
			}
			ResourcePileInstance.IsForbidden = true;
			if (PileTooltipView != null)
			{
				PileTooltipView.RefreshTooltip();
			}
		}

		public void OnUrgentHaulPile(OrderEventData eventData)
		{
			if (eventData.OrderType != OrderType.UrgentHaul && eventData.OrderType != OrderType.Cancel)
			{
				Debug.LogError($"OnUrgentHaulPile callback invoked with unsupported OrderType '{eventData.OrderType}'");
			}
			else if (ResourcePileInstance != null && !ResourcePileInstance.HasDisposed && ResourcePileInstance.OwnedByPlayer() && ObjectIsSelectedByOrder(eventData))
			{
				ResourcePileInstance.IsUrgentHaul = eventData.OrderType != OrderType.Cancel;
				if (PileTooltipView != null)
				{
					PileTooltipView.RefreshTooltip();
				}
			}
		}

		private IEnumerator UpdateReachablePositions()
		{
			yield return new WaitForSecondsRealtime(1f);
			ResourcePileInstance?.ForceRecalculateReachablePositions();
		}

		private void OnStatUpdated(object statInstance)
		{
		}

		public override void OnLeavingMainScene()
		{
			base.OnLeavingMainScene();
			ResourcePileInstance = null;
		}
	}
}
