using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PolyAndCode.UI
{
	public class HorizontalRecyclingSystem : RecyclingSystem
	{
		[CompilerGenerated]
		private sealed class _003CInitCoroutine_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HorizontalRecyclingSystem _003C_003E4__this;

			public Action onInitialized;

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
			public _003CInitCoroutine_003Ed__15(int _003C_003E1__state)
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

		private readonly int _rows;

		private float _cellWidth;

		private float _cellHeight;

		private List<RectTransform> _cellPool;

		private List<ICell> _cachedCells;

		private Bounds _recyclableViewBounds;

		private readonly Vector3[] _corners;

		private bool _recycling;

		private int currentItemCount;

		private int leftMostCellIndex;

		private int rightMostCellIndex;

		private int _leftMostCellRow;

		private int _RightMostCellRow;

		private Vector2 zeroVector;

		public HorizontalRecyclingSystem(RectTransform prototypeCell, RectTransform viewport, RectTransform content, IRecyclableScrollRectDataSource dataSource, bool isGrid, int rows)
		{
		}

		[IteratorStateMachine(typeof(_003CInitCoroutine_003Ed__15))]
		public override IEnumerator InitCoroutine(Action onInitialized)
		{
			return null;
		}

		private void SetRecyclingBounds()
		{
		}

		private void CreateCellPool()
		{
		}

		public override Vector2 OnValueChangedListener(Vector2 direction)
		{
			return default(Vector2);
		}

		private Vector2 RecycleLeftToRight()
		{
			return default(Vector2);
		}

		private Vector2 RecycleRightToleft()
		{
			return default(Vector2);
		}

		private void SetLeftAnchor(RectTransform rectTransform)
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
