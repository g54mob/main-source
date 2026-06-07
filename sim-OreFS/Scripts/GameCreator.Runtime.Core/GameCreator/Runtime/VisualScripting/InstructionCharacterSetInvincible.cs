using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Set Invincible")]
	[Description("Changes the Invincibility state of a Character")]
	[Category("Characters/Combat/Invincibility/Set Invincible")]
	[Parameter("Character", "The Character that attempts to change its invincibility")]
	[Parameter("Duration", "The duration of the invincibility")]
	[Parameter("Wait Until Complete", "Whether to wait until the invincibility wears off")]
	[Keywords(new string[] { "Character", "Combat", "Invincibility" })]
	[Image(typeof(IconDiamondSolid), ColorTheme.Type.Yellow)]
	public class InstructionCharacterSetInvincible : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDecimal m_Duration = GetDecimalDecimal.Create(1f);

		[SerializeField]
		private bool m_WaitUntilComplete;

		public override string Title => $"Set {m_Character} Invincible for {m_Duration} seconds";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (!(character == null))
			{
				float duration = (float)m_Duration.Get(args);
				character.Combat.Invincibility.Set(duration);
				if (m_WaitUntilComplete)
				{
					await Time(duration);
				}
			}
		}
	}
}
