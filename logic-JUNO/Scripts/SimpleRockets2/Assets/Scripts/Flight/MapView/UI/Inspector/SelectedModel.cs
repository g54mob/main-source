using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.MapView.Automation;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.PlanetStudio.UI;
using Assets.Scripts.Ui.Inspector;
using ModApi.CelestialData;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Ioc;
using ModApi.Math;
using ModApi.Planet;
using ModApi.PlanetStudio;
using ModApi.Ui;
using ModApi.Ui.Inspector;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.UI.Inspector
{
	public class SelectedModel
	{
		private ProgressBarModel _burnProgressBar;

		private IconButtonModel _buttonAutoBurn;

		private IconButtonModel _buttonDelete;

		private IconButtonModel _buttonRenameNode;

		private IconButtonModel _buttonSelectPlayer;

		private IconButtonModel _buttonSyncCamera;

		private IconButtonModel _buttonTakeControl;

		private IconButtonModel _buttonToggleLock;

		private IconButtonModel _buttonToggleTarget;

		private IconButtonModel _buttonWarpToNode;

		private IMapViewCoordinateConverter _coordinateConverter;

		private IGameTime _gameTime;

		private IconButtonRowModel _iconButtons;

		private IIocContainer _ioc;

		private IItemRegistry _itemRegistry;

		private IMapView _mapView;

		private IMapViewContext _mapViewContext;

		private MapViewInspectorScript _mapViewInspector;

		private TextModel _nodeArrivalTime;

		private TextModel _nodeBurnAccuracy;

		private TextModel _nodeBurnTime;

		private TextModel _nodeDeltaV;

		private SpinnerModel _nodeSpinner;

		private IMapOptions _options;

		private TextModel _selectedText;

		public string BurnAccuracy { get; private set; }

		public float BurnProgress => NodeNavigator.Progress;

		public string FilePath { get; set; }

		public GroupModel Group { get; private set; }

		public InspectorItemViewModel SelectedItem => _mapViewInspector.SelectedItem;

		public string SelectedNodeName { get; set; }

		public GameObject SelectPlayerButton => _buttonSelectPlayer.ItemElement.GameObject;

		public string Target { get; private set; }

		private NodeNavigator NodeNavigator => _mapViewInspector.PlayerCraft.NodeNavigator;

		private CraftNode SelectedCraftNode => SelectedItem.GetCraftNode();

		public SelectedModel(MapViewInspectorScript mapViewInspector, IIocContainer ioc, IMapViewContext mapViewContext)
		{
			_mapViewContext = mapViewContext;
			_ioc = ioc;
			_itemRegistry = _ioc.Resolve<IItemRegistry>(_mapViewContext);
			_coordinateConverter = _ioc.Resolve<IMapViewCoordinateConverter>(_mapViewContext);
			_options = _ioc.Resolve<IMapOptions>();
			_gameTime = _ioc.Resolve<IGameTime>();
			_mapView = _ioc.Resolve<IMapView>(mapViewContext);
			_mapViewInspector = mapViewInspector;
			Group = new GroupModel(null);
			_selectedText = new TextModel("Type", () => SelectedItem.Name);
			_selectedText.ElementCreated += OnSelectedTextElementCreated;
			Group.Add(_selectedText);
			if (Game.InPlanetStudioScene)
			{
				TextModel item = new TextModel("File", () => FilePath);
				Group.Add(item);
			}
			_nodeSpinner = new SpinnerModel(() => SelectedItem.Name);
			_nodeSpinner.NextClicked = delegate
			{
				AdvanceNode(1);
			};
			_nodeSpinner.PrevClicked = delegate
			{
				AdvanceNode(-1);
			};
			_nodeSpinner.ElementCreated += OnNodeSpinnerElementCreated;
			Group.Add(_nodeSpinner);
			_iconButtons = new IconButtonRowModel();
			if (Game.InFlightScene)
			{
				_nodeArrivalTime = new TextModel("Arrival Time", () => SelectedItem.ArrivalTime);
				_nodeDeltaV = new TextModel("Delta V", () => SelectedItem.DeltaV);
				_nodeBurnTime = new TextModel("Burn Time", () => SelectedItem.BurnDuration);
				_nodeBurnAccuracy = new TextModel("Accuracy", () => SelectedItem.BurnAccuracy);
				_burnProgressBar = new ProgressBarModel("Delta V", () => BurnProgress);
				Group.Add(_nodeBurnAccuracy);
				Group.Add(_nodeArrivalTime);
				Group.Add(_nodeDeltaV);
				Group.Add(_nodeBurnTime);
				Group.Add(_burnProgressBar);
				_nodeArrivalTime.Visible = false;
				_nodeDeltaV.Visible = false;
				_nodeBurnTime.Visible = false;
				_nodeBurnAccuracy.Visible = false;
				_buttonSelectPlayer = new IconButtonModel("Ui/Sprites/MapView/IconPlayer", delegate
				{
					OnSelectPlayer();
				}, "Select player");
				_buttonSyncCamera = new IconButtonModel("Ui/Sprites/MapView/IconCamera", delegate
				{
					OnToggleSyncCamera();
				}, "Toggles the option to sync the camera focus to the selected item.");
				_buttonAutoBurn = new IconButtonModel("Ui/Sprites/MapView/IconAutoBurn", delegate
				{
					OnAutoBurnClicked();
				}, "Toggle to have the player craft perform an auto-burn when a burn node is approached.");
				_buttonWarpToNode = new IconButtonModel("Ui/Sprites/MapView/IconWarpToNode", delegate
				{
					OnWarpToNodeClicked();
				}, "Warp player craft to the next node");
				_buttonToggleTarget = new IconButtonModel("Ui/Sprites/MapView/IconSetTarget", delegate
				{
					OnToggleTargetClicked();
				}, "Set as current target");
				_buttonTakeControl = new IconButtonModel("Ui/Sprites/MapView/IconTakeControl", delegate
				{
					OnTakeControlClicked();
				}, "Take control of this craft");
				_buttonToggleLock = new IconButtonModel("Ui/Sprites/MapView/IconNodeLocked", delegate
				{
					OnToggleLockClicked();
				}, "Locking the node prevents it from being updated by changes to the craft's velocity and should be enabled before performing burns.");
				_buttonRenameNode = new IconButtonModel("Ui/Sprites/MapView/IconRenameNode", delegate
				{
					OnRenameNodeClicked();
				}, "Change the name of this craft");
				_iconButtons.Add(_buttonAutoBurn);
				_iconButtons.Add(_buttonWarpToNode);
				_iconButtons.Add(_buttonSelectPlayer);
				_iconButtons.Add(_buttonSyncCamera);
				_iconButtons.Add(_buttonToggleTarget);
				_iconButtons.Add(_buttonTakeControl);
				_iconButtons.Add(_buttonToggleLock);
				_iconButtons.Add(_buttonRenameNode);
			}
			else if (Game.InPlanetStudioScene)
			{
				IconButtonModel button = new IconButtonModel("Ui/Sprites/PlanetStudio/IconEdit", delegate
				{
					OnEditPlanetClicked();
				}, "Edit this planet in the Celestial Body Designer");
				IconButtonModel button2 = new IconButtonModel("Ui/Sprites/MapView/IconReplacePlanet", delegate
				{
					OnReplacePlanetClicked();
				}, "Replace this planet");
				IconButtonModel button3 = new IconButtonModel("Ui/Sprites/Common/IconAdd", delegate
				{
					OnAddPlanetClicked();
				}, "Add child planet that will orbit this planet");
				_iconButtons.Add(button);
				_iconButtons.Add(button2);
				_iconButtons.Add(button3);
			}
			_buttonDelete = new IconButtonModel("Ui/Sprites/MapView/IconTrash", delegate
			{
				OnDestroyClicked();
			}, "Destroy this item");
			_buttonDelete.Style = ButtonModel.ButtonStyle.Warning;
			_iconButtons.Add(_buttonDelete);
			Group.Add(_iconButtons);
		}

		public void OnSelectedItemChanged(InspectorItemViewModel selectedItem)
		{
			_buttonDelete.Visible = selectedItem.CanDelete;
			if (Game.InFlightScene)
			{
				_buttonSelectPlayer.Visible = selectedItem.CanSelectPlayer;
				_buttonTakeControl.Visible = selectedItem.CanTakeControl && Game.Instance.LevelManager.CurrentLevel == null;
				_buttonToggleLock.Visible = selectedItem.CanLock;
				_buttonToggleTarget.Visible = selectedItem.CanTarget;
				_buttonAutoBurn.Visible = selectedItem.ShowAutoBurn;
				_buttonWarpToNode.Visible = selectedItem.ShowWarpToNext;
				_buttonRenameNode.Visible = selectedItem.ShowNodeRenameButton;
				_nodeArrivalTime.Visible = SelectedItem.ShowArrivalTime;
				_nodeDeltaV.Visible = SelectedItem.IsManeuverNode;
				_nodeBurnTime.Visible = SelectedItem.IsManeuverNode;
				_nodeBurnAccuracy.Visible = SelectedItem.IsManeuverNode;
				_nodeArrivalTime.Visible = SelectedItem.ShowArrivalTime;
				_nodeDeltaV.Visible = SelectedItem.IsManeuverNode;
				_nodeBurnTime.Visible = SelectedItem.IsManeuverNode;
				_nodeBurnAccuracy.Visible = SelectedItem.IsManeuverNode;
			}
			else if (SelectedItem.OrbitNode is PlanetNode planetNode)
			{
				CelestialFile file = Game.Instance.CelestialDatabase.GetFile(planetNode.PlanetData.Id);
				if (file.Path.InUserData)
				{
					FilePath = file.Path.FileName;
				}
				else
				{
					FilePath = "GameData";
				}
			}
			else
			{
				FilePath = "None";
			}
			_iconButtons.Visible = _iconButtons.Buttons.Any((IconButtonModel x) => x.Visible);
			_selectedText.Label = SelectedItem.ItemType;
			_selectedText.Visible = SelectedItem.ShowName;
			_nodeSpinner.Visible = SelectedItem.ShowNodeNavigation;
			_nodeSpinner.NextButtonVisible = SelectedItem.ShowNodeNextButton;
			_nodeSpinner.PrevButtonVisible = SelectedItem.ShowNodePrevButton;
			_buttonDelete.Tooltip = "Destroy " + SelectedItem.Name;
		}

		public void Update()
		{
			if (Game.InFlightScene)
			{
				_buttonToggleTarget.Style = (SelectedItem.IsTargeted ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
				_buttonToggleLock.Style = (SelectedItem.IsLocked ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
				_buttonWarpToNode.Style = (NodeNavigator.IsWarping ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
				_buttonAutoBurn.Style = (NodeNavigator.AutoBurn ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
				_buttonSyncCamera.Style = (_mapView.SyncCameraWithSelectedItem ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
				_burnProgressBar.Visible = SelectedItem.IsManeuverNode && SelectedItem.IsPerformingBurn;
				if (_burnProgressBar.Visible)
				{
					_burnProgressBar.Label = Units.GetPercentageString(_burnProgressBar.Value);
				}
			}
			_nodeSpinner.NextButtonVisible = SelectedItem.ShowNodeNextButton;
			_nodeSpinner.PrevButtonVisible = SelectedItem.ShowNodePrevButton;
		}

		private void AdvanceNode(int direction)
		{
			if (direction > 0)
			{
				_mapViewInspector.PlayerCraft.ChainNodeSelection.SelectNext(CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			}
			else
			{
				_mapViewInspector.PlayerCraft.ChainNodeSelection.SelectPrevious(CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			}
		}

		private void OnAddPlanetClicked()
		{
			PlanetStudioUIScript obj = PlanetStudioScript.Instance.PlanetStudioUI as PlanetStudioUIScript;
			CelestialBodyListViewModel celestialBodyListViewModel = new CelestialBodyListViewModel(null, "Add");
			celestialBodyListViewModel.ItemSelected += OnAddPlanetListItemSelected;
			obj.CreateListView(celestialBodyListViewModel);
		}

		private void OnAddPlanetListItemSelected(ListViewModel model)
		{
			CelestialFile selectedFile = (model as CelestialBodyListViewModel).SelectedFile;
			if (selectedFile != null)
			{
				string newLocalId = Game.Instance.CelestialDatabase.GetCelestialBody(selectedFile.Id).Name;
				if (PlanetarySystemDesignerScript.Instance.CelestialBodyFiles.FirstOrDefault((CelestialFileDesignerInfo x) => x.File.Id == selectedFile.Id || x.Id == newLocalId) != null)
				{
					Game.Instance.UserInterface.CreateMessageDialog("The selected planet already exists in the planetary system.  Duplicates are not currently supported.");
				}
				else if (selectedFile != null)
				{
					MapPlanet mapPlanet = SelectedItem.GetMapItem() as MapPlanet;
					PlanetNode planetNode = mapPlanet.OrbitInfo.OrbitNode as PlanetNode;
					PlanetarySystemDesignerScript.Instance.AddPlanetNode(mapPlanet, selectedFile, _gameTime.Time, repositionCamera: true, _ioc.Resolve<ICurrentCameraTarget>(_mapViewContext), planetNode.PlanetData.SolarSystemData);
				}
			}
		}

		private void OnAutoBurnClicked()
		{
			NodeNavigator.AutoBurn = !NodeNavigator.AutoBurn;
		}

		private void OnConfirmDestroyClicked(MessageDialogScript messageDialog)
		{
			if (Game.InPlanetStudioScene)
			{
				string name = (SelectedItem.MapOrbitNode.OrbitInfo.OrbitNode as PlanetNode).Name;
				SelectedItem?.Delete();
				PlanetarySystemDesignerScript.Instance.RemoveCelestialBody(name);
			}
			else
			{
				SelectedItem?.Delete();
			}
			messageDialog.Close();
		}

		private void OnConfirmTakeControlClicked(MessageDialogScript messageDialog)
		{
			if (SelectedCraftNode != null)
			{
				FlightSceneScript flightSceneScript = Game.Instance.FlightScene as FlightSceneScript;
				bool flag = false;
				if (SelectedCraftNode.CraftScript != null && flightSceneScript.ChangePlayersActiveCommandPodImmediate(SelectedCraftNode.CraftScript.ActiveCommandPod, SelectedCraftNode))
				{
					flag = true;
					_mapViewInspector.SetTarget(SelectedItem.Target);
					string text = $"Switched to craft '{SelectedCraftNode.Name}'";
					flightSceneScript.FlightSceneUI.FlightLog.AddLog(text, FlightLogEntryCategory.Default);
					flightSceneScript.FlightSceneUI.ShowMessage(text);
				}
				if (!flag)
				{
					flightSceneScript.ChangePlayersActiveCraftNode(SelectedCraftNode);
					Debug.Log("Reloading scene to switch craft nodes.");
				}
			}
			messageDialog.Close();
		}

		private void OnDestroyClicked()
		{
			string deleteConfirmation = SelectedItem.DeleteConfirmation;
			if (deleteConfirmation != null)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = deleteConfirmation;
				messageDialogScript.OkayClicked += OnConfirmDestroyClicked;
				messageDialogScript.UseDangerButtonStyle = true;
			}
			else
			{
				SelectedItem.Delete();
			}
		}

		private void OnEditPlanetClicked()
		{
			(PlanetStudioScript.Instance.PlanetStudioUI as PlanetStudioUIScript).PlanetStudioScript.PlanetarySystemDesignerScript.EditPlanet(SelectedItem.Name);
		}

		private void OnNodeSpinnerElementCreated(IItemElement element)
		{
			SpinnerElement obj = element as SpinnerElement;
			obj.Text.enableAutoSizing = true;
			obj.Text.fontSizeMax = 16f;
			obj.Text.fontSizeMin = 10f;
		}

		private void OnRenameNodeClicked()
		{
			CraftNode craftNode = SelectedItem.GetCraftNode();
			if (craftNode != null)
			{
				InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
				inputDialogScript.InputText = craftNode.Name;
				inputDialogScript.MessageText = "Rename Craft";
				inputDialogScript.InputPlaceholderText = "Craft Name";
				inputDialogScript.OkayClicked += delegate(InputDialogScript d)
				{
					d.Close();
					craftNode.Name = d.InputText;
					_mapViewInspector.Refresh();
					((MapViewScript)_mapView).MapViewUi.SearchPanel.OnMapItemsChanged();
				};
			}
		}

		private void OnReplacePlanetClicked()
		{
			PlanetStudioUIScript obj = PlanetStudioScript.Instance.PlanetStudioUI as PlanetStudioUIScript;
			CelestialBodyListViewModel celestialBodyListViewModel = new CelestialBodyListViewModel(null, "Replace");
			celestialBodyListViewModel.ItemSelected += OnReplacePlanetListItemSelected;
			obj.CreateListView(celestialBodyListViewModel);
		}

		private void OnReplacePlanetListItemSelected(ListViewModel model)
		{
			CelestialFile selectedFile = (model as CelestialBodyListViewModel).SelectedFile;
			if (selectedFile == null)
			{
				return;
			}
			PlanetNode planetNode = SelectedItem.MapOrbitNode.OrbitInfo.OrbitNode as PlanetNode;
			PlanetNode parentNode = planetNode.Parent as PlanetNode;
			string name = planetNode.Name;
			string newLocalId = Game.Instance.CelestialDatabase.GetCelestialBody(selectedFile.Id).Name;
			if (PlanetarySystemDesignerScript.Instance.CelestialBodyFiles.FirstOrDefault((CelestialFileDesignerInfo x) => x.File.Id == selectedFile.Id || x.Id == newLocalId) != null && name != newLocalId)
			{
				Game.Instance.UserInterface.CreateMessageDialog("The selected planet already exists in the planetary system.  Duplicates are not currently supported.");
				return;
			}
			Orbit orbit = ((planetNode.Orbit != null) ? new Orbit(planetNode.Orbit) : null);
			double sphereOfInfluence = planetNode.SphereOfInfluence;
			List<IPlanetNode> list = planetNode.ChildPlanets.ToList();
			foreach (IPlanetNode item in list)
			{
				planetNode.RemoveChildNode(item);
			}
			SelectedItem.Delete();
			PlanetarySystemDesignerScript.Instance.ReplaceCelestialBody(selectedFile, name);
			PlanetDataScript planetData = PlanetarySystemDesignerScript.Instance.CurrentPlanetarySystem.Planets.Where((PlanetDataScript x) => x.Name == newLocalId).FirstOrDefault();
			PlanetNode planetNode2 = PlanetarySystemDesignerScript.Instance.CreatePlanetNode(parentNode, planetData);
			if (PlanetarySystemDesignerScript.Instance.RootNode == planetNode)
			{
				PlanetarySystemDesignerScript.Instance.RootNode = planetNode2;
			}
			if (orbit != null)
			{
				planetNode2.Orbit.UpdateFromOrbitalElements(orbit.Time, orbit.Eccentricity, orbit.SemiMajorAxis, orbit.PeriapsisAngle, orbit.TrueAnomaly, orbit.Inclination, orbit.RightAscensionOfAscendingNode, orbit.PrimaryMass, orbit.IsPrograde);
				planetNode2.SetSoi(sphereOfInfluence);
			}
			MapViewManagerScript mapViewManagerScript = _ioc.Resolve<IMapViewManager>() as MapViewManagerScript;
			MapPlanet cameraFocus = mapViewManagerScript.MapView.AddPlanet(planetNode2, mapViewManagerScript.MapView.MapCamera);
			mapViewManagerScript.MapView.SetInspectorFocus(cameraFocus, CameraTransitionSpeed.Default, repositionCamDuringTransition: false);
			foreach (IPlanetNode child in list)
			{
				child.SetPlanetData(PlanetarySystemDesignerScript.Instance.CurrentPlanetarySystem.Planets.Where((PlanetDataScript x) => x.Name == child.Name).FirstOrDefault());
				planetNode2.AddChildNode(child);
			}
		}

		private void OnSelectedTextElementCreated(IItemElement element)
		{
			TextElement obj = element as TextElement;
			obj.ValueText.enableAutoSizing = true;
			obj.ValueText.fontSizeMax = 16f;
			obj.ValueText.fontSizeMin = 10f;
			obj.ValueText.overflowMode = TextOverflowModes.Truncate;
			obj.ValueText.margin = new Vector4(50f, 0f, 10f, 0f);
			obj.ValueText.rectTransform.offsetMin = new Vector2(0f, -5f);
			obj.ValueText.rectTransform.offsetMax = new Vector2(0f, 5f);
			obj.LabelText.enableAutoSizing = true;
			obj.LabelText.fontSizeMax = 16f;
			obj.LabelText.fontSizeMin = 10f;
			obj.LabelText.rectTransform.offsetMin = new Vector2(0f, -5f);
			obj.LabelText.rectTransform.offsetMax = new Vector2(0f, 5f);
		}

		private void OnSelectPlayer()
		{
			if (_mapViewInspector.PlayerCraft != null)
			{
				_mapViewInspector.SelectItem(_mapViewInspector.PlayerCraft);
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "The player-controlled craft has been destroyed.  Take control of another craft to continue.";
			}
		}

		private void OnTakeControlClicked()
		{
			if (SelectedCraftNode != null)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = $"Are you sure you want to take control of the craft named '{SelectedCraftNode.Name}'?";
				messageDialogScript.OkayClicked += OnConfirmTakeControlClicked;
			}
		}

		private void OnToggleLockClicked()
		{
			SelectedItem.ToggleLock();
		}

		private void OnToggleSyncCamera()
		{
			_mapView.SyncCameraWithSelectedItem = !_mapView.SyncCameraWithSelectedItem;
			if (_mapView.SyncCameraWithSelectedItem)
			{
				_mapView.SetCameraFocus(_mapView.MapViewInspector.SelectedItem, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			}
		}

		private void OnToggleTargetClicked()
		{
			SelectedItem.ToggleTarget();
		}

		private void OnWarpToNodeClicked()
		{
			NodeNavigator.WarpToNextNode();
		}
	}
}
