using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Newtonsoft.Json.Linq;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class GattiProjectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<PhaserGameObject, bool> _003C_003E9__20_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CChooseTarget_003Eb__20_0(PhaserGameObject phaserGameObject)
		{
			//IL_00ec: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_001d: Expected O, but got I
			//IL_00ff: Expected I4, but got O
			//IL_0059: Expected O, but got I
			//IL_00ca: Expected O, but got I
			nint num = (nint)typeof(Pickup);
			nint num2 = (nint)phaserGameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<PhaserGameObject>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<PhaserGameObject>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v6+FFFFFFF8+v42 @ rax_v5*8]");
				if (0 == (nint)typeof(Pickup))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [phaserGameObject @ rdx (PhaserGameObject)+F8]");
					if ((nint)0 == 12)
					{
						return true;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [phaserGameObject @ rdx (PhaserGameObject)+F8]");
					object obj3 = -17;
					return obj3 == null;
				}
			}
			InvalidCastException ex = new InvalidCastException();
			return (byte)(int)ex != 0;
		}
	}

	private VampireSurvivors.Framework.TimerSystem.Timer _chooseTimer;

	private float _saveVelX;

	private float _saveVelY;

	private Vector2 _aimVec;

	private VampireSurvivors.Framework.TimerSystem.Timer _expireTimer;

	private MultiTargetTween _onExpireAlphaTween;

	private SpriteRenderer _summon;

	private MultiTargetTween _summonTween;

	private float _defaultSpeed;

	private MultiTargetTween _entryTween;

	private SpriteAnimation _anims;

	protected List<string> _catFrames;

	protected override void Awake()
	{
		//IL_006a: Expected O, but got I4
		base.Awake();
		_defaultSpeed = _speed;
		_aimVec = (Vector2)0;
		GameObject gameObject = base.gameObject;
		string spriteName = default(string);
		SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, 0f, 0f, "vfx", spriteName);
		spriteRenderer.enabled = false;
		_summon = spriteRenderer;
	}

	protected virtual void CreateCatAnim()
	{
		SpriteAnimation anims = _anims;
		if ((object)_anims == null || ((UnityEngine.Object)anims).m_CachedPtr == (IntPtr)0)
		{
			string animName = VampireSurvivors.App.Tools.Extensions.PickRnd(_catFrames);
			GameObject gameObject = _renderer.gameObject;
			SpriteAnimation anims2 = gameObject.AddComponent<SpriteAnimation>();
			_anims = anims2;
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, 3, "vfx", num);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_anims.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			_anims.SetAnimation("idle");
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00dd: Expected O, but got I4
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I4, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_00cf: Expected O, but got I
		//IL_021b: Expected O, but got I4
		//IL_025e: Expected O, but got I4
		//IL_025e: Expected O, but got I4
		//IL_034d: Expected I, but got O
		//IL_03d1: Expected I, but got O
		//IL_046d: Expected O, but got I4
		//IL_0489: Expected O, but got I4
		//IL_0518: Expected I, but got O
		//IL_0573: Expected I, but got O
		//IL_05b4: Expected O, but got I4
		//IL_05c2: Expected O, but got I4
		//IL_0a1b: Expected O, but got F4
		//IL_0a93: Invalid comparison between F4 and I4
		//IL_0c1c: Expected O, but got F4
		//IL_0c24: Expected O, but got F4
		//IL_08e8: Expected O, but got I4
		//IL_0909: Expected F4, but got I4
		//IL_0768->IL0963: Incompatible stack heights: 4 vs 0
		//IL_083b->IL0963: Incompatible stack heights: 4 vs 0
		//IL_0c29->IL071f: Incompatible stack heights: 5 vs 4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		if ((object)_weapon == null)
		{
			goto IL_00d4;
		}
		nint num = (nint)typeof(GattiWeapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v110 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v31 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v110 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v31 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v212+FFFFFFF8+v70 @ rax_v206*8]");
			if (0 == (nint)typeof(GattiWeapon))
			{
				obj3 = 1;
				goto IL_09aa;
			}
		}
		obj3 = 0;
		goto IL_09aa;
		IL_00d4:
		float? catFrames = (float?)(object)0;
		goto IL_09cc;
		IL_09cc:
		_catFrames = (List<string>)catFrames;
		CreateCatAnim();
		if (_summonTween != null)
		{
			_summonTween.Kill();
		}
		if (_entryTween != null)
		{
			_entryTween.Kill();
		}
		if (_onExpireAlphaTween != null)
		{
			_onExpireAlphaTween.Kill();
		}
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		_isCullable = false;
		if ((object)_weapon != null)
		{
			float num4 = _weapon.PSpeed();
			if ((object)_anims != null)
			{
				object obj4 = default(object);
				float num5 = (float)obj4 * 12f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
				_anims.Play("idle", 0);
				ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
				if (body != null)
				{
					BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
					ArcadeSprite arcadeSprite3 = setAlpha(1f);
					SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_summon, 0f);
					if ((object)spriteRenderer != null)
					{
						spriteRenderer.enabled = true;
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 1f);
						ArcadeSprite arcadeSprite4 = setTint(16777215u);
						_speed = _defaultSpeed;
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[2];
						if (array != null)
						{
							if ((object)_summon != null)
							{
								nint num6 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj5 = default(object);
								if (obj5 == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if ((object)_summon != null)
							{
								Transform transform = _summon.transform;
								if ((object)transform != null)
								{
									nint num7 = (nint)array;
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
									if ((object)_weapon != null)
									{
										float num8 = _weapon.PArea();
										tweenConfig.scale = (float?)(object)1;
										tweenConfig.duration = 1000f;
										tweenConfig.alpha = (float?)(object)1;
										MultiTargetTween summonTween = Tweens.Add(tweenConfig);
										_summonTween = summonTween;
										TweenConfig tweenConfig2 = new TweenConfig();
										object[] array2 = new object[1];
										Transform transform2 = base.transform;
										if (array2 != null)
										{
											if ((object)transform2 != null)
											{
												nint num9 = (nint)array2;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj7 = default(object);
												if (obj7 == null)
												{
													ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
													throw ex3;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig2 != null)
											{
												((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
												if ((object)_weapon != null)
												{
													float num10 = _weapon.PArea();
													((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1133903872;
													((Weapon)(object)tweenConfig2)._gameSessionData = (GameSessionData)1;
													TweenCallback currentJsonDataObject = delegate
													{
														//IL_0015: Expected O, but got I4
														ArcadeSprite arcadeSprite5 = setScale(0f, (float?)(object)1);
													};
													((Equipment)(object)tweenConfig2)._currentJsonDataObject = (JObject)(object)currentJsonDataObject;
													MultiTargetTween entryTween = Tweens.Add(tweenConfig2);
													_entryTween = entryTween;
													object obj8 = UnityEngine.Random.value;
													float num11 = num5 * ((float)Math.PI * 2f);
													float2 float5 = base.position;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
													PhaserScene s_scene = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
														Weapon typeFromHandle = (Weapon)(object)typeof(ArcadePhysics);
														VampireSurvivors.Framework.TimerSystem.Timer firingAnimEvent = typeFromHandle._firingAnimEvent;
														float num12 = firingAnimEvent._003CDuration_003Ek__BackingField;
														if (firingAnimEvent._003CDuration_003Ek__BackingField != 0f)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rcx_v76 (System.Single)+28]");
															if ((nint)0 != 0)
															{
																float2 float6 = default(float2);
																base.position = float6;
																if ((object)_summon != null)
																{
																	Transform transform3 = _summon.transform;
																	Transform transform4 = base.transform;
																	if ((object)transform4 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rax_v100 (UnityEngine.Transform)+10]");
																		bool flag = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rax_v100 (UnityEngine.Transform)+10]");
																		Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
																		bool flag2 = (object)transform3 == null;
																		bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																		float2 value = default(float2);
																		Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value));
																		Weapon weapon3 = _weapon;
																		_saveVelX = 1f;
																		_saveVelY = 1f;
																		bool flag4 = (object)_weapon == null;
																		float2 float7;
																		if (!weapon3.IsHoming)
																		{
																			TargetPlayer();
																			float7 = float6;
																		}
																		else
																		{
																			Transform nearestEnemyTransform = base.GetNearestEnemyTransform();
																			bool flag5 = (object)nearestEnemyTransform == null;
																			float7 = float6;
																			if (!flag5)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2170 @ rax_v112 (UnityEngine.Transform)+10]");
																				bool flag6 = (nint)0 == 0;
																				float7 = float6;
																				if (!flag6)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2170 @ rax_v112 (UnityEngine.Transform)+10]");
																					bool flag7 = (nint)0 == 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2170 @ rax_v112 (UnityEngine.Transform)+10]");
																					Transform.get_position_Injected((IntPtr)0, out ret);
																					float2 float8 = base.position;
																					object obj9 = default(object);
																					float num13 = (float)obj9 - num5;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
																					float projectileSpeed = base.ProjectileSpeed;
																					float num14 = (float)float6 * num5;
																					object obj10 = default(object);
																					float num15 = (float)float6 * (float)obj10;
																					_aimVec = (Vector2)num15;
																					float7 = (float2)num14;
																				}
																			}
																		}
																		if (_chooseTimer != null)
																		{
																			_chooseTimer.Cancel();
																		}
																		if ((object)_weapon != null)
																		{
																			float num16 = _weapon.PSpeed();
																			Action onComplete = ChooseTarget;
																			float num17 = 1500f / (float)float7;
																			float num18 = num17 * 0.001f;
																			bool flag8 = default(bool);
																			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																			int repeat = default(int);
																			TimerType type = default(TimerType);
																			VampireSurvivors.Framework.TimerSystem.Timer chooseTimer = Timers.Register(num18, onComplete, null, isLooped: true, flag8, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																			_chooseTimer = chooseTimer;
																			if (_expireTimer != null)
																			{
																				_expireTimer.Cancel();
																			}
																			if ((object)_weapon != null)
																			{
																				float num19 = _weapon.PDuration();
																				Action onComplete2 = OnExpireTimer;
																				float duration = num18 * 0.001f;
																				VampireSurvivors.Framework.TimerSystem.Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, flag8, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																				_expireTimer = expireTimer;
																				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, new SoundManager.SoundConfig
																				{
																					Rate = 1f,
																					Detune = 1000f,
																					Volume = (float?)(object)1
																				}, 200f, 12, flag8 ? 1 : 0);
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
		IL_09aa:
		bool flag9 = obj3 == null;
		Weapon weapon4 = null;
		if (!flag9)
		{
			weapon4 = _weapon;
		}
		if ((object)weapon4 == null)
		{
			goto IL_00d4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v209 (VampireSurvivors.Objects.Weapons.Weapon)+170]");
		catFrames = (float?)(object)0;
		goto IL_09cc;
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_004b: Expected O, but got I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00e2: Expected O, but got I8
		//IL_01ce: Expected O, but got I4
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_00b1: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c7: Expected O, but got I4
		//IL_0163: Expected O, but got I8
		//IL_0132: Expected O, but got I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0148: Expected O, but got I4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_0168;
			}
		}
		obj5 = 4294967295L;
		goto IL_0168;
		IL_01e9:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		return;
		IL_0168:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_01e9;
			}
		}
		obj6 = 4294967295L;
		goto IL_01e9;
	}

	public override void InternalUpdate()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		float2 velocity = (float2)(_aimVec * _saveVelX);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.GattiProjectile)+E4]");
		object obj = 0 * _saveVelY;
		ArcadeSprite sprite = _sprite;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = velocity;
				BaseBody baseBody2 = body;
				if (body != null)
				{
					bool flag = 0 < (nint)baseBody2._velocity;
					object obj2 = 0 - baseBody2._velocity;
					bool flag2 = obj2 == null;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					bool flag5 = flag4 & flag3;
					ArcadeSprite arcadeSprite = setFlipX(flag5);
					if ((object)_summon != null)
					{
						Transform transform = _summon.transform;
						Transform transform2 = base.transform;
						if ((object)transform2 != null)
						{
							bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
							bool flag7 = (object)transform == null;
							bool flag8 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_chooseTimer != null)
		{
			_chooseTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	private void OnExpireTimer()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		//IL_00ab: Expected I, but got O
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
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GattiProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween onExpireAlphaTween = Tweens.Add(tweenConfig);
		_onExpireAlphaTween = onExpireAlphaTween;
	}

	private void TargetPlayer()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = base.position;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
		float projectileSpeed = base.ProjectileSpeed;
		object obj4 = default(object);
		object obj5 = default(object);
		Vector2 aimVec = (Vector2)(obj4 * obj5);
		object obj6 = obj2 * obj5;
		_aimVec = aimVec;
	}

	private unsafe void ChooseTarget()
	{
		//IL_0152: Expected O, but got I
		//IL_039d: Expected O, but got I
		//IL_03d3: Invalid comparison between F4 and I
		//IL_0455: Invalid comparison between F4 and I
		//IL_047a: Invalid comparison between F4 and I
		//IL_049f: Invalid comparison between F4 and I
		//IL_04c4: Invalid comparison between F4 and I
		//IL_01a4->IL0515: Incompatible stack heights: 1 vs 0
		//IL_029a->IL0515: Incompatible stack heights: 1 vs 0
		//IL_02fa->IL0515: Incompatible stack heights: 1 vs 0
		//IL_0671->IL0515: Incompatible stack heights: 1 vs 0
		//IL_0329->IL0515: Incompatible stack heights: 1 vs 0
		//IL_01f0->IL0515: Incompatible stack heights: 1 vs 0
		//IL_034b->IL0515: Incompatible stack heights: 1 vs 0
		//IL_03bd->IL0515: Incompatible stack heights: 2 vs 0
		//IL_0515->IL0698: Incompatible stack heights: 2 vs 1
		//IL_040b->IL0515: Incompatible stack heights: 2 vs 0
		//IL_042d->IL0515: Incompatible stack heights: 2 vs 0
		//IL_0267->IL0515: Incompatible stack heights: 1 vs 0
		//IL_074e->IL0698: Incompatible stack heights: 2 vs 1
		//IL_04d6->IL0698: Incompatible stack heights: 2 vs 1
		Weapon weapon = _weapon;
		float num4 = default(float);
		object obj2 = default(object);
		float num10;
		if ((object)_weapon != null)
		{
			bool num;
			Vector3 ret;
			float num3 = default(float);
			if (weapon.IsHoming)
			{
				Transform nearestEnemyTransform = base.GetNearestEnemyTransform();
				if ((object)nearestEnemyTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v87 (UnityEngine.Transform)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v87 (UnityEngine.Transform)+10]");
						bool flag = (nint)0 == 0;
						num = flag;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v87 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out ret);
						float2 float5 = base.position;
						float num2 = num3 - num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
						float projectileSpeed = base.ProjectileSpeed;
						object obj = default(object);
						Vector2 aimVec = (Vector2)(obj * obj2);
						float num5 = num4 * (float)obj2;
						_aimVec = aimVec;
						return;
					}
				}
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				PhysicsManager physicsManager = core._physicsManager;
				if (core._physicsManager != null)
				{
					PhysicsGroup pickupGroup = physicsManager._pickupGroup;
					if (physicsManager._pickupGroup != null)
					{
						Func<PhaserGameObject, bool> predicate = _003C_003Ec._003C_003E9__20_0;
						if (_003C_003Ec._003C_003E9__20_0 == null)
						{
							predicate = (_003C_003Ec._003C_003E9__20_0 = delegate(PhaserGameObject phaserGameObject2)
							{
								//IL_00ec: Expected I, but got O
								//IL_000d: Expected I, but got O
								//IL_001d: Expected O, but got I
								//IL_00ff: Expected I4, but got O
								//IL_0059: Expected O, but got I
								//IL_00ca: Expected O, but got I
								nint num13 = (nint)typeof(Pickup);
								nint num14 = (nint)phaserGameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<PhaserGameObject>)+130]");
								nint num15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
								if (num15 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<PhaserGameObject>)+C8]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v6+FFFFFFF8+v42 @ rax_v5*8]");
									if (0 == (nint)typeof(Pickup))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [phaserGameObject @ rdx (PhaserGameObject)+F8]");
										if ((nint)0 == 12)
										{
											return true;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [phaserGameObject @ rdx (PhaserGameObject)+F8]");
										object obj7 = -17;
										return obj7 == null;
									}
								}
								InvalidCastException ex = new InvalidCastException();
								return (byte)(int)ex != 0;
							});
						}
						IEnumerable<PhaserGameObject> enumerable = Enumerable.Where(((Group)pickupGroup).children, predicate);
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rbx_v13 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							IEnumerable<PhaserGameObject> enumerable2 = Enumerable.Where((IEnumerable<PhaserGameObject>)0, predicate);
						}
						bool flag2 = enumerable == null;
						num = flag2;
						List<object> list = new List<object>(enumerable);
						if (list != null)
						{
							bool num9;
							if (list._size <= 0)
							{
								Weapon weapon2 = _weapon;
								if ((object)_weapon != null)
								{
									Weapon weapon3 = _weapon;
									ICollection<PhaserGameObject> critChancesArray = (ICollection<PhaserGameObject>)weapon2._critChancesArray;
									int critIndex = weapon3._critIndex + 1;
									weapon3._critIndex = critIndex;
									Weapon weapon4 = _weapon;
									if ((object)_weapon != null)
									{
										List<float> critChancesArray2 = weapon4._critChancesArray;
										if (weapon4._critChancesArray != null && weapon2._critChancesArray != null)
										{
											int critIndex2 = weapon3._critIndex;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ r9_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
											int num7 = (int)((nint)critIndex2 % (nint)0);
											int num8 = num7;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1077 @ r8_v14 (System.Collections.Generic.ICollection`1<PhaserGameObject>)+18]");
											bool flag3 = (nint)num8 >= (nint)0;
											num9 = flag3;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1077 @ r8_v14 (System.Collections.Generic.ICollection`1<PhaserGameObject>)+10]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1077 @ r8_v14 (System.Collections.Generic.ICollection`1<PhaserGameObject>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v39+20+v1349 @ rdx_v20 (System.Int32)*4]");
												if (0.2f > 0f)
												{
													TargetPlayer();
													return;
												}
												Weapon weapon5 = _weapon;
												if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
												{
													float2 float6 = ((Equipment)weapon5)._003COwner_003Ek__BackingField.position;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v39+20+v1349 @ rdx_v20 (System.Int32)*4]");
													if (!(0.25f > 0f))
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v39+20+v1349 @ rdx_v20 (System.Int32)*4]");
														if (!(0.5f > 0f))
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v39+20+v1349 @ rdx_v20 (System.Int32)*4]");
															if (!(0.75f > 0f))
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v39+20+v1349 @ rdx_v20 (System.Int32)*4]");
																if (!(1f > 0f))
																{
																	return;
																}
																num10 = num4 - 2f;
															}
															else
															{
																num10 = num4 + 2f;
															}
															goto IL_06f1;
														}
													}
													num10 = num4;
													goto IL_06f1;
												}
											}
										}
									}
								}
							}
							else
							{
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && (object)s_scene.physics != null)
								{
									PhaserGameObject phaserGameObject = s_scene.physics.closest(this, (ICollection<PhaserGameObject>)list);
									if ((object)phaserGameObject == null || ((UnityEngine.Object)phaserGameObject).m_CachedPtr == (IntPtr)0)
									{
										return;
									}
									Transform transform = phaserGameObject.transform;
									if ((object)transform != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v58 (UnityEngine.Transform)+10]");
										bool flag4 = (nint)0 == 0;
										num9 = flag4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v58 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out ret);
										num10 = num3;
										List<float> critChancesArray2 = null;
										ICollection<PhaserGameObject> critChancesArray = (ICollection<PhaserGameObject>)list;
										int num7 = (int)(&ret);
										goto IL_06f1;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_06f1:
		float2 float7 = base.position;
		float num11 = num4 - num10;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
		float projectileSpeed2 = base.ProjectileSpeed;
		float num12 = (float)obj2 * num4;
		object obj4 = default(object);
		Vector2 aimVec2 = (Vector2)(obj2 * obj4);
		_aimVec = aimVec2;
	}

	private void _003CInitProjectile_003Eb__14_0()
	{
		//IL_0015: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)1);
	}
}
