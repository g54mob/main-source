using System.Collections.Generic;

namespace HandlebarsDotNet.Compiler
{
	internal static class DecoratorDefinitionsExtensions
	{
		public static DecoratorDelegate Compile(this IReadOnlyList<DecoratorDefinition> decoratorDefinitions, CompilationContext context)
		{
			DecoratorDelegate decoratorDelegate = decoratorDefinitions[0].Compile(context);
			for (int i = 1; i < decoratorDefinitions.Count; i++)
			{
				DecoratorDelegate f = decoratorDefinitions[i].Compile(context);
				DecoratorDelegate current = decoratorDelegate;
				decoratorDelegate = delegate(in EncodedTextWriter writer, BindingContext bindingContext, TemplateDelegate function)
				{
					return f(in writer, bindingContext, current(in writer, bindingContext, function));
				};
			}
			return decoratorDelegate;
		}
	}
}
