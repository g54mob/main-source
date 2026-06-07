using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ffcb595f3781e1b4bbf128d57f1cd754_ca7cc6bef32a4ac98a3dc6855a96f22c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ffcb595f3781e1b4bbf128d57f1cd754_ca7cc6bef32a4ac98a3dc6855a96f22c FromInterop(IntPtr data, int dataSize)
		{
			return default(_ffcb595f3781e1b4bbf128d57f1cd754_ca7cc6bef32a4ac98a3dc6855a96f22c);
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

		public static void Serialize(_ffcb595f3781e1b4bbf128d57f1cd754_ca7cc6bef32a4ac98a3dc6855a96f22c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ffcb595f3781e1b4bbf128d57f1cd754_ca7cc6bef32a4ac98a3dc6855a96f22c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ffcb595f3781e1b4bbf128d57f1cd754_ca7cc6bef32a4ac98a3dc6855a96f22c);
		}
	}
}
