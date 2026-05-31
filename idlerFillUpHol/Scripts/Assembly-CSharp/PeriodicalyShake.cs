using DG.Tweening;
using UnityEngine;

public class PeriodicalyShake : MonoBehaviour
{
	private float _timer;

	private void Start()
	{
	}

	private void Update()
	{
		_timer += Time.deltaTime;
		if (_timer >= 5f)
		{
			_timer = 0f;
			base.transform.DOShakeRotation(0.5f, new Vector3(0f, 0f, 20f));
		}
	}
}
