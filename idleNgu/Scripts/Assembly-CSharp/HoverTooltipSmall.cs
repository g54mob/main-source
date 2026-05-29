using UnityEngine;
using UnityEngine.UI;

public class HoverTooltipSmall : MonoBehaviour
{
	public GameObject tooltip;

	private float secondsCount;

	private float timeShown = -1f;

	private bool beingShown;

	private string tooltipMessage;

	public Text tooltipText;

	private float x;

	private float y;

	private float modx;

	private float mody;

	public void showTooltip(string message)
	{
		tooltipText = tooltip.GetComponentInChildren<Text>();
		tooltipText.text = message;
		beingShown = true;
	}

	public void showTooltip(string message, float seconds)
	{
		timeShown = seconds;
		secondsCount = 0f;
		tooltipText = tooltip.GetComponentInChildren<Text>();
		tooltipText.text = message;
		beingShown = true;
	}

	public void hideTooltip()
	{
		beingShown = false;
		timeShown = -1f;
		secondsCount = 0f;
	}

	private void Update()
	{
		UpdateTimerUI();
	}

	public void UpdateTimerUI()
	{
		if (timeShown >= 0f)
		{
			secondsCount += Time.deltaTime;
			if (secondsCount >= timeShown)
			{
				hideTooltip();
			}
		}
		if (beingShown)
		{
			x = Input.mousePosition.x;
			y = Input.mousePosition.y;
			if (x < 300f)
			{
				modx = 0f;
			}
			if (y < 40f)
			{
				mody = 0f;
			}
			if (x > 660f)
			{
				modx = -300f;
			}
			if (y > 560f)
			{
				mody = -135f;
			}
			tooltip.transform.position = new Vector3(x + modx, y + mody);
		}
		else
		{
			tooltip.transform.position = new Vector3(2000f, 2000f);
			tooltipText.text = "Hi I am a dog";
		}
	}
}
