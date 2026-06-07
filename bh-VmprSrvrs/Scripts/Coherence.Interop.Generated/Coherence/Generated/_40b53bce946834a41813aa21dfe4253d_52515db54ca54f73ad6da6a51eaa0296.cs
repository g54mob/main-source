using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _40b53bce946834a41813aa21dfe4253d_52515db54ca54f73ad6da6a51eaa0296 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _40b53bce946834a41813aa21dfe4253d_52515db54ca54f73ad6da6a51eaa0296 FromInterop(IntPtr data, int dataSize)
		{
			return default(_40b53bce946834a41813aa21dfe4253d_52515db54ca54f73ad6da6a51eaa0296);
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

		public static void Serialize(_40b53bce946834a41813aa21dfe4253d_52515db54ca54f73ad6da6a51eaa0296 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _40b53bce946834a41813aa21dfe4253d_52515db54ca54f73ad6da6a51eaa0296 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_40b53bce946834a41813aa21dfe4253d_52515db54ca54f73ad6da6a51eaa0296);
		}
	}
}
