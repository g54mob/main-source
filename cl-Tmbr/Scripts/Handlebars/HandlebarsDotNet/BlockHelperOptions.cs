using System.Runtime.CompilerServices;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.IO;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet
{
	public readonly struct BlockHelperOptions : IHelperOptions, IOptions
	{
		internal readonly TemplateDelegate OriginalTemplate;

		internal readonly TemplateDelegate OriginalInverse;

		public readonly ChainSegment[] BlockVariables;

		public BindingContext Frame { get; }

		public DataValues Data => new DataValues(Frame);

		public PathInfo Name { get; }

		internal BlockHelperOptions(PathInfo name, TemplateDelegate template, TemplateDelegate inverse, ChainSegment[] blockParamsValues, BindingContext frame)
		{
			Name = name;
			OriginalTemplate = template;
			OriginalInverse = inverse;
			Frame = frame;
			BlockVariables = blockParamsValues;
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string Inverse()
		{
			using ReusableStringWriter writer = ReusableStringWriter.Get();
			using EncodedTextWriter writer2 = new EncodedTextWriter(writer, Frame.Configuration.TextEncoder, FormatterProvider.Current);
			OriginalInverse(in writer2, Frame);
			return writer2.ToString();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Inverse(in EncodedTextWriter writer, object context)
		{
			if (context is BindingContext context2)
			{
				OriginalInverse(in writer, context2);
				return;
			}
			using BindingContext context3 = Frame.CreateFrame(context);
			OriginalInverse(in writer, context3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Inverse(in EncodedTextWriter writer, in Context context)
		{
			Inverse(in writer, context.Value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Inverse(in EncodedTextWriter writer, BindingContext context)
		{
			OriginalInverse(in writer, context);
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
	}
}
