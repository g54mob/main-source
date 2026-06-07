using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _62070839e717b7b41a86efad06b9f5e6_dace7e2531d0449fb4517972b94a7f90 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _62070839e717b7b41a86efad06b9f5e6_dace7e2531d0449fb4517972b94a7f90 FromInterop(IntPtr data, int dataSize)
		{
			return default(_62070839e717b7b41a86efad06b9f5e6_dace7e2531d0449fb4517972b94a7f90);
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

		public _62070839e717b7b41a86efad06b9f5e6_dace7e2531d0449fb4517972b94a7f90(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_62070839e717b7b41a86efad06b9f5e6_dace7e2531d0449fb4517972b94a7f90 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _62070839e717b7b41a86efad06b9f5e6_dace7e2531d0449fb4517972b94a7f90 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_62070839e717b7b41a86efad06b9f5e6_dace7e2531d0449fb4517972b94a7f90);
		}
	}
}
