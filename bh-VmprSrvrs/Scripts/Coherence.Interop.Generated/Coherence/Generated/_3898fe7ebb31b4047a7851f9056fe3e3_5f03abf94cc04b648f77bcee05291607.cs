using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3898fe7ebb31b4047a7851f9056fe3e3_5f03abf94cc04b648f77bcee05291607 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _3898fe7ebb31b4047a7851f9056fe3e3_5f03abf94cc04b648f77bcee05291607 FromInterop(IntPtr data, int dataSize)
		{
			return default(_3898fe7ebb31b4047a7851f9056fe3e3_5f03abf94cc04b648f77bcee05291607);
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

		public static void Serialize(_3898fe7ebb31b4047a7851f9056fe3e3_5f03abf94cc04b648f77bcee05291607 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3898fe7ebb31b4047a7851f9056fe3e3_5f03abf94cc04b648f77bcee05291607 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3898fe7ebb31b4047a7851f9056fe3e3_5f03abf94cc04b648f77bcee05291607);
		}
	}
}
