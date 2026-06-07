using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	public abstract class TimeProvider : ManagedBehaviour<WaterRenderer>, ITimeProvider
	{
		public abstract float Time { get; }

		public abstract float Delta { get; }
	}
}
