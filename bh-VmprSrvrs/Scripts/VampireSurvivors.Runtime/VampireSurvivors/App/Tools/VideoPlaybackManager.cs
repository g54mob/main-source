using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace VampireSurvivors.App.Tools
{
	public class VideoPlaybackManager
	{
		private GameObject _videoPlayerPrefab;

		private Dictionary<VideoClip, RenderTexture> _renderTextures;

		private Dictionary<VideoClip, VideoPlayerHelper> _videoPlayerHelpers;

		public VideoPlayerHelper GenerateVideoPlayerForRenderTexture(VideoClip videoClip)
		{
			return null;
		}

		public Renderer GenerateQuadForVideoPlayback(VideoClip videoClip, Vector2 spawnPos, Vector3 scale, float alpha = 1f)
		{
			return null;
		}

		public void ReleaseVideo(VideoClip videoClip)
		{
		}

		public void Cleanup()
		{
		}

		private GameObject GetVideoPlayerPrefab()
		{
			return null;
		}

		private RenderTexture GenerateRenderTexture(VideoClip videoClip)
		{
			return null;
		}
	}
}
