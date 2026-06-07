using System.Collections;
using DV;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public abstract class ControllerPointerDetector : MonoBehaviour
{
	[SerializeField]
	private GameObject[] highlightObjects;

	[SerializeField]
	private Transform animationTransform;

	[SerializeField]
	private Transform animationTransformWithColorChange;

	[SerializeField]
	private bool highlightActiveState;

	protected VRTK_InteractGrab leftGrab;

	protected VRTK_InteractGrab rightGrab;

	protected bool isLeftPointerPresent;

	protected bool isRightPointerPresent;

	protected bool canInteractWithLeft;

	protected bool canInteractWithRight;

	protected bool warnImproperTouchLeft;

	protected bool warnImproperTouchRight;

	private float scaleAmount = 0.5f;

	private float animationDuration = 0.1f;

	private float elapsedAnimationTime;

	private float maxColorAlpha;

	private Color animationColor;

	private Material animationMaterial;

	private Coroutine animationCoro;

	private static readonly int tintColor = Shader.PropertyToID("_TintColor");

	protected abstract bool InteractionAllowed { get; }

	public bool IsProperlyTouched(bool isRight)
	{
		if (isRight ? canInteractWithRight : canInteractWithLeft)
		{
			return !SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen;
		}
		return false;
	}

	public bool IsProperlyTouched()
	{
		if (!IsProperlyTouched(isRight: true))
		{
			return IsProperlyTouched(isRight: false);
		}
		return true;
	}

	public bool WarnImproperTouch(bool isRight)
	{
		if (!isRight)
		{
			return warnImproperTouchLeft;
		}
		return warnImproperTouchRight;
	}

	public bool WarnImproperTouch()
	{
		if (!WarnImproperTouch(isRight: true))
		{
			return WarnImproperTouch(isRight: false);
		}
		return true;
	}

	protected abstract bool ValidIntersect(VRTK_InteractGrab grab);

	private void Awake()
	{
		animationMaterial = animationTransformWithColorChange.GetComponentInChildren<Renderer>(includeInactive: true).material;
		animationColor = animationMaterial.GetColor(tintColor);
		maxColorAlpha = animationColor.a;
		if (highlightObjects != null)
		{
			GameObject[] array = highlightObjects;
			foreach (GameObject gameObject in array)
			{
				if (gameObject.activeSelf != highlightActiveState)
				{
					gameObject.SetActive(highlightActiveState);
				}
			}
		}
		SetupListeners(on: true);
	}

	private void OnDisable()
	{
		canInteractWithLeft = (canInteractWithRight = false);
		warnImproperTouchLeft = (warnImproperTouchRight = false);
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	protected virtual void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused += OnGamePaused;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnGameUnpaused;
		}
		else
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused -= OnGamePaused;
			SingletonBehaviour<AppUtil>.Instance.EndOfFrameGamePaused -= OnGameUnpaused;
		}
	}

	private void OnGamePaused()
	{
		UpdateHighlight(forceUnhighlight: true, instant: true);
	}

	private void OnGameUnpaused()
	{
		isLeftPointerPresent = (isRightPointerPresent = false);
		canInteractWithLeft = (canInteractWithRight = false);
		UpdateHighlight();
	}

	private void OnTriggerStay(Collider other)
	{
		if (!PipaUtils.IsPipa(other.transform) || SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen)
		{
			return;
		}
		VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(other.transform.parent.gameObject);
		bool flag = false;
		bool flag2 = false;
		if (controllerReference.hand == SDK_BaseController.ControllerHand.Right)
		{
			flag2 = isRightPointerPresent;
			isRightPointerPresent = true;
			if (rightGrab == null)
			{
				rightGrab = controllerReference.scriptAlias.GetComponentInChildren<VRTK_InteractGrab>();
			}
			flag = (canInteractWithRight = ValidIntersect(rightGrab));
		}
		else
		{
			flag2 = isLeftPointerPresent;
			isLeftPointerPresent = true;
			if (leftGrab == null)
			{
				leftGrab = controllerReference.scriptAlias.GetComponentInChildren<VRTK_InteractGrab>();
			}
			flag = (canInteractWithLeft = ValidIntersect(leftGrab));
		}
		if (InteractionAllowed && !flag2 && flag)
		{
			HapticUtils.DoHapticPulse(controllerReference, HapticIntensityType.Weak);
			UpdateHighlight();
		}
	}

	protected abstract bool CheckWarnImproperTouch(VRTK_InteractGrab grab);

	private void OnTriggerExit(Collider other)
	{
		if (PipaUtils.IsPipa(other.transform))
		{
			if (VRTK_ControllerReference.GetControllerReference(other.transform.parent.gameObject).hand == SDK_BaseController.ControllerHand.Right)
			{
				isRightPointerPresent = (canInteractWithRight = (warnImproperTouchRight = false));
			}
			else
			{
				isLeftPointerPresent = (canInteractWithLeft = (warnImproperTouchLeft = false));
			}
			UpdateHighlight();
		}
	}

	protected void UpdateHighlight(bool forceUnhighlight = false, bool instant = false)
	{
		if (highlightObjects == null)
		{
			return;
		}
		bool flag = !forceUnhighlight && InteractionAllowed && (canInteractWithRight || canInteractWithLeft);
		if (highlightActiveState != flag)
		{
			highlightActiveState = flag;
			if (animationCoro != null)
			{
				StopCoroutine(animationCoro);
			}
			animationCoro = StartCoroutine(AnimateScale(highlightActiveState, instant));
		}
	}

	private IEnumerator AnimateScale(bool scaleUp, bool instant = false)
	{
		if (scaleUp)
		{
			GameObject[] array = highlightObjects;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
		}
		while (true)
		{
			if (instant)
			{
				elapsedAnimationTime = (scaleUp ? 1 : 0);
			}
			else
			{
				elapsedAnimationTime += (scaleUp ? Time.deltaTime : (0f - Time.deltaTime));
			}
			elapsedAnimationTime = Mathf.Clamp(elapsedAnimationTime, 0f, animationDuration);
			float num = elapsedAnimationTime / animationDuration;
			float num2 = 1f + scaleAmount * num;
			animationTransform.localScale = new Vector3(num2, num2, num2);
			animationColor.a = maxColorAlpha * num;
			animationMaterial.SetColor(tintColor, animationColor);
			if (!(num > 0f) || !(num < 1f))
			{
				break;
			}
			yield return null;
		}
		if (!scaleUp)
		{
			GameObject[] array = highlightObjects;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
		}
		animationCoro = null;
	}
}
