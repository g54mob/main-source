using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Framework;

public class WhiteHandManager : GameMonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public WhiteHandManager _003C_003E4__this;

		public bool forceStageTimerEnd;

		public TweenCallback _003C_003E9__1;

		public DOGetter<float> _003C_003E9__2;

		public DOSetter<float> _003C_003E9__3;

		public TweenCallback _003C_003E9__4;

		internal void _003CSummonWhiteHand_003Eb__1()
		{
			WhiteHandManager whiteHandManager = _003C_003E4__this;
			whiteHandManager._bellTime = 1f;
		}

		internal float _003CSummonWhiteHand_003Eb__2()
		{
			WhiteHandManager whiteHandManager = _003C_003E4__this;
			return whiteHandManager._bellTime;
		}

		internal void _003CSummonWhiteHand_003Eb__3(float x)
		{
			WhiteHandManager whiteHandManager = _003C_003E4__this;
			whiteHandManager._bellTime = x;
		}

		internal void _003CSummonWhiteHand_003Eb__4()
		{
			//IL_005e: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1.5f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Bell, soundConfig, 0f, 10, time);
			WhiteHandManager whiteHandManager = _003C_003E4__this;
			whiteHandManager._gameManager.ZoomOnPlayer();
			SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		}

		internal void _003CSummonWhiteHand_003Eb__0()
		{
			_003C_003E4__this.SpawnWhiteHand(forceStageTimerEnd);
		}
	}

	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public bool forceStageTimerEnd;

		public WhiteHandManager _003C_003E4__this;

		internal void _003CSpawnWhiteHand_003Eb__0()
		{
			if (forceStageTimerEnd)
			{
				WhiteHandManager whiteHandManager = _003C_003E4__this;
				whiteHandManager._gameManager.ForceStageTimerEnd();
			}
			WhiteHandManager whiteHandManager2 = _003C_003E4__this;
			whiteHandManager2._kill = true;
		}
	}

	private Camera _mainCamera;

	private GameManager _gameManager;

	private GameSessionData _gameSessionData;

	private bool _triggered;

	private bool _kill;

	private float _bellTime;

	private Sequence _bellTollEvent;

	private PhaserSprite _whiteHand;

	private void Construct(GameManager gameManager, GameSessionData gameSessionData)
	{
		_gameManager = gameManager;
		_gameSessionData = gameSessionData;
		_bellTime = 1f;
		_kill = false;
	}

	private void Awake()
	{
		Camera main = Camera.main;
		_mainCamera = main;
	}

	protected override void OnUpdate()
	{
		//IL_0267: Expected F4, but got I4
		//IL_0270: Expected F4, but got I4
		//IL_0279: Expected F4, but got I4
		//IL_0025: Invalid comparison between F4 and I4
		//IL_00d3: Invalid comparison between F4 and I4
		if (!_kill)
		{
			return;
		}
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
		while (num2 < (float)characters._size)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			if (!characterController.IsDisconnectedFromOnlinePlay)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				if (!characterController2._isDead && !characterController2.IsDisconnectedFromOnlinePlay)
				{
					num++;
				}
			}
			num3++;
			num2 = num3;
		}
		if (num > 0f)
		{
			GameManager core2 = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = null;
				throw new NullReferenceException();
			}
		}
	}

	public unsafe void SummonWhiteHand(bool forceStageTimerEnd = false)
	{
		//IL_013b: Expected O, but got I4
		//IL_01dc: Expected O, but got I4
		//IL_01f7: Expected F4, but got I4
		//IL_0372: Expected F4, but got I4
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Expected O, but got Unknown
		//IL_04dd: Expected I, but got O
		//IL_04f3: Expected O, but got I
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_0577: Expected I, but got O
		//IL_06d0: Expected O, but got I4
		//IL_06e7: Expected I, but got I8
		//IL_05ec: Expected I4, but got F4
		//IL_0553: Expected I, but got I8
		//IL_0608: Expected I4, but got F4
		//IL_0655: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Expected O, but got Unknown
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals17._003C_003E4__this = this;
		CS_0024_003C_003E8__locals17.forceStageTimerEnd = forceStageTimerEnd;
		if (_triggered)
		{
			return;
		}
		_triggered = true;
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
			{
				GameManager core3 = GM.Core;
				core3._003CCanPause_003Ek__BackingField = false;
			}
		}
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
		BgmType bgmType = default(BgmType);
		SoundManager.FadeMusic(bgmType, 0f, 1000f);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1.5f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Bell, soundConfig, 0f, 10, num);
		if (_bellTollEvent != null)
		{
			DG.Tweening.TweenExtensions.Kill(_bellTollEvent);
		}
		Sequence bellTollEvent = DOTween.Sequence();
		_bellTollEvent = bellTollEvent;
		Sequence sequence = TweenSettingsExtensions.AppendInterval(_bellTollEvent, 1f);
		object obj = 0;
		float x = 1f;
		int num2 = 10;
		float num3 = 0f;
		bool flag3;
		do
		{
			TweenCallback callback = CS_0024_003C_003E8__locals17._003C_003E9__1;
			if (CS_0024_003C_003E8__locals17._003C_003E9__1 == null)
			{
				TweenCallback tweenCallback = (CS_0024_003C_003E8__locals17._003C_003E9__1 = delegate
				{
					WhiteHandManager whiteHandManager = CS_0024_003C_003E8__locals17._003C_003E4__this;
					whiteHandManager._bellTime = 1f;
				});
				num2 = 0;
				callback = tweenCallback;
			}
			Sequence sequence2 = TweenSettingsExtensions.AppendCallback(_bellTollEvent, callback);
			DOGetter<float> getter = CS_0024_003C_003E8__locals17._003C_003E9__2;
			Sequence bellTollEvent2 = _bellTollEvent;
			if (CS_0024_003C_003E8__locals17._003C_003E9__2 == null)
			{
				DOGetter<float> dOGetter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				CS_0024_003C_003E8__locals17._003C_003E9__2 = dOGetter;
				getter = dOGetter;
			}
			DOSetter<float> setter = CS_0024_003C_003E8__locals17._003C_003E9__3;
			if (CS_0024_003C_003E8__locals17._003C_003E9__3 == null)
			{
				DOSetter<float> dOSetter = null;
				((_003C_003Ec__DisplayClass11_0)(object)dOSetter)._003CSummonWhiteHand_003Eb__3(x);
				CS_0024_003C_003E8__locals17._003C_003E9__3 = dOSetter;
				setter = dOSetter;
			}
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, setter, 0f, 1f);
			bool flag = TweenSettingsExtensions.ValidateAddToSequence(_bellTollEvent, (Tween)t, false);
			bool flag2 = !flag;
			num2 = 0;
			num3 = 0f;
			if (!flag2)
			{
				num3 = ((Tween)bellTollEvent2).duration;
				Sequence sequence3 = Sequence.DoInsert(_bellTollEvent, (Tween)t, ((Tween)bellTollEvent2).duration);
				num2 = 0;
			}
			TweenCallback callback2 = CS_0024_003C_003E8__locals17._003C_003E9__4;
			if (CS_0024_003C_003E8__locals17._003C_003E9__4 == null)
			{
				TweenCallback tweenCallback2 = (CS_0024_003C_003E8__locals17._003C_003E9__4 = delegate
				{
					//IL_005e: Expected O, but got I4
					SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
					soundConfig2.Volume = (float?)(object)1;
					soundConfig2.Rate = 1.5f;
					float time = default(float);
					PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Bell, soundConfig2, 0f, 10, time);
					WhiteHandManager whiteHandManager = CS_0024_003C_003E8__locals17._003C_003E4__this;
					whiteHandManager._gameManager.ZoomOnPlayer();
					SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
				});
				num2 = 0;
				callback2 = tweenCallback2;
			}
			Sequence sequence4 = TweenSettingsExtensions.AppendCallback(_bellTollEvent, callback2);
			Sequence sequence5 = TweenSettingsExtensions.AppendInterval(_bellTollEvent, 1f);
			obj++;
			flag3 = (nint)obj < 11;
			x = 1f;
		}
		while (flag3);
		Sequence bellTollEvent3 = _bellTollEvent;
		TweenCallback tweenCallback3 = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v3 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback3).method = (nint)__ldftn(_003C_003Ec__DisplayClass11_0._003CSummonWhiteHand_003Eb__0);
		((Delegate)tweenCallback3).m_target = CS_0024_003C_003E8__locals17;
		((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v3 (Il2CppMethodInfo)+4C]");
		object obj2 = (nint)0 >> 4;
		object obj3 = obj2 & 1;
		nint num5;
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v3 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num5 = unchecked((nint)6447293664L);
				goto IL_06c7;
			}
		}
		num5 = ((Delegate)tweenCallback3).method_ptr;
		((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
		goto IL_06c7;
		IL_06c7:
		object obj4 = 24;
		((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
		bool flag4 = _bellTollEvent == null;
		TweenCallback tweenCallback4 = tweenCallback3;
		if (!flag4)
		{
			bool flag5 = !((Tween)bellTollEvent3)._003Cactive_003Ek__BackingField;
			tweenCallback4 = tweenCallback3;
			if (!flag5)
			{
				bellTollEvent3.onComplete = tweenCallback3;
				tweenCallback4 = tweenCallback3;
			}
		}
		Sequence bellTollEvent4 = _bellTollEvent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		bool flag6 = (nint)0 != 0;
		bool requireDeclaration = (byte)(int)num != 0;
		if (!flag6)
		{
			_ = 1;
			requireDeclaration = (byte)(int)num != 0;
		}
		bellTollEvent4.stringId = "DefaultGameTweenId";
		GameManager core4 = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		core4._signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void ZoomOnPlayer()
	{
		_gameManager.ZoomOnPlayer();
	}

	private void SpawnWhiteHand(bool forceStageTimerEnd = false)
	{
		//IL_0012: Expected O, but got I8
		//IL_00ce: Expected O, but got I4
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_03a3: Expected O, but got I4
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass13_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals8.forceStageTimerEnd = forceStageTimerEnd;
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite whiteHand = instance.AddPhaserSprite(pos, "enemies3", "WhiteHand_i01");
		_whiteHand = whiteHand;
		Transform transform = _whiteHand.transform;
		Transform parent = _mainCamera.transform;
		transform.SetParent(parent, worldPositionStays: true);
		PhaserSprite phaserSprite = _whiteHand.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite phaserSprite2 = _whiteHand.setFlipX(flipX: true);
		PhaserSprite phaserSprite3 = _whiteHand.setDepth(10000);
		PhaserSprite whiteHand2 = _whiteHand;
		GameObject gameObject = whiteHand2._spriteRenderer.gameObject;
		SpriteAnimation spriteAnimation = gameObject.AddComponent<SpriteAnimation>();
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("WhiteHand_i0", 1, 4, "enemies3", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		spriteAnimation.AddAnimation("Idle", animation, 60, flag, startRandomFrame, onComplete, autoSetAnimation);
		Transform target = _whiteHand.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMoveX(target, 0f, 10f);
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v23 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag2 = (nint)0 == 0;
				_ = 0;
				if (!flag2)
				{
					object obj2 = tweenerCore + 184;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v2+462E0+v660 @ rdx_v25*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v2+462E0+v660 @ rdx_v25*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v2+462E0+v660 @ rdx_v25*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v2+462E0+v660 @ rdx_v25*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v2+462E0+v660 @ rdx_v25*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = delegate
					{
						if (CS_0024_003C_003E8__locals8.forceStageTimerEnd)
						{
							WhiteHandManager whiteHandManager = CS_0024_003C_003E8__locals8._003C_003E4__this;
							whiteHandManager._gameManager.ForceStageTimerEnd();
						}
						WhiteHandManager whiteHandManager2 = CS_0024_003C_003E8__locals8._003C_003E4__this;
						whiteHandManager2._kill = true;
					};
					tweenCallback2 = tweenCallback;
					goto IL_02ea;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			if (CS_0024_003C_003E8__locals8.forceStageTimerEnd)
			{
				WhiteHandManager whiteHandManager = CS_0024_003C_003E8__locals8._003C_003E4__this;
				whiteHandManager._gameManager.ForceStageTimerEnd();
			}
			WhiteHandManager whiteHandManager2 = CS_0024_003C_003E8__locals8._003C_003E4__this;
			whiteHandManager2._kill = true;
		};
		bool flag3 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag3)
		{
			goto IL_02ea;
		}
		goto IL_0319;
		IL_0319:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return;
		IL_02ea:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v23 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0319;
	}

	public WhiteHandManager()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
