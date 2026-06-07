using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowRadioButton : MonoBehaviour
	{
		protected internal class ContentItem : MonoBehaviour
		{
			public Text itemText;

			public Image itemImage;

			public Image itemSelect;

			public Image itemCheckmark;

			public Button button;
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
		public class ModalWindowEvent : UnityEvent<int>
		{
		}

		[CompilerGenerated]
		private sealed class _003CDisableTransition_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ModalWindowRadioButton _003C_003E4__this;

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
			public _003CDisableTransition_003Ed__45(int _003C_003E1__state)
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
		private Image iconTitle;

		[SerializeField]
		private Text title;

		[SerializeField]
		private Button buttonClose;

		[SerializeField]
		private Button buttonConfirm;

		[SerializeField]
		private Button buttonCancel;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RectTransform contentRect;

		[SerializeField]
		private GameObject itemTemplate;

		[SerializeField]
		private Text itemText;

		[SerializeField]
		private Image itemImage;

		[SerializeField]
		private Image itemSelect;

		[SerializeField]
		private Image itemCheckmark;

		[SerializeField]
		private RectOffset padding;

		[SerializeField]
		private float spacing;

		[SerializeField]
		private int startSelectedIndex;

		[SerializeField]
		private List<OptionItem> options;

		private List<ContentItem> contentItems;

		[SerializeField]
		private ModalWindowEvent onConfirm;

		[SerializeField]
		private ModalWindowEvent onCancel;

		private int selectedIndex;

		private IEnumerator diableCoroutine;

		private float disableTime;

		public int StartSelectedIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int SelectedIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string TitleValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Sprite IconValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ModalWindowEvent OnConfirm
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ModalWindowEvent OnCancel
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void ShowModalWindow()
		{
		}

		public void HideModalWindow()
		{
		}

		[IteratorStateMachine(typeof(_003CDisableTransition_003Ed__45))]
		private IEnumerator DisableTransition()
		{
			return null;
		}

		private void UpdateSelectIndex()
		{
		}

		private void InitButtons()
		{
		}

		private void OnCloseClick()
		{
		}

		private void OnCancelClick()
		{
		}

		private void OnConfirmClick()
		{
		}

		private void InitAnimation()
		{
		}

		private void PlayAnimation(bool bShow)
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

		private void CreateAllItems(List<OptionItem> options)
		{
		}

		private void DestroyAllItems()
		{
		}

		private void OnItemSelected(int index)
		{
		}
	}
}
