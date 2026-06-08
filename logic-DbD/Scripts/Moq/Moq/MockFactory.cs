using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Moq.Expressions.Visitors;
using Moq.Properties;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This class has been renamed to MockRepository. MockFactory will be retired in v5.", false)]
	public class MockFactory
	{
		private List<Mock> mocks = new List<Mock>();

		private MockBehavior defaultBehavior;

		private DefaultValueProvider defaultValueProvider;

		private Switches switches;

		internal MockBehavior Behavior => defaultBehavior;

		public bool CallBase { get; set; }

		public DefaultValue DefaultValue
		{
			get
			{
				return DefaultValueProvider.Kind;
			}
			set
			{
				DefaultValueProvider = value switch
				{
					DefaultValue.Empty => Moq.DefaultValueProvider.Empty, 
					DefaultValue.Mock => Moq.DefaultValueProvider.Mock, 
					_ => throw new ArgumentOutOfRangeException("value"), 
				};
			}
		}

		public DefaultValueProvider DefaultValueProvider
		{
			get
			{
				return defaultValueProvider;
			}
			set
			{
				defaultValueProvider = value ?? throw new ArgumentNullException("value");
			}
		}

		protected internal IEnumerable<Mock> Mocks => mocks;

		public Switches Switches
		{
			get
			{
				return switches;
			}
			set
			{
				switches = value;
			}
		}

		public MockFactory(MockBehavior defaultBehavior)
		{
			this.defaultBehavior = defaultBehavior;
			defaultValueProvider = Moq.DefaultValueProvider.Empty;
			switches = Switches.Default;
		}

		public Mock<T> Create<T>() where T : class
		{
			return CreateMock<T>(defaultBehavior, new object[0]);
		}

		public Mock<T> Create<T>(params object[] args) where T : class
		{
			if (args == null || args.Length == 0 || !(args[0] is MockBehavior behavior))
			{
				return CreateMock<T>(defaultBehavior, args);
			}
			return CreateMock<T>(behavior, args.Skip(1).ToArray());
		}

		public Mock<T> Create<T>(MockBehavior behavior) where T : class
		{
			return CreateMock<T>(behavior, new object[0]);
		}

		public Mock<T> Create<T>(MockBehavior behavior, params object[] args) where T : class
		{
			return CreateMock<T>(behavior, args);
		}

		public Mock<T> Create<T>(Expression<Func<T>> newExpression, MockBehavior behavior = MockBehavior.Loose) where T : class
		{
			return Create<T>(behavior, ConstructorCallVisitor.ExtractArgumentValues(newExpression));
		}

		protected virtual Mock<T> CreateMock<T>(MockBehavior behavior, object[] args) where T : class
		{
			Mock<T> mock = new Mock<T>(behavior, args);
			mocks.Add(mock);
			mock.CallBase = CallBase;
			mock.DefaultValueProvider = DefaultValueProvider;
			mock.Switches = switches;
			return mock;
		}

		public virtual void Verify()
		{
			VerifyMocks(delegate(Mock verifiable)
			{
				verifiable.Verify();
			});
		}

		public virtual void VerifyAll()
		{
			VerifyMocks(delegate(Mock verifiable)
			{
				verifiable.VerifyAll();
			});
		}

		public void VerifyNoOtherCalls()
		{
			VerifyMocks(delegate(Mock mock)
			{
				Mock.VerifyNoOtherCalls(mock);
			});
		}

		protected virtual void VerifyMocks(Action<Mock> verifyAction)
		{
			Guard.NotNull(verifyAction, "verifyAction");
			List<MockException> list = new List<MockException>();
			foreach (Mock mock in mocks)
			{
				try
				{
					verifyAction(mock);
				}
				catch (MockException ex) when (ex.IsVerificationError)
				{
					list.Add(ex);
				}
			}
			if (list.Count > 0)
			{
				throw MockException.Combined(list, Resources.VerificationErrorsOfMockRepository);
			}
		}
	}
}
