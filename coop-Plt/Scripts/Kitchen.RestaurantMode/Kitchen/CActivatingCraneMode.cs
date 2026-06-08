using Unity.Entities;

namespace Kitchen
{
	public struct CActivatingCraneMode : IComponentData
	{
		public float Progress;

		public const float TimeDelay = 0.5f;

		public bool IsComplete => Progress > 0.5f;

		public bool IsDeactivated => Progress < -0.5f;

		public void Deactivate()
		{
			Progress = -1f;
		}

		public void Reactivate()
		{
			Progress = 0f;
		}
	}
}
