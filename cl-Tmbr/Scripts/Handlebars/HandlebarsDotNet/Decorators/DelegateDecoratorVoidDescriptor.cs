using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Decorators
{
	public sealed class DelegateDecoratorVoidDescriptor : IDecoratorDescriptor<DecoratorOptions>, IDecoratorDescriptor, IDescriptor<DecoratorOptions>
	{
		private readonly HandlebarsDecoratorVoid _helper;

		public PathInfo Name { get; }

		public DelegateDecoratorVoidDescriptor(string name, HandlebarsDecoratorVoid helper)
		{
			_helper = helper;
			Name = name;
		}

		public TemplateDelegate Invoke(in TemplateDelegate function, in DecoratorOptions options, in Context context, in Arguments arguments)
		{
			_helper(function, in options, in context, in arguments);
			return function;
		}

		TemplateDelegate IDecoratorDescriptor<DecoratorOptions>.Invoke(in TemplateDelegate function, in DecoratorOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in function, in options, in context, in arguments);
		}
	}
}
