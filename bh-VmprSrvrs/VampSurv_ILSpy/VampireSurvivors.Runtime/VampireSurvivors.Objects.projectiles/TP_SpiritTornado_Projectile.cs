using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SpiritTornado_Projectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<PhaserGameObject, bool> _003C_003E9__15_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CChooseTarget_003Eb__15_0(PhaserGameObject phaserGameObject)
		{
			//IL_00be: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_001d: Expected O, but got I
			//IL_00d1: Expected I4, but got O
			//IL_0059: Expected O, but got I
			//IL_009c: Expected O, but got I
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
					object obj3 = -6;
					return obj3 == null;
				}
			}
			InvalidCastException ex = new InvalidCastException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public TP_SpiritTornado_Projectile _003C_003E4__this;

		public bool tweenIn;

		public float2 scaleFrom;

		public float2 scaleTo;

		public float alphaFrom;

		public float alphaTo;

		internal void _003CTweenInOut_003Eb__0()
		{
			//IL_001e: Expected F4, but got O
			//IL_0037: Expected O, but got I4
			//IL_000f: Expected F4, but got O
			float xScale = ((!tweenIn) ? ((float)scaleTo) : ((float)scaleFrom));
			ArcadeSprite arcadeSprite = _003C_003E4__this.setScale(xScale, (float?)(object)1);
			float alpha = ((!tweenIn) ? alphaTo : alphaFrom);
			ArcadeSprite arcadeSprite2 = _003C_003E4__this.setAlpha(alpha);
			TP_SpiritTornado_Projectile tP_SpiritTornado_Projectile = _003C_003E4__this;
			BaseBody body = tP_SpiritTornado_Projectile.body;
			body._enable = false;
		}

		internal void _003CTweenInOut_003Eb__1()
		{
			TP_SpiritTornado_Projectile tP_SpiritTornado_Projectile = _003C_003E4__this;
			if (!tweenIn)
			{
				tP_SpiritTornado_Projectile.Despawn();
				return;
			}
			BaseBody body = tP_SpiritTornado_Projectile.body;
			body._enable = tweenIn;
		}
	}

	private float _radius = 32f;

	private Vector2 _aimVec;

	private PhaserSprite _displaySprite;

	private PhaserSprite _animatedSprite;

	private uint[] _colors = new uint[5] { 13434828u, 143654860u, 4521932u, 4521932u, 8978312u };

	private readonly BlendMode[] _blendModes = new BlendMode[4]
	{
		BlendMode.Normal,
		BlendMode.Screen,
		BlendMode.Screen,
		BlendMode.Screen
	};

	private bool _initSpriteTrail;

	private MultiTargetTween _scaleTween;

	private Timer _expireTimer;

	private Timer _chooseTimer;

	protected override void Awake()
	{
		//IL_0359: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_0139: Expected O, but got I4
		//IL_0139: Expected I4, but got O
		//IL_0175: Expected O, but got I4
		//IL_0296: Expected O, but got I4
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		base.Awake();
		_aimVec = (Vector2)0;
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite displaySprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Tornado05");
		_displaySprite = displaySprite;
		PhaserSprite phaserSprite = _displaySprite.setAlpha(0.8f);
		PhaserSprite phaserSprite2 = _displaySprite.setOrigin(0.5f, (float?)(object)1);
		GameObject gameObject2 = base.gameObject;
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "ThosePeople", "TP_VFX_Tornado01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Tornado", 1, 4, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.SetAnimation("loop");
		PhaserSprite phaserSprite3 = _animatedSprite.setOrigin(0.5f, (float?)(object)1);
		if (_initSpriteTrail)
		{
			return;
		}
		PhaserSprite displaySprite2 = _displaySprite;
		_initSpriteTrail = true;
		GameObject gameObject3 = displaySprite2._spriteRenderer.gameObject;
		SpriteTrail spriteTrail = gameObject3.AddComponent<SpriteTrail>();
		_spriteTrail = spriteTrail;
		PhaserSprite displaySprite3 = _displaySprite;
		SpriteTrail spriteTrail2 = _spriteTrail;
		spriteTrail2._MainSprite = displaySprite3._spriteRenderer;
		SpriteTrail spriteTrail3 = _spriteTrail;
		spriteTrail3._DefaultGhostAlpha = 0.6f;
		SpriteTrail spriteTrail4 = _spriteTrail;
		spriteTrail4._AlphaDecayPerGhost = 0.2f;
		SpriteTrail spriteTrail5 = _spriteTrail;
		spriteTrail5._MaxHistory = 3;
		spriteTrail5.InitialiseGhosts(expandExisting: true);
		SpriteTrail spriteTrail6 = _spriteTrail.setVisible(b: true);
		object obj = 0;
		while (true)
		{
			SpriteTrail spriteTrail7 = _spriteTrail;
			List<SpriteRenderer> ghosts = spriteTrail7._ghosts;
			if ((nint)obj >= ghosts._size)
			{
				break;
			}
			SpriteRenderer[] items = ghosts._items;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(tints: new uint[1] { 65535u }, spriteRenderer: items[obj]);
			obj++;
			if ((nint)obj >= 3)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001a: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_014f: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_0310: Expected O, but got F4
		//IL_02ca: Expected O, but got I4
		//IL_0342: Expected O, but got F4
		//IL_02eb: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		PhaserSprite phaserSprite = _animatedSprite.setScale(1.2f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _displaySprite.setScale(0.5f, (float?)(object)0);
		Extensions.Shuffle(_colors);
		uint[] colors = _colors;
		int num = _indexInWeapon % colors.Length;
		PhaserSprite phaserSprite3 = _animatedSprite.setTint(colors[num]);
		BlendMode[] blendModes = _blendModes;
		int num2 = _indexInWeapon % blendModes.Length;
		PhaserSprite phaserSprite4 = _animatedSprite.setBlendMode((BlendMode)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref blendModes[num2]));
		PhaserSprite phaserSprite5 = _animatedSprite.setAlpha(0.75f);
		PhaserSprite phaserSprite6 = _animatedSprite.setVisible(visible: true);
		float radius = _radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = radius ^ 0;
		float radius2 = _radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = radius2 ^ 0;
		BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
		TweenInOut();
		object obj3 = UnityEngine.Random.value;
		float num3 = (float)obj2 * ((float)Math.PI * 2f);
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 float6 = default(float2);
		base.position = float6;
		Weapon weapon2 = _weapon;
		float2 float7 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
		float2 float8 = base.position;
		object obj4 = obj2 - obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
		float projectileSpeed = base.ProjectileSpeed;
		object obj5 = default(object);
		Vector2 aimVec = (Vector2)(obj5 * (object)float6);
		object obj6 = obj2 * (object)float6;
		_aimVec = aimVec;
		StartChooseTargetTimer();
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num4 = _weapon.PDuration();
		Action onComplete = StartDespawn;
		float num5 = (float)float6 * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(num5, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.4f;
		soundConfig.Volume = (float?)(object)1;
		object obj7 = UnityEngine.Random.value;
		float num6 = num5 - 0.5f;
		float detune = num6 * 500f;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Pneuma, soundConfig, 500f, 1, flag ? 1 : 0);
	}

	private void TweenInOut(bool tweenIn = true)
	{
		//IL_002f: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_00b0: Expected I, but got O
		//IL_01a1: Expected O, but got I4
		//IL_01d1: Expected O, but got I4
		//IL_0201: Expected O, but got I4
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals20._003C_003E4__this = this;
		CS_0024_003C_003E8__locals20.tweenIn = tweenIn;
		CS_0024_003C_003E8__locals20.scaleFrom = (float2)0;
		_ = 1082130432;
		CS_0024_003C_003E8__locals20.scaleTo = (float2)1065353216;
		_ = 1065353216;
		CS_0024_003C_003E8__locals20.alphaTo = 0.8f;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			if (CS_0024_003C_003E8__locals20.tweenIn)
			{
			}
			tweenConfig.scaleX = (float?)(object)1;
			if (CS_0024_003C_003E8__locals20.tweenIn)
			{
			}
			tweenConfig.scaleY = (float?)(object)1;
			if (CS_0024_003C_003E8__locals20.tweenIn)
			{
			}
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.duration = 200f;
			tweenConfig.ease = Ease.InOutSine;
			TweenCallback onStart = delegate
			{
				//IL_001e: Expected F4, but got O
				//IL_0037: Expected O, but got I4
				//IL_000f: Expected F4, but got O
				float xScale = ((!CS_0024_003C_003E8__locals20.tweenIn) ? ((float)CS_0024_003C_003E8__locals20.scaleTo) : ((float)CS_0024_003C_003E8__locals20.scaleFrom));
				ArcadeSprite arcadeSprite = CS_0024_003C_003E8__locals20._003C_003E4__this.setScale(xScale, (float?)(object)1);
				float alpha = ((!CS_0024_003C_003E8__locals20.tweenIn) ? CS_0024_003C_003E8__locals20.alphaTo : CS_0024_003C_003E8__locals20.alphaFrom);
				ArcadeSprite arcadeSprite2 = CS_0024_003C_003E8__locals20._003C_003E4__this.setAlpha(alpha);
				TP_SpiritTornado_Projectile tP_SpiritTornado_Projectile = CS_0024_003C_003E8__locals20._003C_003E4__this;
				BaseBody baseBody = tP_SpiritTornado_Projectile.body;
				baseBody._enable = false;
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				TP_SpiritTornado_Projectile tP_SpiritTornado_Projectile = CS_0024_003C_003E8__locals20._003C_003E4__this;
				if (!CS_0024_003C_003E8__locals20.tweenIn)
				{
					tP_SpiritTornado_Projectile.Despawn();
				}
				else
				{
					BaseBody baseBody = tP_SpiritTornado_Projectile.body;
					baseBody._enable = CS_0024_003C_003E8__locals20.tweenIn;
				}
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void StartDespawn()
	{
		TweenInOut(tweenIn: false);
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

	private void ChooseTarget()
	{
		//IL_00ed: Expected O, but got I
		//IL_013f->IL0225: Incompatible stack heights: 1 vs 0
		//IL_02c2->IL0225: Incompatible stack heights: 1 vs 0
		//IL_018b->IL0225: Incompatible stack heights: 1 vs 0
		//IL_0202->IL0225: Incompatible stack heights: 1 vs 0
		//IL_036c->IL02e9: Incompatible stack heights: 2 vs 1
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				PhysicsManager physicsManager = core._physicsManager;
				if (core._physicsManager != null)
				{
					PhysicsGroup pickupGroup = physicsManager._pickupGroup;
					if (physicsManager._pickupGroup != null)
					{
						Func<PhaserGameObject, bool> predicate = _003C_003Ec._003C_003E9__15_0;
						if (_003C_003Ec._003C_003E9__15_0 == null)
						{
							predicate = (_003C_003Ec._003C_003E9__15_0 = delegate(PhaserGameObject phaserGameObject2)
							{
								//IL_00be: Expected I, but got O
								//IL_000d: Expected I, but got O
								//IL_001d: Expected O, but got I
								//IL_00d1: Expected I4, but got O
								//IL_0059: Expected O, but got I
								//IL_009c: Expected O, but got I
								nint num2 = (nint)typeof(Pickup);
								nint num3 = (nint)phaserGameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<PhaserGameObject>)+130]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
								if (num4 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<PhaserGameObject>)+C8]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v6+FFFFFFF8+v42 @ rax_v5*8]");
									if (0 == (nint)typeof(Pickup))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [phaserGameObject @ rdx (PhaserGameObject)+F8]");
										object obj7 = -6;
										return obj7 == null;
									}
								}
								InvalidCastException ex = new InvalidCastException();
								return (byte)(int)ex != 0;
							});
						}
						IEnumerable<PhaserGameObject> enumerable = Enumerable.Where(((Group)pickupGroup).children, predicate);
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rbx_v6 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							IEnumerable<PhaserGameObject> enumerable2 = Enumerable.Where((IEnumerable<PhaserGameObject>)0, predicate);
						}
						bool flag = enumerable == null;
						List<object> list = new List<object>(enumerable);
						if (list != null)
						{
							if (list._size <= 0)
							{
								Transform transform = base.AimForNearestEnemy(rotate: false);
								return;
							}
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null && (object)s_scene.physics != null)
							{
								PhaserGameObject phaserGameObject = s_scene.physics.closest(this, (ICollection<PhaserGameObject>)list);
								if ((object)phaserGameObject == null || ((UnityEngine.Object)phaserGameObject).m_CachedPtr == (IntPtr)0)
								{
									return;
								}
								Transform transform2 = phaserGameObject.transform;
								if ((object)transform2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v38 (UnityEngine.Transform)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v38 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 _);
									float2 float5 = base.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
									float projectileSpeed = base.ProjectileSpeed;
									object obj = default(object);
									object obj2 = default(object);
									Vector2 aimVec = (Vector2)(obj * obj2);
									object obj4 = default(object);
									object obj3 = obj4 * obj2;
									_aimVec = aimVec;
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StartChooseTargetTimer()
	{
		//IL_010e: Expected O, but got I
		//IL_003e: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		TP_SpiritTornado_Projectile tP_SpiritTornado_Projectile = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			tP_SpiritTornado_Projectile = (TP_SpiritTornado_Projectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v47 @ rax_v3 (should have been resolved before IL gen)");
		float num = _weapon.PSpeed();
		bool flag2 = 0.1f > 1000f;
		float num2 = 0.1f;
		if (!flag2)
		{
			num2 = 1000f;
		}
		float num3 = 1000f / num2;
		if (_chooseTimer != null)
		{
			_chooseTimer.Cancel();
		}
		Action onComplete = delegate
		{
			ChooseTarget();
			StartChooseTargetTimer();
		};
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer chooseTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_chooseTimer = chooseTimer;
	}

	private void LateUpdate()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = _aimVec;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_SpiritTornado_Projectile)+D8]");
		_ = 0;
		BaseBody baseBody2 = body;
		bool flag = 0 < (nint)baseBody2._velocity;
		object obj = 0 - baseBody2._velocity;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		PhaserSprite phaserSprite = _displaySprite.setFlipX(flag5);
	}

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
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

	private void _003CStartChooseTargetTimer_003Eb__16_0()
	{
		ChooseTarget();
		StartChooseTargetTimer();
	}
}
