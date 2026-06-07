using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ad325606f9c20fb4a828724c40cf9d36_ce68b465ac1a43d4af10da63bdeb6854 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ad325606f9c20fb4a828724c40cf9d36_ce68b465ac1a43d4af10da63bdeb6854 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ad325606f9c20fb4a828724c40cf9d36_ce68b465ac1a43d4af10da63bdeb6854);
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

		public static void Serialize(_ad325606f9c20fb4a828724c40cf9d36_ce68b465ac1a43d4af10da63bdeb6854 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ad325606f9c20fb4a828724c40cf9d36_ce68b465ac1a43d4af10da63bdeb6854 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ad325606f9c20fb4a828724c40cf9d36_ce68b465ac1a43d4af10da63bdeb6854);
		}
	}
}
