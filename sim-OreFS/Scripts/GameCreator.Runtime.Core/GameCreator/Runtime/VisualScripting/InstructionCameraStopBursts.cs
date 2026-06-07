using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Stop Camera Shake Bursts")]
	[Description("Stops any ongoing camera Burst Shake effects")]
	[Category("Cameras/Shakes/Stop Shake Camera Bursts")]
	[Parameter("Camera", "The camera target that stops all its active Burst Shake effects")]
	[Parameter("Delay", "Amount of time before all Burst Shake effects start blending out")]
	[Parameter("Transition", "Amount of time it takes to blend out all Burst Shake effects")]
	[Keywords(new string[] { "Cameras", "Animation", "Animate", "Shake", "Impact", "Play" })]
	[Image(typeof(IconCameraShake), ColorTheme.Type.Yellow, typeof(OverlayCross))]
	public class InstructionCameraStopBursts : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[Space]
		[SerializeField]
		private float m_Delay;

		[SerializeField]
		private float m_Transition = 0.5f;

		public override string Title => $"Stop burst shakes on {m_Camera}";

		protected override Task Run(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			if (tCamera == null)
			{
				return Instruction.DefaultResult;
			}
			tCamera.StopBurstShakes(m_Delay, m_Transition);
			return Instruction.DefaultResult;
		}
	}
}
