using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3e13a6165d840b64197c2aef3355263e_bfbb3a4b59b04ee284596f1632862c6d : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _3e13a6165d840b64197c2aef3355263e_bfbb3a4b59b04ee284596f1632862c6d FromInterop(IntPtr data, int dataSize)
		{
			return default(_3e13a6165d840b64197c2aef3355263e_bfbb3a4b59b04ee284596f1632862c6d);
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

		public _3e13a6165d840b64197c2aef3355263e_bfbb3a4b59b04ee284596f1632862c6d(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3e13a6165d840b64197c2aef3355263e_bfbb3a4b59b04ee284596f1632862c6d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3e13a6165d840b64197c2aef3355263e_bfbb3a4b59b04ee284596f1632862c6d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3e13a6165d840b64197c2aef3355263e_bfbb3a4b59b04ee284596f1632862c6d);
		}
	}
}
