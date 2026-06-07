using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will animate the target object's position over time, for the specified duration, from the chosen initial position to the chosen destination. These can either be relative Vector3 offsets from the Feedback's position, or Transforms. If you specify transforms, the Vector3 values will be ignored.")]
	[FeedbackPath("Transform/Position")]
	public class MMF_Position : MMF_Feedback
	{
		public enum Spaces
		{
			World = 0,
			Local = 1,
			RectTransform = 2,
			Self = 3
		}

		public enum Modes
		{
			AtoB = 0,
			AlongCurve = 1,
			ToDestination = 2
		}

		public enum TimeScales
		{
			Scaled = 0,
			Unscaled = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Position Target", true, 61, true, false)]
		[Tooltip("the object this feedback will animate the position for")]
		public GameObject AnimatePositionTarget;

		[MMFInspectorGroup("Transition", true, 63, false, false)]
		[Tooltip("the mode this animation should follow (either going from A to B, or moving along a curve)")]
		public Modes Mode;

		[Tooltip("the space in which to move the position in")]
		public Spaces Space;

		[Tooltip("whether or not to randomize remap values between their base and alt values on play, useful to add some variety every time you play this feedback")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public bool RandomizeRemap;

		[Tooltip("the duration of the animation on play")]
		public float AnimatePositionDuration = 0.2f;

		[Tooltip("the MMTween curve definition to use instead of the animation curve to define the acceleration of the movement")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public MMTweenType AnimatePositionTween = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)));

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the value to remap the curve's 0 value to")]
		public float RemapCurveZero;

		[MMFCondition("RandomizeRemap", true)]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("in randomize remap mode, the value to remap the curve's 0 value to (randomized between this and RemapCurveZero")]
		public float RemapCurveZeroAlt;

		[Tooltip("the value to remap the curve's 1 value to")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		[FormerlySerializedAs("CurveMultiplier")]
		public float RemapCurveOne = 1f;

		[Tooltip("in randomize remap mode, the value to remap the curve's 1 value to (randomized between this and RemapCurveOne)")]
		[MMFCondition("RandomizeRemap", true)]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float RemapCurveOneAlt = 1f;

		[Tooltip("if this is true, the x position will be animated")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public bool AnimateX;

		[Tooltip("the acceleration of the movement")]
		[MMFCondition("AnimateX", true)]
		public MMTweenType AnimatePositionTweenX = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(0.6f, -1f), new Keyframe(1f, 0f)));

		[Tooltip("if this is true, the y position will be animated")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public bool AnimateY;

		[Tooltip("the acceleration of the movement")]
		[MMFCondition("AnimateY", true)]
		public MMTweenType AnimatePositionTweenY = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(0.6f, -1f), new Keyframe(1f, 0f)));

		[Tooltip("if this is true, the z position will be animated")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public bool AnimateZ;

		[Tooltip("the acceleration of the movement")]
		[MMFCondition("AnimateZ", true)]
		public MMTweenType AnimatePositionTweenZ = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(0.6f, -1f), new Keyframe(1f, 0f)));

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[MMFInspectorGroup("Positions", true, 64, false, false)]
		[Tooltip("if this is true, the initial position won't be added to init and destination")]
		public bool RelativePosition = true;

		[Tooltip("if this is true, initial and destination positions will be recomputed on every play")]
		public bool DeterminePositionsOnPlay;

		[Tooltip("the initial position")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector3 InitialPosition = Vector3.zero;

		[Tooltip("the destination position")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public Vector3 DestinationPosition = Vector3.one;

		[Tooltip("the initial transform - if set, takes precedence over the Vector3 above")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Transform InitialPositionTransform;

		[Tooltip("the destination transform - if set, takes precedence over the Vector3 above")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public Transform DestinationPositionTransform;

		[HideInInspector]
		public AnimationCurve AnimatePositionCurveX;

		[HideInInspector]
		public AnimationCurve AnimatePositionCurveY;

		[HideInInspector]
		public AnimationCurve AnimatePositionCurveZ;

		[HideInInspector]
		public AnimationCurve AnimatePositionCurve;

		protected Vector3 _newPosition;

		protected Vector3 _currentPosition;

		protected RectTransform _rectTransform;

		protected Vector3 _initialPosition;

		protected Vector3 _destinationPosition;

		protected Coroutine _coroutine;

		protected Vector3 _workInitialPosition;

		protected float _remapCurveZero;

		protected float _remapCurveOne;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(AnimatePositionDuration);
			}
			set
			{
				AnimatePositionDuration = value;
			}
		}

		public override bool HasRandomness => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (!Active)
			{
				return;
			}
			if (AnimatePositionTarget == null)
			{
				Debug.LogWarning("The animate position target for " + this?.ToString() + " is null, you have to define it in the inspector");
				return;
			}
			if (Space == Spaces.RectTransform)
			{
				_rectTransform = AnimatePositionTarget.GetComponent<RectTransform>();
			}
			if (!DeterminePositionsOnPlay)
			{
				DeterminePositions();
			}
		}

		protected virtual void DeterminePositions()
		{
			if (DeterminePositionsOnPlay && RelativePosition && InitialPosition != Vector3.zero)
			{
				return;
			}
			if (InitialPositionTransform != null)
			{
				_workInitialPosition = GetPosition(InitialPositionTransform);
			}
			else
			{
				_workInitialPosition = (RelativePosition ? (GetPosition(AnimatePositionTarget.transform) + InitialPosition) : GetPosition(AnimatePositionTarget.transform));
			}
			if (Mode != Modes.ToDestination)
			{
				if (DestinationPositionTransform != null)
				{
					DestinationPosition = GetPosition(DestinationPositionTransform);
				}
				else
				{
					DestinationPosition = (RelativePosition ? (GetPosition(AnimatePositionTarget.transform) + DestinationPosition) : DestinationPosition);
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || AnimatePositionTarget == null || (!Active && !Owner.AutoPlayOnEnable))
			{
				return;
			}
			if (DeterminePositionsOnPlay && NormalPlayDirection)
			{
				DeterminePositions();
			}
			switch (Mode)
			{
			case Modes.ToDestination:
				_initialPosition = GetPosition(AnimatePositionTarget.transform);
				_destinationPosition = (RelativePosition ? (_initialPosition + DestinationPosition) : DestinationPosition);
				if (DestinationPositionTransform != null)
				{
					_destinationPosition = GetPosition(DestinationPositionTransform);
				}
				_coroutine = Owner.StartCoroutine(MoveFromTo(AnimatePositionTarget, _initialPosition, _destinationPosition, FeedbackDuration, AnimatePositionTween));
				break;
			case Modes.AtoB:
				if (AllowAdditivePlays || _coroutine == null)
				{
					_coroutine = Owner.StartCoroutine(MoveFromTo(AnimatePositionTarget, _workInitialPosition, DestinationPosition, FeedbackDuration, AnimatePositionTween));
				}
				break;
			case Modes.AlongCurve:
				if (AllowAdditivePlays || _coroutine == null)
				{
					float intensityMultiplier = ComputeIntensity(feedbacksIntensity);
					_remapCurveZero = (RandomizeRemap ? Random.Range(RemapCurveZero, RemapCurveZeroAlt) : RemapCurveZero);
					_remapCurveOne = (RandomizeRemap ? Random.Range(RemapCurveOne, RemapCurveOneAlt) : RemapCurveOne);
					_coroutine = Owner.StartCoroutine(MoveAlongCurve(AnimatePositionTarget, _workInitialPosition, FeedbackDuration, intensityMultiplier));
				}
				break;
			}
		}

		protected virtual IEnumerator MoveAlongCurve(GameObject movingObject, Vector3 initialPosition, float duration, float intensityMultiplier)
		{
			IsPlaying = true;
			float journey = (NormalPlayDirection ? 0f : duration);
			while (journey >= 0f && journey <= duration && duration > 0f)
			{
				float percent = Mathf.Clamp01(journey / duration);
				ComputeNewCurvePosition(movingObject, initialPosition, percent, intensityMultiplier);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			ComputeNewCurvePosition(movingObject, initialPosition, FinalNormalizedTime, intensityMultiplier);
			_coroutine = null;
			IsPlaying = false;
		}

		protected virtual void ComputeNewCurvePosition(GameObject movingObject, Vector3 initialPosition, float percent, float intensityMultiplier)
		{
			float num = MMTween.Tween(percent, 0f, 1f, _remapCurveZero * intensityMultiplier, _remapCurveOne * intensityMultiplier, AnimatePositionTweenX);
			float num2 = MMTween.Tween(percent, 0f, 1f, _remapCurveZero * intensityMultiplier, _remapCurveOne * intensityMultiplier, AnimatePositionTweenY);
			float num3 = MMTween.Tween(percent, 0f, 1f, _remapCurveZero * intensityMultiplier, _remapCurveOne * intensityMultiplier, AnimatePositionTweenZ);
			_newPosition = initialPosition;
			_currentPosition = GetPosition(movingObject.transform);
			if (RelativePosition)
			{
				_newPosition.x = (AnimateX ? (initialPosition.x + num) : _currentPosition.x);
				_newPosition.y = (AnimateY ? (initialPosition.y + num2) : _currentPosition.y);
				_newPosition.z = (AnimateZ ? (initialPosition.z + num3) : _currentPosition.z);
			}
			else
			{
				_newPosition.x = (AnimateX ? num : _currentPosition.x);
				_newPosition.y = (AnimateY ? num2 : _currentPosition.y);
				_newPosition.z = (AnimateZ ? num3 : _currentPosition.z);
			}
			if (Space == Spaces.Self)
			{
				_newPosition.x = (AnimateX ? num : 0f);
				_newPosition.y = (AnimateY ? num2 : 0f);
				_newPosition.z = (AnimateZ ? num3 : 0f);
			}
			SetPosition(movingObject.transform, _newPosition);
		}

		protected virtual IEnumerator MoveFromTo(GameObject movingObject, Vector3 pointA, Vector3 pointB, float duration, MMTweenType tweenType)
		{
			IsPlaying = true;
			float journey = (NormalPlayDirection ? 0f : duration);
			while (journey >= 0f && journey <= duration && duration > 0f)
			{
				float t = MMTween.Tween(journey, 0f, duration, 0f, 1f, tweenType);
				_newPosition = Vector3.LerpUnclamped(pointA, pointB, t);
				SetPosition(movingObject.transform, _newPosition);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			if (NormalPlayDirection)
			{
				SetPosition(movingObject.transform, pointB);
			}
			else
			{
				SetPosition(movingObject.transform, pointA);
			}
			_coroutine = null;
			IsPlaying = false;
		}

		protected virtual Vector3 GetPosition(Transform target)
		{
			return Space switch
			{
				Spaces.World => target.position, 
				Spaces.Local => target.localPosition, 
				Spaces.RectTransform => target.gameObject.GetComponent<RectTransform>().anchoredPosition, 
				Spaces.Self => target.position, 
				_ => Vector3.zero, 
			};
		}

		protected virtual void SetPosition(Transform target, Vector3 newPosition)
		{
			switch (Space)
			{
			case Spaces.World:
				target.position = newPosition;
				break;
			case Spaces.Local:
				target.localPosition = newPosition;
				break;
			case Spaces.RectTransform:
				_rectTransform.anchoredPosition = newPosition;
				break;
			case Spaces.Self:
				target.position = _workInitialPosition;
				if (Mode == Modes.AtoB || Mode == Modes.ToDestination)
				{
					newPosition -= _workInitialPosition;
				}
				target.Translate(newPosition, target);
				break;
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && _coroutine != null)
			{
				IsPlaying = false;
				Owner.StopCoroutine(_coroutine);
				_coroutine = null;
			}
		}

		public override void OnDisable()
		{
			_coroutine = null;
		}

		public override void OnValidate()
		{
			base.OnValidate();
			MMFeedbacksHelpers.MigrateCurve(AnimatePositionCurve, AnimatePositionTween, Owner);
			MMFeedbacksHelpers.MigrateCurve(AnimatePositionCurveX, AnimatePositionTweenX, Owner);
			MMFeedbacksHelpers.MigrateCurve(AnimatePositionCurveY, AnimatePositionTweenY, Owner);
			MMFeedbacksHelpers.MigrateCurve(AnimatePositionCurveZ, AnimatePositionTweenZ, Owner);
		}
	}
}
