using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Design.PartProperties;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.Tools.Fuselage;
using Assets.Scripts.Design.Tools.Wing;
using Assets.Scripts.Design.Tutorial;
using Assets.Scripts.Design.Tutorial.Career;
using Assets.Scripts.Design.Tutorial.Sandbox;
using Assets.Scripts.Design.Tutorial.Steps;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.Settings;
using Assets.Scripts.State;
using Assets.Scripts.Terrain.Rendering;
using Assets.Scripts.Tools;
using Assets.Scripts.Tools.ObjectTransform;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Settings;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using Assets.Scripts.Ui.Sharing.Screenshot;
using ModApi;
using ModApi.Audio;
using ModApi.Common.Events;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Design.Events;
using ModApi.GameLoop.Interfaces;
using ModApi.Input;
using ModApi.Input.Events;
using ModApi.Scenes.Parameters;
using ModApi.Scripts.State.Validation;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerScript : MonoBehaviour, IDesigner, IInputHandler
	{
		public delegate void ActiveToolChangedDelegate(DesignerTool tool);

		public delegate bool ClickHandler(ClickEventArgs e);

		public delegate void DesignerScriptHandler(DesignerScript source);

		private delegate bool HandleInputDelegate(DesignerTool handleDelegate);

		private enum CameraMovementMode
		{
			Rotation = 0,
			Translation = 1
		}

		public const int PartDragLayerMask = -2147475456;

		public const int PartHighlightLayerMask = -2147475456;

		public const int PartPreventInteractionLayerMask = 1024;

		private CommandPodScript _activeCommandPod;

		private List<DesignerTool> _activeTools = new List<DesignerTool>();

		private List<DesignerTool> _baseTools = new List<DesignerTool>();

		private CameraMovementMode _cameraMovementMode;

		private CameraTool _cameraTool;

		private DesignerTool _capturedTool;

		private ControlSurfaceTool _controlSurfaceTool;

		private CraftScript _craft;

		[SerializeField]
		private Transform _craftContainer;

		private CraftDesigns _craftDesigns;

		private List<IFlyout> _cycleFlyouts;

		private List<DesignerTool> _cyclePartTools;

		[SerializeField]
		private DesignerCameraScript _designerCamera;

		[SerializeField]
		private DesignerPlatformScript _designerPlatform;

		[SerializeField]
		private DesignerUiScript _designerUi;

		[SerializeField]
		private DragCalculatorScript _dragCalculator;

		private QuadSphereRenderer _fakeQuadSphereRenderer;

		private FuselageShapeTool _fuselageShapeTool;

		private FuselageTool _fuselageTool;

		[SerializeField]
		private DesignerGizmosScript _gizmos;

		private IPartScript _highlightedPart;

		private bool _isInitialized;

		[SerializeField]
		private Transform _lights;

		private MirrorCraftTool _mirrorTool;

		private MovePartTool _movePartTool;

		private bool _nonToolHasCapture;

		private NudgePartTool _nudgePartTool;

		private PaintTool _paintTool;

		private PartConnectionsTool _partConnectionsTool;

		private PartManipulationMode _partManipulationMode;

		private PartTypeList _partTypes;

		private CraftPerformanceAnalysis _performanceAnalysis;

		private RotatePartTool _rotatePartTool;

		private ScreenshotTool _screenshotTool;

		private IPartScript _selectedPart;

		private SelectPartTool _selectPartTool;

		private List<DesignerTool> _tools = new List<DesignerTool>();

		private IUserInterface _userInterface;

		private WingAdjustmentTool _wingAdjustmentTool;

		public ICraftConfiguration ActiveCraftConfiguration => _activeCommandPod.Data.CraftConfiguration;

		public bool AdvancedMode { get; set; }

		public bool AllowPartMovement { get; set; } = true;

		public bool AllowPartSelection { get; set; }

		public bool CameraIsMoving { get; private set; }

		public bool CanPinch { get; set; }

		public DesignerTool CapturedTool => _capturedTool;

		public CraftDesigns CraftDesigns => _craftDesigns;

		public DesignerCraftLoader CraftLoader { get; private set; }

		public ICraftScript CraftScript => _craft;

		public IDesignerCamera DesignerCamera => _designerCamera;

		public DesignerControls DesignerControls { get; private set; }

		public DesignerPlatformScript DesignerPlatform => _designerPlatform;

		public IDesignerUi DesignerUi => _designerUi;

		public DesignerUiScript DesignerUiScript => _designerUi;

		public bool DisableCameraMovement { get; set; }

		public bool DisableCameraZoom { get; private set; }

		public FuselageShapeTool FuselageShapeTool => _fuselageShapeTool;

		public FuselageTool FuselageTool => _fuselageTool;

		public IDesignerGameLoop GameLoop { get; private set; }

		public GameObject GameObject => base.gameObject;

		public Camera GizmoCamera { get; private set; }

		public DesignerGizmosScript Gizmos => _gizmos;

		public IPartScript HighlightedPart
		{
			get
			{
				return _highlightedPart;
			}
			set
			{
				if (value != _highlightedPart)
				{
					if (_highlightedPart != null)
					{
						_highlightedPart.PartMaterialScript.IsHighlighted = false;
					}
					_highlightedPart = value;
					if (_highlightedPart != null)
					{
						_highlightedPart.PartMaterialScript.IsHighlighted = true;
					}
				}
			}
		}

		public bool InputEnabled { get; set; } = true;

		public bool IsTutorialRunning { get; private set; }

		public Light[] Lights { get; private set; }

		public float MaxRadius { get; private set; } = 12.5f;

		public MirrorCraftTool MirrorTool => _mirrorTool;

		public DesignerTool MovePartTool => _movePartTool;

		public NudgePartTool NudgePartTool => _nudgePartTool;

		public PaintTool PaintTool => _paintTool;

		public PartConnectionsTool PartConnectionsTool => _partConnectionsTool;

		public PartManipulationMode PartManipulationMode => _partManipulationMode;

		public IPerformanceAnalysis PerformanceAnalysis => _performanceAnalysis;

		public RotatePartTool RotatePartTool => _rotatePartTool;

		public bool SaveOnExit { get; set; } = true;

		public ScreenshotTool ScreenshotTool => _screenshotTool;

		public IPartScript SelectedPart => _selectedPart;

		public ISelectPartTool SelectPartTool => _selectPartTool;

		ISymmetry IDesigner.Symmetry => Symmetry.Instance;

		public ReadOnlyCollection<DesignerTool> Tools { get; private set; }

		public UndoHistory UndoHistory { get; private set; }

		public IUserInterface UserInterface => _userInterface;

		public IGameStateValidator Validator => Game.Instance.GameState.Validator;

		public WingAdjustmentTool WingAdjustmentTool => _wingAdjustmentTool;

		public event ActiveToolChangedDelegate ActiveToolChanged;

		public event SimpleNotificationDelegate BeforeCraftUnloaded;

		public event ClickHandler Click;

		public event SimpleNotificationDelegate CraftLoaded;

		public event SimpleNotificationDelegate CraftStructureChanged;

		public event DesignerScriptHandler Initialized
		{
			add
			{
				if (_isInitialized)
				{
					value(this);
				}
				else
				{
					_initialized += value;
				}
			}
			remove
			{
				_initialized -= value;
			}
		}

		public event EventHandler<DesignerPartAddedEventArgs> PartAdded;

		public event SelectedPartChangedDelegate SelectedPartChanged;

		public event EventHandler<DesignerTutorialStartedEventArgs> TutorialStarted;

		public event EventHandler<DesignerTutorialStepLoadedEventArgs> TutorialStepLoaded;

		private event DesignerScriptHandler _initialized;

		public static void GetPartFromRayCast(Ray ray, int layerMask, out IPartScript partScript, out RaycastHit? raycastHit)
		{
			RaycastHit[] array = (from x in Physics.RaycastAll(ray, 10000f, layerMask)
				orderby x.distance
				select x).ToArray();
			raycastHit = null;
			partScript = null;
			bool flag = false;
			RaycastHit[] array2 = array;
			for (int num = 0; num < array2.Length; num++)
			{
				RaycastHit value = array2[num];
				IPartScript componentInParent = value.collider.transform.GetComponentInParent<IPartScript>();
				if (componentInParent == null || !componentInParent.Data.Config.PartSelectionEnabled)
				{
					continue;
				}
				if (value.collider.transform.TryGetComponent<DepthMaskScript>(out var _))
				{
					flag = true;
					partScript = componentInParent;
					raycastHit = value;
					continue;
				}
				if (flag)
				{
					if (partScript != componentInParent && componentInParent != null && componentInParent.Data.Config.RenderQueue == PartMeshRenderQueue.BeforeDepthMask)
					{
						partScript = componentInParent;
						raycastHit = value;
						break;
					}
					continue;
				}
				partScript = componentInParent;
				raycastHit = value;
				break;
			}
		}

		public void AddPart(DesignerPart designerPart, Vector2 screenPosition)
		{
			List<IPartScript> list = new List<IPartScript>();
			InstantiatePart(designerPart, list);
			if (list.Count == 1)
			{
				IPartScript partScript = list[0];
				partScript.Transform.position -= partScript.Transform.TransformPoint(partScript.Data.Config.CenterOfMass);
			}
			Ray ray = DesignerCamera.ScreenPointToRay(screenPosition);
			float num = Mathf.Clamp(DesignerCamera.CurrentZoom, 0.5f, 150f);
			Vector3 partPosition = ray.origin + ray.direction * num;
			_movePartTool.AddingNewParts(list, partPosition, num);
			SelectPart(list.FirstOrDefault(), null, justAdded: true);
			SetCapturedTool(_movePartTool);
			this.PartAdded?.Invoke(this, new DesignerPartAddedEventArgs(designerPart, null, list));
		}

		public void AddTool<T>(T newTool) where T : DesignerTool
		{
			DesignerTool toolRef = null;
			AddTool(newTool, ref toolRef);
		}

		public void BeginFlight()
		{
			DesignerUi.SelectedFlyout?.Close(immediate: true);
			StartLevel(_craft.Data.Name);
		}

		public void CreateCraftBodyDatas()
		{
			CraftBuilder.CreateBodyDatas(CraftScript);
		}

		public void CreateNewCraft(CrafConfigurationType type, Action<ICraftScript> successCallback = null)
		{
			string craftId;
			switch (type)
			{
			case CrafConfigurationType.Plane:
				craftId = "__new_plane__";
				break;
			case CrafConfigurationType.Rocket:
				craftId = CraftDesigns.NewCraftId;
				break;
			default:
				Debug.LogWarning($"Unknown CrafConfigurationType: {type}, defaulting to rocket");
				craftId = CraftDesigns.NewCraftId;
				break;
			}
			CraftLoader.LoadCraftInteractive(craftId, createUndoStep: true, centerCamera: true, $"New {type}", successCallback, null);
		}

		public void CreateSubassembly(string name, Assembly subassembly)
		{
			DeselectPart();
			_designerUi.Flyouts.PartList.Transform.GetComponentInChildren<PartListPanelScript>().CreateSubassembly(name, subassembly, CraftScript);
		}

		public void CreateUndoStep(string ignoreKey = null)
		{
			if (UndoHistory.ShouldPushUndo(ignoreKey))
			{
				CreateUndoStep(ignoreKey, head: false);
			}
		}

		public void DeleteSelectedParts()
		{
			_movePartTool.DeleteSelectedParts();
		}

		public void DeselectPart()
		{
			SelectPart(null, null, justAdded: false);
		}

		public void DeselectTool(DesignerTool tool)
		{
			DeactivateTool(tool);
		}

		public void DialogSave()
		{
			ModApi.Ui.InputDialogScript inputDialogScript = UserInterface.CreateInputDialog();
			inputDialogScript.InputPlaceholderText = "CRAFT NAME";
			inputDialogScript.MessageText = "SAVE CRAFT";
			inputDialogScript.OkayButtonText = "SAVE";
			inputDialogScript.CancelButtonText = "CANCEL";
			inputDialogScript.MaxLength = 255;
			inputDialogScript.InputText = Utilities.ScrubFileName(CraftScript.Data.Name);
			inputDialogScript.InvalidCharacters.AddRange(Path.GetInvalidFileNameChars());
			inputDialogScript.OkayClicked += OnSaveCraftDialogOkayButtonClicked;
		}

		public void DownloadCraft(string urlId)
		{
			DownloadCraftDialogScript.Create(DesignerUi.Transform, urlId);
		}

		public void Exit(string exitToScene = "Menu")
		{
			PrepareForExit();
			Game.Instance.SceneManager.LoadScene(exitToScene);
		}

		public XElement GenerateCraftXml(bool undoStep, bool optimizeXml)
		{
			if (!undoStep)
			{
				_craft.RecenterTransformOnCoM(updateRotation: false);
				_craft.CalculatePrice();
				_craft.CalculateStartingBounds();
				CraftBuilder.CreateBodyDatas(_craft);
				PartCollisionIgnoreUtility.UpdatePartCollisions(_craft);
				_dragCalculator.CalculateDrag(_craft);
			}
			else
			{
				_craft.Data.Assembly.RemoveAllBodies();
			}
			foreach (PartData part in CraftScript.Data.Assembly.Parts)
			{
				part.Activated = part.PartScript.CommandPod?.GetActivationGroupState(part.ActivationGroup) ?? false;
			}
			ICraftScript craftScript = CraftScript;
			XElement xElement = craftScript.Data.GenerateXml(craftScript.Transform, optimizeXml, !undoStep);
			xElement.Add(Symmetry.GenerateSymmetryXml(craftScript.Data.Assembly));
			return xElement;
		}

		public PartRaycastResult GetPartAtScreenPosition(Vector2 screenPosition)
		{
			PartRaycastResult result = new PartRaycastResult
			{
				Ray = DesignerCamera.ScreenPointToRay(screenPosition)
			};
			GetPartFromRayCast(result.Ray, -2147475456, out var partScript, out var raycastHit);
			if (partScript != null)
			{
				result.PartScript = partScript;
				result.Hit = raycastHit.Value;
			}
			return result;
		}

		public T GetTool<T>() where T : DesignerTool
		{
			foreach (DesignerTool tool in _tools)
			{
				if (tool is T)
				{
					return tool as T;
				}
			}
			return null;
		}

		public void HandleHover(Vector2? hoverPosition)
		{
			if (!AllowPartSelection)
			{
				return;
			}
			if (!hoverPosition.HasValue)
			{
				HighlightedPart = null;
				return;
			}
			Ray ray = DesignerCamera.ScreenPointToRay(hoverPosition.Value);
			IPartScript partScript = null;
			if (!Physics.Raycast(ray, 10000f, 1024))
			{
				GetPartFromRayCast(ray, -2147475456, out partScript, out var _);
			}
			HighlightedPart = partScript;
		}

		public void HandleInput(ClickEventArgs e)
		{
			this.Click?.Invoke(e);
			if (!_nonToolHasCapture)
			{
				HandleToolInput((DesignerTool x) => x.HandleClick(e), e.FingerToolMode != FingerToolMode.None);
			}
		}

		public void HandlePinch(PinchEventArgs e)
		{
			HandleToolInput((DesignerTool x) => x.HandlePinch(e));
		}

		public void HandleScroll(ScrollEventArgs e)
		{
			HandleToolInput((DesignerTool x) => x.HandleScroll(e));
		}

		public void HandleSelectedPartClicked(RaycastHit hit)
		{
			PerformToolAction(_tools, delegate(DesignerTool x)
			{
				x.SelectedPartClicked(SelectedPart, hit);
			});
		}

		public void InstantiatePart(DesignerPart designerPart, List<IPartScript> partScripts)
		{
			Assembly assembly = new Assembly(designerPart.AssemblyElement, 15, _partTypes);
			foreach (PartData part in assembly.Parts)
			{
				part.OnDesignerPullout(designerPart.Name, assembly, designerPart.IsSubassembly || designerPart.Category.Id == "Payloads");
			}
			if (designerPart.IsSubassembly || designerPart.Mod != null)
			{
				foreach (PartData part2 in assembly.Parts)
				{
					if (part2.SymmetryId.HasValue)
					{
						part2.SymmetryId = null;
					}
					if (part2.IsRootPart)
					{
						part2.IsRootPart = false;
					}
				}
			}
			else if (assembly.Parts.Count == 1)
			{
				assembly.Parts[0].Name = designerPart.Name;
			}
			CraftBuilder.CreatePartGameObjects(assembly.Parts, _craft);
			foreach (PartData part3 in assembly.Parts)
			{
				if (part3.CommandPod == null)
				{
					part3.CommandPod = _craft.RootPart.Data;
				}
				foreach (PartModifierData modifier in part3.Modifiers)
				{
					modifier.SymmetryId = null;
					modifier.GetScript().OnAddedToCraftInDesigner(designerPart.IsSubassembly);
				}
				PartScript partScript = part3.PartScript as PartScript;
				partScripts.Add(partScript);
				partScript.UpdateAttachPoints();
				partScript.OnDesignerPullout(assembly);
			}
			Symmetry.RegenerateUniqueGroupIds(assembly.Parts);
			_craft.Data.Assembly.Absorb(assembly);
		}

		public bool IsToolActive<T>() where T : DesignerTool
		{
			bool result = false;
			foreach (DesignerTool activeTool in _activeTools)
			{
				if (activeTool is T)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		public bool IsToolActive(DesignerTool toolToCheck)
		{
			bool result = false;
			foreach (DesignerTool activeTool in _activeTools)
			{
				if (activeTool == toolToCheck)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		public void LoadInitialCraft()
		{
			XElement xElement = null;
			try
			{
				xElement = _craftDesigns.GetCraftDesign(CraftDesigns.EditorCraftId);
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
				messageDialogScript.MessageText = "An error occurred trying to load the XML for the current editor craft.";
				messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
				{
					d.Close();
					CreateNewCraft(CrafConfigurationType.Rocket);
				};
				return;
			}
			if (xElement == null)
			{
				CreateNewCraft(CrafConfigurationType.Rocket);
				return;
			}
			CraftLoader.LoadCraftInteractive(xElement, createUndoStep: false, centerCamera: true, null, null, delegate
			{
				CreateNewCraft(CrafConfigurationType.Rocket);
			});
		}

		public void OnTutorialComplete(TutorialScript tutorial)
		{
			IsTutorialRunning = false;
			UndoHistory.Enabled = true;
			CreateUndoStep("Tutorial");
			if (tutorial != null)
			{
				tutorial.StepLoaded -= OnTutorialStepLoaded;
			}
		}

		public void OnTutorialStarted()
		{
			IsTutorialRunning = true;
			UndoHistory.Enabled = false;
		}

		public AudioSource PlaySound(AudioFile audioFile)
		{
			return Game.Instance.AudioPlayer.PlaySound(audioFile);
		}

		public void ReconnectSelectedPart()
		{
			if (SelectedPart == null)
			{
				return;
			}
			if (SelectedPart.SymmetrySlice == null && SelectedPart.Data.PartConnectionsEnabled)
			{
				int num = _movePartTool.DisconnectAndReconnectPart(SelectedPart);
				if (num == 1)
				{
					ShowMessage(string.Format("Part reconnected. Found 1 connection", num));
				}
				else
				{
					ShowMessage($"Part reconnected. Found {num} connections");
				}
			}
			else
			{
				ShowMessage("Cannot reconnect a part that has symmetry enabled.");
			}
		}

		public void Redo()
		{
			if (CapturedTool == null)
			{
				UndoStep step = UndoHistory.GetNextRedoStep();
				if (step != null)
				{
					ShowMessage("Redoing last step...");
					CraftLoader.LoadCraftInteractive(step.Xml, createUndoStep: false, centerCamera: false, "Redo complete", delegate
					{
						step.OnRedoComplete(this);
					}, null);
				}
			}
			else
			{
				ShowMessage("Cannot redo while a tool is actively processing inputs.");
			}
		}

		public void SaveCraft(string craftId = null, string name = null, bool showMessage = false)
		{
			try
			{
				if (DesignerUi.Flyouts.PartProperties.IsOpen)
				{
					DesignerUi.SelectedFlyout.Transform.GetComponentInChildren<PartPropertiesFlyoutScript>().UpdateSymmetry();
				}
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("Could not update select part properties symmetry information from flyout before saving: {0}", ex.Message);
			}
			if (string.IsNullOrWhiteSpace(craftId))
			{
				craftId = CraftDesigns.EditorCraftId;
			}
			if (!string.IsNullOrEmpty(name))
			{
				_craft.Data.Name = name;
			}
			XElement craftElement = GenerateCraftXml(undoStep: false, Game.Instance.Settings.Game.Designer.OptimizeCraftXml);
			if (craftId != CraftDesigns.EditorCraftId)
			{
				_craftDesigns.SaveCraft(CraftDesigns.EditorCraftId, craftElement);
			}
			_craftDesigns.SaveCraft(craftId, craftElement);
			if (showMessage)
			{
				DesignerUi.Designer.ShowMessage("Saved as '" + craftId + "'");
			}
		}

		public void SelectPart(IPartScript newPart, RaycastHit? hit, bool justAdded)
		{
			IPartScript oldPart;
			if (newPart == _selectedPart && newPart != null)
			{
				DeselectPart();
				oldPart = null;
			}
			else
			{
				oldPart = _selectedPart;
			}
			if (_selectedPart != null)
			{
				_selectedPart.PartMaterialScript.IsSelected = false;
			}
			_selectedPart = newPart;
			_designerUi.DesignerUiController.PartPropertiesHintVisible = false;
			if (_selectedPart != null)
			{
				_selectedPart.PartMaterialScript.IsSelected = true;
				if (DesignerUi.SelectedFlyout == null && !IsTutorialRunning)
				{
					foreach (PartModifierData modifier in _selectedPart.Data.Modifiers)
					{
						if (modifier is JetEngineData || modifier is RocketEngineData || modifier is ResizableWheelData)
						{
							EnablePartPropertiesHint(modifier);
						}
					}
				}
			}
			_activeCommandPod = GetActiveCommandPod();
			PerformToolAction(_tools, delegate(DesignerTool x)
			{
				x.SelectedPartChanged(newPart, hit, justAdded);
			});
			this.SelectedPartChanged?.Invoke(oldPart, newPart);
		}

		public void SelectTool(DesignerTool tool)
		{
			if (ActivateTool(tool) && tool is MovePartTool)
			{
				SetDefaultGizmosForCurrentPart();
			}
		}

		public void SetCraft(CraftScript craftScript, bool positionAtExistingCraftPosition)
		{
			bool flag = UndoHistory.Enabled;
			UndoHistory.Enabled = false;
			try
			{
				if (SelectedPart != null)
				{
					DeselectPart();
				}
				this.BeforeCraftUnloaded?.Invoke();
				Vector3? vector = null;
				if (_craft != null)
				{
					vector = _craft.transform.position;
					UnloadCurrentCraft();
				}
				craftScript.gameObject.name = "Craft";
				craftScript.transform.parent = _craftContainer;
				craftScript.transform.localPosition = new Vector3(0f, 0f, 0f);
				_craft = craftScript;
				_craft.CraftStructureChanged += OnCraftStructureChanged;
				if (positionAtExistingCraftPosition && vector.HasValue)
				{
					craftScript.transform.position = vector.Value;
				}
				_activeCommandPod = GetActiveCommandPod();
				if (!Physics.autoSyncTransforms)
				{
					Physics.SyncTransforms();
				}
				this.CraftLoaded?.Invoke();
				craftScript.SetStructureChanged();
			}
			finally
			{
				UndoHistory.Enabled = flag;
			}
		}

		public void SetDefaultGizmosForCurrentPart()
		{
			SelectPart(DesignerUi.Designer.SelectedPart, null, justAdded: false);
		}

		public void SetNonToolCapture(bool captured)
		{
			_nonToolHasCapture = captured;
		}

		public void ShowActiveCrafts()
		{
			PrepareForExit();
			Game.Instance.SceneManager.LoadMenu(new MenuSceneLoadParameters
			{
				OpenResumeCraftsListView = true
			});
		}

		public void ShowMessage(string message, float time = 7f)
		{
			_designerUi.ShowMessage(message, time);
		}

		public void Undo()
		{
			if (CapturedTool == null)
			{
				if (!UndoHistory.RedoStepsAvailable)
				{
					CreateUndoStep(null, head: true);
				}
				UndoStep step = UndoHistory.GetNextUndoStep();
				if (step != null)
				{
					ShowMessage("Undoing last step...");
					CraftLoader.LoadCraftInteractive(step.Xml, createUndoStep: false, centerCamera: false, "Undo complete", delegate
					{
						step.OnUndoComplete(this);
					}, null);
				}
			}
			else
			{
				ShowMessage("Cannot undo while a tool is actively processing inputs.");
			}
		}

		public void WeldSelectedPartLimb()
		{
			IPartScript selectedPart = SelectedPart;
			if (selectedPart != null)
			{
				if (CapturedTool == null)
				{
					if (selectedPart.Data.GroupId.HasValue)
					{
						WeldedPartGroup weldedPartGroup = new WeldedPartGroup(selectedPart.Data);
						foreach (PartData part in weldedPartGroup.Parts)
						{
							part.GroupId = null;
							Symmetry.SynchronizeParts(part.PartScript);
						}
						ShowMessage($"Un-grouped {weldedPartGroup.Parts.Count} parts.");
						return;
					}
					PartSelection partSelection = PartSelection.CreatePartSelection(selectedPart, preserveConnections: true);
					if (partSelection.Parts.Count > 1)
					{
						Guid value = Guid.NewGuid();
						foreach (IPartScript part2 in partSelection.Parts)
						{
							part2.Data.GroupId = value;
							Symmetry.SynchronizeParts(part2);
						}
						ShowMessage($"Grouped {partSelection.Parts.Count} parts together.");
					}
					else
					{
						ShowMessage("Cannot create a group from a single part.");
					}
					partSelection.Deselect();
				}
				else
				{
					ShowMessage("Can't group parts right now while actively using a tool.");
				}
			}
			else
			{
				ShowMessage("Cannot group parts: No parts are selected.");
			}
		}

		protected virtual void Awake()
		{
			Game.EnsureInitialized();
			Game.Instance.Designer = this;
			MemoryLeakUtility.Track(this);
			GameLoop = Game.Loop.CreateDesignerLoop();
			Tools = _tools.AsReadOnly();
			DesignerControls = new DesignerControls();
			_performanceAnalysis = new CraftPerformanceAnalysis(this);
			Gizmos.Initialize(this);
			_designerCamera.Initialize(this);
			AllowPartSelection = true;
			_partTypes = Game.Instance.PartTypes;
			_userInterface = Game.Instance.UserInterface;
			_craftDesigns = Game.Instance.CraftDesigns;
			UndoHistory = new UndoHistory();
			CraftLoaded += OnCraftLoaded;
			GizmoCamera = MovementGizmoCamera.Create(DesignerCamera.Transform);
			if (Validator.IsCareerMode)
			{
				MaxRadius = Validator.ItemValue("Craft.MaxDiameter") / 2f;
			}
			AddTool(new CameraTool(this), ref _cameraTool);
			AddTool(new MovePartTool(this), ref _movePartTool);
			AddTool(new NudgePartTool(this), ref _nudgePartTool);
			AddTool(new PaintTool(this), ref _paintTool);
			AddTool(new RotatePartTool(this), ref _rotatePartTool);
			AddTool(new WingAdjustmentTool(this), ref _wingAdjustmentTool);
			AddTool(new ControlSurfaceTool(this), ref _controlSurfaceTool);
			AddTool(new FuselageShapeTool(this), ref _fuselageShapeTool);
			AddTool(new FuselageTool(this), ref _fuselageTool);
			AddTool(new ScreenshotTool(this), ref _screenshotTool);
			AddTool(new PartConnectionsTool(this), ref _partConnectionsTool);
			AddTool(new MirrorCraftTool(this), ref _mirrorTool);
			AddTool(new SelectPartTool(this), ref _selectPartTool);
			GetTool<WingAdjustmentTool>().ControlSurfaceTool = GetTool<ControlSurfaceTool>();
			ActivateBaseTools();
			CraftLoader = new DesignerCraftLoader(this);
			Lights = _lights.GetComponentsInChildren<Light>();
			ShadowQualitySettings shadows = Game.Instance.QualitySettings.Shadows;
			shadows.Changed += OnShadowSettingsChanged;
			ApplyShadowQualitySettings(shadows);
			EnumSetting<VisualEffectsQualitySettings.LightingQualitySettingType> lighting = Game.Instance.QualitySettings.VisualEffects.Lighting;
			lighting.Changed += OnLightingQualityChanged;
			ApplyLightingQuality(lighting.Value);
			_designerPlatform.Initialize(this);
			_designerUi.Initialize();
			_isInitialized = true;
			this._initialized?.Invoke(this);
			if (string.IsNullOrWhiteSpace(Game.Instance.UrlHandler.PendingUrl))
			{
				LoadInitialCraft();
			}
		}

		protected virtual void LateUpdate()
		{
			_fakeQuadSphereRenderer.UpdateRenderer();
			if (_performanceAnalysis.Visible)
			{
				_performanceAnalysis.OnLateUpdate();
			}
		}

		protected virtual void OnDestroy()
		{
			Game.Loop.DestroyDesignerLoop();
			Game.Instance.QualitySettings.Shadows.Changed -= OnShadowSettingsChanged;
			_performanceAnalysis.OnDestroy();
			UnloadCurrentCraft();
		}

		protected virtual void Start()
		{
			Time.timeScale = 1f;
			ApplicationState.DesignInProgress = true;
			_fakeQuadSphereRenderer = QuadSphereRenderer.CreateWithoutQuadsphere(base.gameObject, Vector3.zero, DesignerCamera.Transform, Lights[0].transform);
			IFlyouts flyouts = DesignerUi.Flyouts;
			_cycleFlyouts = new List<IFlyout> { flyouts.Menu, flyouts.Tools, flyouts.PartList, flyouts.PartProperties, flyouts.Symmetry, flyouts.Preflight, flyouts.CraftParts, flyouts.ViewOptions };
			_cyclePartTools = new List<DesignerTool> { _movePartTool, _nudgePartTool, _rotatePartTool, _fuselageShapeTool, _paintTool, _partConnectionsTool };
			string text = Game.Instance.SceneManager.DesignSceneLoadParameters?.TutorialId;
			if (!string.IsNullOrEmpty(text))
			{
				StartCoroutine(StartTutorial(text));
				StartCoroutine(ShowCameraAndMouseControlsDialogCoroutine());
			}
			else
			{
				CheckForTutorials();
				StartCoroutine(ShowCameraAndMouseControlsDialogCoroutine());
			}
			if (!Device.IsMobileBuild)
			{
				StartCoroutine(ShowPerformanceAnalyzer());
			}
		}

		protected virtual void Update()
		{
			DesignerControls.Update(Time.unscaledDeltaTime);
			PerformToolAction(_activeTools, delegate(DesignerTool x)
			{
				x.Update(Time.unscaledDeltaTime);
			});
			if (!_userInterface.AnyDialogsOpen && !_userInterface.IsTextInputFocused && InputEnabled)
			{
				IGameInputs inputs = Game.Instance.Inputs;
				HandleCameraMovementInputs(inputs);
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) || inputs.DesignerToggleMenu.GetButtonDownIfEnabled())
				{
					DesignerUi.ToggleFlyout(DesignerUi.Flyouts.Menu);
				}
				else if (inputs.DesignerTogglePartProperties.GetButtonDownIfEnabled())
				{
					DesignerUi.ToggleFlyout(DesignerUi.Flyouts.PartProperties);
				}
				else if (inputs.MirrorSelectedPart.GetButtonDownIfEnabled())
				{
					_mirrorTool.QuickMirrorSelectedPart();
				}
				else if (inputs.DesignerDeselectPart.GetButtonDownIfEnabled())
				{
					SelectPart(null, null, justAdded: false);
				}
				else if (inputs.Undo.GetButtonDownIfEnabled() && UndoHistory.UndoStepsAvailable)
				{
					Undo();
				}
				else if (inputs.Redo.GetButtonDownIfEnabled() && UndoHistory.RedoStepsAvailable)
				{
					Redo();
				}
				else if (inputs.SaveDesign.GetButtonDownIfEnabled())
				{
					DialogSave();
				}
				else if (inputs.OpenPhotoLibrary.GetButtonDownIfEnabled())
				{
					PhotoLibraryDialogScript.Create(DesignerUi.Transform);
				}
				else if (inputs.TogglePerformanceAnalyzer.GetButtonDownIfEnabled())
				{
					PerformanceAnalysis.ToggleInspectorPanel();
				}
				else if (inputs.SelectFuselageShapeTool.GetButtonDownIfEnabled())
				{
					SelectTool(_fuselageShapeTool);
					DesignerUiScript.Flyouts.Tools.Open();
				}
				else if (inputs.SelectMovePartTool.GetButtonDownIfEnabled())
				{
					SelectTool(_movePartTool);
				}
				else if (inputs.SelectNudgeTool.GetButtonDownIfEnabled())
				{
					SelectTool(_nudgePartTool);
					DesignerUiScript.Flyouts.Tools.Open();
				}
				else if (inputs.SelectPaintTool.GetButtonDownIfEnabled())
				{
					SelectTool(_paintTool);
					DesignerUiScript.Flyouts.Tools.Open();
				}
				else if (inputs.SelectRotateTool.GetButtonDownIfEnabled())
				{
					SelectTool(_rotatePartTool);
					DesignerUiScript.Flyouts.Tools.Open();
				}
				else if (inputs.DesignerFlyoutPrevious.GetButtonDownIfEnabled())
				{
					CycleFlyouts(-1);
				}
				else if (inputs.DesignerFlyoutNext.GetButtonDownIfEnabled())
				{
					CycleFlyouts(1);
				}
				else if (inputs.TogglePartConnectionsPanel.GetButtonDownIfEnabled())
				{
					SelectTool(_partConnectionsTool);
					DesignerUiScript.Flyouts.Tools.Open();
				}
				else if (AllowPartMovement && AllowPartSelection)
				{
					if (inputs.DeleteSelectedPart.GetButtonDownIfEnabled())
					{
						DeleteSelectedParts();
					}
					else if (inputs.OpenSymmetryTool.GetButtonDownIfEnabled())
					{
						DesignerUiScript.ToggleFlyout(DesignerUiScript.Flyouts.Symmetry);
					}
					else if (inputs.SymmetryModePrevious.GetButtonDownIfEnabled())
					{
						SetPreviousSymmetryMode();
					}
					else if (inputs.SymmetryModeNext.GetButtonDownIfEnabled())
					{
						SetNextSymmetryMode();
					}
					else if (inputs.ReattachSelectedPart.GetButtonDownIfEnabled())
					{
						ReconnectSelectedPart();
					}
					else if (inputs.GroupParts.GetButtonDownIfEnabled())
					{
						WeldSelectedPartLimb();
					}
				}
				if (_rotatePartTool.SelectedPart == null)
				{
					return;
				}
				int num = (inputs.DesignerManipulatePartNextMode.GetButtonDownIfEnabled() ? 1 : (inputs.DesignerManipulatePartPreviousMode.GetButtonDownIfEnabled() ? (-1) : 0));
				if (num != 0)
				{
					int num2 = (int)(_partManipulationMode + num) % 7;
					if (num2 < 0)
					{
						num2 = 6;
					}
					_partManipulationMode = (PartManipulationMode)num2;
					ShowMessage("Part Manipulation Mode: " + _partManipulationMode.DisplayName());
				}
				float num3 = Mathf.Max(0.01f, _rotatePartTool.Gizmo.AngleSnap);
				if (inputs.RotatePositiveX.GetButtonDownIfEnabled() || (_partManipulationMode == PartManipulationMode.RotateX && inputs.DesignerManipulatePartPositive.GetButtonDownIfEnabled()))
				{
					RotatePart(Utilities.UnityTransform.TransformAxis.X, num3);
				}
				else if (inputs.RotateNegativeX.GetButtonDownIfEnabled() || (_partManipulationMode == PartManipulationMode.RotateX && inputs.DesignerManipulatePartNegative.GetButtonDownIfEnabled()))
				{
					RotatePart(Utilities.UnityTransform.TransformAxis.X, 0f - num3);
				}
				else if (inputs.RotatePositiveY.GetButtonDownIfEnabled() || (_partManipulationMode == PartManipulationMode.RotateY && inputs.DesignerManipulatePartPositive.GetButtonDownIfEnabled()))
				{
					RotatePart(Utilities.UnityTransform.TransformAxis.Y, num3);
				}
				else if (inputs.RotateNegativeY.GetButtonDownIfEnabled() || (_partManipulationMode == PartManipulationMode.RotateY && inputs.DesignerManipulatePartNegative.GetButtonDownIfEnabled()))
				{
					RotatePart(Utilities.UnityTransform.TransformAxis.Y, 0f - num3);
				}
				else if (inputs.RotatePositiveZ.GetButtonDownIfEnabled() || (_partManipulationMode == PartManipulationMode.RotateZ && inputs.DesignerManipulatePartPositive.GetButtonDownIfEnabled()))
				{
					RotatePart(Utilities.UnityTransform.TransformAxis.Z, num3);
				}
				else if (inputs.RotateNegativeZ.GetButtonDownIfEnabled() || (_partManipulationMode == PartManipulationMode.RotateZ && inputs.DesignerManipulatePartNegative.GetButtonDownIfEnabled()))
				{
					RotatePart(Utilities.UnityTransform.TransformAxis.Z, 0f - num3);
				}
				if (IsNudging(inputs.NudgePartPositiveX, inputs.DesignerManipulatePartPositive, PartManipulationMode.TranslateX))
				{
					NudgePart(Utilities.UnityTransform.TransformAxis.X, _nudgePartTool.GridSize);
				}
				else if (IsNudging(inputs.NudgePartNegativeX, inputs.DesignerManipulatePartNegative, PartManipulationMode.TranslateX))
				{
					NudgePart(Utilities.UnityTransform.TransformAxis.X, 0f - _nudgePartTool.GridSize);
				}
				else if (IsNudging(inputs.NudgePartPositiveY, inputs.DesignerManipulatePartPositive, PartManipulationMode.TranslateY))
				{
					NudgePart(Utilities.UnityTransform.TransformAxis.Y, _nudgePartTool.GridSize);
				}
				else if (IsNudging(inputs.NudgePartNegativeY, inputs.DesignerManipulatePartNegative, PartManipulationMode.TranslateY))
				{
					NudgePart(Utilities.UnityTransform.TransformAxis.Y, 0f - _nudgePartTool.GridSize);
				}
				else if (IsNudging(inputs.NudgePartPositiveZ, inputs.DesignerManipulatePartPositive, PartManipulationMode.TranslateZ))
				{
					NudgePart(Utilities.UnityTransform.TransformAxis.Z, _nudgePartTool.GridSize);
				}
				else if (IsNudging(inputs.NudgePartNegativeZ, inputs.DesignerManipulatePartNegative, PartManipulationMode.TranslateZ))
				{
					NudgePart(Utilities.UnityTransform.TransformAxis.Z, 0f - _nudgePartTool.GridSize);
				}
			}
			else if ((!_userInterface.AnyDialogsOpen || _userInterface.ActiveDialog is ScreenshotDialogScript) && !_userInterface.IsTextInputFocused && InputEnabled)
			{
				IGameInputs inputs2 = Game.Instance.Inputs;
				HandleCameraMovementInputs(inputs2);
			}
			bool IsNudging(IGameInput input, IGameInput inputGeneric, PartManipulationMode mode)
			{
				if (!input.GetButtonDownIfEnabled() && (!(input.GetButtonTimePressed() > 0.5f) || !input.GetButtonRepeating()))
				{
					if (_partManipulationMode == mode)
					{
						if (!inputGeneric.GetButtonDownIfEnabled())
						{
							if (inputGeneric.GetButtonTimePressed() > 0.5f)
							{
								return inputGeneric.GetButtonRepeating();
							}
							return false;
						}
						return true;
					}
					return false;
				}
				return true;
			}
		}

		private static void PerformToolAction(List<DesignerTool> tools, Action<DesignerTool> action)
		{
			for (int num = tools.Count - 1; num >= 0; num--)
			{
				action(tools[num]);
			}
		}

		private void ActivateBaseTools()
		{
			ActivateTools(_baseTools);
		}

		private bool ActivateTool(DesignerTool toolToActivate)
		{
			if (_capturedTool == null || _capturedTool.IsBaseTool)
			{
				if (_activeTools.Count > _baseTools.Count)
				{
					DeactivateTools(_activeTools.GetRange(_baseTools.Count, _activeTools.Count - _baseTools.Count));
				}
				if (!_activeTools.Contains(toolToActivate))
				{
					_activeTools.Add(toolToActivate);
					toolToActivate.Activate();
					PerformToolAction(_activeTools, delegate(DesignerTool x)
					{
						if (x != toolToActivate)
						{
							x.OnOtherToolActivated(toolToActivate);
						}
					});
				}
				this.ActiveToolChanged?.Invoke(toolToActivate);
				return true;
			}
			Debug.LogWarning("Designer currently has a non-base tool captured and cannot activate another tool");
			return false;
		}

		private void ActivateTools(List<DesignerTool> toolsToActivate)
		{
			for (int i = 0; i < toolsToActivate.Count(); i++)
			{
				ActivateTool(toolsToActivate[i]);
			}
		}

		private void AddTool<T>(T newTool, ref T toolRef) where T : DesignerTool
		{
			toolRef = newTool;
			if (newTool.IsBaseTool)
			{
				_baseTools.Add(newTool);
			}
			_tools.Add(newTool);
		}

		private void ApplyCraftDesignerSettings(DesignerSettingsData designerSettings)
		{
			DesignerSettingsData.DesignerPartCollisions partCollisions = designerSettings.PartCollisions;
			PartCollisionDetector.PartCollisionTolerance = partCollisions.Tolerance;
			GetTool<MovePartTool>().PartCollisionsEnabled = partCollisions.Enabled && partCollisions.MovePartTool;
			GetTool<WingAdjustmentTool>().PartCollisionDetector.Enabled = partCollisions.Enabled && partCollisions.WingTool;
			GetTool<FuselageTool>().PartCollisionDetector.Enabled = partCollisions.Enabled && partCollisions.FuselageTool;
			GetTool<FuselageShapeTool>().PartCollisionDetector.Enabled = partCollisions.Enabled && partCollisions.FuselageShapeTool;
		}

		private void ApplyLightingQuality(VisualEffectsQualitySettings.LightingQualitySettingType lightingQuality)
		{
			Lights[1].renderMode = ((lightingQuality == VisualEffectsQualitySettings.LightingQualitySettingType.Low) ? LightRenderMode.ForceVertex : LightRenderMode.Auto);
		}

		private void ApplyShadowQualitySettings(ShadowQualitySettings quality)
		{
			bool flag = false;
			Light[] lights = Lights;
			foreach (Light light in lights)
			{
				if (light.name == "Ceiling")
				{
					flag = true;
					quality.ConfigureLight(light, ShadowQualitySettings.LightType.PrimaryLight);
				}
				else
				{
					quality.ConfigureLight(light, ShadowQualitySettings.LightType.Other);
				}
			}
			if (!flag)
			{
				Debug.LogError("Could not find the primary light for the designer scene.");
			}
		}

		private void CheckForTutorials()
		{
			if (Game.IsCareer)
			{
				string text = (from x in Game.Instance.GameState.Career.Contracts.Active
					where !string.IsNullOrEmpty(x.DesignerTutorialId)
					select x.DesignerTutorialId).FirstOrDefault();
				if (text != null && !Game.Instance.Settings.SeenNotifications.Contains(text))
				{
					Game.Instance.Settings.AddNotification(text);
					StartCoroutine(StartTutorial(text));
				}
			}
		}

		private void CreateUndoStep(string ignoreKey, bool head)
		{
			UndoStep undoStep = new UndoStep(GenerateCraftXml(undoStep: true, optimizeXml: true));
			undoStep.IsHead = head;
			UndoHistory.PushUndo(undoStep, ignoreKey);
		}

		private void CycleFlyouts(int direction)
		{
			direction = ((direction >= 0) ? 1 : (-1));
			int num = _cycleFlyouts.IndexOf(DesignerUi.SelectedFlyout);
			if (num == -1)
			{
				SelectFlyout((direction >= 0) ? _cycleFlyouts[0] : _cycleFlyouts[_cycleFlyouts.Count - 1]);
				return;
			}
			IFlyout flyout = _cycleFlyouts[num];
			if (flyout == DesignerUi.Flyouts.Tools)
			{
				bool flag = false;
				for (int num2 = _cyclePartTools.Count - 1; num2 >= 0; num2--)
				{
					if (_cyclePartTools[num2].Active)
					{
						int num3 = num2 + ((direction >= 0) ? 1 : (-1));
						if (num3 < 0 || num3 >= _cyclePartTools.Count)
						{
							SelectFlyout(_cycleFlyouts[num + direction]);
						}
						else
						{
							SelectTool(_cyclePartTools[num3]);
							flyout.Open();
						}
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					DesignerTool tool = ((direction >= 0) ? _cyclePartTools[0] : _cyclePartTools[_cyclePartTools.Count - 1]);
					SelectTool(tool);
					flyout.Open();
				}
			}
			else if (flyout == DesignerUi.Flyouts.PartList)
			{
				PartListPanelScript componentInChildren = DesignerUi.Flyouts.PartList.Transform.GetComponentInChildren<PartListPanelScript>(includeInactive: true);
				if ((componentInChildren.SelectedCategoryIndex == 0 && direction < 0) || (componentInChildren.SelectedCategoryIndex == componentInChildren.Categories.Count - 1 && direction > 0))
				{
					SelectFlyout(_cycleFlyouts[num + direction]);
				}
				else
				{
					componentInChildren.SelectedCategoryIndex += direction;
				}
			}
			else if (flyout == DesignerUi.Flyouts.Preflight)
			{
				PreflightPanelScript componentInChildren2 = flyout.Transform.GetComponentInChildren<PreflightPanelScript>();
				List<PreflightPanelScript.TabButton> list = new List<PreflightPanelScript.TabButton>(componentInChildren2.TabButtons);
				int num4 = list.IndexOf(componentInChildren2.ActiveButton) + direction;
				if (num4 < 0 || num4 >= list.Count)
				{
					SelectFlyout(_cycleFlyouts[num + direction]);
				}
				else
				{
					componentInChildren2.ActiveButton = list[num4];
				}
			}
			else
			{
				int num5 = num + direction;
				if (num5 < 0)
				{
					num5 = _cycleFlyouts.Count - 1;
				}
				else if (num5 >= _cycleFlyouts.Count)
				{
					num5 = 0;
				}
				flyout = _cycleFlyouts[num5];
				SelectFlyout(flyout);
			}
			void SelectFlyout(IFlyout flyoutToSelect)
			{
				DesignerUi.SelectedFlyout = flyoutToSelect;
				if (flyoutToSelect == DesignerUi.Flyouts.Tools)
				{
					DesignerTool tool2 = ((direction >= 0) ? _cyclePartTools[0] : _cyclePartTools[_cyclePartTools.Count - 1]);
					SelectTool(tool2);
					flyoutToSelect.Open();
				}
				else if (flyoutToSelect == DesignerUi.Flyouts.PartList)
				{
					PartListPanelScript componentInChildren3 = DesignerUi.Flyouts.PartList.Transform.GetComponentInChildren<PartListPanelScript>(includeInactive: true);
					componentInChildren3.SelectedCategoryIndex = ((direction < 0) ? (componentInChildren3.Categories.Count - 1) : 0);
				}
			}
		}

		private void DeactivateTool(DesignerTool toolToDeactivate)
		{
			if (_activeTools.Contains(toolToDeactivate))
			{
				if (toolToDeactivate == _capturedTool)
				{
					_capturedTool = null;
				}
				_activeTools.Remove(toolToDeactivate);
				toolToDeactivate.Deactivate();
				PerformToolAction(_activeTools, delegate(DesignerTool x)
				{
					x.OnOtherToolDeactivated(toolToDeactivate);
				});
			}
		}

		private void DeactivateTools(List<DesignerTool> toolsToDeactivate)
		{
			for (int i = 0; i < toolsToDeactivate.Count(); i++)
			{
				DeactivateTool(toolsToDeactivate[i]);
			}
		}

		private void EnablePartPropertiesHint(PartModifierData modifier)
		{
			string value = $"PartProperties-{modifier.Name}";
			if (!Game.Instance.Settings.SeenNotifications.Contains(value))
			{
				_designerUi.DesignerUiController.PartPropertiesHintVisible = true;
			}
		}

		private CommandPodScript GetActiveCommandPod()
		{
			if (SelectedPart != null)
			{
				return SelectedPart.CommandPod as CommandPodScript;
			}
			if (CraftScript != null)
			{
				return CraftScript.PrimaryCommandPod as CommandPodScript;
			}
			return null;
		}

		private void HandleCameraMovementInputs(IGameInputs inputs)
		{
			int num = ((_cameraMovementMode == CameraMovementMode.Rotation) ? 1 : 0);
			int num2 = ((_cameraMovementMode == CameraMovementMode.Translation) ? 1 : 0);
			if (inputs.DesignerCameraSwitchMode.GetButtonDownIfEnabled())
			{
				_cameraMovementMode = (CameraMovementMode)((int)(_cameraMovementMode + 1) % 2);
				ShowMessage($"Camera Mode: {_cameraMovementMode}");
			}
			float num3 = inputs.DesignerCameraRotateLeftRight.GetAxisIfEnabled() + (float)num * inputs.DesignerCameraLeftRight.GetAxisIfEnabled();
			float num4 = inputs.DesignerCameraRotateUpDown.GetAxisIfEnabled() + (float)num * inputs.DesignerCameraUpDown.GetAxisIfEnabled();
			if (num3 != 0f || num4 != 0f)
			{
				_designerCamera.Rotate(new Vector2(num4 * 0.5f, 0f - num3));
			}
			float num5 = inputs.DesignerCameraZoom.GetAxisIfEnabled() + (float)num * inputs.DesignerCameraInOut.GetAxisIfEnabled();
			if (num5 != 0f)
			{
				_designerCamera.Zoom(1f - num5 * 0.01f);
			}
			float num6 = inputs.DesignerCameraTranslateLeftRight.GetAxisIfEnabled() + (float)num2 * inputs.DesignerCameraLeftRight.GetAxisIfEnabled();
			float num7 = inputs.DesignerCameraTranslateUpDown.GetAxisIfEnabled() + (float)num2 * inputs.DesignerCameraUpDown.GetAxisIfEnabled();
			float num8 = inputs.DesignerCameraTranslateInOut.GetAxisIfEnabled() + (float)num2 * inputs.DesignerCameraInOut.GetAxisIfEnabled();
			if (num6 != 0f || num7 != 0f || num8 != 0f)
			{
				_designerCamera.Move(new Vector3(num6, num7, num8) * 0.1f);
			}
		}

		private void HandleToolInput(HandleInputDelegate handleDelegate, bool fingerToolEvent = false)
		{
			if (_capturedTool != null)
			{
				bool flag;
				try
				{
					flag = handleDelegate(_capturedTool);
				}
				catch (Exception exception)
				{
					flag = false;
					Debug.LogException(exception);
				}
				if (!flag)
				{
					SetCapturedTool(null);
				}
				return;
			}
			for (int num = _activeTools.Count - 1; num >= 0; num--)
			{
				DesignerTool designerTool = _activeTools[num];
				if ((!fingerToolEvent || designerTool.HandleFingerToolEvents) && handleDelegate(designerTool))
				{
					SetCapturedTool(designerTool);
					break;
				}
			}
		}

		private void NudgePart(Utilities.UnityTransform.TransformAxis axis, float distance, bool activateTool = false)
		{
			if (_capturedTool == null)
			{
				_nudgePartTool.NudgeSelection(axis, distance);
				CraftScript.SetStructureChanged();
				ActivateBaseTools();
			}
		}

		private void OnCraftLoaded()
		{
			ActivateTool(MovePartTool);
			DesignerControls.SetCraft(CraftScript);
			ApplyCraftDesignerSettings(CraftScript.Data.DesignerSettings);
			_craft.CalculatePrice();
		}

		private void OnCraftStructureChanged()
		{
			_craft.CalculatePrice();
			PerformToolAction(_activeTools, delegate(DesignerTool x)
			{
				x.OnCraftStructureChanged();
			});
			this.CraftStructureChanged?.Invoke();
		}

		private void OnLightingQualityChanged(object sender, SettingChangedEventArgs<VisualEffectsQualitySettings.LightingQualitySettingType> e)
		{
			ApplyLightingQuality(e.Setting.Value);
		}

		private void OnSaveCraftDialogOkayButtonClicked(ModApi.Ui.InputDialogScript inputDialog)
		{
			string craftId = Utilities.ScrubFileName(inputDialog.InputText);
			if (string.IsNullOrEmpty(craftId))
			{
				return;
			}
			if (CraftDesigns.HasCraft(craftId))
			{
				ModApi.Ui.MessageDialogScript overwriteDialog = UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				overwriteDialog.MessageText = "A craft already exists with that name. Do you wish to overwrite it?";
				overwriteDialog.OkayButtonText = "OVERWRITE";
				overwriteDialog.UseDangerButtonStyle = true;
				overwriteDialog.OkayClicked += delegate
				{
					SaveCraft(craftId, craftId, showMessage: true);
					overwriteDialog.Close();
					inputDialog.Close();
				};
			}
			else
			{
				SaveCraft(craftId, craftId, showMessage: true);
				inputDialog.Close();
			}
		}

		private void OnShadowSettingsChanged(object sender, SettingsChangedEventArgs<ShadowQualitySettings> e)
		{
			ApplyShadowQualitySettings(e.Category);
		}

		private void OnTutorialStepLoaded(TutorialScript tutorial, TutorialStep step)
		{
			this.TutorialStepLoaded?.Invoke(this, new DesignerTutorialStepLoadedEventArgs());
		}

		private void PrepareForExit()
		{
			if (SaveOnExit)
			{
				SaveCraft(CraftDesigns.EditorCraftId);
			}
			PerformanceAnalysis.Visible = false;
			UnloadCurrentCraft();
		}

		private void RefreshPartProperties()
		{
			try
			{
				if (DesignerUi.Flyouts.PartProperties.IsOpen)
				{
					DesignerUi.Flyouts.PartProperties.Transform.GetComponentInChildren<PartPropertiesFlyoutScript>().RefreshUI();
				}
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("Could not update part properties flyout: {0}", ex.Message);
			}
		}

		private void RotatePart(Utilities.UnityTransform.TransformAxis axis, float rotationDegrees, bool activateTool = true)
		{
			if (_capturedTool == null)
			{
				_rotatePartTool.Rotate(Utilities.UnityTransform.GetRotation(axis, rotationDegrees), _rotatePartTool.Gizmo.RelativeSpace);
				CraftScript.SetStructureChanged();
				ActivateBaseTools();
			}
		}

		private void SetCapturedTool(DesignerTool designerTool)
		{
			if (_capturedTool != designerTool)
			{
				_capturedTool = designerTool;
				PerformToolAction(_activeTools, delegate(DesignerTool x)
				{
					x.OnCapturedToolChanged(_capturedTool);
				});
			}
		}

		private void SetNextSymmetryMode()
		{
			if (SelectedPart != null)
			{
				SymmetryMode symmetryMode = (SymmetryMode)((int)(SelectedPart.Data.SymmetryMode + 1) % 7);
				Symmetry.SetSymmetryMode(SelectedPart, symmetryMode, DesignerUi);
				RefreshPartProperties();
			}
		}

		private void SetPreviousSymmetryMode()
		{
			if (SelectedPart != null)
			{
				SymmetryMode symmetryMode = (SymmetryMode)((int)(SelectedPart.Data.SymmetryMode + 6) % 7);
				Symmetry.SetSymmetryMode(SelectedPart, symmetryMode, DesignerUi);
				RefreshPartProperties();
			}
		}

		private IEnumerator ShowCameraAndMouseControlsDialogCoroutine()
		{
			if (!Device.IsMobileBuild && !Game.Instance.Settings.SeenNotifications.Contains("Designer.CameraAndMouseControlsDialog"))
			{
				yield return null;
				yield return null;
				yield return null;
				Game.Instance.Settings.AddNotification("Designer.CameraAndMouseControlsDialog");
				ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = "Camera and mouse controls are fully customizable in the game settings.";
				messageDialogScript.OkayButtonText = "OK";
				messageDialogScript.CancelButtonText = "Show Me";
				messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
				{
					d.Close();
				};
				messageDialogScript.CancelClicked += delegate(ModApi.Ui.MessageDialogScript d)
				{
					d.Close();
					GameSettings game = Game.Instance.Settings.Game;
					game.General.Expanded = false;
					game.Audio.Expanded = false;
					game.Designer.Expanded = false;
					game.Flight.Expanded = false;
					game.MouseInputDesigner.Expanded = true;
					game.MouseInputFlight.Expanded = true;
					SettingsDialogScript.Create();
				};
			}
		}

		private IEnumerator ShowPerformanceAnalyzer()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			PerformanceAnalysis.Visible = true;
		}

		private void StartLevel(string craftNodeName)
		{
			SaveCraft(CraftDesigns.EditorCraftId);
			ValidationResult result = Validator.ValidateCraft(_craft, Game.Instance.GameState.SelectedLaunchLocation);
			Action launchAction = delegate
			{
				UnloadCurrentCraft();
				Game.Instance.BeginFlight(CraftDesigns.EditorCraftId, craftNodeName, "Design", result.LaunchCost);
			};
			Action viewIssuesAction = delegate
			{
				DesignerUi.ShowValidationPanel();
			};
			if (result.ErrorCount == 0)
			{
				if (result.WarningCount > 0)
				{
					ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
					messageDialogScript.MessageText = "One or more potential issues have been found. Would you like to view the issues or continue with the launch?";
					messageDialogScript.CancelButtonText = "View Issues";
					messageDialogScript.OkayButtonText = "Launch Anyway";
					messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
					{
						launchAction();
						d.Close();
					};
					messageDialogScript.CancelClicked += delegate(ModApi.Ui.MessageDialogScript d)
					{
						viewIssuesAction();
						d.Close();
					};
				}
				else if (PlayViewModel.CheckSandboxActiveCrafts())
				{
					launchAction();
				}
			}
			else
			{
				ModApi.Ui.MessageDialogScript messageDialogScript2 = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript2.MessageText = "This craft has one or more issues and cannot be launched at this time. Try launching again after correcting the issues.";
				messageDialogScript2.CancelButtonText = "Close";
				messageDialogScript2.OkayButtonText = "View Issues";
				messageDialogScript2.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
				{
					viewIssuesAction();
					d.Close();
				};
			}
		}

		private IEnumerator StartTutorial(string tutorialId)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			DesignerTutorial arg = null;
			arg = tutorialId switch
			{
				"Tutorial-FirstOrbit" => new FirstOrbitTutorial(this), 
				"Tutorial-FirstPayload" => new FirstPayloadTutorial(this), 
				"Tutorial-Sandbox" => new SandboxTutorial(this), 
				"Tutorial-TheJump" => new TheJumpTutorial(this), 
				"Tutorial-FirstFlight" => new FirstFlightTutorial(this), 
				"Tutorial-VerticalShot" => new VerticalShotTutorial(this), 
				"Tutorial-FirstRace" => new FirstRaceTutorial(this), 
				_ => throw new Exception($"Designer tutorial not found: {arg}"), 
			};
			arg.StartTutorial(tutorialId);
			arg.Tutorial.StepLoaded += OnTutorialStepLoaded;
			this.TutorialStarted?.Invoke(this, new DesignerTutorialStartedEventArgs());
		}

		private void UnloadCurrentCraft()
		{
			if (_craft != null)
			{
				_craft.Unload();
				_craft = null;
			}
		}
	}
}
