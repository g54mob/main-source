using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Wait", order = 201)]
	public class WaitDecision : MAIDecision
	{
		[Space]
		public FloatReference WaitMinTime = new FloatReference(5f);

		public FloatReference WaitMaxTime = new FloatReference(5f);

		public override string DisplayName => "General/Wait";

		public override void PrepareDecision(MAnimalBrain brain, int Index)
		{
			brain.DecisionsVars[Index].floatValue = Random.Range(WaitMinTime, WaitMaxTime);
		}

		public override bool Decide(MAnimalBrain brain, int Index)
		{
			float floatValue = brain.DecisionsVars[Index].floatValue;
			return MTools.ElapsedTime(brain.StateLastTime, floatValue);
		}
	}
}
