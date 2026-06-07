using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _daee5235e07381c42975d5b6c8d0a9f7_e62b0571ad8f4efe87e6c5eaa99aad46 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _daee5235e07381c42975d5b6c8d0a9f7_e62b0571ad8f4efe87e6c5eaa99aad46 FromInterop(IntPtr data, int dataSize)
		{
			return default(_daee5235e07381c42975d5b6c8d0a9f7_e62b0571ad8f4efe87e6c5eaa99aad46);
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

		public _daee5235e07381c42975d5b6c8d0a9f7_e62b0571ad8f4efe87e6c5eaa99aad46(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_daee5235e07381c42975d5b6c8d0a9f7_e62b0571ad8f4efe87e6c5eaa99aad46 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _daee5235e07381c42975d5b6c8d0a9f7_e62b0571ad8f4efe87e6c5eaa99aad46 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_daee5235e07381c42975d5b6c8d0a9f7_e62b0571ad8f4efe87e6c5eaa99aad46);
		}
	}
}
