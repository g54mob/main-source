using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class QualificationDurationModifier : QualificationBaseModifier
	{
		public override string Description()
		{
			return ScriptLocalization.Character_Modifiers.TimeTunnelDuration_Description_CS.Replace("{[PERCENT]}", StringUtils.FormatPercentageValue(_modifier, prefixPlus: true));
		}
	}
}
