using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _cb6340e86c15b7a4d9dc09805e38365e_25205b1088bc488aadb956285e37e7a6 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _cb6340e86c15b7a4d9dc09805e38365e_25205b1088bc488aadb956285e37e7a6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_cb6340e86c15b7a4d9dc09805e38365e_25205b1088bc488aadb956285e37e7a6);
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

		public _cb6340e86c15b7a4d9dc09805e38365e_25205b1088bc488aadb956285e37e7a6(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_cb6340e86c15b7a4d9dc09805e38365e_25205b1088bc488aadb956285e37e7a6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _cb6340e86c15b7a4d9dc09805e38365e_25205b1088bc488aadb956285e37e7a6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_cb6340e86c15b7a4d9dc09805e38365e_25205b1088bc488aadb956285e37e7a6);
		}
	}
}
