using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace DV.MultipleUnit
{
	public sealed class MultipleUnitRemoteChannel
	{
		public readonly HashSet<MultipleUnitModule> devices = new HashSet<MultipleUnitModule>();

		private readonly List<MultipleUnitModule> transmitters = new List<MultipleUnitModule>();

		public readonly ReadOnlyCollection<MultipleUnitModule> allTransmitters;

		public bool HasOneTransmitter => transmitters.Count == 1;

		public MultipleUnitModule Transmitter
		{
			get
			{
				if (!HasOneTransmitter)
				{
					return null;
				}
				return transmitters[0];
			}
		}

		public event Action<MultipleUnitRemoteChannel> OnTransmitterChanged;

		public MultipleUnitRemoteChannel()
		{
			allTransmitters = transmitters.AsReadOnly();
		}

		public bool Add(MultipleUnitModule mu)
		{
			return devices.Add(mu);
		}

		public bool Remove(MultipleUnitModule mu)
		{
			transmitters.Remove(mu);
			return devices.Remove(mu);
		}

		public void SetTransmitterState(MultipleUnitModule mu, bool isTransmitter)
		{
			if (!devices.Contains(mu))
			{
				Debug.LogError("Cannot add MU as transmitter: It is not registered in the channel!");
			}
			else if (isTransmitter)
			{
				if (!transmitters.Contains(mu))
				{
					transmitters.Add(mu);
					RaiseTransmitterChangedEvent();
				}
			}
			else if (transmitters.Remove(mu))
			{
				RaiseTransmitterChangedEvent();
			}
		}

		public void RaiseTransmitterChangedEvent()
		{
			this.OnTransmitterChanged?.Invoke(this);
		}
	}
}
