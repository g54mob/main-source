using System.Runtime.CompilerServices;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.Decorators;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.IO;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet
{
	public readonly struct BlockDecoratorOptions : IDecoratorOptions, IOptions, IHelpersRegistry
	{
		internal readonly TemplateDelegate OriginalTemplate;

		public readonly ChainSegment[] BlockVariables;

		public BindingContext Frame { get; }

		public DataValues Data => new DataValues(Frame);

		public PathInfo Name { get; }

		internal BlockDecoratorOptions(PathInfo name, TemplateDelegate template, ChainSegment[] blockParamsValues, BindingContext frame)
		{
			Name = name;
			OriginalTemplate = template;
			Frame = frame;
			BlockVariables = blockParamsValues;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BindingContext CreateFrame(object value = null)
		{
			return Frame.CreateFrame(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BindingContext CreateFrame(Context value)
		{
			return Frame.CreateFrame(value.Value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string Template()
		{
			using ReusableStringWriter writer = ReusableStringWriter.Get();
			using EncodedTextWriter writer2 = new EncodedTextWriter(writer, Frame.Configuration.TextEncoder, FormatterProvider.Current);
			OriginalTemplate(in writer2, Frame);
			return writer2.ToString();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Template(in EncodedTextWriter writer, object context)
		{
			if (context is BindingContext context2)
			{
				OriginalTemplate(in writer, context2);
				return;
			}
			using BindingContext context3 = Frame.CreateFrame(context);
			OriginalTemplate(in writer, context3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Template(in EncodedTextWriter writer, in Context context)
		{
			Template(in writer, context.Value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Template(in EncodedTextWriter writer, BindingContext context)
		{
			OriginalTemplate(in writer, context);
		}

		IIndexed<string, IHelperDescriptor<HelperOptions>> IHelpersRegistry.GetHelpers()
		{
			return Frame.Helpers;
		}

		IIndexed<string, IHelperDescriptor<BlockHelperOptions>> IHelpersRegistry.GetBlockHelpers()
		{
			return Frame.BlockHelpers;
		}
	}
}
