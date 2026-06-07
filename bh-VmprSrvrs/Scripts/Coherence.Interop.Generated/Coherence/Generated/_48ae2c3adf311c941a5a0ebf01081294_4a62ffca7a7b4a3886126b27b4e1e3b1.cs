using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _48ae2c3adf311c941a5a0ebf01081294_4a62ffca7a7b4a3886126b27b4e1e3b1 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _48ae2c3adf311c941a5a0ebf01081294_4a62ffca7a7b4a3886126b27b4e1e3b1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_48ae2c3adf311c941a5a0ebf01081294_4a62ffca7a7b4a3886126b27b4e1e3b1);
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

		public _48ae2c3adf311c941a5a0ebf01081294_4a62ffca7a7b4a3886126b27b4e1e3b1(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_48ae2c3adf311c941a5a0ebf01081294_4a62ffca7a7b4a3886126b27b4e1e3b1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _48ae2c3adf311c941a5a0ebf01081294_4a62ffca7a7b4a3886126b27b4e1e3b1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_48ae2c3adf311c941a5a0ebf01081294_4a62ffca7a7b4a3886126b27b4e1e3b1);
		}
	}
}
