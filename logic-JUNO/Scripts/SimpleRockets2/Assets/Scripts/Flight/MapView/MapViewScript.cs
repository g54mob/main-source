using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Dev.Philip.UiTesting.Scripts;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.MapDebug;
using Assets.Scripts.Flight.MapView.Options;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.MapView.Orbits.Chain;
using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using Assets.Scripts.Flight.MapView.Orbits.Interfaces;
using Assets.Scripts.Flight.MapView.Targeting;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.MapView.UI.Controllers;
using Assets.Scripts.Flight.MapView.UI.Inspector;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.PlanetStudio;
using ModApi.Craft;
using ModApi.Flight.GameView;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using ModApi.Settings.Core.Events;
using ModApi.State.MapView;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView
{
	public class MapViewScript : MonoBehaviour, IMapView, IDrawModeProvider, IMapViewCoordinateConverter, IObjectContainerProvider, IRenderTextureProvider, IPlayerCraftProvider, ILightPosition, IMapStateProvider, IMapViewContext, IContext
	{
		public enum NodeProcessingModeType
		{
			Disabled = 0,
			CraftOnly = 1,
			Full = 2
		}

		public enum RenderingModeType
		{
			Disabled = 0,
			Texture = 1,
			Screen = 2
		}

		public class OriginFloatedEventArgs : EventArgs
		{
			public Vector3d Delta { get; set; }

			public OriginFloatedEventArgs(Vector3d delta)
			{
				Delta = delta;
			}
		}

		private class ContainerReferences
		{
			public Transform CanvasesRoot { get; set; }

			public Transform CraftCanvases { get; set; }

			public Transform Crafts { get; set; }

			public Transform FloatingOriginIgnoreContainer { get; set; }

			public Transform General { get; set; }

			public Transform OrbitCanvases { get; set; }

			public Transform OrbitContainer { get; set; }

			public Transform Planets { get; set; }

			public Transform PlanetsCanvases { get; set; }

			public Transform Root { get; set; }

			public Transform UiContainer { get; set; }
		}

		private MapCameraScript _cameraScript;

		[SerializeField]
		private GameObject _containerObject;

		private ContainerReferences _containerReferences;

		private IMapViewCoordinateConverter _coordinateConverter;

		[SerializeField]
		private Light _directionalLight;

		private bool _firstFrame = true;

		private bool _firstTimeBeingVisible = true;

		private IGameCamera _gameCamera;

		private AudioListener _gameViewAudioListener;

		private IItemRegistry _itemRegistry;

		[SerializeField]
		private Camera _mapCamera;

		[SerializeField]
		private AudioListener _mapViewAudioListener;

		private Vector3 _mapViewAudioListenerPositionOffset;

		private MapViewData _mapViewStateData;

		private double _maxZoomDistance;

		private TargetingManager _navigationTargetProvider;

		private IObjectContainerProvider _objectContainerProvider;

		private IDrawMode _orbitDrawMode;

		[SerializeField]
		private PhysicsRaycasterCustomScript _physicsRaycaster;

		private MapPlayerCraft _playerCraft;

		private RenderTexture _renderTexture;

		Transform IObjectContainerProvider.CanvasesRoot => _containerReferences.CanvasesRoot;

		public IMapViewContext Context => this;

		Transform IObjectContainerProvider.CraftCanvases => _containerReferences.CraftCanvases;

		IOrbitNode IDrawModeProvider.CraftNode => PlayerCraftNode;

		Transform IObjectContainerProvider.Crafts => _containerReferences.Crafts;

		MapViewData IMapStateProvider.Data => _mapViewStateData;

		public IDrawMode DrawMode => _orbitDrawMode;

		Transform IObjectContainerProvider.FloatingOriginIgnoreContainer => _containerReferences.FloatingOriginIgnoreContainer;

		public Vector3d FloatingOriginOffset { get; private set; }

		Transform IObjectContainerProvider.General => _containerReferences.General;

		public IIocContainer Ioc { get; private set; }

		public IItemRegistry ItemRegistry => _itemRegistry;

		public bool IsInForeground { get; private set; }

		Vector3 ILightPosition.LightPosition => _directionalLight.transform.position;

		public Camera MapCamera => _mapCamera;

		public MapCameraScript MapCameraScript => _cameraScript;

		public double MapScale { get; private set; }

		public IMapViewInspector MapViewInspector => MapViewUi?.MapViewInspector;

		public MapViewUiController MapViewUi { get; private set; }

		public double MaxZoomDistance
		{
			get
			{
				return _maxZoomDistance;
			}
			set
			{
				_maxZoomDistance = value;
				_cameraScript.MaxZoomDistance = _coordinateConverter.MapScale * _maxZoomDistance;
			}
		}

		public NodeProcessingModeType NodeProcessingMode { get; private set; }

		Transform IObjectContainerProvider.OrbitCanvases => _containerReferences.OrbitCanvases;

		Transform IObjectContainerProvider.OrbitContainer => _containerReferences.OrbitContainer;

		public MapOrbitLineManagerScript OrbitLineManager { get; private set; }

		public PhysicsRaycasterCustomScript PhysicsRaycaster => _physicsRaycaster;

		Transform IObjectContainerProvider.Planets => _containerReferences.Planets;

		Transform IObjectContainerProvider.PlanetsCanvases => _containerReferences.PlanetsCanvases;

		public MapPlayerCraft PlayerCraft => _playerCraft;

		MapPlayerCraft IPlayerCraftProvider.PlayerCraft => _playerCraft;

		public CraftNode PlayerCraftNode => _playerCraft.OrbitInfo.OrbitNode as CraftNode;

		public RenderingModeType RenderingMode { get; private set; }

		RenderTexture IRenderTextureProvider.RenderTexture => _mapCamera.targetTexture;

		Transform IObjectContainerProvider.Root => _containerReferences.Root;

		public bool SyncCameraWithSelectedItem { get; set; } = true;

		public TargetingManager TargetingManager => _navigationTargetProvider;

		Transform ILightPosition.Transform => _directionalLight.transform;

		Transform IObjectContainerProvider.UiContainer => _containerReferences.UiContainer;

		public bool UiPanelsVisible
		{
			get
			{
				return _objectContainerProvider.UiContainer.gameObject.activeInHierarchy;
			}
			set
			{
				_objectContainerProvider.UiContainer.gameObject.SetActive(value);
			}
		}

		public bool UiVisible
		{
			get
			{
				return _containerReferences.UiContainer.gameObject.activeSelf;
			}
			set
			{
				_containerReferences.UiContainer.gameObject.SetActive(value);
			}
		}

		public bool Visible
		{
			get
			{
				return _containerObject.activeInHierarchy;
			}
			private set
			{
				_containerObject.SetActive(value);
				if (Game.InFlightScene && _containerObject.activeInHierarchy)
				{
					_gameCamera = FlightSceneScript.Instance.ViewManager.GameView.GameCamera;
					_mapViewAudioListenerPositionOffset = _gameViewAudioListener.transform.position - _gameCamera.Target.CameraTarget.position;
					_mapViewAudioListener.transform.SetPositionAndRotation(_gameCamera.Target.CameraTarget.position + _mapViewAudioListenerPositionOffset, _gameCamera.FarCamera.transform.rotation);
				}
			}
		}

		public event MapViewHandler Initialized;

		public event PlayerCraftHandler PlayerCraftChanged;

		public static MapViewScript Create(MapViewManagerScript mapViewManager, IIocContainer ioc, double scale, double maxZoomDistance, PlanetNode rootNode)
		{
			InfoPanel.EnabledByDefault = false;
			GameObject obj = Game.Instance.ResourceLoader.InstantiatePrefab("Flight/MapView/MapView");
			MapViewScript component = obj.GetComponent<MapViewScript>();
			obj.SetActive(value: true);
			component.transform.SetParent(mapViewManager.transform);
			component.Initialize(mapViewManager, ioc, scale, maxZoomDistance, rootNode);
			return component;
		}

		public MapPlanet AddPlanet(PlanetNode planetNode, Camera mapCamera)
		{
			MapPlanet result = MapPlanet.Create(Ioc, Context, planetNode, mapCamera);
			foreach (IPlanetNode childPlanet in planetNode.ChildPlanets)
			{
				AddPlanet(childPlanet as PlanetNode, mapCamera);
			}
			if (Game.InFlightScene)
			{
				planetNode.DynamicChildAdded += delegate(INode node)
				{
					if (node is StructureNode)
					{
						AddDynamicNode(node, mapCamera);
					}
				};
				foreach (INode dynamicNode in planetNode.DynamicNodes)
				{
					AddDynamicNode(dynamicNode, mapCamera);
				}
			}
			return result;
		}

		public Vector3d ConvertAbsoluteToWorldMapPosition(Vector3d absolutePosition)
		{
			return absolutePosition - FloatingOriginOffset;
		}

		public Vector3d ConvertMapViewToSolar(Vector3d mapViewPosition)
		{
			return ConvertWorldToAbsoluteMapPosition(mapViewPosition) / MapScale;
		}

		public Vector3d ConvertSolarToMapView(Vector3d solarPosition)
		{
			return ConvertAbsoluteToWorldMapPosition(solarPosition * MapScale);
		}

		public Vector3d ConvertWorldToAbsoluteMapPosition(Vector3d worldPosition)
		{
			return worldPosition + FloatingOriginOffset;
		}

		public void Initialize(MapViewManagerScript mapViewManager, IIocContainer ioc, double scale, double maxZoomDistance, PlanetNode rootNode)
		{
			MapScale = scale;
			Ioc = ioc;
			MapOptionsScript.Create(Ioc, base.gameObject);
			if (Game.InFlightScene)
			{
				_gameViewAudioListener = FlightSceneScript.Instance.ViewManager.GameView.GameCamera.Transform.GetComponent<AudioListener>();
			}
			ioc.RegisterContext(Context);
			ioc.Register((IObjectContainerProvider)this, (IContext)Context);
			_objectContainerProvider = ioc.Resolve<IObjectContainerProvider>(Context);
			CreateContainers();
			_itemRegistry = MapItemManager.Create(base.gameObject);
			OrbitLineManager = MapOrbitLineManagerScript.Create(this);
			_navigationTargetProvider = new TargetingManager(Ioc, this, this, this, _itemRegistry);
			ioc.Register((IMapView)this, (IContext)Context);
			ioc.Register((IRenderTextureProvider)this, (IContext)Context);
			ioc.Register((INavigationTargetProvider)_navigationTargetProvider, (IContext)Context);
			ioc.Register((IOrbitLineManager)OrbitLineManager, (IContext)Context);
			ioc.Register(_itemRegistry, Context);
			ioc.Register((IMapViewCoordinateConverter)this, (IContext)Context);
			ioc.Register((IDrawModeProvider)this, (IContext)Context);
			ioc.Register((IPlayerCraftProvider)this, (IContext)Context);
			ioc.Register((ILightPosition)this, (IContext)Context);
			ioc.Register((IMapStateProvider)this, (IContext)Context);
			_coordinateConverter = ioc.Resolve<IMapViewCoordinateConverter>(Context);
			_cameraScript = MapCameraScript.Create(Ioc, Context, base.gameObject, _mapCamera, maxZoomDistance);
			MaxZoomDistance = maxZoomDistance;
			if (Game.InFlightScene)
			{
				FlightSceneScript instance = FlightSceneScript.Instance;
				_mapViewStateData = instance.FlightState.MapView;
			}
			else
			{
				_mapViewStateData = new MapViewData(() => MapViewManagerScript.Instance.Ioc, null);
			}
			_mapViewStateData.MapItemDataSet.SetDataItemsAccessor(() => _itemRegistry.OrbitNodes.Select((MapOrbitNode x) => x.Data));
			_mapViewStateData.SetDirty();
			AddPlanet(rootNode, MapCamera);
			if (_cameraScript.Target == null)
			{
				SyncCameraWithSelectedItem = true;
				SetCameraFocus(_itemRegistry.GetPlanet(rootNode), CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
				_cameraScript.SetRotationAndZoom(new Vector2(-30f, -30f), (float)(3.0 * rootNode.PlanetData.Radius * 0.0001));
			}
			if (Game.InFlightScene)
			{
				this.PlayerCraftChanged?.Invoke(_playerCraft, null);
				FlightSceneScript instance2 = FlightSceneScript.Instance;
				instance2.CraftChanged += OnPlayerCraftNodeChanged;
				instance2.FlightState.CraftNodeAdded += OnCraftNodeAdded;
				instance2.FlightState.MapView.GeneratingXml += OnMapViewDataGeneratingXml;
			}
			Game.Instance.Settings.Quality.Map.MapLineResolution.Changed += OnMapLineResolutionChanged;
		}

		public void PerformMapClosedUpdates()
		{
			MapViewInspectorScript mapViewInspectorScript = MapViewUi?.MapViewInspector;
			if ((object)mapViewInspectorScript != null && mapViewInspectorScript.Visible)
			{
				if (PlayerCraft != null)
				{
					PlayerCraft.OnBeforeCameraPositioned(mapViewVisible: false);
					PlayerCraft.OnAfterCameraPositioned(mapViewVisible: false);
				}
				mapViewInspectorScript.UpdateInspectorPanel();
			}
		}

		public void SetCameraFocus(ICameraFocusable cameraFocus, CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition)
		{
			SetFocus(focusCamera: true, SyncCameraWithSelectedItem, cameraFocus, transitionSpeed, repositionCamDuringTransition);
		}

		public void SetForeground(bool foreground)
		{
			if (foreground)
			{
				SetProcessingModes(RenderingModeType.Screen, NodeProcessingModeType.Full);
			}
			else
			{
				SetProcessingModes(RenderingModeType.Disabled, NodeProcessingModeType.Disabled);
			}
			IsInForeground = foreground;
		}

		public void SetInspectorFocus(ICameraFocusable cameraFocus, CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition)
		{
			SetFocus(SyncCameraWithSelectedItem, focusInspector: true, cameraFocus, transitionSpeed, repositionCamDuringTransition);
		}

		public void SetProcessingModes(RenderingModeType? renderingMode, NodeProcessingModeType? nodeProcessingMode)
		{
			if (renderingMode.HasValue)
			{
				RenderingMode = renderingMode.Value;
			}
			if (nodeProcessingMode.HasValue)
			{
				NodeProcessingMode = nodeProcessingMode.Value;
			}
			if (RenderingMode == RenderingModeType.Disabled)
			{
				Visible = false;
				return;
			}
			Visible = true;
			if (_firstTimeBeingVisible)
			{
				_firstTimeBeingVisible = false;
				FirstTimeInitialization();
			}
		}

		internal void SetOrbitDrawMode(IDrawMode newDrawMode)
		{
			_orbitDrawMode = newDrawMode;
		}

		protected virtual void OnDestroy()
		{
			if (_playerCraft != null)
			{
				_playerCraft.ChainNodeSelection.SetSelected(null);
			}
			MapItem.ItemClicked -= ItemClicked;
			Game.Instance.Settings.Quality.Map.MapLineResolution.Changed -= OnMapLineResolutionChanged;
			if (_navigationTargetProvider != null)
			{
				_navigationTargetProvider.Dispose();
			}
			if (Game.InPlanetStudioScene && PlanetStudioScript.Instance?.PlanetStudioUI != null)
			{
				PlanetStudioUIScript obj = PlanetStudioScript.Instance.PlanetStudioUI as PlanetStudioUIScript;
				obj.InputHandler.RemoveInputResponder(_cameraScript.InputResponder);
				obj.InputHandler.RemoveInputResponder(_physicsRaycaster.InputResponder);
			}
		}

		protected virtual void Update()
		{
			if (Game.InFlightScene)
			{
				_mapViewAudioListener.transform.position = _gameCamera.Target.CameraTarget.position + _mapViewAudioListenerPositionOffset;
			}
		}

		private static void AddAutoArrangeControls()
		{
		}

		private void AddCraft(CraftNode craftNode, Camera mapCamera)
		{
			if (craftNode.IsPlayer || craftNode.IsLoadedInGameView)
			{
				AddDynamicCraft(craftNode, mapCamera);
			}
			else
			{
				AddStaticOrbit(craftNode, mapCamera);
			}
		}

		private void AddDynamicCraft(CraftNode craftNode, Camera mapCamera)
		{
			if (craftNode.IsPlayer)
			{
				MapPlayerCraft playerCraft = MapPlayerCraft.Create(Ioc, Context, craftNode, mapCamera);
				_playerCraft = playerCraft;
				SetCameraFocus(_playerCraft, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			}
			else
			{
				MapCraft.Create(Ioc, Context, craftNode, mapCamera);
			}
		}

		private void AddDynamicNode(INode dynamicNode, Camera mapCamera)
		{
			if (!dynamicNode.IsDestroyed)
			{
				if (dynamicNode is CraftNode craftNode)
				{
					AddCraft(craftNode, mapCamera);
				}
				else if (dynamicNode is StructureNode structureNode && structureNode.Data.VisibleInMapView)
				{
					AddStationaryNode(structureNode, mapCamera);
				}
			}
		}

		private void AddStaticOrbit(OrbitNode orbitNode, Camera mapCamera)
		{
			MapStaticOrbitItem.Create(Ioc, Context, orbitNode, mapCamera);
		}

		private MapSurfaceItem AddStationaryNode(IStationaryNode node, Camera mapCamera)
		{
			return MapSurfaceItem.Create(Ioc, Context, node, mapCamera);
		}

		private void CheckFloatingOrigin()
		{
			if (MapCamera.transform.position.sqrMagnitude > 1000000f)
			{
				StartCoroutine(FloatOriginAtFrameEnd());
			}
		}

		private Transform CreateContainer(string name, Transform parent)
		{
			Transform obj = new GameObject(name).transform;
			obj.gameObject.layer = parent.gameObject.layer;
			obj.SetParent(parent, worldPositionStays: false);
			return obj;
		}

		private void CreateContainers()
		{
			_containerReferences = new ContainerReferences();
			_containerReferences.Root = base.transform;
			_containerReferences.FloatingOriginIgnoreContainer = _containerReferences.Root.Find("FloatingOriginIgnoreContainer");
			_containerReferences.General = _containerReferences.Root.Find("General");
			_containerReferences.OrbitContainer = CreateContainer("MapOrbitLines", _objectContainerProvider.FloatingOriginIgnoreContainer);
			_containerReferences.UiContainer = _containerReferences.FloatingOriginIgnoreContainer.Find("MainUi");
			_containerReferences.Planets = CreateContainer("Planets", _objectContainerProvider.Root);
			_containerReferences.Crafts = CreateContainer("Crafts", _objectContainerProvider.Root);
			_containerReferences.CanvasesRoot = CreateContainer("Canvases", _containerReferences.UiContainer);
			_containerReferences.CraftCanvases = CreateContainer("CraftCanvases", _objectContainerProvider.CanvasesRoot);
			_containerReferences.PlanetsCanvases = CreateContainer("PlanetCanvases", _objectContainerProvider.CanvasesRoot);
			_containerReferences.OrbitCanvases = CreateContainer("OrbitCanvases", _objectContainerProvider.CanvasesRoot);
		}

		private void FirstTimeInitialization()
		{
			MapViewUi = MapViewUiController.Create(Ioc, _objectContainerProvider.UiContainer, this);
			this.Initialized?.Invoke(this);
		}

		private void FloatOrigin()
		{
			Vector3 localPosition = _mapCamera.transform.localPosition;
			FloatingOriginOffset += (Vector3d)localPosition;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				if (child != _objectContainerProvider.FloatingOriginIgnoreContainer)
				{
					for (int j = 0; j < child.childCount; j++)
					{
						child.GetChild(j).transform.localPosition -= localPosition;
					}
				}
			}
			_mapCamera.transform.localPosition = Vector3.zero;
		}

		private IEnumerator FloatOriginAtFrameEnd()
		{
			yield return new WaitForEndOfFrame();
			FloatOrigin();
		}

		private void ItemClicked(object sender, MapItem.ItemClickedEventArgs e)
		{
			if (e.ItemClicked is ICameraFocusable { FocusByClick: not false } cameraFocusable && !UnityEngine.Input.anyKey)
			{
				SetCameraFocus(cameraFocusable, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			}
			if (Game.InPlanetStudioScene)
			{
				MapViewUi.MapViewInspector.Visible = true;
			}
		}

		private void LateUpdate()
		{
			if (!_firstFrame)
			{
				Physics.SyncTransforms();
				UpdateMapItems();
				CheckFloatingOrigin();
			}
			else
			{
				_firstFrame = false;
			}
		}

		private void OnCraftNodeAdded(CraftNode craftNode)
		{
			AddCraft(craftNode, MapCamera);
		}

		private void OnMapLineResolutionChanged(object sender, SettingChangedEventArgs<float> e)
		{
			foreach (MapOrbitLine orbitLine in _itemRegistry.OrbitLines)
			{
				orbitLine.OnLineResolutionQualityChanged();
			}
		}

		private void OnMapViewDataGeneratingXml(MapViewData source)
		{
			_playerCraft?.SynchronizeManeuverNodeData();
			IEnumerable<int> nodeIdsToKeep = _itemRegistry.Crafts.Select((MapItem x) => (x.OrbitInfo.OrbitNode as CraftNode).NodeId);
			source.RemoveManeuverNodesNotIn(nodeIdsToKeep);
		}

		private void OnPlayerCraftNodeChanged(ICraftNode craftNode)
		{
			MapItem current = _itemRegistry.Crafts.Where((MapItem x) => x.OrbitInfo.OrbitNode == craftNode).FirstOrDefault();
			MapPlayerCraft playerCraft = _playerCraft;
			_playerCraft = MapItem.SwitchType<MapPlayerCraft>(current);
			this.PlayerCraftChanged?.Invoke(_playerCraft, playerCraft);
			if (playerCraft != null)
			{
				if (playerCraft.OrbitInfo.OrbitNode.GameViewObject.IsLoadedInGameView)
				{
					MapItem.SwitchType<MapCraft>(playerCraft);
				}
				else
				{
					MapItem.SwitchType<MapStaticOrbitItem>(playerCraft);
				}
			}
			SetFocus(focusCamera: true, focusInspector: true, _playerCraft, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
		}

		private void RenderMapViewToTexture()
		{
			_renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
			MapCamera.targetTexture = _renderTexture;
		}

		private void RunOrbitTestVerifyConstructorTypeEquality()
		{
			Vector3d position = Vector3d.Scale(Vector3d.one * FlightSceneScript.Instance.FlightState.RootNode.PlanetData.Radius * 10.0, new Vector3d(1f, 0f, 0f));
			Vector3d velocity = new Vector3d(0f, 10f, 500f);
			OrbitDebugScript.RunTestFromStateVectors(position, velocity, 0.0, this);
			bool prograde = true;
			double semiMajorAxis = 12559826100.0;
			int num = 1;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			OrbitDebugScript.RunTestFromOrbitalElements(0.82, num5, semiMajorAxis, num2, num, num3, num4, prograde, this);
		}

		private void RunOrbitTestVerifyNewGetPoints()
		{
		}

		private void SetFocus(bool focusCamera, bool focusInspector, ICameraFocusable cameraFocus, CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition)
		{
			if (focusCamera)
			{
				_cameraScript.SetTarget(cameraFocus, transitionSpeed, repositionCamDuringTransition);
			}
			if (focusInspector)
			{
				MapViewUi?.MapViewInspector.SetTarget(cameraFocus);
			}
		}

		private void Start()
		{
			if (Game.InFlightScene)
			{
				FlightSceneScript instance = FlightSceneScript.Instance;
				instance.FlightSceneUI.AddInputResponder(_cameraScript.InputResponder);
				instance.FlightSceneUI.AddInputResponder(_physicsRaycaster.InputResponder);
			}
			else if (Game.InPlanetStudioScene)
			{
				PlanetStudioUIScript obj = PlanetStudioScript.Instance.PlanetStudioUI as PlanetStudioUIScript;
				obj.InputHandler.AddInputResponder(_cameraScript.InputResponder);
				obj.InputHandler.AddInputResponder(_physicsRaycaster.InputResponder);
			}
			MapItem.ItemClicked += ItemClicked;
			FloatOrigin();
			DebugPanel.Instance.AddToggleButton("orbit debug", OrbitChainNodeScript.ShowDebug, delegate(bool x)
			{
				OrbitChainNodeScript.ShowDebug = x;
			});
			DebugPanel.Instance.AddToggleButton("target debug", TargetingManager.ShowDebug, delegate(bool x)
			{
				TargetingManager.ShowDebug = x;
			});
			AddAutoArrangeControls();
		}

		private void UpdateMapItems()
		{
			_itemRegistry.PerformMapItemAction(delegate(MapItem x)
			{
				x.OnBeforeCameraPositioned();
			});
			_navigationTargetProvider.OnBeforeCameraRepositioned();
			MapCameraScript.UpdateCamera();
			_navigationTargetProvider.OnAfterCameraRepositioned();
			_itemRegistry.PerformMapItemAction(delegate(MapItem x)
			{
				x.OnAfterCameraPositioned();
			});
		}
	}
}
