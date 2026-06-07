using TMPro;
using UnityEngine;

public class AgentDevToolAttributeEntry : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _label;

	[SerializeField]
	private TMP_InputField _inputField;

	private Agent _agent;

	private DrifterAttributes.AttributeType _type;

	public void Initialize(Agent agent, DrifterAttributes.AttributeType type)
	{
		_agent = agent;
		_type = type;
		_label.text = agent.Attributes.ReturnAttributeName(type);
		_inputField.text = agent.Attributes.ReturnAttributeExpertise(type).ToString();
	}

	public void OnEndEdit(string str)
	{
		if (_agent != null && int.TryParse(str, out var result))
		{
			_agent.Attributes.SetExpertise(_type, result);
		}
	}
}
