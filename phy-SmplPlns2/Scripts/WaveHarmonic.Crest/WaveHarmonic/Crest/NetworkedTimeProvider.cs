using UnityEngine;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Time/Crest Networked Time Provider")]
	public sealed class NetworkedTimeProvider : TimeProvider
	{
		private readonly DefaultTimeProvider _DefaultTimeProvider = new DefaultTimeProvider();

		public float TimeOffsetToServer { get; set; }

		public override float Time => _DefaultTimeProvider.Time + TimeOffsetToServer;

		public override float Delta => _DefaultTimeProvider.Delta;
	}
}
