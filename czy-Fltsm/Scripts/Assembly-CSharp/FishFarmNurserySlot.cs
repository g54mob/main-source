using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishFarmNurserySlot : MonoBehaviour
{
	[SerializeField]
	private Image _backgroundImage;

	[SerializeField]
	private Image _sliderImage;

	[SerializeField]
	private Image _borderImage;

	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private Slider _progressSlider;

	[SerializeField]
	private Color _hungryBackgroundColor;

	[SerializeField]
	private Color _hungrySliderColor;

	[SerializeField]
	private Color _hungryBorderColor;

	private bool _isHungry;

	private bool _cacheColors = true;

	private Color _backgroundColor;

	private Color _sliderColor;

	private Color _borderColor;

	public AquaFarm.Fish Fish { get; private set; }

	private void LateUpdate()
	{
		_progressSlider.value = Fish.Progress;
		SetIshungry(Fish.Hungry);
	}

	public void Initialize(AquaFarm.Fish fish)
	{
		Fish = fish;
		_icon.sprite = fish.GetIcon();
		_progressSlider.value = fish.Progress;
		SetIshungry(Fish.Hungry);
	}

	private void SetIshungry(bool isHungry)
	{
		_isHungry = isHungry;
		CacheColors();
		if (_isHungry)
		{
			_icon.overrideSprite = Fish.FishProperties.HungryIcon;
			SetImageColor(_backgroundImage, _hungryBackgroundColor);
			SetImageColor(_sliderImage, _hungrySliderColor);
			SetImageColor(_borderImage, _hungryBorderColor);
		}
		else
		{
			_icon.overrideSprite = null;
			SetImageColor(_backgroundImage, _backgroundColor);
			SetImageColor(_sliderImage, _sliderColor);
			SetImageColor(_borderImage, _borderColor);
		}
	}

	private void SetImageColor(Image image, Color color)
	{
		if ((bool)image)
		{
			image.color = color;
		}
	}

	private void CacheColors()
	{
		if (_cacheColors)
		{
			_backgroundColor = (_backgroundImage ? _backgroundImage.color : Color.white);
			_sliderColor = (_sliderImage ? _sliderImage.color : Color.white);
			_borderColor = (_borderImage ? _borderImage.color : Color.white);
			_cacheColors = false;
		}
	}
}
