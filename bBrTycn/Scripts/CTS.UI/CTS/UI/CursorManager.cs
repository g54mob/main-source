using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS.UI
{
	public class CursorManager : MonoSingleton<CursorManager>, ILockable
	{
		private readonly struct CursorData : IEquatable<CursorData>
		{
			public readonly CursorSO Cursor;

			public readonly int Order;

			public CursorData(CursorSO cursor, int order)
			{
				Cursor = cursor;
				Order = order;
			}

			public bool Equals(CursorData other)
			{
				return Cursor == other.Cursor;
			}

			public override bool Equals(object obj)
			{
				if (obj is CursorData other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return Cursor.GetHashCode();
			}
		}

		[SerializeField]
		private GameObject _cursorBlocker;

		[SerializeField]
		private CursorSO _defaultCursor;

		private readonly Dictionary<StringKey<CursorSO>, CursorSO> _availableCursors = new Dictionary<StringKey<CursorSO>, CursorSO>();

		private CursorSO _currentCursor;

		private readonly Dictionary<StringKey, CursorData> _currentCursors = new Dictionary<StringKey, CursorData>();

		private Vector2 _oldPos;

		public CursorMode CursorMode { get; private set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public float LastTimeSinceEnabled { get; private set; }

		protected override void SingletonAwake()
		{
			CursorSO[] array = Resources.LoadAll<CursorSO>("Scriptables/Cursors");
			foreach (CursorSO cursorSO in array)
			{
				_availableCursors[cursorSO] = cursorSO;
			}
			SetCursorVisual(_defaultCursor);
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void SetCursorMode(CursorMode mode)
		{
			if (mode != CursorMode)
			{
				CursorMode = mode;
				RecalculateCursor();
				Cursor.SetCursor(_currentCursor.Icon, _currentCursor.CursorOffset, CursorMode);
			}
		}

		public void AddCursorVisual(StringKey key, StringKey<CursorSO> cursor, int? specificOrder = null)
		{
			AddCursorVisual(key, _availableCursors[cursor], specificOrder);
		}

		public void AddCursorVisual(StringKey key, CursorSO cursor, int? specificOrder = null)
		{
			CursorData value = new CursorData(cursor, specificOrder ?? cursor.DefaultOrder);
			_currentCursors[key] = value;
			RecalculateCursor();
		}

		public void RemoveCursorVisual(StringKey key)
		{
			if (_currentCursors.ContainsKey(key))
			{
				_currentCursors.Remove(key);
				RecalculateCursor();
			}
		}

		private void RecalculateCursor()
		{
			if (_currentCursors.Count <= 0)
			{
				SetCursorVisual(_defaultCursor);
				return;
			}
			int num = int.MinValue;
			CursorSO cursorSO = null;
			foreach (CursorData value in _currentCursors.Values)
			{
				if (value.Order > num)
				{
					num = value.Order;
					cursorSO = value.Cursor;
				}
			}
			if ((object)cursorSO == null)
			{
				SetCursorVisual(_defaultCursor);
			}
			else
			{
				SetCursorVisual(cursorSO);
			}
		}

		private void SetCursorVisual(CursorSO cursor)
		{
			if (!(_currentCursor == cursor))
			{
				_currentCursor = cursor;
				Cursor.SetCursor(cursor.Icon, cursor.CursorOffset, CursorMode);
			}
		}

		void ILockable.OnLocked()
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Confined;
			if ((bool)_cursorBlocker)
			{
				_cursorBlocker.SetActive(value: true);
			}
		}

		void ILockable.OnUnlocked()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			LastTimeSinceEnabled = Time.unscaledTime;
			if ((bool)_cursorBlocker)
			{
				_cursorBlocker.SetActive(value: false);
			}
		}

		public void ResetOldPos()
		{
			Mouse.current.WarpCursorPosition(_oldPos);
		}

		public void RegisterPosition()
		{
			_oldPos = Mouse.current.position.value;
		}
	}
}
