using UnityEngine;

public class DebugNormalizedTime : MonoBehaviour
{
	private Page _page;

	private Page page
	{
		get
		{
			if (!_page)
			{
				_page = GetComponent<Page>();
			}
			return _page;
		}
	}

	private void Update()
	{
		Debug.Log((page.IsFlipping() ? "TRUE" : "fals") + page.AnimationNormalizedTime);
	}
}
