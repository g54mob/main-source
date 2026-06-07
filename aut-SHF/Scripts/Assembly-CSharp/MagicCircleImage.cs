using System;
using UnityEngine;
using UnityEngine.UI;

public class MagicCircleImage : MonoBehaviour
{
	public enum CircleColor
	{
		None = 0,
		Off = 1,
		White = 2,
		Blue = 3,
		Red = 4,
		Black = 5
	}

	[Serializable]
	public class SpriteColor
	{
		public CircleColor color;

		public Sprite sprite;
	}

	[SerializeField]
	private Image circle;

	[SerializeField]
	private SpriteColor[] colorSprites;

	public Sprite TargetSprite(CircleColor color)
	{
		return null;
	}

	public void ChangeColor(CircleColor color)
	{
	}
}
