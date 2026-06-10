using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class BuildingCreator : Creator
{
	public class PickBuilding
	{
		public BuildingPreset preset;

		public float rank;
	}

	[CompilerGenerated]
	private sealed class _003CLoad_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CLoad_003Ed__9(int _003C_003E1__state)
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

	public int loadChunk;

	private List<BuildingPreset> buildingPresets;

	private List<PickBuilding> selectionList;

	private static BuildingCreator _instance;

	public static BuildingCreator Instance => null;

	private void Awake()
	{
	}

	public override void StartLoading()
	{
	}

	[IteratorStateMachine(typeof(_003CLoad_003Ed__9))]
	private IEnumerator Load()
	{
		return null;
	}
}
