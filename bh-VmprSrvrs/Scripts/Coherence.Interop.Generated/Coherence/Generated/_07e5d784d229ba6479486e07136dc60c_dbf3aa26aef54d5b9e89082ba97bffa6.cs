using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _07e5d784d229ba6479486e07136dc60c_dbf3aa26aef54d5b9e89082ba97bffa6 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _07e5d784d229ba6479486e07136dc60c_dbf3aa26aef54d5b9e89082ba97bffa6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_07e5d784d229ba6479486e07136dc60c_dbf3aa26aef54d5b9e89082ba97bffa6);
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

		public static void Serialize(_07e5d784d229ba6479486e07136dc60c_dbf3aa26aef54d5b9e89082ba97bffa6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _07e5d784d229ba6479486e07136dc60c_dbf3aa26aef54d5b9e89082ba97bffa6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_07e5d784d229ba6479486e07136dc60c_dbf3aa26aef54d5b9e89082ba97bffa6);
		}
	}
}
