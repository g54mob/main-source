using System;
using CTS.Utilities;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public abstract class BaseCheckNumericSecondaryQuest<T> : BaseNumericSecondaryQuest<T> where T : QuestNumericGoal
	{
		[SerializeField]
		protected Vector2Int TargetCheckValue;

		[SerializeField]
		[VariablePopup(false)]
		protected string TargetCheck;

		public override void OfferQuest()
		{
			DialogueLua.SetVariable(TargetCheck, TargetCheckValue.RandomInRangeInclusive());
			base.OfferQuest();
		}

		protected override void StartObservingObjectives()
		{
			Goal = (T)Activator.CreateInstance(typeof(T), this, Entry, Progress, Target, TargetCheck);
			Goal?.StartObserving();
		}
	}
}
