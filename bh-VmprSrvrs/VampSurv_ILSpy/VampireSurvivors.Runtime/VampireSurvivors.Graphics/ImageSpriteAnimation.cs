using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.Graphics;

public class ImageSpriteAnimation : BaseSpriteAnimation
{
	private Image _image;

	protected override void Awake()
	{
		Image component = GetComponent<Image>();
		_image = component;
		base.Awake();
	}

	protected override void ApplySpriteFrame(Sprite sprite)
	{
		_image.sprite = sprite;
	}
}
