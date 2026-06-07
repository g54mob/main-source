using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Culling Mask")]
	[Description("Changes the camera culling mask")]
	[Category("Cameras/Properties/Change Culling Mask")]
	[Parameter("Camera", "The camera component whose property changes")]
	[Parameter("Culling Mask", "The mask the camera uses to discern which objects to render")]
	[Keywords(new string[] { "Cameras", "Render" })]
	[Image(typeof(IconCamera), ColorTheme.Type.Blue)]
	public class InstructionCameraCullingMask : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[Space]
		[SerializeField]
		private LayerMask m_CullingMask = -5;

		public override string Title => "Change Culling Mask";

		protected override Task Run(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			if (tCamera == null)
			{
				return Instruction.DefaultResult;
			}
			tCamera.Get<Camera>().cullingMask = m_CullingMask;
			return Instruction.DefaultResult;
		}
	}
}
