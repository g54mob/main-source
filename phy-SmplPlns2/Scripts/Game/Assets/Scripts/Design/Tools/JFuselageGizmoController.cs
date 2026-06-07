using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.UI.Wings;
using Assets.Scripts.Input.Events;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class JFuselageGizmoController
	{
		public enum FuselageGizmoID
		{
			None = 0,
			FrontWidth = 1,
			BackWidth = 2,
			FrontHeight = 3,
			BackHeight = 4,
			BackLength = 5,
			FrontLength = 6
		}

		private readonly Designer _designer;

		private readonly GameObject _gizmoPrefab;

		private readonly List<WingGizmoScript> _gizmos = new List<WingGizmoScript>();

		private readonly JFuselageTool _tool;

		private int _activeGizmos;

		private WingGizmoScript _companionGizmo;

		private WingGizmoScript _draggingGizmo;

		private bool _dragHadChanges;

		private WingGizmoScript _hoverGizmo;

		private bool _sectionAltDragCaptured;

		private Vector3 _sectionAltDragStartCenter;

		private Vector3 _sectionAltDragStartP;

		private float _sectionAltDragStartRise;

		private float _sectionAltDragStartRun;

		private bool _sectionShiftDragCaptured;

		private float _sectionShiftDragStartHeight;

		private Vector3 _sectionShiftDragStartP;

		private float _sectionShiftDragStartWidth;

		private bool _sliceAltDragWasHeld;

		private bool _sliceShiftDragCaptured;

		private Vector3 _sliceShiftDragStartCenterA;

		private Vector3 _sliceShiftDragStartCenterB;

		private float _sliceShiftDragStartHeight;

		private Vector3 _sliceShiftDragStartP;

		private float _sliceShiftDragStartRiseA;

		private float _sliceShiftDragStartRiseB;

		private float _sliceShiftDragStartRunA;

		private float _sliceShiftDragStartRunB;

		private float _sliceShiftDragStartWidth;

		public bool IsDragging => _draggingGizmo != null;

		public Action OnDragged { get; set; }

		public float SnapDistance => _tool.SnapDistance;

		private WingGizmoScript HoverGizmo
		{
			get
			{
				return _hoverGizmo;
			}
			set
			{
				if (!(_hoverGizmo == value))
				{
					if (_hoverGizmo != null)
					{
						_hoverGizmo.Highlighted = false;
					}
					_hoverGizmo = value;
					if (_hoverGizmo != null)
					{
						_hoverGizmo.Highlighted = true;
					}
				}
			}
		}

		private float MinDimension
		{
			get
			{
				if (!(SnapDistance > 0f))
				{
					return 0.05f;
				}
				return SnapDistance;
			}
		}

		public JFuselageGizmoController(JFuselageTool tool, Designer designer)
		{
			_tool = tool;
			_designer = designer;
			_gizmoPrefab = Resources.Load<GameObject>("Designer/JWingGizmo");
			tool.OnSelectionChanged += OnSelectionChanged;
		}

		public void Dispose()
		{
			_tool.OnSelectionChanged -= OnSelectionChanged;
			SetCompanionSelected(selected: false);
			_companionGizmo = null;
			ResetGizmos(0);
		}

		public void EnableTutorialHighlight(FuselageGizmoID gizmoID, bool enable = true)
		{
			for (int i = 0; i < _gizmos.Count; i++)
			{
				WingGizmoScript wingGizmoScript = _gizmos[i];
				if (wingGizmoScript != null)
				{
					if (enable)
					{
						wingGizmoScript.TutorialSubdued = wingGizmoScript.Id != (int?)gizmoID;
					}
					else
					{
						wingGizmoScript.TutorialSubdued = false;
					}
				}
			}
		}

		public WingGizmoScript HandleHover(Vector3? screenPosition)
		{
			if (screenPosition.HasValue)
			{
				WingGizmoScript gizmo = TrapezoidShapeTool.GetGizmo(_designer.CameraController.Camera.ScreenPointToRay(screenPosition.Value));
				HoverGizmo = ((gizmo != null && IsOwnGizmo(gizmo)) ? gizmo : null);
			}
			else
			{
				HoverGizmo = null;
			}
			return _hoverGizmo;
		}

		public bool HandleInput(InputEvent e)
		{
			if (e.InputButton != InputButton.Primary)
			{
				return false;
			}
			bool flag = UnityEngine.Input.GetKey(KeyCode.LeftControl) || UnityEngine.Input.GetKey(KeyCode.RightControl);
			if (e.InputState == InputState.Begin && !flag)
			{
				if (_draggingGizmo != null)
				{
					_draggingGizmo.OnDragEnd();
					_draggingGizmo = null;
				}
				_sectionAltDragCaptured = false;
				_sectionShiftDragCaptured = false;
				_sliceShiftDragCaptured = false;
				_sliceAltDragWasHeld = false;
				_dragHadChanges = false;
				WingGizmoScript gizmo = TrapezoidShapeTool.GetGizmo(e.Ray);
				if (gizmo != null && IsOwnGizmo(gizmo))
				{
					_tool.AllowPartSelection = false;
					gizmo.OnDragStart(e.Ray);
					_draggingGizmo = gizmo;
					_companionGizmo = GetCompanionGizmo(_gizmos.IndexOf(gizmo));
					return true;
				}
			}
			else if (e.InputState == InputState.Updated)
			{
				if (_draggingGizmo != null)
				{
					_draggingGizmo.OnDragContinue(e.Ray);
					_dragHadChanges = true;
					OnDragged?.Invoke();
					return true;
				}
			}
			else if (e.InputState == InputState.End && _draggingGizmo != null)
			{
				SetCompanionSelected(selected: false);
				_companionGizmo = null;
				_tool.AllowPartSelection = true;
				_draggingGizmo.OnDragEnd();
				if (_dragHadChanges)
				{
					_tool.TrackGizmoUndo(_draggingGizmo.name);
					_dragHadChanges = false;
				}
				_draggingGizmo = null;
				return true;
			}
			return false;
		}

		public void Update()
		{
			if (!(_draggingGizmo == null))
			{
				bool companionSelected = UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift);
				SetCompanionSelected(companionSelected);
			}
		}

		private void ConfigureSectionLengthGizmo(WingGizmoScript gizmo, JFuselageTool.SectionSelection section, JFuselageData fuselage, bool isFront)
		{
			int movingSlice = (isFront ? 1 : 0);
			int fixedSlice = ((!isFront) ? 1 : 0);
			gizmo.name = "Length";
			gizmo.GridSize = () => SnapDistance;
			gizmo.Id = (isFront ? 6 : 5);
			gizmo.Configure(() => GetSliceFaceCenter(fuselage, movingSlice), delegate(Vector3 p)
			{
				PartScript partScript = fuselage.Part.PartScript;
				if (!(partScript == null))
				{
					Vector3 forward = partScript.transform.forward;
					Vector3 sliceFaceCenter = GetSliceFaceCenter(fuselage, fixedSlice);
					float num = (isFront ? 1f : (-1f));
					float num2 = num * Vector3.Dot(p - sliceFaceCenter, forward);
					if (num2 < MinDimension)
					{
						num2 = MinDimension;
						Vector3 offset = fuselage.Offset;
						offset.z = num2;
						p = sliceFaceCenter + num * offset;
					}
					Vector3 positionDelta = (p + sliceFaceCenter) / 2f - partScript.transform.position;
					section.SetLengthFromGizmo(num2, positionDelta);
				}
			}, delegate
			{
				Vector3 vector = fuselage.Part.PartScript?.transform.forward ?? Vector3.forward;
				return (!isFront) ? (-vector) : vector;
			}, () => fuselage.Part.PartScript?.transform.up ?? Vector3.up, secondaryFree: false, Constants.Colors.AxisForward);
		}

		private void ConfigureSectionSizeGizmo(WingGizmoScript gizmo, JFuselageData fuselage, int sliceIndex, JFuselageTool.SliceSelection thisSlice, JFuselageTool.SectionSelection thisSectionSel, bool isY, FuselageGizmoID gizmoID)
		{
			gizmo.name = ((sliceIndex == 0) ? "Back " : "Front ") + (isY ? "Height" : "Width");
			gizmo.Id = (int)gizmoID;
			gizmo.Configure(delegate
			{
				PartScript partScript = fuselage.Part.PartScript;
				if (partScript == null)
				{
					return Vector3.zero;
				}
				Vector3 sliceFaceCenter = GetSliceFaceCenter(fuselage, sliceIndex);
				Vector3 vector = (isY ? partScript.transform.up : partScript.transform.right);
				float num = (isY ? (thisSlice.GetHeight() * 0.5f) : (thisSlice.GetWidth() * 0.5f));
				return sliceFaceCenter + vector * num;
			}, delegate(Vector3 p)
			{
				PartScript partScript = fuselage.Part.PartScript;
				if (!(partScript == null))
				{
					Vector3 sliceFaceCenter = GetSliceFaceCenter(fuselage, sliceIndex);
					Vector3 vector = (isY ? partScript.transform.up : partScript.transform.right);
					bool num = UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift);
					bool flag = UnityEngine.Input.GetKey(KeyCode.LeftAlt) || UnityEngine.Input.GetKey(KeyCode.RightAlt);
					if (num)
					{
						_sectionAltDragCaptured = false;
						if (!_sectionShiftDragCaptured)
						{
							_sectionShiftDragStartP = p;
							_sectionShiftDragStartHeight = thisSlice.GetHeight();
							_sectionShiftDragStartWidth = thisSlice.GetWidth();
							_sectionShiftDragCaptured = true;
						}
						float num2 = Vector3.Dot(p - _sectionShiftDragStartP, vector);
						thisSlice.SetHeight(Snap(Mathf.Max(_sectionShiftDragStartHeight + num2, MinDimension)), trackUndo: false);
						thisSlice.SetWidth(Snap(Mathf.Max(_sectionShiftDragStartWidth + num2, MinDimension)), trackUndo: false);
					}
					else if (flag)
					{
						_sectionShiftDragCaptured = false;
						if (!_sectionAltDragCaptured)
						{
							_sectionAltDragStartP = p;
							_sectionAltDragStartRise = thisSectionSel.GetRise();
							_sectionAltDragStartRun = thisSectionSel.GetRun();
							_sectionAltDragStartCenter = partScript.transform.position;
							_sectionAltDragCaptured = true;
						}
						float num3 = Vector3.Dot(p - _sectionAltDragStartP, vector);
						float num4 = (fuselage.SliceIsFront(sliceIndex) ? 1f : (-1f));
						if (isY)
						{
							float num5 = Snap(_sectionAltDragStartRise + num4 * num3);
							float num6 = (num5 - _sectionAltDragStartRise) / num4;
							Vector3 vector2 = _sectionAltDragStartCenter + vector * (num6 / 2f);
							thisSectionSel.SetRiseEdgeFromGizmo(num5, vector2 - partScript.transform.position);
						}
						else
						{
							float num7 = Snap(_sectionAltDragStartRun + num4 * num3);
							float num8 = (num7 - _sectionAltDragStartRun) / num4;
							Vector3 vector3 = _sectionAltDragStartCenter + vector * (num8 / 2f);
							thisSectionSel.SetRunEdgeFromGizmo(num7, vector3 - partScript.transform.position);
						}
					}
					else
					{
						_sectionShiftDragCaptured = false;
						_sectionAltDragCaptured = false;
						float num9 = Vector3.Dot(p - sliceFaceCenter, vector);
						float value = Snap(Mathf.Max(num9 * 2f, MinDimension));
						if (isY)
						{
							thisSlice.SetHeight(value, trackUndo: false);
						}
						else
						{
							thisSlice.SetWidth(value, trackUndo: false);
						}
					}
				}
			}, () => (!isY) ? (fuselage.Part.PartScript?.transform.right ?? Vector3.right) : (fuselage.Part.PartScript?.transform.up ?? Vector3.up), () => (!isY) ? (fuselage.Part.PartScript?.transform.up ?? Vector3.up) : (fuselage.Part.PartScript?.transform.right ?? Vector3.right), secondaryFree: false, isY ? Constants.Colors.AxisUp : Constants.Colors.AxisRight);
		}

		private void ConfigureSliceLengthGizmo(WingGizmoScript gizmo, JFuselageData fuselageA, int sliceIndexA, JFuselageTool.SectionSelection sectionASel, JFuselageData fuselageB, int sliceIndexB, JFuselageTool.SectionSelection sectionBSel)
		{
			gizmo.name = "Length";
			gizmo.GridSize = () => SnapDistance;
			gizmo.Configure(() => GetSliceFaceCenter(fuselageA, sliceIndexA), delegate(Vector3 p)
			{
				PartScript partScript = fuselageA.Part.PartScript;
				if (!(partScript == null))
				{
					Vector3 sliceFaceCenter = GetSliceFaceCenter(fuselageA, 1 - sliceIndexA);
					float num = (fuselageA.SliceIsFront(sliceIndexA) ? 1f : (-1f));
					PartScript partScript2 = fuselageB?.Part.PartScript;
					Vector3 vector = ((partScript2 != null) ? GetSliceFaceCenter(fuselageB, 1 - sliceIndexB) : Vector3.zero);
					float num2 = ((fuselageB != null && fuselageB.SliceIsFront(sliceIndexB)) ? 1f : (-1f));
					if (num * Vector3.Dot(p - sliceFaceCenter, partScript.transform.forward) < MinDimension)
					{
						Vector3 offset = fuselageA.Offset;
						offset.z = MinDimension;
						p = sliceFaceCenter + num * offset;
					}
					if (sectionBSel != null && partScript2 != null && num2 * Vector3.Dot(p - vector, partScript2.transform.forward) < MinDimension)
					{
						Vector3 offset2 = fuselageB.Offset;
						offset2.z = MinDimension;
						p = vector + num2 * offset2;
					}
					float value = num * Vector3.Dot(p - sliceFaceCenter, partScript.transform.forward);
					sectionASel.SetLengthFromGizmo(value, (sliceFaceCenter + p) / 2f - partScript.transform.position);
					if (sectionBSel != null && partScript2 != null)
					{
						float value2 = num2 * Vector3.Dot(p - vector, partScript2.transform.forward);
						sectionBSel.SetLengthFromGizmo(value2, (vector + p) / 2f - partScript2.transform.position);
					}
				}
			}, delegate
			{
				Vector3 vector = fuselageA.Part.PartScript?.transform.forward ?? Vector3.forward;
				return (sliceIndexA != 1) ? (-vector) : vector;
			}, () => fuselageA.Part.PartScript?.transform.up ?? Vector3.up, secondaryFree: false, Constants.Colors.AxisForward);
		}

		private void ConfigureSliceSizeGizmo(WingGizmoScript gizmo, JFuselageTool.SliceSelection slice, JFuselageData fuselageA, int sliceIndexA, JFuselageTool.SectionSelection sectionASel, JFuselageData fuselageB, int sliceIndexB, JFuselageTool.SectionSelection sectionBSel, bool isY, bool isPositive)
		{
			gizmo.name = (isY ? "Height" : "Width");
			gizmo.GridSize = () => SnapDistance;
			gizmo.Configure(delegate
			{
				PartScript partScript = fuselageA.Part.PartScript;
				if (partScript == null)
				{
					return Vector3.zero;
				}
				Vector3 sliceFaceCenter = GetSliceFaceCenter(fuselageA, sliceIndexA);
				Vector3 vector = (isY ? partScript.transform.up : partScript.transform.right);
				float num = (isY ? (slice.GetHeight() * 0.5f) : (slice.GetWidth() * 0.5f));
				return sliceFaceCenter + vector * (isPositive ? num : (0f - num));
			}, delegate(Vector3 p)
			{
				PartScript partScript = fuselageA.Part.PartScript;
				if (!(partScript == null))
				{
					Vector3 sliceFaceCenter = GetSliceFaceCenter(fuselageA, sliceIndexA);
					Vector3 vector = (isY ? partScript.transform.up : partScript.transform.right);
					Vector3 vector2 = (isPositive ? vector : (-vector));
					bool num = UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift);
					bool flag = UnityEngine.Input.GetKey(KeyCode.LeftAlt) || UnityEngine.Input.GetKey(KeyCode.RightAlt);
					if (num)
					{
						_sliceShiftDragCaptured = false;
						float num2 = Vector3.Dot(p - sliceFaceCenter, vector2);
						float value = Snap(Mathf.Max(num2 * 2f, MinDimension));
						if (isY)
						{
							slice.SetHeight(value, trackUndo: false);
						}
						else
						{
							slice.SetWidth(value, trackUndo: false);
						}
					}
					else
					{
						if (flag != _sliceAltDragWasHeld)
						{
							_sliceShiftDragCaptured = false;
							_sliceAltDragWasHeld = flag;
						}
						if (!_sliceShiftDragCaptured)
						{
							_sliceShiftDragStartP = p;
							_sliceShiftDragStartRiseA = sectionASel.GetRise();
							_sliceShiftDragStartRunA = sectionASel.GetRun();
							_sliceShiftDragStartRiseB = sectionBSel?.GetRise() ?? 0f;
							_sliceShiftDragStartRunB = sectionBSel?.GetRun() ?? 0f;
							_sliceShiftDragStartWidth = slice.GetWidth();
							_sliceShiftDragStartHeight = slice.GetHeight();
							_sliceShiftDragStartCenterA = partScript.transform.position;
							_sliceShiftDragStartCenterB = fuselageB?.Part.PartScript?.transform.position ?? Vector3.zero;
							_sliceShiftDragCaptured = true;
						}
						float num3 = Vector3.Dot(p - _sliceShiftDragStartP, vector2);
						float num4 = (fuselageA.SliceIsFront(sliceIndexA) ? 1f : (-1f));
						if (flag)
						{
							float run = _sliceShiftDragStartRunA + num4 * num3 * Vector3.Dot(vector2, partScript.transform.right);
							float rise = _sliceShiftDragStartRiseA + num4 * num3 * Vector3.Dot(vector2, partScript.transform.up);
							Vector3 vector3 = _sliceShiftDragStartCenterA + vector2 * (num3 / 2f);
							sectionASel.SetRiseAndRunEdgeFromGizmo(rise, run, vector3 - partScript.transform.position);
							if (sectionBSel != null && fuselageB?.Part.PartScript != null)
							{
								PartScript partScript2 = fuselageB.Part.PartScript;
								float num5 = (fuselageB.SliceIsFront(sliceIndexB) ? 1f : (-1f));
								float run2 = _sliceShiftDragStartRunB + num5 * num3 * Vector3.Dot(vector2, partScript2.transform.right);
								float rise2 = _sliceShiftDragStartRiseB + num5 * num3 * Vector3.Dot(vector2, partScript2.transform.up);
								Vector3 vector4 = _sliceShiftDragStartCenterB + vector2 * (num3 / 2f);
								sectionBSel.SetRiseAndRunEdgeFromGizmo(rise2, run2, vector4 - partScript2.transform.position);
							}
						}
						else
						{
							float num6 = (isPositive ? 1f : (-1f));
							float num7 = num4 * num6 * num3 / 2f;
							Vector3 positionDelta = _sliceShiftDragStartCenterA + vector2 * (num3 / 4f) - partScript.transform.position;
							if (isY)
							{
								float value2 = _sliceShiftDragStartRiseA + num7;
								float value3 = Snap(Mathf.Max(_sliceShiftDragStartHeight + num3, MinDimension));
								sectionASel.SetRiseEdgeFromGizmo(value2, positionDelta);
								slice.SetHeight(value3, trackUndo: false);
							}
							else
							{
								float value4 = _sliceShiftDragStartRunA + num7;
								float value5 = Snap(Mathf.Max(_sliceShiftDragStartWidth + num3, MinDimension));
								sectionASel.SetRunEdgeFromGizmo(value4, positionDelta);
								slice.SetWidth(value5, trackUndo: false);
							}
							if (sectionBSel != null && fuselageB?.Part.PartScript != null)
							{
								PartScript partScript3 = fuselageB.Part.PartScript;
								float num8 = (fuselageB.SliceIsFront(sliceIndexB) ? 1f : (-1f));
								float num9 = num3 / 2f;
								float run3 = _sliceShiftDragStartRunB + num8 * num9 * Vector3.Dot(vector2, partScript3.transform.right);
								float rise3 = _sliceShiftDragStartRiseB + num8 * num9 * Vector3.Dot(vector2, partScript3.transform.up);
								Vector3 positionDelta2 = _sliceShiftDragStartCenterB + vector2 * (num3 / 4f) - partScript3.transform.position;
								sectionBSel.SetRiseAndRunEdgeFromGizmo(rise3, run3, positionDelta2);
							}
						}
					}
				}
			}, delegate
			{
				PartScript partScript = fuselageA.Part.PartScript;
				if (partScript == null)
				{
					return Vector3.up;
				}
				Vector3 vector = (isY ? partScript.transform.up : partScript.transform.right);
				return (!isPositive) ? (-vector) : vector;
			}, delegate
			{
				PartScript partScript = fuselageA.Part.PartScript;
				return (!isY) ? (partScript?.transform.up ?? Vector3.up) : (partScript?.transform.right ?? Vector3.right);
			}, secondaryFree: false, isY ? Constants.Colors.AxisUp : Constants.Colors.AxisRight);
		}

		private WingGizmoScript GetCompanionGizmo(int draggingIndex)
		{
			int num = ((_tool.Section == null) ? (draggingIndex switch
			{
				1 => 2, 
				2 => 1, 
				3 => 4, 
				4 => 3, 
				_ => -1, 
			}) : ((draggingIndex < 4) ? (draggingIndex ^ 1) : (-1)));
			if (num < 0 || num >= _activeGizmos)
			{
				return null;
			}
			return _gizmos[num];
		}

		private Vector3 GetSliceFaceCenter(JFuselageData fuselage, int sliceIndex)
		{
			return fuselage.JFuselageScript.transform.TransformPoint(fuselage.Offset / 2f * ((sliceIndex == 0) ? (-1f) : 1f));
		}

		private bool IsOwnGizmo(WingGizmoScript gizmo)
		{
			for (int i = 0; i < _activeGizmos; i++)
			{
				if (_gizmos[i] == gizmo)
				{
					return true;
				}
			}
			return false;
		}

		private void OnSelectionChanged()
		{
			UpdateGizmos();
			_tool.AllowPartSelection = true;
		}

		private void ResetGizmos(int size)
		{
			for (int i = size; i < _activeGizmos; i++)
			{
				_gizmos[i].gameObject.SetActive(value: false);
			}
			while (_activeGizmos < size)
			{
				if (_gizmos.Count > _activeGizmos)
				{
					_gizmos[_activeGizmos].gameObject.SetActive(value: true);
				}
				else
				{
					_gizmos.Add(UnityEngine.Object.Instantiate(_gizmoPrefab).GetComponent<WingGizmoScript>());
				}
				_activeGizmos++;
			}
			_activeGizmos = size;
			if (_draggingGizmo == null)
			{
				for (int j = 0; j < size; j++)
				{
					_gizmos[j].ResetTime();
				}
			}
		}

		private void SetCompanionSelected(bool selected)
		{
			if (!(_companionGizmo == null) && _companionGizmo.Selected != selected)
			{
				_companionGizmo.Selected = selected;
			}
		}

		private float Snap(float value)
		{
			float snapDistance = SnapDistance;
			if (!(snapDistance <= 0f))
			{
				return math.round(value / snapDistance) * snapDistance;
			}
			return value;
		}

		private void UpdateGizmos()
		{
			JFuselageTool.SectionSelection section = _tool.Section;
			JFuselageTool.SliceSelection slice = _tool.Slice;
			if (section != null)
			{
				UpdateSectionGizmos(section);
			}
			else if (slice != null)
			{
				UpdateSliceGizmos(slice);
			}
			else
			{
				ResetGizmos(0);
			}
		}

		private void UpdateSectionGizmos(JFuselageTool.SectionSelection section)
		{
			JFuselageData primaryFuselage = section.PrimaryFuselage;
			if (primaryFuselage?.Part.PartScript == null)
			{
				ResetGizmos(0);
				return;
			}
			AttachPointData attachPoint = primaryFuselage.GetAttachPoint(0);
			AttachPointData attachPoint2 = primaryFuselage.GetAttachPoint(1);
			bool num = attachPoint != null && !attachPoint.IsAvailable;
			bool flag = attachPoint2 == null || attachPoint2.IsAvailable;
			bool flag2 = !num;
			int size = 4 + (flag ? 1 : 0) + (flag2 ? 1 : 0);
			ResetGizmos(size);
			JFuselageTool.SliceSelection sliceSelection = new JFuselageTool.SliceSelection(_tool);
			sliceSelection.Set(primaryFuselage, _designer, 0);
			JFuselageTool.SliceSelection sliceSelection2 = new JFuselageTool.SliceSelection(_tool);
			sliceSelection2.Set(primaryFuselage, _designer, 1);
			int num2 = 0;
			ConfigureSectionSizeGizmo(_gizmos[num2++], primaryFuselage, 0, sliceSelection, section, isY: true, FuselageGizmoID.BackHeight);
			ConfigureSectionSizeGizmo(_gizmos[num2++], primaryFuselage, 0, sliceSelection, section, isY: false, FuselageGizmoID.BackWidth);
			ConfigureSectionSizeGizmo(_gizmos[num2++], primaryFuselage, 1, sliceSelection2, section, isY: true, FuselageGizmoID.FrontHeight);
			ConfigureSectionSizeGizmo(_gizmos[num2++], primaryFuselage, 1, sliceSelection2, section, isY: false, FuselageGizmoID.FrontWidth);
			if (flag)
			{
				ConfigureSectionLengthGizmo(_gizmos[num2++], section, primaryFuselage, isFront: true);
			}
			if (flag2)
			{
				ConfigureSectionLengthGizmo(_gizmos[num2++], section, primaryFuselage, isFront: false);
			}
		}

		private void UpdateSliceGizmos(JFuselageTool.SliceSelection slice)
		{
			JFuselageData primaryFuselage = slice.PrimaryFuselage;
			int primarySliceIndex = slice.PrimarySliceIndex;
			if (primaryFuselage?.Part.PartScript == null)
			{
				ResetGizmos(0);
				return;
			}
			JFuselageTool.SectionSelection sectionSelection = new JFuselageTool.SectionSelection(_tool);
			sectionSelection.Set(primaryFuselage, _designer, 0);
			JFuselageData neighbourFuselage = null;
			int neighbourSliceIndex = 0;
			JFuselageTool.SectionSelection sectionSelection2 = null;
			if (primaryFuselage.SyncSlice(primarySliceIndex) && primaryFuselage.TryGetNeighbour(primarySliceIndex, out neighbourFuselage, out neighbourSliceIndex))
			{
				if (!neighbourFuselage.SyncSlice(neighbourSliceIndex))
				{
					neighbourFuselage = null;
				}
				else
				{
					sectionSelection2 = new JFuselageTool.SectionSelection(_tool);
					sectionSelection2.Set(neighbourFuselage, _designer, 0);
				}
			}
			ResetGizmos(5);
			int num = 0;
			ConfigureSliceLengthGizmo(_gizmos[num++], primaryFuselage, primarySliceIndex, sectionSelection, neighbourFuselage, neighbourSliceIndex, sectionSelection2);
			ConfigureSliceSizeGizmo(_gizmos[num++], slice, primaryFuselage, primarySliceIndex, sectionSelection, neighbourFuselage, neighbourSliceIndex, sectionSelection2, isY: true, isPositive: true);
			ConfigureSliceSizeGizmo(_gizmos[num++], slice, primaryFuselage, primarySliceIndex, sectionSelection, neighbourFuselage, neighbourSliceIndex, sectionSelection2, isY: true, isPositive: false);
			ConfigureSliceSizeGizmo(_gizmos[num++], slice, primaryFuselage, primarySliceIndex, sectionSelection, neighbourFuselage, neighbourSliceIndex, sectionSelection2, isY: false, isPositive: true);
			ConfigureSliceSizeGizmo(_gizmos[num++], slice, primaryFuselage, primarySliceIndex, sectionSelection, neighbourFuselage, neighbourSliceIndex, sectionSelection2, isY: false, isPositive: false);
		}
	}
}
