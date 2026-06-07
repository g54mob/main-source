using System.Reflection;
using Coherence.Brook;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.Toolkit
{
	public static class GenericNetworkCommandArgs
	{
		public static readonly int MAX_ENTITY_REFS;

		public static readonly int BYTE_LIST_OVERHEAD;

		public static readonly int MAX_BYTE_ARRAY_LENGTH;

		private const int BITS_IN_BYTE = 8;

		private const int QUATERNION_BITS_PER_COMPONENT = 32;

		private static readonly FloatMeta ColorFloatMeta;

		private static readonly FloatMeta NoCompression;

		public static (byte[], Entity[]) SerializeCommandArgs(MethodInfo method, CoherenceBridge bridge, object[] args, Logger logger)
		{
			return default((byte[], Entity[]));
		}

		public static object[] DeserializeCommandArgs(MethodInfo method, ICoherenceBridge bridge, byte[] data, Entity[] entityIDs, Logger logger)
		{
			return null;
		}
	}
}
