using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fcd65334626bcc24799d6993331abcf6_31001425da494991817059f69709b06a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fcd65334626bcc24799d6993331abcf6_31001425da494991817059f69709b06a FromInterop(IntPtr data, int dataSize)
		{
			return default(_fcd65334626bcc24799d6993331abcf6_31001425da494991817059f69709b06a);
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

		public static void Serialize(_fcd65334626bcc24799d6993331abcf6_31001425da494991817059f69709b06a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fcd65334626bcc24799d6993331abcf6_31001425da494991817059f69709b06a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fcd65334626bcc24799d6993331abcf6_31001425da494991817059f69709b06a);
		}
	}
}
