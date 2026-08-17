using System;
using System.Collections.Generic;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Evil1_Projectile : Projectile
{
	private float _radius = 12f;

	private PhaserSprite _displaySprite;

	private PhaserSprite _displaySprite2;

	private Tween _radiusTween;

	private List<string> frames;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _alphaTween2;

	private Vector2 _sineOffset;

	private float _sineTime;

	private float _sineRadius;

	private VampireSurvivors.Framework.TimerSystem.Timer _expireTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		string spriteName = Extensions.PickRnd(frames);
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite displaySprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", spriteName);
		_displaySprite = displaySprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", spriteName);
		PhaserSprite displaySprite2 = phaserSprite.setBlendMode(BlendMode.Add);
		_displaySprite2 = displaySprite2;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_056f: Expected O, but got I4
		//IL_060d: Expected O, but got I4
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Expected F4, but got Unknown
		//IL_007c: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_0207: Expected I, but got O
		//IL_021a: Expected O, but got I4
		//IL_033b: Expected I, but got O
		//IL_034e: Expected O, but got I4
		//IL_0502: Expected O, but got I4
		//IL_064c: Expected O, but got F4
		//IL_0679: Expected I4, but got F4
		//IL_0531: Expected F4, but got I4
		//IL_017f->IL053b: Incompatible stack heights: 7 vs 0
		//IL_01f5->IL053b: Incompatible stack heights: 7 vs 0
		//IL_01d3->IL01d3: Incompatible stack heights: 8 vs 7
		//IL_02b3->IL053b: Incompatible stack heights: 7 vs 0
		//IL_0329->IL053b: Incompatible stack heights: 7 vs 0
		//IL_0307->IL0307: Incompatible stack heights: 8 vs 7
		//IL_03dc->IL053b: Incompatible stack heights: 7 vs 0
		//IL_047f->IL053b: Incompatible stack heights: 7 vs 0
		//IL_04b2->IL053b: Incompatible stack heights: 7 vs 0
		base.InitProjectile(pool, weapon, index);
		_sineTime = 0f;
		setVelocity(0f, (float?)(object)1);
		base.angle = 0f;
		if ((object)_displaySprite != null)
		{
			Transform transform = _displaySprite.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			Transform transform2 = _displaySprite2.transform;
			bool flag2 = (object)transform2 == null;
			bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			float radius = _radius;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float num = radius ^ 0;
			bool flag4 = body == null;
			BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
			bool flag5 = (object)_weapon == null;
			float num2 = _weapon.PArea();
			ArcadeSprite arcadeSprite2 = setScale(num, (float?)(object)0);
			bool flag6 = (object)_displaySprite == null;
			PhaserSprite phaserSprite = _displaySprite.setAlpha(0f);
			bool flag7 = (object)_displaySprite2 == null;
			PhaserSprite phaserSprite2 = _displaySprite2.setAlpha(0f);
			if (_alphaTween != null)
			{
				_alphaTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				if ((object)_displaySprite != null)
				{
					void* value3 = ((IntPtr*)(&array))->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj = default(object);
					bool flag8 = obj == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
					((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1128792064;
					((GameMonoBehaviour)(object)tweenConfig)._onPauseSent = true;
					_ = 1;
					MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
					_alphaTween = alphaTween;
					if (_alphaTween2 != null)
					{
						_alphaTween2.Kill();
					}
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[1];
					if (array2 != null)
					{
						if ((object)_displaySprite2 != null)
						{
							void* value4 = ((IntPtr*)(&array2))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj2 = default(object);
							bool flag9 = obj2 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig2 != null)
						{
							((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
							((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1140457472;
							((GameMonoBehaviour)(object)tweenConfig2)._onPauseSent = true;
							_ = 1;
							_ = 4294967295L;
							_ = 1;
							MultiTargetTween alphaTween2 = Tweens.Add(tweenConfig2);
							_alphaTween2 = alphaTween2;
							if (_expireTimer != null)
							{
								_expireTimer.Cancel();
							}
							if ((object)_weapon != null)
							{
								float num3 = _weapon.PDuration();
								Action onComplete = StartDespawn;
								float num4 = num * 0.001f;
								bool flag10 = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								VampireSurvivors.Framework.TimerSystem.Timer expireTimer = Timers.Register(num4, onComplete, null, isLooped: false, flag10, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_expireTimer = expireTimer;
								ArcadeSprite arcadeSprite3 = setDepth(8);
								if ((object)_displaySprite != null)
								{
									PhaserSprite phaserSprite3 = _displaySprite.setDepth(8);
									if ((object)_displaySprite2 != null)
									{
										PhaserSprite phaserSprite4 = _displaySprite2.setDepth(9);
										if (index == 0)
										{
											SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
											{
												Volume = (float?)(object)1,
												Rate = 1f
											};
											object obj3 = UnityEngine.Random.value;
											float num5 = num4 - 0.5f;
											float num6 = num5 * 300f;
											((GameMonoBehaviour)(object)soundConfig)._onPauseSent = (byte)(int)num6 != 0;
											PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hex, soundConfig, 200f, 3, flag10 ? 1 : 0);
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
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		//IL_00c9: Expected I, but got O
		//IL_0063: Expected O, but got I4
		nint num = (nint)typeof(PauseSystem);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<PauseSystem>)+B8]");
		nint num2 = 0;
		if (!PauseSystem._paused)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num3 = deltaTime * 1000f;
			float num4 = num3 * 0.005f;
			float num5 = (_sineTime = num4 + _sineTime);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			_sineOffset = (Vector2)0;
			float num6 = num5 * _sineRadius;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6CFF0");
			float num7 = num5 * 57.29578f;
			base.angle = num7;
			float2 float5 = base.position;
			float2 float6 = default(float2);
			base.position = float6;
		}
	}

	public void SetDirection(float dir)
	{
		//IL_002d: Expected O, but got I4
		float projectileSpeed = base.ProjectileSpeed;
		object obj = default(object);
		float xVel = (float)obj * dir;
		setVelocity(xVel, (float?)(object)1);
	}

	private void StartDespawn()
	{
		Despawn();
	}

	public override void Despawn()
	{
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_alphaTween2 != null)
		{
			_alphaTween2.Kill();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	public TP_Evil1_Projectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_HexRunes_01");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_HexRunes_02");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_HexRunes_03");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_HexRunes_04");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_HexRunes_05");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_HexRunes_06");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_HexRunes_07");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_HexRunes_08");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		frames = list;
		_sineRadius = 0.016f;
		base._002Ector();
	}
}
