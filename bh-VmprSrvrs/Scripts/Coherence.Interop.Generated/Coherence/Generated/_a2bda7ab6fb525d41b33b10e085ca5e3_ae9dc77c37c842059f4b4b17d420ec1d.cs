using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a2bda7ab6fb525d41b33b10e085ca5e3_ae9dc77c37c842059f4b4b17d420ec1d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a2bda7ab6fb525d41b33b10e085ca5e3_ae9dc77c37c842059f4b4b17d420ec1d FromInterop(IntPtr data, int dataSize)
		{
			return default(_a2bda7ab6fb525d41b33b10e085ca5e3_ae9dc77c37c842059f4b4b17d420ec1d);
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

		public static void Serialize(_a2bda7ab6fb525d41b33b10e085ca5e3_ae9dc77c37c842059f4b4b17d420ec1d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a2bda7ab6fb525d41b33b10e085ca5e3_ae9dc77c37c842059f4b4b17d420ec1d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a2bda7ab6fb525d41b33b10e085ca5e3_ae9dc77c37c842059f4b4b17d420ec1d);
		}
	}
}
