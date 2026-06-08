using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Properties;
using TypeNameFormatter;

namespace Moq
{
	[DebuggerStepThrough]
	internal static class Guard
	{
		public static void CanCreateInstance(Type type)
		{
			if (!type.CanCreateInstance())
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.TypeHasNoDefaultConstructor, type.GetFormattedName()));
			}
		}

		public static void ImplementsInterface(Type interfaceType, Type type, string paramName = null)
		{
			if (!interfaceType.IsAssignableFrom(type))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.TypeNotImplementInterface, type.GetFormattedName(), interfaceType.GetFormattedName()), paramName);
			}
		}

		public static void ImplementsTypeMatcherProtocol(Type type)
		{
			ImplementsInterface(typeof(ITypeMatcher), type);
			CanCreateInstance(type);
		}

		public static void IsAssignmentToPropertyOrIndexer(LambdaExpression expression, string paramName)
		{
			switch (expression.Body.NodeType)
			{
			case ExpressionType.Assign:
			{
				BinaryExpression binaryExpression = (BinaryExpression)expression.Body;
				if (binaryExpression.Left is MemberExpression || binaryExpression.Left is IndexExpression)
				{
					return;
				}
				break;
			}
			case ExpressionType.Call:
			{
				MethodCallExpression methodCallExpression = (MethodCallExpression)expression.Body;
				if (methodCallExpression.Method.IsSetAccessor())
				{
					return;
				}
				break;
			}
			}
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.SetupNotSetter, expression.ToStringFixed()), paramName);
		}

		public static void IsOverridable(MethodInfo method, Expression expression)
		{
			if (method.IsStatic)
			{
				throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedExpressionWithHint, expression.ToStringFixed(), string.Format(CultureInfo.CurrentCulture, method.IsExtensionMethod() ? Resources.UnsupportedExtensionMethod : Resources.UnsupportedStaticMember, method.DeclaringType.GetFormattedName() + "." + method.Name)));
			}
			if (!method.CanOverride())
			{
				throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedExpressionWithHint, expression.ToStringFixed(), string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedNonOverridableMember, method.DeclaringType.GetFormattedName() + "." + method.Name)));
			}
		}

		public static void IsVisibleToProxyFactory(MethodInfo method)
		{
			if (!ProxyFactory.Instance.IsMethodVisible(method, out string messageIfNotVisible))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.MethodNotVisibleToProxyFactory, method.DeclaringType.Name, method.Name, messageIfNotVisible));
			}
		}

		public static void IsEventAdd(LambdaExpression expression, string paramName)
		{
			ExpressionType nodeType = expression.Body.NodeType;
			if (nodeType == ExpressionType.Call)
			{
				MethodCallExpression methodCallExpression = (MethodCallExpression)expression.Body;
				if (methodCallExpression.Method.IsEventAddAccessor())
				{
					return;
				}
			}
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.SetupNotEventAdd, expression.ToStringFixed()), paramName);
		}

		public static void IsEventRemove(LambdaExpression expression, string paramName)
		{
			ExpressionType nodeType = expression.Body.NodeType;
			if (nodeType == ExpressionType.Call)
			{
				MethodCallExpression methodCallExpression = (MethodCallExpression)expression.Body;
				if (methodCallExpression.Method.IsEventRemoveAccessor())
				{
					return;
				}
			}
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.SetupNotEventRemove, expression.ToStringFixed()), paramName);
		}

		public static void NotNull(object value, string paramName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(paramName);
			}
		}

		public static void NotNullOrEmpty(string value, string paramName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(paramName);
			}
			if (value.Length == 0)
			{
				throw new ArgumentException(Resources.ArgumentCannotBeEmpty, paramName);
			}
		}

		public static void NotField(MemberExpression memberAccess)
		{
			if (memberAccess.Member is FieldInfo)
			{
				throw new NotSupportedException(string.Format(Resources.FieldsNotSupported, memberAccess.ToStringFixed()));
			}
		}

		public static void IsMockable(Type type)
		{
			if (!type.IsMockable())
			{
				throw new NotSupportedException(string.Format(Resources.TypeNotMockable, type.GetFormattedName()));
			}
		}

		public static void Positive(TimeSpan delay)
		{
			if (delay <= TimeSpan.Zero)
			{
				throw new ArgumentException(Resources.DelaysMustBeGreaterThanZero);
			}
		}

		public static void CanRead(PropertyInfo property)
		{
			if (!property.CanRead(out MethodInfo _))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.PropertyGetNotFound, property.DeclaringType.Name, property.Name));
			}
		}

		public static void CanWrite(PropertyInfo property)
		{
			if (!property.CanWrite(out MethodInfo _))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.PropertySetNotFound, property.DeclaringType.Name, property.Name));
			}
		}
	}
}
