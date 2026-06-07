using Assets.Scripts.Tools.ObjectTransform;
using ModApi.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class RotatePartTool : MovementTool
	{
		private RotateGizmo _rotateGizmo;

		public RotateGizmo Gizmo => _rotateGizmo;

		public override bool IsBaseTool => false;

		public RotatePartTool(DesignerScript designer)
			: base(designer)
		{
			_rotateGizmo = new RotateGizmo();
			_rotateGizmo.Initialize(designer.GizmoCamera);
			_rotateGizmo.GridSizeFunc = () => Game.Instance.Settings.Game.Designer.GridSize;
			_rotateGizmo.Sensitivity = 0.5f;
			_rotateGizmo.GizmoAdjusted += OnGizmoAdjusted;
			_rotateGizmo.GizmoAdjustmentStarted += OnGizmoAdjustmentStarted;
		}

		public override bool HandleClick(ClickEventArgs e)
		{
			base.HandleClick(e);
			return _rotateGizmo.HandleClick(e);
		}

		public void Rotate(Vector3 eulers, Space space)
		{
			DirectAdjustmentBegin();
			base.SelectedTransform.Rotate(eulers, space);
			DirectAdjustmentEnd();
		}

		public void SetWorldRotation(Quaternion quaternion)
		{
			DirectAdjustmentBegin();
			base.SelectedTransform.rotation = quaternion;
			DirectAdjustmentEnd();
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			_rotateGizmo.Update();
		}

		protected override bool OnMouseDrag(ClickEventArgs e)
		{
			base.OnMouseDrag(e);
			return true;
		}

		protected override bool OnMouseEnd()
		{
			bool result = base.OnMouseEnd();
			if (_rotateGizmo.IsAdjusting)
			{
				base.DesignerScript.CraftScript.SetStructureChanged();
			}
			return result;
		}

		protected override void OnOrientationChanged()
		{
			base.OnOrientationChanged();
			_rotateGizmo.IsLocalOrientation = base.LocalOrientation;
		}

		protected override void ProcessSelectedTransformChanged(Transform newTransform, bool justAddedPart, bool notifyGizmo)
		{
			base.ProcessSelectedTransformChanged(newTransform, justAddedPart, notifyGizmo);
			if (notifyGizmo)
			{
				_rotateGizmo.SetAdjustmentTransform(newTransform, !justAddedPart);
			}
		}

		private void OnGizmoAdjusted(MovementGizmo<RotateGizmoAxisScript> source, bool? newAxis)
		{
			UpdateSymmetricParts();
			RaiseToolAdjustmentOccurred();
		}

		private void OnGizmoAdjustmentStarted(MovementGizmo<RotateGizmoAxisScript> source, bool? newAxis)
		{
			if (!newAxis.HasValue || newAxis.Value)
			{
				base.DesignerScript.CreateUndoStep();
			}
		}
	}
}
