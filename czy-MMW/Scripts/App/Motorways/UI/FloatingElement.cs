using System;
using Easing;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Motorways.UI
{
	[ExecuteAlways]
	public class FloatingElement : MonoBehaviour
	{
		private enum AnimationOrigin
		{
			Canonical = 0,
			WorldSpace = 1
		}

		[Serializable]
		public class HiddenTrigger : UnityEvent<bool>
		{
		}

		public GameObject baseElement;

		[DisableIf("UseInactiveAchorForPosition")]
		public Vector3 fallbackOffset;

		public float delayBeforeAppearing;

		[SerializeField]
		private float _activeAnimationDuration = 1f;

		[SerializeField]
		private Easings.Functions _activeAnimationEasing;

		[SerializeField]
		private Transform _inactiveAnchor;

		[SerializeField]
		[EnableIf("UseInactiveAchorForPosition")]
		private float _inactiveAnimationDelay;

		[SerializeField]
		[EnableIf("UseInactiveAchorForPosition")]
		private float _inactiveAnimationDuration = 1f;

		[SerializeField]
		[EnableIf("UseInactiveAchorForPosition")]
		private Easings.Functions _inactiveAnimationEasing;

		[SerializeField]
		[Tooltip("The shuffle animation is played when the element is already visible and not animating, and has to move to a new position. It is only used by the upgrade icons.")]
		private float _shuffleAnimationDuration = 0.5f;

		[SerializeField]
		private Easings.Functions _shuffleAnimationEasing;

		[Tooltip("If set, the associated graphic will be hidden when the floating element has completed its deactivation animation.")]
		public bool hideIfFallingBack = true;

		public bool movementControlledByScript;

		[EnableIf("hideIfFallingBack")]
		public bool getAllChildGraphics;

		[EnableIf("ShouldShowGraphics")]
		public Graphic[] graphics;

		[Tooltip("If the active anchor's visibility is toggled while the element is already animating, should it animate from the world-space position, or snap to the canonical position? Canonical is reliable, but world-space looks nicer and avoid snaps if you can guarantee the stability of the anchors.")]
		[SerializeField]
		private AnimationOrigin _interruptingAnimationOrigin;

		public HiddenTrigger onOptionTriggered = new HiddenTrigger();

		private CanvasGroup _canvasGroup;

		private bool _wasDisabled = true;

		private float _appearTimer;

		private float _disappearTimer;

		private bool _isActivePositionUnstable;

		private Vector3 _lastKnownGoodActiveLocalPosition;

		private Vector3 _lastLocalActivePosition;

		private float _animationTime;

		private float _animationDuration;

		private AnimationOrigin _animationOrigin;

		private Vector3 _initialWorldPosition;

		private Easings.Functions _animationEasing;

		private const float DistanceTolerance = 1f;

		private const float MinAppearDelay = 0.01f;

		public GameObject InactiveAnchor => _inactiveAnchor.gameObject;

		public bool IsAnimating { get; private set; }

		public bool IsActive { get; set; }

		public bool BaseElementActive => baseElement.activeInHierarchy;

		private Vector3 ActivePosition
		{
			get
			{
				if (_isActivePositionUnstable && !baseElement.activeInHierarchy)
				{
					return baseElement.transform.parent.localToWorldMatrix.MultiplyPoint(_lastKnownGoodActiveLocalPosition);
				}
				return baseElement.transform.position;
			}
		}

		private Vector3 InactivePosition
		{
			get
			{
				if (UseInactiveAchorForPosition())
				{
					return _inactiveAnchor.position;
				}
				return ActivePosition + base.transform.rotation * fallbackOffset;
			}
		}

		public void SetInactiveAnchor(Transform inactiveAnchor)
		{
			_inactiveAnchor = inactiveAnchor;
		}

		private bool ShouldShowGraphics()
		{
			if (!getAllChildGraphics)
			{
				return hideIfFallingBack;
			}
			return false;
		}

		private void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			if (hideIfFallingBack)
			{
				if (getAllChildGraphics)
				{
					graphics = GetComponentsInChildren<Graphic>();
				}
				if ((graphics != null || _canvasGroup != null) && !baseElement.activeInHierarchy)
				{
					base.transform.position = InactivePosition;
					SetGraphicsEnabled(isEnabled: false);
				}
			}
			ResetTimers();
			IsAnimating = false;
			_isActivePositionUnstable = baseElement.transform.parent.GetComponent<LayoutGroup>() != null;
		}

		private void OnEnable()
		{
			Snap();
		}

		public void Snap()
		{
			_wasDisabled = !baseElement.activeInHierarchy;
			base.transform.position = (_wasDisabled ? InactivePosition : ActivePosition);
			if (hideIfFallingBack)
			{
				SetGraphicsEnabled(!_wasDisabled);
			}
			ResetTimers();
			IsAnimating = false;
		}

		private void Update()
		{
			bool flag = (movementControlledByScript ? IsActive : BaseElementActive);
			Vector3 vector;
			Vector3 vector2;
			if (!flag)
			{
				vector = ActivePosition;
				vector2 = InactivePosition;
				if (!_wasDisabled)
				{
					if (_disappearTimer <= 0f || IsAnimating)
					{
						StartAnimation(IsAnimating ? _interruptingAnimationOrigin : AnimationOrigin.Canonical, _inactiveAnimationDuration, _inactiveAnimationEasing);
						_wasDisabled = true;
						ResetTimers();
						onOptionTriggered.Invoke(arg0: false);
					}
					else
					{
						IsAnimating = false;
						_disappearTimer -= Time.deltaTime;
					}
				}
				else if (!IsAnimating)
				{
					base.transform.position = vector2;
				}
			}
			else
			{
				vector = InactivePosition;
				vector2 = ActivePosition;
				Vector3 localPosition = baseElement.transform.localPosition;
				if (_isActivePositionUnstable)
				{
					_lastKnownGoodActiveLocalPosition = localPosition;
				}
				if (_wasDisabled)
				{
					if (_appearTimer <= 0f || IsAnimating)
					{
						StartAnimation(IsAnimating ? _interruptingAnimationOrigin : AnimationOrigin.Canonical, _activeAnimationDuration, _activeAnimationEasing);
						SetGraphicsEnabled(isEnabled: true);
						_wasDisabled = false;
						ResetTimers();
						_disappearTimer = _inactiveAnimationDelay;
						onOptionTriggered.Invoke(arg0: true);
					}
					else
					{
						_appearTimer -= Time.deltaTime;
						IsAnimating = false;
						base.transform.position = vector;
					}
				}
				else if (!IsAnimating)
				{
					if (Vector3.SqrMagnitude(_lastLocalActivePosition - localPosition) > 1f)
					{
						StartAnimation(AnimationOrigin.WorldSpace, _shuffleAnimationDuration, _shuffleAnimationEasing);
					}
					else
					{
						base.transform.position = vector2;
					}
				}
				_lastLocalActivePosition = localPosition;
			}
			if (!IsAnimating)
			{
				return;
			}
			_animationTime += Time.deltaTime;
			if (_animationTime >= _animationDuration)
			{
				base.transform.position = vector2;
				ResetTimers();
				IsAnimating = false;
				if (!flag && hideIfFallingBack)
				{
					SetGraphicsEnabled(isEnabled: false);
				}
			}
			else
			{
				float t = Easings.Interpolate(_animationTime / _animationDuration, _animationEasing);
				base.transform.position = Vector3.LerpUnclamped((_animationOrigin == AnimationOrigin.Canonical) ? vector : _initialWorldPosition, vector2, t);
			}
		}

		public bool UseInactiveAchorForPosition()
		{
			return _inactiveAnchor != null;
		}

		private void StartAnimation(AnimationOrigin origin, float duration, Easings.Functions easing)
		{
			_animationOrigin = origin;
			_initialWorldPosition = base.transform.position;
			IsAnimating = true;
			_animationTime = 0f;
			_animationDuration = duration;
			_animationEasing = easing;
		}

		private void ResetTimers()
		{
			_appearTimer = Mathf.Max(0.01f, delayBeforeAppearing);
			_disappearTimer = _inactiveAnimationDelay;
		}

		private void SetGraphicsEnabled(bool isEnabled)
		{
			Graphic[] array = graphics;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = isEnabled;
			}
			if (_canvasGroup != null)
			{
				_canvasGroup.alpha = (isEnabled ? 1 : 0);
			}
		}
	}
}
