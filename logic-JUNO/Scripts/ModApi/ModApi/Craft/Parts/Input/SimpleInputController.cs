using System;

namespace ModApi.Craft.Parts.Input
{
	public class SimpleInputController : IInputController
	{
		private float _deactivatedValue;

		private Func<CraftControls, float> _getValue;

		private PartData _partData;

		private IPartScript _partScript;

		private float _value;

		public bool Active => _partData.Activated;

		public bool IgnorePartActivated { get; set; }

		public string InputId { get; private set; }

		public bool InvertOnMirror { get; set; }

		public float Value
		{
			get
			{
				ICommandPod commandPod = _partScript.CommandPod;
				if (commandPod == null)
				{
					return _value;
				}
				_value = ((_partData.Activated || IgnorePartActivated) ? _getValue(commandPod.Controls) : _deactivatedValue);
				return _value;
			}
		}

		public bool Visible { get; set; }

		public SimpleInputController(string id, PartModifierScript partModifier, Func<CraftControls, float> getValue, bool ignorePartActivated = false)
		{
			InputId = id;
			_partScript = partModifier.PartScript;
			_partData = _partScript.Data;
			_getValue = getValue;
			_deactivatedValue = 0f;
			_value = _deactivatedValue;
			IgnorePartActivated = ignorePartActivated;
		}

		public SimpleInputController(string id, PartModifierScript partModifier, Func<CraftControls, bool> getValue, bool ignorePartActivated = false)
		{
			InputId = id;
			_partScript = partModifier.PartScript;
			_partData = _partScript.Data;
			_getValue = (CraftControls x) => getValue(x) ? 1 : (-1);
			_deactivatedValue = -1f;
			_value = _deactivatedValue;
			IgnorePartActivated = ignorePartActivated;
		}
	}
}
