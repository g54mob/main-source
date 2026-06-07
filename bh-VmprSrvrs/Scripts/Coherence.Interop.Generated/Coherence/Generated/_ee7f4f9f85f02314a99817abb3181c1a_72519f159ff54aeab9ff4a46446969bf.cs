using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ee7f4f9f85f02314a99817abb3181c1a_72519f159ff54aeab9ff4a46446969bf : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ee7f4f9f85f02314a99817abb3181c1a_72519f159ff54aeab9ff4a46446969bf FromInterop(IntPtr data, int dataSize)
		{
			return default(_ee7f4f9f85f02314a99817abb3181c1a_72519f159ff54aeab9ff4a46446969bf);
		}

		public uint GetComponentType()
		{
			return 0u;
		}

		public IEntityMessage Clone()
		{
			return null;
		}

		public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public HashSet<Entity> GetEntityRefs()
		{
			return null;
		}

		public void NullEntityRefs(Entity entity)
		{
		}

		public static void Serialize(_ee7f4f9f85f02314a99817abb3181c1a_72519f159ff54aeab9ff4a46446969bf commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ee7f4f9f85f02314a99817abb3181c1a_72519f159ff54aeab9ff4a46446969bf Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ee7f4f9f85f02314a99817abb3181c1a_72519f159ff54aeab9ff4a46446969bf);
		}
	}
}
