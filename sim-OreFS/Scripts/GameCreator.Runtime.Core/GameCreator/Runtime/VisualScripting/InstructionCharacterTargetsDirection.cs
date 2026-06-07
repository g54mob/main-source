using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Cycle Direction Target")]
	[Description("Cycles to the visually closest target candidate from the Targets list and camera")]
	[Category("Characters/Combat/Targeting/Cycle Direction Target")]
	[Parameter("Character", "The Character that attempts to change its candidate target")]
	[Parameter("Camera", "The point of view from which the direction is calculated")]
	[Parameter("Direction", "The local space direction (only [X,Y] components are used)")]
	[Keywords(new string[] { "Character", "Combat", "Focus", "Pick", "Candidate", "Targets" })]
	[Image(typeof(IconBullsEye), ColorTheme.Type.Yellow, typeof(OverlayBolt))]
	public class InstructionCharacterTargetsDirection : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionCharactersMoving.Create;

		public override string Title => $"Cycle {m_Character} Direction Targets from {m_Camera}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			Camera camera = m_Camera.Get<Camera>(args);
			if (camera == null)
			{
				return Instruction.DefaultResult;
			}
			Vector3 vector = m_Direction.Get(args);
			CycleTargets.Direction(character, camera, vector);
			return Instruction.DefaultResult;
		}
	}
}
