using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GarbageManager : NoktaSingleton<GarbageManager>
{
	[CompilerGenerated]
	private sealed class _003CDustOverTime_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GarbageManager _003C_003E4__this;

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
		public _003CDustOverTime_003Ed__12(int _003C_003E1__state)
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
	private sealed class _003CGarbageGeneration_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GarbageManager _003C_003E4__this;

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
		public _003CGarbageGeneration_003Ed__10(int _003C_003E1__state)
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
	private sealed class _003CSpawnOnboardingDirtEnumerator_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GarbageManager _003C_003E4__this;

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
		public _003CSpawnOnboardingDirtEnumerator_003Ed__27(int _003C_003E1__state)
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
	private sealed class _003CSpawnOnboardingGarbageEnumerator_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CSpawnOnboardingGarbageEnumerator_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003CUpdateGarbageList_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CUpdateGarbageList_003Ed__15(int _003C_003E1__state)
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

	[SerializeField]
	private float m_DustRate;

	[SerializeField]
	private List<CustomerSpawnSettingSO> m_SpawnSettings;

	private int m_GarbageMultiplier;

	private int m_MaxGarbageCount;

	private bool m_IsTutorialMissionsCompleted;

	private Coroutine m_SpawnGarbageCoroutine;

	private Coroutine m_DustingRoutine;

	public bool CanSpawnGarbage => false;

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CGarbageGeneration_003Ed__10))]
	private IEnumerator GarbageGeneration()
	{
		return null;
	}

	private float GetGarbageSpawnRate()
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003CDustOverTime_003Ed__12))]
	private IEnumerator DustOverTime()
	{
		return null;
	}

	private void CheckEndDay()
	{
	}

	public void OnStoreOpened()
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateGarbageList_003Ed__15))]
	private IEnumerator UpdateGarbageList()
	{
		return null;
	}

	public void OnStoreClosed()
	{
	}

	public void SpawnGarbage()
	{
	}

	public void CreateJustGarbage()
	{
	}

	public void CreateJustDirt()
	{
	}

	public void Dusting()
	{
	}

	public void CalculateGarbageList()
	{
	}

	public void DelayedSpawnOnboardingGarbage()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnOnboardingGarbageEnumerator_003Ed__25))]
	private IEnumerator SpawnOnboardingGarbageEnumerator()
	{
		return null;
	}

	public void DelayedSpawnOnboardingDirt()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnOnboardingDirtEnumerator_003Ed__27))]
	private IEnumerator SpawnOnboardingDirtEnumerator()
	{
		return null;
	}
}
