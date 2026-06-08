using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.MemberAccessors;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet
{
	public sealed class BindingContext : IDisposable, IHelpersRegistry
	{
		private class BindingContextPool : InternalObjectPool<BindingContext, BindingContextPool.BindingContextPolicy>
		{
			[StructLayout(LayoutKind.Sequential, Size = 1)]
			internal struct BindingContextPolicy : IInternalObjectPoolPolicy<BindingContext>
			{
				public BindingContext Create()
				{
					return new BindingContext();
				}

				public bool Return(BindingContext item)
				{
					item.Root = null;
					item.Value = null;
					item.ParentContext = null;
					item.PartialBlockTemplate = null;
					item.InlinePartialTemplates.Clear();
					item.Helpers.Clear();
					item.BlockHelpers.Clear();
					item.Bag.Clear();
					item.BlockParamsObject.OptionalClear();
					item.ContextDataObject.OptionalClear();
					item.Descriptor.Reset();
					return true;
				}
			}

			public BindingContextPool()
				: base(default(BindingContextPolicy))
			{
			}

			public BindingContext CreateContext(ICompiledHandlebarsConfiguration configuration, object value, BindingContext parent, TemplateDelegate partialBlockTemplate)
			{
				BindingContext bindingContext = Get();
				bindingContext.Configuration = configuration;
				bindingContext.Value = value;
				bindingContext.ParentContext = parent;
				bindingContext.PartialBlockTemplate = partialBlockTemplate;
				bindingContext.PartialDepth = parent?.PartialDepth ?? 0;
				bindingContext.Initialize();
				return bindingContext;
			}
		}

		internal readonly EntryIndex<ChainSegment>[] WellKnownVariables = new EntryIndex<ChainSegment>[8];

		internal readonly DeferredValue<BindingContext, ObjectDescriptor> Descriptor;

		private static readonly BindingContextPool Pool = new BindingContextPool();

		internal CascadeIndex<string, object, StringEqualityComparer> Bag { get; }

		internal FixedSizeDictionary<ChainSegment, object, ChainSegment.ChainSegmentEqualityComparer> ContextDataObject { get; }

		internal FixedSizeDictionary<ChainSegment, object, ChainSegment.ChainSegmentEqualityComparer> BlockParamsObject { get; }

		internal ICompiledHandlebarsConfiguration Configuration { get; private set; }

		internal CascadeIndex<string, Action<EncodedTextWriter, BindingContext>, StringEqualityComparer> InlinePartialTemplates { get; }

		internal CascadeIndex<string, IHelperDescriptor<HelperOptions>, StringEqualityComparer> Helpers { get; }

		internal CascadeIndex<string, IHelperDescriptor<BlockHelperOptions>, StringEqualityComparer> BlockHelpers { get; }

		internal TemplateDelegate PartialBlockTemplate { get; set; }

		internal short PartialDepth { get; set; }

		public object Value { get; set; }

		public DataValues Data => new DataValues(this);

		public IIndexed<string, object> Extensions => Bag;

		internal BindingContext ParentContext { get; private set; }

		internal BindingContext Root { get; private set; }

		private BindingContext()
		{
			InlinePartialTemplates = new CascadeIndex<string, Action<EncodedTextWriter, BindingContext>, StringEqualityComparer>(new StringEqualityComparer(StringComparison.OrdinalIgnoreCase));
			Helpers = new CascadeIndex<string, IHelperDescriptor<HelperOptions>, StringEqualityComparer>(default(StringEqualityComparer));
			BlockHelpers = new CascadeIndex<string, IHelperDescriptor<BlockHelperOptions>, StringEqualityComparer>(default(StringEqualityComparer));
			Bag = new CascadeIndex<string, object, StringEqualityComparer>(new StringEqualityComparer(StringComparison.OrdinalIgnoreCase));
			ContextDataObject = new FixedSizeDictionary<ChainSegment, object, ChainSegment.ChainSegmentEqualityComparer>(16, 7, ChainSegment.EqualityComparer);
			BlockParamsObject = new FixedSizeDictionary<ChainSegment, object, ChainSegment.ChainSegmentEqualityComparer>(16, 7, ChainSegment.EqualityComparer);
			Descriptor = new DeferredValue<BindingContext, ObjectDescriptor>(this, (BindingContext context) => ObjectDescriptor.Create(context.Value));
		}

		internal void SetDataObject(object data)
		{
			if (data == null)
			{
				return;
			}
			if (!ObjectDescriptor.TryCreate(data.GetType(), out var descriptor))
			{
				throw new HandlebarsRuntimeException($"Cannot resolve object descriptor for type `{data.GetType()}`");
			}
			ObjectAccessor objectAccessor = new ObjectAccessor(data, descriptor);
			foreach (ChainSegment property in objectAccessor.Properties)
			{
				ChainSegment key = property;
				object value = objectAccessor[key];
				if (key.WellKnownVariable == WellKnownVariable.None)
				{
					ContextDataObject.AddOrReplace(in key, in value, out var _);
				}
				else
				{
					ContextDataObject.AddOrReplace(in key, in value, out WellKnownVariables[(int)key.WellKnownVariable]);
				}
			}
		}

		private void Initialize()
		{
			Root = ParentContext?.Root ?? this;
			ContextDataObject.AddOrReplace(ChainSegment.Root, Root.Value, out WellKnownVariables[5]);
			if (ParentContext == null)
			{
				ContextDataObject.AddOrReplace(ChainSegment.Parent, (object)UndefinedBindingResult.Create(ChainSegment.Parent), out WellKnownVariables[6]);
				return;
			}
			ParentContext.ContextDataObject.CopyTo(ContextDataObject);
			ParentContext.ContextDataObject.AdjustIndexes(ParentContext.WellKnownVariables, ContextDataObject, WellKnownVariables);
			ContextDataObject.AddOrReplace(ChainSegment.Parent, ParentContext.Value, out WellKnownVariables[6]);
			Bag.Outer = ParentContext.Bag;
			ParentContext.BlockParamsObject.CopyTo(BlockParamsObject);
			InlinePartialTemplates.Outer = ParentContext.InlinePartialTemplates;
			Helpers.Outer = ParentContext.Helpers;
			BlockHelpers.Outer = ParentContext.BlockHelpers;
			if (Value is HashParameterDictionary hash && ParentContext.Value != null && Value != ParentContext.Value)
			{
				PopulateHash(hash, ParentContext.Value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BlockParamsValues BlockParams(ChainSegment[] blockParamsVariables)
		{
			return new BlockParamsValues(this, blockParamsVariables);
		}

		internal bool TryGetVariable(ChainSegment segment, out object value)
		{
			if (segment.WellKnownVariable != WellKnownVariable.None)
			{
				EntryIndex<ChainSegment> keyIndex = WellKnownVariables[(int)segment.WellKnownVariable];
				if (!BlockParamsObject.TryGetValue(in keyIndex, out value))
				{
					return Descriptor.Value.MemberAccessor?.TryGetValue(Value, segment, out value) ?? false;
				}
				return true;
			}
			if (!BlockParamsObject.TryGetValue(in segment, out value))
			{
				return Descriptor.Value.MemberAccessor?.TryGetValue(Value, segment, out value) ?? false;
			}
			return true;
		}

		internal bool TryGetContextVariable(ChainSegment segment, out object value)
		{
			if (segment.WellKnownVariable != WellKnownVariable.None)
			{
				EntryIndex<ChainSegment> keyIndex = WellKnownVariables[(int)segment.WellKnownVariable];
				if (!BlockParamsObject.TryGetValue(in segment, out value))
				{
					return ContextDataObject.TryGetValue(in keyIndex, out value);
				}
				return true;
			}
			if (!BlockParamsObject.TryGetValue(in segment, out value))
			{
				return ContextDataObject.TryGetValue(in segment, out value);
			}
			return true;
		}

		internal BindingContext CreateChildContext(object value, TemplateDelegate partialBlockTemplate = null)
		{
			return Create(Configuration, value, this, partialBlockTemplate ?? PartialBlockTemplate);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BindingContext CreateFrame(object value = null)
		{
			return Create(Configuration, value, this, PartialBlockTemplate);
		}

		private static void PopulateHash(HashParameterDictionary hash, object from)
		{
			ObjectDescriptor objectDescriptor = ObjectDescriptor.Create(from);
			if (objectDescriptor == ObjectDescriptor.Empty)
			{
				return;
			}
			IMemberAccessor memberAccessor = objectDescriptor.MemberAccessor;
			IEnumerator enumerator = objectDescriptor.GetProperties(objectDescriptor, from).GetEnumerator();
			while (enumerator.MoveNext())
			{
				ChainSegment chainSegment = ChainSegment.Create(enumerator.Current);
				if (!hash.ContainsKey(chainSegment) && memberAccessor.TryGetValue(from, chainSegment, out var value))
				{
					hash[chainSegment] = value;
				}
			}
		}

		IIndexed<string, IHelperDescriptor<HelperOptions>> IHelpersRegistry.GetHelpers()
		{
			return Helpers;
		}

		IIndexed<string, IHelperDescriptor<BlockHelperOptions>> IHelpersRegistry.GetBlockHelpers()
		{
			return BlockHelpers;
		}

		internal static BindingContext Create(ICompiledHandlebarsConfiguration configuration, object value)
		{
			return Pool.CreateContext(configuration, value, null, null);
		}

		internal static BindingContext Create(ICompiledHandlebarsConfiguration configuration, object value, BindingContext parent, TemplateDelegate partialBlockTemplate)
		{
			return Pool.CreateContext(configuration, value, parent, partialBlockTemplate);
		}

		public void Dispose()
		{
			Pool.Return(this);
		}
	}
}
