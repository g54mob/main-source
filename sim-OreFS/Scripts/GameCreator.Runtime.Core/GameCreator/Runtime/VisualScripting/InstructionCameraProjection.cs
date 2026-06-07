using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Projection")]
	[Description("Changes the camera projection to either Perspective or Orthographic")]
	[Category("Cameras/Properties/Change Projection")]
	[Parameter("Camera", "The camera component whose property changes")]
	[Parameter("Projection", "Whether to change to Orthographic or Perspective mode")]
	[Keywords(new string[] { "Cameras", "Orthographic", "Perspective", "3D", "2D" })]
	[Image(typeof(IconCamera), ColorTheme.Type.Blue)]
	public class InstructionCameraProjection : Instruction
	{
		private enum Projection
		{
			Orthographic = 0,
			Perspective = 1
		}

		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[Space]
		[SerializeField]
		private Projection m_Projection = Projection.Perspective;

		public override string Title => $"Change Projection to {m_Projection}";

		protected override Task Run(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			if (tCamera == null)
			{
				return Instruction.DefaultResult;
			}
			bool projection = m_Projection == Projection.Orthographic;
			tCamera.Viewport.SetProjection(projection);
			return Instruction.DefaultResult;
		}
	}
}
