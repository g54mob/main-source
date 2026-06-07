using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c9a9d977fdad5454babc00ddaab63396_f38f0fae5a3842929ef6750bfa36ed4f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c9a9d977fdad5454babc00ddaab63396_f38f0fae5a3842929ef6750bfa36ed4f FromInterop(IntPtr data, int dataSize)
		{
			return default(_c9a9d977fdad5454babc00ddaab63396_f38f0fae5a3842929ef6750bfa36ed4f);
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

		public _c9a9d977fdad5454babc00ddaab63396_f38f0fae5a3842929ef6750bfa36ed4f(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_c9a9d977fdad5454babc00ddaab63396_f38f0fae5a3842929ef6750bfa36ed4f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c9a9d977fdad5454babc00ddaab63396_f38f0fae5a3842929ef6750bfa36ed4f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c9a9d977fdad5454babc00ddaab63396_f38f0fae5a3842929ef6750bfa36ed4f);
		}
	}
}
