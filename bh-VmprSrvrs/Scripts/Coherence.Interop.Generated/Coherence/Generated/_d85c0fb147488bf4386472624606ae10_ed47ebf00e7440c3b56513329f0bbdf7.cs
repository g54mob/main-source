using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d85c0fb147488bf4386472624606ae10_ed47ebf00e7440c3b56513329f0bbdf7 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint clientId;
		}

		public uint clientId;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d85c0fb147488bf4386472624606ae10_ed47ebf00e7440c3b56513329f0bbdf7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d85c0fb147488bf4386472624606ae10_ed47ebf00e7440c3b56513329f0bbdf7);
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

		public _d85c0fb147488bf4386472624606ae10_ed47ebf00e7440c3b56513329f0bbdf7(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_d85c0fb147488bf4386472624606ae10_ed47ebf00e7440c3b56513329f0bbdf7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d85c0fb147488bf4386472624606ae10_ed47ebf00e7440c3b56513329f0bbdf7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d85c0fb147488bf4386472624606ae10_ed47ebf00e7440c3b56513329f0bbdf7);
		}
	}
}
