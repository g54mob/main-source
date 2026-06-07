using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _eabd5eea59ab75a49b346f8ad7226ecf_f692db3f8b9a4ab8a6d9b977c97593d5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _eabd5eea59ab75a49b346f8ad7226ecf_f692db3f8b9a4ab8a6d9b977c97593d5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_eabd5eea59ab75a49b346f8ad7226ecf_f692db3f8b9a4ab8a6d9b977c97593d5);
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

		public static void Serialize(_eabd5eea59ab75a49b346f8ad7226ecf_f692db3f8b9a4ab8a6d9b977c97593d5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _eabd5eea59ab75a49b346f8ad7226ecf_f692db3f8b9a4ab8a6d9b977c97593d5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_eabd5eea59ab75a49b346f8ad7226ecf_f692db3f8b9a4ab8a6d9b977c97593d5);
		}
	}
}
