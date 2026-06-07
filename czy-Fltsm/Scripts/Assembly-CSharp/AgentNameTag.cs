using TMPro;
using UnityEngine;

public class AgentNameTag : MonoBehaviour
{
	[SerializeField]
	private ActorBehaviour _actorBehaviour;

	[SerializeField]
	private GameObject _nameTagGameObject;

	[SerializeField]
	private TextMeshProUGUI _text;

	private void Update()
	{
		bool button = FlotsamInputManager.RewiredPlayer.GetButton("Show Drifter Names");
		if (_nameTagGameObject.activeSelf != button)
		{
			_nameTagGameObject.SetActive(button);
			if (button && _actorBehaviour != null && _text.text != _actorBehaviour.Name)
			{
				_text.text = _actorBehaviour.Name;
			}
		}
	}

	public bool IsActive()
	{
		return _nameTagGameObject.activeSelf;
	}
}
