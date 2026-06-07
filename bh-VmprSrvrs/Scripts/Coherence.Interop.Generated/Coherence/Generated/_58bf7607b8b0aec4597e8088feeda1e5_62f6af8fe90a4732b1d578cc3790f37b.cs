using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _58bf7607b8b0aec4597e8088feeda1e5_62f6af8fe90a4732b1d578cc3790f37b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _58bf7607b8b0aec4597e8088feeda1e5_62f6af8fe90a4732b1d578cc3790f37b FromInterop(IntPtr data, int dataSize)
		{
			return default(_58bf7607b8b0aec4597e8088feeda1e5_62f6af8fe90a4732b1d578cc3790f37b);
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

		public static void Serialize(_58bf7607b8b0aec4597e8088feeda1e5_62f6af8fe90a4732b1d578cc3790f37b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _58bf7607b8b0aec4597e8088feeda1e5_62f6af8fe90a4732b1d578cc3790f37b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_58bf7607b8b0aec4597e8088feeda1e5_62f6af8fe90a4732b1d578cc3790f37b);
		}
	}
}
