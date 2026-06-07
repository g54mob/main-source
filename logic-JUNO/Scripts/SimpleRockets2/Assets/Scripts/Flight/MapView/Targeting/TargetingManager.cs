using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.MapView.Orbits.Chain.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Common.UI;
using ModApi.Craft;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Ioc;
using ModApi.Planet;
using ModApi.State.MapView;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.MapView.Targeting
{
	public class TargetingManager : INavigationTargetProvider, IDisposable
	{
		public delegate void TargetChangedHandler(TargetingManager source, ITargetableItem newTarget, ITargetableItem oldTarget);

		private Canvas _canvas;

		private IChainableOrbit _chainNodeOverride;

		private IChainNodeSelection _chainNodeSelection;

		private IObjectContainerProvider _containerProvider;

		private IMapViewCoordinateConverter _coordinateConverter;

		private EncounterInfoScript _craftUiInfo;

		private bool _enabled;

		private IIocContainer _ioc;

		private IItemRegistry _itemRegistry;

		private OrbitAnalyser.SoiEnterInfo _lastClosest;

		private ITargetableItem _navigationTarget;

		private IMapOptions _options;

		private OrbitInteractionScript _orbitInteractionScript;

		private OrbitAnalyser.SoiEnterInfo _pinnedPoint = new OrbitAnalyser.SoiEnterInfo();

		private IPlayerCraftProvider _playerCraftProvider;

		private bool _playerIsDecendantOfTarget;

		private EncounterInfoScript _targetAtCursorUiInfo;

		private Image _targetBoxIcon;

		private bool _targetIsSameNodeAsChainNodeParent;

		private bool? _targetOrbitLineSettingBackup;

		private EncounterInfoScript _targetUiInfo;

		public static bool ShowDebug { get; set; }

		public IChainableOrbit ChainNodeToGetTargetInfoFor { get; private set; }

		public ITargetableItem NavigationTarget => _navigationTarget;

		public bool Pinned { get; private set; }

		public bool ShowEncounterInfo { get; set; } = true;

		public event TargetChangedHandler TargetChanged;

		public TargetingManager(IIocContainer ioc, IPlayerCraftProvider playerCraftProvider, IMapViewCoordinateConverter coordinateConverter, IObjectContainerProvider containerProvider, IItemRegistry itemRegistry)
		{
			_ioc = ioc;
			_containerProvider = containerProvider;
			_coordinateConverter = coordinateConverter;
			_playerCraftProvider = playerCraftProvider;
			_itemRegistry = itemRegistry;
			_playerCraftProvider.PlayerCraftChanged += OnPlayerCraftChanged;
			GameObject gameObject = new GameObject("TargetingContainer");
			_canvas = gameObject.AddComponent<Canvas>();
			_canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			_canvas.gameObject.AddComponent<GraphicRaycaster>();
			_canvas.overrideSorting = true;
			_canvas.sortingOrder = -2;
			gameObject.transform.SetParent(_containerProvider.UiContainer, worldPositionStays: false);
			gameObject.transform.position = Vector3.zero;
			gameObject.layer = LayerMask.NameToLayer("MapView");
			MapItem.ItemClicked += OnItemClicked;
			_options = ioc.Resolve<IMapOptions>();
			_lastClosest = new OrbitAnalyser.SoiEnterInfo();
			_canvas.gameObject.AddComponent<OverrideSortingOnStart>();
			Utilities.FixUnityCanvasSortingBug(_canvas);
		}

		public void Dispose()
		{
			MapItem.ItemClicked -= OnItemClicked;
		}

		public bool IsProcessingTargetInformationFor(IChainableOrbit chainableOrbit)
		{
			if (NavigationTarget != null)
			{
				return ChainNodeToGetTargetInfoFor == chainableOrbit;
			}
			return false;
		}

		public bool IsValidTarget(ITargetableItem target)
		{
			bool result = true;
			IOrbitNode orbitNode = _playerCraftProvider.PlayerCraft?.OrbitInfo.OrbitNode;
			IOrbitNode orbitNode2 = target?.OrbitInfo?.OrbitNode;
			if (orbitNode2 == null || orbitNode == null || orbitNode2 == orbitNode)
			{
				result = false;
			}
			return result;
		}

		public void OnAfterCameraRepositioned()
		{
			if (!_enabled)
			{
				return;
			}
			MapOrbitInfo mapOrbitInfo = NavigationTarget?.OrbitInfo;
			if (mapOrbitInfo != null)
			{
				mapOrbitInfo.UpdateUiComponentFromCurrentPosition(_targetBoxIcon, _canvas, fadeOutWithDistance: false);
			}
			else
			{
				UiUtils.UiComponentSetEnabled(_targetBoxIcon, enabled: false);
			}
			MapPlayerCraft playerCraft = _playerCraftProvider.PlayerCraft;
			if (!_targetIsSameNodeAsChainNodeParent && !_playerIsDecendantOfTarget && mapOrbitInfo != null && ShowEncounterInfo && ChainNodeToGetTargetInfoFor != null && !(mapOrbitInfo?.OrbitNode is StationaryMapOrbitNode))
			{
				MapOrbitInfo orbitInfo = ChainNodeToGetTargetInfoFor.OrbitInfo;
				IOrbit orbit = orbitInfo.OrbitNode.Orbit;
				double timeToStartSearch = ((!(_options.Targeting.PeriodsInFutureToBegin > 0.0)) ? orbit.Time : (orbit.Time + ((orbit.Eccentricity < 1.0) ? (_options.Targeting.PeriodsInFutureToBegin * orbit.Period) : 0.0)));
				double time = playerCraft.OrbitInfo.OrbitNode.Orbit.Time;
				if (Pinned)
				{
					IOrbitNode nodeA = _pinnedPoint.NodeA;
					IOrbitNode orbitNode = NavigationTarget.OrbitInfo.OrbitNode;
					IOrbitPoint pointAtTrueAnomaly = OrbitMath.GetPointAtTrueAnomaly(nodeA.Orbit, _pinnedPoint.PointA.TrueAnomaly);
					IOrbitPoint pointAtTime = OrbitMath.GetPointAtTime(orbitNode.Orbit, pointAtTrueAnomaly.Time);
					_lastClosest.Initialize(nodeA, orbitNode, pointAtTrueAnomaly, pointAtTime);
					UpdateClosestEncounterIcons(_lastClosest, orbitInfo, time, NavigationTarget.OrbitInfo, _craftUiInfo, _targetUiInfo);
				}
				else
				{
					OrbitAnalyser.SoiEnterInfo soiEnterInfo = UpdateClosestEncounter(_ioc, orbitInfo, NavigationTarget.OrbitInfo, timeToStartSearch, time, _options.Targeting.SoiEntryLocalMinimaModifier, ((ITargetableItem)playerCraft).GetSphereOfInfluence(NavigationTarget.OrbitInfo), NavigationTarget.GetSphereOfInfluence(playerCraft.OrbitInfo), _craftUiInfo, _targetUiInfo, _coordinateConverter, this, _itemRegistry, ShowDebug ? "TargetingManager" : null);
					if (soiEnterInfo != null)
					{
						_lastClosest.Initialize(soiEnterInfo);
					}
				}
				UpdatePredictedPositionsAtCursor(_targetAtCursorUiInfo);
			}
			else
			{
				UiUtils.UiComponentSetEnabled(_craftUiInfo, enabled: false);
				if (_targetUiInfo != null)
				{
					UiUtils.UiComponentSetEnabled(_targetUiInfo, enabled: false);
				}
				if (_targetAtCursorUiInfo != null)
				{
					UiUtils.UiComponentSetEnabled(_targetAtCursorUiInfo.CanvasGroup, enabled: false);
				}
			}
		}

		public void OnBeforeCameraRepositioned()
		{
		}

		public void SelectDefaultNodeForTargetingInfo()
		{
			OnChainNodeSelectionChanged(null);
		}

		public void SetChainNodeOverride(IChainableOrbit chainNodeOverride)
		{
			_chainNodeOverride = chainNodeOverride;
			if (_chainNodeOverride != null)
			{
				ChainNodeToGetTargetInfoFor = _chainNodeOverride;
			}
			else
			{
				ChainNodeToGetTargetInfoFor = _chainNodeSelection.Selected;
			}
		}

		public void SetNavigationTarget(ITargetableItem target)
		{
			SetNavigationTarget(target, null);
		}

		public void SetNavSphereTarget(INavSphereTarget target)
		{
			ITargetableItem target2 = _itemRegistry.FindTargetableItem(target?.OrbitNode);
			SetNavigationTarget(target2, target);
		}

		public void SetPinned(bool pinned)
		{
			Pinned = pinned;
			_pinnedPoint.Initialize(_lastClosest);
		}

		private static Transform CreateBall(Transform parent, string name, int layer, Color color, Color emissive)
		{
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			gameObject.name = name;
			gameObject.layer = layer;
			Collider component = gameObject.GetComponent<Collider>();
			component.enabled = false;
			UnityEngine.Object.Destroy(component);
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			Material material = new Material(Shader.Find("Standard"))
			{
				color = color
			};
			if (color.a != 1f)
			{
				material.SetFloat("_Mode", 3f);
				material.SetInt("_SrcBlend", 5);
				material.SetInt("_DstBlend", 10);
				material.SetInt("_ZWrite", 0);
				material.DisableKeyword("_ALPHATEST_ON");
				material.EnableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.renderQueue = 3001;
			}
			material.SetFloat("_SpecularHighlights", 0f);
			material.SetFloat("_SmoothnessTextureChannel", 0f);
			MeshRenderer component2 = gameObject.GetComponent<MeshRenderer>();
			component2.material = material;
			component2.reflectionProbeUsage = ReflectionProbeUsage.Off;
			return gameObject.transform;
		}

		private static EncounterInfoScript CreateTargetingIcon(Canvas canvas, ITargetableItem targetableItem, bool raycastTarget, bool textBelowIcon, string name, string description)
		{
			Image image = UiUtils.CreateUiIcon(canvas, targetableItem.ClosestEncounterIcon, raycastTarget);
			Transform parent = image.transform.parent;
			GameObject gameObject = new GameObject("TargetEncounter: (" + name + ")");
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			gameObject.gameObject.AddComponent<CanvasGroup>();
			GameObject gameObject2 = new GameObject("HoverContents");
			VerticalLayoutGroup verticalLayoutGroup = gameObject2.gameObject.AddComponent<VerticalLayoutGroup>();
			verticalLayoutGroup.spacing = 0f;
			verticalLayoutGroup.childControlHeight = true;
			verticalLayoutGroup.childControlWidth = false;
			verticalLayoutGroup.childForceExpandHeight = false;
			verticalLayoutGroup.childForceExpandWidth = false;
			verticalLayoutGroup.childAlignment = TextAnchor.LowerCenter;
			RectTransform component = gameObject2.GetComponent<RectTransform>();
			component.SetParent(gameObject.transform, worldPositionStays: false);
			component.pivot = new Vector2(0.5f, 0f);
			component.localPosition = new Vector3(0f, textBelowIcon ? (-20) : 20, 0f);
			if (textBelowIcon)
			{
				component.pivot = new Vector2(0.5f, 1f);
				verticalLayoutGroup.childAlignment = TextAnchor.UpperCenter;
			}
			TextMeshProUGUI textMeshProUGUI = UiUtils.CreateUiText(gameObject2.transform, "Desc", clickable: false, TextAlignmentOptions.Center);
			textMeshProUGUI.margin = new Vector4(0f, 0f, 0f, 5f);
			textMeshProUGUI.name = "Desc";
			textMeshProUGUI.raycastTarget = raycastTarget;
			textMeshProUGUI.text = description;
			TextMeshProUGUI textMeshProUGUI2 = UiUtils.CreateUiText(gameObject2.transform, "Dist", clickable: false, TextAlignmentOptions.Center);
			textMeshProUGUI2.margin = new Vector4(0f, 0f, 0f, 0f);
			textMeshProUGUI2.name = "Dist";
			textMeshProUGUI2.raycastTarget = raycastTarget;
			TextMeshProUGUI textMeshProUGUI3 = UiUtils.CreateUiText(gameObject2.transform, "Dv", clickable: false, TextAlignmentOptions.Center);
			textMeshProUGUI3.margin = new Vector4(0f, 0f, 0f, 0f);
			textMeshProUGUI3.name = "Dv";
			textMeshProUGUI3.raycastTarget = raycastTarget;
			TextMeshProUGUI textMeshProUGUI4 = UiUtils.CreateUiText(gameObject2.transform, "Time", clickable: false, TextAlignmentOptions.Center);
			textMeshProUGUI4.margin = new Vector4(0f, 0f, 0f, 0f);
			textMeshProUGUI4.name = "Time";
			textMeshProUGUI4.raycastTarget = raycastTarget;
			image.gameObject.SetActive(value: true);
			image.transform.SetParent(gameObject.transform, worldPositionStays: false);
			image.transform.localPosition = Vector3.zero;
			EncounterInfoScript encounterInfoScript = gameObject.AddComponent<EncounterInfoScript>();
			encounterInfoScript.Initialize();
			gameObject.gameObject.SetActive(value: false);
			return encounterInfoScript;
		}

		private static OrbitAnalyser.SoiEnterInfo UpdateClosestEncounter(IIocContainer ioc, MapOrbitInfo craftOrbitInfo, MapOrbitInfo targetOrbitInfo, double timeToStartSearch, double currentGameTime, double localMinimaModifier, double craftSoi, double targetSoi, EncounterInfoScript craftUiInfoScript, EncounterInfoScript targetUiInfoScript, IMapViewCoordinateConverter coordinateConverter, INavigationTargetProvider navigationTargetProvider, IItemRegistry itemRegistry, string debugDescription)
		{
			MapOrbitInfo mapOrbitInfo = targetOrbitInfo;
			MapOrbitInfo mapOrbitInfo2 = craftOrbitInfo;
			IOrbitNode orbitNode = mapOrbitInfo2.OrbitNode;
			IOrbitNode orbitNode2 = mapOrbitInfo.OrbitNode;
			bool flag = false;
			for (LinkedListNode<IChainableOrbit> linkedListNode = mapOrbitInfo2.ChainNode.ListNode; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				bool flag2 = false;
				IOrbitNode orbitNode3 = orbitNode2;
				while (orbitNode3.Parent != null)
				{
					if (MapUtils.SamePlanet(linkedListNode.Value.OrbitNode.Parent, orbitNode3.Parent))
					{
						if (!flag || MapUtils.SamePlanet(linkedListNode.Value.OrbitNode.Parent, mapOrbitInfo2.OrbitNode.Parent))
						{
							flag = true;
							flag2 = true;
							mapOrbitInfo2 = linkedListNode.Value.OrbitInfo;
							orbitNode = mapOrbitInfo2.OrbitNode;
							mapOrbitInfo = itemRegistry.GetItem(orbitNode3).OrbitInfo;
							orbitNode2 = orbitNode3;
						}
						break;
					}
					orbitNode3 = orbitNode3.Parent;
				}
				if (flag && !flag2)
				{
					break;
				}
			}
			IOrbitNode nodeAWithCommonParent;
			IOrbitNode nodeBWithCommonParent;
			double endNu;
			if (!MapUtils.SamePlanet(orbitNode.Parent, orbitNode2.Parent))
			{
				OrbitAnalyser.GetAncestorsWithCommonParents(orbitNode, orbitNode2, out nodeAWithCommonParent, out nodeBWithCommonParent);
				endNu = nodeAWithCommonParent.Orbit.TrueAnomaly;
				if (nodeAWithCommonParent is SoiEncounterPlanetSimNode)
				{
					nodeAWithCommonParent = (nodeAWithCommonParent as SoiEncounterPlanetSimNode).ReferencePlanet;
				}
				mapOrbitInfo2 = itemRegistry.GetItem(nodeAWithCommonParent).OrbitInfo;
				mapOrbitInfo = itemRegistry.GetItem(nodeBWithCommonParent).OrbitInfo;
			}
			else
			{
				nodeAWithCommonParent = mapOrbitInfo2.OrbitNode;
				nodeBWithCommonParent = mapOrbitInfo.OrbitNode;
				endNu = mapOrbitInfo2.ValidTrueAnomalyEnd;
			}
			ClosestEncounterSearchOptions search = new ClosestEncounterSearchOptions(ioc, nodeAWithCommonParent, nodeBWithCommonParent);
			search.EndNu = endNu;
			search.TimeToStartSearch = timeToStartSearch;
			search.DebugDescription = debugDescription;
			search.SearchSpace = ClosestEncounterSearchSpace.WholeOrbit;
			search.LocalMinimaModifier *= 8.0;
			search.BinarySearchTargetDistance = Mathd.Max(1.0, 1.25);
			OrbitAnalyser.SoiEnterInfo soiEnterInfo = OrbitAnalyser.GetClosestEncounterInfo(search);
			if (soiEnterInfo?.NodeA is ICraftNode craftNode)
			{
				IPlanetData planetData = craftNode.Parent.PlanetData;
				if (craftNode.InContactWithPlanet || (nodeAWithCommonParent.Orbit.PeriapsisDistance - planetData.Radius <= 0.0 && (soiEnterInfo.PointA.Position - craftNode.Position).magnitude < 100000.0))
				{
					soiEnterInfo = null;
				}
			}
			UpdateClosestEncounterIcons(soiEnterInfo, mapOrbitInfo2, currentGameTime, mapOrbitInfo, craftUiInfoScript, targetUiInfoScript);
			return soiEnterInfo;
		}

		private static void UpdateClosestEncounterIcons(OrbitAnalyser.SoiEnterInfo closestPoint, MapOrbitInfo craftOrbitInfo, double currentGameTime, MapOrbitInfo targetOrbitInfo, EncounterInfoScript craftEncounterScript, EncounterInfoScript targetEncounterScript)
		{
			if (closestPoint != null)
			{
				IOrbitPoint pointA = closestPoint.PointA;
				IOrbitPoint pointB = closestPoint.PointB;
				double distance = (pointA.Position - pointB.Position).magnitude;
				double magnitude = (pointA.Velocity - pointB.Velocity).magnitude;
				double num = pointA.Time - currentGameTime;
				double num2 = pointB.Time - currentGameTime;
				IChainableOrbit chainableOrbit = craftOrbitInfo.ChainNode?.ListNode?.Next?.Value;
				if (chainableOrbit != null && chainableOrbit is SoiEnterNodeScript soiEnterNodeScript && MapUtils.SamePlanet(closestPoint.NodeB as IPlanetNode, soiEnterNodeScript.EncounterInfo.NodeB as IPlanetNode))
				{
					IOrbitNode orbitNode = soiEnterNodeScript.OrbitInfo.OrbitNode;
					IOrbitPoint periapsis = orbitNode.Periapsis;
					distance = orbitNode.Orbit.PeriapsisDistance - orbitNode.Parent.PlanetData.Radius;
					if (periapsis != null)
					{
						magnitude = periapsis.Velocity.magnitude;
						double? num3 = periapsis.Time - currentGameTime - soiEnterNodeScript.TimeToNode;
						if (num3.HasValue)
						{
							num += num3.Value;
							num2 += num3.Value;
						}
					}
				}
				craftEncounterScript.Distance = distance;
				craftEncounterScript.Captured = closestPoint.EncounterOccurred;
				craftEncounterScript.DeltaVelocity = magnitude;
				craftEncounterScript.SecondsInFuture = num;
				craftOrbitInfo.UpdateUiComponentFromPoint(craftEncounterScript.CanvasGroup, craftEncounterScript.Canvas, pointA);
				CraftNode obj = closestPoint.NodeB as CraftNode;
				if (obj != null && obj.InContactWithPlanet)
				{
					UiUtils.UiComponentSetEnabled(targetEncounterScript.CanvasGroup, enabled: false);
					return;
				}
				targetEncounterScript.Distance = distance;
				targetEncounterScript.Captured = closestPoint.EncounterOccurred;
				targetEncounterScript.DeltaVelocity = magnitude;
				targetEncounterScript.SecondsInFuture = num2;
				targetOrbitInfo.UpdateUiComponentFromPoint(targetEncounterScript.CanvasGroup, targetEncounterScript.Canvas, pointB);
			}
			else
			{
				UiUtils.UiComponentSetEnabled(craftEncounterScript.CanvasGroup, enabled: false);
				UiUtils.UiComponentSetEnabled(targetEncounterScript.CanvasGroup, enabled: false);
			}
		}

		private void OnActiveCraftDestroyed()
		{
			_enabled = false;
			UiUtils.UiComponentSetEnabled(_targetBoxIcon, enabled: false);
			UiUtils.UiComponentSetEnabled(_craftUiInfo, enabled: false);
			if (_targetUiInfo != null)
			{
				UiUtils.UiComponentSetEnabled(_targetUiInfo, enabled: false);
			}
			if (_targetAtCursorUiInfo != null)
			{
				UiUtils.UiComponentSetEnabled(_targetAtCursorUiInfo.CanvasGroup, enabled: false);
			}
		}

		private void OnChainNodeOrTargetChanged()
		{
			if (ChainNodeToGetTargetInfoFor == null || NavigationTarget == null)
			{
				_targetIsSameNodeAsChainNodeParent = false;
				return;
			}
			IOrbitNode orbitNode = NavigationTarget.OrbitInfo.OrbitNode;
			PlanetNode planetNode = orbitNode as PlanetNode;
			_targetIsSameNodeAsChainNodeParent = planetNode != null && MapUtils.SamePlanet(ChainNodeToGetTargetInfoFor.OrbitInfo.OrbitNode.Parent, planetNode);
			_playerIsDecendantOfTarget = _playerCraftProvider.PlayerCraft.OrbitInfo.OrbitNode.IsDescendantOf(orbitNode, includeSelf: false);
		}

		private void OnChainNodeSelectionChanged(LinkedListNode<IChainableOrbit> chainNode)
		{
			if (chainNode != null)
			{
				ChainNodeToGetTargetInfoFor = chainNode.Value;
			}
			else if (_playerCraftProvider.PlayerCraft.ChainNodeManager.LastNode != null)
			{
				ChainNodeToGetTargetInfoFor = _playerCraftProvider.PlayerCraft.ChainNodeManager.LastNode;
			}
			else
			{
				ChainNodeToGetTargetInfoFor = _playerCraftProvider.PlayerCraft;
			}
			OnChainNodeOrTargetChanged();
		}

		private void OnCraftChangedSoi(IOrbitNode source)
		{
			ITargetableItem planet = _itemRegistry.GetPlanet(source.Parent);
			if (NavigationTarget == planet && !IsValidTarget(planet))
			{
				Debug.Log("Target is no-longer valid, disabling target.");
				SetNavigationTarget(null);
			}
			OnChainNodeOrTargetChanged();
		}

		private void OnCraftDestroyed(INode node)
		{
			node.Destroyed -= OnCraftDestroyed;
			if ((node as CraftNode).IsPlayer)
			{
				OnActiveCraftDestroyed();
			}
		}

		private void OnCraftInitialized(MapPlayerCraft initializedCraft)
		{
			_enabled = true;
			_orbitInteractionScript = initializedCraft.OrbitInteractionScript;
			_chainNodeSelection = initializedCraft.ChainNodeSelection;
			_chainNodeSelection.ChainNodeSelectionChanged += OnChainNodeSelectionChanged;
			if (_craftUiInfo != null)
			{
				UnityEngine.Object.Destroy(_craftUiInfo.gameObject);
			}
			if (_targetBoxIcon != null)
			{
				UnityEngine.Object.Destroy(_targetBoxIcon.gameObject);
			}
			_craftUiInfo = CreateTargetingIcon(_canvas, initializedCraft, raycastTarget: true, textBelowIcon: true, "Craft", "Closest Approach Info");
			_targetBoxIcon = UiUtils.CreateUiIcon(_canvas, "TargetBox", clickable: false);
			_craftUiInfo.Clicked = true;
			SelectDefaultNodeForTargetingInfo();
			if (NavigationTarget != null && !IsValidTarget(NavigationTarget))
			{
				SetNavigationTarget(null);
			}
		}

		private void OnItemClicked(object sender, MapItem.ItemClickedEventArgs e)
		{
			if (_enabled && Game.Instance.Inputs.MapSetTargetModifier.GetButton() && e.ItemClicked is ITargetableItem)
			{
				ITargetableItem targetableItem = e.ItemClicked as ITargetableItem;
				if (NavigationTarget == null || NavigationTarget != targetableItem)
				{
					SetNavigationTarget(targetableItem);
				}
				else
				{
					SetNavigationTarget(null);
				}
			}
		}

		private void OnPlayerCraftChanged(MapPlayerCraft newCraft, MapPlayerCraft oldCraft)
		{
			if (oldCraft != null)
			{
				oldCraft.Initialized -= OnCraftInitialized;
				oldCraft.OrbitInfo.OrbitNode.Destroyed -= OnCraftDestroyed;
				oldCraft.OrbitInfo.OrbitNode.ChangedSoI -= OnCraftChangedSoi;
			}
			newCraft.Initialized += OnCraftInitialized;
			newCraft.OrbitInfo.OrbitNode.Destroyed += OnCraftDestroyed;
			newCraft.OrbitInfo.OrbitNode.ChangedSoI += OnCraftChangedSoi;
		}

		private void OnTargetChanged(ITargetableItem newTarget, ITargetableItem oldTarget)
		{
			if (oldTarget != null)
			{
				oldTarget.OrbitInfo.OrbitNode.Destroyed -= OnTargetDestroyed;
			}
			if (_targetUiInfo != null)
			{
				UnityEngine.Object.Destroy(_targetUiInfo.gameObject);
			}
			if (_targetAtCursorUiInfo != null)
			{
				UnityEngine.Object.Destroy(_targetAtCursorUiInfo.gameObject);
			}
			if (newTarget != null)
			{
				newTarget.OrbitInfo.OrbitNode.Destroyed += OnTargetDestroyed;
				_targetUiInfo = CreateTargetingIcon(_canvas, newTarget, raycastTarget: true, textBelowIcon: true, "Target", "Closest Approach Info");
				_targetAtCursorUiInfo = CreateTargetingIcon(_canvas, newTarget, raycastTarget: false, textBelowIcon: false, "TargetAtCursor", "Approach Info");
				_targetAtCursorUiInfo.AlwaysShowContents = true;
			}
			Pinned = false;
			OnChainNodeOrTargetChanged();
		}

		private void OnTargetDestroyed(INode targetnode)
		{
			SetNavigationTarget(null);
		}

		private void SetNavigationTarget(ITargetableItem target, INavSphereTarget navSphereTarget)
		{
			IFlightSceneUI flightSceneUI = Game.Instance.FlightScene.FlightSceneUI;
			if (target == null || IsValidTarget(target))
			{
				ITargetableItem navigationTarget = _navigationTarget;
				_navigationTarget = target;
				if (navSphereTarget == null)
				{
					navSphereTarget = target?.OrbitInfo?.OrbitNode as INavSphereTarget;
				}
				Game.Instance.FlightScene.FlightSceneUI.NavSphere.Target = navSphereTarget;
				OnTargetChanged(NavigationTarget, navigationTarget);
				this.TargetChanged?.Invoke(this, NavigationTarget, navigationTarget);
				if (target != null)
				{
					flightSceneUI.ShowMessage("Targeting " + target.Name);
				}
				if (navigationTarget != null && !navigationTarget.OrbitInfo.OrbitNode.IsDestroyed)
				{
					_itemRegistry.GetOrbitNode(navigationTarget.OrbitInfo.OrbitNode).Data.ShowOrbitLineRaw = _targetOrbitLineSettingBackup;
				}
				if (NavigationTarget != null)
				{
					MapItemData data = _itemRegistry.GetOrbitNode(NavigationTarget.OrbitInfo.OrbitNode).Data;
					_targetOrbitLineSettingBackup = data.ShowOrbitLineRaw;
					data.ShowOrbitLineRaw = data.SupportsOrbitLines && Game.Instance.GameState.Validator.IsItemAvailable("Map.Lines");
				}
			}
			else
			{
				flightSceneUI.ShowMessage("Cannot set target.");
			}
		}

		private void UpdatePredictedPositionsAtCursor(EncounterInfoScript targetAtCursorUiInfo)
		{
			OrbitInteractionScript.OrbitCursorInfo cursorInfo = _orbitInteractionScript.CursorInfo;
			IOrbitNode orbitNode = cursorInfo?.OrbitInfo.OrbitNode;
			MapOrbitInfo mapOrbitInfo = NavigationTarget?.OrbitInfo;
			IOrbitNode orbitNode2 = mapOrbitInfo?.OrbitNode;
			if (!_playerCraftProvider.PlayerCraft.ManeuverNodeManager.AnyItemsBeingHoveredWhichPreventManeuverNodeAdder && orbitNode != null && orbitNode2 != null && (!(orbitNode2 is IPlanetNode) || !(orbitNode2.Name == orbitNode.Parent?.Name)))
			{
				Orbit orbit = new Orbit((Orbit)cursorInfo.OrbitInfo.OrbitNode.Orbit, cursorInfo.ClosestPoint.TrueAnomaly);
				IOrbitPoint pointAtTime = OrbitMath.GetPointAtTime(orbitNode2.Orbit, orbit.Time);
				double magnitude = (orbit.Position - pointAtTime.Position).magnitude;
				double magnitude2 = (orbit.Velocity - pointAtTime.Velocity).magnitude;
				double num = orbitNode.SphereOfInfluence + orbitNode2.SphereOfInfluence;
				double time = _playerCraftProvider.PlayerCraft.OrbitInfo.OrbitNode.Orbit.Time;
				targetAtCursorUiInfo.SecondsInFuture = pointAtTime.Time - time;
				targetAtCursorUiInfo.Captured = magnitude < num;
				targetAtCursorUiInfo.DeltaVelocity = magnitude2;
				targetAtCursorUiInfo.Distance = magnitude;
				mapOrbitInfo.UpdateUiComponentFromPoint(targetAtCursorUiInfo.CanvasGroup, _canvas, pointAtTime);
			}
			else
			{
				UiUtils.UiComponentSetEnabled(targetAtCursorUiInfo.CanvasGroup, enabled: false);
			}
		}
	}
}
