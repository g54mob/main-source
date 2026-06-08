using HandlebarsDotNet.Compiler;

namespace HandlebarsDotNet
{
	public delegate TemplateDelegate HandlebarsBlockDecorator(TemplateDelegate function, in BlockDecoratorOptions options, in Context context, in Arguments arguments);
}
