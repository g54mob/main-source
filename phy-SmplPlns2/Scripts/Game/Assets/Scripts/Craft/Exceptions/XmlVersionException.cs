using System;
using System.Runtime.Serialization;

namespace Assets.Scripts.Craft.Exceptions
{
	[Serializable]
	public class XmlVersionException : Exception
	{
		public XmlVersionException()
		{
		}

		public XmlVersionException(string message)
			: base(message)
		{
		}

		public XmlVersionException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected XmlVersionException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
