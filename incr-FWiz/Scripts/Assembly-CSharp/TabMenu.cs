using FMODUnity;
using UnityEngine;

public class TabMenu : MonoBehaviour
{
	private TabMenuPage _currentPage;

	public EventReference ChangePageSound;

	public void InitiatePage(TabMenuPage page)
	{
	}

	public virtual void OnSelectTab(TabMenuPage page)
	{
	}
}
