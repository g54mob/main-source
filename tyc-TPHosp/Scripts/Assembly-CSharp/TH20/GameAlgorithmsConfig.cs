using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GameAlgorithmsConfig
	{
		[InspectorHeader("General Balance Values")]
		public readonly float SecondsPerDay = 4f;

		[InspectorMargin(8)]
		[InspectorHeader("Finance Balance Values")]
		public readonly float GlobalSellValueMultiplier = 1f;

		[InspectorMargin(8)]
		[InspectorHeader("Price vs Happiness Values")]
		public readonly float CharacterUnderChargedHappiness = 10f;

		public readonly float CharacterOverChargedHappiness = -25f;

		public readonly float CharacterChargedHappinessBalance = 1000f;

		[InspectorTooltip("What is the minimum happiness level for accepting an overcharge")]
		public readonly float CharacterMinHappinessForOvercharge = 20f;

		[InspectorTooltip("When a Patient is cured how much happier are they")]
		public readonly float CharacterCureHappinessIncrease = 20f;

		[InspectorMargin(8)]
		[InspectorHeader("Input Balance Values")]
		public readonly float CursorHoverStartTime = 0.5f;

		public readonly float CursorHoverStopTime = 1.5f;

		public readonly float CursorHoverVisualisationStartTime = 2f;

		public readonly float CursorPositionDampTime = 0.05f;

		public readonly float CursorRotationDampTime = 0.04f;

		public readonly float CursorRoomRotationDampTime = 0.07f;

		public readonly float CursorItemRotateWithKeysDelta = 45f;

		[InspectorTooltip("Time to hold mouse down to activate pickup")]
		public readonly float MinHoldSelectTime = 0.1f;

		public readonly float MaxHoldSelectTime = 0.5f;

		[InspectorTooltip("Normalised distance mouse has to travel to activate selection")]
		public readonly float DragSelectDistance = 0.05f;

		[InspectorMargin(8)]
		[InspectorHeader("Room Item Collision Values")]
		public readonly float OutsideWallThickness = 2f;

		public readonly float CursorRoomItemSnapDistance = 2f;

		public readonly float CursorInNextRoomDistance = 0.5f;

		public readonly float CursorInNextRoomDistanceItemInvalid = 1f;

		public readonly float CursorItemMaxStepSize = 0.5f;

		[InspectorMargin(8)]
		[InspectorHeader("Character Balance Values")]
		[InspectorTooltip("Time between character status icon checks")]
		public readonly float CharacterStatusIconCheckTime = 60f;

		public readonly float ChanceOfNeedsIdle = 25f;

		public readonly float ChanceOfIllnessIdle = 25f;

		public readonly float PersonToPersonHygieneMultiplier = 0.5f;

		[InspectorMargin(8)]
		[InspectorHeader("Patient Balance Values")]
		public readonly float PatientBetterRoomCheckTime = 10f;

		public readonly float PatientLowHealth = 20f;

		public readonly float PatientLowHappiness = 20f;

		public readonly float PatientWaitForNewRoomTime = 120f;

		public readonly float PatientWaitLongTime = 240f;

		[InspectorMargin(8)]
		[InspectorHeader("Staff Balance Values")]
		public readonly float StaffEnergyLow = 20f;

		public readonly float StaffBreakDurationMin = 30f;

		public readonly float StaffBreakDurationMax = 90f;

		public readonly float StaffMaintenanceJobDuration = 30f;

		[InspectorTooltip("Staff trainers wait for trainees for this amount of time before ending the session")]
		public readonly float TrainingSessionWaitTime = 120f;

		public readonly float MaxDesiredSalary = 0.25f;

		public readonly float StaffLowHappinessThreshold = 10f;

		public readonly float StaffResignationFrequencyInSeconds = 180f;

		public readonly float MaxTimeStaffIdleOnJob = 30f;

		[InspectorMargin(8)]
		[InspectorHeader("Job Balance Values")]
		public readonly float JobQueueScore = 20f;

		public readonly float FailedtoStartJobTimeOut = 5f;

		public readonly float[] JobIndexScoreMultipliers = new float[3] { 0.75f, 0.5f, 0.25f };

		public readonly float JobEmptyQueueScoreMultiplier = 0.1f;

		public readonly float JobAlreadyAssignedMultiplier = 0.5f;

		public readonly float JobNonFunctionalRoomScoreMultiplier = 0.1f;

		public readonly float JobPriorityScoreBoost = 1000f;

		public readonly float JobSameRoomAsJobScoreBoost = 2f;

		[InspectorTooltip("At the sq root of this distance the job priority is halved.")]
		public readonly float JobDistanceMagicNumber = 1600f;

		public readonly float JobFireScore = 10000f;

		public readonly float JobAmbulanceScore = 10000f;

		public readonly float JobFireHasExtinguisherBoost = 10f;

		public readonly float JobMaintenanceBaseJobScore = 10f;

		public readonly float JobMaintenanceCurrentJobBoost = 2f;

		public readonly float JobUpgradeScore = 100f;

		public readonly float JobGhostScore = 200f;

		public readonly float JobResearchScore = 2f;

		public readonly float JobServiceScore = 100f;

		public readonly float JobMarketingScore = 100f;

		[InspectorTooltip("Within this distance (squared distance really...), all jobs have the same distance score. To prevent flip-flopping between close-by jobs.")]
		public readonly float JobMinDistanceScore = 0.5f;

		[InspectorTooltip("Room item jobs within this radius are considered when holding a staff member")]
		public readonly float JobStaffDropRadius = 6f;

		public readonly float JobAssistantReceptionDuration = 10f;

		public readonly float JobAssistantKioskDuration = 8f;

		public readonly SharedInstance<QualificationDefinition> UpgradeQualification;

		public readonly SharedInstance<QualificationDefinition> GhostCaptureQualification;

		[InspectorMargin(8)]
		[InspectorHeader("Room Item Balance Values")]
		public readonly float ItemMaintenanceThreshold = 50f;

		public readonly float ItemFullyRepairedThreshold = 2f;

		public readonly float ItemSmokingThreshold = 80f;

		public readonly float ItemSetOnFireThreshold = 90f;

		[InspectorMargin(8)]
		[InspectorHeader("Needs Balance Values")]
		public readonly float UrgentNeedThreshold = 80f;

		public readonly float OpportunisticNeedThreshold = 40f;

		[InspectorMargin(8)]
		public readonly float UrgentSearchRadiusDefault = 100f;

		public readonly float UrgentSearchRadiusFood = 100f;

		public readonly float UrgentSearchRadiusToilet = 100f;

		public readonly float UrgentSearchRadiusBoredom = 100f;

		public readonly float UrgentSearchRadiusLitter = 100f;

		public readonly float OpportunisticSearchRadiusDefault = 15f;

		public readonly float OpportunisticSearchRadiusFood = 15f;

		public readonly float OpportunisticSearchRadiusToilet = 15f;

		public readonly float OpportunisticSearchRadiusBoredom = 15f;

		public readonly float OpportunisticSearchRadiusLitter = 15f;

		[InspectorMargin(8)]
		public readonly float[] SearchRadiusQueuePositionMultipliers = new float[3] { 0.25f, 0.5f, 0.75f };

		public readonly float MinDelayNeedStartTime = 2f;

		public readonly float MaxDelayNeedStartTime = 4f;

		public readonly float NeedScoreInteractionAvailable = 0.5f;

		public readonly float NeedScoreQueueLengthMultiplier = 4f;

		public readonly float NeedScoreInDifferentRoomMultiplier = 2f;

		[InspectorMargin(8)]
		[InspectorHeader("Room Prestige Table")]
		public readonly RoomPrestigeLevel[] RoomPrestigeLevels;

		[InspectorMargin(8)]
		[InspectorHeader("Graphics")]
		public readonly float BlueprintItemAlpha = 0.5f;

		public readonly float BlueprintItemMaxAlphaForTransparentParts = 0.25f;

		public readonly GameObject DefaultWallPrefab;

		public readonly GameObject DefaultWindowPrefab;

		[InspectorMargin(8)]
		[InspectorHeader("Misc.")]
		public readonly int MaxPlotChallenges = 3;

		public readonly float MaxQueueDistance = 20f;

		public readonly float MaxRoomQueueDistance = 30f;

		public readonly float GoingToQueueDistance = 5f;

		public readonly float QueueUnattractiveThreshold = -0.5f;

		public readonly float MaxTimeVisitorsWaitForReceptionInSeconds = 300f;

		public readonly float InteractionAttractivenessBoost = 10f;

		public readonly float ToughLuckBalancingSensitivity = 1.2f;

		[InspectorMargin(8)]
		public readonly float CharactersLookAtPlayerMinTime = 20f;

		public readonly float CharactersLookAtPlayerMaxTime = 100f;

		public readonly float CharactersLookAtPlayerDuration = 4f;

		[InspectorMargin(8)]
		public readonly int ArrivalPriorityVisitor = 1;

		public readonly int ArrivalPriorityGuestTrainer = 2;

		public readonly int ArrivalPriorityPatientEmergency = 3;

		[InspectorMargin(8)]
		public int CureRateObjectiveNumPatients = 20;

		public float InteractionQueueScore = 50f;

		public int NumMonthsForGeneralTrendIndicators = 3;

		[InspectorMargin(8)]
		[InspectorHeader("Nav Failure Settings")]
		[InspectorTooltip("Navigation failure flag is removed after this many seconds")]
		public int NavFailTimeOut = 10;

		[InspectorTooltip("Navigation failure warning message is triggered after this many failures")]
		public int NavFailWarningTriggerCount = 2;

		[InspectorTooltip("Characters wait for this many seconds until resuming their behaviour")]
		public float NavFailCoolDownTime = 4f;

		public float GhostCaptureNavFailTimeOut = 20f;

		[InspectorMargin(8)]
		public readonly Color[] OnlineChallengeColors;

		[InspectorMargin(8)]
		public readonly GameObject PatientMoveQueueDragPrefab;

		[InspectorMargin(8)]
		[InspectorHeader("Environment Settings")]
		public float HygieneRatingCharacterWeight = 1f;

		public float HygieneRatingEnvironmentWeight = 1f;

		public float EnvironmentThermalComfortMinimum = -0.4f;

		public float EnvironmentThermalComfortMaximum = 0.4f;

		[InspectorMargin(8)]
		[InspectorHeader("Treatment Settings")]
		public readonly float TreatmentStaffSkillMin;

		public readonly float TreatmentStaffSkillMax = 100f;

		public readonly float TreatmentUpgradesFactorMin;

		public readonly float TreatmentUpgradesFactorMax = 100f;

		[InspectorMargin(8)]
		[InspectorHeader("Room Queue Score Settings")]
		[InspectorTooltip("Score per person already in Queue")]
		public readonly float RoomScoreQueueLength = 10f;

		[InspectorTooltip("If already in a Queue, score per position in Queue")]
		public readonly float RoomScorePositionScore = 10f;

		[InspectorTooltip("Multiplier per metre of Distance away from Room")]
		public readonly float RoomScoreDistanceFactor = 1f;

		[InspectorTooltip("Score if room is not Staffed. Otherwise 0.")]
		public readonly float RoomScoreNotFullyStaffed = 20f;

		[InspectorTooltip("Score if room is not Functional. Otherwise 0.")]
		public readonly float RoomScoreRoomNotFunctional = 20f;
	}
}
