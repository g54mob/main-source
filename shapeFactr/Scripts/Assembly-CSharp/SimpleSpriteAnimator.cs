using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSpriteAnimator : MonoBehaviour
{
	public Image targetImage;

	public List<Sprite> sprites;

	public float span;

	public int animationIndexOffset;

	public bool playOnAwake;

	public bool playOneShot;

	private float deltatime;

	private int animationIndex;

	private bool isPlaying;

	public bool IsPlaying => false;

	public void Awake()
	{
	}

	public void Play()
	{
	}

	public void Stop()
	{
	}

	public void Init()
	{
	}

	public void Update()
	{
	}

	public float GetPlayTime()
	{
		return 0f;
	}
}
