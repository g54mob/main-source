using System;

namespace Coherence.Toolkit
{
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class CommandAttribute : Attribute
	{
		public MessageTarget defaultRouting;

		public string OldName { get; }

		public Type[] OldParams { get; }

		public CommandAttribute()
		{
		}

		public CommandAttribute(string oldName = null, params Type[] oldParams)
		{
		}
	}
}
