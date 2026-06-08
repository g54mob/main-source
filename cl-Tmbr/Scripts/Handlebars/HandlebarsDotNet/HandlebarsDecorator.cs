using HandlebarsDotNet.Compiler;

namespace HandlebarsDotNet
{
	public delegate TemplateDelegate HandlebarsDecorator(TemplateDelegate function, in DecoratorOptions options, in Context context, in Arguments arguments);
}
