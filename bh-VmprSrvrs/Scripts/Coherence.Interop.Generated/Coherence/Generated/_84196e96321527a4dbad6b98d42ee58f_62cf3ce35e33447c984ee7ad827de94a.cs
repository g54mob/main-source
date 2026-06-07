using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _84196e96321527a4dbad6b98d42ee58f_62cf3ce35e33447c984ee7ad827de94a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity bundle;
		}

		public Entity bundle;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _84196e96321527a4dbad6b98d42ee58f_62cf3ce35e33447c984ee7ad827de94a FromInterop(IntPtr data, int dataSize)
		{
			return default(_84196e96321527a4dbad6b98d42ee58f_62cf3ce35e33447c984ee7ad827de94a);
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

		public _84196e96321527a4dbad6b98d42ee58f_62cf3ce35e33447c984ee7ad827de94a(Entity entity, Entity bundle)
		{
			this.bundle = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_84196e96321527a4dbad6b98d42ee58f_62cf3ce35e33447c984ee7ad827de94a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _84196e96321527a4dbad6b98d42ee58f_62cf3ce35e33447c984ee7ad827de94a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_84196e96321527a4dbad6b98d42ee58f_62cf3ce35e33447c984ee7ad827de94a);
		}
	}
}
