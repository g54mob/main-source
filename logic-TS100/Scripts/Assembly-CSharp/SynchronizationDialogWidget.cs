using UnityEngine;

public sealed class SynchronizationDialogWidget : MonoBehaviour
{
	private static readonly float _0023_003DqpJ6BixE_0024R5AzlAUJG98hriEWN7pIKw30NJw_0024V13aGC0_003D;

	private static readonly float _0023_003DqLe0qXHePpt_TzD64T3VXQFQi5lbqp8bZhbIp6FWzOEk_003D;

	public RectTransform ProgressBar;

	private float _0023_003DqxaoPxwYlNabLqSUWr1e9mg_003D_003D;

	public SynchronizationDialogWidget()
	{
		int num = -1;
		if (false)
		{
		}
		base._002Ector();
	}

	static SynchronizationDialogWidget()
	{
		if (8u != 0)
		{
			_0023_003DqpJ6BixE_0024R5AzlAUJG98hriEWN7pIKw30NJw_0024V13aGC0_003D = 15f;
		}
		if (true)
		{
			_0023_003DqLe0qXHePpt_TzD64T3VXQFQi5lbqp8bZhbIp6FWzOEk_003D = 200f;
		}
	}

	private void Update()
	{
		float num = _0023_003DqxaoPxwYlNabLqSUWr1e9mg_003D_003D + Time.deltaTime;
		if (7u != 0)
		{
			_0023_003DqxaoPxwYlNabLqSUWr1e9mg_003D_003D = num;
		}
		RectTransform progressBar = ProgressBar;
		float x = (int)(_0023_003DqLe0qXHePpt_TzD64T3VXQFQi5lbqp8bZhbIp6FWzOEk_003D * _0023_003DqxaoPxwYlNabLqSUWr1e9mg_003D_003D / _0023_003DqpJ6BixE_0024R5AzlAUJG98hriEWN7pIKw30NJw_0024V13aGC0_003D) / 8 * 8;
		Vector2 sizeDelta = ProgressBar.sizeDelta;
		Vector2 vector;
		if (uint.MaxValue != 0)
		{
			vector = sizeDelta;
		}
		progressBar.sizeDelta = new Vector2(x, vector.y);
		if (_0023_003DqxaoPxwYlNabLqSUWr1e9mg_003D_003D > _0023_003DqpJ6BixE_0024R5AzlAUJG98hriEWN7pIKw30NJw_0024V13aGC0_003D)
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
		}
	}

	public void Initialize()
	{
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundModem._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
	}
}
