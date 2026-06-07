using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9dd30fc2395013d408bf881d717d21d9_d8d4eee46d03481c9a7824688b6cb16e : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _9dd30fc2395013d408bf881d717d21d9_d8d4eee46d03481c9a7824688b6cb16e FromInterop(IntPtr data, int dataSize)
		{
			return default(_9dd30fc2395013d408bf881d717d21d9_d8d4eee46d03481c9a7824688b6cb16e);
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

		public _9dd30fc2395013d408bf881d717d21d9_d8d4eee46d03481c9a7824688b6cb16e(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_9dd30fc2395013d408bf881d717d21d9_d8d4eee46d03481c9a7824688b6cb16e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9dd30fc2395013d408bf881d717d21d9_d8d4eee46d03481c9a7824688b6cb16e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9dd30fc2395013d408bf881d717d21d9_d8d4eee46d03481c9a7824688b6cb16e);
		}
	}
}
