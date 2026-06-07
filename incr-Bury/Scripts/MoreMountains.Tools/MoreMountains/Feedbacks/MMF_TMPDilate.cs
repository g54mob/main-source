using System.Collections;
using MoreMountains.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback lets you dilate a TMP text over time.")]
	[FeedbackPath("TextMesh Pro/TMP Dilate")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.TextMeshPro", null)]
	public class MMF_TMPDilate : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Target", true, 12, true, false)]
		[Tooltip("the TMP_Text component to control")]
		public TMP_Text TargetTMPText;

		[MMFInspectorGroup("Dilate", true, 16, false, false)]
		[Tooltip("whether or not values should be relative")]
		public bool RelativeValues = true;

		[Tooltip("the selected mode")]
		public MMFeedbackBase.Modes Mode;

		[Tooltip("the duration of the feedback, in seconds")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float Duration = 0.5f;

		[Tooltip("the curve to tween on")]
		public MMTweenType DilateCurve = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0.5f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0.5f)), "", "Mode", default(int));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapZero = -1f;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapOne = 1f;

		[Tooltip("the value to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantDilate;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		protected float _initialDilate;

		protected Coroutine _coroutine;

		public override bool HasCustomInspectors => true;

		public override float FeedbackDuration
		{
			get
			{
				if (Mode != MMFeedbackBase.Modes.Instant)
				{
					return ApplyTimeMultiplier(Duration);
				}
				return 0f;
			}
			set
			{
				Duration = value;
			}
		}

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetTMPText = FindAutomatedTarget<TMP_Text>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active)
			{
				if (TargetTMPText == null)
				{
					Debug.LogWarning("[TMP Dilate Feedback] The TMP Dilate feedback on " + Owner.name + " doesn't have a TargetTMPText, it won't work. You need to specify one in its inspector.");
				}
				else
				{
					_initialDilate = TargetTMPText.fontMaterial.GetFloat(ShaderUtilities.ID_FaceDilate);
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || TargetTMPText == null || !Active)
			{
				return;
			}
			switch (Mode)
			{
			case MMFeedbackBase.Modes.Instant:
			{
				float value = (NormalPlayDirection ? InstantDilate : _initialDilate);
				TargetTMPText.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, value);
				TargetTMPText.UpdateMeshPadding();
				break;
			}
			case MMFeedbackBase.Modes.OverTime:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(ApplyValueOverTime());
				}
				break;
			}
		}

		protected virtual IEnumerator ApplyValueOverTime()
		{
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			IsPlaying = true;
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float value = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				SetValue(value);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetValue(FinalNormalizedTime);
			_coroutine = null;
			IsPlaying = false;
			yield return null;
		}

		protected virtual void SetValue(float time)
		{
			float num = MMTween.Tween(time, 0f, 1f, RemapZero, RemapOne, DilateCurve);
			if (RelativeValues)
			{
				num += _initialDilate;
			}
			TargetTMPText.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, num);
			TargetTMPText.UpdateMeshPadding();
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
					_coroutine = null;
				}
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				TargetTMPText.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, _initialDilate);
				TargetTMPText.UpdateMeshPadding();
			}
		}

		public override void OnValidate()
		{
			base.OnValidate();
			if (string.IsNullOrEmpty(DilateCurve.EnumConditionPropertyName))
			{
				DilateCurve.EnumConditionPropertyName = "Mode";
				DilateCurve.EnumConditions = new bool[32];
				DilateCurve.EnumConditions[0] = true;
			}
		}
	}
}
