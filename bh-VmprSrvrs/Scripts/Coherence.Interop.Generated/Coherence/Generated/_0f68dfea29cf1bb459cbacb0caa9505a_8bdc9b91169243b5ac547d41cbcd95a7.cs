using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _0f68dfea29cf1bb459cbacb0caa9505a_8bdc9b91169243b5ac547d41cbcd95a7 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _0f68dfea29cf1bb459cbacb0caa9505a_8bdc9b91169243b5ac547d41cbcd95a7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_0f68dfea29cf1bb459cbacb0caa9505a_8bdc9b91169243b5ac547d41cbcd95a7);
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

		public _0f68dfea29cf1bb459cbacb0caa9505a_8bdc9b91169243b5ac547d41cbcd95a7(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_0f68dfea29cf1bb459cbacb0caa9505a_8bdc9b91169243b5ac547d41cbcd95a7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _0f68dfea29cf1bb459cbacb0caa9505a_8bdc9b91169243b5ac547d41cbcd95a7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_0f68dfea29cf1bb459cbacb0caa9505a_8bdc9b91169243b5ac547d41cbcd95a7);
		}
	}
}
