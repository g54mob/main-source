using Noesis;
using NoesisApp;
using UnityEngine;
using UnityEngine.Video;

public class NoesisMediaPlayer : MediaPlayer
{
	private GameObject _gameObject;

	private VideoPlayer _videoPlayer;

	private TextureSource _textureSource;

	private bool _keepPlaying;

	public override uint Width => 0u;

	public override uint Height => 0u;

	public override bool CanPause => false;

	public override bool HasAudio => false;

	public override bool HasVideo => false;

	public override double Duration => 0.0;

	public override double Position
	{
		get
		{
			return 0.0;
		}
		set
		{
		}
	}

	public override float SpeedRatio
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public override float Volume
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public override bool IsMuted
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override ImageSource TextureSource => null;

	public NoesisMediaPlayer(string uri)
	{
	}

	public override void Play()
	{
	}

	public override void Pause()
	{
	}

	public override void Stop()
	{
	}

	public override void Close()
	{
	}

	private void OnMediaOpened(VideoPlayer source)
	{
	}

	private void OnMediaEnded(VideoPlayer source)
	{
	}

	private void OnMediaFailed(VideoPlayer source, string message)
	{
	}

	private void OnFrameReady(VideoPlayer source, long index)
	{
	}
}
