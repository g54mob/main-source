using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _adf15ca35ddd8ec4da348afaf9db339e_357cadbbc18d41548dee84008f249b3a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte eraseItems;

			[FieldOffset(1)]
			public byte skipTriggers;
		}

		public bool eraseItems;

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _adf15ca35ddd8ec4da348afaf9db339e_357cadbbc18d41548dee84008f249b3a FromInterop(IntPtr data, int dataSize)
		{
			return default(_adf15ca35ddd8ec4da348afaf9db339e_357cadbbc18d41548dee84008f249b3a);
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

		public _adf15ca35ddd8ec4da348afaf9db339e_357cadbbc18d41548dee84008f249b3a(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_adf15ca35ddd8ec4da348afaf9db339e_357cadbbc18d41548dee84008f249b3a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _adf15ca35ddd8ec4da348afaf9db339e_357cadbbc18d41548dee84008f249b3a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_adf15ca35ddd8ec4da348afaf9db339e_357cadbbc18d41548dee84008f249b3a);
		}
	}
}
