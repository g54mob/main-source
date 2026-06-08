using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Moq.Expressions.Visitors;

namespace Moq
{
	internal sealed class ExpressionComparer : IEqualityComparer<Expression>
	{
		public static readonly ExpressionComparer Default = new ExpressionComparer();

		[ThreadStatic]
		private static int quoteDepth = 0;

		private ExpressionComparer()
		{
		}

		public bool Equals(Expression x, Expression y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			if (x is MemberExpression && quoteDepth == 0)
			{
				x = x.Apply(EvaluateCaptures.Rewriter);
			}
			if (y is MemberExpression && quoteDepth == 0)
			{
				y = y.Apply(EvaluateCaptures.Rewriter);
			}
			if (x.NodeType == y.NodeType)
			{
				switch (x.NodeType)
				{
				case ExpressionType.Quote:
					quoteDepth++;
					try
					{
						return EqualsUnary((UnaryExpression)x, (UnaryExpression)y);
					}
					finally
					{
						quoteDepth--;
					}
				case ExpressionType.ArrayLength:
				case ExpressionType.Convert:
				case ExpressionType.ConvertChecked:
				case ExpressionType.Negate:
				case ExpressionType.UnaryPlus:
				case ExpressionType.NegateChecked:
				case ExpressionType.Not:
				case ExpressionType.TypeAs:
					return EqualsUnary((UnaryExpression)x, (UnaryExpression)y);
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
				case ExpressionType.Power:
				case ExpressionType.RightShift:
				case ExpressionType.Subtract:
				case ExpressionType.SubtractChecked:
				case ExpressionType.Assign:
					return EqualsBinary((BinaryExpression)x, (BinaryExpression)y);
				case ExpressionType.TypeIs:
					return EqualsTypeBinary((TypeBinaryExpression)x, (TypeBinaryExpression)y);
				case ExpressionType.Conditional:
					return EqualsConditional((ConditionalExpression)x, (ConditionalExpression)y);
				case ExpressionType.Constant:
					return EqualsConstant((ConstantExpression)x, (ConstantExpression)y);
				case ExpressionType.Parameter:
					return EqualsParameter((ParameterExpression)x, (ParameterExpression)y);
				case ExpressionType.MemberAccess:
					return EqualsMember((MemberExpression)x, (MemberExpression)y);
				case ExpressionType.Call:
					return EqualsMethodCall((MethodCallExpression)x, (MethodCallExpression)y);
				case ExpressionType.Lambda:
					return EqualsLambda((LambdaExpression)x, (LambdaExpression)y);
				case ExpressionType.New:
					return EqualsNew((NewExpression)x, (NewExpression)y);
				case ExpressionType.NewArrayInit:
				case ExpressionType.NewArrayBounds:
					return EqualsNewArray((NewArrayExpression)x, (NewArrayExpression)y);
				case ExpressionType.Index:
					return EqualsIndex((IndexExpression)x, (IndexExpression)y);
				case ExpressionType.Invoke:
					return EqualsInvocation((InvocationExpression)x, (InvocationExpression)y);
				case ExpressionType.MemberInit:
					return EqualsMemberInit((MemberInitExpression)x, (MemberInitExpression)y);
				case ExpressionType.ListInit:
					return EqualsListInit((ListInitExpression)x, (ListInitExpression)y);
				}
			}
			if (x.NodeType == ExpressionType.Extension || y.NodeType == ExpressionType.Extension)
			{
				return EqualsExtension(x, y);
			}
			return false;
		}

		public int GetHashCode(Expression obj)
		{
			return obj?.GetHashCode() ?? 0;
		}

		private static bool Equals<T>(ReadOnlyCollection<T> x, ReadOnlyCollection<T> y, Func<T, T, bool> comparer)
		{
			if (x.Count != y.Count)
			{
				return false;
			}
			for (int i = 0; i < x.Count; i++)
			{
				if (!comparer(x[i], y[i]))
				{
					return false;
				}
			}
			return true;
		}

		private bool EqualsBinary(BinaryExpression x, BinaryExpression y)
		{
			if (x.Method == y.Method && Equals(x.Left, y.Left) && Equals(x.Right, y.Right))
			{
				return Equals(x.Conversion, y.Conversion);
			}
			return false;
		}

		private bool EqualsConditional(ConditionalExpression x, ConditionalExpression y)
		{
			if (Equals(x.Test, y.Test) && Equals(x.IfTrue, y.IfTrue))
			{
				return Equals(x.IfFalse, y.IfFalse);
			}
			return false;
		}

		private static bool EqualsConstant(ConstantExpression x, ConstantExpression y)
		{
			return object.Equals(x.Value, y.Value);
		}

		private bool EqualsElementInit(ElementInit x, ElementInit y)
		{
			if (x.AddMethod == y.AddMethod)
			{
				return Equals(x.Arguments, y.Arguments, Equals);
			}
			return false;
		}

		private bool EqualsIndex(IndexExpression x, IndexExpression y)
		{
			if (Equals(x.Object, y.Object) && object.Equals(x.Indexer, y.Indexer))
			{
				return Equals(x.Arguments, y.Arguments, Equals);
			}
			return false;
		}

		private bool EqualsInvocation(InvocationExpression x, InvocationExpression y)
		{
			if (Equals(x.Expression, y.Expression))
			{
				return Equals(x.Arguments, y.Arguments, Equals);
			}
			return false;
		}

		private bool EqualsLambda(LambdaExpression x, LambdaExpression y)
		{
			if (x.GetType() == y.GetType() && Equals(x.Body, y.Body))
			{
				return Equals(x.Parameters, y.Parameters, EqualsParameter);
			}
			return false;
		}

		private bool EqualsListInit(ListInitExpression x, ListInitExpression y)
		{
			if (EqualsNew(x.NewExpression, y.NewExpression))
			{
				return Equals(x.Initializers, y.Initializers, EqualsElementInit);
			}
			return false;
		}

		private bool EqualsMemberAssignment(MemberAssignment x, MemberAssignment y)
		{
			return Equals(x.Expression, y.Expression);
		}

		private bool EqualsMemberBinding(MemberBinding x, MemberBinding y)
		{
			if (x.BindingType == y.BindingType && x.Member == y.Member)
			{
				return x.BindingType switch
				{
					MemberBindingType.Assignment => EqualsMemberAssignment((MemberAssignment)x, (MemberAssignment)y), 
					MemberBindingType.MemberBinding => EqualsMemberMemberBinding((MemberMemberBinding)x, (MemberMemberBinding)y), 
					MemberBindingType.ListBinding => EqualsMemberListBinding((MemberListBinding)x, (MemberListBinding)y), 
					_ => throw new ArgumentOutOfRangeException("x"), 
				};
			}
			return false;
		}

		private bool EqualsMember(MemberExpression x, MemberExpression y)
		{
			if (x.Member == y.Member)
			{
				return Equals(x.Expression, y.Expression);
			}
			return false;
		}

		private bool EqualsMemberInit(MemberInitExpression x, MemberInitExpression y)
		{
			if (EqualsNew(x.NewExpression, y.NewExpression))
			{
				return Equals(x.Bindings, y.Bindings, EqualsMemberBinding);
			}
			return false;
		}

		private bool EqualsMemberListBinding(MemberListBinding x, MemberListBinding y)
		{
			return Equals(x.Initializers, y.Initializers, EqualsElementInit);
		}

		private bool EqualsMemberMemberBinding(MemberMemberBinding x, MemberMemberBinding y)
		{
			return Equals(x.Bindings, y.Bindings, EqualsMemberBinding);
		}

		private bool EqualsMethodCall(MethodCallExpression x, MethodCallExpression y)
		{
			if (x.Method == y.Method && Equals(x.Object, y.Object))
			{
				return Equals(x.Arguments, y.Arguments, Equals);
			}
			return false;
		}

		private bool EqualsNewArray(NewArrayExpression x, NewArrayExpression y)
		{
			if (x.Type == y.Type)
			{
				return Equals(x.Expressions, y.Expressions, Equals);
			}
			return false;
		}

		private bool EqualsNew(NewExpression x, NewExpression y)
		{
			if (x.Constructor == y.Constructor)
			{
				return Equals(x.Arguments, y.Arguments, Equals);
			}
			return false;
		}

		private bool EqualsParameter(ParameterExpression x, ParameterExpression y)
		{
			return x.Type == y.Type;
		}

		private bool EqualsTypeBinary(TypeBinaryExpression x, TypeBinaryExpression y)
		{
			if (x.TypeOperand == y.TypeOperand)
			{
				return Equals(x.Expression, y.Expression);
			}
			return false;
		}

		private bool EqualsUnary(UnaryExpression x, UnaryExpression y)
		{
			if (x.Method == y.Method)
			{
				return Equals(x.Operand, y.Operand);
			}
			return false;
		}

		private bool EqualsExtension(Expression x, Expression y)
		{
			if (x.IsMatch(out Match match) && y.IsMatch(out Match match2))
			{
				return object.Equals(match, match2);
			}
			return false;
		}
	}
}
