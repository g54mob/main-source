using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class ChangeUIState : MonoBehaviour
{
	[Tooltip("UI-State to change to.")]
	[SerializeField]
	private UIState UIState;

	public void ChangeState()
	{
		UIManager.SetState(UIState);
	}

	public void ResetState()
	{
		UIManager.SetState(UIState.Normal);
	}
}
