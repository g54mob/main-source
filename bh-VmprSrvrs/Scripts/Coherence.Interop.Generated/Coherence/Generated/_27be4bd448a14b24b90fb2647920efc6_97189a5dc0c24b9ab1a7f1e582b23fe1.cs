using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _27be4bd448a14b24b90fb2647920efc6_97189a5dc0c24b9ab1a7f1e582b23fe1 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _27be4bd448a14b24b90fb2647920efc6_97189a5dc0c24b9ab1a7f1e582b23fe1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_27be4bd448a14b24b90fb2647920efc6_97189a5dc0c24b9ab1a7f1e582b23fe1);
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

		public _27be4bd448a14b24b90fb2647920efc6_97189a5dc0c24b9ab1a7f1e582b23fe1(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_27be4bd448a14b24b90fb2647920efc6_97189a5dc0c24b9ab1a7f1e582b23fe1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _27be4bd448a14b24b90fb2647920efc6_97189a5dc0c24b9ab1a7f1e582b23fe1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_27be4bd448a14b24b90fb2647920efc6_97189a5dc0c24b9ab1a7f1e582b23fe1);
		}
	}
}
