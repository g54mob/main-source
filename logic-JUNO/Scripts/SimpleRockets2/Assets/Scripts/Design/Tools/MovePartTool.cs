using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.DevConsole;
using ModApi;
using ModApi.Audio;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Input;
using ModApi.Input.Events;
using ModApi.Services.Purchasing;
using ModApi.Settings;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class MovePartTool : DesignerToolBase
	{
		public delegate void DragPartDelegate();

		private bool _addingNewPart;

		private bool _clone;

		private Vector3 _grabDelta;

		private float _grabDistance;

		private Vector3 _grabPosition;

		private MovePartToolHelper _helper;

		private IPartScript _initialPart;

		private DateTime _lastClickTime = DateTime.Now;

		private float _manualRepositionTimer;

		private MouseInputSettingsDesigner _mouseInputSettings;

		private XmlElement _movePartPanel;

		private PartSelection _partSelection;

		private DropZoneScript _subassemblyDropZone;

		private DropZoneScript _trashcanDropZone;

		public override ICollection<IPartScript> ActiveParts
		{
			get
			{
				ICollection<IPartScript> collection = _partSelection?.Parts;
				return collection ?? Array.Empty<IPartScript>();
			}
		}

		public Vector3 DragDelta
		{
			get
			{
				if (_partSelection == null)
				{
					return Vector3.zero;
				}
				return _partSelection.ContainerParent.position - _grabPosition;
			}
		}

		public override bool HandleFingerToolEvents => true;

		public override bool IsBaseTool => true;

		public bool IsDragging => _partSelection != null;

		public bool LockMovePart { get; set; }

		public bool PartCollisionsEnabled { get; set; }

		public event DragPartDelegate DragPartSelectionEnded;

		public event DragPartDelegate DragPartSelectionStarted;

		public MovePartTool(DesignerScript designer)
			: base(designer)
		{
			_helper = new MovePartToolHelper(this);
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputDesigner;
		}

		public static float SnapToGrid(float value, float unitSize, bool centerAroundZero)
		{
			if (Mathf.Abs(value) < unitSize * 3f && centerAroundZero)
			{
				return 0f;
			}
			if (value > 0f)
			{
				return (float)(int)((value + unitSize / 2f) / unitSize) * unitSize;
			}
			return (float)(int)((value - unitSize / 2f) / unitSize) * unitSize;
		}

		public override void Activate()
		{
			base.Activate();
		}

		public void AddingNewParts(List<IPartScript> partScripts, Vector3 partPosition, float grabDistance)
		{
			_addingNewPart = true;
			_grabDistance = grabDistance;
			_grabDelta = default(Vector3);
			if (_partSelection != null)
			{
				_partSelection.Deselect();
				_partSelection = null;
			}
			_partSelection = new PartSelection(partScripts, Vector3.zero, Quaternion.identity);
			_helper.DragStart(_partSelection);
			_partSelection.ContainerParent.position = partPosition;
			RequestCaptureOnNextInput();
		}

		public override void Deactivate()
		{
			base.Deactivate();
			base.DesignerScript.HighlightedPart = null;
		}

		public void DeleteSelectedParts()
		{
			if (_partSelection != null)
			{
				DragEnd();
			}
			IPartScript selectedPart = base.Designer.SelectedPart;
			if (selectedPart != null)
			{
				PartSelection partSelection = PartSelection.CreatePartSelection(selectedPart, preserveConnections: false);
				DeleteParts(partSelection);
			}
		}

		public int DisconnectAndReconnectPart(IPartScript part)
		{
			PartSelection partSelection = PartSelection.CreatePartSelection(part, preserveConnections: false, null, null, selectSinglePart: true);
			int result = MovePartToolHelper.DetectAttachPointConnectionsAndConnect(partSelection.AvailableAttachPoints);
			partSelection.Deselect();
			part.CraftScript.SetStructureChanged();
			return result;
		}

		public override bool HandleClick(ClickEventArgs e)
		{
			bool result = base.HandleClick(e);
			bool flag = e.IsTouchPrimary || _mouseInputSettings.CanSelectPart(e.InputButton) || _mouseInputSettings.CanClonePart(e.InputButton);
			bool flag2 = !flag || Game.Instance.Inputs.PreventPartSelection.GetButton();
			bool flag3 = e.FingerToolMode == FingerToolMode.None && base.Designer.DesignerUi.FingerTool.Enabled;
			UpdateDropZoneReferences();
			if (e.InputState == InputState.Begin)
			{
				if (base.Designer.AllowPartSelection && !flag2)
				{
					_clone = false;
					_initialPart = null;
					if (!_addingNewPart)
					{
						result = HandleBeginClick(e, flag3);
					}
				}
			}
			else if (e.InputState == InputState.Updated && base.Designer.AllowPartMovement)
			{
				if (base.IsInputCaptured && base.Designer.AllowPartMovement && (flag || _clone) && !flag2 && !flag3)
				{
					if (_partSelection == null)
					{
						if (_initialPart != null || (!_addingNewPart && e.DragDistanceSinceBegin < 20f))
						{
							result = DragStart(e);
						}
					}
					else
					{
						result = DragUpdate(e);
					}
				}
			}
			else if (e.InputState == InputState.End && base.Designer.AllowPartMovement)
			{
				result = false;
				_addingNewPart = false;
				if (flag || _clone)
				{
					base.Designer.DesignerUi.SetMainPanelVisibility(visible: true);
					_movePartPanel.Hide();
					base.Designer.CanPinch = true;
					if (_partSelection != null)
					{
						DragEnd();
					}
					_clone = false;
				}
			}
			else
			{
				_addingNewPart = false;
			}
			return result;
		}

		public override bool HandleScroll(ScrollEventArgs e)
		{
			bool result = false;
			if (IsDragging)
			{
				result = true;
				base.Designer.GetTool<CameraTool>().HandleScroll(e);
			}
			return result;
		}

		public override void OnCraftStructureChanged()
		{
			base.OnCraftStructureChanged();
		}

		public void RotatePartOnAxis(IPartScript part, Vector3 axis, int angle)
		{
			PartSelection partSelection = PartSelection.CreatePartSelection(part, preserveConnections: false);
			partSelection.ContainerParent.Rotate(axis, angle);
			foreach (IPartScript part2 in partSelection.Parts)
			{
				part2.UpdateAttachPoints();
			}
			int num = MovePartToolHelper.DetectAttachPointConnectionsAndConnect(partSelection.AvailableAttachPoints);
			partSelection.Deselect();
			base.Designer.CreateUndoStep();
			if (num > 0)
			{
				part.CraftScript.SetStructureChanged();
			}
		}

		public override void Update(float deltaTime)
		{
			if (Game.Instance.UserInterface.AnyDialogsOpen && !DevConsoleManagerScript.IsConsoleOpen)
			{
				HandleManualReposition();
			}
		}

		private void CleanupSubassemblySelection()
		{
			_partSelection.ContainerParent.position = _grabPosition;
			if (MovePartToolHelper.DetectAttachPointConnectionsAndConnect(_partSelection.AvailableAttachPoints) > 0)
			{
				base.Designer.CraftScript.SetStructureChanged();
			}
			_partSelection.Deselect();
			_partSelection = null;
			LockMovePart = false;
			this.DragPartSelectionEnded?.Invoke();
			_helper.ShowAttachPoints(show: false);
			base.Designer.DeselectPart();
		}

		private void DeleteParts(PartSelection partSelection)
		{
			List<IPartScript> parts = partSelection.Parts;
			ICraftScript craftScript = parts.First().CraftScript;
			if (parts.Contains(craftScript.RootPart))
			{
				bool flag = false;
				foreach (PartData part in craftScript.Data.Assembly.Parts)
				{
					if (!parts.Contains(part.PartScript))
					{
						CommandPodData modifier = part.GetModifier<CommandPodData>();
						if (modifier != null)
						{
							craftScript.SetPrimaryCommandPod(modifier.Script);
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					base.Designer.ShowMessage("Cannot delete primary command pod.");
					partSelection.Deselect();
					return;
				}
			}
			Symmetry.DeleteSymmetricParts(parts);
			foreach (IPartScript item in parts)
			{
				if (!item.Data.IsDestroyed)
				{
					base.Designer.CraftScript.DestroyPart(item.Data, destroyPartGameObject: true);
				}
			}
			foreach (PartData part2 in base.Designer.CraftScript.Data.Assembly.Parts)
			{
				PartData commandPod = part2.CommandPod;
				if ((object)commandPod != null && commandPod.IsDestroyed)
				{
					Debug.Log("Part referencing destroyed command pod. Changing it to use the Primary Command Pod");
					part2.CommandPod = base.Designer.CraftScript.PrimaryCommandPod.Part;
				}
			}
			partSelection.Deselect();
			base.Designer.DeselectPart();
			base.Designer.CraftScript.SetStructureChanged();
			base.Designer.CreateUndoStep();
			base.Designer.ShowMessage("Selected parts deleted");
			base.Designer.PlaySound(AudioLibrary.Design.DeletePart);
		}

		private void DragEnd()
		{
			foreach (IPartScript part in _partSelection.Parts)
			{
				part.PartMaterialScript.FoundAttachPoint = false;
			}
			bool flag = true;
			bool flag2 = _addingNewPart || _clone;
			IPartScript partScript = null;
			if (_trashcanDropZone.Selected)
			{
				PartDroppedOnTrashcan();
			}
			else
			{
				if (_subassemblyDropZone.Selected && !flag2)
				{
					PartDroppedOnCreateSubassembly();
					return;
				}
				PartDropped(_helper.SelectedPartsColliding);
				if (_clone && _partSelection.Parts.Count > 0)
				{
					partScript = _partSelection.Parts[0];
				}
			}
			_helper.DragEnd();
			_partSelection.Deselect();
			_partSelection = null;
			LockMovePart = false;
			if (flag)
			{
				base.Designer.CreateUndoStep();
			}
			if (partScript != null)
			{
				base.Designer.SelectPart(partScript, null, justAdded: false);
			}
			this.DragPartSelectionEnded?.Invoke();
		}

		private bool DragStart(ClickEventArgs e)
		{
			bool result = false;
			IPartScript partScript = _initialPart;
			bool button = Game.Instance.Inputs.ToolModifier.GetButton();
			bool flag = button || e.FingerToolMode == FingerToolMode.DetachPart;
			if (_clone)
			{
				if (button || e.FingerToolMode == FingerToolMode.CloneGroup || (partScript != null && (partScript.Data?.GroupId).HasValue))
				{
					if (partScript != null)
					{
						bool onlyIncludeGroupedParts = partScript != null && (partScript.Data?.GroupId).HasValue && !button && e.FingerToolMode != FingerToolMode.CloneGroup;
						IEnumerable<IPartScript> source = Symmetry.DuplicateParts(partScript, onlyIncludeGroupedParts);
						Symmetry.RegenerateUniqueGroupIds(source.Select((IPartScript x) => x.Data).ToArray());
						partScript = source.First();
						flag = false;
						base.Designer.ShowMessage($"Cloned {source.Count()} parts", 5f);
					}
				}
				else
				{
					partScript = CraftBuilder.DuplicatePart(partScript.Data, base.Designer.CraftScript as CraftScript, clearSymmetryIds: true, clearGroupIds: true).PartScript;
					flag = true;
					base.Designer.ShowMessage("Cloned part: " + partScript.Data.Name, 5f);
				}
			}
			else if (_initialPart == null)
			{
				Debug.Log("Initial Part is null.");
				PartRaycastResult partAtScreenPosition = base.Designer.GetPartAtScreenPosition(e.Position);
				if (partAtScreenPosition.PartScript != null && partScript != null)
				{
					partScript = partAtScreenPosition.Hit.transform.GetComponentInParent<IPartScript>();
					_grabDelta = partScript.Transform.position - partAtScreenPosition.Hit.point;
					_grabDistance = (partScript.Transform.position - partAtScreenPosition.Ray.origin).magnitude;
					_grabPosition = partScript.Transform.position;
				}
			}
			_initialPart = null;
			if (partScript != null)
			{
				if (new PartGraph(partScript.Data, breakOnRigidBodyBoundary: false).HasRoot)
				{
					base.Designer.PlaySound(AudioLibrary.Design.DisconnectPart);
				}
				if (flag && partScript.SymmetrySlice != null)
				{
					flag = false;
				}
				_partSelection = PartSelection.CreatePartSelection(partScript, preserveConnections: false, Quaternion.identity, _grabPosition, flag);
				_helper.DragStart(_partSelection);
				result = true;
				this.DragPartSelectionStarted?.Invoke();
				base.Designer.CraftScript.SetStructureChanged();
			}
			UpdateDropZoneReferences();
			return result;
		}

		private bool DragUpdate(ClickEventArgs e)
		{
			base.Designer.CanPinch = false;
			base.Designer.DesignerUi.SetMainPanelVisibility(visible: false);
			_movePartPanel.Show();
			_trashcanDropZone.gameObject.SetActive(value: true);
			if (_clone || _addingNewPart)
			{
				_subassemblyDropZone.gameObject.SetActive(value: false);
			}
			else
			{
				_subassemblyDropZone.gameObject.SetActive(value: true);
			}
			if (!LockMovePart)
			{
				Ray screenRay = base.Designer.DesignerCamera.ScreenPointToRay(e.Position);
				float grabDistance = _grabDistance;
				Vector3 vector = screenRay.origin + screenRay.direction * grabDistance;
				_partSelection.ContainerParent.SetPositionAndRotation(vector + _grabDelta, Quaternion.identity);
				_helper.DragPart(screenRay);
				_subassemblyDropZone.UpdateDropZone(e.Position);
				_trashcanDropZone.UpdateDropZone(e.Position);
			}
			return true;
		}

		private bool HandleBeginClick(ClickEventArgs e, bool fingerToolBypassed)
		{
			bool result = false;
			double totalSeconds = (DateTime.Now - _lastClickTime).TotalSeconds;
			_lastClickTime = DateTime.Now;
			PartRaycastResult partAtScreenPosition = base.Designer.GetPartAtScreenPosition(e.Position);
			if (partAtScreenPosition.PartScript != null)
			{
				if (!fingerToolBypassed)
				{
					IPartScript partScript = partAtScreenPosition.PartScript;
					result = base.Designer.AllowPartMovement;
					_initialPart = partScript;
					_grabDelta = partScript.Transform.position - partAtScreenPosition.Hit.point;
					_grabDistance = (partScript.Transform.position - partAtScreenPosition.Ray.origin).magnitude;
					_grabPosition = partScript.Transform.position;
					if (partScript != base.Designer.SelectedPart)
					{
						base.Designer.SelectPart(partScript, partAtScreenPosition.Hit, justAdded: false);
					}
					else if (totalSeconds < 0.5)
					{
						base.Designer.DesignerCamera.FocusOnPart(partScript);
					}
					else
					{
						base.Designer.HandleSelectedPartClicked(partAtScreenPosition.Hit);
					}
					if (_mouseInputSettings.CanClonePart(e.InputButton) || e.FingerToolMode == FingerToolMode.CloneGroup || e.FingerToolMode == FingerToolMode.ClonePart)
					{
						_clone = true;
					}
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.SelectPart);
				}
				else if (totalSeconds < 0.5)
				{
					base.Designer.DesignerCamera.FocusOnPart(partAtScreenPosition.PartScript);
					base.Designer.SelectPart(partAtScreenPosition.PartScript, partAtScreenPosition.Hit, justAdded: false);
				}
			}
			return result;
		}

		private void HandleManualReposition()
		{
			if (!Game.Instance.UserInterface.IsTextInputFocused && base.Designer.SelectedPart != null && 0 == 0)
			{
				_manualRepositionTimer = 0f;
			}
			if (_manualRepositionTimer > 0f)
			{
				_manualRepositionTimer -= Time.deltaTime;
			}
		}

		private bool HandleManualRepositionForKey(IGameInput input, Vector3 repositionAmount)
		{
			if (input.GetButtonIfEnabled())
			{
				if (Game.Instance.Inputs.ToolModifier.GetButton())
				{
					repositionAmount *= 10f;
				}
				if (_manualRepositionTimer <= 0f)
				{
					base.Designer.SelectedPart.Transform.position += repositionAmount;
				}
				if (input.GetButtonDownIfEnabled())
				{
					_manualRepositionTimer = 0.75f;
				}
				return true;
			}
			if (input.GetButtonUpIfEnabled())
			{
				base.Designer.CreateUndoStep("Nudge-" + input.Id);
			}
			return false;
		}

		private void OnCreateSubassemblyDialogClosed(InputDialogScript dialog)
		{
			if (dialog.Result.Value != InputDialogResult.Cancel)
			{
				string text = Utilities.ScrubFileName(dialog.InputText);
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				List<PartData> list = new List<PartData>();
				foreach (IPartScript part in _partSelection.Parts)
				{
					list.Add(part.Data);
				}
				Assembly subassembly = Assembly.CreateAssemblyFromParts(list);
				base.Designer.CreateSubassembly(text, subassembly);
			}
			CleanupSubassemblySelection();
			dialog.Close();
		}

		private void PartDropped(bool selectedPartsColliding)
		{
			if (selectedPartsColliding)
			{
				return;
			}
			if (MovePartToolHelper.DetectAttachPointConnectionsAndConnect(_partSelection.AvailableAttachPoints) > 0)
			{
				AudioSource audioSource = base.Designer.PlaySound(AudioLibrary.Design.ConnectPart);
				audioSource.SetPitch(UnityEngine.Random.Range(0.75f, 1.25f));
				float num = 0f;
				foreach (IPartScript part in _partSelection.Parts)
				{
					num += part.Data.Mass * 100f;
				}
				if (num > 1f)
				{
					float t = Mathf.Clamp01(Mathf.Pow(num / 161292f, 0.25f));
					float cutoff = Mathf.Lerp(22000f, 4000f, t);
					audioSource.AddLowpassCutoff(cutoff);
				}
			}
			else
			{
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.DropPart);
				bool flag = false;
				foreach (IPartScript part2 in _partSelection.Parts)
				{
					if (part2.SymmetrySlice != null)
					{
						IPartScript rootPart = part2.SymmetrySlice.SymmetryGroup.RootPart;
						if (!_partSelection.Parts.Contains(rootPart))
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					Symmetry.DeleteSymmetricParts(_partSelection.Parts);
				}
			}
			base.Designer.CraftScript.SetStructureChanged();
		}

		private void PartDroppedOnCreateSubassembly()
		{
			IInAppPurchaseFeatures<IInAppPurchaseFeature> features = Game.Instance.InAppPurchases.Features;
			if (features.IsFeatureUnlocked(features.CreateSubAssemblies, "unlock support for subassemblies."))
			{
				_subassemblyDropZone.Selected = false;
				InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
				inputDialogScript.MessageText = "Enter a name for this new subassembly." + Environment.NewLine + "You will be able to access it from the part list under the Subassemblies category.";
				inputDialogScript.InputPlaceholderText = "Name...";
				inputDialogScript.InvalidCharacters.AddRange(Path.GetInvalidFileNameChars());
				inputDialogScript.OkayClicked += OnCreateSubassemblyDialogClosed;
				inputDialogScript.CancelClicked += OnCreateSubassemblyDialogClosed;
			}
			else
			{
				CleanupSubassemblySelection();
			}
			if (base.Designer.DesignerUi.FingerTool.Enabled)
			{
				((FingerTool)base.Designer.DesignerUi.FingerTool).ResetToDragStart();
			}
		}

		private void PartDroppedOnTrashcan()
		{
			_trashcanDropZone.Selected = false;
			DeleteParts(_partSelection);
			if (base.Designer.DesignerUi.FingerTool.Enabled)
			{
				((FingerTool)base.Designer.DesignerUi.FingerTool).ResetToDragStart();
			}
		}

		private void UpdateDropZoneReferences()
		{
			DesignerUiScript designerUiScript = base.Designer.DesignerUi as DesignerUiScript;
			_movePartPanel = designerUiScript.DesignerUiController.xmlLayout.GetElementById("move-part-panel");
			XmlElement elementById = designerUiScript.DesignerUiController.xmlLayout.GetElementById("trashcan-dropzone");
			_trashcanDropZone = elementById.gameObject.GetComponent<DropZoneScript>();
			if (_trashcanDropZone == null)
			{
				_trashcanDropZone = elementById.gameObject.AddComponent<DropZoneScript>();
			}
			XmlElement elementById2 = designerUiScript.DesignerUiController.xmlLayout.GetElementById("subassembly-dropzone");
			_subassemblyDropZone = elementById2.gameObject.GetComponent<DropZoneScript>();
			if (_subassemblyDropZone == null)
			{
				_subassemblyDropZone = elementById2.gameObject.AddComponent<DropZoneScript>();
			}
		}
	}
}
