using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6cc9b126243967c42a13e9ca0e361dfd_074af6540f744d28a7e853183d794b56 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _6cc9b126243967c42a13e9ca0e361dfd_074af6540f744d28a7e853183d794b56 FromInterop(IntPtr data, int dataSize)
		{
			return default(_6cc9b126243967c42a13e9ca0e361dfd_074af6540f744d28a7e853183d794b56);
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

		public _6cc9b126243967c42a13e9ca0e361dfd_074af6540f744d28a7e853183d794b56(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6cc9b126243967c42a13e9ca0e361dfd_074af6540f744d28a7e853183d794b56 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6cc9b126243967c42a13e9ca0e361dfd_074af6540f744d28a7e853183d794b56 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6cc9b126243967c42a13e9ca0e361dfd_074af6540f744d28a7e853183d794b56);
		}
	}
}
