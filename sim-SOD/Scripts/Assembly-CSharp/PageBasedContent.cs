using UnityEngine;

public class PageBasedContent : MonoBehaviour
{
	[Header("Page Content")]
	public int elementsPerPage;

	public virtual int GetMaxPages()
	{
		return 0;
	}

	public virtual void UpdateListDisplay()
	{
	}
}
