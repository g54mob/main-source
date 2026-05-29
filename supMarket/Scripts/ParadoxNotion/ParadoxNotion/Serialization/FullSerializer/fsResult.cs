using System;
using System.Collections.Generic;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public struct fsResult
	{
		private static readonly string[] EmptyStringArray;

		private bool _success;

		private List<string> _messages;

		public static fsResult Success;

		public bool Failed => false;

		public bool Succeeded => false;

		public bool HasWarnings => false;

		public Exception AsException => null;

		public IEnumerable<string> RawMessages => null;

		public string FormattedMessages => null;

		public static fsResult Warn(string warning)
		{
			return default(fsResult);
		}

		public static fsResult Fail(string warning)
		{
			return default(fsResult);
		}

		public void AddMessage(string message)
		{
		}

		public void AddMessages(fsResult result)
		{
		}

		private fsResult Merge(fsResult other)
		{
			return default(fsResult);
		}

		public static fsResult operator +(fsResult a, fsResult b)
		{
			return default(fsResult);
		}

		public fsResult AssertSuccess()
		{
			return default(fsResult);
		}

		public fsResult AssertSuccessWithoutWarnings()
		{
			return default(fsResult);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
