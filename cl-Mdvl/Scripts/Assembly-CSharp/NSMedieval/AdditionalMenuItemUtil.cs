using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.UI.Utils;

namespace NSMedieval
{
	public static class AdditionalMenuItemUtil
	{
		public static string GenerateSkillInfo(string skillName, int skillValue)
		{
			return string.Format("{0} {1} {2}", AssetUtils.GetSpriteAsset(skillName), MonoSingleton<LocalizationController>.Instance.GetText("skill_name_" + skillName), skillValue);
		}
	}
}
