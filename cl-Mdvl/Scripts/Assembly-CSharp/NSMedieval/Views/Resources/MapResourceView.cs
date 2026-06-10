using System;
using System.Collections.Generic;
using System.Text;
using Effects;
using Managers.Selection.EventData;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.DebugEvents;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Layers;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval_Pooling;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public abstract class MapResourceView<T> : SelectableObject, IAdditionalMenuOwner, IGameDisposable, IDisposable where T : MapResourceInstance
	{
		protected static readonly StringBuilder StringBuilder = new StringBuilder();

		[NonSerialized]
		private T resourceInstance;

		[NonSerialized]
		protected MapResource blueprint;

		[NonSerialized]
		private float gridDataPositionY;

		[SerializeField]
		private MeshRenderer mesh;

		[SerializeField]
		private MeshRenderer clickMesh;

		[SerializeField]
		private List<Collider> clickColliders = new List<Collider>();

		[SerializeField]
		private List<MeshRenderer> allMeshes = new List<MeshRenderer>();

		[SerializeField]
		private MeshVariationHandler meshVariationHandler;

		[SerializeField]
		private MeshVariationHandler particleMeshVariationHandler;

		private GameObject orderIcon;

		private LayerObjectHide layerObjectHide = new LayerObjectHide();

		public LayerObjectHide LayerObjectHide => layerObjectHide;

		public override bool Visible => layerObjectHide.Visible;

		public T ResourceInstance => resourceInstance;

		protected MeshRenderer Mesh => mesh;

		public bool HasDisposed { get; private set; }

		public event Action<IGameDisposable> OnDisposedEvent;

		public virtual void Dispose()
		{
			Dispose(destroyGameObject: true);
			T val = resourceInstance;
			resourceInstance = null;
			val?.Dispose();
			blueprint = null;
			this.OnDisposedEvent = null;
		}

		public virtual void Setup(T staticResourceInstance)
		{
			Setup(staticResourceInstance, staticResourceInstance.GetBlueprint(), staticResourceInstance.GridDataPosition);
		}

		public void Setup(T mapResourceInstance, MapResource blueprint, Vec3Int gridDataPosition)
		{
			resourceInstance = mapResourceInstance;
			this.blueprint = blueprint;
			gridDataPositionY = gridDataPosition.y;
			if (mapResourceInstance != null && mapResourceInstance.CurrentOrder != OrderType.None)
			{
				OnOrderRefreshed();
			}
			if (!(mesh == null))
			{
				SetupMeshVariations();
			}
		}

		private void SetupMeshVariations()
		{
			if (!(meshVariationHandler == null))
			{
				if (MeshVariationUtils.GetMeshVariations(blueprint.VariationsById, out var variationList))
				{
					meshVariationHandler.UpdateAllFromList(variationList, null);
				}
				if (MeshVariationUtils.GetMaterialParameters(blueprint.VariationsById, out var variationList2))
				{
					meshVariationHandler.UpdateAllFromList(variationList2, null);
				}
				if (MeshVariationUtils.GetParticleMaterialParameters(blueprint.VariationsById, out var variationList3))
				{
					particleMeshVariationHandler?.UpdateAllFromList(variationList3, null);
				}
			}
		}

		public abstract string GetAdditionalMenuId();

		public IGoapTargetable GetAsTarget()
		{
			return ResourceInstance;
		}

		public Transform GetGuiOverlayHookTransform()
		{
			return base.transform;
		}

		public bool ShouldMenuFollowHookTransform()
		{
			return true;
		}

		public void ForceHide(bool hidden)
		{
			if (hidden)
			{
				MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= layerObjectHide.RefreshVisibility;
				MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent -= layerObjectHide.RefreshVisibility;
			}
			else
			{
				MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent += layerObjectHide.RefreshVisibility;
				MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent += layerObjectHide.RefreshVisibility;
			}
		}

		public override string GetSimpleName()
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(blueprint?.LocKeys));
		}

		public override InfoPanelData GetInfoPanelData()
		{
			if (resourceInstance == null || resourceInstance.HasDisposed)
			{
				return null;
			}
			InfoPanelHeader headerData = GetHeaderData();
			InfoPanelBody body = new InfoPanelBody(blueprint.GetID(), MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(blueprint.LocKeys)), string.Empty, GetInfoStats(), GetModifiers(), GetModifierTooltips(), GetResourcesInfo(), new List<string> { MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(blueprint.LocKeys)) }, GetInfos());
			InfoPanelFooter footer = new InfoPanelFooter(GetInfoPanelActions());
			return new InfoPanelData(InfoPanelDataType.General, headerData, body, footer);
		}

		public override InfoPanelData UpdateCallback()
		{
			if (resourceInstance == null)
			{
				return null;
			}
			return GetInfoPanelData();
		}

		protected override bool IsSelectionNull()
		{
			if (resourceInstance != null)
			{
				return resourceInstance.HasDisposed;
			}
			return true;
		}

		protected override void OnPointerEnter(Vector3 pos)
		{
			if (resourceInstance == null)
			{
				return;
			}
			OrderType orderType = MonoSingleton<SelectionManager>.Instance.OrderType;
			if (orderType.Equals(OrderType.Chopping))
			{
				PlantLifePhaseType plantLifePhaseType = MonoSingleton<SelectionManager>.Instance.PlantLifePhaseType;
				if (plantLifePhaseType != PlantLifePhaseType.None && resourceInstance is PlantMapResourceInstance plantMapResourceInstance && plantMapResourceInstance.CurrentPhaseType != plantLifePhaseType)
				{
					return;
				}
			}
			if (orderType.Equals(OrderType.Cancel))
			{
				if (!resourceInstance.CurrentOrder.Equals(OrderType.None))
				{
					base.OnPointerEnter(pos);
				}
			}
			else if (resourceInstance.GetPossibleOrders().HasFlag(orderType) || orderType.HasFlag(OrderType.Cancel))
			{
				base.OnPointerEnter(pos);
			}
		}

		protected virtual void OnOrderResourceCollectionEvent(OrderEventData eventData)
		{
			if (MonoSingleton<World>.IsInstantiated() && !(this == null) && !(base.transform == null) && (int)(base.transform.position.y / (float)World.MapBlockHeight) <= MonoSingleton<World>.Instance.ElevationLevel && SelectionManager.IsWithinSelectionBounds(base.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y) && (!eventData.AffectOnlyOneLayer || (int)base.transform.position.y == (int)eventData.Y))
			{
				if (eventData.OrderType.Equals(OrderType.Cancel))
				{
					CancelOrder(eventData.OrderType);
				}
				else if ((eventData.OrderType.Equals(OrderType.Chopping) || eventData.OrderType.Equals(OrderType.CutAllVegetation)) && MonoSingleton<PlantResourceManager>.Instance.InstantCut && resourceInstance is PlantMapResourceInstance plantMapResourceInstance)
				{
					plantMapResourceInstance.SetLastPhase();
				}
				else
				{
					SelectItem(eventData.OrderType);
				}
			}
		}

		public void SelectItem(OrderType orderType, bool showErrorMessage = false)
		{
			if (resourceInstance == null)
			{
				return;
			}
			if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.LeftControl))
			{
				ClickedJumpToLowerLayer();
			}
			else if (!resourceInstance.GetPossibleOrders().HasFlag(orderType))
			{
				if (showErrorMessage)
				{
					ConstructSelectionErrorMessage(orderType);
				}
			}
			else
			{
				GiveOrder(orderType);
			}
		}

		protected virtual void Dispose(bool destroyGameObject)
		{
			if (!HasDisposed)
			{
				HasDisposed = true;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				this.OnDisposedEvent = null;
				Deselect();
				DestroySelectableObject();
				if (destroyGameObject)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}

		protected override void Start()
		{
			base.Start();
			layerObjectHide.SetupColliders(clickColliders);
			layerObjectHide.SetupMeshRenderers(allMeshes);
			layerObjectHide.Setup(gridDataPositionY, blueprint.LayerHideOffset, blueprint.LayerShadowOffset, LayerHideType.MapResource);
			layerObjectHide.RefreshVisibility(MonoSingleton<World>.Instance.ElevationLevel);
		}

		protected override void OnDestroy()
		{
			using (ProfilerSampleJanitor.Begin("Order Icon Dispose"))
			{
				if (orderIcon != null)
				{
					GameObjectPool.Return(orderIcon);
					orderIcon.transform.parent = null;
					orderIcon = null;
				}
			}
			using (ProfilerSampleJanitor.Begin("Click Detection Dispose"))
			{
				DestroySelectableObject();
			}
			base.OnDestroy();
		}

		protected virtual InfoPanelHeader GetHeaderData()
		{
			return new InfoPanelHeader(resourceInstance.BlueprintId, MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(blueprint.LocKeys)), string.Empty);
		}

		protected virtual List<InfoPanelStat> GetInfoStats()
		{
			List<InfoPanelStat> list = new List<InfoPanelStat>();
			if (HasDisposed || resourceInstance == null || resourceInstance.HasDisposed)
			{
				return list;
			}
			if (resourceInstance.Stats == null || resourceInstance.Stats.HasDisposed)
			{
				return list;
			}
			StatInstance stat = resourceInstance.GetStat(StatType.Health);
			list.Add(new InfoPanelStat("menu_hit_points", "/", new IntRange(Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max)), StatType.Health));
			return list;
		}

		protected virtual List<string> GetModifiers()
		{
			List<string> list = new List<string>();
			list.AddIfNotNullOrEmpty(UiUtils.GetReservedByLocalized(ResourceInstance));
			return list;
		}

		protected virtual List<string> GetModifierTooltips()
		{
			return null;
		}

		protected virtual List<InfoPanelResource> GetResourcesInfo()
		{
			return new List<InfoPanelResource>();
		}

		protected virtual List<string> GetInfos()
		{
			List<string> list = new List<string>();
			if (resourceInstance.Stats != null)
			{
				StatInstance stat = resourceInstance.Stats.GetStat(StatType.Health);
				if (stat != null)
				{
					list.Add(string.Format("{0}: <color=#ffeca8>{1}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points"), stat.Max));
				}
			}
			list.Add(string.Format("{0}: <color=#ffeca8>{1}, {2}, {3}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("global_position"), (int)resourceInstance.WorldPosition.x, (int)resourceInstance.WorldPosition.y, (int)resourceInstance.WorldPosition.z));
			if (ResourceInstance is PlantMapResourceInstance plantMapResourceInstance && !plantMapResourceInstance.BeautyBlocker())
			{
				list.Add(string.Format("{0}: <style=AltColor>{1}</style>", MonoSingleton<LocalizationController>.Instance.GetText("menu_beauty_points"), plantMapResourceInstance.GetBeautyInput()));
			}
			return list;
		}

		protected virtual List<InfoPanelAction> GetInfoPanelActions()
		{
			List<InfoPanelAction> list = new List<InfoPanelAction>();
			if (TutorialManager.IsTutorialActive)
			{
				return list;
			}
			OrderType orderType = ResourceInstance.GetPossibleOrders();
			if (resourceInstance != null && resourceInstance.CurrentOrder != OrderType.None)
			{
				orderType = resourceInstance.CurrentOrder;
			}
			bool flag = blueprint.MiningTool.Equals("axe_item");
			OrderType[] orderTypes = EnumValues.OrderTypes;
			for (int i = 0; i < orderTypes.Length; i++)
			{
				OrderType order = orderTypes[i];
				if ((orderType & order) == order && order != OrderType.None && (!flag || order != OrderType.CutAllVegetation))
				{
					int currentIndex = (ResourceInstance.CurrentOrder.HasFlag(order) ? 1 : 0);
					string id = order.ToString();
					KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[2]
					{
						new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID(id), delegate
						{
							GiveOrder(order);
						}),
						new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
						{
							CancelOrder(order);
						})
					};
					list.Add(new InfoPanelAction(objectActions, currentIndex, isToggle: false));
				}
			}
			return list;
		}

		public virtual void OnOrderRefreshed()
		{
			if (!HasDisposed)
			{
				SetOrderIcon();
			}
		}

		public static string GetOrderMarkPrefabName(OrderType order)
		{
			if ((order & OrderType.CutAllVegetation) != OrderType.None)
			{
				return "order_mark_cut";
			}
			if (order.HasFlag(OrderType.Chopping))
			{
				return "order_mark_chop";
			}
			if (order.HasFlag(OrderType.Harvesting))
			{
				return "order_mark_harvest";
			}
			if (order.HasFlag(OrderType.Fishing))
			{
				return "order_mark_fishing";
			}
			return string.Empty;
		}

		protected void SetOrderIcon()
		{
			string orderMarkPrefabName = GetOrderMarkPrefabName(ResourceInstance.CurrentOrder);
			if (string.IsNullOrEmpty(orderMarkPrefabName))
			{
				if (orderIcon != null)
				{
					GameObjectPool.Return(orderIcon);
					orderIcon.transform.parent = null;
					orderIcon = null;
				}
				return;
			}
			if (orderIcon == null || !orderIcon.name.Equals(orderMarkPrefabName))
			{
				if (orderIcon != null)
				{
					orderIcon.transform.parent = null;
					GameObjectPool.Return(orderIcon);
				}
				orderIcon = GameObjectPool.Get(orderMarkPrefabName);
				orderIcon.name = orderMarkPrefabName;
				orderIcon.transform.parent = base.transform;
				orderIcon.transform.localPosition = Vector3.zero;
			}
			MonoSingleton<OrderMarkAnimationManager>.Instance.AnimateOrderIcon(orderIcon.GetComponent<AnimatedRenderMeshes>());
		}

		public void GiveOrder(OrderType order)
		{
			if (resourceInstance == null || resourceInstance.HasDisposed)
			{
				return;
			}
			if ((order.Equals(OrderType.Chopping) || order.Equals(OrderType.CutAllVegetation)) && MonoSingleton<PlantResourceManager>.Instance.InstantCut && resourceInstance is PlantMapResourceInstance plantMapResourceInstance)
			{
				plantMapResourceInstance.SetLastPhase();
				return;
			}
			DebugEventLog.Write(new OrderIssued(ResourceInstance, order));
			resourceInstance.SetPlayerOrder(order != OrderType.None && order != OrderType.Cancel);
			resourceInstance.SetCurrentOrder(order);
			if (resourceInstance.PlayerOrder)
			{
				OnOrderRefreshed();
			}
			UpdateViewImmediate();
		}

		public virtual void CancelOrder(OrderType order)
		{
			if (resourceInstance != null && !resourceInstance.HasDisposed && resourceInstance.PlayerOrder)
			{
				DebugEventLog.Write(new OrderIssued(ResourceInstance, order));
				OrderType orderType = OrderType.None;
				if (order != OrderType.Cancel)
				{
					orderType = resourceInstance.CurrentOrder & ~order;
				}
				resourceInstance.SetPlayerOrder(orderType != OrderType.None);
				resourceInstance.SetCurrentOrder(orderType);
				UpdateViewImmediate();
			}
		}
	}
}
