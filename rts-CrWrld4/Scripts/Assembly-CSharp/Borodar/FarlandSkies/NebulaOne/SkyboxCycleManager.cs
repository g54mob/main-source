using Borodar.FarlandSkies.Core.Helpers;

namespace Borodar.FarlandSkies.NebulaOne
{
	public class SkyboxCycleManager : Singleton<SkyboxCycleManager>
	{
		public float CycleDuration;

		public float CycleProgress;

		public bool Paused;

		private SkyboxAnimator _skyboxAnimator;

		protected void Start()
		{
		}

		protected void Update()
		{
		}
	}
}
