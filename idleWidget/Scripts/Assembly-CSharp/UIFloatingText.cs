using UnityEngine;

public class UIFloatingText : MonoBehaviour
{
	[SerializeField]
	private float _floatDistance;

	[SerializeField]
	private float _floatTime;

	[SerializeField]
	private float _floatScatter;

	private CanvasGroup _group;

	private float _spentTime;

	private Vector2 _startPos;

	private void Start()
	{
		_group = GetComponent<CanvasGroup>();
		RectTransform rectTransform = base.transform as RectTransform;
		if (_floatScatter != 1f)
		{
			rectTransform.anchoredPosition *= new Vector2(SeededRandom.Global.RandomRange(1f / _floatScatter, _floatScatter), SeededRandom.Global.RandomRange(1f / _floatScatter, _floatScatter));
		}
		_startPos = rectTransform.anchoredPosition;
	}

	private void Update()
	{
		_spentTime += Time.deltaTime;
		if (_spentTime > _floatTime)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		float num = _spentTime / _floatTime;
		((RectTransform)base.transform).anchoredPosition = _startPos + new Vector2(0f, Mathf.SmoothStep(0f, 1f, num) * _floatDistance * (float)Screen.height);
		if (num > 0.6f)
		{
			_group.alpha = 1f - (num - 0.6f) * 3f;
		}
	}
}
