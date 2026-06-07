using Events;
using UnityEngine;

public class ShowWhileToolSelected : MonoBehaviour
{
	[SerializeField]
	private BaseEvent OnToolSelectedEvent;

	[SerializeField]
	private BaseEvent OnToolDeselectedEvent;

	private void Awake()
	{
		base.gameObject.SetActive(value: false);
		OnToolSelectedEvent.Register(ToolSelected);
		OnToolDeselectedEvent.Register(ToolDeselected);
	}

	private void ToolSelected()
	{
		base.gameObject.SetActive(value: true);
	}

	private void ToolDeselected()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		OnToolSelectedEvent.UnRegister(ToolSelected);
		OnToolDeselectedEvent.UnRegister(ToolDeselected);
	}
}
