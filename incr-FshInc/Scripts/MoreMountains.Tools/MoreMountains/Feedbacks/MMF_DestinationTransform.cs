using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you animate the position/rotation/scale of a target transform to match the one of a destination transform.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Transform/Destination")]
	public class MMF_DestinationTransform : MMF_Feedback
	{
		public enum TimeScales
		{
			Scaled = 0,
			Unscaled = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Target to animate", true, 61, true, false)]
		[Tooltip("the target transform we want to animate properties on")]
		public Transform TargetTransform;

		[Tooltip("whether or not we want to force an origin transform. If not, the current position of the target transform will be used as origin instead")]
		public bool ForceOrigin;

		[Tooltip("the transform to use as origin in ForceOrigin mode")]
		[MMFCondition("ForceOrigin", true)]
		public Transform Origin;

		[Tooltip("the destination transform whose properties we want to match")]
		public Transform Destination;

		[MMFInspectorGroup("Transition", true, 63, false, false)]
		[Tooltip("a global curve to animate all properties on, unless dedicated ones are specified")]
		public MMTweenType GlobalAnimationTween = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "", "");

		[Tooltip("the duration of the transition, in seconds")]
		public float Duration = 0.2f;

		[Tooltip("if this is true, the destination will be updated every frame, allowing for dynamic changes to the destination transform, otherwise the destination will be cached on init and not updated after that")]
		public bool UpdateDestinationEveryFrame;

		[MMFInspectorGroup("Axis Locks", true, 64, false, false)]
		[Tooltip("whether or not to animate the X Position")]
		public bool AnimatePositionX = true;

		[Tooltip("whether or not to animate the Y Position")]
		public bool AnimatePositionY = true;

		[Tooltip("whether or not to animate the Z Position")]
		public bool AnimatePositionZ = true;

		[Tooltip("whether or not to animate the X rotation")]
		public bool AnimateRotationX = true;

		[Tooltip("whether or not to animate the Y rotation")]
		public bool AnimateRotationY = true;

		[Tooltip("whether or not to animate the Z rotation")]
		public bool AnimateRotationZ = true;

		[Tooltip("whether or not to animate the W rotation")]
		public bool AnimateRotationW = true;

		[Tooltip("whether or not to animate the X scale")]
		public bool AnimateScaleX = true;

		[Tooltip("whether or not to animate the Y scale")]
		public bool AnimateScaleY = true;

		[Tooltip("whether or not to animate the Z scale")]
		public bool AnimateScaleZ = true;

		[MMFInspectorGroup("Separate Curves", true, 65, false, false)]
		[Tooltip("whether or not to use a separate animation curve to animate the position")]
		public bool SeparatePositionCurve;

		[Tooltip("the curve to use to animate the position on")]
		public MMTweenType AnimatePositionTween = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "SeparatePositionCurve", "");

		[Tooltip("whether or not to use a separate animation curve to animate the rotation")]
		public bool SeparateRotationCurve;

		[Tooltip("the curve to use to animate the rotation on")]
		public MMTweenType AnimateRotationTween = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "SeparateRotationCurve", "");

		[Tooltip("whether or not to use a separate animation curve to animate the scale")]
		public bool SeparateScaleCurve;

		[Tooltip("the curve to use to animate the scale on")]
		public MMTweenType AnimateScaleTween = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "SeparateScaleCurve", "");

		[HideInInspector]
		public AnimationCurve GlobalAnimationCurve;

		[HideInInspector]
		public AnimationCurve AnimateScaleCurve;

		[HideInInspector]
		public AnimationCurve AnimatePositionCurve;

		[HideInInspector]
		public AnimationCurve AnimateRotationCurve;

		protected Coroutine _coroutine;

		protected Vector3 _newPosition;

		protected Quaternion _newRotation;

		protected Vector3 _newScale;

		protected Vector3 _pointAPosition;

		protected Vector3 _pointBPosition;

		protected Quaternion _pointARotation;

		protected Quaternion _pointBRotation;

		protected Vector3 _pointAScale;

		protected Vector3 _pointBScale;

		protected MMTweenType _animationTweenType;

		protected Vector3 _initialPosition;

		protected Vector3 _initialScale;

		protected Quaternion _initialRotation;

		public override bool HasAutomatedTargetAcquisition => true;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(Duration);
			}
			set
			{
				Duration = value;
			}
		}

		protected override void AutomateTargetAcquisition()
		{
			TargetTransform = FindAutomatedTarget<Transform>();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetTransform == null))
			{
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
				}
				_coroutine = Owner.StartCoroutine(AnimateToDestination());
			}
		}

		protected virtual IEnumerator AnimateToDestination()
		{
			_initialPosition = TargetTransform.position;
			_initialRotation = TargetTransform.rotation;
			_initialScale = TargetTransform.localScale;
			_pointAPosition = (ForceOrigin ? Origin.transform.position : TargetTransform.position);
			_pointARotation = (ForceOrigin ? Origin.transform.rotation : TargetTransform.rotation);
			_pointAScale = (ForceOrigin ? Origin.transform.localScale : TargetTransform.localScale);
			CacheDestinationValues();
			IsPlaying = true;
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				if (UpdateDestinationEveryFrame)
				{
					CacheDestinationValues();
				}
				float percent = Mathf.Clamp01(journey / FeedbackDuration);
				ChangeTransformValues(percent);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			ChangeTransformValues(1f);
			IsPlaying = false;
			_coroutine = null;
		}

		protected virtual void CacheDestinationValues()
		{
			_pointBPosition = Destination.transform.position;
			if (!AnimatePositionX)
			{
				_pointAPosition.x = TargetTransform.position.x;
				_pointBPosition.x = _pointAPosition.x;
			}
			if (!AnimatePositionY)
			{
				_pointAPosition.y = TargetTransform.position.y;
				_pointBPosition.y = _pointAPosition.y;
			}
			if (!AnimatePositionZ)
			{
				_pointAPosition.z = TargetTransform.position.z;
				_pointBPosition.z = _pointAPosition.z;
			}
			_pointBRotation = Destination.transform.rotation;
			if (!AnimateRotationX)
			{
				_pointARotation.x = TargetTransform.rotation.x;
				_pointBRotation.x = _pointARotation.x;
			}
			if (!AnimateRotationY)
			{
				_pointARotation.y = TargetTransform.rotation.y;
				_pointBRotation.y = _pointARotation.y;
			}
			if (!AnimateRotationZ)
			{
				_pointARotation.z = TargetTransform.rotation.z;
				_pointBRotation.z = _pointARotation.z;
			}
			if (!AnimateRotationW)
			{
				_pointARotation.w = TargetTransform.rotation.w;
				_pointBRotation.w = _pointARotation.w;
			}
			_pointBScale = Destination.transform.localScale;
			if (!AnimateScaleX)
			{
				_pointAScale.x = TargetTransform.localScale.x;
				_pointBScale.x = _pointAScale.x;
			}
			if (!AnimateScaleY)
			{
				_pointAScale.y = TargetTransform.localScale.y;
				_pointBScale.y = _pointAScale.y;
			}
			if (!AnimateScaleZ)
			{
				_pointAScale.z = TargetTransform.localScale.z;
				_pointBScale.z = _pointAScale.z;
			}
		}

		protected virtual void ChangeTransformValues(float percent)
		{
			_animationTweenType = (SeparatePositionCurve ? AnimatePositionTween : GlobalAnimationTween);
			_newPosition = Vector3.LerpUnclamped(_pointAPosition, _pointBPosition, _animationTweenType.Evaluate(percent));
			_animationTweenType = (SeparateRotationCurve ? AnimateRotationTween : GlobalAnimationTween);
			_newRotation = Quaternion.LerpUnclamped(_pointARotation, _pointBRotation, _animationTweenType.Evaluate(percent));
			_animationTweenType = (SeparateScaleCurve ? AnimateScaleTween : GlobalAnimationTween);
			_newScale = Vector3.LerpUnclamped(_pointAScale, _pointBScale, _animationTweenType.Evaluate(percent));
			TargetTransform.position = _newPosition;
			TargetTransform.rotation = _newRotation;
			TargetTransform.localScale = _newScale;
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
				if (TargetTransform != null && _coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
				}
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				TargetTransform.position = _initialPosition;
				TargetTransform.rotation = _initialRotation;
				TargetTransform.localScale = _initialScale;
			}
		}

		public override void OnValidate()
		{
			base.OnValidate();
			MMFeedbacksHelpers.MigrateCurve(GlobalAnimationCurve, GlobalAnimationTween, Owner);
			MMFeedbacksHelpers.MigrateCurve(AnimatePositionCurve, AnimatePositionTween, Owner);
			MMFeedbacksHelpers.MigrateCurve(AnimateRotationCurve, AnimateRotationTween, Owner);
			MMFeedbacksHelpers.MigrateCurve(AnimateScaleCurve, AnimateScaleTween, Owner);
			if (string.IsNullOrEmpty(AnimatePositionTween.ConditionPropertyName))
			{
				AnimatePositionTween.ConditionPropertyName = "SeparatePositionCurve";
				AnimateRotationTween.ConditionPropertyName = "SeparateRotationCurve";
				AnimateScaleTween.ConditionPropertyName = "SeparateScaleCurve";
			}
		}
	}
}
