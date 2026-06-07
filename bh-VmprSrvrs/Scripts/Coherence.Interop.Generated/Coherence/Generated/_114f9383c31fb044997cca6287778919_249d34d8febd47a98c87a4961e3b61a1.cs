using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _114f9383c31fb044997cca6287778919_249d34d8febd47a98c87a4961e3b61a1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _114f9383c31fb044997cca6287778919_249d34d8febd47a98c87a4961e3b61a1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_114f9383c31fb044997cca6287778919_249d34d8febd47a98c87a4961e3b61a1);
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

		public static void Serialize(_114f9383c31fb044997cca6287778919_249d34d8febd47a98c87a4961e3b61a1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _114f9383c31fb044997cca6287778919_249d34d8febd47a98c87a4961e3b61a1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_114f9383c31fb044997cca6287778919_249d34d8febd47a98c87a4961e3b61a1);
		}
	}
}
