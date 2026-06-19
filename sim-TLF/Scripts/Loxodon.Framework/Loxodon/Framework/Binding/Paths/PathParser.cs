using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Loxodon.Framework.Binding.Paths
{
	public class PathParser : IPathParser
	{
		public virtual Path Parse(string pathText)
		{
			return TextPathParser.Parse(pathText);
		}

		public virtual Path Parse(LambdaExpression expression)
		{
			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}
			Path path = new Path();
			if (expression.Body is MemberExpression expression2)
			{
				Parse(expression2, path);
				return path;
			}
			if (expression.Body is MethodCallExpression expression3)
			{
				Parse(expression3, path);
				return path;
			}
			if (expression.Body is UnaryExpression { NodeType: ExpressionType.Convert } unaryExpression)
			{
				Parse(unaryExpression.Operand, path);
				return path;
			}
			if (expression.Body is BinaryExpression { NodeType: ExpressionType.ArrayIndex } binaryExpression)
			{
				Parse(binaryExpression, path);
				return path;
			}
			return path;
		}

		private MethodInfo GetDelegateMethodInfo(MethodCallExpression expression)
		{
			Expression expression2 = expression.Object;
			ReadOnlyCollection<Expression> arguments = expression.Arguments;
			if (expression2 == null)
			{
				foreach (Expression item in arguments)
				{
					if (item is ConstantExpression)
					{
						object value = (item as ConstantExpression).Value;
						if (value is MethodInfo)
						{
							return (MethodInfo)value;
						}
					}
				}
				return null;
			}
			if (expression2 is ConstantExpression)
			{
				object value2 = (expression2 as ConstantExpression).Value;
				if (value2 is MethodInfo)
				{
					return (MethodInfo)value2;
				}
			}
			return null;
		}

		private void Parse(Expression expression, Path path)
		{
			if (expression == null || (!(expression is MemberExpression) && !(expression is MethodCallExpression) && !(expression is BinaryExpression)))
			{
				return;
			}
			if (expression is MemberExpression { Member: var member } memberExpression)
			{
				if (member.IsStatic())
				{
					path.Prepend(new MemberNode(member));
					return;
				}
				path.Prepend(new MemberNode(member));
				if (memberExpression.Expression != null)
				{
					Parse(memberExpression.Expression, path);
				}
			}
			else if (expression is MethodCallExpression methodCallExpression)
			{
				if (methodCallExpression.Method.Name.Equals("get_Item") && methodCallExpression.Arguments.Count == 1)
				{
					Expression expression2 = methodCallExpression.Arguments[0];
					if (!(expression2 is ConstantExpression))
					{
						expression2 = ConvertMemberAccessToConstant(expression2);
					}
					object value = (expression2 as ConstantExpression).Value;
					if (value is string)
					{
						path.PrependIndexed((string)value);
					}
					else if (value is int)
					{
						path.PrependIndexed((int)value);
					}
					if (methodCallExpression.Object != null)
					{
						Parse(methodCallExpression.Object, path);
					}
					return;
				}
				if (methodCallExpression.Method.Name.Equals("CreateDelegate"))
				{
					MethodInfo delegateMethodInfo = GetDelegateMethodInfo(methodCallExpression);
					if (delegateMethodInfo == null)
					{
						throw new ArgumentException($"Invalid expression:{expression}");
					}
					if (delegateMethodInfo.IsStatic)
					{
						path.Prepend(new MemberNode(delegateMethodInfo));
						return;
					}
					path.Prepend(new MemberNode(delegateMethodInfo));
					Parse(methodCallExpression.Arguments[1], path);
					return;
				}
				if (!methodCallExpression.Method.ReturnType.Equals(typeof(void)))
				{
					throw new ArgumentException($"Invalid expression:{expression}");
				}
				MethodInfo method = methodCallExpression.Method;
				if (method.IsStatic)
				{
					path.Prepend(new MemberNode(method));
					return;
				}
				path.Prepend(new MemberNode(method));
				if (methodCallExpression.Object != null)
				{
					Parse(methodCallExpression.Object, path);
				}
			}
			else if (expression is BinaryExpression binaryExpression)
			{
				if (binaryExpression.NodeType != ExpressionType.ArrayIndex)
				{
					throw new ArgumentException($"Invalid expression:{expression}");
				}
				Expression left = binaryExpression.Left;
				Expression expression3 = binaryExpression.Right;
				if (!(expression3 is ConstantExpression))
				{
					expression3 = ConvertMemberAccessToConstant(expression3);
				}
				object value2 = (expression3 as ConstantExpression).Value;
				if (value2 is string)
				{
					path.PrependIndexed((string)value2);
				}
				else if (value2 is int)
				{
					path.PrependIndexed((int)value2);
				}
				if (left != null)
				{
					Parse(left, path);
				}
			}
		}

		private static Expression ConvertMemberAccessToConstant(Expression argument)
		{
			if (argument is ConstantExpression)
			{
				return argument;
			}
			return Expression.Constant(Expression.Lambda<Func<object>>(Expression.Convert(argument, typeof(object)), Array.Empty<ParameterExpression>()).Compile()());
		}

		public virtual Path ParseStaticPath(LambdaExpression expression)
		{
			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}
			Expression expression2 = expression.Body;
			if (expression2 is UnaryExpression unaryExpression)
			{
				expression2 = unaryExpression.Operand;
			}
			if (expression2 is MemberExpression)
			{
				Path path = new Path();
				Parse(expression2, path);
				return path;
			}
			if (expression2 is MethodCallExpression)
			{
				Path path2 = new Path();
				Parse(expression2, path2);
				return path2;
			}
			if (expression2 is BinaryExpression { NodeType: ExpressionType.ArrayIndex })
			{
				Path path3 = new Path();
				Parse(expression2, path3);
				return path3;
			}
			throw new ArgumentException($"Invalid expression:{expression}");
		}

		public virtual Path ParseStaticPath(string pathText)
		{
			string typeName = ParserTypeName(pathText);
			string name = ParserMemberName(pathText);
			Type type = TypeFinderUtils.FindType(typeName);
			Path path = new Path();
			path.Append(new MemberNode(type, name, isStatic: true));
			return path;
		}

		protected string ParserTypeName(string pathText)
		{
			if (pathText == null)
			{
				throw new ArgumentNullException("pathText");
			}
			pathText = pathText.Replace(" ", "");
			if (string.IsNullOrEmpty(pathText))
			{
				throw new ArgumentException("The pathText is empty");
			}
			int num = pathText.LastIndexOf('.');
			if (num <= 0)
			{
				throw new ArgumentException("pathText");
			}
			return pathText.Substring(0, num);
		}

		protected string ParserMemberName(string pathText)
		{
			if (pathText == null)
			{
				throw new ArgumentNullException("pathText");
			}
			pathText = pathText.Replace(" ", "");
			if (string.IsNullOrEmpty(pathText))
			{
				throw new ArgumentException("The pathText is empty");
			}
			int num = pathText.LastIndexOf('.');
			if (num <= 0)
			{
				throw new ArgumentException("pathText");
			}
			return pathText.Substring(num + 1);
		}

		public virtual string ParseMemberName(LambdaExpression expression)
		{
			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}
			return ParseMemberName0(expression.Body);
		}

		protected string ParseMemberName0(Expression expression)
		{
			if (expression == null || (!(expression is MemberExpression) && !(expression is MethodCallExpression) && !(expression is UnaryExpression)))
			{
				return null;
			}
			if (expression is MethodCallExpression methodCallExpression)
			{
				if (methodCallExpression.Method.Name.Equals("get_Item") && methodCallExpression.Arguments.Count == 1)
				{
					string text = null;
					Expression expression2 = methodCallExpression.Arguments[0];
					if (!(expression2 is ConstantExpression))
					{
						expression2 = ConvertMemberAccessToConstant(expression2);
					}
					object value = (expression2 as ConstantExpression).Value;
					if (value is string arg)
					{
						text = $"[\"{arg}\"]";
					}
					else if (value is int num)
					{
						text = $"[{num}]";
					}
					if (!(methodCallExpression.Object is MemberExpression memberExpression) || !(memberExpression.Expression is ParameterExpression))
					{
						return text;
					}
					return ParseMemberName0(memberExpression) + text;
				}
				return methodCallExpression.Method.Name;
			}
			if (expression is UnaryExpression { NodeType: ExpressionType.Convert } unaryExpression)
			{
				if (unaryExpression.Operand is MethodCallExpression methodCallExpression2 && methodCallExpression2.Method.Name.Equals("CreateDelegate"))
				{
					MethodInfo delegateMethodInfo = GetDelegateMethodInfo(methodCallExpression2);
					if (delegateMethodInfo != null)
					{
						return delegateMethodInfo.Name;
					}
				}
				throw new ArgumentException($"Invalid expression:{expression}");
			}
			if (!(expression is MemberExpression memberExpression2) || !(memberExpression2.Expression is ParameterExpression))
			{
				throw new ArgumentException($"Invalid expression:{expression}");
			}
			return memberExpression2.Member.Name;
		}
	}
}
