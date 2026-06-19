using System;
using System.Collections.Generic;
using AssembleSystem;
using Energy;
using Energy.DistributionPolicies;
using Items;
using MyBox;
using UnityEngine;

namespace ComplexItems.Generator
{
	public class GeneratorObject : MonoBehaviour
	{
		[SerializeField]
		private List<WireController> _availableWires;

		[SerializeField]
		private float _maxPower;

		[SerializeField]
		private PartObject _fuelObject;

		[SerializeField]
		private bool _isOn;

		[SerializeField]
		private bool _working;

		private IEnergySource _source;

		private IEnergyDistributionPolicy _policy;

		private List<IEnergyConsumer> consumers = new List<IEnergyConsumer>();

		[ReadOnly(new string[] { })]
		[SerializeField]
		private float _fuelLevel;

		[ReadOnly(new string[] { })]
		[SerializeField]
		private float _fuelLevelMultiplier = 1f;

		public float FuelLevel
		{
			get
			{
				return ((IProgressable)_fuelObject).CurrentProgress * _fuelLevelMultiplier;
			}
			set
			{
				IProgressable fuelObject = _fuelObject;
				if (fuelObject != null)
				{
					float value2 = Mathf.Clamp(value, 0f, _maxPower) / _fuelLevelMultiplier - fuelObject.CurrentProgress;
					fuelObject.AddProgress(value2);
				}
			}
		}

		public bool IsOn => _isOn;

		public bool IsWorking => _working;

		public float CurrentPower
		{
			get
			{
				int num = 0;
				foreach (WireController availableWire in _availableWires)
				{
					if (availableWire.gameObject.activeSelf)
					{
						num++;
					}
				}
				return num;
			}
		}

		private IProgressable _fuelProgressable => _fuelObject;

		public bool TryConsumeFuel(float amount)
		{
			if (FuelLevel >= amount)
			{
				FuelLevel -= amount;
				return true;
			}
			return false;
		}

		private void Awake()
		{
			_source = new GeneratorEnergySource(this);
			_policy = new ProportionalDistributionPolicy();
			foreach (WireController availableWire in _availableWires)
			{
				MaleWire componentInChildren = availableWire.GetComponentInChildren<MaleWire>();
				componentInChildren.OnConnected = (Action<IEnergyConsumer>)Delegate.Combine(componentInChildren.OnConnected, new Action<IEnergyConsumer>(WireConnected));
				MaleWire componentInChildren2 = availableWire.GetComponentInChildren<MaleWire>();
				componentInChildren2.OnDisconnected = (Action<IEnergyConsumer>)Delegate.Combine(componentInChildren2.OnDisconnected, new Action<IEnergyConsumer>(Disconnect));
			}
		}

		private void WireConnected(IEnergyConsumer consumer)
		{
			Connect(consumer);
		}

		private void Update()
		{
			_fuelLevel = FuelLevel;
			_policy.Distribute(_source, consumers, Time.deltaTime);
		}

		public void Connect(IEnergyConsumer consumer)
		{
			if (!consumers.Contains(consumer))
			{
				consumers.Add(consumer);
			}
		}

		public void Disconnect(IEnergyConsumer consumer)
		{
			consumers.Remove(consumer);
		}
	}
}
