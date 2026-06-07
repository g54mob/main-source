using System;
using System.Collections.Generic;
using Assets.Dev.Philip.UiTesting.Scripts;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits.Chain.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.Interfaces;
using Assets.Scripts.Flight.MapView.Targeting;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Common.UI;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Ioc;
using ModApi.Scripts.State.Validation;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes
{
	public class ManeuverNodeManagerScript : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IScrollHandler, IDisposable, IManeuverNodeAdjustments
	{
		private class ContextMenuIcons
		{
			public Sprite AddNodeApoapsis { get; }

			public Sprite AddNodeAscendingNode { get; }

			public Sprite AddNodeAscendingNodeOfTarget { get; }

			public Sprite AddNodeDescendingNode { get; }

			public Sprite AddNodeDescendingNodeOfTarget { get; }

			public Sprite AddNodeHere { get; }

			public Sprite AddNodePeriapsis { get; }

			public Sprite WarpHere { get; }

			public ContextMenuIcons()
			{
				IResourceLoader resourceLoader = Game.Instance.ResourceLoader;
				AddNodeHere = resourceLoader.Load<Sprite>("Flight/MapView/Icons/Add");
				AddNodePeriapsis = resourceLoader.Load<Sprite>("Flight/MapView/Icons/Periapsis");
				AddNodeApoapsis = resourceLoader.Load<Sprite>("Flight/MapView/Icons/Apoapsis");
				AddNodeAscendingNode = resourceLoader.Load<Sprite>("Flight/MapView/Icons/AscendingNode");
				AddNodeDescendingNode = resourceLoader.Load<Sprite>("Flight/MapView/Icons/DescendingNode");
				AddNodeDescendingNodeOfTarget = resourceLoader.Load<Sprite>("Flight/MapView/Icons/DescendingNodeOfTarget");
				AddNodeAscendingNodeOfTarget = resourceLoader.Load<Sprite>("Flight/MapView/Icons/AscendingNodeOfTarget");
				WarpHere = resourceLoader.Load<Sprite>("Ui/Sprites/MapView/IconWarpToNode");
			}
		}

		private Image _addNodeIcon;

		private Sprite _addSprite;

		private bool _anyItemsBeingHovered;

		private bool _anyItemsBeingHoveredWhichPreventManeuverNodeAdder;

		private IChainNodeList _chainNodeList;

		private IChainNodeSelection _chainSelection;

		private ContextMenuIcons _contextMenuIcons;

		private MapPlayerCraft _craft;

		private ICraftContext _craftContext;

		private InfoPanel _infoPanel;

		private IItemRegistry _itemRegistry;

		private Sprite _lockedSprite;

		private INavigationTargetProvider _navigationTargetProvider;

		private GameObject _nodeAdderGraphicContainer;

		private TextMeshProUGUI _pointerDebugText;

		public static bool NodeAdderIconVisible { get; private set; }

		public bool AnyItemsBeingHovered => _anyItemsBeingHovered;

		public bool AnyItemsBeingHoveredWhichPreventManeuverNodeAdder => _anyItemsBeingHoveredWhichPreventManeuverNodeAdder;

		public Camera Camera { get; private set; }

		public bool ManeuverNodeCreationEnabled { get; internal set; } = true;

		private IMapViewCoordinateConverter CoordinateConverter => _craft.CoordinateConverter;

		public event ManeuverNodeHandler ManeuverNodeAdjusted;

		public static ManeuverNodeManagerScript Create(ICraftContext craftContext, MapPlayerCraft craft)
		{
			IObjectContainerProvider objectContainerProvider = craft.Ioc.Resolve<IObjectContainerProvider>(craft.MapViewContext);
			GameObject obj = new GameObject($"ManeuverNodeAdder({craft.ItemName})");
			obj.transform.parent = objectContainerProvider.CanvasesRoot;
			ManeuverNodeManagerScript maneuverNodeManagerScript = obj.AddComponent<ManeuverNodeManagerScript>();
			maneuverNodeManagerScript.Initialize(craftContext, craft);
			return maneuverNodeManagerScript;
		}

		public void AddContextMenuItems(IContextMenu contextMenu, PointerEventData eventData)
		{
			OrbitInteractionScript.OrbitCursorInfo cursorInfo = _craft.OrbitInteractionScript.CursorInfo;
			MapOrbitInfo orbitInfo = cursorInfo.OrbitInfo;
			double trueAnomaly = cursorInfo.ClosestPoint.TrueAnomaly;
			ContextMenuIcons contextMenuIcons = _contextMenuIcons;
			double? trueAnomalyPeriapsis = null;
			double? trueAnomalyApoapsis = null;
			double? trueAnomalyDescendingNode = null;
			double? trueAnomalyAscendingNode = null;
			double? trueAnomalyDescendingNodeOfTarget = null;
			double? trueAnomalyAscendingNodeOfTarget = null;
			contextMenu.AddContextMenuItem("Planned Burn Here", contextMenuIcons.AddNodeHere, null, delegate
			{
				AddManeuverNode(orbitInfo, trueAnomaly, Vector3d.zero, restoring: false);
			});
			if (orbitInfo.PeriapsisOnVisibleOrbit)
			{
				trueAnomalyPeriapsis = orbitInfo.OrbitNode.Periapsis.TrueAnomaly;
				contextMenu.AddContextMenuItem("Planned Burn at Periapsis", contextMenuIcons.AddNodePeriapsis, null, delegate
				{
					AddManeuverNode(orbitInfo, trueAnomalyPeriapsis.Value, Vector3d.zero, restoring: false);
				});
			}
			if (orbitInfo.ApoapsisOnVisibleOrbit)
			{
				trueAnomalyApoapsis = orbitInfo.OrbitNode.Apoapsis.TrueAnomaly;
				contextMenu.AddContextMenuItem("Planned Burn at Apoapsis", contextMenuIcons.AddNodeApoapsis, null, delegate
				{
					AddManeuverNode(orbitInfo, trueAnomalyApoapsis.Value, Vector3d.zero, restoring: false);
				});
			}
			if (orbitInfo.DescendingNodeOnVisibleOrbit)
			{
				trueAnomalyDescendingNode = orbitInfo.OrbitNode.Orbit.TrueAnomalyOfDescendingNode;
				contextMenu.AddContextMenuItem("Planned Burn at Descending Node", contextMenuIcons.AddNodeDescendingNode, null, delegate
				{
					AddManeuverNode(orbitInfo, trueAnomalyDescendingNode.Value, Vector3d.zero, restoring: false);
				});
			}
			if (orbitInfo.AscendingNodeOnVisibleOrbit)
			{
				trueAnomalyAscendingNode = orbitInfo.OrbitNode.Orbit.TrueAnomalyOfAscendingNode;
				contextMenu.AddContextMenuItem("Planned Burn at Ascending Node", contextMenuIcons.AddNodeAscendingNode, null, delegate
				{
					AddManeuverNode(orbitInfo, trueAnomalyAscendingNode.Value, Vector3d.zero, restoring: false);
				});
			}
			orbitInfo.GetAscendingDescendingNodesToTarget(out trueAnomalyAscendingNodeOfTarget, out trueAnomalyDescendingNodeOfTarget);
			if (trueAnomalyDescendingNodeOfTarget.HasValue)
			{
				contextMenu.AddContextMenuItem("Planned Burn at Descending Node (Target)", contextMenuIcons.AddNodeDescendingNodeOfTarget, null, delegate
				{
					AddManeuverNode(orbitInfo, trueAnomalyDescendingNodeOfTarget.Value, Vector3d.zero, restoring: false);
				});
			}
			if (trueAnomalyAscendingNodeOfTarget.HasValue)
			{
				contextMenu.AddContextMenuItem("Planned Burn at Ascending Node (Target)", contextMenuIcons.AddNodeAscendingNodeOfTarget, null, delegate
				{
					AddManeuverNode(orbitInfo, trueAnomalyAscendingNodeOfTarget.Value, Vector3d.zero, restoring: false);
				});
			}
			if (_craft.OrbitInfo != orbitInfo || !OrbitMath.TrueAnomalyBetween(trueAnomaly, orbitInfo.ValidTrueAnomalyStart, orbitInfo.ValidTrueAnomalyEnd, inclusive: true))
			{
				return;
			}
			contextMenu.AddContextMenuItem("Warp Here", contextMenuIcons.WarpHere, null, delegate
			{
				AddAndWarpToManeuverNode(orbitInfo, trueAnomaly);
			});
			if (0 == 0)
			{
				return;
			}
			if (trueAnomalyPeriapsis.HasValue)
			{
				contextMenu.AddContextMenuItem("Warp to Periapsis", contextMenuIcons.AddNodePeriapsis, null, delegate
				{
					AddAndWarpToManeuverNode(orbitInfo, trueAnomalyPeriapsis.Value);
				});
			}
			if (trueAnomalyApoapsis.HasValue)
			{
				contextMenu.AddContextMenuItem("Warp to Apoapsis", contextMenuIcons.AddNodeApoapsis, null, delegate
				{
					AddAndWarpToManeuverNode(orbitInfo, trueAnomalyApoapsis.Value);
				});
			}
			if (trueAnomalyDescendingNode.HasValue)
			{
				contextMenu.AddContextMenuItem("Warp to Descending Node", contextMenuIcons.AddNodeDescendingNode, null, delegate
				{
					AddAndWarpToManeuverNode(orbitInfo, trueAnomalyDescendingNode.Value);
				});
			}
			if (trueAnomalyAscendingNode.HasValue)
			{
				contextMenu.AddContextMenuItem("Warp to Ascending Node", contextMenuIcons.AddNodeAscendingNode, null, delegate
				{
					AddAndWarpToManeuverNode(orbitInfo, trueAnomalyAscendingNode.Value);
				});
			}
			if (trueAnomalyDescendingNodeOfTarget.HasValue)
			{
				contextMenu.AddContextMenuItem("Warp to Descending Node (Target)", contextMenuIcons.AddNodeDescendingNodeOfTarget, null, delegate
				{
					AddAndWarpToManeuverNode(orbitInfo, trueAnomalyDescendingNodeOfTarget.Value);
				});
			}
			if (trueAnomalyAscendingNodeOfTarget.HasValue)
			{
				contextMenu.AddContextMenuItem("Warp to Ascending Node (Target)", contextMenuIcons.AddNodeAscendingNodeOfTarget, null, delegate
				{
					AddAndWarpToManeuverNode(orbitInfo, trueAnomalyAscendingNodeOfTarget.Value);
				});
			}
		}

		public ManeuverNodeScript AddManeuverNode(MapOrbitInfo originatingOrbitInfo, double trueAnomalyOnOriginatingOrbit, Vector3d deltaV, bool restoring)
		{
			ManeuverSimNode maneuverSimNode = new ManeuverSimNode(new Orbit((Orbit)originatingOrbitInfo.OrbitNode.Orbit, trueAnomalyOnOriginatingOrbit), originatingOrbitInfo.OrbitNode.Parent);
			Material lineMaterial = UnityEngine.Object.Instantiate(_craft.LineMaterial);
			MapCraftOrbitLine orbitLine = MapCraftOrbitLine.Create(_craft.Ioc, _craft.MapViewContext, maneuverSimNode, _craft.Data, UiUtils.GetSortedOrbitLineColor(originatingOrbitInfo.ChainNode.ListNode.List.Count), "ManeuverNode Orbit", Camera, lineMaterial);
			NodeListChangeCategory category = (restoring ? NodeListChangeCategory.Restore : NodeListChangeCategory.Normal);
			Func<LinkedListNode<IChainableOrbit>, IChainableOrbit> creationMethod = (LinkedListNode<IChainableOrbit> x) => ManeuverNodeScript.Create(_craftContext, x, orbitLine, trueAnomalyOnOriginatingOrbit, deltaV, category);
			ManeuverNodeScript maneuverNodeScript = (ManeuverNodeScript)_chainNodeList.AddAfter(originatingOrbitInfo.ChainNode.ListNode, creationMethod, restoring ? NodeListChangeCategory.Restore : NodeListChangeCategory.Normal).Value;
			maneuverSimNode.Name = maneuverNodeScript.name;
			maneuverNodeScript.ManeuverNodeAdjustmentChangingEvent += OnManeuverNodeAdjustmentChanging;
			maneuverNodeScript.NodeDraggingEvent += OnManeuverNodeBeingDragged;
			orbitLine.SetManeuverNodeEventsProvider(maneuverNodeScript);
			maneuverNodeScript.OnAfterInitialized();
			return maneuverNodeScript;
		}

		public void Dispose()
		{
			if (_craft?.OrbitInteractionScript != null)
			{
				_craft.OrbitInteractionScript.HoverExit -= OnHoverExit;
				_craft.OrbitInteractionScript.HoverStay -= OnHoverStay;
			}
			if (_infoPanel != null)
			{
				UnityEngine.Object.Destroy(_infoPanel.gameObject);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void OnAfterCameraPositioned()
		{
		}

		public void OnBeforeCameraPositioned()
		{
			_anyItemsBeingHovered = false;
			_anyItemsBeingHoveredWhichPreventManeuverNodeAdder = false;
			IReadOnlyList<MapItem> items = _itemRegistry.Items;
			for (int i = 0; i < items.Count; i++)
			{
				MapItem mapItem = items[i];
				if (mapItem.Hovered)
				{
					_anyItemsBeingHovered = true;
					if (!mapItem.DisplayManeuverNodeAdderOnMouseHover)
					{
						_anyItemsBeingHoveredWhichPreventManeuverNodeAdder = true;
						break;
					}
				}
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			if (eventData.button != PointerEventData.InputButton.Left || !ManeuverNodeCreationEnabled || (validator.IsCareerMode && !validator.IsItemAvailable("Map.Maneuver")))
			{
				return;
			}
			if (_craft.OrbitInteractionScript.CursorInfo != null)
			{
				_ = _anyItemsBeingHoveredWhichPreventManeuverNodeAdder;
			}
			IContextMenu contextMenu = Game.Instance.FlightScene.FlightSceneUI.ContextMenu;
			MapItemsAtPointerPosition visibleMapItemsAtPointer = ((MapViewScript)Game.Instance.FlightScene.ViewManager.MapViewManager.MapView).MapViewUi.GetVisibleMapItemsAtPointer(eventData, this);
			if (visibleMapItemsAtPointer.PlayerCraft != null)
			{
				visibleMapItemsAtPointer.PlayerCraft.AddContextMenuItem(contextMenu, eventData);
			}
			AddContextMenuItems(contextMenu, eventData);
			foreach (EncounterInfoScript encounterInfo in visibleMapItemsAtPointer.EncounterInfos)
			{
				encounterInfo.AddContextMenuItem(contextMenu);
			}
			foreach (MapItemCanvasScript mapItem in visibleMapItemsAtPointer.MapItems)
			{
				mapItem.MapItem.AddContextMenuItem(contextMenu, eventData);
			}
			contextMenu.ShowContextMenu(eventData.position);
		}

		public void OnScroll(PointerEventData eventData)
		{
			(MapViewManagerScript.Instance?.MapView as MapViewScript)?.MapCameraScript?.OnScroll(eventData);
		}

		protected virtual void OnDestroy()
		{
			NodeAdderIconVisible = false;
		}

		private void AddAndWarpToManeuverNode(MapOrbitInfo orbitInfo, double trueAnomaly)
		{
			ManeuverNodeScript maneuverNodeScript = AddManeuverNode(orbitInfo, trueAnomaly, Vector3d.zero, restoring: false);
			maneuverNodeScript.LockNode();
			maneuverNodeScript.CompleteGizmoAnimations();
			_craft.NodeNavigator.WarpToNextNode();
		}

		private Vector3d? GetManeuverNodeDeltaV()
		{
			return _chainNodeList.FirstManeuverNode?.DeltaV;
		}

		private Vector3d? GetManeuverNodeDeltaVToComplete()
		{
			return _chainNodeList.FirstManeuverNode?.GetDeltaVToCompleteManeuver();
		}

		private void Initialize(ICraftContext craftContext, MapPlayerCraft craft)
		{
			IIocContainer ioc = craft.Ioc;
			_craft = craft;
			_craftContext = craftContext;
			Camera = _craft.Camera;
			_chainNodeList = ioc.Resolve<IChainNodeList>(craftContext);
			_chainSelection = ioc.Resolve<IChainNodeSelection>(craftContext);
			_itemRegistry = ioc.Resolve<IItemRegistry>(_craft.MapViewContext);
			_navigationTargetProvider = ioc.Resolve<INavigationTargetProvider>(_craft.MapViewContext);
			ioc.Register((IManeuverNodeAdjustments)this, (IContext)craftContext);
			_contextMenuIcons = new ContextMenuIcons();
			GameObject gameObject = new GameObject("NodeAdder");
			gameObject.transform.SetParent(base.transform);
			gameObject.layer = base.gameObject.layer;
			Canvas canvas = gameObject.AddComponent<Canvas>();
			canvas.overrideSorting = true;
			canvas.sortingOrder = -5;
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.worldCamera = Camera;
			gameObject.AddComponent<GraphicRaycaster>();
			_nodeAdderGraphicContainer = new GameObject("GraphicContainer");
			_nodeAdderGraphicContainer.transform.SetParent(gameObject.transform);
			_nodeAdderGraphicContainer.layer = base.gameObject.layer;
			_addNodeIcon = new GameObject("AddIcon").AddComponent<Image>();
			_addSprite = UiUtils.LoadIconSprite("Add");
			_lockedSprite = UiUtils.LoadIconSprite("ManeuverLocked");
			_addNodeIcon.sprite = _addSprite;
			_addNodeIcon.raycastTarget = true;
			_addNodeIcon.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 20f);
			_addNodeIcon.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 20f);
			_addNodeIcon.transform.SetParent(_nodeAdderGraphicContainer.transform);
			_addNodeIcon.gameObject.layer = base.gameObject.layer;
			_addNodeIcon.enabled = false;
			_pointerDebugText = UiUtils.CreateUiText(canvas.transform, "PointerText", clickable: false, (TextAlignmentOptions)771);
			_ = _craft.OrbitInteractionScript == null;
			_craft.OrbitInteractionScript.HoverExit += OnHoverExit;
			_craft.OrbitInteractionScript.HoverStay += OnHoverStay;
			if (Device.IsDebugBuild && (_craft.OrbitInfo.OrbitNode as CraftNode).IsPlayer)
			{
				UnityAction<bool> onChanged = delegate(bool x)
				{
					if (!x)
					{
						Debug.LogError("Maneuver node unlocking is not supported.");
					}
					else
					{
						_craft.ChainNodeManager.FirstManeuverNode.LockNode();
					}
				};
				_infoPanel = InfoPanel.Create<InfoPanel>("Maneuver Node Manager", delegate
				{
					Debug.Log("Node options header clicked");
				});
				_infoPanel.AddDynamicText("target", () => (_navigationTargetProvider.NavigationTarget == null) ? "not set" : _navigationTargetProvider.NavigationTarget.Name, rebuildUi: false);
				_infoPanel.AddDynamicText("dv to node", () => GetManeuverNodeDeltaVToComplete()?.magnitude.ToString("0.0"), rebuildUi: false);
				_infoPanel.AddDynamicText("dv of m.node", () => GetManeuverNodeDeltaV()?.magnitude.ToString("0.0"), rebuildUi: false);
				_infoPanel.AddToggleButton("lock first mn", initialValue: false, onChanged, rebuildUi: false);
				_infoPanel.RebuildUi();
			}
			_chainSelection.SetSelected(null, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			canvas.gameObject.AddComponent<OverrideSortingOnStart>();
			Utilities.FixUnityCanvasSortingBug(canvas);
		}

		private void OnHoverExit(OrbitInteractionScript source, OrbitInteractionScript.OrbitCursorInfo orbitCursorInfo)
		{
			SetAddIconEnabled(enabled: false);
			_pointerDebugText.enabled = false;
		}

		private void OnHoverStay(OrbitInteractionScript source, OrbitInteractionScript.OrbitCursorInfo orbitCursorInfo)
		{
			if (!_anyItemsBeingHoveredWhichPreventManeuverNodeAdder)
			{
				SetAddIconEnabled(enabled: true);
				UpdateNodeAdderIcon(orbitCursorInfo);
				if (DebugPanel.Instance.ToggleStates["pointer debug"])
				{
					UpdatePointerDebugInfo(orbitCursorInfo);
				}
			}
			else
			{
				SetAddIconEnabled(enabled: false);
			}
		}

		private void OnManeuverNodeAdjustmentChanging(ManeuverNodeScript source, IOrbit orbtiUpdated)
		{
			this.ManeuverNodeAdjusted?.Invoke(source);
		}

		private void OnManeuverNodeBeingDragged(ManeuverNodeScript source)
		{
			_craft.UpdateChainFromCraft();
		}

		private void OnShowTargetChanged(bool state)
		{
			Debug.Log("Show Target changed toggled");
		}

		private void SetAddIconEnabled(bool enabled)
		{
			_addNodeIcon.enabled = enabled;
			NodeAdderIconVisible = enabled;
		}

		private void UpdateNodeAdderIcon(OrbitInteractionScript.OrbitCursorInfo orbitCursorInfo)
		{
			LinkedListNode<IChainableOrbit> next = orbitCursorInfo.OrbitInfo.ChainNode.ListNode.Next;
			if (next != null && next.Value.Locked)
			{
				_addNodeIcon.sprite = _lockedSprite;
				_addNodeIcon.raycastTarget = false;
			}
			else
			{
				_addNodeIcon.sprite = _addSprite;
				_addNodeIcon.raycastTarget = true;
			}
			_nodeAdderGraphicContainer.transform.position = (Vector2)orbitCursorInfo.ClosestPositionOnOrbitScreen;
		}

		private void UpdatePointerDebugInfo(OrbitInteractionScript.OrbitCursorInfo orbitCursorInfo)
		{
			Vector3 closestPositionOnOrbitScreen = orbitCursorInfo.ClosestPositionOnOrbitScreen;
			_pointerDebugText.transform.position = new Vector3(closestPositionOnOrbitScreen.x + 25f, closestPositionOnOrbitScreen.y + 25f, 0f);
			Orbit orbit = new Orbit((Orbit)orbitCursorInfo.OrbitInfo.OrbitNode.Orbit, orbitCursorInfo.ClosestPoint.TrueAnomaly);
			string text = $"{orbit.Time:0.0}s\n{orbitCursorInfo.ClosestPoint.TrueAnomaly:0.00}nu\n{orbit.EccentricAnomaly:0.00}ea\n{OrbitMath.GetMeanAnomalyFromEccentricAnomaly(orbit.Eccentricity, orbit.EccentricAnomaly):0.00}ma\n";
			if (_navigationTargetProvider.NavigationTarget != null)
			{
				IOrbitPoint pointAtTime = OrbitMath.GetPointAtTime(_navigationTargetProvider.NavigationTarget.OrbitInfo.OrbitNode.Orbit, orbit.Time);
				double magnitude = (orbit.Position - pointAtTime.Position).magnitude;
				text += $"\nTarget Dist: {magnitude:0.0}m";
			}
			_pointerDebugText.text = text;
			_pointerDebugText.enabled = true;
		}
	}
}
