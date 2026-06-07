using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProGifPlayer
{
	private ProGifPlayerComponent player;

	private bool optimizeMemoryUsage = true;

	public ImageRotator.Rotation rotation;

	public string savePath = "";

	public bool isReversed;

	public bool isPingPong;

	public ProGifPlayerComponent playerComponent => player;

	public ProGifPlayerComponent.PlayerState State
	{
		get
		{
			if (!(player == null))
			{
				return player.State;
			}
			return ProGifPlayerComponent.PlayerState.None;
		}
	}

	public int width
	{
		get
		{
			if (!(player == null))
			{
				return player.width;
			}
			return 0;
		}
	}

	public int height
	{
		get
		{
			if (!(player == null))
			{
				return player.height;
			}
			return 0;
		}
	}

	public List<GifTexture> gifTextures
	{
		get
		{
			if (!(player == null))
			{
				return player.gifTextures;
			}
			return null;
		}
	}

	private void _SetupPlayerComponent(Image destination)
	{
		player = destination.gameObject.GetComponent<ProGifPlayerImage>();
		if (player == null)
		{
			player = destination.gameObject.AddComponent<ProGifPlayerImage>();
		}
		player.displayType = ProGifPlayerComponent.DisplayType.Image;
	}

	private void _SetupPlayerComponent(Renderer destination)
	{
		player = destination.gameObject.GetComponent<ProGifPlayerRenderer>();
		if (player == null)
		{
			player = destination.gameObject.AddComponent<ProGifPlayerRenderer>();
		}
		player.displayType = ProGifPlayerComponent.DisplayType.Renderer;
	}

	private void _SetupPlayerComponent(RawImage destination)
	{
		player = destination.gameObject.GetComponent<ProGifPlayerRawImage>();
		if (player == null)
		{
			player = destination.gameObject.AddComponent<ProGifPlayerRawImage>();
		}
		player.displayType = ProGifPlayerComponent.DisplayType.RawImage;
	}

	public void Play(ProGifRecorder recorder, Image destination, bool optimizeMemoryUsage)
	{
		_SetupPlayerComponent(destination);
		_PlayRecorder(recorder, optimizeMemoryUsage);
	}

	public void Play(ProGifRecorder recorder, Renderer destination, bool optimizeMemoryUsage)
	{
		_SetupPlayerComponent(destination);
		_PlayRecorder(recorder, optimizeMemoryUsage);
	}

	public void Play(ProGifRecorder recorder, RawImage destination, bool optimizeMemoryUsage)
	{
		_SetupPlayerComponent(destination);
		_PlayRecorder(recorder, optimizeMemoryUsage);
	}

	private void _PlayRecorder(ProGifRecorder recorder, bool optimizeMemoryUsage)
	{
		this.optimizeMemoryUsage = optimizeMemoryUsage;
		rotation = recorder.Rotation;
		savePath = recorder.SavedFilePath;
		player.Play(recorder.Frames, recorder.FPS, recorder.IsCustomRatio, recorder.Width, recorder.Height, this.optimizeMemoryUsage);
	}

	public void Pause()
	{
		player.Pause();
	}

	public void Resume()
	{
		player.Resume();
	}

	public void Stop()
	{
		player.Stop();
	}

	public int Reverse()
	{
		isReversed = !isReversed;
		int num = gifTextures.Count - 1 - playerComponent.spriteIndex;
		gifTextures.Reverse();
		playerComponent.spriteIndex = num;
		return num;
	}

	public void PingPong()
	{
		isPingPong = true;
		SetOnPlayingCallback(delegate
		{
			if (playerComponent != null && playerComponent.spriteIndex == 0)
			{
				gifTextures.Reverse();
			}
		});
	}

	public void CancelPingPong()
	{
		isPingPong = false;
		SetOnPlayingCallback(null);
	}

	public void SetLoadingCallback(Action<float> onLoading)
	{
		if (player != null)
		{
			player.SetLoadingCallback(onLoading);
		}
		else
		{
			Debug.LogWarning("Gif player not exist, please set callback after the player is set!");
		}
	}

	public void SetOnFirstFrameCallback(Action<ProGifPlayerComponent.FirstGifFrame> onFirstFrame)
	{
		if (player != null)
		{
			player.SetOnFirstFrameCallback(onFirstFrame);
		}
		else
		{
			Debug.LogWarning("Gif player not exist, please set callback after the player is set!");
		}
	}

	public void SetOnPlayingCallback(Action<GifTexture> onPlaying)
	{
		if (player != null)
		{
			player.SetOnPlayingCallback(onPlaying);
		}
		else
		{
			Debug.LogWarning("Gif player not exist, please set callback after the player is set!");
		}
	}

	public void ChangeDestination(Image destination)
	{
		if (player.GetComponent<ProGifPlayerImage>() != null)
		{
			player.GetComponent<ProGifPlayerImage>().ChangeDestination(destination);
		}
	}

	public void ChangeDestination(Renderer destination)
	{
		if (player.GetComponent<ProGifPlayerRenderer>() != null)
		{
			player.GetComponent<ProGifPlayerRenderer>().ChangeDestination(destination);
		}
	}

	public void AddExtraDestination(Image destination)
	{
		if (player.GetComponent<ProGifPlayerImage>() != null)
		{
			player.GetComponent<ProGifPlayerImage>().AddExtraDestination(destination);
		}
	}

	public void AddExtraDestination(Renderer destination)
	{
		if (player.GetComponent<ProGifPlayerRenderer>() != null)
		{
			player.GetComponent<ProGifPlayerRenderer>().AddExtraDestination(destination);
		}
	}

	public void RemoveFromExtraDestination(Image destination)
	{
		if (player.GetComponent<ProGifPlayerImage>() != null)
		{
			player.GetComponent<ProGifPlayerImage>().RemoveFromExtraDestination(destination);
		}
	}

	public void RemoveFromExtraDestination(Renderer destination)
	{
		if (player.GetComponent<ProGifPlayerRenderer>() != null)
		{
			player.GetComponent<ProGifPlayerRenderer>().RemoveFromExtraDestination(destination);
		}
	}

	public void Clear()
	{
		if (player != null)
		{
			player.Clear();
		}
	}
}
