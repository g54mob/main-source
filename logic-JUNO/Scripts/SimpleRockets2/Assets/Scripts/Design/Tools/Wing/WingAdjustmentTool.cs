using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tools.Wing
{
	public class WingAdjustmentTool : WingTool
	{
		public enum EditType
		{
			Dihedral = 0,
			Shape = 1
		}

		private PartCollisionDetector _collisionDetector;

		private Vector3 _dragStartWingPointPosition;

		private EditType _editType;

		public ControlSurfaceTool ControlSurfaceTool { get; set; }

		public EditType CurrentEditType
		{
			get
			{
				return _editType;
			}
			set
			{
				_editType = value;
				EditTypeChanged(value);
			}
		}

		public override bool IsBaseTool => false;

		public PartCollisionDetector PartCollisionDetector => _collisionDetector;

		public bool ThicknessGizmoEnabled { get; set; } = true;

		public WingAdjustmentTool(DesignerScript designer)
			: base(designer)
		{
			_editType = EditType.Shape;
			_collisionDetector = new PartCollisionDetector();
		}

		public override void Activate()
		{
			base.Activate();
			_collisionDetector.AddPartSelection(base.SelectedPart);
			CreateGizmos();
		}

		public override void Deactivate()
		{
			base.Deactivate();
			_collisionDetector.ClearPartSelection();
		}

		protected override bool CanEditPart(IPartScript part, RaycastHit? hit)
		{
			if (part.GameObject.GetComponent<WingScript>() != null)
			{
				return !ControlSurfaceTool.Active;
			}
			return false;
		}

		protected override void CreateGizmos()
		{
			WingScript wingScript = base.SelectedPart.GetModifier<WingScript>();
			if (!wingScript)
			{
				return;
			}
			Transform transform = wingScript.transform;
			if (CurrentEditType == EditType.Shape)
			{
				CreateAdjustmentGizmo(transform, -wingScript.Forward, restrictForwardAftMovement: false, restrictLateralMovement: true, restrictVerticalMovement: true, delegate(Vector3 position)
				{
					UpdateWingPoint(position, WingScript.WingPointType.RootTrailingEdge);
				}, () => GetWingPoint(wingScript.RootTrailingEdge), delegate
				{
					OnGizmoMoveStarted(WingScript.WingPointType.RootTrailingEdge);
				}, delegate
				{
					OnGizmoMoveCompleted(WingScript.WingPointType.RootTrailingEdge);
				});
				CreateAdjustmentGizmo(transform, wingScript.Forward, restrictForwardAftMovement: false, restrictLateralMovement: true, restrictVerticalMovement: true, delegate(Vector3 position)
				{
					UpdateWingPoint(position, WingScript.WingPointType.RootLeadingEdge);
				}, () => GetWingPoint(wingScript.RootLeadingEdge), delegate
				{
					OnGizmoMoveStarted(WingScript.WingPointType.RootLeadingEdge);
				}, delegate
				{
					OnGizmoMoveCompleted(WingScript.WingPointType.RootLeadingEdge);
				});
				CreateAdjustmentGizmo(transform, wingScript.Forward, restrictForwardAftMovement: false, restrictLateralMovement: true, restrictVerticalMovement: true, delegate(Vector3 position)
				{
					UpdateWingPoint(position, WingScript.WingPointType.TipLeadingEdge);
				}, () => GetWingPoint(wingScript.TipLeadingEdge), delegate
				{
					OnGizmoMoveStarted(WingScript.WingPointType.TipLeadingEdge);
				}, delegate
				{
					OnGizmoMoveCompleted(WingScript.WingPointType.TipLeadingEdge);
				});
				CreateAdjustmentGizmo(transform, -wingScript.Forward, restrictForwardAftMovement: false, restrictLateralMovement: true, restrictVerticalMovement: true, delegate(Vector3 position)
				{
					UpdateWingPoint(position, WingScript.WingPointType.TipTrailingEdge);
				}, () => GetWingPoint(wingScript.TipTrailingEdge), delegate
				{
					OnGizmoMoveStarted(WingScript.WingPointType.TipTrailingEdge);
				}, delegate
				{
					OnGizmoMoveCompleted(WingScript.WingPointType.TipTrailingEdge);
				});
				if (ThicknessGizmoEnabled)
				{
					CreateAdjustmentGizmo(transform, wingScript.Up, restrictForwardAftMovement: true, restrictLateralMovement: true, restrictVerticalMovement: false, delegate(Vector3 position)
					{
						UpdateWingPoint(position, WingScript.WingPointType.Thickness);
					}, () => GetWingPoint(wingScript.Thickness), delegate
					{
						OnGizmoMoveStarted(WingScript.WingPointType.Thickness);
					}, delegate
					{
						OnGizmoMoveCompleted(WingScript.WingPointType.Thickness);
					}, Constants.Colors.Complementary.Gamma);
				}
				if (!wingScript.IsWingTipAttached)
				{
					CreateAdjustmentGizmo(transform, wingScript.Right, restrictForwardAftMovement: false, restrictLateralMovement: false, restrictVerticalMovement: true, delegate(Vector3 position)
					{
						UpdateWingPoint(position, WingScript.WingPointType.TipPosition);
					}, () => GetWingPoint(wingScript.Data.TipPosition), delegate
					{
						OnGizmoMoveStarted(WingScript.WingPointType.TipPosition);
					}, delegate
					{
						OnGizmoMoveCompleted(WingScript.WingPointType.TipPosition);
					});
				}
			}
			else if (CurrentEditType == EditType.Dihedral && !wingScript.IsWingTipAttached)
			{
				CreateAdjustmentGizmo(transform, wingScript.LiftUp, restrictForwardAftMovement: true, restrictLateralMovement: true, restrictVerticalMovement: false, delegate(Vector3 position)
				{
					UpdateWingPoint(position, WingScript.WingPointType.TipPosition);
				}, () => GetWingPoint(wingScript.Data.TipPosition), delegate
				{
					OnGizmoMoveStarted(WingScript.WingPointType.TipPosition);
				}, delegate
				{
					OnGizmoMoveCompleted(WingScript.WingPointType.TipPosition);
				});
			}
		}

		protected override void MoveAdjustmentGizmo(GameObject planeHit, AdjustmentGizmoScript gizmoScript, RaycastHit rayHit)
		{
			base.MoveAdjustmentGizmo(planeHit, gizmoScript, rayHit);
			_collisionDetector.DetectCollisions(updateMaterials: true);
		}

		private static Vector3 GetWingPoint(WingScript wingScript, WingScript.WingPointType wingPointType)
		{
			Vector3 result = Vector3.zero;
			switch (wingPointType)
			{
			case WingScript.WingPointType.RootLeadingEdge:
				result = wingScript.RootLeadingEdge;
				break;
			case WingScript.WingPointType.RootTrailingEdge:
				result = wingScript.RootTrailingEdge;
				break;
			case WingScript.WingPointType.TipLeadingEdge:
				result = wingScript.TipLeadingEdge;
				break;
			case WingScript.WingPointType.TipPosition:
				result = wingScript.Data.TipPosition;
				break;
			case WingScript.WingPointType.TipTrailingEdge:
				result = wingScript.TipTrailingEdge;
				break;
			case WingScript.WingPointType.Thickness:
				result = wingScript.Thickness;
				break;
			}
			return result;
		}

		private void EditTypeChanged(EditType value)
		{
			CreateGizmos();
		}

		private Vector3 GetWingPoint(Vector3 position)
		{
			return base.SelectedPart.GameObject.transform.TransformPoint(position);
		}

		private void OnGizmoMoveCompleted(WingScript.WingPointType wingPointType)
		{
			if (base.SelectedPart.PartMaterialScript.IsCollidingInDesigner)
			{
				UpdateWingPoint(_dragStartWingPointPosition, wingPointType);
				Symmetry.SynchronizePartModifiers(base.WingScript.PartScript);
				RefreshGizmoPositions();
				_collisionDetector.DetectCollisions(updateMaterials: true);
			}
		}

		private void OnGizmoMoveStarted(WingScript.WingPointType wingPointType)
		{
			_dragStartWingPointPosition = GetWingPoint(GetWingPoint(base.WingScript, wingPointType));
		}

		private void UpdateWingPoint(Vector3 position, WingScript.WingPointType wingPointType)
		{
			position = base.SelectedPart.GameObject.transform.InverseTransformPoint(position);
			base.WingScript.UpdateWingPoint(position, wingPointType);
		}
	}
}
