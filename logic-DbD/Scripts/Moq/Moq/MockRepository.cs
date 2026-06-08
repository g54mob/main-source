using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Linq;

namespace Moq
{
	public class MockRepository : MockFactory
	{
		public IQueryable<T> Of<T>() where T : class
		{
			return Of<T>(base.Behavior);
		}

		public IQueryable<T> Of<T>(MockBehavior behavior) where T : class
		{
			return CreateMockQuery<T>(behavior);
		}

		public IQueryable<T> Of<T>(Expression<Func<T, bool>> specification) where T : class
		{
			return Of(specification, base.Behavior);
		}

		public IQueryable<T> Of<T>(Expression<Func<T, bool>> specification, MockBehavior behavior) where T : class
		{
			return CreateMockQuery<T>(behavior).Where(specification);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public T OneOf<T>() where T : class
		{
			return OneOf<T>(base.Behavior);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public T OneOf<T>(MockBehavior behavior) where T : class
		{
			return CreateMockQuery<T>(behavior).First();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public T OneOf<T>(Expression<Func<T, bool>> specification) where T : class
		{
			return OneOf(specification, base.Behavior);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public T OneOf<T>(Expression<Func<T, bool>> specification, MockBehavior behavior) where T : class
		{
			return CreateMockQuery<T>(behavior).First(specification);
		}

		internal IQueryable<T> CreateMockQuery<T>(MockBehavior behavior) where T : class
		{
			MethodInfo methodInfo = new Func<MockBehavior, IQueryable<T>>(CreateQueryable<T>).GetMethodInfo();
			return new MockQueryable<T>(Expression.Call(Expression.Constant(this), methodInfo, Expression.Constant(behavior)));
		}

		internal IQueryable<T> CreateQueryable<T>(MockBehavior behavior) where T : class
		{
			return CreateMocks<T>(behavior).AsQueryable();
		}

		private IEnumerable<T> CreateMocks<T>(MockBehavior behavior) where T : class
		{
			while (true)
			{
				Mock<T> mock = Create<T>(behavior);
				if (behavior != MockBehavior.Strict)
				{
					mock.SetupAllProperties();
				}
				yield return mock.Object;
			}
		}

		public MockRepository(MockBehavior defaultBehavior)
			: base(defaultBehavior)
		{
		}
	}
}
