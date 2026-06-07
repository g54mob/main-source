using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
	public RectTransform IconBack;

	public RectTransform MainButton;

	public Image Icon;

	public Texture2D ScreenChange;

	public Text Label;

	public float NormalSize;

	public float FullSize;

	public Color IconNormal;

	public Color IconHover;

	[NonSerialized]
	private Sequence _seq;

	public bool Scale = true;

	public void Hover(bool over)
	{
		MainMenuController.Instance.ClearScreenSaver();
		if (ScreenChange != null)
		{
			MainMenuController.Instance.ToggleScreenImage(over ? ScreenChange : null);
		}
		if (!GetComponent<Button>().interactable)
		{
			return;
		}
		if (_seq != null)
		{
			_seq.Kill();
		}
		_seq = DOTween.Sequence();
		if (over)
		{
			_seq.Append(IconBack.DOSizeDelta(new Vector2(42f, IconBack.sizeDelta.y), 0.25f, true).SetEase(Ease.OutCubic));
			if (Scale)
			{
				_seq.Insert(0f, MainButton.DOSizeDelta(new Vector2(FullSize, MainButton.sizeDelta.y), 0.5f).SetEase(Ease.OutElastic));
			}
			_seq.Insert(0f, Icon.DOColor(IconHover, 0.25f));
			_seq.Insert(0f, Label.rectTransform.DOAnchorPosX(64f, 0.5f, true).SetEase(Ease.OutCubic));
			_seq.Insert(0f, Icon.rectTransform.DOPunchScale(Vector3.one * 0.5f, 0.25f, 0));
		}
		else
		{
			Icon.rectTransform.localScale = Vector3.one;
			_seq.Append(IconBack.DOSizeDelta(new Vector2(0f, IconBack.sizeDelta.y), 0.25f, true).SetEase(Ease.OutCubic));
			if (Scale)
			{
				_seq.Insert(0f, MainButton.DOSizeDelta(new Vector2(NormalSize, MainButton.sizeDelta.y), 0.5f).SetEase(Ease.OutCubic));
			}
			_seq.Insert(0f, Icon.DOColor(IconNormal, 0.25f));
			_seq.Insert(0f, Label.rectTransform.DOAnchorPosX(48f, 0.5f, true).SetEase(Ease.OutCubic));
		}
		_seq.OnComplete(delegate
		{
			_seq = null;
		});
	}
}
