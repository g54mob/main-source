using System.Runtime.CompilerServices;
using HandlebarsDotNet.IO;

namespace HandlebarsDotNet.Helpers
{
	public static class HelperExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static object ReturnInvoke<THelperDescriptor, TOptions>(this THelperDescriptor descriptor, in TOptions options, in Context context, in Arguments arguments) where THelperDescriptor : class, IHelperDescriptor<TOptions> where TOptions : struct, IHelperOptions
		{
			ICompiledHandlebarsConfiguration configuration = options.Frame.Configuration;
			using ReusableStringWriter writer = ReusableStringWriter.Get(configuration.FormatProvider);
			using EncodedTextWriter output = new EncodedTextWriter(writer, configuration.TextEncoder, FormatterProvider.Current, configuration.NoEscape);
			descriptor.Invoke(in output, in options, in context, in arguments);
			return output.ToString();
		}
	}
}
