using TMPro;
using UnityEngine;

public class DrifterEntry : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _nameText;

	private Agent _agent;

	public void Initialize(Agent agent)
	{
		_agent = agent;
		base.gameObject.SetActive(value: true);
		_nameText.text = agent.Name;
	}

	public void SelectDrifter()
	{
		if (!(_agent == null))
		{
			Selector.Select(_agent.gameObject, ObjectType.Agent);
		}
	}
}
