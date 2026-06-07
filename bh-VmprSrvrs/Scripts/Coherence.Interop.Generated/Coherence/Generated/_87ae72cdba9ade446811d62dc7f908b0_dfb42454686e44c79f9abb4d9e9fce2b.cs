using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _87ae72cdba9ade446811d62dc7f908b0_dfb42454686e44c79f9abb4d9e9fce2b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _87ae72cdba9ade446811d62dc7f908b0_dfb42454686e44c79f9abb4d9e9fce2b FromInterop(IntPtr data, int dataSize)
		{
			return default(_87ae72cdba9ade446811d62dc7f908b0_dfb42454686e44c79f9abb4d9e9fce2b);
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

		public _87ae72cdba9ade446811d62dc7f908b0_dfb42454686e44c79f9abb4d9e9fce2b(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_87ae72cdba9ade446811d62dc7f908b0_dfb42454686e44c79f9abb4d9e9fce2b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _87ae72cdba9ade446811d62dc7f908b0_dfb42454686e44c79f9abb4d9e9fce2b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_87ae72cdba9ade446811d62dc7f908b0_dfb42454686e44c79f9abb4d9e9fce2b);
		}
	}
}
