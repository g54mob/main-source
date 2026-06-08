using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet.Helpers.BlockHelpers
{
	public sealed class WithBlockHelperDescriptor : IHelperDescriptor<BlockHelperOptions>, IHelperDescriptor, IDescriptor<BlockHelperOptions>
	{
		public PathInfo Name { get; } = "with";

		public object Invoke(in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			return this.ReturnInvoke(in options, in context, in arguments);
		}

		public void Invoke(in EncodedTextWriter output, in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			if (arguments.Length != 1)
			{
				throw new HandlebarsException("{{with}} helper must have exactly one argument");
			}
			if (!HandlebarsUtils.IsTruthyOrNonEmpty(arguments[0]))
			{
				options.Inverse(in output, in context);
				return;
			}
			using BindingContext bindingContext = options.CreateFrame(arguments[0]);
			BlockParamsValues blockParamsValues = bindingContext.BlockParams(options.BlockVariables);
			blockParamsValues[0] = arguments[0];
			options.Template(in output, bindingContext);
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
