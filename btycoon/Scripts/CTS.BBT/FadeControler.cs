using UnityEngine;
using UnityEngine.UI;

public class FadeControler : MonoBehaviour
{
	public delegate void OnFadeFinish();

	public OnFadeFinish onFadeInFinish;

	public OnFadeFinish onFadeOutFinish;

	[SerializeField]
	private AnimationCurve fadeCurve;

	[SerializeField]
	private Image fadePanelImg;

	[SerializeField]
	private bool useUnscaledTime;

	private bool? fadeIn;

	private float fadeTime;

	private float currentFadeTime;

	private bool backToOut;

	private bool toLoading;

	private float pr_currentFadeValue;

	public static FadeControler instance { get; private set; }

	private float currentFadeValue
	{
		get
		{
			return pr_currentFadeValue;
		}
		set
		{
			pr_currentFadeValue = value;
			if (fadePanelImg != null)
			{
				fadePanelImg.color = new Color(0f, 0f, 0f, value);
			}
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			fadePanelImg.enabled = true;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (!fadeIn.HasValue || !(currentFadeTime > 0f))
		{
			return;
		}
		if (useUnscaledTime)
		{
			currentFadeTime -= Time.unscaledDeltaTime / fadeTime;
		}
		else
		{
			currentFadeTime -= Time.deltaTime / fadeTime;
		}
		if (fadeIn.Value)
		{
			currentFadeValue = fadeCurve.Evaluate(1f - currentFadeTime);
			if (currentFadeTime <= 0f)
			{
				if (backToOut)
				{
					currentFadeTime = 1f;
					fadeIn = false;
					backToOut = false;
				}
				else if (toLoading)
				{
					currentFadeTime = 0f;
					fadeIn = null;
					base.enabled = false;
				}
			}
		}
		else
		{
			currentFadeValue = fadeCurve.Evaluate(currentFadeTime);
			if (currentFadeTime <= 0f)
			{
				currentFadeTime = 0f;
				fadeIn = null;
				base.enabled = false;
			}
		}
	}

	public void FadeOut(float _time)
	{
		base.enabled = true;
		fadeTime = _time;
		currentFadeTime = 1f;
		fadeIn = true;
		currentFadeValue = 0f;
	}

	public void FadeIn(float _time)
	{
		base.enabled = true;
		fadeTime = _time;
		currentFadeTime = 1f;
		fadeIn = false;
	}
}
