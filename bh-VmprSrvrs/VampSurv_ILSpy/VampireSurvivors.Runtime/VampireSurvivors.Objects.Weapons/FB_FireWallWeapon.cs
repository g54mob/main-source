using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_FireWallWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public FlameData flameData;

		public PhaserSprite flameSprite;

		internal void _003CaddFlameSprite_003Eb__0()
		{
			FlameData flameData = this.flameData;
			flameData.active = false;
			PhaserSprite phaserSprite = flameSprite.setVisible(visible: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public FB_FireWallWeapon _003C_003E4__this;

		public Destructible destructible;

		public FB_FireWallProjectile bullet;

		public Vector3 destructiblePos;
	}

	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

		internal void _003COnBulletOverlapsDestructible_003Eb__0()
		{
			//IL_045d: Expected O, but got I4
			//IL_00da: Expected O, but got I
			//IL_0109: Expected I, but got O
			//IL_0117: Expected I, but got O
			//IL_0127: Expected O, but got I
			//IL_01a7: Expected O, but got I4
			//IL_0163: Expected O, but got I
			//IL_0199: Expected O, but got I4
			//IL_0084->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_00b3->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_01de->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_024a->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_0276->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_02ad->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_02e0->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_0319->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_033b->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_0376->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_0398->IL03fd: Incompatible stack heights: 1 vs 0
			//IL_03e9->IL03fd: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass6_0 obj = CS_0024_003C_003E8__locals1;
			_003C_003Ec__DisplayClass6_0 obj3;
			GameObject gameObject2;
			GameObject bullet;
			object obj6;
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
					obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						FB_FireWallWeapon fB_FireWallWeapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null)
						{
							IntPtr intPtr = default(IntPtr);
							gameObject2 = (GameObject)(object)obj3._003C_003E4__this.FireOneProjectile((Vector2)(nint)intPtr, localIndex, fB_FireWallWeapon._targetTransform);
							bool flag2 = (object)gameObject2 == null;
							bullet = null;
							if (flag2)
							{
								goto IL_047a;
							}
							nint num = (nint)gameObject2;
							nint num2 = (nint)typeof(FB_FireWallProjectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile>)+130]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r8_v12 (Il2CppClass<UnityEngine.GameObject>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r8_v12 (Il2CppClass<UnityEngine.GameObject>)+C8]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v45+FFFFFFF8+v538 @ rax_v41*8]");
								if (0 == (nint)typeof(FB_FireWallProjectile))
								{
									obj6 = 1;
									goto IL_048c;
								}
							}
							obj6 = 0;
							goto IL_048c;
						}
					}
				}
			}
			goto IL_03fd;
			IL_047a:
			obj3.bullet = (FB_FireWallProjectile)(object)bullet;
			_003C_003Ec__DisplayClass6_0 obj7 = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				FB_FireWallProjectile bullet2 = obj7.bullet;
				if ((object)obj7.bullet == null || ((UnityEngine.Object)bullet2).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				GameObject gameObject3 = (GameObject)(object)CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null)
				{
					_003C_003Ec__DisplayClass6_0 obj8 = CS_0024_003C_003E8__locals1;
					if ((object)obj8.destructible != null)
					{
						float2 position = obj8.destructible.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdi_v10 (UnityEngine.GameObject)+20]");
						if ((nint)0 != 0)
						{
							GameObject gameObject4 = (GameObject)(object)CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								_003C_003Ec__DisplayClass6_0 obj9 = CS_0024_003C_003E8__locals1;
								FB_FireWallWeapon fB_FireWallWeapon2 = obj9._003C_003E4__this;
								if ((object)obj9._003C_003E4__this != null && (object)((Equipment)fB_FireWallWeapon2)._003COwner_003Ek__BackingField != null)
								{
									float2 position2 = ((Equipment)fB_FireWallWeapon2)._003COwner_003Ek__BackingField.position;
									_003C_003Ec__DisplayClass6_0 obj10 = CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals1 != null && (object)obj10.destructible != null)
									{
										float2 position3 = obj10.destructible.position;
										object obj11 = position2 - position3;
										object obj13 = default(object);
										object obj14 = default(object);
										object obj12 = obj13 - obj14;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdi_v12 (UnityEngine.GameObject)+20]");
										if ((nint)0 != 0)
										{
											return;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_03fd;
			IL_03fd:
			throw new NullReferenceException();
			IL_048c:
			bool flag3 = obj6 == null;
			bullet = null;
			if (!flag3)
			{
				bullet = gameObject2;
			}
			goto IL_047a;
		}
	}

	private List<FlameData> flameData;

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0033: Expected F4, but got I4
		//IL_0065: Expected F4, but got I4
		//IL_009c: Expected F4, but got I4
		base.Fire(skipTriggers);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_FlameShot, 100f, 10, 0f, volume, rate, detune, loop, 1f);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_FlameShot, 100f, 10, 0f, volume, rate, detune, loop, 1f);
		PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_FlameShot, 100f, 10, 0f, volume, rate, detune, loop, 1f);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_explosionType = WeaponType.FIREEXPLOSION;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
	}

	private FlameData nextFlameData()
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_046a->IL03b7: Incompatible stack heights: 1 vs 0
		//IL_01d8->IL03b7: Incompatible stack heights: 1 vs 0
		//IL_0232->IL03b7: Incompatible stack heights: 1 vs 0
		//IL_028d->IL03b7: Incompatible stack heights: 1 vs 0
		//IL_02c2->IL03b7: Incompatible stack heights: 1 vs 0
		//IL_02fd->IL03b7: Incompatible stack heights: 1 vs 0
		//IL_034c->IL03b7: Incompatible stack heights: 1 vs 0
		//IL_03b7->IL0161: Incompatible stack heights: 1 vs 0
		//IL_0388->IL0161: Incompatible stack heights: 1 vs 0
		List<FlameData> list = this.flameData;
		if (this.flameData != null)
		{
			List<FlameData> list2 = this.flameData;
			Transform transform = null;
			Transform transform2 = null;
			object obj = default(object);
			Vector2 pos = default(Vector2);
			int num = default(int);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			FlameData flameData2 = default(FlameData);
			while (true)
			{
				if ((nint)transform2 < list._size)
				{
					if ((nint)transform < list2._size)
					{
						FlameData[] items = list2._items;
						if (list2._items == null)
						{
							break;
						}
						if ((nint)transform < items.Length)
						{
							FlameData flameData = items[(object)transform];
							if (items[(object)transform] == null)
							{
								break;
							}
							if (flameData.active)
							{
								transform = (Transform)(transform + 1);
								transform2 = transform;
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if (obj == null)
							{
								break;
							}
							_ = 1;
							if (this.flameData == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							goto IL_0161;
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					throw new IndexOutOfRangeException();
				}
				PhaserWorld instance = PhaserWorld.Instance;
				Transform transform3 = base.transform;
				if ((object)transform3 == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
				if ((object)instance == null)
				{
					break;
				}
				PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "firstBlood", "Firearm-Firewall-F1");
				if ((object)phaserSprite == null)
				{
					break;
				}
				PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Firearm-Firewall-F", 1, 4, "firstBlood", num);
				if ((object)phaserSprite._spriteAnimation == null)
				{
					break;
				}
				phaserSprite._spriteAnimation.AddAnimation("play", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
				SpriteAnimation spriteAnimation = phaserSprite._spriteAnimation;
				if ((object)phaserSprite._spriteAnimation == null)
				{
					break;
				}
				((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
				flameData2 = new FlameData();
				if (flameData2 == null)
				{
					break;
				}
				flameData2.flameSprite = phaserSprite;
				List<object> list3 = (List<object>)(object)this.flameData;
				if (this.flameData == null)
				{
					break;
				}
				int version = list3._version + 1;
				list3._version = version;
				object[] items2 = list3._items;
				if (list3._items == null)
				{
					break;
				}
				if (list3._size >= items2.Length)
				{
					((List<object>)(object)this.flameData).AddWithResize((object)flameData2);
				}
				else
				{
					int size = list3._size + 1;
					list3._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				goto IL_0161;
				IL_0161:
				return flameData2;
			}
		}
		throw new NullReferenceException();
	}

	public void addFlameSprite(float2 pos)
	{
		//IL_016d: Expected I, but got O
		//IL_01c3: Expected O, but got I4
		//IL_03b7: Expected O, but got I4
		//IL_027d: Expected I, but got O
		//IL_02d3: Expected O, but got I4
		//IL_02fd: Expected O, but got I4
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass5_0();
		FlameData flameData = nextFlameData();
		CS_0024_003C_003E8__locals14.flameData = flameData;
		if (CS_0024_003C_003E8__locals14.flameData == null)
		{
			return;
		}
		FlameData flameData2 = CS_0024_003C_003E8__locals14.flameData;
		CS_0024_003C_003E8__locals14.flameSprite = flameData2.flameSprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite flameSprite = CS_0024_003C_003E8__locals14.flameSprite;
		flameSprite._spriteAnimation.SetAnimation("play");
		PhaserSprite phaserSprite = CS_0024_003C_003E8__locals14.flameSprite.setVisible(visible: true);
		FlameData flameData3 = CS_0024_003C_003E8__locals14.flameData;
		if (flameData3.flameTweenIn != null)
		{
			flameData3.flameTweenIn.Kill();
		}
		FlameData flameData4 = CS_0024_003C_003E8__locals14.flameData;
		if (flameData4.flameTweenOut != null)
		{
			flameData4.flameTweenOut.Kill();
		}
		FlameData flameData5 = CS_0024_003C_003E8__locals14.flameData;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)CS_0024_003C_003E8__locals14.flameSprite != null)
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
		tweenConfig.alpha = (float?)(object)1;
		float num2 = base.PArea();
		float num3 = default(float);
		bool flag = num3 > 4.5f;
		float num4 = 4.5f;
		if (!flag)
		{
			num4 = num3;
		}
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween flameTweenIn = Tweens.Add(tweenConfig);
		flameData5.flameTweenIn = flameTweenIn;
		FlameData flameData6 = CS_0024_003C_003E8__locals14.flameData;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)CS_0024_003C_003E8__locals14.flameSprite != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 200f;
		tweenConfig2.delay = 300f;
		tweenConfig2.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			FlameData flameData7 = CS_0024_003C_003E8__locals14.flameData;
			flameData7.active = false;
			PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals14.flameSprite.setVisible(visible: false);
		};
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween flameTweenOut = Tweens.Add(tweenConfig2);
		flameData6.flameTweenOut = flameTweenOut;
	}

	protected unsafe override bool OnBulletOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01c0: Expected I, but got O
		//IL_08ef: Expected O, but got F4
		//IL_026f: Expected I, but got O
		//IL_027d: Expected I, but got O
		//IL_028d: Expected O, but got I
		//IL_030d: Expected O, but got I4
		//IL_02c9: Expected O, but got I
		//IL_0920: Expected O, but got I4
		//IL_031b: Expected I4, but got O
		//IL_02ff: Expected O, but got I4
		//IL_097a: Expected I, but got F4
		//IL_09a3: Invalid comparison between I and F4
		//IL_0493: Invalid comparison between I and F4
		//IL_034e: Expected I, but got F4
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Expected O, but got Unknown
		//IL_051e: Expected O, but got I4
		//IL_052c: Expected I, but got O
		//IL_053c: Expected O, but got I
		//IL_05bc: Expected O, but got I4
		//IL_0578: Expected O, but got I
		//IL_09c7: Expected O, but got I4
		//IL_0440: Expected I, but got O
		//IL_0849: Invalid comparison between F4 and I4
		//IL_05ae: Expected O, but got I4
		//IL_09b5->IL085d: Incompatible stack heights: 1 vs 0
		//IL_04a5->IL085d: Incompatible stack heights: 1 vs 0
		//IL_038e->IL0863: Incompatible stack heights: 1 vs 0
		//IL_0a5b->IL0863: Incompatible stack heights: 1 vs 0
		//IL_03c2->IL0863: Incompatible stack heights: 1 vs 0
		//IL_075f->IL0863: Incompatible stack heights: 1 vs 0
		//IL_03eb->IL0863: Incompatible stack heights: 1 vs 0
		//IL_07a2->IL0863: Incompatible stack heights: 1 vs 0
		//IL_041c->IL0863: Incompatible stack heights: 1 vs 0
		//IL_046c->IL0863: Incompatible stack heights: 1 vs 0
		//IL_085d->IL085d: Incompatible stack heights: 1 vs 0
		//IL_063d->IL0863: Incompatible stack heights: 1 vs 0
		//IL_0671->IL0863: Incompatible stack heights: 1 vs 0
		//IL_06a7->IL0863: Incompatible stack heights: 1 vs 0
		//IL_06d8->IL0863: Incompatible stack heights: 1 vs 0
		//IL_072a->IL0863: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass6_0 obj = new _003C_003Ec__DisplayClass6_0();
		Projectile projectile;
		float num3 = default(float);
		bool flag2;
		object obj4;
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			if (second != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				GameObject gameObject = default(GameObject);
				if ((object)gameObject != null)
				{
					Projectile component = gameObject.GetComponent<Projectile>();
					if (first != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Destructible component2 = gameObject2.GetComponent<Destructible>();
							obj.destructible = component2;
							IDamageable destructible = obj.destructible;
							if ((object)obj.destructible != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v16 (VampireSurvivors.Interfaces.IDamageable)+D3]");
								if ((nint)0 != 0)
								{
									goto IL_085d;
								}
								if ((object)component != null)
								{
									if (component.HasAlreadyHitObject(obj.destructible))
									{
										goto IL_085d;
									}
									ArcadeColliderType destructible2 = obj.destructible;
									float num = base.PPower();
									if (_currentWeaponData != null && (object)obj.destructible != null)
									{
										nint num2 = (nint)destructible2;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v191 @ rdx_v16 (Il2CppClass<ArcadeColliderType>)+348] (should have been resolved before IL gen)");
										Component destructible3 = obj.destructible;
										if ((object)obj.destructible != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v25 (UnityEngine.Component)+D3]");
											if ((nint)0 == 0)
											{
												goto IL_085d;
											}
											Transform transform = obj.destructible.transform;
											if ((object)transform != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v26 (UnityEngine.Transform)+10]");
												bool flag = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v26 (UnityEngine.Transform)+10]");
												float2 ret;
												Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
												obj.destructiblePos = (Vector3)ret;
												_ = 0;
												projectile = base.FireOneProjectile((Vector2)num3, 0, _targetTransform);
												if ((object)projectile == null)
												{
													flag2 = false;
													goto IL_0913;
												}
												nint num4 = (nint)projectile;
												nint num5 = (nint)typeof(FB_FireWallProjectile);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile>)+130]");
												object obj2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
												nint num6 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile>)+130]");
												if (num6 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
													object obj3 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1083 @ rax_v98+FFFFFFF8+v1040 @ rax_v93*8]");
													if (0 == (nint)typeof(FB_FireWallProjectile))
													{
														obj4 = 1;
														goto IL_0932;
													}
												}
												obj4 = 0;
												goto IL_0932;
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
		goto IL_0863;
		IL_0990:
		float num7 = base.PAmount();
		nint num8;
		float num16 = default(float);
		object obj9 = default(object);
		float num15;
		if ((float)num8 > 1f)
		{
			float num9 = base.PAmount();
			if ((float)num8 > 1f)
			{
				int num10 = 1;
				bool flag3 = default(bool);
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				while (true)
				{
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData == null)
					{
						break;
					}
					object obj5 = num10 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					bool flag4;
					object obj8;
					if ((nint)obj5 <= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						if (!flag3)
						{
							flag4 = false;
							goto IL_09ba;
						}
						Action<float> action = (Action<float>)((bool*)(flag3 ? 1 : 0))->m_value;
						nint num11 = (nint)typeof(FB_FireWallProjectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile>)+130]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ r8_v19 (System.Action`1<System.Single>)+130]");
						nint num12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile>)+130]");
						if (num12 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ r8_v19 (System.Action`1<System.Single>)+C8]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1333 @ rax_v82+FFFFFFF8+v1289 @ rax_v77*8]");
							if (0 == (nint)typeof(FB_FireWallProjectile))
							{
								obj8 = 1;
								goto IL_09d9;
							}
						}
						obj8 = 0;
						goto IL_09d9;
					}
					_003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass6_1();
					if (CS_0024_003C_003E8__locals18 == null)
					{
						break;
					}
					CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1 = obj;
					CS_0024_003C_003E8__locals18.localIndex = num10;
					WeaponData currentWeaponData2 = _currentWeaponData;
					if (_currentWeaponData == null)
					{
						break;
					}
					Action onComplete = delegate
					{
						//IL_045d: Expected O, but got I4
						//IL_00da: Expected O, but got I
						//IL_0109: Expected I, but got O
						//IL_0117: Expected I, but got O
						//IL_0127: Expected O, but got I
						//IL_01a7: Expected O, but got I4
						//IL_0163: Expected O, but got I
						//IL_0199: Expected O, but got I4
						//IL_0084->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_00b3->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_01de->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_024a->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_0276->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_02ad->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_02e0->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_0319->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_033b->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_0376->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_0398->IL03fd: Incompatible stack heights: 1 vs 0
						//IL_03e9->IL03fd: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass6_0 obj10 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1;
						_003C_003Ec__DisplayClass6_0 obj12;
						GameObject gameObject4;
						GameObject bullet6;
						object obj15;
						if (CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1 != null && (object)obj10._003C_003E4__this != null)
						{
							GameObject gameObject3 = obj10._003C_003E4__this.gameObject;
							if ((object)gameObject3 != null)
							{
								bool flag11 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
								object obj11 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject3).m_CachedPtr);
								if (obj11 == null)
								{
									return;
								}
								obj12 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1 != null)
								{
									FB_FireWallWeapon fB_FireWallWeapon = obj12._003C_003E4__this;
									if ((object)obj12._003C_003E4__this != null)
									{
										IntPtr intPtr = default(IntPtr);
										gameObject4 = (GameObject)(object)obj12._003C_003E4__this.FireOneProjectile((Vector2)(nint)intPtr, CS_0024_003C_003E8__locals18.localIndex, fB_FireWallWeapon._targetTransform);
										bool flag12 = (object)gameObject4 == null;
										bullet6 = null;
										if (flag12)
										{
											goto IL_047a;
										}
										nint num18 = (nint)gameObject4;
										nint num19 = (nint)typeof(FB_FireWallProjectile);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile>)+130]");
										object obj13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r8_v12 (Il2CppClass<UnityEngine.GameObject>)+130]");
										nint num20 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile>)+130]");
										if (num20 >= 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r8_v12 (Il2CppClass<UnityEngine.GameObject>)+C8]");
											object obj14 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v45+FFFFFFF8+v538 @ rax_v41*8]");
											if (0 == (nint)typeof(FB_FireWallProjectile))
											{
												obj15 = 1;
												goto IL_048c;
											}
										}
										obj15 = 0;
										goto IL_048c;
									}
								}
							}
						}
						goto IL_03fd;
						IL_047a:
						obj12.bullet = (FB_FireWallProjectile)(object)bullet6;
						_003C_003Ec__DisplayClass6_0 obj16 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1 != null)
						{
							FB_FireWallProjectile bullet7 = obj16.bullet;
							if ((object)obj16.bullet == null || ((UnityEngine.Object)bullet7).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							GameObject gameObject5 = (GameObject)(object)CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1 != null)
							{
								_003C_003Ec__DisplayClass6_0 obj17 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1;
								if ((object)obj17.destructible != null)
								{
									float2 position7 = obj17.destructible.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdi_v10 (UnityEngine.GameObject)+20]");
									if ((nint)0 != 0)
									{
										GameObject gameObject6 = (GameObject)(object)CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1 != null)
										{
											_003C_003Ec__DisplayClass6_0 obj18 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1;
											FB_FireWallWeapon fB_FireWallWeapon2 = obj18._003C_003E4__this;
											if ((object)obj18._003C_003E4__this != null && (object)((Equipment)fB_FireWallWeapon2)._003COwner_003Ek__BackingField != null)
											{
												float2 position8 = ((Equipment)fB_FireWallWeapon2)._003COwner_003Ek__BackingField.position;
												_003C_003Ec__DisplayClass6_0 obj19 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1;
												if (CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals1 != null && (object)obj19.destructible != null)
												{
													float2 position9 = obj19.destructible.position;
													object obj20 = position8 - position9;
													object obj22 = default(object);
													object obj23 = default(object);
													object obj21 = obj22 - obj23;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdi_v12 (UnityEngine.GameObject)+20]");
													if ((nint)0 != 0)
													{
														return;
													}
												}
											}
										}
									}
								}
							}
						}
						goto IL_03fd;
						IL_03fd:
						throw new NullReferenceException();
						IL_048c:
						bool flag13 = obj15 == null;
						bullet6 = null;
						if (!flag13)
						{
							bullet6 = gameObject4;
						}
						goto IL_047a;
					};
					float num13 = (float)num10 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					float num14 = num13 * 0.001f;
					Timer lastShotTimer = Timers.Register(num14, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
					goto IL_0829;
					IL_09d9:
					bool flag5 = obj8 == null;
					flag4 = false;
					if (!flag5)
					{
						flag4 = flag3;
					}
					goto IL_09ba;
					IL_09ba:
					obj.bullet = (FB_FireWallProjectile)flag4;
					ArcadeColliderType bullet = obj.bullet;
					bool flag6 = (object)obj.bullet == null;
					num14 = num3;
					num15 = num3;
					if (!flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1362 @ rbx_v15 (ArcadeColliderType)+10]");
						bool flag7 = (nint)0 == 0;
						num14 = num3;
						num15 = num3;
						if (!flag7)
						{
							ArcadeColliderType bullet2 = obj.bullet;
							if ((object)obj.destructible == null)
							{
								break;
							}
							float2 position = obj.destructible.position;
							if ((object)obj.bullet == null)
							{
								break;
							}
							ArcadeColliderType bullet3 = obj.bullet;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
							{
								break;
							}
							float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
							if ((object)obj.destructible == null)
							{
								break;
							}
							float2 position3 = obj.destructible.position;
							num14 = (float)position2 - (float)position3;
							num15 = num16 - (float)obj9;
							if ((object)obj.bullet == null)
							{
								break;
							}
						}
					}
					goto IL_0829;
					IL_0829:
					num10++;
					float num17 = base.PAmount();
					if (num14 > (float)num10)
					{
						continue;
					}
					goto IL_085d;
				}
				goto IL_0863;
			}
		}
		goto IL_085d;
		IL_0913:
		obj.bullet = (FB_FireWallProjectile)flag2;
		ArcadeColliderType bullet4 = obj.bullet;
		bool flag8 = (object)obj.bullet == null;
		num8 = (nint)num3;
		num15 = num16;
		if (!flag8)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1110 @ rbx_v10 (ArcadeColliderType)+10]");
			bool flag9 = (nint)0 == 0;
			num8 = (nint)num3;
			num15 = num16;
			if (!flag9)
			{
				ArcadeColliderType bullet5 = obj.bullet;
				if ((object)obj.destructible != null)
				{
					float2 position4 = obj.destructible.position;
					if ((object)obj.bullet != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						if ((object)obj.destructible != null)
						{
							float2 position6 = obj.destructible.position;
							num8 = (nint)(position5 - position6);
							num15 = (float)obj9 - num16;
							if ((object)obj.bullet != null)
							{
								goto IL_0990;
							}
						}
					}
				}
				goto IL_0863;
			}
		}
		goto IL_0990;
		IL_0863:
		throw new NullReferenceException();
		IL_0932:
		bool flag10 = obj4 == null;
		flag2 = false;
		if (!flag10)
		{
			flag2 = (byte)(int)projectile != 0;
		}
		goto IL_0913;
		IL_085d:
		return false;
	}

	public unsafe override void Cleanup()
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		base.Cleanup();
		List<FlameData>.Enumerator enumerator = default(List<FlameData>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<FlameData>.Enumerator enumerator2 = (List<FlameData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public FB_FireWallWeapon()
	{
		List<FlameData> list = new List<FlameData>();
		flameData = list;
		base._002Ector();
	}
}
