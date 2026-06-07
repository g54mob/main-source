using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5b900653e6a79844493c74a950c3376f_a835a1e3921a4054be640ecb406ff3ba : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5b900653e6a79844493c74a950c3376f_a835a1e3921a4054be640ecb406ff3ba FromInterop(IntPtr data, int dataSize)
		{
			return default(_5b900653e6a79844493c74a950c3376f_a835a1e3921a4054be640ecb406ff3ba);
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

		public static void Serialize(_5b900653e6a79844493c74a950c3376f_a835a1e3921a4054be640ecb406ff3ba commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5b900653e6a79844493c74a950c3376f_a835a1e3921a4054be640ecb406ff3ba Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5b900653e6a79844493c74a950c3376f_a835a1e3921a4054be640ecb406ff3ba);
		}
	}
}
