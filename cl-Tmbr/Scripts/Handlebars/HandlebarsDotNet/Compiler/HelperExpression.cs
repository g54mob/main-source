using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class HelperExpression : HandlebarsExpression
	{
		public override ExpressionType NodeType => (ExpressionType)6003;

		public override Type Type => typeof(void);

		public string HelperName { get; }

		public bool IsRaw { get; }

		public bool IsBlock { get; set; }

		public IEnumerable<Expression> Arguments { get; }

		public IReaderContext Context { get; }

		public HelperExpression(string helperName, bool isBlock, IEnumerable<Expression> arguments, bool isRaw = false, IReaderContext context = null)
			: this(helperName, isBlock, isRaw)
		{
			Arguments = arguments;
			Context = context;
			IsBlock = isBlock;
		}

		public HelperExpression(string helperName, bool isBlock, bool isRaw = false, IReaderContext context = null)
		{
			HelperName = helperName;
			IsRaw = isRaw;
			Arguments = Enumerable.Empty<Expression>();
			Context = context;
			IsBlock = isBlock;
		}
	}
}
