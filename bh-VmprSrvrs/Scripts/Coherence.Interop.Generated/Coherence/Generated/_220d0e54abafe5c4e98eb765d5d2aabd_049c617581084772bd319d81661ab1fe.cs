using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _220d0e54abafe5c4e98eb765d5d2aabd_049c617581084772bd319d81661ab1fe : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _220d0e54abafe5c4e98eb765d5d2aabd_049c617581084772bd319d81661ab1fe FromInterop(IntPtr data, int dataSize)
		{
			return default(_220d0e54abafe5c4e98eb765d5d2aabd_049c617581084772bd319d81661ab1fe);
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

		public static void Serialize(_220d0e54abafe5c4e98eb765d5d2aabd_049c617581084772bd319d81661ab1fe commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _220d0e54abafe5c4e98eb765d5d2aabd_049c617581084772bd319d81661ab1fe Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_220d0e54abafe5c4e98eb765d5d2aabd_049c617581084772bd319d81661ab1fe);
		}
	}
}
