using UnityEngine;

public class CoolButtonGroup : MonoBehaviour
{
	public DelegateUtl.CoolButtonEvent OnGroupEntered;

	public DelegateUtl.CoolButtonEvent OnGroupExited;

	public DelegateUtl.CoolButtonChangedEvent OnGroupNav;

	public CoolButton CurSelection;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSelectedBtnChanged(CoolButton prevBtn, CoolButton newBtn)
	{
	}

	public void RefreshSelection()
	{
	}
}
