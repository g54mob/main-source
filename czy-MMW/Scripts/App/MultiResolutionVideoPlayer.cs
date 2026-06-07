using System;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class MultiResolutionVideoPlayer : MonoBehaviour
{
	[Serializable]
	public struct VideoClipAspectGroup
	{
		public Vector2 size;

		public VideoClipData[] videoClipData;

		public string folderName;

		public float Aspect => size.x / size.y;
	}

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("MultiResolutionVideoPlayer");

	public Camera targetCamera;

	[HideInInspector]
	public VideoPlayer videoPlayer;

	[SerializeField]
	public VideoClipAspectGroup[] videoCandidates;

	private void Awake()
	{
		videoPlayer = base.gameObject.AddComponent<VideoPlayer>();
		videoPlayer.playOnAwake = false;
		videoPlayer.isLooping = false;
		videoPlayer.targetCamera = targetCamera;
		videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
		videoPlayer.aspectRatio = VideoAspectRatio.FitOutside;
		try
		{
			if (!TryLoadBestMatchingVideoClip())
			{
				return;
			}
		}
		catch (Exception ex)
		{
			Log.Error(ex.Message);
		}
		videoPlayer.Prepare();
		if (!Application.isEditor)
		{
			return;
		}
		int num = 0;
		VideoClipAspectGroup[] array = videoCandidates;
		for (int i = 0; i < array.Length; i++)
		{
			VideoClipAspectGroup aspectGroup = array[i];
			VideoClipData[] videoClipData = aspectGroup.videoClipData;
			for (int j = 0; j < videoClipData.Length; j++)
			{
				VideoClipData bestClip = videoClipData[j];
				if ((bool)bestClip.clip)
				{
					num++;
				}
				else
				{
					File.Exists(BuildFilePath(aspectGroup, bestClip));
				}
			}
		}
	}

	private bool TryLoadBestMatchingVideoClip()
	{
		if (videoCandidates.Length == 0)
		{
			Log.Error("No video candidates found.");
			return false;
		}
		float aspect = videoPlayer.targetCamera.aspect;
		int num = 0;
		float num2 = videoCandidates[num].Aspect;
		for (int i = 1; i < videoCandidates.Length; i++)
		{
			float aspect2 = videoCandidates[i].Aspect;
			if (Mathf.Abs(aspect2 - aspect) < Math.Abs(num2 - aspect))
			{
				num = i;
				num2 = aspect2;
			}
		}
		VideoClipAspectGroup aspectGroup = videoCandidates[num];
		Log.Info("Selected aspect ratio: {0}x{1}", aspectGroup.size.x, aspectGroup.size.y);
		if (aspectGroup.videoClipData.Length == 0 || string.IsNullOrEmpty(aspectGroup.videoClipData[0].ClipName))
		{
			Log.Error("No video clips in aspect group {0}x{1}", aspectGroup.size.x, aspectGroup.size.y);
			return false;
		}
		int num3 = 0;
		uint num4 = aspectGroup.videoClipData[num3].Width * aspectGroup.videoClipData[num3].Height;
		int num5 = targetCamera.pixelWidth * targetCamera.pixelHeight;
		for (int j = 1; j < aspectGroup.videoClipData.Length; j++)
		{
			uint num6 = aspectGroup.videoClipData[j].Width * aspectGroup.videoClipData[j].Height;
			if (num6 < num5 && (Mathf.Abs(num6 - num5) < (float)Math.Abs(num4 - num5) || num4 > num5))
			{
				num3 = j;
				num4 = num6;
			}
		}
		VideoClipData bestClip = aspectGroup.videoClipData[num3];
		Log.Info("Selected resolution: {0}x{1}", bestClip.Width, bestClip.Height);
		if ((bool)bestClip.clip)
		{
			Log.Info("Playing from embedded clip.", bestClip.Width, bestClip.Height);
			videoPlayer.source = VideoSource.VideoClip;
			videoPlayer.clip = bestClip.clip;
		}
		else
		{
			string text = BuildFilePath(aspectGroup, bestClip);
			Log.Info("Playing from " + text);
			videoPlayer.source = VideoSource.Url;
			videoPlayer.url = text;
		}
		return true;
	}

	private string BuildFilePath(VideoClipAspectGroup aspectGroup, VideoClipData bestClip)
	{
		return Application.streamingAssetsPath + "/AppleArcadeSplashVideos/" + aspectGroup.folderName + "/" + bestClip.ClipName + ".mp4";
	}
}
