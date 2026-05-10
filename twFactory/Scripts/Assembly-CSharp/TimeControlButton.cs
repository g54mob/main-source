using UnityEngine;
using UnityEngine.UI;

public class TimeControlButton : MonoBehaviour
{
	[SerializeField]
	private TimeManager.ETimeSpeed timeSpeed;

	[SerializeField]
	private Color enabledColor;

	[SerializeField]
	private float enabledSize;

	[SerializeField]
	private Color disabledColor;

	[SerializeField]
	private float disabledSize;

	private Image buttonImage;

	private void Awake()
	{
		buttonImage = GetComponent<Image>();
	}

	private void Start()
	{
		LTFunctionLibrary.GetTimeManager().onGameSpeedChanged += OnGameSpeedChanged;
		OnGameSpeedChanged(LTFunctionLibrary.GetTimeManager().GetGameSpeed(), Time.timeScale);
	}

	private void OnGameSpeedChanged(TimeManager.ETimeSpeed timeSpeed, float speed)
	{
		if (timeSpeed == this.timeSpeed)
		{
			buttonImage.color = enabledColor;
			buttonImage.rectTransform.sizeDelta = new Vector2(enabledSize, enabledSize);
		}
		else
		{
			buttonImage.color = disabledColor;
			buttonImage.rectTransform.sizeDelta = new Vector2(disabledSize, disabledSize);
		}
	}
}
