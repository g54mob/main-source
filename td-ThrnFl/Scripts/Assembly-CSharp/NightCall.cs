using MPUIKIT;
using MoreMountains.Feedbacks;
using Rewired;
using TMPro;
using UnityEngine;

public class NightCall : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public static NightCall instance;

	public float nightCallTime = 1f;

	public MPImage targetGraphic;

	public MPImage targetFill;

	public MPImage background;

	public TextMeshProUGUI nightCallCueText;

	public TextMeshProUGUI nightCallTimeText;

	public MMF_Player fullFeedback;

	public AnimationCurve textCueScaleCurve;

	public RectTransform scaleParent;

	public AudioSource nightCallAudio;

	private Player input;

	private bool active = true;

	private float currentFill;

	private PlayerInteraction player;

	private Color defaultBackgroundColor;

	private float nightCallTargetVolume;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		input = ReInput.players.GetPlayer(0);
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		targetFill.transform.localScale = Vector3.zero;
		player = PlayerInteraction.instance;
		defaultBackgroundColor = background.color;
		nightCallTargetVolume = nightCallAudio.volume;
	}

	private void Update()
	{
		UpdateFill();
	}

	public void UpdateFill()
	{
		if (active)
		{
			scaleParent.localScale = Vector3.one;
			if (input.GetButtonDown("Call Night") && player.IsFreeToCallNight && !DayNightCycle.Instance.AutomatedDaytime)
			{
				nightCallAudio.Stop();
				nightCallAudio.PlayOneShot(ThronefallAudioManager.Instance.audioContent.NightCallStart, 0.45f);
			}
			if (input.GetButton("Call Night") && player.IsFreeToCallNight && !DayNightCycle.Instance.AutomatedDaytime)
			{
				currentFill += Time.deltaTime * (1f / nightCallTime);
			}
			else
			{
				currentFill -= Time.deltaTime * 2f * (1f / nightCallTime);
			}
			if (currentFill >= 1f)
			{
				nightCallAudio.PlayOneShot(ThronefallAudioManager.Instance.audioContent.NightCallComplete, 0.8f);
				DayNightCycle.Instance.SwitchToNight();
				fullFeedback.PlayFeedbacks();
				active = false;
			}
			if (currentFill > 0f)
			{
				nightCallCueText.gameObject.SetActive(value: true);
				nightCallTimeText.text = (nightCallTime * (1f - currentFill)).ToString("F1") + "s";
				nightCallCueText.transform.localScale = Vector3.one * textCueScaleCurve.Evaluate(Mathf.InverseLerp(0f, 0.15f, currentFill));
				nightCallAudio.volume = Mathf.Lerp(0f, nightCallTargetVolume, Mathf.InverseLerp(0f, 0.3f, currentFill));
			}
			else
			{
				nightCallCueText.gameObject.SetActive(value: false);
				nightCallCueText.transform.localScale = Vector3.one;
			}
			defaultBackgroundColor.a = Mathf.InverseLerp(0f, 0.4f, currentFill);
			background.color = defaultBackgroundColor;
			currentFill = Mathf.Clamp01(currentFill);
			targetGraphic.fillAmount = currentFill;
		}
		else if (currentFill > 0f)
		{
			currentFill -= Time.deltaTime * 2f;
			defaultBackgroundColor.a = Mathf.InverseLerp(0f, 0.4f, currentFill);
			background.color = defaultBackgroundColor;
		}
	}

	public void OnDawn_AfterSunrise()
	{
		targetFill.transform.localScale = Vector3.zero;
		targetGraphic.transform.localScale = Vector3.one;
		targetGraphic.fillAmount = 0f;
		nightCallCueText.gameObject.SetActive(value: false);
		nightCallCueText.transform.localScale = Vector3.one;
		defaultBackgroundColor.a = 0f;
		background.color = defaultBackgroundColor;
		currentFill = 0f;
		active = true;
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
	}

	public void OnDuskEarly()
	{
	}
}
