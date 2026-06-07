using System;
using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class ComboSequence
	{
		[MinMaxRange(0f, 1f)]
		[Tooltip("Buffer Input Activation time for activating the next Sequence")]
		public RangedFloat Activation = new RangedFloat(0.3f, 0.6f);

		[Range(0f, 1f)]
		[Tooltip("Normalized time on the animation to activate the next ability if the animation reached this normalize time and the Sequence has been buffered.")]
		public float ActivationTime = 0.5f;

		[Tooltip("Ability needed to activate the next Sequence")]
		public int PreviewsAbility;

		[Tooltip("Name of the Ability that will be used to activate the next Sequence")]
		public string previewAbilityName;

		public int Ability;

		[Tooltip("Name of the Next Ability to activate")]
		public string nextAbilityName;

		[Tooltip("Branch used on the combo sequence")]
		public int Branch;

		[Tooltip("Is this Secuence a Finisher Combo?")]
		public bool Finisher;

		[Tooltip("Is the sequence a Restarter if is a finisher?")]
		public bool Restarter;

		[Tooltip("Restarter Finisher needs to pass this time to finish")]
		public float FinisherTime = 0.5f;

		public IntEvent OnSequencePlay = new IntEvent();

		public bool Used { get; set; }

		public bool Buffer { get; set; }

		public void Reset()
		{
			Buffer = false;
			Used = false;
		}
	}
}
