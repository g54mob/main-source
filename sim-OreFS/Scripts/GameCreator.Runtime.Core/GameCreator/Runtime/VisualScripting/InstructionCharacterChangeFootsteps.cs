using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Footstep Sounds")]
	[Description("Changes the sound table that links textures with footstep sounds")]
	[Category("Characters/Footsteps/Change Footstep Sounds")]
	[Parameter("Character", "The character that plays animation Gestures")]
	[Parameter("Footsteps", "The sound table asset that contains information about how and when footstep sounds play")]
	[Keywords(new string[] { "Character", "Foot", "Step", "Stomp", "Foliage", "Audio", "Run", "Walk", "Move" })]
	[Image(typeof(IconFootprint), ColorTheme.Type.Yellow)]
	public class InstructionCharacterChangeFootsteps : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private MaterialSoundsAsset m_Materials;

		public override string Title => string.Format("Changes Footstep Sounds on {0} to {1}", m_Character, (m_Materials != null) ? m_Materials.name : "(none)");

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.Footsteps.ChangeFootstepSounds(m_Materials);
			return Instruction.DefaultResult;
		}
	}
}
