using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8ff97a6ad93b99249bb6999eba9c9530_d41e4046c00a43028f8a8a4bb81eb991 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _8ff97a6ad93b99249bb6999eba9c9530_d41e4046c00a43028f8a8a4bb81eb991 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8ff97a6ad93b99249bb6999eba9c9530_d41e4046c00a43028f8a8a4bb81eb991);
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

		public static void Serialize(_8ff97a6ad93b99249bb6999eba9c9530_d41e4046c00a43028f8a8a4bb81eb991 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8ff97a6ad93b99249bb6999eba9c9530_d41e4046c00a43028f8a8a4bb81eb991 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8ff97a6ad93b99249bb6999eba9c9530_d41e4046c00a43028f8a8a4bb81eb991);
		}
	}
}
