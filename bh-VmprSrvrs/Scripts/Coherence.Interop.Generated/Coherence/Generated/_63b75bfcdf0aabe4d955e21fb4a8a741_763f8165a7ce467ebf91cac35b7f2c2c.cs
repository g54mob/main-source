using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _63b75bfcdf0aabe4d955e21fb4a8a741_763f8165a7ce467ebf91cac35b7f2c2c : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _63b75bfcdf0aabe4d955e21fb4a8a741_763f8165a7ce467ebf91cac35b7f2c2c FromInterop(IntPtr data, int dataSize)
		{
			return default(_63b75bfcdf0aabe4d955e21fb4a8a741_763f8165a7ce467ebf91cac35b7f2c2c);
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

		public _63b75bfcdf0aabe4d955e21fb4a8a741_763f8165a7ce467ebf91cac35b7f2c2c(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_63b75bfcdf0aabe4d955e21fb4a8a741_763f8165a7ce467ebf91cac35b7f2c2c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _63b75bfcdf0aabe4d955e21fb4a8a741_763f8165a7ce467ebf91cac35b7f2c2c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_63b75bfcdf0aabe4d955e21fb4a8a741_763f8165a7ce467ebf91cac35b7f2c2c);
		}
	}
}
