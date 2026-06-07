using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2a87a58318e06c444903296a69cecb18_a8ccfe32008f43128a9ba8670226c76a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2a87a58318e06c444903296a69cecb18_a8ccfe32008f43128a9ba8670226c76a FromInterop(IntPtr data, int dataSize)
		{
			return default(_2a87a58318e06c444903296a69cecb18_a8ccfe32008f43128a9ba8670226c76a);
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

		public static void Serialize(_2a87a58318e06c444903296a69cecb18_a8ccfe32008f43128a9ba8670226c76a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2a87a58318e06c444903296a69cecb18_a8ccfe32008f43128a9ba8670226c76a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2a87a58318e06c444903296a69cecb18_a8ccfe32008f43128a9ba8670226c76a);
		}
	}
}
