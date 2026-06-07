namespace Rewired.Data.Mapping
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IControllerTemplateMapSpecialElement_Internal
	{
		T GetMapping<T>() where T : ControllerTemplateSpecialElementMapping;
	}
}
