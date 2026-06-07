using DG.Tweening;
using ModApi;
using ModApi.Input.Events;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public class RotateGizmo : MovementGizmo<RotateGizmoAxisScript>
	{
		private bool _animatingGizmos;

		private float _cameraDist;

		private int _flip;

		private Vector3 _forwardVec;

		private GameObject _gizmoCenter;

		private Transform _gizmoSphere;

		private Quaternion _lastRotation;

		private Quaternion _lastSnapRotation;

		private Vector3 _rightVec;

		private float _screenConstantScale;

		private float _snapDegreesAccum;

		private Quaternion _startingRotation;

		private Vector2 _tangentVec;

		private Vector3 _upVec;

		private RotateGizmoAxisScript _xRotation;

		private RotateGizmoAxisScript _yRotation;

		private RotateGizmoAxisScript _zRotation;

		public float AngleSnap { get; set; }

		public Space RelativeSpace
		{
			get
			{
				if (!base.IsLocalOrientation)
				{
					return Space.World;
				}
				return Space.Self;
			}
		}

		public RotateGizmoAxisScript RotateGizmoBeingDragged => base.GizmoBeingDragged;

		public float Sensitivity { get; set; }

		public override void CreateGizmos(bool playGizmoFlyout)
		{
			base.CreateGizmos(playGizmoFlyout);
			_xRotation = RotateGizmoAxisScript.Create(this, base.GizmosParent, Utilities.UnityTransform.TransformAxis.X, new Color(1f, 0f, 0f, 1f), 2.5f);
			_yRotation = RotateGizmoAxisScript.Create(this, base.GizmosParent, Utilities.UnityTransform.TransformAxis.Y, new Color(0f, 1f, 0f, 1f), 2.5f);
			_zRotation = RotateGizmoAxisScript.Create(this, base.GizmosParent, Utilities.UnityTransform.TransformAxis.Z, new Color(0f, 0f, 1f, 1f), 2.5f);
			_gizmoCenter = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			_gizmoCenter.name = "GizmoCenter";
			_gizmoCenter.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			Object.DestroyImmediate(_gizmoCenter.GetComponent<SphereCollider>());
			_gizmoCenter.transform.localScale = new Vector3(0.125f, 0.125f, 0.125f);
			_gizmoCenter.transform.parent = base.GizmosParent;
			_gizmoCenter.GetComponent<Renderer>().material.color = Constants.Colors.Primary.Gamma;
			_gizmoCenter.layer = 10;
			MeshRenderer component = _gizmoCenter.GetComponent<MeshRenderer>();
			component.receiveShadows = false;
			component.shadowCastingMode = ShadowCastingMode.Off;
			_gizmoCenter.transform.localPosition = Vector3.zero;
			_gizmoSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
			_gizmoSphere.name = "GizmoSphere";
			_gizmoSphere.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			Object.DestroyImmediate(_gizmoSphere.GetComponent<SphereCollider>());
			_gizmoSphere.localScale = new Vector3(0.125f, 0.125f, 0.125f);
			_gizmoSphere.parent = base.GizmosParent;
			_gizmoSphere.GetComponent<Renderer>().material.color = Constants.Colors.Primary.Gamma;
			_gizmoSphere.gameObject.layer = 10;
			_gizmoSphere.transform.localPosition = Vector3.zero;
			MeshRenderer component2 = _gizmoSphere.GetComponent<MeshRenderer>();
			component2.receiveShadows = false;
			component2.shadowCastingMode = ShadowCastingMode.Off;
			component2.material = Game.Instance.ResourceLoader.Load<Material>("Design/Materials/RotateToolGlobe");
			UpdateGizmos();
		}

		public override void DestroyGizmos()
		{
			base.DestroyGizmos();
			_xRotation = (_yRotation = (_zRotation = null));
		}

		public override void Initialize(Camera camera)
		{
			base.Initialize(camera);
			Sensitivity = 0.5f;
		}

		public override void Update()
		{
			base.Update();
			if (base.SelectedTransform != null)
			{
				UpdateGizmos();
			}
		}

		protected override void ProcessGizmoClick(RotateGizmoAxisScript gizmo, RaycastHit rayHit, ClickEventArgs e)
		{
			base.ProcessGizmoClick(gizmo, rayHit, e);
			_lastSnapRotation = (_lastRotation = (_startingRotation = base.SelectedTransform.rotation));
			_tangentVec = GetTangentVec(rayHit.point, base.GizmoBeingDragged);
		}

		protected override void ProcessGizmoDrag(ClickEventArgs e)
		{
			base.ProcessGizmoDrag(e);
			if (base.MouseDrag.MouseDragVec.HasValue)
			{
				float num = base.MouseDrag.DeltaScreenMag * Sensitivity * 0.5f;
				_flip = ((Vector2.Dot(base.MouseDrag.MouseDragVec.Value, _tangentVec) > 0f) ? 1 : (-1));
				num *= (float)_flip;
				if (AngleSnap > 0f)
				{
					num *= AngleSnap * 0.2f;
				}
				UpdateMouseRotation(num);
				NotifyAdjustmentOccurred();
			}
		}

		protected override void ProcessGizmoDragEnd(GizmoAxisScript gizmo, ClickEventArgs e)
		{
			base.ProcessGizmoDragEnd(gizmo, e);
			if (!base.IsLocalOrientation)
			{
				_animatingGizmos = true;
				DOTween.To(() => _rightVec, delegate(Vector3 x)
				{
					_rightVec = x;
				}, Vector3.right, 0.1f).SetEase(Ease.InOutSine);
				DOTween.To(() => _upVec, delegate(Vector3 x)
				{
					_upVec = x;
				}, Vector3.up, 0.1f).SetEase(Ease.InOutSine);
				DOTween.To(() => _forwardVec, delegate(Vector3 x)
				{
					_forwardVec = x;
				}, Vector3.forward, 0.1f).SetEase(Ease.InOutSine).OnComplete(delegate
				{
					_animatingGizmos = false;
				});
			}
		}

		protected override bool ShouldDragGizmo(RotateGizmoAxisScript gizmo, RaycastHit rayHit)
		{
			return Vector3.Distance(rayHit.point, base.SelectedTransform.position) > 0.8f * _screenConstantScale;
		}

		protected void UpdateMouseRotation(float degrees)
		{
			if (AngleSnap > 0f)
			{
				_snapDegreesAccum += degrees;
				base.SelectedTransform.rotation = _lastRotation;
				base.SelectedTransform.Rotate(Utilities.UnityTransform.GetRotation(base.GizmoBeingDragged.Axis, degrees), RelativeSpace);
				Quaternion b = (_lastRotation = base.SelectedTransform.rotation);
				base.SelectedTransform.rotation = _lastSnapRotation;
				if (Quaternion.Angle(_lastSnapRotation, b) > AngleSnap)
				{
					Rotate(Utilities.UnityTransform.GetRotation(base.GizmoBeingDragged.Axis, AngleSnap * (float)((_snapDegreesAccum > 0f) ? 1 : (-1))), RelativeSpace);
				}
			}
			else
			{
				Rotate(Utilities.UnityTransform.GetRotation(base.GizmoBeingDragged.Axis, degrees), RelativeSpace);
			}
		}

		private static bool IsLeft(Vector2 line, Vector2 point)
		{
			Vector2 vector = line * 1f;
			Vector2 vector2 = line * -1f;
			return (vector2.x - vector.x) * (point.y - vector.y) > (vector2.y - vector.y) * (point.x - vector.x);
		}

		private Vector2 GetTangentVec(Vector3 pointOnAxis, RotateGizmoAxisScript gizmo)
		{
			Camera camera = base.Camera;
			Vector3 position = Quaternion.Euler(Utilities.UnityTransform.GetVector(base.SelectedTransform, gizmo.Axis, base.IsLocalOrientation)) * (pointOnAxis - base.SelectedTransform.position) + base.SelectedTransform.position;
			Vector2 vector = Utilities.GameWorldToScreenPoint(camera, pointOnAxis);
			return ((Vector2)Utilities.GameWorldToScreenPoint(camera, position) - vector).normalized;
		}

		private void Rotate(Vector3 eulers, Space space)
		{
			NotifyAdjustmentBeginning(false);
			base.SelectedTransform.Rotate(eulers, space);
			NotifyAdjustmentEnded();
			_lastRotation = (_lastSnapRotation = base.SelectedTransform.rotation);
			_snapDegreesAccum = 0f;
		}

		private void UpdateGizmos()
		{
			Transform selectedTransform = base.SelectedTransform;
			if (!base.IsLocalOrientation && base.IsAdjusting)
			{
				_rightVec = Quaternion.Inverse(_startingRotation * Quaternion.Inverse(base.SelectedTransform.rotation)) * Vector3.right;
				_upVec = Quaternion.Inverse(_startingRotation * Quaternion.Inverse(base.SelectedTransform.rotation)) * Vector3.up;
				_forwardVec = Quaternion.Inverse(_startingRotation * Quaternion.Inverse(base.SelectedTransform.rotation)) * Vector3.forward;
			}
			else if (!_animatingGizmos)
			{
				_rightVec = (base.IsLocalOrientation ? selectedTransform.right : Vector3.right);
				_upVec = (base.IsLocalOrientation ? selectedTransform.up : Vector3.up);
				_forwardVec = (base.IsLocalOrientation ? selectedTransform.forward : Vector3.forward);
			}
			_cameraDist = (base.Camera.transform.position - selectedTransform.position).magnitude;
			_screenConstantScale = 0.1f * _cameraDist;
			Vector3 position = base.GizmosParent.position;
			_xRotation?.UpdateGizmo(position, _rightVec, _screenConstantScale, _cameraDist);
			_yRotation?.UpdateGizmo(position, _upVec, _screenConstantScale, _cameraDist);
			_zRotation?.UpdateGizmo(position, _forwardVec, _screenConstantScale, _cameraDist);
			float num = 1.85f * _screenConstantScale;
			_gizmoSphere.localScale = new Vector3(num, num, num);
			float num2 = 0.005f * _cameraDist;
			_gizmoCenter.transform.localScale = new Vector3(num2, num2, num2);
		}
	}
}
