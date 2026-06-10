using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashController : MonoBehaviour
{
	[Serializable]
	public class SplashImage
	{
		public RectTransform rect;

		public CanvasRenderer rend;

		public float displayTime;
	}

	public Image blackBG;

	public List<SplashImage> splashes;

	public float progress;

	public int splash;

	public float fadeOutTime;

	public bool fadeOut;

	public float fadeProg;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
