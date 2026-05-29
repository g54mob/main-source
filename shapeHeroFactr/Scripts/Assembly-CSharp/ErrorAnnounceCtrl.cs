using DG.Tweening;
using Libs;
using TMPro;
using UnityEngine;

public class ErrorAnnounceCtrl : SingletonMonoBehaviour<ErrorAnnounceCtrl>
{
	public TMP_Text title;

	public CanvasGroup background;

	public RectTransform bgRectTransform;

	private Sequence _sequence;

	private int? _priority;

	private bool _prevIsEnlargementUI;

	private float PosY => 0f;

	private void Awake()
	{
	}

	public void ShowError(string errorText, float duration = 3f, float fadeStart = 1f, int priority = 0)
	{
	}

	public void ShowError(eErrorId id, float duration = 3f, float fadeStart = 1f)
	{
	}

	private void Update()
	{
	}
}
