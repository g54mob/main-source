using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8f69b5b90f9820c48b20d38d4878a1f0_26aa3cfae835415d84107af813928533 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _8f69b5b90f9820c48b20d38d4878a1f0_26aa3cfae835415d84107af813928533 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8f69b5b90f9820c48b20d38d4878a1f0_26aa3cfae835415d84107af813928533);
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

		public _8f69b5b90f9820c48b20d38d4878a1f0_26aa3cfae835415d84107af813928533(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_8f69b5b90f9820c48b20d38d4878a1f0_26aa3cfae835415d84107af813928533 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8f69b5b90f9820c48b20d38d4878a1f0_26aa3cfae835415d84107af813928533 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8f69b5b90f9820c48b20d38d4878a1f0_26aa3cfae835415d84107af813928533);
		}
	}
}
