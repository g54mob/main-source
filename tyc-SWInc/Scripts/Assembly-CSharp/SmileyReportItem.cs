using System;
using UnityEngine;
using UnityEngine.UI;

public class SmileyReportItem : MonoBehaviour
{
	public Image Icon;

	public Sprite[] Icons;

	public Text Label;

	public Text Score;

	public GUIProgressBar Progress;

	public Gradient QualityGradient;

	[NonSerialized]
	private float _score;

	[NonSerialized]
	private float? _progress;

	public void Init(string spec, float score, float? progress, bool relative)
	{
		if (spec != null)
		{
			Label.text = spec.LocTry();
		}
		_score = score;
		_progress = progress;
		UpdateScore(relative);
	}

	public void UpdateScore(bool relative)
	{
		float num = ((relative && _progress.HasValue && _progress.Value > 0f) ? Mathf.Pow(Mathf.Clamp01(_score / _progress.Value), Mathf.Lerp(1.5f, 1f, _progress.Value)) : _score);
		Score.text = (num * 10f).ToString("0.#") + "/10";
		if (_progress.HasValue)
		{
			Progress.Value = _progress.Value;
		}
		else
		{
			Progress.gameObject.SetActive(false);
		}
		Icon.sprite = Icons[num.Quantize(Icons.Length)];
		Icon.color = QualityGradient.Evaluate(num);
	}
}
