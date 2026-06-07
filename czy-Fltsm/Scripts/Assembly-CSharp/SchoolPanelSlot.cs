using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SchoolPanelSlot : SceneBehaviour
{
	[SerializeField]
	private RawImage _drifterPortrait;

	[SerializeField]
	private TextMeshProUGUI _drifterNameField;

	[SerializeField]
	private TextMeshProUGUI _levelField;

	[SerializeField]
	private TextMeshProUGUI _attributePointField;

	[SerializeField]
	private Slider _nextLevelProgress;

	[Header("Animation")]
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _animatorParameterOccopied = "IsOn";

	private Agent _agent;

	private void OnEnable()
	{
		_animator?.SetBool(_animatorParameterOccopied, _agent != null);
	}

	private void Update()
	{
		if ((bool)_agent)
		{
			_nextLevelProgress.value = _agent.Attributes.ReturnNormalizedExperience();
		}
	}

	public void Initialize(Agent agent)
	{
		if (!(_agent == agent))
		{
			RemoveListeners();
			_agent = agent;
			if ((bool)agent)
			{
				_drifterPortrait.texture = PortraitGenerator.ReturnStaticPortrait(agent.Descriptor);
				_drifterNameField.text = agent.Descriptor.Name;
				_nextLevelProgress.value = agent.Attributes.ReturnNormalizedExperience();
				_animator?.SetBool(_animatorParameterOccopied, value: true);
				UpdateLevelField();
				agent.Attributes.LevelIncreasedEvent.AddListener(UpdateLevelField);
				UpdateAttributePointField();
				agent.Attributes.AvailableSpendingPointsUpdatedEvent.AddListener(UpdateAttributePointField);
			}
			else
			{
				_drifterPortrait.texture = null;
				_drifterNameField.text = string.Empty;
				_levelField.text = "0";
				_attributePointField.text = "0";
				_nextLevelProgress.value = 0f;
				_animator?.SetBool(_animatorParameterOccopied, value: false);
			}
		}
	}

	private void RemoveListeners()
	{
		if ((bool)_agent)
		{
			_agent.Attributes.LevelIncreasedEvent.AddListener(UpdateLevelField);
			_agent.Attributes.AvailableSpendingPointsUpdatedEvent.RemoveListener(UpdateAttributePointField);
		}
	}

	private void UpdateLevelField()
	{
		if ((bool)_agent)
		{
			_levelField.text = _agent.Attributes.Level.ToString();
		}
		else
		{
			_levelField.text = "0";
		}
	}

	private void UpdateAttributePointField()
	{
		if ((bool)_agent)
		{
			_attributePointField.text = _agent.Attributes.SpendablePoints.ToString();
		}
		else
		{
			_attributePointField.text = "0";
		}
	}
}
