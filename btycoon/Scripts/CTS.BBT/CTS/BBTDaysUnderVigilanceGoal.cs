using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class BBTDaysUnderVigilanceGoal : BBTGoal<DaysUnderVigilanceGoal>
	{
		[SerializeField]
		[VariablePopup(false)]
		private string _maxVigilanceVariable;

		[SerializeField]
		[Min(0f)]
		private int _maxVigilanceValue;

		public override void SetupTarget()
		{
			base.SetupTarget();
			DialogueLua.SetVariable(_maxVigilanceVariable, _maxVigilanceValue);
		}

		protected override void InstantiateGoal()
		{
			Goal = new DaysUnderVigilanceGoal(Quest, Entry, Variable, Target, _maxVigilanceVariable);
		}
	}
}
