using UnityEngine;

public class PulseHintState : IHintState
{
	private float pulseDelay;

	private float pulseLength;

	private float delayBetweenHintBlinks;

	private bool fadingIn;

	private bool limitedLife;

	public HintStateTypeEnum StateType
	{
		get
		{
			return HintStateTypeEnum.Transition;
		}
	}

	private PulseHintState()
	{
	}

	public PulseHintState(float pulseDelay, float pulseLength)
	{
		this.pulseDelay = pulseDelay;
		this.pulseLength = pulseLength;
		if (pulseLength > 0f)
		{
			limitedLife = true;
		}
	}

	public void Start()
	{
		if (!HintManager.HintPanelGameObject.activeSelf)
		{
			HintManager.HintPanelGameObject.SetActive(true);
		}
		delayBetweenHintBlinks = pulseDelay;
		fadingIn = false;
	}

	public bool Update()
	{
		delayBetweenHintBlinks -= Time.deltaTime;
		Color color = HintManager.HintText.color;
		float a = (color.a = delayBetweenHintBlinks / pulseDelay);
		if (fadingIn)
		{
			color.a = 1f - color.a;
		}
		color.a += 0.5f;
		HintManager.HintText.color = color;
		color.a = a;
		if (fadingIn)
		{
			color.a = 1f - color.a;
		}
		HintManager.HintBorder.color = color;
		if (delayBetweenHintBlinks <= 0f)
		{
			fadingIn = !fadingIn;
			delayBetweenHintBlinks = pulseDelay;
		}
		if (limitedLife)
		{
			pulseLength -= Time.deltaTime;
			if (pulseLength <= 0f)
			{
				return true;
			}
		}
		return false;
	}

	public void Stop()
	{
	}
}
