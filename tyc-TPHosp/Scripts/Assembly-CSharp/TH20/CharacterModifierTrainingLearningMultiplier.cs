using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class CharacterModifierTrainingLearningMultiplier : CharacterModifierMultiplierBase
	{
		public override string Description()
		{
			return LocalisedString.Replace(ScriptLocalization.Character_Modifiers.TrainingLearning_Description_CS, "{[PERCENT]}", StringUtils.FormatPercentageValue(Modifier, prefixPlus: true));
		}
	}
}
