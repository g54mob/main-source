using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerCtrl : MonoBehaviour
{
	public RawImage rawImage;

	public VideoPlayer player;

	public GameObject skipText;

	public double skipableTime;

	public bool isLoop;

	private UnityAction OnLoopPointReachedAction;

	private Action OnSkipAction;

	private RenderTexture _renderTexture;

	private bool _completeLoaded;

	private InputActionController _input;

	private string _prevMovieFilePath;

	public bool isSetURL;

	private const string movieFileAdditionalPathForSteamDeck = "webm";

	private const string movieFileExtensionForSteamDeck = ".webm";

	public double MovieTime => 0.0;

	public bool CompleteLoaded
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool EnableSkip { get; private set; }

	private void Awake()
	{
	}

	public void Init(bool enableSkip, Action skipAction = null)
	{
	}

	public void Init(VideoClip clip, bool enableSkip, Action skipAction = null)
	{
	}

	private void Update()
	{
	}

	public void LoadAddressableVideo(string path, bool loadToPlay = false, UnityAction<VideoClip> preLoadVideo = null, UnityAction<VideoPlayer> postCompleteLoadVideo = null)
	{
	}

	public void Play()
	{
	}

	public void PlayDetailMovie(string filename)
	{
	}

	private string ReplaceSteamDeckPath(string filename)
	{
		return null;
	}

	public void Pause()
	{
	}

	public void Stop()
	{
	}

	public void SetLoopPointReachedAction(UnityAction action)
	{
	}

	private void LoopPointReacheddAction(VideoPlayer vp)
	{
	}

	private void DetailMovieLoopAction(VideoPlayer vp)
	{
	}

	public bool SetMovie(string fileName)
	{
		return false;
	}

	public void MuteAudio(bool mute = true)
	{
	}

	private void AudioAdjustment()
	{
	}

	private void OnDestroy()
	{
	}

	private void AttachRenderTexture(int width = 1920, int height = 1080)
	{
	}

	private void SkipAction()
	{
	}

	public void OnSkip()
	{
	}
}
