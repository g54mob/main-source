using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _92729ef983562154daa0c0af37464b19_27569c74a4064b8e88a6a0c9433e35ba : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity requestingPlayer;
		}

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _92729ef983562154daa0c0af37464b19_27569c74a4064b8e88a6a0c9433e35ba FromInterop(IntPtr data, int dataSize)
		{
			return default(_92729ef983562154daa0c0af37464b19_27569c74a4064b8e88a6a0c9433e35ba);
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

		public _92729ef983562154daa0c0af37464b19_27569c74a4064b8e88a6a0c9433e35ba(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_92729ef983562154daa0c0af37464b19_27569c74a4064b8e88a6a0c9433e35ba commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _92729ef983562154daa0c0af37464b19_27569c74a4064b8e88a6a0c9433e35ba Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_92729ef983562154daa0c0af37464b19_27569c74a4064b8e88a6a0c9433e35ba);
		}
	}
}
