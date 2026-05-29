using System;
using NaughtyAttributes;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class BBTStyleGoal : BBTGoal<StyleGoal>
	{
		[InfoBox("Target Value is not used, it will be replaced by TargetUnitInterval.", EInfoBoxType.Normal)]
		public EBarStyle[] TargetStyle;

		[Range(0.01f, 1f)]
		public float TargetUnitInterval = 0.25f;

		[VariablePopup(false)]
		public string TargetUI;

		protected override void InstantiateGoal()
		{
			DialogueLua.SetVariable(TargetUI, (int)(TargetUnitInterval * 100f));
			Goal = new StyleGoal(Quest, Entry, Variable, Target, TargetUnitInterval, TargetStyle);
		}
	}
}
