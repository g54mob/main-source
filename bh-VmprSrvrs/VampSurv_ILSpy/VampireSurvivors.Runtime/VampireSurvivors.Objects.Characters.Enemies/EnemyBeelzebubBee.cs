using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyBeelzebubBee : EnemyController
{
	private enum BeeState
	{
		Entering,
		Circling,
		Attacking
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public EnemyBeelzebubBee _003C_003E4__this;

		public float attackDelay;

		internal void _003CInit_003Eb__0()
		{
			EnemyBeelzebubBee enemyBeelzebubBee = _003C_003E4__this;
			if (!((EnemyController)enemyBeelzebubBee)._003CIsDead_003Ek__BackingField)
			{
				enemyBeelzebubBee._state = BeeState.Circling;
				EnemyBeelzebubBee enemyBeelzebubBee2 = _003C_003E4__this;
				BaseBody body = enemyBeelzebubBee2.body;
				body._enable = true;
				EnemyBeelzebubBee enemyBeelzebubBee3 = _003C_003E4__this;
				enemyBeelzebubBee3._SpriteAnimation.SetAnimation("Fly");
				Action onComplete = _003C_003E4__this.Attack;
				float duration = attackDelay * 0.001f;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public PhaserSprite exp;

		internal void _003CSetupExplosions_003Eb__0()
		{
			PhaserSprite phaserSprite = exp.setVisible(visible: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public int localIndex;

		public Vector3 bodyPos;

		public float expAngle;

		public float radius;

		public float rnd;

		public EnemyBeelzebubBee _003C_003E4__this;

		internal void _003CPlayExplosions_003Eb__0()
		{
			//IL_015c: Expected F4, but got I4
			EnemyBeelzebubBee enemyBeelzebubBee = _003C_003E4__this;
			List<PhaserSprite> explosionSprites = enemyBeelzebubBee.explosionSprites;
			if (explosionSprites._size >= localIndex)
			{
				EnemyBeelzebubBee enemyBeelzebubBee2 = _003C_003E4__this;
				List<PhaserSprite> explosionSprites2 = enemyBeelzebubBee2.explosionSprites;
				int num = localIndex;
				if (localIndex < explosionSprites2._size)
				{
					PhaserSprite[] items = explosionSprites2._items;
					PhaserSprite phaserSprite = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num2 = expAngle * radius;
					float num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyBeelzebubBee+<>c__DisplayClass22_0)+18]");
					float num4 = num3 + 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
					PhaserSprite phaserSprite2 = items[num].setVisible(visible: true);
					phaserSprite._spriteAnimation.SetAnimation("bang");
					float? volume = default(float?);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.ExploGH, 500f, 10, 0f, volume, rate, detune, loop, 1f);
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			}
		}
	}

	private float2 _startPos;

	private int _groupIndex;

	private int _groupSize;

	private EnemyBeelzebub _parentBoss;

	private float _age;

	private BeeState _state;

	private float2 _attackVector;

	private bool _hasExplosions;

	private List<PhaserSprite> explosionSprites;

	private float offsetRadius;

	private List<Timer> explosionTimers;

	private int ExplosionsNumber;

	private bool _initialized;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0193: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		base.InitEnemy(enemyType, asRemote);
		ArcadeSprite arcadeSprite = setScale(4f, (float?)(object)0);
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._immovable = true;
		BaseBody baseBody3 = body;
		baseBody3._pushable = false;
		_deathStyle = EnemyDeathStyle.Die;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187074010");
		object obj = default(object);
		if (obj == null)
		{
			_SpriteAnimation.CleanAnimations();
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			spriteAnimation._originalSpriteSize = (float2)1115684864;
			_ = 1115684864;
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Beelzebub_BeeAway", 1, 2, "Beelzebub", num);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_SpriteAnimation.AddAnimation("Enter", animationFrames, 32, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("Beelzebub_Bee", 1, 3, "Beelzebub", num);
			_SpriteAnimation.AddAnimation("Fly", animationFrames2, 32, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		}
		SetupExplosions();
	}

	public void OnlineInit(int groupIndex, int groupSize, float circlingAngle, float attackDelay, CoherenceSync parentBoss)
	{
		Component component2 = default(Component);
		EnemyBeelzebub component = component2.GetComponent<EnemyBeelzebub>();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 52 Invalid \"Jump target not found in method: 0x18769B410\"");
		throw new NullReferenceException();
	}

	public void Init(int groupIndex, int groupSize, float circlingAngle, float attackDelay, EnemyBeelzebub parentBoss)
	{
		//IL_0100: Expected I, but got O
		//IL_0164: Expected O, but got I4
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		float attackDelay2 = default(float);
		CS_0024_003C_003E8__locals7.attackDelay = attackDelay2;
		_initialized = true;
		int groupIndex2 = default(int);
		_groupIndex = groupIndex2;
		int groupSize2 = default(int);
		_groupSize = groupSize2;
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		_parentBoss = (EnemyBeelzebub)arcadeSprite;
		_age = 0f;
		float num = (float)_groupIndex * ((float)Math.PI * 2f);
		float num2 = num / (float)_groupSize;
		float num3 = num2 + circlingAngle;
		float2 float5 = arcadeSprite.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float2 float6 = default(float2);
		base.position = float6;
		float2 startPos = base.position;
		BaseBody baseBody = body;
		_startPos = startPos;
		baseBody._enable = false;
		_SpriteAnimation.SetAnimation("Enter");
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num4 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 1000f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				EnemyBeelzebubBee enemyBeelzebubBee = CS_0024_003C_003E8__locals7._003C_003E4__this;
				if (!((EnemyController)enemyBeelzebubBee)._003CIsDead_003Ek__BackingField)
				{
					enemyBeelzebubBee._state = BeeState.Circling;
					EnemyBeelzebubBee enemyBeelzebubBee2 = CS_0024_003C_003E8__locals7._003C_003E4__this;
					BaseBody baseBody2 = enemyBeelzebubBee2.body;
					baseBody2._enable = true;
					EnemyBeelzebubBee enemyBeelzebubBee3 = CS_0024_003C_003E8__locals7._003C_003E4__this;
					enemyBeelzebubBee3._SpriteAnimation.SetAnimation("Fly");
					Action onComplete2 = CS_0024_003C_003E8__locals7._003C_003E4__this.Attack;
					float duration = CS_0024_003C_003E8__locals7.attackDelay * 0.001f;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				}
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void Attack()
	{
		if (!base._003CIsDead_003Ek__BackingField)
		{
			_state = BeeState.Attacking;
			float2 float5 = base.position;
			bool includeFollowers = default(bool);
			CharacterController closestPlayer = GM.Core.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
			Transform transform = closestPlayer.transform;
			if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				throw new NullReferenceException();
			}
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			float2 float6 = base.position;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj = obj2 - obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
			float2 attackVector = default(float2);
			_attackVector = attackVector;
		}
	}

	protected override void OnUpdate()
	{
		//IL_00e4: Expected O, but got I4
		//IL_0228: Expected O, but got I4
		//IL_0228: Expected O, but got I4
		if (!_initialized)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
		float deltaTime = PauseSystem.DeltaTime;
		float num2 = (_age = deltaTime + _age);
		float num3 = (float)_groupIndex * ((float)Math.PI * 2f);
		float num4 = num2 * -1f;
		float num5 = num3 / (float)_groupSize;
		float num6 = num5 + num4;
		float2 float5 = _parentBoss.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		bool flag = _state == BeeState.Entering;
		float2 float7;
		float2 float8 = default(float2);
		if (!flag)
		{
			object obj = _state - 1;
			if (!flag)
			{
				if ((nint)obj == 1)
				{
					float2 float6 = base.position;
					float deltaTime2 = PauseSystem.DeltaTime;
					float7 = float8;
					goto IL_0250;
				}
			}
			else
			{
				base.position = float8;
				float2 float9 = base.position;
				bool includeFollowers = default(bool);
				CharacterController closestPlayer = GM.Core.GetClosestPlayer(float9, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
				float2 float10 = closestPlayer.position;
				float2 float11 = base.position;
				bool flag2 = (byte)(float11 < float10) != 0;
				object obj2 = float11 - float10;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				bool flag6 = flag5 & flag4;
				base.SetFlipX(flag6);
			}
			goto IL_01fa;
		}
		float7 = float8;
		goto IL_0250;
		IL_0250:
		base.position = float7;
		goto IL_01fa;
		IL_01fa:
		if (!base.flipX)
		{
		}
		BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
	}

	protected override void Die()
	{
		PlayExplosions();
		base.Die();
	}

	public override void Despawn()
	{
		List<Timer> list = explosionTimers;
		if (explosionTimers != null)
		{
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
			}
		}
		base.Despawn();
	}

	private unsafe void SetupExplosions()
	{
		//IL_0072: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_0601: Expected I, but got O
		//IL_065f: Expected I, but got O
		//IL_0185: Expected I, but got O
		//IL_019b: Expected O, but got I
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_0212: Expected I, but got O
		//IL_0544: Expected O, but got I4
		//IL_055b: Expected I, but got I8
		//IL_01fb: Expected I, but got I8
		//IL_06ba: Expected I, but got O
		//IL_0718: Expected I, but got O
		//IL_05b3: Expected I, but got O
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected O, but got Unknown
		//IL_062a->IL0512: Incompatible stack heights: 1 vs 0
		//IL_0689->IL0512: Incompatible stack heights: 2 vs 0
		//IL_06e3->IL0512: Incompatible stack heights: 3 vs 0
		//IL_075c->IL073c: Incompatible stack heights: 4 vs 0
		//IL_05d0->IL0512: Incompatible stack heights: 1 vs 0
		//IL_0355->IL0512: Incompatible stack heights: 1 vs 0
		//IL_0384->IL0512: Incompatible stack heights: 1 vs 0
		//IL_03bb->IL0512: Incompatible stack heights: 1 vs 0
		//IL_040a->IL0512: Incompatible stack heights: 1 vs 0
		//IL_04a9->IL0089: Incompatible stack heights: 1 vs 0
		//IL_04ae->IL04ae: Incompatible stack heights: 1 vs 0
		if (_hasExplosions)
		{
			return;
		}
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("HitSmoke", 1, 2, "vfx", num);
		_hasExplosions = true;
		List<PhaserSprite> list = new List<PhaserSprite>();
		explosionSprites = list;
		bool flag = ExplosionsNumber <= 0;
		object obj = 0;
		string text = "vfx";
		if (flag)
		{
			goto IL_04ae;
		}
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		while (true)
		{
			_003C_003Ec__DisplayClass21_0 obj2 = new _003C_003Ec__DisplayClass21_0();
			PhaserWorld instance = PhaserWorld.Instance;
			if ((object)instance == null)
			{
				break;
			}
			PhaserSprite exp = instance.AddPhaserSprite((Vector2)0, "vfx", "HitSmoke1");
			if (obj2 == null)
			{
				break;
			}
			obj2.exp = exp;
			PhaserSprite exp2 = obj2.exp;
			if ((object)obj2.exp == null)
			{
				break;
			}
			Action action = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ r10_v15 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass21_0._003CSetupExplosions_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ r10_v15 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num3;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ r10_v15 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num3 = unchecked((nint)6447293664L);
					goto IL_053b;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num3 = ((Delegate)action).method_ptr;
			goto IL_053b;
			IL_053b:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			if ((object)exp2._spriteAnimation == null)
			{
				break;
			}
			exp2._spriteAnimation.AddAnimation("bang", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			if ((object)obj2.exp == null)
			{
				break;
			}
			PhaserSprite phaserSprite = obj2.exp.setVisible(visible: false);
			if ((object)obj2.exp == null)
			{
				break;
			}
			Transform transform = obj2.exp.transform;
			if ((object)transform == null)
			{
				break;
			}
			bool flag2 = ((List<PhaserSprite>)(object)transform)._items == null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1488 @ rcx_v76 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			Transform.SetParent_Injected((IntPtr)((List<PhaserSprite>)(object)transform)._items, (IntPtr)0, true);
			if ((object)obj2.exp == null)
			{
				break;
			}
			PhaserSprite phaserSprite2 = obj2.exp.setDepth(3000);
			if ((object)obj2.exp == null)
			{
				break;
			}
			GameObject gameObject = obj2.exp.gameObject;
			if ((object)gameObject == null)
			{
				break;
			}
			((UnityEngine.Object)gameObject).SetName("TP_Death_Bang");
			List<object> list2 = (List<object>)(object)explosionSprites;
			if (explosionSprites == null)
			{
				break;
			}
			int version = list2._version + 1;
			list2._version = version;
			text = (string)(object)list2._items;
			if (list2._items == null)
			{
				break;
			}
			int num5 = list2._size;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r9_v14 (System.String)+18]");
			if ((nint)num5 >= (nint)0)
			{
				((List<object>)(object)explosionSprites).AddWithResize((object)obj2.exp);
			}
			else
			{
				int num6 = list2._size + 1;
				list2._size = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			obj++;
			if ((nint)obj < ExplosionsNumber)
			{
				continue;
			}
			goto IL_04ae;
		}
		goto IL_0512;
		IL_0512:
		throw new NullReferenceException();
		IL_04ae:
		CheckRenderer();
		List<PhaserSprite> spriteRenderer = (List<PhaserSprite>)(object)((ArcadeSprite)this)._spriteRenderer;
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			bool flag3 = spriteRenderer._items == null;
			IntPtr gcHandlePtr = SpriteRenderer.get_sprite_Injected((IntPtr)spriteRenderer._items);
			Sprite sprite = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>(gcHandlePtr);
			if ((object)sprite != null)
			{
				bool flag4 = ((List<PhaserSprite>)(object)sprite)._items == null;
				Sprite.get_rect_Injected((IntPtr)((List<PhaserSprite>)(object)sprite)._items, out Rect _);
				CheckRenderer();
				List<PhaserSprite> spriteRenderer2 = (List<PhaserSprite>)(object)((ArcadeSprite)this)._spriteRenderer;
				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
				{
					bool flag5 = spriteRenderer2._items == null;
					IntPtr gcHandlePtr2 = SpriteRenderer.get_sprite_Injected((IntPtr)spriteRenderer2._items);
					Sprite sprite2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>(gcHandlePtr2);
					if ((object)sprite2 != null)
					{
						bool flag6 = ((List<PhaserSprite>)(object)sprite2)._items == null;
						Sprite.get_rect_Injected((IntPtr)((List<PhaserSprite>)(object)sprite2)._items, out Rect _);
						object obj6 = default(object);
						object obj7 = default(object);
						bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7);
						object obj8 = obj6;
						if (!flag7)
						{
							obj8 = obj7;
						}
						float num7 = (float)obj8 * 0.25f;
						offsetRadius = num7;
						return;
					}
				}
			}
		}
		goto IL_0512;
	}

	private unsafe void PlayExplosions()
	{
		//IL_0319: Expected O, but got F4
		//IL_0492: Expected O, but got F4
		//IL_0137: Expected I, but got O
		//IL_014d: Expected O, but got I
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_01c4: Expected I, but got O
		//IL_03e4: Expected O, but got I4
		//IL_03fb: Expected I, but got I8
		//IL_01ad: Expected I, but got I8
		//IL_0460->IL02e0: Incompatible stack heights: 1 vs 0
		//IL_0220->IL02e0: Incompatible stack heights: 1 vs 0
		//IL_02cd->IL02e0: Incompatible stack heights: 1 vs 0
		//IL_02df->IL0465: Incompatible stack heights: 1 vs 0
		List<Timer> list = explosionTimers;
		if (explosionTimers != null)
		{
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
				object[] array = null;
			}
		}
		List<Timer> list2 = new List<Timer>();
		explosionTimers = list2;
		List<PhaserSprite> list3 = explosionSprites;
		if (explosionSprites != null)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			float num = default(float);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				if ((flag3 ? 1 : 0) >= list3._size)
				{
					return;
				}
				_003C_003Ec__DisplayClass22_0 obj = new _003C_003Ec__DisplayClass22_0();
				if (obj == null)
				{
					break;
				}
				obj._003C_003E4__this = this;
				object obj2 = UnityEngine.Random.value;
				obj.rnd = num;
				float num2 = (obj.expAngle = num * 360f);
				object obj3 = UnityEngine.Random.value;
				float num3 = num2 * offsetRadius;
				obj.localIndex = (flag2 ? 1 : 0);
				float num4 = num3 + offsetRadius;
				float radius = num4 * 0.01f;
				obj.radius = radius;
				CheckRenderer();
				object spriteRenderer = ((ArcadeSprite)this)._spriteRenderer;
				if ((object)((ArcadeSprite)this)._spriteRenderer == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdi_v8 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdi_v8 (System.Object)+10]");
				Vector3 ret;
				Renderer.get_bounds_Injected((IntPtr)0, out *(Bounds*)(&ret));
				obj.bodyPos = ret;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Action action = null;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ r10_v7 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass22_0._003CPlayExplosions_003Eb__0);
				((Delegate)action).m_target = obj;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ r10_v7 (Il2CppMethodInfo)+4C]");
				object obj4 = (nint)0 >> 4;
				object obj5 = obj4 & 1;
				nint num6;
				if (obj5 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ r10_v7 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num6 = unchecked((nint)6447293664L);
						goto IL_03db;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num6 = ((Delegate)action).method_ptr;
				goto IL_03db;
				IL_03db:
				object obj6 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				num = (float)(flag ? 1 : 0) * 0.001f;
				Timer item = Timers.Register(num, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				List<object> list4 = (List<object>)(object)explosionTimers;
				if (explosionTimers == null)
				{
					break;
				}
				int version2 = list4._version + 1;
				list4._version = version2;
				object[] array = list4._items;
				if (list4._items == null)
				{
					break;
				}
				if (list4._size >= array.Length)
				{
					((List<object>)(object)explosionTimers).AddWithResize((object)item);
				}
				else
				{
					int num7 = list4._size + 1;
					list4._size = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				list3 = explosionSprites;
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				flag = (byte)((flag ? 1u : 0u) + 30u) != 0;
				if (explosionSprites == null)
				{
					break;
				}
				flag3 = flag2;
			}
		}
		throw new NullReferenceException();
	}

	public EnemyBeelzebubBee()
	{
		List<PhaserSprite> list = new List<PhaserSprite>();
		explosionSprites = list;
		ExplosionsNumber = 12;
		base._002Ector();
	}
}
