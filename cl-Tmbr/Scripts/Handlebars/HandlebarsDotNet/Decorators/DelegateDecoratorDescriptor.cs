using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Decorators
{
	public sealed class DelegateDecoratorDescriptor : IDecoratorDescriptor<DecoratorOptions>, IDecoratorDescriptor, IDescriptor<DecoratorOptions>
	{
		private readonly HandlebarsDecorator _helper;

		public PathInfo Name { get; }

		public DelegateDecoratorDescriptor(string name, HandlebarsDecorator helper)
		{
			_helper = helper;
			Name = name;
		}

		public TemplateDelegate Invoke(in TemplateDelegate function, in DecoratorOptions options, in Context context, in Arguments arguments)
		{
			return _helper(function, in options, in context, in arguments);
		}

		TemplateDelegate IDecoratorDescriptor<DecoratorOptions>.Invoke(in TemplateDelegate function, in DecoratorOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in function, in options, in context, in arguments);
		}
	}
}
