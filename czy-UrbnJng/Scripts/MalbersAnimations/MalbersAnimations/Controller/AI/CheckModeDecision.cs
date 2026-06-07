using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Check Mode", order = 2)]
	public class CheckModeDecision : MAIDecision
	{
		[Space]
		[Tooltip("Check the Decision on the Animal(Self) or the Target(Target)")]
		public Affected checkOn;

		[Tooltip("Check if the Mode is Entering or Exiting")]
		public PlayingModeState ModeState;

		[Hide("ModeState", true, new int[] { 2 })]
		public ModeID ModeID;

		[Tooltip("Which ability is playing in the Mode. If is set to less or equal to zero; then it will return true if the Mode Playing")]
		public IntReference Ability = new IntReference();

		public override string DisplayName => "Animal/Check Mode";

		public override bool Decide(MAnimalBrain brain, int Index)
		{
			return checkOn switch
			{
				Affected.Self => AnimalMode(brain.Animal), 
				Affected.Target => AnimalMode(brain.TargetAnimal), 
				_ => false, 
			};
		}

		private bool AnimalMode(MAnimal animal)
		{
			if (animal == null)
			{
				return false;
			}
			return ModeState switch
			{
				PlayingModeState.Enter => OnEnterMode(animal), 
				PlayingModeState.Exit => OnExitMode(animal), 
				PlayingModeState.PlayingMode => animal.IsPlayingMode, 
				_ => false, 
			};
		}

		private bool OnEnterMode(MAnimal animal)
		{
			if (animal.ActiveModeID == (int)ModeID)
			{
				if ((int)Ability <= 0)
				{
					return true;
				}
				return (int)Ability == animal.ModeAbility % 1000;
			}
			return false;
		}

		private bool OnExitMode(MAnimal animal)
		{
			if (animal.LastModeID == (int)ModeID)
			{
				if ((int)Ability <= 0)
				{
					return true;
				}
				return (int)Ability == animal.LastAbilityIndex;
			}
			return false;
		}
	}
}
