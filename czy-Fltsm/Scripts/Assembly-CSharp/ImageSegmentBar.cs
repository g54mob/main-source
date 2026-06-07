using UnityEngine;
using UnityEngine.UI;

public class ImageSegmentBar : SegmentBar<Image>
{
	[SerializeField]
	private Color _activeColor = Color.white;

	[SerializeField]
	private Color _inactiveColor = Color.white;

	protected override void SetActive(Image segment)
	{
		segment.color = _activeColor;
	}

	protected override void SetInactive(Image segment)
	{
		segment.color = _inactiveColor;
	}
}
