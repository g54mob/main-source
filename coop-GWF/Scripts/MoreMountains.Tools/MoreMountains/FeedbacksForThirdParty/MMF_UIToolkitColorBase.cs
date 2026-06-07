using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Serialization;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	public class MMF_UIToolkitColorBase : MMF_UIToolkit
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1
		}

		[MMFInspectorGroup("Color", true, 55, true, false)]
		[Tooltip("whether the feedback should affect the Image instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the Image should change over time")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float Duration = 0.2f;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("whether or not to modify the color of the image")]
		public bool ModifyColor = true;

		[Tooltip("the colors to apply to the Image over time")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Gradient ColorOverTime = new Gradient
		{
			colorKeys = new GradientColorKey[3]
			{
				new GradientColorKey(Color.white, 0f),
				new GradientColorKey(Color.red, 0.5f),
				new GradientColorKey(Color.white, 1f)
			},
			alphaKeys = new GradientAlphaKey[3]
			{
				new GradientAlphaKey(1f, 0f),
				new GradientAlphaKey(1f, 0.5f),
				new GradientAlphaKey(1f, 1f)
			}
		};

		[Tooltip("the color to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public Color InstantColor;

		[Tooltip("if this is true, the initial color will be applied to the gradient start")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public bool ApplyInitialColorToGradientStart;

		[Tooltip("if this is true, the initial color will be applied to the gradient end")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public bool ApplyInitialColorToGradientEnd;

		[FormerlySerializedAs("GrabInitialColorsOnPlay")]
		[Tooltip("if this is true, the initial color will be applied to the gradient start and end on play")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public bool ApplyInitialColorsOnPlay = true;

		protected Coroutine _coroutine;

		protected Color _initialColor;

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

		public override bool HasChannel => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			HandleApplyInitialColors();
		}

		protected virtual void HandleApplyInitialColors()
		{
			GradientColorKey[] colorKeys = ColorOverTime.colorKeys;
			GradientAlphaKey[] alphaKeys = ColorOverTime.alphaKeys;
			if (ApplyInitialColorToGradientStart)
			{
				colorKeys[0] = new GradientColorKey(GetInitialColor(), 0f);
				alphaKeys[0] = new GradientAlphaKey(GetInitialColor().a, 0f);
			}
			if (ApplyInitialColorToGradientEnd)
			{
				int num = ColorOverTime.colorKeys.Length - 1;
				colorKeys[num] = new GradientColorKey(GetInitialColor(), 1f);
				alphaKeys[num] = new GradientAlphaKey(GetInitialColor().a, 1f);
			}
			if (ApplyInitialColorToGradientEnd || ApplyInitialColorToGradientStart)
			{
				ColorOverTime.SetKeys(colorKeys, alphaKeys);
			}
		}

		protected virtual void ApplyColor(Color newColor)
		{
		}

		protected virtual Color GetInitialColor()
		{
			return Color.white;
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !MMF_UIToolkit.FeedbackTypeAuthorized)
			{
				return;
			}
			_initialColor = GetInitialColor();
			if (ApplyInitialColorsOnPlay)
			{
				HandleApplyInitialColors();
			}
			switch (Mode)
			{
			case Modes.Instant:
				if (ModifyColor)
				{
					ApplyColor(InstantColor);
				}
				break;
			case Modes.OverTime:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(ImageSequence());
				}
				break;
			}
		}

		protected virtual IEnumerator ImageSequence()
		{
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			IsPlaying = true;
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float imageValues = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				SetImageValues(imageValues);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetImageValues(FinalNormalizedTime);
			IsPlaying = false;
			_coroutine = null;
			yield return null;
		}

		protected virtual void SetImageValues(float time)
		{
			if (ModifyColor)
			{
				ApplyColor(ColorOverTime.Evaluate(time));
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && MMF_UIToolkit.FeedbackTypeAuthorized)
			{
				IsPlaying = false;
				base.CustomStopFeedback(position, feedbacksIntensity);
				_coroutine = null;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && MMF_UIToolkit.FeedbackTypeAuthorized)
			{
				ApplyColor(_initialColor);
			}
		}
	}
}
