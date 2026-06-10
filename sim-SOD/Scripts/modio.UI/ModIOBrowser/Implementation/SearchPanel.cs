using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class SearchPanel : SelfInstancingMonoSingleton<SearchPanel>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWaitForTagsToUpdate_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public SearchPanel _003C_003E4__this;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CCreateTagListItems_003Ed__24 : IEnumerable<ListItem>, IEnumerable, IEnumerator<ListItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ListItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private TagCategory category;

			public TagCategory _003C_003E3__category;

			public SearchPanel _003C_003E4__this;

			private bool _003CsetJumpTo_003E5__2;

			private ModIO.Tag[] _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			ListItem IEnumerator<ListItem>.Current
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
			public _003CCreateTagListItems_003Ed__24(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<ListItem> IEnumerable<ListItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[SerializeField]
		[Header("Search Panel")]
		public GameObject SearchPanelGameObject;

		[SerializeField]
		public TMP_InputField SearchPanelField;

		[SerializeField]
		private GameObject SearchPanelTagCategoryPrefab;

		[SerializeField]
		private RectTransform SearchPanelTagViewport;

		[SerializeField]
		private Transform SearchPanelTagParent;

		[SerializeField]
		private GameObject SearchPanelTagPrefab;

		[SerializeField]
		public Image SearchPanelLeftBumperIcon;

		[SerializeField]
		public Image SearchPanelRightBumperIcon;

		public static HashSet<Tag> searchFilterTags;

		internal TagCategory[] tags;

		private bool gettingTags;

		public void Open()
		{
		}

		private void FieldNavigationLock()
		{
		}

		private void FieldNavigationUnlock(List<Selectable> listItems)
		{
		}

		public void Close()
		{
		}

		public void ClearFilter()
		{
		}

		public void SetupTags()
		{
		}

		[AsyncStateMachine(typeof(_003CWaitForTagsToUpdate_003Ed__17))]
		internal Task WaitForTagsToUpdate()
		{
			return null;
		}

		private void UpdateTags()
		{
		}

		private void ReceiveTags(ResultAnd<TagCategory[]> resultAndTags)
		{
		}

		internal List<string> GetHiddenTags()
		{
			return null;
		}

		private void CreateTagCategoryListItems(TagCategory[] tags)
		{
		}

		private void ReorderAndSetNavigation(List<Selectable> items)
		{
		}

		private bool GetWithinBoundsOfList<T>(List<T> list, int index, out T item)
		{
			item = default(T);
			return false;
		}

		[IteratorStateMachine(typeof(_003CCreateTagListItems_003Ed__24))]
		private IEnumerable<ListItem> CreateTagListItems(TagCategory category)
		{
			return null;
		}

		public void ApplyFilter()
		{
		}

		internal void UpdateBumperIcons()
		{
		}

		internal void ToggleState()
		{
		}
	}
}
