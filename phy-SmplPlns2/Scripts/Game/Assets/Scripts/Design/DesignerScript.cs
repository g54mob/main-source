using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Assets.Scripts.Achievements;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Events;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.Tutorials;
using Assets.Scripts.Design.UI;
using Assets.Scripts.Input;
using Assets.Scripts.Input.Events;
using Assets.Scripts.Storage;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Dialogs;
using Jundroo.Common.Extensions;
using Jundroo.Common.Platform;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Jundroo.SocialPlatforms.Achievements;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerScript : MonoBehaviour
	{
		public enum PartConcealmentType
		{
			Invisible = 0,
			Hidden = 1,
			None = 2
		}

		private enum CameraMovementMode
		{
			Rotation = 0,
			Translation = 1
		}

		private const double ResourceCollectionIntervalSeconds = 300.0;

		private static bool _showTutorialDialog = true;

		private static bool _showTutorialsFlyout = true;

		private CameraMovementMode _cameraMovementMode;

		private List<PartScript> _concealedCollection = new List<PartScript>();

		private Vector3 _defaultCameraTarget;

		private Designer _designer;

		private DragCalculatorScript _dragCalculator;

		[SerializeField]
		private DesignerEnvironmentScript _environment;

		private bool _firstFrame = true;

		private double _lastResourceCollectionTime;

		private PartConcealmentType _partConcealment;

		private PartManipulationMode _partManipulationMode;

		public static GameObject DefaultCameraTarget { get; private set; }

		public AircraftScript Aircraft => _designer.Aircraft;

		public Designer Designer => _designer;

		public DesignerUIScript DesignerUI { get; private set; }

		public DragCalculatorScript DragCalculator => _dragCalculator;

		public DesignerEnvironmentScript Environment => _environment;

		public PartConcealmentType PartConcealment
		{
			get
			{
				return _partConcealment;
			}
			set
			{
				_partConcealment = value;
				ChangePartConcealmentType(_partConcealment);
			}
		}

		public PartManipulationMode PartManipulationMode => _partManipulationMode;

		public PartScript SelectedPart => _designer.SelectedPart;

		public TutorialScript Tutorial { get; private set; }

		public bool TutorialRunning => Tutorial?.CurrentTutorial != null;

		public event Action ConcealedPartCollectionChanged;

		public static string FindAircraftUrlId(string s)
		{
			Match match = new Regex("(?:\\/a\\/|\\/Feedback\\/View\\/)([a-zA-Z0-9]+)").Match(s);
			if (match.Success)
			{
				return match.Groups[1].Value;
			}
			return s;
		}

		public void AddPart(DesignerPart part, Vector2 position)
		{
			_designer.Tools.AddPart(part, position);
		}

		public void AddPartsToConcealedCollection(IList<PartScript> parts, bool updateAttachPoints = true)
		{
			for (int i = 0; i < parts.Count; i++)
			{
				PartScript partScript = parts[i];
				partScript.Part.VisibleInDesigner = false;
				SetPartConcealment(partScript, PartConcealment, updateAttachPoints);
			}
			_concealedCollection.AddRange(parts);
			this.ConcealedPartCollectionChanged?.Invoke();
		}

		public void AddPartToConcealedCollection(PartScript part)
		{
			part.Part.VisibleInDesigner = false;
			SetPartConcealment(part, PartConcealment, concealed: true);
			_concealedCollection.Add(part);
			this.ConcealedPartCollectionChanged?.Invoke();
		}

		public void ChangeCameraTarget(Vector3 newPosition)
		{
			DefaultCameraTarget.transform.position = newPosition;
		}

		public void ClearPartConcealment()
		{
			PartConcealment = PartConcealmentType.None;
			foreach (PartScript item in _concealedCollection)
			{
				item.Part.VisibleInDesigner = true;
			}
			_concealedCollection.Clear();
			PartConcealment = PartConcealmentType.Invisible;
			this.ConcealedPartCollectionChanged?.Invoke();
		}

		public void CreateNewAircraft()
		{
			_designer.CreateNewAircraft();
		}

		public void EndPartMovement()
		{
			Designer.Tools.MovePartTool.EndPartMovement();
		}

		public bool EnsureTutorialIsNotRunning(string message = null)
		{
			if (TutorialRunning)
			{
				if (string.IsNullOrEmpty(message))
				{
					message = "This is disabled while the designer tutorial is running.";
				}
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, message, "Disabled During Tutorial");
			}
			return !TutorialRunning;
		}

		public PartScript GetPartAtScreenPosition(Vector2 screenPosition)
		{
			return Designer.GetPartAtScreenPosition(screenPosition)?.Part;
		}

		public void HandleInput(InputEvent e)
		{
			_designer.HandleInput(e);
		}

		public void HandleScroll(MouseScrollEvent e)
		{
			_designer.HandleScroll(e);
		}

		public void InvertPartConcealmentSelection()
		{
			List<PartScript> list = new List<PartScript>(_concealedCollection);
			PartConcealmentType partConcealment = PartConcealment;
			ClearPartConcealment();
			PartConcealment = partConcealment;
			foreach (PartData part in Aircraft.Aircraft.Assembly.Parts)
			{
				PartScript partScript = part.PartScript;
				if (!list.Contains(partScript))
				{
					AddPartToConcealedCollection(partScript);
				}
			}
		}

		public bool IsConcealed(PartScript part)
		{
			return _concealedCollection.Contains(part);
		}

		public void LoadAircraftFromClipboardOrUrl(string url = null)
		{
			bool flag = string.IsNullOrEmpty(url);
			if (flag)
			{
				url = GUIUtility.systemCopyBuffer;
			}
			bool flag2 = true;
			if (url.Length >= 6)
			{
				string text = FindAircraftUrlId(url);
				Debug.Log("Loading URL: " + text);
				string text2 = text;
				for (int i = 0; i < text2.Length; i++)
				{
					if (!char.IsLetterOrDigit(text2[i]))
					{
						flag2 = false;
					}
				}
				if (flag2)
				{
					DownloadAircraft(text);
				}
			}
			else
			{
				flag2 = false;
			}
			if (!flag2)
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Could not find valid aircraft ID " + (flag ? "in your clipboard text." : ("from URL: " + url));
			}
		}

		public void OnEnteredFromFlight()
		{
			_environment.OnEnteredDesignerFromFlight();
		}

		public void OnThemeUpdated()
		{
			PartMaterialScript[] componentsInChildren = Aircraft.GetComponentsInChildren<PartMaterialScript>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnThemeUpdated();
			}
		}

		public void RemovePartFromConcealedCollection(PartScript part)
		{
			SetPartConcealment(part, PartConcealmentType.None, concealed: false);
			part.Part.VisibleInDesigner = true;
			_concealedCollection.Remove(part);
			this.ConcealedPartCollectionChanged?.Invoke();
		}

		public void RemovePartsFromConcealedCollection(IList<PartScript> parts, bool updateAttachPoints = true)
		{
			for (int i = 0; i < parts.Count; i++)
			{
				PartScript partScript = parts[i];
				SetPartConcealment(partScript, PartConcealmentType.None, concealed: false, updateAttachPoints);
				partScript.Part.VisibleInDesigner = true;
				_concealedCollection.Remove(partScript);
			}
			this.ConcealedPartCollectionChanged?.Invoke();
		}

		public void RemovePartsFromConcealedCollection(IList<PartData> parts, bool updateAttachPoints = true)
		{
			for (int i = 0; i < parts.Count; i++)
			{
				PartScript partScript = parts[i].PartScript;
				SetPartConcealment(partScript, PartConcealmentType.None, concealed: false, updateAttachPoints);
				partScript.Part.VisibleInDesigner = true;
				_concealedCollection.Remove(partScript);
			}
			this.ConcealedPartCollectionChanged?.Invoke();
		}

		public void RevertCameraTargetToDefault()
		{
			DefaultCameraTarget.transform.position = _defaultCameraTarget;
		}

		public void RotatePartOnAxis(Vector3 axis, int angle)
		{
			_designer.RotatePartOnAxis(axis, angle);
		}

		public void SaveAircraft()
		{
			EndPartMovement();
			string text = Game.Instance.CraftDatabase.CurrentSubdirectoryPath ?? string.Empty;
			if (text == "Stock Craft")
			{
				text = string.Empty;
			}
			AircraftData aircraft = Designer.Aircraft.Aircraft;
			string inputText = Path.Combine(text, aircraft.Name);
			List<string> tags = aircraft.Tags;
			SaveCraftDialogScript.Create(inputText, tags, OnSaveAircraftDialogOkayClicked);
		}

		public void SaveDesignerCraft()
		{
			Designer.Save("__editor__.xml", Aircraft.Aircraft.Name);
		}

		public bool ToggleCenterOfLiftGizmo()
		{
			_designer.ShowCenterOfLiftGizmo = !_designer.ShowCenterOfLiftGizmo;
			return _designer.ShowCenterOfLiftGizmo;
		}

		public bool ToggleCenterOfMassGizmo()
		{
			_designer.ShowCenterOfMassGizmo = !_designer.ShowCenterOfMassGizmo;
			return _designer.ShowCenterOfMassGizmo;
		}

		public bool ToggleCenterOfThrustGizmo()
		{
			_designer.ShowCenterOfThrustGizmo = !_designer.ShowCenterOfThrustGizmo;
			return _designer.ShowCenterOfThrustGizmo;
		}

		public void ToggleNewPartSymmetryState(bool showMessage = false)
		{
			Designer.Symmetry.SymmetryDisabledForNewParts = !Designer.Symmetry.SymmetryDisabledForNewParts;
			if (showMessage)
			{
				bool symmetryDisabledForNewParts = Designer.Symmetry.SymmetryDisabledForNewParts;
				DesignerUI.ShowMessage("Symmetry " + (symmetryDisabledForNewParts ? "disabled" : "enabled") + " for new parts.");
			}
		}

		public void TogglePartSymmetryForSelectedPart(bool includeConnectedParts, bool cloneUnlinkedOrToggleAndDelete = false)
		{
			if (SelectedPart == null)
			{
				return;
			}
			if (Device.IsDemoBuild)
			{
				Game.Instance.UserInterface.CreateMessageDialog("Symmetry functionality is not available in the demo version of the game.", "Not Available In Demo");
				return;
			}
			PartScript selectedPart = SelectedPart;
			Designer.SelectedPart = null;
			SymmetryUtility.TogglePartSymmetryReport togglePartSymmetryReport = SymmetryUtility.TogglePartSymmetryDisabledState(Designer, selectedPart, includeConnectedParts, cloneUnlinkedOrToggleAndDelete, Designer.Symmetry);
			Designer.SelectedPart = selectedPart;
			if (togglePartSymmetryReport.CreatedParts.Count > 0 || togglePartSymmetryReport.DeletedParts.Count > 0)
			{
				Designer.OnAircraftStructureChanged();
			}
			bool symmetryDisabled = selectedPart.Part.SymmetryDisabled;
			string text = Designer.Symmetry.Mode switch
			{
				SymmetryMode.Disabled => symmetryDisabled ? "Mirroring Disabled" : "Mirroring Enabled", 
				SymmetryMode.Mirrored => symmetryDisabled ? "Mirroring Disabled" : "Mirroring Enabled", 
				SymmetryMode.Radial2x => symmetryDisabled ? "Symmetry Disabled" : "Radial Symmetry 2x Enabled", 
				SymmetryMode.Radial3x => symmetryDisabled ? "Symmetry Disabled" : "Radial Symmetry 3x Enabled", 
				SymmetryMode.Radial4x => symmetryDisabled ? "Symmetry Disabled" : "Radial Symmetry 4x Enabled", 
				_ => symmetryDisabled ? "Symmetry Disabled" : "Symmetry Enabled", 
			};
			DesignerUI.ShowMessage(togglePartSymmetryReport.GetDesignerMessage());
			if (togglePartSymmetryReport.ConnectionFailures.Count > 0)
			{
				PartConnectionFailure.LogWarnings(togglePartSymmetryReport.ConnectionFailures);
				string text2 = string.Empty;
				string text3 = ((Designer.Instance.Symmetry.Mode > SymmetryMode.Mirrored) ? "symmetric" : "mirrored");
				if (togglePartSymmetryReport.ConnectionFailures.Count > 3)
				{
					text2 += $"Failed to create {togglePartSymmetryReport.ConnectionFailures.Count} {text3} connections between parts.";
				}
				else
				{
					for (int i = 0; i < togglePartSymmetryReport.ConnectionFailures.Count; i++)
					{
						PartConnectionFailure partConnectionFailure = togglePartSymmetryReport.ConnectionFailures[i];
						if (partConnectionFailure.PartA != null && partConnectionFailure.PartB != null)
						{
							text2 = text2 + ((i == 0) ? string.Empty : "\n") + "Failed to create " + text3 + " connection between part " + PartString(partConnectionFailure.PartA) + " and part " + PartString(partConnectionFailure.PartB) + "." + ((partConnectionFailure.Reason == PartConnectionFailureReason.AttachPointUnavailable) ? "The attach point is unavailable." : string.Empty);
						}
					}
				}
				Designer.Instance.DesignerScript.DesignerUI.AppendMessage(text2);
			}
			MovePartTool movePartTool = Designer.Tools.MovePartTool;
			if (movePartTool.IsActive && movePartTool.IsManipulatingPart)
			{
				movePartTool.RebuildSymmetricSelections();
			}
			else
			{
				Designer.CreateUndoStepForSelectedPart(text + ((togglePartSymmetryReport.SourceSelectionCount == 1) ? string.Empty : $" and {togglePartSymmetryReport.SourceSelectionCount - 1} other parts"));
			}
			Designer.Symmetry.SymmetryDisabledForNewParts = selectedPart.Part.SymmetryDisabled;
			static string PartString(PartData partData)
			{
				return $"'{partData.Name} (Id: {partData.Id})'";
			}
		}

		public void UnloadUnusedAssets(bool force)
		{
			double realtimeSinceStartupAsDouble = Time.realtimeSinceStartupAsDouble;
			if (realtimeSinceStartupAsDouble >= _lastResourceCollectionTime + 300.0 || force)
			{
				_lastResourceCollectionTime = realtimeSinceStartupAsDouble;
				StartCoroutine(CleanupResourcesCoroutine());
			}
			static IEnumerator CleanupResourcesCoroutine()
			{
				yield return new WaitForEndOfFrame();
				Resources.UnloadUnusedAssets();
			}
		}

		protected virtual void FixedUpdate()
		{
			_designer.FixedUpdate();
		}

		protected virtual void LateUpdate()
		{
			if (Time.timeScale == 0f)
			{
				Physics.SyncTransforms();
			}
			_designer.LateUpdate();
			if (_firstFrame)
			{
				FirstFrameLateUpdate();
				_firstFrame = false;
			}
			if (JFuselageScript.ApplyBufferedChanges())
			{
				Designer.SetAircraftStructureChanged();
			}
			JFuselageScript.StartChangeBuffer();
		}

		protected virtual void OnApplicationFocus(bool pauseStatus)
		{
			if (Application.platform != RuntimePlatform.WindowsEditor && pauseStatus)
			{
				Debug.Log("Designs Saved: Application Focus");
				SaveDesignerCraft();
			}
		}

		protected virtual void OnApplicationPause(bool pauseStatus)
		{
			if (pauseStatus)
			{
				Debug.Log("Designs Saved: Application Pause");
				SaveDesignerCraft();
			}
		}

		protected virtual void OnDestroy()
		{
			Designer?.OnDestroy();
			JFuselageScript.ApplyBufferedChanges();
		}

		protected virtual void Start()
		{
			DesignerUI = UnityEngine.Object.FindFirstObjectByType<DesignerUIScript>(FindObjectsInactive.Include);
			_designer = new Designer(this);
			_designer.PartDeleted += OnPartDeleted;
			DesignerUI.Initialize(this);
			Tutorial = TutorialScript.Create(this);
			if (!Tutorial.TutorialDB.FirstTutorial.IsDone && _showTutorialDialog)
			{
				_showTutorialDialog = false;
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, "Welcome to the designer! Would you like to try an interactive tutorial to learn how to build? It's totally free!", "Designer Tutorial", delegate(MessageDialogScript result)
				{
					result.Close();
					Tutorial.StartTutorial(Tutorial.TutorialDB.FirstTutorial);
				});
			}
			else if (!Tutorial.TutorialDB.AllTutorialsDone && _showTutorialsFlyout)
			{
				_showTutorialsFlyout = false;
				DesignerUI.Flyouts.Selected = DesignerUI.Flyouts.Tutorials;
			}
			DefaultCameraTarget = Utilities.FindFirstGameObjectMyselfOrChildren("CameraTarget", base.gameObject);
			_defaultCameraTarget = DefaultCameraTarget.transform.position;
			base.gameObject.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/DesignerScript");
			if (Game.Instance.DownloadedAircraftId != null)
			{
				DownloadAircraft(Game.Instance.DownloadedAircraftId);
				Game.Instance.DownloadedAircraftId = null;
			}
			_environment.Initialize(_designer);
			_dragCalculator = new GameObject("DragCalculator").AddComponent<DragCalculatorScript>();
			_dragCalculator.transform.SetParent(base.transform, worldPositionStays: false);
		}

		protected virtual void Update()
		{
			_designer.Update();
			if (Game.Instance.UserInterface.AllowKeyboardInputs)
			{
				GameInputs instance = GameInputs.Instance;
				HandleCameraMovementInputs(instance);
				HandlePartManipulationInputs(instance);
				if (DebugInput.GetKeyDown(KeyCode.F12))
				{
					TakeTransparentPromoScreenshot();
				}
				if (instance.DesignerPartSelectAndFocus.GetButtonDownIfEnabled())
				{
					EndPartMovement();
					Designer.SelectPart(InputWrapper.MouseScreenPosition, focus: true);
				}
				if (instance.SymmetryInitialStateToggle.GetButtonDownIfEnabled())
				{
					ToggleNewPartSymmetryState(showMessage: true);
				}
				if (instance.SymmetrySinglePartToggle.GetButtonDownIfEnabled())
				{
					TogglePartSymmetryForSelectedPart(includeConnectedParts: false);
				}
				if (instance.SymmetryMultiPartToggle.GetButtonDownIfEnabled())
				{
					TogglePartSymmetryForSelectedPart(includeConnectedParts: true);
				}
				if (instance.SymmetryUnlinkedSinglePart.GetButtonDownIfEnabled())
				{
					TogglePartSymmetryForSelectedPart(includeConnectedParts: false, cloneUnlinkedOrToggleAndDelete: true);
				}
				if (instance.SymmetryUnlinkedMultiPart.GetButtonDownIfEnabled())
				{
					TogglePartSymmetryForSelectedPart(includeConnectedParts: true, cloneUnlinkedOrToggleAndDelete: true);
				}
				if (instance.RotatePositiveX.GetButtonDownIfEnabled())
				{
					RotatePartOnAxis(Vector3.right, 90);
				}
				if (instance.RotateNegativeX.GetButtonDownIfEnabled())
				{
					RotatePartOnAxis(Vector3.right, -90);
				}
				if (instance.RotatePositiveY.GetButtonDownIfEnabled())
				{
					RotatePartOnAxis(Vector3.up, 90);
				}
				if (instance.RotateNegativeY.GetButtonDownIfEnabled())
				{
					RotatePartOnAxis(Vector3.up, -90);
				}
				if (instance.RotatePositiveZ.GetButtonDownIfEnabled())
				{
					RotatePartOnAxis(Vector3.forward, 90);
				}
				if (instance.RotateNegativeZ.GetButtonDownIfEnabled())
				{
					RotatePartOnAxis(Vector3.forward, -90);
				}
				if (instance.ReattachSelectedPart.GetButtonDownIfEnabled())
				{
					Designer.ReconnectSelectedPart();
				}
				if (instance.TogglePaintPanel.GetButtonDownIfEnabled())
				{
					DesignerUI.Flyouts.ToggleFlyout(DesignerUI.Flyouts.Paint);
				}
				if (instance.ToggleSearchPartsPanel.GetButtonDownIfEnabled())
				{
					DesignerUI.Flyouts.ToggleFlyout(DesignerUI.Flyouts.SearchParts);
				}
				if (instance.TogglePartPropertiesPanel.GetButtonDownIfEnabled())
				{
					DesignerUI.TogglePartProperties();
				}
				if (instance.ToggleTransformPartPanel.GetButtonDownIfEnabled())
				{
					DesignerUI.Flyouts.ToggleFlyout(DesignerUI.Flyouts.TransformPart);
				}
				if (instance.SymmetryPanelToggle.GetButtonDownIfEnabled())
				{
					DesignerUI.Flyouts.ToggleFlyout(DesignerUI.Flyouts.Symmetry);
				}
				if (instance.ToggleBlueprintsPanel.GetButtonDownIfEnabled())
				{
					DesignerUI.Flyouts.ToggleFlyout(DesignerUI.Flyouts.Blueprints);
				}
				if (instance.ToggleDecalVisibility.GetButtonDownIfEnabled())
				{
					DesignerUI.DecalOutlinesVisible = !DesignerUI.DecalOutlinesVisible;
					DesignerUI.ShowMessage(DesignerUI.DecalOutlinesVisible ? "Show decal projectors" : "Hide decal projectors");
				}
				if (instance.ToggleCuttingVisibility.GetButtonDownIfEnabled())
				{
					DesignerUI.CuttingOutlinesVisible = !DesignerUI.CuttingOutlinesVisible;
					DesignerUI.ShowMessage(DesignerUI.CuttingOutlinesVisible ? "Showing cutting volumes" : "Hiding cutting volumes");
				}
				if (instance.ToggleOrtho.GetButtonDownIfEnabled() && !UnityEngine.Input.GetKey(KeyCode.LeftControl) && !UnityEngine.Input.GetKey(KeyCode.RightControl))
				{
					Designer.CameraController.IsOrthographic = !Designer.CameraController.IsOrthographic;
					DesignerUI.UpdateOrthographicButton();
				}
				if (instance.ToggleGhost.GetButtonDownIfEnabled())
				{
					Designer.GhostViewEnabled = !Designer.GhostViewEnabled;
				}
			}
		}

		private void ChangePartConcealmentType(PartConcealmentType partConcealment)
		{
			foreach (PartScript item in _concealedCollection)
			{
				if (item != null)
				{
					SetPartConcealment(item, partConcealment, concealed: true);
				}
			}
		}

		private void DownloadAircraft(string aircraftId)
		{
			if (!EnsureTutorialIsNotRunning("Downloading crafts is disabled while the tutorial is running."))
			{
				return;
			}
			EndPartMovement();
			AchievementHelper.UnlockAchievement(AchievementKey.WebsiteDownloadPlane);
			Game.Instance.UserInterface.CreateCraftDownloadDialog().StartDownload(aircraftId, delegate(CraftDownloadDialogScript.CraftDownloadResult result)
			{
				if (result.ResultType == CraftDownloadDialogScript.CraftDownloadResultType.Canceled)
				{
					DesignerUI.ShowMessage("Aircraft download canceled");
				}
				else if (result.ResultType != CraftDownloadDialogScript.CraftDownloadResultType.Success)
				{
					DesignerUI.ShowMessage(string.Empty);
				}
				else
				{
					Designer.LoadXml(result.CraftXml);
					Designer.CreateUndoStep("Downloaded craft");
					DesignerUI.ShowMessage("Aircraft Downloaded");
				}
			});
		}

		private void FirstFrameLateUpdate()
		{
		}

		private void HandleCameraMovementInputs(GameInputs inputs)
		{
			int num = ((_cameraMovementMode == CameraMovementMode.Rotation) ? 1 : 0);
			int num2 = ((_cameraMovementMode == CameraMovementMode.Translation) ? 1 : 0);
			if (inputs.DesignerCameraSwitchMode.GetButtonDownIfEnabled())
			{
				_cameraMovementMode = (CameraMovementMode)((int)(_cameraMovementMode + 1) % 2);
				Designer.ShowMessage($"Camera Mode: {_cameraMovementMode}");
			}
			float num3 = inputs.DesignerCameraRotateLeftRight.GetAxisIfEnabled() + (float)num * inputs.DesignerCameraLeftRight.GetAxisIfEnabled();
			float num4 = inputs.DesignerCameraRotateUpDown.GetAxisIfEnabled() + (float)num * inputs.DesignerCameraUpDown.GetAxisIfEnabled();
			if (num3 != 0f || num4 != 0f)
			{
				Designer.CameraController.Rotate(new Vector2(0f - num3, num4));
			}
			float num5 = inputs.DesignerCameraZoom.GetAxisIfEnabled() + (float)num * inputs.DesignerCameraInOut.GetAxisIfEnabled();
			if (num5 != 0f)
			{
				Designer.CameraController.Zoom(num5 * 0.2f);
			}
			float num6 = inputs.DesignerCameraTranslateLeftRight.GetAxisIfEnabled() + (float)num2 * inputs.DesignerCameraLeftRight.GetAxisIfEnabled();
			float num7 = inputs.DesignerCameraTranslateUpDown.GetAxisIfEnabled() + (float)num2 * inputs.DesignerCameraUpDown.GetAxisIfEnabled();
			float num8 = inputs.DesignerCameraTranslateInOut.GetAxisIfEnabled() + (float)num2 * inputs.DesignerCameraInOut.GetAxisIfEnabled();
			if (num6 != 0f || num7 != 0f || num8 != 0f)
			{
				Designer.CameraController.Move(new Vector3(num6, num7, num8) * 0.1f);
			}
		}

		private void HandlePartManipulationInputs(GameInputs inputs)
		{
			int num = (inputs.DesignerManipulatePartNextMode.GetButtonDownIfEnabled() ? 1 : (inputs.DesignerManipulatePartPreviousMode.GetButtonDownIfEnabled() ? (-1) : 0));
			if (num != 0)
			{
				int num2 = (int)(_partManipulationMode + num) % 7;
				if (num2 < 0)
				{
					num2 = 6;
				}
				_partManipulationMode = (PartManipulationMode)num2;
				Designer.ShowMessage("Part Manipulation Mode: " + _partManipulationMode.DisplayName());
			}
			int num3 = (inputs.DesignerManipulatePartPositive.GetButtonDownIfEnabled() ? 1 : (inputs.DesignerManipulatePartNegative.GetButtonDownIfEnabled() ? (-1) : 0));
			if (num3 != 0)
			{
				int angle = ((num3 > 0) ? 90 : (-90));
				switch (_partManipulationMode)
				{
				case PartManipulationMode.RotateX:
					RotatePartOnAxis(Vector3.right, angle);
					break;
				case PartManipulationMode.RotateY:
					RotatePartOnAxis(Vector3.up, angle);
					break;
				case PartManipulationMode.RotateZ:
					RotatePartOnAxis(Vector3.forward, angle);
					break;
				case PartManipulationMode.None:
				case PartManipulationMode.TranslateX:
				case PartManipulationMode.TranslateY:
				case PartManipulationMode.TranslateZ:
					break;
				}
			}
		}

		private void OnPartDeleted(object sender, PartDeletedEventArgs e)
		{
			int num = _concealedCollection.IndexOf(e.Part);
			if (num >= 0)
			{
				_concealedCollection.RemoveAt(num);
			}
		}

		private void OnSaveAircraftDialogOkayClicked(SaveCraftDialogScript dialog)
		{
			string aircraftId = dialog.InputText;
			Action<string, string> saveAircraft = delegate(string id, string text)
			{
				AircraftData aircraft = Designer.Aircraft.Aircraft;
				aircraft.Tags.Clear();
				dialog.GetTags(aircraft.Tags);
				Designer.Save(id, text);
				dialog.Close();
			};
			if (string.IsNullOrWhiteSpace(aircraftId))
			{
				return;
			}
			int num = aircraftId.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).LastIndexOf(Path.DirectorySeparatorChar);
			string name = ((num >= 0 && num < aircraftId.Length - 1) ? aircraftId.Substring(num + 1) : aircraftId);
			aircraftId = aircraftId.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar) + ".xml";
			if (Game.Instance.CraftDatabase.TryGetCraft(aircraftId, out var _))
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = "A craft already exists with that name. Do you wish to overwrite it?";
				messageDialogScript.OkayButtonText = "Overwrite";
				messageDialogScript.UseDangerButtonStyle = true;
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					saveAircraft(aircraftId, name);
					d.Close();
				};
				messageDialogScript.ExtraWide = true;
				Widget widget = messageDialogScript.Widget.FindDirectChildWidgetByName("message-dialog");
				if (widget != null)
				{
					widget.SetStyle("position", "0 -45");
				}
			}
			else
			{
				saveAircraft(aircraftId, name);
			}
		}

		private void SetPartConcealment(PartScript part, PartConcealmentType partConcealment, bool concealed, bool updateAttachPoints = true)
		{
			switch (partConcealment)
			{
			case PartConcealmentType.Invisible:
				part.PartMaterialScript.Visible = !concealed;
				part.PartMaterialScript.IsHidden = false;
				if (updateAttachPoints)
				{
					part.SetAttachPointsVisible(visible: false);
				}
				break;
			case PartConcealmentType.Hidden:
				part.PartMaterialScript.IsHidden = concealed;
				part.PartMaterialScript.Visible = true;
				if (updateAttachPoints)
				{
					part.SetAttachPointsVisible(visible: true);
				}
				break;
			case PartConcealmentType.None:
				part.PartMaterialScript.IsHidden = false;
				part.PartMaterialScript.Visible = true;
				if (updateAttachPoints)
				{
					part.SetAttachPointsVisible(visible: true);
				}
				break;
			default:
				Debug.LogError("Unknown concealment type: " + PartConcealment);
				break;
			}
		}

		private void TakeTransparentPromoScreenshot()
		{
			int num = 2560;
			int num2 = 1440;
			string text = string.Format("{0}\\SimplePlanes_{1}x{2}_{3}.png", GameData.GetPath("Promo Screenshots"), num, num2, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
			DirectoryInfo directory = new FileInfo(text).Directory;
			if (!directory.Exists)
			{
				directory.Create();
			}
			Camera camera = Designer.CameraController.Camera;
			Color backgroundColor = camera.backgroundColor;
			int cullingMask = camera.cullingMask;
			CameraClearFlags clearFlags = camera.clearFlags;
			RenderTexture targetTexture = camera.targetTexture;
			RenderTexture active = RenderTexture.active;
			try
			{
				RenderTexture renderTexture = new RenderTexture(num, num2, 24, RenderTextureFormat.ARGB32);
				Texture2D texture2D = new Texture2D(num, num2, TextureFormat.RGBA32, mipChain: false, linear: true);
				camera.cullingMask = 35717120;
				camera.backgroundColor = Color.clear;
				camera.targetTexture = renderTexture;
				Shader.SetGlobalColor("TransparentScreenshotBackgroundHelper_Color", new Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, 1f));
				camera.RenderWithShader(Shader.Find("SimplePlanes/TransparentScreenshotBackgroundHelper"), null);
				camera.clearFlags = CameraClearFlags.Depth;
				camera.Render();
				RenderTexture.active = renderTexture;
				texture2D.ReadPixels(new Rect(0f, 0f, num, num2), 0, 0);
				UnityEngine.Object.Destroy(renderTexture);
				byte[] bytes = texture2D.EncodeToPNG();
				File.WriteAllBytes(text, bytes);
				Debug.Log($"Took screenshot to: {text}");
			}
			finally
			{
				camera.backgroundColor = backgroundColor;
				camera.cullingMask = cullingMask;
				camera.clearFlags = clearFlags;
				camera.targetTexture = targetTexture;
				RenderTexture.active = active;
			}
		}
	}
}
