using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using Moq.Async;
using Moq.Properties;

namespace Moq
{
	[Serializable]
	public class MockException : Exception
	{
		private readonly MockExceptionReasons reasons;

		internal MockExceptionReasons Reasons => reasons;

		public bool IsVerificationError => (reasons & (MockExceptionReasons.NoMatchingCalls | MockExceptionReasons.UnmatchedSetup | MockExceptionReasons.UnverifiedInvocations)) != 0;

		internal static MockException IncorrectNumberOfCalls(MethodCall setup, Times times, int invocationCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(setup.FailMessage ?? "").Append(times.GetExceptionMessage(invocationCount)).AppendLine(setup.Expression.ToStringFixed());
			return new MockException(MockExceptionReasons.IncorrectNumberOfCalls, stringBuilder.ToString());
		}

		internal static MockException NoMatchingCalls(Mock rootMock, LambdaExpression expression, string failMessage, Times times, int callCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(failMessage ?? "").Append(times.GetExceptionMessage(callCount)).AppendLine(expression.PartialMatcherAwareEval().ToStringFixed())
				.AppendLine()
				.AppendLine(Resources.PerformedInvocations)
				.AppendLine();
			HashSet<Mock> hashSet = new HashSet<Mock>();
			Queue<Mock> queue = new Queue<Mock>();
			queue.Enqueue(rootMock);
			while (queue.Any())
			{
				Mock mock = queue.Dequeue();
				if (hashSet.Contains(mock))
				{
					continue;
				}
				hashSet.Add(mock);
				stringBuilder.AppendLine((mock == rootMock) ? $"   {mock} ({expression.Parameters[0].Name}):" : $"   {mock}:");
				Invocation[] array = mock.MutableInvocations.ToArray();
				if (array.Any())
				{
					stringBuilder.AppendLine();
					Invocation[] array2 = array;
					foreach (Invocation invocation in array2)
					{
						stringBuilder.Append($"      {invocation}");
						if (invocation.Method.ReturnType != typeof(void) && Awaitable.TryGetResultRecursive(invocation.ReturnValue) is IMocked mocked)
						{
							Mock mock2 = mocked.Mock;
							queue.Enqueue(mock2);
							stringBuilder.Append($"  => {mock2}");
						}
						stringBuilder.AppendLine();
					}
				}
				else
				{
					stringBuilder.AppendLine("   " + Resources.NoInvocationsPerformed);
				}
				stringBuilder.AppendLine();
			}
			return new MockException(MockExceptionReasons.NoMatchingCalls, stringBuilder.TrimEnd().AppendLine().ToString());
		}

		internal static MockException NoSetup(Invocation invocation)
		{
			return new MockException(MockExceptionReasons.NoSetup, string.Format(CultureInfo.CurrentCulture, Resources.MockExceptionMessage, invocation.ToString(), MockBehavior.Strict, Resources.NoSetup));
		}

		internal static MockException ReturnValueRequired(Invocation invocation)
		{
			return new MockException(MockExceptionReasons.ReturnValueRequired, string.Format(CultureInfo.CurrentCulture, Resources.MockExceptionMessage, invocation.ToString(), MockBehavior.Strict, Resources.ReturnValueRequired));
		}

		internal static MockException UnmatchedSetup(Setup setup)
		{
			return new MockException(MockExceptionReasons.UnmatchedSetup, string.Format(CultureInfo.CurrentCulture, Resources.UnmatchedSetup, setup));
		}

		internal static MockException FromInnerMockOf(ISetup setup, MockException error)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(string.Format(CultureInfo.CurrentCulture, Resources.VerificationErrorsOfInnerMock, setup)).TrimEnd().AppendLine()
				.AppendLine();
			stringBuilder.AppendIndented(error.Message, 3);
			return new MockException(error.Reasons, stringBuilder.ToString());
		}

		internal static MockException Combined(IEnumerable<MockException> errors, string preamble)
		{
			MockExceptionReasons mockExceptionReasons = (MockExceptionReasons)0;
			StringBuilder stringBuilder = new StringBuilder();
			if (preamble != null)
			{
				stringBuilder.Append(preamble).TrimEnd().AppendLine()
					.AppendLine();
			}
			foreach (MockException error in errors)
			{
				mockExceptionReasons |= error.Reasons;
				stringBuilder.AppendIndented(error.Message, 3).TrimEnd().AppendLine()
					.AppendLine();
			}
			return new MockException(mockExceptionReasons, stringBuilder.TrimEnd().ToString());
		}

		internal static MockException UnverifiedInvocations(Mock mock, IEnumerable<Invocation> invocations)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(string.Format(CultureInfo.CurrentCulture, Resources.UnverifiedInvocations, mock)).TrimEnd().AppendLine()
				.AppendLine();
			foreach (Invocation invocation in invocations)
			{
				stringBuilder.AppendIndented(invocation.ToString(), 3).TrimEnd().AppendLine();
			}
			return new MockException(MockExceptionReasons.UnverifiedInvocations, stringBuilder.TrimEnd().ToString());
		}

		private MockException(MockExceptionReasons reasons, string message)
			: base(message)
		{
			this.reasons = reasons;
		}

		protected MockException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			reasons = (MockExceptionReasons)info.GetValue("reasons", typeof(MockExceptionReasons));
		}

		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("reasons", reasons);
		}
	}
}
