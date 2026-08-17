using System;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Newtonsoft.Json.Linq;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors.Objects.Projectiles;

public class LuminaireProjectile : Projectile
{
	private bool _alreadyRecycled;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _scaleTween;

	[NonSerialized]
	public float radius = 64f;

	private float2 _pfxLocation;

	public uint[] _colors = new uint[4] { 16711680u, 16776960u, 255u, 16711935u };

	public int[] _detunes = new int[32]
	{
		0, 0, 0, 0, 600, 600, 800, 800, 0, 0,
		0, 0, 600, 600, 800, 800, -400, -400, -400, -400,
		200, 200, 400, 400, -400, -400, -400, -400, 200, 200,
		400, 400
	};

	private LuminaireWeapon _trueWeapon;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("_phaser", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Material material = MaterialManager.GetMaterial(MaterialType.VfxScreen);
		((Renderer)_renderer).SetMaterial(material);
		_alreadyRecycled = false;
		_speed = 0f;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0059: Expected I, but got O
		//IL_0061: Expected I4, but got O
		//IL_0071: Expected O, but got I
		//IL_00f1: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_0890: Expected O, but got I4
		//IL_00ad: Expected O, but got I
		//IL_00e3: Expected O, but got I4
		//IL_0418: Expected O, but got I4
		//IL_0515: Expected O, but got I4
		//IL_05b3: Expected I, but got O
		//IL_061d: Expected O, but got I4
		//IL_0667: Expected O, but got I4
		//IL_079c: Expected I, but got O
		//IL_07b5: Expected O, but got I4
		//IL_0919->IL0992: Incompatible stack heights: 2 vs 0
		//IL_05d6->IL05d6: Incompatible stack heights: 1 vs 0
		//IL_0768->IL0768: Incompatible stack heights: 1 vs 0
		int index2 = default(int);
		base.InitProjectile(pool, weapon, index2);
		if (_alreadyRecycled)
		{
			return;
		}
		Weapon weapon2 = _weapon;
		_alreadyRecycled = true;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0868;
		}
		nint num = (nint)typeof(LuminaireWeapon);
		index2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ r8_v64 (Il2CppClass<VampireSurvivors.Objects.Weapons.LuminaireWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ r9_v3 (System.Int32)+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ r8_v64 (Il2CppClass<VampireSurvivors.Objects.Weapons.LuminaireWeapon>)+130]");
		object obj3;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ r9_v3 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rax_v181+FFFFFFF8+v193 @ rax_v176*8]");
			if (0 == (nint)typeof(LuminaireWeapon))
			{
				obj3 = 1;
				goto IL_0877;
			}
		}
		obj3 = 0;
		goto IL_0877;
		IL_082c:
		throw new NullReferenceException();
		IL_0877:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0868;
		IL_0868:
		_trueWeapon = (LuminaireWeapon)trueWeapon;
		if ((object)weapon != null)
		{
			Weapon weapon3;
			if (!weapon.IsHoming)
			{
				Transform transform = base.AimForRandomEnemyInScreen();
				weapon3 = (Weapon)(object)transform;
			}
			else
			{
				Transform nearestEnemyTransform = base.GetNearestEnemyTransform();
				weapon3 = (Weapon)(object)nearestEnemyTransform;
			}
			float2 float6;
			if ((object)weapon3 == null || ((UnityEngine.Object)weapon3).m_CachedPtr == (IntPtr)0)
			{
				LuminaireWeapon trueWeapon2 = _trueWeapon;
				if ((object)_trueWeapon == null || (object)((Equipment)trueWeapon2)._003COwner_003Ek__BackingField == null)
				{
					goto IL_082c;
				}
				float2 float5 = ((Equipment)trueWeapon2)._003COwner_003Ek__BackingField.position;
				float6 = float5;
			}
			else
			{
				bool flag2 = ((UnityEngine.Object)weapon3).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)weapon3).m_CachedPtr, out Vector3 _);
				bool flag3 = ((UnityEngine.Object)weapon3).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)weapon3).m_CachedPtr, out Vector3 _);
				float2 float7 = default(float2);
				float6 = float7;
			}
			base.position = float6;
			Weapon weapon4 = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
			{
				Transform targetTransform = ((Equipment)weapon4)._003COwner_003Ek__BackingField.transform;
				_targetTransform = targetTransform;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				int[] detunes = _detunes;
				if (_detunes != null)
				{
					int num3 = _indexInWeapon % detunes.Length;
					_ = 1;
					((GameMonoBehaviour)(object)soundConfig)._onPauseSent = (byte)detunes[num3] != 0;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Magic3, soundConfig, 400f, 7, time);
					GameManager core = GM.Core;
					if ((object)GM.Core != null && core._playerOptions != null)
					{
						PlayerOptionsData config = core._playerOptions.Config;
						if (config != null)
						{
							Weapon renderer;
							MaterialType type;
							if (config._003CFlashingVFXEnabled_003Ek__BackingField)
							{
								ArcadeSprite arcadeSprite = setAlpha(0.65f);
								renderer = (Weapon)(object)_renderer;
								type = MaterialType.VfxScreen;
							}
							else
							{
								ArcadeSprite arcadeSprite2 = setAlpha(0.1f);
								renderer = (Weapon)(object)_renderer;
								type = MaterialType.DefaultSprite;
							}
							Material material = MaterialManager.GetMaterial(type);
							if ((object)renderer != null)
							{
								((Renderer)(object)renderer).SetMaterial(material);
								ArcadeSprite arcadeSprite3 = setScale(1f, (float?)(object)0);
								uint[] colors = _colors;
								if (_colors != null)
								{
									int num4 = _indexInWeapon % colors.Length;
									ArcadeSprite arcadeSprite4 = setTint(colors[num4]);
									BaseBody baseBody = body;
									if (body != null)
									{
										baseBody._enable = true;
										PhaserScene s_scene = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer2 = s_scene._renderer;
											if (s_scene._renderer != null)
											{
												int num5 = renderer2.pixelHeight >> 31;
												int num6 = num5 & 7;
												object obj4 = num6 + renderer2.pixelHeight;
												object obj5 = obj4 >> 3;
												if (_scaleTween != null)
												{
													_scaleTween.Kill();
												}
												TweenConfig tweenConfig = new TweenConfig();
												object[] array = new object[1];
												if (array != null)
												{
													if ((object)_cachedTransform != null)
													{
														nint num7 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj6 = default(object);
														bool flag4 = obj6 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig != null)
													{
														tweenConfig.targets = array;
														tweenConfig.scaleY = (float?)(object)1;
														if ((object)_trueWeapon != null)
														{
															float num8 = _trueWeapon.PArea();
															tweenConfig.duration = 200f;
															tweenConfig.scaleX = (float?)(object)1;
															TweenCallback onStart = delegate
															{
																LuminaireWeapon trueWeapon3 = _trueWeapon;
																if (trueWeapon3._explodeOnExpire)
																{
																	float2 pos = base.position;
																	Projectile projectile = trueWeapon3.SpawnExplosionAt(pos, 0, 1, 0f);
																}
															};
															tweenConfig.onStart = onStart;
															MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
															_scaleTween = scaleTween;
															if (_alphaTween != null)
															{
																_alphaTween.Kill();
															}
															TweenConfig tweenConfig2 = new TweenConfig();
															object[] array2 = new object[1];
															if (array2 != null)
															{
																if ((object)_cachedTransform != null)
																{
																	void* value = ((IntPtr*)(&array2))->m_value;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj7 = default(object);
																	bool flag5 = obj7 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig2 != null)
																{
																	((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
																	_ = 1128792064;
																	((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1120403456;
																	_ = 1;
																	TweenCallback currentJsonDataObject = delegate
																	{
																		BaseBody baseBody2 = body;
																		baseBody2._enable = false;
																	};
																	((Equipment)(object)tweenConfig2)._currentJsonDataObject = (JObject)(object)currentJsonDataObject;
																	TweenCallback signalBus = delegate
																	{
																		Despawn();
																	};
																	((Equipment)(object)tweenConfig2)._signalBus = (SignalBus)(object)signalBus;
																	MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
																	_alphaTween = alphaTween;
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
		goto IL_082c;
	}

	public override void Despawn()
	{
		base.Despawn();
		_alreadyRecycled = false;
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		LuminaireWeapon trueWeapon = _trueWeapon;
		if (trueWeapon.FirstArcana != ArcanaType.T19_FIRE)
		{
			if (trueWeapon.FirstArcana == ArcanaType.T14_JEWELS)
			{
				bool flag = TryFreeze(target);
			}
		}
		else
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void _003CInitProjectile_003Eb__9_0()
	{
		LuminaireWeapon trueWeapon = _trueWeapon;
		if (trueWeapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = trueWeapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	private void _003CInitProjectile_003Eb__9_1()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	private void _003CInitProjectile_003Eb__9_2()
	{
		Despawn();
	}
}
