using System;
using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.Localization;
using Timberborn.UIFormatters;
using Timberborn.WaterBuildings;
using UnityEngine;
using UnityEngine.UIElements;

namespace Timberborn.WaterBuildingsUI
{
	internal class ValveFragment : IEntityPanelFragment
	{
		private static readonly string IdleLocKey = "Building.Valve.State.Idle";

		private static readonly string OpeningLocKey = "Building.Valve.State.Opening";

		private static readonly string ClosingLocKey = "Building.Valve.State.Closing";

		private static readonly string OutflowUnlimitedLocKey = "Building.Valve.OutflowUnlimited";

		private static readonly string ActiveStateLabelClass = "entity-panel__text--highlight-white";

		private readonly VisualElementLoader _visualElementLoader;

		private readonly ILoc _loc;

		private readonly Phrase _outflowLimitPhrase = Phrase.New("Building.Valve.OutflowLimit").FormatFlow<float>("F2");

		private readonly Phrase _automationOutflowLimitPhrase = Phrase.New("Building.Valve.OutflowLimit").FormatFlow<float>("F2");

		private readonly Phrase _reactionSpeedPhrase = Phrase.New("Building.Valve.ReactionSpeed").FormatPercentRounded();

		private Valve _valve;

		private VisualElement _root;

		private Label _valveStateLabel;

		private Label _outflowLimitLabel;

		private Label _outflowLimitStateLabel;

		private PreciseSlider _outflowLimitSlider;

		private Label _automationOutflowLimitLabel;

		private Label _automationOutflowLimitStateLabel;

		private VisualElement _automationOutflowLimitWrapper;

		private PreciseSlider _automationOutflowLimitSlider;

		private VisualElement _reactionSpeedWrapper;

		private Label _reactionSpeedLabel;

		private PreciseSlider _reactionSpeedSlider;

		private Toggle _synchronizeToggle;

		private float OutflowLimitSliderMaxValue => _valve.MaxOutflowLimit + _valve.OutflowLimitStep;

		public ValveFragment(VisualElementLoader visualElementLoader, ILoc loc)
		{
			_visualElementLoader = visualElementLoader;
			_loc = loc;
		}

		public VisualElement InitializeFragment()
		{
			_root = _visualElementLoader.LoadVisualElement("Game/EntityPanel/ValveFragment");
			_valveStateLabel = _root.Q<Label>("ValveState");
			_outflowLimitLabel = _root.Q<Label>("OutflowLimitLabel");
			_outflowLimitStateLabel = _root.Q<Label>("OutflowLimitStateLabel");
			_outflowLimitSlider = _root.Q<PreciseSlider>("OutflowLimitSlider");
			_outflowLimitSlider.SetValueChangedCallback(SetOutflowLimit);
			_automationOutflowLimitWrapper = _root.Q<VisualElement>("AutomationOutflowLimitWrapper");
			_automationOutflowLimitLabel = _root.Q<Label>("AutomationOutflowLimitLabel");
			_automationOutflowLimitStateLabel = _root.Q<Label>("AutomationOutflowLimitStateLabel");
			_automationOutflowLimitSlider = _root.Q<PreciseSlider>("AutomationOutflowLimitSlider");
			_automationOutflowLimitSlider.SetValueChangedCallback(SetAutomationOutflowLimit);
			_reactionSpeedWrapper = _root.Q<VisualElement>("ReactionSpeedWrapper");
			_reactionSpeedLabel = _root.Q<Label>("ReactionSpeedLabel");
			_reactionSpeedSlider = _root.Q<PreciseSlider>("ReactionSpeedSlider");
			_reactionSpeedSlider.SetValueChangedCallback(SetReactionSpeed);
			_synchronizeToggle = _root.Q<Toggle>("Synchronize");
			_synchronizeToggle.RegisterValueChangedCallback(ToggleSynchronization);
			_root.ToggleDisplayStyle(visible: false);
			return _root;
		}

		public void ShowFragment(BaseComponent entity)
		{
			_valve = entity.GetComponent<Valve>();
			if ((bool)_valve)
			{
				_outflowLimitSlider.SetStepWithoutNotify(_valve.OutflowLimitStep);
				_automationOutflowLimitSlider.SetStepWithoutNotify(_valve.OutflowLimitStep);
				_reactionSpeedSlider.SetStepWithoutNotify(_valve.ReactionSpeedStep);
			}
		}

		public void ClearFragment()
		{
			_valve = null;
			_root.ToggleDisplayStyle(visible: false);
		}

		public void UpdateFragment()
		{
			if ((bool)_valve)
			{
				UpdateOutflowLimit();
				UpdateAutomationOutflowLimit();
				UpdateMarkers();
				UpdateReactionSpeed();
				UpdateValveState();
				UpdateSynchronizeToggle();
				_root.ToggleDisplayStyle(visible: true);
			}
			else
			{
				_root.ToggleDisplayStyle(visible: false);
			}
		}

		private void UpdateOutflowLimit()
		{
			_outflowLimitSlider.UpdateValuesWithoutNotify(_valve.OutflowLimitEnabled ? Mathf.Clamp(_valve.OutflowLimit, 0f, _valve.MaxOutflowLimit) : OutflowLimitSliderMaxValue, OutflowLimitSliderMaxValue);
			_outflowLimitLabel.text = (_valve.OutflowLimitEnabled ? _loc.T(_outflowLimitPhrase, _valve.OutflowLimit) : _loc.T(OutflowUnlimitedLocKey));
			_outflowLimitStateLabel.ToggleDisplayStyle(_valve.IsAutomated);
			if (_valve.IsAutomated)
			{
				_outflowLimitStateLabel.EnableInClassList(ActiveStateLabelClass, !_valve.IsInputOn);
			}
		}

		private void UpdateAutomationOutflowLimit()
		{
			_automationOutflowLimitWrapper.ToggleDisplayStyle(_valve.IsAutomated);
			if (_valve.IsAutomated)
			{
				_automationOutflowLimitSlider.UpdateValuesWithoutNotify(_valve.AutomationOutflowLimitEnabled ? Mathf.Clamp(_valve.AutomationOutflowLimit, 0f, _valve.MaxOutflowLimit) : OutflowLimitSliderMaxValue, OutflowLimitSliderMaxValue);
				_automationOutflowLimitLabel.text = (_valve.AutomationOutflowLimitEnabled ? _loc.T(_automationOutflowLimitPhrase, _valve.AutomationOutflowLimit) : _loc.T(OutflowUnlimitedLocKey));
				_automationOutflowLimitStateLabel.EnableInClassList(ActiveStateLabelClass, _valve.IsInputOn);
			}
		}

		private void UpdateMarkers()
		{
			if (_valve.IsAutomated)
			{
				float marker = _valve.CurrentOutflowLimit ?? OutflowLimitSliderMaxValue;
				_outflowLimitSlider.SetMarker(marker);
				_automationOutflowLimitSlider.SetMarker(marker);
			}
			else
			{
				_outflowLimitSlider.ClearMarker();
				_automationOutflowLimitSlider.ClearMarker();
			}
		}

		private void UpdateReactionSpeed()
		{
			_reactionSpeedWrapper.ToggleDisplayStyle(_valve.IsAutomated);
			_reactionSpeedSlider.UpdateValuesWithoutNotify(_valve.ReactionSpeed, Valve.ReactionSpeedMin, Valve.ReactionSpeedMax);
			_reactionSpeedLabel.text = _loc.T(_reactionSpeedPhrase, _valve.ReactionSpeed);
		}

		private void UpdateValveState()
		{
			_valveStateLabel.ToggleDisplayStyle(_valve.State.HasValue);
			if (_valve.State.HasValue)
			{
				Label valveStateLabel = _valveStateLabel;
				valveStateLabel.text = _valve.State switch
				{
					ValveState.Idle => _loc.T(IdleLocKey), 
					ValveState.Opening => _loc.T(OpeningLocKey), 
					ValveState.Closing => _loc.T(ClosingLocKey), 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
		}

		private void UpdateSynchronizeToggle()
		{
			_synchronizeToggle.SetValueWithoutNotify(_valve.IsSynchronized);
		}

		private void SetOutflowLimit(float value)
		{
			if (value > _valve.MaxOutflowLimit)
			{
				_valve.SetOutflowLimitEnabledAndSynchronize(value: false);
				_valve.SetOutflowLimitAndSynchronize(_valve.MaxOutflowLimit);
			}
			else
			{
				_valve.SetOutflowLimitEnabledAndSynchronize(value: true);
				_valve.SetOutflowLimitAndSynchronize(value);
			}
		}

		private void SetAutomationOutflowLimit(float value)
		{
			if (value > _valve.MaxOutflowLimit)
			{
				_valve.SetAutomationOutflowLimitEnabledAndSynchronize(value: false);
				_valve.SetAutomationOutflowLimitAndSynchronize(_valve.MaxOutflowLimit);
			}
			else
			{
				_valve.SetAutomationOutflowLimitEnabledAndSynchronize(value: true);
				_valve.SetAutomationOutflowLimitAndSynchronize(value);
			}
		}

		private void SetReactionSpeed(float value)
		{
			_valve.SetReactionSpeedAndSynchronize(value);
		}

		private void ToggleSynchronization(ChangeEvent<bool> changeEvent)
		{
			_valve.ToggleSynchronization(changeEvent.newValue);
		}
	}
}
