using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace UI
{
	public abstract class BaseCollectionPage : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			public int enumNumber;

			internal bool _003CDelaySetCursor_003Eb__0(CollectionListElement x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CDelaySetCursor_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BaseCollectionPage _003C_003E4__this;

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
			public _003CDelaySetCursor_003Ed__10(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CDelaySetCursor_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public int enumNumber;

			public BaseCollectionPage _003C_003E4__this;

			private _003C_003Ec__DisplayClass11_0 _003C_003E8__1;

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
			public _003CDelaySetCursor_003Ed__11(int _003C_003E1__state)
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

		public TMP_Text selectedText;

		public GameObject detailContentsParentObj;

		public TMP_Text releaseConditionText;

		protected List<CollectionListElement> collectionList;

		protected int collectionCountMax;

		public abstract void Init();

		public abstract void AddCollection(int enumNumber);

		public abstract void SelectItem(int enumNumber, bool isSecret = false);

		protected void SetSelectedName(string newText)
		{
		}

		public void SetCursor(int enumNumber)
		{
		}

		public void SetCursor()
		{
		}

		[IteratorStateMachine(typeof(_003CDelaySetCursor_003Ed__10))]
		private IEnumerator DelaySetCursor()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDelaySetCursor_003Ed__11))]
		private IEnumerator DelaySetCursor(int enumNumber)
		{
			return null;
		}

		private void OnDisable()
		{
		}

		public virtual void SelectItem(int enumNumber)
		{
		}

		public virtual void SelectItem(CollectionListElement element)
		{
		}

		public virtual void SortElements()
		{
		}

		public virtual void SortElements(List<CollectionListElement> list)
		{
		}

		public virtual void SortElements(RectTransform parent)
		{
		}

		protected abstract int GetSortNum(CollectionListElement item);

		public virtual int GetCollectionCountMax()
		{
			return 0;
		}

		public virtual int GetCollectionCount()
		{
			return 0;
		}

		protected abstract void InitCollectionCountMax();

		protected virtual bool IsUnlockWriter(eWriterId writerId)
		{
			return false;
		}

		protected virtual bool IsActiveWriter(eWriterId writerId)
		{
			return false;
		}
	}
}
