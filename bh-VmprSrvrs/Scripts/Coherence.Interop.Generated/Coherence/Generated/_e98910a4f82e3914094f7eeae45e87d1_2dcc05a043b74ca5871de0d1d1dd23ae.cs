using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e98910a4f82e3914094f7eeae45e87d1_2dcc05a043b74ca5871de0d1d1dd23ae : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e98910a4f82e3914094f7eeae45e87d1_2dcc05a043b74ca5871de0d1d1dd23ae FromInterop(IntPtr data, int dataSize)
		{
			return default(_e98910a4f82e3914094f7eeae45e87d1_2dcc05a043b74ca5871de0d1d1dd23ae);
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

		public _e98910a4f82e3914094f7eeae45e87d1_2dcc05a043b74ca5871de0d1d1dd23ae(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e98910a4f82e3914094f7eeae45e87d1_2dcc05a043b74ca5871de0d1d1dd23ae commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e98910a4f82e3914094f7eeae45e87d1_2dcc05a043b74ca5871de0d1d1dd23ae Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e98910a4f82e3914094f7eeae45e87d1_2dcc05a043b74ca5871de0d1d1dd23ae);
		}
	}
}
