using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Helpers
{
	public sealed class DelegateHelperDescriptor : IHelperDescriptor<HelperOptions>, IHelperDescriptor, IDescriptor<HelperOptions>
	{
		private readonly HandlebarsHelper _helper;

		public PathInfo Name { get; }

		public DelegateHelperDescriptor(string name, HandlebarsHelper helper)
		{
			_helper = helper;
			Name = name;
		}

		public object Invoke(in HelperOptions options, in Context context, in Arguments arguments)
		{
			return this.ReturnInvoke(in options, in context, in arguments);
		}

		public void Invoke(in EncodedTextWriter output, in HelperOptions options, in Context context, in Arguments arguments)
		{
			_helper(output, context, arguments);
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
