namespace Rewired.Interfaces
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IControllerTemplateElementIdentifier_Editor : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier
	{
		string scriptingName { get; }

		string alternateScriptingName { get; }
	}
}
