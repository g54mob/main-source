using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class QualificationUpgradeItemModifier : QualificationBaseModifier
	{
		public override string Description()
		{
			return ScriptLocalization.Character_Modifiers.UpgradeItem_Description_CS.Replace("{[PERCENT]}", StringUtils.FormatPercentageValue(_modifier, prefixPlus: true));
		}
	}
}
