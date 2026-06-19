using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIFadeInOnEnable : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup _fadeGroup;

	[SerializeField]
	private RectTransform _transform;

	[SerializeField]
	private float _duration;

	[SerializeField]
	private Vector2 _slideOffset;

	[SerializeField]
	private Vector2 _scaleOffset;

	[SerializeField]
	private float _startFade;

	[SerializeField]
	private float _angularOffset;

	public Ease FadeEase;

	private float _baseAngle;

	private Vector2 _baseAnchoredPosition;

	private Vector2 _baseScale;

	private List<Tween> Tweens;

	private void OnEnable()
	{
	}

	public void DoFadeIn()
	{
	}

	public void Clear()
	{
	}
}
