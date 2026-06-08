namespace HandlebarsDotNet.Compiler
{
	public delegate TemplateDelegate DecoratorDelegate(in EncodedTextWriter writer, BindingContext context, TemplateDelegate function);
}
