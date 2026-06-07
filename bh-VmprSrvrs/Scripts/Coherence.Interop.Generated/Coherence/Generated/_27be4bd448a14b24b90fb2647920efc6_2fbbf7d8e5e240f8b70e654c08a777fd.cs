using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _27be4bd448a14b24b90fb2647920efc6_2fbbf7d8e5e240f8b70e654c08a777fd : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _27be4bd448a14b24b90fb2647920efc6_2fbbf7d8e5e240f8b70e654c08a777fd FromInterop(IntPtr data, int dataSize)
		{
			return default(_27be4bd448a14b24b90fb2647920efc6_2fbbf7d8e5e240f8b70e654c08a777fd);
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

		public _27be4bd448a14b24b90fb2647920efc6_2fbbf7d8e5e240f8b70e654c08a777fd(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_27be4bd448a14b24b90fb2647920efc6_2fbbf7d8e5e240f8b70e654c08a777fd commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _27be4bd448a14b24b90fb2647920efc6_2fbbf7d8e5e240f8b70e654c08a777fd Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_27be4bd448a14b24b90fb2647920efc6_2fbbf7d8e5e240f8b70e654c08a777fd);
		}
	}
}
