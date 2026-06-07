using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Stop Camera Sustain Shake")]
	[Description("Stops a Sustain Shake camera effect in a particular layer layer")]
	[Category("Cameras/Shakes/Stop Camera Sustain Shake")]
	[Parameter("Camera", "The camera target that stops a Sustain Shake effect")]
	[Parameter("Layer", "The camera layer from which the Sustain Shake effect is removed")]
	[Parameter("Delay", "Amount of time before the Sustain Shake effect starts blending out")]
	[Parameter("Transition", "Amount of time it takes to blend out the Sustain Shake effect")]
	[Keywords(new string[] { "Cameras", "Animation", "Animate", "Shake", "Wave", "Play" })]
	[Image(typeof(IconCameraShake), ColorTheme.Type.Green, typeof(OverlayCross))]
	public class InstructionCameraStopSustain : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[Space]
		[SerializeField]
		private int m_Layer;

		[SerializeField]
		private float m_Delay;

		[SerializeField]
		private float m_Transition = 0.5f;

		public override string Title => $"Stop {m_Camera} sustain shake on layer {m_Layer}";

		protected override Task Run(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			if (tCamera == null)
			{
				return Instruction.DefaultResult;
			}
			tCamera.RemoveSustainShake(m_Layer, m_Delay, m_Transition);
			return Instruction.DefaultResult;
		}
	}
}
