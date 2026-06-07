using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d85c0fb147488bf4386472624606ae10_e0334b4ac7034512aba4b45024e1b2f5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d85c0fb147488bf4386472624606ae10_e0334b4ac7034512aba4b45024e1b2f5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d85c0fb147488bf4386472624606ae10_e0334b4ac7034512aba4b45024e1b2f5);
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

		public static void Serialize(_d85c0fb147488bf4386472624606ae10_e0334b4ac7034512aba4b45024e1b2f5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d85c0fb147488bf4386472624606ae10_e0334b4ac7034512aba4b45024e1b2f5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d85c0fb147488bf4386472624606ae10_e0334b4ac7034512aba4b45024e1b2f5);
		}
	}
}
