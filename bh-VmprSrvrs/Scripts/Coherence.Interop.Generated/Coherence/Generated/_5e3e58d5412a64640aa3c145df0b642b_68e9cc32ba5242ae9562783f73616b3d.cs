using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5e3e58d5412a64640aa3c145df0b642b_68e9cc32ba5242ae9562783f73616b3d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5e3e58d5412a64640aa3c145df0b642b_68e9cc32ba5242ae9562783f73616b3d FromInterop(IntPtr data, int dataSize)
		{
			return default(_5e3e58d5412a64640aa3c145df0b642b_68e9cc32ba5242ae9562783f73616b3d);
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

		public static void Serialize(_5e3e58d5412a64640aa3c145df0b642b_68e9cc32ba5242ae9562783f73616b3d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5e3e58d5412a64640aa3c145df0b642b_68e9cc32ba5242ae9562783f73616b3d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5e3e58d5412a64640aa3c145df0b642b_68e9cc32ba5242ae9562783f73616b3d);
		}
	}
}
