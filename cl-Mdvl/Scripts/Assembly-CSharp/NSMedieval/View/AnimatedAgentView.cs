using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FloatingOverlaySystem.Elements;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Extensions;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.Scripts.Pooler;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.View
{
	public abstract class AnimatedAgentView : SelectableObject, IAgentView
	{
		public bool IsRotationLocked;

		[SerializeField]
		protected Animator animator;

		[SerializeField]
		[Tooltip("Used for emitting particles from SkinnedMeshRenderer")]
		private SkinnedMeshRenderer skinnedMeshRenderer;

		[SerializeField]
		protected GameObject fireObject;

		[SerializeField]
		private float fireParticlesRate = 200f;

		private ParticleSystem[] fireParticles;

		[NonSerialized]
		private AnimatedAgentData data;

		protected static readonly StringBuilder StringBuilder = new StringBuilder();

		[NonSerialized]
		private Dictionary<string, FloatingElementBase> floatingElements;

		[NonSerialized]
		private IconCircleFloatingElement[] floatingIcons = new IconCircleFloatingElement[3];

		[NonSerialized]
		private AudioEventsComponent audioEventsComponent;

		[NonSerialized]
		private readonly Dictionary<string, GameObject> activeParticles = new Dictionary<string, GameObject>();

		private Transform parent;

		private bool isStarted;

		private float animStopDelayTime;

		private string footstepEventId = "Footsteps";

		private float agentScale = 1f;

		private bool isAnimatedAgentDestroyed;

		[NonSerialized]
		private readonly HashSet<string> animalCallGoals = new HashSet<string> { "IdleGoal", "AnimalFleeingIdleGoal" };

		[SerializeField]
		private List<FootprintType> agentFootprints = new List<FootprintType>();

		public Quaternion TargetRotation { get; set; }

		public List<FootprintType> AgentFootprints => agentFootprints;

		public bool TriggeredAnimationRunning { get; private set; }

		public bool CombatAnimationEventsEnabled { get; set; }

		public Animator Animator => animator;

		public void TrySetTrigger(string triggerName)
		{
			if (!isAnimatedAgentDestroyed)
			{
				animator.SetTrigger(triggerName);
			}
		}

		public void ResetTriggers()
		{
			if (!isAnimatedAgentDestroyed)
			{
				animator.ResetTriggers();
			}
		}

		public void TrySetParameter(string paramName, int value)
		{
			if (!isAnimatedAgentDestroyed)
			{
				animator.SetInteger(paramName, value);
			}
		}

		public void TrySetParameter(string paramName, float value)
		{
			if (!isAnimatedAgentDestroyed)
			{
				animator.SetFloat(paramName, value);
			}
		}

		public void TrySetParameter(string paramName, bool value)
		{
			if (!isAnimatedAgentDestroyed)
			{
				animator.SetBool(paramName, value);
			}
		}

		public void SetLayerWeight(string layerName, float weight)
		{
			if (!isAnimatedAgentDestroyed)
			{
				int layerIndex = animator.GetLayerIndex(layerName);
				if (layerIndex > 0)
				{
					animator.SetLayerWeight(layerIndex, weight);
				}
			}
		}

		private void CombatAnimationEvent(string eventName)
		{
			if (CombatAnimationEventsEnabled)
			{
				OnCombatAnimationEvent(eventName);
			}
		}

		protected virtual void OnCombatAnimationEvent(string eventName)
		{
		}

		public void ForceQuitAnimation()
		{
			OnTriggerAnimation("ForceQuit");
		}

		public virtual void OnTriggerAnimation(string trigger)
		{
			if (!string.IsNullOrEmpty(trigger) && !(animator == null))
			{
				if (trigger != "ForceQuit")
				{
					ResetTriggers();
					TriggeredAnimationRunning = true;
				}
				else if (TriggeredAnimationRunning)
				{
					TriggeredAnimationRunning = false;
					ResetTriggers();
					MonoSingleton<AnimationController>.Instance.OnAnimationEnded(GetAgent().AgentOwner);
				}
				TrySetTrigger(trigger);
			}
		}

		protected virtual void Update()
		{
			if (!IsRotationLocked)
			{
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, TargetRotation, 540f * Time.deltaTime);
			}
		}

		public void FaceObject(Vector3 objectPosition)
		{
			Vector3 position = base.transform.position;
			Vector3 vector = new Vector3(objectPosition.x, position.y, objectPosition.z) - position;
			if (vector != Vector3.zero)
			{
				Quaternion targetRotation = Quaternion.LookRotation(vector, Vector3.up);
				TargetRotation = targetRotation;
			}
		}

		public void FaceAway(Vector3 objectPosition)
		{
			Vector3 position = base.transform.position;
			Vector3 vector = new Vector3(objectPosition.x, position.y, objectPosition.z) - position;
			if (vector != Vector3.zero)
			{
				Quaternion targetRotation = Quaternion.LookRotation(-vector, Vector3.up);
				TargetRotation = targetRotation;
			}
		}

		public void FaceObject(Quaternion rotation)
		{
			TargetRotation = rotation;
		}

		public void FaceObject(Transform targetTransform)
		{
			TargetRotation = targetTransform.rotation;
		}

		public void SetParent(Transform targetTransform)
		{
			if (parent == null)
			{
				parent = base.transform;
			}
			base.transform.SetParent(targetTransform, worldPositionStays: true);
		}

		public void ResetParent()
		{
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(8, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Universal\\AnimatedAgentView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Before: ");
				messageBuilder.AppendFormatted(base.transform.position);
			}
			Log.Info(messageBuilder);
			base.transform.SetParent(parent, worldPositionStays: true);
			messageBuilder = new FVLogInfoInterpolationHandler(7, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Universal\\AnimatedAgentView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("After: ");
				messageBuilder.AppendFormatted(base.transform.position);
			}
			Log.Info(messageBuilder);
		}

		public void LookAt(Transform targetTransform)
		{
			FaceObject(targetTransform.position);
		}

		public void SetEulerAngle(Vector3 newEulerAngles)
		{
			TargetRotation = Quaternion.Euler(newEulerAngles);
		}

		private static string GetFloatingElementKey(OverlayProgressBarType type)
		{
			return string.Format("{0}{1}", "OverlayProgressBarType", (int)type);
		}

		private static string GetFloatingElementKey(OverlayIconCircleType type)
		{
			return string.Format("{0}{1}", "OverlayIconCircleType", (int)type);
		}

		public ProgressBarFloatingElement GetProgressBar(OverlayProgressBarType type = OverlayProgressBarType.None)
		{
			if (!MonoSingleton<LoadingController>.IsInstantiated() || LoadingController.IsSceneTransition)
			{
				return null;
			}
			string key = GetFloatingElementKey(type);
			if (floatingElements.TryGetValue(key, out var value) && value != null)
			{
				return (ProgressBarFloatingElement)value;
			}
			ProgressBarFloatingElement progressBarFloatingElement = FloatingElementFactory.ProduceProgressBarElement(type, FloatingElementHolderType.Default, GetGuiOverlayHookTransform());
			progressBarFloatingElement.OnDisposedEvent += delegate
			{
				floatingElements[key] = null;
			};
			floatingElements[key] = progressBarFloatingElement;
			return progressBarFloatingElement;
		}

		protected IconCircleFloatingElement GetIconCircle(OverlayIconCircleType type)
		{
			if (!isStarted || !MonoSingleton<LoadingController>.IsInstantiated() || LoadingController.IsSceneTransition)
			{
				return null;
			}
			string key = GetFloatingElementKey(type);
			if (floatingElements.TryGetValue(key, out var value) && value != null)
			{
				return (IconCircleFloatingElement)value;
			}
			IconCircleFloatingElement iconCircleFloatingElement = FloatingElementFactory.ProduceIconCircleElement(type, FloatingElementHolderType.Default, GetGuiOverlayHookTransform());
			iconCircleFloatingElement.OnDisposedEvent += delegate
			{
				floatingElements[key] = null;
			};
			floatingElements[key] = iconCircleFloatingElement;
			return iconCircleFloatingElement;
		}

		public void DestroyProgressBar(OverlayProgressBarType type)
		{
			if (floatingElements == null)
			{
				return;
			}
			if (type == OverlayProgressBarType.Last)
			{
				foreach (var (key, floatingElementBase2) in floatingElements)
				{
					if (!(floatingElementBase2 == null) && floatingElementBase2 is ProgressBarFloatingElement)
					{
						floatingElements[key].Dispose();
						floatingElements[key] = null;
					}
				}
				return;
			}
			string floatingElementKey = GetFloatingElementKey(type);
			if (floatingElements.TryGetValue(floatingElementKey, out var value) && value != null)
			{
				floatingElements[floatingElementKey].Dispose();
				floatingElements[floatingElementKey] = null;
			}
		}

		protected void DestroyIconCircle(OverlayIconCircleType type)
		{
			if (floatingElements == null)
			{
				return;
			}
			if (type == OverlayIconCircleType.Last)
			{
				foreach (var (key, floatingElementBase2) in floatingElements)
				{
					if (!(floatingElementBase2 == null) && floatingElementBase2 is IconCircleFloatingElement)
					{
						floatingElements[key].Dispose();
						floatingElements[key] = null;
					}
				}
				return;
			}
			string floatingElementKey = GetFloatingElementKey(type);
			if (floatingElements.TryGetValue(floatingElementKey, out var value) && value != null)
			{
				floatingElements[floatingElementKey].Dispose();
				floatingElements[floatingElementKey] = null;
			}
		}

		public abstract Transform GetGuiOverlayHookTransform();

		public void SetAudioEventParameters(string audioEvent, Dictionary<string, float> parameters)
		{
			if (!(audioEventsComponent == null))
			{
				audioEventsComponent.SetEventParameters(audioEvent, parameters);
			}
		}

		public void SetAudioEventParameter(string audioEvent, KeyValuePair<string, float> parameter)
		{
			if (!(audioEventsComponent == null))
			{
				audioEventsComponent.SetEventParameter(audioEvent, parameter);
			}
		}

		private void OnGridSpaceChanged(CreatureBase creatureBase, MapNode previousNode, MapNode currentNode)
		{
			if (audioEventsComponent == null || !creatureBase.Equals(GetAsCreature()))
			{
				return;
			}
			HandleFootstepsSound(currentNode);
			if (GetAsCreature() is AnimalInstance animalInstance && animalCallGoals.Contains(CreatureBaseUtils.GetGoalName(animalInstance)))
			{
				string eventId = animalInstance.Blueprint.GetID().CapitalizeFirst() + "Call";
				if (MonoRepository<SoundRepository, SoundEvent>.Instance.EventExists(eventId))
				{
					audioEventsComponent.PlayEvent(eventId);
				}
			}
		}

		private void HandleFootstepsSound(MapNode mapNode)
		{
			if (string.IsNullOrEmpty(footstepEventId))
			{
				return;
			}
			VoxelType voxelType = mapNode?.GetNodeBelow()?.VoxelType;
			if (!(voxelType == null))
			{
				Dictionary<string, float> dictionary = DictionaryPool<string, float>.Get();
				dictionary.Add("WalkableMaterial", GetSoundCategory(mapNode, voxelType));
				dictionary.Add("Weight", GetAsCreature().GetWeight());
				dictionary.Add("Wet", GetWetnessValue(mapNode));
				PathfinderAgentDriver agentPathDriver = GetAgentPathDriver(GetAsCreature());
				if (agentPathDriver != null)
				{
					dictionary.Add("WalkSpeed", IsRunning(agentPathDriver) ? 1 : 0);
				}
				SetAudioEventParameters(footstepEventId, dictionary);
				DictionaryPool<string, float>.Return(dictionary);
			}
		}

		private float GetSnowValue(MapNode mapNode)
		{
			SnowGrassWetnessManager snowGrassWetnessManager = VillageManager.ActiveVillage.Map.SnowGrassWetnessManager;
			if (snowGrassWetnessManager != null)
			{
				return (float)(int)snowGrassWetnessManager.GetSnow(mapNode.Index) / 255f;
			}
			return 0f;
		}

		private float GetWetnessValue(MapNode mapNode)
		{
			SnowGrassWetnessManager snowGrassWetnessManager = VillageManager.ActiveVillage.Map.SnowGrassWetnessManager;
			if (snowGrassWetnessManager != null)
			{
				return (float)(int)snowGrassWetnessManager.GetWetness(mapNode.Index) / 255f;
			}
			return 0f;
		}

		private int GetSoundCategory(MapNode mapNode, VoxelType voxelType)
		{
			if (IsShallowWater(mapNode))
			{
				return 9;
			}
			if (GetSnowValue(mapNode) >= 0.01f)
			{
				return 7;
			}
			if (mapNode.GetWorldObject(GridDataType.PlantMapResource) is PlantMapResourceInstance plantMapResourceInstance && plantMapResourceInstance.Blueprint.WalkableMaterialCategory != SoundWalkableMaterialCategory.None)
			{
				return (int)plantMapResourceInstance.Blueprint.WalkableMaterialCategory;
			}
			if (mapNode.GetWorldObject(GridDataType.BuildingFinished) is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.Blueprint.WalkableMaterialCategory != SoundWalkableMaterialCategory.None)
			{
				return (int)baseBuildingInstance.Blueprint.WalkableMaterialCategory;
			}
			return (int)voxelType.SoundWalkableMaterialCategory;
		}

		private bool IsShallowWater(MapNode mapNode)
		{
			if (mapNode.DataType == GridDataType.Slope)
			{
				return false;
			}
			VillageMap map = VillageManager.ActiveVillage.Map;
			MapNode nodeAbove = mapNode.GetNodeAbove();
			MapNode nodeBelow = mapNode.GetNodeBelow();
			if (map.WaterManager.IsWaterAt(mapNode.Index) || map.WaterManager.IsWaterAt(nodeBelow.Index))
			{
				WaterDepthLevel waterDepthLevel = ((nodeAbove == null) ? WaterDepthLevel.None : map.WaterManager.GetWaterDepthLevel(nodeAbove.Index));
				WaterDepthLevel waterDepthLevel2 = map.WaterManager.GetWaterDepthLevel(mapNode.Index);
				if (waterDepthLevel2 > waterDepthLevel)
				{
					waterDepthLevel = waterDepthLevel2;
				}
				return waterDepthLevel == WaterDepthLevel.Low;
			}
			return false;
		}

		public void StartParticle(string name)
		{
			if (activeParticles.ContainsKey(name))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Universal\\AnimatedAgentView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Humanoid particle ");
					messageBuilder.AppendFormatted(name);
					messageBuilder.AppendLiteral(" already running. Can not double start");
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				GameObject gameObject = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(name, base.transform.position, autoStop: false, useUnscaledTime: false, null, skinnedMeshRenderer);
				if (gameObject != null)
				{
					gameObject.transform.SetParent(base.transform);
					activeParticles[name] = gameObject;
				}
			}
		}

		public void StopParticle(string name)
		{
			if (activeParticles.ContainsKey(name))
			{
				if (MonoSingleton<ParticleSystemPool>.IsInstantiated())
				{
					MonoSingleton<ParticleSystemPool>.Instance.ReturnToPool(activeParticles[name]);
				}
				activeParticles.Remove(name);
			}
		}

		internal override void Select()
		{
			base.Select();
			if (base.Selected)
			{
				MonoSingleton<GoapController>.Instance.AgentSelected(selected: true, GetAgent());
			}
		}

		internal override void Deselect(bool isSilent = false)
		{
			base.Deselect(isSilent);
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.ToggleInfoCursor(active: false);
			}
			if (GetAgent() != null && MonoSingleton<GoapController>.IsInstantiated())
			{
				MonoSingleton<GoapController>.Instance.AgentSelected(selected: false, GetAgent());
			}
		}

		protected void SetupGoapView()
		{
			data = Repository<AnimatedAgentDataRepository, AnimatedAgentData>.Instance.GetData(GetAnimatedAgentDataId());
		}

		protected abstract string GetAnimatedAgentDataId();

		protected abstract string GetGoapAgentId();

		protected void DestroyAnimatedAgent()
		{
			isAnimatedAgentDestroyed = true;
			if (MonoSingleton<AnimationController>.IsInstantiated())
			{
				MonoSingleton<AnimationController>.Instance.ParameterIntChangeEvent -= SetParameter;
				MonoSingleton<AnimationController>.Instance.ParameterFloatChangeEvent -= SetParameter;
				MonoSingleton<AnimationController>.Instance.ParameterBoolChangeEvent -= SetParameter;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.LateTick -= OnLateTick;
			}
			if (activeParticles.Count > 0)
			{
				foreach (string item in activeParticles.Keys.ToList())
				{
					StopParticle(item);
				}
			}
			DestroySelectableObject();
		}

		public virtual void EatParticles()
		{
		}

		public virtual void StopEatParticles()
		{
		}

		public virtual void OnCarcassProximityEnter(WorldObject worldObject)
		{
		}

		protected static void FillAttackersInfo(ref List<string> infos, IDamageTakingAgent agent)
		{
			HashSet<IDamageDealAgent> attackersForTarget = MonoSingleton<CombatTargetManager>.Instance.GetAttackersForTarget(agent);
			if (attackersForTarget == null || attackersForTarget.Count <= 0)
			{
				return;
			}
			using PooledList<IDamageDealAgent> pooledList = attackersForTarget.ToPooledListJanitor();
			infos.Add(MonoSingleton<LocalizationController>.Instance.GetText("hud_lb_targeted_by") + ":");
			foreach (IDamageDealAgent item in pooledList)
			{
				string text = string.Empty;
				if (item is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					text = "<style=AltColor>" + humanoidInstance.Info.FirstName + "</style>";
				}
				else if (item is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsNpc())
				{
					text = "<style=DefaultRed>" + humanoidInstance2.Info.FirstName + " " + humanoidInstance2.Info.LastName + "</style>";
				}
				else if (item is AnimalInstance animalInstance)
				{
					text = "<style=AltColor>" + AnimalUtils.GetLocalizedName(animalInstance.Blueprint) + "</style>";
				}
				if (!(text == string.Empty))
				{
					infos.Add(" " + text);
				}
			}
		}

		protected abstract StatsInstance GetAgentStats();

		protected override void Awake()
		{
			base.Awake();
			TargetRotation = base.transform.rotation;
		}

		protected override void Start()
		{
			base.Start();
			floatingElements = DictionaryPool<string, FloatingElementBase>.Get();
			audioEventsComponent = GetComponent<AudioEventsComponent>();
			if (GetAsCreature() is AnimalInstance animalInstance)
			{
				footstepEventId = animalInstance.Blueprint.FootstepsAudioEvent ?? string.Empty;
			}
			MonoSingleton<AnimationController>.Instance.ParameterIntChangeEvent += SetParameter;
			MonoSingleton<AnimationController>.Instance.ParameterFloatChangeEvent += SetParameter;
			MonoSingleton<AnimationController>.Instance.ParameterBoolChangeEvent += SetParameter;
			GetAsCreature().OnGridSpaceChangedEvent += OnGridSpaceChanged;
			MonoSingleton<SceneController>.Instance.LateTick += OnLateTick;
			isStarted = true;
			agentScale = base.transform.localScale.x;
			if ((bool)fireObject)
			{
				fireParticles = fireObject.GetComponentsInChildren<ParticleSystem>();
				CreatureBase asCreature = GetAsCreature();
				if (asCreature != null)
				{
					TickFireVisuals(asCreature);
				}
			}
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<AnimationController>.IsInstantiated())
			{
				MonoSingleton<AnimationController>.Instance.ParameterIntChangeEvent -= SetParameter;
				MonoSingleton<AnimationController>.Instance.ParameterFloatChangeEvent -= SetParameter;
				MonoSingleton<AnimationController>.Instance.ParameterBoolChangeEvent -= SetParameter;
			}
			CreatureBase asCreature = GetAsCreature();
			if (asCreature != null)
			{
				asCreature.OnGridSpaceChangedEvent -= OnGridSpaceChanged;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.LateTick -= OnLateTick;
			}
			base.OnDestroy();
			if (floatingElements != null)
			{
				DictionaryPool<string, FloatingElementBase>.Return(floatingElements);
			}
		}

		protected virtual bool IsRunningDisabled()
		{
			return false;
		}

		private void GoapAnimationEvent(string eventName)
		{
			IGoapAgentOwner goapAgentOwner = GetAgent()?.AgentOwner;
			if (goapAgentOwner != null)
			{
				MonoSingleton<AnimationController>.Instance.OnAnimationGoapEventFired(goapAgentOwner, eventName);
			}
		}

		private void SetParameter(IGoapAgentOwner owner, string name, int value)
		{
			if (GetAgent()?.AgentOwner == owner)
			{
				TrySetParameter(name, value);
			}
		}

		private void SetParameter(IGoapAgentOwner owner, string name, float value)
		{
			if (GetAgent()?.AgentOwner == owner)
			{
				TrySetParameter(name, value);
			}
		}

		private void SetParameter(IGoapAgentOwner owner, string name, bool value)
		{
			if (GetAgent()?.AgentOwner == owner)
			{
				TrySetParameter(name, value);
			}
		}

		private void OnLateTick(float deltaTime)
		{
			if (MonoSingleton<GameSpeedManager>.Instance.CurrentSpeedIndex == GameSpeedIndex.Pause || deltaTime.IsCloseToZero() || !isStarted)
			{
				return;
			}
			CreatureBase asCreature = GetAsCreature();
			PathfinderAgentDriver agentPathDriver = GetAgentPathDriver(asCreature);
			if (agentPathDriver == null)
			{
				return;
			}
			using (ProfilerSampleJanitor.Begin("AnimatedAgentView.LateTick"))
			{
				TickFireVisuals(asCreature);
				if (!asCreature.IsFallingDown)
				{
					animator.SetBool("Swimming", agentPathDriver.IsSwimming);
					if (agentPathDriver.IsMoving)
					{
						animStopDelayTime = 0.1f;
						TrySetParameter("FallDown", value: false);
						TrySetParameter("ClimbDir", (int)agentPathDriver.ClimbDirection);
						TrySetParameter("Moving", value: true);
						bool flag = IsRunning(agentPathDriver);
						TrySetParameter("Running", flag);
						float magnitude = agentPathDriver.Velocity.magnitude;
						if (flag)
						{
							animator.speed = ((magnitude - data.MinRunSpeedThreshold) * data.RunAnimationSpeedMultiply + data.RunAnimationSpeedAdd) / Mathf.Sqrt(agentScale);
						}
						else
						{
							animator.speed = (magnitude * data.WalkAnimationSpeedMultiply + data.WalkAnimationSpeedAdd) / Mathf.Sqrt(agentScale);
						}
					}
					else
					{
						animator.speed = 1f;
						if (animStopDelayTime > 0f)
						{
							animStopDelayTime -= Time.deltaTime;
						}
						else
						{
							TrySetParameter("FallDown", value: false);
							TrySetParameter("Moving", value: false);
							TrySetParameter("Running", value: false);
							TrySetParameter("ClimbDir", (int)agentPathDriver.ClimbDirection);
						}
					}
				}
				else
				{
					animator.speed = 1f;
					animStopDelayTime = 0.1f;
					TrySetParameter("Moving", value: false);
					TrySetParameter("Running", value: false);
					TrySetParameter("ClimbDir", -1);
					TrySetParameter("FallDown", value: true);
				}
				if (TriggeredAnimationRunning && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
				{
					MonoSingleton<AnimationController>.Instance.OnAnimationEnded(GetAgent()?.AgentOwner);
					TriggeredAnimationRunning = false;
				}
			}
		}

		private void TickFireVisuals(CreatureBase creatureBase)
		{
			float flameValue = creatureBase.GetFlameValue();
			if (!(fireObject != null))
			{
				return;
			}
			if (flameValue > 0.33f && !fireObject.activeSelf)
			{
				fireObject.SetActive(value: true);
			}
			if (flameValue < 0.33f && fireObject.activeSelf)
			{
				fireObject.SetActive(value: false);
			}
			if (flameValue > 0.33f && fireParticles != null)
			{
				ParticleSystem[] array = fireParticles;
				for (int i = 0; i < array.Length; i++)
				{
					ParticleSystem.EmissionModule emission = array[i].emission;
					emission.rateOverTimeMultiplier = (flameValue - 0.33f) * fireParticlesRate;
				}
			}
		}

		private bool IsRunning(PathfinderAgentDriver driver)
		{
			if (driver.Velocity.magnitude > data.MinRunSpeedThreshold)
			{
				return !IsRunningDisabled();
			}
			return false;
		}

		private static PathfinderAgentDriver GetAgentPathDriver(CreatureBase agent)
		{
			return agent.PathDriver;
		}

		public Agent GetAgent()
		{
			return GetAsCreature()?.GetGoapAgent();
		}

		public IGoapAgentOwner GetAgentOwner()
		{
			return GetAsCreature();
		}
	}
}
