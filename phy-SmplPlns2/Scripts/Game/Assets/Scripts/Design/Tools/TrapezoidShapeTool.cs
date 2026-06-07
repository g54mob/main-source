using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers.CarverParts;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.UI.Wings;
using Assets.Scripts.Input.Events;
using Assets.Scripts.UI;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class TrapezoidShapeTool : DesignerTool
	{
		public enum EditMode
		{
			Trapezium = 0,
			Rectangle = 1
		}

		public const float DefaultSnap = 0.05f;

		private int _activeGizmos;

		private EditMode _editMode;

		private TrapezoidMeshModifierData _currentData;

		private TrapezoidMeshModifierScript _currentScript;

		private WingGizmoScript _draggingGizmo;

		private GameObject _gizmoPrefab;

		private List<WingGizmoScript> _gizmos = new List<WingGizmoScript>();

		private WingGizmoScript _hoverGizmo;

		public float MinScaleUnit
		{
			get
			{
				if (SnapDistance != 0f)
				{
					return SnapDistance;
				}
				return 0.05f;
			}
		}

		public float SnapDistance { get; set; } = 0.05f;

		public EditMode Mode
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
					UpdateGizmos();
				}
			}
		}

		private WingGizmoScript HoverGizmo
		{
			get
			{
				return _hoverGizmo;
			}
			set
			{
				if (_hoverGizmo != value)
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

		public TrapezoidShapeTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowFingerAid = false;
			base.AllowPartSelection = true;
			_gizmoPrefab = Resources.Load<GameObject>("Designer/JWingGizmo");
		}

		public static WingGizmoScript GetGizmo(Ray ray)
		{
			WingGizmoScript result = null;
			if (Physics.Raycast(ray, out var hitInfo, float.PositiveInfinity, 1024))
			{
				result = hitInfo.transform.GetComponentInParent<WingGizmoScript>();
			}
			return result;
		}

		public override void HandleInput(InputEvent e)
		{
			if (e.InputButton != InputButton.Primary)
			{
				base.HandleInput(e);
				return;
			}
			bool flag = UnityEngine.Input.GetKey(KeyCode.LeftControl) || UnityEngine.Input.GetKey(KeyCode.RightControl);
			if (e.InputState == InputState.Begin && !flag)
			{
				if (_draggingGizmo != null)
				{
					_draggingGizmo.OnDragEnd();
					_draggingGizmo = null;
				}
				WingGizmoScript gizmo = GetGizmo(e.Ray);
				if (gizmo != null)
				{
					base.PartScript.PartMaterialScript.SetSelected(selected: false, updateSymmetricParts: true);
					gizmo.OnDragStart(e.Ray);
					_draggingGizmo = gizmo;
					base.AllowPartSelection = false;
					return;
				}
			}
			else if (e.InputState == InputState.Updated)
			{
				if (_draggingGizmo != null)
				{
					_draggingGizmo.OnDragContinue(e.Ray);
					return;
				}
			}
			else if (e.InputState == InputState.End && _draggingGizmo != null)
			{
				_draggingGizmo.OnDragEnd();
				base.PartScript.PartMaterialScript.SetSelected(selected: true, updateSymmetricParts: true);
				int num = _gizmos.IndexOf(_draggingGizmo);
				_draggingGizmo = null;
				base.Designer.CreateUndoStepForSelectedPart("Modified shape", $"TrapezoidToolHandle-{num}");
				base.AllowPartSelection = true;
			}
			base.HandleInput(e);
		}

		public override void MouseHover(Vector3? screenPosition)
		{
			if (screenPosition.HasValue)
			{
				Ray ray = base.CameraController.Camera.ScreenPointToRay(screenPosition.Value);
				HoverGizmo = GetGizmo(ray);
			}
			base.MouseHover((HoverGizmo == null) ? screenPosition : ((Vector3?)null));
		}

		public override void Start()
		{
			base.Start();
			base.Designer.HighlightedPart = null;
			base.Designer.SelectedPartChangedEvent += OnSelectedPartChanged;
			OnSelectedPartChanged(base.Designer.SelectedPart);
			base.Designer.DesignerScript.DesignerUI.SetEditingState(editing: true);
			base.Designer.DesignerScript.DesignerUI.DoneEditingButtonClicked += OnDoneEditingButtonClicked;
		}

		public override void Stop()
		{
			HoverGizmo = null;
			ResetGizmos(0);
			base.Stop();
			base.Designer.SelectedPartChangedEvent -= OnSelectedPartChanged;
			base.Designer.DesignerScript.DesignerUI.SetEditingState(editing: false);
			base.Designer.DesignerScript.DesignerUI.DoneEditingButtonClicked -= OnDoneEditingButtonClicked;
		}

		public override void Update()
		{
			if (_currentData != null && _currentData.Part.PartScript == null)
			{
				_currentScript = null;
				_currentData = null;
				base.Designer.Tools.SelectMovePartTool();
			}
		}

		private Vector3 GetCentrePoint(bool top)
		{
			return new Vector3(math.csum(top ? _currentData.UpperSpan : _currentData.LowerSpan) * 0.5f, _currentData.Height * (top ? 0.5f : (-0.5f)), 0f);
		}

		private Vector3 GetCornerPoint(bool top, bool left)
		{
			float2 float5 = (top ? _currentData.UpperSpan : _currentData.LowerSpan);
			return new Vector3(left ? float5.x : float5.y, _currentData.Height * (top ? 0.5f : (-0.5f)), 0f);
		}

		private Vector3 GetSideCentrePoint(bool left)
		{
			float2 float5 = 0.5f * (_currentData.UpperSpan + _currentData.LowerSpan);
			return new Vector3(left ? float5.x : float5.y, 0f, 0f);
		}

		private void OnDoneEditingButtonClicked()
		{
			base.Designer.Tools.SelectMovePartTool();
		}

		private void OnSelectedPartChanged(PartScript newPart)
		{
			if (newPart != null)
			{
				TrapezoidMeshModifierScript modifier = newPart.GetModifier<TrapezoidMeshModifierScript>();
				if (modifier != null)
				{
					_currentScript = modifier;
					_currentData = modifier.Data;
					RaiseSelectionChange();
					return;
				}
			}
			base.Designer.Tools.SelectMovePartTool();
		}

		private void RaiseSelectionChange(bool dataOnlyChange = false)
		{
			if (!dataOnlyChange)
			{
				UpdateGizmos();
				Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerStartGizmoTool);
			}
		}

		private void RepositionPart(TrapezoidMeshModifierData modifier, PartScript part, Pose newPose)
		{
			part.transform.SetGlobalPose(newPose);
			if (modifier.SymmetryDisabled)
			{
				return;
			}
			List<SymmetryTransform> value;
			using (CollectionPool<List<SymmetryTransform>, SymmetryTransform>.Get(out value))
			{
				List<PartData> value2;
				using (CollectionPool<List<PartData>, PartData>.Get(out value2))
				{
					SymmetryUtility.FindSymmetricParts(part.Part, includeSelf: false, value2);
					if (value2.Count == 0)
					{
						return;
					}
					SymmetryUtility.GetSymmetricTransforms(new SymmetryTransform(newPose.position, newPose.rotation), base.Designer.Symmetry, value);
					if (value2.Count != value.Count)
					{
						Debug.LogError("Unsupported symmetry operation");
						return;
					}
					for (int i = 0; i < value.Count; i++)
					{
						SymmetryTransform symmetryTransform = value[i];
						PoseUtility.SetGlobalPose(pose: new Pose(symmetryTransform.Position, symmetryTransform.Rotation), transform: value2[i].PartScript.transform);
					}
				}
			}
		}

		private void ResetGizmos(int size)
		{
			if (_activeGizmos > size)
			{
				for (int i = size; i < _activeGizmos; i++)
				{
					_gizmos[i].gameObject.SetActive(value: false);
				}
			}
			else
			{
				while (_activeGizmos < size)
				{
					if (_gizmos.Count > _activeGizmos)
					{
						_gizmos[_activeGizmos++].gameObject.SetActive(value: true);
						continue;
					}
					_gizmos.Add(Object.Instantiate(_gizmoPrefab).GetComponent<WingGizmoScript>());
					_activeGizmos++;
				}
			}
			_activeGizmos = size;
			for (int j = 0; j < size; j++)
			{
				_gizmos[j].ResetTime();
			}
		}

		private void SetCentrePoint(bool top, Vector3 localPos)
		{
			float2 x = _currentData.Height * math.float2(-0.5f, 0.5f);
			x[top ? 1 : 0] = localPos.y;
			if (x.y - x.x <= MinScaleUnit)
			{
				x[top ? 1 : 0] = (top ? (x.x + MinScaleUnit) : (x.y - MinScaleUnit));
			}
			float height = x.y - x.x;
			float y = math.csum(x) * 0.5f;
			Vector3 vector = _currentScript.transform.TransformVector(new Vector3(0f, y));
			Pose worldPose = _currentScript.transform.GetWorldPose();
			worldPose.position += vector;
			RepositionPart(_currentData, _currentScript.PartScript, worldPose);
			_currentData.Height = height;
			_currentData.SyncSymmetricParts();
		}

		private void SetCornerPoint(bool top, bool left, Vector3 localPos)
		{
			bool buttonIfEnabled = Game.Inputs.DesignerSinglePartModifier.GetButtonIfEnabled();
			SetCornerPoint(buttonIfEnabled || top, buttonIfEnabled || !top, left, localPos);
		}

		private void SetCornerPoint(bool top, bool bottom, bool left, Vector3 localPos)
		{
			float x = localPos.x;
			float2 upperSpan = _currentData.UpperSpan;
			float2 lowerSpan = _currentData.LowerSpan;
			float2 float5 = upperSpan;
			float2 float6 = lowerSpan;
			if (top)
			{
				float5 = ClampSize(upperSpan, x, float6);
			}
			if (bottom)
			{
				float6 = ClampSize(lowerSpan, x, float5);
			}
			float num = math.csum(float5 + float6) * 0.25f;
			float6 -= num;
			float5 -= num;
			Pose worldPose = _currentScript.transform.GetWorldPose();
			worldPose.position += _currentScript.transform.TransformVector(new Vector3(num, 0f, 0f));
			RepositionPart(_currentData, _currentScript.PartScript, worldPose);
			_currentData.UpperSpan = float5;
			_currentData.LowerSpan = float6;
			_currentData.SyncSymmetricParts();
			float2 ClampSize(float2 old, float value, float2 other)
			{
				float num2 = other.y - other.x;
				float2 result = old;
				result[(!left) ? 1 : 0] = value;
				float num3 = (((top && bottom) || num2 < MinScaleUnit) ? MinScaleUnit : 0f);
				if (result.y - result.x < num3)
				{
					result[(!left) ? 1 : 0] = (left ? (result.y - num3) : (result.x + num3));
				}
				return result;
			}
		}

		private float Snap(float x)
		{
			float snapDistance = SnapDistance;
			if (snapDistance <= 0f)
			{
				return x;
			}
			return math.round(x / snapDistance) * snapDistance;
		}

		private Vector3 Snap(Vector3 x)
		{
			float snapDistance = SnapDistance;
			if (snapDistance <= 0f)
			{
				return x;
			}
			return math.round(x / snapDistance) * snapDistance;
		}

		private void UpdateGizmos()
		{
			if (_currentData == null)
			{
				return;
			}
			if (_currentData != null)
			{
				if (_editMode == EditMode.Trapezium)
				{
					ResetGizmos(6);
					_gizmos[0].Configure(() => ToWorld(GetCentrePoint(top: true)), delegate(Vector3 p)
					{
						SetCentrePoint(top: true, FromWorld(p));
					}, () => Direction(Vector3.up), () => Direction(Vector3.right), secondaryFree: false);
					_gizmos[1].Configure(() => ToWorld(GetCentrePoint(top: false)), delegate(Vector3 p)
					{
						SetCentrePoint(top: false, FromWorld(p));
					}, () => Direction(Vector3.down), () => Direction(Vector3.right), secondaryFree: false);
					_gizmos[2].Configure(() => ToWorld(GetCornerPoint(top: true, left: true)), delegate(Vector3 p)
					{
						SetCornerPoint(top: true, left: true, FromWorld(p));
					}, () => Direction(Vector3.left), () => Direction(Vector3.up), secondaryFree: false);
					_gizmos[3].Configure(() => ToWorld(GetCornerPoint(top: true, left: false)), delegate(Vector3 p)
					{
						SetCornerPoint(top: true, left: false, FromWorld(p));
					}, () => Direction(Vector3.right), () => Direction(Vector3.up), secondaryFree: false);
					_gizmos[4].Configure(() => ToWorld(GetCornerPoint(top: false, left: true)), delegate(Vector3 p)
					{
						SetCornerPoint(top: false, left: true, FromWorld(p));
					}, () => Direction(Vector3.left), () => Direction(Vector3.up), secondaryFree: false);
					_gizmos[5].Configure(() => ToWorld(GetCornerPoint(top: false, left: false)), delegate(Vector3 p)
					{
						SetCornerPoint(top: false, left: false, FromWorld(p));
					}, () => Direction(Vector3.right), () => Direction(Vector3.forward), secondaryFree: false);
				}
				else
				{
					ResetGizmos(4);
					_gizmos[0].Configure(() => ToWorld(GetCentrePoint(top: true)), delegate(Vector3 p)
					{
						SetCentrePoint(top: true, FromWorld(p));
					}, () => Direction(Vector3.up), () => Direction(Vector3.right), secondaryFree: false);
					_gizmos[1].Configure(() => ToWorld(GetCentrePoint(top: false)), delegate(Vector3 p)
					{
						SetCentrePoint(top: false, FromWorld(p));
					}, () => Direction(Vector3.down), () => Direction(Vector3.right), secondaryFree: false);
					_gizmos[2].Configure(() => ToWorld(GetSideCentrePoint(left: true)), delegate(Vector3 p)
					{
						SetCornerPoint(top: true, bottom: true, left: true, FromWorld(p));
					}, () => Direction(Vector3.left), () => Direction(Vector3.up), secondaryFree: false);
					_gizmos[3].Configure(() => ToWorld(GetSideCentrePoint(left: false)), delegate(Vector3 p)
					{
						SetCornerPoint(top: true, bottom: true, left: false, FromWorld(p));
					}, () => Direction(Vector3.right), () => Direction(Vector3.up), secondaryFree: false);
				}
			}
			else
			{
				ResetGizmos(0);
			}
			Vector3 Direction(Vector3 local)
			{
				return _currentData.Part.PartScript.transform.rotation * local;
			}
			Vector3 FromWorld(Vector3 world)
			{
				if (_currentData.Part.PartScript == null)
				{
					return world;
				}
				Transform transform = _currentData.Part.PartScript.transform;
				Vector3 vector = transform.InverseTransformPoint(world);
				Vector3 vector2 = transform.InverseTransformPoint(Vector3.zero);
				return Snap(vector - vector2) + vector2;
			}
			Vector3 ToWorld(Vector3 local)
			{
				if (_currentData.Part.PartScript == null)
				{
					return local;
				}
				return _currentData.Part.PartScript.transform.TransformPoint(local);
			}
		}
	}
}
