using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ec21cdaeffd11af429156db0dbd36e5c_6fe3d2dd4752416eaec8bee449d233fb : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ec21cdaeffd11af429156db0dbd36e5c_6fe3d2dd4752416eaec8bee449d233fb FromInterop(IntPtr data, int dataSize)
		{
			return default(_ec21cdaeffd11af429156db0dbd36e5c_6fe3d2dd4752416eaec8bee449d233fb);
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

		public _ec21cdaeffd11af429156db0dbd36e5c_6fe3d2dd4752416eaec8bee449d233fb(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ec21cdaeffd11af429156db0dbd36e5c_6fe3d2dd4752416eaec8bee449d233fb commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ec21cdaeffd11af429156db0dbd36e5c_6fe3d2dd4752416eaec8bee449d233fb Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ec21cdaeffd11af429156db0dbd36e5c_6fe3d2dd4752416eaec8bee449d233fb);
		}
	}
}
