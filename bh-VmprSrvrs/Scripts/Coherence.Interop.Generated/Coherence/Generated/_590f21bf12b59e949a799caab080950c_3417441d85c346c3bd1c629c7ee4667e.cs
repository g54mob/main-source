using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _590f21bf12b59e949a799caab080950c_3417441d85c346c3bd1c629c7ee4667e : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _590f21bf12b59e949a799caab080950c_3417441d85c346c3bd1c629c7ee4667e FromInterop(IntPtr data, int dataSize)
		{
			return default(_590f21bf12b59e949a799caab080950c_3417441d85c346c3bd1c629c7ee4667e);
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

		public _590f21bf12b59e949a799caab080950c_3417441d85c346c3bd1c629c7ee4667e(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_590f21bf12b59e949a799caab080950c_3417441d85c346c3bd1c629c7ee4667e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _590f21bf12b59e949a799caab080950c_3417441d85c346c3bd1c629c7ee4667e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_590f21bf12b59e949a799caab080950c_3417441d85c346c3bd1c629c7ee4667e);
		}
	}
}
