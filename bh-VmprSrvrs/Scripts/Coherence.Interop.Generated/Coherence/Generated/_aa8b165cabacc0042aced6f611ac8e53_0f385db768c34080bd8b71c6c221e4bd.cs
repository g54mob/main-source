using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _aa8b165cabacc0042aced6f611ac8e53_0f385db768c34080bd8b71c6c221e4bd : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _aa8b165cabacc0042aced6f611ac8e53_0f385db768c34080bd8b71c6c221e4bd FromInterop(IntPtr data, int dataSize)
		{
			return default(_aa8b165cabacc0042aced6f611ac8e53_0f385db768c34080bd8b71c6c221e4bd);
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

		public _aa8b165cabacc0042aced6f611ac8e53_0f385db768c34080bd8b71c6c221e4bd(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_aa8b165cabacc0042aced6f611ac8e53_0f385db768c34080bd8b71c6c221e4bd commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _aa8b165cabacc0042aced6f611ac8e53_0f385db768c34080bd8b71c6c221e4bd Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_aa8b165cabacc0042aced6f611ac8e53_0f385db768c34080bd8b71c6c221e4bd);
		}
	}
}
