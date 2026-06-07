using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5e3e58d5412a64640aa3c145df0b642b_6218d227e00e4e77a9c1f5eecb535601 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _5e3e58d5412a64640aa3c145df0b642b_6218d227e00e4e77a9c1f5eecb535601 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5e3e58d5412a64640aa3c145df0b642b_6218d227e00e4e77a9c1f5eecb535601);
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

		public _5e3e58d5412a64640aa3c145df0b642b_6218d227e00e4e77a9c1f5eecb535601(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5e3e58d5412a64640aa3c145df0b642b_6218d227e00e4e77a9c1f5eecb535601 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5e3e58d5412a64640aa3c145df0b642b_6218d227e00e4e77a9c1f5eecb535601 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5e3e58d5412a64640aa3c145df0b642b_6218d227e00e4e77a9c1f5eecb535601);
		}
	}
}
