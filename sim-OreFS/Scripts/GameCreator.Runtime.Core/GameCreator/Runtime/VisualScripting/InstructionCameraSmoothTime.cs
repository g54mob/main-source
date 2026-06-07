using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Smooth Time")]
	[Description("Changes the camera Smooth Time")]
	[Category("Cameras/Properties/Change Smooth Time")]
	[Parameter("Camera", "The camera component whose property changes")]
	[Parameter("Smooth Position", "The new smooth value for translation")]
	[Parameter("Smooth Rotation", "The new smooth value for rotation")]
	[Keywords(new string[] { "Cameras" })]
	[Image(typeof(IconCamera), ColorTheme.Type.Blue)]
	public class InstructionCameraSmoothTime : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[SerializeField]
		private PropertyGetDecimal m_SmoothPosition = new PropertyGetDecimal(0.1f);

		[SerializeField]
		private PropertyGetDecimal m_SmoothRotation = new PropertyGetDecimal(0.1f);

		public override string Title => $"Change Smooth of {m_Camera}";

		protected override Task Run(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			if (tCamera == null)
			{
				return Instruction.DefaultResult;
			}
			tCamera.Transition.SmoothTimePosition = (float)m_SmoothPosition.Get(args);
			tCamera.Transition.SmoothTimeRotation = (float)m_SmoothRotation.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
