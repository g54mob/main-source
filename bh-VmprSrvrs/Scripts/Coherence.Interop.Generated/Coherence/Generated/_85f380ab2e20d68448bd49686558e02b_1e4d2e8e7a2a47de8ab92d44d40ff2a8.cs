using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _85f380ab2e20d68448bd49686558e02b_1e4d2e8e7a2a47de8ab92d44d40ff2a8 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _85f380ab2e20d68448bd49686558e02b_1e4d2e8e7a2a47de8ab92d44d40ff2a8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_85f380ab2e20d68448bd49686558e02b_1e4d2e8e7a2a47de8ab92d44d40ff2a8);
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

		public static void Serialize(_85f380ab2e20d68448bd49686558e02b_1e4d2e8e7a2a47de8ab92d44d40ff2a8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _85f380ab2e20d68448bd49686558e02b_1e4d2e8e7a2a47de8ab92d44d40ff2a8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_85f380ab2e20d68448bd49686558e02b_1e4d2e8e7a2a47de8ab92d44d40ff2a8);
		}
	}
}
