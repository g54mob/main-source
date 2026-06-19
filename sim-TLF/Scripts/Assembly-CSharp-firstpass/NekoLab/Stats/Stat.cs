using System;
using System.Collections.Generic;
using NekoLib.ReactiveProps;
using UnityEngine;

namespace NekoLab.Stats
{
	[Serializable]
	public class Stat : BindableProp<float>
	{
		[Tooltip("Base value of the stat.")]
		[SerializeField]
		protected float _baseValue;

		[SerializeField]
		protected float _offsetValue;

		[SerializeField]
		protected float _initialValue;

		[Tooltip("If true, will limit the final value by an upper bound if present.")]
		[SerializeField]
		protected bool _useUpperBound;

		[Tooltip("If true, will limit the final value by a lower bound if present.")]
		[SerializeField]
		protected bool _useLowerBound;

		[SerializeField]
		protected bool _hasUpperBound;

		[SerializeField]
		protected bool _hasLowerBound;

		[SerializeField]
		protected BindableProp<float> _upperBound;

		[SerializeField]
		protected BindableProp<float> _lowerBound;

		[SerializeField]
		protected List<StatModifier> _modifiers = new List<StatModifier>();

		[SerializeField]
		protected bool _enableBroadcast = true;

		[SerializeField]
		protected StatObserveMode _observeMode;

		[SerializeField]
		protected bool _isDirty = true;

		[SerializeField]
		protected bool _broadcastChangeThisTick = true;

		public override float Value
		{
			get
			{
				if (_isDirty)
				{
					RefreshValue();
				}
				return _value;
			}
			set
			{
				_offsetValue += value - _value;
				SetDirty();
			}
		}

		public float BaseValue
		{
			get
			{
				return _baseValue;
			}
			set
			{
				if (value != _baseValue)
				{
					SetDirty();
				}
				_baseValue = value;
			}
		}

		public float InitialValue
		{
			get
			{
				return _initialValue;
			}
			set
			{
				_initialValue = value;
			}
		}

		public bool UseBounds
		{
			get
			{
				if (_useUpperBound)
				{
					return _useLowerBound;
				}
				return false;
			}
			set
			{
				_useUpperBound = value;
				_useLowerBound = value;
			}
		}

		public bool HasUpperBound => _hasUpperBound;

		public bool HasLowerBound => _hasLowerBound;

		public BindableProp<float> UpperBound => _upperBound;

		public BindableProp<float> LowerBound => _lowerBound;

		public event Action<Stat> StatChanged;

		public Stat()
			: this(0f)
		{
		}

		public Stat(float baseValue)
			: base(baseValue)
		{
			_baseValue = baseValue;
			_initialValue = baseValue;
			_useUpperBound = false;
			_useLowerBound = false;
			_upperBound = null;
			_lowerBound = null;
			_hasUpperBound = false;
			_hasLowerBound = false;
			_modifiers = new List<StatModifier>();
			_isDirty = true;
			_broadcastChangeThisTick = true;
		}

		public void Clear()
		{
			_offsetValue = 0f;
			_baseValue = 0f;
			_initialValue = 0f;
			_useUpperBound = false;
			_useLowerBound = false;
			_upperBound = null;
			_lowerBound = null;
			_hasUpperBound = false;
			_hasLowerBound = false;
			_modifiers.Clear();
			_isDirty = true;
			_broadcastChangeThisTick = true;
			this.StatChanged = null;
		}

		public void Reset(bool clearModifiers = false)
		{
			_offsetValue = 0f;
			_baseValue = _initialValue;
			if (clearModifiers)
			{
				_modifiers.Clear();
			}
			SetDirty();
		}

		public Stat AddModifier(StatModifier modifier)
		{
			_modifiers.Add(modifier);
			SetDirty();
			return this;
		}

		public Stat RemoveModifier(StatModifier modifier)
		{
			_modifiers.Remove(modifier);
			SetDirty();
			return this;
		}

		public Stat UseUpperBound(bool toggle = true)
		{
			_useUpperBound = toggle;
			return this;
		}

		public Stat UseLowerBound(bool toggle = true)
		{
			_useLowerBound = toggle;
			return this;
		}

		public Stat SetUpperBound(BindableProp<float> bindableFloat, bool useUpperBound = true)
		{
			if (_upperBound != null)
			{
				_upperBound.ValueChanged -= HandleUpperBoundChanged;
			}
			_upperBound = bindableFloat;
			_upperBound.ValueChanged += HandleUpperBoundChanged;
			_hasUpperBound = true;
			_useUpperBound = useUpperBound;
			return this;
		}

		public Stat SetUpperBound(float upperBound, bool useUpperBound = true)
		{
			return SetUpperBound(new BindableProp<float>(upperBound), useUpperBound);
		}

		public Stat RemoveUpperBound()
		{
			if (_upperBound != null)
			{
				_upperBound.ValueChanged -= HandleUpperBoundChanged;
			}
			_upperBound = null;
			_hasUpperBound = false;
			return this;
		}

		public Stat SetLowerBound(BindableProp<float> bindableFloat, bool useLowerBound = true)
		{
			if (_lowerBound != null)
			{
				_lowerBound.ValueChanged -= HandleLowerBoundChanged;
			}
			_lowerBound = bindableFloat;
			_lowerBound.ValueChanged += HandleLowerBoundChanged;
			_hasLowerBound = true;
			_useLowerBound = useLowerBound;
			return this;
		}

		public Stat SetLowerBound(float lowerBound = 0f, bool useLowerBound = true)
		{
			return SetLowerBound(new BindableProp<float>(lowerBound), useLowerBound);
		}

		public Stat RemoveLowerBound()
		{
			if (_lowerBound != null)
			{
				_lowerBound.ValueChanged -= HandleLowerBoundChanged;
			}
			_lowerBound = null;
			_hasLowerBound = false;
			return this;
		}

		private void HandleUpperBoundChanged(float value)
		{
			if (_useUpperBound)
			{
				SetDirty();
			}
		}

		private void HandleLowerBoundChanged(float value)
		{
			if (_useLowerBound)
			{
				SetDirty();
			}
		}

		protected float CalculateValue()
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < _modifiers.Count; i++)
			{
				StatModifier statModifier = _modifiers[i];
				if (statModifier.Effect == StatModifierEffect.Add)
				{
					num += statModifier.Value;
				}
				else if (statModifier.Effect == StatModifierEffect.Mult)
				{
					num2 += statModifier.Value;
				}
			}
			float num3 = _baseValue + _baseValue * num2 + num + _offsetValue;
			if (_useUpperBound && _hasUpperBound && num3 > _upperBound.Value)
			{
				num3 = _upperBound.Value;
			}
			if (_useLowerBound && _hasLowerBound && num3 < _lowerBound.Value)
			{
				num3 = _lowerBound.Value;
			}
			return num3;
		}

		public void Tick()
		{
			if (_enableBroadcast && _observeMode == StatObserveMode.EveryTick)
			{
				if (_broadcastChangeThisTick)
				{
					OnValueChange();
				}
				_broadcastChangeThisTick = false;
			}
		}

		public Stat EnableBroadcast(bool toggle = true)
		{
			_enableBroadcast = toggle;
			return this;
		}

		public Stat SetObserveMode(StatObserveMode changeMonitorMode = StatObserveMode.EveryTick)
		{
			_observeMode = changeMonitorMode;
			return this;
		}

		protected override void OnValueChange()
		{
			if (_enableBroadcast)
			{
				base.OnValueChange();
				this.StatChanged?.Invoke(this);
			}
		}

		protected void SetDirty()
		{
			_isDirty = true;
			switch (_observeMode)
			{
			case StatObserveMode.EveryTick:
				_broadcastChangeThisTick = true;
				break;
			case StatObserveMode.EveryChange:
				OnValueChange();
				break;
			}
		}

		protected void RefreshValue()
		{
			_value = CalculateValue();
			_isDirty = false;
		}
	}
}
