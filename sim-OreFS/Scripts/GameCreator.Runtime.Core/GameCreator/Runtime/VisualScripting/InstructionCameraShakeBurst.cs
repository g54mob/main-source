using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Shake Camera Burst")]
	[Description("Shakes the camera for an amount of time")]
	[Category("Cameras/Shakes/Shake Camera Burst")]
	[Parameter("Camera", "The camera that receives the burst shake effect")]
	[Parameter("Delay", "Amount of time in seconds before the shake effect starts")]
	[Parameter("Duration", "Amount of time the shake effect stays active")]
	[Parameter("Shake Position", "If the shake affects the position of the camera")]
	[Parameter("Shake Rotation", "If the shake affects the rotation of the camera")]
	[Parameter("Magnitude", "The maximum amount the camera displaces from its position")]
	[Parameter("Roughness", "Frequency or how violently the camera shakes")]
	[Parameter("Transform", "[Optional] Defines the origin of the shake")]
	[Parameter("Radius", "[Optional] Distance from the origin that the shake starts to fall-off")]
	[Keywords(new string[] { "Cameras", "Animation", "Animate", "Shake", "Impact", "Play" })]
	[Image(typeof(IconCameraShake), ColorTheme.Type.Yellow)]
	public class InstructionCameraShakeBurst : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[Space]
		[SerializeField]
		private float m_Delay;

		[SerializeField]
		private float m_Duration = 0.5f;

		[Space]
		[SerializeField]
		private ShakeEffect m_ShakeEffect = ShakeEffect.Create;

		public override string Title => $"Burst shake {m_Camera} for {m_Duration} seconds";

		protected override Task Run(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			if (tCamera == null)
			{
				return Instruction.DefaultResult;
			}
			tCamera.AddBurstShake(m_Delay, m_Duration, m_ShakeEffect);
			return Instruction.DefaultResult;
		}
	}
}
