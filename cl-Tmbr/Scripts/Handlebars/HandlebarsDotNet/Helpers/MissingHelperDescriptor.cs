using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Helpers
{
	public sealed class MissingHelperDescriptor : IHelperDescriptor<HelperOptions>, IHelperDescriptor, IDescriptor<HelperOptions>
	{
		public PathInfo Name { get; } = "helperMissing";

		public object Invoke(in HelperOptions options, in Context context, in Arguments arguments)
		{
			if (arguments.Length > 0)
			{
				throw new HandlebarsRuntimeException($"Template references a helper that cannot be resolved. Helper '{options.Name}'");
			}
			return UndefinedBindingResult.Create(options.Name);
		}

		public void Invoke(in EncodedTextWriter output, in HelperOptions options, in Context context, in Arguments arguments)
		{
			output.Write(Invoke(in options, in context, in arguments));
		}

		object IHelperDescriptor<HelperOptions>.Invoke(in HelperOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in options, in context, in arguments);
		}

		void IHelperDescriptor<HelperOptions>.Invoke(in EncodedTextWriter output, in HelperOptions options, in Context context, in Arguments arguments)
		{
			Invoke(in output, in options, in context, in arguments);
		}
	}
}
