using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Helpers.BlockHelpers
{
	public sealed class DelegateReturnBlockHelperDescriptor : IHelperDescriptor<BlockHelperOptions>, IHelperDescriptor, IDescriptor<BlockHelperOptions>
	{
		private readonly HandlebarsReturnBlockHelper _helper;

		public PathInfo Name { get; }

		public DelegateReturnBlockHelperDescriptor(string name, HandlebarsReturnBlockHelper helper)
		{
			_helper = helper;
			Name = name;
		}

		public object Invoke(in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			return _helper(options, context, arguments);
		}

		public void Invoke(in EncodedTextWriter output, in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			output.Write(_helper(options, context, arguments));
		}

		object IHelperDescriptor<BlockHelperOptions>.Invoke(in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in options, in context, in arguments);
		}

		void IHelperDescriptor<BlockHelperOptions>.Invoke(in EncodedTextWriter output, in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			Invoke(in output, in options, in context, in arguments);
		}
	}
}
