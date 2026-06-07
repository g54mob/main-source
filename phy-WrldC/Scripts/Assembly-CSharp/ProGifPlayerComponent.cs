using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class ProGifPlayerComponent : MonoBehaviour
{
	public enum DisplayType
	{
		None = 0,
		Image = 1,
		Renderer = 2,
		GuiTexture = 3,
		RawImage = 4
	}

	public enum PlayerState
	{
		None = 0,
		Loading = 1,
		Ready = 2,
		Playing = 3,
		Pause = 4
	}

	public class FirstGifFrame
	{
		public GifTexture gifTexture;

		public int width;

		public int height;

		public float interval;

		public int totalFrame;

		public int fps => (int)(1f / interval);
	}

	[HideInInspector]
	public List<GifTexture> gifTextures = new List<GifTexture>();

	private int totalFrame;

	[HideInInspector]
	public DisplayType displayType;

	[HideInInspector]
	public float nextFrameTime;

	[HideInInspector]
	public int spriteIndex;

	[HideInInspector]
	public float interval;

	public bool optimizeMemoryUsage = true;

	public Action<FirstGifFrame> OnFirstFrame;

	public Action<float> OnLoading;

	public Action<GifTexture> OnPlayingCallback;

	public float LoadingProgress => (float)gifTextures.Count / (float)totalFrame;

	public bool IsLoadingComplete => LoadingProgress >= 1f;

	public PlayerState State { get; private set; }

	public int loopCount { get; private set; }

	public int width { get; private set; }

	public int height { get; private set; }

	public virtual void Play(RenderTexture[] gifFrames, int fps, bool isCustomRatio, int customWidth, int customHeight, bool optimizeMemoryUsage)
	{
		gifTextures = new List<GifTexture>();
		this.optimizeMemoryUsage = optimizeMemoryUsage;
		interval = 1f / (float)fps;
		Clear();
		totalFrame = gifFrames.Length;
		StartCoroutine(_AddGifTextures(gifFrames, fps, isCustomRatio, customWidth, customHeight, optimizeMemoryUsage, 0, yieldPerFrame: true));
		StartCoroutine(_DelayCallback());
		State = PlayerState.Playing;
	}

	private IEnumerator _AddGifTextures(RenderTexture[] gifFrames, float fps, bool isCustomRatio, int customWidth, int customHeight, bool optimizeMemoryUsage, int currentIndex, bool yieldPerFrame)
	{
		int num = currentIndex;
		if (isCustomRatio)
		{
			width = customWidth;
			height = customHeight;
			Texture2D texture2D = new Texture2D(width, height);
			RenderTexture.active = gifFrames[num];
			texture2D.ReadPixels(new Rect((gifFrames[num].width - texture2D.width) / 2, (gifFrames[num].height - texture2D.height) / 2, texture2D.width, texture2D.height), 0, 0);
			texture2D.Apply();
			gifTextures.Add(new GifTexture(texture2D, interval, optimizeMemoryUsage));
		}
		else
		{
			width = gifFrames[0].width;
			height = gifFrames[0].height;
			Texture2D texture2D2 = new Texture2D(gifFrames[num].width, gifFrames[num].height);
			RenderTexture.active = gifFrames[num];
			texture2D2.ReadPixels(new Rect(0f, 0f, gifFrames[num].width, gifFrames[num].height), 0, 0);
			texture2D2.Apply();
			gifTextures.Add(new GifTexture(texture2D2, interval, optimizeMemoryUsage));
		}
		if (currentIndex == 1)
		{
			OnLoading(LoadingProgress);
		}
		if (yieldPerFrame)
		{
			yield return new WaitForEndOfFrame();
		}
		if (OnLoading != null)
		{
			OnLoading(LoadingProgress);
		}
		currentIndex++;
		if (currentIndex < gifFrames.Length)
		{
			StartCoroutine(_AddGifTextures(gifFrames, fps, isCustomRatio, customWidth, customHeight, optimizeMemoryUsage, currentIndex, yieldPerFrame));
		}
	}

	private IEnumerator _DelayCallback()
	{
		yield return new WaitForEndOfFrame();
		_OnFrameReady(gifTextures[0], isFirstFrame: true);
		if (gifTextures != null && gifTextures.Count > 0)
		{
			_OnFirstFrameReady(gifTextures[0]);
		}
	}

	public void Pause()
	{
		State = PlayerState.Pause;
	}

	public void Resume()
	{
		State = PlayerState.Playing;
	}

	public void Stop()
	{
		State = PlayerState.Pause;
		spriteIndex = 0;
	}

	protected abstract void _OnFrameReady(GifTexture gTex, bool isFirstFrame);

	public void _OnFirstFrameReady(GifTexture gifTex)
	{
		interval = gifTex.m_delaySec;
		width = gifTex.m_Width;
		height = gifTex.m_Height;
		if (OnFirstFrame != null)
		{
			OnFirstFrame(new FirstGifFrame
			{
				gifTexture = gifTex,
				width = width,
				height = height,
				interval = interval,
				totalFrame = totalFrame
			});
		}
		State = PlayerState.Playing;
	}

	public void SetOnFirstFrameCallback(Action<FirstGifFrame> onFirstFrame)
	{
		OnFirstFrame = onFirstFrame;
	}

	public void SetLoadingCallback(Action<float> onLoading)
	{
		OnLoading = onLoading;
	}

	public void SetOnPlayingCallback(Action<GifTexture> onPlayingCallback)
	{
		OnPlayingCallback = onPlayingCallback;
	}

	public bool ByteArrayToFile(string fileName, byte[] byteArray)
	{
		try
		{
			using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				fileStream.Write(byteArray, 0, byteArray.Length);
				return true;
			}
		}
		catch (Exception arg)
		{
			Console.WriteLine("Exception caught in process: {0}", arg);
			return false;
		}
	}

	protected void _ClearGifTextures(List<GifTexture> gifTexList)
	{
		if (gifTexList == null)
		{
			return;
		}
		for (int i = 0; i < gifTexList.Count; i++)
		{
			if (gifTexList[i] != null)
			{
				if (gifTexList[i].m_texture2d != null)
				{
					UnityEngine.Object.Destroy(gifTexList[i].m_texture2d);
					gifTexList[i].m_texture2d = null;
				}
				if (gifTexList[i].m_Sprite != null && gifTexList[i].m_Sprite.texture != null)
				{
					UnityEngine.Object.Destroy(gifTexList[i].m_Sprite.texture);
					gifTexList[i].m_Sprite = null;
				}
			}
		}
	}

	public virtual void Clear()
	{
		State = PlayerState.None;
		spriteIndex = 0;
		nextFrameTime = 0f;
		StopAllCoroutines();
		_ClearGifTextures(gifTextures);
		Resources.UnloadUnusedAssets();
	}
}
