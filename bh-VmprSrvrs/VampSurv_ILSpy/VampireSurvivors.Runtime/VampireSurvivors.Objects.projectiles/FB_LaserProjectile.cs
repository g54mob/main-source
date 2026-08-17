using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_LaserProjectile : Projectile
{
	private TrailRenderer _trail;

	private SpriteRenderer _muzzleFlash;

	private SpriteRenderer _muzzleFlash2;

	private Timer _destructionTimer;

	private float _firingCountdown;

	private float2 _startPosition;

	private float _collisionTween;

	private float2 _lastOwnerPosition;

	private float _MaxAlpha = 0.35f;

	private float _AlphaDiff = 0.65f;

	private Vector2 TrailTextureScale
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0043: Expected O, but got F4
		//IL_00e8: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_0226: Expected O, but got F4
		//IL_0291: Expected I4, but got O
		//IL_0383: Expected I4, but got O
		//IL_09b7: Invalid comparison between O and F4
		//IL_0455: Expected I, but got O
		//IL_0497: Expected I4, but got O
		//IL_052b: Expected O, but got F4
		//IL_0620: Expected O, but got F4
		//IL_0921->IL085e: Incompatible stack heights: 1 vs 0
		//IL_0178->IL085e: Incompatible stack heights: 1 vs 0
		//IL_01d6->IL085e: Incompatible stack heights: 1 vs 0
		//IL_0202->IL085e: Incompatible stack heights: 1 vs 0
		//IL_0245->IL085e: Incompatible stack heights: 1 vs 0
		//IL_0273->IL085e: Incompatible stack heights: 1 vs 0
		//IL_02ab->IL085e: Incompatible stack heights: 1 vs 0
		//IL_0977->IL085e: Incompatible stack heights: 2 vs 0
		//IL_02e4->IL085e: Incompatible stack heights: 2 vs 0
		//IL_0313->IL085e: Incompatible stack heights: 2 vs 0
		//IL_0341->IL085e: Incompatible stack heights: 2 vs 0
		//IL_039d->IL085e: Incompatible stack heights: 2 vs 0
		//IL_0500->IL085e: Incompatible stack heights: 3 vs 0
		//IL_076d->IL085e: Incompatible stack heights: 3 vs 0
		//IL_07b5->IL085e: Incompatible stack heights: 3 vs 0
		//IL_0558->IL085e: Incompatible stack heights: 4 vs 0
		//IL_0587->IL085e: Incompatible stack heights: 4 vs 0
		//IL_05b3->IL085e: Incompatible stack heights: 4 vs 0
		//IL_0a97->IL085e: Incompatible stack heights: 5 vs 0
		//IL_064d->IL085e: Incompatible stack heights: 6 vs 0
		//IL_067c->IL085e: Incompatible stack heights: 6 vs 0
		//IL_06a8->IL085e: Incompatible stack heights: 6 vs 0
		//IL_071c->IL085e: Incompatible stack heights: 7 vs 0
		//IL_0753->IL0753: Incompatible stack heights: 7 vs 3
		base.InitProjectile(pool, weapon, index);
		_speed = 3f;
		float alphaDiff = 1f - _MaxAlpha;
		_AlphaDiff = alphaDiff;
		float2 float5 = base.position;
		Weapon weapon2 = _weapon;
		float ret;
		float num18;
		float ret2 = default(float);
		if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
		{
			bool flag = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX;
			float num = default(float);
			base.position = (float2)num;
			float2 float6 = (_startPosition = base.position);
			if ((object)_weapon != null)
			{
				float num2 = _weapon.PArea();
				float num3 = (float)float6 * -8f;
				if (body != null)
				{
					float radius = (float)float6 * 8f;
					BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
					Sprite sprite = SpriteManager.GetSprite("Laser Gun-LaserGunBeamTrail", "firstBlood");
					RenderingExtensions.SetMaterialToPackedSprite(_trail, sprite);
					if ((object)sprite != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rax_v68 (UnityEngine.Sprite)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rax_v68 (UnityEngine.Sprite)+10]");
						Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
						if ((object)_trail != null)
						{
							_trail.widthMultiplier = 1f;
							if ((object)_weapon != null)
							{
								float num4 = _weapon.PArea();
								object obj = default(object);
								float num5 = (float)obj / 100f;
								float num6 = 0f * num5;
								float num7 = num6 * 0.5f;
								if ((object)_trail != null)
								{
									Material material = ((Renderer)_trail).GetMaterial();
									if ((object)material != null)
									{
										int num8 = Shader.PropertyToID("_MainTex");
										material.SetTextureScaleImpl(num8, (Vector2)num);
										if ((object)_trail != null)
										{
											_trail.startWidth = num7;
											if ((object)_trail != null)
											{
												_trail.endWidth = num7;
												int num9 = (int)_trail;
												if ((object)_trail != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rbx_v25 (System.Int32)+10]");
													bool flag3 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rbx_v25 (System.Int32)+10]");
													TrailRenderer.set_textureMode_Injected((IntPtr)0, LineTextureMode.Tile);
													if ((object)_trail != null)
													{
														_trail.enabled = true;
														if ((object)_trail != null)
														{
															_trail.emitting = true;
															if ((object)_weapon != null)
															{
																float num10 = _weapon.PDuration();
																if ((object)_trail != null)
																{
																	float time = num * 0.001f;
																	_trail.time = time;
																	TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
																	int num11 = (int)_trail;
																	if ((object)_trail != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rbx_v27 (System.Int32)+10]");
																		bool flag4 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rbx_v27 (System.Int32)+10]");
																		TrailRenderer.Clear_Injected((IntPtr)0);
																		float alpha;
																		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5f))
																		{
																			float num12 = (float)float6 - 1f;
																			float num13 = num12 / 5f;
																			float num14 = 1.6f - num13;
																			float num15 = num14 * _AlphaDiff;
																			alpha = num15 + _MaxAlpha;
																		}
																		else
																		{
																			alpha = _MaxAlpha;
																		}
																		TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, alpha);
																		_isCullable = false;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2335 @ r8_v34 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_LaserProjectile>)+370]");
																		Action onComplete = new Action(this, (IntPtr)0);
																		nint num16 = (nint)this;
																		bool useRealTime = default(bool);
																		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																		int repeat = default(int);
																		TimerType type = default(TimerType);
																		Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																		int num17 = (int)_muzzleFlash;
																		if ((object)_muzzleFlash != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2347 @ rbx_v30 (System.Int32)+10]");
																			bool flag5 = (nint)0 != 0;
																			num18 = 2f;
																			if (flag5)
																			{
																				goto IL_0753;
																			}
																		}
																		Transform transform = base.transform;
																		if ((object)transform != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v125 (UnityEngine.Transform)+10]");
																			bool flag6 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v125 (UnityEngine.Transform)+10]");
																			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret2));
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
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v138 (UnityEngine.Transform)+10]");
																						bool flag7 = (nint)0 == 0;
																						nint num19 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2719 @ rcx_v119 (Il2CppMethodInfo)+38]");
																						if ((nint)0 == 0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v138 (UnityEngine.Transform)+10]");
																						Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
																						Transform transform3 = base.transform;
																						if ((object)transform3 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rax_v144 (UnityEngine.Transform)+10]");
																							bool flag8 = (nint)0 == 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rax_v144 (UnityEngine.Transform)+10]");
																							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret2));
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
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v156 (UnityEngine.Transform)+10]");
																										bool flag9 = (nint)0 == 0;
																										nint num20 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2913 @ rcx_v134 (Il2CppMethodInfo)+38]");
																										if ((nint)0 == 0)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v156 (UnityEngine.Transform)+10]");
																										Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
																										Material material2 = MaterialManager.GetMaterial(MaterialType.VfxScreen);
																										if ((object)_muzzleFlash2 != null)
																										{
																											((Renderer)_muzzleFlash2).SetMaterial(material2);
																											SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_muzzleFlash2, 0.35f);
																											num18 = num;
																											goto IL_0753;
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
		goto IL_085e;
		IL_0753:
		if ((object)_weapon != null)
		{
			float num21 = _weapon.PDuration();
			float firingCountdown = num18 * 0.001f;
			_firingCountdown = firingCountdown;
			if ((object)_muzzleFlash != null)
			{
				Transform transform5 = _muzzleFlash.transform;
				bool flag10 = (object)transform5 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1918 @ rax_v109 (UnityEngine.Transform)+10]");
				bool flag11 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1918 @ rax_v109 (UnityEngine.Transform)+10]");
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&ret2));
				bool flag12 = (object)_muzzleFlash2 == null;
				Transform transform6 = _muzzleFlash2.transform;
				bool flag13 = (object)transform6 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1778 @ rax_v114 (UnityEngine.Transform)+10]");
				bool flag14 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1778 @ rax_v114 (UnityEngine.Transform)+10]");
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&ret));
				bool flag15 = (object)weapon == null;
				bool flag16 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
				float2 lastOwnerPosition = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				_lastOwnerPosition = lastOwnerPosition;
				return;
			}
		}
		goto IL_085e;
		IL_085e:
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I
		//IL_015b: Expected I4, but got O
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_0126: Expected O, but got I4
		//IL_03bb: Expected I, but got O
		//IL_041d: Invalid comparison between O and F4
		//IL_01d7: Invalid comparison between I4 and F4
		//IL_0222: Expected F4, but got I4
		//IL_04e1: Expected I, but got O
		//IL_05a4: Invalid comparison between F4 and I4
		//IL_071d: Expected O, but got Ref
		//IL_0a10: Invalid comparison between I4 and F4
		//IL_0a5e->IL09e3: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		object obj3 = default(object);
		Vector2 vector3 = default(Vector2);
		float num2;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			BaseBody baseBody = body;
			object obj = float5 - _lastOwnerPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_LaserProjectile)+104]");
			object obj2 = obj3 - 0;
			if (body != null)
			{
				object obj4 = obj * (object)baseBody._velocity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v13 (BaseBody)+74]");
				object obj5 = obj2 * 0;
				Vector2 vector = (Vector2)(obj4 + obj5);
				bool flag = (nint)vector <= 0;
				IntPtr intPtr = default(IntPtr);
				float2 float6 = (float2)(nint)intPtr;
				if (!flag)
				{
					if (body == null)
					{
						goto IL_0965;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004360");
					float2 float7 = default(float2);
					AdjustLine(float7);
					float6 = float7;
					Vector2 vector2 = (Vector2)0;
					vector = vector3;
				}
				bool flag2 = _destructionTimer == null;
				_lastOwnerPosition = float5;
				int num = (int)float6;
				num2 = 1f;
				if (flag2)
				{
					goto IL_02bf;
				}
				float timeRemaining = _destructionTimer.GetTimeRemaining();
				if ((object)_weapon != null)
				{
					float num3 = timeRemaining * 1000f;
					float num4 = _weapon.PDuration();
					num2 = num3 / timeRemaining;
					if (!(0f > num2))
					{
						if (num2 > 1f)
						{
							num2 = 1f;
						}
					}
					else
					{
						num2 = 0f;
					}
					if ((object)_trail != null)
					{
						Material material = ((Renderer)_trail).GetMaterial();
						if (_destructionTimer != null)
						{
							float timeElapsed = _destructionTimer.GetTimeElapsed();
							float projectileSpeed = base.ProjectileSpeed;
							if ((object)material != null)
							{
								int num5 = Shader.PropertyToID("_MainTex");
								material.SetTextureOffsetImpl(num5, vector3);
								num = num5;
								Vector2 vector2 = vector3;
								goto IL_02bf;
							}
						}
					}
				}
			}
		}
		goto IL_0965;
		IL_02bf:
		float deltaTime = PauseSystem.DeltaTime;
		float num6 = deltaTime * 10f;
		float num7 = num6 * num2;
		float num8 = (_collisionTween = num7 + _collisionTween);
		if (num8 > num2)
		{
			_collisionTween = 0f;
			if (_objectsHit == null)
			{
				goto IL_0965;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
		float2 float8 = base.position;
		object obj6 = _startPosition - float8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_LaserProjectile)+F8]");
		object obj7 = 0 - obj3;
		if ((object)_weapon != null)
		{
			float num9 = _weapon.PDuration();
			nint num10 = (nint)this;
			float projectileSpeed2 = base.ProjectileSpeed;
			float num11 = num8 / 1000f;
			object obj8 = obj7 * obj7;
			object obj9 = obj6 * obj6;
			float num12 = num8 * num11;
			object obj10 = obj9 + obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			Material material2 = default(Material);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num12))
			{
				material2 = (Material)(object)body;
				if ((object)_weapon == null)
				{
					goto IL_0965;
				}
			}
			float num13 = _weapon.PArea();
			if ((object)_weapon != null)
			{
				float num14 = _weapon.PArea();
				float num15 = (float)obj10 * -8f;
				if ((object)_weapon != null)
				{
					float num16 = _weapon.PArea();
					float num17 = num15 * -8f;
					if (body != null)
					{
						nint num18 = (nint)material2;
						float num19 = (float)obj10 * 8f;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v138 @ rdx_v19 (Il2CppClass<UnityEngine.Material>)+218] (should have been resolved before IL gen)");
						Weapon weapon2 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							int num20 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.depth;
							if ((object)_trail != null)
							{
								int sortingOrder = num20 + 1;
								_trail.sortingOrder = sortingOrder;
								if (!(_firingCountdown > 0f))
								{
									return;
								}
								SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_muzzleFlash, 2f);
								if ((object)_muzzleFlash != null)
								{
									_muzzleFlash.enabled = true;
									Weapon weapon3 = _weapon;
									if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
									{
										int num21 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.depth;
										if ((object)_muzzleFlash != null)
										{
											int sortingOrder2 = num21 + 1;
											_muzzleFlash.sortingOrder = sortingOrder2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
											if (!(_firingCountdown > 0.05f))
											{
											}
											if ((object)_muzzleFlash != null)
											{
												Transform transform = _muzzleFlash.transform;
												if ((object)transform != null)
												{
													Vector2 vector4 = default(Vector2);
													transform.localEulerAngles = (Vector3)(&vector4);
													float num22 = _firingCountdown * 32f;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
													float num23 = num22 + 1f;
													SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_muzzleFlash2, num23);
													if ((object)_muzzleFlash2 != null)
													{
														_muzzleFlash2.enabled = true;
														Weapon weapon4 = _weapon;
														if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
														{
															int num24 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.depth;
															if ((object)_muzzleFlash2 != null)
															{
																int sortingOrder3 = num24 + 2;
																_muzzleFlash2.sortingOrder = sortingOrder3;
																if ((object)_trail != null)
																{
																	int numPositions = _trail.numPositions;
																	if (numPositions > 0)
																	{
																		Material trail = (Material)(object)_trail;
																		bool flag3 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
																		TrailRenderer.SetPosition_Injected(((UnityEngine.Object)trail).m_CachedPtr, 0, ref *(Vector3*)(&vector4));
																	}
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
																			Weapon weapon5 = _weapon;
																			if ((object)_weapon != null)
																			{
																				if (weapon5._explodeOnExpire)
																				{
																					Projectile projectile = _weapon.SpawnExplosionAt(vector3, 0, 1, 0f);
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
		goto IL_0965;
		IL_0965:
		throw new NullReferenceException();
	}

	private unsafe void AdjustLine(float2 amount)
	{
		//IL_0038: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_01d1: Expected I4, but got O
		//IL_01f0: Expected I4, but got O
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_0222->IL013d: Incompatible stack heights: 2 vs 0
		//IL_0090->IL0227: Incompatible stack heights: 2 vs 0
		TrailRenderer trail = _trail;
		if ((object)_trail != null)
		{
			object obj = null;
			float2 float5 = (float2)0;
			float2 value = default(float2);
			float2 value2 = default(float2);
			float2 float8 = default(float2);
			object obj4 = default(object);
			while (true)
			{
				if (((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(trail);
					break;
				}
				object obj2 = TrailRenderer.get_positionCount_Injected(((UnityEngine.Object)trail).m_CachedPtr);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					object trail2 = _trail;
					if ((object)_trail == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r14_v20 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r14_v20 (System.Object)+10]");
					TrailRenderer.GetPosition_Injected((IntPtr)0, (int)float5, out *(Vector3*)(&value));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r14_v20 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r14_v20 (System.Object)+10]");
					TrailRenderer.SetPosition_Injected((IntPtr)0, (int)float5, ref *(Vector3*)(&value2));
					trail = _trail;
					float2 float6 = float5 + 1;
					if ((object)_trail == null)
					{
						break;
					}
					obj = float6;
					float5 = float6;
					continue;
				}
				float2 float7 = base.position;
				base.position = float8;
				float2 startPosition = amount + _startPosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_LaserProjectile)+F8]");
				object obj3 = obj4 + 0;
				TrailRenderer muzzleFlash = (TrailRenderer)(object)_muzzleFlash;
				_startPosition = startPosition;
				if ((object)_muzzleFlash == null)
				{
					break;
				}
				bool flag3 = ((UnityEngine.Object)muzzleFlash).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)muzzleFlash).m_CachedPtr);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				bool flag4 = (object)transform == null;
				bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value2));
				TrailRenderer muzzleFlash2 = (TrailRenderer)(object)_muzzleFlash2;
				bool flag6 = (object)_muzzleFlash2 == null;
				bool flag7 = ((UnityEngine.Object)muzzleFlash2).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)muzzleFlash2).m_CachedPtr);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				bool flag8 = (object)transform2 == null;
				bool flag9 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		//IL_01c6: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_0029->IL0166: Incompatible stack heights: 1 vs 0
		//IL_0058->IL0166: Incompatible stack heights: 1 vs 0
		//IL_008e->IL0166: Incompatible stack heights: 1 vs 0
		//IL_0207->IL0166: Incompatible stack heights: 1 vs 0
		//IL_00ea->IL0166: Incompatible stack heights: 1 vs 0
		TrailRenderer trail = _trail;
		if ((object)_trail != null)
		{
			bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
			object obj = TrailRenderer.get_emitting_Injected(((UnityEngine.Object)trail).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			if ((object)_trail != null)
			{
				_trail.emitting = false;
				if ((object)_trail != null)
				{
					Material material = ((Renderer)_trail).GetMaterial();
					float projectileSpeed = base.ProjectileSpeed;
					if ((object)material != null)
					{
						int num = Shader.PropertyToID("_MainTex");
						Vector2 offset = default(Vector2);
						material.SetTextureOffsetImpl(num, offset);
						BaseBody baseBody = body;
						if (body != null)
						{
							_ = 0;
							baseBody._velocity = (float2)0;
							if ((object)_weapon != null)
							{
								float num2 = _weapon.PDuration();
								Action onComplete = ActuallyRemove;
								float duration = 0f * 0.001f;
								bool useRealTime = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer destructionTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_destructionTimer = destructionTimer;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ActuallyRemove()
	{
		//IL_0135->IL00e3: Incompatible stack heights: 1 vs 0
		if ((object)_muzzleFlash != null)
		{
			_muzzleFlash.enabled = false;
			if ((object)_muzzleFlash2 != null)
			{
				_muzzleFlash2.enabled = false;
				Renderer trail = _trail;
				if ((object)_trail != null)
				{
					bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
					TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
					if ((object)_trail != null)
					{
						_trail.enabled = false;
						if (_destructionTimer != null)
						{
							_destructionTimer.Cancel();
							_destructionTimer = null;
						}
						base.Despawn();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				bool flag = TryFreeze(other);
			}
		}
	}
}
