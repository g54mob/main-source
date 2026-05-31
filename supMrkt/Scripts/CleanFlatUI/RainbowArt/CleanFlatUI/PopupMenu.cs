using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class PopupMenu : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		protected internal class PopupMenuItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
		{
			public Text itemText;

			public Image itemImage;

			public Image itemLine;

			public Button button;

			public virtual void OnPointerEnter(PointerEventData eventData)
			{
			}
		}

		public enum Origin
		{
			TopStart = 0,
			TopCenter = 1,
			TopEnd = 2,
			BottomStart = 3,
			BottomCenter = 4,
			BottomEnd = 5,
			LeftStart = 6,
			LeftCenter = 7,
			LeftEnd = 8,
			RightStart = 9,
			RightCenter = 10,
			RightEnd = 11
		}

		[Serializable]
		public class OptionItem
		{
			public string text;

			public Sprite icon;

			public OptionItem()
			{
			}

			public OptionItem(string newText)
			{
			}

			public OptionItem(Sprite newImage)
			{
			}

			public OptionItem(string newText, Sprite newImage)
			{
			}
		}

		[Serializable]
		public class PopupMenuEvent : UnityEvent<int>
		{
		}

		[CompilerGenerated]
		private sealed class _003CDisableTransition_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PopupMenu _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDisableTransition_003Ed__43(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private GameObject itemTemplate;

		[SerializeField]
		private Text itemText;

		[SerializeField]
		private Image itemImage;

		[SerializeField]
		private Image itemLine;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RectOffset padding;

		[SerializeField]
		private float spacing;

		[SerializeField]
		private Origin origin;

		[SerializeField]
		private List<OptionItem> options;

		[SerializeField]
		private PopupMenuEvent onValueChanged;

		private List<PopupMenuItem> menuItems;

		private GameObject clickerBlocker;

		private IEnumerator diableCoroutine;

		private float disableTime;

		private uint distance;

		public RectOffset Padding
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Spacing
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public PopupMenuEvent OnValueChanged
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void ShowPopupMenu(Vector3 position, float width, float height)
		{
		}

		public void AddOptions(List<OptionItem> optionList)
		{
		}

		public void AddOptions(List<string> optionList)
		{
		}

		public void AddOptions(List<Sprite> optionList)
		{
		}

		public void ClearOptions()
		{
		}

		private void SetupTemplate()
		{
		}

		private void CreateAllMenuItems(List<OptionItem> options)
		{
		}

		private Canvas GetRootCanvas()
		{
			return null;
		}

		private RectTransform GetRootCanvasRectTrans()
		{
			return null;
		}

		private void CreateClickBlocker()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		private void OnItemClicked(int index)
		{
		}

		private void DestroyAllMenuItems()
		{
		}

		private void DestroyClickBlocker()
		{
		}

		public void HidePopupMenu(bool playAnim)
		{
		}

		[IteratorStateMachine(typeof(_003CDisableTransition_003Ed__43))]
		private IEnumerator DisableTransition()
		{
			return null;
		}

		public bool IsShowing()
		{
			return false;
		}

		private void UpdatePosition(Vector3 position, float uiWidth, float uiHeight)
		{
		}

		private void PlayAnimation(bool bShow)
		{
		}
	}
}
