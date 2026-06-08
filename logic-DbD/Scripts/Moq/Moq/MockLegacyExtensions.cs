using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Moq.Language.Flow;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class MockLegacyExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("The new syntax allows you to pass the value in the expression itself, like f => f.Value = 25.", true)]
		public static ISetupSetter<T, TProperty> SetupSet<T, TProperty>(this Mock<T> mock, Expression<Func<T, TProperty>> expression, TProperty value) where T : class
		{
			throw new NotSupportedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use the new syntax, which allows you to pass the value in the expression itself, mock.VerifySet(m => m.Value = 25);", true)]
		public static void VerifySet<T, TProperty>(this Mock<T> mock, Expression<Func<T, TProperty>> expression, TProperty value) where T : class
		{
			throw new NotSupportedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use the new syntax, which allows you to pass the value in the expression itself, mock.VerifySet(m => m.Value = 25, failMessage);", true)]
		public static void VerifySet<T, TProperty>(this Mock<T> mock, Expression<Func<T, TProperty>> expression, TProperty value, string failMessage) where T : class
		{
			throw new NotSupportedException();
		}
	}
}
