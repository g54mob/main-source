using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Decorators
{
	public sealed class EmptyBlockDecorator : IDecoratorDescriptor<BlockDecoratorOptions>, IDecoratorDescriptor, IDescriptor<BlockDecoratorOptions>
	{
		public PathInfo Name { get; }

		public EmptyBlockDecorator(PathInfo name)
		{
			Name = name;
		}

		public TemplateDelegate Invoke(in TemplateDelegate function, in BlockDecoratorOptions options, in Context context, in Arguments arguments)
		{
			return function;
		}

		TemplateDelegate IDecoratorDescriptor<BlockDecoratorOptions>.Invoke(in TemplateDelegate function, in BlockDecoratorOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in function, in options, in context, in arguments);
		}
	}
}
