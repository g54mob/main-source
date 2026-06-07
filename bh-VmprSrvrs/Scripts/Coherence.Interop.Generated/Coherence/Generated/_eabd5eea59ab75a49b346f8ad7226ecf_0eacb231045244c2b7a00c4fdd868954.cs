using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _eabd5eea59ab75a49b346f8ad7226ecf_0eacb231045244c2b7a00c4fdd868954 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _eabd5eea59ab75a49b346f8ad7226ecf_0eacb231045244c2b7a00c4fdd868954 FromInterop(IntPtr data, int dataSize)
		{
			return default(_eabd5eea59ab75a49b346f8ad7226ecf_0eacb231045244c2b7a00c4fdd868954);
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

		public _eabd5eea59ab75a49b346f8ad7226ecf_0eacb231045244c2b7a00c4fdd868954(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_eabd5eea59ab75a49b346f8ad7226ecf_0eacb231045244c2b7a00c4fdd868954 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _eabd5eea59ab75a49b346f8ad7226ecf_0eacb231045244c2b7a00c4fdd868954 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_eabd5eea59ab75a49b346f8ad7226ecf_0eacb231045244c2b7a00c4fdd868954);
		}
	}
}
