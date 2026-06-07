using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Start Ragdoll")]
	[Description("Makes a Character enter a ragdoll state")]
	[Category("Characters/Ragdoll/Start Ragdoll")]
	[Parameter("Character", "The Character game object that changes to a Ragdoll state")]
	[Keywords(new string[] { "Characters", "Ragdoll", "Dead", "Kill", "Die" })]
	[Image(typeof(IconSkeleton), ColorTheme.Type.Blue)]
	public class InstructionCharacterStartRagdoll : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string Title => $"Start Ragdoll on {m_Character}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (!(character == null))
			{
				await character.Ragdoll.StartRagdoll();
			}
		}
	}
}
