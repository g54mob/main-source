using System;
using System.Collections.Generic;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Compiler.Resolvers;
using HandlebarsDotNet.Decorators;
using HandlebarsDotNet.Features;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.IO;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet
{
	public interface ICompiledHandlebarsConfiguration : IHandlebarsTemplateRegistrations
	{
		HandlebarsConfiguration UnderlingConfiguration { get; }

		IExpressionNameResolver ExpressionNameResolver { get; }

		ITextEncoder TextEncoder { get; }

		IFormatProvider FormatProvider { get; }

		ObservableList<IFormatterProvider> FormatterProviders { get; }

		bool ThrowOnUnresolvedBindingExpression { get; }

		IPartialTemplateResolver PartialTemplateResolver { get; }

		IMissingPartialTemplateHandler MissingPartialTemplateHandler { get; }

		short PartialRecursionDepthLimit { get; }

		IIndexed<PathInfoLight, Ref<IHelperDescriptor<HelperOptions>>> Helpers { get; }

		IIndexed<PathInfoLight, Ref<IHelperDescriptor<BlockHelperOptions>>> BlockHelpers { get; }

		IIndexed<PathInfoLight, Ref<IDecoratorDescriptor<DecoratorOptions>>> Decorators { get; }

		IIndexed<PathInfoLight, Ref<IDecoratorDescriptor<BlockDecoratorOptions>>> BlockDecorators { get; }

		IAppendOnlyList<IHelperResolver> HelperResolvers { get; }

		Compatibility Compatibility { get; }

		ObservableList<IObjectDescriptorProvider> ObjectDescriptorProviders { get; }

		IAppendOnlyList<IExpressionMiddleware> ExpressionMiddlewares { get; }

		IAppendOnlyList<IMemberAliasProvider> AliasProviders { get; }

		IExpressionCompiler ExpressionCompiler { get; set; }

		IReadOnlyList<IFeature> Features { get; }

		bool NoEscape { get; }
	}
}
