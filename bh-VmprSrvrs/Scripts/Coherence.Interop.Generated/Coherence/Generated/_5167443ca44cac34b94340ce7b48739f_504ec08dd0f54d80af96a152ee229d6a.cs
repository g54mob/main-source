using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5167443ca44cac34b94340ce7b48739f_504ec08dd0f54d80af96a152ee229d6a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _5167443ca44cac34b94340ce7b48739f_504ec08dd0f54d80af96a152ee229d6a FromInterop(IntPtr data, int dataSize)
		{
			return default(_5167443ca44cac34b94340ce7b48739f_504ec08dd0f54d80af96a152ee229d6a);
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

		public _5167443ca44cac34b94340ce7b48739f_504ec08dd0f54d80af96a152ee229d6a(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5167443ca44cac34b94340ce7b48739f_504ec08dd0f54d80af96a152ee229d6a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5167443ca44cac34b94340ce7b48739f_504ec08dd0f54d80af96a152ee229d6a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5167443ca44cac34b94340ce7b48739f_504ec08dd0f54d80af96a152ee229d6a);
		}
	}
}
