using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Moq.Properties;
using TypeNameFormatter;

namespace Moq
{
	internal static class StringBuilderExtensions
	{
		public static StringBuilder AppendExpression(this StringBuilder builder, Expression expression)
		{
			if (expression == null)
			{
				return builder.Append("null");
			}
			switch (expression.NodeType)
			{
			case ExpressionType.ArrayLength:
			case ExpressionType.Convert:
			case ExpressionType.ConvertChecked:
			case ExpressionType.Negate:
			case ExpressionType.NegateChecked:
			case ExpressionType.Not:
			case ExpressionType.Quote:
			case ExpressionType.TypeAs:
				return builder.AppendExpression((UnaryExpression)expression);
			case ExpressionType.Add:
			case ExpressionType.AddChecked:
			case ExpressionType.And:
			case ExpressionType.AndAlso:
			case ExpressionType.ArrayIndex:
			case ExpressionType.Coalesce:
			case ExpressionType.Divide:
			case ExpressionType.Equal:
			case ExpressionType.ExclusiveOr:
			case ExpressionType.GreaterThan:
			case ExpressionType.GreaterThanOrEqual:
			case ExpressionType.LeftShift:
			case ExpressionType.LessThan:
			case ExpressionType.LessThanOrEqual:
			case ExpressionType.Modulo:
			case ExpressionType.Multiply:
			case ExpressionType.MultiplyChecked:
			case ExpressionType.NotEqual:
			case ExpressionType.Or:
			case ExpressionType.OrElse:
			case ExpressionType.RightShift:
			case ExpressionType.Subtract:
			case ExpressionType.SubtractChecked:
			case ExpressionType.Assign:
			case ExpressionType.AddAssign:
			case ExpressionType.SubtractAssign:
				return builder.AppendExpression((BinaryExpression)expression);
			case ExpressionType.TypeIs:
				return builder.AppendExpression((TypeBinaryExpression)expression);
			case ExpressionType.Conditional:
				return builder.AppendExpression((ConditionalExpression)expression);
			case ExpressionType.Constant:
			{
				object value = ((ConstantExpression)expression).Value;
				if (value is LambdaExpression expression3)
				{
					return builder.AppendExpression(expression3);
				}
				return builder.AppendValueOf(value);
			}
			case ExpressionType.Parameter:
				return builder.AppendExpression((ParameterExpression)expression);
			case ExpressionType.MemberAccess:
				return builder.AppendExpression((MemberExpression)expression);
			case ExpressionType.Call:
				return builder.AppendExpression((MethodCallExpression)expression);
			case ExpressionType.Index:
				return builder.AppendExpression((IndexExpression)expression);
			case ExpressionType.Lambda:
				return builder.AppendExpression((LambdaExpression)expression);
			case ExpressionType.New:
				return builder.AppendExpression((NewExpression)expression);
			case ExpressionType.NewArrayInit:
			case ExpressionType.NewArrayBounds:
				return builder.AppendExpression((NewArrayExpression)expression);
			case ExpressionType.Invoke:
				return builder.AppendExpression((InvocationExpression)expression);
			case ExpressionType.MemberInit:
				return builder.AppendExpression((MemberInitExpression)expression);
			case ExpressionType.ListInit:
				return builder.AppendExpression((ListInitExpression)expression);
			case ExpressionType.Extension:
				if (expression is MatchExpression expression2)
				{
					return builder.AppendExpression(expression2);
				}
				break;
			}
			throw new Exception(string.Format(Resources.UnhandledExpressionType, expression.NodeType));
		}

		private static StringBuilder AppendElementInit(this StringBuilder builder, ElementInit initializer)
		{
			return builder.AppendCommaSeparated("{ ", initializer.Arguments, AppendExpression, " }");
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, UnaryExpression expression)
		{
			switch (expression.NodeType)
			{
			case ExpressionType.Convert:
			case ExpressionType.ConvertChecked:
				return builder.Append('(').AppendNameOf(expression.Type).Append(')')
					.AppendExpression(expression.Operand);
			case ExpressionType.ArrayLength:
				return builder.AppendExpression(expression.Operand).Append(".Length");
			case ExpressionType.Negate:
			case ExpressionType.NegateChecked:
				return builder.Append('-').AppendExpression(expression.Operand);
			case ExpressionType.Not:
				return builder.Append("!(").AppendExpression(expression.Operand).Append(')');
			case ExpressionType.Quote:
				return builder.AppendExpression(expression.Operand);
			case ExpressionType.TypeAs:
				return builder.Append('(').AppendExpression(expression.Operand).Append(" as ")
					.AppendNameOf(expression.Type)
					.Append(')');
			default:
				return builder;
			}
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, BinaryExpression expression)
		{
			if (expression.NodeType == ExpressionType.ArrayIndex)
			{
				builder.AppendExpression(expression.Left).Append('[').AppendExpression(expression.Right)
					.Append(']');
			}
			else
			{
				AppendMaybeParenthesized(expression.Left, builder);
				builder.Append(' ').Append(GetOperator(expression.NodeType)).Append(' ');
				AppendMaybeParenthesized(expression.Right, builder);
			}
			return builder;
			static void AppendMaybeParenthesized(Expression operand, StringBuilder b)
			{
				bool flag = operand.NodeType == ExpressionType.AndAlso || operand.NodeType == ExpressionType.OrElse;
				if (flag)
				{
					b.Append("(");
				}
				b.AppendExpression(operand);
				if (flag)
				{
					b.Append(")");
				}
			}
			static string GetOperator(ExpressionType nodeType)
			{
				return nodeType switch
				{
					ExpressionType.Add => "+", 
					ExpressionType.AddChecked => "+", 
					ExpressionType.AddAssign => "+=", 
					ExpressionType.Assign => "=", 
					ExpressionType.And => "&", 
					ExpressionType.AndAlso => "&&", 
					ExpressionType.Coalesce => "??", 
					ExpressionType.Divide => "/", 
					ExpressionType.Equal => "==", 
					ExpressionType.ExclusiveOr => "^", 
					ExpressionType.GreaterThan => ">", 
					ExpressionType.GreaterThanOrEqual => ">=", 
					ExpressionType.LeftShift => "<<", 
					ExpressionType.LessThan => "<", 
					ExpressionType.LessThanOrEqual => "<=", 
					ExpressionType.Modulo => "%", 
					ExpressionType.Multiply => "*", 
					ExpressionType.MultiplyChecked => "*", 
					ExpressionType.NotEqual => "!=", 
					ExpressionType.Or => "|", 
					ExpressionType.OrElse => "||", 
					ExpressionType.Power => "**", 
					ExpressionType.RightShift => ">>", 
					ExpressionType.Subtract => "-", 
					ExpressionType.SubtractChecked => "-", 
					ExpressionType.SubtractAssign => "-=", 
					_ => nodeType.ToString(), 
				};
			}
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, TypeBinaryExpression expression)
		{
			return builder.AppendExpression(expression.Expression).Append(" is ").AppendNameOf(expression.TypeOperand);
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, ConditionalExpression expression)
		{
			return builder.AppendExpression(expression.Test).Append(" ? ").AppendExpression(expression.IfTrue)
				.Append(" : ")
				.AppendExpression(expression.IfFalse);
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, ParameterExpression expression)
		{
			return builder.Append(expression.Name ?? "<param>");
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, MemberExpression expression)
		{
			if (expression.Expression != null)
			{
				if (expression.Expression is ConstantExpression constantExpression && constantExpression.Type.IsDefined(typeof(CompilerGeneratedAttribute)))
				{
					return builder.Append(expression.Member.Name);
				}
				builder.AppendExpression(expression.Expression);
			}
			else
			{
				builder.AppendNameOf(expression.Member.DeclaringType);
			}
			return builder.Append('.').Append(expression.Member.Name);
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, MethodCallExpression expression)
		{
			Expression expression2 = expression.Object;
			MethodInfo method = expression.Method;
			IEnumerable<Expression> source = expression.Arguments;
			if (method.IsExtensionMethod())
			{
				expression2 = source.First();
				source = source.Skip(1);
			}
			if (expression2 != null)
			{
				builder.AppendExpression(expression2);
			}
			else
			{
				builder.AppendNameOf(method.DeclaringType);
			}
			if (method.IsGetAccessor())
			{
				if (method.IsPropertyAccessor())
				{
					builder.Append('.').Append(method.Name, 4);
				}
				else
				{
					builder.AppendCommaSeparated("[", source, AppendExpression, "]");
				}
			}
			else if (method.IsSetAccessor())
			{
				if (method.IsPropertyAccessor())
				{
					builder.Append('.').Append(method.Name, 4).Append(" = ")
						.AppendExpression(source.Last());
				}
				else
				{
					builder.AppendCommaSeparated("[", source.Take(source.Count() - 1), AppendExpression, "] = ").AppendExpression(source.Last());
				}
			}
			else if (method.IsEventAddAccessor())
			{
				builder.Append('.').Append(method.Name, 4).Append(" += ")
					.AppendCommaSeparated(source, AppendExpression);
			}
			else if (method.IsEventRemoveAccessor())
			{
				builder.Append('.').Append(method.Name, 7).Append(" -= ")
					.AppendCommaSeparated(source, AppendExpression);
			}
			else
			{
				builder.Append('.').AppendNameOf(method, includeGenericArgumentList: true).AppendCommaSeparated("(", source, AppendExpression, ")");
			}
			return builder;
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, IndexExpression expression)
		{
			return builder.AppendExpression(expression.Object).AppendCommaSeparated("[", expression.Arguments, AppendExpression, "]");
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, LambdaExpression expression)
		{
			if (expression.Parameters.Count == 1)
			{
				builder.AppendExpression(expression.Parameters[0]);
			}
			else
			{
				builder.AppendCommaSeparated("(", expression.Parameters, AppendExpression, ")");
			}
			return builder.Append(" => ").AppendExpression(expression.Body);
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, NewExpression expression)
		{
			Type type = ((expression.Constructor == null) ? expression.Type : expression.Constructor.DeclaringType);
			return builder.Append("new ").AppendNameOf(type).AppendCommaSeparated("(", expression.Arguments, AppendExpression, ")");
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, NewArrayExpression expression)
		{
			return expression.NodeType switch
			{
				ExpressionType.NewArrayInit => builder.AppendCommaSeparated("new[] { ", expression.Expressions, AppendExpression, " }"), 
				ExpressionType.NewArrayBounds => builder.Append("new ").AppendNameOf(expression.Type.GetElementType()).AppendCommaSeparated("[", expression.Expressions, AppendExpression, "]"), 
				_ => builder, 
			};
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, InvocationExpression expression)
		{
			return builder.AppendExpression(expression.Expression).AppendCommaSeparated("(", expression.Arguments, AppendExpression, ")");
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, MemberInitExpression expression)
		{
			return builder.AppendExpression(expression.NewExpression).AppendCommaSeparated(" { ", expression.Bindings, AppendMemberBinding, " }");
			StringBuilder AppendMemberBinding(StringBuilder b, MemberBinding binding)
			{
				switch (binding.BindingType)
				{
				case MemberBindingType.Assignment:
				{
					MemberAssignment memberAssignment = (MemberAssignment)binding;
					return builder.Append(memberAssignment.Member.Name).Append("= ").AppendExpression(memberAssignment.Expression);
				}
				case MemberBindingType.MemberBinding:
					return b.AppendCommaSeparated(((MemberMemberBinding)binding).Bindings, AppendMemberBinding);
				case MemberBindingType.ListBinding:
				{
					ReadOnlyCollection<ElementInit> initializers = ((MemberListBinding)binding).Initializers;
					int i = 0;
					for (int count = initializers.Count; i < count; i++)
					{
						builder.AppendElementInit(initializers[i]);
					}
					return builder;
				}
				default:
					throw new Exception(string.Format(Resources.UnhandledBindingType, binding.BindingType));
				}
			}
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, ListInitExpression expression)
		{
			return builder.AppendExpression(expression.NewExpression).AppendCommaSeparated(" { ", expression.Initializers, AppendElementInit, " }");
		}

		private static StringBuilder AppendExpression(this StringBuilder builder, MatchExpression expression)
		{
			return builder.AppendExpression(expression.Match.RenderExpression);
		}

		public static StringBuilder Append(this StringBuilder stringBuilder, string str, int startIndex)
		{
			return stringBuilder.Append(str, startIndex, str.Length - startIndex);
		}

		public static StringBuilder AppendCommaSeparated<T>(this StringBuilder stringBuilder, string prefix, IEnumerable<T> source, Func<StringBuilder, T, StringBuilder> append, string suffix)
		{
			return stringBuilder.Append(prefix).AppendCommaSeparated(source, append).Append(suffix);
		}

		public static StringBuilder AppendCommaSeparated<T>(this StringBuilder stringBuilder, IEnumerable<T> source, Func<StringBuilder, T, StringBuilder> append)
		{
			bool flag = false;
			foreach (T item in source)
			{
				if (flag)
				{
					stringBuilder.Append(", ");
				}
				append(stringBuilder, item);
				flag = true;
			}
			return stringBuilder;
		}

		public static StringBuilder AppendIndented(this StringBuilder stringBuilder, string str, int count = 1, char indentChar = ' ')
		{
			int num = 0;
			while (num < str.Length)
			{
				stringBuilder.Append(indentChar, count);
				int num2 = str.IndexOf('\n', num + 1);
				if (num2 <= num)
				{
					break;
				}
				stringBuilder.Append(str, num, num2 - num + 1);
				num = num2 + 1;
			}
			stringBuilder.Append(str, num, str.Length - num);
			return stringBuilder;
		}

		public static StringBuilder AppendNameOf(this StringBuilder stringBuilder, MethodBase method, bool includeGenericArgumentList)
		{
			stringBuilder.Append(method.Name);
			if (includeGenericArgumentList && method.IsGenericMethod)
			{
				stringBuilder.AppendCommaSeparated("<", method.GetGenericArguments(), AppendNameOf, ">");
			}
			return stringBuilder;
		}

		public static StringBuilder AppendNameOf(this StringBuilder stringBuilder, Type type)
		{
			return stringBuilder.AppendFormattedName(type);
		}

		public static StringBuilder AppendParameterType(this StringBuilder stringBuilder, ParameterInfo parameter)
		{
			Type type = parameter.ParameterType;
			if (type.IsByRef)
			{
				stringBuilder.Append((parameter.Attributes & (ParameterAttributes.In | ParameterAttributes.Out)) switch
				{
					ParameterAttributes.In => "in ", 
					ParameterAttributes.Out => "out ", 
					_ => "ref ", 
				});
				type = type.GetElementType();
			}
			if (type.IsArray && parameter.IsDefined(typeof(ParamArrayAttribute), inherit: true))
			{
				stringBuilder.Append("params ");
			}
			return stringBuilder.AppendFormattedName(type);
		}

		public static StringBuilder AppendValueOf(this StringBuilder stringBuilder, object obj)
		{
			if (obj == null)
			{
				stringBuilder.Append("null");
			}
			else if (obj is string value)
			{
				stringBuilder.Append('"').Append(value).Append('"');
			}
			else if (obj is float num)
			{
				stringBuilder.Append(num.ToString("G9"));
			}
			else if (obj is double num2)
			{
				stringBuilder.Append(num2.ToString("G17"));
			}
			else if (obj.GetType().IsEnum)
			{
				stringBuilder.AppendNameOf(obj.GetType()).Append('.').Append(obj);
			}
			else if (obj.GetType().IsArray || (obj.GetType().IsConstructedGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(List<>)))
			{
				stringBuilder.Append('[');
				IEnumerator enumerator = ((IEnumerable)obj).GetEnumerator();
				int num3 = 0;
				while (enumerator.MoveNext() && num3 < 11)
				{
					if (num3 > 0)
					{
						stringBuilder.Append(", ");
					}
					if (num3 == 10)
					{
						stringBuilder.Append("...");
						break;
					}
					stringBuilder.AppendValueOf(enumerator.Current);
					num3++;
				}
				stringBuilder.Append(']');
			}
			else
			{
				string text = obj.ToString();
				if (text == null || text == obj.GetType().ToString())
				{
					stringBuilder.AppendNameOf(obj.GetType());
				}
				else
				{
					stringBuilder.Append(text);
				}
			}
			return stringBuilder;
		}

		public static StringBuilder TrimEnd(this StringBuilder stringBuilder)
		{
			while (char.IsWhiteSpace(stringBuilder[stringBuilder.Length - 1]))
			{
				int length = stringBuilder.Length - 1;
				stringBuilder.Length = length;
			}
			return stringBuilder;
		}
	}
}
