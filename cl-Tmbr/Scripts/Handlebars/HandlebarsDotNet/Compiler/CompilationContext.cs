using System.Linq.Expressions;
using Expressions.Shortcuts;

namespace HandlebarsDotNet.Compiler
{
	public sealed class CompilationContext
	{
		internal readonly struct CompilationContextArgs
		{
			public ExpressionContainer<BindingContext> BindingContext { get; }

			public ExpressionContainer<EncodedTextWriter> EncodedWriter { get; }

			public CompilationContextArgs(CompilationContext context)
			{
				BindingContext = new ExpressionContainer<BindingContext>(context.BindingContext);
				EncodedWriter = new ExpressionContainer<EncodedTextWriter>(context.EncodedWriter);
			}
		}

		public ICompiledHandlebarsConfiguration Configuration { get; }

		public ParameterExpression BindingContext { get; }

		public ParameterExpression EncodedWriter { get; }

		internal CompilationContextArgs Args { get; }

		public CompilationContext(ICompiledHandlebarsConfiguration configuration)
		{
			Configuration = configuration;
			BindingContext = Expression.Parameter(typeof(BindingContext), "context");
			EncodedWriter = Expression.Parameter(typeof(EncodedTextWriter).MakeByRefType(), "writer");
			Args = new CompilationContextArgs(this);
		}

		public CompilationContext(CompilationContext context)
		{
			Configuration = context.Configuration;
			BindingContext = Expression.Parameter(typeof(BindingContext), "context");
			EncodedWriter = Expression.Parameter(typeof(EncodedTextWriter).MakeByRefType(), "writer");
			Args = new CompilationContextArgs(this);
		}
	}
}
