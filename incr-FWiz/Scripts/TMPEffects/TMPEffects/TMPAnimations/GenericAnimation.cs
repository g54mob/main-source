using System.Collections.Generic;
using JetBrains.Annotations;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Modifiers;
using UnityEngine;

namespace TMPEffects.TMPAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new GenericAnimation", menuName = "TMPEffects/Animations/Basic Animations/Generic Animation")]
	public sealed class GenericAnimation : TMPAnimation, IGenericAnimation
	{
		[AutoParametersStorage]
		private class AutoParametersData
		{
			public List<List<AnimationStep>> Steps;

			[CanBeNull]
			public Dictionary<AnimationStep, (GenericAnimationUtility.CachedOffset inOffset, GenericAnimationUtility.CachedOffset outOffset)> CachedOffsets;

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
		public GenericAnimationUtility.TrackList Tracks { get; set; }

		public bool Repeat
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Duration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void OnValidate()
		{
		}

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
		}

		public override object GetNewCustomData()
		{
			return null;
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return false;
		}
	}
}
