using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ce9c1b5ac78f2db459e4e7e30e3dce06_ad9f3dcf2cce463ba35290e7531fb3c8 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _ce9c1b5ac78f2db459e4e7e30e3dce06_ad9f3dcf2cce463ba35290e7531fb3c8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ce9c1b5ac78f2db459e4e7e30e3dce06_ad9f3dcf2cce463ba35290e7531fb3c8);
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

		public _ce9c1b5ac78f2db459e4e7e30e3dce06_ad9f3dcf2cce463ba35290e7531fb3c8(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ce9c1b5ac78f2db459e4e7e30e3dce06_ad9f3dcf2cce463ba35290e7531fb3c8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ce9c1b5ac78f2db459e4e7e30e3dce06_ad9f3dcf2cce463ba35290e7531fb3c8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ce9c1b5ac78f2db459e4e7e30e3dce06_ad9f3dcf2cce463ba35290e7531fb3c8);
		}
	}
}
