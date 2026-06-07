using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Input.Events;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class RotateTool : TransformTool
	{
		private Vector3 _gizmoHitPoint;

		private float _lastSoundMoveAmount;

		private float _moveAmount;

		private Vector3 _rotationAxis;

		private Vector3 _screenSpaceTangent;

		private Quaternion _startRotation;

		public float AngleSnap { get; set; } = 15f;

		protected override float BaseToolScale => 0.1f;

		protected override string ToolPrefabName => "RotateTool";

		public RotateTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
		}

		protected override ITransformToolGizmo GetAxisAtScreenPosition(Vector2 screenPosition)
		{
			foreach (RaycastHit item in from x in Physics.RaycastAll(base.CameraController.Camera.ScreenPointToRay(screenPosition), 10000f, 1024)
				orderby x.distance
				select x)
			{
				RotateToolAxisScript componentInParent = item.collider.gameObject.GetComponentInParent<RotateToolAxisScript>();
				if (componentInParent != null && componentInParent.IsHit(item.point))
				{
					_gizmoHitPoint = item.point;
					return componentInParent;
				}
			}
			return null;
		}

		protected override void ProcessMouseDrag(InputEvent e)
		{
			if (base.PartSelection.Parts.Count == 1 && !base.PartSelection.Parts[0].Part.AllowTransformation)
			{
				PartData part = base.PartSelection.Parts[0].Part;
				base.Designer.DesignerScript.DesignerUI.ShowMessage("The '" + part.Name + "' part cannot be rotated at this time.");
				return;
			}
			Camera camera = base.Camera;
			Vector2 b = new Vector2(1f / (float)camera.pixelWidth, 1f / (float)camera.pixelHeight);
			float num = ((Vector2.Dot(_screenSpaceTangent, e.DeltaPosition.normalized) > 0f) ? 1f : (-1f));
			float magnitude = Vector2.Scale(e.DeltaPosition, b).magnitude;
			float num2 = num * magnitude * 100f;
			_moveAmount += num2;
			float num3 = _moveAmount;
			if (AngleSnap > 0f)
			{
				num3 *= Mathf.Max(1f, Mathf.Pow(AngleSnap, 0.5f));
				num3 = MovePartTool.SnapToGrid(num3, AngleSnap, centerAroundZero: false);
			}
			if (Mathf.Abs(num3 - _lastSoundMoveAmount) > 1f)
			{
				_lastSoundMoveAmount = num3;
				Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerResize);
			}
			base.SelectedTransform.rotation = Quaternion.AngleAxis(num3, _rotationAxis) * _startRotation;
			base.ToolObject.transform.rotation = base.SelectedTransform.rotation;
			SyncSymmetricTransforms();
			if (base.TrackedTransform != null)
			{
				base.TrackedTransform.hasChanged = false;
			}
		}

		protected override void ProcessMouseEnd(InputEvent e)
		{
			if (base.SelectedAxis != null)
			{
				if (_moveAmount != 0f)
				{
					base.Designer.CreateUndoStepForSelectedPart("Rotated");
				}
				base.SelectedAxis = null;
				if (!base.UseLocalSpace && _moveAmount != 0f)
				{
					CreatePartSelection();
				}
			}
		}

		protected override void ProcessMouseStart(InputEvent e)
		{
			_startRotation = base.SelectedTransform.rotation;
			_rotationAxis = base.SelectedAxis.Transform.forward;
			_moveAmount = 0f;
			_lastSoundMoveAmount = 0f;
			Vector3 rhs = base.SelectedAxis.Transform.InverseTransformPoint(_gizmoHitPoint);
			rhs.z = 0f;
			Vector3 position = Vector3.Cross(Vector3.forward, rhs);
			Vector3 vector = base.Camera.WorldToScreenPoint(base.SelectedAxis.Transform.position);
			Vector3 vector2 = base.Camera.WorldToScreenPoint(base.SelectedAxis.Transform.TransformPoint(position));
			_screenSpaceTangent = (vector2 - vector).normalized;
		}
	}
}
