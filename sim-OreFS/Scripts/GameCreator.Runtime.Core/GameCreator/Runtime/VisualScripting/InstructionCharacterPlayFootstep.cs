using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Play Footstep")]
	[Description("Plays a Footstep sound from a Material Sound asset")]
	[Category("Characters/Footsteps/Play Footstep")]
	[Parameter("Character", "The character target")]
	[Parameter("Material Sound", "The material sound asset")]
	[Keywords(new string[] { "Step", "Foot", "Impact", "Land", "Sound" })]
	[Image(typeof(IconFootprint), ColorTheme.Type.Green)]
	public class InstructionCharacterPlayFootstep : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private MaterialSoundsAsset m_MaterialSounds;

		public override string Title => $"Play Footstep on {m_Character}";

		protected override Task Run(Args args)
		{
			if (m_MaterialSounds == null)
			{
				return Instruction.DefaultResult;
			}
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.Footsteps.PlayFootstepSound(m_MaterialSounds);
			return Instruction.DefaultResult;
		}
	}
}
