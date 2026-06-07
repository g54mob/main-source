using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fd1192722e04ed446ba8052703d71b52_f98d3a3953ed479fb42b6d6a5f1b907d : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _fd1192722e04ed446ba8052703d71b52_f98d3a3953ed479fb42b6d6a5f1b907d FromInterop(IntPtr data, int dataSize)
		{
			return default(_fd1192722e04ed446ba8052703d71b52_f98d3a3953ed479fb42b6d6a5f1b907d);
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

		public _fd1192722e04ed446ba8052703d71b52_f98d3a3953ed479fb42b6d6a5f1b907d(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_fd1192722e04ed446ba8052703d71b52_f98d3a3953ed479fb42b6d6a5f1b907d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fd1192722e04ed446ba8052703d71b52_f98d3a3953ed479fb42b6d6a5f1b907d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fd1192722e04ed446ba8052703d71b52_f98d3a3953ed479fb42b6d6a5f1b907d);
		}
	}
}
