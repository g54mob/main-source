using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a2bda7ab6fb525d41b33b10e085ca5e3_0502c98f72094341bbab6c6ad9b8944f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a2bda7ab6fb525d41b33b10e085ca5e3_0502c98f72094341bbab6c6ad9b8944f FromInterop(IntPtr data, int dataSize)
		{
			return default(_a2bda7ab6fb525d41b33b10e085ca5e3_0502c98f72094341bbab6c6ad9b8944f);
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

		public _a2bda7ab6fb525d41b33b10e085ca5e3_0502c98f72094341bbab6c6ad9b8944f(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a2bda7ab6fb525d41b33b10e085ca5e3_0502c98f72094341bbab6c6ad9b8944f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a2bda7ab6fb525d41b33b10e085ca5e3_0502c98f72094341bbab6c6ad9b8944f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a2bda7ab6fb525d41b33b10e085ca5e3_0502c98f72094341bbab6c6ad9b8944f);
		}
	}
}
