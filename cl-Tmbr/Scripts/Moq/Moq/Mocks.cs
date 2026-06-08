using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Linq;

namespace Moq
{
	public static class Mocks
	{
		public static IQueryable<T> Of<T>() where T : class
		{
			return Of<T>(MockBehavior.Loose);
		}

		public static IQueryable<T> Of<T>(MockBehavior behavior) where T : class
		{
			return CreateMockQuery<T>(behavior);
		}

		public static IQueryable<T> Of<T>(Expression<Func<T, bool>> specification) where T : class
		{
			return Of(specification, MockBehavior.Loose);
		}

		public static IQueryable<T> Of<T>(Expression<Func<T, bool>> specification, MockBehavior behavior) where T : class
		{
			return CreateMockQuery<T>(behavior).Where(specification);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Moved to Mock.Of<T>, as it's a single one, so no reason to be on Mocks.", true)]
		public static T OneOf<T>() where T : class
		{
			throw new NotSupportedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Moved to Mock.Of<T>, as it's a single one, so no reason to be on Mocks.", true)]
		public static T OneOf<T>(Expression<Func<T, bool>> specification) where T : class
		{
			throw new NotSupportedException();
		}

		internal static IQueryable<T> CreateMockQuery<T>(MockBehavior behavior) where T : class
		{
			MethodInfo methodInfo = new Func<MockBehavior, IQueryable<T>>(CreateQueryable<T>).GetMethodInfo();
			return new MockQueryable<T>(Expression.Call(methodInfo, Expression.Constant(behavior)));
		}

		internal static IQueryable<T> CreateQueryable<T>(MockBehavior behavior) where T : class
		{
			return CreateMocks<T>(behavior).AsQueryable();
		}

		private static IEnumerable<T> CreateMocks<T>(MockBehavior behavior) where T : class
		{
			while (true)
			{
				Mock<T> mock = new Mock<T>(behavior);
				if (behavior != MockBehavior.Strict)
				{
					mock.SetupAllProperties();
				}
				yield return mock.Object;
			}
		}
	}
}
