using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class VIPDefinition
	{
		[InspectorHeader("Behaviours")]
		[InspectorTooltip("The behaviour tree that governs the tour AI")]
		public ExternalBehavior VIPTourBehavior;

		[InspectorTooltip("Action to use once entering a room")]
		public SharedInstance<CharacterActionDefinition> ActionOnEnteringRoom;

		[InspectorTooltip("Action to use for corridor inspections")]
		public SharedInstance<CharacterActionDefinition> ActionOnCorridorInspection;

		[InspectorHeader("Appraisal Interactions")]
		[InspectorTooltip("The visual range the VIP will have for observing phenomena")]
		public float AppraisalVisualRadius;

		[InspectorTooltip("Minimum amount of time until next corridor inspection")]
		public float MinDelayUntilCorridorInspection;

		[InspectorTooltip("Maximum amount of time until next corridor inspection")]
		public float MaxDelayUntilCorridorInspection;

		[InspectorTooltip("Multiplier applied to all appraisals made when inspecting a room")]
		[InspectorName("Room Multiplier")]
		public float RoomAppraisalMultiplier;

		[InspectorTooltip("Multiplier applied to all appraisals made when inspecting a corridor")]
		[InspectorName("Corridor Multiplier")]
		public float CorridorAppraisalMultiplier;
	}
}
