using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _229fafa7a9b860b46b0a94fe1842b413_9a8251ae0dd94f59a94e0e3aed2daf1e : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _229fafa7a9b860b46b0a94fe1842b413_9a8251ae0dd94f59a94e0e3aed2daf1e FromInterop(IntPtr data, int dataSize)
		{
			return default(_229fafa7a9b860b46b0a94fe1842b413_9a8251ae0dd94f59a94e0e3aed2daf1e);
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

		public _229fafa7a9b860b46b0a94fe1842b413_9a8251ae0dd94f59a94e0e3aed2daf1e(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_229fafa7a9b860b46b0a94fe1842b413_9a8251ae0dd94f59a94e0e3aed2daf1e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _229fafa7a9b860b46b0a94fe1842b413_9a8251ae0dd94f59a94e0e3aed2daf1e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_229fafa7a9b860b46b0a94fe1842b413_9a8251ae0dd94f59a94e0e3aed2daf1e);
		}
	}
}
