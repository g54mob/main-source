using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4c5721e499679dc499cc55be525ab38a_92e3a41cd96b4185a7c3cf2f18a5e8ec : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte eraseItems;

			[FieldOffset(1)]
			public byte skipTriggers;
		}

		public bool eraseItems;

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4c5721e499679dc499cc55be525ab38a_92e3a41cd96b4185a7c3cf2f18a5e8ec FromInterop(IntPtr data, int dataSize)
		{
			return default(_4c5721e499679dc499cc55be525ab38a_92e3a41cd96b4185a7c3cf2f18a5e8ec);
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

		public _4c5721e499679dc499cc55be525ab38a_92e3a41cd96b4185a7c3cf2f18a5e8ec(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4c5721e499679dc499cc55be525ab38a_92e3a41cd96b4185a7c3cf2f18a5e8ec commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4c5721e499679dc499cc55be525ab38a_92e3a41cd96b4185a7c3cf2f18a5e8ec Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4c5721e499679dc499cc55be525ab38a_92e3a41cd96b4185a7c3cf2f18a5e8ec);
		}
	}
}
