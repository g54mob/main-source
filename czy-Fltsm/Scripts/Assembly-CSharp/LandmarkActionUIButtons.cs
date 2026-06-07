using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LandmarkActionUIButtons : MonoBehaviour
{
	[Header("Components")]
	[SerializeField]
	private Toggle _swimToggle;

	[SerializeField]
	private Toggle _boatToggle;

	[SerializeField]
	private TextBoxCounter _agentCounter;

	[SerializeField]
	private TooltipButton _button;

	[SerializeField]
	private TextMeshProUGUI _buttonText;

	[Header("Tooltips")]
	[SerializeField]
	private LocalizedString _swimTooltip;

	[SerializeField]
	private LocalizedString _boatTooltip;

	[SerializeField]
	private LocalizedString _cancelText;

	private ILandmarkAction _landmarkAction;

	public void Initialize(ILandmarkAction landmarkAction)
	{
		if (landmarkAction != null)
		{
			if (_landmarkAction != null)
			{
				_landmarkAction.UpdatedEvent.RemoveListener(OnLandmarkActionUpdated);
			}
			_landmarkAction = landmarkAction;
			_landmarkAction.UpdatedEvent.AddListener(OnLandmarkActionUpdated);
			_boatToggle.interactable = landmarkAction.AssignmentLimitMinimum <= landmarkAction.MooringPointCount;
			_boatToggle.SetIsOnWithoutNotify(_landmarkAction.UseBoat);
			_swimToggle.SetIsOnWithoutNotify(!_landmarkAction.UseBoat);
			_agentCounter.gameObject.SetActive(1 < landmarkAction.AssignmentLimitMaximum);
			OnLandmarkActionUpdated(_landmarkAction);
		}
	}

	private void Awake()
	{
		_boatToggle.onValueChanged.AddListener(BoatValueChanged);
		_swimToggle.onValueChanged.AddListener(SwimValueChanged);
		_agentCounter.OnValueChanged.AddListener(AgentLimitChanged);
		_button.onClick.AddListener(OnClick);
	}

	private void Update()
	{
		if (_landmarkAction != null)
		{
			UpdateButtonState(_landmarkAction);
		}
	}

	private void OnDestroy()
	{
		_boatToggle.onValueChanged.RemoveListener(BoatValueChanged);
		_swimToggle.onValueChanged.RemoveListener(SwimValueChanged);
		_agentCounter.OnValueChanged.RemoveListener(AgentLimitChanged);
		_button.onClick.RemoveListener(OnClick);
	}

	private void BoatValueChanged(bool value)
	{
		if (_landmarkAction != null)
		{
			_landmarkAction.UseBoat = value;
			UpdateState();
		}
	}

	private void SwimValueChanged(bool value)
	{
		if (_landmarkAction != null)
		{
			_landmarkAction.UseBoat = !value;
			UpdateState();
		}
	}

	private void AgentLimitChanged(int count)
	{
		if (_landmarkAction != null)
		{
			_landmarkAction.SetAssignmentLimit(_agentCounter.Count);
			UpdateState();
		}
	}

	private void OnClick()
	{
		if (_landmarkAction != null)
		{
			if (_landmarkAction.State == ILandmarkActionStates.Inactive)
			{
				_landmarkAction.Activate();
			}
			else
			{
				_landmarkAction.Deactivate();
			}
			if (_landmarkAction.Project == null)
			{
				_buttonText.text = _landmarkAction.ActivateText;
			}
			else
			{
				_buttonText.text = _cancelText;
			}
			UpdateState();
		}
	}

	private void OnLandmarkActionUpdated(ILandmarkAction landmarkAction)
	{
		UpdateState();
		UpdateButtonState(landmarkAction);
	}

	private void UpdateState()
	{
		if (_landmarkAction.State == ILandmarkActionStates.Completed)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		base.gameObject.SetActive(value: true);
		_button.interactable = _landmarkAction.ReturnIsInteractable();
		_button.SetTooltipMessage(ReturnButtonTooltip());
		_landmarkAction.SetAssignmentLimit(Mathf.Clamp(_landmarkAction.AssignmentLimit, _landmarkAction.AssignmentLimitMinimum, _landmarkAction.AssignmentLimitMaximum));
		_agentCounter.Initialize(_landmarkAction.AssignmentLimitMinimum, _landmarkAction.AssignmentLimitMaximum, _landmarkAction.AssignmentLimit);
		bool interactable = _landmarkAction.State == ILandmarkActionStates.Inactive;
		_swimToggle.interactable = interactable;
		_boatToggle.interactable = interactable;
	}

	private void UpdateButtonState(ILandmarkAction action)
	{
		switch (action.State)
		{
		case ILandmarkActionStates.Inactive:
			_buttonText.text = action.ActivateText;
			_button.interactable = action.ReturnIsInteractable();
			_button.SetTooltipMessage(ReturnButtonTooltip());
			break;
		case ILandmarkActionStates.Active:
			_buttonText.text = _cancelText;
			_button.interactable = true;
			break;
		}
	}

	public LocalizedString ReturnButtonTooltip()
	{
		if (_landmarkAction.TryReturnInteractableTooltip(out var tooltip))
		{
			return tooltip;
		}
		if (!_landmarkAction.UseBoat)
		{
			return _swimTooltip;
		}
		return _boatTooltip;
	}
}
