using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Props;

public class PropLeverTrain : Destructible
{
	private Stage _stage;

	private bool _hasFired;

	private GameObject _PizzaCircleObj;

	public PizzaCircle PizzaCircle;

	private MultiTargetTween _tween1;

	private Timer _selfCleanTimer;

	private void Construct(Stage stage)
	{
		_stage = stage;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
	}

	public unsafe override void Init(PropType destructibleType)
	{
		//IL_01bf: Expected O, but got Ref
		//IL_01bf: Expected O, but got Ref
		//IL_026a: Expected O, but got I4
		//IL_039f->IL0309: Incompatible stack heights: 1 vs 0
		//IL_0062->IL0309: Incompatible stack heights: 1 vs 0
		//IL_00b2->IL0309: Incompatible stack heights: 1 vs 0
		//IL_0454->IL0309: Incompatible stack heights: 1 vs 0
		//IL_01a4->IL0309: Incompatible stack heights: 1 vs 0
		//IL_0138->IL0309: Incompatible stack heights: 1 vs 0
		//IL_01ec->IL0309: Incompatible stack heights: 1 vs 0
		//IL_0233->IL0309: Incompatible stack heights: 1 vs 0
		//IL_0174->IL0238: Incompatible stack heights: 4 vs 1
		base.Init(destructibleType);
		base._003CIsStationary_003Ek__BackingField = true;
		_hasFired = false;
		CheckRenderer();
		PizzaCircle pizzaCircle;
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			Sprite sprite = ((ArcadeSprite)this)._spriteRenderer.sprite;
			if ((object)sprite != null)
			{
				bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect value);
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						if (config._003CSelectedInverse_003Ek__BackingField)
						{
							PlayerOptionsData config2 = _playerOptions.Config;
							if (config2 == null)
							{
								goto IL_0309;
							}
							if (config2._003CVisuallyInvertStages_003Ek__BackingField)
							{
								base.angle = 180f;
							}
						}
						float2 float5 = base.position;
						MasterObjectPooler pizzaCircleObj = (MasterObjectPooler)(object)_PizzaCircleObj;
						if ((object)_PizzaCircleObj != null && ((UnityEngine.Object)pizzaCircleObj).m_CachedPtr != (IntPtr)0)
						{
							if ((object)PizzaCircle != null)
							{
								Transform transform = PizzaCircle.transform;
								bool flag2 = (object)transform == null;
								bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
								pizzaCircle = PizzaCircle;
								bool flag4 = (object)PizzaCircle == null;
								goto IL_0238;
							}
						}
						else if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
						{
							ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
							if ((object)pool != null)
							{
								object obj = default(object);
								GameObject pizzaCircleObj2 = pool.GetObject((Vector3)(&value), (Quaternion)(&obj));
								_PizzaCircleObj = pizzaCircleObj2;
								if ((object)_PizzaCircleObj != null)
								{
									PizzaCircle component = _PizzaCircleObj.GetComponent<PizzaCircle>();
									PizzaCircle = component;
									pizzaCircle = PizzaCircle;
									if ((object)PizzaCircle != null)
									{
										goto IL_0238;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0309;
		IL_0309:
		throw new NullReferenceException();
		IL_0238:
		pizzaCircle.Init(16f);
		ArcadeSprite arcadeSprite = setAlpha(1f);
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		ArcadeSprite arcadeSprite3 = setFlipX(flipX: false);
		if (_selfCleanTimer != null)
		{
			_selfCleanTimer.Cancel();
		}
		Action onComplete = SelfClean;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer selfCleanTimer = Timers.Register(120.00001f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_selfCleanTimer = selfCleanTimer;
	}

	private void SelfClean()
	{
		//IL_010c: Expected O, but got I4
		//IL_0146->IL017e: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Vector3 vector = ret;
					Rect containmentScreenRect = stage._containmentScreenRect;
					if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect))
					{
						object obj2 = default(object);
						object obj = obj2 + (object)stage._containmentScreenRect;
						object obj3 = default(object);
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
						{
							object obj4 = obj2 + obj2;
							bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
							object obj5 = obj4 - obj3;
							bool flag3 = obj5 == null;
							bool flag4 = !flag2;
							bool flag5 = !flag3;
							object obj6 = flag5 & flag4;
							if (obj6 != null)
							{
								return;
							}
						}
					}
					if ((object)_coherenceSync != null)
					{
						if (_coherenceSync.HasStateAuthority)
						{
							Despawn();
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_selfCleanTimer != null)
		{
			_selfCleanTimer.Cancel();
		}
		base.Despawn();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0135: Expected O, but got Ref
		base.OnUpdate();
		if (_hasFired)
		{
			return;
		}
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if ((object)core._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		TilingTileset tilingTileset = stage2._tilingTileset;
		if ((object)stage2._tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
		{
			GameManager core3 = GM.Core;
			Stage stage3 = core3._stage;
			BackgroundManager fancyBg = stage3._fancyBg;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if ((object)stage3._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0 && enumerator.MoveNext())
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
	}

	protected void OnTriggeredByPlayer()
	{
		//IL_0056: Expected O, but got I4
		//IL_00f6: Expected I, but got O
		//IL_0168: Expected O, but got I4
		//IL_0183: Expected I, but got O
		if (!_hasFired)
		{
			if (_selfCleanTimer != null)
			{
				_selfCleanTimer.Cancel();
			}
			_hasFired = true;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 2f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 150f, 2, time);
			ArcadeSprite arcadeSprite = setFlipX(flipX: true);
			if (_tween1 != null)
			{
				_tween1.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 1000f;
			tweenConfig.delay = 1000f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Props.PropLeverTrain>)+330]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween1 = tween;
		}
	}

	public PropLeverTrain()
	{
		//IL_0036: Expected I, but got O
		_hp = 1f;
		base._maxHp = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
