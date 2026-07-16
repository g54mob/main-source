using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MinigameReload : MonoBehaviour
{
	private Slider slider;

	private RectTransform rt;

	private float halfWidth;

	private float halfGoalWidth;

	private float start;

	private float finish;

	[SerializeField]
	private float scrollSpeed = 2f;

	[SerializeField]
	private RectTransform goalRt;

	[SerializeField]
	private RectTransform handleRt;

	private void Awake()
	{
		slider = GetComponent<Slider>();
		rt = GetComponent<RectTransform>();
		halfWidth = rt.rect.width / 2f;
		halfGoalWidth = goalRt.rect.width / 2f;
		RandomGoalLocation();
	}

	private void Update()
	{
		slider.value = Mathf.PingPong(Time.time * scrollSpeed, 1f);
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			TryComplete();
		}
		if (Keyboard.current.rKey.wasPressedThisFrame)
		{
			RandomGoalLocation();
		}
	}

	private void RandomGoalLocation()
	{
		float x = Random.Range(0f - halfWidth + halfGoalWidth, halfWidth - halfGoalWidth);
		goalRt.anchoredPosition = new Vector2(x, 0f);
		start = (goalRt.anchoredPosition.x - halfGoalWidth + halfWidth) / rt.rect.width;
		finish = (goalRt.anchoredPosition.x + halfGoalWidth + halfWidth) / rt.rect.width;
	}

	private void TryComplete()
	{
		float value = slider.value;
		if (value > start && value < finish)
		{
			Debug.Log("AWOOGA");
		}
		else
		{
			Debug.Log("RIP");
		}
	}
}
