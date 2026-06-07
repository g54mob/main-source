using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a5ce7a045db4a7b418fadc9e6af0dd3d_9b385b21920f4eac9046699f3f7e9e59 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a5ce7a045db4a7b418fadc9e6af0dd3d_9b385b21920f4eac9046699f3f7e9e59 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a5ce7a045db4a7b418fadc9e6af0dd3d_9b385b21920f4eac9046699f3f7e9e59);
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

		public static void Serialize(_a5ce7a045db4a7b418fadc9e6af0dd3d_9b385b21920f4eac9046699f3f7e9e59 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a5ce7a045db4a7b418fadc9e6af0dd3d_9b385b21920f4eac9046699f3f7e9e59 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a5ce7a045db4a7b418fadc9e6af0dd3d_9b385b21920f4eac9046699f3f7e9e59);
		}
	}
}
