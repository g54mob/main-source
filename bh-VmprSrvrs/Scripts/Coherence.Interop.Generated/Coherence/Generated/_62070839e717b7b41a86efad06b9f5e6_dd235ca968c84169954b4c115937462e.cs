using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _62070839e717b7b41a86efad06b9f5e6_dd235ca968c84169954b4c115937462e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _62070839e717b7b41a86efad06b9f5e6_dd235ca968c84169954b4c115937462e FromInterop(IntPtr data, int dataSize)
		{
			return default(_62070839e717b7b41a86efad06b9f5e6_dd235ca968c84169954b4c115937462e);
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

		public static void Serialize(_62070839e717b7b41a86efad06b9f5e6_dd235ca968c84169954b4c115937462e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _62070839e717b7b41a86efad06b9f5e6_dd235ca968c84169954b4c115937462e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_62070839e717b7b41a86efad06b9f5e6_dd235ca968c84169954b4c115937462e);
		}
	}
}
