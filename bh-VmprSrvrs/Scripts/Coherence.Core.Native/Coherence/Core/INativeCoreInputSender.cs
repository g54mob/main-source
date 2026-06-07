namespace Coherence.Core
{
	public interface INativeCoreInputSender
	{
		void SendInput<T>(InteropEntity id, long frame, uint inputType, T message, int dataSize) where T : struct;
	}
}
