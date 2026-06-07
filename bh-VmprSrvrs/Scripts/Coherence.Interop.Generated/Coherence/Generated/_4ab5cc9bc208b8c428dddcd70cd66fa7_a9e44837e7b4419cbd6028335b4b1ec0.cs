using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4ab5cc9bc208b8c428dddcd70cd66fa7_a9e44837e7b4419cbd6028335b4b1ec0 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4ab5cc9bc208b8c428dddcd70cd66fa7_a9e44837e7b4419cbd6028335b4b1ec0 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4ab5cc9bc208b8c428dddcd70cd66fa7_a9e44837e7b4419cbd6028335b4b1ec0);
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

		public static void Serialize(_4ab5cc9bc208b8c428dddcd70cd66fa7_a9e44837e7b4419cbd6028335b4b1ec0 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4ab5cc9bc208b8c428dddcd70cd66fa7_a9e44837e7b4419cbd6028335b4b1ec0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4ab5cc9bc208b8c428dddcd70cd66fa7_a9e44837e7b4419cbd6028335b4b1ec0);
		}
	}
}
