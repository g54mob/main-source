using System;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
	[SerializeField]
	private Animator blissWallpaper;

	[SerializeField]
	private Animator img100Wallpaper;

	[SerializeField]
	private Animator koalaWallpaper;

	private Settings.Wallpaper currentWallpaper;

	private RectTransform canvas;

	private static int DEFAULT_WIDTH = 1920;

	private static int DEFAULT_HEIGHT = 1080;

	private void Start()
	{
		canvas = UIUtils.FindCanvasFromChild(base.transform).GetComponent<RectTransform>();
		currentWallpaper = PlayerPrefsManager.GetSavedWallpaper();
		ResizeWallpaper();
	}

	public void ResizeWallpaper()
	{
		if (currentWallpaper != Settings.Wallpaper.DEFAULT)
		{
			ResizeWallpaper(blissWallpaper.GetComponent<RectTransform>());
			ResizeWallpaper(img100Wallpaper.GetComponent<RectTransform>());
			ResizeWallpaper(koalaWallpaper.GetComponent<RectTransform>());
		}
	}

	private void ResizeWallpaper(RectTransform wallpaper)
	{
		if (canvas == null)
		{
			canvas = UIUtils.FindCanvasFromChild(base.transform).GetComponent<RectTransform>();
		}
		wallpaper.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, DEFAULT_WIDTH);
		wallpaper.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, DEFAULT_HEIGHT);
		if (wallpaper.rect.width < canvas.rect.width || wallpaper.rect.height < canvas.rect.height)
		{
			float num = canvas.rect.width - wallpaper.rect.width;
			float num2 = canvas.rect.height - wallpaper.rect.height;
			if (num > num2)
			{
				float size = canvas.rect.width / wallpaper.rect.width * wallpaper.rect.height;
				wallpaper.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, canvas.rect.width);
				wallpaper.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
			}
			else
			{
				float size2 = canvas.rect.height / wallpaper.rect.height * wallpaper.rect.width;
				wallpaper.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvas.rect.height);
				wallpaper.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size2);
			}
		}
	}

	public void EnableWallpaper(Settings.Wallpaper newWallpaper)
	{
		if (currentWallpaper != newWallpaper)
		{
			WallpaperFade(PlayFadeOut, currentWallpaper);
			WallpaperFade(PlayFadeIn, newWallpaper);
			currentWallpaper = newWallpaper;
			ResizeWallpaper();
		}
	}

	private void WallpaperFade(Action<Animator> fadeAction, Settings.Wallpaper wallpaper)
	{
		switch (wallpaper)
		{
		case Settings.Wallpaper.BLISS:
			fadeAction(blissWallpaper);
			break;
		case Settings.Wallpaper.IMG100:
			fadeAction(img100Wallpaper);
			break;
		case Settings.Wallpaper.KOALA:
			fadeAction(koalaWallpaper);
			break;
		}
	}

	private void PlayFadeOut(Animator wallpaper)
	{
		wallpaper.Play("fade out");
	}

	private void PlayFadeIn(Animator wallpaper)
	{
		wallpaper.Play("fade in");
	}
}
