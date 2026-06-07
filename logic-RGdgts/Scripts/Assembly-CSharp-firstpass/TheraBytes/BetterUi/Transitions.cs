using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class Transitions
	{
		public enum TransitionMode
		{
			None = 0,
			ColorTint = 1,
			SpriteSwap = 2,
			Animation = 3,
			ObjectActiveness = 4,
			Alpha = 5,
			MaterialProperty = 6,
			Color32Tint = 7,
			LocationAnimationTransition = 8,
			CustomCallback = 9
		}

		public static readonly string[] OnOffStateNames;

		public static readonly string[] ShowHideStateNames;

		public static readonly string[] SelectionStateNames;

		[SerializeField]
		private TransitionMode mode;

		[SerializeField]
		private string[] stateNames;

		[SerializeField]
		private ColorTransitions colorTransitions;

		[SerializeField]
		private Color32Transitions color32Transitions;

		[SerializeField]
		private SpriteSwapTransitions spriteSwapTransitions;

		[SerializeField]
		private AnimationTransitions animationTransitions;

		[SerializeField]
		private ObjectActivenessTransitions activenessTransitions;

		[SerializeField]
		private AlphaTransitions alphaTransitions;

		[SerializeField]
		private MaterialPropertyTransition materialPropertyTransitions;

		[SerializeField]
		private LocationAnimationTransitions locationAnimationTransitions;

		[SerializeField]
		private CustomTransitions customTransitions;

		public TransitionMode Mode => default(TransitionMode);

		public ReadOnlyCollection<string> StateNames => null;

		public TransitionStateCollection TransitionStates => null;

		public Transitions(params string[] stateNames)
		{
		}

		public void SetState(string stateName, bool instant)
		{
		}

		public void SetMode(TransitionMode mode)
		{
		}

		public void ComplementStateNames(string[] stateNames)
		{
		}
	}
}
