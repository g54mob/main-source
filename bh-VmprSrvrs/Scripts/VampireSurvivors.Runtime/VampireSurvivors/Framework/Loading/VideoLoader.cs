using System;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.Video;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loading
{
	public static class VideoLoader
	{
		public static void LoadVideo(string videoName, string cacheGroupName, DlcType? dlcType, Action<VideoClip> onComplete = null)
		{
		}

		public static void LoadVideoAsync(string videoName, string cacheGroupName, DlcType? dlcType, Action<VideoClip> onComplete = null)
		{
		}

		private static void LoadVideoInternal(string videoName, string cacheGroupName, DlcType? dlcType, Action<VideoClip> onComplete = null, bool forceSync = false)
		{
		}

		private static void LoadVideoFromResourceLocation(IResourceLocation videoLocation, string cacheGroupName, string videoName, DlcType? dlcType, Action<VideoClip> onComplete = null, bool forceSync = false)
		{
		}
	}
}
