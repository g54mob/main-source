namespace Coherence.Core
{
	public interface INativeCoreCommandSender
	{
		bool SendCommand<T>(InteropEntity id, MessageTarget target, uint commandType, T message, int dataSize) where T : struct;
	}
}
