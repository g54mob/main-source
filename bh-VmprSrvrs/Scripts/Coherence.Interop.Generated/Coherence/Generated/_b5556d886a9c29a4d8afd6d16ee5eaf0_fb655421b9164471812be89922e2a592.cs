using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b5556d886a9c29a4d8afd6d16ee5eaf0_fb655421b9164471812be89922e2a592 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b5556d886a9c29a4d8afd6d16ee5eaf0_fb655421b9164471812be89922e2a592 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b5556d886a9c29a4d8afd6d16ee5eaf0_fb655421b9164471812be89922e2a592);
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

		public static void Serialize(_b5556d886a9c29a4d8afd6d16ee5eaf0_fb655421b9164471812be89922e2a592 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b5556d886a9c29a4d8afd6d16ee5eaf0_fb655421b9164471812be89922e2a592 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b5556d886a9c29a4d8afd6d16ee5eaf0_fb655421b9164471812be89922e2a592);
		}
	}
}
