using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _27be4bd448a14b24b90fb2647920efc6_1e3d9a14adde4638b961d8f609dd3a16 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _27be4bd448a14b24b90fb2647920efc6_1e3d9a14adde4638b961d8f609dd3a16 FromInterop(IntPtr data, int dataSize)
		{
			return default(_27be4bd448a14b24b90fb2647920efc6_1e3d9a14adde4638b961d8f609dd3a16);
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

		public static void Serialize(_27be4bd448a14b24b90fb2647920efc6_1e3d9a14adde4638b961d8f609dd3a16 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _27be4bd448a14b24b90fb2647920efc6_1e3d9a14adde4638b961d8f609dd3a16 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_27be4bd448a14b24b90fb2647920efc6_1e3d9a14adde4638b961d8f609dd3a16);
		}
	}
}
