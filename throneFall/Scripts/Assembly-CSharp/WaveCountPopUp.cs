using System.Collections;
using TMPro;
using UnityEngine;

public class WaveCountPopUp : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public GameObject popup;

	public AnimationCurve scaleCurve;

	public float animationTime = 0.75f;

	public float initialDelay = 0.5f;

	public float showTime = 3f;

	public TextMeshProUGUI targetText;

	private bool inAnimation;

	private void Start()
	{
		popup.SetActive(value: false);
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
		if (!inAnimation)
		{
			StartCoroutine(PopUpAnimation());
		}
	}

	private IEnumerator PopUpAnimation()
	{
		inAnimation = true;
		popup.SetActive(value: true);
		popup.transform.localScale = Vector3.zero;
		float timer = 0f;
		yield return new WaitForSeconds(initialDelay);
		targetText.text = "<style=Body Numerals>" + (EnemySpawner.instance.Wavenumber + 1) + "</style><style=Body Bold>/</style><style=Body Numerals>" + EnemySpawner.instance.WaveCount;
		StartCoroutine(PlaySoundDelayed());
		while (timer < animationTime)
		{
			timer += Time.deltaTime;
			popup.transform.localScale = Vector3.one * scaleCurve.Evaluate(Mathf.InverseLerp(0f, animationTime, timer));
			yield return null;
		}
		popup.transform.localScale = Vector3.one;
		yield return new WaitForSeconds(showTime);
		timer = 0f;
		while (timer < animationTime)
		{
			timer += Time.deltaTime;
			popup.transform.localScale = Vector3.one * scaleCurve.Evaluate(Mathf.InverseLerp(animationTime, 0f, timer));
			yield return null;
		}
		popup.transform.localScale = Vector3.zero;
		popup.SetActive(value: false);
		inAnimation = false;
	}

	private IEnumerator PlaySoundDelayed()
	{
		yield return new WaitForSeconds(0.1f);
		ThronefallAudioManager.Oneshot(ThronefallAudioManager.AudioOneShot.ShowWaveCount);
	}

	public void OnDuskEarly()
	{
	}
}
