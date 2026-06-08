using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Helpers.BlockHelpers
{
	public sealed class DelegateBlockHelperDescriptor : IHelperDescriptor<BlockHelperOptions>, IHelperDescriptor, IDescriptor<BlockHelperOptions>
	{
		private readonly HandlebarsBlockHelper _helper;

		public PathInfo Name { get; }

		public DelegateBlockHelperDescriptor(string name, HandlebarsBlockHelper helper)
		{
			_helper = helper;
			Name = name;
		}

		public object Invoke(in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			return this.ReturnInvoke(in options, in context, in arguments);
		}

		public void Invoke(in EncodedTextWriter output, in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			_helper(output, options, context, arguments);
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
