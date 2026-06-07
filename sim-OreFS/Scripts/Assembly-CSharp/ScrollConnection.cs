using UnityEngine;
using UnityEngine.UI;

public class ScrollConnection : MonoBehaviour
{
	public Scrollbar scrollbar;

	public ScrollRect scrollRect;

	[Range(0f, 1f)]
	public float fixedSize = 0.3f;

	private void OnEnable()
	{
		if (scrollbar != null)
		{
			scrollbar.size = fixedSize;
		}
	}

	private void Update()
	{
		if (scrollbar != null)
		{
			scrollbar.size = fixedSize;
			scrollbar.value = scrollRect.verticalNormalizedPosition;
		}
	}
}
