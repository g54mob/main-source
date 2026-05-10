using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SteppedSlider : Slider, IScrollHandler, IEventSystemHandler
{
	[SerializeField]
	private float step = 0.1f;

	public AudioClip sound;

	[SerializeField]
	private float minPitch = 1f;

	[SerializeField]
	private float maxPitch = 1f;

	private float soundCooldown = 0.035f;

	private float lastTimeSound;

	[Header("Text")]
	[SerializeField]
	private TextMeshProUGUI sliderText;

	[SerializeField]
	private int textMonoSpace;

	[SerializeField]
	private bool zeroAsInifinite;

	[SerializeField]
	private bool maxAsInfinite;

	private bool firstActivationMuted = true;

	protected override void Start()
	{
		base.Start();
		SetText(m_Value);
	}

	protected override void Set(float input, bool sendCallback = true)
	{
		input = ParseInput(input);
		if (m_Value != input)
		{
			base.Set(input, sendCallback);
			SetText(m_Value);
			if (!firstActivationMuted && Time.unscaledTime >= lastTimeSound + soundCooldown)
			{
				lastTimeSound = Time.unscaledTime;
				AudioSystem.Instance.PlaySound2D(sound, AudioSystem.EAudioMixerGroup.UI, 0.65f, Mathf.Lerp(minPitch, maxPitch, (input - base.minValue) / (base.maxValue - base.minValue)));
			}
			firstActivationMuted = false;
		}
	}

	private float ParseInput(float input)
	{
		return Mathf.Round(input / base.maxValue * (base.maxValue / step)) * step;
	}

	private void SetText(float value)
	{
		if ((bool)sliderText)
		{
			string text = "";
			if (textMonoSpace > 0)
			{
				text = "<mspace=" + textMonoSpace + ">";
			}
			text = ((zeroAsInifinite && value == 0f) ? (text + "∞") : ((!maxAsInfinite || !(value >= base.maxValue)) ? (text + value) : (text + "∞")));
			sliderText.text = text;
		}
	}

	public void OnScroll(PointerEventData eventData)
	{
		if (eventData.scrollDelta.y > 0f)
		{
			Set(m_Value + step);
		}
		else
		{
			Set(m_Value - step);
		}
	}
}
