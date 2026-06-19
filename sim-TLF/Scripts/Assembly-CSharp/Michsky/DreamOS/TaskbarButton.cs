using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[RequireComponent(typeof(Animator))]
	public class TaskbarButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler
	{
		[SerializeField]
		private enum DefaultPinState
		{
			Pinned = 0,
			Unpinned = 1
		}

		public Animator buttonAnimator;

		[HideInInspector]
		public WindowManager windowManager;

		public List<AppElement> appElements = new List<AppElement>();

		public string buttonTitle = "App Window";

		[SerializeField]
		private DefaultPinState defaultPinState;

		public Animator contextMenu;

		public UIBlur contextBlur;

		public ButtonManager headerButton;

		public ButtonManager closeButton;

		public ButtonManager pinButton;

		public ButtonManager unpinButton;

		private bool isContextOn;

		public UnityEvent onClick = new UnityEvent();

		private bool initialized;

		private bool isDragging;

		private float cachedButtonLength = 0.5f;

		private float cachedContextMenuLength = 0.5f;

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.Apps;

		[HideInInspector]
		public bool isPinned;

		private void OnEnable()
		{
			if (initialized && isPinned)
			{
				buttonAnimator.Play("Start Draw");
			}
			else if (initialized && !isPinned)
			{
				buttonAnimator.Play("Start Hide");
			}
			StartCoroutine("DisableAnimator");
		}

		public void InitializeButton()
		{
			if (base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
			if (buttonAnimator == null)
			{
				buttonAnimator = base.gameObject.GetComponent<Animator>();
			}
			if (defaultPinState == DefaultPinState.Pinned && !DreamOSDataManager.ContainsJsonKey(dataCat, buttonTitle + "_TaskbarShortcut"))
			{
				DreamOSDataManager.WriteBooleanData(dataCat, buttonTitle + "_TaskbarShortcut", value: true);
			}
			if (DreamOSDataManager.ReadBooleanData(dataCat, buttonTitle + "_TaskbarShortcut"))
			{
				isPinned = true;
			}
			else
			{
				isPinned = false;
			}
			for (int i = 0; i < appElements.Count; i++)
			{
				if (!(appElements[i] == null))
				{
					appElements[i].appID = buttonTitle;
					appElements[i].UpdateLibrary();
					appElements[i].UpdateElement();
				}
			}
			if (headerButton != null)
			{
				headerButton.onClick.AddListener(delegate
				{
					windowManager.OpenWindow();
					AnimateContextMenu();
				});
			}
			if (closeButton != null)
			{
				closeButton.gameObject.SetActive(value: false);
				closeButton.onClick.AddListener(delegate
				{
					windowManager.CloseWindow();
					AnimateContextMenu();
				});
			}
			if (pinButton != null && unpinButton != null)
			{
				if (!isPinned)
				{
					pinButton.gameObject.SetActive(value: true);
					unpinButton.gameObject.SetActive(value: false);
				}
				else
				{
					pinButton.gameObject.SetActive(value: false);
					unpinButton.gameObject.SetActive(value: true);
				}
				pinButton.onClick.AddListener(delegate
				{
					PinTaskBarButton();
				});
				unpinButton.onClick.AddListener(delegate
				{
					PinTaskBarButton();
				});
			}
			onClick.AddListener(delegate
			{
				windowManager.OpenWindow();
			});
			cachedButtonLength = DreamOSInternalTools.GetAnimatorClipLength(buttonAnimator, "TaskbarButton_HideToActive") + 0.1f;
			cachedContextMenuLength = DreamOSInternalTools.GetAnimatorClipLength(contextMenu, "ContextMenu_In") + 0.1f;
			initialized = true;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			isDragging = true;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			isDragging = false;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!isDragging && !(windowManager == null))
			{
				if (eventData.button == PointerEventData.InputButton.Right)
				{
					AnimateContextMenu();
				}
				else if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Active to Highlighted") && windowManager.transform.GetSiblingIndex() != windowManager.transform.parent.childCount - 1)
				{
					windowManager.FocusToWindow();
					buttonAnimator.Play("Inactive to Active");
				}
				else if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Active to Highlighted") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Closed to Active") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Inactive to Active") || (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Highlighted to Active") && windowManager.transform.GetSiblingIndex() == windowManager.transform.parent.childCount - 1))
				{
					windowManager.MinimizeWindow();
					buttonAnimator.Play("Active to Inactive");
				}
				else if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Inactive to Highlighted") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Highlighted to Inactive") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Active to Inactive"))
				{
					onClick.Invoke();
					windowManager.FocusToWindow();
					buttonAnimator.Play("Highlighted to Active");
				}
				else if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hide"))
				{
					onClick.Invoke();
					windowManager.FocusToWindow();
					buttonAnimator.Play("Hide to Active");
				}
				else
				{
					onClick.Invoke();
					windowManager.FocusToWindow();
					buttonAnimator.Play("Closed to Active");
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			StopCoroutine("DisableAnimator");
			buttonAnimator.enabled = true;
			if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Highlighted to Closed") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Active to Closed"))
			{
				buttonAnimator.Play("Closed to Highlighted");
			}
			else if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Highlighted to Active") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Closed to Active") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Inactive to Active") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hide to Active"))
			{
				buttonAnimator.Play("Active to Highlighted");
			}
			else if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Active to Inactive") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Highlighted to Inactive"))
			{
				buttonAnimator.Play("Inactive to Highlighted");
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Closed to Highlighted"))
			{
				buttonAnimator.Play("Highlighted to Closed");
			}
			else if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Active to Highlighted"))
			{
				buttonAnimator.Play("Highlighted to Active");
			}
			else if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Inactive to Highlighted"))
			{
				buttonAnimator.Play("Highlighted to Inactive");
			}
			StartCoroutine("DisableAnimator");
		}

		public void SetOpen()
		{
			buttonAnimator.enabled = true;
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
			if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Inactive to Highlighted") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Active to Highlighted"))
			{
				buttonAnimator.Play("Highlighted to Active");
			}
			else if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Start Hide") || buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hide"))
			{
				buttonAnimator.Play("Hide to Active");
			}
			else
			{
				buttonAnimator.Play("Closed to Active");
			}
		}

		public void SetClosed()
		{
			buttonAnimator.enabled = true;
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
			if (DreamOSDataManager.ContainsJsonKey(dataCat, buttonTitle + "_TaskbarShortcut") && DreamOSDataManager.ReadBooleanData(dataCat, buttonTitle + "_TaskbarShortcut"))
			{
				buttonAnimator.Play("Active to Closed");
			}
			else
			{
				buttonAnimator.Play("Hide");
			}
		}

		public void SetMinimized()
		{
			buttonAnimator.enabled = true;
			buttonAnimator.Play("Active to Inactive");
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
		}

		public void PinTaskBarButton()
		{
			if (!isPinned)
			{
				isPinned = true;
				DreamOSDataManager.WriteBooleanData(dataCat, buttonTitle + "_TaskbarShortcut", value: true);
				if (pinButton != null && unpinButton != null)
				{
					pinButton.gameObject.SetActive(value: false);
					unpinButton.gameObject.SetActive(value: true);
				}
			}
			else
			{
				if (!windowManager.isOn)
				{
					buttonAnimator.Play("Hide");
				}
				if (pinButton != null && unpinButton != null)
				{
					pinButton.gameObject.SetActive(value: true);
					unpinButton.gameObject.SetActive(value: false);
				}
				DreamOSDataManager.WriteBooleanData(dataCat, buttonTitle + "_TaskbarShortcut", value: false);
				isPinned = false;
			}
			AnimateContextMenu();
		}

		public void AnimateContextMenu()
		{
			if (isContextOn)
			{
				isContextOn = false;
				contextMenu.Play("Out");
				StopCoroutine("DisableContextMenu");
				StartCoroutine("DisableContextMenu");
				if (contextBlur != null)
				{
					contextBlur.BlurOutAnim();
				}
			}
			else if (!isContextOn)
			{
				contextMenu.gameObject.SetActive(value: true);
				isContextOn = true;
				contextMenu.Play("In");
				StopCoroutine("DisableContextMenu");
				if (contextBlur != null)
				{
					contextBlur.BlurInAnim();
				}
				if (windowManager.isOn && closeButton != null)
				{
					closeButton.gameObject.SetActive(value: true);
				}
				else if (closeButton != null)
				{
					closeButton.gameObject.SetActive(value: false);
				}
			}
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(cachedButtonLength);
			buttonAnimator.enabled = false;
		}

		private IEnumerator DisableContextMenu()
		{
			yield return new WaitForSeconds(cachedContextMenuLength);
			contextMenu.gameObject.SetActive(value: false);
		}
	}
}
