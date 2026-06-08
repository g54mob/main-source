using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Helpers
{
	public sealed class DelegateReturnHelperWithOptionsDescriptor : IHelperDescriptor<HelperOptions>, IHelperDescriptor, IDescriptor<HelperOptions>
	{
		private readonly HandlebarsReturnWithOptionsHelper _helper;

		public PathInfo Name { get; }

		public DelegateReturnHelperWithOptionsDescriptor(string name, HandlebarsReturnWithOptionsHelper helper)
		{
			_helper = helper;
			Name = name;
		}

		public object Invoke(in HelperOptions options, in Context context, in Arguments arguments)
		{
			return _helper(in options, in context, in arguments);
		}

		public void Invoke(in EncodedTextWriter output, in HelperOptions options, in Context context, in Arguments arguments)
		{
			output.Write(_helper(in options, in context, in arguments));
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
