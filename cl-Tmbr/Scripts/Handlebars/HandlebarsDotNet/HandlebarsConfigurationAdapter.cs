using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Compiler.Middlewares;
using HandlebarsDotNet.Compiler.Resolvers;
using HandlebarsDotNet.Decorators;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.Features;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.IO;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet
{
	internal class HandlebarsConfigurationAdapter : ICompiledHandlebarsConfiguration, IHandlebarsTemplateRegistrations
	{
		private readonly List<object> _observers = new List<object>();

		public HandlebarsConfiguration UnderlingConfiguration { get; }

		public IExpressionNameResolver ExpressionNameResolver => UnderlingConfiguration.ExpressionNameResolver;

		public ITextEncoder TextEncoder => UnderlingConfiguration.TextEncoder;

		public IFormatProvider FormatProvider => UnderlingConfiguration.FormatProvider;

		public ViewEngineFileSystem FileSystem => UnderlingConfiguration.FileSystem;

		public ObservableList<IFormatterProvider> FormatterProviders { get; }

		public bool ThrowOnUnresolvedBindingExpression => UnderlingConfiguration.ThrowOnUnresolvedBindingExpression;

		public IPartialTemplateResolver PartialTemplateResolver => UnderlingConfiguration.PartialTemplateResolver;

		public IMissingPartialTemplateHandler MissingPartialTemplateHandler => UnderlingConfiguration.MissingPartialTemplateHandler;

		public short PartialRecursionDepthLimit => UnderlingConfiguration.PartialRecursionDepthLimit;

		public Compatibility Compatibility => UnderlingConfiguration.Compatibility;

		public bool NoEscape => UnderlingConfiguration.NoEscape;

		public ObservableList<IObjectDescriptorProvider> ObjectDescriptorProviders { get; }

		public IAppendOnlyList<IExpressionMiddleware> ExpressionMiddlewares { get; }

		public IAppendOnlyList<IMemberAliasProvider> AliasProviders { get; }

		public IExpressionCompiler ExpressionCompiler { get; set; }

		public IReadOnlyList<IFeature> Features { get; }

		public IIndexed<PathInfoLight, Ref<IHelperDescriptor<HelperOptions>>> Helpers { get; }

		public IIndexed<PathInfoLight, Ref<IHelperDescriptor<BlockHelperOptions>>> BlockHelpers { get; }

		public IIndexed<PathInfoLight, Ref<IDecoratorDescriptor<DecoratorOptions>>> Decorators { get; }

		public IIndexed<PathInfoLight, Ref<IDecoratorDescriptor<BlockDecoratorOptions>>> BlockDecorators { get; }

		public IAppendOnlyList<IHelperResolver> HelperResolvers { get; }

		public IIndexed<string, HandlebarsTemplate<TextWriter, object, object>> RegisteredTemplates { get; }

		public HandlebarsConfigurationAdapter(HandlebarsConfiguration configuration)
		{
			UnderlingConfiguration = configuration;
			HelperResolvers = new ObservableList<IHelperResolver>(configuration.HelperResolvers);
			RegisteredTemplates = new ObservableIndex<string, HandlebarsTemplate<TextWriter, object, object>, StringEqualityComparer>(new StringEqualityComparer(StringComparison.OrdinalIgnoreCase), configuration.RegisteredTemplates);
			AliasProviders = new ObservableList<IMemberAliasProvider>(configuration.AliasProviders);
			FormatterProviders = new ObservableList<IFormatterProvider>
			{
				new DefaultFormatterProvider(),
				new CollectionFormatterProvider(),
				new ReadOnlyCollectionFormatterProvider()
			}.AddMany(configuration.FormatterProviders);
			configuration.FormatterProviders.Subscribe(FormatterProviders);
			ObjectDescriptorProviders = CreateObjectDescriptorProvider(UnderlingConfiguration.ObjectDescriptorProviders);
			ExpressionMiddlewares = new ObservableList<IExpressionMiddleware>(configuration.CompileTimeConfiguration.ExpressionMiddleware)
			{
				new ClosureExpressionMiddleware(),
				new ExpressionOptimizerMiddleware()
			};
			Features = (from o in UnderlingConfiguration.CompileTimeConfiguration.Features
				select o.CreateFeature() into o
				orderby o.GetType().GetTypeInfo().GetCustomAttribute<FeatureOrderAttribute>()?.Order ?? 100
				select o).ToList();
			Helpers = CreateHelpersSubscription<IHelperDescriptor<HelperOptions>, HelperOptions>(configuration.Helpers);
			BlockHelpers = CreateHelpersSubscription<IHelperDescriptor<BlockHelperOptions>, BlockHelperOptions>(configuration.BlockHelpers);
			Decorators = CreateHelpersSubscription<IDecoratorDescriptor<DecoratorOptions>, DecoratorOptions>(configuration.Decorators);
			BlockDecorators = CreateHelpersSubscription<IDecoratorDescriptor<BlockDecoratorOptions>, BlockDecoratorOptions>(configuration.BlockDecorators);
		}

		private ObservableIndex<PathInfoLight, Ref<TDescriptor>, PathInfoLight.PathInfoLightEqualityComparer> CreateHelpersSubscription<TDescriptor, TOptions>(IIndexed<string, TDescriptor> source) where TDescriptor : class, IDescriptor<TOptions> where TOptions : struct, IOptions
		{
			PathInfoLight.PathInfoLightEqualityComparer comparer = (Compatibility.RelaxedHelperNaming ? PathInfoLight.PlainPathComparer : PathInfoLight.PlainPathWithPartsCountComparer);
			IIndexed<PathInfoLight, Ref<TDescriptor>> outer = ((IEnumerable<KeyValuePair<string, TDescriptor>>)source).ToIndexed((Func<KeyValuePair<string, TDescriptor>, PathInfoLight>)((KeyValuePair<string, TDescriptor> o) => "[" + o.Key + "]"), (Func<KeyValuePair<string, TDescriptor>, Ref<TDescriptor>>)((KeyValuePair<string, TDescriptor> o) => new Ref<TDescriptor>(o.Value)), comparer);
			ObservableIndex<PathInfoLight, Ref<TDescriptor>, PathInfoLight.PathInfoLightEqualityComparer> observableIndex = new ObservableIndex<PathInfoLight, Ref<TDescriptor>, PathInfoLight.PathInfoLightEqualityComparer>(comparer, outer);
			IObserver<ObservableEvent<TDescriptor>> observer = ObserverBuilder<ObservableEvent<TDescriptor>>.Create(observableIndex).OnEvent(delegate(DictionaryAddedObservableEvent<string, TDescriptor> @event, ObservableIndex<PathInfoLight, Ref<TDescriptor>, PathInfoLight.PathInfoLightEqualityComparer> state)
			{
				PathInfoLight key = "[" + @event.Key + "]";
				if (state.TryGetValue(in key, out var value))
				{
					value.Value = @event.Value;
				}
				else
				{
					state.AddOrReplace(in key, new Ref<TDescriptor>(@event.Value));
				}
			}).Build();
			_observers.Add(observer);
			ObservableIndex<string, TDescriptor, StringEqualityComparer> observableIndex2 = source.As<ObservableIndex<string, TDescriptor, StringEqualityComparer>>();
			if (observableIndex2 != null)
			{
				observableIndex2.Subscribe(observer);
				return observableIndex;
			}
			return observableIndex;
		}

		private ObservableList<IObjectDescriptorProvider> CreateObjectDescriptorProvider(ObservableList<IObjectDescriptorProvider> descriptorProviders)
		{
			ObjectDescriptorProvider objectDescriptorProvider = new ObjectDescriptorProvider(AliasProviders);
			ObservableList<IObjectDescriptorProvider> observableList = new ObservableList<IObjectDescriptorProvider>
			{
				objectDescriptorProvider,
				new DynamicObjectDescriptor(objectDescriptorProvider),
				new EnumerableObjectDescriptor(objectDescriptorProvider),
				new DictionaryObjectDescriptor(),
				new ReadOnlyGenericDictionaryObjectDescriptorProvider(),
				new GenericDictionaryObjectDescriptorProvider(),
				new ReadOnlyStringDictionaryObjectDescriptorProvider(),
				new StringDictionaryObjectDescriptorProvider(),
				new LayoutViewModel.DescriptorProvider()
			}.AddMany(descriptorProviders);
			descriptorProviders.Subscribe(observableList);
			return observableList;
		}
	}
}
