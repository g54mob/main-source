using System;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Minigames
{
	public class MinigameView : UIView
	{
		[Header("Links")]
		[SerializeField]
		private MinigameProgressUI progressUI;

		[SerializeField]
		private RectTransform keyRectTransform;

		[SerializeField]
		private RectTransform boltRectTransform;

		[SerializeField]
		private RectTransform jawPoint;

		[Header("Tuning")]
		[SerializeField]
		private float _rotateOffset;

		[SerializeField]
		private float _alignTolerance = 5f;

		[SerializeField]
		private float _snapDistance = 40f;

		[SerializeField]
		private float _outerRadius = 50f;

		[SerializeField]
		private float _innerRadius = 30f;

		[SerializeField]
		private float _moveSpeed = 10f;

		[SerializeField]
		private float _rotationSpeed = 5f;

		[SerializeField]
		private int _boltSides = 6;

		[SerializeField]
		private float _blockedMovementAngle = 15f;

		[Header("Progress")]
		[SerializeField]
		private AnimationCurve _rotationProgressCurve = AnimationCurve.Linear(0f, 0f, 5f, 2f);

		[Header("Dead Zones")]
		[SerializeField]
		private RectTransform[] _deadZones;

		private Canvas _canvas;

		private Vector2 _targetLocalPos;

		private Vector2 _currentVelocity;

		private float _blockedPositionAngle;

		private bool _wasBlocked;

		private MinigameViewModel _viewModel;

		protected override void Awake()
		{
			base.Awake();
			_canvas = GetComponentInParent<Canvas>();
		}

		protected override void Start()
		{
			base.Start();
			_viewModel = new MinigameViewModel();
			float z = keyRectTransform.localEulerAngles.z;
			float z2 = boltRectTransform.localEulerAngles.z;
			_viewModel.InitialAngleOffset = Mathf.DeltaAngle(z2, z);
			_viewModel.Initialize(_rotationProgressCurve);
			_targetLocalPos = keyRectTransform.localPosition;
			this.SetDataContext(_viewModel);
			BindViewModel();
			progressUI.SetViewModel(_viewModel);
		}

		private void BindViewModel()
		{
			this.CreateBindingSet<MinigameView, MinigameViewModel>().Build();
			_viewModel.BoltRotation.ValueChanged += OnBoltRotationChanged;
		}

		private void OnBoltRotationChanged(object sender, EventArgs e)
		{
			if (_viewModel != null)
			{
				boltRectTransform.localRotation = Quaternion.Euler(0f, 0f, _viewModel.BoltRotation.Value);
			}
		}

		private void Update()
		{
			if (_viewModel == null)
			{
				return;
			}
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Mouse.current.position.ReadValue(), _canvas.worldCamera, out var localPoint);
			if (!IsInDeadZone(localPoint))
			{
				float z = keyRectTransform.localEulerAngles.z;
				float z2 = boltRectTransform.localEulerAngles.z;
				bool flag = _viewModel.IsKeyAlignedWithBolt(z, z2, _boltSides, _alignTolerance);
				_viewModel.SetAligned(flag);
				float num = (flag ? _innerRadius : _outerRadius);
				float num2 = Vector2.Distance(_canvas.transform.TransformPoint(localPoint), boltRectTransform.position);
				bool flag2 = !flag && num2 < num;
				_viewModel.SetBlocked(flag2);
				if (flag2 && !_wasBlocked)
				{
					_blockedPositionAngle = GetKeyAngleAroundBolt();
				}
				_wasBlocked = flag2;
				if (!flag2)
				{
					_targetLocalPos = ClampToCircleBoundary(localPoint, boltRectTransform, num);
				}
				else
				{
					_targetLocalPos = ClampToBlockedMovement(localPoint, boltRectTransform, num, _blockedPositionAngle, _blockedMovementAngle);
				}
				Vector2 vector = Vector2.SmoothDamp(keyRectTransform.localPosition, _targetLocalPos, ref _currentVelocity, 1f / _moveSpeed);
				keyRectTransform.localPosition = vector;
				_viewModel.SetKeyPosition(vector);
				RotateKeyToBolt(keyRectTransform, boltRectTransform, _rotateOffset);
				_viewModel.SetKeyRotation(keyRectTransform.localEulerAngles.z);
				UpdateEngagementState(flag);
			}
		}

		private void UpdateEngagementState(bool isAligned)
		{
			if (!_viewModel.IsEngaged.Value)
			{
				if (CanEngage(isAligned))
				{
					_viewModel.SetEngaged(engaged: true);
					_viewModel.ResetPreviousAngle(GetKeyAngleAroundBolt());
				}
			}
			else if (!IsBoltInJaw(boltRectTransform, jawPoint, _snapDistance) || !isAligned)
			{
				_viewModel.SetEngaged(engaged: false);
			}
			else if (!_viewModel.IsBlocked.Value)
			{
				float keyAngleAroundBolt = GetKeyAngleAroundBolt();
				float num = Mathf.DeltaAngle(_viewModel.BoltRotation.Value, _viewModel.BoltRotation.Value + Mathf.DeltaAngle(GetPreviousKeyAngle(), keyAngleAroundBolt));
				_viewModel.SetBoltRotation(_viewModel.BoltRotation.Value + num);
				_viewModel.UpdateBoltRotation(keyAngleAroundBolt);
			}
		}

		private float GetPreviousKeyAngle()
		{
			Vector2 vector = (Vector2)keyRectTransform.parent.TransformPoint(_targetLocalPos) - (Vector2)boltRectTransform.position;
			return Mathf.Atan2(vector.y, vector.x) * 57.29578f;
		}

		private bool IsInDeadZone(Vector2 localPos)
		{
			if (_deadZones == null || _deadZones.Length == 0)
			{
				return false;
			}
			Vector2 screenPoint = _canvas.transform.TransformPoint(localPos);
			RectTransform[] deadZones = _deadZones;
			foreach (RectTransform rectTransform in deadZones)
			{
				if (!(rectTransform == null) && RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPoint, _canvas.worldCamera))
				{
					return true;
				}
			}
			return false;
		}

		private bool CanEngage(bool isAligned)
		{
			if (!IsBoltInJaw(boltRectTransform, jawPoint, _snapDistance))
			{
				return false;
			}
			return isAligned;
		}

		private bool IsBoltInJaw(RectTransform bolt, RectTransform jaw, float snapRadius)
		{
			return Vector2.Distance(jaw.position, bolt.position) <= snapRadius;
		}

		private Vector2 ClampToCircleBoundary(Vector2 desiredLocalPos, RectTransform bolt, float radius)
		{
			Vector2 vector = keyRectTransform.parent.TransformPoint(desiredLocalPos);
			Vector2 vector2 = bolt.position;
			Vector2 vector3 = vector - vector2;
			if (vector3.magnitude < radius)
			{
				Vector2 vector4 = vector2 + vector3.normalized * radius;
				return keyRectTransform.parent.InverseTransformPoint(vector4);
			}
			return desiredLocalPos;
		}

		private Vector2 ClampToBlockedMovement(Vector2 desiredLocalPos, RectTransform bolt, float radius, float centerAngle, float maxAngleOffset)
		{
			Vector2 vector = keyRectTransform.parent.TransformPoint(desiredLocalPos);
			Vector2 vector2 = bolt.position;
			Vector2 vector3 = vector - vector2;
			float target = Mathf.Atan2(vector3.y, vector3.x) * 57.29578f;
			float num = Mathf.Clamp(Mathf.DeltaAngle(centerAngle, target), 0f - maxAngleOffset, maxAngleOffset);
			float f = (centerAngle + num) * (MathF.PI / 180f);
			Vector2 vector4 = vector2 + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
			return keyRectTransform.parent.InverseTransformPoint(vector4);
		}

		private void RotateKeyToBolt(RectTransform key, RectTransform bolt, float zOffset)
		{
			Vector2 vector = bolt.position - key.position;
			float z = Mathf.Atan2(vector.y, vector.x) * 57.29578f + zOffset;
			Quaternion b = Quaternion.Euler(0f, 0f, z);
			key.rotation = Quaternion.Slerp(key.rotation, b, Time.deltaTime * _rotationSpeed);
		}

		private float GetKeyAngleAroundBolt()
		{
			Vector2 vector = (Vector2)keyRectTransform.position - (Vector2)boltRectTransform.position;
			return Mathf.Atan2(vector.y, vector.x) * 57.29578f;
		}

		public MinigameViewModel GetViewModel()
		{
			return _viewModel;
		}
	}
}
