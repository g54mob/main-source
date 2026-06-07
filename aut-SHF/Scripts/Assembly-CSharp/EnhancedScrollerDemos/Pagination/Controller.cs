using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.Pagination
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[CompilerGenerated]
		private sealed class _003CFakeDelay_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Controller _003C_003E4__this;

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
			public _003CFakeDelay_003Ed__13(int _003C_003E1__state)
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

		private SmallList<Data> _data;

		public EnhancedScroller scroller;

		public CellView cellViewPrefab;

		public LoadingCellView loadingCellViewPrefab;

		public int cellHeight;

		public int pageCount;

		private bool _loadingNew;

		private void Start()
		{
		}

		private void LoadData(int pageStartIndex)
		{
		}

		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			return 0;
		}

		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 0f;
		}

		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			return null;
		}

		private void ScrollerScrolled(EnhancedScroller scroller, Vector2 val, float scrollPosition)
		{
		}

		[IteratorStateMachine(typeof(_003CFakeDelay_003Ed__13))]
		private IEnumerator FakeDelay()
		{
			return null;
		}
	}
}
