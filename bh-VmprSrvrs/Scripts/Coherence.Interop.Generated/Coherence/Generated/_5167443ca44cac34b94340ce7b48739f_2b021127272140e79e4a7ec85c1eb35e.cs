using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5167443ca44cac34b94340ce7b48739f_2b021127272140e79e4a7ec85c1eb35e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte eraseItems;

			[FieldOffset(1)]
			public byte skipTriggers;
		}

		public bool eraseItems;

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5167443ca44cac34b94340ce7b48739f_2b021127272140e79e4a7ec85c1eb35e FromInterop(IntPtr data, int dataSize)
		{
			return default(_5167443ca44cac34b94340ce7b48739f_2b021127272140e79e4a7ec85c1eb35e);
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

		public _5167443ca44cac34b94340ce7b48739f_2b021127272140e79e4a7ec85c1eb35e(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5167443ca44cac34b94340ce7b48739f_2b021127272140e79e4a7ec85c1eb35e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5167443ca44cac34b94340ce7b48739f_2b021127272140e79e4a7ec85c1eb35e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5167443ca44cac34b94340ce7b48739f_2b021127272140e79e4a7ec85c1eb35e);
		}
	}
}
