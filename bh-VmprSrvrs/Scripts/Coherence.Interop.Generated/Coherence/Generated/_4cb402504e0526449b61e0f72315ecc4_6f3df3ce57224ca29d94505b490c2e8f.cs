using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4cb402504e0526449b61e0f72315ecc4_6f3df3ce57224ca29d94505b490c2e8f : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _4cb402504e0526449b61e0f72315ecc4_6f3df3ce57224ca29d94505b490c2e8f FromInterop(IntPtr data, int dataSize)
		{
			return default(_4cb402504e0526449b61e0f72315ecc4_6f3df3ce57224ca29d94505b490c2e8f);
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

		public _4cb402504e0526449b61e0f72315ecc4_6f3df3ce57224ca29d94505b490c2e8f(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4cb402504e0526449b61e0f72315ecc4_6f3df3ce57224ca29d94505b490c2e8f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4cb402504e0526449b61e0f72315ecc4_6f3df3ce57224ca29d94505b490c2e8f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4cb402504e0526449b61e0f72315ecc4_6f3df3ce57224ca29d94505b490c2e8f);
		}
	}
}
