using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyGashadokuro : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass40_0
	{
		public EnemyGashadokuro _003C_003E4__this;

		public Bounds camBounds;

		internal void _003CDrownerWarning_003Eb__0()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyGashadokuro+<>c__DisplayClass40_0)+24]");
			float num = 0f * 2f;
			float sizeX = num * 0.5f;
			_003C_003E4__this.SingleWarning(sizeX);
		}

		internal void _003CDrownerWarning_003Eb__1()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyGashadokuro+<>c__DisplayClass40_0)+24]");
			float num = 0f * 2f;
			float sizeX = num * 0.75f;
			_003C_003E4__this.SingleWarning(sizeX);
		}

		internal void _003CDrownerWarning_003Eb__2()
		{
			//IL_014e: Expected I4, but got O
			//IL_008c: Expected O, but got I4
			//IL_0095: Expected O, but got I4
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Expected O, but got Unknown
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num = renderer.width * 100f;
			float num2 = num * (1f / 32f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			float num3 = num2 * 32f;
			EnemyType enemyType = (EnemyType)ArcadePhysics.s_scene;
			EnemyGashadokuro enemyGashadokuro = _003C_003E4__this;
			object obj = 0;
			object obj2 = 0;
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			while ((nint)obj2 < enemyGashadokuro._spiritsToSummon)
			{
				float num4 = (float)obj * num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
				float num5 = num4 / num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				GameManager core = GM.Core;
				GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MS_EVILSPIRIT, spawnPos, asRemote: false, forceSpawn);
				enemyGashadokuro = _003C_003E4__this;
				obj++;
				enemyType = EnemyType.MS_EVILSPIRIT;
				obj2 = obj;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public SpriteRenderer redWarning;

		public GameObject redWarningObject;

		public TweenCallback _003C_003E9__1;

		internal void _003CRedWarning_003Eb__0()
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(redWarning, 0f, 0.1f);
			TweenCallback tweenCallback = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				tweenCallback = (_003C_003E9__1 = delegate
				{
					UnityEngine.Object.Destroy(redWarningObject, 0f);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CRedWarning_003Eb__1()
		{
			UnityEngine.Object.Destroy(redWarningObject, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public Transform singleWarningTransform;

		public GameObject singleWarningObject;

		public TweenCallback _003C_003E9__1;

		internal unsafe void _003CSingleWarning_003Eb__0()
		{
			//IL_0098: Expected O, but got Ref
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(singleWarningTransform, (Vector3)(&obj), 0.2f);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 0.2f);
			TweenCallback tweenCallback = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				tweenCallback = (_003C_003E9__1 = delegate
				{
					UnityEngine.Object.Destroy(singleWarningObject, 0f);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CSingleWarning_003Eb__1()
		{
			UnityEngine.Object.Destroy(singleWarningObject, 0f);
		}
	}

	private SpriteRenderer _FrontArm;

	private SpriteAnimation _FrontArmAnim;

	private SpriteRenderer _BackArm;

	private SpriteAnimation _BackArmAnim;

	private SpriteRenderer _Head;

	private SpriteAnimation _HeadAnim;

	private Vector2 _frontOffset;

	private Vector2 _backOffset;

	private Vector2 _headOffset;

	private Vector2 _invFrontOffset;

	private Vector2 _invBackOffset;

	private Vector2 _invHeadOffset;

	private List<Sprite> _frameNamesArms;

	private List<Sprite> _frameNamesArmsDie;

	private List<Sprite> _frameNamesHead;

	private List<Sprite> _frameNamesHeadDie;

	private MultiTargetTween _armsSpinTween;

	private MultiTargetTween _speedTween;

	public float _SpeedMul;

	private Timer _spinTimer;

	private MultiTargetTween _armsSpinTween2;

	private MultiTargetTween _speedTween2;

	private Timer _summonTimer;

	private int _spiritsToSummon;

	private float _spinnnDelay;

	private float _summonTime;

	private float _summonDelay;

	private bool _spritesInitialised;

	private bool _hasLostTreasure;

	protected override void Awake()
	{
		base.Awake();
		Vector2 pivot = default(Vector2);
		string textureName = default(string);
		int zeroPad = default(int);
		bool respectOriginalXPivot = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Gash_arm_i", 1, 5, pivot, textureName, zeroPad, respectOriginalXPivot);
		_frameNamesArms = animationFrames;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("Gash_arm_", 0, 29, pivot, textureName, zeroPad, respectOriginalXPivot);
		_frameNamesArmsDie = animationFrames2;
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("Gash_head_i", 1, 5, pivot, textureName, zeroPad, respectOriginalXPivot);
		_frameNamesHead = animationFrames3;
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("Gash_head_", 0, 29, pivot, textureName, zeroPad, respectOriginalXPivot);
		_frameNamesHeadDie = animationFrames4;
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0069: Expected O, but got I
		//IL_007e: Expected O, but got I
		//IL_0095: Expected F4, but got I
		//IL_00ed: Expected O, but got Ref
		//IL_0113: Expected O, but got Ref
		base.InitEnemy(enemyType, asRemote);
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _dataManager.GetConvertedEnemyData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).get_Item((System.Int32Enum)_enemyType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v10 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v10 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v11+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v12+18]");
			_defaultSpeed = 0f;
			InitSprites();
			_summonTime = 0f;
			_SpeedMul = 1f;
			base._003CIsTeleportOnCull_003Ek__BackingField = true;
			_hasLostTreasure = false;
			Transform transform = _FrontArm.transform;
			object obj4 = default(object);
			transform.localEulerAngles = (Vector3)(&obj4);
			Transform transform2 = _BackArm.transform;
			transform2.localEulerAngles = (Vector3)(&obj4);
			_FrontArm.enabled = true;
			_BackArm.enabled = true;
			_Head.enabled = true;
			_FrontArmAnim.SetAnimation("idle");
			_BackArmAnim.SetAnimation("idle");
			_HeadAnim.SetAnimation("idle");
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_FrontArm, 1f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_BackArm, 1f);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_Head, 1f);
			if (_spinTimer != null)
			{
				_spinTimer.Cancel();
			}
			Action onComplete = AndSpinnn;
			float duration = _spinnnDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer spinTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_spinTimer = spinTimer;
			OnUpdate();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void InitSprites()
	{
		if (!_spritesInitialised)
		{
			_spritesInitialised = true;
			Vector2 newPivot = default(Vector2);
			Sprite sprite = SpriteManager.GetSprite("Gash_arm_i01", newPivot, "moonspellEnemies");
			_FrontArm.sprite = sprite;
			Sprite sprite2 = SpriteManager.GetSprite("Gash_arm_i01", newPivot, "moonspellEnemies");
			_BackArm.sprite = sprite2;
			Sprite sprite3 = SpriteManager.GetSprite("Gash_head_i01", newPivot, "moonspellEnemies");
			_Head.sprite = sprite3;
			bool shouldLoop = default(bool);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_FrontArmAnim.AddAnimation("idle", _frameNamesArms, 24, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			_BackArmAnim.AddAnimation("idle", _frameNamesArms, 24, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			_FrontArmAnim.AddAnimation("die", _frameNamesArmsDie, 30, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			_BackArmAnim.AddAnimation("die", _frameNamesArmsDie, 30, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			_HeadAnim.AddAnimation("idle", _frameNamesHead, 24, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			_HeadAnim.AddAnimation("die", _frameNamesHeadDie, 30, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
		}
	}

	private void PlayDeathAnimations()
	{
		SpriteRenderer frontArm = _FrontArm;
		if ((object)_FrontArm != null && ((UnityEngine.Object)frontArm).m_CachedPtr != (IntPtr)0)
		{
			SpriteAnimation frontArmAnim = _FrontArmAnim;
			if ((object)_FrontArmAnim != null && ((UnityEngine.Object)frontArmAnim).m_CachedPtr != (IntPtr)0)
			{
				_FrontArmAnim.SetAnimation("die");
			}
		}
		SpriteRenderer backArm = _BackArm;
		if ((object)_BackArm != null && ((UnityEngine.Object)backArm).m_CachedPtr != (IntPtr)0)
		{
			SpriteAnimation backArmAnim = _BackArmAnim;
			if ((object)_BackArmAnim != null && ((UnityEngine.Object)backArmAnim).m_CachedPtr != (IntPtr)0)
			{
				_BackArmAnim.SetAnimation("die");
			}
		}
		SpriteRenderer head = _Head;
		if ((object)_Head != null && ((UnityEngine.Object)head).m_CachedPtr != (IntPtr)0)
		{
			SpriteAnimation headAnim = _HeadAnim;
			if ((object)_HeadAnim != null && ((UnityEngine.Object)headAnim).m_CachedPtr != (IntPtr)0)
			{
				_HeadAnim.SetAnimation("die");
			}
		}
	}

	private unsafe void AndSpinnn()
	{
		//IL_003b: Expected O, but got Ref
		//IL_0096: Expected I, but got O
		//IL_0108: Expected O, but got I4
		//IL_017e: Expected O, but got Ref
		//IL_01d9: Expected I, but got O
		//IL_024b: Expected O, but got I4
		//IL_02c5: Expected I, but got O
		//IL_03e0: Expected I, but got O
		if (_armsSpinTween != null)
		{
			_armsSpinTween.Kill();
		}
		Transform transform = _BackArm.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform2 = _BackArm.transform;
		if ((object)transform2 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.repeat = 19;
		tweenConfig.angle = (float?)(object)1;
		MultiTargetTween armsSpinTween = Tweens.Add(tweenConfig);
		_armsSpinTween = armsSpinTween;
		if (_armsSpinTween2 != null)
		{
			_armsSpinTween2.Kill();
		}
		Transform transform3 = _FrontArm.transform;
		transform3.localEulerAngles = (Vector3)(&obj);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		Transform transform4 = _FrontArm.transform;
		if ((object)transform4 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 500f;
		tweenConfig2.repeat = 19;
		tweenConfig2.angle = (float?)(object)1;
		MultiTargetTween armsSpinTween2 = Tweens.Add(tweenConfig2);
		_armsSpinTween2 = armsSpinTween2;
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		nint num3 = (nint)array3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj4 = default(object);
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_SpeedMul", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig3.custom = dictionary;
			tweenConfig3.duration = 2000f;
			MultiTargetTween speedTween = Tweens.Add(tweenConfig3);
			_speedTween = speedTween;
			if (_speedTween2 != null)
			{
				_speedTween2.Kill();
			}
			TweenConfig tweenConfig4 = new TweenConfig();
			object[] array4 = new object[1];
			nint num4 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig4.targets = array4;
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value2 = default(object);
				bool flag2 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_SpeedMul", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig4.custom = dictionary2;
				tweenConfig4.duration = 2000f;
				tweenConfig4.delay = 8000f;
				MultiTargetTween speedTween2 = Tweens.Add(tweenConfig4);
				_speedTween2 = speedTween2;
				return;
			}
			ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
			throw ex3;
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
	}

	private void AndSummon()
	{
		DrownerWarning();
	}

	protected override void Die()
	{
		base.Die();
		PlayDeathAnimations();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 14 Invalid \"Jump target not found in method: 0x187718170\"");
	}

	private void MakeTreasureChest()
	{
		//IL_006e: Expected O, but got I
		//IL_00e9: Expected O, but got I
		//IL_056a: Expected O, but got I
		//IL_0154: Expected O, but got I
		//IL_05b2: Expected O, but got I
		//IL_01bf: Expected O, but got I
		//IL_0235: Expected O, but got I
		//IL_02af: Expected O, but got I
		//IL_0294: Expected O, but got I4
		//IL_0617: Expected O, but got I
		//IL_0319: Expected O, but got I
		//IL_02fe: Expected O, but got I4
		//IL_065f: Expected O, but got I
		//IL_0383: Expected O, but got I
		//IL_0368: Expected O, but got I4
		//IL_06a7: Expected O, but got I
		//IL_03ed: Expected O, but got I
		//IL_03d2: Expected O, but got I4
		//IL_06ef: Expected O, but got I
		//IL_0457: Expected O, but got I
		//IL_043c: Expected O, but got I4
		//IL_0775->IL051e: Incompatible stack heights: 1 vs 0
		//IL_051e->IL077a: Incompatible stack heights: 1 vs 0
		if (_hasLostTreasure)
		{
			return;
		}
		_hasLostTreasure = true;
		Treasure treasure = new Treasure();
		List<float> list = new List<float>();
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdx_v10+18]");
				if (num >= 0)
				{
					list.AddWithResize(0.1f);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj2 = (nint)0 + (nint)1;
					_ = 1036831949;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rdx_v11+18]");
					if (num2 >= 0)
					{
						list.AddWithResize(1f);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
						object obj4 = (nint)0 + (nint)1;
						_ = 1065353216;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rdx_v12+18]");
						if (num3 >= 0)
						{
							list.AddWithResize(100f);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
							object obj6 = (nint)0 + (nint)1;
							_ = 1120403456;
						}
						if (treasure != null)
						{
							treasure._003Cchances_003Ek__BackingField = list;
							List<PrizeType?> list2 = new List<PrizeType?>();
							if (list2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
									nint num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v15+18]");
									if (num4 >= 0)
									{
										list2.AddWithResize((PrizeType?)(object)1);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
										object obj8 = (nint)0 + (nint)1;
										_ = 1;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
									object obj9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
										nint num5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rdx_v17+18]");
										if (num5 >= 0)
										{
											list2.AddWithResize((PrizeType?)(object)1);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
											object obj10 = (nint)0 + (nint)1;
											_ = 1;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
										object obj11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rdx_v19+18]");
											if (num6 >= 0)
											{
												list2.AddWithResize((PrizeType?)(object)1);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
												object obj12 = (nint)0 + (nint)1;
												_ = 1;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
											object obj13 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
												nint num7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rdx_v21+18]");
												if (num7 >= 0)
												{
													list2.AddWithResize((PrizeType?)(object)1);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
													object obj14 = (nint)0 + (nint)1;
													_ = 1;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
												_ = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
												object obj15 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
													nint num8 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdx_v23+18]");
													if (num8 >= 0)
													{
														list2.AddWithResize((PrizeType?)(object)1);
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
														object obj16 = (nint)0 + (nint)1;
														_ = 1;
													}
													treasure._003CprizeTypes_003Ek__BackingField = list2;
													GameManager core = GM.Core;
													if ((object)GM.Core != null && (object)core._stage != null)
													{
														int num9 = core._stage.SetTreasureLevelFromChance(treasure);
														List<float> cachedTransform = (List<float>)(object)_cachedTransform;
														if ((object)_cachedTransform != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rbx_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
															bool flag = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rbx_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
															Transform.get_position_Injected((IntPtr)0, out Vector3 _);
															if ((object)GM.Core != null)
															{
																Vector2 pos = default(Vector2);
																TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
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
		throw new NullReferenceException();
	}

	public override void Disappear()
	{
		base.Disappear();
		PlayDeathAnimations();
	}

	public unsafe override void Despawn()
	{
		//IL_0136: Expected O, but got Ref
		//IL_015c: Expected O, but got Ref
		if (_spinTimer != null)
		{
			_spinTimer.Cancel();
		}
		if (_armsSpinTween != null)
		{
			_armsSpinTween.Kill();
		}
		if (_armsSpinTween2 != null)
		{
			_armsSpinTween2.Kill();
		}
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		if (_speedTween2 != null)
		{
			_speedTween2.Kill();
		}
		_FrontArm.enabled = false;
		_BackArm.enabled = false;
		_Head.enabled = false;
		Transform transform = _FrontArm.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		Transform transform2 = _BackArm.transform;
		transform2.localEulerAngles = (Vector3)(&obj);
		base.Despawn();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_02f7: Invalid comparison between F4 and I
		//IL_0015: Expected F4, but got I
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected O, but got Unknown
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Expected O, but got Unknown
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Expected O, but got Unknown
		//IL_058b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected O, but got Unknown
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected O, but got Unknown
		//IL_037b->IL02cd: Incompatible stack heights: 1 vs 0
		//IL_0099->IL02cd: Incompatible stack heights: 2 vs 0
		//IL_03e9->IL02cd: Incompatible stack heights: 2 vs 0
		//IL_00f2->IL02cd: Incompatible stack heights: 2 vs 0
		//IL_0498->IL02cd: Incompatible stack heights: 5 vs 0
		//IL_0183->IL02cd: Incompatible stack heights: 5 vs 0
		//IL_0550->IL02cd: Incompatible stack heights: 8 vs 0
		//IL_0214->IL02cd: Incompatible stack heights: 8 vs 0
		float num = _SpeedMul * _defaultSpeed;
		float num2 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10FB4]");
		if (num2 > 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10FB4]");
			num = 0f;
		}
		base._003CSpeed_003Ek__BackingField = num;
		base.OnUpdate();
		base.angle = 0f;
		SpriteRenderer enemyRenderer = _EnemyRenderer;
		if ((object)_EnemyRenderer != null)
		{
			bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
			bool flag2 = SpriteRenderer.get_flipX_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr);
			float xScale = ((!flag2) ? 1f : (-1f));
			SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				_ = 0;
				_ = 0;
				bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 64;
				Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_FrontArm, xScale, 1f);
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_BackArm, xScale, 1f);
				if ((object)_Head != null)
				{
					_Head.flipX = flag2;
					if (flag2)
					{
					}
					if ((object)_FrontArm != null)
					{
						Transform transform = _FrontArm.transform;
						if ((object)transform != null)
						{
							_ = 0;
							_ = 0;
							bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							object obj3 = obj2 - 64;
							Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-38]");
							_ = 0;
							bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							object obj4 = obj2 - 48;
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj4);
							int num3 = base.depth;
							bool flag6 = (object)_FrontArm == null;
							int sortingOrder = num3 + 2;
							_FrontArm.sortingOrder = sortingOrder;
							if (flag2)
							{
							}
							if ((object)_BackArm != null)
							{
								Transform transform2 = _BackArm.transform;
								if ((object)transform2 != null)
								{
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v78 (UnityEngine.Transform)+10]");
									bool flag7 = (nint)0 == 0;
									object obj5 = obj2 - 64;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v78 (UnityEngine.Transform)+10]");
									Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj5);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-38]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v78 (UnityEngine.Transform)+10]");
									bool flag8 = (nint)0 == 0;
									object obj6 = obj2 - 48;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v78 (UnityEngine.Transform)+10]");
									Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj6);
									int num4 = base.depth;
									bool flag9 = (object)_BackArm == null;
									int sortingOrder2 = num4 - 1;
									_BackArm.sortingOrder = sortingOrder2;
									if (flag2)
									{
									}
									if ((object)_Head != null)
									{
										Transform transform3 = _Head.transform;
										if ((object)transform3 != null)
										{
											_ = 0;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v91 (UnityEngine.Transform)+10]");
											bool flag10 = (nint)0 == 0;
											object obj7 = obj2 - 64;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v91 (UnityEngine.Transform)+10]");
											Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj7);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-38]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v91 (UnityEngine.Transform)+10]");
											bool flag11 = (nint)0 == 0;
											object obj8 = obj2 - 48;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v91 (UnityEngine.Transform)+10]");
											Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj8);
											int num5 = base.depth;
											bool flag12 = (object)_Head == null;
											int sortingOrder3 = num5 + 1;
											_Head.sortingOrder = sortingOrder3;
											float deltaTime = PauseSystem.DeltaTime;
											float num6 = deltaTime * 1000f;
											if (!((_summonTime = num6 + _summonTime) < _summonDelay))
											{
												DrownerWarning();
												_summonTime = 0f;
											}
											float num7 = _hp / _maxHp;
											float num8 = num7 * 25000f;
											float summonDelay = num8 + 5000f;
											_summonDelay = summonDelay;
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
		throw new NullReferenceException();
	}

	private void DrownerWarning()
	{
		_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass40_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		RedWarning();
		Camera main = Camera.main;
		CS_0024_003C_003E8__locals6.camBounds = (Bounds)CameraExtensions.OrthographicBounds(main).m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v8 (UnityEngine.Bounds)+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (VampireSurvivors.Objects.Characters.Enemies.EnemyGashadokuro+<>c__DisplayClass40_0)+24]");
		float num = 0f * 2f;
		float sizeX = num * 0.25f;
		SingleWarning(sizeX);
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyGashadokuro+<>c__DisplayClass40_0)+24]");
			float num2 = 0f * 2f;
			float sizeX2 = num2 * 0.5f;
			CS_0024_003C_003E8__locals6._003C_003E4__this.SingleWarning(sizeX2);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyGashadokuro+<>c__DisplayClass40_0)+24]");
			float num2 = 0f * 2f;
			float sizeX2 = num2 * 0.75f;
			CS_0024_003C_003E8__locals6._003C_003E4__this.SingleWarning(sizeX2);
		};
		Timer timer2 = Timers.Register(0.4f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete3 = delegate
		{
			//IL_014e: Expected I4, but got O
			//IL_008c: Expected O, but got I4
			//IL_0095: Expected O, but got I4
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Expected O, but got Unknown
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num2 = renderer.width * 100f;
			float num3 = num2 * (1f / 32f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			float num4 = num3 * 32f;
			EnemyType enemyType = (EnemyType)ArcadePhysics.s_scene;
			EnemyGashadokuro enemyGashadokuro = CS_0024_003C_003E8__locals6._003C_003E4__this;
			object obj = 0;
			object obj2 = 0;
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			while ((nint)obj2 < enemyGashadokuro._spiritsToSummon)
			{
				float num5 = (float)obj * num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
				float num6 = num5 / num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				GameManager core = GM.Core;
				GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MS_EVILSPIRIT, spawnPos, asRemote: false, forceSpawn);
				enemyGashadokuro = CS_0024_003C_003E8__locals6._003C_003E4__this;
				obj++;
				enemyType = EnemyType.MS_EVILSPIRIT;
				obj2 = obj;
			}
		};
		Timer timer3 = Timers.Register(1f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void RedWarning()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0489: Expected O, but got Ref
		//IL_04df: Expected O, but got F4
		//IL_06d2: Expected O, but got I4
		//IL_04ed: Expected O, but got I4
		//IL_0530: Expected O, but got Ref
		//IL_058f: Expected O, but got Ref
		//IL_05b7: Expected O, but got Ref
		//IL_05df: Expected O, but got Ref
		//IL_0607: Expected O, but got Ref
		//IL_0641: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass41_0();
		TweenerCore<Color, Color, ColorOptions> tweenerCore;
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.CrabRedWarning);
			if ((object)pool != null)
			{
				GameObject redWarningObject = pool.GetObject();
				if (CS_0024_003C_003E8__locals26 != null)
				{
					CS_0024_003C_003E8__locals26.redWarningObject = redWarningObject;
					if ((object)CS_0024_003C_003E8__locals26.redWarningObject != null)
					{
						Transform transform = CS_0024_003C_003E8__locals26.redWarningObject.transform;
						if ((object)CS_0024_003C_003E8__locals26.redWarningObject != null)
						{
							SpriteRenderer componentInChildren = CS_0024_003C_003E8__locals26.redWarningObject.GetComponentInChildren<SpriteRenderer>(includeInactive: false);
							CS_0024_003C_003E8__locals26.redWarning = componentInChildren;
							SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(CS_0024_003C_003E8__locals26.redWarning, 0.25f);
							object redWarning = CS_0024_003C_003E8__locals26.redWarning;
							if ((object)CS_0024_003C_003E8__locals26.redWarning != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rbx_v26 (System.Object)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rbx_v26 (System.Object)+10]");
									Renderer.set_sortingOrder_Injected((IntPtr)0, 9000);
									Vector2 newPivot = default(Vector2);
									Sprite sprite = SpriteManager.GetSprite("WhiteLine", newPivot, "vfx");
									if ((object)CS_0024_003C_003E8__locals26.redWarning != null)
									{
										CS_0024_003C_003E8__locals26.redWarning.sprite = sprite;
										Camera main = Camera.main;
										Bounds bounds = CameraExtensions.OrthographicBounds(main);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v81 (UnityEngine.Bounds)+10]");
										_ = 0;
										_ = 0;
										bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
										Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
										Camera main2 = Camera.main;
										Transform parent = main2.transform;
										transform.SetParent(parent, worldPositionStays: true);
										Camera main3 = Camera.main;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v89 (UnityEngine.Camera)+10]");
										bool flag2 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v89 (UnityEngine.Camera)+10]");
										object obj4 = Camera.get_orthographicSize_Injected((IntPtr)0);
										object obj5 = Screen.height;
										object obj6 = Screen.width;
										Transform transform2 = CS_0024_003C_003E8__locals26.redWarning.transform;
										Sprite sprite2 = CS_0024_003C_003E8__locals26.redWarning.sprite;
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ rax_v101 (UnityEngine.Sprite)+10]");
										bool flag3 = (nint)0 == 0;
										object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ rax_v101 (UnityEngine.Sprite)+10]");
										Sprite.get_bounds_Injected((IntPtr)0, out *(Bounds*)obj7);
										bool flag4 = (object)transform2 == null;
										_ = 1f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v100 (UnityEngine.Transform)+10]");
										bool flag5 = (nint)0 == 0;
										object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v100 (UnityEngine.Transform)+10]");
										Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj8);
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ rax_v101 (UnityEngine.Sprite)+10]");
										bool flag6 = (nint)0 == 0;
										object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ rax_v101 (UnityEngine.Sprite)+10]");
										Sprite.get_bounds_Injected((IntPtr)0, out *(Bounds*)obj9);
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v100 (UnityEngine.Transform)+10]");
										bool flag7 = (nint)0 == 0;
										object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v100 (UnityEngine.Transform)+10]");
										Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj10);
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v100 (UnityEngine.Transform)+10]");
										bool flag8 = (nint)0 == 0;
										object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v100 (UnityEngine.Transform)+10]");
										Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj11);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v100 (UnityEngine.Transform)+10]");
										bool flag9 = (nint)0 == 0;
										object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v100 (UnityEngine.Transform)+10]");
										Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj12);
										tweenerCore = DOTweenModuleSprite.DOFade(CS_0024_003C_003E8__locals26.redWarning, 0.5f, 0.2f);
										TweenCallback tweenCallback2;
										if (tweenerCore != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2134 @ rax_v130 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2134 @ rax_v130 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 6;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2134 @ rax_v130 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2134 @ rax_v130 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
														float num = 0f * 6f;
													}
													TweenCallback tweenCallback = delegate
													{
														TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(CS_0024_003C_003E8__locals26.redWarning, 0f, 0.1f);
														TweenCallback tweenCallback4 = CS_0024_003C_003E8__locals26._003C_003E9__1;
														if (CS_0024_003C_003E8__locals26._003C_003E9__1 == null)
														{
															tweenCallback4 = (CS_0024_003C_003E8__locals26._003C_003E9__1 = delegate
															{
																UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals26.redWarningObject, 0f);
															});
														}
														if (tweenerCore2 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
															if ((nint)0 == 0)
															{
															}
														}
													};
													tweenCallback2 = tweenCallback;
													goto IL_0368;
												}
											}
										}
										TweenCallback tweenCallback3 = delegate
										{
											TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(CS_0024_003C_003E8__locals26.redWarning, 0f, 0.1f);
											TweenCallback tweenCallback4 = CS_0024_003C_003E8__locals26._003C_003E9__1;
											if (CS_0024_003C_003E8__locals26._003C_003E9__1 == null)
											{
												tweenCallback4 = (CS_0024_003C_003E8__locals26._003C_003E9__1 = delegate
												{
													UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals26.redWarningObject, 0f);
												});
											}
											if (tweenerCore2 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
												if ((nint)0 == 0)
												{
												}
											}
										};
										bool flag10 = tweenerCore == null;
										tweenCallback2 = tweenCallback3;
										if (!flag10)
										{
											goto IL_0368;
										}
										goto IL_0397;
									}
								}
								else
								{
									UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(CS_0024_003C_003E8__locals26.redWarning);
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0368:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2134 @ rax_v130 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0397;
		IL_0397:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag11 = tweenerCore == null;
	}

	private unsafe void SingleWarning(float sizeX)
	{
		//IL_03bf: Expected O, but got Ref
		//IL_0284: Expected O, but got I4
		//IL_0402: Expected O, but got F4
		//IL_03f4->IL02b8: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass42_0();
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.SingleWarning);
			if ((object)pool != null)
			{
				GameObject singleWarningObject = pool.GetObject();
				if (CS_0024_003C_003E8__locals14 != null)
				{
					CS_0024_003C_003E8__locals14.singleWarningObject = singleWarningObject;
					if ((object)CS_0024_003C_003E8__locals14.singleWarningObject != null)
					{
						Transform transform = CS_0024_003C_003E8__locals14.singleWarningObject.transform;
						if ((object)CS_0024_003C_003E8__locals14.singleWarningObject != null)
						{
							Component componentInChildren = CS_0024_003C_003E8__locals14.singleWarningObject.GetComponentInChildren<SpriteRenderer>(includeInactive: false);
							if ((object)componentInChildren != null)
							{
								Transform singleWarningTransform = componentInChildren.transform;
								CS_0024_003C_003E8__locals14.singleWarningTransform = singleWarningTransform;
								TweenCallback singleWarningTransform2 = (TweenCallback)(object)CS_0024_003C_003E8__locals14.singleWarningTransform;
								bool flag = ((Delegate)singleWarningTransform2).method_ptr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_localScale_Injected(((Delegate)singleWarningTransform2).method_ptr, ref value);
								bool flag2 = ((UnityEngine.Object)componentInChildren).m_CachedPtr == (IntPtr)0;
								Renderer.set_sortingOrder_Injected(((UnityEngine.Object)componentInChildren).m_CachedPtr, 9000);
								Vector2 newPivot = default(Vector2);
								Sprite sprite = SpriteManager.GetSprite("ExclamationMark", newPivot, "UI");
								((SpriteRenderer)componentInChildren).sprite = sprite;
								Camera main = Camera.main;
								Bounds bounds = CameraExtensions.OrthographicBounds(main);
								bool flag3 = (object)transform == null;
								bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector2 value2 = default(Vector2);
								Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value2));
								Camera main2 = Camera.main;
								bool flag5 = (object)main2 == null;
								Transform parent = main2.transform;
								transform.SetParent(parent, worldPositionStays: true);
								object obj = default(object);
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals14.singleWarningTransform, (Vector3)(&obj), 0.2f);
								TweenCallback tweenCallback = delegate
								{
									//IL_0098: Expected O, but got Ref
									object obj3 = default(object);
									TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals14.singleWarningTransform, (Vector3)(&obj3), 0.2f);
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, 0.2f);
									TweenCallback tweenCallback2 = CS_0024_003C_003E8__locals14._003C_003E9__1;
									if (CS_0024_003C_003E8__locals14._003C_003E9__1 == null)
									{
										tweenCallback2 = (CS_0024_003C_003E8__locals14._003C_003E9__1 = delegate
										{
											UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals14.singleWarningObject, 0f);
										});
									}
									if (tweenerCore2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
										if ((nint)0 == 0)
										{
										}
									}
								};
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1264 @ rax_v66 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 == 0)
									{
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore != null)
								{
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
									soundConfig.Volume = (float?)(object)1;
									soundConfig.Rate = 1f;
									object obj2 = UnityEngine.Random.value;
									float detune = (float)Vector3.oneVector * 500f;
									soundConfig.Rate = 1f;
									soundConfig.Detune = detune;
									float time = default(float);
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, time);
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

	public EnemyGashadokuro()
	{
		//IL_0017: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_0045: Expected O, but got I8
		//IL_0056: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		_frontOffset = (Vector2)1045891645;
		_ = 3184315596L;
		_backOffset = (Vector2)1025758986;
		_ = 3164854026L;
		_headOffset = (Vector2)3196395192L;
		_ = 1045891645;
		_invFrontOffset = (Vector2)1054951342;
		_ = 3184315596L;
		_invBackOffset = (Vector2)1058810102;
		_ = 3164854026L;
		_invHeadOffset = (Vector2)1063339950;
		_ = 1045891645;
		_spiritsToSummon = 60;
		_spinnnDelay = 20000f;
		_summonDelay = 3000f;
		base._002Ector();
	}
}
