using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Data;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;

namespace Assets.Scripts.Craft.Parts.Modifiers.Input
{
	public class CurveInputScript : PartModifierScript<CurveInputData>, IInputControllerInput, IFlightStart, IGameLoopItem, IFlightPreUpdate
	{
		private IInputController _inputAmplitude;

		private IInputController _inputEnabled;

		private IInputController _inputFrequency;

		private bool _usesInputControllers;

		public bool Enabled { get; private set; }

		public float Value { get; private set; }

		void IFlightPreUpdate.FlightPreUpdate(in FlightFrameData frame)
		{
			CurveInputData data = base.Data;
			UserCurve curve = data.Curve;
			if (_usesInputControllers)
			{
				if (_inputFrequency != null)
				{
					curve.Frequency = _inputFrequency.Value;
				}
				if (_inputAmplitude != null)
				{
					curve.Amplitude = _inputAmplitude.Value;
				}
				if (_inputEnabled != null)
				{
					Enabled = _inputEnabled.Value != 0f;
				}
			}
			if ((data.IgnorePartActivationState || base.PartScript.Data.Activated) && (data.UpdateInWarp || !frame.IsWarping))
			{
				Value = curve.GetValue(data.UseUnscaledTime ? ((double)frame.DeltaTimeUnscaled) : frame.DeltaTimeWorld);
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			Enabled = true;
			_inputFrequency = GetInputController("CurveInputFrequency");
			_inputAmplitude = GetInputController("CurveInputAmplitude");
			_inputEnabled = GetInputController("CurveInputEnabled");
			_usesInputControllers = _inputFrequency != null || _inputAmplitude != null || _inputEnabled != null;
		}
	}
}
