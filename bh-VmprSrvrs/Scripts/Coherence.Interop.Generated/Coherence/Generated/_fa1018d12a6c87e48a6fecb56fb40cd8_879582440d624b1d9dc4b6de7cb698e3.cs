using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using UnityEngine;

namespace Coherence.Generated
{
	public struct _fa1018d12a6c87e48a6fecb56fb40cd8_879582440d624b1d9dc4b6de7cb698e3 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Vector2 position;

			[FieldOffset(8)]
			public int count;
		}

		public Vector2 position;

		public int count;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fa1018d12a6c87e48a6fecb56fb40cd8_879582440d624b1d9dc4b6de7cb698e3 FromInterop(IntPtr data, int dataSize)
		{
			return default(_fa1018d12a6c87e48a6fecb56fb40cd8_879582440d624b1d9dc4b6de7cb698e3);
		}

		public uint GetComponentType()
		{
			return 0u;
		}

		public IEntityMessage Clone()
		{
			return null;
		}

		public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Coherence.Log.Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Coherence.Log.Logger logger)
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

		public _fa1018d12a6c87e48a6fecb56fb40cd8_879582440d624b1d9dc4b6de7cb698e3(Entity entity, Vector2 position, int count)
		{
			this.position = default(Vector2);
			this.count = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_fa1018d12a6c87e48a6fecb56fb40cd8_879582440d624b1d9dc4b6de7cb698e3 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fa1018d12a6c87e48a6fecb56fb40cd8_879582440d624b1d9dc4b6de7cb698e3 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fa1018d12a6c87e48a6fecb56fb40cd8_879582440d624b1d9dc4b6de7cb698e3);
		}
	}
}
