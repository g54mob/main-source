using Assets.Scripts.Tools.ObjectTransform;
using ModApi;
using ModApi.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class NudgePartTool : MovementTool
	{
		private TranslateGizmo _translateGizmo;

		public TranslateGizmo Gizmo => _translateGizmo;

		public override bool IsBaseTool => false;

		public NudgePartTool(DesignerScript designer)
			: base(designer)
		{
			_translateGizmo = new TranslateGizmo();
			_translateGizmo.GridSizeFunc = () => Game.Instance.Settings.Game.Designer.GridSize;
			_translateGizmo.Initialize(designer.GizmoCamera);
			_translateGizmo.GizmoAdjustmentStarted += OnGizmoAdjustmentStarted;
			_translateGizmo.GizmoAdjusted += OnGizmoAdjusted;
		}

		public override bool HandleClick(ClickEventArgs e)
		{
			base.HandleClick(e);
			return _translateGizmo.HandleClick(e);
		}

		public void NudgeSelection(Utilities.UnityTransform.TransformAxis axis, float distance)
		{
			DirectAdjustmentBegin();
			Vector3 position = base.SelectedTransform.position;
			switch (axis)
			{
			case Utilities.UnityTransform.TransformAxis.X:
				position += (base.LocalOrientation ? base.SelectedTransform.right : Vector3.right) * distance;
				break;
			case Utilities.UnityTransform.TransformAxis.Y:
				position += (base.LocalOrientation ? base.SelectedTransform.up : Vector3.up) * distance;
				break;
			case Utilities.UnityTransform.TransformAxis.Z:
				position += (base.LocalOrientation ? base.SelectedTransform.forward : Vector3.forward) * distance;
				break;
			}
			base.SelectedTransform.position = position;
			DirectAdjustmentEnd();
		}

		public void SetWorldPosition(Vector3 position)
		{
			DirectAdjustmentBegin();
			base.SelectedTransform.position = position;
			DirectAdjustmentEnd();
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			_translateGizmo.Update();
		}

		protected override bool OnMouseDrag(ClickEventArgs e)
		{
			base.OnMouseDrag(e);
			return true;
		}

		protected override bool OnMouseEnd()
		{
			bool result = base.OnMouseEnd();
			if (_translateGizmo.IsAdjusting)
			{
				base.DesignerScript.CraftScript.SetStructureChanged();
			}
			return result;
		}

		protected override void OnOrientationChanged()
		{
			base.OnOrientationChanged();
			_translateGizmo.IsLocalOrientation = base.LocalOrientation;
		}

		protected override void ProcessSelectedTransformChanged(Transform newTransform, bool justAddedPart, bool notifyGizmo)
		{
			base.ProcessSelectedTransformChanged(newTransform, justAddedPart, notifyGizmo);
			if (notifyGizmo)
			{
				_translateGizmo.SetAdjustmentTransform(newTransform, !justAddedPart);
			}
		}

		private void OnGizmoAdjusted(MovementGizmo<TranslateGizmoAxisScript> source, bool? newAxis)
		{
			UpdateSymmetricParts();
			RaiseToolAdjustmentOccurred();
		}

		private void OnGizmoAdjustmentStarted(MovementGizmo<TranslateGizmoAxisScript> source, bool? newAxis)
		{
			if (!newAxis.HasValue || newAxis.Value)
			{
				base.DesignerScript.CreateUndoStep();
			}
			UpdateSymmetricParts();
			RaiseToolAdjustmentOccurred();
		}
	}
}
