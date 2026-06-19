using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LetterAnimationStyles : MonoBehaviour
{
	public static Sequence CreateBounceAnimation(RectTransform letter, float height = 30f, float duration = 0.4f)
	{
		Vector2 anchoredPosition = letter.anchoredPosition;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y + height, duration * 0.4f).SetEase(Ease.OutQuad));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y, duration * 0.25f).SetEase(Ease.InQuad));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y + height * 0.6f, duration * 0.15f).SetEase(Ease.OutQuad));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y, duration * 0.12f).SetEase(Ease.InQuad));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y + height * 0.3f, duration * 0.08f).SetEase(Ease.OutQuad));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y, duration * 0.1f).SetEase(Ease.InQuad));
		return sequence;
	}

	public static Sequence CreateElasticAnimation(RectTransform letter, float height = 40f, float duration = 0.6f)
	{
		Vector2 anchoredPosition = letter.anchoredPosition;
		Vector3 localScale = letter.localScale;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y + height, duration * 0.5f).SetEase(Ease.OutElastic));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y, duration * 0.5f).SetEase(Ease.InElastic));
		sequence.Insert(0f, letter.DOScale(localScale * 1.3f, duration * 0.3f).SetEase(Ease.OutElastic));
		sequence.Insert(duration * 0.3f, letter.DOScale(localScale, duration * 0.4f).SetEase(Ease.InOutElastic));
		return sequence;
	}

	public static Sequence CreateWaveAnimation(RectTransform letter, float amplitude = 25f, float duration = 0.5f)
	{
		Vector2 anchoredPosition = letter.anchoredPosition;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y + amplitude, duration / 4f).SetEase(Ease.InOutSine));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y - amplitude * 0.5f, duration / 4f).SetEase(Ease.InOutSine));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y + amplitude * 0.3f, duration / 4f).SetEase(Ease.InOutSine));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y, duration / 4f).SetEase(Ease.InOutSine));
		return sequence;
	}

	public static Sequence CreateSpinJumpAnimation(RectTransform letter, float height = 35f, float spinAmount = 360f, float duration = 0.5f)
	{
		Vector2 anchoredPosition = letter.anchoredPosition;
		Vector3 localEulerAngles = letter.localEulerAngles;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y + height, duration / 2f).SetEase(Ease.OutQuad));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y, duration / 2f).SetEase(Ease.InQuad));
		sequence.Insert(0f, letter.DORotate(new Vector3(localEulerAngles.x, localEulerAngles.y, localEulerAngles.z + spinAmount), duration, RotateMode.FastBeyond360).SetEase(Ease.InOutQuad));
		return sequence;
	}

	public static Sequence CreateSquashStretchAnimation(RectTransform letter, float duration = 0.4f)
	{
		Vector2 anchoredPosition = letter.anchoredPosition;
		Vector3 localScale = letter.localScale;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(letter.DOScale(new Vector3(localScale.x * 1.2f, localScale.y * 0.8f, localScale.z), duration * 0.15f).SetEase(Ease.OutQuad));
		sequence.Append(letter.DOScale(new Vector3(localScale.x * 0.8f, localScale.y * 1.2f, localScale.z), duration * 0.2f).SetEase(Ease.InOutQuad));
		sequence.Join(letter.DOAnchorPosY(anchoredPosition.y + 40f, duration * 0.2f).SetEase(Ease.OutQuad));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y, duration * 0.25f).SetEase(Ease.InQuad));
		sequence.Append(letter.DOScale(new Vector3(localScale.x * 1.1f, localScale.y * 0.9f, localScale.z), duration * 0.1f).SetEase(Ease.OutQuad));
		sequence.Append(letter.DOScale(localScale, duration * 0.3f).SetEase(Ease.OutElastic));
		return sequence;
	}

	public static Sequence CreatePopAnimation(RectTransform letter, float scaleMultiplier = 1.5f, float duration = 0.3f)
	{
		Vector3 localScale = letter.localScale;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(letter.DOScale(localScale * scaleMultiplier, duration * 0.3f).SetEase(Ease.OutBack));
		sequence.Append(letter.DOScale(localScale, duration * 0.7f).SetEase(Ease.OutElastic));
		return sequence;
	}

	public static Sequence CreateWiggleAnimation(RectTransform letter, float angle = 15f, float duration = 0.4f)
	{
		Vector3 localEulerAngles = letter.localEulerAngles;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(letter.DORotate(new Vector3(localEulerAngles.x, localEulerAngles.y, localEulerAngles.z + angle), duration / 6f).SetEase(Ease.InOutSine));
		sequence.Append(letter.DORotate(new Vector3(localEulerAngles.x, localEulerAngles.y, localEulerAngles.z - angle), duration / 3f).SetEase(Ease.InOutSine));
		sequence.Append(letter.DORotate(new Vector3(localEulerAngles.x, localEulerAngles.y, localEulerAngles.z + angle * 0.5f), duration / 6f).SetEase(Ease.InOutSine));
		sequence.Append(letter.DORotate(localEulerAngles, duration / 3f).SetEase(Ease.InOutSine));
		return sequence;
	}

	public static Sequence CreateRainbowJumpAnimation(RectTransform letter, float height = 35f, float duration = 0.6f, Color[] rainbowColors = null)
	{
		if (rainbowColors == null)
		{
			rainbowColors = new Color[8]
			{
				Color.red,
				new Color(1f, 0.5f, 0f),
				Color.yellow,
				Color.green,
				Color.cyan,
				Color.blue,
				new Color(0.5f, 0f, 1f),
				Color.white
			};
		}
		Vector2 anchoredPosition = letter.anchoredPosition;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y + height, duration / 2f).SetEase(Ease.OutQuad));
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y, duration / 2f).SetEase(Ease.InQuad));
		Graphic component = letter.GetComponent<Graphic>();
		if (component != null)
		{
			Color color = component.color;
			float num = duration / (float)rainbowColors.Length;
			for (int i = 0; i < rainbowColors.Length; i++)
			{
				sequence.Insert((float)i * num, component.DOColor(rainbowColors[i], num));
			}
			sequence.Append(component.DOColor(color, num));
		}
		return sequence;
	}
}
