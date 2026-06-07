using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _93146e3daa128b749b312aadee0d3900_8a3d185c09c341b28c23127462eb884c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity enemy;
		}

		public Entity enemy;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _93146e3daa128b749b312aadee0d3900_8a3d185c09c341b28c23127462eb884c FromInterop(IntPtr data, int dataSize)
		{
			return default(_93146e3daa128b749b312aadee0d3900_8a3d185c09c341b28c23127462eb884c);
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

		public _93146e3daa128b749b312aadee0d3900_8a3d185c09c341b28c23127462eb884c(Entity entity, Entity enemy)
		{
			this.enemy = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_93146e3daa128b749b312aadee0d3900_8a3d185c09c341b28c23127462eb884c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _93146e3daa128b749b312aadee0d3900_8a3d185c09c341b28c23127462eb884c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_93146e3daa128b749b312aadee0d3900_8a3d185c09c341b28c23127462eb884c);
		}
	}
}
