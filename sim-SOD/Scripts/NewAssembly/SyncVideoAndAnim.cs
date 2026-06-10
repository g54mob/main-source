using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(Animation))]
public class SyncVideoAndAnim : MonoBehaviour
{
	private VideoPlayer videoPlayer;

	private Animation animation;

	private bool firstUpdate;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void Loop(VideoPlayer vp)
	{
	}
}
