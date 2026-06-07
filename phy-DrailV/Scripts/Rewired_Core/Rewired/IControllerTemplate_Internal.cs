using Rewired.Internal.Localization;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IControllerTemplate_Internal : IControllerTemplate
	{
		DeviceLocalizationInfo deviceLocalizationInfo { get; }
	}
}
