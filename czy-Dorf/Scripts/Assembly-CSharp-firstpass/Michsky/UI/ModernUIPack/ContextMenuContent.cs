using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class ContextMenuContent : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[Serializable]
		public class ContextItem
		{
			public string itemText;

			public Sprite itemIcon;

			public ContextItemType contextItemType;

			public UnityEvent onClickEvents;
		}

		public enum ContextItemType
		{
			BUTTON = 0
		}

		private sealed class _003CExecuteAfterTime_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float time;

			public ContextMenuContent _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CExecuteAfterTime_003Ed__13(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				ContextMenuContent contextMenuContent = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E2__current = new WaitForSeconds(time);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					contextMenuContent.itemParent.gameObject.SetActive(value: false);
					contextMenuContent.itemParent.gameObject.SetActive(value: true);
					contextMenuContent.StopCoroutine(contextMenuContent.ExecuteAfterTime(0.01f));
					contextMenuContent.StopCoroutine("ExecuteAfterTime");
					return false;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		public ContextMenuManager contextManager;

		public Transform itemParent;

		public List<ContextItem> contexItems = new List<ContextItem>();

		private Animator contextAnimator;

		private GameObject selectedItem;

		private Image setItemImage;

		private TextMeshProUGUI setItemText;

		private Sprite imageHelper;

		private string textHelper;

		private void Start()
		{
			if (contextManager == null)
			{
				try
				{
					contextManager = GameObject.Find("Context Menu").GetComponent<ContextMenuManager>();
					contextAnimator = contextManager.contextAnimator;
					itemParent = contextManager.transform.Find("Content/Item List").transform;
				}
				catch
				{
					Debug.Log("Context Menu - No variable attached to Context Manager.", this);
				}
			}
			foreach (Transform item in itemParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (contextManager.isContextMenuOn)
			{
				contextAnimator.Play("Menu Out");
				contextManager.isContextMenuOn = false;
			}
			else
			{
				if (eventData.button != PointerEventData.InputButton.Right || contextManager.isContextMenuOn)
				{
					return;
				}
				foreach (Transform item in itemParent)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
				for (int i = 0; i < contexItems.Count; i++)
				{
					if (contexItems[i].contextItemType == ContextItemType.BUTTON)
					{
						selectedItem = contextManager.contextButton;
					}
					GameObject gameObject = UnityEngine.Object.Instantiate(selectedItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
					gameObject.transform.SetParent(itemParent, worldPositionStays: false);
					setItemText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
					textHelper = contexItems[i].itemText;
					setItemText.text = textHelper;
					Transform transform = gameObject.gameObject.transform.Find("Icon");
					setItemImage = transform.GetComponent<Image>();
					imageHelper = contexItems[i].itemIcon;
					setItemImage.sprite = imageHelper;
					Button component = gameObject.GetComponent<Button>();
					component.onClick.AddListener(contexItems[i].onClickEvents.Invoke);
					component.onClick.AddListener(CloseOnClick);
					StartCoroutine(ExecuteAfterTime(0.01f));
				}
				contextManager.SetContextMenuPosition();
				contextAnimator.Play("Menu In");
				contextManager.isContextMenuOn = true;
				contextManager.SetContextMenuPosition();
			}
		}

		private IEnumerator ExecuteAfterTime(float time)
		{
			return new _003CExecuteAfterTime_003Ed__13(0)
			{
				_003C_003E4__this = this,
				time = time
			};
		}

		public void CloseOnClick()
		{
			contextAnimator.Play("Menu Out");
			contextManager.isContextMenuOn = false;
		}
	}
}
