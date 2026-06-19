using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class VIPChallengeConfig : ChallengeConfig
	{
		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("GUI")]
		public string ChallengeDisplayName;

		public LocalisedString ChallengeDisplayNameLoc;

		[InspectorHeader("VIP")]
		[InspectorTooltip("VIP Visitor that is the subject of this Challenge")]
		public SharedInstance<VisitorDefinition> VisitorDef;

		public SharedInstance<ArrivalMethodDefinition> ArrivalMethod;

		[InspectorHeader("Tour Route")]
		public VIPTourRouteConfig TourRouteConfig;

		[InspectorHeader("Appraisal")]
		public SharedInstance<VIPAppraisalCriteriaRangesConfig> AppraisalRangesConfig;

		[SerializeField]
		public VIPAppraisalCriteriaInterest AppraisalCriteriaInterest;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeVIP(this, level);
		}
	}
}
