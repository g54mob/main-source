using Coherence.Brook;

namespace Coherence.Serializer
{
	public static class DeserializeCommands
	{
		public static bool DeserializeCommand(IInBitStream stream, out MessageType messageType)
		{
			messageType = default(MessageType);
			return false;
		}
	}
}
