using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_LongswordProjectile_LifeSprinkler : Projectile
{
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public EME_LongswordProjectile_LifeSprinkler _003C_003E4__this;

		public Weapon weapon;

		internal void _003CInitProjectile_003Eb__0()
		{
			_003C_003E4__this.GoToNearestEnemy();
		}

		internal void _003CInitProjectile_003Eb__1()
		{
			//IL_006a: Expected O, but got I
			ArcadeSprite arcadeSprite = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (ArcadeSprite)+118]");
			if ((nint)0 != 0)
			{
				float2 position = arcadeSprite.position;
				float num = weapon.PAmount();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (ArcadeSprite)+118]");
				Vector2 pos = default(Vector2);
				float _amount = default(float);
				((EME_Longsword1Weapon)0).FireLSSlashes(pos, _003C_003E4__this, _amount);
			}
			EME_LongswordProjectile_LifeSprinkler eME_LongswordProjectile_LifeSprinkler = _003C_003E4__this;
			eME_LongswordProjectile_LifeSprinkler.lifeSprinklerCrossVFX.Play(withChildren: true);
			EME_LongswordProjectile_LifeSprinkler eME_LongswordProjectile_LifeSprinkler2 = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}

		internal void _003CInitProjectile_003Eb__2()
		{
			EME_LongswordProjectile_LifeSprinkler eME_LongswordProjectile_LifeSprinkler = _003C_003E4__this;
			if (eME_LongswordProjectile_LifeSprinkler._movementTimer != null)
			{
				eME_LongswordProjectile_LifeSprinkler._movementTimer.Cancel();
			}
			EME_LongswordProjectile_LifeSprinkler eME_LongswordProjectile_LifeSprinkler2 = _003C_003E4__this;
			if (eME_LongswordProjectile_LifeSprinkler2._hitboxTimer != null)
			{
				eME_LongswordProjectile_LifeSprinkler2._hitboxTimer.Cancel();
			}
			EME_LongswordProjectile_LifeSprinkler eME_LongswordProjectile_LifeSprinkler3 = _003C_003E4__this;
			eME_LongswordProjectile_LifeSprinkler3.lifeSprinklerFullVFX.Stop();
		}

		internal void _003CInitProjectile_003Eb__3()
		{
			_003C_003E4__this.Despawn();
		}
	}

	private ParticleSystem lifeSprinklerFullVFX;

	private ParticleEventCall lifeSprinklerFullVFXParticleEventCall;

	private ParticleSystem lifeSprinklerCrossVFX;

	private ParticleEventCall lifeSprinklerCrossVFXParticleEventCall;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _alphaTween;

	private Timer _hitboxTimer;

	private MultiTargetTween _moveTween;

	private Timer _movementTimer;

	private EME_Longsword1Weapon _trueweapon;

	private PhaserSprite cloneImage1;

	private PhaserSprite cloneImage2;

	private PhaserSprite cloneImage3;

	private PhaserSprite cloneImage4;

	private MultiTargetTween _fadeInClonesTween;

	private MultiTargetTween _fadeClonesTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	private unsafe void MakeCloneSprites()
	{
		//IL_00de: Expected O, but got I
		//IL_00f3: Expected O, but got I
		//IL_019b: Expected I4, but got O
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterController._characterType);
		if (obj == null)
		{
			GameManager core2 = GM.Core;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = core2._dataManager.GetConvertedCharacterData();
			obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)1);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v36 (System.Object)+18]");
		bool flag = (nint)0 <= (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v36 (System.Object)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v34+20]");
		CharacterData characterData = (CharacterData)0;
		string textureName;
		string text;
		int end;
		int fps;
		if (characterData._003Cskins_003Ek__BackingField == null)
		{
			bool flag2 = (object)characterData._003CwalkFrameRate_003Ek__BackingField == null;
			textureName = characterData._003CtextureName_003Ek__BackingField;
			text = characterData._003CspriteName_003Ek__BackingField;
			end = characterData._003CwalkingFrames_003Ek__BackingField;
			if (!flag2)
			{
				if ((object)characterData._003CwalkFrameRate_003Ek__BackingField != null)
				{
					fps = (object?)characterData._003CwalkFrameRate_003Ek__BackingField >> 32;
					goto IL_02a2;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				goto IL_07e1;
			}
		}
		else
		{
			Skin currentSkinData = characterData.GetCurrentSkinData();
			SpriteAnims spriteAnims = currentSkinData._003CspriteAnims_003Ek__BackingField;
			if (currentSkinData._003CspriteAnims_003Ek__BackingField != null && spriteAnims._003CmeleeAttack_003Ek__BackingField != null)
			{
				MeleeAttack meleeAttack = spriteAnims._003CmeleeAttack_003Ek__BackingField;
				textureName = meleeAttack._003CtextureName_003Ek__BackingField;
				SpriteAnims spriteAnims2 = currentSkinData._003CspriteAnims_003Ek__BackingField;
				MeleeAttack meleeAttack2 = spriteAnims2._003CmeleeAttack_003Ek__BackingField;
				MeleeAttack meleeAttack3 = spriteAnims2._003CmeleeAttack_003Ek__BackingField;
				text = meleeAttack2._003CspriteName_003Ek__BackingField;
				end = meleeAttack3._003CframesNumber_003Ek__BackingField;
				fps = 16;
				goto IL_02a2;
			}
			textureName = currentSkinData._003CtextureName_003Ek__BackingField;
			text = currentSkinData._003CspriteName_003Ek__BackingField;
			end = currentSkinData._003CwalkingFrames_003Ek__BackingField;
		}
		fps = 8;
		goto IL_02a2;
		IL_02a2:
		string animName = text.Replace("01.png", "");
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, end, textureName, num);
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "textureName", "spriteName");
		cloneImage1 = phaserSprite;
		PhaserWorld instance2 = PhaserWorld.Instance;
		PhaserSprite phaserSprite2 = instance2.AddPhaserSprite(pos, "textureName", "spriteName");
		cloneImage2 = phaserSprite2;
		PhaserWorld instance3 = PhaserWorld.Instance;
		PhaserSprite phaserSprite3 = instance3.AddPhaserSprite(pos, "textureName", "spriteName");
		cloneImage3 = phaserSprite3;
		PhaserWorld instance4 = PhaserWorld.Instance;
		PhaserSprite phaserSprite4 = instance4.AddPhaserSprite(pos, "textureName", "spriteName");
		cloneImage4 = phaserSprite4;
		PhaserSprite phaserSprite5 = cloneImage1;
		bool flag3 = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		phaserSprite5._spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num != 0, flag3, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite6 = cloneImage1;
		phaserSprite6._spriteAnimation.SetAnimation("walk");
		PhaserSprite phaserSprite7 = cloneImage2;
		phaserSprite7._spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num != 0, flag3, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite8 = cloneImage2;
		phaserSprite8._spriteAnimation.SetAnimation("walk");
		PhaserSprite phaserSprite9 = cloneImage3;
		phaserSprite9._spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num != 0, flag3, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite10 = cloneImage3;
		phaserSprite10._spriteAnimation.SetAnimation("walk");
		PhaserSprite phaserSprite11 = cloneImage4;
		phaserSprite11._spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num != 0, flag3, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite12 = cloneImage4;
		phaserSprite12._spriteAnimation.SetAnimation("walk");
		PhaserSprite phaserSprite13 = cloneImage1.setTint(16760438u, 16761033u, 16760438u, (uint)num, flag3 ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite14 = cloneImage2.setTint(16760438u, 16761033u, 16760438u, (uint)num, flag3 ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite15 = cloneImage3.setTint(16760438u, 16761033u, 16760438u, (uint)num, flag3 ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite16 = cloneImage4.setTint(16760438u, 16761033u, 16760438u, (uint)num, flag3 ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite17 = cloneImage1.setAlpha(0f);
		PhaserSprite phaserSprite18 = cloneImage2.setAlpha(0f);
		PhaserSprite phaserSprite19 = cloneImage3.setAlpha(0f);
		PhaserSprite phaserSprite20 = cloneImage4.setAlpha(0f);
		PhaserSprite phaserSprite21 = cloneImage3.setFlipX(flipX: true);
		PhaserSprite phaserSprite22 = cloneImage4.setFlipX(flipX: true);
		Transform transform = cloneImage1.transform;
		Transform parent = base.transform;
		transform.SetParent(parent, worldPositionStays: true);
		Transform transform2 = cloneImage2.transform;
		Transform parent2 = base.transform;
		transform2.SetParent(parent2, worldPositionStays: true);
		Transform transform3 = cloneImage3.transform;
		Transform parent3 = base.transform;
		transform3.SetParent(parent3, worldPositionStays: true);
		Transform transform4 = cloneImage4.transform;
		Transform parent4 = base.transform;
		transform4.SetParent(parent4, worldPositionStays: true);
		Transform transform5 = cloneImage1.transform;
		goto IL_07e1;
		IL_07e1:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ rax_v84 (UnityEngine.Transform)+10]");
		bool flag4 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ rax_v84 (UnityEngine.Transform)+10]");
		Vector2 value = default(Vector2);
		Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
		Transform transform6 = cloneImage2.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rax_v89 (UnityEngine.Transform)+10]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rax_v89 (UnityEngine.Transform)+10]");
		Vector2 value2 = default(Vector2);
		Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value2));
		Transform transform7 = cloneImage3.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1124 @ rax_v94 (UnityEngine.Transform)+10]");
		bool flag6 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1124 @ rax_v94 (UnityEngine.Transform)+10]");
		Vector2 value3 = default(Vector2);
		Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value3));
		Transform transform8 = cloneImage4.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1125 @ rax_v99 (UnityEngine.Transform)+10]");
		bool flag7 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1125 @ rax_v99 (UnityEngine.Transform)+10]");
		Vector2 value4 = default(Vector2);
		Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value4));
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0035: Expected I4, but got O
		//IL_014a: Expected I, but got O
		//IL_0152: Expected I, but got O
		//IL_0162: Expected O, but got I
		//IL_01e2: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_0ca4: Expected O, but got I4
		//IL_019e: Expected O, but got I
		//IL_01d4: Expected O, but got I4
		//IL_0233: Expected O, but got I4
		//IL_0233: Expected O, but got I4
		//IL_0247: Expected O, but got I4
		//IL_046c: Expected O, but got Ref
		//IL_04a2: Expected I4, but got O
		//IL_0d94: Expected O, but got F4
		//IL_0dbb: Expected F4, but got I8
		//IL_0671: Expected O, but got I4
		//IL_0565: Expected O, but got F4
		//IL_0572: Expected F4, but got I8
		//IL_057f: Expected F4, but got I8
		//IL_095f: Expected O, but got I4
		//IL_0b8a: Expected O, but got I4
		//IL_064c->IL0c40: Incompatible stack heights: 1 vs 0
		//IL_0dd1->IL0591: Incompatible stack heights: 1 vs 0
		//IL_069c->IL0c40: Incompatible stack heights: 1 vs 0
		//IL_0539->IL0c40: Incompatible stack heights: 1 vs 0
		//IL_0591->IL0591: Incompatible stack heights: 1 vs 0
		//IL_07ab->IL0c40: Incompatible stack heights: 1 vs 0
		//IL_07ff->IL07ff: Incompatible stack heights: 2 vs 1
		//IL_0858->IL0858: Incompatible stack heights: 2 vs 1
		//IL_092c->IL0c40: Incompatible stack heights: 1 vs 0
		//IL_08b1->IL08b1: Incompatible stack heights: 2 vs 1
		//IL_090a->IL090a: Incompatible stack heights: 2 vs 1
		//IL_09e4->IL0c40: Incompatible stack heights: 1 vs 0
		//IL_0a38->IL0a38: Incompatible stack heights: 2 vs 1
		//IL_0a91->IL0a91: Incompatible stack heights: 2 vs 1
		//IL_0b65->IL0c40: Incompatible stack heights: 1 vs 0
		//IL_0aea->IL0aea: Incompatible stack heights: 2 vs 1
		//IL_0b43->IL0b43: Incompatible stack heights: 2 vs 1
		//IL_0bb5->IL0c40: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals25 = new _003C_003Ec__DisplayClass18_0();
		if (CS_0024_003C_003E8__locals25 != null)
		{
			CS_0024_003C_003E8__locals25._003C_003E4__this = this;
			CS_0024_003C_003E8__locals25.weapon = weapon;
			base.InitProjectile(pool, CS_0024_003C_003E8__locals25.weapon, index);
			int num = (int)cloneImage1;
			if ((object)cloneImage1 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdi_v15 (System.Int32)+10]");
				if ((nint)0 != 0)
				{
					goto IL_007c;
				}
			}
			MakeCloneSprites();
			goto IL_007c;
		}
		goto IL_0c40;
		IL_0c7d:
		float? trueweapon;
		_trueweapon = (EME_Longsword1Weapon)trueweapon;
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(48f, (float?)(object)1, (float?)(object)1);
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			if (_movementTimer != null)
			{
				_movementTimer.Cancel();
			}
			Action onComplete = delegate
			{
				CS_0024_003C_003E8__locals25._003C_003E4__this.GoToNearestEnemy();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer movementTimer = Timers.Register(0.3f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_movementTimer = movementTimer;
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			if ((object)_weapon != null)
			{
				float hitBoxDelay = _weapon.HitBoxDelay;
				Action onComplete2 = delegate
				{
					//IL_006a: Expected O, but got I
					ArcadeSprite arcadeSprite3 = CS_0024_003C_003E8__locals25._003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (ArcadeSprite)+118]");
					if ((nint)0 != 0)
					{
						float2 float6 = arcadeSprite3.position;
						float num15 = CS_0024_003C_003E8__locals25.weapon.PAmount();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (ArcadeSprite)+118]");
						Vector2 pos = default(Vector2);
						float _amount = default(float);
						((EME_Longsword1Weapon)0).FireLSSlashes(pos, CS_0024_003C_003E8__locals25._003C_003E4__this, _amount);
					}
					EME_LongswordProjectile_LifeSprinkler eME_LongswordProjectile_LifeSprinkler = CS_0024_003C_003E8__locals25._003C_003E4__this;
					eME_LongswordProjectile_LifeSprinkler.lifeSprinklerCrossVFX.Play(withChildren: true);
					EME_LongswordProjectile_LifeSprinkler eME_LongswordProjectile_LifeSprinkler2 = CS_0024_003C_003E8__locals25._003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				};
				float duration = hitBoxDelay * 0.001f;
				Timer hitboxTimer = Timers.Register(duration, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_hitboxTimer = hitboxTimer;
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					Weapon weapon2 = CS_0024_003C_003E8__locals25.weapon;
					if ((object)CS_0024_003C_003E8__locals25.weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
					{
						Transform transform = ((Equipment)weapon2)._003COwner_003Ek__BackingField.transform;
						if ((object)transform != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v69 (UnityEngine.Transform)+10]");
							if ((nint)0 == 0)
							{
								UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v69 (UnityEngine.Transform)+10]");
								float ret;
								Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
								if ((object)core._stage != null)
								{
									float? num2 = default(float?);
									EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&num2));
									int num3;
									if ((object)enemyController != null)
									{
										Transform transform2 = enemyController.transform;
										num3 = (int)transform2;
									}
									else
									{
										num3 = 0;
									}
									bool flag = num3 == 0;
									float num4 = 3.4028235E+38f;
									float num5 = ret;
									float num6 = 1f;
									Projectile projectile = null;
									if (!flag)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ rdi_v19 (System.Int32)+10]");
										bool flag2 = (nint)0 == 0;
										num4 = 3.4028235E+38f;
										num5 = ret;
										num6 = 1f;
										projectile = null;
										if (!flag2)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ rdi_v19 (System.Int32)+10]");
											bool flag3 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ rdi_v19 (System.Int32)+10]");
											Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
											float num7 = default(float);
											base.position = (float2)num7;
											bool flag4 = (object)_trueweapon == null;
											num4 = 3.4028235E+38f;
											num5 = 3.2589742E+09f;
											num6 = num7;
											projectile = null;
											if (!flag4)
											{
												float2 float5 = base.position;
												if ((object)CS_0024_003C_003E8__locals25.weapon == null)
												{
													goto IL_0c40;
												}
												float num8 = CS_0024_003C_003E8__locals25.weapon.PAmount();
												_trueweapon.FireLSSlashes((Vector2)num7, this, -48f);
												num4 = 3.2589742E+09f;
												num5 = 3.2589742E+09f;
												num6 = num7;
												projectile = this;
											}
										}
									}
									if (_despawnTween != null)
									{
										_despawnTween.Kill();
									}
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if (array != null)
									{
										int value = ((int*)(&array))->m_value;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj = default(object);
										bool flag5 = obj == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null)
										{
											tweenConfig.targets = array;
											tweenConfig.alpha = (float?)(object)1;
											tweenConfig.duration = 1000f;
											if ((object)CS_0024_003C_003E8__locals25.weapon != null)
											{
												float num9 = CS_0024_003C_003E8__locals25.weapon.PDuration();
												float num10 = (tweenConfig.delay = num5 * 10f);
												TweenCallback onStart = delegate
												{
													EME_LongswordProjectile_LifeSprinkler eME_LongswordProjectile_LifeSprinkler = CS_0024_003C_003E8__locals25._003C_003E4__this;
													if (eME_LongswordProjectile_LifeSprinkler._movementTimer != null)
													{
														eME_LongswordProjectile_LifeSprinkler._movementTimer.Cancel();
													}
													EME_LongswordProjectile_LifeSprinkler eME_LongswordProjectile_LifeSprinkler2 = CS_0024_003C_003E8__locals25._003C_003E4__this;
													if (eME_LongswordProjectile_LifeSprinkler2._hitboxTimer != null)
													{
														eME_LongswordProjectile_LifeSprinkler2._hitboxTimer.Cancel();
													}
													EME_LongswordProjectile_LifeSprinkler eME_LongswordProjectile_LifeSprinkler3 = CS_0024_003C_003E8__locals25._003C_003E4__this;
													eME_LongswordProjectile_LifeSprinkler3.lifeSprinklerFullVFX.Stop();
												};
												tweenConfig.onStart = onStart;
												TweenCallback onComplete3 = delegate
												{
													CS_0024_003C_003E8__locals25._003C_003E4__this.Despawn();
												};
												tweenConfig.onComplete = onComplete3;
												MultiTargetTween despawnTween = Tweens.Add(tweenConfig);
												_despawnTween = despawnTween;
												if (_fadeInClonesTween != null)
												{
													_fadeInClonesTween.Kill();
												}
												TweenConfig tweenConfig2 = new TweenConfig();
												object[] array2 = new object[4];
												if (array2 != null)
												{
													if ((object)cloneImage1 != null)
													{
														int value2 = ((int*)(&array2))->m_value;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj2 = default(object);
														bool flag6 = obj2 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if ((object)cloneImage2 != null)
													{
														int value3 = ((int*)(&array2))->m_value;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj3 = default(object);
														bool flag7 = obj3 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if ((object)cloneImage3 != null)
													{
														int value4 = ((int*)(&array2))->m_value;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj4 = default(object);
														bool flag8 = obj4 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if ((object)cloneImage4 != null)
													{
														int value5 = ((int*)(&array2))->m_value;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj5 = default(object);
														bool flag9 = obj5 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig2 != null)
													{
														tweenConfig2.targets = array2;
														tweenConfig2.duration = 200f;
														tweenConfig2.alpha = (float?)(object)1;
														MultiTargetTween fadeInClonesTween = Tweens.Add(tweenConfig2);
														_fadeInClonesTween = fadeInClonesTween;
														if (_fadeClonesTween != null)
														{
															_fadeClonesTween.Kill();
														}
														TweenConfig tweenConfig3 = new TweenConfig();
														object[] array3 = new object[4];
														if (array3 != null)
														{
															if ((object)cloneImage1 != null)
															{
																int value6 = ((int*)(&array3))->m_value;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj6 = default(object);
																bool flag10 = obj6 == null;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)cloneImage2 != null)
															{
																int value7 = ((int*)(&array3))->m_value;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj7 = default(object);
																bool flag11 = obj7 == null;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)cloneImage3 != null)
															{
																int value8 = ((int*)(&array3))->m_value;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj8 = default(object);
																bool flag12 = obj8 == null;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)cloneImage4 != null)
															{
																int value9 = ((int*)(&array3))->m_value;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj9 = default(object);
																bool flag13 = obj9 == null;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if (tweenConfig3 != null)
															{
																tweenConfig3.targets = array3;
																tweenConfig3.alpha = (float?)(object)1;
																tweenConfig3.duration = 1000f;
																if ((object)CS_0024_003C_003E8__locals25.weapon != null)
																{
																	float num11 = CS_0024_003C_003E8__locals25.weapon.PDuration();
																	float delay = num10 * 10f;
																	tweenConfig3.delay = delay;
																	MultiTargetTween fadeClonesTween = Tweens.Add(tweenConfig3);
																	_fadeClonesTween = fadeClonesTween;
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
		goto IL_0c40;
		IL_0c8c:
		object obj10;
		bool flag14 = obj10 == null;
		trueweapon = (float?)(object)0;
		if (!flag14)
		{
			trueweapon = (float?)CS_0024_003C_003E8__locals25.weapon;
		}
		goto IL_0c7d;
		IL_0c40:
		throw new NullReferenceException();
		IL_007c:
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		if ((object)lifeSprinklerFullVFX != null)
		{
			lifeSprinklerFullVFX.Play(withChildren: true);
			BaseBody baseBody2 = body;
			_isCullable = false;
			if (body != null)
			{
				baseBody2._enable = false;
				Weapon weapon3 = CS_0024_003C_003E8__locals25.weapon;
				if ((object)CS_0024_003C_003E8__locals25.weapon == null)
				{
					trueweapon = (float?)(object)0;
					goto IL_0c7d;
				}
				nint num12 = (nint)typeof(EME_Longsword1Weapon);
				nint num13 = (nint)weapon3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ r8_v90 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Longsword1Weapon>)+130]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1088 @ r9_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ r8_v90 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Longsword1Weapon>)+130]");
				if (num14 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1088 @ r9_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1144 @ rax_v231+FFFFFFF8+v1089 @ rax_v226*8]");
					if (0 == (nint)typeof(EME_Longsword1Weapon))
					{
						obj10 = 1;
						goto IL_0c8c;
					}
				}
				obj10 = 0;
				goto IL_0c8c;
			}
		}
		goto IL_0c40;
	}

	private unsafe void GoToNearestEnemy()
	{
		//IL_0223: Expected O, but got F4
		//IL_022c: Invalid comparison between F4 and O
		//IL_024b: Invalid comparison between F4 and I4
		//IL_0274: Expected O, but got I4
		//IL_0060: Expected O, but got Ref
		//IL_0100: Expected I, but got O
		//IL_0152: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		//IL_018f->IL018f: Incompatible stack heights: 1 vs 0
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.2f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		float num = 0.2f - (float)obj2;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj3 = flag4 & flag3;
		if (obj3 != null)
		{
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		}
		else
		{
			object cachedTransform = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v7 (System.Object)+10]");
			if ((nint)0 == 0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v7 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
		}
		GameManager core = GM.Core;
		object obj4 = default(object);
		EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj4));
		if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
		{
			float2 float6 = enemyController.position;
			if (_moveTween != null)
			{
				_moveTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			bool flag5 = obj5 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.x = (float?)(object)1;
			tweenConfig.duration = 100f;
			tweenConfig.y = (float?)(object)1;
			MultiTargetTween moveTween = Tweens.Add(tweenConfig);
			_moveTween = moveTween;
		}
	}

	public override void Despawn()
	{
		if (_fadeInClonesTween != null)
		{
			_fadeInClonesTween.Kill();
		}
		if (_fadeClonesTween != null)
		{
			_fadeClonesTween.Kill();
		}
		if ((object)lifeSprinklerFullVFX != null)
		{
			lifeSprinklerFullVFX.Stop();
		}
		if ((object)lifeSprinklerFullVFX != null)
		{
			lifeSprinklerFullVFX.Clear(withChildren: true);
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		base.Despawn();
	}

	private void LateUpdate()
	{
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float6 = base.position;
		object obj = default(object);
		float num = (float)obj - 0.48f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float7 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float8 = base.position;
		float num2 = (float)obj - 0.48f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
	}

	private void DespawnAfterParticlesToFinish()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		if ((object)lifeSprinklerFullVFX != null)
		{
			lifeSprinklerFullVFX.Clear(withChildren: true);
		}
		base.Despawn();
	}
}
