using UnityEngine;

public abstract class BaseGUIPanelView : BaseView
{
	public GameObject MainPanel { get; set; }

	public virtual void SetVisibility(bool isVisible)
	{
		if (MainPanel != null && MainPanel.activeSelf != isVisible)
		{
			MainPanel.SetActive(isVisible);
		}
	}
}
