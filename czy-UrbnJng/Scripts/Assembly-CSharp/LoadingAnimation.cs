using System.Collections.Generic;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
	[SerializeField]
	private List<Transform> loadingFrames;

	private int currentFrame;

	private float frameTimer;

	private float frameRate = 0.2f;

	private void Start()
	{
		SetFrame(0);
	}

	private void Update()
	{
		frameTimer -= Time.deltaTime;
		if (frameTimer <= 0f)
		{
			frameTimer += frameRate;
			currentFrame = (currentFrame + 1) % loadingFrames.Count;
			SetFrame(currentFrame);
		}
	}

	private void SetFrame(int index)
	{
		foreach (Transform loadingFrame in loadingFrames)
		{
			loadingFrame.gameObject.SetActive(value: false);
		}
		loadingFrames[index].gameObject.SetActive(value: true);
	}
}
