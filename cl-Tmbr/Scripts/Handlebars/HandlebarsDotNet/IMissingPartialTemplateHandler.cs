namespace HandlebarsDotNet
{
	public interface IMissingPartialTemplateHandler
	{
		void Handle(ICompiledHandlebarsConfiguration configuration, string partialName, in EncodedTextWriter textWriter);
	}
}
