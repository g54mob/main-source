using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Orthographic Size")]
	[Description("Changes the camera's orthographic size")]
	[Category("Cameras/Properties/Change Orthographic Size")]
	[Parameter("Camera", "The camera component whose property changes")]
	[Parameter("Size", "The new size of the orthographic view")]
	[Parameter("Duration", "The time in seconds, it takes for the camera to complete the change")]
	[Parameter("Easing", "The easing function used to transition")]
	[Keywords(new string[] { "Cameras", "Orthographic", "Size", "2D" })]
	[Image(typeof(IconCamera), ColorTheme.Type.Blue)]
	public class InstructionCameraSize : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[SerializeField]
		private PropertyGetDecimal m_Size = new PropertyGetDecimal(5f);

		[SerializeField]
		private PropertyGetDecimal m_Duration = new PropertyGetDecimal(1f);

		[SerializeField]
		private Easing.Type m_Easing = Easing.Type.QuadInOut;

		public override string Title => $"Change Orthographic Size to {m_Size}";

		protected override Task Run(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			if (tCamera == null)
			{
				return Instruction.DefaultResult;
			}
			float value = (float)m_Size.Get(args);
			float duration = (float)m_Duration.Get(args);
			tCamera.Viewport.SetOrthographicSize(value, duration, m_Easing);
			return Instruction.DefaultResult;
		}
	}
}
