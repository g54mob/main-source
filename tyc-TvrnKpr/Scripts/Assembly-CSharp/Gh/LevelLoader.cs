using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh
{
	public static class LevelLoader
	{
		[CompilerGenerated]
		private sealed class _003CLoadLevelAsync_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string sceneOverride;

			public string levelName;

			private AsyncOperation _003CasyncOperation_003E5__2;

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
			public _003CLoadLevelAsync_003Ed__16(int _003C_003E1__state)
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

		public static string CurrentLevel { get; private set; }

		public static string CurrentScene { get; private set; }

		public static bool HasLevelBeenLoaded => false;

		public static event EventHandler PreLevelUnloaded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler PostLevelUnloaded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[IteratorStateMachine(typeof(_003CLoadLevelAsync_003Ed__16))]
		public static IEnumerator LoadLevelAsync(string levelName, string sceneOverride)
		{
			return null;
		}

		public static void UnloadLevel(string viewId = "mainMenu", Action onComplete = null)
		{
		}
	}
}
