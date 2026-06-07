using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameTileMgr : TileMgr
{
	[CompilerGenerated]
	private sealed class _003C_RunDisableExpandVFX_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameTileMgr _003C_003E4__this;

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
		public _003C_RunDisableExpandVFX_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003C_RunExpandVFX_003Ed__26 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameTileMgr _003C_003E4__this;

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
		public _003C_RunExpandVFX_003Ed__26(int _003C_003E1__state)
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

	public static GameTileMgr I;

	private Material[][] _matArrByWallIdx;

	public Transform WrapperLeftWall;

	public Transform WrapperRightWall;

	public Transform WrapperGround;

	public MeshRenderer LevelFakeLight;

	public SerializedObjectPool<GameWallPiece> LeftWallPool;

	public SerializedObjectPool<GameWallPiece> RightWallPool;

	public SerializedObjectPool<GameWallPiece> GroundPool;

	public PartSysGroup ExpandPartsLeft;

	public PartSysGroup ExpandPartsRight;

	public MeshRenderer[] DisplacementSmoke;

	private OuterTilemapSet _curOuterTilemap;

	private int _numExpansions;

	private float _curExpansionPct;

	public Mesh TiledGroundMesh;

	[NonSerialized]
	public GameCompleteObj GameComplete;

	private const float kTgtExpandAlpha = 0.3f;

	private void Awake()
	{
	}

	public void InitTiles()
	{
	}

	public float GetTileHeight()
	{
		return 0f;
	}

	public void WrapTiles(int numRows, bool isBackwards)
	{
	}

	public void SetExpansionPct(int numExpansions, float pct)
	{
	}

	public OuterTilemapSet GetCurOuterTilemap()
	{
		return null;
	}

	public void EnableExpandVFX()
	{
	}

	private void SetDisplacementSmokeOpacity(float alpha)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunExpandVFX_003Ed__26))]
	private IEnumerator<float> _RunExpandVFX()
	{
		return null;
	}

	public void DisableExpandVFX()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunDisableExpandVFX_003Ed__28))]
	private IEnumerator<float> _RunDisableExpandVFX()
	{
		return null;
	}
}
