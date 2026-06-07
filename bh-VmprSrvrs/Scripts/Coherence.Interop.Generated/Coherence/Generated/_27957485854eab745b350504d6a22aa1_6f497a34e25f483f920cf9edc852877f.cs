using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _27957485854eab745b350504d6a22aa1_6f497a34e25f483f920cf9edc852877f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _27957485854eab745b350504d6a22aa1_6f497a34e25f483f920cf9edc852877f FromInterop(IntPtr data, int dataSize)
		{
			return default(_27957485854eab745b350504d6a22aa1_6f497a34e25f483f920cf9edc852877f);
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

		public static void Serialize(_27957485854eab745b350504d6a22aa1_6f497a34e25f483f920cf9edc852877f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _27957485854eab745b350504d6a22aa1_6f497a34e25f483f920cf9edc852877f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_27957485854eab745b350504d6a22aa1_6f497a34e25f483f920cf9edc852877f);
		}
	}
}
