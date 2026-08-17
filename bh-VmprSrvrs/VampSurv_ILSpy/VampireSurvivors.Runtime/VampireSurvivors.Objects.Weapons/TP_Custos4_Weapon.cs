using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Custos4_Weapon : TP_Custos_Weapon
{
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public int localIndex;

		public TP_Custos4_Weapon _003C_003E4__this;

		internal void _003CShootFireballs_003Eb__0()
		{
			//IL_00c2: Expected O, but got I4
			//IL_006f->IL008b: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					if ((object)_003C_003E4__this != null)
					{
						_003C_003E4__this.FireFireballProjectiles(localIndex);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public TP_Custos4_Weapon _003C_003E4__this;

		public List<BulletPool> sequence;

		public List<Vector2> offsets;
	}

	private sealed class _003C_003Ec__DisplayClass28_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals1;

		internal void _003CBiteAttack_003Eb__0()
		{
			//IL_0132: Expected O, but got I4
			//IL_00a8->IL00fb: Incompatible stack heights: 1 vs 0
			//IL_00ca->IL00fb: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass28_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass28_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						obj3._003C_003E4__this.FireOneBiteProjectile(obj3.sequence, obj3.offsets, localIndex);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private Transform _DummyTarget;

	private const int AnimFPS = 20;

	private PhaserSprite _custos1;

	private PhaserSprite _custos2;

	private PhaserSprite _custos3;

	private Vector2 _offset1;

	private Vector2 _offset2;

	private Vector2 _offset3;

	private int _firingCounter;

	private const int MinBites = 6;

	private int _numBites;

	private const int MinFireballs = 16;

	private int _numFireballs;

	private const float HeadFadeTime = 500f;

	private const float GapBetweenFireballandBiteAttacks = 250f;

	private Timer _animTimer;

	private MultiTargetTween _alphaTween;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		InitAllBulletPools();
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats = characterController2._playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + 10f;
		playerStats._003CArmor_003Ek__BackingField = eggFloat2;
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats2 = characterController3._playerStats;
		EggFloat eggFloat3 = playerStats2._003CRegen_003Ek__BackingField;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = eggFloat3._val + 2f;
		playerStats2._003CRegen_003Ek__BackingField = eggFloat4;
		VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats3 = characterController4._playerStats;
		EggFloat eggFloat5 = playerStats3._003CCooldown_003Ek__BackingField;
		float value3 = default(float);
		EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
		value3 = eggFloat5._val - 0.1f;
		playerStats3._003CCooldown_003Ek__BackingField = eggFloat6;
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.RemoveWeapon(WeaponType.TP_CUSTOS1, ((Equipment)this)._003COwner_003Ek__BackingField);
		GameManager core2 = GM.Core;
		Weapon weapon2 = core2._weaponsFacade.RemoveWeapon(WeaponType.TP_CUSTOS2, ((Equipment)this)._003COwner_003Ek__BackingField);
		GameManager core3 = GM.Core;
		Weapon weapon3 = core3._weaponsFacade.RemoveWeapon(WeaponType.TP_CUSTOS3, ((Equipment)this)._003COwner_003Ek__BackingField);
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 1, 4, "ThosePeople", num);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 5, 8, "ThosePeople", num);
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 9, 12, "ThosePeople", num);
		List<Sprite> list = (List<Sprite>)(object)new List<object>(animationFrames2);
		((List<object>)(object)list).Reverse();
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 13, 16, "ThosePeople", num);
		List<Sprite> animationFrames5 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 17, 20, "ThosePeople", num);
		List<Sprite> animationFrames6 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 21, 24, "ThosePeople", num);
		List<Sprite> list2 = (List<Sprite>)(object)new List<object>(animationFrames5);
		((List<object>)(object)list2).Reverse();
		List<Sprite> animationFrames7 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 25, 28, "ThosePeople", num);
		List<Sprite> animationFrames8 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 29, 32, "ThosePeople", num);
		List<Sprite> animationFrames9 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 33, 36, "ThosePeople", num);
		List<Sprite> list3 = (List<Sprite>)(object)new List<object>(animationFrames8);
		((List<object>)(object)list3).Reverse();
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite custos = RenderingExtensions.AddPhaserSprite(gameObject, pos, "TP_VFX_Cerberus01", "ThosePeople");
		_custos1 = custos;
		PhaserSprite custos2 = _custos1;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		custos2._spriteAnimation.AddAnimation("custos1_open", animationFrames, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos3 = _custos1;
		custos3._spriteAnimation.AddAnimation("custos1_closed", animationFrames3, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos4 = _custos1;
		custos4._spriteAnimation.AddAnimation("custos1_opening", list, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos5 = _custos1;
		custos5._spriteAnimation.AddAnimation("custos1_closing", animationFrames2, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos6 = _custos1;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(custos6._spriteRenderer, 0f);
		PhaserSprite custos7 = _custos1;
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		int sortingOrder = depth - 1;
		custos7._spriteRenderer.sortingOrder = sortingOrder;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite custos8 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "TP_VFX_Cerberus01", "ThosePeople");
		_custos2 = custos8;
		PhaserSprite custos9 = _custos2;
		custos9._spriteAnimation.AddAnimation("custos2_open", animationFrames4, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos10 = _custos2;
		custos10._spriteAnimation.AddAnimation("custos2_closed", animationFrames6, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos11 = _custos2;
		custos11._spriteAnimation.AddAnimation("custos2_opening", list2, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos12 = _custos2;
		custos12._spriteAnimation.AddAnimation("custos2_closing", animationFrames5, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos13 = _custos2;
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(custos13._spriteRenderer, 0f);
		PhaserSprite custos14 = _custos2;
		int depth2 = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		int sortingOrder2 = depth2 - 1;
		custos14._spriteRenderer.sortingOrder = sortingOrder2;
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite custos15 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "TP_VFX_Cerberus01", "ThosePeople");
		_custos3 = custos15;
		PhaserSprite custos16 = _custos3;
		custos16._spriteAnimation.AddAnimation("custos3_open", animationFrames7, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos17 = _custos3;
		custos17._spriteAnimation.AddAnimation("custos3_closed", animationFrames9, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos18 = _custos3;
		custos18._spriteAnimation.AddAnimation("custos3_opening", list3, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos19 = _custos3;
		custos19._spriteAnimation.AddAnimation("custos3_closing", animationFrames8, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite custos20 = _custos3;
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(custos20._spriteRenderer, 0f);
		PhaserSprite custos21 = _custos3;
		int depth3 = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		int sortingOrder3 = depth3 - 1;
		custos21._spriteRenderer.sortingOrder = sortingOrder3;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
	}

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(3f > num2);
		float result = 3f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	public override float PInterval()
	{
		//IL_0043: Invalid comparison between F4 and I
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldownFinal();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A102CC]");
			float num2 = default(float);
			WeaponData currentWeaponData = default(WeaponData);
			if (!(num2 < 0f))
			{
				currentWeaponData = _currentWeaponData;
				if (_currentWeaponData == null)
				{
					goto IL_0076;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A102CC]");
			return 0f * currentWeaponData._003Cinterval_003Ek__BackingField;
		}
		goto IL_0076;
		IL_0076:
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Invalid comparison between O and F4
		if ((++_firingCounter & 1) != 0)
		{
			BiteAttack();
		}
		else
		{
			StartFireballAttack();
		}
		float num = PInterval();
		float num3 = default(float);
		float num2 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num4 = PInterval();
			_lastFiringInterval = num3;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private void StartFireballAttack()
	{
		//IL_0019: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_0489: Expected I, but got O
		//IL_0509: Expected I, but got O
		//IL_0589: Expected I, but got O
		//IL_060f: Expected O, but got I4
		//IL_043d->IL06df: Incompatible stack heights: 3 vs 0
		//IL_045a->IL06df: Incompatible stack heights: 3 vs 0
		//IL_04da->IL06df: Incompatible stack heights: 3 vs 0
		//IL_04ac->IL04ac: Incompatible stack heights: 4 vs 3
		//IL_055a->IL06df: Incompatible stack heights: 3 vs 0
		//IL_052c->IL052c: Incompatible stack heights: 4 vs 3
		//IL_05ce->IL06df: Incompatible stack heights: 3 vs 0
		//IL_05ac->IL05ac: Incompatible stack heights: 4 vs 3
		float num = PArea();
		if ((object)_custos1 != null)
		{
			float num2 = default(float);
			PhaserSprite phaserSprite = _custos1.setScale(num2, (float?)(object)0);
			float num3 = PArea();
			if ((object)_custos2 != null)
			{
				PhaserSprite phaserSprite2 = _custos2.setScale(num2, (float?)(object)0);
				float num4 = PArea();
				if ((object)_custos3 != null)
				{
					PhaserSprite phaserSprite3 = _custos3.setScale(num2, (float?)(object)0);
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)_custos1 != null)
					{
						PhaserSprite phaserSprite4 = _custos1.setFlipX(characterController._isFlipped);
						VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)_custos2 != null)
						{
							PhaserSprite phaserSprite5 = _custos2.setFlipX(characterController2._isFlipped);
							VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)_custos3 != null)
							{
								PhaserSprite phaserSprite6 = _custos3.setFlipX(characterController3._isFlipped);
								VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
								{
									if (!characterController4._isFlipped)
									{
									}
									Transform transform = _custos1.transform;
									float num5 = PArea();
									float num6 = PArea();
									float num7 = num2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Custos4_Weapon)+1DC]");
									float num8 = num7 * 0f;
									float num9 = num8 * 0.01f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ rax_v43 (UnityEngine.Transform)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ rax_v43 (UnityEngine.Transform)+10]");
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected((IntPtr)0, ref value);
									Transform transform2 = _custos2.transform;
									float num10 = PArea();
									float num11 = PArea();
									float num12 = num9;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Custos4_Weapon)+1E4]");
									float num13 = num12 * 0f;
									float num14 = num13 * 0.01f;
									bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Vector3 value2 = default(Vector3);
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
									Transform transform3 = _custos3.transform;
									float num15 = PArea();
									float num16 = PArea();
									float num17 = num14;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Custos4_Weapon)+1EC]");
									float num18 = num17 * 0f;
									float num19 = num18 * 0.01f;
									bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									Vector3 value3 = default(Vector3);
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value3);
									PhaserSprite custos = _custos1;
									custos._spriteAnimation.SetAnimation("custos1_closed");
									PhaserSprite custos2 = _custos2;
									custos2._spriteAnimation.SetAnimation("custos2_closed");
									PhaserSprite custos3 = _custos3;
									custos3._spriteAnimation.SetAnimation("custos3_closed");
									float num20 = PArea();
									if (1f < num19 && num19 < 3f)
									{
										float num21 = num19 - 1f;
										float num22 = num21 * 0.25f;
										num19 = num22 * 0.5f;
									}
									if (_alphaTween != null)
									{
										_alphaTween.Kill();
									}
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[3];
									PhaserSprite custos4 = _custos1;
									if ((object)_custos1 != null && array != null)
									{
										if ((object)custos4._spriteRenderer != null)
										{
											nint num23 = (nint)array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj = default(object);
											bool flag4 = obj == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										PhaserSprite custos5 = _custos2;
										if ((object)_custos2 != null)
										{
											if ((object)custos5._spriteRenderer != null)
											{
												nint num24 = (nint)array;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj2 = default(object);
												bool flag5 = obj2 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											PhaserSprite custos6 = _custos3;
											if ((object)_custos3 != null)
											{
												if ((object)custos6._spriteRenderer != null)
												{
													nint num25 = (nint)array;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj3 = default(object);
													bool flag6 = obj3 == null;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig != null)
												{
													tweenConfig.targets = array;
													tweenConfig.duration = 500f;
													tweenConfig.ease = Ease.Linear;
													tweenConfig.alpha = (float?)(object)1;
													TweenCallback onComplete = ShootFireballs;
													tweenConfig.onComplete = onComplete;
													MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
													_alphaTween = alphaTween;
													if (_animTimer != null)
													{
														_animTimer.Cancel();
													}
													Action onComplete2 = delegate
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A52A0]");
														if ((nint)0 == 0)
														{
															_ = 1;
														}
														PhaserSprite custos7 = _custos1;
														custos7._spriteAnimation.SetAnimation("custos1_opening");
														PhaserSprite custos8 = _custos2;
														custos8._spriteAnimation.SetAnimation("custos2_opening");
														PhaserSprite custos9 = _custos3;
														custos9._spriteAnimation.SetAnimation("custos3_opening");
													};
													bool useRealTime = default(bool);
													MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
													int repeat = default(int);
													TimerType type = default(TimerType);
													Timer animTimer = Timers.Register(0.3f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
													_animTimer = animTimer;
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

	private unsafe void ShootFireballs()
	{
		//IL_017d: Invalid comparison between F4 and I4
		//IL_018f: Expected F4, but got I4
		//IL_049a: Expected I4, but got F4
		//IL_032e: Expected I, but got O
		//IL_0344: Expected O, but got I
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_04f9: Invalid comparison between F4 and I4
		//IL_03c8: Expected I, but got O
		//IL_0571: Expected O, but got I4
		//IL_0598: Expected I, but got I8
		//IL_030e: Expected O, but got I4
		//IL_031c: Expected O, but got I4
		//IL_03a4: Expected I, but got I8
		//IL_01f6->IL03ce: Incompatible stack heights: 3 vs 0
		PhaserSprite custos = _custos1;
		float num7;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if ((object)_custos1 != null && (object)custos._spriteAnimation != null)
		{
			custos._spriteAnimation.SetAnimation("custos1_open");
			PhaserSprite custos2 = _custos2;
			if ((object)_custos2 != null && (object)custos2._spriteAnimation != null)
			{
				custos2._spriteAnimation.SetAnimation("custos2_open");
				PhaserSprite custos3 = _custos3;
				if ((object)_custos3 != null && (object)custos3._spriteAnimation != null)
				{
					custos3._spriteAnimation.SetAnimation("custos3_open");
					object dummyTarget = _DummyTarget;
					Transform fireballTarget = GetFireballTarget();
					if ((object)fireballTarget != null)
					{
						bool flag = ((UnityEngine.Object)fireballTarget).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)fireballTarget).m_CachedPtr, out Vector3 ret);
						bool flag2 = (object)_DummyTarget == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ rbx_v12 (System.Object)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ rbx_v12 (System.Object)+10]");
						Vector3 value = default(Vector3);
						Transform.set_position_Injected((IntPtr)0, ref value);
						_targetTransform = _DummyTarget;
						float num = base.PAmount();
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
						float num2 = num * 2f;
						float num3 = num2 + 16f;
						bool flag4 = !(num3 > 1f);
						float num4 = 1f;
						if (!flag4)
						{
							num4 = num3;
						}
						_numFireballs = (int)num4;
						float num5 = PInterval();
						float num6 = (float)ret - 250f;
						num7 = num6 - 1000f;
						if (!(num7 > 100f))
						{
							num7 = 100f;
						}
						float num8 = num7 / (float)_numFireballs;
						if (_numFireballs <= 0)
						{
							goto IL_02c3;
						}
						int num9 = 0;
						while (true)
						{
							float num10 = (float)num9 * num8;
							if (!(num10 > 0f))
							{
								FireFireballProjectiles(num9);
							}
							else
							{
								_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass24_0();
								if (CS_0024_003C_003E8__locals8 == null)
								{
									break;
								}
								CS_0024_003C_003E8__locals8._003C_003E4__this = this;
								CS_0024_003C_003E8__locals8.localIndex = num9;
								Action onComplete = delegate
								{
									//IL_00c2: Expected O, but got I4
									//IL_006f->IL008b: Incompatible stack heights: 1 vs 0
									if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
									{
										GameObject gameObject = CS_0024_003C_003E8__locals8._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj4 == null)
											{
												return;
											}
											if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
											{
												CS_0024_003C_003E8__locals8._003C_003E4__this.FireFireballProjectiles(CS_0024_003C_003E8__locals8.localIndex);
												return;
											}
										}
									}
									throw new NullReferenceException();
								};
								float num11 = (float)num9 * num8;
								float duration = num11 * 0.001f;
								Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_lastShotTimer = lastShotTimer;
							}
							num9++;
							if (num9 < _numFireballs)
							{
								continue;
							}
							goto IL_02c3;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0568:
		object obj = 24;
		float duration2 = num7 * 0.001f;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		Timer animTimer = Timers.Register(duration2, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_animTimer = animTimer;
		return;
		IL_02c3:
		Timer animTimer2 = _animTimer;
		if (_animTimer != null && !_animTimer.IsDone)
		{
			float timeElapsed = _animTimer.GetTimeElapsed();
			animTimer2._timeElapsedBeforeCancel = (float?)(object)1;
			animTimer2._timeElapsedBeforePause = (float?)(object)0;
		}
		action = null;
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(TP_Custos4_Weapon.EndFireballAttack);
		((Delegate)action).m_target = this;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj2 = (nint)0 >> 4;
		object obj3 = obj2 & 1;
		nint num13;
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num13 = unchecked((nint)6447293664L);
				goto IL_0568;
			}
		}
		num13 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_0568;
	}

	private void FireFireballProjectiles(int index)
	{
		//IL_0280: Expected O, but got I4
		//IL_028b: Expected O, but got I4
		//IL_05e5: Expected O, but got F4
		//IL_0390: Expected F4, but got I4
		//IL_03c2: Expected F4, but got I4
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_04d1->IL03cc: Incompatible stack heights: 1 vs 0
		//IL_030d->IL03cc: Incompatible stack heights: 2 vs 0
		//IL_0571->IL03cc: Incompatible stack heights: 3 vs 0
		//IL_035d->IL05bb: Incompatible stack heights: 4 vs 0
		PhaserSprite[] array = new PhaserSprite[3];
		if (array != null)
		{
			if ((object)_custos1 != null)
			{
				object obj = array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_custos2 != null)
			{
				object obj3 = array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_custos3 != null)
			{
				object obj5 = array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			BulletPool[] array2 = new BulletPool[3];
			if (array2 != null)
			{
				if (_fireFireballPool != null)
				{
					object obj7 = array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj8 = default(object);
					if (obj8 == null)
					{
						ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
						throw ex4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (_iceFireballPool != null)
				{
					object obj9 = array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj10 = default(object);
					if (obj10 == null)
					{
						ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
						throw ex5;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (_lightningFireballPool != null)
				{
					object obj11 = array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj12 = default(object);
					if (obj12 == null)
					{
						ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
						throw ex6;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if ((object)_custos1 != null)
				{
					bool flipX = _custos1.flipX;
					object obj13 = 0;
					object obj14 = 0;
					object obj16 = default(object);
					Vector2 pos = default(Vector2);
					float? volume = default(float?);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					while (true)
					{
						if ((nint)obj14 < array.Length)
						{
							object obj15 = array[obj13];
							if ((object)array[obj13] == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v28 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v28 (System.Object)+10]");
							IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
							Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							if ((object)transform == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v81 (UnityEngine.Transform)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v81 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out Vector3 _);
							float num = PArea();
							PhaserSprite phaserSprite = array[obj13];
							if ((object)array[obj13] == null)
							{
								break;
							}
							bool flag3 = ((UnityEngine.Object)phaserSprite).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)phaserSprite).m_CachedPtr);
							Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
							if ((object)transform2 == null)
							{
								break;
							}
							bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
							float num2 = (float)obj16 - 0.19999999f;
							Projectile projectile = base.FireOneProjectile(pos, index, _targetTransform);
							obj13++;
							obj14 = obj13;
							continue;
						}
						object obj17 = UnityEngine.Random.value;
						PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Custos1, 200f, 10, 0f, volume, rate, detune, loop, 1f);
						PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Fireball, 200f, 10, 0f, volume, rate, detune, loop, 1f);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe Transform GetFireballTarget()
	{
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected Ref, but got Unknown
		//IL_031c->IL02d8: Incompatible stack heights: 2 vs 0
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		object obj = default(object);
		float num = (float)obj * 2f;
		float num2 = num * 0.25f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num3 = 0f * 2f;
		float num4 = num3 * 0.5f;
		Camera result;
		if ((object)_custos1 != null)
		{
			float x;
			if (_custos1.flipX)
			{
				x = (float)bounds.m_Center - (float)obj;
			}
			else
			{
				object obj2 = (object)bounds.m_Center + obj;
				x = (float)obj2 - num2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v5 (UnityEngine.Bounds)+10]");
			object obj3 = obj - 0;
			Rectangle rectangle = new Rectangle();
			float num5 = num4 * 0.5f;
			rectangle._x = x;
			float y = num5 + (float)obj3;
			rectangle._width = num2;
			rectangle._height = num4;
			rectangle._y = y;
			GameManager gameMan = _gameMan;
			if ((object)_gameMan != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)gameMan._stage != null)
			{
				ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
				Transform transform = gameMan._stage.PickRandomEnemyInRectBounds(rectangle, ref rng);
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0;
					result = (Camera)(object)transform;
					if (flag)
					{
						goto IL_02d8;
					}
				}
				if ((object)_custos1 != null)
				{
					bool flipX = _custos1.flipX;
					Camera dummyTarget = (Camera)(object)_DummyTarget;
					bool flag2 = (object)_DummyTarget == null;
					bool flag3 = ((UnityEngine.Object)dummyTarget).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)dummyTarget).m_CachedPtr, ref value);
					result = (Camera)(object)_DummyTarget;
					goto IL_02d8;
				}
			}
		}
		throw new NullReferenceException();
		IL_02d8:
		return (Transform)(object)result;
	}

	private void EndFireballAttack()
	{
		//IL_00e1: Expected I, but got O
		//IL_014b: Expected I, but got O
		//IL_01b5: Expected I, but got O
		//IL_0227: Expected O, but got I4
		PhaserSprite custos = _custos1;
		custos._spriteAnimation.SetAnimation("custos1_closing");
		PhaserSprite custos2 = _custos2;
		custos2._spriteAnimation.SetAnimation("custos2_closing");
		PhaserSprite custos3 = _custos3;
		custos3._spriteAnimation.SetAnimation("custos3_closing");
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		PhaserSprite custos4 = _custos1;
		if ((object)custos4._spriteRenderer != null)
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
		PhaserSprite custos5 = _custos2;
		if ((object)custos5._spriteRenderer != null)
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
		PhaserSprite custos6 = _custos3;
		if ((object)custos6._spriteRenderer != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		if (_animTimer != null)
		{
			_animTimer.Cancel();
		}
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A52A1]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			PhaserSprite custos7 = _custos1;
			custos7._spriteAnimation.SetAnimation("custos1_closed");
			PhaserSprite custos8 = _custos2;
			custos8._spriteAnimation.SetAnimation("custos2_closed");
			PhaserSprite custos9 = _custos3;
			custos9._spriteAnimation.SetAnimation("custos3_closed");
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer animTimer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_animTimer = animTimer;
	}

	private void BiteAttack()
	{
		//IL_0041: Invalid comparison between F4 and I4
		//IL_0053: Expected F4, but got I4
		//IL_0206: Expected I4, but got F4
		//IL_0232: Expected O, but got I4
		//IL_027b: Invalid comparison between F4 and I4
		//IL_01d1: Expected O, but got I4
		_003C_003Ec__DisplayClass28_0 obj = new _003C_003Ec__DisplayClass28_0();
		obj._003C_003E4__this = this;
		float num = base.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		float num2 = num + 6f;
		bool flag = !(num2 > 1f);
		float num3 = 1f;
		if (!flag)
		{
			num3 = num2;
		}
		_numBites = (int)num3;
		List<BulletPool> sequence = GenerateBiteSequence();
		obj.sequence = sequence;
		List<Vector2> biteOffsets = GetBiteOffsets(obj.sequence);
		obj.offsets = biteOffsets;
		float num4 = PInterval();
		object obj2 = default(object);
		float num5 = (float)obj2 - 250f;
		if (!(num5 > 100f))
		{
			num5 = 100f;
		}
		object obj3 = _numBites - 1;
		float num6 = num5 / (float)_numBites;
		if ((nint)obj3 <= 0)
		{
			return;
		}
		int num7 = 0;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		object obj4;
		do
		{
			float num8 = (float)num7 * num6;
			if (!(num8 > 0f))
			{
				FireOneBiteProjectile(obj.sequence, obj.offsets, num7);
			}
			else
			{
				_003C_003Ec__DisplayClass28_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass28_1();
				CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 = obj;
				CS_0024_003C_003E8__locals7.localIndex = num7;
				Action onComplete = delegate
				{
					//IL_0132: Expected O, but got I4
					//IL_00a8->IL00fb: Incompatible stack heights: 1 vs 0
					//IL_00ca->IL00fb: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass28_0 obj5 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
					{
						GameObject gameObject = obj5._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj6 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj6 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass28_0 obj7 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null && (object)obj7._003C_003E4__this != null)
							{
								obj7._003C_003E4__this.FireOneBiteProjectile(obj7.sequence, obj7.offsets, CS_0024_003C_003E8__locals7.localIndex);
								return;
							}
						}
					}
					throw new NullReferenceException();
				};
				float num9 = (float)num7 * num6;
				float duration = num9 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			num7++;
			obj4 = _numBites - 1;
		}
		while (num7 < (nint)obj4);
	}

	private void FireOneBiteProjectile(List<BulletPool> sequence, List<Vector2> offsets, int index)
	{
		ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [offsets @ r8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)index < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (ArcadeSprite)+242]");
			if ((nint)0 == 0)
			{
			}
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [offsets @ r8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)index < (nint)0 && index < sequence._size)
			{
				Vector2 pos = default(Vector2);
				Projectile projectile = base.FireOneProjectile(pos, index, _targetTransform);
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe List<BulletPool> GenerateBiteSequence()
	{
		//IL_002c: Expected I, but got O
		//IL_009f: Expected I, but got O
		//IL_0114: Expected I, but got O
		//IL_0234: Expected O, but got Ref
		BulletPool[] array = new BulletPool[3];
		if (_fireHeadPool != null)
		{
			nint num = (nint)array;
			BulletPool fireHeadPool = _fireHeadPool;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v48 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Object>>)+40]");
			BulletPool item = default(BulletPool);
			((List<BulletPool>)(object)fireHeadPool).Insert(0, item);
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		((List<BulletPool>)(object)array).Insert(0, _fireHeadPool);
		if (_iceHeadPool != null)
		{
			nint num2 = (nint)array;
			BulletPool iceHeadPool = _iceHeadPool;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v46 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Object>>)+40]");
			((List<BulletPool>)(object)iceHeadPool).Insert(0, _fireHeadPool);
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		((List<BulletPool>)(object)array).Insert(1, _iceHeadPool);
		if (_lightningHeadPool != null)
		{
			nint num3 = (nint)array;
			BulletPool lightningHeadPool = _lightningHeadPool;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v44 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Object>>)+40]");
			((List<BulletPool>)(object)lightningHeadPool).Insert(0, _iceHeadPool);
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		((List<BulletPool>)(object)array).Insert(2, _lightningHeadPool);
		List<BulletPool> list = new List<BulletPool>();
		object obj4 = null;
		List<BulletPool>.Enumerator enumerator = default(List<BulletPool>.Enumerator);
		while (true)
		{
			int num4 = Enumerable.Count(list);
			if (num4 >= _numBites)
			{
				break;
			}
			List<BulletPool> list2 = (List<BulletPool>)(object)new List<object>(array);
			Extensions.Shuffle((IList<object>)list2);
			if (obj4 != null)
			{
				BulletPool bulletPool = list2.get_Item(0);
				if (obj4 == bulletPool)
				{
					list2.RemoveAt(0);
					((List<object>)(object)list2).Insert(1, obj4);
				}
			}
			object obj5 = Enumerable.Last((IEnumerable<object>)list2);
			while (enumerator.MoveNext())
			{
				bool flag = list == null;
				List<BulletPool>.Enumerator enumerator2 = (List<BulletPool>.Enumerator)(&enumerator);
				if (!flag)
				{
					((List<object>)(object)list).Add((object)null);
					continue;
				}
				throw new NullReferenceException();
			}
			obj4 = obj5;
		}
		return list;
	}

	private unsafe List<Vector2> GetBiteOffsets(List<BulletPool> sequence)
	{
		//IL_0141: Expected I, but got O
		//IL_00f3: Expected O, but got Ref
		//IL_00c9: Expected O, but got Ref
		//IL_009f: Expected O, but got Ref
		List<Vector2> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		nint num = (nint)this;
		float num2 = PArea();
		object obj = default(object);
		if (0 <= (nint)obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm6,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		List<BulletPool>.Enumerator enumerator = default(List<BulletPool>.Enumerator);
		Vector2 item = default(Vector2);
		while (enumerator.MoveNext())
		{
			if (0 != (nint)_fireHeadPool)
			{
				if (0 != (nint)_iceHeadPool)
				{
					if (0 != (nint)_lightningHeadPool)
					{
						continue;
					}
					bool flag = list == null;
					List<BulletPool>.Enumerator enumerator2 = (List<BulletPool>.Enumerator)(&enumerator);
					if (flag)
					{
						throw new NullReferenceException();
					}
				}
				else
				{
					bool flag2 = list == null;
					List<BulletPool>.Enumerator enumerator2 = (List<BulletPool>.Enumerator)(&enumerator);
					if (flag2)
					{
						throw new NullReferenceException();
					}
				}
			}
			else
			{
				bool flag3 = list == null;
				List<BulletPool>.Enumerator enumerator2 = (List<BulletPool>.Enumerator)(&enumerator);
				if (flag3)
				{
					throw new NullReferenceException();
				}
			}
			list.Add(item);
		}
		return list;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_animTimer != null)
		{
			_animTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _custos1.setVisible(visible);
		PhaserSprite phaserSprite2 = _custos2.setVisible(visible);
		PhaserSprite phaserSprite3 = _custos3.setVisible(visible);
	}

	private float AlphaFromScale(float weaponArea, float maxScale, float minAlpha)
	{
		//IL_0052: Invalid comparison between F4 and I4
		float num = maxScale - 1f;
		float num2 = 1f - minAlpha;
		bool flag = !(1f < weaponArea);
		float result = 1f;
		if (!flag)
		{
			bool flag2 = num < 0f;
			result = 1f;
			if (!flag2)
			{
				if (!(weaponArea < maxScale))
				{
					return minAlpha;
				}
				float num3 = weaponArea - 1f;
				float num4 = num3 * num2;
				float num5 = num4 / num;
				result = 1f - num5;
			}
		}
		return result;
	}

	public TP_Custos4_Weapon()
	{
		//IL_0011: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		_ = 1109393408;
		_offset1 = (Vector2)0;
		_ = 3248488448L;
		_offset3 = (Vector2)1101004800;
		_ = 1092616192;
		((Weapon)this)._002Ector();
	}

	private void _003CStartFireballAttack_003Eb__23_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A52A0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite custos = _custos1;
		custos._spriteAnimation.SetAnimation("custos1_opening");
		PhaserSprite custos2 = _custos2;
		custos2._spriteAnimation.SetAnimation("custos2_opening");
		PhaserSprite custos3 = _custos3;
		custos3._spriteAnimation.SetAnimation("custos3_opening");
	}

	private void _003CEndFireballAttack_003Eb__27_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A52A1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite custos = _custos1;
		custos._spriteAnimation.SetAnimation("custos1_closed");
		PhaserSprite custos2 = _custos2;
		custos2._spriteAnimation.SetAnimation("custos2_closed");
		PhaserSprite custos3 = _custos3;
		custos3._spriteAnimation.SetAnimation("custos3_closed");
	}
}
