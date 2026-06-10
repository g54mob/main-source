using UnityEngine;

public class BoxColliderResizer2D : MonoBehaviour
{
	private void Start()
	{
		BoxCollider2D component = GetComponent<BoxCollider2D>();
		if (!(component == null))
		{
			RectTransform rectTransform = base.transform as RectTransform;
			if (!(rectTransform == null))
			{
				component.size = rectTransform.sizeDelta;
			}
		}
	}
}
