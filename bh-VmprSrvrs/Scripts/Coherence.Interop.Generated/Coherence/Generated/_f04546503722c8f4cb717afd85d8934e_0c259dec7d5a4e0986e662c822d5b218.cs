using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f04546503722c8f4cb717afd85d8934e_0c259dec7d5a4e0986e662c822d5b218 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public ByteArray disabledPowerUps;
		}

		public byte[] disabledPowerUps;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f04546503722c8f4cb717afd85d8934e_0c259dec7d5a4e0986e662c822d5b218 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f04546503722c8f4cb717afd85d8934e_0c259dec7d5a4e0986e662c822d5b218);
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

		public _f04546503722c8f4cb717afd85d8934e_0c259dec7d5a4e0986e662c822d5b218(Entity entity, byte[] disabledPowerUps)
		{
			this.disabledPowerUps = null;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f04546503722c8f4cb717afd85d8934e_0c259dec7d5a4e0986e662c822d5b218 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f04546503722c8f4cb717afd85d8934e_0c259dec7d5a4e0986e662c822d5b218 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f04546503722c8f4cb717afd85d8934e_0c259dec7d5a4e0986e662c822d5b218);
		}
	}
}
