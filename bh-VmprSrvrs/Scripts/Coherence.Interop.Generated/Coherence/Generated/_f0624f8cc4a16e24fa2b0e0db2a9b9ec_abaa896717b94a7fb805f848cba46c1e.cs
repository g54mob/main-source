using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f0624f8cc4a16e24fa2b0e0db2a9b9ec_abaa896717b94a7fb805f848cba46c1e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f0624f8cc4a16e24fa2b0e0db2a9b9ec_abaa896717b94a7fb805f848cba46c1e FromInterop(IntPtr data, int dataSize)
		{
			return default(_f0624f8cc4a16e24fa2b0e0db2a9b9ec_abaa896717b94a7fb805f848cba46c1e);
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

		public static void Serialize(_f0624f8cc4a16e24fa2b0e0db2a9b9ec_abaa896717b94a7fb805f848cba46c1e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f0624f8cc4a16e24fa2b0e0db2a9b9ec_abaa896717b94a7fb805f848cba46c1e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f0624f8cc4a16e24fa2b0e0db2a9b9ec_abaa896717b94a7fb805f848cba46c1e);
		}
	}
}
