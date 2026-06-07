using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ef11fd415a87c334b834f7d07d58919f_ea72dd91a4d24a718dd2e59c6bbfbedc : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ef11fd415a87c334b834f7d07d58919f_ea72dd91a4d24a718dd2e59c6bbfbedc FromInterop(IntPtr data, int dataSize)
		{
			return default(_ef11fd415a87c334b834f7d07d58919f_ea72dd91a4d24a718dd2e59c6bbfbedc);
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

		public _ef11fd415a87c334b834f7d07d58919f_ea72dd91a4d24a718dd2e59c6bbfbedc(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ef11fd415a87c334b834f7d07d58919f_ea72dd91a4d24a718dd2e59c6bbfbedc commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ef11fd415a87c334b834f7d07d58919f_ea72dd91a4d24a718dd2e59c6bbfbedc Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ef11fd415a87c334b834f7d07d58919f_ea72dd91a4d24a718dd2e59c6bbfbedc);
		}
	}
}
