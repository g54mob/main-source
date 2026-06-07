using UnityEngine;

public class UITimerBar : MonoBehaviour
{
	public delegate void UITimerEvent(UITimerBar timer);

	[SerializeField]
	private RectTransform _fill;

	[SerializeField]
	private bool _destroyWhenDone = true;

	private float _totalTime;

	private float _timeSpent;

	public event UITimerEvent OnFinished;

	public void StartTimer(float totalTime)
	{
		_totalTime = totalTime;
		_timeSpent = 0f;
	}

	public void UpdateTimeSpent(float time)
	{
		_timeSpent = time;
	}

	public void UpdateTime(float totalTime, float spent)
	{
		_totalTime = totalTime;
		_timeSpent = spent;
	}

	private void Update()
	{
		_timeSpent += Time.deltaTime;
		float num = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(_timeSpent / _totalTime));
		if (num == 1f && _destroyWhenDone)
		{
			this.OnFinished?.Invoke(this);
			Object.Destroy(base.gameObject);
		}
		else
		{
			_fill.localScale = new Vector3(num, 1f, 1f);
		}
	}

	public void SetScale(Vector2 scale)
	{
		(base.transform as RectTransform).sizeDelta *= scale;
	}
}
