using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildingMeshObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateSurroundings_003Ed__29 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BuildingMeshObj _003C_003E4__this;

		public float startScale;

		public float tgtScale;

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
		public _003C_AnimateSurroundings_003Ed__29(int _003C_003E1__state)
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

	public BuildingType Type;

	public MeshRenderer BldMesh;

	public MeshRenderer[] ExtraMesh;

	public BuildingAnimObj[] Anims;

	public MeshFilter BldFilt;

	public Mesh[] LvlMeshes;

	public BuildingVFXSettings[] VFX;

	public SelectionOutlineObj OutlineObj;

	public SelectionOutlineObj[] ExtraOutlineObjs;

	[FormerlySerializedAs("MatIdx")]
	public int BldMatIdx;

	public int PlatformMatIdx;

	public Vector3 Placement;

	public Vector3 OverlayOffset;

	public MeshRenderer PlatformMesh;

	public SelectionOutlineObj PlatformOutline;

	public Transform WrapperGroundSurrounding;

	protected BuildingObj _tgtBld;

	protected int _curLvl;

	private CoroutineHandle _surroundingAnim;

	public virtual void Init(BuildingObj b)
	{
	}

	public virtual void SetLvl(int lvl)
	{
	}

	public void SetVFXEnabled(bool isOn)
	{
	}

	public float GetDefaultScale()
	{
		return 0f;
	}

	public void SetMaterial(BuildingMatType mt)
	{
	}

	public void ResetMaterial()
	{
	}

	public void SetColor(Color c)
	{
	}

	public void SetOutline(Color c)
	{
	}

	public void ClearOutline()
	{
	}

	public void AnimateSurroundings(float startScale, float tgtScale)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateSurroundings_003Ed__29))]
	public IEnumerator<float> _AnimateSurroundings(float startScale, float tgtScale)
	{
		return null;
	}

	public void OnWorkerAssigned(bool isAssigned)
	{
	}
}
