using UnityEngine;
using UnityEngine.UI;

public class AnimatedOutline : MonoBehaviour
{
	private unsafe void Start()
	{
		//IL_0055: Expected O, but got Ref
		Image component = GetComponent<Image>();
		Material material = component.material;
		RectTransform rectTransform = component.rectTransform;
		Rect rect = rectTransform.rect;
		Rect rect2 = rectTransform.rect;
		object obj = default(object);
		material.SetVector("_RectSize", (Vector4)(&obj));
	}

	private void Update()
	{
	}
}
