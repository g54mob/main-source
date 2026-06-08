using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Moq.Language;
using Moq.Language.Flow;

namespace Moq.Protected
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IProtectedAsMock<T, TAnalog> : IFluentInterface where T : class where TAnalog : class
	{
		ISetup<T> Setup(Expression<Action<TAnalog>> expression);

		ISetup<T, TResult> Setup<TResult>(Expression<Func<TAnalog, TResult>> expression);

		ISetupSetter<T, TProperty> SetupSet<TProperty>(Action<TAnalog> setterExpression);

		ISetup<T> SetupSet(Action<TAnalog> setterExpression);

		ISetupGetter<T, TProperty> SetupGet<TProperty>(Expression<Func<TAnalog, TProperty>> expression);

		Mock<T> SetupProperty<TProperty>(Expression<Func<TAnalog, TProperty>> expression, TProperty initialValue = default(TProperty));

		ISetupSequentialResult<TResult> SetupSequence<TResult>(Expression<Func<TAnalog, TResult>> expression);

		ISetupSequentialAction SetupSequence(Expression<Action<TAnalog>> expression);

		void Verify(Expression<Action<TAnalog>> expression, Times? times = null, string failMessage = null);

		void Verify<TResult>(Expression<Func<TAnalog, TResult>> expression, Times? times = null, string failMessage = null);

		void VerifySet(Action<TAnalog> setterExpression, Times? times = null, string failMessage = null);

		void VerifyGet<TProperty>(Expression<Func<TAnalog, TProperty>> expression, Times? times = null, string failMessage = null);
	}
}
