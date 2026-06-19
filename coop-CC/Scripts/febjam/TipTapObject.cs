using System.Collections.Generic;
using Aggro.Core.Networking;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "tiptap-", menuName = "Tip Tap", order = 1)]
public class TipTapObject : NetworkScriptableObject
{
	public string username = string.Empty;

	public string description = string.Empty;

	public int likeCount;

	public string likeStatId;

	public List<VideoClip> videoClips;

	public Sprite thumbnail;

	[Range(0f, 100f)]
	public float volume = 20f;

	public int activeIndex;
}
