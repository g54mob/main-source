using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.FuelTanks
{
	public class FuelTank : SensorPart, IHasResources
	{
		public float MaxFuelAmount;

		public float RechargePerSecond;

		public float ExplosionRadius;

		public float ExplosionDamage;

		public float ExplosionForce;

		public Renderer FuelDisplayRenderer;

		[NonSerialized]
		[HideInInspector]
		public float CurrentFuelAmount;

		private EventKeyBinding _fuelFull;

		private EventKeyBinding _fuelEmpty;

		private bool _wasFull;

		private bool _wasEmpty;

		public override void PostLoad()
		{
			base.PostLoad();
			CurrentFuelAmount = MaxFuelAmount;
		}

		protected override void Awake()
		{
			base.Awake();
			CurrentFuelAmount = MaxFuelAmount;
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			return new List<KeyBinding>();
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_fuelFull = new EventKeyBinding("Tank full", KeyCode.None);
			_fuelEmpty = new EventKeyBinding("Tank empty", KeyCode.None);
			return new List<EventKeyBinding> { _fuelFull, _fuelEmpty };
		}

		public float GetRechargePerSecond(EResourceType resourceType)
		{
			return RechargePerSecond;
		}

		protected override void Start()
		{
			base.Start();
			base.CurrentResourceHub.RegisterPart(EResourceType.Fuel, this);
			SetResourceAmount(EResourceType.Fuel, MaxFuelAmount);
		}

		public void ChangeResourceHub(ResourceHub oldHub, ResourceHub newHub)
		{
			if (oldHub != null)
			{
				oldHub.UnregisterPart(EResourceType.Fuel, this);
			}
			newHub.RegisterPart(EResourceType.Fuel, this);
		}

		public override void Update()
		{
			base.Update();
			if (FuelDisplayRenderer != null)
			{
				FuelDisplayRenderer.material.SetFloat("_Fuel", 1f / MaxFuelAmount * CurrentFuelAmount);
			}
		}

		protected override void HealthPool_HasDied()
		{
			base.HealthPool_HasDied();
			Explode();
		}

		public void Explode()
		{
			Vector3 position = base.transform.position;
			TerrainModificationHelper.LerpRemoveTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, position, ExplosionRadius, 0f);
			position.z = 0f;
			List<Collider> list = new List<Collider>();
			list.AddRange(Physics.OverlapSphere(position, ExplosionRadius));
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			foreach (Collider item in list)
			{
				if (item != null && !hashSet.Contains(item.gameObject) && !item.isTrigger)
				{
					if (item.attachedRigidbody != null)
					{
						item.attachedRigidbody.AddExplosionForce(ExplosionForce, position, ExplosionRadius);
					}
					item.gameObject.SendMessage("TakeDamage", new DamageInformation(ExplosionDamage, EDamageReason.Death, this), SendMessageOptions.DontRequireReceiver);
					hashSet.Add(item.gameObject);
				}
			}
		}

		public override void SetBroken(bool isBroken)
		{
			base.SetBroken(isBroken);
			if (isBroken)
			{
				base.CurrentResourceHub.UnregisterPart(EResourceType.Fuel, this);
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			ResourceHub currentResourceHub = base.CurrentResourceHub;
			if (currentResourceHub != null)
			{
				currentResourceHub.UnregisterPart(EResourceType.Fuel, this, false);
			}
			if (_wasEmpty)
			{
				_fuelEmpty.PressKey(false, KeyEventHub);
			}
			if (_wasFull)
			{
				_fuelFull.PressKey(false, KeyEventHub);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/FuelAmount") + ": " + LabelHelper.Orange + MaxFuelAmount + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Refill") + ": " + LabelHelper.Orange + RechargePerSecond + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/ExplosionDamage") + ": " + LabelHelper.Orange + ExplosionDamage;
		}

		public float GetResourceCapacity(EResourceType resourceType)
		{
			return MaxFuelAmount;
		}

		public float GetResourceAmount(EResourceType resourceType)
		{
			return CurrentFuelAmount;
		}

		public void SetResourceAmount(EResourceType resourceType, float value)
		{
			CurrentFuelAmount = value;
			if (CurrentFuelAmount >= MaxFuelAmount * 0.9f && !_wasFull)
			{
				_fuelFull.PressKey(true, KeyEventHub);
				_wasFull = true;
			}
			else if (CurrentFuelAmount < MaxFuelAmount * 0.9f && _wasFull)
			{
				_fuelFull.PressKey(false, KeyEventHub);
				_wasFull = false;
			}
			if (CurrentFuelAmount <= MaxFuelAmount * 0.1f && !_wasEmpty)
			{
				_fuelEmpty.PressKey(true, KeyEventHub);
				_wasEmpty = true;
			}
			else if (CurrentFuelAmount > MaxFuelAmount * 0.1f && _wasEmpty)
			{
				_fuelEmpty.PressKey(false, KeyEventHub);
				_wasEmpty = false;
			}
		}
	}
}
