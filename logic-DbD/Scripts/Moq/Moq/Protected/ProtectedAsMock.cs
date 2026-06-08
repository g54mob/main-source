using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Language;
using Moq.Language.Flow;
using Moq.Properties;

namespace Moq.Protected
{
	internal sealed class ProtectedAsMock<T, TAnalog> : IProtectedAsMock<T, TAnalog>, IFluentInterface where T : class where TAnalog : class
	{
		private sealed class DuckReplacer : ExpressionVisitor
		{
			private Type duckType;

			private Type targetType;

			public DuckReplacer(Type duckType, Type targetType)
			{
				this.duckType = duckType;
				this.targetType = targetType;
			}

			protected override Expression VisitMethodCall(MethodCallExpression node)
			{
				if (node.Object is ParameterExpression parameterExpression && parameterExpression.Type == duckType)
				{
					ParameterExpression instance = Expression.Parameter(targetType, parameterExpression.Name);
					return Expression.Call(instance, FindCorrespondingMethod(node.Method), node.Arguments);
				}
				return base.VisitMethodCall(node);
			}

			protected override Expression VisitIndex(IndexExpression node)
			{
				if (node.Object is ParameterExpression parameterExpression && parameterExpression.Type == duckType)
				{
					ParameterExpression instance = Expression.Parameter(targetType, parameterExpression.Name);
					return Expression.MakeIndex(instance, FindCorrespondingProperty(node.Indexer), node.Arguments);
				}
				return base.VisitIndex(node);
			}

			protected override Expression VisitMember(MemberExpression node)
			{
				if (node.Expression is ParameterExpression parameterExpression && parameterExpression.Type == duckType)
				{
					ParameterExpression expression = Expression.Parameter(targetType, parameterExpression.Name);
					return Expression.MakeMemberAccess(expression, FindCorrespondingMember(node.Member));
				}
				return base.VisitMember(node);
			}

			private MemberInfo FindCorrespondingMember(MemberInfo duckMember)
			{
				if (duckMember is MethodInfo duckMethod)
				{
					return FindCorrespondingMethod(duckMethod);
				}
				if (duckMember is PropertyInfo duckProperty)
				{
					return FindCorrespondingProperty(duckProperty);
				}
				throw new NotSupportedException();
			}

			private MethodInfo FindCorrespondingMethod(MethodInfo duckMethod)
			{
				MethodInfo[] array = (from ctm in targetType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
					where IsCorrespondingMethod(duckMethod, ctm)
					select ctm).ToArray();
				if (array.Length == 0)
				{
					throw new ArgumentException(string.Format(Resources.ProtectedMemberNotFound, targetType, duckMethod));
				}
				MethodInfo methodInfo = array[0];
				if (methodInfo.IsGenericMethodDefinition)
				{
					Type[] genericArguments = duckMethod.GetGenericArguments();
					methodInfo = methodInfo.MakeGenericMethod(genericArguments);
				}
				return methodInfo;
			}

			private PropertyInfo FindCorrespondingProperty(PropertyInfo duckProperty)
			{
				PropertyInfo[] array = (from ctp in targetType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
					where IsCorrespondingProperty(duckProperty, ctp)
					select ctp).ToArray();
				if (array.Length == 0)
				{
					throw new ArgumentException(string.Format(Resources.ProtectedMemberNotFound, targetType, duckProperty));
				}
				return array[0];
			}

			private static bool IsCorrespondingMethod(MethodInfo duckMethod, MethodInfo candidateTargetMethod)
			{
				if (candidateTargetMethod.Name != duckMethod.Name)
				{
					return false;
				}
				if (candidateTargetMethod.IsGenericMethod != duckMethod.IsGenericMethod)
				{
					return false;
				}
				if (candidateTargetMethod.IsGenericMethodDefinition)
				{
					Type[] genericArguments = candidateTargetMethod.GetGenericArguments();
					Type[] genericArguments2 = duckMethod.GetGenericArguments();
					if (genericArguments.Length != genericArguments2.Length)
					{
						return false;
					}
					try
					{
						candidateTargetMethod = candidateTargetMethod.MakeGenericMethod(genericArguments2);
					}
					catch
					{
						return false;
					}
				}
				ParameterInfo[] parameters = duckMethod.GetParameters();
				ParameterInfo[] parameters2 = candidateTargetMethod.GetParameters();
				if (parameters2.Length != parameters.Length)
				{
					return false;
				}
				int i = 0;
				for (int num = parameters2.Length; i < num; i++)
				{
					if (parameters2[i].ParameterType != parameters[i].ParameterType)
					{
						return false;
					}
				}
				return true;
			}

			private static bool IsCorrespondingProperty(PropertyInfo duckProperty, PropertyInfo candidateTargetProperty)
			{
				if (candidateTargetProperty.Name == duckProperty.Name && candidateTargetProperty.PropertyType == duckProperty.PropertyType && candidateTargetProperty.CanRead(out MethodInfo getter) == duckProperty.CanRead(out getter))
				{
					return candidateTargetProperty.CanWrite(out getter) == duckProperty.CanWrite(out getter);
				}
				return false;
			}
		}

		private Mock<T> mock;

		private static DuckReplacer DuckReplacerInstance = new DuckReplacer(typeof(TAnalog), typeof(T));

		public ProtectedAsMock(Mock<T> mock)
		{
			this.mock = mock;
		}

		public ISetup<T> Setup(Expression<Action<TAnalog>> expression)
		{
			Guard.NotNull(expression, "expression");
			Expression<Action<T>> expression2;
			try
			{
				expression2 = (Expression<Action<T>>)ReplaceDuck(expression);
			}
			catch (ArgumentException ex)
			{
				throw new ArgumentException(ex.Message, "expression");
			}
			MethodCall setup = Mock.Setup(mock, expression2, null);
			return new VoidSetupPhrase<T>(setup);
		}

		public ISetup<T, TResult> Setup<TResult>(Expression<Func<TAnalog, TResult>> expression)
		{
			Guard.NotNull(expression, "expression");
			Expression<Func<T, TResult>> expression2;
			try
			{
				expression2 = (Expression<Func<T, TResult>>)ReplaceDuck(expression);
			}
			catch (ArgumentException ex)
			{
				throw new ArgumentException(ex.Message, "expression");
			}
			MethodCall setup = Mock.Setup(mock, expression2, null);
			return new NonVoidSetupPhrase<T, TResult>(setup);
		}

		public ISetupSetter<T, TProperty> SetupSet<TProperty>(Action<TAnalog> setterExpression)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			LambdaExpression expression = ReconstructAndReplaceSetter(setterExpression);
			MethodCall setup = Mock.SetupSet(mock, expression, null);
			return new SetterSetupPhrase<T, TProperty>(setup);
		}

		public ISetup<T> SetupSet(Action<TAnalog> setterExpression)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			LambdaExpression expression = ReconstructAndReplaceSetter(setterExpression);
			MethodCall setup = Mock.SetupSet(mock, expression, null);
			return new VoidSetupPhrase<T>(setup);
		}

		public ISetupGetter<T, TProperty> SetupGet<TProperty>(Expression<Func<TAnalog, TProperty>> expression)
		{
			Guard.NotNull(expression, "expression");
			Expression<Func<T, TProperty>> expression2;
			try
			{
				expression2 = (Expression<Func<T, TProperty>>)ReplaceDuck(expression);
			}
			catch (ArgumentException ex)
			{
				throw new ArgumentException(ex.Message, "expression");
			}
			MethodCall setup = Mock.SetupGet(mock, expression2, null);
			return new NonVoidSetupPhrase<T, TProperty>(setup);
		}

		public Mock<T> SetupProperty<TProperty>(Expression<Func<TAnalog, TProperty>> expression, TProperty initialValue = default(TProperty))
		{
			Guard.NotNull(expression, "expression");
			Expression<Func<T, TProperty>> property;
			try
			{
				property = (Expression<Func<T, TProperty>>)ReplaceDuck(expression);
			}
			catch (ArgumentException ex)
			{
				throw new ArgumentException(ex.Message, "expression");
			}
			return mock.SetupProperty(property, initialValue);
		}

		public ISetupSequentialResult<TResult> SetupSequence<TResult>(Expression<Func<TAnalog, TResult>> expression)
		{
			Guard.NotNull(expression, "expression");
			Expression<Func<T, TResult>> expression2;
			try
			{
				expression2 = (Expression<Func<T, TResult>>)ReplaceDuck(expression);
			}
			catch (ArgumentException ex)
			{
				throw new ArgumentException(ex.Message, "expression");
			}
			SequenceSetup setup = Mock.SetupSequence(mock, expression2);
			return new SetupSequencePhrase<TResult>(setup);
		}

		public ISetupSequentialAction SetupSequence(Expression<Action<TAnalog>> expression)
		{
			Guard.NotNull(expression, "expression");
			Expression<Action<T>> expression2;
			try
			{
				expression2 = (Expression<Action<T>>)ReplaceDuck(expression);
			}
			catch (ArgumentException ex)
			{
				throw new ArgumentException(ex.Message, "expression");
			}
			SequenceSetup setup = Mock.SetupSequence(mock, expression2);
			return new SetupSequencePhrase(setup);
		}

		public void Verify(Expression<Action<TAnalog>> expression, Times? times = null, string failMessage = null)
		{
			Guard.NotNull(expression, "expression");
			Expression<Action<T>> expression2;
			try
			{
				expression2 = (Expression<Action<T>>)ReplaceDuck(expression);
			}
			catch (ArgumentException ex)
			{
				throw new ArgumentException(ex.Message, "expression");
			}
			Mock.Verify(mock, expression2, times ?? Times.AtLeastOnce(), failMessage);
		}

		public void Verify<TResult>(Expression<Func<TAnalog, TResult>> expression, Times? times = null, string failMessage = null)
		{
			Guard.NotNull(expression, "expression");
			Expression<Func<T, TResult>> expression2;
			try
			{
				expression2 = (Expression<Func<T, TResult>>)ReplaceDuck(expression);
			}
			catch (ArgumentException ex)
			{
				throw new ArgumentException(ex.Message, "expression");
			}
			Mock.Verify(mock, expression2, times ?? Times.AtLeastOnce(), failMessage);
		}

		public void VerifySet(Action<TAnalog> setterExpression, Times? times = null, string failMessage = null)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			LambdaExpression expression = ReconstructAndReplaceSetter(setterExpression);
			Mock.VerifySet(mock, expression, times.HasValue ? times.Value : Times.AtLeastOnce(), failMessage);
		}

		public void VerifyGet<TProperty>(Expression<Func<TAnalog, TProperty>> expression, Times? times = null, string failMessage = null)
		{
			Guard.NotNull(expression, "expression");
			Expression<Func<T, TProperty>> expression2;
			try
			{
				expression2 = (Expression<Func<T, TProperty>>)ReplaceDuck(expression);
			}
			catch (ArgumentException ex)
			{
				throw new ArgumentException(ex.Message, "expression");
			}
			Mock.VerifyGet(mock, expression2, times ?? Times.AtLeastOnce(), failMessage);
		}

		private LambdaExpression ReconstructAndReplaceSetter(Action<TAnalog> setterExpression)
		{
			Expression<Action<TAnalog>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, mock.ConstructorArguments);
			return ReplaceDuck(expression);
		}

		private static LambdaExpression ReplaceDuck(LambdaExpression expression)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T), expression.Parameters[0].Name);
			return Expression.Lambda(DuckReplacerInstance.Visit(expression.Body), parameterExpression);
		}

		Type IFluentInterface.GetType()
		{
			return GetType();
		}
	}
}
