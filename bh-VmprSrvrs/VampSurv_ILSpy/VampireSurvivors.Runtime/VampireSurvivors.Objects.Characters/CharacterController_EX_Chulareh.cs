using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters;

public class CharacterController_EX_Chulareh : CharacterController
{
	private enum DiceResult
	{
		NoEffect,
		UnluckyOne,
		Two,
		Three,
		Four,
		Five,
		LuckySix
	}

	private enum SpecialState
	{
		None,
		Lucky,
		Unlucky
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__57_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe void _003CActivateLuckyBonus_003Eb__57_1()
		{
			//IL_0029: Expected O, but got Ref
			GameManager core = GM.Core;
			Stage stage = core._stage;
			VampireSurvivors.Data.Stage.Event obj = new VampireSurvivors.Data.Stage.Event();
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			obj._003CeventType_003Ek__BackingField = text;
			bool flag = stage._stageEventManager.TriggerEvent(obj);
		}
	}

	private sealed class _003C_003Ec__DisplayClass49_0
	{
		public CharacterController_EX_Chulareh _003C_003E4__this;

		public float offsetY;

		internal void _003CDoDiceRollAnim_003Eb__0()
		{
			//IL_01a5->IL014f: Incompatible stack heights: 1 vs 0
			//IL_013e->IL014f: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				SoundManager.StopSound(SfxType.Sfx_dice_roll);
				CharacterController_EX_Chulareh characterController_EX_Chulareh = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					SpriteAnimation diceRollAnim = characterController_EX_Chulareh._diceRollAnim;
					if ((object)characterController_EX_Chulareh._diceRollAnim != null)
					{
						((BaseSpriteAnimation)diceRollAnim)._currentAnimation = null;
						CharacterController_EX_Chulareh characterController_EX_Chulareh2 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null && (object)characterController_EX_Chulareh2._DiceSprite != null)
						{
							Transform transform = characterController_EX_Chulareh2._DiceSprite.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
								if ((object)_003C_003E4__this != null)
								{
									_003C_003E4__this.SetDiceSpriteForRoll();
									if ((object)_003C_003E4__this != null)
									{
										_003C_003E4__this.DoDiceRollOutcome();
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
	}

	private SpriteRenderer _DiceSprite;

	private SpriteRenderer _ScreenFillRenderer;

	private Transform _CameraTarget;

	private List<DiceResult> _nonLuckyDiceResults;

	private const float LuckyMoveBonus = 0.77f;

	private const float LuckyLuckBonus = 7.77f;

	private const float UnluckyLuckMalus = -7.77f;

	private const float UnluckyCurseBonus = 0.77f;

	private const float LuckyDiceRollBaseChance = 1f / 6f;

	private const float LuckyDiceEffectDuration = 30000f;

	private const float UnluckyDiceEffectDuration = 10000f;

	private const float DiceRollInterval = 30000f;

	private string _characterTexture;

	private SpriteAnimation _diceRollAnim;

	private DiceResult _diceResult;

	private SpecialState _specialState;

	private int _diceRollCounter;

	private int _queuedDiceRolls;

	private bool _diceRollInProgress;

	private bool _luckyCameraZoomTriggered;

	private bool _unluckyCameraZoomTriggered;

	private Timer _diceRollTimer;

	private Timer _diceEffectTimer;

	private Timer _cameraTimer;

	private Timer _eventTimer;

	private MultiTargetTween _diceTween;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _luckyPfx;

	private ParticleSystem _unluckyPfx;

	private List<Transform> _originalCameraTargets;

	private float _orthographicSize;

	private bool IsLucky
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = _specialState - 1;
			return obj == null;
		}
	}

	private bool IsUnlucky
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = _specialState - 2;
			return obj == null;
		}
	}

	public override float LootMult_Rerollo => 5f;

	public override float PLuck()
	{
		//IL_004c: Expected F4, but got I4
		float num = ((_specialState == SpecialState.Lucky) ? 7.77f : ((_specialState != SpecialState.Unlucky) ? 0f : (-7.77f)));
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CLuck_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		WickedSeason wickedSeason = arcanaManager._wickedSeason;
		float eggValue = default(float);
		float value2 = default(float);
		EggFloat eggFloat3 = new EggFloat(value2, eggValue);
		eggValue = eggFloat2._eggVal * wickedSeason._luck;
		value2 = eggFloat2._val * wickedSeason._luck;
		if (eggFloat3._val > MaxReachedPLuck)
		{
			MaxReachedPLuck = eggFloat3._val;
		}
		if (MinReachedPLuck > eggFloat3._val)
		{
			MinReachedPLuck = eggFloat3._val;
		}
		return eggFloat3._val;
	}

	public override float PMoveSpeed()
	{
		//IL_0039: Expected F4, but got I4
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		float num = ((_specialState != SpecialState.Lucky) ? 0f : 0.77f);
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CMoveSpeed_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num;
		float eggValue = default(float);
		float value2 = default(float);
		EggFloat eggFloat3 = new EggFloat(value2, eggValue);
		eggValue = eggFloat2._eggVal * MoveSpeedMultiplier;
		value2 = eggFloat2._val * MoveSpeedMultiplier;
		float num2 = eggFloat3._eggVal + eggFloat3._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875C665Ah\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_0194;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_0194;
		IL_0194:
		return num2;
	}

	public override float PCurse()
	{
		//IL_001c: Expected F4, but got I4
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		float num = ((_specialState != SpecialState.Unlucky) ? 0f : 0.77f);
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCurse_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		WickedSeason wickedSeason = arcanaManager._wickedSeason;
		float eggValue = default(float);
		float value2 = default(float);
		EggFloat eggFloat3 = new EggFloat(value2, eggValue);
		eggValue = eggFloat2._eggVal * wickedSeason._curse;
		value2 = eggFloat2._val * wickedSeason._curse;
		float num2 = eggFloat3._eggVal + eggFloat3._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875C682Dh\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_01d1;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_01d1;
		IL_01d1:
		return num2;
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_046a->IL0383: Incompatible stack heights: 1 vs 0
		//IL_0069->IL0383: Incompatible stack heights: 1 vs 0
		base.MakeLevelOne();
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_DiceSprite, 0f);
		SpriteRenderer diceSprite = _DiceSprite;
		if ((object)_DiceSprite != null)
		{
			bool flag = ((UnityEngine.Object)diceSprite).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)diceSprite).m_CachedPtr, 2000);
			SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
			if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
				bool flag2 = (object)_ScreenFillRenderer == null;
				_ScreenFillRenderer.sprite = sprite;
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ScreenFillRenderer, 0f);
				bool flag3 = (object)_DiceSprite == null;
				GameObject gameObject = _DiceSprite.gameObject;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rdi_v12 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				bool flag4 = (object)gameObject == null;
				SpriteAnimation diceRollAnim = ((!gameObject.TryGetComponent<SpriteAnimation>(out var component)) ? gameObject.AddComponent<SpriteAnimation>() : component);
				_diceRollAnim = diceRollAnim;
				int num2 = default(int);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("dice", 1, 6, _characterTexture, num2);
				bool flag5 = (object)_diceRollAnim == null;
				bool startRandomFrame = default(bool);
				Action onComplete = default(Action);
				bool autoSetAnimation = default(bool);
				_diceRollAnim.AddAnimation("roll", animationFrames, 30, (byte)num2 != 0, startRandomFrame, onComplete, autoSetAnimation);
				SpriteAnimation diceRollAnim2 = _diceRollAnim;
				bool flag6 = (object)_diceRollAnim == null;
				((BaseSpriteAnimation)diceRollAnim2)._currentAnimation = null;
				bool flag7 = (object)_CameraTarget == null;
				Transform transform = _CameraTarget.transform;
				bool flag8 = (object)transform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v885 @ rax_v49 (UnityEngine.Transform)+10]");
				bool flag9 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v885 @ rax_v49 (UnityEngine.Transform)+10]");
				Vector3 value = default(Vector3);
				Transform.set_position_Injected((IntPtr)0, ref value);
				GameObject gameObject2 = base.gameObject;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rdi_v14 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				bool flag10 = (object)gameObject2 == null;
				ParticleEmitterManager pfxManager = ((!gameObject2.TryGetComponent<ParticleEmitterManager>(out var component2)) ? gameObject2.AddComponent<ParticleEmitterManager>() : component2);
				_pfxManager = pfxManager;
				GenerateLuckyParticleSystem();
				GenerateUnluckyParticleSystem();
				_specialState = SpecialState.None;
				_queuedDiceRolls = 0;
				_diceRollInProgress = false;
				WaitForNextDiceRoll(30000f);
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void InternalUpdate()
	{
		//IL_0032: Expected I4, but got I8
		//IL_0081: Expected I4, but got I8
		base.InternalUpdate();
		Vector2 pos = default(Vector2);
		if (_specialState == SpecialState.Lucky)
		{
			float2 float5 = base.position;
			RenderingExtensions.EmitParticleAt(_luckyPfx, pos, -1);
		}
		if (_specialState == SpecialState.Unlucky)
		{
			float2 float6 = base.position;
			RenderingExtensions.EmitParticleAt(_unluckyPfx, pos, -1);
		}
		if (_queuedDiceRolls > 0 && !_diceRollInProgress)
		{
			DoDiceRoll();
		}
	}

	private void CheckForQueuedDiceRolls()
	{
		if (_queuedDiceRolls > 0 && !_diceRollInProgress)
		{
			DoDiceRoll();
		}
	}

	public override void OnPickupCollected(Pickup pickup)
	{
		if (pickup._003CPickupType_003Ek__BackingField == ItemType.PICKUP_REROLL_DICE)
		{
			int queuedDiceRolls = _queuedDiceRolls + 1;
			_queuedDiceRolls = queuedDiceRolls;
			if (!_diceRollInProgress)
			{
				DoDiceRoll();
			}
		}
	}

	private void WaitForNextDiceRoll(float delay)
	{
		if (_diceRollTimer != null)
		{
			_diceRollTimer.Cancel();
		}
		Action onComplete = delegate
		{
			int queuedDiceRolls = _queuedDiceRolls + 1;
			_queuedDiceRolls = queuedDiceRolls;
			DoDiceRoll();
		};
		float duration = delay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer diceRollTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_diceRollTimer = diceRollTimer;
	}

	private void DoDiceRoll()
	{
		//IL_006f: Expected O, but got I
		//IL_0146: Expected I4, but got O
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v18 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v18 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v18 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		if (!base._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			int queuedDiceRolls = _queuedDiceRolls - 1;
			_queuedDiceRolls = queuedDiceRolls;
			_diceRollInProgress = true;
			DiceResult diceResult = GetDiceResult();
			_diceResult = diceResult;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				DoDiceRollAnim();
			}
			else
			{
				Action<int> action = null;
				((CharacterController_EX_Chulareh)(object)action).SetDiceResult((int)this);
				bool flag3 = _coherenceSync.SendCommand(action, MessageTarget.All, (int)_diceResult);
			}
		}
		else
		{
			_queuedDiceRolls = 0;
		}
		WaitForNextDiceRoll(30000f);
	}

	public void SetDiceResult(int result)
	{
		_diceResult = (DiceResult)result;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x1875C73B0\"");
	}

	private void DoDiceRollAnim()
	{
		//IL_021a: Expected O, but got I4
		//IL_019f->IL019f: Incompatible stack heights: 4 vs 3
		_003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass49_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			PlayDiceShakeSfx();
			if ((object)_diceRollAnim != null)
			{
				_diceRollAnim.SetAnimation("roll");
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_DiceSprite, 0.6f);
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_DiceSprite, 1f);
				CS_0024_003C_003E8__locals13.offsetY = 0.56f;
				if ((object)_DiceSprite != null)
				{
					Transform transform = _DiceSprite.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						if (_diceTween != null)
						{
							_diceTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						bool flag2 = (object)_DiceSprite == null;
						Transform transform2 = _DiceSprite.transform;
						bool flag3 = array == null;
						if ((object)transform2 != null)
						{
							SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale((SpriteRenderer)(object)transform2, CS_0024_003C_003E8__locals13.offsetY);
							bool flag4 = (object)spriteRenderer3 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						bool flag5 = tweenConfig == null;
						tweenConfig.targets = array;
						tweenConfig.duration = 100f;
						tweenConfig.repeat = 25;
						tweenConfig.yoyo = true;
						tweenConfig.ease = Ease.InOutSine;
						tweenConfig.localX = (float?)(object)1;
						TweenCallback onComplete = delegate
						{
							//IL_01a5->IL014f: Incompatible stack heights: 1 vs 0
							//IL_013e->IL014f: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
							{
								SoundManager.StopSound(SfxType.Sfx_dice_roll);
								CharacterController_EX_Chulareh characterController_EX_Chulareh = CS_0024_003C_003E8__locals13._003C_003E4__this;
								if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
								{
									SpriteAnimation diceRollAnim = characterController_EX_Chulareh._diceRollAnim;
									if ((object)characterController_EX_Chulareh._diceRollAnim != null)
									{
										((BaseSpriteAnimation)diceRollAnim)._currentAnimation = null;
										CharacterController_EX_Chulareh characterController_EX_Chulareh2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null && (object)characterController_EX_Chulareh2._DiceSprite != null)
										{
											Transform transform3 = characterController_EX_Chulareh2._DiceSprite.transform;
											if ((object)transform3 != null)
											{
												bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
												Vector3 value2 = default(Vector3);
												Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
												if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
												{
													CS_0024_003C_003E8__locals13._003C_003E4__this.SetDiceSpriteForRoll();
													if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
													{
														CS_0024_003C_003E8__locals13._003C_003E4__this.DoDiceRollOutcome();
														return;
													}
												}
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						tweenConfig.onComplete = onComplete;
						MultiTargetTween diceTween = Tweens.Add(tweenConfig);
						_diceTween = diceTween;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private DiceResult GetDiceResult()
	{
		//IL_0258: Expected O, but got I
		//IL_02b2: Expected O, but got I
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0330: Expected O, but got F4
		float num;
		if (++_diceRollCounter != 1)
		{
			PlayerModifierStats playerStats = _playerStats;
			EggFloat eggFloat = playerStats._003CLuck_003Ek__BackingField;
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			WickedSeason wickedSeason = arcanaManager._wickedSeason;
			float eggValue = default(float);
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggValue);
			eggValue = eggFloat._eggVal * wickedSeason._luck;
			value = eggFloat._val * wickedSeason._luck;
			float value2 = default(float);
			EggFloat eggFloat3 = new EggFloat(value2, eggFloat2._eggVal);
			value2 = eggFloat2._val + 3f;
			float value3 = default(float);
			EggFloat eggFloat4 = new EggFloat(value3, eggFloat3._eggVal);
			value3 = eggFloat3._val - 1f;
			num = eggFloat4._eggVal + eggFloat4._val;
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875C7AD4h\"");
					if (num == -1f / 0f)
					{
						num = -3.4028235E+38f;
					}
					goto IL_02fe;
				}
			}
			num = 3.4028235E+38f;
			goto IL_02fe;
		}
		bool flag = ((List<System.Int32Enum>)(object)_nonLuckyDiceResults).Remove((System.Int32Enum)1);
		DiceResult result = VampireSurvivors.App.Tools.Extensions.PickRnd(_nonLuckyDiceResults);
		List<System.Int32Enum> nonLuckyDiceResults = (List<System.Int32Enum>)(object)_nonLuckyDiceResults;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r9_v3 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r9_v3 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r9_v3 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4+18]");
		if (num2 >= 0)
		{
			nonLuckyDiceResults.AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r9_v3 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1;
		}
		goto IL_01eb;
		IL_02fe:
		bool flag2 = !(1f < num);
		float num3 = 1f;
		if (!flag2)
		{
			num3 = num;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C46650");
		float num4 = num3 * (1f / 6f);
		object obj5 = UnityEngine.Random.value;
		result = ((num4 > num3) ? DiceResult.LuckySix : VampireSurvivors.App.Tools.Extensions.PickRnd(_nonLuckyDiceResults));
		goto IL_01eb;
		IL_01eb:
		return result;
	}

	private bool IsDiceResult2345()
	{
		//IL_006d: Expected O, but got I4
		if (_diceResult != DiceResult.Two && _diceResult != DiceResult.Three && _diceResult != DiceResult.Four)
		{
			object obj = _diceResult - 5;
			return obj == null;
		}
		return true;
	}

	private void SetDiceSpriteForRoll()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 61 Invalid \"Jump target not found in method: 0x1875C84ED\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 79 Invalid \"Jump target not found in method: 0x1875C82C0\"");
	}

	private void DoDiceRollOutcome()
	{
		//IL_01ce: Expected O, but got I4
		//IL_007b: Expected F4, but got I4
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (_diceResult != DiceResult.LuckySix)
		{
			if (_diceResult != DiceResult.UnluckyOne)
			{
				float bonus = (float)_diceResult * 0.01f;
				AddPermanentLuckBonus(bonus);
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Volume = (float?)(object)1;
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.KeyWrong, soundConfig, 200f, 10, flag ? 1 : 0);
				DoDiceFadeOutSequence();
				return;
			}
			if (_specialState == SpecialState.Lucky)
			{
				_specialState = SpecialState.None;
			}
			ActivateUnluckyBonus();
			if (_diceEffectTimer != null)
			{
				_diceEffectTimer.Cancel();
			}
			Action onComplete = delegate
			{
				DeactivateUnluckyBonus();
			};
			Timer diceEffectTimer = Timers.Register(30.000002f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_diceEffectTimer = diceEffectTimer;
		}
		else
		{
			if (_specialState == SpecialState.Unlucky)
			{
				DeactivateUnluckyBonus(playSfx: false);
			}
			ActivateLuckyBonus();
			if (_diceEffectTimer != null)
			{
				_diceEffectTimer.Cancel();
			}
			Action onComplete2 = DeactivateLuckyBonus;
			Timer diceEffectTimer2 = Timers.Register(30.000002f, onComplete2, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_diceEffectTimer = diceEffectTimer2;
		}
	}

	private void GetNormalOutcome()
	{
		//IL_0064: Expected O, but got I4
		float bonus = (float)_diceResult * 0.01f;
		AddPermanentLuckBonus(bonus);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.KeyWrong, soundConfig, 200f, 10, time);
		DoDiceFadeOutSequence();
	}

	private void GetLucky()
	{
		if (_specialState == SpecialState.Unlucky)
		{
			DeactivateUnluckyBonus(playSfx: false);
		}
		ActivateLuckyBonus();
		if (_diceEffectTimer != null)
		{
			_diceEffectTimer.Cancel();
		}
		Action onComplete = DeactivateLuckyBonus;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer diceEffectTimer = Timers.Register(30.000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_diceEffectTimer = diceEffectTimer;
	}

	private void GetUnlucky()
	{
		if (_specialState == SpecialState.Lucky)
		{
			_specialState = SpecialState.None;
		}
		ActivateUnluckyBonus();
		if (_diceEffectTimer != null)
		{
			_diceEffectTimer.Cancel();
		}
		Action onComplete = delegate
		{
			DeactivateUnluckyBonus();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer diceEffectTimer = Timers.Register(30.000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_diceEffectTimer = diceEffectTimer;
	}

	private unsafe void ActivateLuckyBonus()
	{
		//IL_025e: Expected O, but got Ref
		//IL_027a: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_00ad: Expected O, but got I4
		//IL_01b4: Expected I4, but got F4
		//IL_0233: Expected I4, but got F4
		_specialState = SpecialState.Lucky;
		object obj = default(object);
		DisplayOverheadIcon(null, null, (Vector2?)(object)(&obj));
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = 500f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.AutoLV, soundConfig, 150f, 3, num);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = 600f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.AutoLV, soundConfig2, 150f, 3, num);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 1f;
		soundConfig3.Detune = 700f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.AutoLV, soundConfig3, 150f, 3, num);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (_luckyCameraZoomTriggered)
		{
			DoQuickScreenFill();
			DoDiceFadeOutSequence();
		}
		else
		{
			_luckyCameraZoomTriggered = true;
			if (_cameraTimer != null)
			{
				_cameraTimer.Cancel();
			}
			float deltaTime = PauseSystem.DeltaTime;
			Action onComplete = delegate
			{
				ZoomInOnDice();
			};
			float duration = deltaTime * 0.001f;
			Timer cameraTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_cameraTimer = cameraTimer;
		}
		if (_eventTimer != null)
		{
			_eventTimer.Cancel();
		}
		Action onComplete2 = _003C_003Ec._003C_003E9__57_1;
		if (_003C_003Ec._003C_003E9__57_1 == null)
		{
			onComplete2 = (_003C_003Ec._003C_003E9__57_1 = delegate
			{
				//IL_0029: Expected O, but got Ref
				GameManager core = GM.Core;
				Stage stage = core._stage;
				VampireSurvivors.Data.Stage.Event obj2 = new VampireSurvivors.Data.Stage.Event();
				IntPtr intPtr = default(IntPtr);
				string text = ((Enum)(&intPtr)).ToString();
				obj2._003CeventType_003Ek__BackingField = text;
				bool flag = stage._stageEventManager.TriggerEvent(obj2);
			});
		}
		Timer eventTimer = Timers.Register(0.05f, onComplete2, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_eventTimer = eventTimer;
	}

	private void DeactivateLuckyBonus()
	{
		_specialState = SpecialState.None;
	}

	private unsafe void ActivateUnluckyBonus()
	{
		//IL_038a: Expected O, but got Ref
		//IL_03a6: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_0153: Expected I4, but got F4
		//IL_01de: Expected I4, but got F4
		//IL_026c: Expected I4, but got O
		//IL_0334: Invalid comparison between I4 and F4
		//IL_0410: Expected I4, but got O
		_specialState = SpecialState.Unlucky;
		object obj = default(object);
		DisplayOverheadIcon(null, null, (Vector2?)(object)(&obj));
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.CATI, soundConfig, 200f, 10, num);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LittleHit, soundConfig2, 200f, 10, num);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (_unluckyCameraZoomTriggered)
		{
			DoQuickScreenFill();
			DoDiceFadeOutSequence();
		}
		else
		{
			_unluckyCameraZoomTriggered = true;
			if (_cameraTimer != null)
			{
				_cameraTimer.Cancel();
			}
			float deltaTime = PauseSystem.DeltaTime;
			Action onComplete = delegate
			{
				ZoomInOnDice();
			};
			float duration = deltaTime * 0.001f;
			Timer cameraTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_cameraTimer = cameraTimer;
		}
		if (_eventTimer != null)
		{
			_eventTimer.Cancel();
		}
		Action onComplete2 = delegate
		{
			PlayLaughSfx();
			Action onComplete3 = delegate
			{
				DoShootingStars();
				Action onComplete4 = delegate
				{
					DoShootingStars();
				};
				bool useRealTime2 = default(bool);
				MonoBehaviour autoDestroyOwner3 = default(MonoBehaviour);
				int repeat3 = default(int);
				TimerType type3 = default(TimerType);
				Timer eventTimer3 = Timers.Register(5f, onComplete4, null, isLooped: false, useRealTime2, autoDestroyOwner3, repeat3, type3, isOnlineTimer: false, canPause: false);
				_eventTimer = eventTimer3;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer eventTimer2 = Timers.Register(0.90000004f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_eventTimer = eventTimer2;
		};
		Timer eventTimer = Timers.Register(0.1f, onComplete2, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_eventTimer = eventTimer;
		GameManager core = GM.Core;
		if (core._003CHasGfBonus_003Ek__BackingField)
		{
			return;
		}
		bool flag = (nint)core._stage < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul dword ptr [rdx+44h]\"");
		object obj2 = (object)core._stage >> 31;
		bool flag2 = (byte)(int)((object)core._stage + obj2) != 0;
		if (!flag)
		{
			if ((flag2 ? 1 : 0) > 4)
			{
				flag2 = true;
			}
		}
		else
		{
			flag2 = false;
		}
		float num2 = (float)(flag2 ? 1 : 0) * 0.05f;
		float maxInclusive = num2 + 1.25f;
		float num3 = UnityEngine.Random.Range(1.25f, maxInclusive);
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		StageData stageData = stage._stageData;
		GameManager core3 = GM.Core;
		Stage stage2 = core3._stage;
		float num4 = (float)stageData._003Cminimum_003Ek__BackingField * num3;
		GameManager core4 = GM.Core;
		Stage stage3 = core4._stage;
		StageData stageData2 = stage3._stageData;
		GameManager core5 = default(GameManager);
		if ((float)stage2._maximum > num4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			stageData2._003Cminimum_003Ek__BackingField = (int)stage3;
			core5 = GM.Core;
		}
		core5._stage.SwarmCheck();
		GameManager core6 = GM.Core;
		core6._stage.CalculateEnemySpeed();
	}

	private void DeactivateUnluckyBonus(bool playSfx = true)
	{
		_specialState = SpecialState.None;
		GameManager core = GM.Core;
		if (!core._003CHasGfBonus_003Ek__BackingField)
		{
			Stage stage = core._stage;
			StageData stageData = stage._stageData;
			stageData._003Cminimum_003Ek__BackingField = stage._lastMinimum;
			GameManager core2 = GM.Core;
			core2._stage.CalculateEnemySpeed();
		}
		if (playSfx)
		{
			PlayLaughSfx();
		}
	}

	private unsafe void DoShootingStars()
	{
		//IL_00e4: Expected O, but got I4
		//IL_00ed: Expected O, but got I4
		//IL_0170: Expected O, but got Ref
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_009e: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_0186: Expected I4, but got O
		//IL_0186: Expected I4, but got O
		if (_specialState != SpecialState.Unlucky)
		{
			return;
		}
		GameManager core = GM.Core;
		bool flag = (nint)core._stage < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul dword ptr [r8+44h]\"");
		object obj = (object)core >> 31;
		object obj2 = (object)core + obj;
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		object obj3;
		object obj4;
		if (!flag)
		{
			if ((nint)obj2 > 4)
			{
				obj3 = 13;
				obj4 = 6;
			}
			else
			{
				obj4 = obj2 + 2;
				object obj5 = obj4 * 2;
				obj3 = obj5 + 1;
			}
		}
		else
		{
			obj3 = 5;
			obj4 = 2;
		}
		VampireSurvivors.Data.Stage.Event obj6 = new VampireSurvivors.Data.Stage.Event();
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		obj6._003CeventType_003Ek__BackingField = text;
		int num = UnityEngine.Random.RandomRangeInt((int)obj4, (int)obj3);
		obj6._003CmoreX_003Ek__BackingField = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj7 = default(object);
		obj6._003CmoreY_003Ek__BackingField = obj7;
		obj6._003CmoreZ_003Ek__BackingField = 1f;
		bool flag2 = stage._stageEventManager.TriggerEvent(obj6);
	}

	private unsafe void AddPermanentLuckBonus(float bonus)
	{
		//IL_008f: Expected O, but got Ref
		//IL_00ab: Expected O, but got I4
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CLuck_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + bonus;
		playerStats._003CLuck_003Ek__BackingField = eggFloat2;
		float value2 = bonus * 100f;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string textOverride = System.Number.FormatSingle(value2, null, currentInfo);
		object obj = default(object);
		DisplayOverheadIcon(null, textOverride, (Vector2?)(object)(&obj));
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = 2000f;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, time);
	}

	private unsafe void DisplayOverheadIcon(string frameOverride = null, string textOverride = null, Vector2? offsetOverride = null)
	{
		//IL_01c4: Expected O, but got I4
		//IL_0165: Expected O, but got I4
		//IL_0165: Expected F4, but got O
		//IL_0165: Expected O, but got I4
		//IL_0165: Expected O, but got Ref
		string frameName;
		string value;
		string translation;
		bool flag3 = default(bool);
		GameObject gameObject = default(GameObject);
		string text = default(string);
		bool flag4 = default(bool);
		bool flag5;
		if (_diceResult != DiceResult.LuckySix)
		{
			if (_diceResult != DiceResult.UnluckyOne)
			{
				bool flag = frameOverride == null;
				frameName = "Clover";
				if (!flag)
				{
					frameName = frameOverride;
				}
				bool flag2 = textOverride == null;
				value = "";
				if (!flag2)
				{
					value = textOverride;
				}
				if ((object)offsetOverride == null)
				{
				}
				goto IL_01ab;
			}
			translation = LocalizationManager.GetTranslation("lang/chulareh_unlucky", FixForRTL: true, 0, ignoreRTLnumbers: true, flag3, gameObject, text, flag4);
			flag5 = !_unluckyCameraZoomTriggered;
			frameName = "Curse";
		}
		else
		{
			translation = LocalizationManager.GetTranslation("lang/chulareh_lucky", FixForRTL: true, 0, ignoreRTLnumbers: true, flag3, gameObject, text, flag4);
			flag5 = !_luckyCameraZoomTriggered;
			frameName = "Clover";
		}
		object obj = !flag5;
		value = translation;
		if (obj == null)
		{
			value = translation;
		}
		goto IL_01ab;
		IL_01ab:
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj2 = default(object);
		core._gizmoManager.DisplayIconOverhead(frameName, value, (Color?)(object)(&obj2), (CharacterController)flag3, (float)gameObject, (Vector2)text, (string)flag4);
	}

	private void DoDiceFadeOutSequence()
	{
		//IL_00d2: Expected I, but got O
		//IL_0144: Expected O, but got I4
		if (_diceResult == DiceResult.Two || _diceResult == DiceResult.Three || _diceResult == DiceResult.Four || _diceResult != DiceResult.Five)
		{
		}
		if (_diceTween != null)
		{
			_diceTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = _DiceSprite.transform;
		if ((object)transform != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_005e: Expected I, but got O
			//IL_00d0: Expected O, but got I4
			if (_diceTween != null)
			{
				_diceTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_DiceSprite != null)
			{
				nint num2 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 1000f;
			tweenConfig2.ease = Ease.Linear;
			tweenConfig2.alpha = (float?)(object)1;
			TweenCallback onComplete2 = delegate
			{
				_diceRollInProgress = false;
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween diceTween2 = Tweens.Add(tweenConfig2);
			_diceTween = diceTween2;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween diceTween = Tweens.Add(tweenConfig);
		_diceTween = diceTween;
	}

	private unsafe void GenerateLuckyParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03b3: Expected O, but got Ref
		//IL_03cd: Expected native int or pointer, but got O
		//IL_03e7: Expected O, but got I
		//IL_0407: Expected O, but got Ref
		//IL_0421: Expected native int or pointer, but got O
		//IL_06bf: Expected O, but got I4
		//IL_0439: Expected O, but got Ref
		//IL_0460: Expected O, but got I
		//IL_047a: Expected native int or pointer, but got O
		//IL_0494: Expected O, but got I
		//IL_04b4: Expected O, but got Ref
		//IL_04ce: Expected native int or pointer, but got O
		//IL_06dc: Expected O, but got I4
		//IL_04f3: Expected O, but got Ref
		//IL_050d: Expected native int or pointer, but got O
		//IL_070e: Expected O, but got I
		//IL_0545: Expected O, but got Ref
		//IL_055a: Expected native int or pointer, but got O
		//IL_0574: Expected O, but got I
		//IL_076f: Expected I, but got O
		//IL_0774->IL06b0: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem luckyPfx = _luckyPfx;
		if ((object)_luckyPfx != null && ((UnityEngine.Object)luckyPfx).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
		List<string> list = new List<string>();
		if (list != null)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"clover2");
				}
				else
				{
					int num = list._size + 1;
					list._size = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"clover2");
					}
					else
					{
						int num2 = list._size + 1;
						list._size = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items3 = list._items;
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"clover2");
						}
						else
						{
							int num3 = list._size + 1;
							list._size = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						string[] items4 = list._items;
						if (list._items != null)
						{
							if (list._size >= items4.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"dice");
							}
							else
							{
								int num4 = list._size + 1;
								list._size = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							if (particleSystemConfig != null)
							{
								particleSystemConfig._frame = list;
								ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 180f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
								particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(5f, 20f));
								particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
								_ = 0;
								_ = 10;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
								particleSystemConfig._quantity = (int?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 400f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
								_ = 0;
								particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0.5f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
								particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(-1000f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
								particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
								_ = 0;
								particleSystemConfig._on = false;
								EmitZone emitZone = new EmitZone();
								emitZone._type = EmitZoneType.Random;
								emitZone._source = circle;
								particleSystemConfig._emitZone = emitZone;
								Transform parent = base.transform;
								if ((object)_pfxManager != null)
								{
									ParticleSystem luckyPfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
									_luckyPfx = luckyPfx2;
									int num5 = base.depth;
									int num6 = num5 - 1;
									RenderingExtensions.SetDepth(_luckyPfx, num6);
									if ((object)_luckyPfx != null)
									{
										Transform transform = _luckyPfx.transform;
										bool flag = ((List<string>)(object)transform)._items == null;
										Vector3 value = default(Vector3);
										Transform.set_localPosition_Injected((IntPtr)((List<string>)(object)transform)._items, ref value);
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

	private unsafe void GenerateUnluckyParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03b3: Expected O, but got Ref
		//IL_03cd: Expected native int or pointer, but got O
		//IL_03e7: Expected O, but got I
		//IL_0407: Expected O, but got Ref
		//IL_0421: Expected native int or pointer, but got O
		//IL_06bf: Expected O, but got I4
		//IL_0439: Expected O, but got Ref
		//IL_0460: Expected O, but got I
		//IL_047a: Expected native int or pointer, but got O
		//IL_0494: Expected O, but got I
		//IL_04b4: Expected O, but got Ref
		//IL_04ce: Expected native int or pointer, but got O
		//IL_06dc: Expected O, but got I4
		//IL_04f3: Expected O, but got Ref
		//IL_050d: Expected native int or pointer, but got O
		//IL_070e: Expected O, but got I
		//IL_0545: Expected O, but got Ref
		//IL_055a: Expected native int or pointer, but got O
		//IL_0574: Expected O, but got I
		//IL_076f: Expected I, but got O
		//IL_0774->IL06b0: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem unluckyPfx = _unluckyPfx;
		if ((object)_unluckyPfx != null && ((UnityEngine.Object)unluckyPfx).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
		List<string> list = new List<string>();
		if (list != null)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"curse");
				}
				else
				{
					int num = list._size + 1;
					list._size = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"curse");
					}
					else
					{
						int num2 = list._size + 1;
						list._size = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items3 = list._items;
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"curse");
						}
						else
						{
							int num3 = list._size + 1;
							list._size = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						string[] items4 = list._items;
						if (list._items != null)
						{
							if (list._size >= items4.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"dice");
							}
							else
							{
								int num4 = list._size + 1;
								list._size = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							if (particleSystemConfig != null)
							{
								particleSystemConfig._frame = list;
								ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 180f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
								particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(5f, 20f));
								particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
								_ = 0;
								_ = 10;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
								particleSystemConfig._quantity = (int?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 400f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
								_ = 0;
								particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0.5f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
								particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(-1000f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
								particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
								_ = 0;
								particleSystemConfig._on = false;
								EmitZone emitZone = new EmitZone();
								emitZone._type = EmitZoneType.Random;
								emitZone._source = circle;
								particleSystemConfig._emitZone = emitZone;
								Transform parent = base.transform;
								if ((object)_pfxManager != null)
								{
									ParticleSystem unluckyPfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
									_unluckyPfx = unluckyPfx2;
									int num5 = base.depth;
									int num6 = num5 - 1;
									RenderingExtensions.SetDepth(_unluckyPfx, num6);
									if ((object)_unluckyPfx != null)
									{
										Transform transform = _unluckyPfx.transform;
										bool flag = ((List<string>)(object)transform)._items == null;
										Vector3 value = default(Vector3);
										Transform.set_localPosition_Injected((IntPtr)((List<string>)(object)transform)._items, ref value);
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

	private void UpdateParticles()
	{
		//IL_002c: Expected I4, but got I8
		//IL_007b: Expected I4, but got I8
		Vector2 pos = default(Vector2);
		if (_specialState == SpecialState.Lucky)
		{
			float2 float5 = base.position;
			RenderingExtensions.EmitParticleAt(_luckyPfx, pos, -1);
		}
		if (_specialState == SpecialState.Unlucky)
		{
			float2 float6 = base.position;
			RenderingExtensions.EmitParticleAt(_unluckyPfx, pos, -1);
		}
	}

	private void PlayDiceShakeSfx(bool play = true)
	{
		//IL_0069: Expected O, but got F4
		//IL_00a5: Expected O, but got I4
		if (!play)
		{
			SoundManager.StopSound(SfxType.Sfx_dice_roll);
			return;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig.Rate = 1f;
		float detune = num * 300f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_dice_roll, soundConfig, 1000f, 1, time);
	}

	private void PlayNormalEffectSfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.KeyWrong, soundConfig, 200f, 10, time);
	}

	private void PlayLuckySfx()
	{
		//IL_0109: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_0099: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = 500f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.AutoLV, soundConfig, 150f, 3, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = 600f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.AutoLV, soundConfig2, 150f, 3, time);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 1f;
		soundConfig3.Detune = 700f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.AutoLV, soundConfig3, 150f, 3, time);
	}

	private void PlayUnluckySfx()
	{
		//IL_0095: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.CATI, soundConfig, 200f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LittleHit, soundConfig2, 200f, 10, time);
	}

	private void PlayLaughSfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 2f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Haha, soundConfig, 200f, 10, time);
	}

	private void ZoomInOnDice()
	{
		//IL_015d: Expected O, but got I4
		//IL_05aa: Expected O, but got F4
		//IL_0511: Expected I4, but got F4
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected O, but got Unknown
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_0524->IL0524: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			if (!core._003CCanInterrupt_003Ek__BackingField || core._isPaused || !core._003CCanPause_003Ek__BackingField || core._003CFreezingFrame_003Ek__BackingField || !GM.Core.IsNormalCameraTarget())
			{
				DoDiceFadeOutSequence();
				return;
			}
			if ((object)GM.Core != null)
			{
				GM.Core.PauseGame();
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					core2._003CCanPause_003Ek__BackingField = false;
					SetupScreenFill();
					TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0.65f, 0.1f);
					List<Transform> originalCameraTargets = new List<Transform>();
					_originalCameraTargets = originalCameraTargets;
					object obj = 0;
					float num2 = default(float);
					Vector2 vector = default(Vector2);
					int repeat = default(int);
					while (true)
					{
						ProCamera2D instance = ProCamera2D.Instance;
						if ((object)instance == null)
						{
							break;
						}
						List<Com.LuisPedroFonseca.ProCamera2D.CameraTarget> cameraTargets = instance.CameraTargets;
						if (instance.CameraTargets == null)
						{
							break;
						}
						if ((nint)obj < cameraTargets._size)
						{
							List<Transform> originalCameraTargets2 = _originalCameraTargets;
							ProCamera2D instance2 = ProCamera2D.Instance;
							if ((object)instance2 == null)
							{
								break;
							}
							List<Com.LuisPedroFonseca.ProCamera2D.CameraTarget> cameraTargets2 = instance2.CameraTargets;
							if (instance2.CameraTargets == null)
							{
								break;
							}
							if ((nint)obj < cameraTargets2._size)
							{
								Com.LuisPedroFonseca.ProCamera2D.CameraTarget[] items = cameraTargets2._items;
								if (cameraTargets2._items == null)
								{
									break;
								}
								if ((nint)obj < items.Length)
								{
									Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = items[obj];
									if (items[obj] == null || _originalCameraTargets == null)
									{
										break;
									}
									int version = originalCameraTargets2._version + 1;
									originalCameraTargets2._version = version;
									Transform[] items2 = originalCameraTargets2._items;
									if (originalCameraTargets2._items == null)
									{
										break;
									}
									if (originalCameraTargets2._size >= items2.Length)
									{
										((List<object>)(object)_originalCameraTargets).AddWithResize((object)cameraTarget.TargetTransform);
										obj++;
										continue;
									}
									int num = originalCameraTargets2._size + 1;
									originalCameraTargets2._size = num;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									obj++;
									continue;
								}
							}
							else
							{
								System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							}
							throw new IndexOutOfRangeException();
						}
						ProCamera2D instance3 = ProCamera2D.Instance;
						if ((object)instance3 == null)
						{
							break;
						}
						instance3.RemoveAllCameraTargets(0.1f);
						ProCamera2D instance4 = ProCamera2D.Instance;
						if ((object)_CameraTarget == null)
						{
							break;
						}
						Transform targetTransform = _CameraTarget.transform;
						if ((object)instance4 == null)
						{
							break;
						}
						Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget2 = instance4.AddCameraTarget(targetTransform, 1f, 1f, num2, vector);
						Camera main = Camera.main;
						if ((object)main == null)
						{
							break;
						}
						bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
						object obj2 = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
						_orthographicSize = 0f;
						TweenerCore<float, float, FloatOptions> tweenerCore2 = ShortcutExtensions.DOOrthoSize(main, 1f, 0.2f);
						if (_cameraTimer != null)
						{
							_cameraTimer.Cancel();
						}
						Action onComplete = ZoomOutFromDice;
						Timer cameraTimer = TimerHelper.RegisterMillisUI(1500f, onComplete, null, isLooped: false, (byte)(int)num2 != 0, (MonoBehaviour)vector, repeat);
						_cameraTimer = cameraTimer;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SetupScreenFill()
	{
		//IL_01cb: Expected O, but got I4
		//IL_026f: Expected O, but got I4
		//IL_0266->IL01c1: Incompatible stack heights: 9 vs 1
		string hex;
		if (_diceResult == DiceResult.UnluckyOne)
		{
			hex = "0x200020";
		}
		else
		{
			bool flag = _diceResult == DiceResult.LuckySix;
			hex = "0x002000";
			if (!flag)
			{
				hex = "0x000000";
			}
		}
		Color color = ColourHelper.HexToColor(hex);
		SpriteRenderer screenFillRenderer = _ScreenFillRenderer;
		bool flag2 = ((UnityEngine.Object)screenFillRenderer).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)screenFillRenderer).m_CachedPtr, ref *(Color*)(&value));
		Camera main = Camera.main;
		if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
		{
			Camera main2 = Camera.main;
			bool flag3 = (object)main2 == null;
			float orthographicSize = main2.orthographicSize;
			object obj = Screen.height;
			object obj2 = Screen.width;
			bool flag4 = (object)_ScreenFillRenderer == null;
			Sprite sprite = _ScreenFillRenderer.sprite;
			bool flag5 = (object)_ScreenFillRenderer == null;
			Transform transform = _ScreenFillRenderer.transform;
			bool flag6 = (object)sprite == null;
			bool flag7 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			Sprite.get_bounds_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Bounds _);
			bool flag8 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			Sprite.get_bounds_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Bounds _);
			bool flag9 = (object)transform == null;
			bool flag10 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		}
	}

	public void ZoomOutFromDice()
	{
		//IL_008b: Expected I4, but got F4
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0f, 0.1f);
		Camera main = Camera.main;
		TweenerCore<float, float, FloatOptions> tweenerCore2 = ShortcutExtensions.DOOrthoSize(main, _orthographicSize, 0.2f);
		ProCamera2D instance = ProCamera2D.Instance;
		instance.RemoveAllCameraTargets(0.5f);
		ProCamera2D instance2 = ProCamera2D.Instance;
		float num = default(float);
		Vector2 vector = default(Vector2);
		instance2.AddCameraTargets(_originalCameraTargets, 1f, 1f, num, vector);
		Action onComplete = delegate
		{
			GM.Core.ResumeGame();
			GameManager core = GM.Core;
			core._003CCanPause_003Ek__BackingField = true;
			DoDiceFadeOutSequence();
		};
		int repeat = default(int);
		Timer timer = TimerHelper.RegisterMillisUI(500f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat);
	}

	private unsafe void DoQuickScreenFill()
	{
		SetupScreenFill();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0.5f, 0.25f);
		TweenCallback tweenCallback = delegate
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0f, 0.75f);
		};
		tweenCallback._002Ector(this, (nint)__ldftn(CharacterController_EX_Chulareh._003CDoQuickScreenFill_003Eb__76_0));
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	public override bool OnTreasureCollected(TreasureChest treasure)
	{
		//IL_0333: Expected I4, but got O
		//IL_00da: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_014e: Expected O, but got I
		//IL_01d2: Expected O, but got I
		//IL_0207: Expected O, but got I
		//IL_0246: Expected O, but got I
		//IL_02de: Expected O, but got I4
		if (_specialState != SpecialState.Lucky)
		{
			goto IL_02fd;
		}
		if ((object)treasure != null)
		{
			Treasure treasure2 = treasure._treasure;
			if (treasure._treasure != null)
			{
				if (treasure2._003Clevel_003Ek__BackingField == 3)
				{
					goto IL_02fd;
				}
				List<float> list = treasure2._003Cchances_003Ek__BackingField;
				if (treasure2._003Cchances_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_0333;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v5+20]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v5+20]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A104DC]");
						if (num < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A104DC]");
							obj2 = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
						_ = (nint)0 + (nint)1;
						List<float> list2 = treasure2._003Cchances_003Ek__BackingField;
						if (treasure2._003Cchances_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
							if ((nint)0 <= (nint)1)
							{
								goto IL_0333;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v7+24]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v7+24]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A108D8]");
								if (num2 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A108D8]");
									obj4 = 0;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
								_ = (nint)0 + (nint)1;
								GameManager core = GM.Core;
								if ((object)GM.Core != null && (object)core._stage != null)
								{
									int num3 = core._stage.SetTreasureLevelFromChance(treasure._treasure);
									object obj5 = treasure2._003Clevel_003Ek__BackingField - treasure2._003Clevel_003Ek__BackingField;
									bool flag = obj5 == null;
									return !flag;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0325;
		IL_02fd:
		return false;
		IL_0333:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0325;
		IL_0325:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override void Despawn()
	{
		if ((object)_diceRollAnim != null)
		{
			_diceRollAnim.CleanAnimations();
		}
		if (_diceRollTimer != null)
		{
			_diceRollTimer.Cancel();
		}
		if (_diceEffectTimer != null)
		{
			_diceEffectTimer.Cancel();
		}
		if (_cameraTimer != null)
		{
			_cameraTimer.Cancel();
		}
		if (_eventTimer != null)
		{
			_eventTimer.Cancel();
		}
		if (_diceTween != null)
		{
			_diceTween.Kill();
		}
	}

	private void DebugDoDiceRoll()
	{
		DoDiceRoll();
	}

	private void DebugGetLucky()
	{
		int diceRollCounter = _diceRollCounter + 1;
		_diceRollCounter = diceRollCounter;
		_diceResult = DiceResult.LuckySix;
		DoDiceRollAnim();
		WaitForNextDiceRoll(30000f);
	}

	private void DebugGetUnlucky()
	{
		int diceRollCounter = _diceRollCounter + 1;
		_diceRollCounter = diceRollCounter;
		_diceResult = DiceResult.UnluckyOne;
		DoDiceRollAnim();
		WaitForNextDiceRoll(30000f);
	}

	private void DebugGetNormalOutcome()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0222: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_024a: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0272: Expected O, but got I
		//IL_01c0: Expected O, but got I
		int diceRollCounter = _diceRollCounter + 1;
		_diceRollCounter = diceRollCounter;
		List<DiceResult> list = new List<DiceResult>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 5;
		}
		DiceResult diceResult = VampireSurvivors.App.Tools.Extensions.PickRnd(list);
		_diceResult = diceResult;
		DoDiceRollAnim();
		WaitForNextDiceRoll(30000f);
	}

	private void DebugRemoveCurrentDiceEffect()
	{
		if (_specialState == SpecialState.Lucky)
		{
			_specialState = SpecialState.None;
		}
		if (_specialState == SpecialState.Unlucky)
		{
			DeactivateUnluckyBonus();
		}
	}

	public CharacterController_EX_Chulareh()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0278: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_02a0: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_02c8: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_02f0: Expected O, but got I
		//IL_022a: Expected O, but got I
		List<DiceResult> list = new List<DiceResult>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterController_EX_Chulareh+DiceResult>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 5;
		}
		_nonLuckyDiceResults = list;
		_characterTexture = "character_chulareh";
		base._002Ector();
	}

	private void _003CWaitForNextDiceRoll_003Eb__46_0()
	{
		int queuedDiceRolls = _queuedDiceRolls + 1;
		_queuedDiceRolls = queuedDiceRolls;
		DoDiceRoll();
	}

	private void _003CGetUnlucky_003Eb__56_0()
	{
		DeactivateUnluckyBonus();
	}

	private void _003CActivateLuckyBonus_003Eb__57_0()
	{
		ZoomInOnDice();
	}

	private void _003CActivateUnluckyBonus_003Eb__59_0()
	{
		ZoomInOnDice();
	}

	private void _003CActivateUnluckyBonus_003Eb__59_1()
	{
		PlayLaughSfx();
		Action onComplete = delegate
		{
			DoShootingStars();
			Action onComplete2 = delegate
			{
				DoShootingStars();
			};
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer eventTimer2 = Timers.Register(5f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_eventTimer = eventTimer2;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer eventTimer = Timers.Register(0.90000004f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_eventTimer = eventTimer;
	}

	private void _003CActivateUnluckyBonus_003Eb__59_2()
	{
		DoShootingStars();
		Action onComplete = delegate
		{
			DoShootingStars();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer eventTimer = Timers.Register(5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_eventTimer = eventTimer;
	}

	private void _003CActivateUnluckyBonus_003Eb__59_3()
	{
		DoShootingStars();
	}

	private void _003CDoDiceFadeOutSequence_003Eb__64_0()
	{
		//IL_005e: Expected I, but got O
		//IL_00d0: Expected O, but got I4
		if (_diceTween != null)
		{
			_diceTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_DiceSprite != null)
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
		tweenConfig.duration = 1000f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			_diceRollInProgress = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween diceTween = Tweens.Add(tweenConfig);
		_diceTween = diceTween;
	}

	private void _003CDoDiceFadeOutSequence_003Eb__64_1()
	{
		_diceRollInProgress = false;
	}

	private void _003CZoomOutFromDice_003Eb__75_0()
	{
		GM.Core.ResumeGame();
		GameManager core = GM.Core;
		core._003CCanPause_003Ek__BackingField = true;
		DoDiceFadeOutSequence();
	}

	private void _003CDoQuickScreenFill_003Eb__76_0()
	{
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0f, 0.75f);
	}
}
