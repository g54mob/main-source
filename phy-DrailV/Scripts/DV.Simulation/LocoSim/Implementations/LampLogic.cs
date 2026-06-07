using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class LampLogic : SimComponent
	{
		public enum LampState
		{
			LAMP_OFF = 0,
			LAMP_ON_NO_AUDIO = 1,
			LAMP_ON_WITH_AUDIO = 2,
			LAMP_BLINK_NO_AUDIO = 3,
			LAMP_BLINK_WITH_AUDIO = 4
		}

		private readonly float offRangeMin;

		private readonly float offRangeMax;

		private readonly bool onRangeUsed;

		private readonly float onRangeMin;

		private readonly float onRangeMax;

		private readonly bool blinkRangeUsed;

		private readonly float blinkRangeMin;

		private readonly float blinkRangeMax;

		private readonly bool playAudioOnValueDrop;

		private readonly bool playAudioOnValueRaise;

		private readonly bool useAbsoluteInputValue;

		private readonly PortReference inputReader;

		private readonly Port lampStateReadOut;

		private readonly FuseReference powerFuse;

		private float prevValue;

		public LampLogic(LampLogicDefinition llDef)
			: base(llDef.ID)
		{
			offRangeMin = llDef.offRangeMin;
			offRangeMax = llDef.offRangeMax;
			onRangeUsed = llDef.onRangeUsed;
			onRangeMin = llDef.onRangeMin;
			onRangeMax = llDef.onRangeMax;
			blinkRangeUsed = llDef.blinkRangeUsed;
			blinkRangeMin = llDef.blinkRangeMin;
			blinkRangeMax = llDef.blinkRangeMax;
			playAudioOnValueDrop = llDef.playAudioOnValueDrop;
			playAudioOnValueRaise = llDef.playAudioOnValueRaise;
			useAbsoluteInputValue = llDef.useAbsoluteInputValue;
			inputReader = AddPortReference(llDef.inputReader);
			lampStateReadOut = AddPort(llDef.lampStateReadOut);
			if (!string.IsNullOrEmpty(llDef.powerFuseId))
			{
				powerFuse = AddFuseReference(llDef.powerFuseId);
			}
		}

		public override void InitializationAfterConnecting()
		{
			inputReader.port.ValueUpdatedInternally += OnInputChanged;
			if (powerFuse != null)
			{
				powerFuse.SubToStateChangedEvent(OnPowerFuseChanged, on: true);
			}
			UpdateLampState();
		}

		private void OnInputChanged(float _)
		{
			UpdateLampState();
		}

		private void OnPowerFuseChanged(bool _)
		{
			UpdateLampState();
		}

		private void UpdateLampState()
		{
			if (powerFuse != null && !powerFuse.State)
			{
				lampStateReadOut.Value = 0f;
				return;
			}
			float num = inputReader.Value;
			if (useAbsoluteInputValue)
			{
				num = Mathf.Abs(num);
			}
			if (num >= offRangeMin && num <= offRangeMax)
			{
				lampStateReadOut.Value = 0f;
			}
			else if (onRangeUsed && num >= onRangeMin && num <= onRangeMax)
			{
				bool flag = (playAudioOnValueRaise && inputReader.port.Diff > 0f) || (playAudioOnValueDrop && inputReader.port.Diff < 0f);
				lampStateReadOut.Value = (flag ? 2f : 1f);
			}
			else if (blinkRangeUsed && num >= blinkRangeMin && num <= blinkRangeMax)
			{
				bool flag2 = (playAudioOnValueRaise && inputReader.port.Diff > 0f) || (playAudioOnValueDrop && inputReader.port.Diff < 0f);
				lampStateReadOut.Value = (flag2 ? 4f : 3f);
			}
			else
			{
				Debug.LogError("Bad range setup for lamp " + id);
			}
		}

		public override void Tick(float delta)
		{
		}
	}
}
