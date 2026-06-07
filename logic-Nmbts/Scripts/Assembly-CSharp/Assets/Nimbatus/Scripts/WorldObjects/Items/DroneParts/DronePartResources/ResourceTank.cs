using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.DronePartResources
{
	public class ResourceTank : SensorPart, IHasResources
	{
		public float ResourceCapacity;

		public float DrainSpeed;

		public AnimationCurve FillCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		private EventKeyBinding _tankFull;

		private EventKeyBinding _tankEmpty;

		public ResourceParticleSystem DrainParticles;

		public Renderer AmountDisplayRenderer;

		[NonSerialized]
		[HideInInspector]
		public float CurrentAmountCommonOre;

		[NonSerialized]
		[HideInInspector]
		public float CurrentAmountRareOre;

		private float _lastDrainTime;

		private bool _isDraining;

		private Transform _drainTarget;

		private bool _wasEmpty;

		private bool _wasFull;

		private float _miningModifier;

		public override void PostLoad()
		{
			base.PostLoad();
			CurrentAmountCommonOre = 0f;
			CurrentAmountRareOre = 0f;
		}

		protected override void Awake()
		{
			base.Awake();
			CurrentAmountCommonOre = 0f;
			CurrentAmountRareOre = 0f;
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			return new List<KeyBinding>();
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_tankFull = new EventKeyBinding("Tank full", KeyCode.None);
			_tankEmpty = new EventKeyBinding("Tank empty", KeyCode.None);
			return new List<EventKeyBinding> { _tankFull, _tankEmpty };
		}

		public float GetRechargePerSecond(EResourceType resourceType)
		{
			return 0f;
		}

		protected override void Start()
		{
			base.Start();
			if (AmountDisplayRenderer != null)
			{
				AmountDisplayRenderer.material.SetFloat("_Fuel", 0f);
			}
			SetResourceAmount(EResourceType.CommonOre, 0f);
			SetResourceAmount(EResourceType.RareOre, 0f);
			base.CurrentResourceHub.RegisterPart(EResourceType.RareOre, this);
			base.CurrentResourceHub.RegisterPart(EResourceType.CommonOre, this);
			_miningModifier = 1f;
			List<DroneEffect> activeEffects = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects;
			ResourceCollectionEffect resourceCollectionEffect = ((activeEffects != null) ? activeEffects.OfType<ResourceCollectionEffect>().FirstOrDefault() : null);
			if (resourceCollectionEffect != null)
			{
				_miningModifier = (float)(100 + resourceCollectionEffect.ResourceCollectionIncrease) / 100f;
			}
		}

		public float GetResourceCapacity(EResourceType resourceType)
		{
			switch (resourceType)
			{
			case EResourceType.CommonOre:
				return ResourceCapacity - CurrentAmountRareOre;
			case EResourceType.RareOre:
				return ResourceCapacity - CurrentAmountCommonOre;
			default:
				return ResourceCapacity;
			}
		}

		public float GetResourceAmount(EResourceType resourceType)
		{
			switch (resourceType)
			{
			case EResourceType.CommonOre:
				return CurrentAmountCommonOre;
			case EResourceType.RareOre:
				return CurrentAmountRareOre;
			default:
				return CurrentAmountCommonOre + CurrentAmountRareOre;
			}
		}

		public void ChangeResourceHub(ResourceHub oldHub, ResourceHub newHub)
		{
			if (oldHub != null)
			{
				oldHub.UnregisterPart(EResourceType.CommonOre, this);
			}
			if (oldHub != null)
			{
				oldHub.UnregisterPart(EResourceType.RareOre, this);
			}
			newHub.RegisterPart(EResourceType.CommonOre, this);
			newHub.RegisterPart(EResourceType.RareOre, this);
		}

		public void SetResourceAmount(EResourceType resourceType, float value)
		{
			switch (resourceType)
			{
			case EResourceType.CommonOre:
				CurrentAmountCommonOre = value;
				break;
			case EResourceType.RareOre:
				CurrentAmountRareOre = value;
				break;
			}
		}

		public void StartDrain(Transform targetPos)
		{
			_isDraining = true;
			_drainTarget = targetPos;
		}

		public void StopDrain()
		{
			_isDraining = false;
			DrainParticles.Stop();
		}

		public bool IsReadyToDrain()
		{
			if (Time.time - _lastDrainTime > 0.1f)
			{
				_lastDrainTime = Time.time;
				return true;
			}
			return false;
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (AmountDisplayRenderer != null && IsActive())
			{
				float num = CurrentAmountRareOre + CurrentAmountCommonOre;
				AmountDisplayRenderer.material.SetFloat("_Fuel", FillCurve.Evaluate(1f / ResourceCapacity * num));
				if (num >= ResourceCapacity * 0.9f && !_wasFull)
				{
					_tankFull.PressKey(true, KeyEventHub);
					_wasFull = true;
				}
				else if (num < ResourceCapacity * 0.9f && _wasFull)
				{
					_tankFull.PressKey(false, KeyEventHub);
					_wasFull = false;
				}
				if (num <= ResourceCapacity * 0.1f && !_wasEmpty)
				{
					_tankEmpty.PressKey(true, KeyEventHub);
					_wasEmpty = true;
				}
				else if (num >= ResourceCapacity * 0.1f && _wasEmpty)
				{
					_tankEmpty.PressKey(false, KeyEventHub);
					_wasEmpty = false;
				}
			}
			if (_isDraining && _drainTarget != null)
			{
				if (IsReadyToDrain())
				{
					if (GetResourceAmount(EResourceType.CommonOre) > 0f)
					{
						DrainResources(EResourceType.CommonOre);
					}
					else if (GetResourceAmount(EResourceType.RareOre) > 0f)
					{
						DrainResources(EResourceType.RareOre);
					}
					else
					{
						DrainParticles.Stop();
					}
				}
			}
			else
			{
				DrainParticles.Stop();
			}
		}

		private void DrainResources(EResourceType oreType)
		{
			float resourceAmount = GetResourceAmount(oreType);
			float num = Mathf.Min(resourceAmount, DrainSpeed * 0.1f);
			ETerrainMaterial key = EnumHelper.ConvertEnum(oreType);
			if (num > 0f)
			{
				SetResourceAmount(oreType, resourceAmount - num);
				SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.AddResources(key, num * _miningModifier);
				if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial != null)
				{
					TutorialResourceGatheringLogic tutorialResourceGatheringLogic = GenericTutorialLogic.Instance as TutorialResourceGatheringLogic;
					if (tutorialResourceGatheringLogic != null)
					{
						tutorialResourceGatheringLogic.AddResourceFakeAmount(num);
					}
				}
				Color particleColor = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(key).ParticleColor;
				DrainParticles.Init(_drainTarget, particleColor, Vector2.Distance(base.transform.position, _drainTarget.position) / 10f, false, true);
			}
			else
			{
				DrainParticles.Stop();
			}
		}

		public override void SetBroken(bool isBroken)
		{
			base.SetBroken(isBroken);
			if (isBroken)
			{
				ResourceHub currentResourceHub = base.CurrentResourceHub;
				if (currentResourceHub != null)
				{
					currentResourceHub.UnregisterPart(EResourceType.CommonOre, this);
				}
				ResourceHub currentResourceHub2 = base.CurrentResourceHub;
				if (currentResourceHub2 != null)
				{
					currentResourceHub2.UnregisterPart(EResourceType.RareOre, this);
				}
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			ResourceHub currentResourceHub = base.CurrentResourceHub;
			if (currentResourceHub != null)
			{
				currentResourceHub.UnregisterPart(EResourceType.CommonOre, this, false);
			}
			ResourceHub currentResourceHub2 = base.CurrentResourceHub;
			if (currentResourceHub2 != null)
			{
				currentResourceHub2.UnregisterPart(EResourceType.RareOre, this, false);
			}
			if (_wasEmpty)
			{
				_tankEmpty.PressKey(false, KeyEventHub);
			}
			if (_wasFull)
			{
				_tankFull.PressKey(false, KeyEventHub);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Capacity") + ": " + LabelHelper.Orange + ResourceCapacity;
		}
	}
}
