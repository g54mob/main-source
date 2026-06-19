using Pug.RP;
using Pug.UnityExtensions;
using UnityEngine;

public class CameraSceneFader : MonoBehaviour
{
	public struct FadeSettings
	{
		public readonly FadeCurve fadeCurveIn;

		public readonly FadeCurve fadeCurveOut;

		public readonly FadeStyle fadeStyleIn;

		public readonly FadeStyle fadeStyleOut;

		public FadeSettings(FadeStyle styleOut, FadeCurve curveOut, FadeStyle styleIn, FadeCurve curveIn)
		{
			fadeStyleOut = styleOut;
			fadeCurveOut = curveOut;
			fadeStyleIn = styleIn;
			fadeCurveIn = curveIn;
		}
	}

	public enum FadeCurve
	{
		STRAIGHT = 0,
		SMOOTH = 1,
		ANIM_CURVE_VICTORY = 2,
		ANIM_CURVE_EATEN = 3,
		ANIM_CURVE_BUTTDANCE = 4
	}

	public enum FadeStyle
	{
		CIRCLE = 0,
		BLACK = 1,
		MASK = 2,
		CUT = 3
	}

	[Header("References:")]
	public Camera cameraToFade;

	public PP_Brightness brightnessComponent;

	public PP_MaskEye maskEyeComponent;

	[Header("Settings:")]
	public AnimationCurve straightAnimationCurve = new AnimationCurve();

	public AnimationCurve smoothAnimationCurve = new AnimationCurve();

	public AnimationCurve twoStepAnimationCurve = new AnimationCurve();

	public AnimationCurve twoStepDeathAnimationCurve = new AnimationCurve();

	public AnimationCurve twoStepButtAnimationCurve = new AnimationCurve();

	public AnimationCurve delayedSmoothAnimationCurve = new AnimationCurve();

	public bool useFadeCurveQuanitzation = true;

	[Range(0f, 480f)]
	public float fadeCurveQuantizationSteps = 134.99f;

	private FadeSettings _currentFadeSettings;

	private AnimationCurve _currentAnimationCurveIn;

	private AnimationCurve _currentAnimationCurveOut;

	private PugCamera m_pugCamera;

	public Texture2D maskTexture
	{
		get
		{
			return maskEyeComponent.maskTexture;
		}
		set
		{
			maskEyeComponent.maskTexture = value;
		}
	}

	public FadeSettings GetCurrentFadeSettings()
	{
		return _currentFadeSettings;
	}

	private void UpdateAnimationCurve(FadeCurve fadeCurve, bool curveIsFadeIn)
	{
		AnimationCurve animationCurve = null;
		switch (fadeCurve)
		{
		case FadeCurve.SMOOTH:
			animationCurve = smoothAnimationCurve;
			break;
		case FadeCurve.STRAIGHT:
			animationCurve = straightAnimationCurve;
			break;
		case FadeCurve.ANIM_CURVE_VICTORY:
			animationCurve = twoStepAnimationCurve;
			break;
		case FadeCurve.ANIM_CURVE_EATEN:
			animationCurve = twoStepDeathAnimationCurve;
			break;
		case FadeCurve.ANIM_CURVE_BUTTDANCE:
			animationCurve = twoStepButtAnimationCurve;
			break;
		default:
			animationCurve = straightAnimationCurve;
			Debug.LogError(fadeCurve.ToString() + " is an invalid type of fade curve.");
			break;
		}
		if (curveIsFadeIn)
		{
			_currentAnimationCurveIn = animationCurve;
		}
		else
		{
			_currentAnimationCurveOut = animationCurve;
		}
	}

	public void SetFadeSettings(FadeSettings _settings)
	{
		_currentFadeSettings = _settings;
		UpdateAnimationCurve(_settings.fadeCurveIn, curveIsFadeIn: true);
		UpdateAnimationCurve(_settings.fadeCurveOut, curveIsFadeIn: false);
	}

	public void OnFadeChange(bool isFadeIn, float fadeValue)
	{
		EnableCorrespondingPP(_currentFadeSettings.fadeStyleIn);
		UpdateShaderValues(fadeValue);
	}

	private void Awake()
	{
		m_pugCamera = GetComponent<PugCamera>();
		brightnessComponent.enabled = true;
		brightnessComponent.brightness = 0f;
		SetFadeSettings(new FadeSettings(FadeStyle.BLACK, FadeCurve.STRAIGHT, FadeStyle.BLACK, FadeCurve.STRAIGHT));
	}

	private void UpdateShaderValues(float fadeValue)
	{
		if (brightnessComponent.enabled)
		{
			brightnessComponent.brightness = fadeValue;
		}
		if (maskEyeComponent.enabled)
		{
			_ = Manager.main.currentSceneHandler == null;
			maskEyeComponent.scale = fadeValue;
		}
		m_pugCamera.fadeColor = new Color(0f, 0f, 0f, 1f - fadeValue);
	}

	private void LateUpdate()
	{
		LoadManager load = Manager.load;
		Fader.FadeDirection fadeDirection = load.GetFadeDirection();
		float fadeValue = load.GetFadeValue();
		if (fadeDirection == Fader.FadeDirection.None && fadeValue > 0.999f)
		{
			if (brightnessComponent.enabled)
			{
				brightnessComponent.enabled = false;
			}
			if (maskEyeComponent.enabled)
			{
				maskEyeComponent.enabled = false;
			}
			return;
		}
		bool num = fadeDirection == Fader.FadeDirection.In;
		FadeStyle fadeStyle = (num ? _currentFadeSettings.fadeStyleIn : _currentFadeSettings.fadeStyleOut);
		EnableCorrespondingPP(fadeStyle);
		float num2 = (num ? _currentAnimationCurveIn : _currentAnimationCurveOut).Evaluate(fadeValue);
		if (useFadeCurveQuanitzation)
		{
			num2 = Mathf.Round(num2 * fadeCurveQuantizationSteps) / fadeCurveQuantizationSteps;
		}
		num2 = Mathf.Clamp01(num2);
		UpdateShaderValues(num2);
	}

	public void EnableCorrespondingPP(FadeStyle fadeStyle)
	{
		brightnessComponent.enabled = fadeStyle == FadeStyle.BLACK;
		maskEyeComponent.enabled = fadeStyle == FadeStyle.MASK;
	}
}
