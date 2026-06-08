using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Moq.Language.Flow;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ObsoleteMockExtensions
	{
		[Obsolete("Replaced by SetupSet(Action)")]
		public static ISetupSetter<T, TProperty> SetupSet<T, TProperty>(this Mock<T> mock, Expression<Func<T, TProperty>> expression) where T : class
		{
			Guard.NotNull(expression, "expression");
			MethodCall setup = Mock.SetupSet(mock, expression.AssignItIsAny(), null);
			return new SetterSetupPhrase<T, TProperty>(setup);
		}

		[Obsolete("Replaced by VerifySet(Action)")]
		public static void VerifySet<T, TProperty>(this Mock<T> mock, Expression<Func<T, TProperty>> expression) where T : class
		{
			Guard.NotNull(expression, "expression");
			Mock.VerifySet(mock, expression.AssignItIsAny(), Times.AtLeastOnce(), null);
		}

		[Obsolete("Replaced by  VerifySet(Action, string)")]
		public static void VerifySet<T, TProperty>(this Mock<T> mock, Expression<Func<T, TProperty>> expression, string failMessage) where T : class
		{
			Mock.VerifySet(mock, expression, Times.AtLeastOnce(), failMessage);
		}

		[Obsolete("Replaced by  VerifySet(Action, Times)")]
		public static void VerifySet<T, TProperty>(this Mock<T> mock, Expression<Func<T, TProperty>> expression, Times times) where T : class
		{
			Mock.VerifySet(mock, expression, times, null);
		}

		[Obsolete("Replaced by  VerifySet(Action, Times, string)")]
		public static void VerifySet<T, TProperty>(this Mock<T> mock, Expression<Func<T, TProperty>> expression, Times times, string failMessage) where T : class
		{
			Mock.VerifySet(mock, expression, times, failMessage);
		}
	}
}
