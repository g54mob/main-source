using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Recover from Ragdoll")]
	[Description("Recovers a Character from the Ragdoll state and stands up")]
	[Category("Characters/Ragdoll/Recover Ragdoll")]
	[Parameter("Character", "The Character game object that recovers from the Ragdoll state")]
	[Keywords(new string[] { "Characters", "Ragdoll", "Recover", "Stand" })]
	[Image(typeof(IconSkeleton), ColorTheme.Type.Green)]
	public class InstructionCharacterRecoverRagdoll : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string Title => $"Recover Ragdoll on {m_Character}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (!(character == null))
			{
				await character.Ragdoll.StartRecover();
			}
		}
	}
}
