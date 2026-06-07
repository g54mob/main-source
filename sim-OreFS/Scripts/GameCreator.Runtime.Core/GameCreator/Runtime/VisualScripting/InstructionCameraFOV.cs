using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Field of View")]
	[Description("Changes the camera field of view")]
	[Category("Cameras/Properties/Change Field of View")]
	[Parameter("Camera", "The camera component whose property changes")]
	[Parameter("FoV", "The field of view of the camera, measured in degrees")]
	[Parameter("Duration", "The time in seconds, it takes for the camera to complete the change")]
	[Parameter("Easing", "The easing function used to transition")]
	[Keywords(new string[] { "Cameras", "Perspective", "FOV", "3D" })]
	[Image(typeof(IconCamera), ColorTheme.Type.Blue)]
	public class InstructionCameraFOV : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[SerializeField]
		private PropertyGetDecimal m_FieldOfView = new PropertyGetDecimal(60f);

		[SerializeField]
		private PropertyGetDecimal m_Duration = new PropertyGetDecimal(1f);

		[SerializeField]
		private Easing.Type m_Easing = Easing.Type.QuadInOut;

		public override string Title => $"Change Field of View to {m_FieldOfView}";

		protected override Task Run(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			if (tCamera == null)
			{
				return Instruction.DefaultResult;
			}
			float value = (float)m_FieldOfView.Get(args);
			float duration = (float)m_Duration.Get(args);
			tCamera.Viewport.SetFieldOfView(value, duration, m_Easing);
			return Instruction.DefaultResult;
		}
	}
}
