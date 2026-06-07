namespace Rewired.Interfaces
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal
	{
		new ControllerTemplateElementType elementType { get; }
	}
}
