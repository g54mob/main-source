using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class BBTBloodBagQualityProductionGoal : BBTGoal<BloodBagQualityProductionGoal>
	{
		[SerializeField]
		[VariablePopup(false)]
		private string _targetQuality;

		[SerializeField]
		[Min(0f)]
		private int _targetQualityValue;

		public override void SetupTarget()
		{
			base.SetupTarget();
			DialogueLua.SetVariable(_targetQuality, _targetQualityValue);
		}

		protected override void InstantiateGoal()
		{
			Goal = new BloodBagQualityProductionGoal(Quest, Entry, Variable, Target, _targetQuality);
		}
	}
}
