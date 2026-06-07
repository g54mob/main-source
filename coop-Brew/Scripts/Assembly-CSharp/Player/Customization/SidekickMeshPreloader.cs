using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Player.Customization
{
	public class SidekickMeshPreloader : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CPreloadCoroutine_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickMeshPreloader _003C_003E4__this;

			private ResourceRequest _003CbaseModelReq_003E5__2;

			private ResourceRequest _003CbaseMatReq_003E5__3;

			private List<(string assetName, string resourcePath)> _003CpathsToLoad_003E5__4;

			private List<(string assetName, ResourceRequest req)> _003CinFlight_003E5__5;

			private int _003Cidx_003E5__6;

			private Stopwatch _003CframeTimer_003E5__7;

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
			public _003CPreloadCoroutine_003Ed__31(int _003C_003E1__state)
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
		private sealed class _003CWaitUntilReady_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickMeshPreloader _003C_003E4__this;

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
			public _003CWaitUntilReady_003Ed__32(int _003C_003E1__state)
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

		[Header("Legacy scene-serialized meshes (optional)")]
		[Tooltip("Kept for backward compatibility. The preloader now enumerates the whole database. Anything dragged here is additionally seeded into the cache on Awake.")]
		[SerializeField]
		private List<GameObject> meshPrefabs;

		[Header("Preload Settings")]
		[Tooltip("Max milliseconds per frame spent processing async load completions. Keeps the preload itself from hitching frame-time.")]
		[SerializeField]
		private float msBudgetPerFrame;

		[Tooltip("Maximum number of async LoadAsync requests held in flight at once.")]
		[SerializeField]
		private int maxInFlight;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Coroutine _preloadRoutine;

		public static SidekickMeshPreloader Instance { get; private set; }

		public bool IsReady { get; private set; }

		public int TotalPartsEnumerated { get; private set; }

		public int TotalPartsCached { get; private set; }

		public GameObject BaseModel { get; private set; }

		public Material BaseMaterialSource { get; private set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CPreloadCoroutine_003Ed__31))]
		private IEnumerator PreloadCoroutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitUntilReady_003Ed__32))]
		public IEnumerator WaitUntilReady()
		{
			return null;
		}

		public static SidekickMeshPreloader EnsureInstance()
		{
			return null;
		}
	}
}
