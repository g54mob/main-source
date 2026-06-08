using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Helpers
{
	public sealed class LookupReturnHelperDescriptor : IHelperDescriptor<HelperOptions>, IHelperDescriptor, IDescriptor<HelperOptions>
	{
		public PathInfo Name { get; } = "lookup";

		public object Invoke(in HelperOptions options, in Context context, in Arguments arguments)
		{
			if (arguments.Length != 2 && arguments.Length != 3)
			{
				throw new HandlebarsException("{{lookup}} helper must have two or three arguments");
			}
			ChainSegment chainSegment = ChainSegment.Create(arguments[1]);
			if (options.TryAccessMember(arguments[0], chainSegment, out var value))
			{
				return value;
			}
			if (arguments.Length != 3)
			{
				return UndefinedBindingResult.Create(chainSegment);
			}
			return arguments[2];
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
