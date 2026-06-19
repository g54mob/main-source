using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeElectricityConfig : ChallengeConfig
	{
		[Serializable]
		public class ElectricityTypeEntry
		{
			public ChallengeElectricity.ElectricityType Type;

			public string AssignmentLocText;

			public bool Enabled;
		}

		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Electricity Config")]
		public float StaffApplicantRate = 0.1f;

		public float PatientArrivalRatePerUnit = 0.2f;

		public GameObject HUDPrefab;

		public List<ElectricityTypeEntry> ActiveAssignments;

		[InspectorTooltip("Advisor message to be displayed if you have closed rooms and spare energy capacity")]
		public LocalisedString ClosedRoomsAdvisorMessage;

		[InspectorTooltip("Minimum interval between advisor messages")]
		public float MinClosedRoomsAdvisorMessageInterval;

		[InspectorTooltip("Time between the game detecting a closed room with spare energy and the advisor popping up")]
		public float ClosedRoomsAdvisorWarmupTimer;

		public string TooltipLocString = "Challenges/SubGoals/ChallengeBudget_ToolTip_CS";

		public LocalisedString StaffApplicantTooltip;

		public LocalisedString PatientFlowTooltip;

		public LocalisedString RoomUsageTooltip;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeElectricity(this, level);
		}
	}
}
