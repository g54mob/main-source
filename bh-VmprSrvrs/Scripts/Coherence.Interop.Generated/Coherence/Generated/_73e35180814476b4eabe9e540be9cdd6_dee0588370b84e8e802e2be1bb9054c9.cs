using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _73e35180814476b4eabe9e540be9cdd6_dee0588370b84e8e802e2be1bb9054c9 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public byte instantRevival;
		}

		public long startingSimFrame;

		public bool instantRevival;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _73e35180814476b4eabe9e540be9cdd6_dee0588370b84e8e802e2be1bb9054c9 FromInterop(IntPtr data, int dataSize)
		{
			return default(_73e35180814476b4eabe9e540be9cdd6_dee0588370b84e8e802e2be1bb9054c9);
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

		public _73e35180814476b4eabe9e540be9cdd6_dee0588370b84e8e802e2be1bb9054c9(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_73e35180814476b4eabe9e540be9cdd6_dee0588370b84e8e802e2be1bb9054c9 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _73e35180814476b4eabe9e540be9cdd6_dee0588370b84e8e802e2be1bb9054c9 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_73e35180814476b4eabe9e540be9cdd6_dee0588370b84e8e802e2be1bb9054c9);
		}
	}
}
