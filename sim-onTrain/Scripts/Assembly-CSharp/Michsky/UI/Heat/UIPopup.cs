using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(CanvasGroup))]
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("Heat UI/Animation/UI Popup")]
	public class UIPopup : MonoBehaviour
	{
		public enum AnimationMode
		{
			Scale = 0,
			Horizontal = 1,
			Vertical = 2
		}

		public enum StartBehaviour
		{
			Default = 0,
			Disabled = 1,
			Static = 2
		}

		public enum UpdateMode
		{
			DeltaTime = 0,
			UnscaledTime = 1
		}

		[Header("Settings")]
		[SerializeField]
		private bool playOnEnable = true;

		[SerializeField]
		private bool closeOnDisable;

		[Tooltip("Skip out animation.")]
		[SerializeField]
		private bool instantOut;

		[Tooltip("Enables content size fitter mode.")]
		[SerializeField]
		private bool fitterMode;

		[SerializeField]
		private StartBehaviour startBehaviour;

		[SerializeField]
		private UpdateMode updateMode = UpdateMode.UnscaledTime;

		[Header("Animation")]
		[SerializeField]
		private AnimationMode animationMode;

		[SerializeField]
		private AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[Range(0.5f, 10f)]
		public float curveSpeed = 4f;

		[Header("Events")]
		public UnityEvent onEnable = new UnityEvent();

		public UnityEvent onVisible = new UnityEvent();

		public UnityEvent onDisable = new UnityEvent();

		private RectTransform rect;

		private CanvasGroup cg;

		private Vector2 rectHelper;

		private bool isInitialized;

		private bool isFitterInitialized;

		[HideInInspector]
		public bool isOn;

		private void Start()
		{
			if (startBehaviour == StartBehaviour.Disabled)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void OnEnable()
		{
			if (!isInitialized)
			{
				Initialize();
			}
			if (playOnEnable)
			{
				isOn = false;
				PlayIn();
			}
		}

		private void OnDisable()
		{
			if (closeOnDisable)
			{
				base.gameObject.SetActive(value: false);
				isOn = false;
			}
		}

		private void Initialize()
		{
			if (rect == null)
			{
				rect = GetComponent<RectTransform>();
			}
			if (cg == null)
			{
				cg = GetComponent<CanvasGroup>();
			}
			if (startBehaviour == StartBehaviour.Disabled || startBehaviour == StartBehaviour.Static)
			{
				rectHelper = rect.sizeDelta;
			}
			else if (startBehaviour == StartBehaviour.Default && base.gameObject.activeInHierarchy && !fitterMode)
			{
				isOn = true;
			}
			isInitialized = true;
		}

		public void ResetFitterData()
		{
			isFitterInitialized = false;
		}

		public void Animate()
		{
			if (isOn)
			{
				PlayOut();
			}
			else
			{
				PlayIn();
			}
		}

		public void PlayIn()
		{
			if (isOn)
			{
				return;
			}
			base.gameObject.SetActive(value: true);
			if (fitterMode && !isFitterInitialized)
			{
				cg.alpha = 0f;
				StartCoroutine("InitFitter");
				return;
			}
			if (animationMode == AnimationMode.Scale && cg != null)
			{
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine("ScaleIn");
				}
				else
				{
					cg.alpha = 1f;
					rect.localScale = new Vector3(1f, 1f, 1f);
				}
			}
			else if (animationMode == AnimationMode.Horizontal && cg != null)
			{
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine("HorizontalIn");
				}
				else
				{
					cg.alpha = 1f;
				}
			}
			else if (animationMode == AnimationMode.Vertical && cg != null)
			{
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine("VerticalIn");
				}
				else
				{
					cg.alpha = 1f;
				}
			}
			isOn = true;
			onEnable.Invoke();
		}

		public void PlayOut()
		{
			if (!isOn)
			{
				return;
			}
			if (instantOut)
			{
				base.gameObject.SetActive(value: false);
				isOn = false;
				return;
			}
			if (animationMode == AnimationMode.Scale && cg != null)
			{
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine("ScaleOut");
				}
				else
				{
					cg.alpha = 0f;
					rect.localScale = new Vector3(0f, 0f, 0f);
					base.gameObject.SetActive(value: false);
				}
			}
			else if (animationMode == AnimationMode.Horizontal && cg != null)
			{
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine("HorizontalOut");
				}
				else
				{
					cg.alpha = 0f;
					base.gameObject.SetActive(value: false);
				}
			}
			else if (animationMode == AnimationMode.Vertical && cg != null)
			{
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine("VerticalOut");
				}
				else
				{
					cg.alpha = 0f;
					base.gameObject.SetActive(value: false);
				}
			}
			isOn = false;
			onDisable.Invoke();
		}

		private IEnumerator InitFitter()
		{
			if (updateMode == UpdateMode.UnscaledTime)
			{
				yield return new WaitForSecondsRealtime(0.04f);
			}
			else
			{
				yield return new WaitForSeconds(0.04f);
			}
			GetComponent<ContentSizeFitter>().enabled = false;
			rectHelper = rect.sizeDelta;
			isFitterInitialized = true;
			PlayIn();
		}

		private IEnumerator ScaleIn()
		{
			StopCoroutine("ScaleOut");
			float elapsedTime = 0f;
			float startingPoint = 0f;
			rect.localScale = new Vector3(0f, 0f, 0f);
			cg.alpha = 0f;
			while ((double)rect.localScale.x < 0.99)
			{
				elapsedTime = ((updateMode != UpdateMode.UnscaledTime) ? (elapsedTime + Time.deltaTime) : (elapsedTime + Time.unscaledDeltaTime));
				float num = Mathf.Lerp(startingPoint, 1f, animationCurve.Evaluate(elapsedTime * curveSpeed));
				rect.localScale = new Vector3(num, num, num);
				cg.alpha = num;
				yield return null;
			}
			cg.alpha = 1f;
			rect.localScale = new Vector3(1f, 1f, 1f);
			onVisible.Invoke();
		}

		private IEnumerator ScaleOut()
		{
			StopCoroutine("ScaleIn");
			float elapsedTime = 0f;
			float startingPoint = 1f;
			rect.localScale = new Vector3(1f, 1f, 1f);
			cg.alpha = 1f;
			while ((double)rect.localScale.x > 0.01)
			{
				elapsedTime = ((updateMode != UpdateMode.UnscaledTime) ? (elapsedTime + Time.deltaTime) : (elapsedTime + Time.unscaledDeltaTime));
				float num = Mathf.Lerp(startingPoint, 0f, animationCurve.Evaluate(elapsedTime * curveSpeed));
				rect.localScale = new Vector3(num, num, num);
				cg.alpha = num;
				yield return null;
			}
			cg.alpha = 0f;
			rect.localScale = new Vector3(0f, 0f, 0f);
			base.gameObject.SetActive(value: false);
		}

		private IEnumerator HorizontalIn()
		{
			StopCoroutine("HorizontalOut");
			float elapsedTime = 0f;
			Vector2 startPos = new Vector2(0f, rect.sizeDelta.y);
			Vector2 endPos = rectHelper;
			if (!fitterMode && startBehaviour == StartBehaviour.Default)
			{
				endPos = rect.sizeDelta;
			}
			else if (fitterMode && startBehaviour == StartBehaviour.Default)
			{
				endPos = rectHelper;
			}
			rect.sizeDelta = startPos;
			while (rect.sizeDelta.x <= endPos.x - 0.1f)
			{
				if (updateMode == UpdateMode.UnscaledTime)
				{
					elapsedTime += Time.unscaledDeltaTime;
					cg.alpha += Time.unscaledDeltaTime * (curveSpeed * 2f);
				}
				else
				{
					elapsedTime += Time.deltaTime;
					cg.alpha += Time.deltaTime * (curveSpeed * 2f);
				}
				rect.sizeDelta = Vector2.Lerp(startPos, endPos, animationCurve.Evaluate(elapsedTime * curveSpeed));
				yield return null;
			}
			cg.alpha = 1f;
			rect.sizeDelta = endPos;
			onVisible.Invoke();
		}

		private IEnumerator HorizontalOut()
		{
			StopCoroutine("HorizontalIn");
			float elapsedTime = 0f;
			Vector2 startPos = rect.sizeDelta;
			Vector2 endPos = new Vector2(0f, rect.sizeDelta.y);
			while (rect.sizeDelta.x >= 0.1f)
			{
				if (updateMode == UpdateMode.UnscaledTime)
				{
					elapsedTime += Time.unscaledDeltaTime;
					cg.alpha -= Time.unscaledDeltaTime * (curveSpeed * 2f);
				}
				else
				{
					elapsedTime += Time.deltaTime;
					cg.alpha -= Time.deltaTime * (curveSpeed * 2f);
				}
				rect.sizeDelta = Vector2.Lerp(startPos, endPos, animationCurve.Evaluate(elapsedTime * curveSpeed));
				yield return null;
			}
			cg.alpha = 0f;
			rect.sizeDelta = endPos;
			rect.gameObject.SetActive(value: false);
		}

		private IEnumerator VerticalIn()
		{
			StopCoroutine("VerticalOut");
			float elapsedTime = 0f;
			Vector2 startPos = new Vector2(rect.sizeDelta.x, 0f);
			Vector2 endPos = rectHelper;
			if (!fitterMode && startBehaviour == StartBehaviour.Default)
			{
				endPos = rect.sizeDelta;
			}
			else if (fitterMode && startBehaviour == StartBehaviour.Default)
			{
				endPos = rectHelper;
			}
			rect.sizeDelta = startPos;
			while (rect.sizeDelta.y <= endPos.y - 0.1f)
			{
				if (updateMode == UpdateMode.UnscaledTime)
				{
					elapsedTime += Time.unscaledDeltaTime;
					cg.alpha += Time.unscaledDeltaTime * (curveSpeed * 2f);
				}
				else
				{
					elapsedTime += Time.deltaTime;
					cg.alpha += Time.deltaTime * (curveSpeed * 2f);
				}
				rect.sizeDelta = Vector2.Lerp(startPos, endPos, animationCurve.Evaluate(elapsedTime * curveSpeed));
				yield return null;
			}
			cg.alpha = 1f;
			rect.sizeDelta = endPos;
			onVisible.Invoke();
		}

		private IEnumerator VerticalOut()
		{
			StopCoroutine("VerticalIn");
			float elapsedTime = 0f;
			Vector2 startPos = rect.sizeDelta;
			Vector2 endPos = new Vector2(rect.sizeDelta.x, 0f);
			while (rect.sizeDelta.y >= 0.1f)
			{
				if (updateMode == UpdateMode.UnscaledTime)
				{
					elapsedTime += Time.unscaledDeltaTime;
					cg.alpha -= Time.unscaledDeltaTime * (curveSpeed * 2f);
				}
				else
				{
					elapsedTime += Time.deltaTime;
					cg.alpha -= Time.deltaTime * (curveSpeed * 2f);
				}
				rect.sizeDelta = Vector2.Lerp(startPos, endPos, animationCurve.Evaluate(elapsedTime * curveSpeed));
				yield return null;
			}
			cg.alpha = 0f;
			rect.sizeDelta = endPos;
			rect.gameObject.SetActive(value: false);
		}
	}
}
