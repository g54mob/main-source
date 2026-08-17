using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDirecter : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass131_0
	{
		public EnemyDirecter _003C_003E4__this;

		public int rnd;

		internal void _003COnlineAttackBehaviour3_003Eb__0()
		{
			_003C_003E4__this.PerformAttackBehaviour3(rnd);
		}
	}

	private sealed class _003C_003Ec__DisplayClass147_0
	{
		public EnemyDirecter _003C_003E4__this;

		public CoherenceSync mask;

		internal void _003COnMaskBrokenOnline_003Eb__0()
		{
			EnemyDMask component = mask.GetComponent<EnemyDMask>();
			_003C_003E4__this.PerformMaskBroken(component);
		}
	}

	private sealed class _003C_003Ec__DisplayClass169_0
	{
		public EnemyDirecter _003C_003E4__this;

		public float radiusMul;

		public Action _003C_003E9__0;

		internal void _003CShootEyes_003Eb__0()
		{
			EnemyDirecter enemyDirecter = _003C_003E4__this;
			enemyDirecter._shootingEyesManager.ShootOne(radiusMul);
		}
	}

	private sealed class _003C_003Ec__DisplayClass171_0
	{
		public EnemyDirecter _003C_003E4__this;

		public Vector3 whiteHandPos;

		internal void _003CDragInWhiteHand_003Eb__0()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A621A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			EnemyDirecter enemyDirecter = _003C_003E4__this;
			PhaserSprite rightHand = enemyDirecter._RightHand;
			rightHand._spriteAnimation.SetAnimation("pinch_do");
		}

		internal void _003CDragInWhiteHand_003Eb__1()
		{
			EnemyDirecter enemyDirecter = _003C_003E4__this;
			if ((object)_003C_003E4__this != null && (object)enemyDirecter._003CWhiteHand_003Ek__BackingField != null)
			{
				Transform transform = enemyDirecter._003CWhiteHand_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					EnemyDirecter enemyDirecter2 = _003C_003E4__this;
					whiteHandPos = ret;
					_ = 0;
					bool flag2 = (object)_003C_003E4__this == null;
					bool flag3 = (object)enemyDirecter2._RightHand == null;
					Transform transform2 = enemyDirecter2._RightHand.transform;
					bool flag4 = (object)transform2 == null;
					bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
					return;
				}
			}
			throw new NullReferenceException();
		}

		internal unsafe void _003CDragInWhiteHand_003Eb__2()
		{
			//IL_0023: Expected I4, but got O
			//IL_0031: Expected I4, but got O
			//IL_012c: Expected F4, but got O
			//IL_0192: Expected I, but got O
			//IL_01a8: Expected O, but got I
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			//IL_021f: Expected I, but got O
			//IL_039c: Expected O, but got I4
			//IL_043d: Expected O, but got I4
			//IL_0454: Expected I, but got I8
			//IL_048f: Expected O, but got F4
			//IL_0208: Expected I, but got I8
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				bool flag = (byte)(int)core._characters != 0;
				if ((int)(~core._characters) == 0)
				{
					List<CharacterController>.Enumerator enumerator2 = default(List<CharacterController>.Enumerator);
					object obj4;
					Action action;
					Timer timer;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					for (List<CharacterController>.Enumerator enumerator = (List<CharacterController>.Enumerator)core._characters; enumerator2.MoveNext(); obj4 = 24, ((Delegate)action).extra_arg = unchecked((nint)6447293568L), timer = Timers.Register(2f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false), enumerator = (List<CharacterController>.Enumerator)2f, flag = false)
					{
						_003C_003Ec__DisplayClass171_1 obj = new _003C_003Ec__DisplayClass171_1();
						bool flag2 = obj == null;
						CharacterController typeFromHandle = (CharacterController)(object)typeof(_003C_003Ec__DisplayClass171_1);
						if (!flag2)
						{
							obj.c = null;
							typeFromHandle = null;
							CharacterController c = obj.c;
							if ((object)obj.c != null)
							{
								c._currentHp = 0f;
								float num = obj.c.MaxHp();
								if (0 > (nint)enumerator)
								{
									float num2 = obj.c.MaxHp();
									c._currentHp = (float)enumerator;
								}
								if ((object)obj.c != null)
								{
									obj.c.Die();
									action = null;
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v8 (Il2CppMethodInfo)+8]");
									((Delegate)action).method_ptr = (IntPtr)0;
									((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass171_1._003CDragInWhiteHand_003Eb__3);
									((Delegate)action).m_target = obj;
									((Delegate)action).method_code = (IntPtr)action;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v8 (Il2CppMethodInfo)+4C]");
									object obj2 = (nint)0 >> 4;
									object obj3 = obj2 & 1;
									nint num4;
									if (obj3 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v8 (Il2CppMethodInfo)+52]");
										if ((nint)0 == 0)
										{
											num4 = unchecked((nint)6447293664L);
											continue;
										}
									}
									((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
									num4 = ((Delegate)action).method_ptr;
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[2];
					EnemyDirecter enemyDirecter = _003C_003E4__this;
					if ((object)_003C_003E4__this != null && array != null)
					{
						if ((object)enemyDirecter._RightHand != null)
						{
							GameManager core2 = GM.Core;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj5 = default(object);
							if (obj5 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						EnemyDirecter enemyDirecter2 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null)
						{
							if ((object)enemyDirecter2._003CWhiteHand_003Ek__BackingField != null)
							{
								GameManager core3 = GM.Core;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj6 = default(object);
								if (obj6 == null)
								{
									ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
									throw ex2;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								tweenConfig.scale = (float?)(object)1;
								tweenConfig.duration = 500f;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass171_1
	{
		public CharacterController c;

		internal void _003CDragInWhiteHand_003Eb__3()
		{
			c.RestoreTint();
		}
	}

	private int _003CStageIndex_003Ek__BackingField;

	private int _003CBrokenMasks_003Ek__BackingField;

	private bool _003CBreakEnabled_003Ek__BackingField;

	private MultiTargetTween _onEnterTween;

	private bool _isInvul;

	public float _Radius1;

	public float _Radius2;

	public float _Radius3;

	public float _Radius4;

	public float _Radius5;

	public float _Radius6;

	public float _Radius7;

	private float _myAngle1;

	private float _myAngle2;

	private float _myAngle3;

	private float _myAngle4;

	private float _myAngle5;

	private float _myAngle6;

	private float _myAngle7;

	private EnemyDMask _eye1;

	private EnemyDMask _eye2;

	private EnemyDMask _eye3;

	private EnemyDMask _eye4;

	private EnemyDMask _eye5;

	private EnemyDMask _eye6;

	private EnemyDMask _eye7;

	private bool _spawnedMasks;

	private TileSprite _stars1;

	private TileSprite _stars2;

	private PhaserSprite _LeftHand;

	private PhaserSprite _RightHand;

	public float _scale1;

	public float _scale2;

	public float _scale3;

	public float _scale4;

	public float _scale5;

	public float _scale6;

	public float _scale7;

	private int _currentPhase;

	public float _xOffset;

	private MultiTargetTween _moveTween0;

	public float _yOffset;

	private float _breakTimer;

	private float _breakDelay = 1000f;

	private MultiTargetTween _moveTween3;

	private MultiTargetTween _moveTween4;

	private ShootingEyesManager _shootingEyesManager;

	private float _attacksDurationMultiplier = 1f;

	private float _attackDelay = 5000f;

	private float _attackTimer;

	private int _attack1Index;

	private int _attack2Index;

	private int _attack3Index;

	private int _attack4Index;

	private float _003CTotalDamage_003Ek__BackingField;

	private int _003CDirectHits_003Ek__BackingField;

	private bool _003CHasHands_003Ek__BackingField;

	private PhaserSprite _003CWhiteHand_003Ek__BackingField;

	private float _angleUnit = (float)Math.PI / 360f;

	private ObjectPool _explosionPool;

	private SpriteMask _spriteMask;

	private List<MultiTargetTween> _allTweens;

	private float _movement0StartingOffset;

	private float _movement0TargetOffset;

	private float _movement3StartingOffset;

	private float _movement3TargetOffset;

	private float _movement4StartingOffset;

	private float _movement4TargetOffset;

	public CoherenceSync Eye1
	{
		get
		{
			EnemyDMask eye = _eye1;
			if ((object)_eye1 != null && ((UnityEngine.Object)eye).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask eye2 = _eye1;
				if ((object)_eye1 != null)
				{
					return ((EnemyController)eye2)._coherenceSync;
				}
				return (CoherenceSync)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask component = value.GetComponent<EnemyDMask>();
				_eye1 = component;
			}
			else
			{
				_eye1 = null;
			}
		}
	}

	public CoherenceSync Eye2
	{
		get
		{
			EnemyDMask eye = _eye2;
			if ((object)_eye2 != null && ((UnityEngine.Object)eye).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask eye2 = _eye2;
				if ((object)_eye2 != null)
				{
					return ((EnemyController)eye2)._coherenceSync;
				}
				return (CoherenceSync)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask component = value.GetComponent<EnemyDMask>();
				_eye2 = component;
			}
			else
			{
				_eye2 = null;
			}
		}
	}

	public CoherenceSync Eye3
	{
		get
		{
			EnemyDMask eye = _eye3;
			if ((object)_eye3 != null && ((UnityEngine.Object)eye).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask eye2 = _eye3;
				if ((object)_eye3 != null)
				{
					return ((EnemyController)eye2)._coherenceSync;
				}
				return (CoherenceSync)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask component = value.GetComponent<EnemyDMask>();
				_eye3 = component;
			}
			else
			{
				_eye3 = null;
			}
		}
	}

	public CoherenceSync Eye4
	{
		get
		{
			EnemyDMask eye = _eye4;
			if ((object)_eye4 != null && ((UnityEngine.Object)eye).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask eye2 = _eye4;
				if ((object)_eye4 != null)
				{
					return ((EnemyController)eye2)._coherenceSync;
				}
				return (CoherenceSync)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask component = value.GetComponent<EnemyDMask>();
				_eye4 = component;
			}
			else
			{
				_eye4 = null;
			}
		}
	}

	public CoherenceSync Eye5
	{
		get
		{
			EnemyDMask eye = _eye5;
			if ((object)_eye5 != null && ((UnityEngine.Object)eye).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask eye2 = _eye5;
				if ((object)_eye5 != null)
				{
					return ((EnemyController)eye2)._coherenceSync;
				}
				return (CoherenceSync)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask component = value.GetComponent<EnemyDMask>();
				_eye5 = component;
			}
			else
			{
				_eye5 = null;
			}
		}
	}

	public CoherenceSync Eye6
	{
		get
		{
			EnemyDMask eye = _eye6;
			if ((object)_eye6 != null && ((UnityEngine.Object)eye).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask eye2 = _eye6;
				if ((object)_eye6 != null)
				{
					return ((EnemyController)eye2)._coherenceSync;
				}
				return (CoherenceSync)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask component = value.GetComponent<EnemyDMask>();
				_eye6 = component;
			}
			else
			{
				_eye6 = null;
			}
		}
	}

	public CoherenceSync Eye7
	{
		get
		{
			EnemyDMask eye = _eye7;
			if ((object)_eye7 != null && ((UnityEngine.Object)eye).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask eye2 = _eye7;
				if ((object)_eye7 != null)
				{
					return ((EnemyController)eye2)._coherenceSync;
				}
				return (CoherenceSync)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyDMask component = value.GetComponent<EnemyDMask>();
				_eye7 = component;
			}
			else
			{
				_eye7 = null;
			}
		}
	}

	public int StageIndex
	{
		get
		{
			return _003CStageIndex_003Ek__BackingField;
		}
		set
		{
			_003CStageIndex_003Ek__BackingField = value;
		}
	}

	public int BrokenMasks
	{
		get
		{
			return _003CBrokenMasks_003Ek__BackingField;
		}
		set
		{
			_003CBrokenMasks_003Ek__BackingField = value;
		}
	}

	public bool BreakEnabled
	{
		get
		{
			return _003CBreakEnabled_003Ek__BackingField;
		}
		set
		{
			_003CBreakEnabled_003Ek__BackingField = value;
		}
	}

	private float TotalDamage
	{
		get
		{
			return _003CTotalDamage_003Ek__BackingField;
		}
		set
		{
			_003CTotalDamage_003Ek__BackingField = value;
		}
	}

	private int DirectHits
	{
		get
		{
			return _003CDirectHits_003Ek__BackingField;
		}
		set
		{
			_003CDirectHits_003Ek__BackingField = value;
		}
	}

	private bool HasHands
	{
		get
		{
			return _003CHasHands_003Ek__BackingField;
		}
		set
		{
			_003CHasHands_003Ek__BackingField = value;
		}
	}

	private PhaserSprite WhiteHand
	{
		get
		{
			return _003CWhiteHand_003Ek__BackingField;
		}
		set
		{
			_003CWhiteHand_003Ek__BackingField = value;
		}
	}

	private void MakeHandAnimations()
	{
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("hand_", 1, 4, "enemiesM", num);
		PhaserSprite leftHand = _LeftHand;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		leftHand._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand = _RightHand;
		rightHand._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("hand_italian_", 1, 2, "enemiesM", num);
		PhaserSprite leftHand2 = _LeftHand;
		leftHand2._spriteAnimation.AddAnimation("italian", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand2 = _RightHand;
		rightHand2._spriteAnimation.AddAnimation("italian", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("hand_point_", 1, 2, "enemiesM", num);
		PhaserSprite leftHand3 = _LeftHand;
		leftHand3._spriteAnimation.AddAnimation("point", animationFrames3, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand3 = _RightHand;
		rightHand3._spriteAnimation.AddAnimation("point", animationFrames3, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("hand_throw_", 1, 4, "enemiesM", num);
		PhaserSprite leftHand4 = _LeftHand;
		leftHand4._spriteAnimation.AddAnimation("throw", animationFrames3, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand4 = _RightHand;
		rightHand4._spriteAnimation.AddAnimation("throw", animationFrames3, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames5 = SpriteManager.GetAnimationFrames("hand_snap_", 1, 3, "enemiesM", num);
		PhaserSprite leftHand5 = _LeftHand;
		leftHand5._spriteAnimation.AddAnimation("snap_start", animationFrames5, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand5 = _RightHand;
		rightHand5._spriteAnimation.AddAnimation("snap_start", animationFrames5, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames6 = SpriteManager.GetAnimationFrames("hand_snap_", 4, 5, "enemiesM", num);
		PhaserSprite leftHand6 = _LeftHand;
		leftHand6._spriteAnimation.AddAnimation("snap_do", animationFrames6, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand6 = _RightHand;
		rightHand6._spriteAnimation.AddAnimation("snap_do", animationFrames6, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames7 = SpriteManager.GetAnimationFrames("hand_pinch_", 1, 2, "enemiesM", num);
		PhaserSprite leftHand7 = _LeftHand;
		leftHand7._spriteAnimation.AddAnimation("pinch_start", animationFrames7, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand7 = _RightHand;
		rightHand7._spriteAnimation.AddAnimation("pinch_start", animationFrames7, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames8 = SpriteManager.GetAnimationFrames("hand_pinch_", 3, 4, "enemiesM", num);
		PhaserSprite leftHand8 = _LeftHand;
		leftHand8._spriteAnimation.AddAnimation("pinch_do", animationFrames8, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand8 = _RightHand;
		rightHand8._spriteAnimation.AddAnimation("pinch_do", animationFrames8, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames9 = SpriteManager.GetAnimationFrames("hand_reveal_", 1, 2, "enemiesM", num);
		PhaserSprite leftHand9 = _LeftHand;
		leftHand9._spriteAnimation.AddAnimation("reveal_start", animationFrames9, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand9 = _RightHand;
		rightHand9._spriteAnimation.AddAnimation("reveal_start", animationFrames9, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames10 = SpriteManager.GetAnimationFrames("hand_reveal_", 3, 4, "enemiesM", num);
		PhaserSprite leftHand10 = _LeftHand;
		leftHand10._spriteAnimation.AddAnimation("reveal_do", animationFrames10, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand10 = _RightHand;
		rightHand10._spriteAnimation.AddAnimation("reveal_do", animationFrames10, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames11 = SpriteManager.GetAnimationFrames("hand_revive_", 1, 2, "enemiesM", num);
		PhaserSprite leftHand11 = _LeftHand;
		leftHand11._spriteAnimation.AddAnimation("revive_start", animationFrames11, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand11 = _RightHand;
		rightHand11._spriteAnimation.AddAnimation("revive_start", animationFrames11, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames12 = SpriteManager.GetAnimationFrames("hand_revive_", 3, 7, "enemiesM", num);
		PhaserSprite leftHand12 = _LeftHand;
		leftHand12._spriteAnimation.AddAnimation("revive_do", animationFrames12, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite rightHand12 = _RightHand;
		rightHand12._spriteAnimation.AddAnimation("revive_do", animationFrames12, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	protected override void Awake()
	{
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0176: Expected I4, but got I8
		//IL_0191: Expected I, but got O
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_0296: Expected I4, but got I8
		//IL_02b1: Expected I, but got O
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_03b1: Expected I4, but got I8
		//IL_03cc: Expected I, but got O
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Expected O, but got Unknown
		//IL_04cc: Expected I4, but got I8
		//IL_04e7: Expected I, but got O
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Expected O, but got Unknown
		//IL_05e7: Expected I4, but got I8
		//IL_0602: Expected I, but got O
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Expected O, but got Unknown
		//IL_0702: Expected I4, but got I8
		//IL_071d: Expected I, but got O
		//IL_07a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a8: Expected O, but got Unknown
		//IL_0818: Expected I4, but got I8
		//IL_0833: Expected I, but got O
		//IL_0906: Unknown result type (might be due to invalid IL or missing references)
		//IL_090b: Expected O, but got Unknown
		//IL_097b: Expected I4, but got I8
		//IL_0996: Expected I, but got O
		//IL_0a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a21: Expected O, but got Unknown
		//IL_0a91: Expected I4, but got I8
		//IL_0aac: Expected I, but got O
		//IL_0b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b37: Expected O, but got Unknown
		//IL_0ba7: Expected I4, but got I8
		//IL_0bc2: Expected I, but got O
		//IL_0c48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4d: Expected O, but got Unknown
		//IL_0cbd: Expected I4, but got I8
		//IL_0cd8: Expected I, but got O
		//IL_0d5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d63: Expected O, but got Unknown
		//IL_0dd3: Expected I4, but got I8
		//IL_0dee: Expected I, but got O
		//IL_0e74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e79: Expected O, but got Unknown
		//IL_0ee9: Expected I4, but got I8
		//IL_0f04: Expected I, but got O
		//IL_0f8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8f: Expected O, but got Unknown
		//IL_1004: Expected I4, but got I8
		//IL_101f: Expected I, but got O
		base.Awake();
		base._003CIsBoss_003Ek__BackingField = true;
		List<MultiTargetTween> allTweens = new List<MultiTargetTween>();
		_allTweens = allTweens;
		_003CBrokenMasks_003Ek__BackingField = 0;
		SetupMovementTargetOffsetValues();
		_003CHasHands_003Ek__BackingField = true;
		_xOffset = 0f;
		_yOffset = 0f;
		_Radius1 = 0.64f;
		_Radius2 = 0.64f;
		_Radius3 = 0.64f;
		_Radius4 = 0.64f;
		_Radius5 = 0.64f;
		_Radius6 = 0.64f;
		_Radius7 = 0.64f;
		_myAngle2 = 1.4451327f;
		_myAngle3 = (float)Math.PI * 41f / 50f;
		_myAngle4 = 3.8327432f;
		_myAngle5 = 4.4610615f;
		_myAngle6 = 4.9637165f;
		_myAngle7 = 5.215044f;
		TweenConfig tweenConfig = new TweenConfig();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		object obj2 = default(object);
		object obj = obj2 + 32;
		_ = 1050924810;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_Radius1", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 1009f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
			TweenConfig tweenConfig2 = new TweenConfig();
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			object obj4 = obj2 + 32;
			_ = 1050924810;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_Radius2", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig2.custom = dictionary2;
			tweenConfig2.duration = 1217f;
			tweenConfig2.yoyo = true;
			tweenConfig2.repeat = -1;
			object[] array2 = new object[1];
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
				TweenConfig tweenConfig3 = new TweenConfig();
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				object obj6 = obj2 + 32;
				_ = 1050924810;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value3 = default(object);
				bool flag3 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_Radius3", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig3.custom = dictionary3;
				tweenConfig3.duration = 1489f;
				tweenConfig3.yoyo = true;
				tweenConfig3.repeat = -1;
				object[] array3 = new object[1];
				nint num3 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig3.targets = array3;
					MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
					TweenConfig tweenConfig4 = new TweenConfig();
					Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
					object obj8 = obj2 + 32;
					_ = 1050924810;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object value4 = default(object);
					bool flag4 = ((Dictionary<object, object>)(object)dictionary4).TryInsert((object)"_Radius4", value4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					tweenConfig4.custom = dictionary4;
					tweenConfig4.duration = 1619f;
					tweenConfig4.yoyo = true;
					tweenConfig4.repeat = -1;
					object[] array4 = new object[1];
					nint num4 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj9 = default(object);
					if (obj9 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig4.targets = array4;
						MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
						TweenConfig tweenConfig5 = new TweenConfig();
						Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
						object obj10 = obj2 + 32;
						_ = 1050924810;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						object value5 = default(object);
						bool flag5 = ((Dictionary<object, object>)(object)dictionary5).TryInsert((object)"_Radius5", value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						tweenConfig5.custom = dictionary5;
						tweenConfig5.duration = 1861f;
						tweenConfig5.yoyo = true;
						tweenConfig5.repeat = -1;
						object[] array5 = new object[1];
						nint num5 = (nint)array5;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj11 = default(object);
						if (obj11 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							tweenConfig5.targets = array5;
							MultiTargetTween multiTargetTween5 = Tweens.Add(tweenConfig5);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
							TweenConfig tweenConfig6 = new TweenConfig();
							Dictionary<string, object> dictionary6 = new Dictionary<string, object>();
							object obj12 = obj2 + 32;
							_ = 1050924810;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							object value6 = default(object);
							bool flag6 = ((Dictionary<object, object>)(object)dictionary6).TryInsert((object)"_Radius6", value6, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							tweenConfig6.custom = dictionary6;
							tweenConfig6.duration = 2099f;
							tweenConfig6.yoyo = true;
							tweenConfig6.repeat = -1;
							object[] array6 = new object[1];
							nint num6 = (nint)array6;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj13 = default(object);
							if (obj13 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								tweenConfig6.targets = array6;
								MultiTargetTween multiTargetTween6 = Tweens.Add(tweenConfig6);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
								TweenConfig tweenConfig7 = new TweenConfig();
								Dictionary<string, object> dictionary7 = new Dictionary<string, object>();
								object obj14 = obj2 + 32;
								_ = 1050924810;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								object value7 = default(object);
								bool flag7 = ((Dictionary<object, object>)(object)dictionary7).TryInsert((object)"_Radius7", value7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								tweenConfig7.custom = dictionary7;
								tweenConfig7.duration = 2341f;
								tweenConfig7.yoyo = true;
								tweenConfig7.repeat = -1;
								object[] array7 = new object[1];
								nint num7 = (nint)array7;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj15 = default(object);
								if (obj15 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									tweenConfig7.targets = array7;
									MultiTargetTween multiTargetTween7 = Tweens.Add(tweenConfig7);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
									_scale1 = 2f;
									_scale2 = 1.75f;
									_scale3 = 1.5f;
									_scale4 = 1.25f;
									_scale5 = 1f;
									_scale6 = 0.75f;
									_scale7 = 0.5f;
									TweenConfig tweenConfig8 = new TweenConfig();
									Dictionary<string, object> dictionary8 = new Dictionary<string, object>();
									object obj16 = obj2 + 32;
									_ = 1056964608;
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
									object value8 = default(object);
									bool flag8 = ((Dictionary<object, object>)(object)dictionary8).TryInsert((object)"_scale1", value8, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									tweenConfig8.custom = dictionary8;
									tweenConfig8.duration = 1009f;
									tweenConfig8.yoyo = true;
									tweenConfig8.repeat = -1;
									object[] array8 = new object[1];
									nint num8 = (nint)array8;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj17 = default(object);
									if (obj17 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										tweenConfig8.targets = array8;
										MultiTargetTween multiTargetTween8 = Tweens.Add(tweenConfig8);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
										TweenConfig tweenConfig9 = new TweenConfig();
										Dictionary<string, object> dictionary9 = new Dictionary<string, object>();
										object obj18 = obj2 + 32;
										_ = 1061158912;
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
										object value9 = default(object);
										bool flag9 = ((Dictionary<object, object>)(object)dictionary9).TryInsert((object)"_scale2", value9, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
										tweenConfig9.custom = dictionary9;
										tweenConfig9.duration = 1217f;
										tweenConfig9.yoyo = true;
										tweenConfig9.repeat = -1;
										object[] array9 = new object[1];
										nint num9 = (nint)array9;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj19 = default(object);
										if (obj19 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											tweenConfig9.targets = array9;
											MultiTargetTween multiTargetTween9 = Tweens.Add(tweenConfig9);
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
											TweenConfig tweenConfig10 = new TweenConfig();
											Dictionary<string, object> dictionary10 = new Dictionary<string, object>();
											object obj20 = obj2 + 32;
											_ = 1065353216;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
											object value10 = default(object);
											bool flag10 = ((Dictionary<object, object>)(object)dictionary10).TryInsert((object)"_scale3", value10, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
											tweenConfig10.custom = dictionary10;
											tweenConfig10.duration = 1489f;
											tweenConfig10.yoyo = true;
											tweenConfig10.repeat = -1;
											object[] array10 = new object[1];
											nint num10 = (nint)array10;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj21 = default(object);
											if (obj21 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												tweenConfig10.targets = array10;
												MultiTargetTween multiTargetTween10 = Tweens.Add(tweenConfig10);
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
												TweenConfig tweenConfig11 = new TweenConfig();
												Dictionary<string, object> dictionary11 = new Dictionary<string, object>();
												object obj22 = obj2 + 32;
												_ = 1067450368;
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
												object value11 = default(object);
												bool flag11 = ((Dictionary<object, object>)(object)dictionary11).TryInsert((object)"_scale4", value11, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
												tweenConfig11.custom = dictionary11;
												tweenConfig11.duration = 1619f;
												tweenConfig11.yoyo = true;
												tweenConfig11.repeat = -1;
												object[] array11 = new object[1];
												nint num11 = (nint)array11;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj23 = default(object);
												if (obj23 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													tweenConfig11.targets = array11;
													MultiTargetTween multiTargetTween11 = Tweens.Add(tweenConfig11);
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
													TweenConfig tweenConfig12 = new TweenConfig();
													Dictionary<string, object> dictionary12 = new Dictionary<string, object>();
													object obj24 = obj2 + 32;
													_ = 1069547520;
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
													object value12 = default(object);
													bool flag12 = ((Dictionary<object, object>)(object)dictionary12).TryInsert((object)"_scale5", value12, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
													tweenConfig12.custom = dictionary12;
													tweenConfig12.duration = 1861f;
													tweenConfig12.yoyo = true;
													tweenConfig12.repeat = -1;
													object[] array12 = new object[1];
													nint num12 = (nint)array12;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj25 = default(object);
													if (obj25 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														tweenConfig12.targets = array12;
														MultiTargetTween multiTargetTween12 = Tweens.Add(tweenConfig12);
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
														TweenConfig tweenConfig13 = new TweenConfig();
														Dictionary<string, object> dictionary13 = new Dictionary<string, object>();
														object obj26 = obj2 + 32;
														_ = 1071644672;
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
														object value13 = default(object);
														bool flag13 = ((Dictionary<object, object>)(object)dictionary13).TryInsert((object)"_scale6", value13, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
														tweenConfig13.custom = dictionary13;
														tweenConfig13.duration = 2099f;
														tweenConfig13.yoyo = true;
														tweenConfig13.repeat = -1;
														object[] array13 = new object[1];
														nint num13 = (nint)array13;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj27 = default(object);
														if (obj27 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															tweenConfig13.targets = array13;
															MultiTargetTween multiTargetTween13 = Tweens.Add(tweenConfig13);
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
															TweenConfig tweenConfig14 = new TweenConfig();
															Dictionary<string, object> dictionary14 = new Dictionary<string, object>();
															object obj28 = obj2 + 32;
															_ = 1073741824;
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
															object value14 = default(object);
															bool flag14 = ((Dictionary<object, object>)(object)dictionary14).TryInsert((object)"_scale7", value14, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
															tweenConfig14.custom = dictionary14;
															tweenConfig14.duration = 2341f;
															tweenConfig14.yoyo = true;
															tweenConfig14.repeat = -1;
															object[] array14 = new object[1];
															nint num14 = (nint)array14;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj29 = default(object);
															if (obj29 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																tweenConfig14.targets = array14;
																MultiTargetTween multiTargetTween14 = Tweens.Add(tweenConfig14);
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																return;
															}
															ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
															throw ex;
														}
														ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
														throw ex2;
													}
													ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
													throw ex3;
												}
												ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
												throw ex4;
											}
											ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
											throw ex5;
										}
										ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
										throw ex6;
									}
									ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
									throw ex7;
								}
								ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
								throw ex8;
							}
							ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
							throw ex9;
						}
						ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
						throw ex10;
					}
					ArrayTypeMismatchException ex11 = new ArrayTypeMismatchException();
					throw ex11;
				}
				ArrayTypeMismatchException ex12 = new ArrayTypeMismatchException();
				throw ex12;
			}
			ArrayTypeMismatchException ex13 = new ArrayTypeMismatchException();
			throw ex13;
		}
		ArrayTypeMismatchException ex14 = new ArrayTypeMismatchException();
		throw ex14;
	}

	private void MakeMasks()
	{
		//IL_0519: Expected I, but got O
		//IL_055e: Expected I, but got O
		//IL_05a3: Expected I, but got O
		//IL_05e8: Expected I, but got O
		//IL_062d: Expected I, but got O
		//IL_0672: Expected I, but got O
		//IL_06b7: Expected I, but got O
		//IL_074c->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_0098->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_00d9->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_011c->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_013e->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_017f->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_01c2->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_01e4->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_0225->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_0268->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_028a->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_02cb->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_030e->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_0330->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_0371->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_03b4->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_03d6->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_0417->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_045a->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_047c->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_04bd->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_050c->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_0551->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_0596->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_05db->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_0620->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_0665->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_06aa->IL06d1: Incompatible stack heights: 1 vs 0
		//IL_06d1->IL0751: Incompatible stack heights: 1 vs 0
		if (_spawnedMasks)
		{
			return;
		}
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)core._stage != null)
				{
					Vector2 spawnPos = default(Vector2);
					bool forceSpawn = default(bool);
					GameObject gameObject = core._stage.SpawnEnemy(EnemyType.D_MASK_SUN, spawnPos, asRemote: false, forceSpawn);
					if ((object)gameObject != null)
					{
						EnemyDMask component = gameObject.GetComponent<EnemyDMask>();
						_eye1 = component;
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && (object)core2._stage != null)
						{
							GameObject gameObject2 = core2._stage.SpawnEnemy(EnemyType.D_MASK_MOON, spawnPos, asRemote: false, forceSpawn);
							if ((object)gameObject2 != null)
							{
								EnemyDMask component2 = gameObject2.GetComponent<EnemyDMask>();
								_eye2 = component2;
								GameManager core3 = GM.Core;
								if ((object)GM.Core != null && (object)core3._stage != null)
								{
									GameObject gameObject3 = core3._stage.SpawnEnemy(EnemyType.D_MASK_CITY, spawnPos, asRemote: false, forceSpawn);
									if ((object)gameObject3 != null)
									{
										EnemyDMask component3 = gameObject3.GetComponent<EnemyDMask>();
										_eye3 = component3;
										GameManager core4 = GM.Core;
										if ((object)GM.Core != null && (object)core4._stage != null)
										{
											GameObject gameObject4 = core4._stage.SpawnEnemy(EnemyType.D_MASK_WINDS, spawnPos, asRemote: false, forceSpawn);
											if ((object)gameObject4 != null)
											{
												EnemyDMask component4 = gameObject4.GetComponent<EnemyDMask>();
												_eye4 = component4;
												GameManager core5 = GM.Core;
												if ((object)GM.Core != null && (object)core5._stage != null)
												{
													GameObject gameObject5 = core5._stage.SpawnEnemy(EnemyType.D_MASK_VOLCANO, spawnPos, asRemote: false, forceSpawn);
													if ((object)gameObject5 != null)
													{
														EnemyDMask component5 = gameObject5.GetComponent<EnemyDMask>();
														_eye5 = component5;
														GameManager core6 = GM.Core;
														if ((object)GM.Core != null && (object)core6._stage != null)
														{
															GameObject gameObject6 = core6._stage.SpawnEnemy(EnemyType.D_MASK_GREED, spawnPos, asRemote: false, forceSpawn);
															if ((object)gameObject6 != null)
															{
																EnemyDMask component6 = gameObject6.GetComponent<EnemyDMask>();
																_eye6 = component6;
																GameManager core7 = GM.Core;
																if ((object)GM.Core != null && (object)core7._stage != null)
																{
																	GameObject gameObject7 = core7._stage.SpawnEnemy(EnemyType.D_MASK_VOID, spawnPos, asRemote: false, forceSpawn);
																	if ((object)gameObject7 != null)
																	{
																		EnemyDMask component7 = gameObject7.GetComponent<EnemyDMask>();
																		_eye7 = component7;
																		Transform eye = (Transform)(object)_eye1;
																		GameObject gameObject8 = base.gameObject;
																		if ((object)_eye1 != null)
																		{
																			nint num = (nint)eye;
																			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v189 @ r9_v13 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																			Transform eye2 = (Transform)(object)_eye2;
																			GameObject gameObject9 = base.gameObject;
																			if ((object)_eye2 != null)
																			{
																				nint num2 = (nint)eye2;
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v190 @ r9_v14 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																				Transform eye3 = (Transform)(object)_eye3;
																				GameObject gameObject10 = base.gameObject;
																				if ((object)_eye3 != null)
																				{
																					nint num3 = (nint)eye3;
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v191 @ r9_v15 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																					Transform eye4 = (Transform)(object)_eye4;
																					GameObject gameObject11 = base.gameObject;
																					if ((object)_eye4 != null)
																					{
																						nint num4 = (nint)eye4;
																						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v192 @ r9_v16 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																						Transform eye5 = (Transform)(object)_eye5;
																						GameObject gameObject12 = base.gameObject;
																						if ((object)_eye5 != null)
																						{
																							nint num5 = (nint)eye5;
																							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v193 @ r9_v17 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																							Transform eye6 = (Transform)(object)_eye6;
																							GameObject gameObject13 = base.gameObject;
																							if ((object)_eye6 != null)
																							{
																								nint num6 = (nint)eye6;
																								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v194 @ r9_v18 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																								Transform eye7 = (Transform)(object)_eye7;
																								GameObject gameObject14 = base.gameObject;
																								if ((object)_eye7 != null)
																								{
																									nint num7 = (nint)eye7;
																									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v672 @ r9_v19 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																									_spawnedMasks = true;
																									return;
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MakeSkulls()
	{
		//IL_0502: Expected I, but got O
		//IL_050a: Expected I, but got O
		//IL_051a: Expected O, but got I
		//IL_0556: Expected O, but got I
		//IL_0593: Expected O, but got I
		//IL_05d7: Expected O, but got I4
		//IL_05c9: Expected O, but got I4
		//IL_067a: Expected O, but got I
		//IL_0636: Expected O, but got I
		//IL_06ba: Expected I, but got O
		//IL_06c2: Expected I, but got O
		//IL_06d2: Expected O, but got I
		//IL_070e: Expected O, but got I
		//IL_074b: Expected O, but got I
		//IL_078f: Expected O, but got I4
		//IL_0781: Expected O, but got I4
		//IL_0832: Expected O, but got I
		//IL_07ee: Expected O, but got I
		//IL_0872: Expected I, but got O
		//IL_087a: Expected I, but got O
		//IL_088a: Expected O, but got I
		//IL_08c6: Expected O, but got I
		//IL_0903: Expected O, but got I
		//IL_0947: Expected O, but got I4
		//IL_0939: Expected O, but got I4
		//IL_09ea: Expected O, but got I
		//IL_09a6: Expected O, but got I
		//IL_0a2a: Expected I, but got O
		//IL_0a32: Expected I, but got O
		//IL_0a42: Expected O, but got I
		//IL_0a7e: Expected O, but got I
		//IL_0abb: Expected O, but got I
		//IL_0aff: Expected O, but got I4
		//IL_0af1: Expected O, but got I4
		//IL_0ba2: Expected O, but got I
		//IL_0b5e: Expected O, but got I
		//IL_0be2: Expected I, but got O
		//IL_0bea: Expected I, but got O
		//IL_0bfa: Expected O, but got I
		//IL_0c36: Expected O, but got I
		//IL_0c73: Expected O, but got I
		//IL_0cb7: Expected O, but got I4
		//IL_0ca9: Expected O, but got I4
		//IL_0d5a: Expected O, but got I
		//IL_0d16: Expected O, but got I
		//IL_0d9a: Expected I, but got O
		//IL_0da2: Expected I, but got O
		//IL_0db2: Expected O, but got I
		//IL_0dee: Expected O, but got I
		//IL_0e2b: Expected O, but got I
		//IL_0e41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e46: Expected O, but got Unknown
		//IL_0ea3: Expected O, but got I
		//IL_0ede: Expected I, but got O
		//IL_0ee6: Expected I, but got O
		//IL_0ef6: Expected O, but got I
		//IL_0f32: Expected O, but got I
		//IL_0f6f: Expected O, but got I
		//IL_0f85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8a: Expected O, but got Unknown
		//IL_0fe7: Expected O, but got I
		//IL_1084: Expected I, but got O
		//IL_10c9: Expected I, but got O
		//IL_110e: Expected I, but got O
		//IL_1153: Expected I, but got O
		//IL_1198: Expected I, but got O
		//IL_11dd: Expected I, but got O
		//IL_1222: Expected I, but got O
		//IL_12a9->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0085->IL1231: Incompatible stack heights: 1 vs 0
		//IL_00c6->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0109->IL1231: Incompatible stack heights: 1 vs 0
		//IL_012b->IL1231: Incompatible stack heights: 1 vs 0
		//IL_016c->IL1231: Incompatible stack heights: 1 vs 0
		//IL_01af->IL1231: Incompatible stack heights: 1 vs 0
		//IL_01d1->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0212->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0255->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0277->IL1231: Incompatible stack heights: 1 vs 0
		//IL_02b8->IL1231: Incompatible stack heights: 1 vs 0
		//IL_02fb->IL1231: Incompatible stack heights: 1 vs 0
		//IL_031d->IL1231: Incompatible stack heights: 1 vs 0
		//IL_035e->IL1231: Incompatible stack heights: 1 vs 0
		//IL_03a1->IL1231: Incompatible stack heights: 1 vs 0
		//IL_03c3->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0404->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0447->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0469->IL1231: Incompatible stack heights: 1 vs 0
		//IL_04aa->IL1231: Incompatible stack heights: 1 vs 0
		//IL_04ef->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0541->IL1231: Incompatible stack heights: 1 vs 0
		//IL_057e->IL1231: Incompatible stack heights: 1 vs 0
		//IL_065f->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0616->IL1231: Incompatible stack heights: 1 vs 0
		//IL_06a7->IL1231: Incompatible stack heights: 1 vs 0
		//IL_06f9->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0736->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0817->IL1231: Incompatible stack heights: 1 vs 0
		//IL_07ce->IL1231: Incompatible stack heights: 1 vs 0
		//IL_085f->IL1231: Incompatible stack heights: 1 vs 0
		//IL_08b1->IL1231: Incompatible stack heights: 1 vs 0
		//IL_08ee->IL1231: Incompatible stack heights: 1 vs 0
		//IL_09cf->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0986->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0a17->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0a69->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0aa6->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0b87->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0b3e->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0bcf->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0c21->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0c5e->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0d3f->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0cf6->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0d87->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0dd9->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0e16->IL1231: Incompatible stack heights: 1 vs 0
		//IL_1526->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0ecb->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0f1d->IL1231: Incompatible stack heights: 1 vs 0
		//IL_0f5a->IL1231: Incompatible stack heights: 1 vs 0
		//IL_154b->IL1231: Incompatible stack heights: 1 vs 0
		//IL_1005->IL1231: Incompatible stack heights: 1 vs 0
		//IL_1034->IL1231: Incompatible stack heights: 1 vs 0
		//IL_1077->IL1231: Incompatible stack heights: 1 vs 0
		//IL_10bc->IL1231: Incompatible stack heights: 1 vs 0
		//IL_1101->IL1231: Incompatible stack heights: 1 vs 0
		//IL_1146->IL1231: Incompatible stack heights: 1 vs 0
		//IL_118b->IL1231: Incompatible stack heights: 1 vs 0
		//IL_11d0->IL1231: Incompatible stack heights: 1 vs 0
		//IL_1215->IL1231: Incompatible stack heights: 1 vs 0
		//IL_1231->IL1256: Incompatible stack heights: 1 vs 0
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			DisappearEyes();
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)core._stage != null)
				{
					Vector2 spawnPos = default(Vector2);
					bool forceSpawn = default(bool);
					GameObject gameObject = core._stage.SpawnEnemy(EnemyType.D_SKULL, spawnPos, asRemote: false, forceSpawn);
					if ((object)gameObject != null)
					{
						EnemyDSkull component = gameObject.GetComponent<EnemyDSkull>();
						_eye1 = component;
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && (object)core2._stage != null)
						{
							GameObject gameObject2 = core2._stage.SpawnEnemy(EnemyType.D_SKULL, spawnPos, asRemote: false, forceSpawn);
							if ((object)gameObject2 != null)
							{
								EnemyDSkull component2 = gameObject2.GetComponent<EnemyDSkull>();
								_eye2 = component2;
								GameManager core3 = GM.Core;
								if ((object)GM.Core != null && (object)core3._stage != null)
								{
									GameObject gameObject3 = core3._stage.SpawnEnemy(EnemyType.D_SKULL, spawnPos, asRemote: false, forceSpawn);
									if ((object)gameObject3 != null)
									{
										EnemyDSkull component3 = gameObject3.GetComponent<EnemyDSkull>();
										_eye3 = component3;
										GameManager core4 = GM.Core;
										if ((object)GM.Core != null && (object)core4._stage != null)
										{
											GameObject gameObject4 = core4._stage.SpawnEnemy(EnemyType.D_SKULL, spawnPos, asRemote: false, forceSpawn);
											if ((object)gameObject4 != null)
											{
												EnemyDSkull component4 = gameObject4.GetComponent<EnemyDSkull>();
												_eye4 = component4;
												GameManager core5 = GM.Core;
												if ((object)GM.Core != null && (object)core5._stage != null)
												{
													GameObject gameObject5 = core5._stage.SpawnEnemy(EnemyType.D_SKULL, spawnPos, asRemote: false, forceSpawn);
													if ((object)gameObject5 != null)
													{
														EnemyDSkull component5 = gameObject5.GetComponent<EnemyDSkull>();
														_eye5 = component5;
														GameManager core6 = GM.Core;
														if ((object)GM.Core != null && (object)core6._stage != null)
														{
															GameObject gameObject6 = core6._stage.SpawnEnemy(EnemyType.D_EYE, spawnPos, asRemote: false, forceSpawn);
															if ((object)gameObject6 != null)
															{
																EnemyDSkull component6 = gameObject6.GetComponent<EnemyDSkull>();
																_eye6 = component6;
																GameManager core7 = GM.Core;
																if ((object)GM.Core != null && (object)core7._stage != null)
																{
																	GameObject gameObject7 = core7._stage.SpawnEnemy(EnemyType.D_EYE, spawnPos, asRemote: false, forceSpawn);
																	if ((object)gameObject7 != null)
																	{
																		EnemyDSkull component7 = gameObject7.GetComponent<EnemyDSkull>();
																		_eye7 = component7;
																		EnemyDMask eye = _eye1;
																		if ((object)_eye1 != null)
																		{
																			nint num = (nint)typeof(EnemyDSkull);
																			nint num2 = (nint)eye;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
																			object obj = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+130]");
																			nint num3 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
																			if (num3 >= 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+C8]");
																				object obj2 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v54+FFFFFFF8+v247 @ rax_v53*8]");
																				if (0 == (nint)typeof(EnemyDSkull))
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
																					object obj3 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v54+FFFFFFF8+v1699 @ rcx_v46*8]");
																					object obj4 = ((0 != (nint)typeof(EnemyDSkull)) ? ((object)0) : ((object)1));
																					bool flag2 = obj4 == null;
																					EnemyDMask enemyDMask = null;
																					if (!flag2)
																					{
																						enemyDMask = _eye1;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A623A]");
																					if ((nint)0 == 0)
																					{
																						_ = 1;
																					}
																					if ("eyes_1" != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rsi_v8 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
																						if ((nint)0 != 0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rsi_v8 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
																							PhaserSprite phaserSprite = ((PhaserSprite)0).setFrame("eyes_1", "enemiesM");
																							goto IL_0683;
																						}
																					}
																					else
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rsi_v8 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
																						if ((nint)0 != 0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rsi_v8 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
																							PhaserSprite phaserSprite2 = ((PhaserSprite)0).setVisible(visible: false);
																							goto IL_0683;
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1231;
		IL_0d63:
		EnemyDMask eye2 = _eye6;
		if ((object)_eye6 != null)
		{
			nint num4 = (nint)typeof(EnemyDSkull);
			nint num5 = (nint)eye2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r9_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r9_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v79+FFFFFFF8+v267 @ rax_v78*8]");
				if (0 == (nint)typeof(EnemyDSkull))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v79+FFFFFFF8+v2049 @ rcx_v66*8]");
					object obj8 = 0 - typeof(EnemyDSkull);
					bool flag3 = obj8 == null;
					bool flag4 = !flag3;
					Transform transform2 = null;
					if (!flag4)
					{
						transform2 = (Transform)(object)_eye6;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A623A]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdi_v14 (UnityEngine.Transform)+280]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdi_v14 (UnityEngine.Transform)+280]");
						PhaserSprite phaserSprite3 = ((PhaserSprite)0).setVisible(visible: false);
						EnemyDMask eye3 = _eye7;
						if ((object)_eye7 != null)
						{
							nint num7 = (nint)typeof(EnemyDSkull);
							nint num8 = (nint)eye3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+130]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
							if (num9 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+C8]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v84+FFFFFFF8+v271 @ rax_v83*8]");
								if (0 == (nint)typeof(EnemyDSkull))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v84+FFFFFFF8+v211 @ rdx_v45*8]");
									object obj12 = 0 - typeof(EnemyDSkull);
									bool flag5 = obj12 == null;
									bool flag6 = !flag5;
									EnemyDMask enemyDMask2 = null;
									if (!flag6)
									{
										enemyDMask2 = _eye7;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A623A]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbp_v7 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbp_v7 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
										PhaserSprite phaserSprite4 = ((PhaserSprite)0).setVisible(visible: false);
										if ((object)_eye6 != null)
										{
											_eye6.SetFlipX(flip: true);
											if ((object)_eye7 != null)
											{
												_eye7.SetFlipX(flip: true);
												Transform eye4 = (Transform)(object)_eye1;
												GameObject gameObject8 = base.gameObject;
												if ((object)_eye1 != null)
												{
													nint num10 = (nint)eye4;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v142 @ r9_v24 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
													Transform eye5 = (Transform)(object)_eye2;
													GameObject gameObject9 = base.gameObject;
													if ((object)_eye2 != null)
													{
														nint num11 = (nint)eye5;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v143 @ r9_v25 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
														Transform eye6 = (Transform)(object)_eye3;
														GameObject gameObject10 = base.gameObject;
														if ((object)_eye3 != null)
														{
															nint num12 = (nint)eye6;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v144 @ r9_v26 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
															Transform eye7 = (Transform)(object)_eye4;
															GameObject gameObject11 = base.gameObject;
															if ((object)_eye4 != null)
															{
																nint num13 = (nint)eye7;
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v145 @ r9_v27 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																Transform eye8 = (Transform)(object)_eye5;
																GameObject gameObject12 = base.gameObject;
																if ((object)_eye5 != null)
																{
																	nint num14 = (nint)eye8;
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v146 @ r9_v28 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																	Transform eye9 = (Transform)(object)_eye6;
																	GameObject gameObject13 = base.gameObject;
																	if ((object)_eye6 != null)
																	{
																		nint num15 = (nint)eye9;
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v147 @ r9_v29 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																		Transform eye10 = (Transform)(object)_eye7;
																		GameObject gameObject14 = base.gameObject;
																		if ((object)_eye7 != null)
																		{
																			nint num16 = (nint)eye10;
																			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1031 @ r9_v30 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																			return;
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1231;
		IL_1231:
		throw new NullReferenceException();
		IL_083b:
		EnemyDMask eye11 = _eye3;
		if ((object)_eye3 != null)
		{
			nint num17 = (nint)typeof(EnemyDSkull);
			nint num18 = (nint)eye11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+130]");
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
			if (num19 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+C8]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v64+FFFFFFF8+v255 @ rax_v63*8]");
				if (0 == (nint)typeof(EnemyDSkull))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v64+FFFFFFF8+v1839 @ rcx_v54*8]");
					object obj16 = ((0 != (nint)typeof(EnemyDSkull)) ? ((object)0) : ((object)1));
					bool flag7 = obj16 == null;
					EnemyDMask enemyDMask3 = null;
					if (!flag7)
					{
						enemyDMask3 = _eye3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A623A]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if ("eyes_3" != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rsi_v12 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rsi_v12 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
							PhaserSprite phaserSprite5 = ((PhaserSprite)0).setFrame("eyes_3", "enemiesM");
							goto IL_09f3;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rsi_v12 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rsi_v12 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
							PhaserSprite phaserSprite6 = ((PhaserSprite)0).setVisible(visible: false);
							goto IL_09f3;
						}
					}
				}
			}
		}
		goto IL_1231;
		IL_0bab:
		EnemyDMask eye12 = _eye5;
		if ((object)_eye5 != null)
		{
			nint num20 = (nint)typeof(EnemyDSkull);
			nint num21 = (nint)eye12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ r9_v20 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+130]");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
			if (num22 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ r9_v20 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+C8]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v74+FFFFFFF8+v263 @ rax_v73*8]");
				if (0 == (nint)typeof(EnemyDSkull))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
					object obj19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v74+FFFFFFF8+v1979 @ rcx_v62*8]");
					object obj20 = ((0 != (nint)typeof(EnemyDSkull)) ? ((object)0) : ((object)1));
					bool flag8 = obj20 == null;
					EnemyDMask enemyDMask4 = null;
					if (!flag8)
					{
						enemyDMask4 = _eye5;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A623A]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if ("eyes_5" != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rsi_v16 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rsi_v16 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
							PhaserSprite phaserSprite7 = ((PhaserSprite)0).setFrame("eyes_5", "enemiesM");
							goto IL_0d63;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rsi_v16 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rsi_v16 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
							PhaserSprite phaserSprite8 = ((PhaserSprite)0).setVisible(visible: false);
							goto IL_0d63;
						}
					}
				}
			}
		}
		goto IL_1231;
		IL_09f3:
		EnemyDMask eye13 = _eye4;
		if ((object)_eye4 != null)
		{
			nint num23 = (nint)typeof(EnemyDSkull);
			nint num24 = (nint)eye13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r9_v18 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+130]");
			nint num25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
			if (num25 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r9_v18 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+C8]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v69+FFFFFFF8+v259 @ rax_v68*8]");
				if (0 == (nint)typeof(EnemyDSkull))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
					object obj23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v69+FFFFFFF8+v1909 @ rcx_v58*8]");
					object obj24 = ((0 != (nint)typeof(EnemyDSkull)) ? ((object)0) : ((object)1));
					bool flag9 = obj24 == null;
					EnemyDMask enemyDMask5 = null;
					if (!flag9)
					{
						enemyDMask5 = _eye4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A623A]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if ("eyes_4" != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rsi_v14 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rsi_v14 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
							PhaserSprite phaserSprite9 = ((PhaserSprite)0).setFrame("eyes_4", "enemiesM");
							goto IL_0bab;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rsi_v14 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rsi_v14 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
							PhaserSprite phaserSprite10 = ((PhaserSprite)0).setVisible(visible: false);
							goto IL_0bab;
						}
					}
				}
			}
		}
		goto IL_1231;
		IL_0683:
		EnemyDMask eye14 = _eye2;
		if ((object)_eye2 != null)
		{
			nint num26 = (nint)typeof(EnemyDSkull);
			nint num27 = (nint)eye14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+130]");
			nint num28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
			if (num28 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDMask>)+C8]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v59+FFFFFFF8+v251 @ rax_v58*8]");
				if (0 == (nint)typeof(EnemyDSkull))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDSkull>)+130]");
					object obj27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v59+FFFFFFF8+v1769 @ rcx_v50*8]");
					object obj28 = ((0 != (nint)typeof(EnemyDSkull)) ? ((object)0) : ((object)1));
					bool flag10 = obj28 == null;
					EnemyDMask enemyDMask6 = null;
					if (!flag10)
					{
						enemyDMask6 = _eye2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A623A]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if ("eyes_2" != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rsi_v10 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rsi_v10 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
							PhaserSprite phaserSprite11 = ((PhaserSprite)0).setFrame("eyes_2", "enemiesM");
							goto IL_083b;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rsi_v10 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rsi_v10 (VampireSurvivors.Objects.Characters.Enemies.EnemyDMask)+280]");
							PhaserSprite phaserSprite12 = ((PhaserSprite)0).setVisible(visible: false);
							goto IL_083b;
						}
					}
				}
			}
		}
		goto IL_1231;
	}

	private void DisappearEyes()
	{
		if (GM.Core.IsStageHost)
		{
			EnemyController eye = _eye1;
			if (!eye._003CIsDead_003Ek__BackingField)
			{
				eye.Disappear();
			}
			EnemyController eye2 = _eye2;
			if (!eye2._003CIsDead_003Ek__BackingField)
			{
				eye2.Disappear();
			}
			EnemyController eye3 = _eye3;
			if (!eye3._003CIsDead_003Ek__BackingField)
			{
				eye3.Disappear();
			}
			EnemyController eye4 = _eye4;
			if (!eye4._003CIsDead_003Ek__BackingField)
			{
				eye4.Disappear();
			}
			EnemyController eye5 = _eye5;
			if (!eye5._003CIsDead_003Ek__BackingField)
			{
				eye5.Disappear();
			}
			EnemyController eye6 = _eye6;
			if (!eye6._003CIsDead_003Ek__BackingField)
			{
				eye6.Disappear();
			}
			EnemyController eye7 = _eye7;
			if (!eye7._003CIsDead_003Ek__BackingField)
			{
				eye7.Disappear();
			}
		}
	}

	private void MakeTreasures()
	{
		//IL_0506: Expected I, but got O
		//IL_054b: Expected I, but got O
		//IL_0590: Expected I, but got O
		//IL_05d5: Expected I, but got O
		//IL_061a: Expected I, but got O
		//IL_065f: Expected I, but got O
		//IL_06a4: Expected I, but got O
		//IL_072b->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0085->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_00c6->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0109->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_012b->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_016c->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_01af->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_01d1->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0212->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0255->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0277->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_02b8->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_02fb->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_031d->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_035e->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_03a1->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_03c3->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0404->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0447->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0469->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_04aa->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_04f9->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_053e->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0583->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_05c8->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_060d->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0652->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_0697->IL06b3: Incompatible stack heights: 1 vs 0
		//IL_06b3->IL06d8: Incompatible stack heights: 1 vs 0
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			DisappearEyes();
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)core._stage != null)
				{
					Vector2 spawnPos = default(Vector2);
					bool forceSpawn = default(bool);
					GameObject gameObject = core._stage.SpawnEnemy(EnemyType.D_CLUSTER_GEMS, spawnPos, asRemote: false, forceSpawn);
					if ((object)gameObject != null)
					{
						EnemyDMask component = gameObject.GetComponent<EnemyDMask>();
						_eye1 = component;
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && (object)core2._stage != null)
						{
							GameObject gameObject2 = core2._stage.SpawnEnemy(EnemyType.D_CLUSTER_COINS, spawnPos, asRemote: false, forceSpawn);
							if ((object)gameObject2 != null)
							{
								EnemyDMask component2 = gameObject2.GetComponent<EnemyDMask>();
								_eye2 = component2;
								GameManager core3 = GM.Core;
								if ((object)GM.Core != null && (object)core3._stage != null)
								{
									GameObject gameObject3 = core3._stage.SpawnEnemy(EnemyType.D_CLUSTER_GEMS, spawnPos, asRemote: false, forceSpawn);
									if ((object)gameObject3 != null)
									{
										EnemyDMask component3 = gameObject3.GetComponent<EnemyDMask>();
										_eye3 = component3;
										GameManager core4 = GM.Core;
										if ((object)GM.Core != null && (object)core4._stage != null)
										{
											GameObject gameObject4 = core4._stage.SpawnEnemy(EnemyType.D_CLUSTER_COINS, spawnPos, asRemote: false, forceSpawn);
											if ((object)gameObject4 != null)
											{
												EnemyDMask component4 = gameObject4.GetComponent<EnemyDMask>();
												_eye4 = component4;
												GameManager core5 = GM.Core;
												if ((object)GM.Core != null && (object)core5._stage != null)
												{
													GameObject gameObject5 = core5._stage.SpawnEnemy(EnemyType.D_CLUSTER_GEMS, spawnPos, asRemote: false, forceSpawn);
													if ((object)gameObject5 != null)
													{
														EnemyDMask component5 = gameObject5.GetComponent<EnemyDMask>();
														_eye5 = component5;
														GameManager core6 = GM.Core;
														if ((object)GM.Core != null && (object)core6._stage != null)
														{
															GameObject gameObject6 = core6._stage.SpawnEnemy(EnemyType.D_CLUSTER_COINS, spawnPos, asRemote: false, forceSpawn);
															if ((object)gameObject6 != null)
															{
																EnemyDMask component6 = gameObject6.GetComponent<EnemyDMask>();
																_eye6 = component6;
																GameManager core7 = GM.Core;
																if ((object)GM.Core != null && (object)core7._stage != null)
																{
																	GameObject gameObject7 = core7._stage.SpawnEnemy(EnemyType.D_CLUSTER_GEMS, spawnPos, asRemote: false, forceSpawn);
																	if ((object)gameObject7 != null)
																	{
																		EnemyDMask component7 = gameObject7.GetComponent<EnemyDMask>();
																		_eye7 = component7;
																		Transform eye = (Transform)(object)_eye1;
																		GameObject gameObject8 = base.gameObject;
																		if ((object)_eye1 != null)
																		{
																			nint num = (nint)eye;
																			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v109 @ r9_v12 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																			Transform eye2 = (Transform)(object)_eye2;
																			GameObject gameObject9 = base.gameObject;
																			if ((object)_eye2 != null)
																			{
																				nint num2 = (nint)eye2;
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v110 @ r9_v13 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																				Transform eye3 = (Transform)(object)_eye3;
																				GameObject gameObject10 = base.gameObject;
																				if ((object)_eye3 != null)
																				{
																					nint num3 = (nint)eye3;
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ r9_v14 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																					Transform eye4 = (Transform)(object)_eye4;
																					GameObject gameObject11 = base.gameObject;
																					if ((object)_eye4 != null)
																					{
																						nint num4 = (nint)eye4;
																						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v112 @ r9_v15 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																						Transform eye5 = (Transform)(object)_eye5;
																						GameObject gameObject12 = base.gameObject;
																						if ((object)_eye5 != null)
																						{
																							nint num5 = (nint)eye5;
																							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v113 @ r9_v16 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																							Transform eye6 = (Transform)(object)_eye6;
																							GameObject gameObject13 = base.gameObject;
																							if ((object)_eye6 != null)
																							{
																								nint num6 = (nint)eye6;
																								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v114 @ r9_v17 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																								Transform eye7 = (Transform)(object)_eye7;
																								GameObject gameObject14 = base.gameObject;
																								if ((object)_eye7 != null)
																								{
																									nint num7 = (nint)eye7;
																									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v543 @ r9_v18 (Il2CppClass<UnityEngine.Transform>)+358] (should have been resolved before IL gen)");
																									return;
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Shrink()
	{
		//IL_0055: Expected I, but got O
		//IL_00d1: Expected O, but got I4
		//IL_039b: Expected I, but got O
		//IL_03e5: Expected I, but got O
		//IL_02ae: Expected O, but got I4
		//IL_02ea: Expected I4, but got I8
		//IL_0189->IL0321: Incompatible stack heights: 1 vs 0
		//IL_01c5->IL0321: Incompatible stack heights: 1 vs 0
		//IL_01ef->IL0321: Incompatible stack heights: 1 vs 0
		//IL_0237->IL0321: Incompatible stack heights: 2 vs 0
		//IL_0289->IL0321: Incompatible stack heights: 3 vs 0
		//IL_0311->IL0321: Incompatible stack heights: 3 vs 0
		DisappearEyes();
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._enable = false;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					tweenConfig.duration = 1000f;
					tweenConfig.scale = (float?)(object)1;
					MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
					if (_allTweens != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
						Transform transform = base.transform;
						if ((object)transform != null)
						{
							bool flag = ((TweenConfig)(object)transform).targets == null;
							Transform.get_position_Injected((IntPtr)((TweenConfig)(object)transform).targets, out Vector3 _);
							GameObject gameObject = base.gameObject;
							Vector2 pos = default(Vector2);
							PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "items", "HeartRuby");
							int num2 = base.depth;
							if ((object)phaserSprite != null)
							{
								int num3 = num2 + 1;
								PhaserSprite phaserSprite2 = phaserSprite.setDepth(num3);
								if ((object)phaserSprite2 != null)
								{
									Transform transform2 = phaserSprite2.transform;
									if ((object)transform2 != null)
									{
										bool flag2 = ((TweenConfig)(object)transform2).targets == null;
										Transform.SetParent_Injected((IntPtr)((TweenConfig)(object)transform2).targets, (IntPtr)0, true);
										PhaserSprite phaserSprite3 = RenderingExtensions.SetScale(phaserSprite2, 1f);
										SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(phaserSprite2._spriteRenderer, 1f);
										TweenConfig tweenConfig2 = new TweenConfig();
										tweenConfig2._002Ector();
										object[] array2 = new object[1];
										if (array2 != null)
										{
											SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale((SpriteRenderer)(object)phaserSprite2, 1f);
											bool flag3 = (object)spriteRenderer2 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig2 != null)
											{
												tweenConfig2.targets = array2;
												tweenConfig2.scale = (float?)(object)1;
												tweenConfig2.duration = 1000f;
												tweenConfig2.yoyo = true;
												tweenConfig2.ease = Ease.InOutSine;
												tweenConfig2.repeat = -1;
												MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
												if (_allTweens != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
													return;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetupMovementTargetOffsetValues()
	{
		//IL_002f: Expected O, but got F4
		//IL_0073: Expected O, but got F4
		//IL_00b7: Expected O, but got F4
		//IL_00fb: Expected O, but got F4
		//IL_013f: Expected O, but got F4
		//IL_0183: Expected O, but got F4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj = renderer.width ^ -0f;
		float movement0TargetOffset = (float)obj * 0.2f;
		_movement0TargetOffset = movement0TargetOffset;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		object obj2 = renderer2.width ^ -0f;
		float movement0StartingOffset = (float)obj2 * 0.45f;
		_movement0StartingOffset = movement0StartingOffset;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		object obj3 = renderer3.width ^ -0f;
		float movement3TargetOffset = (float)obj3 * 0.25f;
		_movement3TargetOffset = movement3TargetOffset;
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer4 = s_scene4._renderer;
		object obj4 = renderer4.width ^ -0f;
		float movement3StartingOffset = (float)obj4 * 0.4f;
		_movement3StartingOffset = movement3StartingOffset;
		PhaserScene s_scene5 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer5 = s_scene5._renderer;
		object obj5 = renderer5.width ^ -0f;
		float movement4TargetOffset = (float)obj5 * 0.2f;
		_movement4TargetOffset = movement4TargetOffset;
		PhaserScene s_scene6 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer6 = s_scene6._renderer;
		object obj6 = renderer6.width ^ -0f;
		float movement4StartingOffset = (float)obj6 * 0.3f;
		_movement4StartingOffset = movement4StartingOffset;
	}

	private void Movement_Behaviour0(float deltaTime)
	{
		//IL_002f: Expected I, but got O
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		//IL_02fd: Invalid comparison between F4 and I4
		//IL_030c: Invalid comparison between F4 and I4
		//IL_00e2: Expected I4, but got I8
		//IL_0375: Expected O, but got I4
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_0249: Expected O, but got F4
		//IL_026e: Invalid comparison between F4 and I4
		//IL_027d: Invalid comparison between F4 and I4
		if (_moveTween0 == null)
		{
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_xOffset", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 2000f;
			tweenConfig.repeat = -1;
			tweenConfig.yoyo = true;
			tweenConfig.ease = Ease.InOutSine;
			TweenCallback onStart = delegate
			{
				_xOffset = _movement0StartingOffset;
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween moveTween = Tweens.Add(tweenConfig);
			_moveTween0 = moveTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
		}
		CharacterController playerOne = GM.Core.PlayerOne;
		float num2 = playerOne.PMoveSpeed();
		float num3 = _movement0TargetOffset * GameManager.PlayerPxSpeed;
		float num4 = num3 * 0.9f;
		float num5 = num4 * deltaTime;
		float2 float5 = base.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v23 (PhaserScene+Renderer)+38]");
		object obj2 = default(object);
		bool flag2;
		bool flag3;
		bool flag4;
		if (0 <= (nint)obj2)
		{
			float num6 = (float)obj2 - num5;
			float num7 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v23 (PhaserScene+Renderer)+38]");
			float num8 = num7 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v23 (PhaserScene+Renderer)+38]");
			object obj3 = num6 ^ 0;
			object obj4 = num6 ^ num8;
			object obj5 = obj3 & obj4;
			flag2 = (nint)obj5 < 0;
			flag3 = num8 < 0f;
			flag4 = num8 == 0f;
		}
		else
		{
			float num9 = (float)obj2 + num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v23 (PhaserScene+Renderer)+38]");
			float num10 = 0f - num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v23 (PhaserScene+Renderer)+38]");
			object obj6 = 0 ^ num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v23 (PhaserScene+Renderer)+38]");
			object obj7 = 0 ^ num10;
			object obj8 = obj6 & obj7;
			flag2 = (nint)obj8 < 0;
			flag3 = num10 < 0f;
			flag4 = num10 == 0f;
		}
		bool flag5 = flag3 == flag2;
		object obj9 = !flag4;
		object obj10 = flag5 & obj9;
		if (obj10 == null)
		{
		}
		float2 float6 = default(float2);
		base.position = float6;
	}

	private void Movement_Behaviour3(float deltaTime)
	{
		//IL_0061: Expected I, but got O
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0359: Invalid comparison between F4 and I4
		//IL_0368: Invalid comparison between F4 and I4
		//IL_03ce: Expected O, but got I4
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02a5: Expected O, but got F4
		//IL_02ca: Invalid comparison between F4 and I4
		//IL_02d9: Invalid comparison between F4 and I4
		//IL_013e: Expected I4, but got I8
		if (_moveTween0 != null)
		{
			_moveTween0.Kill();
		}
		if (_moveTween3 == null)
		{
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_xOffset", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_yOffset", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 1000f;
			tweenConfig.repeat = -1;
			tweenConfig.yoyo = true;
			tweenConfig.ease = Ease.InOutSine;
			TweenCallback onStart = delegate
			{
				_xOffset = _movement3StartingOffset;
				_yOffset = 0.08f;
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween moveTween = Tweens.Add(tweenConfig);
			_moveTween3 = moveTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
		}
		CharacterController playerOne = GM.Core.PlayerOne;
		float num2 = playerOne.PMoveSpeed();
		float num3 = _movement3TargetOffset * GameManager.PlayerPxSpeed;
		float num4 = num3 * 0.9f;
		float num5 = num4 * deltaTime;
		float2 float5 = base.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
		object obj2 = default(object);
		bool flag3;
		bool flag4;
		bool flag5;
		if (0 <= (nint)obj2)
		{
			float num6 = (float)obj2 - num5;
			float num7 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
			float num8 = num7 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
			object obj3 = num6 ^ 0;
			object obj4 = num6 ^ num8;
			object obj5 = obj3 & obj4;
			flag3 = (nint)obj5 < 0;
			flag4 = num8 < 0f;
			flag5 = num8 == 0f;
		}
		else
		{
			float num9 = (float)obj2 + num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
			float num10 = 0f - num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
			object obj6 = 0 ^ num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
			object obj7 = 0 ^ num10;
			object obj8 = obj6 & obj7;
			flag3 = (nint)obj8 < 0;
			flag4 = num10 < 0f;
			flag5 = num10 == 0f;
		}
		bool flag6 = flag4 == flag3;
		object obj9 = !flag5;
		object obj10 = flag6 & obj9;
		if (obj10 == null)
		{
		}
		float2 float6 = default(float2);
		base.position = float6;
	}

	private void Movement_Behaviour4(float deltaTime)
	{
		//IL_0061: Expected I, but got O
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0359: Invalid comparison between F4 and I4
		//IL_0368: Invalid comparison between F4 and I4
		//IL_03ce: Expected O, but got I4
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02a5: Expected O, but got F4
		//IL_02ca: Invalid comparison between F4 and I4
		//IL_02d9: Invalid comparison between F4 and I4
		//IL_013e: Expected I4, but got I8
		if (_moveTween3 != null)
		{
			_moveTween3.Kill();
		}
		if (_moveTween4 == null)
		{
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_xOffset", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_yOffset", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 2000f;
			tweenConfig.repeat = -1;
			tweenConfig.yoyo = true;
			tweenConfig.ease = Ease.InOutSine;
			TweenCallback onStart = delegate
			{
				_xOffset = _movement4StartingOffset;
				_yOffset = 0.08f;
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween moveTween = Tweens.Add(tweenConfig);
			_moveTween4 = moveTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
		}
		CharacterController playerOne = GM.Core.PlayerOne;
		float num2 = playerOne.PMoveSpeed();
		float num3 = _movement4TargetOffset * GameManager.PlayerPxSpeed;
		float num4 = num3 * 0.9f;
		float num5 = num4 * deltaTime;
		float2 float5 = base.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
		object obj2 = default(object);
		bool flag3;
		bool flag4;
		bool flag5;
		if (0 <= (nint)obj2)
		{
			float num6 = (float)obj2 - num5;
			float num7 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
			float num8 = num7 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
			object obj3 = num6 ^ 0;
			object obj4 = num6 ^ num8;
			object obj5 = obj3 & obj4;
			flag3 = (nint)obj5 < 0;
			flag4 = num8 < 0f;
			flag5 = num8 == 0f;
		}
		else
		{
			float num9 = (float)obj2 + num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
			float num10 = 0f - num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
			object obj6 = 0 ^ num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v24 (PhaserScene+Renderer)+38]");
			object obj7 = 0 ^ num10;
			object obj8 = obj6 & obj7;
			flag3 = (nint)obj8 < 0;
			flag4 = num10 < 0f;
			flag5 = num10 == 0f;
		}
		bool flag6 = flag4 == flag3;
		object obj9 = !flag5;
		object obj10 = flag6 & obj9;
		if (obj10 == null)
		{
		}
		float2 float6 = default(float2);
		base.position = float6;
	}

	private void CheckAttack()
	{
		//IL_005b: Expected O, but got I4
		//IL_0260: Expected O, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_021a: Expected I8, but got O
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		bool flag = _currentPhase == 0;
		if (!flag)
		{
			object obj = _currentPhase - 1;
			Action<long> action2;
			Action<long> onlineTrigger;
			Action singlePlayerTrigger;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (flag)
					{
						Attack_Behaviour3();
						return;
					}
					if ((nint)obj3 != 1)
					{
						return;
					}
					Action action = PerformAttackBehaviour4;
					action2 = null;
					onlineTrigger = action2;
					singlePlayerTrigger = action;
				}
				else
				{
					Action action3 = PerformAttackBehaviour2;
					action2 = null;
					onlineTrigger = action2;
					singlePlayerTrigger = action3;
				}
			}
			else
			{
				Action action4 = PerformAttackBehaviour1;
				action2 = null;
				onlineTrigger = action2;
				singlePlayerTrigger = action4;
			}
			((EnemyDirecter)(object)action2).OnlineAttackBehaviour4((long)this);
			TriggerAttackBehaviour(singlePlayerTrigger, onlineTrigger);
		}
		else
		{
			Debug.Log("<color=green>STARTING ATTACK BEHAVIOUR 0</color>");
			object obj4 = UnityEngine.Random.RandomRangeInt(0, 2);
			float moreZ = default(float);
			float rndDiv = default(float);
			if (obj4 == null)
			{
				GameManager core = GM.Core;
				Stage stage = core._stage;
				stage._stageEventManager.GenerateEnemySwarm(20000f, 50, EnemyType.BATSWARM, moreZ, rndDiv);
			}
			else if ((nint)obj4 == 1)
			{
				GameManager core2 = GM.Core;
				Stage stage2 = core2._stage;
				stage2._stageEventManager.GenerateEnemySwarm(60000f, 16, EnemyType.TRAINEE_Y, moreZ, rndDiv);
			}
		}
	}

	private void TriggerAttackBehaviour(Action singlePlayerTrigger, Action<long> onlineTrigger)
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: singlePlayerTrigger.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		else if (GM.Core.IsStageHost)
		{
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			bool flag = _coherenceSync.SendCommand(onlineTrigger, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	private void Attack_Behaviour0()
	{
		//IL_00dd: Expected O, but got I4
		Debug.Log("<color=green>STARTING ATTACK BEHAVIOUR 0</color>");
		object obj = UnityEngine.Random.RandomRangeInt(0, 2);
		float moreZ = default(float);
		float rndDiv = default(float);
		if (obj == null)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._stageEventManager.GenerateEnemySwarm(20000f, 50, EnemyType.BATSWARM, moreZ, rndDiv);
		}
		else if ((nint)obj == 1)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			stage2._stageEventManager.GenerateEnemySwarm(60000f, 16, EnemyType.TRAINEE_Y, moreZ, rndDiv);
		}
	}

	private void Attack_Behaviour1()
	{
		//IL_000f: Expected I8, but got O
		Action singlePlayerTrigger = PerformAttackBehaviour1;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineAttackBehaviour1((long)this);
		TriggerAttackBehaviour(singlePlayerTrigger, action);
	}

	public void OnlineAttackBehaviour1(long startingSimFrame)
	{
		Action onSyncedTimer = PerformAttackBehaviour1;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private unsafe void PerformAttackBehaviour1()
	{
		//IL_0274: Expected O, but got Ref
		//IL_0290: Expected O, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "<color=green>STARTING ATTACK BEHAVIOUR 1. Index: {0}</color>", (System.ParamsArray)(&obj));
		Debug.Log(message);
		int attack1Index = _attack1Index + 1;
		_attack1Index = attack1Index;
		ThrowEggR(0f, 0f);
		object obj2 = UnityEngine.Random.RandomRangeInt(0, 5);
		bool flag = obj2 == null;
		StageEventManager stageEventManager;
		int count;
		EnemyType enemyType;
		float duration;
		if (!flag)
		{
			object obj3 = obj2 - 1;
			if (!flag)
			{
				object obj4 = obj3 - 1;
				if (!flag)
				{
					object obj5 = obj4 - 1;
					if (!flag)
					{
						if ((nint)obj5 != 1)
						{
							return;
						}
						GameManager core = GM.Core;
						Stage stage = core._stage;
						stageEventManager = stage._stageEventManager;
						count = _attack1Index + 16;
						enemyType = EnemyType.TRAINEE_Y;
					}
					else
					{
						GameManager core2 = GM.Core;
						Stage stage2 = core2._stage;
						stageEventManager = stage2._stageEventManager;
						count = _attack1Index + 24;
						enemyType = EnemyType.SKULLINO;
					}
				}
				else
				{
					GameManager core3 = GM.Core;
					Stage stage3 = core3._stage;
					stageEventManager = stage3._stageEventManager;
					count = _attack1Index + 24;
					enemyType = EnemyType.MILK;
				}
			}
			else
			{
				GameManager core4 = GM.Core;
				Stage stage4 = core4._stage;
				stageEventManager = stage4._stageEventManager;
				count = _attack1Index + 24;
				enemyType = EnemyType.MUD;
			}
			duration = 60000f;
		}
		else
		{
			GameManager core5 = GM.Core;
			Stage stage5 = core5._stage;
			stageEventManager = stage5._stageEventManager;
			duration = 20000f;
			enemyType = EnemyType.BATSWARM;
			count = 50;
		}
		float moreZ = default(float);
		float rndDiv = default(float);
		stageEventManager.GenerateEnemySwarm(duration, count, enemyType, moreZ, rndDiv);
	}

	private void Attack_Behaviour2()
	{
		//IL_000f: Expected I8, but got O
		Action singlePlayerTrigger = PerformAttackBehaviour2;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineAttackBehaviour2((long)this);
		TriggerAttackBehaviour(singlePlayerTrigger, action);
	}

	public void OnlineAttackBehaviour2(long startingSimFrame)
	{
		Action onSyncedTimer = PerformAttackBehaviour2;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private unsafe void PerformAttackBehaviour2()
	{
		//IL_04d0: Expected O, but got Ref
		//IL_0125: Expected O, but got I4
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "<color=green>STARTING ATTACK BEHAVIOUR 2. Index: {0}</color>", (System.ParamsArray)(&obj));
		Debug.Log(message);
		int attack2Index = _attack2Index + 1;
		_attack2Index = attack2Index;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num = renderer2.width * 0.5f;
		float x = num + (float)renderer.screenCenter;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v20 (PhaserScene+Renderer)+38]");
		float y = 0f - -0.79999995f;
		ThrowEggL(x, y);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v20 (PhaserScene+Renderer)+38]");
		float y2 = 0f - 0.79999995f;
		ThrowEggR(x, y2);
		bool flag = _003CStageIndex_003Ek__BackingField == 0;
		float moreZ = default(float);
		float rndDiv = default(float);
		StageEventManager stageEventManager;
		EnemyType enemyType;
		int count2;
		float duration;
		if (!flag)
		{
			object obj2 = _003CStageIndex_003Ek__BackingField - 1;
			float num2;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					object obj4 = obj3 - 1;
					if (!flag)
					{
						if ((nint)obj4 != 1)
						{
							return;
						}
						GameManager core = GM.Core;
						Stage stage = core._stage;
						int count = _attack2Index + 16;
						stage._stageEventManager.GenerateEnemySwarm(60000f, count, EnemyType.TRAINEE_Y, moreZ, rndDiv);
						GameManager core2 = GM.Core;
						Stage stage2 = core2._stage;
						stageEventManager = stage2._stageEventManager;
						num2 = 60000f;
						enemyType = EnemyType.SKELETON;
						count2 = 24;
					}
					else
					{
						GameManager core3 = GM.Core;
						Stage stage3 = core3._stage;
						stage3._stageEventManager.GenerateEnemySwarm(60000f, 24, EnemyType.SKULOROSSO, moreZ, rndDiv);
						GameManager core4 = GM.Core;
						Stage stage4 = core4._stage;
						stageEventManager = stage4._stageEventManager;
						count2 = _attack2Index + 12;
						num2 = 60000f;
						enemyType = EnemyType.DULL0;
					}
				}
				else
				{
					GameManager core5 = GM.Core;
					Stage stage5 = core5._stage;
					stage5._stageEventManager.GenerateEnemySwarm(60000f, 12, EnemyType.LIZARD1_2, moreZ, rndDiv);
					GameManager core6 = GM.Core;
					Stage stage6 = core6._stage;
					stageEventManager = stage6._stageEventManager;
					count2 = _attack2Index + 24;
					num2 = 60000f;
					enemyType = EnemyType.FISHMAN_1;
				}
			}
			else
			{
				GameManager core7 = GM.Core;
				Stage stage7 = core7._stage;
				stage7._stageEventManager.GenerateEnemySwarm(60000f, 12, EnemyType.MUMMY, moreZ, rndDiv);
				GameManager core8 = GM.Core;
				Stage stage8 = core8._stage;
				stageEventManager = stage8._stageEventManager;
				count2 = _attack2Index + 12;
				num2 = 60000f;
				enemyType = EnemyType.GHOST;
			}
			duration = num2;
		}
		else
		{
			GameManager core9 = GM.Core;
			Stage stage9 = core9._stage;
			stage9._stageEventManager.GenerateEnemySwarm(20000f, 50, EnemyType.BATSWARM, moreZ, rndDiv);
			GameManager core10 = GM.Core;
			Stage stage10 = core10._stage;
			stageEventManager = stage10._stageEventManager;
			count2 = _attack2Index + 24;
			duration = 60000f;
			enemyType = EnemyType.ZOMBIE;
		}
		stageEventManager.GenerateEnemySwarm(duration, count2, enemyType, moreZ, rndDiv);
	}

	private void Attack_Behaviour3()
	{
		int rnd = UnityEngine.Random.RandomRangeInt(0, 5);
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			PerformAttackBehaviour3(rnd);
		}
		else if (GM.Core.IsStageHost)
		{
			Action<long, int> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			int param = default(int);
			bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
		}
	}

	public void OnlineAttackBehaviour3(long startingSimFrame, int rnd)
	{
		_003C_003Ec__DisplayClass131_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass131_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		CS_0024_003C_003E8__locals4.rnd = rnd;
		Action onSyncedTimer = delegate
		{
			CS_0024_003C_003E8__locals4._003C_003E4__this.PerformAttackBehaviour3(CS_0024_003C_003E8__locals4.rnd);
		};
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private unsafe void PerformAttackBehaviour3(int rnd)
	{
		//IL_028b: Expected O, but got Ref
		//IL_00bc: Expected O, but got I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "<color=green>STARTING ATTACK BEHAVIOUR 3. Index: {0}</color>", (System.ParamsArray)(&obj));
		Debug.Log(message);
		int attack3Index = _attack3Index + 1;
		_attack3Index = attack3Index;
		if (GM.Core.HasAPlayerGotRevivals() && _attack3Index > 3)
		{
			_attack3Index = 0;
			DragInWhiteHand();
		}
		bool flag = rnd == 0;
		float delay;
		int times;
		float radiusMul;
		if (!flag)
		{
			object obj2 = rnd - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (flag)
				{
					delay = 30f;
					times = 10;
					goto IL_02ab;
				}
				object obj4 = obj3 - 1;
				if (flag)
				{
					delay = 100f;
					radiusMul = 0.5f;
					times = 20;
					goto IL_0294;
				}
				if ((nint)obj4 == 1)
				{
					DamagingZone_Explosions(-200f);
					DamagingZone_Explosions(200f);
				}
			}
			else
			{
				DamagingZone_Explosions(-100f);
				DamagingZone_Explosions(100f);
			}
			goto IL_01d8;
		}
		delay = 60f;
		times = 5;
		goto IL_02ab;
		IL_02ab:
		radiusMul = 1f;
		goto IL_0294;
		IL_01d8:
		GameManager core = GM.Core;
		Stage stage = core._stage;
		int num = _attack3Index;
		if (_attack3Index > 12)
		{
			num = 12;
		}
		int count = num + 12;
		float moreZ = default(float);
		float rndDiv = default(float);
		stage._stageEventManager.GenerateEnemySwarm(60000f, count, EnemyType.D_WEAK_EYE, moreZ, rndDiv);
		return;
		IL_0294:
		ShootEyes(times, delay, radiusMul);
		goto IL_01d8;
	}

	private unsafe void DamagingZone_Explosions(float yOffset = 0f, bool follow = false, float duration = 10000f)
	{
		//IL_0065: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		//IL_01ba: Expected O, but got F4
		//IL_0242->IL01c6: Incompatible stack heights: 1 vs 0
		//IL_00a3->IL01c6: Incompatible stack heights: 1 vs 0
		//IL_00c0->IL01c6: Incompatible stack heights: 1 vs 0
		//IL_00ef->IL01c6: Incompatible stack heights: 1 vs 0
		//IL_015c->IL01c6: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_explosionPool != null)
				{
					object obj2 = default(object);
					GameObject obj = _explosionPool.GetObject((Vector3)(&ret), (Quaternion)(&obj2));
					Transform objectComponent = (Transform)(object)_explosionPool.GetObjectComponent<DamagingZone>(obj);
					GameManager core = GM.Core;
					if ((object)GM.Core != null && (object)objectComponent != null)
					{
						GameObject gameObject = objectComponent.gameObject;
						if (core._diContainer != null)
						{
							core._diContainer.InjectGameObject(gameObject);
							Camera main2 = Camera.main;
							Bounds bounds = CameraExtensions.OrthographicBounds(main2);
							object obj3 = default(object);
							float num = (float)obj3 * 2f;
							Camera main3 = Camera.main;
							if ((object)main3 != null)
							{
								Transform transform2 = main3.transform;
								float w = num * 100f;
								float num2 = _attacksDurationMultiplier * duration;
								float durationMillis = default(float);
								float hitBoxDelayMillis = default(float);
								string skinType = default(string);
								bool follow2 = default(bool);
								((DamagingZone)(object)objectComponent).Init(w, 100f, 12f, durationMillis, hitBoxDelayMillis, skinType, follow2, (Transform)num2);
								_ = 1;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Attack_Behaviour4()
	{
		//IL_000f: Expected I8, but got O
		Action singlePlayerTrigger = PerformAttackBehaviour4;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineAttackBehaviour4((long)this);
		TriggerAttackBehaviour(singlePlayerTrigger, action);
	}

	public void OnlineAttackBehaviour4(long startingSimFrame)
	{
		Action onSyncedTimer = PerformAttackBehaviour4;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private unsafe void PerformAttackBehaviour4()
	{
		//IL_02c6: Expected O, but got Ref
		//IL_01a5: Expected F4, but got O
		//IL_01ba: Expected F4, but got I
		//IL_0225: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		string message = string.FormatHelper((IFormatProvider)null, "<color=green>STARTING ATTACK BEHAVIOUR 4. Index: {0}</color>", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CHasSeenFinalFireworks_003Ek__BackingField && _attack4Index < 1)
		{
			DragInWhiteHand();
		}
		int attack4Index = _attack4Index + 1;
		_attack4Index = attack4Index;
		GameManager core2 = GM.Core;
		PhysicsGroup enemies = core2.Enemies;
		HashSet<PhaserGameObject> children = ((Group)enemies).children;
		if (children._count > 108)
		{
			return;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer4 = s_scene4._renderer;
		Ellipse ellipse = new Ellipse();
		float height = renderer4.height * 1.4f;
		float width = renderer3.width * 1.4f;
		ellipse._x = (float)renderer.screenCenter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rax_v25 (PhaserScene+Renderer)+38]");
		ellipse._y = 0f;
		ellipse._width = width;
		ellipse._height = height;
		List<Vector2> points = ellipse.GetPoints(5);
		Extensions.Shuffle(points);
		List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				GameManager core3 = GM.Core;
				bool flag = (object)GM.Core == null;
				nint num = (nint)typeof(GM);
				if (!flag)
				{
					bool isStageHost = GM.Core.IsStageHost;
					if ((object)core3._stage == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
					_ = 0;
					_ = 1;
					continue;
				}
				throw new NullReferenceException();
			}
			return;
		}
		throw new NullReferenceException();
	}

	public void TriggerPhase1()
	{
		//IL_000f: Expected I8, but got O
		Action singlePlayerTrigger = TriggerPhase1OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase1((long)this);
		TriggerPhase(singlePlayerTrigger, action);
	}

	public void OnlineTriggerPhase1(long startingSimFrame)
	{
		Action onSyncedTimer = TriggerPhase1OnClient;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void TriggerPhase1OnClient()
	{
		Debug.Log("<color=green>TRIGGERING PHASE 1</color>");
		PhaserSprite leftHand = _LeftHand;
		_currentPhase = 1;
		_attackDelay = 5000f;
		leftHand._spriteAnimation.SetAnimation("idle");
		PhaserSprite rightHand = _RightHand;
		rightHand._spriteAnimation.SetAnimation("idle");
		PhaserSprite phaserSprite = _LeftHand.setFlipY(flipY: true);
		PhaserSprite phaserSprite2 = _RightHand.setFlipY(flipY: true);
	}

	public void TriggerPhase2()
	{
		//IL_000f: Expected I8, but got O
		Action singlePlayerTrigger = TriggerPhase2OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase2((long)this);
		TriggerPhase(singlePlayerTrigger, action);
	}

	public void OnlineTriggerPhase2(long startingSimFrame)
	{
		Action onSyncedTimer = TriggerPhase2OnClient;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void TriggerPhase2OnClient()
	{
		//IL_006e: Expected I, but got O
		//IL_00c6: Expected I, but got O
		//IL_012a: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		Debug.Log("<color=green>TRIGGERING PHASE 2</color>");
		_currentPhase = 2;
		_attackDelay = 5000f;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_LeftHand != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_RightHand != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			_003CHasHands_003Ek__BackingField = false;
			AutoPositionHands();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
	}

	private void TriggerPhase(Action singlePlayerTrigger, Action<long> onlineTrigger)
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: singlePlayerTrigger.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		else if (GM.Core.IsStageHost)
		{
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			bool flag = _coherenceSync.SendCommand(onlineTrigger, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	private void AutoPositionHands()
	{
		//IL_0033: Expected O, but got I4
		//IL_0236: Expected I4, but got O
		//IL_02a4: Expected I4, but got O
		//IL_026f: Expected I4, but got O
		//IL_032d: Expected I4, but got O
		//IL_02fa: Expected I4, but got O
		//IL_03b4: Expected I4, but got O
		//IL_0381: Expected I4, but got O
		//IL_03dd: Expected O, but got I4
		//IL_03f9: Expected O, but got I4
		//IL_0424: Expected I4, but got O
		PhaserSprite phaserSprite = _RightHand.setFlipX(flipX: false);
		PhaserSprite phaserSprite2 = _RightHand.setOrigin(1f, (float?)(object)1);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num = renderer2.height * 0.5f;
		float y = num - 0.79999995f;
		PhaserSprite phaserSprite3 = _LeftHand.setPosition(renderer.width, y);
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		PhaserSprite phaserSprite4 = phaserSprite3.setDepth(renderer3.pixelHeight);
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer4 = s_scene4._renderer;
		PhaserScene s_scene5 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer5 = s_scene5._renderer;
		float num2 = renderer5.height * 0.5f;
		float y2 = num2 + 0.79999995f;
		PhaserSprite phaserSprite5 = _RightHand.setPosition(renderer4.width, y2);
		PhaserScene s_scene6 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer6 = s_scene6._renderer;
		PhaserSprite phaserSprite6 = phaserSprite5.setDepth(renderer6.pixelHeight);
		PhaserSprite phaserSprite7 = RenderingExtensions.SetScrollFactor(_LeftHand, 0f);
		PhaserSprite phaserSprite8 = RenderingExtensions.SetScrollFactor(_RightHand, 0f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[4];
		if ((object)_LeftHand != null)
		{
			PhaserSprite phaserSprite9 = RenderingExtensions.SetScrollFactor(_LeftHand, 0f);
			if ((object)phaserSprite9 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		PhaserSprite phaserSprite10 = RenderingExtensions.SetScrollFactor((PhaserSprite)(object)array, 0f, (byte)(int)_LeftHand != 0);
		if ((object)_RightHand != null)
		{
			PhaserSprite phaserSprite11 = RenderingExtensions.SetScrollFactor(_RightHand, 0f, (byte)(int)_LeftHand != 0);
			if ((object)phaserSprite11 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		PhaserSprite phaserSprite12 = RenderingExtensions.SetScrollFactor((PhaserSprite)(object)array, 0f, (byte)(int)_RightHand != 0);
		PhaserSprite leftHand = _LeftHand;
		Transform transform = leftHand._spriteRenderer.transform;
		if ((object)transform != null)
		{
			PhaserSprite phaserSprite13 = RenderingExtensions.SetScrollFactor((PhaserSprite)(object)transform, 0f, (byte)(int)_RightHand != 0);
			if ((object)phaserSprite13 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		PhaserSprite phaserSprite14 = RenderingExtensions.SetScrollFactor((PhaserSprite)(object)array, 0f, (byte)(int)transform != 0);
		PhaserSprite rightHand = _RightHand;
		Transform transform2 = rightHand._spriteRenderer.transform;
		if ((object)transform2 != null)
		{
			PhaserSprite phaserSprite15 = RenderingExtensions.SetScrollFactor((PhaserSprite)(object)transform2, 0f, (byte)(int)transform != 0);
			if ((object)phaserSprite15 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		PhaserSprite phaserSprite16 = RenderingExtensions.SetScrollFactor((PhaserSprite)(object)array, 0f, (byte)(int)transform2 != 0);
		tweenConfig.targets = array;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = 500f;
		tweenConfig.scaleY = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		PhaserSprite phaserSprite17 = RenderingExtensions.SetScrollFactor((PhaserSprite)(object)_allTweens, 0f, (byte)(int)transform2 != 0);
	}

	public void MakeMasksBreakable()
	{
		_breakTimer = 0f;
		_003CBreakEnabled_003Ek__BackingField = true;
		if (GM.Core.IsStageHost)
		{
			EnemyDMask eye = _eye1;
			if (!((EnemyController)eye)._003CIsDead_003Ek__BackingField)
			{
				eye._canBreak = true;
			}
			EnemyDMask eye2 = _eye2;
			if (!((EnemyController)eye2)._003CIsDead_003Ek__BackingField)
			{
				eye2._canBreak = true;
			}
			EnemyDMask eye3 = _eye3;
			if (!((EnemyController)eye3)._003CIsDead_003Ek__BackingField)
			{
				eye3._canBreak = true;
			}
			EnemyDMask eye4 = _eye4;
			if (!((EnemyController)eye4)._003CIsDead_003Ek__BackingField)
			{
				eye4._canBreak = true;
			}
			EnemyDMask eye5 = _eye5;
			if (!((EnemyController)eye5)._003CIsDead_003Ek__BackingField)
			{
				eye5._canBreak = true;
			}
			EnemyDMask eye6 = _eye6;
			if (!((EnemyController)eye6)._003CIsDead_003Ek__BackingField)
			{
				eye6._canBreak = true;
			}
			EnemyDMask eye7 = _eye7;
			if (!((EnemyController)eye7)._003CIsDead_003Ek__BackingField)
			{
				eye7._canBreak = true;
			}
		}
	}

	public void OnMaskBroken(EnemyDMask mask)
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			PerformMaskBroken(mask);
			return;
		}
		Action<long, CoherenceSync> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		object param = default(object);
		bool flag = _coherenceSync.SendCommand((Action<long, object>)action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void OnMaskBrokenOnline(long startingSimFrame, CoherenceSync mask)
	{
		_003C_003Ec__DisplayClass147_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass147_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		CS_0024_003C_003E8__locals4.mask = mask;
		Action onSyncedTimer = delegate
		{
			EnemyDMask component = CS_0024_003C_003E8__locals4.mask.GetComponent<EnemyDMask>();
			CS_0024_003C_003E8__locals4._003C_003E4__this.PerformMaskBroken(component);
		};
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void PerformMaskBroken(EnemyDMask mask)
	{
		//IL_002a: Expected O, but got I4
		//IL_009a: Expected O, but got F4
		((EnemyController)mask).Disappear();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float detune = (float)obj2 * -600f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Crystal12, soundConfig, 0f, 10, time);
		Action onComplete = delegate
		{
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("MaskBreakingShake");
			OnFreezeFinished();
		};
		GM.Core.FrameFreeze(onComplete);
	}

	private unsafe void OnFreezeFinished()
	{
		//IL_0221: Expected O, but got Ref
		int num = _003CBrokenMasks_003Ek__BackingField + 1;
		_003CBrokenMasks_003Ek__BackingField = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "MASK BROKEN. BROKEN MASKS: {0}", (System.ParamsArray)(&obj));
		Debug.Log(message);
		_breakTimer = 0f;
		if (GM.Core.IsStageHost)
		{
			EnemyDMask eye = _eye1;
			if (!((EnemyController)eye)._003CIsDead_003Ek__BackingField)
			{
				eye._canBreak = false;
			}
			EnemyDMask eye2 = _eye2;
			if (!((EnemyController)eye2)._003CIsDead_003Ek__BackingField)
			{
				eye2._canBreak = false;
			}
			EnemyDMask eye3 = _eye3;
			if (!((EnemyController)eye3)._003CIsDead_003Ek__BackingField)
			{
				eye3._canBreak = false;
			}
			EnemyDMask eye4 = _eye4;
			if (!((EnemyController)eye4)._003CIsDead_003Ek__BackingField)
			{
				eye4._canBreak = false;
			}
			EnemyDMask eye5 = _eye5;
			if (!((EnemyController)eye5)._003CIsDead_003Ek__BackingField)
			{
				eye5._canBreak = false;
			}
			EnemyDMask eye6 = _eye6;
			if (!((EnemyController)eye6)._003CIsDead_003Ek__BackingField)
			{
				eye6._canBreak = false;
			}
			EnemyDMask eye7 = _eye7;
			if (!((EnemyController)eye7)._003CIsDead_003Ek__BackingField)
			{
				eye7._canBreak = false;
			}
		}
	}

	public void TriggerPhase3()
	{
		//IL_000f: Expected I8, but got O
		Action singlePlayerTrigger = TriggerPhase3OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase3((long)this);
		TriggerPhase(singlePlayerTrigger, action);
	}

	public void OnlineTriggerPhase3(long startingSimFrame)
	{
		Action onSyncedTimer = TriggerPhase3OnClient;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void TriggerPhase3OnClient()
	{
		//IL_0079: Expected I, but got O
		//IL_00d1: Expected I, but got O
		//IL_0127: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		Debug.Log("<color=green>TRIGGERING PHASE 3</color>");
		_currentPhase = 3;
		_003CDirectHits_003Ek__BackingField = 0;
		MakeSkulls();
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_LeftHand != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_RightHand != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = 500f;
		tweenConfig.scaleY = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
	}

	public void TriggerPhase4()
	{
		//IL_000f: Expected I8, but got O
		Action singlePlayerTrigger = TriggerPhase4OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase4((long)this);
		TriggerPhase(singlePlayerTrigger, action);
	}

	public void OnlineTriggerPhase4(long startingSimFrame)
	{
		Action onSyncedTimer = TriggerPhase4OnClient;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void TriggerPhase4OnClient()
	{
		Debug.Log("<color=green>TRIGGERING PHASE 4</color>");
		_attackDelay = 500f;
		_currentPhase = 4;
		MakeTreasures();
	}

	public void TriggerPhase5()
	{
		//IL_000f: Expected I8, but got O
		Action singlePlayerTrigger = TriggerPhase5OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase5((long)this);
		TriggerPhase(singlePlayerTrigger, action);
	}

	public void OnlineTriggerPhase5(long startingSimFrame)
	{
		Action onSyncedTimer = TriggerPhase5OnClient;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void TriggerPhase5OnClient()
	{
		Debug.Log("<color=green>TRIGGERING PHASE 5</color>");
		_currentPhase = 5;
		Shrink();
	}

	private void ThrowEggR(float x, float y)
	{
		//IL_0044: Invalid comparison between F4 and I4
		PhaserSprite rightHand = _RightHand;
		rightHand._spriteAnimation.SetAnimation("throw");
		PhaserSprite phaserSprite = _RightHand.setFlipY(flipY: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187705B88h\"");
		Vector2 spawnPos;
		Vector2 vector = default(Vector2);
		Stage stage;
		if (x == 0f)
		{
			GameManager core = GM.Core;
			float x2 = _RightHand.X;
			float y2 = _RightHand.Y;
			spawnPos = vector;
			stage = core._stage;
		}
		else
		{
			GameManager core2 = GM.Core;
			stage = core2._stage;
			spawnPos = vector;
		}
		bool flag = default(bool);
		GameObject gameObject = stage.SpawnEnemy(EnemyType.BULLET_EGG, spawnPos, asRemote: false, flag);
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6217]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			PhaserSprite rightHand2 = _RightHand;
			rightHand2._spriteAnimation.SetAnimation("idle");
			PhaserSprite phaserSprite2 = _RightHand.setFlipY(flipY: true);
		};
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void ThrowEggL(float x, float y)
	{
		//IL_0044: Invalid comparison between F4 and I4
		PhaserSprite leftHand = _LeftHand;
		leftHand._spriteAnimation.SetAnimation("throw");
		PhaserSprite phaserSprite = _LeftHand.setFlipY(flipY: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187705D98h\"");
		Vector2 spawnPos;
		Vector2 vector = default(Vector2);
		Stage stage;
		if (x == 0f)
		{
			GameManager core = GM.Core;
			float x2 = _LeftHand.X;
			float y2 = _LeftHand.Y;
			spawnPos = vector;
			stage = core._stage;
		}
		else
		{
			GameManager core2 = GM.Core;
			stage = core2._stage;
			spawnPos = vector;
		}
		bool flag = default(bool);
		GameObject gameObject = stage.SpawnEnemy(EnemyType.BULLET_EGG, spawnPos, asRemote: false, flag);
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6218]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			PhaserSprite leftHand2 = _LeftHand;
			leftHand2._spriteAnimation.SetAnimation("idle");
			PhaserSprite phaserSprite2 = _LeftHand.setFlipY(flipY: true);
		};
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected override void OnUpdate()
	{
		//IL_056f: Expected O, but got F4
		//IL_0015: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		object obj = Time.deltaTime;
		float num2 = default(float);
		float num = num2 * 1000f;
		bool flag = _currentPhase == 0;
		if (!flag)
		{
			object obj2 = _currentPhase - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					object obj4 = obj3 - 1;
					if (!flag)
					{
						if ((nint)obj4 == 1)
						{
							Movement_Behaviour4(num2);
						}
					}
					else
					{
						Movement_Behaviour3(num2);
					}
					goto IL_00a8;
				}
			}
		}
		Movement_Behaviour0(num2);
		goto IL_00a8;
		IL_00a8:
		if (!((_attackTimer = num + _attackTimer) < _attackDelay))
		{
			_attackTimer = 0f;
			CheckAttack();
		}
		if (_003CBreakEnabled_003Ek__BackingField && (_breakTimer = num + _breakTimer) > _breakDelay)
		{
			_breakTimer = 0f;
			MakeMasksBreakable();
		}
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			BaseBody baseBody = body;
			ArcadeTransform arcadeTransform = baseBody._transform;
			float2 float5 = base.position;
			arcadeTransform.position = float5;
			float2 float6 = base.cachedPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v14 (PhaserScene+Renderer)+38]");
			object obj6 = default(object);
			object obj5 = obj6 - 0;
			float num3 = (float)obj5 * -100f;
			float num4 = num3 + 9f;
			ArcadeSprite arcadeSprite = setDepth(num4);
			TileSprite stars = _stars1;
			int num5 = base.depth;
			int sortingOrder = num5 + 1;
			stars._spriteRenderer.sortingOrder = sortingOrder;
			TileSprite stars2 = _stars2;
			int num6 = base.depth;
			int sortingOrder2 = num6 + 1;
			stars2._spriteRenderer.sortingOrder = sortingOrder2;
			if (_003CHasHands_003Ek__BackingField)
			{
				float2 float7 = base.cachedPosition;
				float2 float8 = base.position;
				float x = (float)float7 - 0.48f;
				float y = default(float);
				PhaserSprite phaserSprite = _LeftHand.setPosition(x, y);
				int num7 = base.depth;
				int num8 = num7 + 2;
				PhaserSprite phaserSprite2 = phaserSprite.setDepth(num8);
				float2 float9 = base.cachedPosition;
				float2 float10 = base.position;
				float x2 = (float)float9 + 0.48f;
				PhaserSprite phaserSprite3 = _RightHand.setPosition(x2, y);
				int num9 = base.depth;
				int num10 = num9 + 2;
				PhaserSprite phaserSprite4 = phaserSprite3.setDepth(num10);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addps xmm0,xmm6\"");
			float2 float11 = default(float2);
			float myAngle = (float)float11 + _myAngle1;
			float myAngle2 = (float)float11 + _myAngle2;
			float myAngle3 = (float)float11 + _myAngle7;
			_myAngle3 = _myAngle3;
			_myAngle1 = myAngle;
			_myAngle2 = myAngle2;
			_myAngle7 = myAngle3;
			float angle = default(float);
			float angle2 = default(float);
			float radius = default(float);
			UpdateEye(_eye1, float11, _scale1, angle, angle2, radius);
			UpdateEye(_eye2, float11, _scale2, angle, angle2, radius);
			UpdateEye(_eye3, float11, _scale3, angle, angle2, radius);
			UpdateEye(_eye4, float11, _scale4, angle, angle2, radius);
			UpdateEye(_eye5, float11, _scale5, angle, angle2, radius);
			UpdateEye(_eye6, float11, _scale6, angle, angle2, radius);
			UpdateEye(_eye7, float11, _scale7, angle, angle2, radius);
			Sprite sprite = _EnemyRenderer.sprite;
			_spriteMask.sprite = sprite;
			_shootingEyesManager.InternalUpdate();
			return;
		}
		throw new NullReferenceException();
	}

	private void UpdateEye(EnemyDMask eye, float2 playerPos, float scale, float angle1, float angle2, float radius)
	{
		//IL_0098: Expected O, but got I4
		if ((object)eye != null && ((UnityEngine.Object)eye).m_CachedPtr != (IntPtr)0)
		{
			float2 float5 = eye.cachedPosition;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj = obj2 - obj3;
			float num = (float)obj * -100f;
			float num2 = num + 73f;
			ArcadeSprite arcadeSprite = eye.setDepth(num2);
			ArcadeSprite arcadeSprite2 = eye.setScale(scale, (float?)(object)0);
			float2 float6 = base.cachedPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float2 float7 = default(float2);
			eye.position = float7;
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0091: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_01d6: Expected O, but got I4
		//IL_020a: Expected O, but got I4
		//IL_0492: Expected O, but got I4
		//IL_04ab: Expected O, but got I4
		//IL_04e9: Expected O, but got I4
		//IL_04e9: Expected O, but got I4
		//IL_04fd: Expected O, but got I4
		//IL_0079->IL0502: Incompatible stack heights: 1 vs 0
		//IL_00ad->IL0502: Incompatible stack heights: 1 vs 0
		//IL_00e1->IL0502: Incompatible stack heights: 1 vs 0
		//IL_0110->IL0502: Incompatible stack heights: 1 vs 0
		//IL_013a->IL0502: Incompatible stack heights: 1 vs 0
		//IL_01be->IL0502: Incompatible stack heights: 2 vs 0
		//IL_01f2->IL0502: Incompatible stack heights: 2 vs 0
		//IL_0226->IL0502: Incompatible stack heights: 2 vs 0
		//IL_0255->IL0502: Incompatible stack heights: 2 vs 0
		//IL_0284->IL0502: Incompatible stack heights: 2 vs 0
		//IL_02ae->IL0502: Incompatible stack heights: 2 vs 0
		//IL_0324->IL0502: Incompatible stack heights: 3 vs 0
		//IL_0346->IL0502: Incompatible stack heights: 3 vs 0
		//IL_0382->IL0502: Incompatible stack heights: 3 vs 0
		//IL_03a4->IL0502: Incompatible stack heights: 3 vs 0
		//IL_0635->IL0502: Incompatible stack heights: 3 vs 0
		//IL_0405->IL0502: Incompatible stack heights: 3 vs 0
		//IL_0427->IL0502: Incompatible stack heights: 3 vs 0
		//IL_0467->IL0502: Incompatible stack heights: 3 vs 0
		//IL_04c9->IL0502: Incompatible stack heights: 3 vs 0
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		MakeWhiteHand();
		MakeStars();
		MakeMasks();
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "enemiesM", "hand_01");
			if ((object)phaserSprite != null)
			{
				PhaserSprite phaserSprite2 = phaserSprite.setOrigin(1f, (float?)(object)1);
				if ((object)phaserSprite2 != null)
				{
					PhaserSprite phaserSprite3 = phaserSprite2.setScale(1f, (float?)(object)0);
					if ((object)phaserSprite3 != null)
					{
						PhaserSprite phaserSprite4 = phaserSprite3.setFlipY(flipY: false);
						if ((object)phaserSprite4 != null)
						{
							Transform transform2 = phaserSprite4.transform;
							if ((object)transform2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v37 (UnityEngine.Transform)+10]");
								bool flag2 = (nint)0 == 0;
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ rcx_v36 (Il2CppMethodInfo)+38]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v37 (UnityEngine.Transform)+10]");
								Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
								_LeftHand = phaserSprite4;
								GameObject gameObject2 = base.gameObject;
								PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "enemiesM", "hand_01");
								if ((object)phaserSprite5 != null)
								{
									PhaserSprite phaserSprite6 = phaserSprite5.setOrigin(0f, (float?)(object)1);
									if ((object)phaserSprite6 != null)
									{
										PhaserSprite phaserSprite7 = phaserSprite6.setScale(1f, (float?)(object)0);
										if ((object)phaserSprite7 != null)
										{
											PhaserSprite phaserSprite8 = phaserSprite7.setFlipY(flipY: false);
											if ((object)phaserSprite8 != null)
											{
												PhaserSprite phaserSprite9 = phaserSprite8.setFlipX(flipX: true);
												if ((object)phaserSprite9 != null)
												{
													Transform transform3 = phaserSprite9.transform;
													if ((object)transform3 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v52 (UnityEngine.Transform)+10]");
														bool flag3 = (nint)0 == 0;
														nint num2 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1115 @ rcx_v49 (Il2CppMethodInfo)+38]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v52 (UnityEngine.Transform)+10]");
														Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
														_RightHand = phaserSprite9;
														MakeHandAnimations();
														PhaserSprite leftHand = _LeftHand;
														if ((object)_LeftHand != null && (object)leftHand._spriteAnimation != null)
														{
															leftHand._spriteAnimation.SetAnimation("italian");
															PhaserSprite rightHand = _RightHand;
															if ((object)_RightHand != null && (object)rightHand._spriteAnimation != null)
															{
																rightHand._spriteAnimation.SetAnimation("italian");
																if ((object)HeroVfxManager._factory != null)
																{
																	ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.DamagingZones);
																	_explosionPool = pool;
																	GameManager core = GM.Core;
																	if ((object)GM.Core != null && core._diContainer != null)
																	{
																		ShootingEyesManager shootingEyesManager = core._diContainer.Instantiate<ShootingEyesManager>();
																		_shootingEyesManager = shootingEyesManager;
																		if (_shootingEyesManager != null)
																		{
																			_shootingEyesManager.Initialize();
																			base._003CIsCullable_003Ek__BackingField = false;
																			ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
																			ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
																			if (body != null)
																			{
																				BaseBody baseBody = body.setCircle(12f, (float?)(object)1, (float?)(object)1);
																				ArcadeSprite arcadeSprite3 = setScale(5f, (float?)(object)0);
																				return;
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		GameObject owner = _owner;
		if ((object)_owner != null && ((UnityEngine.Object)owner).m_CachedPtr != (IntPtr)0)
		{
			EnemyController component = _owner.GetComponent<EnemyController>();
			component.GetDamaged(value, showHitVfx, damageKb, WeaponType.VOID, hasKb: false);
		}
		if (!_isInvul)
		{
			int num = _003CDirectHits_003Ek__BackingField + 1;
			_003CDirectHits_003Ek__BackingField = num;
			float num2 = value + _003CTotalDamage_003Ek__BackingField;
			_003CTotalDamage_003Ek__BackingField = num2;
			WeaponType damageType2 = default(WeaponType);
			bool hasKb2 = default(bool);
			base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
		}
	}

	private void MakeStars()
	{
		//IL_05a4: Expected I4, but got O
		//IL_0605: Expected I4, but got I8
		//IL_0613: Expected O, but got I4
		//IL_065a: Expected I4, but got O
		//IL_0703: Expected I4, but got O
		//IL_06d2: Expected I4, but got O
		//IL_0744: Expected O, but got I4
		//IL_0780: Expected I4, but got I8
		//IL_07c2: Expected I4, but got O
		//IL_098d->IL07c7: Incompatible stack heights: 1 vs 0
		//IL_0513->IL07c7: Incompatible stack heights: 1 vs 0
		//IL_053a->IL07c7: Incompatible stack heights: 2 vs 0
		//IL_05c0->IL07c7: Incompatible stack heights: 2 vs 0
		//IL_0590->IL0590: Incompatible stack heights: 3 vs 2
		//IL_063f->IL07c7: Incompatible stack heights: 2 vs 0
		//IL_0698->IL07c7: Incompatible stack heights: 2 vs 0
		//IL_071f->IL07c7: Incompatible stack heights: 2 vs 0
		//IL_06ef->IL06ef: Incompatible stack heights: 3 vs 2
		//IL_07a7->IL07c7: Incompatible stack heights: 2 vs 0
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			PhaserScene.Renderer renderer = s_scene._renderer;
			if (s_scene._renderer != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer2 = s_scene2._renderer;
					if (s_scene2._renderer != null)
					{
						PhaserScene s_scene3 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer3 = s_scene3._renderer;
							if (s_scene3._renderer != null)
							{
								PhaserScene s_scene4 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene4._renderer != null)
								{
									float y = renderer2.height * 0.5f;
									float x = renderer.width * 0.5f;
									float height = default(float);
									string textureName = default(string);
									string spriteName = default(string);
									TileSprite component = RenderingExtensions.AddTileSprite(this, x, y, renderer3.width, height, textureName, spriteName);
									TileSprite tileSprite = RenderingExtensions.SetScrollFactor(component, 0f);
									PhaserScene s_scene5 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										PhaserScene.Renderer renderer4 = s_scene5._renderer;
										if (s_scene5._renderer != null && (object)tileSprite != null)
										{
											int num = renderer4.pixelHeight - 1;
											TileSprite stars = tileSprite.SetDepth(num);
											_stars1 = stars;
											if ((object)_stars1 != null)
											{
												GameObject gameObject = _stars1.gameObject;
												if ((object)gameObject != null)
												{
													((UnityEngine.Object)gameObject).SetName("Stars1");
													PhaserScene s_scene6 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null)
													{
														PhaserScene.Renderer renderer5 = s_scene6._renderer;
														if (s_scene6._renderer != null)
														{
															PhaserScene s_scene7 = ArcadePhysics.s_scene;
															if (ArcadePhysics.s_scene != null)
															{
																PhaserScene.Renderer renderer6 = s_scene7._renderer;
																if (s_scene7._renderer != null)
																{
																	PhaserScene s_scene8 = ArcadePhysics.s_scene;
																	if (ArcadePhysics.s_scene != null)
																	{
																		PhaserScene.Renderer renderer7 = s_scene8._renderer;
																		if (s_scene8._renderer != null)
																		{
																			PhaserScene s_scene9 = ArcadePhysics.s_scene;
																			if (ArcadePhysics.s_scene != null && s_scene9._renderer != null)
																			{
																				float y2 = renderer6.height * 0.5f;
																				float x2 = renderer5.width * 0.5f;
																				TileSprite component2 = RenderingExtensions.AddTileSprite(this, x2, y2, renderer7.width, height, textureName, spriteName);
																				TileSprite tileSprite2 = RenderingExtensions.SetScrollFactor(component2, 0f);
																				PhaserScene s_scene10 = ArcadePhysics.s_scene;
																				if (ArcadePhysics.s_scene != null)
																				{
																					PhaserScene.Renderer renderer8 = s_scene10._renderer;
																					if (s_scene10._renderer != null && (object)tileSprite2 != null)
																					{
																						int num2 = renderer8.pixelHeight - 1;
																						TileSprite stars2 = tileSprite2.SetDepth(num2);
																						_stars2 = stars2;
																						if ((object)_stars2 != null)
																						{
																							GameObject gameObject2 = _stars2.gameObject;
																							if ((object)gameObject2 != null)
																							{
																								((UnityEngine.Object)gameObject2).SetName("Stars2");
																								if ((object)_EnemyRenderer != null)
																								{
																									GameObject gameObject3 = _EnemyRenderer.gameObject;
																									if ((object)gameObject3 != null)
																									{
																										SpriteMask spriteMask = gameObject3.AddComponent<SpriteMask>();
																										_spriteMask = spriteMask;
																										TileSprite stars3 = _stars1;
																										if ((object)_stars1 != null)
																										{
																											object spriteRenderer = stars3._spriteRenderer;
																											if ((object)stars3._spriteRenderer != null)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdi_v11 (System.Object)+10]");
																												bool flag = (nint)0 == 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdi_v11 (System.Object)+10]");
																												SpriteRenderer.set_maskInteraction_Injected((IntPtr)0, SpriteMaskInteraction.VisibleInsideMask);
																												TileSprite stars4 = _stars2;
																												if ((object)_stars2 != null)
																												{
																													TileSprite spriteRenderer2 = (TileSprite)(object)stars4._spriteRenderer;
																													if ((object)stars4._spriteRenderer != null)
																													{
																														bool flag2 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
																														SpriteRenderer.set_maskInteraction_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, SpriteMaskInteraction.VisibleInsideMask);
																														TweenConfig tweenConfig = new TweenConfig();
																														object[] array = new object[1];
																														if (array != null)
																														{
																															if ((object)_stars2 != null)
																															{
																																TileSprite tileSprite3 = RenderingExtensions.SetScrollFactor(_stars2, 0f);
																																bool flag3 = (object)tileSprite3 == null;
																															}
																															TileSprite tileSprite4 = RenderingExtensions.SetScrollFactor((TileSprite)(object)array, 0f, (byte)(int)_stars2 != 0);
																															if (tweenConfig != null)
																															{
																																tweenConfig.targets = array;
																																tweenConfig.duration = 1000f;
																																tweenConfig.yoyo = true;
																																tweenConfig.repeat = -1;
																																tweenConfig.alpha = (float?)(object)1;
																																MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
																																if (_allTweens != null)
																																{
																																	TileSprite tileSprite5 = RenderingExtensions.SetScrollFactor((TileSprite)(object)_allTweens, 0f, (byte)(int)_stars2 != 0);
																																	TweenConfig tweenConfig2 = new TweenConfig();
																																	object[] array2 = new object[1];
																																	if (array2 != null)
																																	{
																																		if ((object)_stars1 != null)
																																		{
																																			TileSprite tileSprite6 = RenderingExtensions.SetScrollFactor(_stars1, 0f, (byte)(int)_stars2 != 0);
																																			bool flag4 = (object)tileSprite6 == null;
																																		}
																																		TileSprite tileSprite7 = RenderingExtensions.SetScrollFactor((TileSprite)(object)array2, 0f, (byte)(int)_stars1 != 0);
																																		if (tweenConfig2 != null)
																																		{
																																			tweenConfig2.targets = array2;
																																			tweenConfig2.alpha = (float?)(object)1;
																																			tweenConfig2.duration = 1000f;
																																			tweenConfig2.delay = 500f;
																																			tweenConfig2.yoyo = true;
																																			tweenConfig2.repeat = -1;
																																			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
																																			if (_allTweens != null)
																																			{
																																				TileSprite tileSprite8 = RenderingExtensions.SetScrollFactor((TileSprite)(object)_allTweens, 0f, (byte)(int)_stars1 != 0);
																																				return;
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void Die()
	{
	}

	public override void Disappear()
	{
	}

	private float Approach(float start, float end, float shift)
	{
		if (!(end > start))
		{
			float num = start - shift;
			if (num < end)
			{
				num = end;
			}
			return num;
		}
		float num2 = start + shift;
		if (num2 > end)
		{
			num2 = end;
		}
		return num2;
	}

	private void ShootEyes(int times, float delay, float radiusMul = 1f)
	{
		_003C_003Ec__DisplayClass169_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass169_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		CS_0024_003C_003E8__locals7.radiusMul = radiusMul;
		if (times <= 0)
		{
			return;
		}
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			Action onComplete = CS_0024_003C_003E8__locals7._003C_003E9__0;
			if (CS_0024_003C_003E8__locals7._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals7._003C_003E9__0 = delegate
				{
					EnemyDirecter enemyDirecter = CS_0024_003C_003E8__locals7._003C_003E4__this;
					enemyDirecter._shootingEyesManager.ShootOne(CS_0024_003C_003E8__locals7.radiusMul);
				});
			}
			float num = (float)(flag ? 1 : 0) * delay;
			float duration = num * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < times);
	}

	private void MakeWhiteHand()
	{
		//IL_010f: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "enemies3", "WhiteHand_i01");
		GameObject gameObject2 = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject2).SetName("WhiteHand");
		_003CWhiteHand_003Ek__BackingField = phaserSprite;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("WhiteHand_i0", 1, 4, "enemies3", num);
		PhaserSprite phaserSprite2 = _003CWhiteHand_003Ek__BackingField;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		phaserSprite2._spriteAnimation.AddAnimation("idle", animationFrames, 60, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite3 = _003CWhiteHand_003Ek__BackingField;
		phaserSprite3._spriteAnimation.SetAnimation("idle");
		PhaserSprite phaserSprite4 = _003CWhiteHand_003Ek__BackingField.setScale(2f, (float?)(object)0);
		PhaserSprite phaserSprite5 = _003CWhiteHand_003Ek__BackingField.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite phaserSprite6 = RenderingExtensions.SetScrollFactor(_003CWhiteHand_003Ek__BackingField, 0f);
		PhaserSprite phaserSprite7 = _003CWhiteHand_003Ek__BackingField.setDepth(10000);
	}

	private unsafe void DragInWhiteHand()
	{
		//IL_00a5: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		//IL_0657->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_00c3->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_00f6->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_0129->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_0184->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_01dd->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_01ff->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_023d->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_0269->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_0295->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_02df->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_030b->IL05b9: Incompatible stack heights: 1 vs 0
		//IL_03ee->IL03ee: Incompatible stack heights: 8 vs 7
		//IL_04fd->IL04fd: Incompatible stack heights: 12 vs 11
		_003C_003Ec__DisplayClass171_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass171_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			if ((object)_003CWhiteHand_003Ek__BackingField != null)
			{
				Transform transform = _003CWhiteHand_003Ek__BackingField.transform;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					if ((object)_003CWhiteHand_003Ek__BackingField != null)
					{
						PhaserSprite phaserSprite = _003CWhiteHand_003Ek__BackingField.setScale(2f, (float?)(object)0);
						if ((object)_RightHand != null)
						{
							PhaserSprite phaserSprite2 = _RightHand.setFlipX(flipX: true);
							if ((object)_RightHand != null)
							{
								PhaserSprite phaserSprite3 = _RightHand.setFlipY(flipY: false);
								if ((object)_RightHand != null)
								{
									PhaserSprite phaserSprite4 = _RightHand.setOrigin(1f, (float?)(object)1);
									PhaserSprite phaserSprite5 = RenderingExtensions.SetScale(_RightHand, 1f);
									PhaserSprite rightHand = _RightHand;
									if ((object)_RightHand != null)
									{
										SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(rightHand._spriteRenderer, 1f);
										PhaserSprite phaserSprite6 = RenderingExtensions.SetScale(_LeftHand, 0f);
										PhaserSprite rightHand2 = _RightHand;
										if ((object)_RightHand != null && (object)rightHand2._spriteAnimation != null)
										{
											rightHand2._spriteAnimation.SetAnimation("pinch_start");
											Camera main = Camera.main;
											if ((object)main != null)
											{
												Transform parent = main.transform;
												if ((object)_RightHand != null)
												{
													Transform transform2 = _RightHand.transform;
													if ((object)transform2 != null)
													{
														transform2.SetParent(parent, worldPositionStays: true);
														PhaserSprite phaserSprite7 = RenderingExtensions.SetScale(_RightHand, 4f);
														if ((object)_003CWhiteHand_003Ek__BackingField != null)
														{
															Transform transform3 = _003CWhiteHand_003Ek__BackingField.transform;
															if ((object)transform3 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v50 (UnityEngine.Transform)+10]");
																bool flag2 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v50 (UnityEngine.Transform)+10]");
																Transform.get_localPosition_Injected((IntPtr)0, out Vector3 ret);
																CS_0024_003C_003E8__locals13.whiteHandPos = ret;
																_ = 0;
																bool flag3 = (object)_RightHand == null;
																Transform transform4 = _RightHand.transform;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (VampireSurvivors.Objects.Characters.Enemies.EnemyDirecter+<>c__DisplayClass171_0)+1C]");
																float num = 0f + 0.19999999f;
																bool flag4 = (object)transform4 == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1083 @ rax_v57 (UnityEngine.Transform)+10]");
																bool flag5 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1083 @ rax_v57 (UnityEngine.Transform)+10]");
																Transform.set_localPosition_Injected((IntPtr)0, ref ret);
																TweenConfig tweenConfig = new TweenConfig();
																object[] array = new object[1];
																bool flag6 = (object)_RightHand == null;
																Transform transform5 = _RightHand.transform;
																bool flag7 = array == null;
																if ((object)transform5 != null)
																{
																	PhaserSprite phaserSprite8 = RenderingExtensions.SetScale((PhaserSprite)(object)transform5, num);
																	bool flag8 = (object)phaserSprite8 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																bool flag9 = tweenConfig == null;
																_ = 1148846080;
																_ = 1;
																MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
																bool flag10 = _allTweens == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																TweenConfig tweenConfig2 = new TweenConfig();
																bool flag11 = tweenConfig2 == null;
																_ = 1149861888;
																object[] array2 = new object[1];
																bool flag12 = array2 == null;
																if ((object)_003CWhiteHand_003Ek__BackingField != null)
																{
																	object obj = array2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj2 = default(object);
																	bool flag13 = obj2 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																_ = 1161527296;
																_ = 1;
																TweenCallback tweenCallback = delegate
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A621A]");
																	if ((nint)0 == 0)
																	{
																		_ = 1;
																	}
																	EnemyDirecter enemyDirecter = CS_0024_003C_003E8__locals13._003C_003E4__this;
																	PhaserSprite rightHand3 = enemyDirecter._RightHand;
																	rightHand3._spriteAnimation.SetAnimation("pinch_do");
																};
																TweenCallback tweenCallback2 = delegate
																{
																	EnemyDirecter enemyDirecter = CS_0024_003C_003E8__locals13._003C_003E4__this;
																	if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null && (object)enemyDirecter._003CWhiteHand_003Ek__BackingField != null)
																	{
																		Transform transform6 = enemyDirecter._003CWhiteHand_003Ek__BackingField.transform;
																		if ((object)transform6 != null)
																		{
																			bool flag15 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
																			Transform.get_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out Vector3 ret2);
																			EnemyDirecter enemyDirecter2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
																			CS_0024_003C_003E8__locals13.whiteHandPos = ret2;
																			_ = 0;
																			bool flag16 = (object)CS_0024_003C_003E8__locals13._003C_003E4__this == null;
																			bool flag17 = (object)enemyDirecter2._RightHand == null;
																			Transform transform7 = enemyDirecter2._RightHand.transform;
																			bool flag18 = (object)transform7 == null;
																			bool flag19 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
																			Transform.set_localPosition_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref ret2);
																			return;
																		}
																	}
																	throw new NullReferenceException();
																};
																TweenCallback tweenCallback3 = delegate
																{
																	//IL_0023: Expected I4, but got O
																	//IL_0031: Expected I4, but got O
																	//IL_012c: Expected F4, but got O
																	//IL_0192: Expected I, but got O
																	//IL_01a8: Expected O, but got I
																	//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
																	//IL_01b6: Expected O, but got Unknown
																	//IL_021f: Expected I, but got O
																	//IL_039c: Expected O, but got I4
																	//IL_043d: Expected O, but got I4
																	//IL_0454: Expected I, but got I8
																	//IL_048f: Expected O, but got F4
																	//IL_0208: Expected I, but got I8
																	GameManager core = GM.Core;
																	if ((object)GM.Core != null)
																	{
																		bool flag15 = (byte)(int)core._characters != 0;
																		if ((int)(~core._characters) == 0)
																		{
																			List<CharacterController>.Enumerator enumerator2 = default(List<CharacterController>.Enumerator);
																			object obj6;
																			Action action;
																			Timer timer;
																			bool useRealTime = default(bool);
																			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																			int repeat = default(int);
																			TimerType type = default(TimerType);
																			for (List<CharacterController>.Enumerator enumerator = (List<CharacterController>.Enumerator)core._characters; enumerator2.MoveNext(); obj6 = 24, ((Delegate)action).extra_arg = unchecked((nint)6447293568L), timer = Timers.Register(2f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false), enumerator = (List<CharacterController>.Enumerator)2f, flag15 = false)
																			{
																				_003C_003Ec__DisplayClass171_1 obj3 = new _003C_003Ec__DisplayClass171_1();
																				bool flag16 = obj3 == null;
																				CharacterController typeFromHandle = (CharacterController)(object)typeof(_003C_003Ec__DisplayClass171_1);
																				if (flag16)
																				{
																					throw new NullReferenceException();
																				}
																				obj3.c = null;
																				typeFromHandle = null;
																				CharacterController c = obj3.c;
																				if ((object)obj3.c == null)
																				{
																					throw new NullReferenceException();
																				}
																				c._currentHp = 0f;
																				float num2 = obj3.c.MaxHp();
																				if (0 > (nint)enumerator)
																				{
																					float num3 = obj3.c.MaxHp();
																					c._currentHp = (float)enumerator;
																				}
																				if ((object)obj3.c == null)
																				{
																					throw new NullReferenceException();
																				}
																				obj3.c.Die();
																				action = null;
																				nint num4 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v8 (Il2CppMethodInfo)+8]");
																				((Delegate)action).method_ptr = (IntPtr)0;
																				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass171_1._003CDragInWhiteHand_003Eb__3);
																				((Delegate)action).m_target = obj3;
																				((Delegate)action).method_code = (IntPtr)action;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v8 (Il2CppMethodInfo)+4C]");
																				object obj4 = (nint)0 >> 4;
																				object obj5 = obj4 & 1;
																				nint num5;
																				if (obj5 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v8 (Il2CppMethodInfo)+52]");
																					if ((nint)0 == 0)
																					{
																						num5 = unchecked((nint)6447293664L);
																						continue;
																					}
																				}
																				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
																				num5 = ((Delegate)action).method_ptr;
																			}
																			TweenConfig tweenConfig3 = new TweenConfig();
																			object[] array3 = new object[2];
																			EnemyDirecter enemyDirecter = CS_0024_003C_003E8__locals13._003C_003E4__this;
																			if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null && array3 != null)
																			{
																				if ((object)enemyDirecter._RightHand != null)
																				{
																					GameManager core2 = GM.Core;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																					object obj7 = default(object);
																					if (obj7 == null)
																					{
																						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
																						throw ex;
																					}
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				EnemyDirecter enemyDirecter2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
																				if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
																				{
																					if ((object)enemyDirecter2._003CWhiteHand_003Ek__BackingField != null)
																					{
																						GameManager core3 = GM.Core;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																						object obj8 = default(object);
																						if (obj8 == null)
																						{
																							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
																							throw ex2;
																						}
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					if (tweenConfig3 != null)
																					{
																						tweenConfig3.targets = array3;
																						tweenConfig3.scale = (float?)(object)1;
																						tweenConfig3.duration = 500f;
																						MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
																						return;
																					}
																				}
																			}
																		}
																	}
																	throw new NullReferenceException();
																};
																MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
																bool flag14 = _allTweens == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																return;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CMovement_Behaviour0_003Eb__118_0()
	{
		_xOffset = _movement0StartingOffset;
	}

	private void _003CMovement_Behaviour3_003Eb__119_0()
	{
		_xOffset = _movement3StartingOffset;
		_yOffset = 0.08f;
	}

	private void _003CMovement_Behaviour4_003Eb__120_0()
	{
		_xOffset = _movement4StartingOffset;
		_yOffset = 0.08f;
	}

	private void _003CTriggerPhase2OnClient_003Eb__142_0()
	{
		_003CHasHands_003Ek__BackingField = false;
		AutoPositionHands();
	}

	private void _003CPerformMaskBroken_003Eb__148_0()
	{
		ProCamera2DShake instance = ProCamera2DShake.Instance;
		instance.Shake("MaskBreakingShake");
		OnFreezeFinished();
	}

	private void _003CThrowEggR_003Eb__159_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6217]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite rightHand = _RightHand;
		rightHand._spriteAnimation.SetAnimation("idle");
		PhaserSprite phaserSprite = _RightHand.setFlipY(flipY: true);
	}

	private void _003CThrowEggL_003Eb__160_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6218]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite leftHand = _LeftHand;
		leftHand._spriteAnimation.SetAnimation("idle");
		PhaserSprite phaserSprite = _LeftHand.setFlipY(flipY: true);
	}
}
