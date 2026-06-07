using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Face
{
	public class GameStateFaceSource : FaceSource, IFaceMoodProducer, IFaceMoodConsumer
	{
		private struct RuleRuntime
		{
			public FaceExpressionPlayer player;

			public bool wasActive;

			public float currentIntensity;
		}

		[Header("State Source")]
		[SerializeField]
		private FaceStateReactionSet reactionSet;

		private readonly Dictionary<string, IFaceStateProbe> _probesById;

		private RuleRuntime[] _runtime;

		private FaceMoodSet _lastEmittedMoodSet;

		private bool _useExternalMoodSet;

		private FaceMoodSet _externalMoodSet;

		public override string DebugName => null;

		public FaceMoodSet CurrentMoodSet => default(FaceMoodSet);

		public bool UseExternalMoodSet
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event Action<FaceMoodSet> OnMoodSetChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void ApplyExternalMoodSet(FaceMoodSet set)
		{
		}

		private void OnEnable()
		{
		}

		private void CacheProbes()
		{
		}

		private void BuildRuntime()
		{
		}

		protected override float ComputeTargetWeight(float dt)
		{
			return 0f;
		}

		protected override void Sample(FaceFrame frame, float dt, float sourceFade)
		{
		}
	}
}
