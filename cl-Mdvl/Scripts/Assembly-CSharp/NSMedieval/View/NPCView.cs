using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Extensions;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap;
using NSMedieval.Goap.Goals;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Model;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.View
{
	[Serializable]
	public class NPCView : HumanoidView, IObserver, IAdditionalMenuOwner, IGameDisposable, IDisposable
	{
		private const float AggressiveXrayColor = 2f;

		private const float PrisonerXrayColor = 3f;

		private const float NonAggressiveXrayColor = 4f;

		private static readonly int XRayColor = Shader.PropertyToID("_xRay_color");

		[SerializeField]
		private Transform gameplayOverlayHook;

		[SerializeField]
		private GameObject bleedingParticle;

		[SerializeField]
		private string panelTitle = string.Empty;

		[SerializeField]
		private Collider doorOpenerCollider;

		private AgentCircleIndicator feetCircleIndicator;

		private GameObject overheadBillboard;

		private LinearProgressBarFloatingElement healthBar;

		private DamagePopupFloatingElement damagePopup;

		private TextFloatingElement nameElement;

		private string currentRightHandItem;

		private Timer animationParamsUpdateTimer;

		private Dictionary<string, GameObject> tools = new Dictionary<string, GameObject>();

		public override bool Visible => true;

		public event Action<IGameDisposable> OnDisposedEvent;

		public override WorldObject GetAsWorldObject()
		{
			return null;
		}

		public override CreatureBase GetAsCreature()
		{
			return humanoidInstance;
		}

		public void Setup(HumanoidInstance instance, bool randomizeAppearance, System.Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			humanoidInstance = instance;
			MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent += OnFactionFriendlinessChanged;
			base.BodyPreview.Setup(humanoidInstance);
			if (randomizeAppearance)
			{
				base.BodyPreview.RandomizeAppearance(rnd);
			}
			base.BodyPreview.ShowEntity();
			base.BodyPreview.OnItemEquippedEvent += SetXRaymaterialOnChildren;
			SetupGoapView();
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				if (!(this == null) && !(base.transform == null) && !base.HasDisposed)
				{
					SetXRaymaterialOnChildren(base.transform);
				}
			});
			InstantiateIndicator();
			InstantiateNameElement();
			float num = humanoidInstance.Info.Height / Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.DefaultHeight[(int)humanoidInstance.Info.BodyType];
			base.gameObject.transform.localScale = new Vector3(num, num, num);
			base.BodyPreview.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, humanoidInstance.Info.GetBlendShapeWeight());
			if (bleedingParticle != null)
			{
				bleedingParticle.SetActive(value: false);
			}
			UpdatePanelTitle();
			SetWeaponAnimationParams();
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnHitTaken;
			MonoSingleton<CombatController>.Instance.HitBlockedEvent += OnHitTaken;
			MonoSingleton<CombatController>.Instance.HitMissedEvent += OnHitMissed;
			MonoSingleton<LifeController>.Instance.OnStartBleedingEvent += StartedBleeding;
			MonoSingleton<LifeController>.Instance.OnStopBleedingEvent += StoppedBleeding;
			MonoSingleton<SceneController>.Instance.SceneSetup += RebindOnGameplayStart;
			MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent += OnPlayerTriggeredEventStarted;
			MonoSingleton<PlayerTriggeredEventManager>.Instance.EventEndedEvent += OnPlayerTriggeredEventEnded;
			SetDoorOpenerCollider();
			if (humanoidInstance.IsStatsInitialized)
			{
				OnStatsInitialized(humanoidInstance.Stats);
			}
			humanoidInstance.StatsInitializedEvent += OnStatsInitialized;
			animationParamsUpdateTimer = new Timer(1f);
			animationParamsUpdateTimer.AddCallback(UpdateAnimationParams);
			animationParamsUpdateTimer.SetRestartOnEnd(value: true);
			UpdateAnimationParams();
		}

		public void SetBuildProgress()
		{
			if (humanoidInstance != null && !humanoidInstance.HasDisposed)
			{
				humanoidInstance.IsBulidProgressAlowed = true;
			}
		}

		private void UpdateAnimationParams()
		{
			if (humanoidInstance != null && humanoidInstance.IsEnemy())
			{
				Goal goal = humanoidInstance.GetGoapAgent()?.GetCurrentGoal();
				if (!(goal is FollowDigOrderGoal) && !(goal is FollowConstructBuildingGoal) && !(goal is FollowOperateSiegeWeaponOrderGoal) && !(goal is FollowDeliverSiegeWeaponAmmoOrderGoal) && !(goal is FollowCutPlantOrderGoal))
				{
					TrySetParameter("IsCombatAlert", value: true);
				}
			}
		}

		private void OnPlayerTriggeredEventEnded(PlayerTriggeredEventInstance obj)
		{
			if (!(overheadBillboard == null))
			{
				overheadBillboard.SetActive(value: true);
			}
		}

		private void OnPlayerTriggeredEventStarted(PlayerTriggeredEventInstance obj)
		{
			if (!(overheadBillboard == null) && humanoidInstance.IsAtEvent())
			{
				overheadBillboard.SetActive(value: false);
			}
		}

		public string GetAdditionalMenuId()
		{
			return GetGoapAgentId();
		}

		public IGoapTargetable GetAsTarget()
		{
			return humanoidInstance;
		}

		public override Transform GetGuiOverlayHookTransform()
		{
			if (gameplayOverlayHook != null)
			{
				return gameplayOverlayHook;
			}
			return base.BodyPreview.HeadSocket;
		}

		public bool ShouldMenuFollowHookTransform()
		{
			return humanoidInstance.IsEnemy();
		}

		protected override bool IsSelectionNull()
		{
			if (humanoidInstance != null)
			{
				return humanoidInstance.HasDisposed;
			}
			return true;
		}

		protected override void OnItemEquipped(EquipmentInstance item)
		{
			base.OnItemEquipped(item);
			if (item.Blueprint.ItemType == ItemType.Weapon)
			{
				SetWeaponAnimationParams(item);
			}
		}

		protected override void OnItemDropped(EquipmentInstance item)
		{
			if (item.Blueprint.ItemType == ItemType.Weapon)
			{
				SetWeaponAnimationParams();
			}
		}

		private void RebindOnGameplayStart()
		{
			animator.RebindKeepState();
		}

		public void Dispose()
		{
			Dispose(disposeInstance: true);
		}

		public void Dispose(bool disposeInstance)
		{
			if (!base.HasDisposed)
			{
				DestroyAnimatedAgent();
				base.HumanoidInstance.StatsInitializedEvent -= OnStatsInitialized;
				if (disposeInstance)
				{
					base.HumanoidInstance?.Dispose();
					humanoidInstance = null;
				}
				if (MonoSingleton<LifeController>.IsInstantiated())
				{
					MonoSingleton<LifeController>.Instance.OnStartBleedingEvent -= StartedBleeding;
					MonoSingleton<LifeController>.Instance.OnStopBleedingEvent -= StoppedBleeding;
				}
				base.HasDisposed = true;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				if (base.BodyPreview != null)
				{
					base.BodyPreview.OnItemEquippedEvent -= SetXRaymaterialOnChildren;
				}
				if (MonoSingleton<CombatController>.IsInstantiated())
				{
					MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnHitTaken;
					MonoSingleton<CombatController>.Instance.HitBlockedEvent -= OnHitTaken;
					MonoSingleton<CombatController>.Instance.HitMissedEvent -= OnHitMissed;
				}
				if (MonoSingleton<FactionsController>.IsInstantiated())
				{
					MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent -= OnFactionFriendlinessChanged;
				}
				if (MonoSingleton<SceneController>.IsInstantiated())
				{
					MonoSingleton<SceneController>.Instance.SceneSetup -= RebindOnGameplayStart;
				}
				if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
				{
					MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent -= OnPlayerTriggeredEventStarted;
					MonoSingleton<PlayerTriggeredEventManager>.Instance.EventEndedEvent -= OnPlayerTriggeredEventEnded;
				}
				this.OnDisposedEvent = null;
				tools.Clear();
				animationParamsUpdateTimer.Dispose();
				animationParamsUpdateTimer = null;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void OnFactionFriendlinessChanged(FactionFriendliness newFriendliness, FactionInstance factionInstance)
		{
			if (factionInstance == humanoidInstance.Faction)
			{
				SetDoorOpenerCollider();
			}
		}

		public override string GetMultiselectName()
		{
			return base.HumanoidInstance.ActiveBehaviour.GetMultiselectName();
		}

		public override string GetSimpleName()
		{
			return base.HumanoidInstance.ActiveBehaviour.GetSingleSelectName();
		}

		protected override void OnPointerEnter(Vector3 pos)
		{
			if (MonoSingleton<SelectionManager>.Instance.OrderType == OrderType.None)
			{
				base.OnPointerEnter(pos);
			}
		}

		internal override void Select()
		{
			if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible)
			{
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.SetWorldMapVisible(isWorldMapVisible: false);
			}
			if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.LeftControl))
			{
				ClickedJumpToUpperLayer();
			}
			else
			{
				base.Select();
			}
		}

		protected override string GetAnimatedAgentDataId()
		{
			return base.HumanoidInstance.GetGoapAgentID();
		}

		protected override string GetGoapAgentId()
		{
			return base.HumanoidInstance.GetGoapAgentID();
		}

		private void StartedBleeding(CreatureBase creatureBase)
		{
			if (humanoidInstance == creatureBase)
			{
				bleedingParticle.SetActive(value: true);
			}
		}

		private void StoppedBleeding(CreatureBase creatureBase)
		{
			if (humanoidInstance == creatureBase)
			{
				bleedingParticle.SetActive(value: false);
			}
		}

		public void ShowTool(string toolID, Transform socket = null)
		{
			if (string.IsNullOrEmpty(toolID))
			{
				return;
			}
			if (socket == null)
			{
				socket = base.BodyPreview.RightHandSocket;
			}
			if (!tools.ContainsKey(toolID))
			{
				GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(toolID);
				if (byAddress == null)
				{
					return;
				}
				tools.Add(toolID, UnityEngine.Object.Instantiate(byAddress, socket));
			}
			animator.RebindKeepState();
			tools[toolID].SetActive(value: true);
			currentRightHandItem = toolID;
			MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(GetAgentOwner(), toolID, value: true);
		}

		public void HideTool()
		{
			if (currentRightHandItem != null && tools.ContainsKey(currentRightHandItem))
			{
				tools[currentRightHandItem].SetActive(value: false);
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(GetAgentOwner(), currentRightHandItem, value: false);
			}
		}

		public GameObject GetCurrentTool()
		{
			if (currentRightHandItem != null && tools.TryGetValue(currentRightHandItem, out var value))
			{
				return value;
			}
			return null;
		}

		public void HandleUpdateName()
		{
			UpdatePanelTitle();
			InstantiateNameElement();
		}

		public void OnNPCBehaviourChanged()
		{
			InstantiateIndicator();
			UpdatePanelTitle();
			InstantiateNameElement();
			SetXRaymaterialOnChildren(base.transform);
		}

		private string GetEnemyName()
		{
			return panelTitle;
		}

		private void UpdatePanelTitle()
		{
			HumanoidBehaviour activeBehaviour = base.HumanoidInstance.ActiveBehaviour;
			string text = ((activeBehaviour is EnemyBehaviour) ? "<style=DefaultRed>" : ((!(activeBehaviour is TraderBehaviour)) ? "<style=DefaultYellow>" : "<style=DefaultBlue>"));
			panelTitle = text;
			string text2 = GetSimpleName();
			if (!string.IsNullOrEmpty(text2))
			{
				text2 = "(" + text2 + ")";
			}
			panelTitle = panelTitle + " " + humanoidInstance.Info.FirstName + " " + humanoidInstance.Info.LastName + "</style> " + text2;
		}

		protected override void UpdateCombatFootCircleIndicator()
		{
			if (!(feetCircleIndicator == null) && humanoidInstance != null && !humanoidInstance.HasDisposed)
			{
				EquipmentInstance bestCombatCoverEquipment = humanoidInstance.GetBestCombatCoverEquipment(DamageType.Melee);
				if (bestCombatCoverEquipment == null)
				{
					feetCircleIndicator.SetCoverAngle(0f);
				}
				else
				{
					feetCircleIndicator.SetCoverAngle(bestCombatCoverEquipment.Blueprint.CoverAngle);
				}
			}
		}

		private void InstantiateIndicator()
		{
			if (feetCircleIndicator != null)
			{
				UnityEngine.Object.Destroy(feetCircleIndicator.gameObject);
				feetCircleIndicator = null;
			}
			if (overheadBillboard != null)
			{
				UnityEngine.Object.Destroy(overheadBillboard);
				overheadBillboard = null;
			}
			string indicatorPrefabName = base.HumanoidInstance.ActiveBehaviour.IndicatorPrefabName;
			if (indicatorPrefabName != null)
			{
				GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(indicatorPrefabName);
				feetCircleIndicator = UnityEngine.Object.Instantiate(byAddress, Vector3.zero, Quaternion.identity, base.transform).GetComponent<AgentCircleIndicator>();
				feetCircleIndicator.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				UpdateCombatFootCircleIndicator();
			}
			string overheadBillboardPrefabName = base.HumanoidInstance.ActiveBehaviour.OverheadBillboardPrefabName;
			if (overheadBillboardPrefabName != null)
			{
				GameObject byAddress2 = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(overheadBillboardPrefabName);
				overheadBillboard = UnityEngine.Object.Instantiate(byAddress2, Vector3.zero, Quaternion.identity, base.transform);
				overheadBillboard.transform.localPosition = Vector3.zero;
			}
		}

		private void InstantiateNameElement()
		{
			HumanoidBehaviour activeBehaviour = base.HumanoidInstance.ActiveBehaviour;
			OverlayTextElementType overlayTextElementType = ((activeBehaviour is EnemyBehaviour) ? OverlayTextElementType.EnemyName : ((activeBehaviour is TraderBehaviour) ? OverlayTextElementType.TraderName : ((activeBehaviour is TraderBodyguardBehaviour) ? OverlayTextElementType.TraderBodyguardName : ((!(activeBehaviour is CaptiveNpcBehaviour)) ? OverlayTextElementType.Default : OverlayTextElementType.TraderBodyguardName))));
			OverlayTextElementType overlayTextElementType2 = overlayTextElementType;
			if (nameElement != null)
			{
				if (nameElement.Type == overlayTextElementType2)
				{
					nameElement.SetText(base.HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner.GetDefaultDisplayNameRole());
					return;
				}
				nameElement.Dispose();
				nameElement = null;
			}
			nameElement = FloatingElementFactory.ProduceTextElement(overlayTextElementType2, FloatingElementHolderType.Default, GetGuiOverlayHookTransform(), base.HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner.GetDefaultDisplayNameRole());
		}

		private void OnStatsInitialized(StatsInstance stats)
		{
			if (humanoidInstance == null)
			{
				Log.Warning("this.humanoidInstance == null", "C:\\GIT\\dev\\Assets\\Scripts\\View\\Humanoid\\NPCView.cs");
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(46, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Humanoid\\NPCView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Active behaviour: ");
				messageBuilder.AppendFormatted(humanoidInstance?.ActiveBehaviour);
				messageBuilder.AppendLiteral(", has died: ");
				messageBuilder.AppendFormatted(humanoidInstance?.HasDied);
				messageBuilder.AppendLiteral(", has disposed: ");
				messageBuilder.AppendFormatted(humanoidInstance?.HasDisposed);
			}
			Log.Warning(messageBuilder);
			if (humanoidInstance?.Stats == null)
			{
				Log.Warning("this.humanoidInstance.Stats == null", "C:\\GIT\\dev\\Assets\\Scripts\\View\\Humanoid\\NPCView.cs");
			}
			if (humanoidInstance?.Stats?.Controller == null)
			{
				Log.Warning("this.humanoidInstance.Stats.Controller == null", "C:\\GIT\\dev\\Assets\\Scripts\\View\\Humanoid\\NPCView.cs");
			}
			humanoidInstance.Stats.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Health, OnStatUpdated);
			humanoidInstance.Stats.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Sleep, OnStatUpdated);
			humanoidInstance.Stats.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Mood, OnStatUpdated);
			humanoidInstance.Stats.Controller.RegisterListener(StatEventType.AttributeModiferAdded, OnStatUpdated);
			humanoidInstance.Stats.Controller.RegisterListener(StatEventType.AttributeModiferRemoved, OnStatUpdated);
		}

		private void OnStatUpdated(object statInstance)
		{
			if (statInstance == null || !(statInstance is StatInstance { Type: StatType.Health } statInstance2) || base.HasDisposed)
			{
				return;
			}
			HumanoidInstance obj = humanoidInstance;
			if (obj == null || obj.HasDisposed)
			{
				return;
			}
			if (statInstance2.Current.IsCloseTo(statInstance2.Max, 0.1f))
			{
				if (!(healthBar == null))
				{
					healthBar.Dispose();
					healthBar = null;
				}
				return;
			}
			if (healthBar == null && statInstance2.Current < statInstance2.Max)
			{
				healthBar = FloatingElementFactory.ProduceProgressBarElement<LinearProgressBarFloatingElement>(OverlayProgressBarType.LineRed, FloatingElementHolderType.Default, GetGuiOverlayHookTransform());
				healthBar.SetIndex(0);
				healthBar.OnDisposedEvent += delegate
				{
					healthBar = null;
				};
				healthBar.SetTrailEnabled(enabled: true);
			}
			if (!(healthBar == null))
			{
				healthBar.SetValue(statInstance2.Current / statInstance2.Max);
			}
		}

		private void SetXRaymaterialOnChildren(Transform parent)
		{
			if (!(parent == null))
			{
				HumanoidBehaviour activeBehaviour = humanoidInstance.ActiveBehaviour;
				float num = ((activeBehaviour is EnemyBehaviour) ? 2f : ((!(activeBehaviour is PrisonerBehaviour)) ? 4f : 3f));
				float value = num;
				Renderer[] componentsInChildren = parent.GetComponentsInChildren<Renderer>();
				foreach (Renderer renderer in componentsInChildren)
				{
					MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(renderer);
					materialPropertyBlock.SetFloat(XRayColor, value);
					renderer.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}

		private void OnHitMissed(IDamageDealAgent deal, IDamageTakingAgent take, CombatMissType missType)
		{
			if (take == humanoidInstance && (CombatUtils.GetAttackType(deal) == AttackType.Melee || missType == CombatMissType.Evade) && HandleDamagePopup())
			{
				damagePopup.HitMessed(missType);
			}
		}

		private void OnHitTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (take == humanoidInstance)
			{
				if (healthBar != null && hitInfo.Damage > 0f)
				{
					QuickWiggleEffect.WiggleX(healthBar.transform.GetChild(0), 0.25f, 16f);
				}
				if (HandleDamagePopup())
				{
					damagePopup.FireDamage(hitInfo);
				}
			}
		}

		private bool HandleDamagePopup()
		{
			if (damagePopup == null)
			{
				damagePopup = FloatingElementFactory.ProduceDamagePopupElement(GetGuiOverlayHookTransform());
			}
			return damagePopup != null;
		}

		public override InfoPanelData GetInfoPanelData()
		{
			List<InfoPanelStat> infoStats = HumanoidView.GetInfoStats(humanoidInstance);
			List<string> infos = GetInfos();
			InfoPanelEnemyBody body = new InfoPanelEnemyBody(humanoidInstance, infoStats, infos);
			InfoPanelFooter footer = new InfoPanelFooter(GetFooterData(), humanoidInstance);
			return new InfoPanelData(new InfoPanelHeader("Enemy", GetEnemyName(), string.Empty), body, footer);
		}

		public override InfoPanelData UpdateCallback()
		{
			if (humanoidInstance == null || humanoidInstance.HasDisposed || humanoidInstance.HasDied)
			{
				return null;
			}
			return GetInfoPanelData();
		}

		protected override StatsInstance GetAgentStats()
		{
			return humanoidInstance.Stats;
		}

		private List<string> GetInfos()
		{
			List<string> infos = new List<string>();
			infos.AddIfNotNullOrEmpty("<style=Desc>" + CreatureBaseUtils.GetLocalizedCurrentActionInfo(humanoidInstance) + "</style>");
			AnimatedAgentView.FillAttackersInfo(ref infos, humanoidInstance);
			if (humanoidInstance.ActiveBehaviour is CaptiveLabourerBehaviour)
			{
				infos.AddIfNotNullOrEmpty("<style=Desc>" + MonoSingleton<LocalizationController>.Instance.GetText("captive_labourer_work_info", humanoidInstance.Info.BodyType) + "</style>");
			}
			return infos;
		}

		private void FillDebugInfo(ref List<string> infos)
		{
			if (CombatUtils.IsNullOrDisposed(base.humanoidInstance))
			{
				return;
			}
			MapNode node = base.humanoidInstance.GetNode();
			infos.Add($"[Dev] node: {node?.Position ?? Vec3Int.zero}");
			List<IReservable> reservedBy = MonoSingleton<ReservationManager>.Instance.GetReservedBy(base.humanoidInstance);
			List<string> list = new List<string>();
			foreach (IReservable item2 in reservedBy)
			{
				string item = item2.GetType().Name;
				if (item2 is WorldObject worldObject)
				{
					item = $"({item2.GetType().Name}, {worldObject.GridDataPosition})";
				}
				if (item2 is AnimalInstance animalInstance)
				{
					item = $"({animalInstance.Blueprint.GetID()}: {animalInstance.AnimalType}, {animalInstance.GetFullName()})";
				}
				if (item2 is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					item = "(" + humanoidInstance.Info.GetFullName() + ")";
				}
				if (item2 is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsNpc())
				{
					item = $"({humanoidInstance2.Info.GetFullName()} (hostile: {humanoidInstance2.Faction.IsHostile()}, aggressive: {humanoidInstance2.IsEnemy()}))";
				}
				list.Add(item);
			}
			infos.Add("[Dev] climbing: " + base.humanoidInstance.PathDriver.ClimbDirection);
			infos.Add($"[Dev] on fire: {base.humanoidInstance.IsOnFire}");
			infos.Add("[Dev] reserved: " + string.Join(", ", list));
		}

		private List<string> GetModifiers()
		{
			List<string> list = new List<string>();
			if (humanoidInstance.Faction != null)
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText("general_faction");
				FactionFriendliness friendliness = humanoidInstance.Faction.GetFriendliness();
				string text2 = MonoSingleton<LocalizationController>.Instance.GetText(humanoidInstance.Faction.GetFriendlinessTextKey());
				string text3 = "Normal";
				switch (friendliness)
				{
				case FactionFriendliness.Friendly:
					text3 = "DefaultGreen";
					break;
				case FactionFriendliness.Hostile:
				case FactionFriendliness.PermanentlyHostile:
					text3 = "DefaultRed";
					break;
				}
				list.Add(text + ": " + humanoidInstance.Faction.NameLocalized);
				list.Add("<style=" + text3 + ">(" + text2 + ")</style>");
			}
			return list;
		}

		private List<InfoPanelAction> GetFooterData()
		{
			CaptiveNpcBehaviour captiveBehaviour = humanoidInstance.CaptiveNpcBehaviour;
			if (captiveBehaviour == null || captiveBehaviour.Owner != null)
			{
				return new List<InfoPanelAction>();
			}
			int currentIndex = (captiveBehaviour.MarkedForUnShackling ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] array = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ShacklesOffPrisoner"), delegate
				{
					OnShacklesOffToggle(captiveBehaviour);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ShacklesOffPrisonerToggled"), delegate
				{
					OnShacklesOffToggle(captiveBehaviour);
				})
			};
			_ = captiveBehaviour.MarkedForShackling;
			KeyValuePair<SelectionInputActionData, Action>[] array2 = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ShacklesOnPrisoner"), delegate
				{
					OnShacklesOnToggle(captiveBehaviour);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ShacklesOnPrisonerToggled"), delegate
				{
					OnShacklesOnToggle(captiveBehaviour);
				})
			};
			int currentIndex2 = (captiveBehaviour.MarkedForRecruiting ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("RecruitPrisoner"), delegate
				{
					RecruitPrisoner(captiveBehaviour, state: true);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
				{
					RecruitPrisoner(captiveBehaviour, state: false);
				})
			};
			int currentIndex3 = (captiveBehaviour.MarkedForStripping ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions2 = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("StripPrisoner"), delegate
				{
					StripPrisoner(captiveBehaviour, state: true);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
				{
					StripPrisoner(captiveBehaviour, state: false);
				})
			};
			int currentIndex4 = (captiveBehaviour.MarkedForReleasing ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions3 = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ReleasePrisoner"), delegate
				{
					ReleasePrisoner(captiveBehaviour, state: true);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
				{
					ReleasePrisoner(captiveBehaviour, state: false);
				})
			};
			if (captiveBehaviour.IsCaptiveLabourer)
			{
				return new List<InfoPanelAction>
				{
					new InfoPanelAction(captiveBehaviour.Shackled ? array : array2, currentIndex),
					new InfoPanelAction(objectActions2, currentIndex3),
					new InfoPanelAction(objectActions3, currentIndex4)
				};
			}
			return new List<InfoPanelAction>
			{
				new InfoPanelAction(captiveBehaviour.Shackled ? array : array2, currentIndex),
				new InfoPanelAction(objectActions, currentIndex2),
				new InfoPanelAction(objectActions2, currentIndex3),
				new InfoPanelAction(objectActions3, currentIndex4)
			};
		}

		private void RecruitPrisoner(CaptiveNpcBehaviour prisonerBehaviour, bool state)
		{
			prisonerBehaviour.MarkForRecruiting(state);
		}

		private void StripPrisoner(CaptiveNpcBehaviour prisonerBehaviour, bool state)
		{
			prisonerBehaviour.MarkForStripping(state);
		}

		private void ReleasePrisoner(CaptiveNpcBehaviour prisonerBehaviour, bool state)
		{
			prisonerBehaviour.MarkForReleasing(state);
		}

		private void OnShacklesOnToggle(CaptiveNpcBehaviour prisonerBehaviour)
		{
			if (!prisonerBehaviour.MarkedForShackling && !MonoSingleton<ResourcePileManager>.Instance.ResourcePileWithProtoIdExists("shackles"))
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText("equipment_name_shackles");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("no_item_available").Replace("<item_name>", text));
			}
			prisonerBehaviour.MarkForShackling(!prisonerBehaviour.MarkedForShackling);
		}

		private void OnShacklesOffToggle(CaptiveNpcBehaviour prisonerBehaviour)
		{
			prisonerBehaviour.MarkForUnShackling(!prisonerBehaviour.MarkedForUnShackling);
		}

		private void SetDoorOpenerCollider()
		{
			if (humanoidInstance?.Faction != null)
			{
				if (doorOpenerCollider == null)
				{
					Log.Info("Enemy does not have a door opener collider.", "C:\\GIT\\dev\\Assets\\Scripts\\View\\Humanoid\\NPCView.cs");
				}
				else
				{
					doorOpenerCollider.isTrigger = humanoidInstance.IsFriendlyFaction();
				}
			}
		}
	}
}
