using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1ee4e97c7eb3fda4a85f62cf386e89a5_0468d554ad434eaf9559c3548d777e17 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _1ee4e97c7eb3fda4a85f62cf386e89a5_0468d554ad434eaf9559c3548d777e17 FromInterop(IntPtr data, int dataSize)
		{
			return default(_1ee4e97c7eb3fda4a85f62cf386e89a5_0468d554ad434eaf9559c3548d777e17);
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

		public _1ee4e97c7eb3fda4a85f62cf386e89a5_0468d554ad434eaf9559c3548d777e17(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_1ee4e97c7eb3fda4a85f62cf386e89a5_0468d554ad434eaf9559c3548d777e17 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1ee4e97c7eb3fda4a85f62cf386e89a5_0468d554ad434eaf9559c3548d777e17 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1ee4e97c7eb3fda4a85f62cf386e89a5_0468d554ad434eaf9559c3548d777e17);
		}
	}
}
