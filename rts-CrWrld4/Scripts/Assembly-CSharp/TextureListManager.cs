using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextureListManager : MonoBehaviour
{
	[Serializable]
	public class OnTextureSelectedEvent : UnityEvent<int>
	{
	}

	public List<Toggle> images;

	private List<Material> materialList;

	private int _selectedImage;

	private List<short> textures;

	public OnTextureSelectedEvent OnTextureSelected;

	public int selectedImage
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Init()
	{
	}

	public void Unselect()
	{
	}

	public void Select(int val)
	{
	}

	public void OnSelectionChanged(bool val)
	{
	}

	public static void SetTexture(RawImage ri, short val)
	{
	}

	public void SetTexture(short val, int image)
	{
	}

	public void SetColor(Color color, int image)
	{
	}

	public void SetColorOnActiveImage(Color color)
	{
	}

	public void SetTextureOnActiveImage(short val)
	{
	}

	public short GetTextureOnActiveImage()
	{
		return 0;
	}
}
