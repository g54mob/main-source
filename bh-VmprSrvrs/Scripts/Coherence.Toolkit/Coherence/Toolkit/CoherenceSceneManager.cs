using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Log;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Coherence.Toolkit
{
	public class CoherenceSceneManager
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			public IEnumerable<CoherenceSync> bringAlong;

			public IEnumerable<CoherenceSync> leaveBehind;

			public AsyncOperation load;

			internal bool _003CLoadScene_003Eb__0()
			{
				return false;
			}

			internal bool _003CLoadScene_003Eb__1()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass13_0
		{
			public Scene scene;

			internal bool _003CLoadSceneAdditive_003Eb__0()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadScene_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public IEnumerable<CoherenceSync> bringAlong;

			public IEnumerable<CoherenceSync> leaveBehind;

			private _003C_003Ec__DisplayClass11_0 _003C_003E8__1;

			public int sceneBuildIndex;

			public LoadSceneMode loadSceneMode;

			public CoherenceBridge bridge;

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
			public _003CLoadScene_003Ed__11(int _003C_003E1__state)
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
		private sealed class _003CLoadSceneAdditive_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public int sceneBuildIndex;

			public CoherenceBridge bridge;

			public bool mergeScenes;

			private _003C_003Ec__DisplayClass13_0 _003C_003E8__1;

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
			public _003CLoadSceneAdditive_003Ed__13(int _003C_003E1__state)
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

		private CoherenceClientConnectionManager clientConnections;

		private IClient client;

		private static Coherence.Log.Logger logger;

		private uint? pendingNewScene;

		private uint? lastSetScene;

		public CoherenceSceneManager(CoherenceClientConnectionManager clientConnections, IClient client)
		{
		}

		public void SetClientScene(int newSceneIndex)
		{
		}

		public void SetClientScene(uint newSceneIndex)
		{
		}

		public uint GetClientScene()
		{
			return 0u;
		}

		internal void GotMyClientConnection(CoherenceClientConnection myClientConnection)
		{
		}

		public static IEnumerator LoadScene(CoherenceBridge bridge, string scenePath, IEnumerable<CoherenceSync> bringAlong = null, IEnumerable<CoherenceSync> leaveBehind = null, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CLoadScene_003Ed__11))]
		public static IEnumerator LoadScene(CoherenceBridge bridge, int sceneBuildIndex, IEnumerable<CoherenceSync> bringAlong = null, IEnumerable<CoherenceSync> leaveBehind = null, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
		{
			return null;
		}

		public static IEnumerator LoadSceneAdditive(CoherenceBridge bridge, string scenePath, bool mergeScenes = true)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CLoadSceneAdditive_003Ed__13))]
		public static IEnumerator LoadSceneAdditive(CoherenceBridge bridge, int sceneBuildIndex, bool mergeScenes = false)
		{
			return null;
		}
	}
}
