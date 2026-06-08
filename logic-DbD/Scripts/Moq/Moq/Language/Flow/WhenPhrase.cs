using System;
using System.Linq.Expressions;

namespace Moq.Language.Flow
{
	internal sealed class WhenPhrase<T> : ISetupConditionResult<T> where T : class
	{
		private Mock<T> mock;

		private Condition condition;

		public WhenPhrase(Mock<T> mock, Condition condition)
		{
			this.mock = mock;
			this.condition = condition;
		}

		public ISetup<T> Setup(Expression<Action<T>> expression)
		{
			MethodCall setup = Mock.Setup(mock, expression, condition);
			return new VoidSetupPhrase<T>(setup);
		}

		public ISetup<T, TResult> Setup<TResult>(Expression<Func<T, TResult>> expression)
		{
			MethodCall setup = Mock.Setup(mock, expression, condition);
			return new NonVoidSetupPhrase<T, TResult>(setup);
		}

		public ISetupGetter<T, TProperty> SetupGet<TProperty>(Expression<Func<T, TProperty>> expression)
		{
			MethodCall setup = Mock.SetupGet(mock, expression, condition);
			return new NonVoidSetupPhrase<T, TProperty>(setup);
		}

		public ISetupSetter<T, TProperty> SetupSet<TProperty>(Action<T> setterExpression)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, mock.ConstructorArguments);
			MethodCall setup = Mock.SetupSet(mock, expression, condition);
			return new SetterSetupPhrase<T, TProperty>(setup);
		}

		public ISetup<T> SetupSet(Action<T> setterExpression)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, mock.ConstructorArguments);
			MethodCall setup = Mock.SetupSet(mock, expression, condition);
			return new VoidSetupPhrase<T>(setup);
		}
	}
}
