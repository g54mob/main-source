using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomImageListManager : MonoBehaviour
{
	[Serializable]
	public class OnCustomImageSelectedEvent : UnityEvent<int>
	{
	}

	public List<Toggle> images;

	private int _selectedImage;

	private List<Texture2D> textures;

	public OnCustomImageSelectedEvent OnCustomImageSelected;

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

	public void OnSelectionChanged(bool val)
	{
	}

	public void SetTexture(Texture2D tex, int image)
	{
	}

	public void SetTextureOnActiveImage(Texture2D tex)
	{
	}

	public Texture2D GetTextureOnActiveImage()
	{
		return null;
	}
}
