namespace HandlebarsDotNet
{
	public interface IPartialTemplateResolver
	{
		bool TryRegisterPartial(IHandlebars env, string partialName, string templatePath);
	}
}
