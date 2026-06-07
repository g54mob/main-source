using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class BBTShakeBloodQualityProductionGoal : BBTGoal<ShakeBloodQualityProductionGoal>
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
			Goal = new ShakeBloodQualityProductionGoal(Quest, Entry, Variable, Target, _targetQuality);
		}
	}
}
