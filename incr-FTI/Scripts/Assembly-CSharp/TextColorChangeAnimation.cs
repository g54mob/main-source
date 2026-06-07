using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextColorChangeAnimation
{
	public void Run(TextMeshProUGUI target)
	{
		float duration = 0.2f;
		float interval = 0.4f;
		Sequence s = DOTween.Sequence();
		s.Append(target.DOColor(Color.cyan, duration));
		s.AppendInterval(interval);
		s.Append(target.DOColor(Color.white, duration));
		Sequence s2 = DOTween.Sequence();
		s2.Append(target.transform.DOScale(1.3f, duration));
		s2.AppendInterval(interval);
		s2.Append(target.transform.DOScale(1f, duration));
	}
}
