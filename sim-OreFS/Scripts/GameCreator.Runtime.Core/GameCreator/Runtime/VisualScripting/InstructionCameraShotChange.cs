using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change to Shot")]
	[Description("Changes the active Shot for a particular camera")]
	[Category("Cameras/Change to Shot")]
	[Parameter("Camera", "The target camera component")]
	[Parameter("Shot", "The camera Shot that becomes active")]
	[Parameter("Duration", "How long it takes to transition to the new Shot, in seconds")]
	[Parameter("Wait To Complete", "If the instruction waits till the transition is complete")]
	[Keywords(new string[] { "Cameras", "Render", "Switch", "Move" })]
	[Image(typeof(IconCameraShot), ColorTheme.Type.Blue)]
	public class InstructionCameraShotChange : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[Space]
		[SerializeField]
		private PropertyGetGameObject m_Shot = GetGameObjectShot.Create;

		[Space]
		[SerializeField]
		private Easing.Type m_Easing = Easing.Type.QuadInOut;

		[SerializeField]
		private float m_Duration;

		[ConditionShow(new string[] { "m_Duration" })]
		[SerializeField]
		private bool m_WaitToComplete;

		public override string Title => $"Change Shot to {m_Shot} {((m_Duration <= 0f) ? string.Empty : $"in {m_Duration}s")}";

		protected override async Task Run(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			ShotCamera shotCamera = m_Shot.Get<ShotCamera>(args);
			if (!(tCamera == null) && !(shotCamera == null))
			{
				tCamera.Transition.ChangeToShot(shotCamera, m_Duration, m_Easing);
				if (m_WaitToComplete)
				{
					await Time(m_Duration, shotCamera.TimeMode);
				}
			}
		}
	}
}
