using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class QualificationTreatmentModifier : QualificationBaseModifier
	{
		public override string Description()
		{
			if (_validRooms == null || _validRooms.Length == 0)
			{
				return ScriptLocalization.Character_Modifiers.Treatment_Description_CS.Replace("{[PERCENT]}", StringUtils.FormatPercentageValue(_modifier, prefixPlus: true));
			}
			return LocalisedString.Replace(ScriptLocalization.Character_Modifiers.TreatmentRoom_Description_CS, new SubPair[2]
			{
				new SubPair("{[ROOM]}", _validRooms[0].Instance.GetLocalisedName()),
				new SubPair("{[PERCENT]}", StringUtils.FormatPercentageValue(_modifier, prefixPlus: true))
			});
		}
	}
}
