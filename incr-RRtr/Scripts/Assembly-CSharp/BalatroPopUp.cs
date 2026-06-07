using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BalatroPopUp : MonoBehaviour
{
	[SerializeField]
	private TMP_Text text;

	[SerializeField]
	private TMP_Text textShadow;

	[SerializeField]
	private Image background;

	[Header("Colors")]
	[SerializeField]
	private Color red;

	[SerializeField]
	private Color blue;

	[SerializeField]
	private Color yellow;

	private void Start()
	{
	}

	private void Test()
	{
		Show("x4 Mult", 1.25f, Color.red);
	}

	public void Show(string msg, float time, Color color)
	{
		text.text = msg;
		textShadow.text = msg;
		PlayTextAnimation(time);
		PlayBackgroundAnimation(time, color);
		UpdateColor(color);
		Object.Destroy(base.gameObject, time + 0.5f);
	}

	private void PlayTextAnimation(float time)
	{
		int num = 15;
		text.transform.DOKill();
		text.transform.localScale = Vector3.one * 1.3f;
		text.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
		int num2 = ((Random.Range(0, 2) != 0) ? 1 : (-1));
		text.transform.localEulerAngles = new Vector3(0f, 0f, num * num2);
		text.transform.DORotate(Vector3.zero, 0.25f).SetEase(Ease.OutBack);
		text.DOFade(0f, time / 4f).SetDelay(time * 3f / 4f);
		textShadow.transform.DOKill();
		textShadow.transform.localScale = Vector3.one * 1.3f;
		textShadow.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
		textShadow.transform.localEulerAngles = new Vector3(0f, 0f, num * num2);
		textShadow.transform.DORotate(Vector3.zero, 0.25f).SetEase(Ease.OutBack);
		textShadow.DOFade(0f, time / 4f).SetDelay(time * 3f / 4f);
	}

	private void PlayBackgroundAnimation(float time, Color color)
	{
		background.DOKill();
		background.transform.DOScale(Vector3.one * 1.5f, time).SetEase(Ease.InSine);
		int num = ((Random.Range(0, 2) != 0) ? 1 : (-1));
		int num2 = Random.Range(0, 10);
		background.transform.localEulerAngles = new Vector3(0f, 0f, 45 + num2);
		if (color != Color.yellow)
		{
			ShortcutExtensions.DORotate(endValue: new Vector3(0f, 0f, 45 + num2 + 20 * num), target: background.transform, duration: time);
		}
		background.DOFade(0f, time / 2f).SetDelay(time / 2f);
	}

	private void UpdateColor(Color color)
	{
		if (color == Color.red)
		{
			background.color = red;
		}
		else if (color == Color.blue)
		{
			background.color = blue;
		}
		else if (color == Color.yellow)
		{
			background.color = yellow;
		}
		else
		{
			background.color = color;
		}
	}
}
