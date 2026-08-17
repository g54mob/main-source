using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class RandomSpriteUI : MonoBehaviour
{
	private List<string> _SpriteNames;

	private Image _image;

	public void SetIndex(int index)
	{
		Image component = GetComponent<Image>();
		_image = component;
		List<string> spriteNames = _SpriteNames;
		if (index < spriteNames._size)
		{
			string[] items = spriteNames._items;
			Sprite unpackedSprite = SpriteManager.GetUnpackedSprite(items[index]);
			_image.sprite = unpackedSprite;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public RandomSpriteUI()
	{
		List<string> spriteNames = new List<string>();
		_SpriteNames = spriteNames;
	}
}
