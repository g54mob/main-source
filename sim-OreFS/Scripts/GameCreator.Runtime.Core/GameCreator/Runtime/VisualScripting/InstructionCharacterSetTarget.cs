using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Set Target")]
	[Description("Changes the targeted game object by the specified Character")]
	[Category("Characters/Combat/Targeting/Set Target")]
	[Parameter("Character", "The Character that attempts to change its target")]
	[Parameter("Target", "The new targeted game object by the character")]
	[Keywords(new string[] { "Character", "Combat", "Focus", "Pick" })]
	[Image(typeof(IconBullsEye), ColorTheme.Type.Green)]
	public class InstructionCharacterSetTarget : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectInstance.Create();

		public override string Title => $"Target {m_Character} = {m_Target}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			GameObject primary = m_Target.Get(args);
			character.Combat.Targets.Primary = primary;
			return Instruction.DefaultResult;
		}
	}
}
