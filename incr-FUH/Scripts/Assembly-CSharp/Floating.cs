using DG.Tweening;
using UnityEngine;

public class Floating : MonoBehaviour
{
	private void Start()
	{
		base.transform.DOMoveY(base.transform.position.y - 0.5f, 3f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
	}
}
