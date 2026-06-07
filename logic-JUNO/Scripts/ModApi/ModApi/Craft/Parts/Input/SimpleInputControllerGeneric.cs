using System;

namespace ModApi.Craft.Parts.Input
{
	public class SimpleInputControllerGeneric<T> : IInputController where T : PartModifierScript
	{
		private float _deactivatedValue;

		private Func<T, float> _getValue;

		private PartData _partData;

		private T _partModifier;

		private IPartScript _partScript;

		private float _value;

		public bool Active => _partData.Activated;

		public string InputId { get; private set; }

		public bool InvertOnMirror { get; set; }

		public float Value
		{
			get
			{
				if (_partScript.CommandPod == null)
				{
					return _value;
				}
				_value = (_partData.Activated ? _getValue(_partModifier) : _deactivatedValue);
				return _value;
			}
		}

		public bool Visible { get; set; }

		public SimpleInputControllerGeneric(string id, T partModifier, Func<T, float> getValue)
		{
			InputId = id;
			_partModifier = partModifier;
			_partScript = partModifier.PartScript;
			_partData = _partScript.Data;
			_getValue = getValue;
			_deactivatedValue = 0f;
			_value = _deactivatedValue;
		}
	}
}
