using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a53e110a439c53642a3224d2d46f0152_1972318136d342a99ccedd99f52e098d : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _a53e110a439c53642a3224d2d46f0152_1972318136d342a99ccedd99f52e098d FromInterop(IntPtr data, int dataSize)
		{
			return default(_a53e110a439c53642a3224d2d46f0152_1972318136d342a99ccedd99f52e098d);
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

		public _a53e110a439c53642a3224d2d46f0152_1972318136d342a99ccedd99f52e098d(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a53e110a439c53642a3224d2d46f0152_1972318136d342a99ccedd99f52e098d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a53e110a439c53642a3224d2d46f0152_1972318136d342a99ccedd99f52e098d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a53e110a439c53642a3224d2d46f0152_1972318136d342a99ccedd99f52e098d);
		}
	}
}
