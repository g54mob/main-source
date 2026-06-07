using System;
using UnityEngine;
using UnityEngine.UI;

public class GlobalSearchResult : MonoBehaviour
{
	public Text Label;

	public Image Sprite;

	public Image Back;

	public RawImage Image;

	public Color ActiveColor;

	[NonSerialized]
	private RenderTexture _tex;

	[NonSerialized]
	private GlobalSearchPanel.SearchItem _item;

	public GlobalSearchPanel.SearchItem Item
	{
		get
		{
			return _item;
		}
	}

	public void Set(GlobalSearchPanel.SearchItem item)
	{
		item.WasVisible();
		_item = item;
		Label.text = item.Title;
		bool flag = item.ImageTh != null || item.Render != null;
		Sprite.gameObject.SetActive(!flag);
		Image.gameObject.SetActive(flag);
		if (flag)
		{
			if (item.Render != null)
			{
				if (_tex == null)
				{
					_tex = new RenderTexture(32, 32, 0);
				}
				Image.texture = _tex;
				Image.uvRect = new Rect(0f, 0f, 1f, 1f);
				item.Render(_tex);
			}
			else
			{
				Image.texture = item.ImageTh;
				Image.uvRect = item.UVRect;
			}
		}
		else
		{
			Sprite.sprite = item.SpriteTh;
			Sprite.color = (item.SpriteWhite ? Color.white : ((Color)new Color32(50, 50, 50, byte.MaxValue)));
		}
		base.gameObject.SetActive(true);
	}

	public void OnClick()
	{
		if (Item != null)
		{
			Item.FindAction();
			GlobalSearchPanel.Instance.gameObject.SetActive(false);
		}
	}

	public void Clear()
	{
		_item = null;
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (_tex != null)
		{
			UnityEngine.Object.Destroy(_tex);
		}
	}

	public void Highlight(bool active)
	{
		Back.color = (active ? ActiveColor : Color.white);
	}
}
