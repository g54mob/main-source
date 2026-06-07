using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _faaf48c97104b4e4e833834bf5748abf_dd80db354cda4ab9960c53e56aaa29d0 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _faaf48c97104b4e4e833834bf5748abf_dd80db354cda4ab9960c53e56aaa29d0 FromInterop(IntPtr data, int dataSize)
		{
			return default(_faaf48c97104b4e4e833834bf5748abf_dd80db354cda4ab9960c53e56aaa29d0);
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

		public static void Serialize(_faaf48c97104b4e4e833834bf5748abf_dd80db354cda4ab9960c53e56aaa29d0 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _faaf48c97104b4e4e833834bf5748abf_dd80db354cda4ab9960c53e56aaa29d0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_faaf48c97104b4e4e833834bf5748abf_dd80db354cda4ab9960c53e56aaa29d0);
		}
	}
}
