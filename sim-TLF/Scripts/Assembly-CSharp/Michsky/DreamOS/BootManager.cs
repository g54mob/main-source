using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class BootManager : MonoBehaviour
	{
		public Animator bootAnimator;

		[SerializeField]
		private UserManager userManager;

		[SerializeField]
		private Canvas targetCanvas;

		public bool bootOnEnable = true;

		[SerializeField]
		private bool fadeFrameSkip;

		[Range(0f, 30f)]
		public float bootTime = 4f;

		[Range(0f, 5f)]
		public float initTime = 0.5f;

		[Range(0.5f, 12f)]
		public float fadeSpeed = 1.5f;

		public UnityEvent onBootStart = new UnityEvent();

		public UnityEvent onBootEnd = new UnityEvent();

		public UnityEvent onRebootStart = new UnityEvent();

		public UnityEvent onRebootEnd = new UnityEvent();

		public UnityEvent onShutdownEnd = new UnityEvent();

		private float cachedStartLength = 2f;

		private float cachedOutLength = 0.5f;

		private bool isRebootInProgress;

		private bool isShutdownInProgress;

		private void Awake()
		{
			if (targetCanvas == null)
			{
				targetCanvas = GetComponentInParent<Canvas>();
			}
			if (bootAnimator != null)
			{
				cachedStartLength = DreamOSInternalTools.GetAnimatorClipLength(bootAnimator, "BootScreen_Start") + 0.1f;
			}
			if (bootAnimator != null)
			{
				cachedOutLength = DreamOSInternalTools.GetAnimatorClipLength(bootAnimator, "BootScreen_Out") + 0.1f;
			}
		}

		private void OnEnable()
		{
			if (bootOnEnable)
			{
				Boot();
			}
		}

		private void OnDisable()
		{
			if (bootAnimator != null)
			{
				bootAnimator.gameObject.SetActive(value: false);
			}
		}

		public void Boot()
		{
			if (bootAnimator.gameObject.activeInHierarchy)
			{
				return;
			}
			if (userManager == null)
			{
				Debug.LogError("<b>[Boot Manager]</b> User Manager is missing, but it's an essential variable for boot to work.", this);
				return;
			}
			userManager.setupScreen.gameObject.SetActive(value: false);
			userManager.lockScreen.gameObject.SetActive(value: true);
			userManager.desktopScreen.gameObject.SetActive(value: true);
			if (userManager.desktopScreen.gameObject.activeInHierarchy)
			{
				userManager.desktopScreen.Play("Instant Out");
			}
			Invoke("BootHelper", initTime);
			onBootStart.Invoke();
		}

		private void BootHelper()
		{
			if (base.gameObject.activeInHierarchy)
			{
				userManager.lockScreen.gameObject.SetActive(value: false);
				userManager.desktopScreen.gameObject.SetActive(value: false);
				bootAnimator.gameObject.SetActive(value: true);
				bootAnimator.enabled = true;
				bootAnimator.Play("Start");
				StopCoroutine("StartBootProcess");
				StartCoroutine("StartBootProcess");
			}
		}

		public void Reboot()
		{
			if (!isRebootInProgress)
			{
				UnityEvent unityEvent = new UnityEvent();
				unityEvent.AddListener(delegate
				{
					onRebootEnd.Invoke();
					isRebootInProgress = false;
					targetCanvas.gameObject.SetActive(value: false);
					targetCanvas.gameObject.SetActive(value: true);
				});
				DoFadeInAnimation(unityEvent);
				isRebootInProgress = true;
				onRebootStart.Invoke();
			}
		}

		public void Shutdown()
		{
			if (!isShutdownInProgress)
			{
				UnityEvent unityEvent = new UnityEvent();
				unityEvent.AddListener(delegate
				{
					isShutdownInProgress = false;
					targetCanvas.gameObject.SetActive(value: false);
					onShutdownEnd?.Invoke();
				});
				DoFadeInAnimation(unityEvent);
				isShutdownInProgress = true;
			}
		}

		private void DoFadeInAnimation(UnityEvent externalEvents)
		{
			GameObject animObj = new GameObject();
			animObj.name = "Boot Fade Animation (Temp)";
			animObj.transform.SetParent(targetCanvas.transform, worldPositionStays: false);
			animObj.transform.SetAsLastSibling();
			animObj.AddComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
			RectTransform component = animObj.gameObject.GetComponent<RectTransform>();
			component.anchorMin = new Vector2(0f, 0f);
			component.anchorMax = new Vector2(1f, 1f);
			component.offsetMin = new Vector2(0f, 0f);
			component.offsetMax = new Vector2(0f, 0f);
			ImageFading imageFading = animObj.AddComponent<ImageFading>();
			imageFading.frameSkip = fadeFrameSkip;
			imageFading.onFadeInEnd.AddListener(delegate
			{
				externalEvents.Invoke();
				Object.Destroy(animObj);
			});
			imageFading.fadeSpeed = fadeSpeed;
			imageFading.FadeIn();
		}

		private IEnumerator StartBootProcess()
		{
			yield return new WaitForSeconds(bootTime);
			if (bootTime != 0f)
			{
				bootAnimator.Play("Out");
			}
			else
			{
				bootAnimator.Play("Disabled");
			}
			onBootEnd.Invoke();
			if (userManager.userCreated)
			{
				userManager.setupScreen.gameObject.SetActive(value: false);
				userManager.OpenLockScreen();
			}
			else
			{
				userManager.setupScreen.gameObject.SetActive(value: true);
			}
			StartCoroutine("DisableBootScreen");
		}

		private IEnumerator DisableBootScreenAnimator()
		{
			yield return new WaitForSeconds(cachedStartLength);
			bootAnimator.enabled = false;
		}

		private IEnumerator DisableBootScreen()
		{
			yield return new WaitForSeconds(cachedOutLength);
			bootAnimator.gameObject.SetActive(value: false);
		}
	}
}
