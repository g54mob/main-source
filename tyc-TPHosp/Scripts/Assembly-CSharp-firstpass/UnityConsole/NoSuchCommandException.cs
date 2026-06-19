using System;
using System.Runtime.Serialization;

namespace UnityConsole
{
	[Serializable]
	public class NoSuchCommandException : Exception
	{
		public string Command { get; private set; }

		public NoSuchCommandException()
		{
		}

		public NoSuchCommandException(string message)
			: base(message)
		{
		}

		public NoSuchCommandException(string message, string command)
			: base(message)
		{
			Command = command;
		}

		protected NoSuchCommandException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			if (info != null)
			{
				Command = info.GetString("command");
			}
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info?.AddValue("command", Command);
		}
	}
}
