using DV.Simulation.Cars;
using DV.Simulation.Controllers;

namespace DV.MultipleUnit
{
	public class MUControlBlockPropagator
	{
		private readonly MultipleUnitModule muModule;

		public MUControlBlockPropagator(MultipleUnitModule muModule)
		{
			this.muModule = muModule;
			BaseControlsOverrider controlsOverrider = this.muModule.controlsOverrider;
			if (controlsOverrider.Throttle?.controlBlocker != null)
			{
				controlsOverrider.Throttle.controlBlocker.BlockedByBlockersDefinitionChanged += OnControlBlockStateChanged;
			}
			if (controlsOverrider.Brake?.controlBlocker != null)
			{
				controlsOverrider.Brake.controlBlocker.BlockedByBlockersDefinitionChanged += OnControlBlockStateChanged;
			}
			if (controlsOverrider.IndependentBrake?.controlBlocker != null)
			{
				controlsOverrider.IndependentBrake.controlBlocker.BlockedByBlockersDefinitionChanged += OnControlBlockStateChanged;
			}
			if (controlsOverrider.DynamicBrake?.controlBlocker != null)
			{
				controlsOverrider.DynamicBrake.controlBlocker.BlockedByBlockersDefinitionChanged += OnControlBlockStateChanged;
			}
			if (controlsOverrider.Reverser?.controlBlocker != null)
			{
				controlsOverrider.Reverser.controlBlocker.BlockedByBlockersDefinitionChanged += OnControlBlockStateChanged;
			}
			if (controlsOverrider.Sander?.controlBlocker != null)
			{
				controlsOverrider.Sander.controlBlocker.BlockedByBlockersDefinitionChanged += OnControlBlockStateChanged;
			}
			if (controlsOverrider.HeadlightsFront?.controlBlocker != null)
			{
				controlsOverrider.HeadlightsFront.controlBlocker.BlockedByBlockersDefinitionChanged += OnControlBlockStateChanged;
			}
			if (controlsOverrider.HeadlightsRear?.controlBlocker != null)
			{
				controlsOverrider.HeadlightsRear.controlBlocker.BlockedByBlockersDefinitionChanged += OnControlBlockStateChanged;
			}
			MultipleUnitCable.AnyConnectionChanged += OnCableConnectionChanged;
			muModule.RemoteChannelChanged += OnRemoteChannelChanged;
		}

		public void Deinitialize()
		{
			MultipleUnitCable.AnyConnectionChanged -= OnCableConnectionChanged;
			muModule.RemoteChannelChanged -= OnRemoteChannelChanged;
		}

		private void OnControlBlockStateChanged(bool _)
		{
			UpdateControlBlockPropagationOnRadioChannel(muModule.RemoteChannel);
			UpdateControlBlockPropagationViaCable(muModule);
		}

		private void OnRemoteChannelChanged(MultipleUnitRemoteChannel oldChannel, MultipleUnitRemoteChannel newChannel)
		{
			UpdateControlBlockPropagationOnRadioChannel(oldChannel);
			UpdateControlBlockPropagationOnRadioChannel(newChannel);
		}

		private void OnCableConnectionChanged(bool connected, MultipleUnitCable a, MultipleUnitCable b)
		{
			if (!(a.muModule != muModule))
			{
				if (connected)
				{
					UpdateControlBlockPropagationViaCable(a.muModule);
					return;
				}
				UpdateControlBlockPropagationViaCable(a.muModule);
				UpdateControlBlockPropagationViaCable(b.muModule);
			}
		}

		private void UpdateControlBlockPropagationOnRadioChannel(MultipleUnitRemoteChannel channel)
		{
			if (channel == null)
			{
				return;
			}
			bool throttleBlocked = false;
			bool brakeBlocked = false;
			bool indBrakeBlocked = false;
			bool dynamicBrakeBlocked = false;
			bool reverserBlocked = false;
			bool sanderBlocked = false;
			bool headlightsFrontBlocked = false;
			bool headlightsRearBlocked = false;
			foreach (MultipleUnitModule device in channel.devices)
			{
				RecalculateControlBlockFlags(device.controlsOverrider, ref throttleBlocked, ref brakeBlocked, ref indBrakeBlocked, ref dynamicBrakeBlocked, ref reverserBlocked, ref sanderBlocked, ref headlightsFrontBlocked, ref headlightsRearBlocked);
			}
			foreach (MultipleUnitModule device2 in channel.devices)
			{
				UpdateMuPropagatedBlockFlags(device2.controlsOverrider, throttleBlocked, brakeBlocked, indBrakeBlocked, dynamicBrakeBlocked, reverserBlocked, sanderBlocked, headlightsFrontBlocked, headlightsRearBlocked);
			}
		}

		private void UpdateControlBlockPropagationViaCable(MultipleUnitModule startingModule)
		{
			bool throttleBlocked = false;
			bool brakeBlocked = false;
			bool indBrakeBlocked = false;
			bool dynamicBrakeBlocked = false;
			bool reverserBlocked = false;
			bool sanderBlocked = false;
			bool headlightsFrontBlocked = false;
			bool headlightsRearBlocked = false;
			RecalculateControlBlockFlags(startingModule.controlsOverrider, ref throttleBlocked, ref brakeBlocked, ref indBrakeBlocked, ref dynamicBrakeBlocked, ref reverserBlocked, ref sanderBlocked, ref headlightsFrontBlocked, ref headlightsRearBlocked);
			MultipleUnitModule multipleUnitModule = startingModule.FrontCable.connectedTo?.muModule;
			MultipleUnitModule multipleUnitModule2 = startingModule;
			while (multipleUnitModule != null && multipleUnitModule != startingModule)
			{
				RecalculateControlBlockFlags(multipleUnitModule.controlsOverrider, ref throttleBlocked, ref brakeBlocked, ref indBrakeBlocked, ref dynamicBrakeBlocked, ref reverserBlocked, ref sanderBlocked, ref headlightsFrontBlocked, ref headlightsRearBlocked);
				MultipleUnitModule obj = ((multipleUnitModule.FrontCable.connectedTo?.muModule != multipleUnitModule2) ? multipleUnitModule.FrontCable.connectedTo?.muModule : multipleUnitModule.RearCable.connectedTo?.muModule);
				multipleUnitModule2 = multipleUnitModule;
				multipleUnitModule = obj;
			}
			multipleUnitModule = startingModule.RearCable.connectedTo?.muModule;
			multipleUnitModule2 = startingModule;
			while (multipleUnitModule != null && multipleUnitModule != startingModule)
			{
				RecalculateControlBlockFlags(multipleUnitModule.controlsOverrider, ref throttleBlocked, ref brakeBlocked, ref indBrakeBlocked, ref dynamicBrakeBlocked, ref reverserBlocked, ref sanderBlocked, ref headlightsFrontBlocked, ref headlightsRearBlocked);
				MultipleUnitModule obj2 = ((multipleUnitModule.RearCable.connectedTo?.muModule != multipleUnitModule2) ? multipleUnitModule.RearCable.connectedTo?.muModule : multipleUnitModule.FrontCable.connectedTo?.muModule);
				multipleUnitModule2 = multipleUnitModule;
				multipleUnitModule = obj2;
			}
			UpdateMuPropagatedBlockFlags(startingModule.controlsOverrider, throttleBlocked, brakeBlocked, indBrakeBlocked, dynamicBrakeBlocked, reverserBlocked, sanderBlocked, headlightsFrontBlocked, headlightsRearBlocked);
			multipleUnitModule = startingModule.FrontCable.connectedTo?.muModule;
			multipleUnitModule2 = startingModule;
			while (multipleUnitModule != null && multipleUnitModule != startingModule)
			{
				UpdateMuPropagatedBlockFlags(multipleUnitModule.controlsOverrider, throttleBlocked, brakeBlocked, indBrakeBlocked, dynamicBrakeBlocked, reverserBlocked, sanderBlocked, headlightsFrontBlocked, headlightsRearBlocked);
				MultipleUnitModule obj3 = ((multipleUnitModule.FrontCable.connectedTo?.muModule != multipleUnitModule2) ? multipleUnitModule.FrontCable.connectedTo?.muModule : multipleUnitModule.RearCable.connectedTo?.muModule);
				multipleUnitModule2 = multipleUnitModule;
				multipleUnitModule = obj3;
			}
			multipleUnitModule = startingModule.RearCable.connectedTo?.muModule;
			multipleUnitModule2 = startingModule;
			while (multipleUnitModule != null && multipleUnitModule != startingModule)
			{
				UpdateMuPropagatedBlockFlags(multipleUnitModule.controlsOverrider, throttleBlocked, brakeBlocked, indBrakeBlocked, dynamicBrakeBlocked, reverserBlocked, sanderBlocked, headlightsFrontBlocked, headlightsRearBlocked);
				MultipleUnitModule obj4 = ((multipleUnitModule.RearCable.connectedTo?.muModule != multipleUnitModule2) ? multipleUnitModule.RearCable.connectedTo?.muModule : multipleUnitModule.FrontCable.connectedTo?.muModule);
				multipleUnitModule2 = multipleUnitModule;
				multipleUnitModule = obj4;
			}
		}

		private void RecalculateControlBlockFlags(BaseControlsOverrider co, ref bool throttleBlocked, ref bool brakeBlocked, ref bool indBrakeBlocked, ref bool dynamicBrakeBlocked, ref bool reverserBlocked, ref bool sanderBlocked, ref bool headlightsFrontBlocked, ref bool headlightsRearBlocked)
		{
			if (!throttleBlocked)
			{
				ThrottleControl throttle = co.Throttle;
				if ((object)throttle != null && throttle.controlBlocker?.BlockedByBlockersDefinition == true)
				{
					throttleBlocked = true;
				}
			}
			if (!brakeBlocked)
			{
				BrakeControl brake = co.Brake;
				if ((object)brake != null && brake.controlBlocker?.BlockedByBlockersDefinition == true)
				{
					brakeBlocked = true;
				}
			}
			if (!indBrakeBlocked)
			{
				IndependentBrakeControl independentBrake = co.IndependentBrake;
				if ((object)independentBrake != null && independentBrake.controlBlocker?.BlockedByBlockersDefinition == true)
				{
					indBrakeBlocked = true;
				}
			}
			if (!dynamicBrakeBlocked)
			{
				DynamicBrakeControl dynamicBrake = co.DynamicBrake;
				if ((object)dynamicBrake != null && dynamicBrake.controlBlocker?.BlockedByBlockersDefinition == true)
				{
					dynamicBrakeBlocked = true;
				}
			}
			if (!reverserBlocked)
			{
				ReverserControl reverser = co.Reverser;
				if ((object)reverser != null && reverser.controlBlocker?.BlockedByBlockersDefinition == true)
				{
					reverserBlocked = true;
				}
			}
			if (!sanderBlocked)
			{
				SanderControl sander = co.Sander;
				if ((object)sander != null && sander.controlBlocker?.BlockedByBlockersDefinition == true)
				{
					sanderBlocked = true;
				}
			}
			if (!headlightsFrontBlocked)
			{
				HeadlightsControlFront headlightsFront = co.HeadlightsFront;
				if ((object)headlightsFront != null && headlightsFront.controlBlocker?.BlockedByBlockersDefinition == true)
				{
					headlightsFrontBlocked = true;
				}
			}
			if (!headlightsRearBlocked)
			{
				HeadlightsControlRear headlightsRear = co.HeadlightsRear;
				if ((object)headlightsRear != null && headlightsRear.controlBlocker?.BlockedByBlockersDefinition == true)
				{
					headlightsRearBlocked = true;
				}
			}
		}

		private void UpdateMuPropagatedBlockFlags(BaseControlsOverrider co, bool throttleBlocked, bool brakeBlocked, bool indBrakeBlocked, bool dynamicBrakeBlocked, bool reverserBlocked, bool sanderBlocked, bool headlightsFrontBlocked, bool headlightsRearBlocked)
		{
			if (co.Throttle?.controlBlocker != null)
			{
				co.Throttle.controlBlocker.MUPropagatedBlock = throttleBlocked;
			}
			if (co.Brake?.controlBlocker != null)
			{
				co.Brake.controlBlocker.MUPropagatedBlock = brakeBlocked;
			}
			if (co.IndependentBrake?.controlBlocker != null)
			{
				co.IndependentBrake.controlBlocker.MUPropagatedBlock = indBrakeBlocked;
			}
			if (co.DynamicBrake?.controlBlocker != null)
			{
				co.DynamicBrake.controlBlocker.MUPropagatedBlock = dynamicBrakeBlocked;
			}
			if (co.Reverser?.controlBlocker != null)
			{
				co.Reverser.controlBlocker.MUPropagatedBlock = reverserBlocked;
			}
			if (co.Sander?.controlBlocker != null)
			{
				co.Sander.controlBlocker.MUPropagatedBlock = sanderBlocked;
			}
			if (co.HeadlightsFront?.controlBlocker != null)
			{
				co.HeadlightsFront.controlBlocker.MUPropagatedBlock = headlightsFrontBlocked;
			}
			if (co.HeadlightsRear?.controlBlocker != null)
			{
				co.HeadlightsRear.controlBlocker.MUPropagatedBlock = headlightsRearBlocked;
			}
		}
	}
}
