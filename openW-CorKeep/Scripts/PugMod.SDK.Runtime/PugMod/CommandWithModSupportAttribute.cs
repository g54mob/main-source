using System.Runtime.CompilerServices;
using QFSW.QC;

namespace PugMod
{
	public class CommandWithModSupportAttribute : CommandAttribute
	{
		public CommandWithModSupportAttribute([CallerMemberName] string aliasOverride = "", string description = "", Platform supportedPlatforms = Platform.AllPlatforms, MonoTargetType targetType = MonoTargetType.Single, uint paramsInGlobalSuggestions = 0u)
			: base(aliasOverride, description, supportedPlatforms, targetType, paramsInGlobalSuggestions)
		{
		}
	}
}
