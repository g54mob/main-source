using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c7e0fb570efe2be44b57e26a8153d304_abfef8cbe065455abf123f9fd7b82359 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c7e0fb570efe2be44b57e26a8153d304_abfef8cbe065455abf123f9fd7b82359 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c7e0fb570efe2be44b57e26a8153d304_abfef8cbe065455abf123f9fd7b82359);
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

		public static void Serialize(_c7e0fb570efe2be44b57e26a8153d304_abfef8cbe065455abf123f9fd7b82359 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c7e0fb570efe2be44b57e26a8153d304_abfef8cbe065455abf123f9fd7b82359 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c7e0fb570efe2be44b57e26a8153d304_abfef8cbe065455abf123f9fd7b82359);
		}
	}
}
