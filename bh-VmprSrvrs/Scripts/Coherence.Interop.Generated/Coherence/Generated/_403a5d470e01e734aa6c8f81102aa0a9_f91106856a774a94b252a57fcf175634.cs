using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _403a5d470e01e734aa6c8f81102aa0a9_f91106856a774a94b252a57fcf175634 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _403a5d470e01e734aa6c8f81102aa0a9_f91106856a774a94b252a57fcf175634 FromInterop(IntPtr data, int dataSize)
		{
			return default(_403a5d470e01e734aa6c8f81102aa0a9_f91106856a774a94b252a57fcf175634);
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

		public static void Serialize(_403a5d470e01e734aa6c8f81102aa0a9_f91106856a774a94b252a57fcf175634 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _403a5d470e01e734aa6c8f81102aa0a9_f91106856a774a94b252a57fcf175634 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_403a5d470e01e734aa6c8f81102aa0a9_f91106856a774a94b252a57fcf175634);
		}
	}
}
