using DG.Tweening;
using UnityEngine;

public class TrailerCamera : MonoBehaviour
{
	[SerializeField]
	public Vector3 startPosition;

	[SerializeField]
	public Vector3 startRotation;

	[SerializeField]
	public Vector3 endPosition;

	[SerializeField]
	public Vector3 endRotation;

	[SerializeField]
	public Vector3 extraRotation;

	[SerializeField]
	public float extraRotationDuration;

	[SerializeField]
	private AnimationCurve extraRotationEasingCurve;

	[SerializeField]
	private Transform extraRotationTarget;

	[SerializeField]
	private KeyCode extraRotationButton = KeyCode.E;

	[SerializeField]
	private bool extraRotationIncremental;

	[SerializeField]
	public float transitionDuration = 10f;

	[SerializeField]
	private AnimationCurve easingCurve;

	[SerializeField]
	private int loopCount;

	[SerializeField]
	internal LoopType loopType;

	[SerializeField]
	private KeyCode startButton = KeyCode.T;

	[SerializeField]
	private KeyCode pauseButton = KeyCode.Z;

	[SerializeField]
	public float automaticallyStartExtraRotationAfter = -1f;

	private Sequence transitionTween;

	private bool tweenPaused;

	private void RecordStartValues()
	{
		startPosition = base.transform.position;
		startRotation = base.transform.rotation.eulerAngles;
	}

	public void ResetToStartOrientation()
	{
		base.transform.position = startPosition;
		base.transform.rotation = Quaternion.Euler(startRotation);
	}

	private void RecordEndValues()
	{
		endPosition = base.transform.position;
		endRotation = base.transform.rotation.eulerAngles;
	}

	private void SetToEndOrientation()
	{
		base.transform.position = endPosition;
		base.transform.rotation = Quaternion.Euler(endRotation);
	}

	private void StartExtraRotation()
	{
		Tween t = TweenSettingsExtensions.SetEase(ShortcutExtensions.DOBlendableLocalRotateBy(extraRotationTarget, extraRotation, extraRotationDuration), extraRotationEasingCurve);
		if (extraRotationIncremental)
		{
			TweenSettingsExtensions.SetLoops(t, -1, LoopType.Incremental);
		}
	}

	private void StartTransition()
	{
		Sequence sequence = transitionTween;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence);
		}
		tweenPaused = false;
		transitionTween = DOTween.Sequence();
		TweenSettingsExtensions.Insert(transitionTween, 0f, TweenSettingsExtensions.SetLoops(TweenSettingsExtensions.SetEase(TweenSettingsExtensions.From(ShortcutExtensions.DOMove(base.transform, endPosition, transitionDuration), startPosition), easingCurve), loopCount, loopType));
		TweenSettingsExtensions.Insert(transitionTween, 0f, TweenSettingsExtensions.SetLoops(TweenSettingsExtensions.SetEase(ShortcutExtensions.DORotate(base.transform, endRotation, transitionDuration, RotateMode.FastBeyond360), easingCurve), loopCount, loopType));
		if (automaticallyStartExtraRotationAfter >= 0f)
		{
			TweenSettingsExtensions.Insert(transitionTween, automaticallyStartExtraRotationAfter, TweenSettingsExtensions.SetEase(ShortcutExtensions.DOBlendableLocalRotateBy(extraRotationTarget, extraRotation, extraRotationDuration), extraRotationEasingCurve));
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(startButton))
		{
			StartTransition();
		}
		if (Input.GetKeyDown(extraRotationButton))
		{
			StartExtraRotation();
		}
		if (Input.GetKeyDown(pauseButton) && transitionTween != null)
		{
			if (tweenPaused)
			{
				TweenExtensions.Play(transitionTween);
			}
			else
			{
				TweenExtensions.Pause(transitionTween);
			}
			tweenPaused = !tweenPaused;
		}
	}

	public void SetValues(Vector3 configTrailerCamStartPos, Vector3 configTrailerCamEndPos, float configTrailerCamDuration)
	{
		startPosition = configTrailerCamStartPos;
		endPosition = configTrailerCamEndPos;
		transitionDuration = configTrailerCamDuration;
	}
}
