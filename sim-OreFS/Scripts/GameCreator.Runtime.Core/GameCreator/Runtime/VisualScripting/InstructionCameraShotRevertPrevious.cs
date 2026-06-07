using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Revert to Previous Shot")]
	[Description("Reverts the active Shot of a particular camera to the previous one")]
	[Category("Cameras/Revert to previous Shot")]
	[Parameter("Camera", "The target camera component")]
	[Parameter("Duration", "How long it takes to transition to the new Shot, in seconds")]
	[Keywords(new string[] { "Cameras", "Render", "Switch", "Move" })]
	[Image(typeof(IconCameraShot), ColorTheme.Type.Yellow, typeof(OverlayArrowLeft))]
	public class InstructionCameraShotRevertPrevious : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[Space]
		[SerializeField]
		private float m_Duration;

		public override string Title => $"Revert to {m_Camera}'s previous Shot";

		protected override Task Run(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			if (tCamera == null)
			{
				return Instruction.DefaultResult;
			}
			tCamera.Transition.ChangeToPreviousShot(m_Duration);
			return Instruction.DefaultResult;
		}
	}
}
