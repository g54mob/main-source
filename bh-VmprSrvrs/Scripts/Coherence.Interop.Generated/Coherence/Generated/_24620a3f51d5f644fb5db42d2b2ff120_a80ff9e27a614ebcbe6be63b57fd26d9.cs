using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _24620a3f51d5f644fb5db42d2b2ff120_a80ff9e27a614ebcbe6be63b57fd26d9 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _24620a3f51d5f644fb5db42d2b2ff120_a80ff9e27a614ebcbe6be63b57fd26d9 FromInterop(IntPtr data, int dataSize)
		{
			return default(_24620a3f51d5f644fb5db42d2b2ff120_a80ff9e27a614ebcbe6be63b57fd26d9);
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

		public _24620a3f51d5f644fb5db42d2b2ff120_a80ff9e27a614ebcbe6be63b57fd26d9(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_24620a3f51d5f644fb5db42d2b2ff120_a80ff9e27a614ebcbe6be63b57fd26d9 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _24620a3f51d5f644fb5db42d2b2ff120_a80ff9e27a614ebcbe6be63b57fd26d9 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_24620a3f51d5f644fb5db42d2b2ff120_a80ff9e27a614ebcbe6be63b57fd26d9);
		}
	}
}
