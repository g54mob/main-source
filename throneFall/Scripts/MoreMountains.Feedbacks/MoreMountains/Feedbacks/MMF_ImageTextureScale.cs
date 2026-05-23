using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you control the texture scale of a target UI Image over time.")]
	[FeedbackPath("UI/Image Texture Scale")]
	public class MMF_ImageTextureScale : MMF_Feedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1
		}

		public enum MaterialPropertyTypes
		{
			Main = 0,
			TextureID = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Texture Scale", true, 63, true, false)]
		[Tooltip("the UI Image on which to change texture scale on")]
		public Image TargetImage;

		[Tooltip("whether to target the main texture property, or one specified in MaterialPropertyName")]
		public MaterialPropertyTypes MaterialPropertyType;

		[Tooltip("the property name, for example _MainTex_ST, or _MainTex if you don't have UseMaterialPropertyBlocks set to true")]
		[MMEnumCondition("MaterialPropertyType", new int[] { 1 })]
		public string MaterialPropertyName = "_MainTex_ST";

		[Tooltip("whether the feedback should affect the material instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the material should change over time")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float Duration = 0.2f;

		[Tooltip("whether or not the values should be relative")]
		public bool RelativeValues = true;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[MMFInspectorGroup("Intensity", true, 65, false, false)]
		[Tooltip("the curve to tween the scale on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public AnimationCurve ScaleCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the scale curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 RemapZero = Vector2.zero;

		[Tooltip("the value to remap the scale curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 RemapOne = Vector2.one;

		[Tooltip("the value to move the intensity to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public Vector2 InstantScale;

		protected Vector2 _initialValue;

		protected Coroutine _coroutine;

		protected Vector2 _newValue;

		protected Material _material;

		public override bool HasRandomness => true;

		public override float FeedbackDuration
		{
			get
			{
				if (Mode != Modes.Instant)
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

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			_material = TargetImage.material;
			switch (MaterialPropertyType)
			{
			case MaterialPropertyTypes.Main:
				_initialValue = _material.mainTextureScale;
				break;
			case MaterialPropertyTypes.TextureID:
				_initialValue = _material.GetTextureScale(MaterialPropertyName);
				break;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			float num = ComputeIntensity(feedbacksIntensity);
			switch (Mode)
			{
			case Modes.Instant:
				ApplyValue(InstantScale * num);
				break;
			case Modes.OverTime:
				if (AllowAdditivePlays || _coroutine == null)
				{
					_coroutine = Owner.StartCoroutine(TransitionCo(num));
				}
				break;
			}
		}

		protected virtual IEnumerator TransitionCo(float intensityMultiplier)
		{
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			IsPlaying = true;
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float time = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				SetMaterialValues(time, intensityMultiplier);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetMaterialValues(FinalNormalizedTime, intensityMultiplier);
			IsPlaying = false;
			_coroutine = null;
			yield return null;
		}

		protected virtual void SetMaterialValues(float time, float intensityMultiplier)
		{
			_newValue.x = MMFeedbacksHelpers.Remap(ScaleCurve.Evaluate(time), 0f, 1f, RemapZero.x, RemapOne.x);
			_newValue.y = MMFeedbacksHelpers.Remap(ScaleCurve.Evaluate(time), 0f, 1f, RemapZero.y, RemapOne.y);
			if (RelativeValues)
			{
				_newValue += _initialValue;
			}
			ApplyValue(_newValue * intensityMultiplier);
		}

		protected virtual void ApplyValue(Vector2 newValue)
		{
			switch (MaterialPropertyType)
			{
			case MaterialPropertyTypes.Main:
				_material.mainTextureScale = newValue;
				break;
			case MaterialPropertyTypes.TextureID:
				_material.SetTextureScale(MaterialPropertyName, newValue);
				break;
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && _coroutine != null)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
				Owner.StopCoroutine(_coroutine);
				_coroutine = null;
			}
		}
	}
}
