using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d9a82312b61cdec469f33340676236e7_e3bf4b4b0dbe41e58ee442078f007c55 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity requestingPlayer;
		}

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d9a82312b61cdec469f33340676236e7_e3bf4b4b0dbe41e58ee442078f007c55 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d9a82312b61cdec469f33340676236e7_e3bf4b4b0dbe41e58ee442078f007c55);
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

		public _d9a82312b61cdec469f33340676236e7_e3bf4b4b0dbe41e58ee442078f007c55(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_d9a82312b61cdec469f33340676236e7_e3bf4b4b0dbe41e58ee442078f007c55 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d9a82312b61cdec469f33340676236e7_e3bf4b4b0dbe41e58ee442078f007c55 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d9a82312b61cdec469f33340676236e7_e3bf4b4b0dbe41e58ee442078f007c55);
		}
	}
}
