using System.Collections.Generic;
using UnityEngine.Video;

public class VideoProvider
{
	public struct Value
	{
		public int refs;

		public VideoClip video;
	}

	public static VideoProvider instance;

	private Dictionary<string, Value> _videos;

	private VideoProvider()
	{
	}

	public void Register(string uri, VideoClip video)
	{
	}

	public void Unregister(string uri)
	{
	}

	public VideoClip GetVideoClip(string uri)
	{
		return null;
	}
}
