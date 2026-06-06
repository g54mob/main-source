using System;

namespace MalbersAnimations.SA
{
	[Serializable]
	public class MAdvancedSettings
	{
		public float groundCheckDistance = 0.01f;

		public float stickToGroundHelperDistance = 0.5f;

		public float slowDownRate = 20f;

		public bool airControl;
	}
}
