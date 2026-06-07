using UnityEngine;
using UnityEngine.UI;

public class FocusTarget : MonoBehaviour, IFocusTarget
{
	[SerializeField]
	private int _priority;

	public int Priority => _priority;

	public GameObject SelectedGameObject => base.gameObject;

	public bool SelectedGameObjectIsActiveAndEnabled => base.isActiveAndEnabled;

	private void OnEnable()
	{
		FocusManager.RequestFocus(this);
	}

	private void LateUpdate()
	{
		FocusManager.RequestFocus(this);
	}

	private void OnDisable()
	{
		FocusManager.ReleaseFocus(this);
	}

	public void OnCurrentSelectedSelectableChanged(Selectable selectable)
	{
		FocusManager.RequestFocus(this);
	}

	public void OnFocusGained()
	{
	}

	public void OnFocusLost()
	{
	}
}
