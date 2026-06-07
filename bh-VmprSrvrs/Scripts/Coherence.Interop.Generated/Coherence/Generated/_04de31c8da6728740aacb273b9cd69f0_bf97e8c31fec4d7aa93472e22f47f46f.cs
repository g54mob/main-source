using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _04de31c8da6728740aacb273b9cd69f0_bf97e8c31fec4d7aa93472e22f47f46f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _04de31c8da6728740aacb273b9cd69f0_bf97e8c31fec4d7aa93472e22f47f46f FromInterop(IntPtr data, int dataSize)
		{
			return default(_04de31c8da6728740aacb273b9cd69f0_bf97e8c31fec4d7aa93472e22f47f46f);
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

		public _04de31c8da6728740aacb273b9cd69f0_bf97e8c31fec4d7aa93472e22f47f46f(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_04de31c8da6728740aacb273b9cd69f0_bf97e8c31fec4d7aa93472e22f47f46f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _04de31c8da6728740aacb273b9cd69f0_bf97e8c31fec4d7aa93472e22f47f46f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_04de31c8da6728740aacb273b9cd69f0_bf97e8c31fec4d7aa93472e22f47f46f);
		}
	}
}
