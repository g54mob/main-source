using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Moq.Language.Flow;

namespace Moq.Language
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ISetupConditionResult<T> where T : class
	{
		ISetup<T> Setup(Expression<Action<T>> expression);

		ISetup<T, TResult> Setup<TResult>(Expression<Func<T, TResult>> expression);

		ISetupGetter<T, TProperty> SetupGet<TProperty>(Expression<Func<T, TProperty>> expression);

		ISetupSetter<T, TProperty> SetupSet<TProperty>(Action<T> setterExpression);

		ISetup<T> SetupSet(Action<T> setterExpression);
	}
}
