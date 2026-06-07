using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AddressablesMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public LevelType lt;

		internal void _003C_LoadEnemyMeshes_003Eb__0(GameObject go)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_LoadEnemyMeshes_003Ed__8 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelType lt;

		public AddressablesMgr _003C_003E4__this;

		private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

		private LevelAssetState _003CassetState_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_LoadEnemyMeshes_003Ed__8(int _003C_003E1__state)
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
	private sealed class _003C_LoadLevelAssets_003Ed__10 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public AddressablesMgr _003C_003E4__this;

		public LevelType lt;

		public Action onLoadComplete;

		private LevelAssetState _003CassetState_003E5__2;

		private LevelInfo _003ClInf_003E5__3;

		private int _003Ci_003E5__4;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_LoadLevelAssets_003Ed__10(int _003C_003E1__state)
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

	public LevelAssetState[] LoadedLevelAssets;

	public static AddressablesMgr I { get; private set; }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void RunTimeInitialization()
	{
	}

	private void Awake()
	{
	}

	public void LoadEnemyMeshes(LevelType lt)
	{
	}

	[IteratorStateMachine(typeof(_003C_LoadEnemyMeshes_003Ed__8))]
	private IEnumerator<float> _LoadEnemyMeshes(LevelType lt)
	{
		return null;
	}

	public void LoadLevelAssets(LevelType lt, Action onLoadComplete)
	{
	}

	[IteratorStateMachine(typeof(_003C_LoadLevelAssets_003Ed__10))]
	private IEnumerator<float> _LoadLevelAssets(LevelType lt, Action onLoadComplete)
	{
		return null;
	}

	public bool AreLevelAssetsLoaded(LevelType lt)
	{
		return false;
	}

	public bool AreLevelAssetsLoading(LevelType lt)
	{
		return false;
	}

	public bool AreLevelAssetsAtState(LevelType lt, AssetLoadState checkState)
	{
		return false;
	}

	public void UnloadLevelAssets(LevelType lt)
	{
	}
}
