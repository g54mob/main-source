using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Remove Target Candidate")]
	[Description("Removes a new candidate target for the specified character")]
	[Category("Characters/Combat/Targeting/Remove Target Candidate")]
	[Parameter("Character", "The Character that attempts to change its target candidate")]
	[Parameter("Target", "The target candidate to remove by the character")]
	[Keywords(new string[] { "Character", "Combat", "Focus", "Pick" })]
	[Image(typeof(IconBullsEye), ColorTheme.Type.TextLight, typeof(OverlayMinus))]
	public class InstructionCharacterRemoveCandidateTarget : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectInstance.Create();

		public override string Title => $"Remove {m_Target} Candidate from {m_Character}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			GameObject candidate = m_Target.Get(args);
			character.Combat.Targets.RemoveCandidate(candidate);
			return Instruction.DefaultResult;
		}
	}
}
