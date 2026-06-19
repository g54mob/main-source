using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class QualificationJobRoomScoreBoost : CharacterModifier
	{
		public RoomDefinition.Type RoomType;

		public float ScoreBoost;
	}
}
