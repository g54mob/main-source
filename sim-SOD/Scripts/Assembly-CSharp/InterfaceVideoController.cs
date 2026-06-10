using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InterfaceVideoController : MonoBehaviour
{
	[Header("Components")]
	public VideoPlayer player;

	public RawImage image;

	[Header("Settings")]
	public RenderTexture renderTexturePrefab;

	private RenderTexture renderTextureInstance;

	public void Setup(VideoClip clip, Texture2D img)
	{
	}

	private void OnDestroy()
	{
	}
}
