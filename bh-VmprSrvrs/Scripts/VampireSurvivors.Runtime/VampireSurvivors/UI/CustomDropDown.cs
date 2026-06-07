using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class CustomDropDown : MonoBehaviour, ISelectableUI, IUIObject
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndFormat_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomDropDown _003C_003E4__this;

			public int count;

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
			public _003CWaitAndFormat_003Ed__20(int _003C_003E1__state)
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
		private TextMeshProUGUI _Label;

		[SerializeField]
		private Graphic _SelectedItem;

		[SerializeField]
		private Image _Arrow;

		[SerializeField]
		private GameObject _OptionPrefab;

		[FormerlySerializedAs("_Container")]
		[SerializeField]
		private RectTransform _ContentContainer;

		[SerializeField]
		private Button _DropDown;

		[SerializeField]
		private int _ItemsToShow;

		[SerializeField]
		private ScrollEnhancer _Scroll;

		[SerializeField]
		private GameObject _DropdownScrollContainer;

		private List<CustomDropdownItem> _spawned;

		private List<object> _options;

		private Action<int> _callback;

		private int _selectedIndex;

		public bool IsOpen => false;

		public void InitialSet(string text, List<object> options, int selectedIndex, Action<int> callbackWithNewSelectedIndex, bool clearCurrentOptions = false)
		{
		}

		private void ClearOptions()
		{
		}

		public void RegenerateOptions(List<object> options, int selectedIndex)
		{
		}

		private void UpdateSelectedItem(object value)
		{
		}

		public void SetItemsToShow(int count, bool force = false)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndFormat_003Ed__20))]
		private IEnumerator WaitAndFormat(int count)
		{
			return null;
		}

		private void Format(int count)
		{
		}

		private void ApplyNavigation()
		{
		}

		public void Open()
		{
		}

		public void SelectItem(CustomDropdownItem item)
		{
		}

		public void Close()
		{
		}

		public void Toggle()
		{
		}

		public void Update()
		{
		}

		public Selectable GetSelectable()
		{
			return null;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
		{
		}
	}
}
