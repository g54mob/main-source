using UnityEngine;
using UnityEngine.UI;

public class ImageFillAmountTweener : IPropertyTweener
{
	private Image _image;

	private float _fromFillAmount;

	private float _toFillAmount;

	public ImageFillAmountTweener(Image image, float targetFillAmount)
	{
		_image = image;
		_fromFillAmount = image.fillAmount;
		_toFillAmount = targetFillAmount;
	}

	public void Update(float to)
	{
		_fromFillAmount = _image.fillAmount;
		_toFillAmount = to;
	}

	public void UpdateProgress(float progress)
	{
		_image.fillAmount = Mathf.Lerp(_fromFillAmount, _toFillAmount, progress);
	}
}
