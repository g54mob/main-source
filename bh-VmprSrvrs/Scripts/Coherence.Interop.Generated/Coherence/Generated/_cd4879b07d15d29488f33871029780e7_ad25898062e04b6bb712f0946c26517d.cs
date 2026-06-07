using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _cd4879b07d15d29488f33871029780e7_ad25898062e04b6bb712f0946c26517d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _cd4879b07d15d29488f33871029780e7_ad25898062e04b6bb712f0946c26517d FromInterop(IntPtr data, int dataSize)
		{
			return default(_cd4879b07d15d29488f33871029780e7_ad25898062e04b6bb712f0946c26517d);
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

		public _cd4879b07d15d29488f33871029780e7_ad25898062e04b6bb712f0946c26517d(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_cd4879b07d15d29488f33871029780e7_ad25898062e04b6bb712f0946c26517d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _cd4879b07d15d29488f33871029780e7_ad25898062e04b6bb712f0946c26517d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_cd4879b07d15d29488f33871029780e7_ad25898062e04b6bb712f0946c26517d);
		}
	}
}
