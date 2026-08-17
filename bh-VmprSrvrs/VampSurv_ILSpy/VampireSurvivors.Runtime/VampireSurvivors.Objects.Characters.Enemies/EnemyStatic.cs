using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyStatic : EnemyController
{
	private MultiTargetTween _onEnterTween;

	private float _randomDepthOffset;

	private int _prevDepth;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_025e: Expected O, but got F4
		//IL_0283: Expected O, but got I4
		//IL_029f: Expected O, but got F4
		//IL_0073: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_0318: Expected O, but got I4
		//IL_032e: Expected O, but got I4
		//IL_0236: Expected I4, but got I8
		//IL_0167: Expected I, but got O
		//IL_01c7: Expected O, but got I4
		//IL_018a->IL018a: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		base._003CIsStatic_003Ek__BackingField = true;
		object obj = UnityEngine.Random.value;
		float num = default(float);
		_randomDepthOffset = num;
		base._003CSpeed_003Ek__BackingField = 0f;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		BaseBody baseBody = body;
		baseBody._immovable = false;
		object obj2 = UnityEngine.Random.value;
		bool flag = num < 0.5f;
		bool flag2 = !flag;
		base.SetFlipX(flag2);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		uint num3;
		if (!config._003CSelectedInverse_003Ek__BackingField)
		{
			ArcadeSprite arcadeSprite2 = setFlipY(flipY: false);
			ArcadeSprite arcadeSprite3 = setOrigin(0.5f, (float?)(object)1);
			float num2 = 0.5f;
			object obj3 = 0;
			num3 = 16777215u;
		}
		else
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			if (!config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
				ArcadeSprite arcadeSprite4 = setFlipY(flipY: false);
			}
			else
			{
				ArcadeSprite arcadeSprite5 = setFlipY(flipY: true);
			}
			ArcadeSprite arcadeSprite6 = setOrigin(0.5f, (float?)(object)1);
			float num2 = 0.5f;
			object obj3 = 0;
			num3 = 16746751u;
		}
		_saveTint = num3;
		ArcadeSprite arcadeSprite7 = setTint(num3);
		if (_onEnterTween != null)
		{
			_onEnterTween.Restart();
		}
		else
		{
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_cachedTransform != null)
			{
				nint num4 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				bool flag3 = obj4 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 300f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				BaseBody baseBody2 = body;
				baseBody2._immovable = true;
				PhysicsManager sInstance = PhysicsManager._sInstance;
				sInstance._enemyGroup.remove(this);
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			MultiTargetTween onEnterTween = multiTargetTween.SetAutoKill(autoKill: false);
			_onEnterTween = onEnterTween;
		}
		_prevDepth = -1;
	}

	protected override void OnUpdate()
	{
		if (!base._003CIsDead_003Ek__BackingField)
		{
			UpdateDepth();
			if (!base._003CIsTimeStopped_003Ek__BackingField)
			{
				base.ProcessWiggle();
			}
		}
	}

	protected override void UpdateDepth()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		if (num != _prevDepth)
		{
			_prevDepth = num;
			_EnemyRenderer.sortingOrder = num;
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_00e9: Expected I4, but got O
		//IL_018a: Expected I4, but got O
		//IL_0258: Expected I, but got O
		//IL_0260: Expected I, but got O
		//IL_0270: Expected O, but got I
		//IL_02f0: Expected O, but got I4
		//IL_02ac: Expected O, but got I
		//IL_02e2: Expected O, but got I4
		//IL_038e->IL0319: Incompatible stack heights: 1 vs 0
		//IL_0149->IL0319: Incompatible stack heights: 1 vs 0
		//IL_0178->IL0319: Incompatible stack heights: 1 vs 0
		//IL_03b5->IL033d: Incompatible stack heights: 1 vs 0
		//IL_01be->IL033d: Incompatible stack heights: 1 vs 0
		//IL_01e7->IL0319: Incompatible stack heights: 1 vs 0
		//IL_0216->IL0319: Incompatible stack heights: 1 vs 0
		//IL_0245->IL033d: Incompatible stack heights: 1 vs 0
		//IL_03f4->IL033d: Incompatible stack heights: 1 vs 0
		//IL_0319->IL033d: Incompatible stack heights: 1 vs 0
		object obj = default(object);
		if ((nint)obj != 41)
		{
			WeaponType damageType2 = default(WeaponType);
			bool hasKb2 = default(bool);
			base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
			return;
		}
		GameSessionData gameSessionData = _gameSessionData;
		float hp = value + _hp;
		_hp = hp;
		Stage stage2;
		object obj4;
		if (_gameSessionData != null)
		{
			CharacterController activeCharacter = gameSessionData._activeCharacter;
			if ((object)gameSessionData._activeCharacter != null && (object)_gameManager != null)
			{
				float xp = (float)activeCharacter._level * 0.005f;
				_gameManager.AddPlayerXp(xp);
				HitVfxType hitVfxType = (HitVfxType)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdi_v7 (VampireSurvivors.Data.HitVfxType)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdi_v7 (VampireSurvivors.Data.HitVfxType)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					if ((object)_gameManager != null)
					{
						Vector2 pos = default(Vector2);
						_gameManager.ShowRecoveryAt(pos, value);
						GameManager gameManager = _gameManager;
						if ((object)_gameManager != null)
						{
							Stage stage = gameManager._stage;
							if ((object)gameManager._stage != null)
							{
								HitVfxType hitVfxType2 = (HitVfxType)stage._fancyBg;
								if ((object)stage._fancyBg == null)
								{
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v8 (VampireSurvivors.Data.HitVfxType)+10]");
								if ((nint)0 == 0)
								{
									return;
								}
								GameManager gameManager2 = _gameManager;
								if ((object)_gameManager != null)
								{
									stage2 = gameManager2._stage;
									if ((object)gameManager2._stage != null)
									{
										BackgroundMolise fancyBg = (BackgroundMolise)stage2._fancyBg;
										if ((object)stage2._fancyBg == null)
										{
											return;
										}
										nint num = (nint)typeof(BackgroundMolise);
										nint num2 = (nint)fancyBg;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundMolise>)+130]");
										object obj2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundMolise>)+130]");
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundMolise>)+130]");
										if (num3 >= 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundMolise>)+C8]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rax_v32+FFFFFFF8+v595 @ rax_v27*8]");
											if (0 == (nint)typeof(BackgroundMolise))
											{
												obj4 = 1;
												goto IL_03ba;
											}
										}
										obj4 = 0;
										goto IL_03ba;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_03ba:
		bool flag2 = obj4 == null;
		BackgroundMolise backgroundMolise = null;
		if (!flag2)
		{
			backgroundMolise = (BackgroundMolise)stage2._fancyBg;
		}
		backgroundMolise?.RestoreHp(value);
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_onEnterTween != null)
		{
			_onEnterTween.Pause();
		}
	}

	protected override void Die()
	{
		base.Die();
		if (_onEnterTween != null)
		{
			_onEnterTween.Pause();
		}
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (_onEnterTween != null)
		{
			_onEnterTween.Kill();
		}
	}

	public EnemyStatic()
	{
		//IL_001b: Expected I4, but got I8
		_prevDepth = -1;
		base._002Ector();
	}

	private void _003CInitEnemy_003Eb__2_0()
	{
		BaseBody baseBody = body;
		baseBody._immovable = true;
		PhysicsManager sInstance = PhysicsManager._sInstance;
		sInstance._enemyGroup.remove(this);
	}
}
