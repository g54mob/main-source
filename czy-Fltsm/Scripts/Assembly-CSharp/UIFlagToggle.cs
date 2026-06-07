using UnityEngine;

public class UIFlagToggle : SceneBehaviour
{
	[SerializeField]
	private UIFlags _uiFlag;

	[SerializeField]
	private bool _ignoreInEditor = true;

	private void Start()
	{
		base.gameObject.SetActive((GameManager.UIManager.Flags & _uiFlag) == 0);
		GameManager.UIManager.Flags |= _uiFlag;
	}

	public void Toggle()
	{
		base.gameObject.SetActive(!base.gameObject.activeSelf);
	}
}
