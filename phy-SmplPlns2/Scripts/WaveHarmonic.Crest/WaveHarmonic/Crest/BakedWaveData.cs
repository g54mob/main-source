using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	internal abstract class BakedWaveData : CustomScriptableObject
	{
		public abstract float WindSpeed { get; }

		public abstract ICollisionProvider CreateCollisionProvider();
	}
}
