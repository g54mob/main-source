using System;
using UnityEngine;

public class SimpleFade : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup fadeScreen;

	private bool fadeOut;

	private bool fadeIn;

	private float delayTimer;

	[SerializeField]
	private float fadedOutAlpha = 1f;

	public static SimpleFade Instance { get; private set; }

	internal bool IsFadeLocked { get; set; }

	public event Action OnUIShown;

	public event Action OnUIHidden;

	private void Awake()
	{
		Instance = this;
	}

	public void HideUI()
	{
		if (!fadeIn)
		{
			fadeOut = true;
			fadeIn = false;
		}
	}

	public void ShowUI()
	{
		if (!fadeOut)
		{
			fadeIn = true;
			fadeOut = false;
		}
	}

	public void ForceShowUI()
	{
		fadeIn = true;
		fadeOut = false;
	}

	public void ShowUIDelay(float delay)
	{
		if (!fadeOut)
		{
			delayTimer = delay;
			fadeIn = true;
			fadeOut = false;
		}
	}

	private void Update()
	{
		if (IsFadeLocked)
		{
			return;
		}
		if (fadeOut)
		{
			if (delayTimer > 0f)
			{
				delayTimer -= Time.deltaTime;
				Debug.Log($"SimpleFade: Fade Out delay timer: {delayTimer}");
			}
			else if (fadeScreen.alpha < fadedOutAlpha)
			{
				fadeScreen.alpha += Time.deltaTime;
				fadeScreen.alpha = Mathf.Min(fadeScreen.alpha, 1f);
				Debug.Log($"SimpleFade: Fade Out. Setting alpha to: {fadeScreen.alpha}. fadeOut: {fadeOut}. fadeIn: {fadeIn}.");
			}
			else
			{
				fadeScreen.alpha = fadedOutAlpha;
				this.OnUIHidden?.Invoke();
				Debug.Log("SimpleFade: Fade out finished");
				fadeOut = false;
			}
		}
		else if (fadeIn)
		{
			if (delayTimer > 0f)
			{
				delayTimer -= Time.deltaTime;
				Debug.Log($"SimpleFade: Fade In delay timer: {delayTimer}");
			}
			else if (fadeScreen.alpha > 0f)
			{
				fadeScreen.alpha -= Time.deltaTime;
				fadeScreen.alpha = Mathf.Max(fadeScreen.alpha, 0f);
				Debug.Log($"SimpleFade: Fade In. Setting alpha to: {fadeScreen.alpha}. fadeOut: {fadeOut}. fadeIn: {fadeIn}.");
			}
			else
			{
				fadeScreen.alpha = 0f;
				this.OnUIShown?.Invoke();
				Debug.Log("SimpleFade: Fade in finished");
				fadeIn = false;
			}
		}
	}

	public void BlackScreen()
	{
		fadeScreen.alpha = fadedOutAlpha;
		Debug.Log("SimpleFade: BlackScreen()");
	}
}
