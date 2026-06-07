using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Check Stance", order = 3)]
	public class CheckStanceDecision : MAIDecision
	{
		[Space]
		[Tooltip("Check the Decision on the Animal(Self) or the Target(Target)")]
		public Affected check;

		[Tooltip("Check if the State is Entering or Exiting")]
		public EEnterExit when = EEnterExit.Enter;

		public StanceID stanceID;

		public override string DisplayName => "Animal/Check Stance";

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
				EEnterExit.Enter => (int)animal.Stance == stanceID.ID, 
				EEnterExit.Exit => animal.LastStanceID == stanceID.ID, 
				_ => false, 
			};
		}
	}
}
