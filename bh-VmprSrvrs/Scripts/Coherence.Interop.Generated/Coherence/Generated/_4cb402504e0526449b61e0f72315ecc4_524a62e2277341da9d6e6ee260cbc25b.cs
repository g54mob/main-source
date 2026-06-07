using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4cb402504e0526449b61e0f72315ecc4_524a62e2277341da9d6e6ee260cbc25b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _4cb402504e0526449b61e0f72315ecc4_524a62e2277341da9d6e6ee260cbc25b FromInterop(IntPtr data, int dataSize)
		{
			return default(_4cb402504e0526449b61e0f72315ecc4_524a62e2277341da9d6e6ee260cbc25b);
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

		public _4cb402504e0526449b61e0f72315ecc4_524a62e2277341da9d6e6ee260cbc25b(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4cb402504e0526449b61e0f72315ecc4_524a62e2277341da9d6e6ee260cbc25b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4cb402504e0526449b61e0f72315ecc4_524a62e2277341da9d6e6ee260cbc25b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4cb402504e0526449b61e0f72315ecc4_524a62e2277341da9d6e6ee260cbc25b);
		}
	}
}
