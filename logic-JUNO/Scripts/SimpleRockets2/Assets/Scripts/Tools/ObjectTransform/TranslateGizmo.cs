using System;
using ModApi;
using ModApi.Input.Events;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public class TranslateGizmo : MovementGizmo<TranslateGizmoAxisScript>
	{
		private TranslateGizmoAxisScript _forwardAxisGizmo;

		private TranslateGizmoAxisScript _rightAxisGizmo;

		private Vector3 _snapDeltaAccum;

		private TranslateGizmoAxisScript _upAxisGizmo;

		public override void CreateGizmos(bool playGizmoFlyout)
		{
			base.CreateGizmos(playGizmoFlyout);
			bool screenSizeConstant = true;
			Camera camera = base.Camera;
			Transform parent = base.GizmosParent;
			_upAxisGizmo = TranslateGizmoAxisScript.Create(parent, () => (!base.IsLocalOrientation) ? Vector3.up : parent.up, new Color(0f, 1f, 0f), 2.5f, screenSizeConstant, camera, TranslateGizmoAxisScript.GizmoAxisType.Up);
			_forwardAxisGizmo = TranslateGizmoAxisScript.Create(parent, () => (!base.IsLocalOrientation) ? Vector3.forward : parent.forward, new Color(0f, 0f, 1f), 2.5f, screenSizeConstant, camera, TranslateGizmoAxisScript.GizmoAxisType.Forward);
			_rightAxisGizmo = TranslateGizmoAxisScript.Create(parent, () => (!base.IsLocalOrientation) ? Vector3.right : parent.right, new Color(1f, 0f, 0f), 2.5f, screenSizeConstant, camera, TranslateGizmoAxisScript.GizmoAxisType.Right);
		}

		public override void DestroyGizmos()
		{
			base.DestroyGizmos();
			_upAxisGizmo = (_forwardAxisGizmo = (_rightAxisGizmo = null));
		}

		public override void Update()
		{
			base.Update();
			if (Game.Instance.Inputs.ToolModifier.GetButtonUp())
			{
				DestroyGizmos();
				base.IsLocalOrientation = !base.IsLocalOrientation;
			}
		}

		protected static Vector3 Drag(Transform trans, float movementMag, Vector3 dragDir, Vector3 snapDeltaAccum, float gridSize, bool local)
		{
			Vector3 vector = dragDir * movementMag;
			snapDeltaAccum += vector;
			float magnitude = snapDeltaAccum.magnitude;
			Vector3 position = trans.position;
			Vector3 position2;
			if (gridSize > 0f)
			{
				if (magnitude > gridSize)
				{
					vector = vector.normalized * (int)(magnitude / gridSize) * gridSize;
					magnitude = gridSize;
					snapDeltaAccum = Vector3.zero;
				}
				else
				{
					vector = Vector3.zero;
				}
				Vector3 vector2 = position + vector;
				if (local)
				{
					position2 = vector2;
				}
				else
				{
					if (!Utilities.CompareVector3s(dragDir, Vector3.up) && !Utilities.CompareVector3s(dragDir, Vector3.right) && !Utilities.CompareVector3s(dragDir, Vector3.forward))
					{
						throw new ArgumentException("dragDir must be Vector3.up/right/forward when world grid snapping is used.");
					}
					vector2 = MathUtils.RoundToGrid(vector2, gridSize);
					Vector3 vector3 = Vector3.Scale(vector2 - position, dragDir);
					position2 = position + vector3;
				}
			}
			else
			{
				position2 = position + vector;
			}
			trans.position = position2;
			return snapDeltaAccum;
		}

		protected override void ProcessGizmoClick(TranslateGizmoAxisScript gizmo, RaycastHit rayHit, ClickEventArgs e)
		{
			base.ProcessGizmoClick(gizmo, rayHit, e);
			base.MouseDrag.SetDragDirection(base.GizmoBeingDragged.Direction);
			gizmo.AdjustmentGizmoScript.IsSelected = true;
		}

		protected override void ProcessGizmoDrag(ClickEventArgs e)
		{
			base.ProcessGizmoDrag(e);
			_snapDeltaAccum = Drag(base.SelectedTransform, base.MouseDrag.DeltaMag, base.MouseDrag.Direction, _snapDeltaAccum, base.GridSize, base.IsLocalOrientation);
			NotifyAdjustmentOccurred();
		}

		protected override void ProcessGizmoDragEnd(GizmoAxisScript gizmo, ClickEventArgs e)
		{
			base.ProcessGizmoDragEnd(gizmo, e);
			(gizmo as TranslateGizmoAxisScript).AdjustmentGizmoScript.IsSelected = false;
		}
	}
}
