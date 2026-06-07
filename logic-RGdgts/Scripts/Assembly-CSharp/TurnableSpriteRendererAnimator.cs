using System;
using UnityEngine;

public class TurnableSpriteRendererAnimator : MonoBehaviour
{
	[Serializable]
	public class Animation
	{
		public float fps;

		public int[] frames;
	}

	[Serializable]
	public class Frame
	{
		public TurnableSprite turnableSprite;
	}

	private TurnableSpriteRenderer turnableSpriteRenderer;

	private Animation _animation;

	private int _animationI;

	private int _animationDirection;

	private float lastFrameChangeTime;

	private int currentFrame;

	public Frame[] frames;

	private void Awake()
	{
	}

	public void Refresh()
	{
	}

	public void SetFrame(int i)
	{
	}

	public void PlayAnimation(Animation animation, int direction = 1)
	{
	}

	private void LateUpdate()
	{
	}
}
