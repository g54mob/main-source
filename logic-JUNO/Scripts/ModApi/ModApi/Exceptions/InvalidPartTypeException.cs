using System;
using System.Runtime.Serialization;

namespace ModApi.Exceptions
{
	[Serializable]
	public class InvalidPartTypeException : GameException
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

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("PartId", PartId);
		}
	}
}
