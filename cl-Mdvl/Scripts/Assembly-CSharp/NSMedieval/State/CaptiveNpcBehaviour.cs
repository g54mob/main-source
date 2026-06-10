using System;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.Serialization;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.State
{
	[FVSerializableKey("CaptiveNpcBehaviour", "")]
	public abstract class CaptiveNpcBehaviour : HumanoidBehaviour
	{
		public const uint SurrenderWaitTimeHours = 6u;

		[SerializeField]
		private bool isMarkedForRecruiting;

		[SerializeField]
		private bool isCaptiveLabourer;

		[SerializeField]
		private bool isShackled;

		[SerializeField]
		private bool isEscaping;

		[SerializeField]
		private bool isMarkedForShackling;

		[SerializeField]
		private bool isMarkedForUnShackling;

		[SerializeField]
		private bool isMarkedForStripping;

		[SerializeField]
		private bool isMarkedForReleasing;

		[SerializeField]
		private bool hasSurrendered;

		[SerializeField]
		private int ownerId;

		[SerializeField]
		private long surrenderWaitExpireTimeMinutes = -1L;

		[NonSerialized]
		private HumanoidInstance ownerCache;

		[NonSerialized]
		private EquipmentSlotType autoEquipSlots;

		public override BehaviourType BehaviourType => BehaviourType.CaptiveNpc;

		public PrisonerGoapAgent PrisonerAgent => (PrisonerGoapAgent)base.GoapAgent;

		public bool IsCaptiveLabourer => isCaptiveLabourer;

		public bool MarkedForShackling => isMarkedForShackling;

		public bool MarkedForUnShackling => isMarkedForUnShackling;

		public bool MarkedForRecruiting => isMarkedForRecruiting;

		public bool MarkedForStripping => isMarkedForStripping;

		public bool MarkedForReleasing => isMarkedForReleasing;

		public bool HasSurrendered => hasSurrendered;

		public int PrisonerOwnerId => ownerId;

		public override bool ProximityDetection => true;

		public long SurrenderWaitExpireTimeMinutes => surrenderWaitExpireTimeMinutes;

		public bool IsInPrisonCell
		{
			get
			{
				if (base.Humanoid.Room == null)
				{
					return false;
				}
				return base.Humanoid.Room.RoomType.Prison;
			}
		}

		public EquipmentSlotType AutoEquipSlots
		{
			get
			{
				if (base.Inventory == null)
				{
					return EquipmentSlotType.None;
				}
				return autoEquipSlots & ~base.Inventory.OccupiedSlots;
			}
		}

		public bool Shackled
		{
			get
			{
				return isShackled;
			}
			private set
			{
				if (!isShackled && value)
				{
					IsEscaping = false;
				}
				isShackled = value;
			}
		}

		public bool IsEscaping
		{
			get
			{
				return isEscaping;
			}
			set
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\CaptiveNpcBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Prisoner.IsEscaping = ");
					messageBuilder.AppendFormatted(value);
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(this);
				}
				Log.Info(messageBuilder);
				isEscaping = value;
				if (MonoSingleton<GlobalWarningMessagesManager>.IsInstantiated())
				{
					MonoSingleton<GlobalWarningMessagesManager>.Instance.RefreshPrisonerEscapingMessage();
				}
			}
		}

		public bool IsPlayerVillagePrisoner => Owner == null;

		public HumanoidInstance Owner
		{
			get
			{
				if (ownerId == 0)
				{
					return null;
				}
				if (ownerCache == null)
				{
					VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
					ownerCache = currentVillageData.Workers.FirstOrDefault((HumanoidInstance w) => w.UniqueId == ownerId);
					if (ownerCache == null)
					{
						ownerCache = currentVillageData.NPCs.FirstOrDefault((HumanoidInstance w) => w.UniqueId == ownerId);
					}
				}
				return ownerCache;
			}
			set
			{
				ownerCache = value;
				ownerId = value?.UniqueId ?? 0;
				MonoSingleton<NPCController>.Instance.OnOwnerSet(this);
			}
		}

		public override float RopedFollowRange
		{
			get
			{
				if (base.Humanoid.RopedTo() is HumanoidInstance humanoidInstance && humanoidInstance.ActiveBehaviour is TraderBehaviour)
				{
					return 3f;
				}
				return base.RopedFollowRange;
			}
		}

		public override bool RopedAllowedToIdle
		{
			get
			{
				if (base.Humanoid.RopedTo() is HumanoidInstance humanoidInstance && humanoidInstance.ActiveBehaviour is TraderBehaviour)
				{
					return true;
				}
				return base.RopedAllowedToIdle;
			}
		}

		public override bool RopedShouldAlwaysWalk
		{
			get
			{
				if (base.Humanoid.RopedTo() is HumanoidInstance humanoidInstance && humanoidInstance.ActiveBehaviour is TraderBehaviour)
				{
					return true;
				}
				return base.RopedShouldAlwaysWalk;
			}
		}

		protected CaptiveNpcBehaviour()
		{
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			if (Owner != null && !base.Humanoid.IsLeaving)
			{
				base.Humanoid.RopeTo(Owner);
			}
			autoEquipSlots = EquipmentSlotType.Head | EquipmentSlotType.Body;
			MoveDataFromOtherBehaviour();
			base.Humanoid.SetCombatAiAgent("PrisonerNPCAgent");
			base.Humanoid.DropStorage();
			MonoSingleton<RoleManager>.Instance.RoleRetractedEvent += OnRoleRetracted;
		}

		protected override void OnDeactivate()
		{
			base.OnDeactivate();
			MonoSingleton<RoleManager>.Instance.RoleRetractedEvent -= OnRoleRetracted;
		}

		public int GetRecruitedPercentage()
		{
			float current = base.Humanoid.Stats.GetStat(StatType.PrisonerNotRecruited).Current;
			float max = base.Humanoid.Stats.GetStat(StatType.PrisonerNotRecruited).Max;
			float num = current / max * 100f;
			return (int)(100f - num);
		}

		protected void MoveDataFromOtherBehaviour()
		{
			if (base.Humanoid.ActiveBehaviour is CaptiveLabourerBehaviour && base.Humanoid.ContainsBehaviour<PrisonerBehaviour>())
			{
				PrisonerBehaviour behaviour = base.Humanoid.GetBehaviour<PrisonerBehaviour>();
				isMarkedForRecruiting = behaviour.MarkedForRecruiting;
				isCaptiveLabourer = behaviour.IsCaptiveLabourer;
				Shackled = behaviour.Shackled;
				isMarkedForShackling = behaviour.MarkedForShackling;
				isMarkedForUnShackling = behaviour.isMarkedForUnShackling;
				isMarkedForStripping = behaviour.isMarkedForStripping;
				hasSurrendered = behaviour.hasSurrendered;
				ownerId = behaviour.PrisonerOwnerId;
			}
			else if (base.Humanoid.ActiveBehaviour is PrisonerBehaviour && base.Humanoid.ContainsBehaviour<CaptiveLabourerBehaviour>())
			{
				CaptiveLabourerBehaviour behaviour2 = base.Humanoid.GetBehaviour<CaptiveLabourerBehaviour>();
				isMarkedForRecruiting = behaviour2.MarkedForRecruiting;
				isCaptiveLabourer = behaviour2.IsCaptiveLabourer;
				Shackled = behaviour2.Shackled;
				isMarkedForShackling = behaviour2.MarkedForShackling;
				isMarkedForUnShackling = behaviour2.isMarkedForUnShackling;
				isMarkedForStripping = behaviour2.isMarkedForStripping;
				hasSurrendered = behaviour2.hasSurrendered;
				ownerId = behaviour2.PrisonerOwnerId;
			}
		}

		public void MarkForReleasing(bool mark)
		{
			isMarkedForReleasing = mark;
		}

		public void MarkForStripping(bool mark)
		{
			isMarkedForStripping = mark;
		}

		public void MarkForRecruiting(bool mark)
		{
			isMarkedForRecruiting = mark;
			MonoSingleton<NPCController>.Instance.OnMarkedForRecruitment(this, mark);
		}

		public void MarkForShackling(bool mark)
		{
			isMarkedForShackling = mark;
		}

		public void MarkForUnShackling(bool mark)
		{
			isMarkedForUnShackling = mark;
		}

		public void MarkAsSurrendered()
		{
			hasSurrendered = true;
		}

		public void ShacklePrisoner(bool isShackled, bool justSetValue = false)
		{
			Shackled = isShackled;
			if (!justSetValue)
			{
				isMarkedForShackling = false;
				isMarkedForUnShackling = false;
				if (!isShackled && isCaptiveLabourer)
				{
					SetCaptiveLabour(isLabourEnabled: false);
				}
				base.Humanoid.RefreshRopedAnimationParameter();
			}
		}

		public void EquipShackles()
		{
			EquipmentInstance item = base.Humanoid.Inventory.GetItem(EquipmentSlotType.LeftHand);
			if (item == null || !item.Blueprint.Resource.ProtoId.Equals("shackles"))
			{
				EquipmentInstance item2 = new EquipmentInstance(Repository<ResourceRepository, Resource>.Instance.GetAllResourcesByProtoId("shackles").PickRandom().GetID(), isManuallyEquiped: true);
				base.Humanoid.Inventory.Equip(item2);
			}
		}

		public void SetCaptiveLabour(bool isLabourEnabled)
		{
			if (!(!isShackled && isLabourEnabled))
			{
				isCaptiveLabourer = isLabourEnabled;
				if (isLabourEnabled)
				{
					base.Humanoid.SetActiveBehaviour<CaptiveLabourerBehaviour>();
				}
				else
				{
					base.Humanoid.SetActiveBehaviour<PrisonerBehaviour>();
				}
			}
		}

		public void SetSurrenderExpireTime()
		{
			surrenderWaitExpireTimeMinutes = HumanoidBehaviour.DateTime.CurrentTimeTutorialAware + (long)HumanoidBehaviour.DateTime.MinutesInHour * 6L;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(70, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\CaptiveNpcBehaviour.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Prisoner surrender expire time set to ");
				messageBuilder.AppendFormatted(surrenderWaitExpireTimeMinutes);
				messageBuilder.AppendLiteral(" minutes total (");
				messageBuilder.AppendFormatted((surrenderWaitExpireTimeMinutes - HumanoidBehaviour.DateTime.CurrentTimeTutorialAware) / HumanoidBehaviour.DateTime.MinutesInHour);
				messageBuilder.AppendLiteral(" hours from now)");
			}
			Log.Info(messageBuilder);
		}

		private void OnRoleRetracted(Role role, HumanoidInstance humanoidInstance)
		{
			if (!(role.GetID() != "warden"))
			{
				SetCaptiveLabour(isLabourEnabled: false);
			}
		}

		public override void OnHealthDepleted(bool wasNaturalDeath = false)
		{
			if (base.Humanoid.Faction != null)
			{
				base.Humanoid.Faction.AddFriendliness(base.Humanoid.Faction.Blueprint.AddFriendlinessOnPrisonerDeath);
			}
			base.OnHealthDepleted();
		}

		public override void Dispose()
		{
			base.Dispose();
			IsEscaping = false;
		}

		public override void Serialize(FVSerializer serializer)
		{
			serializer.Write("isMarkedForRecruiting", isMarkedForRecruiting);
			serializer.Write("isCaptiveLabourer", isCaptiveLabourer);
			serializer.Write("shackled", isShackled);
			serializer.Write("markedForShackling", isMarkedForShackling);
			serializer.Write("markedForUnShackling", isMarkedForUnShackling);
			serializer.Write("ownerId", ownerId);
			serializer.Write("isMarkedForStripping", isMarkedForStripping);
			serializer.Write("isMarkedForReleasing", isMarkedForReleasing);
			serializer.Write("hasSurrendered", hasSurrendered);
			serializer.Write("surrenderWaitExpireTimeMinutes", surrenderWaitExpireTimeMinutes);
		}

		public CaptiveNpcBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
			isMarkedForRecruiting = deserializer.ReadBool("isMarkedForRecruiting");
			isCaptiveLabourer = deserializer.ReadBool("isCaptiveLabourer");
			isShackled = deserializer.ReadBool("shackled");
			isMarkedForShackling = deserializer.ReadBool("markedForShackling");
			isMarkedForUnShackling = deserializer.ReadBool("markedForUnShackling");
			ownerId = deserializer.ReadInt("ownerId");
			isMarkedForStripping = deserializer.ReadBool("isMarkedForStripping");
			isMarkedForReleasing = deserializer.ReadBool("isMarkedForReleasing");
			hasSurrendered = deserializer.ReadBool("hasSurrendered", defaultValue: true);
			surrenderWaitExpireTimeMinutes = deserializer.ReadLong("surrenderWaitExpireTimeMinutes", -1L);
		}
	}
}
