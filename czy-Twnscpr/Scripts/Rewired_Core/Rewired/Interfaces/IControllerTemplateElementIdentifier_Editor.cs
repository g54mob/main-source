namespace Rewired.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IControllerTemplateElementIdentifier_Editor : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier
	{
		string scriptingName { get; }

		string alternateScriptingName { get; }
	}
}
