using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7152f042fbafc14468670f353ab59954_2984cc70c1644edc8ee1cc4cafa50755 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7152f042fbafc14468670f353ab59954_2984cc70c1644edc8ee1cc4cafa50755 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7152f042fbafc14468670f353ab59954_2984cc70c1644edc8ee1cc4cafa50755);
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

		public static void Serialize(_7152f042fbafc14468670f353ab59954_2984cc70c1644edc8ee1cc4cafa50755 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7152f042fbafc14468670f353ab59954_2984cc70c1644edc8ee1cc4cafa50755 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7152f042fbafc14468670f353ab59954_2984cc70c1644edc8ee1cc4cafa50755);
		}
	}
}
