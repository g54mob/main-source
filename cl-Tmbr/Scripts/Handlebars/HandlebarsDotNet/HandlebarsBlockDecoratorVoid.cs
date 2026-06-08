using HandlebarsDotNet.Compiler;

namespace HandlebarsDotNet
{
	public delegate void HandlebarsBlockDecoratorVoid(TemplateDelegate function, in BlockDecoratorOptions options, in Context context, in Arguments arguments);
}
