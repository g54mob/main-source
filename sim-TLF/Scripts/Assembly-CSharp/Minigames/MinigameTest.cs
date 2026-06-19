using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Minigames
{
	public class MinigameTest : MonoBehaviour
	{
		private enum State
		{
			Free = 0,
			Engaged = 1
		}

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
		private AnimationCurve _progressCurve = AnimationCurve.Linear(0f, 0f, 5f, 2f);

		[SerializeField]
		private float _boltProgress;

		[Header("Dead Zones")]
		[SerializeField]
		private RectTransform[] _deadZones;

		private Canvas _canvas;

		private Vector2 _targetLocalPos;

		private Vector2 _currentVelocity;

		private State _currentState;

		private float _previousAngle;

		private float _initialAngleOffset;

		private float _blockedPositionAngle;

		private bool _wasBlocked;

		private float _totalRotation;

		public float BoltProgress => _boltProgress;

		private void Awake()
		{
			_canvas = GetComponentInParent<Canvas>();
			_targetLocalPos = keyRectTransform.localPosition;
			float z = keyRectTransform.localEulerAngles.z;
			float z2 = boltRectTransform.localEulerAngles.z;
			_initialAngleOffset = Mathf.DeltaAngle(z2, z);
		}

		private void Update()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Mouse.current.position.ReadValue(), _canvas.worldCamera, out var localPoint);
			if (IsInDeadZone(localPoint))
			{
				return;
			}
			bool flag = IsKeyAlignedWithBolt();
			float num = (flag ? _innerRadius : _outerRadius);
			float num2 = Vector2.Distance(_canvas.transform.TransformPoint(localPoint), boltRectTransform.position);
			bool flag2 = !flag && num2 < num;
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
			RotateKeyToBolt(keyRectTransform, boltRectTransform, _rotateOffset);
			if (_currentState == State.Free)
			{
				if (CanEngage())
				{
					_currentState = State.Engaged;
					_previousAngle = GetKeyAngleAroundBolt();
				}
			}
			else if (_currentState == State.Engaged)
			{
				if (!IsBoltInJaw(boltRectTransform, jawPoint, _snapDistance) || !flag)
				{
					_currentState = State.Free;
				}
				else if (!flag2)
				{
					UpdateBoltRotation();
				}
			}
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

		private bool IsKeyAlignedWithBolt()
		{
			float z = keyRectTransform.localEulerAngles.z;
			float t = Mathf.DeltaAngle(boltRectTransform.localEulerAngles.z, z) - _initialAngleOffset;
			float num = 360f / (float)_boltSides;
			float num2 = Mathf.Repeat(t, num);
			if (num2 > num / 2f)
			{
				num2 = num - num2;
			}
			return num2 <= _alignTolerance;
		}

		private bool CanEngage()
		{
			if (!IsBoltInJaw(boltRectTransform, jawPoint, _snapDistance))
			{
				return false;
			}
			return IsKeyAlignedWithBolt();
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

		private void UpdateBoltRotation()
		{
			float keyAngleAroundBolt = GetKeyAngleAroundBolt();
			float num = Mathf.DeltaAngle(_previousAngle, keyAngleAroundBolt);
			float z = boltRectTransform.localEulerAngles.z + num;
			boltRectTransform.localRotation = Quaternion.Euler(0f, 0f, z);
			if (num > 0f)
			{
				_totalRotation += Mathf.Abs(num);
			}
			else
			{
				_totalRotation -= Mathf.Abs(num);
				_totalRotation = Mathf.Max(0f, _totalRotation);
			}
			UpdateProgress();
			_previousAngle = keyAngleAroundBolt;
		}

		private void UpdateProgress()
		{
			float time = _totalRotation / 360f;
			_boltProgress = Mathf.Clamp(_progressCurve.Evaluate(time), 0f, 2f);
			if (_boltProgress >= 2f)
			{
				OnMinigameComplete();
			}
		}

		private void OnMinigameComplete()
		{
			Debug.Log("Minigame completed! Progress: " + _boltProgress);
		}
	}
}
