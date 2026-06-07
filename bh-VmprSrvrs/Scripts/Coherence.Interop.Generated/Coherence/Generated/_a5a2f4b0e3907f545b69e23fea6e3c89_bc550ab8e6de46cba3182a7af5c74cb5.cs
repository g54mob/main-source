using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a5a2f4b0e3907f545b69e23fea6e3c89_bc550ab8e6de46cba3182a7af5c74cb5 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _a5a2f4b0e3907f545b69e23fea6e3c89_bc550ab8e6de46cba3182a7af5c74cb5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a5a2f4b0e3907f545b69e23fea6e3c89_bc550ab8e6de46cba3182a7af5c74cb5);
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

		public _a5a2f4b0e3907f545b69e23fea6e3c89_bc550ab8e6de46cba3182a7af5c74cb5(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a5a2f4b0e3907f545b69e23fea6e3c89_bc550ab8e6de46cba3182a7af5c74cb5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a5a2f4b0e3907f545b69e23fea6e3c89_bc550ab8e6de46cba3182a7af5c74cb5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a5a2f4b0e3907f545b69e23fea6e3c89_bc550ab8e6de46cba3182a7af5c74cb5);
		}
	}
}
