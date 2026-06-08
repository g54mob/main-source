using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Expressions.Shortcuts
{
	internal class ParameterReplacerVisitor : ExpressionVisitor
	{
		private readonly ICollection<Expression> _replacements;

		private readonly bool _addIfMiss;

		public ParameterReplacerVisitor(IEnumerable<Expression> replacements, bool addIfMiss = false)
		{
			_replacements = replacements.Where((Expression o) => o != null).ToList();
			_addIfMiss = addIfMiss;
		}

		protected override Expression VisitParameter(ParameterExpression node)
		{
			Expression expression = _replacements.FirstOrDefault((Expression o) => o?.Type == node.Type);
			if (expression == null || expression == node)
			{
				if (_addIfMiss)
				{
					_replacements.Add(node);
				}
				return base.VisitParameter(node);
			}
			return base.Visit(expression);
		}
	}
}
