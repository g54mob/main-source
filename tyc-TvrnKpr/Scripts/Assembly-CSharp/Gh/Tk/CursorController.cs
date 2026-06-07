using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class CursorController : SingletonMonoBehaviour<CursorController>
	{
		[Serializable]
		public class CursorConfig
		{
			public string id;

			public Vector2 hotSpot;

			public List<Sprite> cursorFrames;

			private Dictionary<Sprite, Texture2D> _frameCache;

			private int _currentFrameIndex;

			public float secondsPerFrame;

			private float _lastFrameTime;

			public void ApplyCursor()
			{
			}

			private void SetCursorToCurrentFrame()
			{
			}

			public void UpdateCursor()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CStart_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CursorController _003C_003E4__this;

			private int _003Cx_003E5__2;

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
			public _003CStart_003Ed__8(int _003C_003E1__state)
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

		private string _nextCursorId;

		public bool cacheFrameTextures;

		public bool showDebugHotspot;

		public List<CursorConfig> cursorConfigs;

		private CursorConfig _currentConfig;

		private bool _readyToSetCursor;

		private string CalculateActiveCursor()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__8))]
		private IEnumerator Start()
		{
			return null;
		}

		private void LateUpdate()
		{
		}

		public void SetCursor(string cursorId)
		{
		}

		public void SetCursor(CursorConfig config)
		{
		}

		private void ResetCursor()
		{
		}
	}
}
