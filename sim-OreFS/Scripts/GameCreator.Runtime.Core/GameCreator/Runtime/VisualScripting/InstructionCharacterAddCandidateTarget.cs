using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Add Target Candidate")]
	[Description("Adds a new candidate target for the specified character")]
	[Category("Characters/Combat/Targeting/Add Target Candidate")]
	[Parameter("Character", "The Character that attempts to change its candidate target")]
	[Parameter("Target", "The new target candidate game object by the character")]
	[Keywords(new string[] { "Character", "Combat", "Focus", "Pick" })]
	[Image(typeof(IconBullsEye), ColorTheme.Type.TextLight, typeof(OverlayPlus))]
	public class InstructionCharacterAddCandidateTarget : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectInstance.Create();

		public override string Title => $"Add {m_Target} Candidate to {m_Character}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			GameObject candidate = m_Target.Get(args);
			character.Combat.Targets.AddCandidate(candidate);
			return Instruction.DefaultResult;
		}
	}
}
