using System;
using Coherence.Entities;

namespace Coherence.Core
{
	public class SerializerException : Exception
	{
		private string messageOverride;

		public string Section { get; private set; }

		public Entity EntityId { get; private set; }

		public uint ComponentId { get; private set; }

		public override string Message => null;

		public SerializerException(string section, Entity entityId, uint componentId, Exception inner)
		{
		}

		public string ToStringEx(string entityName)
		{
			return null;
		}

		private string BuildMessage(string entityName)
		{
			return null;
		}
	}
}
