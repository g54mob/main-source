using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Modifiers;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.HideAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new GenericHideAnimation", menuName = "TMPEffects/Animations/Hide Animations/Generic Animation")]
	public sealed class GenericHideAnimation : TMPHideAnimation, IGenericAnimation
	{
		[AutoParametersStorage]
		private class AutoParametersData
		{
			public List<List<AnimationStep>> Steps;

			public Dictionary<AnimationStep, (GenericAnimationUtility.CachedOffset inOffset, GenericAnimationUtility.CachedOffset outOffset)> CachedOffsets = new Dictionary<AnimationStep, (GenericAnimationUtility.CachedOffset, GenericAnimationUtility.CachedOffset)>();

			public bool repeat;

			public float duration;
		}

		[AutoParameter("repeat", new string[] { "rp" })]
		[SerializeField]
		private bool repeat;

		[AutoParameter("duration", new string[] { "dur" })]
		[SerializeField]
		private float duration;

		private CharDataModifiers modifiersStorage;

		private CharDataModifiers modifiersStorage2;

		private CharDataModifiers accModifier;

		private CharDataModifiers current;

		[field: SerializeField]
		public GenericAnimationUtility.TrackList Tracks { get; set; } = new GenericAnimationUtility.TrackList();

		public bool Repeat
		{
			get
			{
				return repeat;
			}
			set
			{
				repeat = value;
			}
		}

		public float Duration
		{
			get
			{
				return duration;
			}
			set
			{
				duration = value;
			}
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			GenericAnimationUtility.EnsureNonOverlappingTimings_Editor(Tracks);
		}

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			if (Mathf.Lerp(0f, 1f, (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData)) / data.duration) >= 1f)
			{
				context.FinishAnimation(cData);
			}
			else
			{
				GenericAnimationUtility.Animate(cData, Tracks, ref data.Steps, data.CachedOffsets, data.repeat, data.duration, context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData), context, ref modifiersStorage, ref modifiersStorage2, ref accModifier, ref current);
			}
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
			AutoParametersData data = context.CustomData as AutoParametersData;
			Animate(cData, data, context);
		}

		public override object GetNewCustomData()
		{
			return new AutoParametersData
			{
				repeat = repeat,
				duration = duration
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetBoolParameter(out var value, parameters, keywordDatabase, "repeat", "rp"))
				{
					autoParametersData.repeat = value;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value2, parameters, keywordDatabase, "duration", "dur"))
				{
					autoParametersData.duration = value2;
				}
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonBoolParameter(parameters, keywordDatabase, "repeat", "rp"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "duration", "dur"))
			{
				return false;
			}
			return true;
		}
	}
}
