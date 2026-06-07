using UnityEngine;
using UnityEngine.UI;

public class ResponsiveGrowing : MonoBehaviour
{
	[SerializeField]
	private ContentSizeFitter contentSizeFitter;

	[SerializeField]
	private LayoutElement layoutElement;

	[Tooltip("The treshold of the panel height. If height of recttransform surpasses treshold, layout element going to set preffered height = treshold.")]
	[SerializeField]
	private float treshold;

	private RectTransform content;

	private float height;

	private void Start()
	{
		content = (RectTransform)contentSizeFitter.transform;
	}

	private void Update()
	{
		height = content.rect.height;
		layoutElement.preferredHeight = Mathf.Min(treshold, height);
	}
}
