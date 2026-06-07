using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9dd30fc2395013d408bf881d717d21d9_8b96052bfb9a4c66b899319a6abfd094 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _9dd30fc2395013d408bf881d717d21d9_8b96052bfb9a4c66b899319a6abfd094 FromInterop(IntPtr data, int dataSize)
		{
			return default(_9dd30fc2395013d408bf881d717d21d9_8b96052bfb9a4c66b899319a6abfd094);
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

		public static void Serialize(_9dd30fc2395013d408bf881d717d21d9_8b96052bfb9a4c66b899319a6abfd094 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9dd30fc2395013d408bf881d717d21d9_8b96052bfb9a4c66b899319a6abfd094 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9dd30fc2395013d408bf881d717d21d9_8b96052bfb9a4c66b899319a6abfd094);
		}
	}
}
