using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Targeting;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Common.Events;
using ModApi.Common.UI;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Ioc;
using ModApi.Scripts.State.Validation;
using ModApi.Ui;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.MapView.Items
{
	public abstract class MapItem : MonoBehaviour, IOrbitInfoProvider, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public class ItemClickedEventArgs : EventArgs
		{
			public MapItem ItemClicked { get; private set; }

			public ItemClickedEventArgs(MapItem itemClicked)
			{
				ItemClicked = itemClicked;
			}
		}

		private static MapItem _currentTooltipMapItem;

		private static Dictionary<IOrbitNode, MapOrbitInfo> _orbitInfos = new Dictionary<IOrbitNode, MapOrbitInfo>();

		private IDrawModeProvider _drawModeProvider;

		private Canvas _infoCanvas;

		private TextMeshProUGUI _infoText;

		private Image _itemIcon;

		private MapItemCanvasScript _mapItemCanvas;

		private MapOrbitInfo _orbitInfo;

		private float? _tooltipHoverTime;

		private TextMeshProUGUI _tooltipText;

		public abstract ICameraFocusable AssociatedPlanetCameraFocusable { get; }

		public Camera Camera { get; private set; }

		public Color Color { get; protected set; }

		public IMapViewCoordinateConverter CoordinateConverter { get; private set; }

		public virtual bool DisplayManeuverNodeAdderOnMouseHover => false;

		public IDrawModeProvider DrawModeProvider => _drawModeProvider;

		public bool Hovered { get; private set; }

		public Canvas InfoCanvas => _infoCanvas;

		public IIocContainer Ioc { get; private set; }

		public Image ItemIcon
		{
			get
			{
				return _itemIcon;
			}
			private set
			{
				_itemIcon = value;
			}
		}

		public string ItemName { get; set; }

		public virtual Vector3 MapPosition => (Vector3)CoordinateConverter.ConvertSolarToMapView(OrbitInfo.OrbitNode.SolarPosition);

		public IMapViewContext MapViewContext { get; private set; }

		public MapOrbitInfo OrbitInfo => _orbitInfo;

		public bool Selectable { get; protected set; }

		public bool SupportsContextMenuSelection { get; protected set; }

		public string Text { get; set; } = string.Empty;

		public float UiCameraDist { get; private set; }

		public float UiMaxRenderDist { get; set; } = float.MaxValue;

		public float UiVisibilityAtItemPosition { get; private set; }

		public float UiVisibilityAtItemPositionUnclamped { get; private set; } = float.NegativeInfinity;

		protected IObjectContainerProvider ContainerProvider { get; private set; }

		protected bool IsTooltipVisible => _tooltipText?.gameObject.activeSelf ?? false;

		protected IItemRegistry ItemRegistry { get; private set; }

		protected virtual bool ShowTooltipOnHover => false;

		protected virtual string TooltipText => ((ITargetableItem)this)?.Name ?? ItemName;

		public static event EventHandler<ItemClickedEventArgs> ItemClicked
		{
			add
			{
				_itemClicked += WeakEventHandler.Create(value, delegate(EventHandler<ItemClickedEventArgs> x)
				{
					_itemClicked -= x;
				});
			}
			remove
			{
				_itemClicked -= WeakEventHandler.FindUnregisterHandler(MapItem._itemClicked, value);
			}
		}

		private static event EventHandler<ItemClickedEventArgs> _itemClicked;

		public static void OnMapItemManagerDestroyed(MapItemManager mapItemManager)
		{
			_currentTooltipMapItem = null;
		}

		public static T SwitchType<T>(MapItem current) where T : MapItem
		{
			IOrbitNode orbitNode = current.OrbitInfo.OrbitNode;
			MapItem mapItem = null;
			if (orbitNode is CraftNode)
			{
				current.OnSwitchingToNewType();
				IIocContainer ioc = current.Ioc;
				Camera mapCamera = ioc.Resolve<IMapView>(current.MapViewContext).MapCamera;
				CraftNode craftNode = orbitNode as CraftNode;
				Type typeFromHandle = typeof(T);
				if (typeFromHandle == typeof(MapPlayerCraft))
				{
					mapItem = MapPlayerCraft.Create(current.Ioc, current.MapViewContext, craftNode, mapCamera);
				}
				else if (typeFromHandle == typeof(MapCraft))
				{
					mapItem = MapCraft.Create(current.Ioc, current.MapViewContext, craftNode, mapCamera);
				}
				else if (typeFromHandle == typeof(MapStaticOrbitItem))
				{
					mapItem = MapStaticOrbitItem.Create(current.Ioc, current.MapViewContext, craftNode, mapCamera);
				}
				else
				{
					mapItem = null;
					UnityEngine.Debug.LogError($"Unsupported MapItem type to switch to: {typeFromHandle}");
				}
				ICurrentCameraTarget currentCameraTarget = ioc.Resolve<ICurrentCameraTarget>(current.MapViewContext);
				IMapView mapView = ioc.Resolve<IMapView>(current.MapViewContext);
				if (current is ICameraFocusable && mapView.MapViewInspector?.SelectedItem == current as ICameraFocusable)
				{
					if (mapItem is ICameraFocusable)
					{
						mapView.SetInspectorFocus(mapItem as ICameraFocusable, CameraTransitionSpeed.Fast, repositionCamDuringTransition: false);
					}
					else
					{
						mapView.SetInspectorFocus(currentCameraTarget.TargetsAssociatedPlanet, CameraTransitionSpeed.Fast, repositionCamDuringTransition: false);
					}
				}
				INavigationTargetProvider navigationTargetProvider = ioc.Resolve<INavigationTargetProvider>(current.MapViewContext);
				if (navigationTargetProvider.NavigationTarget != null && navigationTargetProvider.NavigationTarget == current as ITargetableItem)
				{
					navigationTargetProvider.SetNavigationTarget(mapItem as ITargetableItem);
				}
			}
			else
			{
				UnityEngine.Debug.LogError($"SwitchMapItemType does not currently support switching types for {orbitNode.GetType()}");
			}
			current.Destroy();
			return mapItem as T;
		}

		public virtual void AddContextMenuItem(IContextMenu contextMenu, PointerEventData eventData)
		{
			string text = (this as ITargetableItem)?.Name ?? ItemName;
			contextMenu.AddContextMenuItem("Select " + text, ItemIcon?.sprite, null, delegate
			{
				OnPointerClick(eventData);
			});
		}

		public void AddPointerNotifications(Canvas canvas)
		{
			PointerNotificationScript pointerNotificationScript = canvas.gameObject.AddComponent<PointerNotificationScript>();
			pointerNotificationScript.PointerClick += OnPointerClick;
			pointerNotificationScript.PointerEnterNoSource += OnPointerEnter;
			pointerNotificationScript.PointerExitNoSource += OnPointerExit;
			pointerNotificationScript.ScrollNoSource += OnScroll;
		}

		public virtual void Destroy()
		{
			UnityEngine.Object.Destroy(_infoCanvas.gameObject);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public virtual void OnAfterCameraPositioned()
		{
			UiCameraDist = (MapPosition - Camera.transform.position).magnitude;
			if (!string.IsNullOrEmpty(Text))
			{
				_infoText.color = OrbitInfo.OrbitColor;
				_infoText.text = Text;
				Vector3 textPosition = GetTextPosition();
				Vector2 uiCeterOffset = OrbitInfo.UiCeterOffset;
				_infoText.transform.position = new Vector3(textPosition.x + uiCeterOffset.x, textPosition.y + uiCeterOffset.y, 0f);
				_infoText.enabled = textPosition.z >= 0f;
			}
			else
			{
				_infoText.enabled = false;
			}
			if (!_tooltipHoverTime.HasValue)
			{
				return;
			}
			_tooltipHoverTime = _tooltipHoverTime.Value + Time.unscaledDeltaTime;
			if ((double)_tooltipHoverTime.Value > 0.25 && ShowTooltipOnHover && !ManeuverNodeManagerScript.NodeAdderIconVisible)
			{
				if (_tooltipText == null)
				{
					_tooltipText = UiUtils.CreateUiText(_infoCanvas.transform, "MapItemTooltip", clickable: false, TextAlignmentOptions.Midline);
					_tooltipText.rectTransform.pivot = new Vector2(0.5f, 0f);
					_tooltipText.text = TooltipText;
				}
				TextMeshProUGUI textMeshProUGUI = _currentTooltipMapItem?._tooltipText;
				if ((object)textMeshProUGUI != null && textMeshProUGUI != _tooltipText && textMeshProUGUI.gameObject.activeSelf)
				{
					textMeshProUGUI.gameObject.SetActive(value: false);
				}
				_currentTooltipMapItem = this;
				if (!_tooltipText.gameObject.activeSelf)
				{
					_tooltipText.gameObject.SetActive(value: true);
				}
			}
			else if ((object)_tooltipText != null && _tooltipText.gameObject.activeSelf)
			{
				_tooltipHoverTime = 0f;
				_tooltipText.gameObject.SetActive(value: false);
			}
		}

		public virtual void OnBeforeCameraPositioned()
		{
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (!eventData.dragging)
			{
				RaiseItemClicked(this);
			}
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (Selectable)
			{
				Hovered = true;
			}
			if (!Device.IsMobileBuild)
			{
				_tooltipHoverTime = 0f;
			}
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			if (Selectable)
			{
				Hovered = false;
			}
			_tooltipHoverTime = null;
			if (_tooltipText != null)
			{
				_tooltipText.gameObject.SetActive(value: false);
				if (this == _currentTooltipMapItem)
				{
					_currentTooltipMapItem = null;
				}
			}
		}

		public virtual void OnSwitchingToNewType()
		{
		}

		[Conditional("DEBUG")]
		[Conditional("UNITY_EDITOR")]
		public virtual void PerformValidityChecks()
		{
		}

		public void SetDrawModeProvider(IDrawModeProvider drawModeProvider)
		{
			_drawModeProvider = drawModeProvider;
		}

		public void UpdateUiComponentFromCurrentPosition(Component component, Canvas canvas, MapOrbitInfo orbitInfo, bool fadeOutWithDistance = true)
		{
			UiUtils.UpdateUiComponentFromCurrentPosition(component, orbitInfo, DrawModeProvider, CoordinateConverter, canvas, Camera, fadeOutWithDistance ? UiMaxRenderDist : float.PositiveInfinity);
		}

		public void UpdateUiComponentFromPoint(Component component, Canvas canvas, IOrbitPoint point)
		{
			UiUtils.UpdateUiComponentFromPoint(component, point, OrbitInfo, DrawModeProvider, CoordinateConverter, canvas, Camera, UiMaxRenderDist);
		}

		internal static void OnSceneTransition()
		{
			_orbitInfos.Clear();
			MapItem._itemClicked = null;
		}

		protected static T Create<T>(IIocContainer ioc, IMapViewContext mapViewContext, IOrbitNode node, string name, Transform canvasContainer, Camera mapCamera, Transform container, Sprite distanceIcon) where T : MapItem
		{
			GameObject go = new GameObject();
			go.name = $"{name}({go.GetInstanceID()}) ";
			go.transform.position = container.position;
			go.layer = container.gameObject.layer;
			T val = go.AddComponent<T>();
			val.Initialize(ioc, mapViewContext, node, name, canvasContainer, mapCamera, distanceIcon);
			ioc.Resolve<IItemRegistry>(mapViewContext).RegisterItem(val);
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				if (go != null)
				{
					go.transform.parent = container;
				}
			});
			return val;
		}

		protected virtual void Awake()
		{
		}

		protected virtual void FixedUpdate()
		{
		}

		protected virtual Vector3 GetScreenPos()
		{
			Vector3d vector3d = OrbitInfo.CoordinateConverter.ConvertSolarToMapView(_drawModeProvider.DrawMode.GetSolarPositionAtCurrent(OrbitInfo));
			return Utilities.GameWorldToScreenPoint(_infoCanvas.worldCamera, (Vector3)vector3d);
		}

		protected virtual Vector3 GetTextPosition()
		{
			return GetScreenPos();
		}

		protected virtual void LateUpdate()
		{
		}

		protected virtual void OnDestroy()
		{
			if ((object)this == _currentTooltipMapItem)
			{
				_currentTooltipMapItem = null;
			}
			ItemRegistry.UnregisterItem(this);
			OrbitInfo.OrbitNode.Destroyed -= OnNodeDestroyed;
			RemovePointerNotifications(_infoCanvas);
		}

		protected virtual void OnDisable()
		{
			if (_infoCanvas != null)
			{
				_infoCanvas.enabled = false;
			}
		}

		protected virtual void OnEnable()
		{
			if (_infoCanvas != null)
			{
				_infoCanvas.enabled = true;
			}
		}

		protected virtual void OnMapItemInitialized()
		{
		}

		protected virtual void OnNodeDestroyed(INode node)
		{
			Destroy();
		}

		protected virtual void Start()
		{
		}

		protected virtual void UpdateIconPosition()
		{
			UiUtils.UIComponentVisibility uIComponentVisibility = UiUtils.UpdateUiComponentFromCurrentPosition(ItemIcon, OrbitInfo, DrawModeProvider, CoordinateConverter, InfoCanvas, Camera, UiMaxRenderDist);
			UiVisibilityAtItemPositionUnclamped = uIComponentVisibility.VisibilityUnclamped;
			UiVisibilityAtItemPosition = uIComponentVisibility.Visibility;
		}

		protected virtual void UpdateTooltip()
		{
			if (IsTooltipVisible)
			{
				_tooltipText.rectTransform.localPosition = ItemIcon.rectTransform.localPosition;
				_tooltipText.text = TooltipText;
			}
		}

		private static Color GenerateColor()
		{
			return UnityEngine.Random.ColorHSV(0f, 1f, 0.4f, 0.6f, 0.4f, 0.6f);
		}

		private static MapOrbitInfo GetOrCreateOrbitInfo(IIocContainer ioc, IMapViewContext mapViewContext, IOrbitNode node, Camera mapCamera)
		{
			if (!_orbitInfos.ContainsKey(node))
			{
				MapOrbitInfo value = new MapOrbitInfo(ioc, mapViewContext, node, mapCamera, null);
				_orbitInfos.Add(node, value);
			}
			return _orbitInfos[node];
		}

		private static void RaiseItemClicked(MapItem itemClicked)
		{
			if (MapItem._itemClicked == null)
			{
				return;
			}
			ItemClickedEventArgs e = new ItemClickedEventArgs(itemClicked);
			Delegate[] invocationList = MapItem._itemClicked.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<ItemClickedEventArgs> eventHandler = (EventHandler<ItemClickedEventArgs>)invocationList[i];
				try
				{
					eventHandler(itemClicked, e);
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception);
				}
			}
		}

		private void Initialize(IIocContainer ioc, IMapViewContext mapViewContext, IOrbitNode node, string itemName, Transform canvasContainer, Camera mapCamera, Sprite distanceIcon)
		{
			Ioc = ioc;
			MapViewContext = mapViewContext;
			CoordinateConverter = ioc.Resolve<IMapViewCoordinateConverter>(mapViewContext);
			ContainerProvider = ioc.Resolve<IObjectContainerProvider>(mapViewContext);
			ItemRegistry = ioc.Resolve<IItemRegistry>(mapViewContext);
			_drawModeProvider = ioc.Resolve<IDrawModeProvider>(mapViewContext);
			_orbitInfo = GetOrCreateOrbitInfo(Ioc, MapViewContext, node, mapCamera);
			Color = GenerateColor();
			Selectable = false;
			Hovered = false;
			Camera = mapCamera;
			ItemName = itemName;
			_infoCanvas = new GameObject("InfoCanvas (" + itemName + ")").AddComponent<Canvas>();
			_infoCanvas.transform.SetParent(canvasContainer, worldPositionStays: false);
			_infoCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			_infoCanvas.worldCamera = Camera;
			_infoCanvas.gameObject.AddComponent<GraphicRaycaster>();
			_infoCanvas.additionalShaderChannels = AdditionalCanvasShaderChannels.TexCoord1 | AdditionalCanvasShaderChannels.Normal | AdditionalCanvasShaderChannels.Tangent;
			_infoCanvas.overrideSorting = true;
			_infoCanvas.sortingOrder = -node.NestedDepth - 10;
			_mapItemCanvas = _infoCanvas.gameObject.AddComponent<MapItemCanvasScript>();
			_mapItemCanvas.Initialize(this, _infoCanvas);
			_infoText = UiUtils.CreateUiText(_infoCanvas.transform, "Text", clickable: false, (TextAlignmentOptions)771);
			_infoText.rectTransform.pivot = new Vector2(0f, 0.5f);
			if (distanceIcon != null)
			{
				GameObject gameObject = new GameObject("ItemIcon");
				gameObject.transform.SetParent(_infoCanvas.transform, worldPositionStays: false);
				ItemIcon = gameObject.AddComponent<Image>();
				ItemIcon.sprite = distanceIcon;
				ItemIcon.raycastTarget = true;
				ItemIcon.gameObject.layer = _infoCanvas.gameObject.layer;
				ItemIcon.sprite = distanceIcon;
				ItemIcon.SetNativeSize();
			}
			node.Destroyed += OnNodeDestroyed;
			AddPointerNotifications(_infoCanvas);
			_infoCanvas.gameObject.AddComponent<OverrideSortingOnStart>();
			Utilities.FixUnityCanvasSortingBug(_infoCanvas);
			OnMapItemInitialized();
		}

		private void OnPointerClick(PointerNotificationScript source, PointerEventData eventData)
		{
			if (eventData.dragging)
			{
				return;
			}
			MapItemsAtPointerPosition mapItemsAtPointerPosition = (Game.InFlightScene ? ((MapViewScript)Game.Instance.FlightScene.ViewManager.MapViewManager.MapView) : null)?.MapViewUi.GetVisibleMapItemsAtPointer(eventData, _mapItemCanvas);
			if (mapItemsAtPointerPosition == null || mapItemsAtPointerPosition.ItemCount == 0 || !SupportsContextMenuSelection)
			{
				OnPointerClick(eventData);
				return;
			}
			IContextMenu contextMenu = Game.Instance.FlightScene.FlightSceneUI.ContextMenu;
			if (mapItemsAtPointerPosition.PlayerCraft != null)
			{
				mapItemsAtPointerPosition.PlayerCraft.AddContextMenuItem(contextMenu, eventData);
			}
			if (mapItemsAtPointerPosition.ManeuverNodeManager != null)
			{
				IGameStateValidator validator = Game.Instance.GameState.Validator;
				if (!validator.IsCareerMode || validator.IsItemAvailable("Map.Maneuver"))
				{
					mapItemsAtPointerPosition.ManeuverNodeManager.AddContextMenuItems(contextMenu, eventData);
				}
			}
			AddContextMenuItem(contextMenu, eventData);
			foreach (MapItemCanvasScript mapItem in mapItemsAtPointerPosition.MapItems)
			{
				mapItem.MapItem.AddContextMenuItem(contextMenu, eventData);
			}
			foreach (EncounterInfoScript encounterInfo in mapItemsAtPointerPosition.EncounterInfos)
			{
				encounterInfo.AddContextMenuItem(contextMenu);
			}
			contextMenu.ShowContextMenu(eventData.position);
		}

		private void OnScroll(PointerEventData eventData)
		{
			(MapViewManagerScript.Instance?.MapView as MapViewScript)?.MapCameraScript?.OnScroll(eventData);
		}

		private void RemovePointerNotifications(Canvas canvas)
		{
			if (canvas != null)
			{
				PointerNotificationScript component = canvas.GetComponent<PointerNotificationScript>();
				component.PointerClick -= OnPointerClick;
				component.PointerEnterNoSource -= OnPointerEnter;
				component.PointerExitNoSource -= OnPointerExit;
				component.ScrollNoSource -= OnScroll;
			}
		}
	}
}
