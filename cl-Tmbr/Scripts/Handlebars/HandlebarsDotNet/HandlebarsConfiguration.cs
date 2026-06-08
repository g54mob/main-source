using System;
using System.Globalization;
using System.IO;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Compiler.Resolvers;
using HandlebarsDotNet.Decorators;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.IO;
using HandlebarsDotNet.ObjectDescriptors;

namespace HandlebarsDotNet
{
	public sealed class HandlebarsConfiguration : IHandlebarsTemplateRegistrations
	{
		private readonly UndefinedFormatter _undefinedFormatter = new UndefinedFormatter();

		public IIndexed<string, IHelperDescriptor<HelperOptions>> Helpers { get; }

		public IIndexed<string, IHelperDescriptor<BlockHelperOptions>> BlockHelpers { get; }

		public IIndexed<string, IDecoratorDescriptor<DecoratorOptions>> Decorators { get; }

		public IIndexed<string, IDecoratorDescriptor<BlockDecoratorOptions>> BlockDecorators { get; }

		public IIndexed<string, HandlebarsTemplate<TextWriter, object, object>> RegisteredTemplates { get; }

		public IAppendOnlyList<IHelperResolver> HelperResolvers { get; }

		public IExpressionNameResolver ExpressionNameResolver { get; set; }

		public ITextEncoder TextEncoder { get; set; }

		public IFormatProvider FormatProvider { get; set; } = CultureInfo.CurrentCulture;

		public ViewEngineFileSystem FileSystem { get; set; }

		[Obsolete("Register custom formatters using `Formatters` property")]
		public string UnresolvedBindingFormatter
		{
			get
			{
				return _undefinedFormatter.FormatString;
			}
			set
			{
				_undefinedFormatter.FormatString = value;
			}
		}

		public bool ThrowOnUnresolvedBindingExpression { get; set; }

		public bool NoEscape { get; set; }

		public IPartialTemplateResolver PartialTemplateResolver { get; set; } = new FileSystemPartialTemplateResolver();

		public IMissingPartialTemplateHandler MissingPartialTemplateHandler { get; set; }

		public short PartialRecursionDepthLimit { get; set; } = 100;

		public IAppendOnlyList<IMemberAliasProvider> AliasProviders { get; } = new ObservableList<IMemberAliasProvider>();

		public Compatibility Compatibility { get; } = new Compatibility();

		public CompileTimeConfiguration CompileTimeConfiguration { get; } = new CompileTimeConfiguration();

		public ObservableList<IFormatterProvider> FormatterProviders { get; } = new ObservableList<IFormatterProvider>();

		public ObservableList<IObjectDescriptorProvider> ObjectDescriptorProviders { get; } = new ObservableList<IObjectDescriptorProvider>();

		public HandlebarsConfiguration()
		{
			StringEqualityComparer comparer = new StringEqualityComparer(StringComparison.OrdinalIgnoreCase);
			Helpers = new ObservableIndex<string, IHelperDescriptor<HelperOptions>, StringEqualityComparer>(comparer);
			BlockHelpers = new ObservableIndex<string, IHelperDescriptor<BlockHelperOptions>, StringEqualityComparer>(comparer);
			Decorators = new ObservableIndex<string, IDecoratorDescriptor<DecoratorOptions>, StringEqualityComparer>(comparer);
			BlockDecorators = new ObservableIndex<string, IDecoratorDescriptor<BlockDecoratorOptions>, StringEqualityComparer>(comparer);
			RegisteredTemplates = new ObservableIndex<string, HandlebarsTemplate<TextWriter, object, object>, StringEqualityComparer>(comparer);
			HelperResolvers = new ObservableList<IHelperResolver>();
			TextEncoder = new HtmlEncoderLegacy();
			FormatterProviders.Add(_undefinedFormatter);
		}
	}
}
