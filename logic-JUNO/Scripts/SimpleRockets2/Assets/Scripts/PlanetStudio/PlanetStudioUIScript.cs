using System;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Menu;
using Assets.Scripts.PlanetStudio.Flyouts;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Inspector;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using ModApi.CelestialData;
using ModApi.Input;
using ModApi.PlanetStudio;
using ModApi.Ui;
using ModApi.Ui.Inspector;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio
{
	public class PlanetStudioUIScript : MonoBehaviour, IPlanetStudioUI
	{
		[SerializeField]
		private GameObject _controllerGameObject;

		private PlanetStudioEditMode _editMode;

		[SerializeField]
		private InputHandlerScript _inputHandler;

		[SerializeField]
		private ObjectViewerScript _objectViewer;

		[SerializeField]
		private PlanetStudioScript _planetStudio;

		private IFlyout _selectedFlyout;

		public PlanetStudioUIController Controller { get; private set; }

		public PlanetStudioEditMode EditMode
		{
			get
			{
				return _editMode;
			}
			set
			{
				if (_editMode != value)
				{
					_editMode = value;
					PlanetStudio.CelestialBodyDesigner.GameObject.SetActive(_editMode == PlanetStudioEditMode.CelestialBody);
					PlanetStudio.PlanetarySystemDesigner.GameObject.SetActive(_editMode == PlanetStudioEditMode.PlanetarySystem);
					this.EditModeChanged?.Invoke(this, new EventArgs());
				}
				UndoHistory.Clear();
				UndoHistory.Enabled = _editMode == PlanetStudioEditMode.CelestialBody;
			}
		}

		public ElementBuilder ElementBuilder => Controller.ElementBuilder;

		public IEquirectangularMapView EquirectangularMapView => Controller.EquirectangularMapView;

		public InputHandlerScript InputHandler => _inputHandler;

		public bool IsLoading
		{
			get
			{
				return Controller.IsLoading;
			}
			set
			{
				Controller.IsLoading = value;
			}
		}

		public IPlanetStudio PlanetStudio => _planetStudio;

		public PlanetStudioScript PlanetStudioScript => _planetStudio;

		public IFlyout SelectedFlyout
		{
			get
			{
				return _selectedFlyout;
			}
			set
			{
				if (_selectedFlyout != value)
				{
					IFlyout selectedFlyout = _selectedFlyout;
					_selectedFlyout = value;
					if (selectedFlyout != null && selectedFlyout.IsOpen)
					{
						selectedFlyout.Close();
					}
					if (_selectedFlyout != null && !_selectedFlyout.IsOpen)
					{
						_selectedFlyout.Open();
					}
					if (this.SelectedFlyoutChanged != null)
					{
						this.SelectedFlyoutChanged(_selectedFlyout);
					}
				}
			}
		}

		public RectTransform Transform { get; private set; }

		public UndoHistory<UndoStep> UndoHistory { get; private set; } = new UndoHistory<UndoStep>(100);

		public bool Visible
		{
			get
			{
				return Controller.gameObject.activeInHierarchy;
			}
			set
			{
				if (EditMode == PlanetStudioEditMode.PlanetarySystem)
				{
					PlanetStudio.PlanetarySystemDesigner.UIVisible = value;
				}
				Game.Instance.UserInterface.InspectorPanelsVisible = value;
				Controller.gameObject.SetActive(value);
			}
		}

		public event EventHandler<EventArgs> EditModeChanged;

		public event FlyoutDelegate SelectedFlyoutChanged;

		public IListView CreateListView(IListViewModel viewModel)
		{
			IListView listView = Game.Instance.UserInterface.CreateListView(viewModel, _objectViewer);
			_objectViewer.Show(listView.PreviewEnabled);
			Visible = false;
			(listView as IDialog).Closed += delegate
			{
				Visible = true;
				_objectViewer.Show(show: false);
				if (EditMode == PlanetStudioEditMode.CelestialBody)
				{
					PlanetStudio.CelestialBodyDesigner?.RefreshQuadSphereRenderer();
				}
			};
			return listView;
		}

		public void CreateTexturePicker(TexturePickerLibrary texturePickerLibrary, Action<SupportFileData, string> onComplete)
		{
			CelestialBodyFileData celestialBody = PlanetStudio.CelestialBodyDesigner?.CurrentCelestialBody?.FileData;
			if (texturePickerLibrary == null)
			{
				texturePickerLibrary = new TexturePickerLibrary(celestialBody);
			}
			PhotoLibraryDialogScript.Create(Transform, texturePickerLibrary).OnPhotoSelected = delegate(PhotoLibraryDialogScript d, PhotoItemModel m)
			{
				TexturePickerLibrary.TexturePhotoData texturePhotoData = m.Photo as TexturePickerLibrary.TexturePhotoData;
				onComplete(texturePhotoData?.SupportFile, texturePhotoData?.Path);
				d.Close();
			};
		}

		public void CreateUndoStep(string ignoreKey = null, string description = null)
		{
			if (UndoHistory.ShouldPushUndo(ignoreKey))
			{
				CreateUndoStep(ignoreKey, head: false, description);
			}
		}

		public T GetFlyout<T>() where T : PlanetStudioFlyoutScript
		{
			return Controller.Flyouts.Where((PlanetStudioFlyoutScript x) => x is T).FirstOrDefault() as T;
		}

		public void MarkDirty()
		{
			if (_editMode == PlanetStudioEditMode.CelestialBody)
			{
				_planetStudio.CelestialBodyDesignerScript.RaiseCelestialBodyModifiedEvent();
			}
			else if (_editMode == PlanetStudioEditMode.PlanetarySystem)
			{
				_planetStudio.PlanetarySystemDesignerScript.RaisePlanetarySystemModifiedEvent();
			}
		}

		public void PrepareInspectorModel(InspectorModel model, Action<string, string> createUndoStepOverride = null)
		{
			foreach (GroupModel group in model.Groups)
			{
				ProcessInspectorGroup(group, model.Title, createUndoStepOverride);
			}
		}

		public void Redo()
		{
			UndoStep nextRedoStep = UndoHistory.GetNextRedoStep();
			if (nextRedoStep != null)
			{
				RestoreFromUndoStep(nextRedoStep);
			}
		}

		public void ShowMessage(string message, float time = 7f)
		{
			Controller.ShowMessage(message, time);
		}

		public void Undo()
		{
			if (!UndoHistory.RedoStepsAvailable)
			{
				CreateUndoStep(null, head: true, null);
			}
			UndoStep nextUndoStep = UndoHistory.GetNextUndoStep();
			if (nextUndoStep != null)
			{
				RestoreFromUndoStep(nextUndoStep);
			}
		}

		public void Undo(UndoStep undoStep)
		{
			RestoreFromUndoStep(undoStep);
			UndoHistory.CurrentUndoStep = undoStep;
		}

		protected virtual void Awake()
		{
			Transform = GetComponent<RectTransform>();
			XmlLayout xmlLayout = _controllerGameObject.AddComponent<XmlLayout>();
			Controller = _controllerGameObject.AddComponent<PlanetStudioUIController>();
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/PlanetStudio/PlanetStudioUI", xmlLayout);
			Controller.InitializeUI(this);
		}

		protected virtual void Start()
		{
			_inputHandler.AddInputResponder(_planetStudio.CelestialBodyDesignerScript.InputResponder);
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.AnyDialogsOpen || Game.Instance.UserInterface.IsTextInputFocused)
			{
				return;
			}
			IGameInputs inputs = Game.Instance.Inputs;
			if (inputs.PlanetStudioOpenMenu.GetButtonDownIfEnabled())
			{
				IFlyout flyout = GetFlyout<MenuFlyoutScript>().Flyout;
				SelectedFlyout = ((SelectedFlyout == flyout) ? null : flyout);
			}
			if (inputs.PlanetStudioRecenterCamera.GetButtonDownIfEnabled())
			{
				if (EditMode == PlanetStudioEditMode.CelestialBody)
				{
					PlanetStudio.CelestialBodyDesigner.CelestialBodyViewer.ResetView();
				}
				else if (EditMode == PlanetStudioEditMode.PlanetarySystem)
				{
					PlanetarySystemDesignerScript.Instance.MapViewManager.MapView.MapCameraScript.RecenterOnTarget();
				}
			}
			if (inputs.Undo.GetButtonDownIfEnabled() && UndoHistory.UndoStepsAvailable)
			{
				Undo();
			}
			else if (inputs.Redo.GetButtonDownIfEnabled() && UndoHistory.RedoStepsAvailable)
			{
				Redo();
			}
		}

		private void CreateUndoStep(string ignoreKey, bool head, string description)
		{
			XElement xElement = SaveXmlForUndo();
			if (xElement != null)
			{
				UndoStep undoStep = new UndoStep(xElement, description, DateTime.Now);
				undoStep.IsHead = head;
				UndoHistory.PushUndo(undoStep, ignoreKey);
			}
		}

		private void OnInspectorModelChanged(ItemModel model, string description, bool finished, Action<string, string> createUndoStepOverride)
		{
			if (finished)
			{
				if (createUndoStepOverride != null)
				{
					createUndoStepOverride(model.GetHashCode().ToString(), description);
				}
				else
				{
					CreateUndoStep(model.GetHashCode().ToString(), description);
				}
			}
			MarkDirty();
		}

		private void ProcessInspectorGroup(IGroupModel group, string description, Action<string, string> createUndoStepOverride)
		{
			foreach (ItemModel item in group.Items)
			{
				if (item is IGroupModel groupModel)
				{
					string text = description;
					if (!string.IsNullOrEmpty(groupModel.Name))
					{
						text = text + "/" + groupModel.Name;
					}
					ProcessInspectorGroup(groupModel, text, createUndoStepOverride);
				}
				else if (item is IValueChanged valueChanged)
				{
					valueChanged.ValueChangedByUserInput += delegate(ItemModel model, string name, bool finished)
					{
						OnInspectorModelChanged(model, description + ": " + name, finished, createUndoStepOverride);
					};
				}
			}
		}

		private void RestoreFromUndoStep(UndoStep step)
		{
			if (EditMode == PlanetStudioEditMode.CelestialBody)
			{
				CelestialBodyDesignerScript celestialBodyDesignerScript = PlanetStudioScript.CelestialBodyDesignerScript;
				celestialBodyDesignerScript.LoadCelestialBodyFromXml(step.Xml, celestialBodyDesignerScript.CurrentCelestialBody.File);
				OperationResult operationResult = celestialBodyDesignerScript.ViewCelestialBody(cleanGeneratedData: false, false);
				if (!operationResult.IsSuccess)
				{
					operationResult.Log();
					Game.Instance.UserInterface.CreateErrorDialog("Unable to restore from undo step: " + operationResult.ErrorMessage);
				}
			}
			else
			{
				Debug.LogError("Redo not implemented.");
			}
		}

		private XElement SaveXmlForUndo()
		{
			if (EditMode == PlanetStudioEditMode.CelestialBody)
			{
				return PlanetStudioScript.Instance.CelestialBodyDesignerScript.SaveXml(useFilePaths: true)?.Root;
			}
			return null;
		}
	}
}
