using System;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class HoseAndCock
	{
		public BrakeSystem parentSystem;

		public HoseAndCock connectedTo;

		public bool cockOpen;

		public bool isFront;

		public float exhaustFlow;

		public bool wasPressurized;

		internal float exhaustFlowRef;

		public bool IsHoseConnected => connectedTo != null;

		public bool IsFullyConnected
		{
			get
			{
				if (cockOpen && IsHoseConnected)
				{
					return connectedTo.cockOpen;
				}
				return false;
			}
		}

		public bool IsOpenToAtmosphere
		{
			get
			{
				if (connectedTo == null)
				{
					return cockOpen;
				}
				return false;
			}
		}

		public event Action<bool> CockChanged;

		public HoseAndCock(BrakeSystem parentSystem, bool isFront)
		{
			this.parentSystem = parentSystem;
			this.isFront = isFront;
		}

		public void SetCock(bool open)
		{
			if (cockOpen == open)
			{
				return;
			}
			cockOpen = open;
			if (connectedTo != null && connectedTo.cockOpen)
			{
				if (open)
				{
					Brakeset.Merge(parentSystem, connectedTo.parentSystem);
				}
				else
				{
					Brakeset.Split(parentSystem, connectedTo.parentSystem);
				}
			}
			this.CockChanged?.Invoke(open);
		}

		public void Connect(HoseAndCock other)
		{
			if (other == null)
			{
				Debug.LogError("Can't connect, other is null", parentSystem);
				return;
			}
			if (other == this)
			{
				Debug.LogError("Can't connect to self", parentSystem);
				return;
			}
			if (connectedTo != null)
			{
				Debug.LogError("Can't connect, " + (isFront ? "front" : "rear") + " is already connected", parentSystem);
				return;
			}
			if (other.connectedTo != null)
			{
				Debug.LogError("Can't connect, other's " + (other.isFront ? "front" : "rear") + " is already connected", parentSystem);
				return;
			}
			connectedTo = other;
			other.connectedTo = this;
			Brakeset.FireHoseConnectionChanged(connected: true, this, other);
			if (cockOpen && other.cockOpen)
			{
				Brakeset.Merge(parentSystem, other.parentSystem);
			}
		}

		public void Disconnect()
		{
			if (connectedTo == null)
			{
				Debug.Log("Nothing to disconnect, " + (isFront ? "front" : "rear") + " is not connected", parentSystem);
				return;
			}
			Brakeset.FireHoseConnectionChanged(connected: false, this, connectedTo);
			if (cockOpen && connectedTo.cockOpen)
			{
				Brakeset.Split(parentSystem, connectedTo.parentSystem);
			}
			connectedTo.connectedTo = null;
			connectedTo = null;
		}

		public void UpdatePressurized()
		{
			if (connectedTo != null)
			{
				if (cockOpen)
				{
					wasPressurized = parentSystem.brakePipePressure > 1.5f;
				}
				else if (connectedTo.cockOpen)
				{
					wasPressurized = connectedTo.parentSystem.brakePipePressure > 1.5f;
				}
			}
			else
			{
				wasPressurized = false;
			}
		}
	}
}
