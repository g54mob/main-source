using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Decorators
{
	public sealed class EmptyDecorator : IDecoratorDescriptor<DecoratorOptions>, IDecoratorDescriptor, IDescriptor<DecoratorOptions>
	{
		public PathInfo Name { get; }

		public EmptyDecorator(PathInfo name)
		{
			Name = name;
		}

		public TemplateDelegate Invoke(in TemplateDelegate function, in DecoratorOptions options, in Context context, in Arguments arguments)
		{
			return function;
		}

		TemplateDelegate IDecoratorDescriptor<DecoratorOptions>.Invoke(in TemplateDelegate function, in DecoratorOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in function, in options, in context, in arguments);
		}
	}
}
