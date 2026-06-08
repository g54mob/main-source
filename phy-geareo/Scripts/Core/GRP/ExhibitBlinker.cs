using UnityEngine;

namespace GRP
{
	public class ExhibitBlinker : MonoBehaviour
	{
		public ExhibitBlinkerConfig config;

		public ExhibitLoader exhibit;

		public bool isBlink;

		private bool lastBlink;

		private bool isPulse;

		private float startTime;

		private float pulseStartTime;

		private float lastAlpha;

		private float startAlpha;

		private float alpha;

		public void Update()
		{
		}

		public void Pulse()
		{
		}
	}
}
