using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Kill Character")]
	[Description("Changes the state of the Character to dead")]
	[Category("Characters/Properties/Kill Character")]
	[Parameter("Character", "The character target")]
	[Keywords(new string[] { "Dead", "Die", "Murder" })]
	[Image(typeof(IconSkull), ColorTheme.Type.Red)]
	public class InstructionCharacterKill : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string Title => $"Kill {m_Character}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.IsDead = true;
			return Instruction.DefaultResult;
		}
	}
}
