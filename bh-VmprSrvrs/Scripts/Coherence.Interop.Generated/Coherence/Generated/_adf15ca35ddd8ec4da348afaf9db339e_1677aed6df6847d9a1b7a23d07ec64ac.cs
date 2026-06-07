using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _adf15ca35ddd8ec4da348afaf9db339e_1677aed6df6847d9a1b7a23d07ec64ac : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _adf15ca35ddd8ec4da348afaf9db339e_1677aed6df6847d9a1b7a23d07ec64ac FromInterop(IntPtr data, int dataSize)
		{
			return default(_adf15ca35ddd8ec4da348afaf9db339e_1677aed6df6847d9a1b7a23d07ec64ac);
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

		public _adf15ca35ddd8ec4da348afaf9db339e_1677aed6df6847d9a1b7a23d07ec64ac(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_adf15ca35ddd8ec4da348afaf9db339e_1677aed6df6847d9a1b7a23d07ec64ac commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _adf15ca35ddd8ec4da348afaf9db339e_1677aed6df6847d9a1b7a23d07ec64ac Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_adf15ca35ddd8ec4da348afaf9db339e_1677aed6df6847d9a1b7a23d07ec64ac);
		}
	}
}
