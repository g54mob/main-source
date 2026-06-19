using System;
using Minigames.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Minigames
{
	public class WrenchMinigameView : MonoBehaviour
	{
		[Header("Components")]
		[SerializeField]
		private WrenchTool _wrench;

		[SerializeField]
		private BoltFastener _bolt;

		[SerializeField]
		private HintSystem _hintSystem;

		[Header("Movement")]
		[SerializeField]
		private float _outerRadius = 50f;

		[SerializeField]
		private float _innerRadius = 30f;

		[SerializeField]
		private float _moveSpeed = 10f;

		[SerializeField]
		private float _rotationSpeed = 5f;

		[SerializeField]
		private float _alignTolerance = 5f;

		[SerializeField]
		private float _blockedMovementAngle = 15f;

		[Header("Progress")]
		[SerializeField]
		private AnimationCurve _progressCurve = AnimationCurve.Linear(0f, 0f, 5f, 2f);

		[Header("Dead Zones")]
		[SerializeField]
		private RectTransform[] _deadZones;

		private Canvas _canvas;

		private CircularConstraint _circularConstraint;

		private ProgressTracker _progressTracker;

		private DeadZoneChecker _deadZoneChecker;

		private Vector2 _targetLocalPos;

		private Vector2 _currentVelocity;

		private float _initialAngleOffset;

		private float _previousAngle;

		private float _blockedPositionAngle;

		private bool _wasBlocked;

		private bool _isEngaged;

		public float Progress => _progressTracker?.Progress ?? 0f;

		public ProgressTracker Progressor => _progressTracker;

		public void Init()
		{
			_canvas = GetComponentInParent<Canvas>();
			_circularConstraint = new CircularConstraint(_wrench.Transform.parent as RectTransform, _bolt.Transform);
			_progressTracker = new ProgressTracker(_progressCurve);
			_deadZoneChecker = new DeadZoneChecker(_deadZones, _canvas);
			_progressTracker.OnCompleted += OnMinigameComplete;
			float z = _wrench.Transform.localEulerAngles.z;
			float currentRotation = _bolt.GetCurrentRotation();
			_initialAngleOffset = Mathf.DeltaAngle(currentRotation, z);
			_targetLocalPos = _wrench.Transform.localPosition;
		}

		private void Start()
		{
			_hintSystem.Init(_progressTracker);
		}

		private void Update()
		{
			Vector2 mouseLocalPosition = GetMouseLocalPosition();
			if (!_deadZoneChecker.IsInDeadZone(mouseLocalPosition, _canvas.transform as RectTransform))
			{
				bool flag = _bolt.IsAlignedWith(_wrench, _initialAngleOffset, _alignTolerance);
				float num = (flag ? _innerRadius : _outerRadius);
				float num2 = Vector2.Distance(_canvas.transform.TransformPoint(mouseLocalPosition), _bolt.Transform.position);
				bool flag2 = !flag && num2 < num;
				if (flag2 && !_wasBlocked)
				{
					_blockedPositionAngle = _circularConstraint.GetAngleAroundCenter(_wrench.Transform.position);
				}
				_wasBlocked = flag2;
				if (!flag2)
				{
					_targetLocalPos = _circularConstraint.ClampToCircle(mouseLocalPosition, num);
				}
				else
				{
					_targetLocalPos = ClampToBlockedMovement(mouseLocalPosition, num, _blockedPositionAngle, _blockedMovementAngle);
				}
				Vector2 localPosition = Vector2.SmoothDamp(_wrench.Transform.localPosition, _targetLocalPos, ref _currentVelocity, 1f / _moveSpeed);
				_wrench.UpdatePosition(localPosition);
				RotateWrenchToBolt();
				UpdateEngagementState(flag, flag2);
			}
		}

		public void SetProgress(float progress)
		{
			_progressTracker.SetProgress(progress);
		}

		private Vector2 GetMouseLocalPosition()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Mouse.current.position.ReadValue(), _canvas.worldCamera, out var localPoint);
			return localPoint;
		}

		private void UpdateEngagementState(bool isAligned, bool isBlocked)
		{
			if (!_isEngaged)
			{
				if (CanEngage(isAligned))
				{
					_isEngaged = true;
					_previousAngle = _circularConstraint.GetAngleAroundCenter(_wrench.Transform.position);
				}
			}
			else if (!_wrench.CanEngage(_bolt) || !isAligned)
			{
				_isEngaged = false;
			}
			else if (!isBlocked)
			{
				float angleAroundCenter = _circularConstraint.GetAngleAroundCenter(_wrench.Transform.position);
				float num = Mathf.DeltaAngle(_previousAngle, angleAroundCenter);
				_bolt.Rotate(num);
				_progressTracker.AddRotation(0f - num);
				_previousAngle = angleAroundCenter;
			}
		}

		private bool CanEngage(bool isAligned)
		{
			return _wrench.CanEngage(_bolt) && isAligned;
		}

		private void RotateWrenchToBolt()
		{
			Vector2 vector = _bolt.Transform.position - _wrench.Transform.position;
			float z = Mathf.Atan2(vector.y, vector.x) * 57.29578f + _wrench.RotationOffset;
			Quaternion b = Quaternion.Euler(0f, 0f, z);
			_wrench.Transform.rotation = Quaternion.Slerp(_wrench.Transform.rotation, b, Time.deltaTime * _rotationSpeed);
		}

		private Vector2 ClampToBlockedMovement(Vector2 desiredLocalPos, float radius, float centerAngle, float maxAngleOffset)
		{
			Vector2 vector = _wrench.Transform.parent.TransformPoint(desiredLocalPos);
			Vector2 vector2 = _bolt.Transform.position;
			Vector2 vector3 = vector - vector2;
			float target = Mathf.Atan2(vector3.y, vector3.x) * 57.29578f;
			float num = Mathf.Clamp(Mathf.DeltaAngle(centerAngle, target), 0f - maxAngleOffset, maxAngleOffset);
			float f = (centerAngle + num) * (MathF.PI / 180f);
			Vector2 vector4 = vector2 + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
			return _wrench.Transform.parent.InverseTransformPoint(vector4);
		}

		private void OnMinigameComplete()
		{
			Debug.Log("Wrench minigame completed! Progress: " + _progressTracker.Progress);
		}
	}
}
