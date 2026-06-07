using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6ef7c0baad4dee54584188b4e3f62f97_0a553ca14cfc44fe959a57319df5980e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _6ef7c0baad4dee54584188b4e3f62f97_0a553ca14cfc44fe959a57319df5980e FromInterop(IntPtr data, int dataSize)
		{
			return default(_6ef7c0baad4dee54584188b4e3f62f97_0a553ca14cfc44fe959a57319df5980e);
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

		public static void Serialize(_6ef7c0baad4dee54584188b4e3f62f97_0a553ca14cfc44fe959a57319df5980e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6ef7c0baad4dee54584188b4e3f62f97_0a553ca14cfc44fe959a57319df5980e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6ef7c0baad4dee54584188b4e3f62f97_0a553ca14cfc44fe959a57319df5980e);
		}
	}
}
