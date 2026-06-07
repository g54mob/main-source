using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3c697731337d91d44840227ca0707343_897a3544a31d4b4686eb0fce6549a343 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _3c697731337d91d44840227ca0707343_897a3544a31d4b4686eb0fce6549a343 FromInterop(IntPtr data, int dataSize)
		{
			return default(_3c697731337d91d44840227ca0707343_897a3544a31d4b4686eb0fce6549a343);
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

		public static void Serialize(_3c697731337d91d44840227ca0707343_897a3544a31d4b4686eb0fce6549a343 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3c697731337d91d44840227ca0707343_897a3544a31d4b4686eb0fce6549a343 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3c697731337d91d44840227ca0707343_897a3544a31d4b4686eb0fce6549a343);
		}
	}
}
