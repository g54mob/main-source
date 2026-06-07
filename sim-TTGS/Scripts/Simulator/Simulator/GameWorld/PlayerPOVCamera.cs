using UnityEngine;

namespace Simulator.GameWorld
{
	public class PlayerPOVCamera : POVCamera
	{
		[SerializeField]
		private HeadBobbing m_headBobbing;

		protected override void OnSetEnable()
		{
			base.OnSetEnable();
			m_headBobbing.SetEnable();
		}

		protected override void OnSetDisable()
		{
			base.OnSetDisable();
			m_headBobbing.SetDisable();
		}
	}
}
