using System;
using System.Collections;
using System.Diagnostics;
using Assets.Scripts.Analysis.Analytics;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Demo;
using Assets.Scripts.Design.Events;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.UI.Input;
using Assets.Scripts.Design.UI.Variables;
using Assets.Scripts.Flight;
using Assets.Scripts.Input;
using Assets.Scripts.Scenes;
using Assets.Scripts.Scenes.Startup;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Sharing;
using Jundroo.Common.Events;
using Jundroo.Common.Platform;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Design.UI
{
	public class DesignerUIScript : MonoBehaviour, IScreenshotDialogHandler
	{
		private static bool _cuttingOutlinesVisible;

		private static bool _decalOutlinesVisible;

		private ButtonWidget _buttonDesignerSymmetry;

		private Widget _buttonDoneEditing;

		private Widget _buttonGhostView;

		private Widget _buttonOrtho;

		private Widget _buttonPartProperties;

		private ButtonWidget _buttonPartSymmetry;

		private Widget _buttonPowertrainView;

		private Widget _buttonRedo;

		private Widget _buttonSelectedPartOptions;

		private Widget _buttonUndo;

		private WidgetContext _context;

		private DesignerFlyouts _flyouts;

		private HideScriptsManager _hiddenScripts;

		private Widget _mainUI;

		private TextWidget _massText;

		private Widget _panelPartOptions;

		private Widget _panelSymmetry;

		private Widget _panelUndo;

		[SerializeField]
		private DesignerScreenInputScript _screenInput;

		private Widget _selectedPanel;

		private StatusMessageScript _statusMessage;

		public bool CuttingOutlinesVisible
		{
			get
			{
				return _cuttingOutlinesVisible;
			}
			set
			{
				if (_cuttingOutlinesVisible != value)
				{
					_cuttingOutlinesVisible = value;
					UpdateToggleCuttingOutlinesButton();
					this.CuttingOutlinesVisibleChanged?.Invoke(value);
				}
			}
		}

		public bool DecalOutlinesVisible
		{
			get
			{
				return _decalOutlinesVisible;
			}
			set
			{
				if (_decalOutlinesVisible != value)
				{
					_decalOutlinesVisible = value;
					UpdateToggleDecalOutlinesButton();
				}
			}
		}

		public DesignerScript DesignerScript { get; private set; }

		public DropZones DropZones { get; private set; }

		public FingerTool FingerTool { get; private set; }

		public IDesignerFlyouts Flyouts => _flyouts;

		public bool InEditingState => _buttonDoneEditing.Visible;

		public bool IsPartOptionsPanelOpened => _selectedPanel == _panelPartOptions;

		public bool IsViewPanelOpen => SelectedPanel?.Id == "panel-view";

		public Widget RootWidget => _context.Root;

		Camera IScreenshotDialogHandler.SceneCamera => DesignerScript.Designer.CameraController.Camera;

		public DesignerScreenInputScript ScreenInput => _screenInput;

		public Widget SelectedPanel
		{
			get
			{
				return _selectedPanel;
			}
			set
			{
				if (_selectedPanel != value)
				{
					if (_selectedPanel != null)
					{
						_selectedPanel.Hide();
					}
					_selectedPanel = value;
					if (_selectedPanel != null)
					{
						_selectedPanel.Show();
					}
				}
			}
		}

		public bool Visible
		{
			get
			{
				return _context.Root.Visible;
			}
			set
			{
				_context.Root.Visible = value;
			}
		}

		public event Action<bool> CuttingOutlinesVisibleChanged;

		public event SimpleNotificationDelegate DoneEditingButtonClicked;

		public event EventHandler<EventArgs> Initialized;

		public event SimpleNotificationDelegate SideViewButtonClicked;

		public event SimpleNotificationDelegate UndoRedoComplete;

		public static void TutorialCenterViewOnPart(PartScript part)
		{
			Camera main = Camera.main;
			MoveObjectScript component = main.GetComponent<MoveObjectScript>();
			if (!component.ObjectIsPanning)
			{
				component.ResetPanning();
				component.DestinationPanPosition = part.transform.position + new Vector3(6f, 3f, 3f);
				component.PanningFocus = part.transform.position;
				component.IsPanningFocusACameraTarget = true;
				component.CameraTarget = main.transform.parent;
				component.TimeToFinishPanning = 0.65f;
			}
		}

		public void AppendMessage(string message, float time = 7f, bool animate = true)
		{
			_statusMessage.AppendMessage(message, time, animate);
		}

		public void ClearConcealedPartsList()
		{
			DesignerScript.ClearPartConcealment();
			ShowMessage("Hidden parts list cleared");
		}

		public void CycleConcealmentType()
		{
			string text = string.Empty;
			switch (DesignerScript.PartConcealment)
			{
			case DesignerScript.PartConcealmentType.Hidden:
				DesignerScript.PartConcealment = DesignerScript.PartConcealmentType.None;
				text = "None";
				break;
			case DesignerScript.PartConcealmentType.Invisible:
				DesignerScript.PartConcealment = DesignerScript.PartConcealmentType.Hidden;
				text = "X-Ray (interactable)";
				break;
			case DesignerScript.PartConcealmentType.None:
				DesignerScript.PartConcealment = DesignerScript.PartConcealmentType.Invisible;
				text = "Invisible (non-interactable)";
				break;
			}
			ShowMessage("Part concealment set to: " + text);
		}

		public void ExitDesigner()
		{
			if (DesignerScript.TutorialRunning)
			{
				DesignerScript.Tutorial.EndTutorial();
			}
			UnityAnalytics.SceneExited(designer: true);
			DesignerScript.SaveDesignerCraft();
			SceneManager sceneManager = Game.Instance.SceneManager;
			if (sceneManager.InFlightScene)
			{
				sceneManager.EndLevelReturnScene = null;
				FlightSceneScript.Instance.ExitLevel();
			}
			else
			{
				sceneManager.LoadMenu();
			}
		}

		public void HideMainUI(bool hide, bool hideWithVisibility = false)
		{
			if (hide)
			{
				_mainUI.AddClass("main-ui-hidden");
				if (hideWithVisibility)
				{
					_mainUI.Visible = false;
				}
			}
			else if (!InEditingState)
			{
				_mainUI.RemoveClass("main-ui-hidden");
				_mainUI.Visible = true;
			}
		}

		public void Initialize(DesignerScript designerScript)
		{
			DesignerScript = designerScript;
			designerScript.Designer.CameraController.Camera.GetUniversalAdditionalCameraData().renderPostProcessing = true;
			Stopwatch stopwatch = Stopwatch.StartNew();
			_context = Game.Instance.UserInterface.CreateContext(GetComponent<RectTransform>(), this);
			_context.LoadWidgetFromXml("Xml/Design/Designer", null);
			_context.Root.EventHandler = this;
			_mainUI = _context.Root.FindWidget("main-ui");
			_statusMessage = _context.Root.FindWidget("status-message").GetComponent<StatusMessageScript>();
			_buttonOrtho = RootWidget.FindWidget("button-ortho");
			_buttonGhostView = RootWidget.FindWidget("button-ghost-view");
			_buttonPowertrainView = RootWidget.FindWidget("button-powertrain-view");
			_buttonSelectedPartOptions = RootWidget.FindWidget("button-part-options");
			_buttonPartProperties = RootWidget.FindWidget("button-part-properties");
			_panelPartOptions = RootWidget.FindWidget("panel-part-options");
			_buttonUndo = RootWidget.FindWidget("button-undo");
			_buttonRedo = RootWidget.FindWidget("button-redo");
			_buttonDoneEditing = RootWidget.FindWidget("button-done-editing");
			_massText = RootWidget.FindWidget<TextWidget>("mass-text");
			_panelUndo = RootWidget.FindWidget("panel-undo");
			_panelSymmetry = RootWidget.FindWidget("panel-symmetry");
			_buttonDesignerSymmetry = RootWidget.FindWidget<ButtonWidget>("btn-designer-symmetry");
			_buttonPartSymmetry = RootWidget.FindWidget<ButtonWidget>("btn-part-symmetry");
			UnityEngine.Debug.Log($"Time: {stopwatch.ElapsedMilliseconds:n0}ms");
			_flyouts = new DesignerFlyouts(this, _context.Root);
			_flyouts.SelectedFlyoutChanged += OnSelectedFlyoutChanged;
			ScreenInput.InputHandler = designerScript.Designer;
			DropZones = new DropZones(this);
			FingerTool = new FingerTool(_context.Root.FindWidget("finger-tool"), DesignerScript, ScreenInput);
			DesignerScript.Designer.PartDeleted += OnPartDeleted;
			_screenInput.Initialize(this);
			UpdateToggleDecalOutlinesButton();
			UpdateToggleCuttingOutlinesButton();
			if (!DesignerScript.TutorialRunning)
			{
				DesignerTips.ShowDesignerTip(this);
			}
			this.Initialized?.Invoke(this, EventArgs.Empty);
			designerScript.Designer.Tools.SelectedToolChanged += OnDesignerToolChanged;
			UpdateSelectedToolUI();
			designerScript.Designer.SelectedPartChangedEvent += OnSelectedPartChanged;
			OnSelectedPartChanged(null);
			designerScript.Designer.Symmetry.SymmetryDisabledForNewPartsChanged += OnSymmetryDisabledForNewPartsChanged;
			UpdatePartSymmetryButtons();
		}

		public void InvertConcealedParts()
		{
			ShowMessage("Inverting hidden parts");
			DesignerScript.InvertPartConcealmentSelection();
		}

		void IScreenshotDialogHandler.OnScreenshotDialogActivated(bool activated)
		{
			if (activated)
			{
				DesignerScript.Designer.SelectedPart = null;
				DesignerScript.Designer.Tools.SelectedTool.AllowPartSelection = false;
				_hiddenScripts = HideScriptsManager.HideForScreenshot(DesignerScript.Designer.Aircraft.transform);
			}
			else
			{
				DesignerScript.Designer.Tools.SelectedTool.AllowPartSelection = true;
				_hiddenScripts?.Restore();
				_hiddenScripts = null;
			}
		}

		public void SetAircraftInformationDisplay(string text)
		{
			if (_massText != null)
			{
				_massText.Text = text;
			}
		}

		public void SetEditingState(bool editing)
		{
			if (editing)
			{
				_buttonDoneEditing.Visible = true;
				HideMainUI(hide: true, hideWithVisibility: true);
			}
			else
			{
				_buttonDoneEditing.Visible = false;
				HideMainUI(hide: false, hideWithVisibility: true);
			}
		}

		void IScreenshotDialogHandler.SetSceneUIVisibility(bool visible)
		{
			Visible = visible;
		}

		void IScreenshotDialogHandler.ShowMessage(string message, float time)
		{
			ShowMessage(message, time, animate: false);
		}

		public void ShowMessage(string message, float time = 7f, bool animate = true)
		{
			_statusMessage.ShowMessage(message, time, animate);
		}

		public void StartFlight()
		{
			if (DesignerScript.EnsureTutorialIsNotRunning())
			{
				UnityAnalytics.SceneExited(designer: true);
				if (Flyouts.Selected == Flyouts.LoadCraft)
				{
					Flyouts.Selected.Close();
				}
				DesignerScript.Designer.Tools.SelectMovePartTool();
				DesignerScript.Designer.StartFlight();
			}
		}

		public void ToggleCenterOfIndicators()
		{
			bool visible = DesignerScript.ToggleCenterOfMassGizmo();
			DesignerScript.ToggleCenterOfLiftGizmo();
			DesignerScript.ToggleCenterOfThrustGizmo();
			_context.Root.FindWidget("CenterWidgetKey").Visible = visible;
		}

		public void TogglePartProperties()
		{
			if (Designer.Instance.SelectedPart != null)
			{
				Flyouts.Selected = Flyouts.PartProperties;
			}
		}

		public void UpdateDesignerViewButtons()
		{
			_buttonGhostView.EnableClass("btn-primary", DesignerScript.Designer.ViewMode == DesignerViewMode.Ghost);
			_buttonPowertrainView.EnableClass("btn-primary", DesignerScript.Designer.ViewMode == DesignerViewMode.Powertrain);
		}

		public void UpdateOrthographicButton()
		{
			_buttonOrtho.EnableClass("btn-primary", DesignerScript.Designer.CameraController.IsOrthographic);
		}

		public void UpdatePartSymmetryButtons()
		{
			PartScript selectedPart = DesignerScript.SelectedPart;
			_buttonDesignerSymmetry.EnableClass("btn-primary", !DesignerScript.Designer.Symmetry.SymmetryDisabledForNewParts);
			_buttonPartSymmetry.SetVisible(selectedPart != null);
			_buttonPartSymmetry.EnableClass("btn-primary", !(selectedPart?.Part.SymmetryDisabled ?? false));
			_buttonDesignerSymmetry.SetVisible(selectedPart == null);
			_buttonPartSymmetry.SetVisible(selectedPart != null);
		}

		protected virtual void LateUpdate()
		{
			_context?.LateUpdate();
		}

		protected virtual void Update()
		{
			if (!(DesignerScript == null))
			{
				HandleKeyboardShortcuts();
				_buttonUndo.Visible = Designer.Instance.UndoHistory.UndoStepsAvailable;
				_buttonRedo.Visible = Designer.Instance.UndoHistory.RedoStepsAvailable;
				bool flag = DesignerScript.SelectedPart != null;
				_buttonPartProperties.Visible = flag;
				_buttonSelectedPartOptions.Visible = flag;
				if (!flag && SelectedPanel == _panelPartOptions)
				{
					SelectedPanel = null;
				}
				if (!flag && Flyouts.Selected == Flyouts.TransformPart)
				{
					Flyouts.Selected = null;
				}
			}
		}

		private void CloseSelectedPanel()
		{
			SelectedPanel = null;
		}

		private void ConcealSelectedPart()
		{
			if (DesignerScript.SelectedPart != null)
			{
				if (DesignerScript.PartConcealment == DesignerScript.PartConcealmentType.None)
				{
					DesignerScript.PartConcealment = DesignerScript.PartConcealmentType.Invisible;
				}
				DesignerScript.AddPartToConcealedCollection(DesignerScript.SelectedPart);
				DesignerScript.Designer.CreateUndoStepForSelectedPart("hidden", "HidePart");
				ShowMessage("Part hidden");
				DesignerScript.Designer.SelectedPart = null;
			}
		}

		private void HandleKeyboardShortcuts()
		{
			if (SimplePlanesDevConsoleScript.IsConsoleOpen || !Game.Instance.UserInterface.AllowKeyboardInputs)
			{
				return;
			}
			GameInputs instance = GameInputs.Instance;
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				if (InEditingState)
				{
					OnDoneEditingButtonClicked(null);
				}
				else if (Flyouts.Selected != null)
				{
					Flyouts.Selected = null;
				}
				else
				{
					Flyouts.Selected = Flyouts.Menu;
				}
			}
			if (instance.DesignerToggleMenu.GetButtonDownIfEnabled())
			{
				Flyouts.ToggleFlyout(Flyouts.Menu);
			}
			Designer designer = DesignerScript.Designer;
			if (instance.RotateTool.GetButtonDownIfEnabled())
			{
				designer.Tools.SelectTool(designer.Tools.RotateTool);
				ShowMessage("Selected Rotate Part Tool");
			}
			if (instance.TranslateTool.GetButtonDownIfEnabled())
			{
				designer.Tools.SelectTool(designer.Tools.TranslateTool);
				ShowMessage("Selected Translate Part Tool");
			}
			if (instance.MoveTool.GetButtonDownIfEnabled())
			{
				designer.Tools.SelectTool(designer.Tools.MovePartTool);
				ShowMessage("Selected Move Part Tool");
			}
			if (instance.ViewTool.GetButtonDownIfEnabled())
			{
				designer.Tools.SelectTool(designer.Tools.ViewTool);
				ShowMessage("Selected View Tool");
			}
			if (instance.LoadClipboardAircraft.GetButtonDownIfEnabled())
			{
				DesignerScript.LoadAircraftFromClipboardOrUrl();
			}
			if (instance.DeletePart.GetButtonDownIfEnabled())
			{
				designer.DeleteSelectedParts();
			}
			if (instance.SaveAircraft.GetButtonDownIfEnabled())
			{
				DesignerScript.SaveAircraft();
			}
			if (instance.Redo.GetButtonDownIfEnabled())
			{
				Redo();
			}
			if (instance.Undo.GetButtonDownIfEnabled())
			{
				Undo();
			}
			if (instance.ToggleCenterBalls.GetButtonDownIfEnabled())
			{
				ToggleCenterOfIndicators();
			}
			if (instance.ConcealPart.GetButtonDownIfEnabled())
			{
				ConcealSelectedPart();
			}
			if (instance.InvertConcealedParts.GetButtonDownIfEnabled())
			{
				InvertConcealedParts();
			}
			if (instance.CycleConcealmentType.GetButtonDownIfEnabled())
			{
				CycleConcealmentType();
			}
			if (instance.ClearConcealedPartsList.GetButtonDownIfEnabled())
			{
				ClearConcealedPartsList();
			}
		}

		private void OnCenterButtonClicked(Widget widget)
		{
			CloseSelectedPanel();
			if (DesignerScript.SelectedPart != null)
			{
				Designer.CenterViewOnPart(DesignerScript.SelectedPart);
			}
		}

		private void OnConcealButtonClicked(Widget widget)
		{
			ConcealSelectedPart();
		}

		private void OnConcealInvertButtonClicked(Widget widget)
		{
			InvertConcealedParts();
		}

		private void OnCycleConcealButtonClicked(Widget widget)
		{
			CycleConcealmentType();
		}

		private void OnDesignerSymmetryButtonClicked(Widget widget)
		{
			DesignerScript.ToggleNewPartSymmetryState();
		}

		private void OnDesignerToolChanged(object sender, ToolChangedEventArgs e)
		{
			UpdateSelectedToolUI();
		}

		private void OnDoneEditingButtonClicked(Widget widget)
		{
			this.DoneEditingButtonClicked?.Invoke();
		}

		private void OnFlyoutButtonClicked(Widget widget)
		{
			Flyouts.ToggleFlyout(Flyouts.FindById(widget.Data));
		}

		private void OnOrthoButtonClicked(Widget widget)
		{
			DesignerScript.Designer.CameraController.IsOrthographic = !DesignerScript.Designer.CameraController.IsOrthographic;
			UpdateOrthographicButton();
		}

		private void OnPanelButtonClicked(Widget widget)
		{
			Widget widget2 = RootWidget.FindWidget(widget.Data);
			if (widget2 != null)
			{
				if (SelectedPanel != widget2)
				{
					SelectedPanel = widget2;
				}
				else
				{
					SelectedPanel = null;
				}
			}
		}

		private void OnPartDeleted(object sender, PartDeletedEventArgs e)
		{
			if (FingerTool.Enabled && DesignerScript.SelectedPart == e.Part)
			{
				FingerTool.Position = Vector3.zero;
			}
		}

		private void OnPartSymmetryButtonClicked(Widget widget)
		{
			bool includeConnectedParts = !Game.Inputs.DesignerSinglePartModifier.GetButtonIfEnabled();
			DesignerScript.TogglePartSymmetryForSelectedPart(includeConnectedParts);
			UpdatePartSymmetryButtons();
		}

		private void OnPlayButtonClicked(Widget widget)
		{
			StartFlight();
		}

		private void OnPowertrainButtonClicked(Widget widget)
		{
			if (DesignerScript.Designer.ViewMode == DesignerViewMode.Powertrain)
			{
				ShowMessage("Disabled Powertrain View");
				DesignerScript.Designer.ViewMode = DesignerViewMode.Normal;
			}
			else
			{
				ShowMessage("Enabled Powertrain View");
				DesignerScript.Designer.ViewMode = DesignerViewMode.Powertrain;
			}
			UpdateDesignerViewButtons();
		}

		private void OnRedoButtonClicked(Widget widget)
		{
			Redo();
		}

		private void OnRotateXButtonClicked(Widget widget)
		{
			DesignerScript.RotatePartOnAxis(Vector3.right, 90);
		}

		private void OnRotateYButtonClicked(Widget widget)
		{
			DesignerScript.RotatePartOnAxis(Vector3.up, 90);
		}

		private void OnRotateZButtonClicked(Widget widget)
		{
			DesignerScript.RotatePartOnAxis(Vector3.forward, -90);
		}

		private void OnSearchPartsButtonClicked(Widget widget)
		{
			Flyouts.ToggleFlyout(Flyouts.SearchParts);
		}

		private void OnSelectedFlyoutChanged(IFlyout flyout)
		{
			_panelUndo.RemoveClass("flyout-nudged");
			if (flyout != null)
			{
				_panelUndo.Stylesheet.GetStyle("flyout-nudged").Attributes["position"] = $"{(int)flyout.Width + 20} 10:OutBack 0.25";
				_panelUndo.AddClass("flyout-nudged");
			}
		}

		private void OnSelectedPartChanged(PartScript part)
		{
			UpdatePartSymmetryButtons();
		}

		private void OnShowAllButtonClicked(Widget widget)
		{
			ClearConcealedPartsList();
		}

		private void OnSymmetryDisabledForNewPartsChanged(object sender, EventArgs e)
		{
			UpdatePartSymmetryButtons();
		}

		private void OnToggleCuttingOutlinesClicked(Widget widget)
		{
			CuttingOutlinesVisible = !CuttingOutlinesVisible;
		}

		private void OnToggleDecalOutlinesClicked(Widget widget)
		{
			DecalOutlinesVisible = !DecalOutlinesVisible;
		}

		private void OnToolButtonClicked(Widget widget)
		{
			switch (widget.Data)
			{
			case "tool-translate":
				DesignerScript.Designer.Tools.SelectTool(DesignerScript.Designer.Tools.TranslateTool);
				break;
			case "tool-rotate":
				DesignerScript.Designer.Tools.SelectTool(DesignerScript.Designer.Tools.RotateTool);
				break;
			case "tool-view":
				DesignerScript.Designer.Tools.SelectTool(DesignerScript.Designer.Tools.ViewTool);
				break;
			case "tool-paint":
				Flyouts.ToggleFlyout(Flyouts.Paint);
				break;
			default:
				if (Device.IsDemoBuild)
				{
					Game.Instance.UserInterface.CreateMessageDialog(DemoMessages.ToolNotAvailable((DesignerTools x) => x.MovePartTool), "Not Available In Demo");
					DesignerScript.Designer.Tools.SelectTool(DesignerScript.Designer.Tools.ViewTool);
				}
				else
				{
					DesignerScript.Designer.Tools.SelectMovePartTool();
				}
				break;
			}
			SelectedPanel = null;
		}

		private void OnUndoButtonClicked(Widget widget)
		{
			Undo();
		}

		private void OnVariableOutputsButtonClicked(Widget widget)
		{
			if (Device.IsDemoBuild)
			{
				Game.Instance.UserInterface.CreateMessageDialog("The variable outputs dialog is not available in the demo version of the game.", "Not Available In Demo");
			}
			else if (DesignerScript.EnsureTutorialIsNotRunning())
			{
				Game.Instance.UserInterface.CreateDialog<VariableOutputsDialogScript>("Xml/Design/VariableOutputsDialog").Initialize(DesignerScript.SelectedPart);
			}
		}

		private void OnViewFrontButtonClicked(Widget widget)
		{
			CloseSelectedPanel();
			Bounds bounds = DesignerScript.Aircraft.CalculateBounds(includeDisconnectedParts: false);
			float num = 10f;
			Vector3 vector = bounds.center + Vector3.forward * (bounds.max.x * 1.5f);
			if (vector.z < num)
			{
				vector.z = num;
			}
			Vector3 value = bounds.center + Vector3.forward * (bounds.min.x * 1.5f);
			if (value.z > 0f - num)
			{
				value.z = 0f - num;
			}
			Camera main = Camera.main;
			MoveObjectScript component = Camera.main.GetComponent<MoveObjectScript>();
			component.ResetPanning();
			component.DestinationPanUp = Vector3.up;
			component.PanningFocus = bounds.center;
			component.TimeToFinishPanning = 1f;
			component.IsPanningFocusACameraTarget = true;
			component.CameraTarget = main.transform.parent;
			if (Utilities.CompareVector3s(main.transform.position, vector, 0.1f))
			{
				component.DestinationPanPosition = value;
			}
			else
			{
				component.DestinationPanPosition = vector;
			}
		}

		private void OnViewSideButtonClicked(Widget widget)
		{
			CloseSelectedPanel();
			Bounds bounds = DesignerScript.Aircraft.CalculateBounds(includeDisconnectedParts: false);
			float num = 10f;
			Vector3 vector = bounds.center + Vector3.right * bounds.max.x;
			if (vector.x < num)
			{
				vector.x = num;
			}
			Vector3 value = bounds.center + Vector3.right * bounds.min.x;
			if (value.x > 0f - num)
			{
				value.x = 0f - num;
			}
			Camera main = Camera.main;
			MoveObjectScript component = Camera.main.GetComponent<MoveObjectScript>();
			component.ResetPanning();
			component.DestinationPanUp = Vector3.up;
			component.PanningFocus = bounds.center;
			component.TimeToFinishPanning = 1f;
			component.IsPanningFocusACameraTarget = true;
			component.CameraTarget = main.transform.parent;
			if (Utilities.CompareVector3s(main.transform.position, vector, 0.1f))
			{
				component.DestinationPanPosition = value;
			}
			else
			{
				component.DestinationPanPosition = vector;
			}
			if (this.SideViewButtonClicked != null)
			{
				this.SideViewButtonClicked();
			}
		}

		private void OnViewTopButtonClicked(Widget widget)
		{
			CloseSelectedPanel();
			Bounds bounds = DesignerScript.Aircraft.CalculateBounds(includeDisconnectedParts: false);
			_ = bounds.extents / Mathf.Tan(MathF.PI / 180f * (Camera.main.fieldOfView / 2f)) / 2f;
			Vector3 value = bounds.center + new Vector3(0f, Mathf.Abs(bounds.max.z - bounds.min.z), 0f);
			Camera main = Camera.main;
			MoveObjectScript component = main.GetComponent<MoveObjectScript>();
			component.ResetPanning();
			component.DestinationPanPosition = value;
			component.DestinationPanUp = Vector3.forward;
			component.PanningFocus = bounds.center;
			component.TimeToFinishPanning = 1f;
			component.IsPanningFocusACameraTarget = true;
			component.CameraTarget = main.transform.parent;
		}

		private void OnXrayButtonClicked(Widget widget)
		{
			if (DesignerScript.Designer.ViewMode == DesignerViewMode.Ghost)
			{
				ShowMessage("Disabled Ghost View");
				DesignerScript.Designer.ViewMode = DesignerViewMode.Normal;
			}
			else
			{
				ShowMessage("Enabled Ghost View");
				DesignerScript.Designer.ViewMode = DesignerViewMode.Ghost;
			}
			UpdateDesignerViewButtons();
		}

		private void OnZoomInButtonClicked(Widget widget)
		{
			Camera.main.transform.position += Camera.main.transform.forward * 1.5f;
		}

		private void OnZoomOutButtonClicked(Widget widget)
		{
			Camera.main.transform.position += Camera.main.transform.forward * -1.5f;
		}

		private void Redo()
		{
			if (DesignerScript.EnsureTutorialIsNotRunning())
			{
				if (Designer.Instance.UndoHistory.RedoStepsAvailable)
				{
					DesignerScript.EndPartMovement();
					ShowMessage("Re-doing step...");
					StartCoroutine(RedoStep());
				}
				else
				{
					ShowMessage("Nothing left to redo");
				}
			}
		}

		private IEnumerator RedoStep()
		{
			yield return null;
			Designer.Instance.Redo();
			ShowMessage("Redo complete");
		}

		private void Undo()
		{
			if (DesignerScript.EnsureTutorialIsNotRunning())
			{
				if (Designer.Instance.UndoHistory.UndoStepsAvailable)
				{
					DesignerScript.EndPartMovement();
					ShowMessage("Undoing last step...");
					StartCoroutine(UndoStep());
				}
				else
				{
					ShowMessage("Nothing left to undo.");
				}
			}
		}

		private IEnumerator UndoStep()
		{
			yield return null;
			Designer.Instance.Undo();
			this.UndoRedoComplete?.Invoke();
			ShowMessage("Undo complete");
		}

		private void UpdateSelectedToolUI()
		{
			string text = "tool-move";
			DesignerTools tools = DesignerScript.Designer.Tools;
			if (tools.SelectedTool == tools.TranslateTool)
			{
				text = "tool-translate";
			}
			else if (tools.SelectedTool == tools.RotateTool)
			{
				text = "tool-rotate";
			}
			else if (tools.SelectedTool == tools.JWingTool)
			{
				text = "tool-wing";
			}
			else if (tools.SelectedTool == tools.FuselageTool)
			{
				text = "tool-fuselage";
			}
			else if (tools.SelectedTool == tools.ViewTool)
			{
				text = "tool-view";
			}
			else if (tools.SelectedTool == tools.ColorTool)
			{
				text = "tool-paint";
			}
			else if (tools.SelectedTool == tools.TrapezoidShapeTool)
			{
				text = "tool-trapezoid-shape";
			}
			foreach (Widget item in RootWidget.FindWidgetsByClass("tool-button"))
			{
				item.EnableClass("btn-primary", item.Data == text);
			}
			foreach (Widget item2 in RootWidget.FindWidgetsByClass("tool-panel"))
			{
				if (item2.Data == text)
				{
					item2.Show(force: true);
				}
				else
				{
					item2.Hide(null, force: true);
				}
			}
			Widget widget = RootWidget.FindWidget("btn-selected-tool");
			widget.EnableClass("tool-icon-move", tools.SelectedTool == tools.MovePartTool);
			widget.EnableClass("tool-icon-translate", tools.SelectedTool == tools.TranslateTool);
			widget.EnableClass("tool-icon-rotate", tools.SelectedTool == tools.RotateTool);
			widget.EnableClass("tool-icon-wing", tools.SelectedTool == tools.JWingTool);
			widget.EnableClass("tool-icon-fuselage", tools.SelectedTool == tools.FuselageTool);
			widget.EnableClass("tool-icon-view", tools.SelectedTool == tools.ViewTool);
			widget.EnableClass("tool-icon-paint", tools.SelectedTool == tools.ColorTool);
		}

		private void UpdateToggleCuttingOutlinesButton()
		{
			_context.Root.FindWidget("toggle-cutting-outlines").EnableClass("btn-primary", CuttingOutlinesVisible);
		}

		private void UpdateToggleDecalOutlinesButton()
		{
			_context.Root.FindWidget("toggle-decal-outlines").EnableClass("btn-primary", DecalOutlinesVisible);
		}
	}
}
