using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Expressions.Shortcuts;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Decorators;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.Helpers.BlockHelpers;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Polyfills;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler
{
	internal class BlockHelperFunctionBinder : HandlebarsExpressionVisitor
	{
		private readonly List<DecoratorDefinition> _decorators;

		private CompilationContext CompilationContext { get; }

		public BlockHelperFunctionBinder(CompilationContext compilationContext, List<DecoratorDefinition> decorators)
		{
			_decorators = decorators;
			CompilationContext = compilationContext;
		}

		protected override Expression VisitStatementExpression(StatementExpression sex)
		{
			if (!(sex.Body is BlockHelperExpression))
			{
				return sex;
			}
			return Visit(sex.Body);
		}

		protected override Expression VisitBlockHelperExpression(BlockHelperExpression bhex)
		{
			PathInfo orAdd = PathInfoStore.Current.GetOrAdd(bhex.HelperName);
			ExpressionContainer<BindingContext> bindingContext = CompilationContext.Args.BindingContext;
			BlockHelperDirection direction = ((!bhex.IsRaw && !orAdd.IsBlockHelper) ? BlockHelperDirection.Inverse : BlockHelperDirection.Direct);
			if (direction switch
			{
				BlockHelperDirection.Direct => bhex.HelperName.StartsWith("#*"), 
				BlockHelperDirection.Inverse => bhex.HelperName.StartsWith("^*"), 
				_ => throw new ArgumentOutOfRangeException(), 
			})
			{
				_decorators.AddRange(VisitDecoratorBlockExpression(bhex));
				return Expression.Empty();
			}
			IReaderContext readerContext = bhex.Context;
			IReadOnlyList<DecoratorDefinition> directDecorators;
			TemplateDelegate direct = Compile(bhex.Body, out directDecorators);
			IReadOnlyList<DecoratorDefinition> inverseDecorators;
			TemplateDelegate inverse = Compile(bhex.Inversion, out inverseDecorators);
			ExpressionContainer<Arguments> args = FunctionBinderHelpers.CreateArguments(bhex.Arguments, CompilationContext);
			ExpressionContainer<object> context = bindingContext.Property((BindingContext o) => o.Value);
			ExpressionContainer<ChainSegment[]> blockParams = CreateBlockParams();
			IIndexed<PathInfoLight, Ref<IHelperDescriptor<BlockHelperOptions>>> blockHelpers = CompilationContext.Configuration.BlockHelpers;
			if (blockHelpers.TryGetValue((PathInfoLight)orAdd, out var value))
			{
				return BindByRef(orAdd, value);
			}
			IAppendOnlyList<IHelperResolver> helperResolvers = CompilationContext.Configuration.HelperResolvers;
			for (int num = 0; num < helperResolvers.Count; num++)
			{
				if (helperResolvers[num].TryResolveBlockHelper(orAdd, out var helper))
				{
					value = new Ref<IHelperDescriptor<BlockHelperOptions>>(helper);
					blockHelpers.AddOrReplace((PathInfoLight)orAdd, in value);
					return BindByRef(orAdd, value);
				}
			}
			Ref<IHelperDescriptor<BlockHelperOptions>> value2 = new Ref<IHelperDescriptor<BlockHelperOptions>>(new LateBindBlockHelperDescriptor(orAdd));
			blockHelpers.AddOrReplace((PathInfoLight)orAdd, in value2);
			return BindByRef(orAdd, value2);
			unsafe Expression BindByRef(PathInfo name, Ref<IHelperDescriptor<BlockHelperOptions>> helperBox)
			{
				IReadOnlyList<DecoratorDefinition> decorators;
				switch (direction)
				{
				case BlockHelperDirection.Direct:
					if (directDecorators.Count > 0)
					{
						ExpressionContainer<BlockHelperOptions> helperOptions2 = direction switch
						{
							BlockHelperDirection.Direct => ExpressionShortcuts.New(() => new BlockHelperOptions(name, direct, inverse, (ChainSegment[])blockParams, (BindingContext)bindingContext)), 
							BlockHelperDirection.Inverse => ExpressionShortcuts.New(() => new BlockHelperOptions(name, inverse, direct, (ChainSegment[])blockParams, (BindingContext)bindingContext)), 
							_ => throw new HandlebarsCompilerException("Helper referenced with unknown prefix", readerContext), 
						};
						ExpressionContainer<Context> callContext2 = ExpressionShortcuts.New(() => new Context((BindingContext)bindingContext, context));
						ExpressionContainer<EncodedTextWriter> writer2 = CompilationContext.Args.EncodedWriter;
						DecoratorDelegate directDecorator = directDecorators.Compile(CompilationContext);
						TemplateDelegate templateDelegate2 = FunctionBuilder.Compile(new Expression[1] { ExpressionShortcuts.Call(() => helperBox.Value.Invoke(in *(EncodedTextWriter*)(EncodedTextWriter)writer2, in *(BlockHelperOptions*)(BlockHelperOptions)helperOptions2, in *(Context*)(Context)callContext2, in *(Arguments*)(Arguments)args)).Expression }, CompilationContext, out decorators);
						return ExpressionShortcuts.Call(() => directDecorator(in *(EncodedTextWriter*)(EncodedTextWriter)writer2, (BindingContext)bindingContext, templateDelegate2)).Call((TemplateDelegate f) => f(in *(EncodedTextWriter*)(EncodedTextWriter)writer2, (BindingContext)bindingContext));
					}
					break;
				case BlockHelperDirection.Inverse:
					if (inverseDecorators.Count > 0)
					{
						ExpressionContainer<BlockHelperOptions> helperOptions = direction switch
						{
							BlockHelperDirection.Direct => ExpressionShortcuts.New(() => new BlockHelperOptions(name, direct, inverse, (ChainSegment[])blockParams, (BindingContext)bindingContext)), 
							BlockHelperDirection.Inverse => ExpressionShortcuts.New(() => new BlockHelperOptions(name, inverse, direct, (ChainSegment[])blockParams, (BindingContext)bindingContext)), 
							_ => throw new HandlebarsCompilerException("Helper referenced with unknown prefix", readerContext), 
						};
						ExpressionContainer<Context> callContext = ExpressionShortcuts.New(() => new Context((BindingContext)bindingContext, context));
						ExpressionContainer<EncodedTextWriter> writer = CompilationContext.Args.EncodedWriter;
						DecoratorDelegate inverseDecorator = inverseDecorators.Compile(CompilationContext);
						TemplateDelegate templateDelegate = FunctionBuilder.Compile(new Expression[1] { ExpressionShortcuts.Call(() => helperBox.Value.Invoke(in *(EncodedTextWriter*)(EncodedTextWriter)writer, in *(BlockHelperOptions*)(BlockHelperOptions)helperOptions, in *(Context*)(Context)callContext, in *(Arguments*)(Arguments)args)).Expression }, CompilationContext, out decorators);
						return ExpressionShortcuts.Call(() => inverseDecorator(in *(EncodedTextWriter*)(EncodedTextWriter)writer, (BindingContext)bindingContext, templateDelegate)).Call((TemplateDelegate f) => f(in *(EncodedTextWriter*)(EncodedTextWriter)writer, (BindingContext)bindingContext));
					}
					break;
				}
				ExpressionContainer<BlockHelperOptions> helperOptions3 = direction switch
				{
					BlockHelperDirection.Direct => ExpressionShortcuts.New(() => new BlockHelperOptions(name, direct, inverse, (ChainSegment[])blockParams, (BindingContext)bindingContext)), 
					BlockHelperDirection.Inverse => ExpressionShortcuts.New(() => new BlockHelperOptions(name, inverse, direct, (ChainSegment[])blockParams, (BindingContext)bindingContext)), 
					_ => throw new HandlebarsCompilerException("Helper referenced with unknown prefix", readerContext), 
				};
				ExpressionContainer<Context> callContext3 = ExpressionShortcuts.New(() => new Context((BindingContext)bindingContext, context));
				ExpressionContainer<EncodedTextWriter> writer3 = CompilationContext.Args.EncodedWriter;
				return ExpressionShortcuts.Call(() => helperBox.Value.Invoke(in *(EncodedTextWriter*)(EncodedTextWriter)writer3, in *(BlockHelperOptions*)(BlockHelperOptions)helperOptions3, in *(Context*)(Context)callContext3, in *(Arguments*)(Arguments)args));
			}
			TemplateDelegate Compile(Expression expression, out IReadOnlyList<DecoratorDefinition> decorators)
			{
				return FunctionBuilder.Compile(((BlockExpression)expression).Expressions, CompilationContext, out decorators);
			}
			ExpressionContainer<ChainSegment[]> CreateBlockParams()
			{
				ChainSegment[] array = bhex.BlockParams?.BlockParam?.Parameters;
				if (array == null)
				{
					array = ArrayEx.Empty<ChainSegment>();
				}
				return ExpressionShortcuts.Arg(array);
			}
		}

		private IEnumerable<DecoratorDefinition> VisitDecoratorBlockExpression(BlockHelperExpression bhex)
		{
			PathInfo pathInfo = PathInfoStore.Current.GetOrAdd(bhex.HelperName);
			ExpressionContainer<BindingContext> bindingContext = CompilationContext.Args.BindingContext;
			if (((!bhex.IsRaw && !pathInfo.IsBlockHelper) ? 1 : 0) == 1)
			{
				throw new HandlebarsCompilerException("^ is not supported for decorators", bhex.Context);
			}
			IReadOnlyList<DecoratorDefinition> decorators;
			TemplateDelegate direct = Compile(bhex.Body, out decorators);
			for (int index = 0; index < decorators.Count; index++)
			{
				yield return decorators[index];
			}
			ExpressionContainer<Arguments> args = FunctionBinderHelpers.CreateArguments(bhex.Arguments, CompilationContext);
			ExpressionContainer<object> context = bindingContext.Property((BindingContext o) => o.Value);
			ExpressionContainer<ChainSegment[]> blockParams = CreateBlockParams();
			IIndexed<PathInfoLight, Ref<IDecoratorDescriptor<BlockDecoratorOptions>>> blockDecorators = CompilationContext.Configuration.BlockDecorators;
			if (blockDecorators.TryGetValue((PathInfoLight)pathInfo, out var value))
			{
				ExpressionContainer<TemplateDelegate> function;
				Expression decorator = BindDecoratorByRef(pathInfo, value, out function);
				yield return new DecoratorDefinition(decorator, function);
				yield break;
			}
			Ref<IDecoratorDescriptor<BlockDecoratorOptions>> value2 = new Ref<IDecoratorDescriptor<BlockDecoratorOptions>>(new EmptyBlockDecorator(pathInfo));
			blockDecorators.AddOrReplace((PathInfoLight)pathInfo, in value2);
			ExpressionContainer<TemplateDelegate> function2;
			Expression decorator2 = BindDecoratorByRef(pathInfo, value2, out function2);
			yield return new DecoratorDefinition(decorator2, function2);
			unsafe Expression BindDecoratorByRef(PathInfo name, Ref<IDecoratorDescriptor<BlockDecoratorOptions>> helperBox, out ExpressionContainer<TemplateDelegate> reference)
			{
				reference = ExpressionShortcuts.Parameter<TemplateDelegate>();
				ExpressionContainer<TemplateDelegate> f = reference;
				ExpressionContainer<BlockDecoratorOptions> helperOptions = ExpressionShortcuts.New(() => new BlockDecoratorOptions(name, direct, (ChainSegment[])blockParams, (BindingContext)bindingContext));
				ExpressionContainer<Context> callContext = ExpressionShortcuts.New(() => new Context((BindingContext)bindingContext, context));
				return ExpressionShortcuts.Call(() => helperBox.Value.Invoke(in *(TemplateDelegate*)(TemplateDelegate)f, in *(BlockDecoratorOptions*)(BlockDecoratorOptions)helperOptions, in *(Context*)(Context)callContext, in *(Arguments*)(Arguments)args));
			}
			TemplateDelegate Compile(Expression expression, out IReadOnlyList<DecoratorDefinition> decorators2)
			{
				return FunctionBuilder.Compile(((BlockExpression)expression).Expressions, CompilationContext, out decorators2);
			}
			ExpressionContainer<ChainSegment[]> CreateBlockParams()
			{
				ChainSegment[] array = bhex.BlockParams?.BlockParam?.Parameters;
				if (array == null)
				{
					array = ArrayEx.Empty<ChainSegment>();
				}
				return ExpressionShortcuts.Arg(array);
			}
		}
	}
}
