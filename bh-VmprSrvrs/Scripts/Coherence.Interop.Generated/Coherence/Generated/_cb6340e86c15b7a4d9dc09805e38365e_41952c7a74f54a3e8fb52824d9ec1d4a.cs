using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _cb6340e86c15b7a4d9dc09805e38365e_41952c7a74f54a3e8fb52824d9ec1d4a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _cb6340e86c15b7a4d9dc09805e38365e_41952c7a74f54a3e8fb52824d9ec1d4a FromInterop(IntPtr data, int dataSize)
		{
			return default(_cb6340e86c15b7a4d9dc09805e38365e_41952c7a74f54a3e8fb52824d9ec1d4a);
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

		public _cb6340e86c15b7a4d9dc09805e38365e_41952c7a74f54a3e8fb52824d9ec1d4a(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_cb6340e86c15b7a4d9dc09805e38365e_41952c7a74f54a3e8fb52824d9ec1d4a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _cb6340e86c15b7a4d9dc09805e38365e_41952c7a74f54a3e8fb52824d9ec1d4a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_cb6340e86c15b7a4d9dc09805e38365e_41952c7a74f54a3e8fb52824d9ec1d4a);
		}
	}
}
