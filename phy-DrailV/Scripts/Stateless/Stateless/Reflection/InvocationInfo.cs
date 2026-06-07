using System;

namespace Stateless.Reflection
{
	public readonly struct InvocationInfo
	{
		public enum Timing
		{
			Synchronous = 0,
			Asynchronous = 1
		}

		private readonly string _description;

		private readonly Timing _timing;

		public readonly string MethodName;

		public const string DefaultFunctionDescription = "Function";

		private static readonly char[] InvalidMethodNameChars = new char[3] { '<', '>', '`' };

		public string Description
		{
			get
			{
				if (_description != null)
				{
					return _description;
				}
				if (MethodName == null)
				{
					return "<null>";
				}
				if (MethodName.IndexOfAny(InvalidMethodNameChars) >= 0)
				{
					return "Function";
				}
				return MethodName;
			}
		}

		public bool IsAsync => _timing == Timing.Asynchronous;

		internal static InvocationInfo Create(Delegate method, string description, Timing timing = Timing.Synchronous)
		{
			return new InvocationInfo(method?.Method?.Name, description, timing);
		}

		public InvocationInfo(string methodName, string description, Timing timing)
		{
			MethodName = methodName;
			_description = description;
			_timing = timing;
		}
	}
}
