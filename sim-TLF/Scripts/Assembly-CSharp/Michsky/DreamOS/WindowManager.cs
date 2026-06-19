using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Michsky.DreamOS
{
	[RequireComponent(typeof(CanvasGroup))]
	public class WindowManager : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public enum DefaultState
		{
			Minimized = 0,
			Expanded = 1
		}

		public enum ResizeAnchor
		{
			Disabled = 0,
			BottomLeft = 1,
			BottomRight = 2
		}

		public Animator windowAnimator;

		public RectTransform windowContainer;

		public RectTransform windowContent;

		public RectTransform navbarRect;

		public TaskbarButton taskbarButton;

		public WindowDragger windowDragger;

		[SerializeField]
		private GameObject resizePreset;

		public GameObject fullscreenImage;

		public GameObject normalizeImage;

		[SerializeField]
		private bool disableAtStart = true;

		[SerializeField]
		private bool enableMobileMode;

		public bool allowGestures = true;

		public bool useBackgroundBlur = true;

		[SerializeField]
		private bool hasNavDrawer = true;

		public float minNavbarWidth = 75f;

		public float maxNavbarWidth = 300f;

		[Range(0f, 10f)]
		public float navbarCurveSpeed = 4f;

		[SerializeField]
		private AnimationCurve navbarCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public DefaultState defaultNavbarState;

		public ResizeAnchor resizeAnchor = ResizeAnchor.BottomRight;

		[Range(25f, 100f)]
		public int minWindowSize = 50;

		public UnityEvent onOpen = new UnityEvent();

		public UnityEvent onClose = new UnityEvent();

		public UnityEvent onMinimize = new UnityEvent();

		public UnityEvent onFullscreen = new UnityEvent();

		private float left;

		private float right;

		private float top;

		private float bottom;

		private float cachedStateLength = 1f;

		private bool isNavbarOpen = true;

		private UIBlur windowBGBlur;

		private RectTransform windowRect;

		private WindowResizeAnchor cachedResizeAnchor;

		[HideInInspector]
		public bool isOn;

		[HideInInspector]
		public bool isNormalized;

		[HideInInspector]
		public bool isFullscreen;

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.Apps;

		private void Awake()
		{
			if (windowAnimator == null)
			{
				windowAnimator = base.gameObject.GetComponent<Animator>();
			}
			cachedStateLength = DreamOSInternalTools.GetAnimatorClipLength(windowAnimator, "Window_In") + 0.1f;
			InitializeWindow();
		}

		private void Start()
		{
			if (disableAtStart)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void OnEnable()
		{
			if (enableMobileMode || !hasNavDrawer)
			{
				return;
			}
			if (navbarRect == null || windowContent == null)
			{
				Debug.LogError("<b>[Window Manager]</b> Navbar is enabled but its resources are missing!");
				return;
			}
			if (!DreamOSDataManager.ContainsJsonKey(dataCat, base.gameObject.name + "_NavDrawer"))
			{
				if (defaultNavbarState == DefaultState.Expanded)
				{
					DreamOSDataManager.WriteBooleanData(dataCat, base.gameObject.name + "_NavDrawer", value: true);
				}
				else
				{
					DreamOSDataManager.WriteBooleanData(dataCat, base.gameObject.name + "_NavDrawer", value: false);
				}
			}
			else if (DreamOSDataManager.ReadBooleanData(dataCat, base.gameObject.name + "_NavDrawer"))
			{
				defaultNavbarState = DefaultState.Expanded;
				isNavbarOpen = true;
			}
			else if (!DreamOSDataManager.ReadBooleanData(dataCat, base.gameObject.name + "_NavDrawer"))
			{
				defaultNavbarState = DefaultState.Minimized;
				isNavbarOpen = false;
			}
			if (defaultNavbarState == DefaultState.Minimized)
			{
				navbarRect.sizeDelta = new Vector2(minNavbarWidth, navbarRect.sizeDelta.y);
				windowContent.offsetMin = new Vector2(minNavbarWidth, windowContent.offsetMin.y);
			}
			else if (defaultNavbarState == DefaultState.Expanded)
			{
				navbarRect.sizeDelta = new Vector2(maxNavbarWidth, navbarRect.sizeDelta.y);
				windowContent.offsetMin = new Vector2(maxNavbarWidth, windowContent.offsetMin.y);
			}
		}

		private void OnDisable()
		{
			if (base.gameObject.activeInHierarchy || isOn)
			{
				CloseWindow();
				base.gameObject.SetActive(value: false);
			}
		}

		public void InitializeWindow()
		{
			if (!enableMobileMode)
			{
				if (taskbarButton != null)
				{
					taskbarButton.windowManager = this;
					taskbarButton.InitializeButton();
				}
				if (useBackgroundBlur)
				{
					windowBGBlur = base.gameObject.GetComponent<UIBlur>();
				}
				if (windowDragger != null)
				{
					windowDragger.wManager = this;
				}
				windowRect = base.gameObject.GetComponent<RectTransform>();
				left = windowRect.offsetMin.x;
				right = 0f - windowRect.offsetMax.x;
				top = 0f - windowRect.offsetMax.y;
				bottom = windowRect.offsetMin.y;
				if (fullscreenImage != null && normalizeImage != null)
				{
					fullscreenImage.SetActive(value: true);
					normalizeImage.SetActive(value: false);
				}
				InitializeResizePreset();
			}
		}

		public void AnimateNavbar()
		{
			if (!(navbarRect == null) && !(windowContent == null))
			{
				StopCoroutine("DoNavbarExpand");
				StopCoroutine("DoNavbarMinimize");
				StopCoroutine("DoContentExpand");
				StopCoroutine("DoContentMinimize");
				if (isNavbarOpen)
				{
					StartCoroutine("DoNavbarMinimize");
					StartCoroutine("DoContentMinimize");
					DreamOSDataManager.WriteBooleanData(dataCat, base.gameObject.name + "_NavDrawer", value: false);
					defaultNavbarState = DefaultState.Minimized;
					isNavbarOpen = false;
				}
				else
				{
					StartCoroutine("DoNavbarExpand");
					StartCoroutine("DoContentExpand");
					DreamOSDataManager.WriteBooleanData(dataCat, base.gameObject.name + "_NavDrawer", value: true);
					defaultNavbarState = DefaultState.Expanded;
					isNavbarOpen = true;
				}
			}
		}

		public void OpenWindow()
		{
			FocusToWindow();
			isOn = true;
			base.gameObject.SetActive(value: true);
			onOpen.Invoke();
			if (!enableMobileMode)
			{
				windowAnimator.enabled = true;
				if (!windowAnimator.GetCurrentAnimatorStateInfo(0).IsName("Fullscreen") && !windowAnimator.GetCurrentAnimatorStateInfo(0).IsName("Normalize"))
				{
					windowAnimator.Play("In");
				}
				if (taskbarButton != null && !enableMobileMode)
				{
					taskbarButton.SetOpen();
				}
				if (windowBGBlur != null)
				{
					windowBGBlur.BlurInAnim();
				}
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator", false);
			}
		}

		public void CloseWindow()
		{
			isOn = false;
			onClose.Invoke();
			if (!enableMobileMode)
			{
				if (useBackgroundBlur && windowBGBlur != null)
				{
					windowBGBlur.BlurOutAnim();
				}
				if (taskbarButton != null)
				{
					taskbarButton.SetClosed();
				}
				if (base.gameObject.activeInHierarchy)
				{
					windowAnimator.enabled = true;
					windowAnimator.Play("Out");
					StopCoroutine("DisableAnimator");
					StartCoroutine("DisableAnimator", true);
				}
			}
		}

		public void MinimizeWindow()
		{
			onMinimize.Invoke();
			windowAnimator.enabled = true;
			windowAnimator.Play("Minimize");
			if (taskbarButton != null)
			{
				taskbarButton.SetMinimized();
			}
			if (useBackgroundBlur && windowBGBlur != null)
			{
				windowBGBlur.BlurOutAnim();
			}
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator", false);
		}

		public void FullscreenWindow()
		{
			onFullscreen.Invoke();
			windowAnimator.enabled = true;
			if (!isFullscreen)
			{
				isFullscreen = true;
				isNormalized = false;
				if (fullscreenImage != null && normalizeImage != null)
				{
					fullscreenImage.SetActive(value: false);
					normalizeImage.SetActive(value: true);
				}
				StartCoroutine("SetFullscreen");
			}
			else
			{
				isFullscreen = false;
				isNormalized = true;
				if (fullscreenImage != null && normalizeImage != null)
				{
					fullscreenImage.SetActive(value: true);
					normalizeImage.SetActive(value: false);
				}
				StartCoroutine("SetNormalized");
			}
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator", false);
		}

		public void InitializeResizePreset()
		{
			if (resizeAnchor != ResizeAnchor.Disabled && !(resizePreset == null) && !(windowContainer == null))
			{
				if (cachedResizeAnchor == null)
				{
					GameObject gameObject = Object.Instantiate(resizePreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
					gameObject.transform.SetParent(windowContainer, worldPositionStays: false);
					cachedResizeAnchor = gameObject.GetComponent<WindowResizeAnchor>();
					cachedResizeAnchor.targetRect = windowContainer;
				}
				cachedResizeAnchor.SetMinSize(minWindowSize);
				cachedResizeAnchor.SetAnchor(resizeAnchor);
			}
		}

		public void FocusToWindow()
		{
			base.gameObject.transform.SetAsLastSibling();
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			FocusToWindow();
		}

		public static void SetPivot(RectTransform rectTransform, Vector2 pivot)
		{
			Vector2 vector = pivot - rectTransform.pivot;
			vector.Scale(rectTransform.rect.size);
			Vector3 position = rectTransform.position + rectTransform.TransformVector(vector);
			rectTransform.pivot = pivot;
			rectTransform.position = position;
		}

		private IEnumerator DoNavbarExpand()
		{
			float elapsedTime = 0f;
			Vector2 startPos = navbarRect.sizeDelta;
			Vector2 endPos = new Vector2(maxNavbarWidth, navbarRect.sizeDelta.y);
			if (navbarCurveSpeed == 0f)
			{
				navbarRect.sizeDelta = endPos;
			}
			else
			{
				while (navbarRect.sizeDelta.x <= endPos.x - 0.1f)
				{
					elapsedTime += Time.deltaTime;
					navbarRect.sizeDelta = Vector2.Lerp(startPos, endPos, navbarCurve.Evaluate(elapsedTime * navbarCurveSpeed));
					yield return null;
				}
			}
			navbarRect.sizeDelta = endPos;
		}

		private IEnumerator DoNavbarMinimize()
		{
			float elapsedTime = 0f;
			Vector2 startPos = new Vector2(navbarRect.sizeDelta.x, navbarRect.sizeDelta.y);
			Vector2 endPos = new Vector2(minNavbarWidth, navbarRect.sizeDelta.y);
			if (navbarCurveSpeed == 0f)
			{
				navbarRect.sizeDelta = endPos;
			}
			else
			{
				while (navbarRect.sizeDelta.x >= endPos.x)
				{
					elapsedTime += Time.deltaTime;
					navbarRect.sizeDelta = Vector2.Lerp(startPos, endPos, navbarCurve.Evaluate(elapsedTime * navbarCurveSpeed));
					yield return null;
				}
			}
			navbarRect.sizeDelta = endPos;
		}

		private IEnumerator DoContentExpand()
		{
			float elapsedTime = 0f;
			Vector2 startPos = windowContent.offsetMin;
			Vector2 endPos = new Vector2(maxNavbarWidth, windowContent.offsetMin.y);
			if (navbarCurveSpeed == 0f)
			{
				windowContent.offsetMin = endPos;
			}
			else
			{
				while (windowContent.offsetMin.x < endPos.x - 0.1f)
				{
					windowContent.offsetMin = Vector2.Lerp(startPos, endPos, navbarCurve.Evaluate(elapsedTime * navbarCurveSpeed));
					elapsedTime += Time.deltaTime;
					yield return null;
				}
			}
			windowContent.offsetMin = endPos;
		}

		private IEnumerator DoContentMinimize()
		{
			float elapsedTime = 0f;
			Vector2 startPos = windowContent.offsetMin;
			Vector2 endPos = new Vector2(minNavbarWidth, windowContent.offsetMin.y);
			if (navbarCurveSpeed == 0f)
			{
				windowContent.offsetMin = endPos;
			}
			else
			{
				while (windowContent.offsetMin.x > endPos.x)
				{
					windowContent.offsetMin = Vector2.Lerp(startPos, endPos, navbarCurve.Evaluate(elapsedTime * navbarCurveSpeed));
					elapsedTime += Time.deltaTime;
					yield return null;
				}
			}
			windowContent.offsetMin = endPos;
		}

		private IEnumerator SetFullscreen()
		{
			left = windowContainer.offsetMin.x;
			right = 0f - windowContainer.offsetMax.x;
			top = 0f - windowContainer.offsetMax.y;
			bottom = windowContainer.offsetMin.y;
			windowAnimator.Play("Fullscreen");
			windowContainer.offsetMin = new Vector2(0f, 0f);
			windowContainer.offsetMax = new Vector2(0f, 0f);
			isFullscreen = true;
			isNormalized = false;
			if (cachedResizeAnchor != null)
			{
				cachedResizeAnchor.gameObject.SetActive(value: false);
			}
			yield return null;
		}

		private IEnumerator SetNormalized()
		{
			windowAnimator.Play("Normalize");
			windowContainer.offsetMin = new Vector2(left, bottom);
			windowContainer.offsetMax = new Vector2(0f - right, 0f - top);
			isFullscreen = false;
			isNormalized = true;
			if (cachedResizeAnchor != null)
			{
				cachedResizeAnchor.gameObject.SetActive(value: true);
			}
			yield return null;
		}

		private IEnumerator DisableAnimator(bool disableObject)
		{
			yield return new WaitForSeconds(cachedStateLength);
			windowAnimator.enabled = false;
			if (disableObject)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
