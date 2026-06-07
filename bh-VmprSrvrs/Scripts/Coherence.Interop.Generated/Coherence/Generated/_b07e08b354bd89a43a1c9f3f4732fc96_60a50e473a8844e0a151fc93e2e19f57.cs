using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b07e08b354bd89a43a1c9f3f4732fc96_60a50e473a8844e0a151fc93e2e19f57 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _b07e08b354bd89a43a1c9f3f4732fc96_60a50e473a8844e0a151fc93e2e19f57 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b07e08b354bd89a43a1c9f3f4732fc96_60a50e473a8844e0a151fc93e2e19f57);
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

		public _b07e08b354bd89a43a1c9f3f4732fc96_60a50e473a8844e0a151fc93e2e19f57(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_b07e08b354bd89a43a1c9f3f4732fc96_60a50e473a8844e0a151fc93e2e19f57 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b07e08b354bd89a43a1c9f3f4732fc96_60a50e473a8844e0a151fc93e2e19f57 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b07e08b354bd89a43a1c9f3f4732fc96_60a50e473a8844e0a151fc93e2e19f57);
		}
	}
}
