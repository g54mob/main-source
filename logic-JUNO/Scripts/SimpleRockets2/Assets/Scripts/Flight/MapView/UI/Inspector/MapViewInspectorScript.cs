using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Ui.Inspector;
using ModApi;
using ModApi.Flight;
using ModApi.Flight.MapView;
using ModApi.Ioc;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.UI.Inspector
{
	public class MapViewInspectorScript : MonoBehaviour, IMapViewInspector
	{
		private ICurrentCameraTarget _cameraTarget;

		private IMapViewCoordinateConverter _coordinateConverter;

		private MapDebugModel _debugModel;

		private IFlightScene _flightScene;

		private InspectorModel _inspectorModel;

		private IInspectorPanel _inspectorPanel;

		private IIocContainer _ioc;

		private IItemRegistry _itemRegistry;

		private ItemVisibilityModel _itemVisibilityModel;

		private ManeuverNodeModel _maneuverNodeModel;

		private IMapView _mapView;

		private IMapViewContext _mapViewContext;

		private NodeModel _nodeModel;

		private IMapOptions _options;

		private OptionsModel _optionsModel;

		private OrbitModel _orbitModel;

		private IPlayerCraftProvider _playerCraftProvider;

		private InspectorItemViewModel _selectedItem;

		private SelectedModel _selectedModel;

		private bool _visible;

		public IInspectorPanel InspectorPanel
		{
			get
			{
				return _inspectorPanel;
			}
			set
			{
				_inspectorPanel = value;
			}
		}

		public IMapView MapView => _mapView;

		public INavigationTargetProvider NavigationTargetProvider { get; private set; }

		public MapPlayerCraft PlayerCraft => _playerCraftProvider.PlayerCraft;

		public InspectorItemViewModel SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			private set
			{
				if (_selectedItem != null)
				{
					_selectedItem.OnDeselected();
				}
				_selectedItem = value;
				if (_selectedItem != null)
				{
					_selectedItem.OnSelected();
				}
			}
		}

		ICameraFocusable IMapViewInspector.SelectedItem => SelectedItem?.Target;

		public SelectedModel SelectedModel => _selectedModel;

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				bool num = _visible != value;
				_visible = value;
				if (num && _inspectorPanel != null)
				{
					_inspectorPanel.Visible = _visible;
				}
			}
		}

		public static MapViewInspectorScript Create(IIocContainer ioc, IMapViewContext mapViewContext)
		{
			GameObject obj = new GameObject("MapViewInspector");
			IObjectContainerProvider objectContainerProvider = ioc.Resolve<IObjectContainerProvider>(mapViewContext);
			obj.transform.SetParent(objectContainerProvider.UiContainer, worldPositionStays: false);
			MapViewInspectorScript mapViewInspectorScript = obj.AddComponent<MapViewInspectorScript>();
			mapViewInspectorScript.Initialize(ioc, mapViewContext);
			return mapViewInspectorScript;
		}

		public void Refresh()
		{
			if (SelectedItem != null)
			{
				SetTarget(SelectedItem.Target);
			}
		}

		public void SelectItem(ICameraFocusable item)
		{
			if (item is IChainableOrbit)
			{
				IChainableOrbit chainableOrbit = item as IChainableOrbit;
				PlayerCraft.ChainNodeSelection.SetSelected(chainableOrbit.ListNode, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			}
			else
			{
				_mapView.SetInspectorFocus(item, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			}
		}

		public void SetTarget(ICameraFocusable target)
		{
			SelectedItem = new InspectorItemViewModel(target, this);
			_selectedModel.OnSelectedItemChanged(SelectedItem);
			_itemVisibilityModel.ItemChanged(SelectedItem);
			if (target is MapStaticOrbitItem || target is MapPlayerCraft)
			{
				Visible = true;
			}
		}

		public void ShowMessage(string message)
		{
			_flightScene.FlightSceneUI.ShowMessage(message);
		}

		public void UpdateInspectorPanel()
		{
			if (_inspectorPanel == null)
			{
				return;
			}
			ICameraFocusable cameraFocusable = SelectedItem?.Target;
			if (cameraFocusable != null && cameraFocusable as MonoBehaviour == null && cameraFocusable != PlayerCraft)
			{
				Debug.LogWarning("Map view inspector selected item has been destroyed. Attempting to select player's craft");
				MapView.SetInspectorFocus(PlayerCraft, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			}
			bool flag = _flightScene != null && _flightScene.ViewManager.GameView.RenderView;
			_inspectorPanel.Visible = Visible && (!flag || _inspectorPanel.IsPinned);
			if (_inspectorPanel.Visible)
			{
				_selectedModel.Update();
				_orbitModel.Update(SelectedItem.OrbitNode);
				_nodeModel.Update();
				if (flag)
				{
					_maneuverNodeModel.Group.Visible = false;
				}
				else
				{
					_maneuverNodeModel.Update();
				}
				_itemVisibilityModel.Group.Visible = !flag;
				if (_optionsModel != null)
				{
					_optionsModel.Group.Visible = !flag;
				}
				if (_debugModel != null)
				{
					_debugModel.Group.Visible = !flag;
				}
			}
		}

		protected virtual void Start()
		{
			IIocContainer ioc = _ioc;
			_playerCraftProvider = ioc.Resolve<IPlayerCraftProvider>(_mapViewContext);
			NavigationTargetProvider = ioc.Resolve<INavigationTargetProvider>(_mapViewContext);
			_flightScene = Game.Instance.FlightScene;
			_cameraTarget = ioc.Resolve<ICurrentCameraTarget>(_mapViewContext);
			_inspectorModel = new InspectorModel("MapView", "Map Info");
			_selectedModel = new SelectedModel(this, ioc, _mapViewContext);
			_inspectorModel.AddGroup(_selectedModel.Group);
			_maneuverNodeModel = new ManeuverNodeModel(this, ioc, _mapViewContext);
			_inspectorModel.AddGroup(_maneuverNodeModel.Group);
			_maneuverNodeModel.Group.Visible = false;
			_nodeModel = new NodeModel(this);
			_inspectorModel.AddGroup(_nodeModel.Group);
			_nodeModel.Group.Visible = false;
			_orbitModel = new OrbitModel(_ioc, _mapViewContext);
			_inspectorModel.AddGroup(_orbitModel.Group);
			_orbitModel.Group.Collapsed = true;
			_orbitModel.OrbitUpdated += OnOrbitUpdated;
			_itemVisibilityModel = new ItemVisibilityModel(ioc, _mapViewContext, _flightScene != null);
			_inspectorModel.AddGroup(_itemVisibilityModel.Group);
			_itemVisibilityModel.Group.Collapsed = true;
			if (_flightScene != null)
			{
				_optionsModel = new OptionsModel(ioc, this);
				_inspectorModel.AddGroup(_optionsModel.Group);
				_optionsModel.Group.Collapsed = true;
			}
			if (Debug.isDebugBuild)
			{
				_debugModel = new MapDebugModel(ioc, _mapViewContext);
				_inspectorModel.AddGroup(_debugModel.Group);
				_debugModel.Group.Collapsed = true;
			}
			InspectorPanelCreationInfo inspectorPanelCreationInfo = new InspectorPanelCreationInfo();
			inspectorPanelCreationInfo.StartPosition = InspectorPanelCreationInfo.InspectorStartPosition.UpperRight;
			inspectorPanelCreationInfo.StartOffset = new Vector2(-170f, -90f);
			inspectorPanelCreationInfo.Resizable = !Device.IsMobileBuild;
			_inspectorPanel = Game.Instance.UserInterface.CreateInspectorPanel(_inspectorModel, inspectorPanelCreationInfo);
			_inspectorPanel.CloseButtonClicked += delegate
			{
				Visible = false;
			};
			_inspectorPanel.Transform.sizeDelta = new Vector2(260f, _inspectorPanel.Transform.sizeDelta.y);
			SetTarget(_cameraTarget.Target);
			Visible = !Device.IsMobileBuild;
		}

		protected virtual void Update()
		{
			UpdateInspectorPanel();
		}

		private void Initialize(IIocContainer ioc, IMapViewContext mapViewContext)
		{
			_ioc = ioc;
			_mapViewContext = mapViewContext;
			_mapView = _ioc.Resolve<IMapView>(mapViewContext);
			_itemRegistry = _ioc.Resolve<IItemRegistry>(_mapViewContext);
			_coordinateConverter = _ioc.Resolve<IMapViewCoordinateConverter>(_mapViewContext);
			_options = _ioc.Resolve<IMapOptions>();
			MapViewManagerScript.Instance.ForegroundStateChanged += OnForegroundStateChanged;
		}

		private void OnDestroy()
		{
			if (_inspectorModel != null && _inspectorModel.Panel as InspectorPanelScript != null)
			{
				GameObject gameObject = _inspectorModel.Panel.Transform.gameObject;
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
			}
			if (MapViewManagerScript.Instance != null)
			{
				MapViewManagerScript.Instance.ForegroundStateChanged -= OnForegroundStateChanged;
			}
		}

		private void OnForegroundStateChanged(bool foreground)
		{
			UpdateInspectorPanel();
		}

		private void OnOrbitUpdated()
		{
		}
	}
}
