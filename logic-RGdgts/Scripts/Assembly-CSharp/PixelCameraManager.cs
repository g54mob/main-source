using System;
using System.Reflection;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PixelCameraManager : MonoBehaviour
{
	public Camera mainCamera;

	public Camera clearColorCamera;

	public TransparentWindow transparentWindow;

	public float zoom;

	public Ease expandEase;

	public float expandTime;

	private MethodInfo dynMethod;

	private PixelPerfectCamera pp;

	private object[] param;

	private Vector2Int wantedResolution;

	private Tweener tween;

	private bool isExpanded;

	private float expandedI;

	public float pixelRatio => 0f;

	public Vector2 renderSize => default(Vector2);

	public int renderScaleFactor => 0;

	public void Init()
	{
	}

	public void ApplyCameraMatrix()
	{
	}

	private void LateUpdate()
	{
	}

	public void SetStandardMode(float delayTransparentWindow, Action onComplete)
	{
	}

	public void SetDesktopMode(float expandToFullscreenDelay, Action onComplete)
	{
	}

	public void SetDesktopModeImmediate()
	{
	}

	public void Refresh()
	{
	}

	public void SetPixelPerfectRendering(bool isOn)
	{
	}

	public void SetBloom(bool isOn)
	{
	}

	public void ExpandToFullScreen(float delay = 0f, Action onComplete = null)
	{
	}

	public void ShrinkToNormal(Action onComplete = null)
	{
	}
}
