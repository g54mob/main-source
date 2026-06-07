using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _00c0cbb90f61cdc43be6d6c474d3375c_11960840f2ef420ba0aa340902ab2f56 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _00c0cbb90f61cdc43be6d6c474d3375c_11960840f2ef420ba0aa340902ab2f56 FromInterop(IntPtr data, int dataSize)
		{
			return default(_00c0cbb90f61cdc43be6d6c474d3375c_11960840f2ef420ba0aa340902ab2f56);
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

		public _00c0cbb90f61cdc43be6d6c474d3375c_11960840f2ef420ba0aa340902ab2f56(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_00c0cbb90f61cdc43be6d6c474d3375c_11960840f2ef420ba0aa340902ab2f56 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _00c0cbb90f61cdc43be6d6c474d3375c_11960840f2ef420ba0aa340902ab2f56 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_00c0cbb90f61cdc43be6d6c474d3375c_11960840f2ef420ba0aa340902ab2f56);
		}
	}
}
