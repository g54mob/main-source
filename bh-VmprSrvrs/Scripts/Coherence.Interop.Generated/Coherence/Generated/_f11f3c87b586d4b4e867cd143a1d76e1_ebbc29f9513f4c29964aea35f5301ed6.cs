using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f11f3c87b586d4b4e867cd143a1d76e1_ebbc29f9513f4c29964aea35f5301ed6 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _f11f3c87b586d4b4e867cd143a1d76e1_ebbc29f9513f4c29964aea35f5301ed6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f11f3c87b586d4b4e867cd143a1d76e1_ebbc29f9513f4c29964aea35f5301ed6);
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

		public _f11f3c87b586d4b4e867cd143a1d76e1_ebbc29f9513f4c29964aea35f5301ed6(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f11f3c87b586d4b4e867cd143a1d76e1_ebbc29f9513f4c29964aea35f5301ed6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f11f3c87b586d4b4e867cd143a1d76e1_ebbc29f9513f4c29964aea35f5301ed6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f11f3c87b586d4b4e867cd143a1d76e1_ebbc29f9513f4c29964aea35f5301ed6);
		}
	}
}
