using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Footsteps Set Active")]
	[Description("Changes whether a Character plays footstep events or not")]
	[Category("Characters/Footsteps/Footsteps Set Active")]
	[Parameter("Character", "The character targeted")]
	[Parameter("Active", "Whether the footstep events are executed or not")]
	[Keywords(new string[] { "Character", "Foot", "Step", "Stomp", "Foliage", "Audio", "Run", "Walk", "Move" })]
	[Image(typeof(IconFootprint), ColorTheme.Type.Yellow)]
	public class InstructionCharacterFootstepsActive : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetBool m_Active = new PropertyGetBool(value: true);

		public override string Title => $"Footstep of {m_Character} = {m_Active}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.Footsteps.IsActive = m_Active.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
