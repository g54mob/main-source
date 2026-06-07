using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseElevatorObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateFrameChange_003Ed__29 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseElevatorObj _003C_003E4__this;

		public int idx;

		private float _003CstartTime_003E5__2;

		private float _003Clen_003E5__3;

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
		public _003C_AnimateFrameChange_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003C_WaitForAnimsAndPlaceCombinedMesh_003Ed__23 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseElevatorObj _003C_003E4__this;

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
		public _003C_WaitForAnimsAndPlaceCombinedMesh_003Ed__23(int _003C_003E1__state)
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

	public static BaseElevatorObj I;

	public SelectionOutlineObj[] ElevatorOutlineObjs;

	public bool IsHovering;

	public Transform PlatformWrapper;

	public Transform[] MarkerResources;

	public BaseElevatorAnimator[] Animators;

	[Header("Indexed By Level")]
	public BaseElevatorLevelGroup[] LevelGroups;

	public Transform[] MarkerChar1;

	public Transform[] MarkerChar2;

	public Transform[] MarkerCharExit1;

	public Transform[] MarkerCharExit2;

	public ElevatorVicinityObj[] VicinityWrappers;

	public Mesh[] CombinedMeshes;

	public MeshFilter CombinedMeshFilt;

	public Mesh[] VicinityCombinedMeshes;

	public MeshFilter VicinityCombinedMeshFilt;

	[Header("Indexed By Tier")]
	public Transform[] TierWrappers;

	public Transform[] FrameMeshWrappers;

	[Header("VFX")]
	public PartSys ContactParts;

	public PartSys UpgradeParts;

	private int _displayedLvl;

	private void Awake()
	{
	}

	public void SetLevel(int lvl, bool animate)
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitForAnimsAndPlaceCombinedMesh_003Ed__23))]
	private IEnumerator<float> _WaitForAnimsAndPlaceCombinedMesh()
	{
		return null;
	}

	public void SetHover(bool isHover)
	{
	}

	public Transform GetChar1EntryMarker()
	{
		return null;
	}

	public Transform GetChar2EntryMarker()
	{
		return null;
	}

	public Transform GetChar1ExitMarker()
	{
		return null;
	}

	public Transform GetChar2ExitMarker()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AnimateFrameChange_003Ed__29))]
	private IEnumerator<float> _AnimateFrameChange(int idx)
	{
		return null;
	}

	public void SetAnimatorSpeed(float speed)
	{
	}

	public void InitEditor()
	{
	}
}
