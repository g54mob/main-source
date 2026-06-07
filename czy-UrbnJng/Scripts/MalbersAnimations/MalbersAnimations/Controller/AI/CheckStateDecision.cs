using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Check State", order = 1)]
	public class CheckStateDecision : MAIDecision
	{
		[Space]
		[Tooltip("Check the Decision on the Animal(Self) or the Target(Target)")]
		public Affected check;

		public StateID StateID;

		[Tooltip("Check if the State is Entering or Exiting")]
		public EEnterExit when = EEnterExit.Enter;

		public override string DisplayName => "Animal/Check State";

		public override bool Decide(MAnimalBrain brain, int index)
		{
			switch (check)
			{
			case Affected.Self:
				return CheckState(brain.Animal);
			case Affected.Target:
				if (brain.TargetAnimal != null)
				{
					return CheckState(brain.TargetAnimal);
				}
				return false;
			default:
				return false;
			}
		}

		private bool CheckState(MAnimal animal)
		{
			return when switch
			{
				EEnterExit.Enter => (int)animal.ActiveStateID == StateID.ID, 
				EEnterExit.Exit => (int)animal.LastState.ID == StateID.ID, 
				_ => false, 
			};
		}
	}
}
