using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3666eedab5aa8fc44b0cfeb079f3fca1_fa65b9c723784d808009b9dca9fb941b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _3666eedab5aa8fc44b0cfeb079f3fca1_fa65b9c723784d808009b9dca9fb941b FromInterop(IntPtr data, int dataSize)
		{
			return default(_3666eedab5aa8fc44b0cfeb079f3fca1_fa65b9c723784d808009b9dca9fb941b);
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

		public _3666eedab5aa8fc44b0cfeb079f3fca1_fa65b9c723784d808009b9dca9fb941b(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3666eedab5aa8fc44b0cfeb079f3fca1_fa65b9c723784d808009b9dca9fb941b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3666eedab5aa8fc44b0cfeb079f3fca1_fa65b9c723784d808009b9dca9fb941b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3666eedab5aa8fc44b0cfeb079f3fca1_fa65b9c723784d808009b9dca9fb941b);
		}
	}
}
