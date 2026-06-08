using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Decorators
{
	public sealed class DelegateBlockDecoratorVoidDescriptor : IDecoratorDescriptor<BlockDecoratorOptions>, IDecoratorDescriptor, IDescriptor<BlockDecoratorOptions>
	{
		private readonly HandlebarsBlockDecoratorVoid _helper;

		public PathInfo Name { get; }

		public DelegateBlockDecoratorVoidDescriptor(string name, HandlebarsBlockDecoratorVoid helper)
		{
			_helper = helper;
			Name = name;
		}

		public TemplateDelegate Invoke(in TemplateDelegate function, in BlockDecoratorOptions options, in Context context, in Arguments arguments)
		{
			_helper(function, in options, in context, in arguments);
			return function;
		}

		TemplateDelegate IDecoratorDescriptor<BlockDecoratorOptions>.Invoke(in TemplateDelegate function, in BlockDecoratorOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in function, in options, in context, in arguments);
		}
	}
}
