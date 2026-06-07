using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _52e3b4ea7f19fec42b81756e2a8aeabf_7c72c75a1fd9464c99aceb0a937f8e5e : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _52e3b4ea7f19fec42b81756e2a8aeabf_7c72c75a1fd9464c99aceb0a937f8e5e FromInterop(IntPtr data, int dataSize)
		{
			return default(_52e3b4ea7f19fec42b81756e2a8aeabf_7c72c75a1fd9464c99aceb0a937f8e5e);
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

		public _52e3b4ea7f19fec42b81756e2a8aeabf_7c72c75a1fd9464c99aceb0a937f8e5e(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_52e3b4ea7f19fec42b81756e2a8aeabf_7c72c75a1fd9464c99aceb0a937f8e5e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _52e3b4ea7f19fec42b81756e2a8aeabf_7c72c75a1fd9464c99aceb0a937f8e5e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_52e3b4ea7f19fec42b81756e2a8aeabf_7c72c75a1fd9464c99aceb0a937f8e5e);
		}
	}
}
