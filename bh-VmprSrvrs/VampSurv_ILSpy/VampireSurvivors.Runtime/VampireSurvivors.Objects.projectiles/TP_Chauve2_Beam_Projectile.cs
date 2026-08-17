using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Chauve2_Beam_Projectile : Projectile
{
	private SpriteRenderer _muzzleFlash;

	private SpriteRenderer _muzzleFlash2;

	private SpriteRenderer _line9Slice;

	private Timer _destructionTimer;

	private float _firingCountdown;

	private float2 _startPosition;

	private float _collisionTween;

	private float2 _lastOwnerPosition;

	private float _MaxAlpha = 0.35f;

	private float _AlphaDiff = 0.65f;

	private float2 _playerTipOffset;

	private TP_Chauve2_Weapon _trueWeapon;

	private float _area;

	private const float Radius = 12f;

	public override float ProjectileSpeed => GameManager.ProjectileSpeed * _speed;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0013: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00a5: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		bool flag = (object)_weapon == null;
		TP_Chauve2_Weapon trueWeapon = null;
		if (flag)
		{
			goto IL_0113;
		}
		nint num = (nint)typeof(TP_Chauve2_Weapon);
		Weapon weapon3 = weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Chauve2_Weapon>)+130]");
		object obj = 0;
		bool isHoming = weapon3.IsHoming;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Chauve2_Weapon>)+130]");
		object obj2;
		if ((nint)(isHoming ? 1 : 0) >= (nint)0)
		{
			BulletPool projectilePool = weapon3._projectilePool;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v17 (VampireSurvivors.Objects.Pools.BulletPool)+FFFFFFF8+v60 @ rax_v13*8]");
			if (0 == (nint)typeof(TP_Chauve2_Weapon))
			{
				obj2 = 1;
				goto IL_0122;
			}
		}
		obj2 = 0;
		goto IL_0122;
		IL_0113:
		_trueWeapon = trueWeapon;
		float num2 = _weapon.PArea();
		float area = default(float);
		_area = area;
		return;
		IL_0122:
		bool flag2 = obj2 == null;
		trueWeapon = null;
		if (!flag2)
		{
			trueWeapon = (TP_Chauve2_Weapon)_weapon;
		}
		goto IL_0113;
	}

	public unsafe void ManualInitProjectile(float2 playerTipOffset, float2 angleVector)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0807: Expected O, but got I
		//IL_0836: Expected O, but got I
		//IL_005c: Expected O, but got I
		//IL_005c: Expected O, but got I
		//IL_08b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bc: Expected O, but got Unknown
		//IL_0a92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a97: Expected O, but got Unknown
		//IL_0aee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af3: Expected O, but got Unknown
		//IL_0972: Unknown result type (might be due to invalid IL or missing references)
		//IL_0977: Expected O, but got Unknown
		//IL_0734: Expected O, but got F4
		//IL_0b1b: Expected O, but got F4
		//IL_0b62: Expected O, but got I
		//IL_0771: Expected F4, but got I4
		//IL_09fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Expected O, but got Unknown
		//IL_0191->IL0776: Incompatible stack heights: 1 vs 0
		//IL_01c0->IL0776: Incompatible stack heights: 1 vs 0
		//IL_01ec->IL0776: Incompatible stack heights: 1 vs 0
		//IL_093a->IL0776: Incompatible stack heights: 2 vs 0
		//IL_0722->IL0776: Incompatible stack heights: 9 vs 0
		//IL_0286->IL0776: Incompatible stack heights: 3 vs 0
		//IL_02b5->IL0776: Incompatible stack heights: 3 vs 0
		//IL_02e1->IL0776: Incompatible stack heights: 3 vs 0
		//IL_0355->IL0776: Incompatible stack heights: 4 vs 0
		//IL_03a4->IL0776: Incompatible stack heights: 4 vs 0
		//IL_03e6->IL0776: Incompatible stack heights: 5 vs 0
		//IL_0410->IL0776: Incompatible stack heights: 5 vs 0
		//IL_0476->IL0776: Incompatible stack heights: 6 vs 0
		//IL_0492->IL0492: Incompatible stack heights: 6 vs 0
		object obj2 = default(object);
		object obj = obj2 - 95;
		float alphaDiff = 1f - _MaxAlpha;
		_AlphaDiff = alphaDiff;
		_speed = 12f;
		base.position = playerTipOffset;
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
		_ = 0;
		float num = _area * -12f;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
		_startPosition = (float2)0;
		float num2 = _area * -12f;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
		_lastOwnerPosition = (float2)0;
		_ = 1;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (body != null)
		{
			float radius = _area * 12f;
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
			BaseBody baseBody2 = baseBody.setCircle(radius, (float?)(object)num3, (float?)(object)0);
			_isCullable = false;
			if ((object)_trueWeapon != null)
			{
				Action onComplete = ActuallyRemove;
				Timer timer = Timers.Register(0.25f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				SpriteRenderer muzzleFlash = _muzzleFlash;
				if ((object)_muzzleFlash != null && ((UnityEngine.Object)muzzleFlash).m_CachedPtr != (IntPtr)0)
				{
					goto IL_0492;
				}
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					_ = 0;
					_ = 0;
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj3 = obj - 41;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
					GameObject gameObject = base.gameObject;
					Vector2 pos = default(Vector2);
					SpriteRenderer muzzleFlash2 = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "2Spell4Blue");
					_muzzleFlash = muzzleFlash2;
					if ((object)_muzzleFlash != null)
					{
						_muzzleFlash.enabled = false;
						if ((object)_muzzleFlash != null)
						{
							Transform transform2 = _muzzleFlash.transform;
							if ((object)transform2 != null)
							{
								bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2100 @ rcx_v103 (Il2CppMethodInfo)+38]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
								}
								Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)0, true);
								Transform transform3 = base.transform;
								if ((object)transform3 != null)
								{
									_ = 0;
									_ = 0;
									bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									object obj4 = obj - 41;
									Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj4);
									GameObject gameObject2 = base.gameObject;
									SpriteRenderer muzzleFlash3 = RenderingExtensions.AddSprite(gameObject2, pos, "vfx", "_blur");
									_muzzleFlash2 = muzzleFlash3;
									if ((object)_muzzleFlash2 != null)
									{
										_muzzleFlash2.enabled = false;
										if ((object)_muzzleFlash2 != null)
										{
											Transform transform4 = _muzzleFlash2.transform;
											if ((object)transform4 != null)
											{
												bool flag5 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
												nint num5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2355 @ rcx_v118 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
												}
												Transform.SetParent_Injected(((UnityEngine.Object)transform4).m_CachedPtr, (IntPtr)0, true);
												Material material = MaterialManager.GetMaterial(MaterialType.VfxScreen);
												if ((object)_muzzleFlash2 != null)
												{
													((Renderer)_muzzleFlash2).SetMaterial(material);
													SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_muzzleFlash2, 0.35f);
													Transform transform5 = base.transform;
													if ((object)transform5 != null)
													{
														_ = 0;
														_ = 0;
														bool flag6 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
														object obj5 = obj - 41;
														Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj5);
														GameObject gameObject3 = base.gameObject;
														SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(gameObject3, pos, "TP_Beam01_9Slice", "TP_Beam01_9Slice");
														if ((object)spriteRenderer2 != null)
														{
															Transform transform6 = spriteRenderer2.transform;
															if ((object)transform6 != null)
															{
																bool flag7 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
																nint num6 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2519 @ rcx_v136 (Il2CppMethodInfo)+38]");
																if ((nint)0 == 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																}
																Transform.SetParent_Injected(((UnityEngine.Object)transform6).m_CachedPtr, (IntPtr)0, true);
																((UnityEngine.Object)spriteRenderer2).SetName("ChauveBeam");
																_line9Slice = spriteRenderer2;
																if ((object)_line9Slice != null)
																{
																	_line9Slice.drawMode = SpriteDrawMode.Tiled;
																	goto IL_0492;
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
		goto IL_0776;
		IL_0776:
		throw new NullReferenceException();
		IL_0492:
		_firingCountdown = 100f;
		if ((object)_muzzleFlash != null)
		{
			Transform transform7 = _muzzleFlash.transform;
			bool flag8 = (object)transform7 == null;
			_ = 0;
			bool flag9 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
			object obj6 = obj - 41;
			Transform.set_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref *(Vector3*)obj6);
			bool flag10 = (object)_muzzleFlash2 == null;
			Transform transform8 = _muzzleFlash2.transform;
			bool flag11 = (object)transform8 == null;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1474 @ rax_v69 (UnityEngine.Transform)+10]");
			bool flag12 = (nint)0 == 0;
			object obj7 = obj - 9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1474 @ rax_v69 (UnityEngine.Transform)+10]");
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj7);
			bool flag13 = (object)_line9Slice == null;
			_line9Slice.enabled = false;
			Material material2 = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
			bool flag14 = (object)_line9Slice == null;
			((Renderer)_line9Slice).SetMaterial(material2);
			float num7 = _area - 1f;
			float num8 = num7 / 5f;
			float num9 = 1f - num8;
			float num10 = num9 * _AlphaDiff;
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(alpha: num10 + _MaxAlpha, spriteRenderer: _line9Slice);
			bool flag15 = (object)_muzzleFlash == null;
			_muzzleFlash.enabled = true;
			bool flag16 = (object)_muzzleFlash2 == null;
			_muzzleFlash2.enabled = true;
			float deltaTime = PauseSystem.DeltaTime;
			Action onComplete2 = delegate
			{
				_line9Slice.enabled = true;
			};
			float num11 = deltaTime * 0.001f;
			Timer timer2 = Timers.Register(num11, onComplete2, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			float projectileSpeed = ProjectileSpeed;
			BaseBody baseBody3 = body;
			float num12 = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
			float num13 = num12 * 0f;
			float num14 = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-15]");
			float num15 = num14 * 0f;
			if (body != null)
			{
				baseBody3._velocity = (float2)num13;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
				{
					Rate = 0.8f
				};
				object obj8 = UnityEngine.Random.value;
				float num16 = num15 * 300f;
				_ = 0;
				_ = 1061997773;
				float detune = num16 + 200f;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
				soundConfig.Volume = (float?)(object)0;
				soundConfig.Detune = detune;
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Nitesco1, soundConfig, 200f, 5, flag ? 1 : 0);
				return;
			}
		}
		goto IL_0776;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00fd: Expected I, but got O
		//IL_0056: Invalid comparison between I4 and F4
		//IL_00ab: Expected F4, but got I4
		//IL_00b0: Expected I, but got O
		//IL_07cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d0: Expected O, but got Unknown
		//IL_0081: Expected I, but got O
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0874: Expected O, but got Unknown
		//IL_01e4: Expected F4, but got I4
		//IL_009d: Expected I, but got O
		//IL_01f2: Expected F4, but got I4
		//IL_02d4: Expected O, but got Ref
		//IL_03cf: Invalid comparison between F4 and I4
		//IL_0556: Expected O, but got Ref
		//IL_06b0: Invalid comparison between I4 and F4
		//IL_0355->IL072d: Incompatible stack heights: 1 vs 0
		//IL_03aa->IL072d: Incompatible stack heights: 1 vs 0
		//IL_0419->IL072d: Incompatible stack heights: 1 vs 0
		//IL_0452->IL072d: Incompatible stack heights: 1 vs 0
		//IL_0474->IL072d: Incompatible stack heights: 1 vs 0
		//IL_04a5->IL072d: Incompatible stack heights: 1 vs 0
		//IL_0518->IL072d: Incompatible stack heights: 1 vs 0
		//IL_0544->IL072d: Incompatible stack heights: 1 vs 0
		//IL_05c0->IL072d: Incompatible stack heights: 1 vs 0
		//IL_05f9->IL072d: Incompatible stack heights: 1 vs 0
		//IL_061b->IL072d: Incompatible stack heights: 1 vs 0
		//IL_064c->IL072d: Incompatible stack heights: 1 vs 0
		//IL_06e3->IL072d: Incompatible stack heights: 1 vs 0
		//IL_0712->IL072d: Incompatible stack heights: 1 vs 0
		bool flag = _destructionTimer == null;
		float num = 1f;
		if (!flag)
		{
			float timeRemaining = _destructionTimer.GetTimeRemaining();
			float num2 = timeRemaining * 1000f;
			num = num2 / 1300f;
			if (!(0f > num))
			{
				bool flag2 = !(num > 1f);
				nint num3 = unchecked((nint)null);
				if (!flag2)
				{
					num = 1f;
					num3 = unchecked((nint)null);
				}
			}
			else
			{
				num = 0f;
				nint num3 = unchecked((nint)null);
			}
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num4 = deltaTime * 10f;
		float num5 = num4 * num;
		float num6 = (_collisionTween = num5 + _collisionTween);
		if (num6 > num)
		{
			_collisionTween = 0f;
			if (_objectsHit == null)
			{
				goto IL_072d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
		float2 float5 = base.position;
		nint num7 = (nint)this;
		float num8 = (float)_startPosition - (float)float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Chauve2_Beam_Projectile)+F8]");
		object obj = default(object);
		float num9 = 0f - (float)obj;
		float projectileSpeed = ProjectileSpeed;
		float num10 = num6 * 1.3f;
		float num11 = num8 * num8;
		float num12 = num9 * num9;
		float num13 = num11 + num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		if (num13 > num10)
		{
			float num14 = num8 / num13;
			float num15 = num9 / num13;
			num8 = num14 * num10;
			num9 = num15 * num10;
		}
		object obj2 = num8 & -2147483649L;
		if ((nint)obj2 > 2139095040)
		{
			num8 = 0f;
		}
		object obj3 = num9 & -2147483649L;
		if ((nint)obj3 > 2139095040)
		{
			num9 = 0f;
		}
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			int num16 = ((Equipment)weapon)._003COwner_003Ek__BackingField.depth;
			if ((object)_line9Slice != null)
			{
				int sortingOrder = num16 - 2;
				_line9Slice.sortingOrder = sortingOrder;
				if ((object)_line9Slice != null)
				{
					Transform transform = _line9Slice.transform;
					float2 float6 = base.position;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector2 value = default(Vector2);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					Transform transform2 = _line9Slice.transform;
					Vector2 vector = default(Vector2);
					transform2.localEulerAngles = (Vector3)(&vector);
					float num17 = ((_indexInWeapon >= 0) ? 1f : 0.5f);
					float yScale = _area * num17;
					SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_line9Slice, 1f, yScale);
					if ((object)_line9Slice != null)
					{
						Vector2 vector2 = default(Vector2);
						_line9Slice.size = vector2;
						if (_destructionTimer == null)
						{
							if ((object)_line9Slice == null)
							{
								goto IL_072d;
							}
							_line9Slice.enabled = true;
						}
						if (!(_firingCountdown > 0f))
						{
							return;
						}
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_muzzleFlash, 2f);
						if ((object)_muzzleFlash != null)
						{
							_muzzleFlash.enabled = true;
							Weapon weapon2 = _weapon;
							if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
							{
								int num18 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.depth;
								if ((object)_muzzleFlash != null)
								{
									int sortingOrder2 = num18 + 1;
									_muzzleFlash.sortingOrder = sortingOrder2;
									SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_muzzleFlash, 0.1f, yScale);
									if (!(_firingCountdown > 0.05f))
									{
									}
									if ((object)_muzzleFlash != null)
									{
										Transform transform3 = _muzzleFlash.transform;
										if ((object)transform3 != null)
										{
											transform3.localEulerAngles = (Vector3)(&vector);
											float num19 = _firingCountdown * 32f;
											SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale((SpriteRenderer)(object)transform3, 0.1f, yScale);
											float num20 = num19 + 1f;
											SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale(_muzzleFlash2, num20);
											if ((object)_muzzleFlash2 != null)
											{
												_muzzleFlash2.enabled = true;
												Weapon weapon3 = _weapon;
												if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
												{
													int num21 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.depth;
													if ((object)_muzzleFlash2 != null)
													{
														int sortingOrder3 = num21 + 2;
														_muzzleFlash2.sortingOrder = sortingOrder3;
														float deltaTime2 = PauseSystem.DeltaTime;
														float num22 = deltaTime2 * 1000f;
														if (0f < (_firingCountdown -= num22))
														{
															return;
														}
														if ((object)_muzzleFlash != null)
														{
															_muzzleFlash.enabled = false;
															if ((object)_muzzleFlash2 != null)
															{
																_muzzleFlash2.enabled = false;
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
		goto IL_072d;
		IL_072d:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		//IL_0111: Expected O, but got I4
		//IL_0028: Expected O, but got I4
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0152->IL00b1: Incompatible stack heights: 1 vs 0
		//IL_0042->IL00b1: Incompatible stack heights: 1 vs 0
		//IL_0096->IL00b1: Incompatible stack heights: 1 vs 0
		SpriteRenderer line9Slice = _line9Slice;
		if ((object)_line9Slice != null)
		{
			bool flag = ((UnityEngine.Object)line9Slice).m_CachedPtr == (IntPtr)0;
			object obj = Renderer.get_enabled_Injected(((UnityEngine.Object)line9Slice).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			BaseBody baseBody = body;
			if (body != null)
			{
				_ = 0;
				baseBody._velocity = (float2)0;
				if ((object)_weapon != null)
				{
					float num = _weapon.PSpeed();
					object obj2 = 0 * GameManager.ProjectileSpeed;
					float num2 = (float)obj2 + (float)obj2;
					bool flag2 = 1f > num2;
					float num3 = 1f;
					if (!flag2)
					{
						num3 = num2;
					}
					Action onComplete = ActuallyRemove;
					float num4 = 750f / num3;
					float duration = num4 * 0.001f;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer destructionTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_destructionTimer = destructionTimer;
					if ((object)_line9Slice != null)
					{
						_line9Slice.enabled = false;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ActuallyRemove()
	{
		if (_destructionTimer != null)
		{
			_destructionTimer.Cancel();
			_destructionTimer = null;
		}
		_muzzleFlash.enabled = false;
		_muzzleFlash2.enabled = false;
		_line9Slice.enabled = false;
		base.Despawn();
	}

	private void _003CManualInitProjectile_003Eb__18_0()
	{
		_line9Slice.enabled = true;
	}
}
