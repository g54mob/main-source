using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4127a4e35991419499f44f6674101879_2749a00b23524188891a5c679834576b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _4127a4e35991419499f44f6674101879_2749a00b23524188891a5c679834576b FromInterop(IntPtr data, int dataSize)
		{
			return default(_4127a4e35991419499f44f6674101879_2749a00b23524188891a5c679834576b);
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

		public _4127a4e35991419499f44f6674101879_2749a00b23524188891a5c679834576b(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4127a4e35991419499f44f6674101879_2749a00b23524188891a5c679834576b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4127a4e35991419499f44f6674101879_2749a00b23524188891a5c679834576b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4127a4e35991419499f44f6674101879_2749a00b23524188891a5c679834576b);
		}
	}
}
