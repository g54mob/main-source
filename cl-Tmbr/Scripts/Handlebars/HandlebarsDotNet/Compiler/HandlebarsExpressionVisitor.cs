using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class HandlebarsExpressionVisitor : ExpressionVisitor
	{
		public override Expression Visit(Expression exp)
		{
			if (exp == null)
			{
				return null;
			}
			return (HandlebarsExpressionType)exp.NodeType switch
			{
				HandlebarsExpressionType.StatementExpression => VisitStatementExpression((StatementExpression)exp), 
				HandlebarsExpressionType.StaticExpression => VisitStaticExpression((StaticExpression)exp), 
				HandlebarsExpressionType.HelperExpression => VisitHelperExpression((HelperExpression)exp), 
				HandlebarsExpressionType.BlockExpression => VisitBlockHelperExpression((BlockHelperExpression)exp), 
				HandlebarsExpressionType.HashParameterAssignmentExpression => exp, 
				HandlebarsExpressionType.HashParametersExpression => VisitHashParametersExpression((HashParametersExpression)exp), 
				HandlebarsExpressionType.PathExpression => VisitPathExpression((PathExpression)exp), 
				HandlebarsExpressionType.IteratorExpression => VisitIteratorExpression((IteratorExpression)exp), 
				HandlebarsExpressionType.PartialExpression => VisitPartialExpression((PartialExpression)exp), 
				HandlebarsExpressionType.BoolishExpression => VisitBoolishExpression((BoolishExpression)exp), 
				HandlebarsExpressionType.SubExpression => VisitSubExpression((SubExpressionExpression)exp), 
				_ => base.Visit(exp), 
			};
		}

		protected virtual Expression VisitStatementExpression(StatementExpression sex)
		{
			Expression expression = Visit(sex.Body);
			if (expression != sex.Body)
			{
				return HandlebarsExpression.Statement(expression, sex.IsEscaped, sex.TrimBefore, sex.TrimAfter);
			}
			return sex;
		}

		protected virtual Expression VisitPathExpression(PathExpression pex)
		{
			return pex;
		}

		protected virtual Expression VisitHelperExpression(HelperExpression hex)
		{
			IEnumerable<Expression> enumerable = VisitExpressionList(hex.Arguments);
			if (!object.Equals(enumerable, hex.Arguments))
			{
				return HandlebarsExpression.Helper(hex.HelperName, hex.IsBlock, enumerable, hex.IsRaw);
			}
			return hex;
		}

		protected virtual Expression VisitBlockHelperExpression(BlockHelperExpression bhex)
		{
			IEnumerable<Expression> enumerable = VisitExpressionList(bhex.Arguments);
			if (enumerable != bhex.Arguments)
			{
				return HandlebarsExpression.BlockHelper(bhex.HelperName, enumerable, bhex.BlockParams, bhex.Body, bhex.Inversion, bhex.IsRaw);
			}
			return bhex;
		}

		protected virtual Expression VisitStaticExpression(StaticExpression stex)
		{
			return stex;
		}

		protected virtual Expression VisitIteratorExpression(IteratorExpression iex)
		{
			Expression expression = Visit(iex.Sequence);
			if (expression != iex.Sequence)
			{
				return HandlebarsExpression.Iterator(iex.HelperName, expression, iex.BlockParams, iex.Template, iex.IfEmpty);
			}
			return iex;
		}

		protected virtual Expression VisitPartialExpression(PartialExpression pex)
		{
			Expression expression = Visit(pex.PartialName);
			Expression expression2 = Visit(pex.Argument);
			if (expression != pex.PartialName || expression2 != pex.Argument)
			{
				return HandlebarsExpression.Partial(expression, expression2, pex.Fallback);
			}
			return pex;
		}

		protected virtual Expression VisitBoolishExpression(BoolishExpression bex)
		{
			Expression expression = Visit(bex.Condition);
			if (expression != bex.Condition)
			{
				return HandlebarsExpression.Boolish(expression);
			}
			return bex;
		}

		protected virtual Expression VisitSubExpression(SubExpressionExpression subex)
		{
			Expression expression = Visit(subex.Expression);
			if (expression != subex.Expression)
			{
				return HandlebarsExpression.SubExpression(expression);
			}
			return subex;
		}

		protected virtual Expression VisitHashParametersExpression(HashParametersExpression hpex)
		{
			Dictionary<string, Expression> dictionary = new Dictionary<string, Expression>();
			bool flag = false;
			foreach (string key in hpex.Parameters.Keys)
			{
				Expression expression = Visit(hpex.Parameters[key]);
				dictionary.Add(key, expression);
				if (expression != hpex.Parameters[key])
				{
					flag = true;
				}
			}
			if (flag)
			{
				return HandlebarsExpression.HashParametersExpression(dictionary);
			}
			return hpex;
		}

		private IEnumerable<Expression> VisitExpressionList(IEnumerable<Expression> original)
		{
			if (original == null)
			{
				return null;
			}
			IReadOnlyList<Expression> readOnlyList = (original as IReadOnlyList<Expression>) ?? original.ToArray();
			List<Expression> list = null;
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				Expression expression = Visit(readOnlyList[i]);
				if (list != null)
				{
					list.Add(expression);
				}
				else if (expression != readOnlyList[i])
				{
					list = new List<Expression>(readOnlyList.Count);
					for (int j = 0; j < i; j++)
					{
						list.Add(readOnlyList[j]);
					}
					list.Add(expression);
				}
			}
			IReadOnlyList<Expression> readOnlyList2 = list?.ToArray();
			return readOnlyList2 ?? readOnlyList;
		}
	}
}
