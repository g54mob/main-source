using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _20bcb04d7eca75d4791a6b8471eb2720_f7e81283199d4f5e94fb993f1effec03 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long frame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long frame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _20bcb04d7eca75d4791a6b8471eb2720_f7e81283199d4f5e94fb993f1effec03 FromInterop(IntPtr data, int dataSize)
		{
			return default(_20bcb04d7eca75d4791a6b8471eb2720_f7e81283199d4f5e94fb993f1effec03);
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

		public _20bcb04d7eca75d4791a6b8471eb2720_f7e81283199d4f5e94fb993f1effec03(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_20bcb04d7eca75d4791a6b8471eb2720_f7e81283199d4f5e94fb993f1effec03 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _20bcb04d7eca75d4791a6b8471eb2720_f7e81283199d4f5e94fb993f1effec03 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_20bcb04d7eca75d4791a6b8471eb2720_f7e81283199d4f5e94fb993f1effec03);
		}
	}
}
