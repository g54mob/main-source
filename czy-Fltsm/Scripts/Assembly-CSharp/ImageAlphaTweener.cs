using UnityEngine;
using UnityEngine.UI;

public struct ImageAlphaTweener : IPropertyTweener
{
	private Image _image;

	private float _fromAlpha;

	private float _toAlpha;

	public ImageAlphaTweener(Image image, float targetAlpha)
	{
		_image = image;
		_fromAlpha = image.color.a;
		_toAlpha = targetAlpha;
	}

	public void Update(float to)
	{
		_fromAlpha = _image.color.a;
		_toAlpha = to;
	}

	public void UpdateProgress(float progress)
	{
		Color color = _image.color;
		color.a = Mathf.Lerp(_fromAlpha, _toAlpha, progress);
		_image.color = color;
	}
}
