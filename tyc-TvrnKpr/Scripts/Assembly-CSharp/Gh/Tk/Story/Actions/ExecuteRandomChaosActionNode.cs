using System;
using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class ExecuteRandomChaosActionNode : ConnectedStoryNode
	{
		public enum StoryTarget
		{
			Prop = 0,
			Staff = 1,
			Ingredient = 2
		}

		[Serializable]
		public enum StoryTargetMode
		{
			RandomAllowMultiple = 0,
			RandomSingleOnly = 1,
			StoryTarget = 2
		}

		public StoryEffect storyEffect;

		[Header("story target")]
		public StoryTarget storyTarget;

		public StoryTargetMode targetMode;

		[Header("Action type")]
		public bool randomActionType;

		public ChaosActions.ChaosActionTypes actionType;

		private static readonly int[] _targetNumberDistribution;

		private static readonly ChaosActions.ChaosActionTypes[] _fireActions;

		private string _targetsLeftKey => null;

		private string _nextEffectTime => null;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private ChaosActions.ChaosActionTypes SelectPropAction(Predicate<ChaosActions.ChaosActionTypes> exclude)
		{
			return default(ChaosActions.ChaosActionTypes);
		}

		private float GetActionWeighting(ChaosActions.ChaosActionTypes type)
		{
			return 0f;
		}

		public override void OnUpdate(ActiveStory story)
		{
		}
	}
}
