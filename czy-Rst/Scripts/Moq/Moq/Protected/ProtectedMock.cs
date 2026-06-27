using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Language;
using Moq.Language.Flow;
using Moq.Properties;
using TypeNameFormatter;

namespace Moq.Protected
{
	internal class ProtectedMock<T> : IProtectedMock<T>, IFluentInterface where T : class
	{
		private Mock<T> mock;

		public ProtectedMock(Mock<T> mock)
		{
			this.mock = mock;
		}

		public IProtectedAsMock<T, TAnalog> As<TAnalog>() where TAnalog : class
		{
			return new ProtectedAsMock<T, TAnalog>(mock);
		}

		public ISetup<T> Setup(string methodName, params object[] args)
		{
			return InternalSetup(methodName, null, exactParameterMatch: false, args);
		}

		public ISetup<T> Setup(string methodName, bool exactParameterMatch, params object[] args)
		{
			return InternalSetup(methodName, null, exactParameterMatch, args);
		}

		public ISetup<T> Setup(string methodName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNull(genericTypeArguments, "genericTypeArguments");
			return InternalSetup(methodName, genericTypeArguments, exactParameterMatch, args);
		}

		private ISetup<T> InternalSetup(string methodName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNull(methodName, "methodName");
			MethodInfo method = GetMethod(methodName, genericTypeArguments, exactParameterMatch, args);
			ThrowIfMethodMissing(methodName, method, args);
			ThrowIfPublicMethod(method, typeof(T).Name);
			MethodCall setup = Mock.Setup(mock, GetMethodCall(method, args), null);
			return new VoidSetupPhrase<T>(setup);
		}

		public ISetup<T, TResult> Setup<TResult>(string methodName, params object[] args)
		{
			return InternalSetup<TResult>(methodName, null, exactParameterMatch: false, args);
		}

		public ISetup<T, TResult> Setup<TResult>(string methodName, bool exactParameterMatch, params object[] args)
		{
			return InternalSetup<TResult>(methodName, null, exactParameterMatch, args);
		}

		public ISetup<T, TResult> Setup<TResult>(string methodName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNull(genericTypeArguments, "genericTypeArguments");
			return InternalSetup<TResult>(methodName, genericTypeArguments, exactParameterMatch, args);
		}

		private ISetup<T, TResult> InternalSetup<TResult>(string methodName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNullOrEmpty(methodName, "methodName");
			PropertyInfo property = GetProperty(methodName);
			if (property != null)
			{
				ThrowIfPublicGetter(property, typeof(T).Name);
				MethodCall setup = Mock.SetupGet(mock, GetMemberAccess<TResult>(property), null);
				return new NonVoidSetupPhrase<T, TResult>(setup);
			}
			MethodInfo method = GetMethod(methodName, genericTypeArguments, exactParameterMatch, args);
			ThrowIfMethodMissing(methodName, method, args);
			ThrowIfVoidMethod(method);
			ThrowIfPublicMethod(method, typeof(T).Name);
			MethodCall setup2 = Mock.Setup(mock, GetMethodCall<TResult>(method, args), null);
			return new NonVoidSetupPhrase<T, TResult>(setup2);
		}

		public ISetupGetter<T, TProperty> SetupGet<TProperty>(string propertyName)
		{
			Guard.NotNullOrEmpty(propertyName, "propertyName");
			PropertyInfo property = GetProperty(propertyName);
			ThrowIfMemberMissing(propertyName, property);
			ThrowIfPublicGetter(property, typeof(T).Name);
			Guard.CanRead(property);
			MethodCall setup = Mock.SetupGet(mock, GetMemberAccess<TProperty>(property), null);
			return new NonVoidSetupPhrase<T, TProperty>(setup);
		}

		public ISetupSetter<T, TProperty> SetupSet<TProperty>(string propertyName, object value)
		{
			Guard.NotNullOrEmpty(propertyName, "propertyName");
			PropertyInfo property = GetProperty(propertyName);
			ThrowIfMemberMissing(propertyName, property);
			ThrowIfPublicSetter(property, typeof(T).Name);
			Guard.CanWrite(property);
			Expression<Action<T>> setterExpression = GetSetterExpression(property, ToExpressionArg(property.PropertyType, value));
			MethodCall setup = Mock.SetupSet(mock, setterExpression, null);
			return new SetterSetupPhrase<T, TProperty>(setup);
		}

		public ISetupSequentialAction SetupSequence(string methodOrPropertyName, params object[] args)
		{
			return InternalSetupSequence(methodOrPropertyName, null, exactParameterMatch: false, args);
		}

		public ISetupSequentialAction SetupSequence(string methodOrPropertyName, bool exactParameterMatch, params object[] args)
		{
			return InternalSetupSequence(methodOrPropertyName, null, exactParameterMatch, args);
		}

		public ISetupSequentialAction SetupSequence(string methodOrPropertyName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNull(genericTypeArguments, "genericTypeArguments");
			return InternalSetupSequence(methodOrPropertyName, genericTypeArguments, exactParameterMatch, args);
		}

		private ISetupSequentialAction InternalSetupSequence(string methodOrPropertyName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNullOrEmpty(methodOrPropertyName, "methodOrPropertyName");
			MethodInfo method = GetMethod(methodOrPropertyName, genericTypeArguments, exactParameterMatch, args);
			ThrowIfMemberMissing(methodOrPropertyName, method);
			ThrowIfPublicMethod(method, typeof(T).Name);
			SequenceSetup setup = Mock.SetupSequence(mock, GetMethodCall(method, args));
			return new SetupSequencePhrase(setup);
		}

		public ISetupSequentialResult<TResult> SetupSequence<TResult>(string methodOrPropertyName, params object[] args)
		{
			return InternalSetupSequence<TResult>(methodOrPropertyName, null, exactParameterMatch: false, args);
		}

		public ISetupSequentialResult<TResult> SetupSequence<TResult>(string methodOrPropertyName, bool exactParameterMatch, params object[] args)
		{
			return InternalSetupSequence<TResult>(methodOrPropertyName, null, exactParameterMatch, args);
		}

		public ISetupSequentialResult<TResult> SetupSequence<TResult>(string methodOrPropertyName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNull(genericTypeArguments, "genericTypeArguments");
			return InternalSetupSequence<TResult>(methodOrPropertyName, genericTypeArguments, exactParameterMatch, args);
		}

		private ISetupSequentialResult<TResult> InternalSetupSequence<TResult>(string methodOrPropertyName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNullOrEmpty(methodOrPropertyName, "methodOrPropertyName");
			PropertyInfo property = GetProperty(methodOrPropertyName);
			if (property != null)
			{
				ThrowIfPublicGetter(property, typeof(T).Name);
				SequenceSetup setup = Mock.SetupSequence(mock, GetMemberAccess<TResult>(property));
				return new SetupSequencePhrase<TResult>(setup);
			}
			MethodInfo method = GetMethod(methodOrPropertyName, genericTypeArguments, exactParameterMatch, args);
			ThrowIfMemberMissing(methodOrPropertyName, method);
			ThrowIfVoidMethod(method);
			ThrowIfPublicMethod(method, typeof(T).Name);
			SequenceSetup setup2 = Mock.SetupSequence(mock, GetMethodCall<TResult>(method, args));
			return new SetupSequencePhrase<TResult>(setup2);
		}

		public void Verify(string methodName, Times times, object[] args)
		{
			InternalVerify(methodName, null, times, exactParameterMatch: false, args);
		}

		public void Verify(string methodName, Type[] genericTypeArguments, Times times, params object[] args)
		{
			Guard.NotNull(genericTypeArguments, "genericTypeArguments");
			InternalVerify(methodName, genericTypeArguments, times, exactParameterMatch: false, args);
		}

		public void Verify(string methodName, Times times, bool exactParameterMatch, object[] args)
		{
			InternalVerify(methodName, null, times, exactParameterMatch, args);
		}

		public void Verify(string methodName, Type[] genericTypeArguments, Times times, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNull(genericTypeArguments, "genericTypeArguments");
			InternalVerify(methodName, genericTypeArguments, times, exactParameterMatch, args);
		}

		private void InternalVerify(string methodName, Type[] genericTypeArguments, Times times, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNullOrEmpty(methodName, "methodName");
			MethodInfo method = GetMethod(methodName, genericTypeArguments, exactParameterMatch, args);
			ThrowIfMethodMissing(methodName, method, args);
			ThrowIfPublicMethod(method, typeof(T).Name);
			Mock.Verify(mock, GetMethodCall(method, args), times, null);
		}

		public void Verify<TResult>(string methodName, Times times, object[] args)
		{
			InternalVerify<TResult>(methodName, null, times, exactParameterMatch: false, args);
		}

		public void Verify<TResult>(string methodName, Type[] genericTypeArguments, Times times, params object[] args)
		{
			Guard.NotNull(genericTypeArguments, "genericTypeArguments");
			InternalVerify<TResult>(methodName, genericTypeArguments, times, exactParameterMatch: false, args);
		}

		public void Verify<TResult>(string methodName, Times times, bool exactParameterMatch, object[] args)
		{
			InternalVerify<TResult>(methodName, null, times, exactParameterMatch, args);
		}

		public void Verify<TResult>(string methodName, Type[] genericTypeArguments, Times times, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNull(genericTypeArguments, "genericTypeArguments");
			InternalVerify<TResult>(methodName, genericTypeArguments, times, exactParameterMatch, args);
		}

		private void InternalVerify<TResult>(string methodName, Type[] genericTypeArguments, Times times, bool exactParameterMatch, params object[] args)
		{
			Guard.NotNullOrEmpty(methodName, "methodName");
			PropertyInfo property = GetProperty(methodName);
			if (property != null)
			{
				ThrowIfPublicGetter(property, typeof(T).Name);
				Mock.VerifyGet(mock, GetMemberAccess<TResult>(property), times, null);
				return;
			}
			MethodInfo method = GetMethod(methodName, genericTypeArguments, exactParameterMatch, args);
			ThrowIfMethodMissing(methodName, method, args);
			ThrowIfPublicMethod(method, typeof(T).Name);
			Mock.Verify(mock, GetMethodCall<TResult>(method, args), times, null);
		}

		public void VerifyGet<TProperty>(string propertyName, Times times)
		{
			Guard.NotNullOrEmpty(propertyName, "propertyName");
			PropertyInfo property = GetProperty(propertyName);
			ThrowIfMemberMissing(propertyName, property);
			ThrowIfPublicGetter(property, typeof(T).Name);
			Guard.CanRead(property);
			Mock.VerifyGet(mock, GetMemberAccess<TProperty>(property), times, null);
		}

		public void VerifySet<TProperty>(string propertyName, Times times, object value)
		{
			Guard.NotNullOrEmpty(propertyName, "propertyName");
			PropertyInfo property = GetProperty(propertyName);
			ThrowIfMemberMissing(propertyName, property);
			ThrowIfPublicSetter(property, typeof(T).Name);
			Guard.CanWrite(property);
			Expression<Action<T>> setterExpression = GetSetterExpression(property, ToExpressionArg(property.PropertyType, value));
			Mock.VerifySet(mock, setterExpression, times, null);
		}

		private static Expression<Func<T, TResult>> GetMemberAccess<TResult>(PropertyInfo property)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "mock");
			return Expression.Lambda<Func<T, TResult>>(Expression.MakeMemberAccess(parameterExpression, property), new ParameterExpression[1] { parameterExpression });
		}

		private static MethodInfo GetMethod(string methodName, Type[] genericTypeArguments, bool exact, params object[] args)
		{
			Type[] argTypes = ToArgTypes(args);
			IEnumerable<MethodInfo> source = from m in typeof(T).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				where m.Name == methodName
				select m;
			if (genericTypeArguments != null && genericTypeArguments.Length != 0)
			{
				source = from m in source
					where m.IsGenericMethod && m.GetGenericArguments().Length == genericTypeArguments.Length
					select m.MakeGenericMethod(genericTypeArguments);
			}
			return source.SingleOrDefault((MethodInfo m) => m.GetParameterTypes().CompareTo(argTypes, exact, considerTypeMatchers: false));
		}

		private static Expression<Func<T, TResult>> GetMethodCall<TResult>(MethodInfo method, object[] args)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "mock");
			return Expression.Lambda<Func<T, TResult>>(Expression.Call(parameterExpression, method, ToExpressionArgs(method, args)), new ParameterExpression[1] { parameterExpression });
		}

		private static Expression<Action<T>> GetMethodCall(MethodInfo method, object[] args)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "mock");
			return Expression.Lambda<Action<T>>(Expression.Call(parameterExpression, method, ToExpressionArgs(method, args)), new ParameterExpression[1] { parameterExpression });
		}

		private static PropertyInfo GetProperty(string propertyName)
		{
			return typeof(T).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		private static Expression<Action<T>> GetSetterExpression(PropertyInfo property, Expression value)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "mock");
			return Expression.Lambda<Action<T>>(Expression.Call(parameterExpression, property.GetSetMethod(nonPublic: true), value), new ParameterExpression[1] { parameterExpression });
		}

		private static void ThrowIfMemberMissing(string memberName, MemberInfo member)
		{
			if (member == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.MemberMissing, typeof(T).Name, memberName));
			}
		}

		private static void ThrowIfMethodMissing(string methodName, MethodInfo method, object[] args)
		{
			if (!(method == null))
			{
				return;
			}
			List<string> list = new List<string>();
			foreach (object obj in args)
			{
				if (obj is Expression expression)
				{
					list.Add(expression.Type.GetFormattedName());
				}
				else
				{
					list.Add(obj.GetType().GetFormattedName());
				}
			}
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.MethodMissing, typeof(T).Name, methodName, string.Join(", ", list.ToArray())));
		}

		private static void ThrowIfPublicMethod(MethodInfo method, string reflectedTypeName)
		{
			if (method.IsPublic)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.MethodIsPublic, reflectedTypeName, method.Name));
			}
		}

		private static void ThrowIfPublicGetter(PropertyInfo property, string reflectedTypeName)
		{
			if (property.CanRead(out MethodInfo getter) && getter.IsPublic)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.UnexpectedPublicProperty, reflectedTypeName, property.Name));
			}
		}

		private static void ThrowIfPublicSetter(PropertyInfo property, string reflectedTypeName)
		{
			if (property.CanWrite(out MethodInfo setter) && setter.IsPublic)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.UnexpectedPublicProperty, reflectedTypeName, property.Name));
			}
		}

		private static void ThrowIfVoidMethod(MethodInfo method)
		{
			if (method.ReturnType == typeof(void))
			{
				throw new ArgumentException(Resources.CantSetReturnValueForVoid);
			}
		}

		private static Type[] ToArgTypes(object[] args)
		{
			if (args == null)
			{
				throw new ArgumentException(Resources.UseItExprIsNullRatherThanNullArgumentValue);
			}
			Type[] array = new Type[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == null)
				{
					throw new ArgumentException(Resources.UseItExprIsNullRatherThanNullArgumentValue);
				}
				if (!(args[i] is Expression expression))
				{
					array[i] = args[i].GetType();
					continue;
				}
				if (expression.NodeType == ExpressionType.Call)
				{
					array[i] = ((MethodCallExpression)expression).Method.ReturnType;
					continue;
				}
				FieldInfo fieldInfo = ItRefAnyField(expression);
				if ((object)fieldInfo != null)
				{
					array[i] = fieldInfo.FieldType.MakeByRefType();
				}
				else if (expression.NodeType == ExpressionType.MemberAccess)
				{
					MemberExpression memberExpression = (MemberExpression)expression;
					if (memberExpression.Member is FieldInfo fieldInfo2)
					{
						array[i] = fieldInfo2.FieldType;
						continue;
					}
					if (!(memberExpression.Member is PropertyInfo propertyInfo))
					{
						throw new NotSupportedException(string.Format(Resources.Culture, Resources.UnsupportedMember, memberExpression.Member.Name));
					}
					array[i] = propertyInfo.PropertyType;
				}
				else
				{
					array[i] = (expression.PartialEval() as ConstantExpression)?.Type;
				}
			}
			return array;
		}

		private static bool IsItRefAny(Expression expression)
		{
			return ItRefAnyField(expression) != null;
		}

		private static FieldInfo ItRefAnyField(Expression expr)
		{
			FieldInfo result = null;
			if (expr.NodeType == ExpressionType.MemberAccess)
			{
				MemberExpression memberExpression = (MemberExpression)expr;
				if (memberExpression.Member is FieldInfo { Name: "IsAny", DeclaringType: var declaringType } fieldInfo && declaringType.IsGenericType)
				{
					Type genericTypeDefinition = declaringType.GetGenericTypeDefinition();
					if (genericTypeDefinition == typeof(It.Ref<>))
					{
						result = fieldInfo;
					}
				}
			}
			return result;
		}

		private static Expression ToExpressionArg(Type type, object arg)
		{
			Expression expression = arg as Expression;
			if (expression != null)
			{
				if (!type.IsAssignableFrom(expression.GetType()))
				{
					if (arg is LambdaExpression lambdaExpression)
					{
						expression = lambdaExpression.Body;
					}
					return expression;
				}
				if (IsItRefAny(expression))
				{
					return expression;
				}
				if (expression.IsMatch(out Match _))
				{
					return expression;
				}
			}
			return Expression.Constant(arg, type);
		}

		private static IEnumerable<Expression> ToExpressionArgs(MethodInfo method, object[] args)
		{
			ParameterInfo[] methodParams = method.GetParameters();
			for (int i = 0; i < args.Length; i++)
			{
				yield return ToExpressionArg(methodParams[i].ParameterType, args[i]);
			}
		}

		Type IFluentInterface.GetType()
		{
			return GetType();
		}
	}
}
