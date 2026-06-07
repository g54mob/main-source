using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4c5721e499679dc499cc55be525ab38a_963dc7109b3041b0886b36771cec20e7 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4c5721e499679dc499cc55be525ab38a_963dc7109b3041b0886b36771cec20e7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4c5721e499679dc499cc55be525ab38a_963dc7109b3041b0886b36771cec20e7);
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

		public static void Serialize(_4c5721e499679dc499cc55be525ab38a_963dc7109b3041b0886b36771cec20e7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4c5721e499679dc499cc55be525ab38a_963dc7109b3041b0886b36771cec20e7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4c5721e499679dc499cc55be525ab38a_963dc7109b3041b0886b36771cec20e7);
		}
	}
}
