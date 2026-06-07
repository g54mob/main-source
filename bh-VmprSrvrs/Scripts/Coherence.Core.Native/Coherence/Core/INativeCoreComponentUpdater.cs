namespace Coherence.Core
{
	public interface INativeCoreComponentUpdater
	{
		void UpdateComponent<T>(InteropEntity entity, uint componentId, T component, int dataSize, uint fieldMask, uint stoppedMask, long[] frames) where T : struct;
	}
}
