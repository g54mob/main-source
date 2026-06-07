using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public class GridPieceObj : SerializedMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__66 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		public float delay;

		private float _003CdropDist_003E5__2;

		private float _003Clen_003E5__3;

		private float _003CstartTime_003E5__4;

		private Color _003CshadowColor_003E5__5;

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
		public _003C_AnimateEntry_003Ed__66(int _003C_003E1__state)
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
	private sealed class _003C_AttackEnemy_003Ed__160 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		public GridPieceObj tgt;

		private float _003CstartTime_003E5__2;

		private float _003CwaitLen_003E5__3;

		private bool _003CdidAttack_003E5__4;

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
		public _003C_AttackEnemy_003Ed__160(int _003C_003E1__state)
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
	private sealed class _003C_FadeStatusEffect_003Ed__136 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		public float len;

		public string property;

		public float startVal;

		public float endVal;

		private float _003CstartTime_003E5__2;

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
		public _003C_FadeStatusEffect_003Ed__136(int _003C_003E1__state)
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
	private sealed class _003C_HitFlash_003Ed__80 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		public DamageType dmgType;

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
		public _003C_HitFlash_003Ed__80(int _003C_003E1__state)
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
	private sealed class _003C_QueueRemove_003Ed__123 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

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
		public _003C_QueueRemove_003Ed__123(int _003C_003E1__state)
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
	private sealed class _003C_RunAttack_003Ed__117 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		public Transform tgt;

		public Func<EnemyAttackResult> onAttackComplete;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private Vector2 _003CattackDir_003E5__4;

		private float _003CwaitLen_003E5__5;

		private Vector3 _003CtgtPos_003E5__6;

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
		public _003C_RunAttack_003Ed__117(int _003C_003E1__state)
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
	private sealed class _003C_RunBounce_003Ed__85 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		public float len;

		public float zIntensity;

		private float _003CstartTime_003E5__2;

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
		public _003C_RunBounce_003Ed__85(int _003C_003E1__state)
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
	private sealed class _003C_RunBounceUnscaled_003Ed__87 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		public float len;

		public float zIntensity;

		private float _003CstartTime_003E5__2;

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
		public _003C_RunBounceUnscaled_003Ed__87(int _003C_003E1__state)
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
	private sealed class _003C_RunCurseImpact_003Ed__175 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		private StatusEffect _003Cef_003E5__2;

		private StatusEffInd _003CefInd_003E5__3;

		private Vector3 _003CstartLocalPos_003E5__4;

		private Vector3 _003CtgtLocalPos_003E5__5;

		private float _003CstartTime_003E5__6;

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
		public _003C_RunCurseImpact_003Ed__175(int _003C_003E1__state)
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
	private sealed class _003C_RunDeath_003Ed__125 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private Vector3 _003CtgtPos_003E5__4;

		private Vector3 _003CtgtRot_003E5__5;

		private bool _003CplayedVox_003E5__6;

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
		public _003C_RunDeath_003Ed__125(int _003C_003E1__state)
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
	private sealed class _003C_RunDelayedChant_003Ed__171 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

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
		public _003C_RunDelayedChant_003Ed__171(int _003C_003E1__state)
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
	private sealed class _003C_RunHitTilt_003Ed__92 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		public float len;

		public Vector2 hitNormal;

		public Vector3 hitOffset;

		public float intensity;

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
		public _003C_RunHitTilt_003Ed__92(int _003C_003E1__state)
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
	private sealed class _003C_RunJustSpawned_003Ed__151 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		public Vector3 tgtPos;

		public Vector3 spawnPos;

		private float _003CstartTime_003E5__2;

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
		public _003C_RunJustSpawned_003Ed__151(int _003C_003E1__state)
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
	private sealed class _003C_RunSimpleAnim_003Ed__46 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		private float _003Csc_003E5__2;

		private float _003Ct_003E5__3;

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
		public _003C_RunSimpleAnim_003Ed__46(int _003C_003E1__state)
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
	private sealed class _003C_RunStackDrop_003Ed__129 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj _003C_003E4__this;

		public Vector3 tgtPos;

		private GridPieceMarker _003Cmarker_003E5__2;

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
		public _003C_RunStackDrop_003Ed__129(int _003C_003E1__state)
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

	public GridPieceType Type;

	[NonSerialized]
	[OdinSerialize]
	public GridPieceInst Inst;

	public GridSpriteObj SpriteObj;

	public GridPieceShadow Shadow;

	public EnemyMeshController MeshController;

	public Collider2D Col;

	public ColliderType ColType;

	[SerializeField]
	protected Vector2 _defaultColSize;

	public Vector3 CenterPos;

	[SerializeField]
	protected Vector3 _defaultSpritePos;

	protected Vector3 _defaultMeshPos;

	public List<StatusEffInd> AttachedInds;

	public SubGridPieceObj[] Children;

	public bool IsActive;

	public float SpawnTime;

	public float StateChangePhysTime;

	protected Vector2 _lastHitNormal;

	protected Vector3 _lastHitOffset;

	public float RemainingEntryTime;

	private float _curEntryDelay;

	protected Vector2 _size;

	private CoroutineHandle _curColorAnim;

	protected bool _isBouncing;

	protected CoroutineHandle _curBounceAnim;

	protected bool _isTilting;

	protected CoroutineHandle _curTiltAnim;

	public bool IsGonnaGetThorned;

	private bool _gotSpiked;

	private float _walkTime;

	private float _walkBounceSpeed;

	public GridPieceObj AttackTgt;

	private PetObjTortoise _tgtTortoise;

	protected CoroutineHandle _attackAnim;

	protected CoroutineHandle _entryAnim;

	protected CoroutineHandle _deathAnim;

	protected GridPieceMarker _curMarker;

	protected bool _isHitFlashing;

	private TrailVFX _entryTrail;

	private float _lastAttackTime;

	private int _numTimesAttackedPlayer;

	private bool _isRunningCurse;

	protected MaterialPropertyBlock _matBlock;

	private CoroutineHandle _simpleAnim;

	private AlertSprite _alertSprite;

	protected const float kShadowAlpha = 0.175f;

	private float _hitFlashStartTime;

	private const float kBounceLen = 0.2f;

	private const float kTiltLen = 0.2f;

	private const float kSqueezeScale = 0.0625f;

	private float _hitTiltStartTime;

	private Vector3 _hitTiltRotAmt;

	private float _hitTiltLen;

	private const float kAttackLen = 0.25f;

	private const float kDeathLen = 0.2f;

	protected const float kDropLen = 0.2f;

	private float _distToCustomPos;

	private const float kSpawnLen = 0.25f;

	private const float kPieceAttackLen = 0.125f;

	public virtual void Init(GridPieceInst inst)
	{
	}

	public void RefreshSimplifiedGraphics()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunSimpleAnim_003Ed__46))]
	protected virtual IEnumerator<float> _RunSimpleAnim()
	{
		return null;
	}

	public void InitShadow(Sprite sprShadow)
	{
	}

	public virtual void InitShadow()
	{
	}

	public virtual bool ShouldSpawnMesh()
	{
		return false;
	}

	public virtual void RefreshMat()
	{
	}

	public float GetMeshCrackPct()
	{
		return 0f;
	}

	protected virtual void InitChildren()
	{
	}

	public virtual int GetNumActiveChildren()
	{
		return 0;
	}

	public virtual void OnChildDied(SubGridPieceObj child)
	{
	}

	public virtual void RegisterColliders()
	{
	}

	public virtual void DeregisterColliders()
	{
	}

	public StackState GetStackState()
	{
		return default(StackState);
	}

	public virtual bool IsBottomOfStack()
	{
		return false;
	}

	public virtual bool IsTopOfStack()
	{
		return false;
	}

	public virtual void UpdateWalk()
	{
	}

	public void SetPosition(Vector3 pos)
	{
	}

	public void AnimateEntry(float delay = 0f)
	{
	}

	public void CancelEntryAnim()
	{
	}

	public void SkipEntryDelay()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__66))]
	public virtual IEnumerator<float> _AnimateEntry(float delay = 0f)
	{
		return null;
	}

	protected virtual void OnEntryComplete()
	{
	}

	public virtual void DestroyTouchingPieces()
	{
	}

	public virtual void Reset()
	{
	}

	public void SetColor(Color c)
	{
	}

	public virtual bool IsChild()
	{
		return false;
	}

	public virtual bool OnAboutToHit(BallObj b, Vector2 hitNormal)
	{
		return false;
	}

	public virtual bool CanBeDamaged()
	{
		return false;
	}

	public virtual bool CanBePushedByWind()
	{
		return false;
	}

	public virtual HitType GetDefaultHitType()
	{
		return default(HitType);
	}

	public virtual bool Damage(int amt, DamageType dt, HitType hitType)
	{
		return false;
	}

	public virtual void OnHit(Vector3 hitPos, Vector2 hitNormal, DamageType dmgType)
	{
	}

	public virtual void HitFlash(DamageType dmgType)
	{
	}

	[IteratorStateMachine(typeof(_003C_HitFlash_003Ed__80))]
	protected virtual IEnumerator<float> _HitFlash(DamageType dmgType)
	{
		return null;
	}

	public virtual void RunBounce(float zIntensity, float len = 0.2f)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunBounce_003Ed__85))]
	private IEnumerator<float> _RunBounce(float zIntensity, float len)
	{
		return null;
	}

	public void RunBounceUnscaled(float zIntensity, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunBounceUnscaled_003Ed__87))]
	private IEnumerator<float> _RunBounceUnscaled(float zIntensity, float len)
	{
		return null;
	}

	public virtual void RunHitTilt(Vector2 hitNormal, Vector3 hitOffset, float intensity = 1f, float len = 0.2f)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunHitTilt_003Ed__92))]
	protected virtual IEnumerator<float> _RunHitTilt(Vector2 hitNormal, Vector3 hitOffset, float intensity, float len)
	{
		return null;
	}

	public Vector3 GetTiltRot(Vector2 hitNormal, Vector3 hitOffset)
	{
		return default(Vector3);
	}

	public void OnDamaged(DamageType dt)
	{
	}

	public virtual Vector3 GetDropPos(int idx)
	{
		return default(Vector3);
	}

	public Vector3 GetCenterPos()
	{
		return default(Vector3);
	}

	public virtual void DropDeathStuff()
	{
	}

	protected virtual void Remove()
	{
	}

	public float GetBotY()
	{
		return 0f;
	}

	public float GetTopY()
	{
		return 0f;
	}

	public virtual float GetPlatformTopZ()
	{
		return 0f;
	}

	public virtual float GetCharLocalTopZ()
	{
		return 0f;
	}

	public virtual float GetCharTopZ()
	{
		return 0f;
	}

	public virtual float GetVFXZ()
	{
		return 0f;
	}

	public virtual float GetLocalPlatformTopZ()
	{
		return 0f;
	}

	public float GetWorldTopZ()
	{
		return 0f;
	}

	public Vector2 GetSize()
	{
		return default(Vector2);
	}

	public float GetScale()
	{
		return 0f;
	}

	public virtual void AttackPlayer()
	{
	}

	public virtual void AttackTortoise(PetObjTortoise tortoise)
	{
	}

	public virtual bool ShouldPushPlayerBack()
	{
		return false;
	}

	public virtual bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	public virtual bool CanBeAttackedByAlly()
	{
		return false;
	}

	public virtual void RunAttack(GridPieceObj tgt)
	{
	}

	public bool IsPlayerInRange()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_RunAttack_003Ed__117))]
	protected virtual IEnumerator<float> _RunAttack(Transform tgt, Func<EnemyAttackResult> onAttackComplete)
	{
		return null;
	}

	private EnemyAttackResult OnAttackPlayer()
	{
		return default(EnemyAttackResult);
	}

	private void OnAttackTortoise()
	{
	}

	public void OnStateChanged()
	{
	}

	public virtual void Die(bool runDeathAnim)
	{
	}

	public virtual void PlayBreakSFX()
	{
	}

	[IteratorStateMachine(typeof(_003C_QueueRemove_003Ed__123))]
	protected virtual IEnumerator<float> _QueueRemove()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunDeath_003Ed__125))]
	protected virtual IEnumerator<float> _RunDeath()
	{
		return null;
	}

	protected virtual void OnDeathComplete()
	{
	}

	public void RunStackDrop(Vector3 tgtPos)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunStackDrop_003Ed__129))]
	private IEnumerator<float> _RunStackDrop(Vector3 tgtPos)
	{
		return null;
	}

	protected virtual void OnStackDropComplete()
	{
	}

	public virtual bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	private void RunFrozenSpikes()
	{
	}

	public void OnStatusEffectApplied(StatusEffect ef)
	{
	}

	public void OnStatusEffectRemoved(StatusEffect ef)
	{
	}

	private void DetachStackTopStatusEffInds(StatusEffectType t)
	{
	}

	[IteratorStateMachine(typeof(_003C_FadeStatusEffect_003Ed__136))]
	private IEnumerator<float> _FadeStatusEffect(string property, float startVal, float endVal, float len)
	{
		return null;
	}

	public virtual bool IsShielded(Vector2 hitNormal)
	{
		return false;
	}

	public void CacheDistToPos(Vector3 pos)
	{
	}

	public float GetDistSqrToCustomPos()
	{
		return 0f;
	}

	public virtual void ResetSprite()
	{
	}

	public virtual void ResetRot()
	{
	}

	public virtual void ResetScale()
	{
	}

	public virtual void InitEditor()
	{
	}

	protected void DetermineColType()
	{
	}

	protected void RecalculateColBounds()
	{
	}

	public virtual Vector3 GetLocalCenterPos()
	{
		return default(Vector3);
	}

	public virtual Vector3 GetWorldCenterPos()
	{
		return default(Vector3);
	}

	public void RunJustSpawned(Vector3 spawnPos, Vector3 tgtPos)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunJustSpawned_003Ed__151))]
	private IEnumerator<float> _RunJustSpawned(Vector3 spawnPos, Vector3 tgtPos)
	{
		return null;
	}

	public int GetFXSortLayer()
	{
		return 0;
	}

	public virtual float GetMoveDir()
	{
		return 0f;
	}

	public virtual bool HasUnevenFront()
	{
		return false;
	}

	public virtual float GetFrontYAtXPct(float pct)
	{
		return 0f;
	}

	public bool IsAlly()
	{
		return false;
	}

	public bool ShouldCancelPieceAttack()
	{
		return false;
	}

	public void CancelPieceAttack()
	{
	}

	[IteratorStateMachine(typeof(_003C_AttackEnemy_003Ed__160))]
	protected IEnumerator<float> _AttackEnemy(GridPieceObj tgt)
	{
		return null;
	}

	public virtual bool ShouldAffectFrontEnemyY()
	{
		return false;
	}

	public virtual float GetHealthPct()
	{
		return 0f;
	}

	protected virtual void OnGameSpeedChanged()
	{
	}

	public virtual Vector3 GetStatusEffectIndPos(StatusEffectType t)
	{
		return default(Vector3);
	}

	public virtual bool AlwaysPlayHitSFX()
	{
		return false;
	}

	public virtual void PlayHitSFX(Vector3 pos)
	{
	}

	public virtual void PlayHitVox()
	{
	}

	public virtual void PlayDeathVox()
	{
	}

	public bool CanChant()
	{
		return false;
	}

	public virtual bool PlayChantFX(bool playSFX)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_RunDelayedChant_003Ed__171))]
	private IEnumerator<float> _RunDelayedChant()
	{
		return null;
	}

	public virtual void CreateDeathParts()
	{
	}

	public virtual bool ShouldAIIgnore()
	{
		return false;
	}

	public void RunCurseImpact()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunCurseImpact_003Ed__175))]
	private IEnumerator<float> _RunCurseImpact()
	{
		return null;
	}
}
