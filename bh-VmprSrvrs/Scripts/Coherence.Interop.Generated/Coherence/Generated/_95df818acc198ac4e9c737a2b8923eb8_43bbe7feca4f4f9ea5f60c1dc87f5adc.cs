using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _95df818acc198ac4e9c737a2b8923eb8_43bbe7feca4f4f9ea5f60c1dc87f5adc : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _95df818acc198ac4e9c737a2b8923eb8_43bbe7feca4f4f9ea5f60c1dc87f5adc FromInterop(IntPtr data, int dataSize)
		{
			return default(_95df818acc198ac4e9c737a2b8923eb8_43bbe7feca4f4f9ea5f60c1dc87f5adc);
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

		public static void Serialize(_95df818acc198ac4e9c737a2b8923eb8_43bbe7feca4f4f9ea5f60c1dc87f5adc commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _95df818acc198ac4e9c737a2b8923eb8_43bbe7feca4f4f9ea5f60c1dc87f5adc Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_95df818acc198ac4e9c737a2b8923eb8_43bbe7feca4f4f9ea5f60c1dc87f5adc);
		}
	}
}
