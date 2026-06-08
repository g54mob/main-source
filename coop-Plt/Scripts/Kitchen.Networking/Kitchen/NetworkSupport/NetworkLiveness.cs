using UnityEngine;

namespace Kitchen.NetworkSupport
{
	public class NetworkLiveness : ILiveness
	{
		public float MaxLivenessTimeout = 15f;

		public float MaxLivenessWarning = 2f;

		private float LastLiveness;

		public virtual bool IsLive => Time.realtimeSinceStartup - LastLiveness < MaxLivenessTimeout;

		public virtual bool IsGoodQuality => Time.realtimeSinceStartup - LastLiveness < MaxLivenessWarning;

		public void RefreshLiveness()
		{
			LastLiveness = Time.realtimeSinceStartup;
		}

		public NetworkLiveness()
		{
			RefreshLiveness();
		}

		public void SetUnlive()
		{
			LastLiveness = -1f;
		}
	}
}
