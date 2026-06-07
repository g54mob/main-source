using System;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class SimpleInputController : IInputController
	{
		private float _deactivatedValue;

		private Func<AircraftControls, float> _getValue;

		private PartScript _partScript;

		private float _value;

		public bool Active { get; set; } = true;

		public bool IgnorePartActivated { get; set; }

		public string InputId { get; private set; }

		public bool InvertOnMirror { get; set; }

		public float Value
		{
			get
			{
				AircraftScript aircraft = _partScript.Aircraft;
				if (aircraft == null)
				{
					return _value;
				}
				_value = ((Active || IgnorePartActivated) ? _getValue(aircraft.Controls) : _deactivatedValue);
				return _value;
			}
		}

		public bool Visible { get; set; } = true;

		public SimpleInputController(string id, PartModifierScript partModifier, Func<AircraftControls, float> getValue, bool ignorePartActivated = false)
		{
			InputId = id;
			_partScript = partModifier.PartScript;
			_getValue = getValue;
			_deactivatedValue = 0f;
			_value = _deactivatedValue;
			IgnorePartActivated = ignorePartActivated;
		}

		public SimpleInputController(string id, PartModifierScript partModifier, Func<AircraftControls, bool> getValue, bool ignorePartActivated = false)
		{
			InputId = id;
			_partScript = partModifier.PartScript;
			_getValue = (AircraftControls x) => getValue(x) ? 1 : (-1);
			_deactivatedValue = -1f;
			_value = _deactivatedValue;
			IgnorePartActivated = ignorePartActivated;
		}
	}
}
