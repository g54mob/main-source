using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class ChaseCameraController : InteractiveCameraController
	{
		private bool _animatingRecenter;

		private Vector3 _cameraUp = Vector3.up;

		private bool _centerOnRigidBody;

		private float _rotationDamp;

		private Func<IRigidBody> _transformBody;

		private Func<Transform> _transformToTrack;

		private bool _chasedByPedro;

		public override Vector3 AngularVelocity
		{
			get
			{
				IRigidBody rigidBody = _transformBody();
				if (rigidBody != null)
				{
					return rigidBody.PhysxRigidBody?.angularVelocity ?? Vector3.zero;
				}
				return Vector3.zero;
			}
		}

		public bool IsCentered
		{
			get
			{
				if ((_deltaRotation - CenterRotation).sqrMagnitude < 0.5f)
				{
					return (_targetPositionOffset - CenterPosition).sqrMagnitude < 0.01f;
				}
				return false;
			}
		}

		public override bool IsRecenterAvailable
		{
			get
			{
				if (!IsCentered)
				{
					return !_animatingRecenter;
				}
				return false;
			}
		}

		public bool StayUpright { get; set; }

		protected override bool SupportsMovementInXR => true;

		private Vector3 CenterPosition
		{
			get
			{
				if (!_chasedByPedro)
				{
					return Vector3.zero;
				}
				return new Vector3(0f, 0.15f, 0f);
			}
		}

		private Vector2 CenterRotation
		{
			get
			{
				if (!_chasedByPedro)
				{
					return new Vector2(15f, 0f);
				}
				return Vector2.zero;
			}
		}

		public ChaseCameraController(CameraManagerScript cameraManager, bool centerOnRigidBody, float startDistance, PartScript part)
			: base(cameraManager)
		{
			Initialize(() => part.transform, () => part.Body.RigidBody, centerOnRigidBody, startDistance);
		}

		public ChaseCameraController(CameraManagerScript cameraManager, bool centerOnRigidBody, float startDistance, CameraVantageScript cameraVantage)
			: base(cameraManager)
		{
			base.CameraVantage = cameraVantage;
			Initialize(() => cameraVantage.TransformToTrack, () => cameraVantage.RigidBody, centerOnRigidBody, startDistance);
		}

		public override bool AllowGunReticle(Transform targetingTransform)
		{
			return AllowMissileLocking(targetingTransform);
		}

		public override bool AllowMissileLocking(Transform targetingTransform)
		{
			if (targetingTransform == null)
			{
				return false;
			}
			return Vector3.Dot(base.CameraTransform.forward, targetingTransform.forward) > 0.9f;
		}

		public override void Move(Vector2 direction)
		{
			float num = 0.05f;
			Vector3 vector = base.CameraTransform.right * (direction.x * num) + base.CameraTransform.up * (direction.y * num);
			Transform transform = _transformToTrack();
			_targetPositionOffset += transform.InverseTransformVector(vector);
		}

		public override void RecenterView()
		{
			_animatingRecenter = true;
			_targetPositionOffset = CenterPosition;
			DOTween.To(() => _deltaRotation, delegate(Vector2 x)
			{
				_deltaRotation = x;
			}, CenterRotation, 0.5f).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
			{
				_animatingRecenter = false;
			});
		}

		public override void Update(int frameCount)
		{
			base.Update(frameCount);
			float num = Mathf.Min(Time.unscaledDeltaTime, 0.2f);
			base.CameraManager.SharedCameraDistance = Mathf.Lerp(base.CameraManager.SharedCameraDistance, _targetDistance, 3f * num);
			Transform transform = _transformToTrack();
			Quaternion b = transform.rotation * Quaternion.Euler(_deltaRotation.x, _deltaRotation.y, 0f);
			base.CameraManager.SharedCameraRotation = Quaternion.Slerp(base.CameraManager.SharedCameraRotation, b, _rotationDamp * num);
			Vector3 position = transform.position;
			if (_centerOnRigidBody)
			{
				IRigidBody rigidBody = _transformBody();
				if (rigidBody != null)
				{
					position = rigidBody.position;
				}
			}
			position += transform.TransformVector(_targetPositionOffset * (_chasedByPedro ? base.CameraManager.SharedCameraDistance : 0.5f));
			base.CameraTransform.position = position - base.CameraManager.SharedCameraRotation * Vector3.forward * base.CameraManager.SharedCameraDistance;
			if (StayUpright)
			{
				_cameraUp = Vector3.up;
			}
			else
			{
				_cameraUp = Vector3.Lerp(_cameraUp, transform.up, 3f * num);
			}
			base.CameraTransform.LookAt(position, _cameraUp);
			ForceCameraAboveTerrain(position);
			base.CameraManager.CameraFocalPosition.position = transform.position;
		}

		private void Initialize(Func<Transform> transform, Func<IRigidBody> body, bool centerOnRigidBody, float startDistance)
		{
			base.Name = "Chase View";
			_chasedByPedro = Game.Instance.Settings.Gameplay.Camera.ChasedByPedro.Value;
			_centerOnRigidBody = centerOnRigidBody;
			_targetDistance = startDistance;
			_deltaRotation = CenterRotation;
			base.AutoSwitchWhenBelowWater = true;
			_transformToTrack = transform;
			_transformBody = body;
			_rotationDamp = (_chasedByPedro ? 1.5f : 3f);
		}
	}
}
