using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MetagameSubGoalDefinitionTimeTunnelPatients : SubGoalDefinition
	{
		public int CureCount;

		public SharedInstance<IllnessDefinition> Illness;

		public SharedInstance<RoomDefinition> Room;

		public LocalisedString GoalString;

		public override string GoalText(Objective objective)
		{
			if (GoalString.IsNull())
			{
				return "";
			}
			bool num = Room != null && Room.Instance != null;
			bool flag = Illness != null && Illness.Instance != null;
			string text = GoalString.Translation;
			if (num)
			{
				text = text.Replace("{[ROOM]}", Room.Instance.GetLocalisedName());
			}
			if (flag)
			{
				text = text.Replace("{[ILLNESS]}", Illness.Instance.Name.Translation);
			}
			LocalisationParams.Set("COUNT", CureCount);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalTimeTunnelPatients(owner, this);
		}

		public bool ValidRoom(Room room)
		{
			if (!(Room == null) && Room.Instance != null)
			{
				if (room != null)
				{
					return Room.Instance == room.Definition;
				}
				return false;
			}
			return true;
		}

		public bool ValidIllness(IllnessDefinition illness)
		{
			if (!(Illness == null) && Illness.Instance != null)
			{
				return Illness.Instance == illness;
			}
			return true;
		}

		public bool ValidPatient(Patient patient)
		{
			return patient.GetComponent<AnachronisticTreatmentComponent>() != null;
		}
	}
}
