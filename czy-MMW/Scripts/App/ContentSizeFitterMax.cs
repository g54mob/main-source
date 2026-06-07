using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(ContentSizeFitter))]
public class ContentSizeFitterMax : MonoBehaviour
{
	public float maxWidth;

	private RectTransform _rect;

	private ContentSizeFitter _fitter;

	private ILayoutElement _layout;

	public void OnEnable()
	{
		_rect = GetComponent<RectTransform>();
		_fitter = GetComponent<ContentSizeFitter>();
		_layout = GetComponent<ILayoutElement>();
	}

	public void Update()
	{
		if (_layout.preferredWidth > maxWidth)
		{
			_fitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
			_rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxWidth);
		}
		else
		{
			_fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
		}
	}

	public void OnValidate()
	{
		OnEnable();
	}
}
