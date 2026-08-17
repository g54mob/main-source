using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_ProtonBeamProjectile : Projectile
{
	private SpriteRenderer _muzzleFlash;

	private SpriteRenderer _muzzleFlash2;

	private SpriteRenderer _line9Slice;

	private Timer _destructionTimer;

	private Timer _canSplitTimer;

	private float _firingCountdown;

	private float2 _startPosition;

	private float _collisionTween;

	private bool _hasSplit;

	private bool _canSplit;

	private float2 _lastOwnerPosition;

	private IDamageable _ignoreHitObject;

	private float _MaxAlpha = 0.35f;

	private float _AlphaDiff = 0.65f;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00aa: Expected O, but got I
		//IL_0124: Expected O, but got I
		//IL_013d: Invalid comparison between I4 and F4
		//IL_015d: Expected F4, but got I4
		//IL_0083: Expected O, but got F4
		//IL_0238: Expected O, but got I
		//IL_0238: Expected O, but got I
		//IL_0284: Expected I, but got O
		//IL_02c6: Expected I4, but got O
		//IL_0aa5: Expected O, but got Ref
		//IL_035a: Expected O, but got F4
		//IL_0ca4: Expected O, but got Ref
		//IL_0d03: Expected O, but got Ref
		//IL_0b6c: Expected O, but got Ref
		//IL_044f: Expected O, but got F4
		//IL_0983: Expected O, but got I
		//IL_0c02: Expected O, but got Ref
		//IL_05c0: Expected O, but got F4
		//IL_0387->IL0991: Incompatible stack heights: 1 vs 0
		//IL_03b6->IL0991: Incompatible stack heights: 1 vs 0
		//IL_03e2->IL0991: Incompatible stack heights: 1 vs 0
		//IL_0b2c->IL0991: Incompatible stack heights: 2 vs 0
		//IL_0d52->IL0991: Incompatible stack heights: 7 vs 0
		//IL_047c->IL0991: Incompatible stack heights: 3 vs 0
		//IL_04ab->IL0991: Incompatible stack heights: 3 vs 0
		//IL_0901->IL0991: Incompatible stack heights: 7 vs 0
		//IL_0933->IL0991: Incompatible stack heights: 7 vs 0
		//IL_04d7->IL0991: Incompatible stack heights: 3 vs 0
		//IL_0955->IL0991: Incompatible stack heights: 7 vs 0
		//IL_054b->IL0991: Incompatible stack heights: 4 vs 0
		//IL_059a->IL0991: Incompatible stack heights: 4 vs 0
		//IL_05dc->IL0991: Incompatible stack heights: 5 vs 0
		//IL_0606->IL0991: Incompatible stack heights: 5 vs 0
		//IL_066c->IL0991: Incompatible stack heights: 6 vs 0
		//IL_0690->IL0690: Incompatible stack heights: 6 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		_speed = 3f;
		float alphaDiff = 1f - _MaxAlpha;
		_AlphaDiff = alphaDiff;
		float num = default(float);
		if (index >= 0)
		{
			float2 float5 = base.position;
			Weapon weapon2 = _weapon;
			if ((object)_weapon == null || (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null)
			{
				goto IL_0991;
			}
			bool flag = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX;
			base.position = (float2)num;
		}
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
		_startPosition = (float2)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+63]");
		_ = 0;
		_hasSplit = false;
		_ignoreHitObject = null;
		_canSplit = false;
		float num5;
		float num12;
		if ((object)_weapon != null)
		{
			float num2 = _weapon.PSpeed();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj3 = num3 & 0;
			float num4 = 100f / (float)obj3;
			if (0f > num4)
			{
				num4 = 0f;
			}
			Action onComplete = delegate
			{
				_canSplit = true;
			};
			num5 = num4 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer canSplitTimer = Timers.Register(num5, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_canSplitTimer = canSplitTimer;
			if ((object)_weapon != null)
			{
				float num6 = _weapon.PArea();
				float num7 = num5 * -8f;
				_ = 0;
				_ = 0;
				_ = 1;
				float num8 = num5 * -8f;
				_ = 1;
				if (body != null)
				{
					float radius = num5 * 8f;
					BaseBody baseBody = body;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
					BaseBody baseBody2 = baseBody.setCircle(radius, (float?)(object)num9, (float?)(object)0);
					Sprite sprite = SpriteManager.GetSprite("Proton Beam-ProtonBeamTrail", "firstBlood");
					_isCullable = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1081 @ r8_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_ProtonBeamProjectile>)+370]");
					Action onComplete2 = new Action(this, (IntPtr)0);
					nint num10 = (nint)this;
					Timer timer = Timers.Register(2f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					int num11 = (int)_muzzleFlash;
					if ((object)_muzzleFlash != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1093 @ rbx_v23 (System.Int32)+10]");
						bool flag2 = (nint)0 != 0;
						num12 = 2f;
						if (flag2)
						{
							goto IL_0690;
						}
					}
					Transform transform = base.transform;
					if ((object)transform != null)
					{
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rax_v119 (UnityEngine.Transform)+10]");
						bool flag3 = (nint)0 == 0;
						object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rax_v119 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj4);
						GameObject gameObject = base.gameObject;
						SpriteRenderer muzzleFlash = RenderingExtensions.AddSprite(gameObject, (Vector2)num, "vfx", "2Spell4Blue");
						_muzzleFlash = muzzleFlash;
						if ((object)_muzzleFlash != null)
						{
							_muzzleFlash.enabled = false;
							if ((object)_muzzleFlash != null)
							{
								Transform transform2 = _muzzleFlash.transform;
								if ((object)transform2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v132 (UnityEngine.Transform)+10]");
									bool flag4 = (nint)0 == 0;
									nint num13 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2376 @ rcx_v113 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v132 (UnityEngine.Transform)+10]");
									Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
									Transform transform3 = base.transform;
									if ((object)transform3 != null)
									{
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rax_v138 (UnityEngine.Transform)+10]");
										bool flag5 = (nint)0 == 0;
										object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rax_v138 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
										GameObject gameObject2 = base.gameObject;
										SpriteRenderer muzzleFlash2 = RenderingExtensions.AddSprite(gameObject2, (Vector2)num, "vfx", "_blur");
										_muzzleFlash2 = muzzleFlash2;
										if ((object)_muzzleFlash2 != null)
										{
											_muzzleFlash2.enabled = false;
											if ((object)_muzzleFlash2 != null)
											{
												Transform transform4 = _muzzleFlash2.transform;
												if ((object)transform4 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v150 (UnityEngine.Transform)+10]");
													bool flag6 = (nint)0 == 0;
													nint num14 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2745 @ rcx_v128 (Il2CppMethodInfo)+38]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v150 (UnityEngine.Transform)+10]");
													Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
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
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v161 (UnityEngine.Transform)+10]");
															bool flag7 = (nint)0 == 0;
															object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v161 (UnityEngine.Transform)+10]");
															Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
															GameObject gameObject3 = base.gameObject;
															SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(gameObject3, (Vector2)num, "ProtonBeamTrail9Slice", "ProtonBeamTrail9Slice");
															if ((object)spriteRenderer2 != null)
															{
																Transform transform6 = spriteRenderer2.transform;
																if ((object)transform6 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v171 (UnityEngine.Transform)+10]");
																	bool flag8 = (nint)0 == 0;
																	nint num15 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2909 @ rcx_v146 (Il2CppMethodInfo)+38]");
																	if ((nint)0 == 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v171 (UnityEngine.Transform)+10]");
																	Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
																	((UnityEngine.Object)spriteRenderer2).SetName("ProtonBeam9Slice");
																	_line9Slice = spriteRenderer2;
																	if ((object)_line9Slice != null)
																	{
																		_line9Slice.drawMode = SpriteDrawMode.Tiled;
																		num12 = num;
																		goto IL_0690;
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
		goto IL_0991;
		IL_0690:
		if ((object)_weapon != null)
		{
			float num16 = _weapon.PDuration();
			float firingCountdown = num12 * 0.001f;
			_firingCountdown = firingCountdown;
			if ((object)_muzzleFlash != null)
			{
				Transform transform7 = _muzzleFlash.transform;
				bool flag9 = (object)transform7 == null;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v74 (UnityEngine.Transform)+10]");
				bool flag10 = (nint)0 == 0;
				object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v74 (UnityEngine.Transform)+10]");
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj7);
				bool flag11 = (object)_muzzleFlash2 == null;
				Transform transform8 = _muzzleFlash2.transform;
				bool flag12 = (object)transform8 == null;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2016 @ rax_v79 (UnityEngine.Transform)+10]");
				bool flag13 = (nint)0 == 0;
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2016 @ rax_v79 (UnityEngine.Transform)+10]");
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj8);
				bool flag14 = (object)_line9Slice == null;
				_line9Slice.enabled = false;
				Material material2 = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
				bool flag15 = (object)_line9Slice == null;
				((Renderer)_line9Slice).SetMaterial(material2);
				string text = ((_indexInWeapon < 0) ? "ProtonBeamTrail9Slice_noRed" : "ProtonBeamTrail9Slice");
				Sprite sprite2 = SpriteManager.GetSprite(text, text);
				if ((object)_line9Slice != null)
				{
					_line9Slice.sprite = sprite2;
					if (!(num5 > 3f))
					{
						float num17 = num5 - 1f;
						float num18 = num17 / 5f;
						float num19 = 1f - num18;
						float num20 = num19 * _AlphaDiff;
						SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(alpha: num20 + _MaxAlpha, spriteRenderer: _line9Slice);
					}
					else
					{
						SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(_line9Slice, _MaxAlpha);
						Material material3 = MaterialManager.GetMaterial(MaterialType.VfxScreen);
						if ((object)_line9Slice == null)
						{
							goto IL_0991;
						}
						((Renderer)_line9Slice).SetMaterial(material3);
					}
					if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
					{
						float2 float7 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
						_lastOwnerPosition = (float2)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+63]");
						_ = 0;
						return;
					}
				}
			}
		}
		goto IL_0991;
		IL_0991:
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_09f4: Expected O, but got I
		//IL_0217: Expected I, but got O
		//IL_00e2: Expected I, but got O
		//IL_0102: Expected O, but got I
		//IL_0129: Invalid comparison between I4 and F4
		//IL_0a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a76: Expected O, but got Unknown
		//IL_0174: Expected F4, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0b34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b39: Expected O, but got Unknown
		//IL_02e0: Expected F4, but got I4
		//IL_02ee: Expected F4, but got I4
		//IL_0368: Expected O, but got F4
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected O, but got Unknown
		//IL_03ed: Expected I, but got O
		//IL_050d: Expected O, but got Ref
		//IL_061a: Invalid comparison between F4 and I4
		//IL_07a1: Expected O, but got Ref
		//IL_08eb: Invalid comparison between I4 and F4
		//IL_05a0->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_05f5->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_0664->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_069d->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_06bf->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_06f0->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_0763->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_078f->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_080b->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_0844->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_0866->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_0897->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_091e->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_094d->IL09d4: Incompatible stack heights: 1 vs 0
		//IL_0986->IL09d4: Incompatible stack heights: 1 vs 0
		bool flag = _indexInWeapon < 0;
		IntPtr intPtr = default(IntPtr);
		float2 float5 = (float2)(nint)intPtr;
		object obj2 = default(object);
		float2 float6 = default(float2);
		if (!flag)
		{
			Weapon weapon = _weapon;
			if ((object)_weapon == null || (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null)
			{
				goto IL_09d4;
			}
			float2 lastOwnerPosition = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_ProtonBeamProjectile)+110]");
			object obj = obj2 - 0;
			AdjustLine(float6);
			_lastOwnerPosition = lastOwnerPosition;
			float5 = float6;
		}
		bool flag2 = _destructionTimer == null;
		float num = 1f;
		if (!flag2)
		{
			float timeRemaining = _destructionTimer.GetTimeRemaining();
			Weapon weapon2 = _weapon;
			if ((object)_weapon == null)
			{
				goto IL_09d4;
			}
			nint num2 = (nint)weapon2;
			float num3 = timeRemaining * 1000f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+4A0]");
			float5 = (float2)0;
			float num4 = _weapon.PDuration();
			num = num3 / timeRemaining;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num5 = deltaTime * 10f;
		float num6 = num5 * num;
		float num7 = (_collisionTween = num6 + _collisionTween);
		if (num7 > num)
		{
			_collisionTween = 0f;
			if (_objectsHit == null)
			{
				goto IL_09d4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
		float2 float7 = base.position;
		float num8 = (float)_startPosition - (float)float7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_ProtonBeamProjectile)+100]");
		float num9 = 0f - (float)obj2;
		if ((object)_weapon != null)
		{
			float num10 = _weapon.PDuration();
			nint num11 = (nint)this;
			float projectileSpeed = base.ProjectileSpeed;
			float num12 = num7 / 1000f;
			float num13 = num9 * num9;
			float num14 = num8 * num8;
			float num15 = num7 * num12;
			float num16 = num14 + num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			if (num16 > num15)
			{
				float num17 = num8 / num16;
				float num18 = num9 / num16;
				num8 = num17 * num15;
				num9 = num18 * num15;
			}
			object obj3 = num8 & -2147483649L;
			if ((nint)obj3 > 2139095040)
			{
				num8 = 0f;
			}
			object obj4 = num9 & -2147483649L;
			if ((nint)obj4 > 2139095040)
			{
				num9 = 0f;
			}
			if ((object)_weapon != null)
			{
				float num19 = _weapon.PArea();
				Renderer renderer = (Renderer)(object)body;
				if ((object)_weapon != null)
				{
					float num20 = _weapon.PArea();
					float num21 = num16 * -8f;
					float num22 = num16 * -8f;
					object obj5 = num9 ^ -0f;
					object obj6 = obj5 * _collisionTween;
					float num23 = num8 * _collisionTween;
					float num24 = (float)obj6 * 100f;
					float num25 = num23 * 100f;
					float num26 = num24 + num22;
					float num27 = num25 + num21;
					if (body != null)
					{
						nint num28 = (nint)renderer;
						float num29 = num16 * 8f;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v219 @ rdx_v13 (Il2CppClass<UnityEngine.Renderer>)+218] (should have been resolved before IL gen)");
						Weapon weapon3 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
						{
							int num30 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.depth;
							if ((object)_line9Slice != null)
							{
								int sortingOrder = num30 + 1;
								_line9Slice.sortingOrder = sortingOrder;
								if ((object)_line9Slice != null)
								{
									Transform transform = _line9Slice.transform;
									float2 float8 = base.position;
									bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									float2 value = default(float2);
									Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
									Transform transform2 = _line9Slice.transform;
									float2 float9 = default(float2);
									transform2.localEulerAngles = (Vector3)(&float9);
									float num31 = _weapon.PArea();
									float num32 = ((_indexInWeapon >= 0) ? 1f : 0.5f);
									float yScale = (float)float6 * num32;
									SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_line9Slice, 1f, yScale);
									if ((object)_line9Slice != null)
									{
										_line9Slice.size = float6;
										if (_destructionTimer == null)
										{
											if ((object)_line9Slice == null)
											{
												goto IL_09d4;
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
											Weapon weapon4 = _weapon;
											if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
											{
												int num33 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.depth;
												if ((object)_muzzleFlash != null)
												{
													int sortingOrder2 = num33 + 1;
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
															transform3.localEulerAngles = (Vector3)(&float9);
															float num34 = _firingCountdown * 32f;
															SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale((SpriteRenderer)(object)transform3, 0.1f, yScale);
															float num35 = num34 + 1f;
															SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale(_muzzleFlash2, num35);
															if ((object)_muzzleFlash2 != null)
															{
																_muzzleFlash2.enabled = true;
																Weapon weapon5 = _weapon;
																if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
																{
																	int num36 = ((Equipment)weapon5)._003COwner_003Ek__BackingField.depth;
																	if ((object)_muzzleFlash2 != null)
																	{
																		int sortingOrder3 = num36 + 2;
																		_muzzleFlash2.sortingOrder = sortingOrder3;
																		float deltaTime2 = PauseSystem.DeltaTime;
																		if (0f < (_firingCountdown -= deltaTime2))
																		{
																			return;
																		}
																		if ((object)_muzzleFlash != null)
																		{
																			_muzzleFlash.enabled = false;
																			if ((object)_muzzleFlash2 != null)
																			{
																				_muzzleFlash2.enabled = false;
																				Weapon weapon6 = _weapon;
																				if ((object)_weapon != null)
																				{
																					if (weapon6._explodeOnExpire)
																					{
																						Projectile projectile = _weapon.SpawnExplosionAt(float6, 0, 1, 0f);
																					}
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
		goto IL_09d4;
		IL_09d4:
		throw new NullReferenceException();
	}

	private unsafe void AdjustLine(float2 amount)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		float2 startPosition = amount + _startPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_ProtonBeamProjectile)+100]");
		object obj2 = default(object);
		object obj = obj2 + 0;
		_startPosition = startPosition;
		Transform transform = _muzzleFlash.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		float2 value = default(float2);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		Transform transform2 = _muzzleFlash2.transform;
		bool flag2 = (object)transform2 == null;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		float2 value2 = default(float2);
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value2));
	}

	public override void Despawn()
	{
		//IL_0157: Expected O, but got I4
		//IL_0028: Expected O, but got I4
		//IL_0198->IL00f7: Incompatible stack heights: 1 vs 0
		//IL_0042->IL00f7: Incompatible stack heights: 1 vs 0
		//IL_00dc->IL00f7: Incompatible stack heights: 1 vs 0
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
					float num = _weapon.PDuration();
					Action onComplete = ActuallyRemove;
					float duration = 0f * 0.001f;
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
		if (_canSplitTimer != null)
		{
			_canSplitTimer.Cancel();
		}
		_muzzleFlash.enabled = false;
		_muzzleFlash2.enabled = false;
		_line9Slice.enabled = false;
		_ignoreHitObject = null;
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0381: Expected O, but got F4
		//IL_00d7: Expected I, but got O
		//IL_00e5: Expected I, but got O
		//IL_00f5: Expected O, but got I
		//IL_0175: Expected O, but got I4
		//IL_03cc: Expected F4, but got O
		//IL_0131: Expected O, but got I
		//IL_0190: Expected F4, but got O
		//IL_0167: Expected O, but got I4
		//IL_024c: Expected O, but got F4
		//IL_0289: Expected F4, but got I4
		if (_hasSplit || !_canSplit || _ignoreHitObject == other)
		{
			goto IL_02a4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		_hasSplit = true;
		float2 float5 = base.position;
		bool flag = _indexInWeapon > 0;
		int num = 0;
		if (!flag)
		{
			num = _indexInWeapon;
		}
		int index = num - 1;
		float num2 = default(float);
		Projectile projectile = _weapon.FireOneProjectile((Vector2)num2, index);
		Projectile projectile2;
		float num3;
		if ((object)projectile == null)
		{
			projectile2 = null;
			num3 = num2;
			goto IL_03df;
		}
		nint num4 = (nint)projectile;
		nint num5 = (nint)typeof(FB_ProtonBeamProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_ProtonBeamProjectile>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_ProtonBeamProjectile>)+130]");
		object obj4;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rax_v45+FFFFFFF8+v519 @ rax_v41*8]");
			if (0 == (nint)typeof(FB_ProtonBeamProjectile))
			{
				obj4 = 1;
				goto IL_03aa;
			}
		}
		obj4 = 0;
		goto IL_03aa;
		IL_03aa:
		bool flag2 = obj4 == null;
		projectile2 = null;
		num3 = (float)typeof(FB_ProtonBeamProjectile);
		if (!flag2)
		{
			projectile2 = projectile;
			num3 = (float)typeof(FB_ProtonBeamProjectile);
		}
		goto IL_03df;
		IL_02a4:
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj5 = default(object);
			if ((nint)obj5 != -1)
			{
				bool flag3 = TryFreeze(other);
			}
		}
		return;
		IL_03df:
		bool flag4 = (object)projectile2 == null;
		float num7 = num2;
		float num9 = default(float);
		float num8 = num9;
		if (!flag4)
		{
			bool flag5 = ((UnityEngine.Object)projectile2).m_CachedPtr == (IntPtr)0;
			num7 = num2;
			num8 = num9;
			if (!flag5)
			{
				float num10 = UnityEngine.Random.Range(0f, (float)Math.PI * 2f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
				float projectileSpeed = projectile2.ProjectileSpeed;
				BaseBody baseBody = projectile2.body;
				float num11 = num10 * num10;
				float num12 = num10 * num10;
				baseBody._velocity = (float2)num11;
				float? volume = default(float?);
				float rate = default(float);
				float detune = default(float);
				bool loop = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_EnemyHit, 10f, 10, 0f, volume, rate, detune, loop, 1f);
				num7 = 1f;
				num8 = 10f;
			}
		}
		goto IL_02a4;
	}

	private void _003CInitProjectile_003Eb__14_0()
	{
		_canSplit = true;
	}
}
