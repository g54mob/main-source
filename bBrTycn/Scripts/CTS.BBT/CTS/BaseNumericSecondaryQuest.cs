using System;
using CTS.Utilities;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public abstract class BaseNumericSecondaryQuest<T> : SecondaryQuest where T : QuestNumericGoal
	{
		protected T Goal;

		[SerializeField]
		protected Vector2Int TargetValue;

		[SerializeField]
		[QuestEntryPopup]
		protected int Entry;

		[SerializeField]
		[VariablePopup(false)]
		protected string Target;

		[SerializeField]
		[VariablePopup(false)]
		protected string Progress;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(Progress);
		}

		public override void OfferQuest()
		{
			DialogueLua.SetVariable(Target, TargetValue.RandomInRangeInclusive());
			base.OfferQuest();
		}

		protected override void StopObservingObjectives()
		{
			Goal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			Goal = (T)Activator.CreateInstance(typeof(T), this, Entry, Progress, Target);
			Goal?.StartObserving();
		}
	}
}
