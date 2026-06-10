using System;
using System.Collections.Generic;
using System.Linq;
using FloatingOverlaySystem.Elements;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.View
{
	public abstract class HumanoidView : AnimatedAgentView
	{
		[NonSerialized]
		protected HumanoidInstance humanoidInstance;

		private const int ShieldRaisedTimeMinutes = 7;

		[SerializeField]
		private HumanoidBodyPreview bodyPreview;

		private Timer shieldVisualsUpdateTimer;

		private long nextCanLowerShieldTimeMinutes;

		private int attackAnimationLayerIndex;

		[SerializeField]
		private Transform ropeHookBone;

		private IconCircleFloatingElement combatCoverIcon;

		private Sprite combatCoverActiveIcon;

		private Sprite combatCoverInactiveIcon;

		public HumanoidInstance HumanoidInstance => humanoidInstance;

		private long CurrentTimeMinutes => (GlobalSaveController.CurrentVillageData?.DateAndTime?.MinutesTotal).GetValueOrDefault();

		public HumanoidBodyPreview BodyPreview => bodyPreview;

		public Transform RopeHookBone => ropeHookBone;

		public bool HasDisposed { get; protected set; }

		public bool IsRunningDisabledGoap { get; set; }

		protected abstract void UpdateCombatFootCircleIndicator();

		protected override void Start()
		{
			base.Start();
			humanoidInstance = (HumanoidInstance)GetAsCreature();
			InitializeShieldVisuals();
			MonoSingleton<DraftController>.Instance.OnEndDraftEvent += OnDraftChanged;
			MonoSingleton<DraftController>.Instance.OnStartDraftEvent += OnDraftChanged;
			humanoidInstance.Inventory.OnEquipedEvent += OnInventoryChanged;
			humanoidInstance.Inventory.OnDroppedEvent += OnInventoryChanged;
			humanoidInstance.Inventory.OnDestroyEvent += OnInventoryChanged;
			UpdateCombatFootCircleIndicator();
		}

		public override CreatureBase GetAsCreature()
		{
			return humanoidInstance;
		}

		private void InitializeShieldVisuals()
		{
			combatCoverActiveIcon = AssetUtils.GetSprite("ranged_cover_icon");
			combatCoverInactiveIcon = AssetUtils.GetSprite("ranged_cover_disabled_icon");
			shieldVisualsUpdateTimer = new Timer(0.5f + UnityEngine.Random.value / 4f, restartOnEnd: true);
			shieldVisualsUpdateTimer.AddCallback(UpdateShieldVisuals);
			nextCanLowerShieldTimeMinutes = CurrentTimeMinutes - 1;
			attackAnimationLayerIndex = animator.GetLayerIndex("Attack Animations");
			UpdateShieldVisuals();
			SetIsMidStrike(isMidStrike: false);
		}

		public void GenerateAnimationRnd()
		{
			MonoSingleton<AnimationController>.Instance.GenerateNewAnimationRnd(GetAgentOwner());
		}

		private void UpdateShieldVisuals()
		{
			if (!humanoidInstance.HasShield())
			{
				TrySetParameter("ShouldRaiseShield", value: false);
				return;
			}
			bool flag = ShouldRaiseShield();
			if (flag)
			{
				nextCanLowerShieldTimeMinutes = CurrentTimeMinutes + 7;
			}
			else if (CurrentTimeMinutes < nextCanLowerShieldTimeMinutes)
			{
				return;
			}
			TrySetParameter("ShouldRaiseShield", flag);
		}

		private bool ShouldRaiseShield()
		{
			if (MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(humanoidInstance) != null)
			{
				return true;
			}
			if (ShouldRaiseShieldBasedOn(CombatAiState.LastDamageTakenFrom, CombatAiState.LastDamageTakenTime))
			{
				return true;
			}
			if (ShouldRaiseShieldBasedOn(CombatAiState.LastBlockFrom, CombatAiState.LastBlockTime))
			{
				return true;
			}
			if (ShouldRaiseShieldBasedOn(CombatAiState.LastMissFrom, CombatAiState.LastMissTime))
			{
				return true;
			}
			return false;
		}

		private bool ShouldRaiseShieldBasedOn(CombatAiState damageDealAgentField, CombatAiState timeMinutesField)
		{
			IDamageDealAgent damageDealAgent = humanoidInstance.CombatAi?.GetState<IDamageDealAgent>(damageDealAgentField);
			if (damageDealAgent != null && !damageDealAgent.HasDied)
			{
				long state = humanoidInstance.CombatAi.GetState<long>(timeMinutesField);
				if (CurrentTimeMinutes - state < 7)
				{
					return true;
				}
			}
			return false;
		}

		private void SetIsMidStrike(bool isMidStrike)
		{
			if (humanoidInstance == null || humanoidInstance.HasDisposed)
			{
				return;
			}
			humanoidInstance.IsMidStrike = isMidStrike;
			bool num = !humanoidInstance.Inventory.HasCombatCoverItemEquipped(DamageType.Ranged);
			bool flag = humanoidInstance.ActiveBehaviour is WorkerBehaviour workerBehaviour && !workerBehaviour.IsDrafting;
			if (num || flag)
			{
				if (combatCoverIcon != null)
				{
					combatCoverIcon.Dispose();
					combatCoverIcon = null;
				}
			}
			else
			{
				if (combatCoverIcon == null)
				{
					combatCoverIcon = GetIconCircle(OverlayIconCircleType.CombatCoverVulnerability);
				}
				combatCoverIcon.SetSprite(isMidStrike ? combatCoverInactiveIcon : combatCoverActiveIcon);
			}
		}

		private void OnDraftChanged(HumanoidInstance humanoid)
		{
			if (humanoidInstance != null && !humanoidInstance.HasDisposed && humanoid == humanoidInstance)
			{
				SetIsMidStrike(isMidStrike: false);
			}
		}

		private void OnInventoryChanged(EquipmentInstance instance)
		{
			if (humanoidInstance != null && !humanoidInstance.HasDisposed)
			{
				SetIsMidStrike(isMidStrike: false);
				UpdateCombatFootCircleIndicator();
				UpdateViewImmediate();
			}
		}

		protected override void OnCombatAnimationEvent(string eventName)
		{
			if (!(eventName == "StrikeStart"))
			{
				if (eventName == "StrikeEnd")
				{
					SetIsMidStrike(isMidStrike: false);
				}
			}
			else
			{
				SetIsMidStrike(isMidStrike: true);
			}
		}

		public override void OnTriggerAnimation(string trigger)
		{
			base.OnTriggerAnimation(trigger);
			if (trigger == "ForceQuit")
			{
				SetIsMidStrike(isMidStrike: false);
			}
		}

		protected override void OnDestroy()
		{
			shieldVisualsUpdateTimer?.Dispose();
			shieldVisualsUpdateTimer = null;
			if (MonoSingleton<DraftController>.IsInstantiated())
			{
				MonoSingleton<DraftController>.Instance.OnEndDraftEvent -= OnDraftChanged;
				MonoSingleton<DraftController>.Instance.OnStartDraftEvent -= OnDraftChanged;
			}
			if (humanoidInstance?.Inventory != null)
			{
				humanoidInstance.Inventory.OnEquipedEvent -= OnInventoryChanged;
				humanoidInstance.Inventory.OnDroppedEvent -= OnInventoryChanged;
			}
			humanoidInstance = null;
			base.OnDestroy();
		}

		public static List<InfoPanelStat> GetInfoStats(CreatureBase creatureBase)
		{
			StatInstance stat = creatureBase.Stats.GetStat(StatType.Hunger);
			StatInstance stat2 = creatureBase.Stats.GetStat(StatType.Sleep);
			StatInstance stat3 = creatureBase.Stats.GetStat(StatType.Health);
			StatInstance stat4 = creatureBase.Stats.GetStat(StatType.Mood);
			return new List<InfoPanelStat>
			{
				new InfoPanelStat("menu_hit_points", $"{stat3.Current}%", new IntRange(Mathf.RoundToInt(stat3.Current), Mathf.RoundToInt(stat3.Max)), StatType.Health),
				new InfoPanelStat("menu_sleep", $"{stat2.Current}%", new IntRange(Mathf.RoundToInt(stat2.Current), Mathf.RoundToInt(stat2.Max)), StatType.Sleep),
				new InfoPanelStat("menu_hunger", $"{stat.Current}%", new IntRange(Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max)), StatType.Hunger),
				new InfoPanelStat("menu_mood", $"{stat4.Current}%", new IntRange(Mathf.RoundToInt(stat4.Current), Mathf.RoundToInt(stat4.Max)), "Target: " + stat4.Target, StatType.Mood)
			};
		}

		public static string GetOverweightMessage(CreatureBase creatureBase)
		{
			if (creatureBase == null || !creatureBase.Storage.IsOverweight())
			{
				return string.Empty;
			}
			AnimatedAgentView.StringBuilder.Clear();
			AnimatedAgentView.StringBuilder.Append("\n<style=DefaultRed>");
			AnimatedAgentView.StringBuilder.Append(MonoSingleton<LocalizationController>.Instance.GetText("worker_overweight_slowdown", creatureBase.GetInfo().BodyType));
			AnimatedAgentView.StringBuilder.Append("</style>");
			return AnimatedAgentView.StringBuilder.ToString();
		}

		public void ForbidWeaponAnimation(bool forbid)
		{
			MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(humanoidInstance);
			if (forbid)
			{
				TrySetParameter("WeaponType", 0);
				SetAnimationAttackSpeedParam();
				return;
			}
			EquipmentInstance weapon = CombatUtils.GetWeapon(humanoidInstance);
			if (weapon != null)
			{
				TrySetParameter("WeaponType", (int)weapon.WeaponType);
				SetAnimationAttackSpeedParam();
			}
		}

		public void OnToggleWeaponMode(EquipmentInstance weapon = null)
		{
			SetWeaponAnimationParams(weapon);
			MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(humanoidInstance);
			TrySetTrigger("Attack");
			UpdateViewImmediate();
		}

		public void SetWeaponAnimationParams(EquipmentInstance weapon = null)
		{
			if (humanoidInstance == null || humanoidInstance.HasDisposed)
			{
				return;
			}
			if (weapon == null)
			{
				weapon = humanoidInstance.Inventory.GetEquipments().FirstOrDefault((EquipmentInstance item) => item.Blueprint.ItemType == ItemType.Weapon);
			}
			if (weapon != null)
			{
				TrySetParameter("WeaponType", (int)weapon.WeaponType);
			}
			else
			{
				TrySetParameter("WeaponType", 0);
			}
			SetAnimationAttackSpeedParam();
		}

		public void DropItem(EquipmentInstance item)
		{
			BodyPreview.DropItem(item.Blueprint);
			if (MonoSingleton<HumanoidIconManager>.IsInstantiated())
			{
				MonoSingleton<HumanoidIconManager>.Instance.OnItemDropped(humanoidInstance, item);
			}
			HumanoidInstance.WarmthInstance.UpdateWarmth();
			RegenerateIcon();
			if (!humanoidInstance.HasFainted)
			{
				animator.RebindKeepState();
			}
			OnItemDropped(item);
		}

		protected virtual void OnItemDropped(EquipmentInstance item)
		{
		}

		public void EquipItem(EquipmentInstance item)
		{
			BodyPreview.EquipItem(item.Blueprint);
			if (MonoSingleton<HumanoidIconManager>.IsInstantiated())
			{
				MonoSingleton<HumanoidIconManager>.Instance.OnItemEquipped(humanoidInstance, item);
			}
			HumanoidInstance.WarmthInstance.UpdateWarmth();
			RegenerateIcon();
			animator.RebindKeepState();
			OnItemEquipped(item);
		}

		protected virtual void OnItemEquipped(EquipmentInstance item)
		{
			RefreshMeshLayers();
		}

		public void RegenerateIcon()
		{
			if (!MonoSingleton<HumanoidIconManager>.IsInstantiated())
			{
				return;
			}
			MonoSingleton<HumanoidIconManager>.Instance.ShowHumanoid(humanoidInstance.UniqueId);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				if (HumanoidInstance != null && !humanoidInstance.HasDisposed)
				{
					MonoSingleton<HumanoidIconManager>.Instance.GenerateAndCacheIcon(HumanoidInstance);
				}
			});
		}

		protected void SetAnimationAttackSpeedParam()
		{
			TrySetParameter("AttackSpeed", 1f / CombatCalculator.CalculateAttackSpeed(humanoidInstance));
		}

		public void SnapToBed(BedComponentInstance bed)
		{
			if (bed.BaseBuildingBlueprint.BuildingType != BuildingType.Bed)
			{
				return;
			}
			BedComponent component = bed.Map.BedComponentManager.GetComponent(bed);
			if (component == null)
			{
				return;
			}
			Vector3 sleepPosition = component.SleepTRS.position;
			Vector3 sleepRotation = component.SleepTRS.eulerAngles;
			Quaternion transformRotation = base.transform.rotation;
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				if (!HasDisposed)
				{
					RotateAndMove(new Vector3(transformRotation.x, sleepRotation.y, transformRotation.z), sleepPosition);
				}
			});
		}

		protected void RotateAndMove(Vector3 angles, Vector3 position)
		{
			base.transform.position = position;
			humanoidInstance.UpdatePosition(position);
			Quaternion rotation = Quaternion.Euler(angles.x, angles.y, angles.z);
			FaceObject(rotation);
		}

		protected override bool IsRunningDisabled()
		{
			if (humanoidInstance == null)
			{
				return false;
			}
			if (!IsRunningDisabledGoap && !humanoidInstance.IsBleeding)
			{
				return humanoidInstance.RopedTo() != null;
			}
			return true;
		}
	}
}
