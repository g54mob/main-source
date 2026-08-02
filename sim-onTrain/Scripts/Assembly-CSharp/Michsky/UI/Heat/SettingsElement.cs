using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[DisallowMultipleComponent]
	public class SettingsElement : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
	{
		[SerializeField]
		private CanvasGroup highlightCG;

		public bool isInteractable = true;

		public bool useSounds = true;

		[Range(1f, 15f)]
		public float fadingMultiplier = 8f;

		public bool useUINavigation;

		public Navigation.Mode navigationMode = Navigation.Mode.Automatic;

		public GameObject selectOnUp;

		public GameObject selectOnDown;

		public GameObject selectOnLeft;

		public GameObject selectOnRight;

		public bool wrapAround;

		public UnityEvent onClick = new UnityEvent();

		public UnityEvent onHover = new UnityEvent();

		public UnityEvent onLeave = new UnityEvent();

		private Button targetButton;

		private void Start()
		{
			if (ControllerManager.instance != null)
			{
				ControllerManager.instance.settingsElements.Add(this);
			}
			if (highlightCG == null)
			{
				highlightCG = new GameObject().AddComponent<CanvasGroup>();
				highlightCG.gameObject.AddComponent<RectTransform>();
				highlightCG.transform.SetParent(base.transform);
				highlightCG.gameObject.name = "Highlight";
			}
			if (GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
		}

		private void OnEnable()
		{
			if (highlightCG != null)
			{
				highlightCG.alpha = 0f;
			}
			if (Application.isPlaying && useUINavigation)
			{
				AddUINavigation();
			}
			else if (Application.isPlaying && !useUINavigation && targetButton == null)
			{
				if (base.gameObject.GetComponent<Button>() == null)
				{
					targetButton = base.gameObject.AddComponent<Button>();
				}
				else
				{
					targetButton = GetComponent<Button>();
				}
				targetButton.transition = Selectable.Transition.None;
			}
		}

		public void Interactable(bool value)
		{
			isInteractable = value;
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine("SetNormal");
			}
		}

		public void AddUINavigation()
		{
			if (targetButton == null)
			{
				if (base.gameObject.GetComponent<Button>() == null)
				{
					targetButton = base.gameObject.AddComponent<Button>();
				}
				else
				{
					targetButton = GetComponent<Button>();
				}
				targetButton.transition = Selectable.Transition.None;
			}
			if (targetButton.navigation.mode != navigationMode)
			{
				Navigation navigation = new Navigation
				{
					mode = navigationMode
				};
				if (navigationMode == Navigation.Mode.Vertical || navigationMode == Navigation.Mode.Horizontal)
				{
					navigation.wrapAround = wrapAround;
				}
				else if (navigationMode == Navigation.Mode.Explicit)
				{
					StartCoroutine("InitUINavigation", navigation);
					return;
				}
				targetButton.navigation = navigation;
			}
		}

		public void DisableUINavigation()
		{
			if (targetButton != null)
			{
				Navigation navigation = default(Navigation);
				Navigation.Mode mode = Navigation.Mode.None;
				navigation.mode = mode;
				targetButton.navigation = navigation;
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (isInteractable && eventData.button == PointerEventData.InputButton.Left)
			{
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
				}
				onClick.Invoke();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (isInteractable)
			{
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
				}
				onHover.Invoke();
				StartCoroutine("SetHighlight");
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (isInteractable)
			{
				onLeave.Invoke();
				StartCoroutine("SetNormal");
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (isInteractable)
			{
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
				}
				onHover.Invoke();
				StartCoroutine("SetHighlight");
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (isInteractable && !(highlightCG == null))
			{
				onLeave.Invoke();
				StartCoroutine("SetNormal");
			}
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (isInteractable)
			{
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
				}
				onClick.Invoke();
			}
		}

		private IEnumerator SetNormal()
		{
			StopCoroutine("SetHighlight");
			while (highlightCG.alpha > 0.01f)
			{
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			highlightCG.alpha = 0f;
		}

		private IEnumerator SetHighlight()
		{
			StopCoroutine("SetNormal");
			while (highlightCG.alpha < 0.99f)
			{
				highlightCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			highlightCG.alpha = 1f;
		}

		private IEnumerator InitUINavigation(Navigation nav)
		{
			yield return new WaitForSecondsRealtime(0.1f);
			if (selectOnUp != null)
			{
				nav.selectOnUp = selectOnUp.GetComponent<Selectable>();
			}
			if (selectOnDown != null)
			{
				nav.selectOnDown = selectOnDown.GetComponent<Selectable>();
			}
			if (selectOnLeft != null)
			{
				nav.selectOnLeft = selectOnLeft.GetComponent<Selectable>();
			}
			if (selectOnRight != null)
			{
				nav.selectOnRight = selectOnRight.GetComponent<Selectable>();
			}
			targetButton.navigation = nav;
		}
	}
}
