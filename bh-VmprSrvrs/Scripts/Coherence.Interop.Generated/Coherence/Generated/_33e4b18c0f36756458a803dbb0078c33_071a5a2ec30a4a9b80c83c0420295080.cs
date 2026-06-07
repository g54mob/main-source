using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _33e4b18c0f36756458a803dbb0078c33_071a5a2ec30a4a9b80c83c0420295080 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _33e4b18c0f36756458a803dbb0078c33_071a5a2ec30a4a9b80c83c0420295080 FromInterop(IntPtr data, int dataSize)
		{
			return default(_33e4b18c0f36756458a803dbb0078c33_071a5a2ec30a4a9b80c83c0420295080);
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

		public _33e4b18c0f36756458a803dbb0078c33_071a5a2ec30a4a9b80c83c0420295080(Entity entity, long startingSimFrame, int weaponType, float value)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			this.value = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_33e4b18c0f36756458a803dbb0078c33_071a5a2ec30a4a9b80c83c0420295080 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _33e4b18c0f36756458a803dbb0078c33_071a5a2ec30a4a9b80c83c0420295080 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_33e4b18c0f36756458a803dbb0078c33_071a5a2ec30a4a9b80c83c0420295080);
		}
	}
}
