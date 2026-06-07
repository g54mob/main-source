using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Characters.IK;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Clear Looking Around")]
	[Description("Stops looking at any target that isn't in a Hotspot (priority zero)")]
	[Category("Characters/IK/Clear Looking Around")]
	[Parameter("Character", "The character target")]
	[Keywords(new string[] { "Inverse", "Kinematics", "IK" })]
	[Image(typeof(IconEye), ColorTheme.Type.Blue, typeof(OverlayCross))]
	public class InstructionCharacterIKLookClear : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string Title => $"{m_Character} stop looking around";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			if (character.IK.HasRig<RigLookTo>())
			{
				character.IK.GetRig<RigLookTo>().ClearTargets();
			}
			return Instruction.DefaultResult;
		}
	}
}
