using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Helpers
{
	public sealed class DelegateReturnHelperDescriptor : IHelperDescriptor<HelperOptions>, IHelperDescriptor, IDescriptor<HelperOptions>
	{
		private readonly HandlebarsReturnHelper _helper;

		public PathInfo Name { get; }

		public DelegateReturnHelperDescriptor(string name, HandlebarsReturnHelper helper)
		{
			_helper = helper;
			Name = name;
		}

		public object Invoke(in HelperOptions options, in Context context, in Arguments arguments)
		{
			return _helper(context, arguments);
		}

		public void Invoke(in EncodedTextWriter output, in HelperOptions options, in Context context, in Arguments arguments)
		{
			output.Write(_helper(context, arguments));
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
