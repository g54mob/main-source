using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.Symmetry.Events;
using Assets.Scripts.Design.UI;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.Input;
using Assets.Scripts.Input.Events;
using Assets.Scripts.UI;
using Jundroo.Common.Platform;
using Jundroo.Common.Pool;
using Jundroo.Common.Settings;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class MovePartTool : DesignerTool
	{
		public enum ConnectionMode
		{
			None = 0,
			PartSelection = 1,
			AttachPoint = 2
		}

		private static class Profile
		{
			public static readonly ProfilerMarker ConnectPartToAttachPoint = new ProfilerMarker("MovePartTool.ConnectPartToAttachPoint");

			public static readonly ProfilerMarker DetectAttachPointConnectionsAndConnect = new ProfilerMarker("MovePartTool.DetectAttachPointConnectionsAndConnect");

			public static readonly ProfilerMarker DragPart = new ProfilerMarker("MovePartTool.DragPart");

			public static readonly ProfilerMarker GetHitResults = new ProfilerMarker("MovePartTool.GetHitResults");

			public static readonly ProfilerMarker HandleInput = new ProfilerMarker("MovePartTool.HandleInput");

			public static readonly ProfilerMarker UpdateSymmetricPartsOnDrag = new ProfilerMarker("MovePartTool.UpdateSymmetricPartsOnDrag");
		}

		public const int PartDragLayerMask = 2129921;

		private static RaycastHit[] _rayHitBuffer = new RaycastHit[64];

		private bool _addingNewPart;

		private bool _clone;

		private AttachPointScript _closestAttachPoint;

		private List<AttachPointScript> _compatibleAttachPoints = new List<AttachPointScript>();

		private ConnectionMode _connectionMode;

		private DragVisualizationTool _dragVisualizationTool;

		private Vector3 _grabDelta;

		private float _grabDistance;

		private Vector3 _grabPosition;

		private Quaternion _grabRotation;

		private AttachPointGizmo _hoveredAttachPoint;

		private AttachPointScript _hoverTargetAttachPoint;

		private PartScript _initialPart;

		private float _manualRepositionTimer;

		private PartSelection _partSelection;

		private DesignerViewMode? _savedViewMode;

		private bool _selectedPartsColliding;

		private List<PartSelection> _symmetricPartSelections = new List<PartSelection>();

		private (PartData Part, SymmetryUtility.SymmetricAttachPointsAvailability Availability)? _unnavailableSymmetricAttachPoint;

		public bool CheckCollisionsOnDrag { get; set; }

		public DragVisualizationTool DragVisualizationTool => _dragVisualizationTool;

		public AttachPointGizmo HoveredAttachPoint
		{
			get
			{
				return _hoveredAttachPoint;
			}
			private set
			{
				if (_hoveredAttachPoint != value)
				{
					if (_hoveredAttachPoint != null)
					{
						_hoveredAttachPoint.Highlighted = false;
					}
					_hoveredAttachPoint = value;
					if (_hoveredAttachPoint != null)
					{
						_hoveredAttachPoint.Highlighted = true;
						_hoveredAttachPoint.Selected = false;
						_hoveredAttachPoint.Success = false;
					}
				}
			}
		}

		public bool InConnectedMode { get; set; }

		public bool IsManipulatingPart => _partSelection != null;

		public bool ShowDrag
		{
			get
			{
				return _dragVisualizationTool.Enabled;
			}
			set
			{
				_dragVisualizationTool.Enabled = value;
				base.Designer.Tools.UpdateToolInformationDisplay();
			}
		}

		protected override bool PartHighlightEnabled => true;

		public MovePartTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			_dragVisualizationTool = new DragVisualizationTool(designer);
		}

		public static void ConnectPartToAttachPoint(AttachPointScript attachPointScript, AttachPointScript targetAttachPointScript, bool connectSymmetricParts, bool autoConcealSymmetricParts, List<(PartData PartA, PartData PartB)> connectedSymmetricParts = null)
		{
			using (Profile.ConnectPartToAttachPoint.Auto())
			{
				attachPointScript.PartScript.ConnectToPart(attachPointScript, targetAttachPointScript);
				if (!connectSymmetricParts)
				{
					return;
				}
				List<(PartData, PartData)> value;
				if (autoConcealSymmetricParts)
				{
					using (CollectionPool<List<(PartData, PartData)>, (PartData, PartData)>.Get(out value))
					{
						SymmetryUtility.ConnectSymmetricParts(attachPointScript, targetAttachPointScript, Designer.Instance.Symmetry, showConnectionFailureMessages: true, value);
						connectedSymmetricParts?.AddRange(value);
						DesignerScript designerScript = Designer.Instance.DesignerScript;
						foreach (var item2 in value)
						{
							if (!item2.Item2.VisibleInDesigner)
							{
								designerScript.AddPartToConcealedCollection(item2.Item1.PartScript);
							}
						}
						return;
					}
				}
				List<(PartData, PartData)> value2;
				using (CollectionPool<List<(PartData, PartData)>, (PartData, PartData)>.Get(out value2))
				{
					List<PartConnectionFailure> value3;
					using (CollectionPool<List<PartConnectionFailure>, PartConnectionFailure>.Get(out value3))
					{
						SymmetryUtility.ConnectSymmetricParts(attachPointScript, targetAttachPointScript, Designer.Instance.Symmetry, showConnectionFailureMessages: true, value2, value3);
						connectedSymmetricParts?.AddRange(value2);
						foreach (PartConnectionFailure item3 in value3)
						{
							value2.Add((item3.PartA, item3.PartB));
						}
						foreach (var item4 in value2)
						{
							var (partData, _) = item4;
							object obj;
							if (partData != null && !partData.VisibleInDesigner)
							{
								(obj, _) = item4;
							}
							else
							{
								PartData item = item4.Item2;
								obj = ((item != null && !item.VisibleInDesigner) ? item4.Item2 : null);
							}
							PartData partData2 = (PartData)obj;
							if (partData2 == null)
							{
								continue;
							}
							List<PartData> value4;
							using (CollectionPool<List<PartData>, PartData>.Get(out value4))
							{
								List<PartData> value5;
								using (CollectionPool<List<PartData>, PartData>.Get(out value5))
								{
									PartData partData3;
									if (partData2 != item4.Item1)
									{
										(partData3, _) = item4;
									}
									else
									{
										partData3 = item4.Item2;
									}
									PartData partData4 = partData3;
									if (partData4 != null)
									{
										value5.Add(partData4);
									}
									SymmetryUtility.GetAllConnectedParts(partData2, value4, value5);
									Designer.Instance.DesignerScript.RemovePartsFromConcealedCollection(value4);
								}
							}
						}
					}
				}
			}
		}

		public static int DetectAttachPointConnectionsAndConnect(IEnumerable<AttachPointScript> attachPoints, GameObject gameObjectOwningAttachPoints, bool connectSymmetricParts, bool autoConcealSymmetricParts)
		{
			using (Profile.DetectAttachPointConnectionsAndConnect.Auto())
			{
				gameObjectOwningAttachPoints.SetActive(value: false);
				List<(AttachPointScript, AttachPointScript)> list = new List<(AttachPointScript, AttachPointScript)>();
				foreach (AttachPointScript attachPoint in attachPoints)
				{
					if (!attachPoint.AttachPoint.IsAvailable || attachPoint.AttachPoint.SeekType == AttachPointConnectionType.None)
					{
						continue;
					}
					int num = 16384;
					if (!attachPoint.AttachPoint.IgnoreSurfaces)
					{
						num |= 0x8000;
					}
					Collider[] array = Physics.OverlapSphere(attachPoint.transform.position, 1f / 32f, num);
					if (!Designer.Instance.MakeConnectionsToInvisibleParts)
					{
						array = array.Where((Collider x) => x.GetComponentInParent<PartScript>().IsInteractable).ToArray();
					}
					AttachPointScript attachPointScript = null;
					Collider[] array2 = array;
					for (int num2 = 0; num2 < array2.Length; num2++)
					{
						AttachPointScript attachPointFromCollider = AttachPointScript.GetAttachPointFromCollider(array2[num2]);
						if (attachPointFromCollider != null && !attachPointFromCollider.AttachPoint.IsSurfaceAttachPoint && attachPointFromCollider.AttachPoint.IsAvailable && attachPointFromCollider.AttachPoint.CanReceive(attachPoint.AttachPoint))
						{
							attachPointScript = attachPointFromCollider;
							break;
						}
					}
					if (attachPointScript == null)
					{
						array2 = array;
						for (int num2 = 0; num2 < array2.Length; num2++)
						{
							AttachPointScript attachPointFromCollider2 = AttachPointScript.GetAttachPointFromCollider(array2[num2]);
							if (attachPointFromCollider2 != null && attachPointFromCollider2.AttachPoint.IsAvailable && attachPointFromCollider2.AttachPoint.CanReceive(attachPoint.AttachPoint))
							{
								attachPointScript = attachPointFromCollider2;
								break;
							}
						}
					}
					if (attachPointScript != null && attachPointScript.AttachPoint.IsAvailable)
					{
						list.Add((attachPoint, attachPointScript));
					}
				}
				gameObjectOwningAttachPoints.SetActive(value: true);
				int num3 = 0;
				foreach (var (attachPointScript2, attachPointScript3) in list)
				{
					if (attachPointScript2.AttachPoint.IsAvailable && attachPointScript3.AttachPoint.IsAvailable)
					{
						ConnectPartToAttachPoint(attachPointScript2, attachPointScript3, connectSymmetricParts, autoConcealSymmetricParts);
						num3++;
					}
				}
				return num3;
			}
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

		public void AddingNewParts(List<PartScript> partScripts, Vector3 partPosition, float grabDistance)
		{
			_addingNewPart = true;
			_grabDistance = grabDistance;
			_grabDelta = default(Vector3);
			_grabRotation = Quaternion.identity;
			ClearPartSelection();
			if (partScripts.Count == 1)
			{
				_grabRotation = partScripts[0].transform.rotation;
			}
			_selectedPartsColliding = false;
			_unnavailableSymmetricAttachPoint = null;
			_connectionMode = ConnectionMode.PartSelection;
			_partSelection = new PartSelection(partScripts, Vector3.zero, Quaternion.identity);
			_partSelection.ContainerParent.position = partPosition;
			SymmetryUtility.CreateSymmetricPartSelections(base.Designer, _partSelection, partScripts[0], rebuildValidSymmetry: true, singlePart: false, preserveConnections: false, raiseAircraftStructureChanged: true, _symmetricPartSelections);
			SetDraggingPartsFlag();
			TryEnablePowertrainView();
		}

		public override void AircraftStructureChanged()
		{
			base.AircraftStructureChanged();
			if (_dragVisualizationTool.Enabled)
			{
				_dragVisualizationTool.AircraftStructureChanged();
			}
		}

		public void DeleteSelectedParts(bool singlePart)
		{
			if (_connectionMode == ConnectionMode.AttachPoint)
			{
				return;
			}
			PartScript selectedPart = base.Designer.SelectedPart;
			if (!(selectedPart != null))
			{
				return;
			}
			if (selectedPart == base.Designer.Aircraft.MainCockpit)
			{
				base.Designer.ShowMessage("Cannot delete main cockpit");
				return;
			}
			EndPartMovement();
			PartSelection partSelection = PartSelection.CreatePartSelection(selectedPart, preserveConnections: false, null, null, singlePart);
			List<PartSelection> value;
			using (CollectionPool<List<PartSelection>, PartSelection>.Get(out value))
			{
				SymmetryUtility.CreateSymmetricPartSelections(base.Designer, partSelection, selectedPart, rebuildValidSymmetry: false, singlePart, preserveConnections: false, raiseAircraftStructureChanged: false, value);
				DeleteParts(partSelection, value);
			}
		}

		public void EndPartMovement()
		{
			_connectionMode = ConnectionMode.None;
			if (!base.IsActive)
			{
				return;
			}
			bool flag = _addingNewPart || _clone;
			bool addingNewPart = _addingNewPart;
			bool clone = _clone;
			_addingNewPart = false;
			_clone = false;
			base.CanPinch = true;
			_closestAttachPoint = null;
			base.Designer.DesignerScript.DesignerUI.HideMainUI(hide: false);
			string text = null;
			if (_partSelection != null)
			{
				foreach (PartScript part2 in _partSelection.Parts)
				{
					part2.PartMaterialScript.FoundAttachPoint = false;
				}
				foreach (PartSelection symmetricPartSelection in _symmetricPartSelections)
				{
					foreach (PartScript part3 in symmetricPartSelection.Parts)
					{
						part3.PartMaterialScript.FoundAttachPoint = false;
					}
				}
				int count = _partSelection.Parts.Count;
				int num = 0;
				bool flag2 = false;
				bool flag3 = false;
				if (count == 1)
				{
					ControlSurfacePartScript modifier = _partSelection.Parts[0].GetModifier<ControlSurfacePartScript>();
					if ((object)modifier != null)
					{
						flag2 = true;
						bool flag4 = modifier.ConnectedWing != null;
						num += (flag4 ? 1 : 0);
						modifier.OnDragEnd();
						int num2 = 0;
						foreach (PartSelection symmetricPartSelection2 in _symmetricPartSelections)
						{
							foreach (PartScript part4 in symmetricPartSelection2.Parts)
							{
								ControlSurfacePartScript modifier2 = part4.GetModifier<ControlSurfacePartScript>();
								if ((object)modifier2 != null)
								{
									if (modifier2.ConnectedWing != null)
									{
										num++;
									}
									else
									{
										num2++;
									}
									modifier2.OnDragEnd();
								}
							}
						}
						if (flag4 && modifier.PartScript.Part.SymmetryDisabled != modifier.ConnectedWing.PartScript.Part.SymmetryDisabled)
						{
							Assembly assembly = base.Designer.Aircraft.Aircraft.Assembly;
							DesignerUIScript designerUI = base.Designer.DesignerScript.DesignerUI;
							if (modifier.PartScript.Part.SymmetryDisabled)
							{
								List<PartData> value;
								using (CollectionPool<List<PartData>, PartData>.Get(out value))
								{
									SymmetryUtility.FindSymmetricParts(modifier.ConnectedWing.PartScript.Part, includeSelf: true, value);
									if (value.Count > 0)
									{
										foreach (PartData item in value)
										{
											foreach (ControlSurfacePartData item2 in item.GetModifier<JWingData>().ControlSurfacesInformational)
											{
												if (item2.Part.SymmetryId != 0)
												{
													assembly.UnlinkSymmetricParts(item2.Part.SymmetryId, disableSymmetry: true);
												}
												else
												{
													item2.SymmetryDisabled = true;
												}
											}
											if (item.SymmetryId != 0)
											{
												assembly.UnlinkSymmetricParts(item.SymmetryId, disableSymmetry: true);
											}
											else
											{
												item.SymmetryDisabled = true;
											}
										}
										designerUI.ShowMessage("A non-symmetric control surface has been attached to a symmetric wing." + System.Environment.NewLine + "Symmetry has been disabled for these wings and attached control surfaces.");
									}
								}
							}
							else if (modifier.ConnectedWing.PartScript.Part.SymmetryDisabled && modifier.PartScript.Part.SymmetryId != 0)
							{
								assembly.UnlinkSymmetricParts(modifier.PartScript.Part.SymmetryId, disableSymmetry: true);
								designerUI.ShowMessage("A symmetric control surface has been attached to a non-symmetric wing." + System.Environment.NewLine + "Symmetry has been disabled for the control surface that was just attached.");
								designerUI.UpdatePartSymmetryButtons();
							}
						}
						flag3 = flag4 && num2 > 0 && num == 1;
					}
				}
				if (base.Designer.DraggingPartsOverTrashcan())
				{
					Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerDelete);
					DeleteParts(_partSelection, _symmetricPartSelections);
				}
				else
				{
					if (base.Designer.DraggingPartsOverCreateSubassembly() && !flag)
					{
						InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
						inputDialogScript.MessageText = "Enter a name for this new subassembly." + System.Environment.NewLine + "You will be able to access it from the part menu under the <i>Subassemblies</i> category.";
						inputDialogScript.ValidationFunction = FileIOUtility.IsValidDirectoryOrFileName;
						inputDialogScript.OkayClicked += CreateSubassemblyDialog_Closed;
						inputDialogScript.CancelClicked += CreateSubassemblyDialog_Closed;
						return;
					}
					bool flag5 = true;
					if (_selectedPartsColliding)
					{
						flag5 = false;
						PartData partData = _unnavailableSymmetricAttachPoint?.Part;
						SymmetryUtility.SymmetricAttachPointsAvailability? symmetricAttachPointsAvailability = _unnavailableSymmetricAttachPoint?.Availability;
						if (_unnavailableSymmetricAttachPoint.HasValue && symmetricAttachPointsAvailability != SymmetryUtility.SymmetricAttachPointsAvailability.Available)
						{
							DesignerUIScript designerUI2 = base.Designer.DesignerScript.DesignerUI;
							if (partData != null)
							{
								if (symmetricAttachPointsAvailability == SymmetryUtility.SymmetricAttachPointsAvailability.NotFound)
								{
									designerUI2.ShowMessage($"Connection failed. A symmetric attach point on part '{partData.Name} (ID: {partData.Id})' could not be found.");
								}
								else if (symmetricAttachPointsAvailability == SymmetryUtility.SymmetricAttachPointsAvailability.NotAvailable)
								{
									designerUI2.ShowMessage($"Connection failed. A symmetric attach point on part '{partData.Name} (ID: {partData.Id})' was found but it is not currently available.");
								}
							}
							else if (_partSelection.Parts.Count == 1 && _symmetricPartSelections.Count == 1 && _symmetricPartSelections[0].Parts.Count == 1)
							{
								flag5 = true;
								flag3 = true;
								PartData part = _partSelection.Parts[0].Part;
								base.Designer.Aircraft.Aircraft.Assembly.UnlinkSymmetricParts(part.SymmetryId, disableSymmetry: true);
								designerUI2.ShowMessage($"A symmetric target part could not be found. Symmetry has been disabled for part '{part.Name} (ID: {part.Id})'");
							}
							else
							{
								designerUI2.ShowMessage("Connection failed. A symmetric target part could not be found.");
							}
						}
						_selectedPartsColliding = false;
						_unnavailableSymmetricAttachPoint = null;
						if (flag5)
						{
							foreach (PartScript part5 in _partSelection.Parts)
							{
								part5.PartMaterialScript.IsCollidingInDesigner = false;
							}
						}
						else
						{
							Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerPlacePartError);
						}
					}
					if (flag5)
					{
						bool flag6 = _symmetricPartSelections.Count > 0 && SymmetryUtility.PartsSpanSymmetricOrigin(_symmetricPartSelections[0].Parts, symmetricPartsOnly: true, base.Designer.Symmetry);
						int num3 = 0;
						if (flag6 || flag3)
						{
							num3 = DeleteSymmetricPartSelections(_symmetricPartSelections);
						}
						if (!flag2)
						{
							num = DetectAttachPointConnectionsAndConnect(_partSelection.AvailableAttachPoints, _partSelection.ContainerParent.gameObject, connectSymmetricParts: true, autoConcealSymmetricParts: true);
							if (num > 0)
							{
								foreach (PartSelection symmetricPartSelection3 in _symmetricPartSelections)
								{
									num += DetectAttachPointConnectionsAndConnect(symmetricPartSelection3.AvailableAttachPoints, symmetricPartSelection3.ContainerParent.gameObject, connectSymmetricParts: false, autoConcealSymmetricParts: false);
								}
							}
						}
						if (flag6)
						{
							SymmetryUtility.AutoLinkSymmetricParts(_partSelection, partSelectionOnly: true, ignoreSymmetryDisabled: false, base.Designer.Symmetry);
						}
						if (num == 0)
						{
							foreach (PartSelection symmetricPartSelection4 in _symmetricPartSelections)
							{
								base.Designer.DesignerScript.AddPartsToConcealedCollection(symmetricPartSelection4.Parts);
							}
						}
						if (num > 0 && _partSelection.Parts.Count >= 1 && _partSelection.Parts[0].Part.IsCockpit && !SymmetryUtility.IsConnectedToCockpit(_partSelection.Parts, ignoreSourcePartCockpits: true))
						{
							List<PartScript> value2;
							using (CollectionPool<List<PartScript>, PartScript>.Get(out value2))
							{
								SymmetryUtility.GetAllConnectedParts(_partSelection.Parts[0], value2);
								List<PartData> value3;
								using (CollectionPool<List<PartData>, PartData>.Get(out value3))
								{
									SymmetryUtility.GetAllSymmetricAndConnectedParts(value2, value3);
									base.Designer.DesignerScript.RemovePartsFromConcealedCollection(value3, updateAttachPoints: false);
								}
							}
						}
						if (num > 0)
						{
							Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerConnectPart);
						}
						else if (!flag && num3 <= 0)
						{
							Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerDropPart);
						}
						base.Designer.OnAircraftStructureChanged();
					}
					text = FormatUndoMessage(clone ? "Cloned" : (addingNewPart ? "Added" : "Moved"), _partSelection, _symmetricPartSelections, base.Designer.Symmetry);
				}
				ClearPartSelection();
				base.Designer.HideDraggingPartButtons();
				base.Designer.LockMovePart = false;
				if (!string.IsNullOrEmpty(text))
				{
					base.Designer.CreateUndoStep(text);
				}
				if (addingNewPart && base.Designer.SelectedPart != null)
				{
					OnPartAdded(base.Designer.SelectedPart, count == 1);
				}
			}
			else
			{
				base.Designer.HideDraggingPartButtons();
			}
		}

		public Vector3 FindSurfaceGridPosition(Transform t, Vector3 worldPosition)
		{
			Vector3 position = t.InverseTransformPoint(worldPosition);
			position.x = SnapToGrid(position.x, 0.0625f, centerAroundZero: true);
			position.y = SnapToGrid(position.y, 0.0625f, centerAroundZero: false);
			position.z = SnapToGrid(position.z, 0.0625f, centerAroundZero: false);
			return t.TransformPoint(position);
		}

		public override string GetAircraftInformationDisplay()
		{
			if (_dragVisualizationTool.Enabled)
			{
				return (int)_dragVisualizationTool.DragCount + " drag points";
			}
			return base.GetAircraftInformationDisplay();
		}

		public override void HandleInput(InputEvent e)
		{
			using (Profile.HandleInput.Auto())
			{
				bool userPreventPartGrab = base.Designer.UserPreventPartGrab;
				if (HoveredAttachPoint != null)
				{
					AttachPointScript attachPointScript = HoveredAttachPoint.AttachPoint.AttachPointScript;
					Ray ray = base.Designer.ScreenPointToRay(e.Position);
					if (e.InputState == InputState.Begin)
					{
						ShowCompatibleAttachPoints(attachPointScript);
						_grabDistance = Vector3.Distance(ray.origin, HoveredAttachPoint.transform.position);
						_connectionMode = ConnectionMode.AttachPoint;
						HoveredAttachPoint.Selected = true;
						TryEnablePowertrainView(attachPointScript.AttachPoint.SeekType);
					}
					else if (e.InputState == InputState.Updated)
					{
						_ = _grabDistance;
						AttachPointScript[] attachPoints = new AttachPointScript[1] { attachPointScript };
						Vector3 point = ray.GetPoint(_grabDistance);
						attachPointScript.transform.position = point;
						AttachPointScript closestAttachPoint = null;
						AttachPointScript selectedAttachPoint = null;
						Vector3 closestAttachPointPosition = Vector3.zero;
						Vector3 hitPosition = Vector3.zero;
						Vector3 closestAttachPointNormal = Vector3.zero;
						FindBestAttachPointPair(attachPoints, ref closestAttachPoint, ref selectedAttachPoint, ref closestAttachPointPosition, ref hitPosition, ref closestAttachPointNormal);
						if (closestAttachPoint != null && selectedAttachPoint == attachPointScript)
						{
							attachPointScript.transform.position = closestAttachPointPosition;
							_hoverTargetAttachPoint = closestAttachPoint;
							HoveredAttachPoint.Success = true;
						}
						else
						{
							_hoverTargetAttachPoint = null;
							HoveredAttachPoint.Success = false;
						}
						List<PartData> value;
						using (CollectionPool<List<PartData>, PartData>.Get(out value))
						{
							base.Designer.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(attachPointScript.PartScript.Part, value);
							if (value.Count == 1)
							{
								AttachPointData attachPoint = value[0].GetAttachPoint(attachPointScript.AttachPoint.Id);
								if (attachPoint != null)
								{
									Vector3 mirroredPosition = SymmetryUtility.GetMirroredPosition(attachPointScript.transform.position, base.Designer.Symmetry);
									attachPoint.AttachPointScript.transform.position = mirroredPosition;
								}
							}
						}
					}
					else if (e.InputState == InputState.End)
					{
						if (_hoverTargetAttachPoint != null)
						{
							ConnectPartToAttachPoint(attachPointScript, _hoverTargetAttachPoint, connectSymmetricParts: true, autoConcealSymmetricParts: false);
							base.Designer.OnAircraftStructureChanged();
							base.Designer.DesignerScript.DesignerUI.ShowMessage("Connection added");
							base.Designer.CreateUndoStepForSelectedPart("Connection Added");
							_hoverTargetAttachPoint = null;
						}
						else
						{
							base.Designer.CreateUndoStepForSelectedPart("Moved attach point");
						}
						RestorePowertrainView();
						_connectionMode = ConnectionMode.None;
						HoveredAttachPoint = null;
						HideCompatibleAttachPoints();
					}
				}
				else if (base.AllowPartSelection && !base.Designer.DisableMovePart)
				{
					if (e.InputState == InputState.End && (e.InputButton == InputButton.Primary || _clone))
					{
						EndPartMovement();
					}
					else if (e.InputState == InputState.Begin && !userPreventPartGrab && !UnityEngine.Input.GetKey(KeyCode.Mouse2))
					{
						_initialPart = null;
						if (!_addingNewPart)
						{
							(PartScript, RaycastHit, Ray)? partAtScreenPosition = base.Designer.GetPartAtScreenPosition(e.Position);
							if (partAtScreenPosition.HasValue)
							{
								_connectionMode = ConnectionMode.PartSelection;
								PartScript partScript = (_initialPart = partAtScreenPosition.Value.Item1);
								_grabDelta = partScript.transform.position - partAtScreenPosition.Value.Item2.point;
								_grabDistance = (partScript.transform.position - partAtScreenPosition.Value.Item3.origin).magnitude;
								_grabPosition = partScript.transform.position;
								_grabRotation = partScript.transform.rotation;
								if (e.InputButton == InputButton.Secondary)
								{
									_clone = true;
								}
								ControlSurfacePartScript modifier = partAtScreenPosition.Value.Item1.GetModifier<ControlSurfacePartScript>();
								if ((object)modifier != null && modifier.ConnectedWing != null)
								{
									_grabRotation = modifier.ConnectedWing.PartScript.transform.rotation;
								}
							}
						}
					}
					else if (e.InputState == InputState.Updated && (e.InputButton == InputButton.Primary || _clone) && !userPreventPartGrab && !UnityEngine.Input.GetKey(KeyCode.Mouse2))
					{
						if (!base.ViewPortIsMoving)
						{
							if (_partSelection == null)
							{
								if (_initialPart != null || (!_addingNewPart && e.DragDistanceSinceBegin < 20f))
								{
									PartScript partScript2 = _initialPart;
									bool buttonIfEnabled = Game.Inputs.DesignerSinglePartModifier.GetButtonIfEnabled();
									if (_clone)
									{
										if (buttonIfEnabled)
										{
											partScript2 = SymmetryUtility.DuplicatePart(partScript2.Part, mirrored: false).PartScript;
											partScript2.Part.SymmetryDisabled = base.Designer.Symmetry.SymmetryDisabledForNewParts;
										}
										else
										{
											PartSelection partSelection = PartSelection.CreatePartSelection(partScript2, preserveConnections: true, null, null, buttonIfEnabled);
											List<PartData> list = SymmetryUtility.DuplicateParts(partSelection);
											bool symmetryDisabledForNewParts = base.Designer.Symmetry.SymmetryDisabledForNewParts;
											foreach (PartData item in list)
											{
												item.SymmetryDisabled = symmetryDisabledForNewParts;
											}
											partScript2 = list[0].PartScript;
											partSelection.Deselect();
										}
									}
									_initialPart = null;
									if (partScript2 != null)
									{
										if (new PartGraph(partScript2.Part, breakOnRigidBodyBoundary: false).HasCockpit)
										{
											Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerDetachPart);
										}
										base.Designer.SelectedPart = partScript2;
										_partSelection = PartSelection.CreatePartSelection(partScript2, preserveConnections: false, null, null, buttonIfEnabled);
										SymmetryUtility.CreateSymmetricPartSelections(base.Designer, _partSelection, partScript2, rebuildValidSymmetry: true, buttonIfEnabled, preserveConnections: false, raiseAircraftStructureChanged: true, _symmetricPartSelections);
										foreach (PartSelection symmetricPartSelection in _symmetricPartSelections)
										{
											base.Designer.DesignerScript.RemovePartsFromConcealedCollection(symmetricPartSelection.Parts, updateAttachPoints: false);
										}
										TryEnablePowertrainView();
									}
								}
								else
								{
									_clone = false;
								}
								SetDraggingPartsFlag();
							}
							if (_partSelection != null)
							{
								base.CanPinch = false;
								base.Designer.DesignerScript.DesignerUI.HideMainUI(hide: true);
								if (_partSelection.Parts[0] != base.Designer.Aircraft.MainCockpit)
								{
									base.Designer.ShowDraggingPartButtons(_clone || _addingNewPart);
								}
								if (!base.Designer.LockMovePart)
								{
									Ray pointRay = base.Designer.ScreenPointToRay(e.Position);
									float num = _grabDistance;
									float num2 = (0f - (pointRay.origin.y - 0.5f)) / pointRay.direction.y;
									if (num2 > 1f && num > num2)
									{
										num = num2;
									}
									ControlSurfacePartScript controlSurfacePartScript = null;
									if (_partSelection.Parts.Count == 1)
									{
										controlSurfacePartScript = _partSelection.Parts[0].GetModifier<ControlSurfacePartScript>();
									}
									if (controlSurfacePartScript == null || !controlSurfacePartScript.IsAttachedToWing)
									{
										Vector3 vector = pointRay.origin + pointRay.direction * num;
										_partSelection.ContainerParent.position = vector + _grabDelta;
										if (GetMaxPartsPerSelection() == 1)
										{
											RotateSinglePartSelection(_grabRotation);
										}
									}
									if (controlSurfacePartScript != null)
									{
										DragControlSurface(controlSurfacePartScript, pointRay);
										if (!controlSurfacePartScript.IsAttachedToWing)
										{
											_partSelection.Parts[0].transform.localPosition = Vector3.zero;
											foreach (PartSelection symmetricPartSelection2 in _symmetricPartSelections)
											{
												if (symmetricPartSelection2.Parts.Count == 1)
												{
													symmetricPartSelection2.Parts[0].transform.localPosition = Vector3.zero;
												}
											}
										}
										bool flag = controlSurfacePartScript.IsAttachedToWing;
										foreach (PartSelection symmetricPartSelection3 in _symmetricPartSelections)
										{
											if (symmetricPartSelection3.Parts.Count != 0)
											{
												ControlSurfacePartScript modifier2 = symmetricPartSelection3.Parts[0].GetModifier<ControlSurfacePartScript>();
												if (modifier2 != null)
												{
													flag &= modifier2.IsAttachedToWing;
												}
											}
										}
										UpdateSymmetricPartsOnDrag(flag);
									}
									else
									{
										DragPart();
									}
								}
							}
						}
						else
						{
							_clone = false;
						}
					}
					else
					{
						_clone = false;
					}
				}
				if (_partSelection == null && HoveredAttachPoint == null)
				{
					base.HandleInput(e);
				}
			}
		}

		public override void MouseHover(Vector3? screenPosition)
		{
			if (base.Designer.UserPreventPartGrab)
			{
				return;
			}
			if (_connectionMode == ConnectionMode.None)
			{
				AttachPointGizmo attachPointGizmo = RaycastToAttachPointGizmo(screenPosition);
				if (attachPointGizmo != null && attachPointGizmo.AttachPoint.AttachPointScript.SupportsDragging)
				{
					HoveredAttachPoint = attachPointGizmo;
				}
				else
				{
					HoveredAttachPoint = null;
				}
			}
			base.MouseHover((HoveredAttachPoint != null) ? ((Vector3?)null) : screenPosition);
		}

		public void RebuildSymmetricSelections()
		{
			if (_partSelection == null)
			{
				return;
			}
			foreach (PartSelection symmetricPartSelection in _symmetricPartSelections)
			{
				symmetricPartSelection.Deselect();
			}
			_symmetricPartSelections.Clear();
			if (!(base.Designer.SelectedPart != null))
			{
				return;
			}
			foreach (PartScript part in _partSelection.Parts)
			{
				part.transform.parent = _partSelection.ContainerParent;
			}
			SymmetryUtility.CreateSymmetricPartSelections(base.Designer, _partSelection, base.Designer.SelectedPart, rebuildValidSymmetry: true, singlePart: false, preserveConnections: false, raiseAircraftStructureChanged: true, _symmetricPartSelections);
		}

		public void RotatePart(PartScript part, Quaternion rotation, bool singlePart, bool rotationIsTarget, bool disconnectParts, string undoStepName = null)
		{
			if (Device.IsDemoBuild)
			{
				Game.Instance.UserInterface.CreateMessageDialog("Rotating craft parts is not available in the demo version of the game.", "Not Available In Demo");
				return;
			}
			if (!part.Part.AllowTransformation || _connectionMode == ConnectionMode.AttachPoint)
			{
				base.Designer.DesignerScript.DesignerUI.ShowMessage("The '" + part.Part.Name + "' part cannot be rotated at this time.");
				return;
			}
			bool flag = _partSelection != null;
			if (!flag)
			{
				EndPartMovement();
				Quaternion value = (rotationIsTarget ? part.transform.rotation : Quaternion.identity);
				if (Game.Inputs.DesignerSinglePartModifier.GetButtonIfEnabled())
				{
					singlePart = !singlePart;
				}
				_partSelection = PartSelection.CreatePartSelection(part, !disconnectParts, value, null, singlePart);
				SymmetryUtility.CreateSymmetricPartSelections(base.Designer, _partSelection, part, rebuildValidSymmetry: false, singlePart, !disconnectParts, disconnectParts, _symmetricPartSelections);
			}
			Quaternion quaternion = rotation;
			if (flag)
			{
				quaternion = _partSelection.ContainerParent.rotation * rotation;
				if (GetMaxPartsPerSelection() == 1)
				{
					_grabRotation = quaternion;
				}
			}
			_partSelection.ContainerParent.rotation = quaternion;
			List<SymmetryTransform> value2;
			using (CollectionPool<List<SymmetryTransform>, SymmetryTransform>.Get(out value2))
			{
				SymmetryUtility.GetSymmetricTransforms(new SymmetryTransform(_partSelection.ContainerParent.position, _partSelection.ContainerParent.rotation), base.Designer.Symmetry, value2);
				if (_symmetricPartSelections.Count != value2.Count)
				{
					Debug.LogError("Unable to rotate the current symmetric part selections. " + $"The symmetric part selection count ({_symmetricPartSelections.Count}) does not match the symmetric transform count ({value2.Count}).");
					return;
				}
				for (int i = 0; i < _symmetricPartSelections.Count; i++)
				{
					PartSelection partSelection = _symmetricPartSelections[i];
					SymmetryTransform symmetryTransform = value2[i];
					partSelection.ContainerParent.rotation = symmetryTransform.Rotation;
				}
				if (flag)
				{
					return;
				}
				_partSelection.Parts.Any((PartScript x) => x.Part.IsCockpit);
				_symmetricPartSelections.Any((PartSelection s) => s.Parts.Any((PartScript x) => x.Part.IsCockpit));
				if (disconnectParts && (_symmetricPartSelections.Count <= 0 || !SymmetryUtility.PartsSpanSymmetricOrigin(_symmetricPartSelections[0].Parts, symmetricPartsOnly: true, base.Designer.Symmetry)))
				{
					int num = DetectAttachPointConnectionsAndConnect(_partSelection.AvailableAttachPoints, _partSelection.ContainerParent.gameObject, connectSymmetricParts: true, autoConcealSymmetricParts: true);
					foreach (PartSelection symmetricPartSelection in _symmetricPartSelections)
					{
						num += DetectAttachPointConnectionsAndConnect(symmetricPartSelection.AvailableAttachPoints, symmetricPartSelection.ContainerParent.gameObject, connectSymmetricParts: false, autoConcealSymmetricParts: false);
					}
					if (num > 0)
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerConnectPart);
					}
				}
				ClearPartSelection();
				base.Designer.CreateUndoStepForSelectedPart(undoStepName ?? "Rotated");
				base.Designer.OnAircraftStructureChanged();
			}
		}

		public void SetPartPosition(PartScript part, Vector3 position, bool singlePart, bool disconnectParts)
		{
			if (Device.IsDemoBuild)
			{
				Game.Instance.UserInterface.CreateMessageDialog("Moving craft parts is not available in the demo version of the game.", "Not Available In Demo");
				return;
			}
			if (!part.Part.AllowTransformation || _connectionMode == ConnectionMode.AttachPoint)
			{
				base.Designer.DesignerScript.DesignerUI.ShowMessage("The '" + part.Part.Name + "' part cannot be translated at this time.");
				return;
			}
			EndPartMovement();
			if (Game.Inputs.DesignerSinglePartModifier.GetButtonIfEnabled())
			{
				singlePart = !singlePart;
			}
			_partSelection = PartSelection.CreatePartSelection(part, !disconnectParts, null, null, singlePart);
			SymmetryUtility.CreateSymmetricPartSelections(base.Designer, _partSelection, part, rebuildValidSymmetry: false, singlePart, !disconnectParts, disconnectParts, _symmetricPartSelections);
			if (!singlePart)
			{
				CockpitData modifier = part.Part.GetModifier<CockpitData>();
				if (modifier != null && modifier.PrimaryCockpit)
				{
					Vector3 value = position - _partSelection.ContainerParent.position;
					base.Designer.UpdatePaintOrigin(value);
				}
			}
			_partSelection.ContainerParent.position = position;
			List<SymmetryTransform> value2;
			using (CollectionPool<List<SymmetryTransform>, SymmetryTransform>.Get(out value2))
			{
				SymmetryUtility.GetSymmetricTransforms(new SymmetryTransform(_partSelection.ContainerParent.position, _partSelection.ContainerParent.rotation), base.Designer.Symmetry, value2);
				if (_symmetricPartSelections.Count != value2.Count)
				{
					Debug.LogError("Unable to position the current symmetric part selections. " + $"The symmetric part selection count ({_symmetricPartSelections.Count}) does not match the symmetric transform count ({value2.Count}).");
					return;
				}
				for (int i = 0; i < _symmetricPartSelections.Count; i++)
				{
					PartSelection partSelection = _symmetricPartSelections[i];
					SymmetryTransform symmetryTransform = value2[i];
					partSelection.ContainerParent.position = symmetryTransform.Position;
				}
				bool flag = false;
				if (disconnectParts)
				{
					int num = DetectAttachPointConnectionsAndConnect(_partSelection.AvailableAttachPoints, _partSelection.ContainerParent.gameObject, connectSymmetricParts: true, autoConcealSymmetricParts: true);
					foreach (PartSelection symmetricPartSelection in _symmetricPartSelections)
					{
						num += DetectAttachPointConnectionsAndConnect(symmetricPartSelection.AvailableAttachPoints, symmetricPartSelection.ContainerParent.gameObject, connectSymmetricParts: false, autoConcealSymmetricParts: false);
					}
					if (num > 0)
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerConnectPart);
						flag = true;
					}
				}
				ClearPartSelection();
				base.Designer.CreateUndoStepForSelectedPart("Nudged");
				if (flag)
				{
					base.Designer.OnAircraftStructureChanged();
				}
			}
		}

		public override void Start()
		{
			base.Start();
			base.Designer.Symmetry.SymmetryModeChanged += SymmetryModeChanged;
		}

		public override void Stop()
		{
			EndPartMovement();
			base.Stop();
			_connectionMode = ConnectionMode.None;
			_hoverTargetAttachPoint = null;
			HoveredAttachPoint = null;
			HideCompatibleAttachPoints();
			_dragVisualizationTool.Enabled = false;
			base.Designer.Symmetry.SymmetryModeChanged -= SymmetryModeChanged;
		}

		public override void Update()
		{
			base.Update();
			if (Game.Instance.UserInterface.AllowKeyboardInputs)
			{
				HandleManualReposition();
			}
		}

		private static string FormatUndoMessage(string prefix, PartSelection partSelection, IList<PartSelection> symmetricPartSelections = null, SymmetryConfig symmetry = null)
		{
			string text = prefix;
			if (partSelection != null && partSelection.Parts.Count > 0)
			{
				int num = partSelection.Parts.Count;
				if (symmetricPartSelections != null)
				{
					foreach (PartSelection symmetricPartSelection in symmetricPartSelections)
					{
						num += symmetricPartSelection.Parts.Count;
					}
				}
				text += $" {partSelection.Parts[0].Part.Name} #{partSelection.Parts[0].Part.Id}";
				if (num > 1)
				{
					int? num2 = ((symmetry == null || symmetricPartSelections == null) ? ((int?)null) : new int?(SymmetryUtility.GetSymmetricPartGroupCount(symmetry.Mode)));
					text = ((!num2.HasValue || num != num2.Value || symmetricPartSelections.Count != num2.Value - 1) ? (text + string.Format(" and {0} other part{1}", num - 1, (num == 2) ? string.Empty : "s")) : (text + string.Format(" and {0} {1} part{2}", num - 1, (symmetry.Mode == SymmetryMode.Mirrored) ? "mirrored" : "symmetric", (num == 2) ? string.Empty : "s")));
				}
			}
			return text;
		}

		private static bool RaycastIgnoreRootTransform(Ray ray, out RaycastHit hit, float maxDistance, int layerMask, Transform ignoreRoot)
		{
			int num;
			while ((num = Physics.RaycastNonAlloc(ray, _rayHitBuffer, maxDistance, layerMask)) >= _rayHitBuffer.Length)
			{
				_rayHitBuffer = new RaycastHit[_rayHitBuffer.Length * 2];
			}
			RaycastHit? raycastHit = null;
			for (int i = 0; i < num; i++)
			{
				RaycastHit value = _rayHitBuffer[i];
				if (!(value.transform.root == ignoreRoot) && (!raycastHit.HasValue || value.distance < raycastHit.Value.distance))
				{
					raycastHit = value;
				}
			}
			hit = raycastHit.GetValueOrDefault();
			return raycastHit.HasValue;
		}

		private bool CheckSelectedPartsCollideWithPartGraph(PartScript partScript)
		{
			PartGraph partGraph = new PartGraph(partScript.Part, breakOnRigidBodyBoundary: false);
			List<PartScript> list = new List<PartScript>();
			foreach (PartData part in partGraph.Parts)
			{
				list.Add(part.PartScript);
			}
			return PartCollisionDetection.CheckIfAnyPartsCollide(_partSelection.Parts, list);
		}

		private void ClearPartSelection()
		{
			RestorePowertrainView();
			_partSelection?.Deselect();
			_partSelection = null;
			foreach (PartSelection symmetricPartSelection in _symmetricPartSelections)
			{
				symmetricPartSelection.Deselect();
			}
			_symmetricPartSelections.Clear();
		}

		private void CreateSubassemblyDialog_Closed(InputDialogScript dialog)
		{
			if (dialog.Result == InputDialogResult.Okay)
			{
				base.Designer.CreateSubassemblyFromSelectedParts(dialog.InputText);
			}
			ClearPartSelection();
			base.Designer.HideDraggingPartButtons();
			base.Designer.LockMovePart = false;
			if (base.Designer.DesignerScript.DesignerUI.FingerTool.Enabled)
			{
				base.Designer.DesignerScript.DesignerUI.FingerTool.Position = Vector3.zero;
			}
			UndoStep currentUndoStep = base.Designer.UndoHistory.CurrentUndoStep;
			if (currentUndoStep != null)
			{
				base.Designer.RestoreFromUndoStep(currentUndoStep);
			}
			else
			{
				Debug.LogError("Attempted to restore the craft state after creating a subassembly, but the current undo step was null");
			}
			dialog.Close();
		}

		private void DeleteParts(PartSelection partSelection, IList<PartSelection> symmetricPartSelections = null)
		{
			string text = FormatUndoMessage("Deleted", partSelection, symmetricPartSelections, base.Designer.Symmetry);
			bool deleteSymmetricParts = symmetricPartSelections == null;
			foreach (PartScript part in partSelection.Parts)
			{
				base.Designer.DeletePart(part, deleteSymmetricParts);
			}
			if (symmetricPartSelections != null)
			{
				DeleteSymmetricPartSelections(symmetricPartSelections);
			}
			if (partSelection != _partSelection)
			{
				partSelection.Deselect();
			}
			else
			{
				ClearPartSelection();
			}
			base.Designer.DeselectPart();
			base.Designer.OnAircraftStructureChanged();
			base.Designer.CreateUndoStep(text);
			Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerDelete);
			base.Designer.ShowMessage(text);
		}

		private int DeleteSymmetricPartSelections(IList<PartSelection> symmetricPartSelections)
		{
			List<PartScript> value;
			using (CollectionPool<List<PartScript>, PartScript>.Get(out value))
			{
				foreach (PartSelection symmetricPartSelection in symmetricPartSelections)
				{
					value.AddRange(symmetricPartSelection.Parts);
					symmetricPartSelection.Deselect();
				}
				symmetricPartSelections.Clear();
				int count = value.Count;
				foreach (PartScript item in value)
				{
					base.Designer.DeletePart(item);
				}
				return count;
			}
		}

		private void DragControlSurface(ControlSurfacePartScript controlSurface, Ray pointRay)
		{
			int layerMask = 32769;
			RaycastHit hit;
			if (controlSurface.IsAttachedToWing)
			{
				if (Physics.Raycast(pointRay, out var hitInfo, float.PositiveInfinity, layerMask))
				{
					ControlSurfacePartScript componentInParent = hitInfo.transform.GetComponentInParent<ControlSurfacePartScript>();
					if (componentInParent != null && componentInParent == controlSurface)
					{
						base.Designer.Tools.JWingTool.AttachControlSurfaceToWing(controlSurface, componentInParent.LastGeneratedWing, hitInfo);
						return;
					}
					JWingScript componentInParent2 = hitInfo.transform.GetComponentInParent<JWingScript>();
					base.Designer.Tools.JWingTool.AttachControlSurfaceToWing(controlSurface, componentInParent2, hitInfo);
				}
				else
				{
					base.Designer.Tools.JWingTool.AttachControlSurfaceToWing(controlSurface, null, default(RaycastHit));
				}
			}
			else if (RaycastIgnoreRootTransform(pointRay, out hit, float.PositiveInfinity, layerMask, _partSelection.ContainerParent))
			{
				JWingScript componentInParent3 = hit.transform.GetComponentInParent<JWingScript>();
				base.Designer.Tools.JWingTool.AttachControlSurfaceToWing(controlSurface, componentInParent3, hit);
			}
		}

		private void DragPart()
		{
			using (Profile.DragPart.Auto())
			{
				AttachPointScript closestAttachPoint = null;
				AttachPointScript selectedAttachPoint = null;
				Vector3 closestAttachPointPosition = Vector3.zero;
				Vector3 hitPosition = Vector3.zero;
				Vector3 closestAttachPointNormal = Vector3.zero;
				using (LayerUtility.TemporarilyChangeLayer((IReadOnlyList<PartScript>)_partSelection.Parts, 2, true))
				{
					foreach (PartSelection symmetricPartSelection in _symmetricPartSelections)
					{
						symmetricPartSelection.ContainerParent.gameObject.SetActive(value: false);
					}
					FindBestAttachPointPair(_partSelection.AvailableAttachPoints, ref closestAttachPoint, ref selectedAttachPoint, ref closestAttachPointPosition, ref hitPosition, ref closestAttachPointNormal);
				}
				bool flag = false;
				bool flag2 = false;
				if (closestAttachPoint != null)
				{
					if (selectedAttachPoint.AttachPoint.AllowRotation && GetMaxPartsPerSelection() == 1)
					{
						MatchTargetRotation(selectedAttachPoint, selectedAttachPoint.AttachPoint.IgnoreGrid ? hitPosition : closestAttachPointPosition, closestAttachPointNormal, closestAttachPoint);
						flag2 = true;
						PartScript partScript = _partSelection.Parts[0];
						if (partScript.HasModifier<WingScript>())
						{
							List<PartData> value;
							using (CollectionPool<List<PartData>, PartData>.Get(out value))
							{
								if (partScript.Part.SymmetryId != 0)
								{
									partScript.Aircraft.Aircraft.Assembly.GetSymmetricParts(partScript.Part, value);
								}
								else
								{
									value.Add(partScript.Part);
								}
								foreach (PartData item in value)
								{
									WingScript modifier = item.PartScript.GetModifier<WingScript>();
									if (modifier == null)
									{
										Debug.LogError($"An error occurred dragging wing part '{partScript.Part.Id}' with symmetric parts. The WingScript modifier could not be found on symmetric part '{item.Id}'");
										continue;
									}
									bool flag3 = false;
									float z = item.PartScript.transform.localRotation.eulerAngles.z;
									if (Utilities.CompareFloats(z, 270f, 1f) && !modifier.Wing.Inverted)
									{
										flag3 = true;
									}
									else if (Utilities.CompareFloats(z, 90f, 1f) && modifier.Wing.Inverted)
									{
										flag3 = true;
									}
									if (flag3)
									{
										modifier.Wing.Inverted = !modifier.Wing.Inverted;
										Vector3 tipPosition = modifier.Wing.TipPosition;
										tipPosition.x = 0f - tipPosition.x;
										modifier.UpdateWingPoint(tipPosition, WingScript.WingPointType.TipPosition);
									}
								}
							}
						}
						if (CheckCollisionsOnDrag)
						{
							flag = CheckSelectedPartsCollideWithPartGraph(closestAttachPoint.PartScript);
						}
					}
					else
					{
						PreviewPosition(selectedAttachPoint, closestAttachPointPosition, _closestAttachPoint, hitPosition);
						if (!closestAttachPoint.AttachPoint.IsSurfaceAttachPoint)
						{
							flag2 = true;
						}
						else if ((closestAttachPointPosition - hitPosition).magnitude < 1f)
						{
							flag2 = true;
						}
						if (CheckCollisionsOnDrag)
						{
							flag = CheckSelectedPartsCollideWithPartGraph(closestAttachPoint.PartScript);
						}
					}
					if (_closestAttachPoint != closestAttachPoint)
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerDragPart);
					}
				}
				_closestAttachPoint = closestAttachPoint;
				UpdateSymmetricPartsOnDrag(flag2);
				bool isCollidingInDesigner = false;
				_unnavailableSymmetricAttachPoint = null;
				if (selectedAttachPoint != null && _closestAttachPoint != null && !flag)
				{
					PartData unavailableSymmetricPart;
					SymmetryUtility.SymmetricAttachPointsAvailability symmetricAttachPointsAvailability = SymmetryUtility.GetSymmetricAttachPointsAvailability(selectedAttachPoint.AttachPoint, _closestAttachPoint.AttachPoint, base.Designer.Symmetry, out unavailableSymmetricPart);
					if (symmetricAttachPointsAvailability != SymmetryUtility.SymmetricAttachPointsAvailability.Available)
					{
						flag = true;
						isCollidingInDesigner = true;
						_unnavailableSymmetricAttachPoint = (unavailableSymmetricPart, symmetricAttachPointsAvailability);
					}
				}
				foreach (PartSelection symmetricPartSelection2 in _symmetricPartSelections)
				{
					foreach (PartScript part in symmetricPartSelection2.Parts)
					{
						part.PartMaterialScript.IsCollidingInDesigner = isCollidingInDesigner;
					}
				}
				if (flag != _selectedPartsColliding)
				{
					_selectedPartsColliding = flag;
					if (flag)
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerDragPartPositionError);
					}
					else
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerDragPart);
					}
				}
				foreach (PartScript part2 in _partSelection.Parts)
				{
					part2.PartMaterialScript.IsCollidingInDesigner = _selectedPartsColliding;
					part2.PartMaterialScript.FoundAttachPoint = flag2;
				}
			}
		}

		private void FindBestAttachPointPair(IEnumerable<AttachPointScript> attachPoints, ref AttachPointScript closestAttachPoint, ref AttachPointScript selectedAttachPoint, ref Vector3 closestAttachPointPosition, ref Vector3 hitPosition, ref Vector3 closestAttachPointNormal)
		{
			closestAttachPoint = null;
			selectedAttachPoint = null;
			float num = float.MaxValue;
			foreach (AttachPointScript attachPoint in attachPoints)
			{
				if (!attachPoint.gameObject.activeSelf || attachPoint.AttachPoint.SeekType == AttachPointConnectionType.None)
				{
					continue;
				}
				List<RaycastHit> value;
				using (CollectionPool<List<RaycastHit>, RaycastHit>.Get(out value))
				{
					GetHitResults(attachPoint, value);
					foreach (RaycastHit item in value)
					{
						if (AttachPointScript.TryGetAttachPointFromCollider(item.collider, out var result) && result.AttachPoint.CanReceive(attachPoint.AttachPoint) && (!result.AttachPoint.FuselageConnection || attachPoint.AttachPoint.FuselageConnection))
						{
							Vector3 zero = Vector3.zero;
							Vector3 zero2 = Vector3.zero;
							bool flag = false;
							if (!result.AttachPoint.IsSurfaceAttachPoint)
							{
								flag = ((!(Vector3.Dot(attachPoint.WorldNormal, result.WorldNormal) > -0.97f)) ? result.AttachPoint.IsAvailable : ((attachPoint.AttachPoint.AllowRotation || attachPoint.AttachPoint.IgnoreNormalAlignment || result.AttachPoint.IgnoreNormalAlignment) && result.AttachPoint.IsAvailable));
								zero = result.transform.position;
								zero2 = result.WorldNormal;
							}
							else
							{
								zero = (UnityEngine.Input.GetKey(KeyCode.LeftShift) ? item.point : FindSurfaceGridPosition(item.collider.transform, item.point));
								zero2 = ((attachPoint.AttachPoint.AllowRotation && attachPoint.AttachPoint.IgnoreGrid) ? item.normal : ((Mathf.Abs(item.normal.x) > Mathf.Abs(item.normal.y) && Mathf.Abs(item.normal.x) > Mathf.Abs(item.normal.z)) ? (Vector3.right * Mathf.Sign(item.normal.x)) : ((!(Mathf.Abs(item.normal.y) > Mathf.Abs(item.normal.z))) ? (Vector3.forward * Mathf.Sign(item.normal.z)) : (Vector3.up * Mathf.Sign(item.normal.y)))));
								flag = !(Vector3.Dot(attachPoint.WorldNormal, zero2) > -0.97f) || attachPoint.AttachPoint.AllowRotation || attachPoint.AttachPoint.IgnoreNormalAlignment || result.AttachPoint.IgnoreNormalAlignment;
							}
							if (flag && item.distance < num)
							{
								num = item.distance;
								closestAttachPoint = result;
								closestAttachPointPosition = zero;
								selectedAttachPoint = attachPoint;
								hitPosition = item.point;
								closestAttachPointNormal = zero2;
							}
						}
					}
				}
			}
		}

		private void GetHitResults(AttachPointScript attachPoint, List<RaycastHit> hits)
		{
			using (Profile.GetHitResults.Auto())
			{
				Ray ray = base.Designer.WorldPointToRay(attachPoint.transform.position);
				int num = 16384;
				if (!attachPoint.AttachPoint.IgnoreSurfaces)
				{
					num |= 0x8000;
				}
				List<RaycastHit> value;
				using (CollectionPool<List<RaycastHit>, RaycastHit>.Get(out value))
				{
					if (attachPoint.AttachPoint.IgnoreGrid)
					{
						PhysicsUtility.RaycastAll(ray, 10000f, num, value);
					}
					else
					{
						PhysicsUtility.SphereCastAll(ray, 0.05f, 10000f, num, value);
					}
					if (hits.Capacity < value.Count)
					{
						hits.Capacity = value.Count;
					}
					foreach (RaycastHit item in value)
					{
						if (item.collider.gameObject.GetComponentInParent<PartScript>().IsInteractable)
						{
							hits.Add(item);
						}
					}
					hits.Sort((RaycastHit x, RaycastHit y) => x.distance.CompareTo(y.distance));
				}
			}
		}

		private int GetMaxPartsPerSelection()
		{
			int num = _partSelection.Parts.Count;
			foreach (PartSelection symmetricPartSelection in _symmetricPartSelections)
			{
				num = Mathf.Max(num, symmetricPartSelection.Parts.Count);
			}
			return num;
		}

		private void HandleManualReposition()
		{
			if (Game.Instance.UserInterface.AllowKeyboardInputs && base.Designer.SelectedPart != null)
			{
				NumericSetting<float> nudgeDistance = Game.Instance.Settings.Gameplay.Designer.NudgeDistance;
				bool flag = _manualRepositionTimer <= 0f;
				GameInputs instance = GameInputs.Instance;
				Vector3 zero = Vector3.zero;
				zero += HandleManualRepositionForKey(instance.NudgePartPositiveZ, new Vector3(0f, 0f, nudgeDistance));
				zero += HandleManualRepositionForKey(instance.NudgePartNegativeZ, new Vector3(0f, 0f, 0f - (float)nudgeDistance));
				zero += HandleManualRepositionForKey(instance.NudgePartNegativeX, new Vector3(0f - (float)nudgeDistance, 0f, 0f));
				zero += HandleManualRepositionForKey(instance.NudgePartPositiveX, new Vector3(nudgeDistance, 0f, 0f));
				zero += HandleManualRepositionForKey(instance.NudgePartNegativeY, new Vector3(0f, 0f - (float)nudgeDistance, 0f));
				zero += HandleManualRepositionForKey(instance.NudgePartPositiveY, new Vector3(0f, nudgeDistance, 0f));
				switch (base.Designer.DesignerScript.PartManipulationMode)
				{
				case PartManipulationMode.TranslateX:
					zero += HandleManualRepositionForKey(instance.DesignerManipulatePartNegative, new Vector3(0f - (float)nudgeDistance, 0f, 0f));
					zero += HandleManualRepositionForKey(instance.DesignerManipulatePartPositive, new Vector3(nudgeDistance, 0f, 0f));
					break;
				case PartManipulationMode.TranslateY:
					zero += HandleManualRepositionForKey(instance.DesignerManipulatePartNegative, new Vector3(0f, 0f - (float)nudgeDistance, 0f));
					zero += HandleManualRepositionForKey(instance.DesignerManipulatePartPositive, new Vector3(0f, nudgeDistance, 0f));
					break;
				case PartManipulationMode.TranslateZ:
					zero += HandleManualRepositionForKey(instance.DesignerManipulatePartNegative, new Vector3(0f, 0f, nudgeDistance));
					zero += HandleManualRepositionForKey(instance.DesignerManipulatePartPositive, new Vector3(0f, 0f, 0f - (float)nudgeDistance));
					break;
				}
				if (zero.sqrMagnitude > 0f)
				{
					if (flag)
					{
						Vector3 position = base.PartScript.transform.position + zero;
						bool singlePart = !InConnectedMode;
						SetPartPosition(base.PartScript, position, singlePart, disconnectParts: false);
					}
				}
				else
				{
					_manualRepositionTimer = 0f;
				}
			}
			if (_manualRepositionTimer > 0f)
			{
				_manualRepositionTimer -= Time.deltaTime;
			}
		}

		private Vector3 HandleManualRepositionForKey(IGameInput input, Vector3 repositionAmount)
		{
			if (input.GetButtonIfEnabled())
			{
				if (UnityEngine.Input.GetKey(KeyCode.LeftControl) || UnityEngine.Input.GetKey(KeyCode.RightControl))
				{
					repositionAmount *= 10f;
				}
				if (input.GetButtonDownIfEnabled())
				{
					_manualRepositionTimer = 0.75f;
				}
				return repositionAmount;
			}
			return Vector3.zero;
		}

		private void HideCompatibleAttachPoints()
		{
			foreach (AttachPointScript compatibleAttachPoint in _compatibleAttachPoints)
			{
				compatibleAttachPoint.ShowGizmo(show: false);
			}
			_compatibleAttachPoints.Clear();
		}

		private void MatchTargetRotation(AttachPointScript selectedAttachPoint, Vector3 attachmentPosition, Vector3 closestAttachPointNormal, AttachPointScript targetAttachPoint)
		{
			Vector3 vector = -closestAttachPointNormal;
			bool preferUpwardsOrientation = selectedAttachPoint.AttachPoint.PreferUpwardsOrientation;
			Vector3 vector2 = (preferUpwardsOrientation ? Vector3.up : Vector3.forward);
			if (Mathf.Abs(Vector3.Dot(vector2, vector)) >= 0.9f)
			{
				vector2 = (preferUpwardsOrientation ? Vector3.forward : Vector3.up);
			}
			GameObject gameObject = new GameObject("AttachPointRotation");
			gameObject.transform.SetPositionAndRotation(selectedAttachPoint.transform.position, selectedAttachPoint.transform.rotation);
			_partSelection.ContainerParent.SetParent(gameObject.transform, worldPositionStays: true);
			gameObject.transform.SetPositionAndRotation(attachmentPosition, Quaternion.LookRotation(vector, vector2));
			_partSelection.ContainerParent.SetParent(null, worldPositionStays: true);
			UnityEngine.Object.Destroy(gameObject);
			foreach (PartScript part in _partSelection.Parts)
			{
				RotateSymmetricParts(part);
			}
			OnPreviewPartPosition(selectedAttachPoint, targetAttachPoint);
		}

		private void OnPartAdded(PartScript partScript, bool singlePart)
		{
			Action<IFlyout> action = null;
			if ((object)partScript.GetModifier<TextureDecalScript>() != null)
			{
				action = delegate
				{
					TextureProperty textureProperty = PartPropertiesPanelScript.GetPropertiesByType<TextureDecalData>()?.GetProperty<TextureProperty>("_decalId");
					if (textureProperty != null)
					{
						textureProperty.RefreshUI();
						textureProperty.OpenTexturePicker();
					}
				};
			}
			if (action != null)
			{
				DesignerUIScript designerUI = base.Designer.DesignerScript.DesignerUI;
				designerUI.Flyouts.SelectFlyoutAndQueueAction(designerUI.Flyouts.PartProperties, action);
			}
		}

		private void OnPreviewPartPosition(AttachPointScript selectedAttachPoint, AttachPointScript targetAttachPoint)
		{
			foreach (PartScript part in _partSelection.Parts)
			{
				try
				{
					if (selectedAttachPoint != null && targetAttachPoint != null)
					{
						part.PreviewDesignerPlacement(selectedAttachPoint.AttachPoint, targetAttachPoint.AttachPoint, _partSelection);
					}
				}
				catch (Exception ex)
				{
					Debug.LogError("PreviewDesignerPlacement Error: " + ex.Message);
				}
			}
		}

		private void PreviewPosition(AttachPointScript selectedAttachPoint, Vector3 targetAttachPointGridPosition, AttachPointScript targetAttachPoint, Vector3 hitPosition)
		{
			Vector3 vector = targetAttachPointGridPosition - selectedAttachPoint.transform.position;
			if (selectedAttachPoint.AttachPoint.IgnoreGrid)
			{
				vector = hitPosition - selectedAttachPoint.transform.position;
			}
			_partSelection.ContainerParent.position += vector;
			OnPreviewPartPosition(selectedAttachPoint, targetAttachPoint);
		}

		private AttachPointGizmo RaycastToAttachPointGizmo(Vector2? screenPos)
		{
			if (screenPos.HasValue && Physics.Raycast(base.CameraController.Camera.ScreenPointToRay(screenPos.Value), out var hitInfo, 10000f, 1024) && hitInfo.transform.TryGetComponent<AttachPointGizmo>(out var component))
			{
				return component;
			}
			return null;
		}

		private void RestorePowertrainView()
		{
			if (_savedViewMode.HasValue)
			{
				base.Designer.ViewMode = _savedViewMode.Value;
				_savedViewMode = null;
			}
		}

		private void RotateSinglePartSelection(Quaternion rotation)
		{
			int maxPartsPerSelection = GetMaxPartsPerSelection();
			if (maxPartsPerSelection != 1)
			{
				Debug.LogError($"Attempted to rotate a single part selection with '{maxPartsPerSelection}' parts selected in at least one of the current selections.");
				return;
			}
			PartScript partScript = _partSelection.Parts[0];
			partScript.UpdateRotationForAttachment(rotation);
			RotateSymmetricParts(partScript);
		}

		private void RotateSymmetricParts(PartScript part)
		{
			if (base.Designer.Symmetry.Mode == SymmetryMode.Disabled)
			{
				return;
			}
			List<SymmetryTransform> value;
			using (CollectionPool<List<SymmetryTransform>, SymmetryTransform>.Get(out value))
			{
				SymmetryUtility.GetSymmetricTransforms(part.Part, base.Designer.Symmetry, value);
				if (_symmetricPartSelections.Count != value.Count)
				{
					Debug.LogError($"Unable to auto-rotate symmetric part '{part.Part.Id}'. " + $"The symmetric part selection count ({_symmetricPartSelections.Count}) does not match the symmetric transform count ({value.Count}).");
				}
				for (int i = 0; i < value.Count; i++)
				{
					PartSelection partSelection = _symmetricPartSelections[i];
					if (partSelection.Parts.Count == 1)
					{
						partSelection.Parts[0].UpdateRotationForAttachment(value[i].Rotation);
					}
				}
			}
		}

		private void SetDraggingPartsFlag()
		{
			if (_partSelection == null)
			{
				return;
			}
			foreach (PartScript part in _partSelection.Parts)
			{
				part.IsDragging = true;
			}
			foreach (PartSelection symmetricPartSelection in _symmetricPartSelections)
			{
				foreach (PartScript part2 in symmetricPartSelection.Parts)
				{
					part2.IsDragging = true;
				}
			}
		}

		private void ShowCompatibleAttachPoints(AttachPointScript hoverAttachPoint)
		{
			foreach (PartData item in base.Designer.Aircraft.Parts.Concat(base.Designer.Aircraft.InitiallyDisconnectedParts))
			{
				if (item == hoverAttachPoint.PartScript.Part || !item.VisibleInDesigner)
				{
					continue;
				}
				foreach (AttachPointData attachPoint in item.AttachPoints)
				{
					if (attachPoint.IsAvailable && attachPoint.CanReceive(hoverAttachPoint.AttachPoint))
					{
						_compatibleAttachPoints.Add(attachPoint.AttachPointScript);
						attachPoint.AttachPointScript.ShowGizmo(show: true);
					}
				}
			}
		}

		private void SymmetryModeChanged(object sender, SymmetryModeChangeEventArgs e)
		{
			if (base.Designer.SelectedPart == null)
			{
				Debug.LogError("Symmetry mode was changed while having an active part selection but not having a selected part.");
			}
			RebuildSymmetricSelections();
		}

		private void TryEnablePowertrainView()
		{
			TryEnablePowertrainView(_partSelection.IsSeekExclusivelyPowertrain);
		}

		private void TryEnablePowertrainView(AttachPointConnectionType seekType)
		{
			AttachPointConnectionType attachPointConnectionType = (AttachPointConnectionType)176;
			bool condition = seekType != AttachPointConnectionType.None && (seekType & ~attachPointConnectionType) == 0;
			TryEnablePowertrainView(condition);
		}

		private void TryEnablePowertrainView(bool condition)
		{
			if (base.Designer.ViewMode != DesignerViewMode.Powertrain && condition)
			{
				_savedViewMode = base.Designer.ViewMode;
				base.Designer.ViewMode = DesignerViewMode.Powertrain;
			}
		}

		private void UpdateSymmetricPartsOnDrag(bool connected)
		{
			using (Profile.UpdateSymmetricPartsOnDrag.Auto())
			{
				if (_partSelection == null)
				{
					return;
				}
				Vector3 position = _partSelection.ContainerParent.transform.position;
				Quaternion rotation = _partSelection.ContainerParent.transform.rotation;
				List<SymmetryTransform> value;
				using (CollectionPool<List<SymmetryTransform>, SymmetryTransform>.Get(out value))
				{
					SymmetryUtility.GetSymmetricTransforms(new SymmetryTransform(position, rotation), base.Designer.Symmetry, value);
					if (value.Count != _symmetricPartSelections.Count)
					{
						Debug.LogError($"Symmetric transform count '{value.Count}' does not match symmetric part selection count '{_symmetricPartSelections.Count}'");
						return;
					}
					for (int i = 0; i < value.Count; i++)
					{
						SymmetryTransform symmetryTransform = value[i];
						_symmetricPartSelections[i].ContainerParent.position = symmetryTransform.Position;
					}
					bool flag = connected;
					if (connected)
					{
						bool flag2 = _symmetricPartSelections.Count > 0 && SymmetryUtility.PartsSpanSymmetricOrigin(_symmetricPartSelections[0].Parts, symmetricPartsOnly: true, base.Designer.Symmetry);
						flag = flag && !flag2;
					}
					for (int j = 0; j < value.Count; j++)
					{
						_symmetricPartSelections[j].ContainerParent.gameObject.SetActive(flag);
					}
				}
			}
		}
	}
}
