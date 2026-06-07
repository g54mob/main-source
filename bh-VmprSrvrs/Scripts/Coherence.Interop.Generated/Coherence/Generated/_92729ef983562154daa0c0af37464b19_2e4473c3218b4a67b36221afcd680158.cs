using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _92729ef983562154daa0c0af37464b19_2e4473c3218b4a67b36221afcd680158 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint clientId;
		}

		public uint clientId;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _92729ef983562154daa0c0af37464b19_2e4473c3218b4a67b36221afcd680158 FromInterop(IntPtr data, int dataSize)
		{
			return default(_92729ef983562154daa0c0af37464b19_2e4473c3218b4a67b36221afcd680158);
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

		public _92729ef983562154daa0c0af37464b19_2e4473c3218b4a67b36221afcd680158(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_92729ef983562154daa0c0af37464b19_2e4473c3218b4a67b36221afcd680158 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _92729ef983562154daa0c0af37464b19_2e4473c3218b4a67b36221afcd680158 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_92729ef983562154daa0c0af37464b19_2e4473c3218b4a67b36221afcd680158);
		}
	}
}
