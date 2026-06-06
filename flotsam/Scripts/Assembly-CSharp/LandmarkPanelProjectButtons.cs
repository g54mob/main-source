using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LandmarkPanelProjectButtons : MonoBehaviour
{
	[Header("Components")]
	[SerializeField]
	private Toggle _swimToggle;

	[SerializeField]
	private Toggle _boatToggle;

	[SerializeField]
	private string _animatorParameterError = "Error";

	[SerializeField]
	private CounterBase _drifterCounter;

	[SerializeField]
	private TextMeshProUGUI _errorMessage;

	[Header("Localization")]
	[SerializeField]
	[FormerlySerializedAs("_swimTooltip")]
	private LocalizedString _swimmingRadiusError;

	[SerializeField]
	[FormerlySerializedAs("_boatTooltip")]
	private LocalizedString _noBoatError;

	[SerializeField]
	private LocalizedString _boatRadiusError;

	[SerializeField]
	private LocalizedString _activeText;

	[SerializeField]
	private LocalizedString _cancelText;

	private ActionsBehaviour _landmarkBehaviour;

	private List<LandmarkAction> _landmarkActions;

	private void Awake()
	{
		_boatToggle.onValueChanged.AddListener(BoatValueChanged);
		_swimToggle.onValueChanged.AddListener(SwimValueChanged);
		_drifterCounter.OnValueChanged.AddListener(AgentLimitChanged);
	}

	private void Update()
	{
		_ = _landmarkBehaviour == null;
	}

	private void OnDestroy()
	{
		_boatToggle.onValueChanged.RemoveListener(BoatValueChanged);
		_swimToggle.onValueChanged.RemoveListener(SwimValueChanged);
		_drifterCounter.OnValueChanged.RemoveListener(AgentLimitChanged);
	}

	public void Initialize(ActionsBehaviour landmarkBehaviour)
	{
		if (_landmarkActions != null)
		{
			foreach (LandmarkAction landmarkAction in _landmarkActions)
			{
				((ILandmarkAction)landmarkAction)?.UpdatedEvent.RemoveListener(OnLandmarkActionUpdated);
			}
		}
		if (landmarkBehaviour.Actions.IsNullOrEmpty())
		{
			return;
		}
		_landmarkBehaviour = landmarkBehaviour;
		_landmarkActions = landmarkBehaviour.Actions;
		foreach (LandmarkAction landmarkAction2 in _landmarkActions)
		{
			((ILandmarkAction)landmarkAction2)?.UpdatedEvent.AddListener(OnLandmarkActionUpdated);
		}
		if (!HasActiveOrCompletedAction(landmarkBehaviour))
		{
			landmarkBehaviour.UseBoat = !landmarkBehaviour.IsInSwimmingRadius() || Community.PlayerCommunity.ReturnHasBoatOfType(BoatType.SalvagingBoat);
		}
		if (landmarkBehaviour.UseBoat)
		{
			_boatToggle.isOn = true;
		}
		else
		{
			_swimToggle.isOn = true;
		}
		UpdateState();
	}

	private void BoatValueChanged(bool value)
	{
		if (!(_landmarkBehaviour == null))
		{
			_landmarkBehaviour.UseBoat = value;
			UpdateState();
		}
	}

	private void SwimValueChanged(bool value)
	{
		if (!(_landmarkBehaviour == null))
		{
			_landmarkBehaviour.UseBoat = !value;
			UpdateState();
		}
	}

	private void AgentLimitChanged(int count)
	{
		if (!(_landmarkBehaviour == null))
		{
			_landmarkBehaviour.SetAssignmentLimit(_drifterCounter.Count);
			UpdateState();
		}
	}

	private void OnLandmarkActionUpdated(ILandmarkAction landmarkAction)
	{
		UpdateState();
	}

	private void UpdateState()
	{
		LocalizedString error;
		bool flag = TryReturnError(out error);
		base.gameObject.SetActive(value: true);
		if (flag)
		{
			_drifterCounter.gameObject.SetActive(value: false);
			_errorMessage.gameObject.SetActive(value: true);
			_errorMessage.text = error;
		}
		else
		{
			_errorMessage.gameObject.SetActive(value: false);
			_drifterCounter.gameObject.SetActive(value: true);
			_landmarkBehaviour.SetAssignmentLimit(Mathf.Clamp(_landmarkBehaviour.AssignmentLimit, _landmarkBehaviour.AssignmentLimitMinimum, _landmarkBehaviour.AssignmentLimitMaximum));
			_drifterCounter.Initialize(_landmarkBehaviour.AssignmentLimitMinimum, _landmarkBehaviour.AssignmentLimitMaximum, _landmarkBehaviour.AssignmentLimit);
		}
		_swimToggle.animator.SetBool(_animatorParameterError, _swimToggle.isOn && flag);
		_boatToggle.animator.SetBool(_animatorParameterError, _boatToggle.isOn && flag);
	}

	public bool TryReturnError(out LocalizedString error)
	{
		if (_boatToggle.isOn)
		{
			if (!Community.PlayerCommunity.ReturnHasBoatWithAssignmentType(AssignmentType.LandmarkInteraction))
			{
				error = _noBoatError;
				return true;
			}
			if (!_landmarkBehaviour.IsInBoatRadius())
			{
				error = _boatRadiusError;
				return true;
			}
		}
		else if (!_landmarkBehaviour.IsInSwimmingRadius())
		{
			error = _swimmingRadiusError;
			return true;
		}
		error = default(LocalizedString);
		return false;
	}

	private bool HasActiveOrCompletedAction(ActionsBehaviour landmarkBehaviour)
	{
		foreach (LandmarkAction action in landmarkBehaviour.Actions)
		{
			ILandmarkActionStates state = action.State;
			if ((uint)(state - 2) <= 1u)
			{
				return true;
			}
		}
		return false;
	}
}
