using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9eacf83a7726a8446bda843cc0c25b64_e0c11cbc3dd04554a7f66a389ce2079b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _9eacf83a7726a8446bda843cc0c25b64_e0c11cbc3dd04554a7f66a389ce2079b FromInterop(IntPtr data, int dataSize)
		{
			return default(_9eacf83a7726a8446bda843cc0c25b64_e0c11cbc3dd04554a7f66a389ce2079b);
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

		public static void Serialize(_9eacf83a7726a8446bda843cc0c25b64_e0c11cbc3dd04554a7f66a389ce2079b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9eacf83a7726a8446bda843cc0c25b64_e0c11cbc3dd04554a7f66a389ce2079b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9eacf83a7726a8446bda843cc0c25b64_e0c11cbc3dd04554a7f66a389ce2079b);
		}
	}
}
