using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _145b9c266d666ec47b26a3ed9363150a_8e6308f608824297ac7e0f9771d5c619 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _145b9c266d666ec47b26a3ed9363150a_8e6308f608824297ac7e0f9771d5c619 FromInterop(IntPtr data, int dataSize)
		{
			return default(_145b9c266d666ec47b26a3ed9363150a_8e6308f608824297ac7e0f9771d5c619);
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

		public _145b9c266d666ec47b26a3ed9363150a_8e6308f608824297ac7e0f9771d5c619(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_145b9c266d666ec47b26a3ed9363150a_8e6308f608824297ac7e0f9771d5c619 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _145b9c266d666ec47b26a3ed9363150a_8e6308f608824297ac7e0f9771d5c619 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_145b9c266d666ec47b26a3ed9363150a_8e6308f608824297ac7e0f9771d5c619);
		}
	}
}
