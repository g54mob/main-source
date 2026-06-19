using UnityEngine;
using UnityEngine.UI;

public class PressableDeepClickAnimator : PressListenerAnimator
{
	public Image _image;

	public Color _defaultColor;

	public float _defaultSize;

	public Color _hoveredColor;

	public float _hoveredSize;

	public Color _pressedColor;

	public float _pressedSize;

	public override void AfterStateUpdate()
	{
	}
}
