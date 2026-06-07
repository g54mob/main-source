using System;
using DV.Simulation.Cars;
using UnityEngine;

namespace DV.MultipleUnit
{
	public class MultipleUnitCable
	{
		public MultipleUnitModule muModule;

		public MultipleUnitCable connectedTo;

		public bool isFront;

		public bool IsConnected => connectedTo != null;

		public CouplingHoseMultipleUnitAdapter HoseAdapter
		{
			get
			{
				if (!isFront)
				{
					return muModule.rearCableAdapter;
				}
				return muModule.frontCableAdapter;
			}
		}

		public event Action<bool, bool> ConnectionChanged;

		public static event MUCableConnectionChangedDelegate AnyConnectionChanged;

		public MultipleUnitCable(MultipleUnitModule muModule, bool isFront)
		{
			this.muModule = muModule;
			this.isFront = isFront;
		}

		public void Connect(MultipleUnitCable other, bool playAudio = false)
		{
			if (other == null)
			{
				Debug.LogError("Can't connect, other is null", muModule);
				return;
			}
			if (other == this)
			{
				Debug.LogError("Can't connect to self", muModule);
				return;
			}
			if (connectedTo != null)
			{
				Debug.LogError("Can't connect, " + (isFront ? "front" : "rear") + " is already connected", muModule);
				return;
			}
			if (other.connectedTo != null)
			{
				Debug.LogError("Can't connect, other's " + (other.isFront ? "front" : "rear") + " is already connected", muModule);
				return;
			}
			connectedTo = other;
			other.connectedTo = this;
			BaseControlsOverrider controlsOverrider = muModule.controlsOverrider;
			BaseControlsOverrider controlsOverrider2 = other.muModule.controlsOverrider;
			controlsOverrider.Throttle?.Set(0f);
			controlsOverrider2.Throttle?.Set(0f);
			controlsOverrider.DynamicBrake?.Set(0f);
			controlsOverrider2.DynamicBrake?.Set(0f);
			controlsOverrider.Reverser?.Set(0.5f);
			controlsOverrider2.Reverser?.Set(0.5f);
			controlsOverrider.Sander?.Set(0f);
			controlsOverrider2.Sander?.Set(0f);
			controlsOverrider.HeadlightsFront?.Set(0.4f);
			controlsOverrider2.HeadlightsFront?.Set(0.4f);
			controlsOverrider.HeadlightsRear?.Set(0.4f);
			controlsOverrider2.HeadlightsRear?.Set(0.4f);
			float num = controlsOverrider.Brake?.Value ?? 0f;
			float num2 = controlsOverrider2.Brake?.Value ?? 0f;
			if (num2 > num)
			{
				controlsOverrider.Brake?.Set(num2);
			}
			else
			{
				controlsOverrider2.Brake?.Set(num);
			}
			float num3 = controlsOverrider.IndependentBrake?.Value ?? 0f;
			float num4 = controlsOverrider2.IndependentBrake?.Value ?? 0f;
			if (num4 > num3)
			{
				controlsOverrider.IndependentBrake?.Set(num4);
			}
			else
			{
				controlsOverrider2.IndependentBrake?.Set(num3);
			}
			MultipleUnitCable.AnyConnectionChanged?.Invoke(connected: true, this, other);
			try
			{
				this.ConnectionChanged?.Invoke(arg1: true, playAudio);
				other.ConnectionChanged?.Invoke(arg1: true, playAudio);
			}
			catch (Exception exception)
			{
				Debug.LogError("Caught the following exception while firing ConnectionChanged event:", muModule);
				Debug.LogException(exception);
			}
		}

		public void Disconnect(bool playAudio = false)
		{
			if (connectedTo == null)
			{
				Debug.Log("Nothing to disconnect, " + (isFront ? "front" : "rear") + " is not connected", muModule);
				return;
			}
			MultipleUnitCable multipleUnitCable = connectedTo;
			connectedTo.connectedTo = null;
			connectedTo = null;
			MultipleUnitCable.AnyConnectionChanged?.Invoke(connected: false, this, multipleUnitCable);
			try
			{
				this.ConnectionChanged?.Invoke(arg1: false, playAudio);
				multipleUnitCable.ConnectionChanged?.Invoke(arg1: false, playAudio);
			}
			catch (Exception exception)
			{
				Debug.LogError("Caught the following exception while firing ConnectionChanged event:", muModule);
				Debug.LogException(exception);
			}
		}
	}
}
