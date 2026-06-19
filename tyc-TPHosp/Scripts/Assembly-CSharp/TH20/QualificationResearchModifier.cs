using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class QualificationResearchModifier : QualificationBaseModifier
	{
		public override string Description()
		{
			return ScriptLocalization.Character_Modifiers.Research_Description_CS.Replace("{[PERCENT]}", StringUtils.FormatPercentageValue(_modifier, prefixPlus: true));
		}
	}
}
