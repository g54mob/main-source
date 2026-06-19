using System;
using System.Text;
using JetBrains.Annotations;
using Pug.UnityExtensions;
using UnityEngine;

public class RadicalOptionsMenuOption_Slider : RadicalPauseMenuOption
{
	[Tooltip("The value range this slider should cover.")]
	[SerializeField]
	private Pug.UnityExtensions.Range _range = new Pug.UnityExtensions.Range
	{
		min = 0f,
		max = 1f
	};

	[Tooltip("The amount of steps to cover the full slider range.")]
	[SerializeField]
	private int _numberOfSteps = 10;

	[Tooltip("If set true this control needs to be 'activated' before any adjustment can be made.")]
	[SerializeField]
	private bool _requiresActivationForAdjustment;

	[Tooltip("Related to 'Requires Activation For Adjustment' and only applies when it's enabled. If set true navigation will be handled internally when 'active'.")]
	[SerializeField]
	private bool _useInternalNavigationWhenActive;

	[Tooltip("Which character to use for rendering an active step?")]
	[SerializeField]
	private char _activeStepChar = '♦';

	[Tooltip("Which character to use for rendering an inactive step?")]
	[SerializeField]
	private char _inactiveStepChar = '♢';

	private int _currentStep;

	private float _currentValue;

	private bool _isActive;

	private bool _originalInternalNavigation;

	private float StepSize => (_range.max - _range.min) / (float)_numberOfSteps;

	public float CurrentValue => _currentValue;

	public event Action<float, int> ValueChanged;

	public override bool OnSkimRight()
	{
		return OnSkimDelta(1);
	}

	public override bool OnSkimLeft()
	{
		return OnSkimDelta(-1);
	}

	protected override void Awake()
	{
		_originalInternalNavigation = handleNavigationInternally;
		ValueChanged += OnValueChanged;
		base.Awake();
	}

	private void Start()
	{
		UpdateValueText();
	}

	public void SetValueRange(float min, float max)
	{
		if (min.Approximately(in max))
		{
			Debug.LogError("SetValueRange: the range min and max values are the same. This is not supported.");
			return;
		}
		_range = new Pug.UnityExtensions.Range
		{
			min = min,
			max = max
		};
	}

	public void SetValue(float value)
	{
		if (!_currentValue.Approximately(in value))
		{
			_currentValue = value;
			value = Mathf.Clamp(value, _range.min, _range.max);
			int valueStep_Internal = Mathf.RoundToInt((value - _range.min) / StepSize);
			SetValueStep_Internal(valueStep_Internal);
		}
	}

	public override void OnSelected()
	{
		base.OnSelected();
		UpdateValueText();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		Cleanup();
	}

	public override void OnActivated()
	{
		_isActive = !_isActive;
		if (_requiresActivationForAdjustment)
		{
			if (_isActive)
			{
				handleNavigationInternally = true;
			}
			else
			{
				handleNavigationInternally = _originalInternalNavigation;
			}
			UpdateValueTextColor(_currentStep, _isActive);
		}
		base.OnActivated();
	}

	[UsedImplicitly]
	public void SetValueStep(int step)
	{
		SetValueStep_Internal(step);
	}

	private void UpdateValueText()
	{
		UpdateValueText(_currentStep, IsSelected());
	}

	[UsedImplicitly]
	public void UpdateTextSelected(int step)
	{
		UpdateValueTextColor(step, selected: true);
	}

	[UsedImplicitly]
	public void UpdateTextDeselected(int step)
	{
		UpdateValueTextColor(step, selected: false);
	}

	public void UpdateValueText(int step, bool selected)
	{
		StringBuilder preallocatedStringBuilder = Manager.memory.preallocatedStringBuilder;
		preallocatedStringBuilder.Clear();
		for (int i = 0; i < _numberOfSteps; i++)
		{
			preallocatedStringBuilder.Append((i < step) ? _activeStepChar : _inactiveStepChar);
		}
		UpdateValueTextColor(step, selected);
		valueText.Render(preallocatedStringBuilder.ToString());
	}

	private void UpdateValueTextColor(int step, bool selected)
	{
		if (_requiresActivationForAdjustment)
		{
			selected &= _isActive;
		}
		for (int i = 0; i < valueText.glyphs.Count; i++)
		{
			valueText.glyphs[i].color = (selected ? PugTextEffectMenuOption.SELECTED_VALUE_COLOR : PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR);
		}
	}

	protected virtual void OnValueChanged(float value, int step)
	{
	}

	private bool OnSkimDelta(int delta)
	{
		if (_requiresActivationForAdjustment && !_isActive)
		{
			return false;
		}
		SetValueStep_Internal(_currentStep + delta);
		return true;
	}

	private void SetValueStep_Internal(int step)
	{
		int num = Mathf.Clamp(step, 0, _numberOfSteps);
		if (_currentStep != num)
		{
			_currentStep = num;
			_currentValue = _range.min + (float)_currentStep * StepSize;
			UpdateValueText();
			this.ValueChanged?.Invoke(CurrentValue, _currentStep);
		}
	}

	private void Cleanup()
	{
		foreach (SpriteRenderer glyph in valueText.glyphs)
		{
			glyph.color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		}
		_isActive = false;
		handleNavigationInternally = _originalInternalNavigation;
	}
}
