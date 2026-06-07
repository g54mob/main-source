using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _885006f2aca335e4cb9483009498af66_5972f2507e274b4296e036c1194eb65b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _885006f2aca335e4cb9483009498af66_5972f2507e274b4296e036c1194eb65b FromInterop(IntPtr data, int dataSize)
		{
			return default(_885006f2aca335e4cb9483009498af66_5972f2507e274b4296e036c1194eb65b);
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

		public _885006f2aca335e4cb9483009498af66_5972f2507e274b4296e036c1194eb65b(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_885006f2aca335e4cb9483009498af66_5972f2507e274b4296e036c1194eb65b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _885006f2aca335e4cb9483009498af66_5972f2507e274b4296e036c1194eb65b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_885006f2aca335e4cb9483009498af66_5972f2507e274b4296e036c1194eb65b);
		}
	}
}
