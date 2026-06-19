using System.Collections;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class PopupPanelManager : MonoBehaviour
	{
		public enum DefaultState
		{
			Minimized = 0,
			Expanded = 1
		}

		public enum AnimationDirection
		{
			Vertical = 0,
			Horizontal = 1
		}

		[Header("Settings")]
		public bool enableBlurAnim = true;

		public bool useTransition = true;

		public bool disableOnOut = true;

		public bool disableAnimation;

		public float closeOn = 25f;

		public float panelSize = 100f;

		[Header("Animation")]
		public DefaultState defaultPanelState;

		public AnimationDirection animationDirection;

		[SerializeField]
		private AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[SerializeField]
		[Range(0.5f, 10f)]
		private float curveSpeed = 3f;

		[SerializeField]
		[Range(1f, 12f)]
		private float fadeSpeed = 3f;

		private RectTransform objectRect;

		private CanvasGroup objectCG;

		private UIBlur bManager;

		[HideInInspector]
		public bool isOn;

		private void Awake()
		{
			objectRect = base.gameObject.GetComponent<RectTransform>();
			if (disableAnimation)
			{
				base.enabled = false;
				return;
			}
			if (useTransition)
			{
				objectCG = base.gameObject.GetComponent<CanvasGroup>();
				objectCG.alpha = 0f;
				objectCG.interactable = false;
				objectCG.blocksRaycasts = false;
			}
			if (defaultPanelState == DefaultState.Minimized)
			{
				if (animationDirection == AnimationDirection.Vertical)
				{
					objectRect.sizeDelta = new Vector2(objectRect.sizeDelta.x, closeOn);
				}
				else
				{
					objectRect.sizeDelta = new Vector2(closeOn, objectRect.sizeDelta.y);
				}
				isOn = false;
			}
			else if (defaultPanelState == DefaultState.Expanded)
			{
				if (animationDirection == AnimationDirection.Vertical)
				{
					objectRect.sizeDelta = new Vector2(objectRect.sizeDelta.x, panelSize);
				}
				else
				{
					objectRect.sizeDelta = new Vector2(panelSize, objectRect.sizeDelta.y);
				}
				if (useTransition)
				{
					objectCG.alpha = 1f;
					objectCG.interactable = true;
					objectCG.blocksRaycasts = true;
				}
				isOn = true;
			}
			if (enableBlurAnim)
			{
				bManager = base.gameObject.GetComponent<UIBlur>();
			}
			if (!isOn && disableOnOut && defaultPanelState != DefaultState.Expanded)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void OnDisable()
		{
			isOn = false;
		}

		public void AnimatePanel()
		{
			base.gameObject.SetActive(value: true);
			if (isOn)
			{
				if (useTransition && !disableAnimation)
				{
					objectCG.blocksRaycasts = false;
					objectCG.interactable = false;
				}
				if (enableBlurAnim && !disableAnimation)
				{
					bManager.BlurOutAnim();
				}
				ClosePanel();
			}
			else if (!isOn)
			{
				if (useTransition && !disableAnimation)
				{
					objectCG.blocksRaycasts = true;
					objectCG.interactable = true;
				}
				if (enableBlurAnim && !disableAnimation)
				{
					bManager.BlurInAnim();
				}
				OpenPanel();
			}
		}

		public void OpenPanel()
		{
			if (objectRect == null)
			{
				objectRect = base.gameObject.GetComponent<RectTransform>();
			}
			if (isOn)
			{
				return;
			}
			base.gameObject.SetActive(value: true);
			isOn = true;
			if (!disableAnimation)
			{
				if (animationDirection == AnimationDirection.Horizontal)
				{
					StopCoroutine("HorizontalExpand");
					StartCoroutine("HorizontalExpand");
				}
				else if (animationDirection == AnimationDirection.Vertical)
				{
					StopCoroutine("VerticalExpand");
					StartCoroutine("VerticalExpand");
				}
				if (useTransition)
				{
					StartCoroutine("FadeIn");
					objectCG.blocksRaycasts = true;
					objectCG.interactable = true;
				}
				if (enableBlurAnim)
				{
					bManager.BlurInAnim();
				}
			}
		}

		public void ClosePanel()
		{
			if (objectRect == null || !isOn)
			{
				return;
			}
			isOn = false;
			if (disableAnimation)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			if (animationDirection == AnimationDirection.Horizontal)
			{
				StopCoroutine("HorizontalMinimize");
				StartCoroutine("HorizontalMinimize");
			}
			else if (animationDirection == AnimationDirection.Vertical)
			{
				StopCoroutine("VerticalMinimize");
				StartCoroutine("VerticalMinimize");
			}
			if (useTransition)
			{
				StopCoroutine("FadeOut");
				StartCoroutine("FadeOut");
				if (disableOnOut)
				{
					StopCoroutine("CheckForDisable");
					StartCoroutine("CheckForDisable");
				}
				objectCG.blocksRaycasts = false;
				objectCG.interactable = false;
			}
			if (enableBlurAnim)
			{
				bManager.BlurOutAnim();
			}
		}

		public void InstantMinimized()
		{
			if (!(objectRect == null) && !(objectCG == null))
			{
				objectRect.sizeDelta = new Vector2(objectRect.sizeDelta.x, closeOn);
				objectCG.alpha = 0f;
			}
		}

		public void InstantExpanded()
		{
			if (!(objectRect == null) && !(objectCG == null))
			{
				objectRect.sizeDelta = new Vector2(objectRect.sizeDelta.x, panelSize);
				objectCG.alpha = 1f;
			}
		}

		private IEnumerator VerticalExpand()
		{
			StopCoroutine("VerticalMinimize");
			float elapsedTime = 0f;
			Vector2 startPos = objectRect.sizeDelta;
			Vector2 endPos = new Vector2(objectRect.sizeDelta.x, panelSize);
			while (objectRect.sizeDelta.y < panelSize - 0.1f)
			{
				elapsedTime += Time.deltaTime;
				objectRect.sizeDelta = Vector2.Lerp(startPos, endPos, animationCurve.Evaluate(elapsedTime * curveSpeed));
				yield return null;
			}
			objectRect.sizeDelta = endPos;
		}

		private IEnumerator VerticalMinimize()
		{
			StopCoroutine("VerticalExpand");
			float elapsedTime = 0f;
			Vector2 startPos = objectRect.sizeDelta;
			Vector2 endPos = new Vector2(objectRect.sizeDelta.x, closeOn);
			while (objectRect.sizeDelta.y > closeOn + 0.1f)
			{
				elapsedTime += Time.deltaTime;
				objectRect.sizeDelta = Vector2.Lerp(startPos, endPos, animationCurve.Evaluate(elapsedTime * curveSpeed));
				yield return null;
			}
			objectRect.sizeDelta = endPos;
		}

		private IEnumerator HorizontalExpand()
		{
			StopCoroutine("HorizontalMinimize");
			float elapsedTime = 0f;
			Vector2 startPos = objectRect.sizeDelta;
			Vector2 endPos = new Vector2(panelSize, objectRect.sizeDelta.y);
			while (objectRect.sizeDelta.y < panelSize - 0.1f)
			{
				elapsedTime += Time.deltaTime;
				objectRect.sizeDelta = Vector2.Lerp(startPos, endPos, animationCurve.Evaluate(elapsedTime * curveSpeed));
				yield return null;
			}
			objectRect.sizeDelta = endPos;
		}

		private IEnumerator HorizontalMinimize()
		{
			StopCoroutine("HorizontalExpand");
			float elapsedTime = 0f;
			Vector2 startPos = objectRect.sizeDelta;
			Vector2 endPos = new Vector2(closeOn, objectRect.sizeDelta.y);
			while (objectRect.sizeDelta.y > panelSize + closeOn)
			{
				elapsedTime += Time.deltaTime;
				objectRect.sizeDelta = Vector2.Lerp(startPos, endPos, animationCurve.Evaluate(elapsedTime * curveSpeed));
				yield return null;
			}
			objectRect.sizeDelta = endPos;
		}

		private IEnumerator FadeIn()
		{
			StopCoroutine("FadeOut");
			float elapsedTime = 0f;
			float startValue = 0f;
			while (objectCG.alpha < 0.99f)
			{
				elapsedTime += Time.deltaTime;
				objectCG.alpha = Mathf.Lerp(startValue, 1f, animationCurve.Evaluate(elapsedTime * fadeSpeed));
				yield return null;
			}
			objectCG.alpha = 1f;
		}

		private IEnumerator FadeOut()
		{
			StopCoroutine("FadeIn");
			float elapsedTime = 0f;
			float startValue = objectCG.alpha;
			while (objectCG.alpha > 0.01f)
			{
				elapsedTime += Time.deltaTime;
				objectCG.alpha = Mathf.Lerp(startValue, 0f, animationCurve.Evaluate(elapsedTime * fadeSpeed));
				yield return null;
			}
			objectCG.alpha = 0f;
		}

		private IEnumerator CheckForDisable()
		{
			while (objectCG.alpha > 0f)
			{
				yield return null;
			}
			base.gameObject.SetActive(value: false);
		}
	}
}
