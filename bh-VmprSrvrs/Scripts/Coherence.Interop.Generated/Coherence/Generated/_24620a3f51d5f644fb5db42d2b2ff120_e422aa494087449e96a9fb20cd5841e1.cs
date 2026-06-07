using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _24620a3f51d5f644fb5db42d2b2ff120_e422aa494087449e96a9fb20cd5841e1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public float percentage;
		}

		public long startingSimFrame;

		public float percentage;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _24620a3f51d5f644fb5db42d2b2ff120_e422aa494087449e96a9fb20cd5841e1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_24620a3f51d5f644fb5db42d2b2ff120_e422aa494087449e96a9fb20cd5841e1);
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

		public _24620a3f51d5f644fb5db42d2b2ff120_e422aa494087449e96a9fb20cd5841e1(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_24620a3f51d5f644fb5db42d2b2ff120_e422aa494087449e96a9fb20cd5841e1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _24620a3f51d5f644fb5db42d2b2ff120_e422aa494087449e96a9fb20cd5841e1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_24620a3f51d5f644fb5db42d2b2ff120_e422aa494087449e96a9fb20cd5841e1);
		}
	}
}
