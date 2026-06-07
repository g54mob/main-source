using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FXMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRunPorcupineTrail_003Ed__61 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObj tgt;

		public PartSys trail;

		public Vector3 startPos;

		public int minDamage;

		public int maxDamage;

		private float _003Clen_003E5__2;

		private float _003CstartTime_003E5__3;

		private GridPieceInst _003CtgtInst_003E5__4;

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
		public _003CRunPorcupineTrail_003Ed__61(int _003C_003E1__state)
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
	private sealed class _003C_RunLifestealTrail_003Ed__57 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public FXMgr _003C_003E4__this;

		public TrailVFX trail;

		public float healAmt;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

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
		public _003C_RunLifestealTrail_003Ed__57(int _003C_003E1__state)
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
	private sealed class _003C_RunSimplePart_003Ed__63 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public SpriteAnimator a;

		public Vector3 pos;

		public int layer;

		public SpriteAnimClip clip;

		public FXMgr _003C_003E4__this;

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
		public _003C_RunSimplePart_003Ed__63(int _003C_003E1__state)
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
	private sealed class _003C_RunThornsTrail_003Ed__59 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public TrailVFX trail;

		public float delay;

		public GridPieceObj tgt;

		public Vector3 startPos;

		public PassiveType pt;

		private float _003CstartTime_003E5__2;

		private float _003Clen_003E5__3;

		private GridPieceInst _003CtgtInst_003E5__4;

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
		public _003C_RunThornsTrail_003Ed__59(int _003C_003E1__state)
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

	public static FXMgr I;

	[NamedArray(typeof(PartSysType))]
	public SerializedObjectPool<PartSys>[] PartSysPool;

	private int _numPartSysInstantiatedThisFrame;

	[NamedArray(typeof(LineFXType))]
	public SerializedObjectPool<LineFX>[] LineFXPool;

	[NamedArray(typeof(StatusEffectType))]
	public SerializedObjectPool<StatusEffInd>[] StatusEffIndPool;

	[NamedArray(typeof(PlayerStatusEffectType))]
	public SerializedObjectPool<PlayerStatusEffInd>[] PlayerStatusEffIndPool;

	[NamedArray(typeof(TrailVFXType))]
	public SerializedObjectPool<TrailVFX>[] TrailVFXPool;

	[NamedArray(typeof(RadialVFXType))]
	public SerializedObjectPool<RadialVFX>[] RadialVFXPool;

	[NamedArray(typeof(BallAttachmentType))]
	public SerializedObjectPool<BallAttachment>[] BallAttachmentPool;

	[NonSerialized]
	public ObjectPool<BallVFXController>[] BallVFXPool;

	public SerializedObjectPool<BallVFXController> BabyVFXPool;

	public FastPool<DamageNumber> DamageNumberPool;

	private int _numDamageNumbersInstantiatedThisFrame;

	[NamedArray(typeof(TouchableTrailType))]
	public SerializedObjectPool<TouchableTrailObj>[] TouchTrailPool;

	[Header("Laser")]
	[NamedArray(typeof(LaserFXType))]
	public LaserFXInfo[] LaserInfo;

	public SerializedObjectPool<SpriteAnimator> SimplePartPool;

	public SerializedObjectPool<AlertSprite> AlertSpritePool;

	public SerializedObjectPool<RangeViz> RangeVizPool;

	public SerializedObjectPool<CannonballObj> CannonballPool;

	public SerializedObjectPool<EnemyLaserObj> EnemyLaserPool;

	public SerializedObjectPool<BoxRangeViz> BoxRangeVizPool;

	public SerializedObjectPool<NumberSprite> NumberSpritePool;

	private const int kMaxDamageNumbersPerFrame = 10;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnSceneAboutToChange()
	{
	}

	private void OnSceneLoaded()
	{
	}

	private void OnValidate()
	{
	}

	public bool ShouldLimitPartSys(PartSysType t)
	{
		return false;
	}

	public PartSys CreatePartSys(PartSysType t, Vector3 pos)
	{
		return null;
	}

	public PartSys PreparePartSys(PartSysType t, Vector3 pos)
	{
		return null;
	}

	public PartSys CreatePartSys(PartSysType t, Vector3 pos, Vector2 aimDir)
	{
		return null;
	}

	public PartSys CreateImpactPart(Vector3 pos, Vector2 aimDir)
	{
		return null;
	}

	public PartSys AttachPartSys(PartSysType t, Transform xfm)
	{
		return null;
	}

	public void RemovePartSys(PartSys ps)
	{
	}

	public TouchableTrailObj AttachTouchTrail(TouchableTrailType t, BallObj b)
	{
		return null;
	}

	public void RemoveTouchTrail(TouchableTrailObj t)
	{
	}

	public LineFX CreateLineFX(LineFXType type, DamageType dt, Vector3 startPos, Vector3 endPos, bool isBaby, float thickness = 0f)
	{
		return null;
	}

	public LineFX CreateLineFX(LineFXType type, DamageType dt, Vector3 pos, float range)
	{
		return null;
	}

	public LineFX CreateLineFX(LineFXType type, EnemyLaserObj l)
	{
		return null;
	}

	public void RemoveLineFX(LineFX fx)
	{
	}

	public StatusEffInd AttachStatusEffInd(StatusEffect ef, GridPieceObj p)
	{
		return null;
	}

	public void RemoveStatusEffInd(StatusEffInd ind)
	{
	}

	public PlayerStatusEffInd CreateStatusEffInd(PlayerStatusEffect ef, PlayerCharController pc)
	{
		return null;
	}

	public void RemoveStatusEffInd(PlayerStatusEffInd ind)
	{
	}

	public NumberSprite CreateCritNumber(Vector3 pos, DamageType dt, int num)
	{
		return null;
	}

	private NumberSprite GetDamageNumber()
	{
		return null;
	}

	public NumberSprite CreateNumberSprite(Vector3 pos, DamageType dt, int num)
	{
		return null;
	}

	public NumberSprite CreateNumberSprite(Vector3 pos, Color c, int num)
	{
		return null;
	}

	public NumberSprite CreateNumberSprite(Vector3 pos, Color c, int num, float size, Sprite startSprite, Sprite endSprite)
	{
		return null;
	}

	public NumberSprite CreateHarvestClockNum(Vector3 pos, float num)
	{
		return null;
	}

	public NumberSprite CreateResourcePart(Vector3 pos, ResourceType dt, int num, bool sendToUI)
	{
		return null;
	}

	public DamageNumber CreateTextPart(Vector3 pos, string str, Color c, bool isPrelocalized = false)
	{
		return null;
	}

	public void RemoveDamageNumber(DamageNumber num)
	{
	}

	public void RemoveNumberSprite(NumberSprite num)
	{
	}

	public void RunLifestealTrail(Vector3 pos, float healAmt)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunLifestealTrail_003Ed__57))]
	private IEnumerator<float> _RunLifestealTrail(TrailVFX trail, float healAmt)
	{
		return null;
	}

	public void RunThornsTrail(PassiveType pt, Vector3 startPos, GridPieceObj tgt, float delay)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunThornsTrail_003Ed__59))]
	private IEnumerator<float> _RunThornsTrail(PassiveType pt, TrailVFX trail, Vector3 startPos, GridPieceObj tgt, float delay)
	{
		return null;
	}

	public void RunPorcupineTrail(Vector3 startPos, GridPieceObj tgt, int minDamage, int maxDamage)
	{
	}

	[IteratorStateMachine(typeof(_003CRunPorcupineTrail_003Ed__61))]
	private IEnumerator<float> RunPorcupineTrail(PartSys trail, Vector3 startPos, GridPieceObj tgt, int minDamage, int maxDamage)
	{
		return null;
	}

	public SpriteAnimator RunSimplePart(Vector3 pos, SpriteAnimClip clip, int layer = -999)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunSimplePart_003Ed__63))]
	private IEnumerator<float> _RunSimplePart(SpriteAnimator a, Vector3 pos, SpriteAnimClip clip, int layer)
	{
		return null;
	}

	public void RemoveSimplePart(SpriteAnimator a)
	{
	}

	public AlertSprite CreateAlertSprite(GridPieceObj alerted)
	{
		return null;
	}

	public void RemoveAlertSprite(AlertSprite spr)
	{
	}

	public RangeViz CreateDangerRangeViz(Vector3 pos, float range)
	{
		return null;
	}

	public void RemoveRangeViz(RangeViz rViz)
	{
	}

	public BoxRangeViz CreateBoxRangeViz(EnemyLaserObj l)
	{
		return null;
	}

	public BoxRangeViz CreateBoxRangeViz(Vector3 startPos, Vector3 tgtPos, float thickness)
	{
		return null;
	}

	public void RemoveBoxRangeViz(BoxRangeViz viz)
	{
	}

	public CannonballObj CreateCannonball(CannonballType type, Vector3 srcPos, Vector3 tgtPos, float previewLen, float radius, int dmg)
	{
		return null;
	}

	public void RemoveCannonball(CannonballObj b)
	{
	}

	public EnemyLaserObj CreateEnemyLaser(LineFXType laserType, GridPieceObj shooter, Transform startXfm, Vector3 aimDir, float previewLen, float width, int dmg)
	{
		return null;
	}

	public void RemoveEnemyLaser(EnemyLaserObj b)
	{
	}

	public void InitBallVFXPool(HeroType t)
	{
	}

	public BallVFXController CreateBallVFX(HeroInst h, BallObj b)
	{
		return null;
	}

	public void RemoveBallVFX(BallVFXController vfx)
	{
	}

	public BallVFXController CreateBabyBallVFX(BallObj b)
	{
		return null;
	}

	public void RemoveBabyBallVFX(BallVFXController vfx)
	{
	}

	public TrailVFX CreateTrailVFX(TrailVFXType t, Vector3 pos)
	{
		return null;
	}

	public void RemoveTrailVFX(TrailVFX vfx)
	{
	}

	public RadialVFX CreateRadialVFX(RadialVFXType t, DamageType dt, Vector3 pos, float range)
	{
		return null;
	}

	public RadialVFX CreateRadialVFX(RadialVFXType t, BallObj b, float range)
	{
		return null;
	}

	public RadialVFX CreateRadialVFX(BallSpecialType special, HeroInst h, Vector3 pos)
	{
		return null;
	}

	public RadialVFX CreatePlayerRadialVFX(RadialVFXType t, PassiveInst p, float range)
	{
		return null;
	}

	public void RemoveRadialVFX(RadialVFX vfx)
	{
	}

	public BallAttachment CreateBallAttachment(BallAttachmentType t, BallObj b)
	{
		return null;
	}

	public void RemoveBallAttachment(BallAttachment b)
	{
	}

	private void OnGameSpeedChanged()
	{
	}
}
