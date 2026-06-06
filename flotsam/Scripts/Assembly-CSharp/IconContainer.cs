using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class IconContainer<T> : UIBehaviour
{
	[Serializable]
	private struct Icon
	{
		public T Id;

		public Sprite Sprite;
	}

	[SerializeField]
	private Image _image;

	[SerializeField]
	private Icon[] _icons;

	public void Initialize(T id)
	{
		Icon[] icons = _icons;
		for (int i = 0; i < icons.Length; i++)
		{
			Icon icon = icons[i];
			T id2 = icon.Id;
			if (id2.Equals(id))
			{
				_image.overrideSprite = icon.Sprite;
				break;
			}
		}
	}
}
