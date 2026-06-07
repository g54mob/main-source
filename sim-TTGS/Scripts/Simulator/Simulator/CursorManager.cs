using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator
{
	public static class CursorManager
	{
		private static readonly Stack<CursorState> m_stack = new Stack<CursorState>();

		public static CursorState Current { get; private set; }

		public static event Action<CursorState> OnCursorStateChanged;

		public static void SetBaseState(CursorState state)
		{
			m_stack.Clear();
			Current = state;
			SetCursorState(state);
		}

		public static void StackState(CursorState state)
		{
			m_stack.Push(Current);
			Current = state;
			SetCursorState(state);
		}

		public static void PopCurrent()
		{
			if (m_stack.TryPop(out var result))
			{
				Current = result;
				SetCursorState(result);
			}
			else
			{
				Current = default(CursorState);
				SetCursorState(default(CursorState));
			}
		}

		public static void ResetState()
		{
			m_stack.Clear();
			Current = default(CursorState);
			SetCursorState(default(CursorState));
		}

		private static void SetCursorState(CursorState state)
		{
			Cursor.SetCursor(state.texture, state.hotspot, state.mode);
			CursorManager.OnCursorStateChanged?.Invoke(state);
		}
	}
}
