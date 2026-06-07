using System;
using System.Runtime.Serialization;

namespace Assets.Scripts.Craft.Exceptions
{
	[Serializable]
	public class InvalidPartTypeException : Exception
	{
		public string PartId { get; set; }

		public InvalidPartTypeException()
		{
		}

		public InvalidPartTypeException(string message, string partId)
			: base(message)
		{
			PartId = partId;
		}

		public InvalidPartTypeException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected InvalidPartTypeException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
