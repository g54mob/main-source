using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Custos_Projectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__18_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitProjectile_003Eb__18_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1440;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public TP_Custos_Projectile _003C_003E4__this;

		public float spacingX;

		public float spacingY;
	}

	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public int trailIndex;

		public _003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals1;

		internal void _003CInitFireTrails_003Eb__0()
		{
			//IL_0046: Expected O, but got F4
			_003C_003Ec__DisplayClass22_0 obj = CS_0024_003C_003E8__locals1;
			TP_Custos_Projectile tP_Custos_Projectile = obj._003C_003E4__this;
			object obj2 = UnityEngine.Random.value;
			Vector2 pos = default(Vector2);
			Projectile projectile = tP_Custos_Projectile._custosWeapon.AddFireTrailAt(pos);
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public TP_Custos_Projectile _003C_003E4__this;

		public float spacingX;

		public float spacingY;
	}

	private sealed class _003C_003Ec__DisplayClass23_1
	{
		public int trailIndex;

		public _003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals1;

		internal void _003CInitIceTrails_003Eb__0()
		{
			//IL_0046: Expected O, but got F4
			_003C_003Ec__DisplayClass23_0 obj = CS_0024_003C_003E8__locals1;
			TP_Custos_Projectile tP_Custos_Projectile = obj._003C_003E4__this;
			object obj2 = UnityEngine.Random.value;
			Vector2 pos = default(Vector2);
			Projectile projectile = tP_Custos_Projectile._custosWeapon.AddIceTrailAt(pos);
		}
	}

	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public TP_Custos_Projectile _003C_003E4__this;

		public float spacingX;

		public float spacingY;
	}

	private sealed class _003C_003Ec__DisplayClass24_1
	{
		public int trailIndex;

		public _003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals1;

		internal void _003CInitLightningTrails_003Eb__0()
		{
			//IL_0046: Expected O, but got F4
			_003C_003Ec__DisplayClass24_0 obj = CS_0024_003C_003E8__locals1;
			TP_Custos_Projectile tP_Custos_Projectile = obj._003C_003E4__this;
			object obj2 = UnityEngine.Random.value;
			Vector2 pos = default(Vector2);
			Projectile projectile = tP_Custos_Projectile._custosWeapon.AddLightningTrailAt(pos);
		}
	}

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _posTween;

	private SpriteAnimation _anim;

	private const int AnimFPS = 24;

	protected int _startFrame = 1;

	protected float _posX;

	protected float _posY;

	protected Timer[] _trailTimers;

	protected const float TweenInDuration = 200f;

	protected const float TweenOutDuration = 200f;

	protected const float TweenOutDelay = 300f;

	protected TP_Custos_Weapon _custosWeapon;

	protected TP_Custos4_Weapon _evoWeapon;

	private int _biteCounter;

	private float2 _startingPoint;

	protected float2 ExplosionPoint
	{
		get
		{
			//IL_0098->IL003d: Incompatible stack heights: 1 vs 0
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				Transform cachedTransform2 = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out Vector3 _);
					float2 result = default(float2);
					return result;
				}
			}
			throw new NullReferenceException();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		InitAnimation(_startFrame);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_094b: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_01cb: Expected I, but got O
		//IL_01d9: Expected I, but got O
		//IL_01e9: Expected O, but got I
		//IL_0269: Expected O, but got I4
		//IL_01be: Expected O, but got I4
		//IL_09d6: Expected O, but got I4
		//IL_0225: Expected O, but got I
		//IL_025b: Expected O, but got I4
		//IL_036f: Expected O, but got I4
		//IL_036f: Expected F4, but got O
		//IL_044c: Expected O, but got I4
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected O, but got Unknown
		//IL_057a: Expected O, but got I4
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_0595: Expected O, but got Unknown
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected I4, but got Unknown
		//IL_05ba: Invalid comparison between F4 and O
		//IL_05da: Invalid comparison between O and F4
		//IL_0667: Expected I, but got O
		//IL_06df: Expected O, but got I4
		//IL_06ed: Expected O, but got I4
		//IL_0b52: Expected O, but got F4
		//IL_0b8b: Expected O, but got F4
		//IL_07e5: Expected I, but got O
		//IL_0aa1: Expected I, but got O
		//IL_0ab0: Expected O, but got I4
		//IL_0b09: Expected I, but got O
		//IL_0b44: Expected O, but got I4
		//IL_0ad4->IL08e6: Incompatible stack heights: 1 vs 0
		//IL_08a9->IL08a9: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		float? custosWeapon;
		if ((object)weapon == null)
		{
			custosWeapon = (float?)(object)0;
			goto IL_0924;
		}
		nint num = (nint)typeof(TP_Custos_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v73 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Custos_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v51 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v73 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Custos_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v51 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v170+FFFFFFF8+v71 @ rax_v165*8]");
			if (0 == (nint)typeof(TP_Custos_Weapon))
			{
				obj3 = 1;
				goto IL_0933;
			}
		}
		obj3 = 0;
		goto IL_0933;
		IL_0924:
		_custosWeapon = (TP_Custos_Weapon)custosWeapon;
		Weapon weapon2 = _weapon;
		Equipment equipment;
		float? evoWeapon;
		object obj6;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
				if ((object)characterController._weaponsManager != null)
				{
					Predicate<Equipment> match = _003C_003Ec._003C_003E9__18_0;
					if (_003C_003Ec._003C_003E9__18_0 == null)
					{
						match = (_003C_003Ec._003C_003E9__18_0 = delegate(Equipment x)
						{
							//IL_0052: Expected I4, but got O
							//IL_0030: Expected O, but got I4
							if ((object)x == null)
							{
								NullReferenceException ex3 = new NullReferenceException();
								return (byte)(int)ex3 != 0;
							}
							object obj17 = x._equipmentType - 1440;
							return obj17 == null;
						});
					}
					if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
					{
						equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
						if ((object)equipment == null)
						{
							evoWeapon = (float?)(object)0;
							goto IL_09ae;
						}
						nint num4 = (nint)equipment;
						nint num5 = (nint)typeof(TP_Custos4_Weapon);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rdx_v68 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Custos4_Weapon>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rdx_v68 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Custos4_Weapon>)+130]");
						if (num6 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rax_v146+FFFFFFF8+v833 @ rax_v141*8]");
							if (0 == (nint)typeof(TP_Custos4_Weapon))
							{
								obj6 = 1;
								goto IL_09bd;
							}
						}
						obj6 = 0;
						goto IL_09bd;
					}
				}
			}
		}
		goto IL_08e6;
		IL_08a9:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj7 = UnityEngine.Random.value;
		float num8;
		float num7 = num8 - 0.5f;
		_ = 1065353216;
		float num9 = num7 * 200f;
		_ = 1;
		((Group)(object)soundConfig).childrenToRemove = (HashSet<PhaserGameObject>)num9;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Custos1, soundConfig, 200f, 10, time);
		return;
		IL_09ae:
		_evoWeapon = (TP_Custos4_Weapon)evoWeapon;
		Weapon weapon3 = _weapon;
		_biteCounter = 0;
		if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = (_startingPoint = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position);
			if ((object)_anim != null)
			{
				_anim.SetAnimation("windup");
				ArcadeSprite arcadeSprite = setAlpha(0f);
				if ((object)weapon != null)
				{
					float num10 = weapon.PArea();
					ArcadeSprite arcadeSprite2 = setScale((float)float5, (float?)(object)0);
					Weapon weapon4 = _weapon;
					if ((object)_weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon4)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
						{
							ArcadeSprite arcadeSprite3 = setFlipX(characterController2._isFlipped);
							bool flag = base.flipX;
							BaseBody baseBody = body;
							if (body != null)
							{
								baseBody._enable = false;
								num8 = (float)float5 * 0.45f;
								Weapon weapon5 = _weapon;
								object obj8 = (flag ? 1 : 0) ^ 1;
								_posY = 0f;
								object obj9 = obj8 * 2;
								object obj10 = obj9 - 1;
								float posX = (float)obj10 * num8;
								_posX = posX;
								if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
								{
									int num11 = ((Equipment)weapon5)._003COwner_003Ek__BackingField.Depth;
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer = s_scene._renderer;
											if (s_scene._renderer != null && (object)_renderer != null)
											{
												int num12 = renderer.pixelHeight >> 31;
												object obj11 = renderer.pixelHeight - num12;
												object obj12 = obj11 >> 1;
												object obj13 = num11 + obj12;
												int sortingOrder = obj13 + index;
												_renderer.sortingOrder = sortingOrder;
												if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) || System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f))
												{
												}
												if (_alphaTween != null)
												{
													_alphaTween.Kill();
												}
												TweenConfig tweenConfig = new TweenConfig();
												Delegate[] array = (Delegate[])new object[1];
												if (array != null)
												{
													if ((object)_renderer != null)
													{
														nint num13 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj14 = default(object);
														if (obj14 == null)
														{
															ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
															throw ex;
														}
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig != null)
													{
														((EventEmitter)(object)tweenConfig).callbacks = array;
														SpriteRenderer renderer2 = _renderer;
														((Group)(object)tweenConfig).children = (HashSet<PhaserGameObject>)1128792064;
														((Group)(object)tweenConfig).childrenToRemove = (HashSet<PhaserGameObject>)3;
														_ = 1;
														MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
														_alphaTween = alphaTween;
														TP_Custos4_Weapon evoWeapon2 = _evoWeapon;
														if ((object)_evoWeapon == null || ((UnityEngine.Object)evoWeapon2).m_CachedPtr == (IntPtr)0)
														{
															goto IL_08a9;
														}
														if (_posTween != null)
														{
															_posTween.Kill();
														}
														TweenConfig tweenConfig2 = new TweenConfig();
														object[] array2 = new object[1];
														if (array2 != null)
														{
															if ((object)_cachedTransform != null)
															{
																nint num14 = (nint)array2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj15 = default(object);
																if (obj15 == null)
																{
																	ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
																	throw ex2;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if (tweenConfig2 != null)
															{
																tweenConfig2.targets = array2;
																renderer2 = (SpriteRenderer)(object)_cachedTransform;
																BulletPool cachedTransform = (BulletPool)(object)_cachedTransform;
																if ((object)_cachedTransform != null)
																{
																	bool flag2 = ((EventEmitter)cachedTransform).callbacks == null;
																	Transform.get_position_Injected((IntPtr)((EventEmitter)cachedTransform).callbacks, out Vector3 _);
																	tweenConfig2.x = (float?)(object)1;
																	BulletPool cachedTransform2 = (BulletPool)(object)_cachedTransform;
																	if ((object)_cachedTransform != null)
																	{
																		bool flag3 = ((EventEmitter)cachedTransform2).callbacks == null;
																		Transform.get_position_Injected((IntPtr)((EventEmitter)cachedTransform2).callbacks, out Vector3 _);
																		object obj16 = default(object);
																		num8 = (float)obj16 + _posY;
																		tweenConfig2.duration = 200f;
																		tweenConfig2.ease = Ease.OutSine;
																		tweenConfig2.y = (float?)(object)1;
																		MultiTargetTween posTween = Tweens.Add(tweenConfig2);
																		_posTween = posTween;
																		goto IL_08a9;
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
		goto IL_08e6;
		IL_08e6:
		throw new NullReferenceException();
		IL_0933:
		bool flag4 = obj3 == null;
		custosWeapon = (float?)(object)0;
		if (!flag4)
		{
			custosWeapon = (float?)weapon;
		}
		goto IL_0924;
		IL_09bd:
		bool flag5 = obj6 == null;
		evoWeapon = (float?)(object)0;
		if (!flag5)
		{
			evoWeapon = (float?)equipment;
		}
		goto IL_09ae;
	}

	private void InitAnimation(int startFrame)
	{
		//IL_00b8: Expected I, but got O
		//IL_0142: Expected I, but got O
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Cerberus01", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		CheckRenderer();
		GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		_anim = anim;
		int end = startFrame + 3;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", startFrame, end, "ThosePeople", num);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Custos_Projectile>)+440]");
		Action action = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("windup", animationFrames, 24, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		int end2 = startFrame + 7;
		int start = startFrame + 4;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", start, end2, "ThosePeople", num);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Custos_Projectile>)+450]");
		Action action2 = new Action(this, (IntPtr)0);
		nint num3 = (nint)this;
		_anim.AddAnimation("bite", animationFrames2, 24, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		int end3 = startFrame + 11;
		int start2 = startFrame + 8;
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", start2, end3, "ThosePeople", num);
		_anim.AddAnimation("idle", animationFrames3, 24, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	public virtual void Bite()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4377]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_anim.SetAnimation("bite");
		int biteCounter = _biteCounter + 1;
		_biteCounter = biteCounter;
	}

	protected virtual void OnBiteAnimComplete()
	{
		TP_Custos4_Weapon evoWeapon = _evoWeapon;
		if ((object)_evoWeapon == null || ((UnityEngine.Object)evoWeapon).m_CachedPtr == (IntPtr)0)
		{
			float num = _weapon.PAmount();
			object obj = default(object);
			if ((nint)obj > _biteCounter)
			{
				_anim.SetAnimation("windup");
				return;
			}
		}
		_anim.SetAnimation("idle");
		FadeOut();
	}

	private protected unsafe void InitFireTrails()
	{
		//IL_014f: Expected I, but got O
		//IL_0165: Expected O, but got I
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_01dc: Expected I, but got O
		//IL_0292: Expected O, but got I4
		//IL_02a9: Expected I, but got I8
		//IL_01c5: Expected I, but got I8
		//IL_0213: Expected I, but got O
		_003C_003Ec__DisplayClass22_0 obj = new _003C_003Ec__DisplayClass22_0();
		obj._003C_003E4__this = this;
		Timer[] trailTimers = _trailTimers;
		float num = _posX * 0.75f;
		float spacingX = num / (float)trailTimers.Length;
		obj.spacingX = spacingX;
		Timer[] trailTimers2 = _trailTimers;
		float num2 = _posY * 0.75f;
		float spacingY = num2 / (float)trailTimers2.Length;
		obj.spacingY = spacingY;
		Timer[] trailTimers3 = _trailTimers;
		float num3 = 200f / (float)trailTimers3.Length;
		bool flag = false;
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		object obj6 = default(object);
		while (true)
		{
			if ((flag2 ? 1 : 0) >= trailTimers3.Length)
			{
				return;
			}
			_003C_003Ec__DisplayClass22_1 obj2 = new _003C_003Ec__DisplayClass22_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.trailIndex = (flag ? 1 : 0);
			Timer[] trailTimers4 = _trailTimers;
			Action action = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass22_1._003CInitFireTrails_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num5;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num5 = unchecked((nint)6447293664L);
					goto IL_0289;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num5 = ((Delegate)action).method_ptr;
			goto IL_0289;
			IL_0289:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num6 = (float)(flag ? 1 : 0) * num3;
			float duration = num6 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			if (timer != null)
			{
				nint num7 = (nint)trailTimers4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj6 == null)
				{
					break;
				}
			}
			trailTimers4[flag ? 1u : 0u] = timer;
			trailTimers3 = _trailTimers;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			flag2 = flag;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private protected unsafe void InitIceTrails()
	{
		//IL_014f: Expected I, but got O
		//IL_0165: Expected O, but got I
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_01dc: Expected I, but got O
		//IL_0292: Expected O, but got I4
		//IL_02a9: Expected I, but got I8
		//IL_01c5: Expected I, but got I8
		//IL_0213: Expected I, but got O
		_003C_003Ec__DisplayClass23_0 obj = new _003C_003Ec__DisplayClass23_0();
		obj._003C_003E4__this = this;
		Timer[] trailTimers = _trailTimers;
		float num = _posX * 0.75f;
		float spacingX = num / (float)trailTimers.Length;
		obj.spacingX = spacingX;
		Timer[] trailTimers2 = _trailTimers;
		float num2 = _posY * 0.75f;
		float spacingY = num2 / (float)trailTimers2.Length;
		obj.spacingY = spacingY;
		Timer[] trailTimers3 = _trailTimers;
		float num3 = 200f / (float)trailTimers3.Length;
		bool flag = false;
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		object obj6 = default(object);
		while (true)
		{
			if ((flag2 ? 1 : 0) >= trailTimers3.Length)
			{
				return;
			}
			_003C_003Ec__DisplayClass23_1 obj2 = new _003C_003Ec__DisplayClass23_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.trailIndex = (flag ? 1 : 0);
			Timer[] trailTimers4 = _trailTimers;
			Action action = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass23_1._003CInitIceTrails_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num5;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num5 = unchecked((nint)6447293664L);
					goto IL_0289;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num5 = ((Delegate)action).method_ptr;
			goto IL_0289;
			IL_0289:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num6 = (float)(flag ? 1 : 0) * num3;
			float duration = num6 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			if (timer != null)
			{
				nint num7 = (nint)trailTimers4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj6 == null)
				{
					break;
				}
			}
			trailTimers4[flag ? 1u : 0u] = timer;
			trailTimers3 = _trailTimers;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			flag2 = flag;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private protected unsafe void InitLightningTrails()
	{
		//IL_014f: Expected I, but got O
		//IL_0165: Expected O, but got I
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_01dc: Expected I, but got O
		//IL_0292: Expected O, but got I4
		//IL_02a9: Expected I, but got I8
		//IL_01c5: Expected I, but got I8
		//IL_0213: Expected I, but got O
		_003C_003Ec__DisplayClass24_0 obj = new _003C_003Ec__DisplayClass24_0();
		obj._003C_003E4__this = this;
		Timer[] trailTimers = _trailTimers;
		float num = _posX * 0.75f;
		float spacingX = num / (float)trailTimers.Length;
		obj.spacingX = spacingX;
		Timer[] trailTimers2 = _trailTimers;
		float num2 = _posY * 0.75f;
		float spacingY = num2 / (float)trailTimers2.Length;
		obj.spacingY = spacingY;
		Timer[] trailTimers3 = _trailTimers;
		float num3 = 200f / (float)trailTimers3.Length;
		bool flag = false;
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		object obj6 = default(object);
		while (true)
		{
			if ((flag2 ? 1 : 0) >= trailTimers3.Length)
			{
				return;
			}
			_003C_003Ec__DisplayClass24_1 obj2 = new _003C_003Ec__DisplayClass24_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.trailIndex = (flag ? 1 : 0);
			Timer[] trailTimers4 = _trailTimers;
			Action action = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass24_1._003CInitLightningTrails_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num5;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num5 = unchecked((nint)6447293664L);
					goto IL_0289;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num5 = ((Delegate)action).method_ptr;
			goto IL_0289;
			IL_0289:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num6 = (float)(flag ? 1 : 0) * num3;
			float duration = num6 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			if (timer != null)
			{
				nint num7 = (nint)trailTimers4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj6 == null)
				{
					break;
				}
			}
			trailTimers4[flag ? 1u : 0u] = timer;
			trailTimers3 = _trailTimers;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			flag2 = flag;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void FadeOut()
	{
		//IL_005e: Expected I, but got O
		//IL_00de: Expected O, but got I4
		//IL_00f9: Expected I, but got O
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_renderer != null)
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
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.delay = 300f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Custos_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	public override void Despawn()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		Timer[] trailTimers = _trailTimers;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < trailTimers.Length)
		{
			Timer[] trailTimers2 = _trailTimers;
			if (trailTimers2[obj2] != null)
			{
				trailTimers2[obj2].Cancel();
			}
			trailTimers = _trailTimers;
			obj2++;
			obj = obj2;
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		base.Despawn();
	}

	public TP_Custos_Projectile()
	{
		Timer[] trailTimers = new Timer[10];
		_trailTimers = trailTimers;
		base._002Ector();
	}
}
