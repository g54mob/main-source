using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _88b68dbaed804624b8f27ed0be24b05d_7a6be6b206c343d1872d56bf28f4d049 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity player;
		}

		public long startingSimFrame;

		public Entity player;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _88b68dbaed804624b8f27ed0be24b05d_7a6be6b206c343d1872d56bf28f4d049 FromInterop(IntPtr data, int dataSize)
		{
			return default(_88b68dbaed804624b8f27ed0be24b05d_7a6be6b206c343d1872d56bf28f4d049);
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

		public _88b68dbaed804624b8f27ed0be24b05d_7a6be6b206c343d1872d56bf28f4d049(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_88b68dbaed804624b8f27ed0be24b05d_7a6be6b206c343d1872d56bf28f4d049 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _88b68dbaed804624b8f27ed0be24b05d_7a6be6b206c343d1872d56bf28f4d049 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_88b68dbaed804624b8f27ed0be24b05d_7a6be6b206c343d1872d56bf28f4d049);
		}
	}
}
