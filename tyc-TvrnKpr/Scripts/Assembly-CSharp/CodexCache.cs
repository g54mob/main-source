using System;
using Gh;
using UnityEngine;

public class CodexCache : SingletonMonoBehaviour<CodexCache>
{
	[Serializable]
	public struct CodexEntry
	{
		public string keyword;

		public string header;

		[Multiline]
		public string text;
	}

	[Serializable]
	public struct CodexVideoMetadata
	{
		public string id;

		public uint width;

		public uint height;

		public string GetUrl()
		{
			return null;
		}
	}

	public CodexEntry[] CodexEntries;

	public Texture2D[] CodexImages;

	public CodexVideoMetadata[] CodexVideos;

	public Texture2D GetCodexImage(string id)
	{
		return null;
	}

	public CodexVideoMetadata GetVideoData(string id)
	{
		return default(CodexVideoMetadata);
	}

	private void Start()
	{
	}
}
