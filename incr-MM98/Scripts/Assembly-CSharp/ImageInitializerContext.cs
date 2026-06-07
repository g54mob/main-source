using UnityEngine;
using UnityEngine.UI;

public class ImageInitializerContext : InitializerContext<Image>
{
	public ImageInitializerContext Color(Color color)
	{
		Target.color = color;
		return this;
	}

	public ImageInitializerContext Color(out Color color)
	{
		color = Target.color;
		return this;
	}

	public ImageInitializerContext Sprite(Sprite sprite)
	{
		Target.sprite = sprite;
		return this;
	}
}
