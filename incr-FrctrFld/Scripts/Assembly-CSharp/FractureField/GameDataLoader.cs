using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FractureField.Shared.DTOs.GameData;
using UnityEngine;

namespace FractureField
{
	public class GameDataLoader : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass12_0
		{
			public GameDataLoader _003C_003E4__this;

			public bool loadCompleted;

			internal void _003CLoadGameDataCoroutine_003Eb__0(GameDataDto gameData)
			{
			}

			internal void _003CLoadGameDataCoroutine_003Eb__1(string error)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CEnsureGameDataLoaded_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameDataLoader _003C_003E4__this;

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
			public _003CEnsureGameDataLoaded_003Ed__11(int _003C_003E1__state)
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
		private sealed class _003CLoadGameDataCoroutine_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameDataLoader _003C_003E4__this;

			private _003C_003Ec__DisplayClass12_0 _003C_003E8__1;

			private float _003Celapsed_003E5__2;

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
			public _003CLoadGameDataCoroutine_003Ed__12(int _003C_003E1__state)
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
		private sealed class _003CRefreshGameDataCoroutine_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameDataLoader _003C_003E4__this;

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
			public _003CRefreshGameDataCoroutine_003Ed__16(int _003C_003E1__state)
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

		[Header("Configuration")]
		[SerializeField]
		private bool loadOnStart;

		[SerializeField]
		private float timeoutSeconds;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public bool IsLoading { get; private set; }

		public bool IsLoaded => false;

		private void Start()
		{
		}

		public void LoadGameData()
		{
		}

		[IteratorStateMachine(typeof(_003CEnsureGameDataLoaded_003Ed__11))]
		private IEnumerator EnsureGameDataLoaded()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CLoadGameDataCoroutine_003Ed__12))]
		private IEnumerator LoadGameDataCoroutine()
		{
			return null;
		}

		private void LogDebug(string message)
		{
		}

		private void LogError(string message)
		{
		}

		public void RefreshGameData()
		{
		}

		[IteratorStateMachine(typeof(_003CRefreshGameDataCoroutine_003Ed__16))]
		private IEnumerator RefreshGameDataCoroutine()
		{
			return null;
		}
	}
}
