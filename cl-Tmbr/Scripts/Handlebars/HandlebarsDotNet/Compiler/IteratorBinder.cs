using System.Collections.Generic;
using System.Linq.Expressions;
using Expressions.Shortcuts;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Polyfills;

namespace HandlebarsDotNet.Compiler
{
	internal class IteratorBinder : HandlebarsExpressionVisitor
	{
		private CompilationContext CompilationContext { get; }

		public IteratorBinder(CompilationContext compilationContext)
		{
			CompilationContext = compilationContext;
		}

		protected unsafe override Expression VisitIteratorExpression(IteratorExpression iex)
		{
			BlockHelperDirection blockHelperDirection = iex.HelperName[0] switch
			{
				'#' => BlockHelperDirection.Direct, 
				'^' => BlockHelperDirection.Inverse, 
				_ => throw new HandlebarsCompilerException("Tried to convert " + iex.HelperName + " expression to iterator block", iex.Context), 
			};
			IReadOnlyList<DecoratorDefinition> decorators;
			TemplateDelegate template = FunctionBuilder.Compile(new Expression[1] { iex.Template }, CompilationContext, out decorators);
			IReadOnlyList<DecoratorDefinition> decorators2;
			TemplateDelegate ifEmpty = FunctionBuilder.Compile(new Expression[1] { iex.IfEmpty }, CompilationContext, out decorators2);
			if (iex.Sequence is PathExpression pathExpression)
			{
				pathExpression.Context = PathExpression.ResolutionContext.Parameter;
			}
			IReadOnlyList<DecoratorDefinition> decorators3;
			switch (blockHelperDirection)
			{
			case BlockHelperDirection.Direct:
			{
				if (decorators.Count > 0)
				{
					ExpressionContainer<BindingContext> context3 = CompilationContext.Args.BindingContext;
					ExpressionContainer<EncodedTextWriter> writer3 = CompilationContext.Args.EncodedWriter;
					ExpressionContainer<object> compiledSequence3 = ExpressionShortcuts.Arg<object>(FunctionBuilder.Reduce(iex.Sequence, CompilationContext, out decorators3));
					ExpressionContainer<ChainSegment[]> blockParamsValues3 = CreateBlockParams();
					TemplateDelegate templateDelegate2 = FunctionBuilder.Compile(new Expression[1] { ExpressionShortcuts.Call(() => Iterator.Iterate((BindingContext)context3, (EncodedTextWriter)writer3, (ChainSegment[])blockParamsValues3, compiledSequence3, template, ifEmpty)).Expression }, CompilationContext, out decorators3);
					DecoratorDelegate decorator2 = decorators.Compile(CompilationContext);
					return ExpressionShortcuts.Call(() => decorator2(in *(EncodedTextWriter*)(EncodedTextWriter)writer3, (BindingContext)context3, templateDelegate2)).Call((TemplateDelegate f) => f(in *(EncodedTextWriter*)(EncodedTextWriter)writer3, (BindingContext)context3));
				}
				ExpressionContainer<BindingContext> context4 = CompilationContext.Args.BindingContext;
				ExpressionContainer<EncodedTextWriter> writer4 = CompilationContext.Args.EncodedWriter;
				ExpressionContainer<object> compiledSequence4 = ExpressionShortcuts.Arg<object>(FunctionBuilder.Reduce(iex.Sequence, CompilationContext, out decorators3));
				ExpressionContainer<ChainSegment[]> blockParamsValues4 = CreateBlockParams();
				return ExpressionShortcuts.Call(() => Iterator.Iterate((BindingContext)context4, (EncodedTextWriter)writer4, (ChainSegment[])blockParamsValues4, compiledSequence4, template, ifEmpty));
			}
			case BlockHelperDirection.Inverse:
			{
				if (decorators2.Count > 0)
				{
					ExpressionContainer<BindingContext> context = CompilationContext.Args.BindingContext;
					ExpressionContainer<EncodedTextWriter> writer = CompilationContext.Args.EncodedWriter;
					ExpressionContainer<object> compiledSequence = ExpressionShortcuts.Arg<object>(FunctionBuilder.Reduce(iex.Sequence, CompilationContext, out decorators3));
					ExpressionContainer<ChainSegment[]> blockParamsValues = CreateBlockParams();
					TemplateDelegate templateDelegate = FunctionBuilder.Compile(new Expression[1] { ExpressionShortcuts.Call(() => Iterator.Iterate((BindingContext)context, (EncodedTextWriter)writer, (ChainSegment[])blockParamsValues, compiledSequence, ifEmpty, template)).Expression }, CompilationContext, out decorators3);
					DecoratorDelegate decorator = decorators2.Compile(CompilationContext);
					return ExpressionShortcuts.Call(() => decorator(in *(EncodedTextWriter*)(EncodedTextWriter)writer, (BindingContext)context, templateDelegate)).Call((TemplateDelegate f) => f(in *(EncodedTextWriter*)(EncodedTextWriter)writer, (BindingContext)context));
				}
				ExpressionContainer<BindingContext> context2 = CompilationContext.Args.BindingContext;
				ExpressionContainer<EncodedTextWriter> writer2 = CompilationContext.Args.EncodedWriter;
				ExpressionContainer<object> compiledSequence2 = ExpressionShortcuts.Arg<object>(FunctionBuilder.Reduce(iex.Sequence, CompilationContext, out decorators3));
				ExpressionContainer<ChainSegment[]> blockParamsValues2 = CreateBlockParams();
				return ExpressionShortcuts.Call(() => Iterator.Iterate((BindingContext)context2, (EncodedTextWriter)writer2, (ChainSegment[])blockParamsValues2, compiledSequence2, ifEmpty, template));
			}
			default:
				throw new HandlebarsCompilerException("Tried to convert " + iex.HelperName + " expression to iterator block", iex.Context);
			}
			ExpressionContainer<ChainSegment[]> CreateBlockParams()
			{
				ChainSegment[] array = iex.BlockParams?.BlockParam?.Parameters;
				if (array == null)
				{
					array = ArrayEx.Empty<ChainSegment>();
				}
				return ExpressionShortcuts.Arg(array);
			}
		}
	}
}
