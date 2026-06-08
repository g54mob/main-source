using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class ButtonManagerIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
	{
		public Sprite buttonIcon;

		public UnityEvent clickEvent;

		public UnityEvent hoverEvent;

		public AudioClip hoverSound;

		public AudioClip clickSound;

		private Button buttonVar;

		public Image normalIcon;

		public Image highlightedIcon;

		public AudioSource soundSource;

		public GameObject rippleParent;

		public bool useCustomContent;

		public bool enableButtonSounds;

		public bool useHoverSound = true;

		public bool useClickSound = true;

		public bool useRipple = true;

		public Sprite rippleShape;

		public float speed = 1f;

		public float maxSize = 4f;

		public Color startColor = new Color(1f, 1f, 1f, 1f);

		public Color transitionColor = new Color(1f, 1f, 1f, 1f);

		public bool renderOnTop;

		public bool centered;

		private bool isPointerOn;

		private void Start()
		{
			if (buttonVar == null)
			{
				buttonVar = base.gameObject.GetComponent<Button>();
			}
			buttonVar.onClick.AddListener(delegate
			{
				clickEvent.Invoke();
			});
			if (enableButtonSounds && useClickSound)
			{
				buttonVar.onClick.AddListener(delegate
				{
					soundSource.PlayOneShot(clickSound);
				});
			}
			if (!useCustomContent)
			{
				UpdateUI();
			}
			if (useRipple && rippleParent != null)
			{
				rippleParent.SetActive(value: false);
			}
			else if (!useRipple && rippleParent != null)
			{
				Object.Destroy(rippleParent);
			}
		}

		public void UpdateUI()
		{
			normalIcon.sprite = buttonIcon;
			highlightedIcon.sprite = buttonIcon;
		}

		public void CreateRipple(Vector2 pos)
		{
			if (rippleParent != null)
			{
				GameObject gameObject = new GameObject();
				gameObject.AddComponent<Ripple>();
				gameObject.AddComponent<Image>();
				gameObject.GetComponent<Image>().sprite = rippleShape;
				gameObject.name = "Ripple";
				rippleParent.SetActive(value: true);
				gameObject.transform.SetParent(rippleParent.transform);
				if (renderOnTop)
				{
					rippleParent.transform.SetAsLastSibling();
				}
				else
				{
					rippleParent.transform.SetAsFirstSibling();
				}
				if (centered)
				{
					gameObject.transform.localPosition = new Vector2(0f, 0f);
				}
				else
				{
					gameObject.transform.position = pos;
				}
				gameObject.GetComponent<Ripple>().speed = speed;
				gameObject.GetComponent<Ripple>().maxSize = maxSize;
				gameObject.GetComponent<Ripple>().startColor = startColor;
				gameObject.GetComponent<Ripple>().transitionColor = transitionColor;
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (useRipple && isPointerOn)
			{
				CreateRipple(Input.mousePosition);
			}
			else if (!useRipple)
			{
				base.enabled = false;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (enableButtonSounds && useHoverSound && buttonVar.interactable)
			{
				soundSource.PlayOneShot(hoverSound);
			}
			hoverEvent.Invoke();
			isPointerOn = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isPointerOn = false;
		}

		private void _003CStart_003Eb__23_0()
		{
			clickEvent.Invoke();
		}

		private void _003CStart_003Eb__23_1()
		{
			soundSource.PlayOneShot(clickSound);
		}
	}
}
