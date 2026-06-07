using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Batteries
{
	public class Battery : SensorPart, IHasResources
	{
		public float MaxEnergyAmount;

		public float RechargePerSecond;

		private EventKeyBinding _batteryFull;

		private EventKeyBinding _batteryEmpty;

		private bool _wasFull;

		private bool _wasEmpty;

		public Renderer EnergyDisplayRenderer;

		[NonSerialized]
		[HideInInspector]
		public float CurrentEnergyAmount;

		private float _rechargeRate;

		private DynamoEffect _dynamo;

		public override List<KeyBinding> GetKeyBindings()
		{
			return new List<KeyBinding>();
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_batteryFull = new EventKeyBinding("Battery full", KeyCode.None);
			_batteryEmpty = new EventKeyBinding("Battery empty", KeyCode.None);
			return new List<EventKeyBinding> { _batteryFull, _batteryEmpty };
		}

		public override void InitDronePerkSettings(List<DroneEffect> effects)
		{
			base.InitDronePerkSettings(effects);
			_rechargeRate = RechargePerSecond;
			_dynamo = ((effects != null) ? effects.OfType<DynamoEffect>().FirstOrDefault() : null);
			SuperchargedBatteries superchargedBatteries = ((effects != null) ? effects.OfType<SuperchargedBatteries>().FirstOrDefault() : null);
			if (superchargedBatteries != null)
			{
				float num = (float)(100 + superchargedBatteries.RechargeIncrease) / 100f;
				_rechargeRate = RechargePerSecond * num;
			}
		}

		protected override void Start()
		{
			base.Start();
			base.CurrentResourceHub.RegisterPart(EResourceType.Energy, this);
			SetResourceAmount(EResourceType.Energy, MaxEnergyAmount);
			if (EnergyDisplayRenderer != null)
			{
				EnergyDisplayRenderer.material.SetFloat("_Fuel", 1f);
			}
		}

		public override void PostLoad()
		{
			base.PostLoad();
			CurrentEnergyAmount = MaxEnergyAmount;
		}

		protected override void Awake()
		{
			base.Awake();
			CurrentEnergyAmount = MaxEnergyAmount;
		}

		public float GetRechargePerSecond(EResourceType resourceType)
		{
			float num = _rechargeRate;
			if (_dynamo != null && Rigidbody != null && Rigidbody.velocity.magnitude > _dynamo.MinSpeed)
			{
				num *= (100f + _dynamo.Enhancement) / 100f;
			}
			return num;
		}

		public float GetResourceCapacity(EResourceType resourceType)
		{
			return MaxEnergyAmount;
		}

		public float GetResourceAmount(EResourceType resourceType)
		{
			return CurrentEnergyAmount;
		}

		public void SetResourceAmount(EResourceType resourceType, float value)
		{
			CurrentEnergyAmount = value;
			if (CurrentEnergyAmount >= MaxEnergyAmount * 0.9f && !_wasFull)
			{
				_batteryFull.PressKey(true, KeyEventHub);
				_wasFull = true;
			}
			else if (CurrentEnergyAmount < MaxEnergyAmount * 0.9f && _wasFull)
			{
				_batteryFull.PressKey(false, KeyEventHub);
				_wasFull = false;
			}
			if (CurrentEnergyAmount <= MaxEnergyAmount * 0.1f && !_wasEmpty)
			{
				_batteryEmpty.PressKey(true, KeyEventHub);
				_wasEmpty = true;
			}
			else if (CurrentEnergyAmount >= MaxEnergyAmount * 0.1f && _wasEmpty)
			{
				_batteryEmpty.PressKey(false, KeyEventHub);
				_wasEmpty = false;
			}
		}

		public void ChangeResourceHub(ResourceHub oldHub, ResourceHub newHub)
		{
			if (oldHub != null)
			{
				oldHub.UnregisterPart(EResourceType.Energy, this);
			}
			newHub.RegisterPart(EResourceType.Energy, this);
		}

		public override void Update()
		{
			base.Update();
			if (EnergyDisplayRenderer != null)
			{
				EnergyDisplayRenderer.material.SetFloat("_Fuel", 1f / MaxEnergyAmount * CurrentEnergyAmount);
			}
		}

		public override void SetBroken(bool isBroken)
		{
			base.SetBroken(isBroken);
			if (isBroken)
			{
				base.CurrentResourceHub.UnregisterPart(EResourceType.Energy, this);
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			ResourceHub currentResourceHub = base.CurrentResourceHub;
			if (currentResourceHub != null)
			{
				currentResourceHub.UnregisterPart(EResourceType.Energy, this, false);
			}
			if (_wasEmpty)
			{
				_batteryEmpty.PressKey(false, KeyEventHub);
			}
			if (_wasFull)
			{
				_batteryFull.PressKey(false, KeyEventHub);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Capacity") + ": " + LabelHelper.Orange + MaxEnergyAmount + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Recharge") + ": " + LabelHelper.Orange + _rechargeRate;
		}
	}
}
