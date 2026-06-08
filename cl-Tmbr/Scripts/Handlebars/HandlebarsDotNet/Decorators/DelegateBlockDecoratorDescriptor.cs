using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Decorators
{
	public sealed class DelegateBlockDecoratorDescriptor : IDecoratorDescriptor<BlockDecoratorOptions>, IDecoratorDescriptor, IDescriptor<BlockDecoratorOptions>
	{
		private readonly HandlebarsBlockDecorator _helper;

		public PathInfo Name { get; }

		public DelegateBlockDecoratorDescriptor(string name, HandlebarsBlockDecorator helper)
		{
			_helper = helper;
			Name = name;
		}

		public TemplateDelegate Invoke(in TemplateDelegate function, in BlockDecoratorOptions options, in Context context, in Arguments arguments)
		{
			return _helper(function, in options, in context, in arguments);
		}

		TemplateDelegate IDecoratorDescriptor<BlockDecoratorOptions>.Invoke(in TemplateDelegate function, in BlockDecoratorOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in function, in options, in context, in arguments);
		}
	}
}
