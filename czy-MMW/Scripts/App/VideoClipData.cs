using System;
using UnityEngine.Video;

[Serializable]
public struct VideoClipData
{
	public string ClipName;

	public uint Width;

	public uint Height;

	public VideoClip clip;
}
