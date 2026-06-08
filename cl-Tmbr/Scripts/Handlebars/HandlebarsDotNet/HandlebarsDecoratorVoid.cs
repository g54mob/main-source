using HandlebarsDotNet.Compiler;

namespace HandlebarsDotNet
{
	public delegate void HandlebarsDecoratorVoid(TemplateDelegate function, in DecoratorOptions options, in Context context, in Arguments arguments);
}
