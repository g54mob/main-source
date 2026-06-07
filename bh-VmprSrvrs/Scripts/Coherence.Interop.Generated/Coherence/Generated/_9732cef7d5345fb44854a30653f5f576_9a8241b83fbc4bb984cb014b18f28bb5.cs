using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9732cef7d5345fb44854a30653f5f576_9a8241b83fbc4bb984cb014b18f28bb5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int weaponType;

			[FieldOffset(12)]
			public float value;
		}

		public long startingSimFrame;

		public int weaponType;

		public float value;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _9732cef7d5345fb44854a30653f5f576_9a8241b83fbc4bb984cb014b18f28bb5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_9732cef7d5345fb44854a30653f5f576_9a8241b83fbc4bb984cb014b18f28bb5);
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

		public _9732cef7d5345fb44854a30653f5f576_9a8241b83fbc4bb984cb014b18f28bb5(Entity entity, long startingSimFrame, int weaponType, float value)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			this.value = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_9732cef7d5345fb44854a30653f5f576_9a8241b83fbc4bb984cb014b18f28bb5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9732cef7d5345fb44854a30653f5f576_9a8241b83fbc4bb984cb014b18f28bb5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9732cef7d5345fb44854a30653f5f576_9a8241b83fbc4bb984cb014b18f28bb5);
		}
	}
}
