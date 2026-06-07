using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ReviewerPanel : MonoBehaviour
{
	public Image Thumbnail;

	public Text Name;

	public TextLerp Review;

	public Image[] StarImage;

	public RectTransform[] StarRect;

	public RectTransform ThumbRect;

	public CanvasGroup ThumbGroup;

	public float StampSpeed = 0.5f;

	public float TextSpeed = 1f;

	public float StarSpeed = 0.25f;

	public void ClearReview()
	{
		ThumbGroup.alpha = 0f;
		ThumbRect.localScale = Vector3.one * 2f;
		for (int i = 0; i < StarImage.Length; i++)
		{
			StarImage[i].color = StarImage[i].color.Alpha(0f);
			StarRect[i].localScale = Vector3.one * 5f;
		}
		Review.MaxChars = 0;
	}

	public void SetReview(FinalReviewGenerator.Review r, Sequence s)
	{
		Thumbnail.sprite = r.Subject.Logo;
		Name.text = r.Subject.Name;
		Review.text = r.Statement;
		s.Append(ThumbGroup.DOFade(1f, StampSpeed).SetEase(Ease.InCirc));
		s.Join(ThumbRect.DOScale(Vector3.one, StampSpeed).SetEase(Ease.InCirc));
	}

	public void DoStar(int score, Sequence s, AudioClip[] starBlips, AudioClip[] endStarBlips)
	{
		for (int i = 0; i < score; i++)
		{
			int k = i;
			if (i == score - 1)
			{
				s.AppendCallback(delegate
				{
					UISoundFX.PlaySFX(endStarBlips[k], 0.6f);
				});
			}
			else
			{
				s.AppendCallback(delegate
				{
					UISoundFX.PlaySFX(starBlips[k], 0.6f);
				});
			}
			s.Append(StarImage[i].DOColor(StarImage[i].color.Alpha(1f), StarSpeed).SetEase(Ease.InCirc));
			s.Join(StarRect[i].DOScale(Vector3.one, StarSpeed).SetEase(Ease.InCirc));
		}
	}

	public void DoReview(bool first, Sequence s)
	{
		Tweener t = DOTween.To(() => Review.MaxChars, delegate(int x)
		{
			Review.MaxChars = x;
		}, Review.text.Length, TextSpeed);
		if (first)
		{
			s.Append(t);
		}
		else
		{
			s.Join(t);
		}
	}
}
