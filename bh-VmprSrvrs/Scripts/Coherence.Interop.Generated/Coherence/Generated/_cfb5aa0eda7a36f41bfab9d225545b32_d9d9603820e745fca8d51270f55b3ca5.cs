using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _cfb5aa0eda7a36f41bfab9d225545b32_d9d9603820e745fca8d51270f55b3ca5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _cfb5aa0eda7a36f41bfab9d225545b32_d9d9603820e745fca8d51270f55b3ca5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_cfb5aa0eda7a36f41bfab9d225545b32_d9d9603820e745fca8d51270f55b3ca5);
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

		public static void Serialize(_cfb5aa0eda7a36f41bfab9d225545b32_d9d9603820e745fca8d51270f55b3ca5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _cfb5aa0eda7a36f41bfab9d225545b32_d9d9603820e745fca8d51270f55b3ca5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_cfb5aa0eda7a36f41bfab9d225545b32_d9d9603820e745fca8d51270f55b3ca5);
		}
	}
}
