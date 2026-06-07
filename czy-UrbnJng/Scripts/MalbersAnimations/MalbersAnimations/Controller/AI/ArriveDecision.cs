using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Arrived to Target", order = -100)]
	public class ArriveDecision : MAIDecision
	{
		[Space]
		[Tooltip("(OPTIONAL)Use it if you want to know if we have arrived to a specific Target")]
		public string TargetName = string.Empty;

		public override string DisplayName => "Movement/Has Arrived";

		public override bool Decide(MAnimalBrain brain, int index)
		{
			if (string.IsNullOrEmpty(TargetName))
			{
				return brain.AIControl.HasArrived;
			}
			return brain.AIControl.HasArrived && (brain.Target.name == TargetName || brain.Target.root.name == TargetName);
		}
	}
}
