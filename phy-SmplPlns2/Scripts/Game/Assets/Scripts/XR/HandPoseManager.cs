using System;
using Assets.Scripts.Input.XR;
using Assets.Scripts.XR.HandPoses;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.XR
{
	public class HandPoseManager : MonoBehaviour
	{
		private enum PoseMode
		{
			EmptyHand = 0,
			GenericHold = 1,
			BallHold = 2,
			ControllerHold = 3
		}

		private class AnimTweener
		{
			private float _value;

			public Action<float> SetAction { get; set; }

			public float Speed { get; set; }

			public float Target { get; set; }

			public float Value
			{
				get
				{
					return _value;
				}
				set
				{
					_value = value;
					SetAction(value);
				}
			}

			public void Update()
			{
				if (Value != Target)
				{
					if (Mathf.Approximately(Value, Target))
					{
						Value = Target;
					}
					else
					{
						Value = Mathf.MoveTowards(Value, Target, Speed * Time.unscaledDeltaTime);
					}
				}
			}
		}

		[SerializeField]
		private Animator _animator;

		private int _animLayerPoint;

		private int _animLayerThumb;

		private int _animParamFlex;

		private int _animParamPinch;

		private int _animParamPose;

		private InputAction _grip;

		private float? _gripOverride;

		private TweenerCore<float, float, FloatOptions> _gripOverrideTweener;

		private bool _hasStarted;

		private InputAction _indexTouch;

		[SerializeField]
		private bool _isLeft;

		private AnimatorOverrideController _overrideController;

		private bool _overridePoint;

		private bool _overrideThumb;

		private float? _pointOverrideValue;

		private AnimTweener _pointTweener;

		private GripPose _queuedGripOnStart;

		private InputAction _thumbTouch;

		private AnimTweener _thumbTweener;

		private InputAction _trigger;

		public Pose CurrentGripOffset { get; private set; }

		public bool EnableInputs { get; set; } = true;

		public float? GripOverride
		{
			get
			{
				return _gripOverride;
			}
			set
			{
				_ = _gripOverride;
				if (value.HasValue)
				{
					_gripOverride = value;
					SetGrip(_gripOverride.Value);
					if (_gripOverrideTweener != null)
					{
						_gripOverrideTweener.Kill();
						_gripOverrideTweener = null;
					}
				}
				else if (_gripOverride != value)
				{
					_gripOverrideTweener = DOTween.To(() => _gripOverride.Value, delegate(float x)
					{
						_gripOverride = x;
					}, 0f, 0.25f).SetUpdate(isIndependentUpdate: true).OnUpdate(delegate
					{
						SetGrip(_gripOverride.Value);
					})
						.OnComplete(delegate
						{
							_gripOverride = null;
							_gripOverrideTweener = null;
						});
				}
			}
		}

		public float? OverridePoint
		{
			get
			{
				return _pointOverrideValue;
			}
			set
			{
				if (_pointOverrideValue != value)
				{
					_pointOverrideValue = value;
					if (value.HasValue)
					{
						_pointTweener.Target = value.Value;
						SetPinch(0f);
					}
					else
					{
						_pointTweener.Target = ((_indexTouch.phase != InputActionPhase.Waiting) ? 0f : 1f);
						SetPinch(_trigger.ReadValue<float>());
					}
				}
			}
		}

		public void SetCustomGripPose(GripPose clip)
		{
			if (!_hasStarted)
			{
				_queuedGripOnStart = clip;
				return;
			}
			if (clip == null)
			{
				SetPose(PoseMode.EmptyHand);
				CurrentGripOffset = Pose.identity;
				_overridePoint = false;
				_overrideThumb = false;
				_pointTweener.Target = ((_thumbTouch.phase != InputActionPhase.Waiting) ? 0f : 1f);
				_thumbTweener.Target = ((_thumbTouch.phase != InputActionPhase.Waiting) ? 0f : 1f);
			}
			else
			{
				if (_isLeft)
				{
					_overrideController["l_hand_hold_generic"] = clip.LeftHandAnimation;
					CurrentGripOffset = clip.LeftHandOffset;
				}
				else
				{
					_overrideController["r_hand_hold_generic"] = clip.RightHandAnimation;
					CurrentGripOffset = clip.RightHandOffset;
				}
				SetPose(PoseMode.GenericHold);
				_overrideThumb = clip.OverrideThumbsUp;
				_overridePoint = clip.OverridePoint;
			}
			if (_overridePoint)
			{
				_pointTweener.Target = 0f;
			}
			if (_overrideThumb)
			{
				_thumbTweener.Target = 0f;
			}
		}

		protected virtual void OnDestroy()
		{
			if (EnableInputs)
			{
				if (_grip != null)
				{
					_grip.performed -= ActionGripPerformed;
					_grip.canceled -= ActionGripCanceled;
				}
				if (_trigger != null)
				{
					_trigger.performed -= ActionTriggerPerformed;
					_trigger.canceled -= ActionTriggerCanceled;
				}
				if (_indexTouch != null)
				{
					_indexTouch.performed -= ActionIndexTouchPerformed;
					_indexTouch.canceled -= ActionIndexTouchCanceled;
				}
				if (_thumbTouch != null)
				{
					_thumbTouch.performed -= ActionThumbPerformed;
					_thumbTouch.canceled -= ActionThumbCanceled;
				}
			}
		}

		protected virtual void Start()
		{
			_hasStarted = true;
			_animLayerPoint = _animator.GetLayerIndex("Point Layer");
			_animLayerThumb = _animator.GetLayerIndex("Thumb Layer");
			_animParamFlex = Animator.StringToHash("Flex");
			_animParamPinch = Animator.StringToHash("Pinch");
			_animParamPose = Animator.StringToHash("Pose");
			_overrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
			_animator.runtimeAnimatorController = _overrideController;
			_thumbTweener = new AnimTweener
			{
				SetAction = SetThumb,
				Speed = 13f,
				Target = 0f,
				Value = 0f
			};
			_pointTweener = new AnimTweener
			{
				SetAction = SetPoint,
				Speed = 10f,
				Target = 0f,
				Value = 0f
			};
			if (EnableInputs)
			{
				if (_isLeft)
				{
					_grip = XRInputs.PoseLeftHand.Grip;
					_trigger = XRInputs.PoseLeftHand.Trigger;
					_indexTouch = XRInputs.PoseLeftHand.TriggerTouched;
					_thumbTouch = XRInputs.PoseLeftHand.ThumbTouched;
				}
				else
				{
					_grip = XRInputs.PoseRightHand.Grip;
					_trigger = XRInputs.PoseRightHand.Trigger;
					_indexTouch = XRInputs.PoseRightHand.TriggerTouched;
					_thumbTouch = XRInputs.PoseRightHand.ThumbTouched;
				}
				_grip.performed += ActionGripPerformed;
				_grip.canceled += ActionGripCanceled;
				_trigger.performed += ActionTriggerPerformed;
				_trigger.canceled += ActionTriggerCanceled;
				_indexTouch.performed += ActionIndexTouchPerformed;
				_indexTouch.canceled += ActionIndexTouchCanceled;
				_thumbTouch.performed += ActionThumbPerformed;
				_thumbTouch.canceled += ActionThumbCanceled;
			}
			if (_queuedGripOnStart != null)
			{
				SetCustomGripPose(_queuedGripOnStart);
				_queuedGripOnStart = null;
			}
		}

		protected virtual void Update()
		{
			_thumbTweener.Update();
			_pointTweener.Update();
		}

		private void ActionGripCanceled(InputAction.CallbackContext obj)
		{
			if (!GripOverride.HasValue)
			{
				SetGrip(0f);
			}
		}

		private void ActionGripPerformed(InputAction.CallbackContext obj)
		{
			if (!GripOverride.HasValue)
			{
				SetGrip(obj.ReadValue<float>());
			}
		}

		private void ActionIndexTouchCanceled(InputAction.CallbackContext obj)
		{
			if (!_overridePoint && !_pointOverrideValue.HasValue)
			{
				_pointTweener.Target = 1f;
			}
		}

		private void ActionIndexTouchPerformed(InputAction.CallbackContext obj)
		{
			if (!_overridePoint && !_pointOverrideValue.HasValue)
			{
				_pointTweener.Target = 0f;
			}
		}

		private void ActionThumbCanceled(InputAction.CallbackContext obj)
		{
			if (!_overrideThumb)
			{
				_thumbTweener.Target = 1f;
			}
		}

		private void ActionThumbPerformed(InputAction.CallbackContext obj)
		{
			if (!_overrideThumb)
			{
				_thumbTweener.Target = 0f;
			}
		}

		private void ActionTriggerCanceled(InputAction.CallbackContext obj)
		{
			SetPinch(0f);
		}

		private void ActionTriggerPerformed(InputAction.CallbackContext obj)
		{
			SetPinch(obj.ReadValue<float>());
		}

		private void SetGrip(float grip)
		{
			_animator.SetFloat(_animParamFlex, Mathf.Clamp01(grip));
		}

		private void SetPinch(float pinch)
		{
			if (!OverridePoint.HasValue)
			{
				_animator.SetFloat(_animParamPinch, Mathf.Clamp01(pinch));
			}
			else
			{
				_animator.SetFloat(_animParamPinch, 0f);
			}
		}

		private void SetPoint(float point)
		{
			_animator.SetLayerWeight(_animLayerPoint, Mathf.Clamp01(point));
		}

		private void SetPose(PoseMode pose)
		{
			_animator.SetInteger(_animParamPose, (int)pose);
		}

		private void SetThumb(float thumb)
		{
			_animator.SetLayerWeight(_animLayerThumb, Mathf.Clamp01(thumb));
		}
	}
}
