using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerFixer : MonoBehaviour
{
	private VideoPlayer videoPlayer;

	private void Awake()
	{
		videoPlayer = GetComponent<VideoPlayer>();
		videoPlayer.prepareCompleted += PrepareCompletedHandler;
	}

	private void PrepareCompletedHandler(VideoPlayer source)
	{
		videoPlayer.Play();
	}

	public void PlayVideo()
	{
		videoPlayer.Prepare();
	}

	public void StopVideo()
	{
		videoPlayer.Stop();
		videoPlayer.targetTexture.Release();
		videoPlayer.targetTexture.DiscardContents();
	}

	private void OnEnable()
	{
		PlayVideo();
	}

	private void OnDisable()
	{
		StopVideo();
	}
}
