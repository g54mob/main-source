using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.Analytics
{
	[CreateAssetMenu(menuName = "TH20/Configs/Analytics Manager", order = 1102)]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AnalyticsManagerConfig : BaseScriptableObject
	{
		public const int TitleIdentifier = 7;

		public const int SessionIdentifier = 1;

		public readonly GameEventInfo GameSessionOpenInfo;

		public readonly GameEventInfo GameSessionCloseInfo;

		public readonly GameEventInfo MonthSummaryInfo;

		[Obsolete("MonthlyRoomTypeSummaryInfo event fields moved into BatchedMonthlyRoomTypeSummaryInfo event")]
		public readonly GameEventInfo MonthlyRoomTypeSummaryInfo;

		public readonly GameEventInfo BatchedMonthlyRoomTypeSummaryInfo;

		[Obsolete("MonthlySpeedIndexSummaryInfo event fields moved into MonthSummaryInfo event")]
		public readonly GameEventInfo MonthlySpeedIndexSummaryInfo;

		public readonly GameEventInfo AnnualIllnessSummaryInfo;

		[Obsolete("SpawnPatientInfo event fields moved into BatchedSpawnPatientInfo event")]
		public readonly GameEventInfo SpawnPatientInfo;

		[Obsolete("DestroyPatientInfo event fields moved into BatchedDestroyPatientInfo event")]
		public readonly GameEventInfo DestroyPatientInfo;

		public readonly GameEventInfo BatchedSpawnPatientInfo;

		public readonly GameEventInfo BatchedDestroyPatientInfo;

		[Obsolete("HospitalValue event fields moved into monthSummary event")]
		public readonly GameEventInfo HospitalValueInfo;

		public readonly GameEventInfo EndLevelInfo;

		public readonly GameEventInfo AwardStarInfo;

		public readonly GameEventInfo AwardRemixBadgeInfo;

		public readonly GameEventInfo OnlineFeatureUsedInfo;

		public readonly GameEventInfo SandboxSetupInfo;

		public readonly GameEventInfo UnhandledErrorInfo;

		public readonly GameEventInfo UGCLocalModCreatedInfo;

		public readonly GameEventInfo UGCLocalModPublishedInfo;

		public readonly GameEventInfo UGCWorkshopItemSubscribedToInfo;

		public readonly GameEventInfo CollaborativeProjectNodeCompletedInfo;

		public readonly GameEventInfo SuperBugProjectNodeCompletedInfo;

		public readonly GameEventInfo CollaborativeProjectCompletedInfo;

		public readonly GameEventInfo SuperBugRewardCollectionInfo;

		public readonly GameEventInfo HospitalSignupInfo;

		public readonly GameEventInfo MultiplayerChallengeStarted;

		public readonly GameEventInfo MultiplayerChallengeCompleted;

		public readonly GameEventInfo PlayfabUpdateUserDataInfo;

		public readonly GameEventInfo PlayfabGetUserDataInfo;

		public readonly GameEventInfo PlayfabUpdatePlayerStatisticsInfo;

		public readonly GameEventInfo PlayfabGetPlayerStatisticsInfo;

		public readonly GameEventInfo PlayfabGetLeaderboardAroundPlayerInfo;

		public readonly GameEventInfo PlayfabGetPlayFabIDsFromGenericIDsInfo;

		public readonly GameEventInfo RoomTemplateCreated;

		public readonly GameEventInfo RoomTemplatePlaced;

		public readonly GameEventInfo PrimeLogin;

		public readonly GameEventInfo PrimeFulfillmentInfo;

		public readonly GameEventInfo CareerSavesInfo;
	}
}
