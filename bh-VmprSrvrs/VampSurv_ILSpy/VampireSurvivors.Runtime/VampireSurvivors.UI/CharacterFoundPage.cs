using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.UI;

public class CharacterFoundPage : BaseUIPage
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__42_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnShowStart_003Eb__42_1()
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public int count;

		public string[] frames;

		public CharacterFoundPage _003C_003E4__this;

		public TweenCallback _003C_003E9__1;

		public TweenCallback _003C_003E9__0;

		internal void _003CPlayFirework_003Eb__0()
		{
			//IL_00cd: Expected O, but got I4
			//IL_010c: Expected O, but got I4
			//IL_0112: Expected O, but got I
			if (frames != null)
			{
				List<object> list = new List<object>(frames);
				CharacterFoundPage characterFoundPage = _003C_003E4__this;
				RectTransform panel = characterFoundPage._Panel;
				ParticleSystem particleSystem = FireworksManager.CreateRandomFirework(count, (List<string>)(object)list, characterFoundPage._Panel, 0.6f);
				CharacterFoundPage characterFoundPage2 = _003C_003E4__this;
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(characterFoundPage2._BGAdditiveOverlay, 0.4f, 0.03f);
				TweenCallback tweenCallback = _003C_003E9__1;
				bool flag = _003C_003E9__1 != null;
				object obj = 0;
				if (!flag)
				{
					tweenCallback = (_003C_003E9__1 = delegate
					{
						CharacterFoundPage characterFoundPage3 = _003C_003E4__this;
						TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(characterFoundPage3._BGAdditiveOverlay, 0f, 0.03f);
					});
					obj = 0;
					panel = (RectTransform)0;
				}
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
				int num = count + 1;
				count = num;
				return;
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}

		internal void _003CPlayFirework_003Eb__1()
		{
			CharacterFoundPage characterFoundPage = _003C_003E4__this;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(characterFoundPage._BGAdditiveOverlay, 0f, 0.03f);
		}
	}

	private Image _Icon;

	private TextMeshProUGUI _Name;

	private TextMeshProUGUI _ThankYouText;

	private RectTransform _TextPanel;

	private GameObject _ThankYouTextPanel;

	private Image _BGFader;

	private Image _PanelDarkOverlay;

	private GameObject _DoneButton;

	private GameObject _OkButton;

	private GameObject _Ray;

	private Transform _RayContainer;

	private ParticleEmitterManager _Particles;

	private RectTransform _Panel;

	private Image _BGAdditiveOverlay;

	private GameObject VFX;

	private SignalBus _signalBus;

	private DataManager _dataManager;

	private CharacterData _unlockedCharacterData;

	private CharacterType _unlockedCharacterType;

	private List<Image> _ghosts;

	private List<GameObject> _rays;

	private Image _darkIcon;

	private ParticleSystem _darkParticles;

	private ParticleSystem _colorParticles;

	private List<Tween> _tweens;

	private GravityWell _gravityWell;

	private VampireSurvivors.Objects.Characters.CharacterController _currentCharacter;

	private bool _playDarkParticles;

	private bool _canSkip;

	private List<Tween> _toCompleteOnSkip;

	private PlaySoundResult _openCoffinSoundResult;

	private GravityWellConfig gravityWellCongfig;

	private void Construct(SignalBus signalBus, DataManager data)
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_0251: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_0145: Expected O, but got I
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_028c: Expected O, but got I
		//IL_01f1: Expected O, but got I4
		//IL_01f1: Expected O, but got I
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_02c7: Expected O, but got I
		_signalBus = signalBus;
		DataManager dataManager = default(DataManager);
		_dataManager = dataManager;
		Action<GameplaySignals.CharacterFoundSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A6B0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.CharacterFoundSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.CharacterFoundSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v15 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus2.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = OnCollectedCharacterRemotely;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.CollectCharacter>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.CollectCharacter>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v30 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus3.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Action action5 = OnRevealCharacterRemotely;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rbx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj7 = null;
		Action<object> action6 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.RevealCharacter>)obj7)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.RevealCharacter>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus4 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v45 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus4.SubscribeInternal(signalType3, (object)null, (object)0, callback);
	}

	private void OnRevealCharacterRemotely()
	{
		PerformReveal();
	}

	private void OnCollectedCharacterRemotely()
	{
		PerformCollectCharacter();
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		Action<GameplaySignals.CharacterFoundSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A6B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = OnCollectedCharacterRemotely;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		Action token3 = OnRevealCharacterRemotely;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
	}

	private void FixedUpdate()
	{
		//IL_00f3: Expected O, but got F4
		//IL_0125: Expected O, but got F4
		float t = default(float);
		bool fixedTimeStep = default(bool);
		if (_playDarkParticles)
		{
			object obj = Time.fixedDeltaTime;
			_darkParticles.Simulate(t, withChildren: true, restart: false, fixedTimeStep);
		}
		ParticleSystem colorParticles = _colorParticles;
		if ((object)_colorParticles != null && ((UnityEngine.Object)colorParticles).m_CachedPtr != (IntPtr)0)
		{
			object obj2 = Time.fixedDeltaTime;
			_colorParticles.Simulate(t, withChildren: false, restart: false, fixedTimeStep);
		}
		if (Player.GetButtonDown(6))
		{
			OnCancelPressed();
		}
	}

	public void CollectCharacter()
	{
		//IL_009e: Expected I8, but got O
		//IL_0082: Expected I8, but got O
		//IL_0057: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x186B9F120\"");
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).CollectCharacter((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbx_v4 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private void PerformCollectCharacter()
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		if (_unlockedCharacterType != CharacterType.TP_DRACULA)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj = default(object);
			if (obj == null)
			{
				PlayerOptionsData config2 = core._playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
			}
			PlayerOptionsData config3 = core._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				PlayerOptionsData config4 = core._playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
			}
			GameManager core2 = GM.Core;
			core2._playerOptions.Save();
			Debug.Log("Collected character");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj4 = default(object);
			object obj3 = obj4 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 377 Invalid \"Jump target not found in method: 0x186B9F3D0\"");
		throw new NullReferenceException();
	}

	private unsafe void AnimateOut()
	{
		//IL_00b5: Expected O, but got Ref
		//IL_01ea: Expected O, but got Ref
		//IL_02f2: Expected O, but got Ref
		//IL_02fe->IL02fe: Incompatible stack heights: 2 vs 0
		if ((object)_colorParticles != null)
		{
			_colorParticles.Stop();
			if ((object)_Panel != null)
			{
				Transform target = _Panel.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0f, 0.3f);
				if ((object)_Panel != null)
				{
					Transform target2 = _Panel.transform;
					List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&enumerator), 0.3f);
					TweenCallback tweenCallback = delegate
					{
						View.Hide();
					};
					if (tweenerCore2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
					if (_rays != null)
					{
						List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
						while (enumerator2.MoveNext())
						{
							object obj = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v10 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v10 (System.Object)+10]");
							IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
							Transform target3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target3, 0f, 0.3f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v10 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v10 (System.Object)+10]");
							IntPtr gcHandlePtr2 = GameObject.get_transform_Injected((IntPtr)0);
							Transform target4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DOLocalRotate(target4, (Vector3)(&enumerator), 0.3f);
						}
						if ((object)_Name != null)
						{
							Transform target5 = _Name.transform;
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(target5, 0f, 0.3f);
							if ((object)_Name != null)
							{
								Transform target6 = _Name.transform;
								TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore6 = ShortcutExtensions.DOLocalRotate(target6, (Vector3)(&enumerator), 0.3f);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Reveal()
	{
		//IL_0053: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x186B9FAA0\"");
		}
		object instance = OnlineStageManager._instance;
		Action action = OnlineStageManager._instance.RevealCharacter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rbx_v4 (System.Object)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All);
	}

	private unsafe void PerformReveal()
	{
		//IL_0192: Expected O, but got Ref
		//IL_02d4: Expected O, but got I4
		//IL_0294: Expected O, but got I4
		//IL_0254: Expected O, but got I4
		//IL_0214: Expected O, but got I4
		PlayFirework();
		AddRays();
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 0.5f);
		TweenCallback tweenCallback = delegate
		{
			AddRays();
		};
		object message;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback != null)
					{
						Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					}
					goto IL_0171;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message);
		goto IL_0171;
		IL_0171:
		Transform transform = _Name.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		SoundManager.SoundConfig soundConfig2;
		SfxType sfxType;
		if (_unlockedCharacterType != CharacterType.CONCETTA)
		{
			if (_unlockedCharacterType != CharacterType.GIOVANNA)
			{
				if (_unlockedCharacterType != CharacterType.POPPEA)
				{
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Rate = 1f;
					soundConfig.Volume = (float?)(object)1;
					soundConfig2 = soundConfig;
					sfxType = SfxType.Piano;
				}
				else
				{
					SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
					soundConfig3.Rate = 1f;
					soundConfig3.Volume = (float?)(object)1;
					soundConfig2 = soundConfig3;
					sfxType = SfxType.CFF3;
				}
			}
			else
			{
				SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
				soundConfig4.Rate = 1f;
				soundConfig4.Volume = (float?)(object)1;
				soundConfig2 = soundConfig4;
				sfxType = SfxType.CFF2;
			}
		}
		else
		{
			SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
			soundConfig5.Rate = 1f;
			soundConfig5.Volume = (float?)(object)1;
			soundConfig2 = soundConfig5;
			sfxType = SfxType.CFF4;
		}
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig2, 0f, 10, time);
		Sequence sequence4 = TweenSettingsExtensions.AppendInterval(sequence, 2.5f);
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(_BGFader, 0f, 0.5f);
		TweenCallback tweenCallback3;
		object message2;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			Sequence sequence5 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
			TweenCallback tweenCallback2 = delegate
			{
				//IL_0104: Expected F4, but got I4
				//IL_00c7: Expected O, but got I4
				//IL_00f5: Expected F4, but got I4
				//IL_020b->IL0259: Incompatible stack heights: 3 vs 0
				if ((object)_darkParticles != null)
				{
					_darkParticles.Stop();
					MakeColorParticles();
					if ((object)_Name != null)
					{
						Transform target = _Name.transform;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.5f);
						float endValue;
						if (_unlockedCharacterType == CharacterType.TP_DRACULA)
						{
							SoundManager.SoundConfig soundConfig6 = new SoundManager.SoundConfig();
							soundConfig6.Rate = 1f;
							soundConfig6.Volume = (float?)(object)1;
							float time2 = default(float);
							PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Coffin2, soundConfig6, 0f, 10, time2);
							endValue = 0f;
						}
						else
						{
							endValue = 0f;
						}
						if (_ghosts != null)
						{
							List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
							while (enumerator.MoveNext())
							{
								object obj2 = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v11 (System.Object)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v11 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
								GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
								bool flag3 = (object)gameObject == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v38 (UnityEngine.GameObject)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v38 (UnityEngine.GameObject)+10]");
								GameObject.SetActive_Injected((IntPtr)0, false);
							}
							TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Icon, 1f, 0.5f);
							TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_darkIcon, endValue, 0.5f);
							TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleUI.DOFade(_PanelDarkOverlay, endValue, 0.5f);
							return;
						}
					}
				}
				throw new NullReferenceException();
			};
			tweenCallback3 = tweenCallback2;
		}
		else
		{
			TweenCallback tweenCallback4 = delegate
			{
				//IL_0104: Expected F4, but got I4
				//IL_00c7: Expected O, but got I4
				//IL_00f5: Expected F4, but got I4
				//IL_020b->IL0259: Incompatible stack heights: 3 vs 0
				if ((object)_darkParticles != null)
				{
					_darkParticles.Stop();
					MakeColorParticles();
					if ((object)_Name != null)
					{
						Transform target = _Name.transform;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.5f);
						float endValue;
						if (_unlockedCharacterType == CharacterType.TP_DRACULA)
						{
							SoundManager.SoundConfig soundConfig6 = new SoundManager.SoundConfig();
							soundConfig6.Rate = 1f;
							soundConfig6.Volume = (float?)(object)1;
							float time2 = default(float);
							PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Coffin2, soundConfig6, 0f, 10, time2);
							endValue = 0f;
						}
						else
						{
							endValue = 0f;
						}
						if (_ghosts != null)
						{
							List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
							while (enumerator.MoveNext())
							{
								object obj2 = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v11 (System.Object)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v11 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
								GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
								bool flag3 = (object)gameObject == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v38 (UnityEngine.GameObject)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v38 (UnityEngine.GameObject)+10]");
								GameObject.SetActive_Injected((IntPtr)0, false);
							}
							TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Icon, 1f, 0.5f);
							TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_darkIcon, endValue, 0.5f);
							TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleUI.DOFade(_PanelDarkOverlay, endValue, 0.5f);
							return;
						}
					}
				}
				throw new NullReferenceException();
			};
			bool flag = sequence == null;
			tweenCallback3 = tweenCallback4;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "You can't add elements to a NULL Sequence";
				goto IL_0701;
			}
		}
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				if (tweenCallback3 != null)
				{
					Sequence sequence6 = Sequence.DoInsertCallback(sequence, tweenCallback3, ((Tween)sequence).duration);
				}
				goto IL_04af;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_0701;
		IL_060d:
		DisableOkButton();
		return;
		IL_04af:
		Sequence sequence7 = TweenSettingsExtensions.AppendInterval(sequence, 4f);
		TweenCallback tweenCallback5 = delegate
		{
			EnableDoneButton();
		};
		object message3;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback5 != null)
					{
						Sequence sequence8 = Sequence.DoInsertCallback(sequence, tweenCallback5, ((Tween)sequence).duration);
					}
					goto IL_060d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message3 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message3 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message3 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message3);
		goto IL_060d;
		IL_0701:
		Debugger.LogWarning(message2);
		goto IL_04af;
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_008f: Expected O, but got I
		//IL_00e3: Expected O, but got Ref
		//IL_0109: Expected O, but got Ref
		//IL_016e: Expected O, but got Ref
		//IL_0198: Expected I, but got O
		//IL_01a5: Expected O, but got Ref
		//IL_0364: Expected O, but got I
		//IL_03ce: Expected O, but got I
		//IL_0475: Expected I, but got O
		//IL_04ba: Expected I, but got O
		//IL_050a: Expected I, but got O
		//IL_054f: Expected I, but got O
		//IL_05e6: Expected I, but got O
		//IL_0875: Expected I4, but got O
		//IL_0875: Expected O, but got I4
		//IL_06da: Expected I4, but got O
		//IL_06da: Expected O, but got I4
		//IL_08a9: Expected I, but got O
		//IL_070e: Expected I, but got O
		//IL_08c0: Expected I, but got O
		//IL_0753: Expected I, but got O
		//IL_08fb: Expected I, but got O
		//IL_07b7: Expected O, but got I
		//IL_0936: Expected I, but got O
		//IL_07e9: Expected O, but got I
		//IL_080c: Expected O, but got I
		//IL_0971: Expected I, but got O
		//IL_0838: Expected I, but got O
		//IL_09ac: Expected I, but got O
		//IL_0a00: Expected O, but got Ref
		//IL_0a52: Expected O, but got Ref
		//IL_0b41: Expected I, but got O
		//IL_0b57: Expected O, but got I
		//IL_0b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b65: Expected O, but got Unknown
		//IL_0bce: Expected I, but got O
		//IL_15fc: Expected O, but got I4
		//IL_1605: Expected O, but got I4
		//IL_161c: Expected I, but got I8
		//IL_0bb7: Expected I, but got I8
		//IL_16eb: Expected I, but got O
		//IL_1701: Expected O, but got I
		//IL_170a: Unknown result type (might be due to invalid IL or missing references)
		//IL_170f: Expected O, but got Unknown
		//IL_0e48: Expected I, but got O
		//IL_1743: Expected I, but got I8
		//IL_0e1b: Expected I, but got I8
		//IL_17b4: Expected O, but got Ref
		//IL_0f1d: Expected I, but got O
		//IL_1012: Expected O, but got I4
		//IL_104f: Expected F4, but got I4
		//IL_1063: Unknown result type (might be due to invalid IL or missing references)
		//IL_1068: Expected O, but got Unknown
		//IL_17ef: Expected O, but got I4
		//IL_0fd5: Expected F4, but got I4
		//IL_0fe9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fee: Expected O, but got Unknown
		//IL_1137: Expected O, but got Ref
		//IL_11c9: Expected I, but got O
		//IL_11d8: Expected O, but got Ref
		//IL_1237: Expected O, but got I
		//IL_1272: Expected O, but got I
		//IL_1b6a: Expected O, but got Ref
		//IL_0ea0->IL13c9: Incompatible stack heights: 3 vs 0
		//IL_0ed3->IL13c9: Incompatible stack heights: 3 vs 0
		//IL_0f06->IL13c9: Incompatible stack heights: 3 vs 0
		//IL_17dc->IL13c9: Incompatible stack heights: 4 vs 0
		//IL_1094->IL13c9: Incompatible stack heights: 4 vs 0
		//IL_1855->IL13c9: Incompatible stack heights: 5 vs 0
		//IL_18af->IL13c9: Incompatible stack heights: 6 vs 0
		//IL_1909->IL13c9: Incompatible stack heights: 7 vs 0
		//IL_10ea->IL13c9: Incompatible stack heights: 8 vs 0
		base.OnShowStart(g);
		Component toCompleteOnSkip = (Component)(object)_toCompleteOnSkip;
		Vector3 ret = default(Vector3);
		Vector2 value = default(Vector2);
		Vector2 vector = default(Vector2);
		GameObject gameObject;
		bool flag6 = default(bool);
		bool flag7 = default(bool);
		GameObject gameObject2 = default(GameObject);
		string text = default(string);
		if (_toCompleteOnSkip != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v84 (UnityEngine.Component)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v84 (UnityEngine.Component)+18]");
			if ((nint)0 > (nint)0)
			{
				IntPtr cachedPtr = ((UnityEngine.Object)toCompleteOnSkip).m_CachedPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v84 (UnityEngine.Component)+18]");
				Array.Clear((Array)(nint)cachedPtr, 0, 0);
			}
			FireworksManager.Clear();
			toCompleteOnSkip = _Panel;
			if ((object)_Panel != null)
			{
				Transform transform = _Panel.transform;
				transform.localScale = (Vector3)(&ret);
				Transform transform2 = _Panel.transform;
				transform2.localEulerAngles = (Vector3)(&value);
				Transform target = _Panel.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.15f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
				Transform target2 = _Panel.transform;
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&value), 0.15f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
				Image bGFader = _BGFader;
				nint num = (nint)bGFader;
				bGFader.color = (Color)(&value);
				TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_BGFader, 0.9f, 0.3f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
				CharacterType characterType = default(CharacterType);
				object obj = characterType;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
				object message = default(object);
				Debug.Log(message);
				EnterMultiplayerControl(_currentCharacter);
				RectTransform component = _ThankYouTextPanel.GetComponent<RectTransform>();
				float screenWidth = UIHelper.ScreenWidth;
				RectTransform component2 = _ThankYouTextPanel.GetComponent<RectTransform>();
				Vector2 sizeDelta = component2.sizeDelta;
				bool flag = (object)_ThankYouTextPanel == null;
				toCompleteOnSkip = (Component)(object)_ThankYouTextPanel;
				if (!flag)
				{
					RectTransform component3 = _ThankYouTextPanel.GetComponent<RectTransform>();
					bool flag2 = (object)component3 == null;
					toCompleteOnSkip = (Component)(object)_ThankYouTextPanel;
					if (!flag2)
					{
						Vector2 anchoredPosition = component3.anchoredPosition;
						bool flag3 = (object)component == null;
						toCompleteOnSkip = component3;
						if (!flag3)
						{
							component.anchoredPosition = vector;
							bool flag4 = _tweens == null;
							toCompleteOnSkip = component;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
								List<Tween>.Enumerator enumerator = default(List<Tween>.Enumerator);
								while (enumerator.MoveNext())
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2538 @ rax_v127+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2538 @ rax_v127+10]");
										DG.Tweening.TweenExtensions.Kill((Tween)0);
									}
								}
								toCompleteOnSkip = (Component)(object)_tweens;
								if (_tweens != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v84 (UnityEngine.Component)+1C]");
									_ = (nint)0 + (nint)1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v84 (UnityEngine.Component)+18]");
									if ((nint)0 > (nint)0)
									{
										IntPtr cachedPtr2 = ((UnityEngine.Object)toCompleteOnSkip).m_CachedPtr;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v84 (UnityEngine.Component)+18]");
										Array.Clear((Array)(nint)cachedPtr2, 0, 0);
									}
									gameObject = (GameObject)(object)_Name;
									bool flag5 = LocalizationManager.TryGetTranslation("lang/charFound_joins", out var Translation, FixForRTL: true, 0, flag6, flag7, gameObject2, text);
									string text2;
									if (Translation != null)
									{
										bool flag8 = Translation._stringLength > 0;
										text2 = Translation;
										if (flag8)
										{
											goto IL_1462;
										}
									}
									text2 = "lang/charFound_joins";
									goto IL_1462;
								}
							}
						}
					}
				}
			}
		}
		goto IL_13c9;
		IL_172c:
		TweenCallback tweenCallback;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		Sequence sequence;
		if (sequence != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5066 @ rax_v211 (DG.Tweening.Sequence)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		toCompleteOnSkip = (Component)(object)_toCompleteOnSkip;
		if (_toCompleteOnSkip != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
			toCompleteOnSkip = (Component)(object)_toCompleteOnSkip;
			if (_toCompleteOnSkip != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
				GameObject okButton = _OkButton;
				if ((object)_OkButton != null)
				{
					bool flag9 = ((UnityEngine.Object)okButton).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)okButton).m_CachedPtr);
					Transform target3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DOLocalRotate(target3, (Vector3)(&value), 0.01f);
					toCompleteOnSkip = _PanelDarkOverlay;
					if ((object)_PanelDarkOverlay != null)
					{
						nint num2 = (nint)toCompleteOnSkip;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v5467 @ rax_v231 (Il2CppClass<UnityEngine.Component>)+2A8] (should have been resolved before IL gen)");
						if (_unlockedCharacterType != CharacterType.ARENGIJUS)
						{
							SoundManager.SoundConfig soundConfig = ((_unlockedCharacterType == CharacterType.AVATAR) ? new SoundManager.SoundConfig
							{
								Detune = -1000f,
								Rate = 0.5f
							} : new SoundManager.SoundConfig
							{
								Detune = -2000f,
								Rate = 1f
							});
							soundConfig.Volume = (float?)(object)1;
							PlaySoundResult openCoffinSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, flag6 ? 1 : 0);
							_openCoffinSoundResult = openCoffinSoundResult;
							toCompleteOnSkip = (Component)(this + 456);
						}
						else
						{
							PlaySoundResult openCoffinSoundResult2 = SoundManager.PlaySound(SfxType.ThingFound, new SoundManager.SoundConfig
							{
								Volume = (float?)(object)1,
								Detune = -1000f,
								Rate = 0.5f
							}, 0f, 10, flag6 ? 1 : 0);
							_openCoffinSoundResult = openCoffinSoundResult2;
							toCompleteOnSkip = (Component)(this + 456);
						}
						GameObject icon = (GameObject)(object)_Icon;
						if ((object)_Icon != null)
						{
							bool flag10 = ((UnityEngine.Object)icon).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)icon).m_CachedPtr);
							GameObject original = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
							GameObject icon2 = (GameObject)(object)_Icon;
							if ((object)_Icon != null)
							{
								bool flag11 = ((UnityEngine.Object)icon2).m_CachedPtr == (IntPtr)0;
								IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)icon2).m_CachedPtr);
								Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
								if ((object)transform3 != null)
								{
									bool flag12 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									IntPtr parent_Injected = Transform.GetParent_Injected(((UnityEngine.Object)transform3).m_CachedPtr);
									Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
									if ((object)transform4 != null)
									{
										bool flag13 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										IntPtr parent_Injected2 = Transform.GetParent_Injected(((UnityEngine.Object)transform4).m_CachedPtr);
										Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected2);
										GameObject gameObject3 = UnityEngine.Object.Instantiate(original, parent);
										if ((object)gameObject3 != null)
										{
											Image component4 = gameObject3.GetComponent<Image>();
											_darkIcon = component4;
											bool flag14 = (object)_darkIcon == null;
											_darkIcon.color = (Color)(&ret);
											GameObject darkIcon = (GameObject)(object)_darkIcon;
											bool flag15 = (object)_darkIcon == null;
											bool flag16 = ((UnityEngine.Object)darkIcon).m_CachedPtr == (IntPtr)0;
											IntPtr gcHandlePtr4 = Component.get_gameObject_Injected(((UnityEngine.Object)darkIcon).m_CachedPtr);
											GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr4);
											bool flag17 = (object)gameObject4 == null;
											((UnityEngine.Object)gameObject4).SetName("_DARKICON");
											bool flag18 = (object)_darkIcon == null;
											RectTransform rectTransform = _darkIcon.rectTransform;
											bool flag19 = (object)rectTransform == null;
											bool flag20 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
											Transform.set_localScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref *(Vector3*)(&value));
											Image icon3 = _Icon;
											bool flag21 = (object)_Icon == null;
											nint num3 = (nint)icon3;
											_Icon.color = (Color)(&ret);
											bool flag22 = (object)_darkIcon == null;
											RectTransform rectTransform2 = _darkIcon.rectTransform;
											GameObject darkIcon2 = (GameObject)(object)_darkIcon;
											bool flag23 = (object)_darkIcon == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3624 @ rbx_v66 (UnityEngine.GameObject)+E0]");
											GameObject gameObject5 = (GameObject)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3624 @ rbx_v66 (UnityEngine.GameObject)+E0]");
											bool flag24 = (nint)0 == 0;
											bool flag25 = ((UnityEngine.Object)gameObject5).m_CachedPtr == (IntPtr)0;
											Sprite.get_rect_Injected(((UnityEngine.Object)gameObject5).m_CachedPtr, out *(Rect*)(&ret));
											GameObject darkIcon3 = (GameObject)(object)_darkIcon;
											bool flag26 = (object)_darkIcon == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3189 @ rbx_v68 (UnityEngine.GameObject)+E0]");
											GameObject gameObject6 = (GameObject)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3189 @ rbx_v68 (UnityEngine.GameObject)+E0]");
											bool flag27 = (nint)0 == 0;
											bool flag28 = ((UnityEngine.Object)gameObject6).m_CachedPtr == (IntPtr)0;
											Sprite.get_rect_Injected(((UnityEngine.Object)gameObject6).m_CachedPtr, out Rect _);
											bool flag29 = (object)rectTransform2 == null;
											bool flag30 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
											Vector2 value2 = default(Vector2);
											RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)rectTransform2).m_CachedPtr, ref value2);
											bool flag31 = (object)_darkIcon == null;
											RectTransform rectTransform3 = _darkIcon.rectTransform;
											float screenHeight = UIHelper.ScreenHeight;
											bool flag32 = (object)rectTransform3 == null;
											bool flag33 = ((UnityEngine.Object)rectTransform3).m_CachedPtr == (IntPtr)0;
											Vector2 value3 = default(Vector2);
											RectTransform.set_anchoredPosition_Injected(((UnityEngine.Object)rectTransform3).m_CachedPtr, ref value3);
											GameObject darkIcon4 = (GameObject)(object)_darkIcon;
											bool flag34 = (object)_darkIcon == null;
											bool flag35 = ((UnityEngine.Object)darkIcon4).m_CachedPtr == (IntPtr)0;
											IntPtr gcHandlePtr5 = Component.get_transform_Injected(((UnityEngine.Object)darkIcon4).m_CachedPtr);
											Transform target4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
											TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(target4, (Vector3)(&value), 0.2f);
											bool flag36 = _toCompleteOnSkip == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
											bool flag37 = (object)_darkIcon == null;
											RectTransform rectTransform4 = _darkIcon.rectTransform;
											TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore6 = DOTweenModuleUI.DOAnchorPosY(rectTransform4, 0f, 0.2f);
											TweenCallback tweenCallback2 = delegate
											{
												PlayGhosts();
												VFX.SetActive(value: true);
											};
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B5D0");
											bool flag38 = _toCompleteOnSkip == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
											object obj2 = default(object);
											if (obj2 != null)
											{
												_canSkip = true;
											}
											CreateBlackParticles();
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
		goto IL_13c9;
		IL_13c9:
		throw new NullReferenceException();
		IL_0db9:
		tweenCallback = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r10_v38 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback).method = (nint)__ldftn(CharacterFoundPage._003COnShowStart_003Eb__42_2);
		((Delegate)tweenCallback).m_target = this;
		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r10_v38 (Il2CppMethodInfo)+4C]");
		object obj3 = (nint)0 >> 4;
		object obj4 = obj3 & 1;
		nint num5;
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r10_v38 (Il2CppMethodInfo)+52]");
			bool flag39 = (nint)0 == 0;
			num5 = unchecked((nint)6447293664L);
			if (flag39)
			{
				goto IL_172c;
			}
		}
		num5 = ((Delegate)tweenCallback).method_ptr;
		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
		goto IL_172c;
		IL_1462:
		bool flag40 = (object)_Name == null;
		toCompleteOnSkip = (Component)(object)"lang/charFound_joins";
		if (!flag40)
		{
			nint num6 = (nint)gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3309 @ rax_v136 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
			GameObject gameObject7 = (GameObject)(object)_Name;
			bool flag41 = (object)_Name == null;
			toCompleteOnSkip = _Name;
			if (!flag41)
			{
				nint num7 = (nint)gameObject7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3311 @ rdx_v97 (Il2CppClass<UnityEngine.GameObject>)+548] (should have been resolved before IL gen)");
				string text3 = default(string);
				bool flag42 = text3 == null;
				toCompleteOnSkip = _Name;
				if (!flag42)
				{
					string text4 = text3.Replace("\\n", "<br>");
					nint num8 = (nint)gameObject7;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v300 @ r9_v45 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
					Component component5 = _Name;
					bool flag43 = (object)_Name == null;
					toCompleteOnSkip = _Name;
					if (!flag43)
					{
						nint num9 = (nint)component5;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3463 @ rdx_v101 (Il2CppClass<UnityEngine.Component>)+548] (should have been resolved before IL gen)");
						bool flag44 = _unlockedCharacterData == null;
						toCompleteOnSkip = (Component)(object)_unlockedCharacterData;
						if (!flag44)
						{
							string fullName = _unlockedCharacterData.GetFullName(_unlockedCharacterType, ignoreSkinPrefixSuffix: true);
							GameObject gameObject8 = default(GameObject);
							bool flag45 = (object)gameObject8 == null;
							toCompleteOnSkip = (Component)(object)_unlockedCharacterData;
							if (!flag45)
							{
								string text5 = ((string)(object)gameObject8).Replace("%0", fullName);
								nint num10 = (nint)component5;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v302 @ r9_v48 (Il2CppClass<UnityEngine.Component>)+558] (should have been resolved before IL gen)");
								CharacterData unlockedCharacterData = _unlockedCharacterData;
								bool flag46 = _unlockedCharacterData == null;
								toCompleteOnSkip = _Name;
								if (!flag46)
								{
									Sprite sprite = SpriteManager.GetSprite(unlockedCharacterData._003CspriteName_003Ek__BackingField, unlockedCharacterData._003CtextureName_003Ek__BackingField);
									bool flag47 = (object)_Icon == null;
									toCompleteOnSkip = (Component)(object)unlockedCharacterData._003CspriteName_003Ek__BackingField;
									if (!flag47)
									{
										_Icon.sprite = sprite;
										GameObject thankYouText = (GameObject)(object)_ThankYouText;
										if (_unlockedCharacterType != CharacterType.TP_DRACULA)
										{
											string translation = LocalizationManager.GetTranslation("lang/charFound_another", FixForRTL: true, 0, ignoreRTLnumbers: true, flag6, (GameObject)flag7, (string)(object)gameObject2, (byte)(int)text != 0);
											bool flag48 = (object)_ThankYouText == null;
											toCompleteOnSkip = (Component)(object)"lang/charFound_another";
											if (!flag48)
											{
												nint num11 = (nint)thankYouText;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v305 @ r9_v76 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
												Component thankYouText2 = _ThankYouText;
												bool flag49 = (object)_ThankYouText == null;
												toCompleteOnSkip = _ThankYouText;
												if (!flag49)
												{
													nint num12 = (nint)thankYouText2;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4128 @ rdx_v185 (Il2CppClass<UnityEngine.Component>)+548] (should have been resolved before IL gen)");
													toCompleteOnSkip = _currentCharacter;
													if ((object)_currentCharacter != null)
													{
														VampireSurvivors.Objects.Characters.CharacterController currentCharacter = _currentCharacter;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v84 (UnityEngine.Component)+110]");
														bool flag50 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v84 (UnityEngine.Component)+110]");
														toCompleteOnSkip = (Component)0;
														if (!flag50)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v84 (UnityEngine.Component)+110]");
															string fullName2 = ((CharacterData)0).GetFullName(currentCharacter._characterType, ignoreSkinPrefixSuffix: true);
															GameObject gameObject9 = default(GameObject);
															bool flag51 = (object)gameObject9 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v84 (UnityEngine.Component)+110]");
															toCompleteOnSkip = (Component)0;
															if (!flag51)
															{
																string text6 = ((string)(object)gameObject9).Replace("%0", fullName2);
																nint num13 = (nint)thankYouText2;
																GameObject thankYouText3 = (GameObject)(object)_ThankYouText;
																goto IL_148a;
															}
														}
													}
												}
											}
										}
										else
										{
											string text6 = LocalizationManager.GetTranslation("lang/TP_Dialog_110", FixForRTL: true, 0, ignoreRTLnumbers: true, flag6, (GameObject)flag7, (string)(object)gameObject2, (byte)(int)text != 0);
											bool flag52 = (object)_ThankYouText == null;
											toCompleteOnSkip = (Component)(object)"lang/TP_Dialog_110";
											if (!flag52)
											{
												nint num13 = (nint)thankYouText;
												GameObject thankYouText3 = (GameObject)(object)_ThankYouText;
												goto IL_148a;
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
		goto IL_13c9;
		IL_15f3:
		object obj5 = 24;
		object obj6 = 24;
		TweenCallback tweenCallback3;
		((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore7;
		if (tweenerCore7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4712 @ rax_v198 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		TweenCallback tweenCallback4 = _003C_003Ec._003C_003E9__42_1;
		if (_003C_003Ec._003C_003E9__42_1 == null)
		{
			tweenCallback4 = (_003C_003Ec._003C_003E9__42_1 = delegate
			{
			});
			bool flag53 = false;
		}
		if (tweenerCore7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4712 @ rax_v198 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		sequence = DOTween.Sequence();
		float num14 = ((_unlockedCharacterType != CharacterType.TP_DRACULA) ? 7.5f : 12.5f);
		object message2;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					_ = ((Tween)sequence).duration;
					float num15 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5066 @ rax_v211 (DG.Tweening.Sequence)+A0]");
					num14 = num15 + 0f;
					goto IL_0db9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message2);
		goto IL_0db9;
		IL_148a:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v308 @ r9_v50 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
		toCompleteOnSkip = _Name;
		if ((object)_Name != null)
		{
			nint num16 = (nint)toCompleteOnSkip;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4149 @ rax_v153 (Il2CppClass<UnityEngine.Component>)+2D8] (should have been resolved before IL gen)");
			toCompleteOnSkip = _Name;
			if ((object)_Name != null)
			{
				nint num17 = (nint)toCompleteOnSkip;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4222 @ rax_v155 (Il2CppClass<UnityEngine.Component>)+2F8] (should have been resolved before IL gen)");
				toCompleteOnSkip = _Name;
				if ((object)_Name != null)
				{
					nint num18 = (nint)toCompleteOnSkip;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4223 @ rax_v157 (Il2CppClass<UnityEngine.Component>)+808] (should have been resolved before IL gen)");
					toCompleteOnSkip = _Name;
					if ((object)_Name != null)
					{
						nint num19 = (nint)toCompleteOnSkip;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4298 @ rax_v159 (Il2CppClass<UnityEngine.Component>)+7D8] (should have been resolved before IL gen)");
						toCompleteOnSkip = _Icon;
						if ((object)_Icon != null)
						{
							nint num20 = (nint)toCompleteOnSkip;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4299 @ rax_v161 (Il2CppClass<UnityEngine.Component>)+2A8] (should have been resolved before IL gen)");
							bool flag54 = (object)_Name == null;
							toCompleteOnSkip = _Name;
							if (!flag54)
							{
								Transform transform5 = _Name.transform;
								Vector3 vector2 = default(Vector3);
								transform5.localScale = (Vector3)(&vector2);
								_DoneButton.SetActive(value: false);
								RectTransform rectTransform5 = _Icon.rectTransform;
								Image icon4 = _Icon;
								Rect rect = icon4.m_Sprite.rect;
								toCompleteOnSkip = (Component)(&ret);
								Image icon5 = _Icon;
								if ((object)_Icon != null && (object)icon5.m_Sprite != null)
								{
									Rect rect2 = icon5.m_Sprite.rect;
									bool flag55 = ((UnityEngine.Object)rectTransform5).m_CachedPtr == (IntPtr)0;
									Vector2 value4 = default(Vector2);
									RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)rectTransform5).m_CachedPtr, ref value4);
									GameObject icon6 = (GameObject)(object)_Icon;
									bool flag56 = ((UnityEngine.Object)icon6).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr6 = Component.get_transform_Injected(((UnityEngine.Object)icon6).m_CachedPtr);
									Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
									bool flag57 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
									Vector2 value5 = default(Vector2);
									Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)(&value5));
									TweenerCore<Color, Color, ColorOptions> tweenerCore8 = DOTweenModuleUI.DOFade(_BGFader, 0.9f, 0.3f);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
									if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
									{
										_canSkip = true;
									}
									TweenerCore<Vector2, Vector2, VectorOptions> t = DOTweenModuleUI.DOAnchorPos(_TextPanel, vector, 0.15f);
									tweenerCore7 = TweenSettingsExtensions.SetDelay(t, 4f);
									tweenCallback3 = null;
									nint num21 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4716 @ r10_v37 (Il2CppMethodInfo)+8]");
									((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
									((Delegate)tweenCallback3).method = (nint)__ldftn(CharacterFoundPage._003COnShowStart_003Eb__42_0);
									((Delegate)tweenCallback3).m_target = this;
									bool flag53 = false;
									((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4716 @ r10_v37 (Il2CppMethodInfo)+4C]");
									object obj7 = (nint)0 >> 4;
									object obj8 = obj7 & 1;
									nint num22;
									if (obj8 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4716 @ r10_v37 (Il2CppMethodInfo)+52]");
										if ((nint)0 == 0)
										{
											num22 = unchecked((nint)6447293664L);
											goto IL_15f3;
										}
									}
									((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
									num22 = ((Delegate)tweenCallback3).method_ptr;
									goto IL_15f3;
								}
							}
						}
					}
				}
			}
		}
		goto IL_13c9;
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		return _currentCharacter;
	}

	private void Skip()
	{
		//IL_0018: Expected I, but got O
		//IL_0114: Expected I, but got O
		//IL_0143: Expected I, but got O
		//IL_01c2: Expected I, but got O
		//IL_01f1: Expected I, but got O
		//IL_022d: Expected I, but got O
		//IL_02a7: Expected I, but got O
		//IL_02d6: Expected I, but got O
		//IL_0312: Expected I, but got O
		//IL_0344: Expected I, but got O
		//IL_0369: Expected I, but got O
		nint num = (nint)typeof(AdventureManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v5 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager>)+B8]");
		nint num2 = 0;
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField || !_canSkip)
		{
			return;
		}
		if (_toCompleteOnSkip != null)
		{
			List<Tween>.Enumerator enumerator = default(List<Tween>.Enumerator);
			while (enumerator.MoveNext())
			{
				DG.Tweening.TweenExtensions.Complete(null, withCallbacks: false);
			}
			if (_openCoffinSoundResult != null)
			{
				PlaySoundResult openCoffinSoundResult = _openCoffinSoundResult;
				SoundGroupVariation soundGroupVariation = openCoffinSoundResult._003CActingVariation_003Ek__BackingField;
				if ((object)openCoffinSoundResult._003CActingVariation_003Ek__BackingField != null && ((UnityEngine.Object)soundGroupVariation).m_CachedPtr != (IntPtr)0)
				{
					PlaySoundResult openCoffinSoundResult2 = _openCoffinSoundResult;
					bool flag = _openCoffinSoundResult == null;
					num2 = (nint)typeof(UnityEngine.Object);
					if (!flag)
					{
						bool flag2 = (object)openCoffinSoundResult2._003CActingVariation_003Ek__BackingField == null;
						num2 = (nint)openCoffinSoundResult2._003CActingVariation_003Ek__BackingField;
						if (!flag2)
						{
							AudioSource varAudio = openCoffinSoundResult2._003CActingVariation_003Ek__BackingField.VarAudio;
							if ((object)varAudio == null || ((UnityEngine.Object)varAudio).m_CachedPtr == (IntPtr)0)
							{
								goto IL_044d;
							}
							PlaySoundResult openCoffinSoundResult3 = _openCoffinSoundResult;
							bool flag3 = _openCoffinSoundResult == null;
							num2 = (nint)typeof(UnityEngine.Object);
							if (!flag3)
							{
								bool flag4 = (object)openCoffinSoundResult3._003CActingVariation_003Ek__BackingField == null;
								num2 = (nint)openCoffinSoundResult3._003CActingVariation_003Ek__BackingField;
								if (!flag4)
								{
									AudioSource varAudio2 = openCoffinSoundResult3._003CActingVariation_003Ek__BackingField.VarAudio;
									bool flag5 = (object)varAudio2 == null;
									num2 = (nint)openCoffinSoundResult3._003CActingVariation_003Ek__BackingField;
									if (!flag5)
									{
										AudioClip clip = varAudio2.clip;
										if ((object)clip == null || ((UnityEngine.Object)clip).m_CachedPtr == (IntPtr)0)
										{
											goto IL_044d;
										}
										PlaySoundResult openCoffinSoundResult4 = _openCoffinSoundResult;
										bool flag6 = _openCoffinSoundResult == null;
										num2 = (nint)typeof(UnityEngine.Object);
										if (!flag6)
										{
											bool flag7 = (object)openCoffinSoundResult4._003CActingVariation_003Ek__BackingField == null;
											num2 = (nint)openCoffinSoundResult4._003CActingVariation_003Ek__BackingField;
											if (!flag7)
											{
												AudioSource varAudio3 = openCoffinSoundResult4._003CActingVariation_003Ek__BackingField.VarAudio;
												bool flag8 = (object)varAudio3 == null;
												num2 = (nint)openCoffinSoundResult4._003CActingVariation_003Ek__BackingField;
												if (!flag8)
												{
													AudioClip clip2 = varAudio3.clip;
													bool flag9 = (object)clip2 == null;
													num2 = (nint)varAudio3;
													if (!flag9)
													{
														float length = clip2.length;
														num2 = (nint)_openCoffinSoundResult;
														if (_openCoffinSoundResult != null)
														{
															SoundGroupVariation markerInitDataManager = (SoundGroupVariation)AdventureManager.MarkerInitDataManager;
															if ((object)AdventureManager.MarkerInitDataManager != null)
															{
																SoundGroupVariation.PlaySoundParams playSndParam = markerInitDataManager._playSndParam;
																if (markerInitDataManager._playSndParam != null)
																{
																	if (playSndParam.IsPlaying)
																	{
																		AudioSource varAudio4 = ((SoundGroupVariation)AdventureManager.MarkerInitDataManager).VarAudio;
																		if ((object)varAudio4 == null)
																		{
																			goto IL_045d;
																		}
																		float time = length - 2f;
																		varAudio4.time = time;
																	}
																	goto IL_044d;
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
					goto IL_045d;
				}
			}
			goto IL_044d;
		}
		goto IL_045d;
		IL_045d:
		throw new NullReferenceException();
		IL_044d:
		_canSkip = false;
	}

	protected override void OnHideFinish(GameObject g)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0147: Expected F4, but got I4
		//IL_0139: Expected F4, but got I4
		//IL_0398: Expected I4, but got O
		//IL_0444: Expected I4, but got O
		//IL_0541: Expected I4, but got O
		//IL_0682->IL0769: Incompatible stack heights: 1 vs 0
		//IL_06e7->IL078f: Incompatible stack heights: 1 vs 0
		base.OnHideFinish(g);
		Type type;
		bool flag = default(bool);
		float t;
		if (_signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			type = null;
			Type signalType = default(Type);
			_signalBus.InternalFire(signalType, (object)null, (object)null, flag);
			FireworksManager.Clear();
			ParticleSystem darkParticles = _darkParticles;
			if ((object)_darkParticles == null || ((UnityEngine.Object)darkParticles).m_CachedPtr == (IntPtr)0)
			{
				t = 0f;
				goto IL_060e;
			}
			if ((object)_darkParticles != null)
			{
				Transform transform = _darkParticles.transform;
				if ((object)transform != null)
				{
					Transform parent = transform.parent;
					if ((object)parent != null)
					{
						GameObject obj3 = parent.gameObject;
						UnityEngine.Object.Destroy(obj3, 0f);
						t = 0f;
						goto IL_060e;
					}
				}
			}
		}
		goto IL_0588;
		IL_021c:
		if ((object)_ThankYouTextPanel != null)
		{
			RectTransform component = _ThankYouTextPanel.GetComponent<RectTransform>();
			float screenWidth = UIHelper.ScreenWidth;
			if ((object)_ThankYouTextPanel != null)
			{
				RectTransform component2 = _ThankYouTextPanel.GetComponent<RectTransform>();
				if ((object)component2 != null)
				{
					Vector2 sizeDelta = component2.sizeDelta;
					if ((object)_ThankYouTextPanel != null)
					{
						RectTransform component3 = _ThankYouTextPanel.GetComponent<RectTransform>();
						if ((object)component3 != null)
						{
							Vector2 anchoredPosition = component3.anchoredPosition;
							if ((object)component != null)
							{
								Vector2 anchoredPosition2 = default(Vector2);
								component.anchoredPosition = anchoredPosition2;
								if (_rays != null)
								{
									List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
									while (enumerator.MoveNext())
									{
										object obj4 = null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rdi_v13 (System.Object)+10]");
										bool flag2 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rdi_v13 (System.Object)+10]");
										GameObject.SetActive_Injected((IntPtr)0, false);
									}
									List<GameObject> rays = _rays;
									if (_rays != null)
									{
										int version = rays._version + 1;
										rays._version = version;
										rays._size = (int)type;
										if (rays._size > 0)
										{
											Array.Clear(rays._items, 0, rays._size);
										}
										if (_ghosts != null)
										{
											List<Image>.Enumerator enumerator2 = default(List<Image>.Enumerator);
											while (enumerator2.MoveNext())
											{
												object obj5 = null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rdi_v12 (System.Object)+10]");
												bool flag3 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rdi_v12 (System.Object)+10]");
												Behaviour.set_enabled_Injected((IntPtr)0, false);
											}
											List<Image> ghosts = _ghosts;
											if (_ghosts != null)
											{
												int version2 = ghosts._version + 1;
												ghosts._version = version2;
												ghosts._size = (int)type;
												if (ghosts._size > 0)
												{
													Array.Clear(ghosts._items, 0, ghosts._size);
												}
												if (_rays != null)
												{
													List<GameObject>.Enumerator enumerator3 = default(List<GameObject>.Enumerator);
													while (enumerator3.MoveNext())
													{
														flag = flag;
														UnityEngine.Object.Destroy(null, t);
													}
													List<GameObject> rays2 = _rays;
													if (_rays != null)
													{
														int version3 = rays2._version + 1;
														rays2._version = version3;
														rays2._size = (int)type;
														if (rays2._size > 0)
														{
															Array.Clear(rays2._items, 0, rays2._size);
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
					}
				}
			}
		}
		goto IL_0588;
		IL_0588:
		throw new NullReferenceException();
		IL_060e:
		ParticleSystem colorParticles = _colorParticles;
		if ((object)_colorParticles == null || ((UnityEngine.Object)colorParticles).m_CachedPtr == (IntPtr)0)
		{
			goto IL_021c;
		}
		if ((object)_colorParticles != null)
		{
			Transform transform2 = _colorParticles.transform;
			if ((object)transform2 != null)
			{
				Transform parent2 = transform2.parent;
				if ((object)parent2 != null)
				{
					GameObject obj6 = parent2.gameObject;
					UnityEngine.Object.Destroy(obj6, 0f);
					goto IL_021c;
				}
			}
		}
		goto IL_0588;
	}

	private unsafe void EnableDoneButton()
	{
		//IL_00a1: Expected O, but got Ref
		//IL_0242: Expected O, but got Ref
		//IL_013c: Expected O, but got I4
		//IL_0170: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		//IL_0260->IL01cb: Incompatible stack heights: 1 vs 0
		//IL_00de->IL01cb: Incompatible stack heights: 1 vs 0
		//IL_01b7->IL01cb: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL01f5: Incompatible stack heights: 1 vs 0
		if (!IsLocalPlayerControllingUi())
		{
			return;
		}
		Debug.Log("Enabling button");
		if ((object)_DoneButton != null)
		{
			_DoneButton.SetActive(value: true);
			if ((object)_DoneButton != null)
			{
				Transform transform = _DoneButton.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform transform2 = _DoneButton.transform;
				object obj = default(object);
				transform2.localEulerAngles = (Vector3)(&obj);
				Transform target = _DoneButton.transform;
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj), 0.15f);
				if (_tweens != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
					if ((object)_DoneButton != null)
					{
						Transform target2 = _DoneButton.transform;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, 1f, 0.15f);
						TweenCallback tweenCallback = delegate
						{
							Selectable component = _DoneButton.GetComponent<Selectable>();
							component.Select();
						};
						bool flag2 = tweenerCore2 == null;
						object obj2 = 0;
						nint num = 0;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							bool flag3 = (nint)0 == 0;
							obj2 = 0;
							num = 0;
							if (!flag3)
							{
								obj2 = 0;
								num = 0;
							}
						}
						if (_tweens != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void CreateBlackParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03fa: Expected O, but got Ref
		//IL_040f: Expected native int or pointer, but got O
		//IL_0429: Expected O, but got I
		//IL_0474: Expected O, but got Ref
		//IL_0483: Expected O, but got I4
		//IL_0490: Expected native int or pointer, but got O
		//IL_04af: Expected O, but got I
		//IL_04d5: Expected O, but got I4
		//IL_04ee: Expected O, but got Ref
		//IL_0526: Expected native int or pointer, but got O
		//IL_07aa: Expected O, but got I
		//IL_056e: Expected O, but got Ref
		//IL_0587: Expected native int or pointer, but got O
		//IL_07e4: Expected O, but got I
		//IL_083a: Expected O, but got Ref
		//IL_084f: Expected O, but got I
		//IL_0870: Expected O, but got I
		//IL_088a: Expected native int or pointer, but got O
		//IL_08a4: Expected O, but got I
		//IL_05d7: Expected O, but got I
		//IL_08e6: Expected I, but got O
		//IL_0a2b: Expected O, but got I
		//IL_0900: Expected O, but got Ref
		//IL_0918: Expected O, but got Ref
		//IL_0932: Expected native int or pointer, but got O
		//IL_0945: Expected O, but got Ref
		//IL_0952: Expected O, but got Ref
		//IL_0962: Expected O, but got I
		//IL_0998: Expected O, but got Ref
		//IL_0a63: Expected O, but got I
		//IL_0a08: Expected I, but got O
		//IL_06be->IL08f2: Incompatible stack heights: 2 vs 1
		//IL_09d2->IL075b: Incompatible stack heights: 1 vs 0
		//IL_06eb->IL098a: Incompatible stack heights: 2 vs 1
		//IL_074c->IL075b: Incompatible stack heights: 1 vs 0
		//IL_0718->IL09ae: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float particleScaleFactor = UICamera.ParticleScaleFactor;
		float num = particleScaleFactor * 0.65f;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
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
					((List<object>)(object)list).AddWithResize((object)"PfxGreen.png");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
					}
					else
					{
						int size2 = list._size + 1;
						list._size = size2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items3 = list._items;
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"PfxBlue.png");
						}
						else
						{
							int size3 = list._size + 1;
							list._size = size3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						string[] items4 = list._items;
						if (list._items != null)
						{
							if (list._size >= items4.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"PfxColor1.png");
							}
							else
							{
								int size4 = list._size + 1;
								list._size = size4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version5 = list._version + 1;
							list._version = version5;
							string[] items5 = list._items;
							if (list._items != null)
							{
								if (list._size >= items5.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"PfxColor2.png");
								}
								else
								{
									int size5 = list._size + 1;
									list._size = size5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								if (particleSystemConfig != null)
								{
									particleSystemConfig._frame = list;
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
									particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
									_ = 0;
									Camera main = Camera.main;
									Bounds bounds = CameraExtensions.OrthographicBounds(main);
									object obj3 = default(object);
									float max = (float)obj3 * 2f;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
									_ = 0;
									obj = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, max));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
									particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
									ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(1000f);
									particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
									float max2 = num * -600f;
									float min = num * -300f;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(min, max2));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
									particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
									_ = 0;
									float min2 = num * 4f;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(min2, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
									particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
									_ = 0;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rax+14h]\"");
									object obj4 = (object)minMaxCurve5 << 3;
									ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
									particleSystemConfig._quantity = (int?)(object)0;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
									particleSystemConfig._tint = (uint?)(object)0;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
									particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
									_ = 0;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
									particleSystemConfig._blendMode = (BlendMode?)(object)0;
									particleSystemConfig._on = true;
									if ((object)_Particles != null)
									{
										Transform transform = _Particles.transform;
										Transform parent = default(Transform);
										string psName = default(string);
										bool isAdditive = default(bool);
										bool requiresMasking = default(bool);
										ParticleSystem darkParticles = _Particles.CreateUIEmitter(particleSystemConfig, "UI", 0, parent, psName, isAdditive, requiresMasking);
										_darkParticles = darkParticles;
										if ((object)_darkParticles != null)
										{
											Transform transform2 = _darkParticles.transform;
											bool flag = (object)((ParticleSystemConfig)(object)transform2)._x == null;
											Vector3 value = default(Vector3);
											Transform.set_localPosition_Injected((IntPtr)((ParticleSystemConfig)(object)transform2)._x, ref value);
											_ = _darkParticles;
											_ = _darkParticles;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
											object obj5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												bool flag2 = obj5 == null;
											}
											object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1854 @ rax_v75 (should have been resolved before IL gen)");
											ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
											ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
											((ParticleSystem.RotationOverLifetimeModule*)rotationOverLifetimeModule)->z = (ParticleSystem.MinMaxCurve)(&value);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
											object obj7 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												bool flag3 = obj7 == null;
											}
											object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1885 @ rax_v80 (should have been resolved before IL gen)");
											_ = _darkParticles;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
											object obj9 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												bool flag4 = obj9 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1973 @ rax_v84 (should have been resolved before IL gen)");
											if ((object)_darkParticles != null)
											{
												_darkParticles.Play(withChildren: true);
												List<string> darkParticles2 = (List<string>)(object)_darkParticles;
												if ((object)_darkParticles != null)
												{
													bool flag5 = darkParticles2._items == null;
													ParticleSystem.Pause_Injected((IntPtr)darkParticles2._items, true);
													_playDarkParticles = true;
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
		throw new NullReferenceException();
	}

	protected override void OnCancelPressed()
	{
		Skip();
	}

	private unsafe void MakeColorParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03fa: Expected O, but got Ref
		//IL_040f: Expected native int or pointer, but got O
		//IL_0429: Expected O, but got I
		//IL_0474: Expected O, but got Ref
		//IL_048d: Expected native int or pointer, but got O
		//IL_04ac: Expected O, but got I
		//IL_04da: Expected O, but got I4
		//IL_04f3: Expected O, but got Ref
		//IL_052b: Expected native int or pointer, but got O
		//IL_079a: Expected O, but got I4
		//IL_056d: Expected O, but got Ref
		//IL_0586: Expected native int or pointer, but got O
		//IL_07d4: Expected O, but got I
		//IL_082a: Expected O, but got Ref
		//IL_083f: Expected O, but got I
		//IL_0866: Expected O, but got I
		//IL_0880: Expected native int or pointer, but got O
		//IL_089a: Expected O, but got I
		//IL_05dc: Expected O, but got I
		//IL_08dd: Expected I, but got O
		//IL_0913: Expected O, but got I
		//IL_09d5: Expected O, but got Ref
		//IL_09ed: Expected O, but got Ref
		//IL_0a07: Expected native int or pointer, but got O
		//IL_0a1a: Expected O, but got Ref
		//IL_0a27: Expected O, but got Ref
		//IL_0a37: Expected O, but got I
		//IL_0949: Expected O, but got Ref
		//IL_0a6f: Expected O, but got I
		//IL_09c6: Expected I, but got O
		//IL_08f7->IL0758: Incompatible stack heights: 1 vs 0
		//IL_06f4->IL09c7: Incompatible stack heights: 2 vs 1
		//IL_0721->IL093b: Incompatible stack heights: 2 vs 1
		//IL_074e->IL095f: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float particleScaleFactor = UICamera.ParticleScaleFactor;
		float num = particleScaleFactor * 0.65f;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
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
					((List<object>)(object)list).AddWithResize((object)"PfxGreen.png");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
					}
					else
					{
						int size2 = list._size + 1;
						list._size = size2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items3 = list._items;
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"PfxBlue.png");
						}
						else
						{
							int size3 = list._size + 1;
							list._size = size3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						string[] items4 = list._items;
						if (list._items != null)
						{
							if (list._size >= items4.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"PfxColor1.png");
							}
							else
							{
								int size4 = list._size + 1;
								list._size = size4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version5 = list._version + 1;
							list._version = version5;
							string[] items5 = list._items;
							if (list._items != null)
							{
								if (list._size >= items5.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"PfxColor2.png");
								}
								else
								{
									int size5 = list._size + 1;
									list._size = size5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								if (particleSystemConfig != null)
								{
									particleSystemConfig._frame = list;
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
									particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
									_ = 0;
									Camera main = Camera.main;
									Bounds bounds = CameraExtensions.OrthographicBounds(main);
									object obj3 = default(object);
									float max = (float)obj3 * 2f;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, max));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
									particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(1000f);
									particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
									float max2 = num * -600f;
									float min = num * -300f;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(min, max2));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
									_ = 0;
									particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
									_ = 0;
									float min2 = num * 4f;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(min2, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
									particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
									_ = 0;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rax+14h]\"");
									object obj4 = (object)minMaxCurve5 << 3;
									ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
									particleSystemConfig._quantity = (int?)(object)0;
									_ = 0;
									_ = 16777215;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
									particleSystemConfig._tint = (uint?)(object)0;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
									particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
									_ = 0;
									_ = 0;
									_ = 1;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
									particleSystemConfig._blendMode = (BlendMode?)(object)0;
									particleSystemConfig._on = true;
									if ((object)_Particles != null)
									{
										Transform transform = _Particles.transform;
										Transform parent = default(Transform);
										string psName = default(string);
										bool isAdditive = default(bool);
										bool requiresMasking = default(bool);
										ParticleSystem colorParticles = _Particles.CreateUIEmitter(particleSystemConfig, "UI", 0, parent, psName, isAdditive, requiresMasking);
										_colorParticles = colorParticles;
										if ((object)_colorParticles != null)
										{
											_colorParticles.Play(withChildren: true);
											List<string> colorParticles2 = (List<string>)(object)_colorParticles;
											if ((object)_colorParticles != null)
											{
												bool flag = colorParticles2._items == null;
												ParticleSystem.Pause_Injected((IntPtr)colorParticles2._items, true);
												if ((object)_colorParticles != null)
												{
													_ = _colorParticles;
													_ = _colorParticles;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
													object obj5 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
														bool flag2 = obj5 == null;
													}
													object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1837 @ rax_v72 (should have been resolved before IL gen)");
													ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
													ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
													((ParticleSystem.RotationOverLifetimeModule*)rotationOverLifetimeModule)->z = (ParticleSystem.MinMaxCurve)(&minMaxCurve3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
													object obj7 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
														bool flag3 = obj7 == null;
													}
													object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1868 @ rax_v77 (should have been resolved before IL gen)");
													_ = _colorParticles;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
													object obj9 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
														bool flag4 = obj9 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1957 @ rax_v82 (should have been resolved before IL gen)");
													Transform transform2 = _colorParticles.transform;
													bool flag5 = (object)transform2 == null;
													bool flag6 = ((List<string>)(object)transform2)._items == null;
													Vector3 value = default(Vector3);
													Transform.set_localPosition_Injected((IntPtr)((List<string>)(object)transform2)._items, ref value);
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
		throw new NullReferenceException();
	}

	private unsafe void EnableOkButton()
	{
		//IL_00a1: Expected O, but got Ref
		//IL_0242: Expected O, but got Ref
		//IL_013c: Expected O, but got I4
		//IL_0170: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		//IL_0260->IL01cb: Incompatible stack heights: 1 vs 0
		//IL_00de->IL01cb: Incompatible stack heights: 1 vs 0
		//IL_01b7->IL01cb: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL01f5: Incompatible stack heights: 1 vs 0
		if (!IsLocalPlayerControllingUi())
		{
			return;
		}
		Debug.Log("Enabling button");
		if ((object)_OkButton != null)
		{
			_OkButton.SetActive(value: true);
			if ((object)_OkButton != null)
			{
				Transform transform = _OkButton.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform transform2 = _OkButton.transform;
				object obj = default(object);
				transform2.localEulerAngles = (Vector3)(&obj);
				Transform target = _OkButton.transform;
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj), 0.15f);
				if (_tweens != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
					if ((object)_OkButton != null)
					{
						Transform target2 = _OkButton.transform;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, 1f, 0.15f);
						TweenCallback tweenCallback = delegate
						{
							Selectable component = _OkButton.GetComponent<Selectable>();
							component.Select();
						};
						bool flag2 = tweenerCore2 == null;
						object obj2 = 0;
						nint num = 0;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							bool flag3 = (nint)0 == 0;
							obj2 = 0;
							num = 0;
							if (!flag3)
							{
								obj2 = 0;
								num = 0;
							}
						}
						if (_tweens != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void DisableOkButton()
	{
		//IL_003d: Expected O, but got I8
		//IL_0173: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_0214: Expected O, but got Ref
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_03d2: Expected O, but got I4
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_0132: Expected O, but got I4
		Transform target = _OkButton.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0f, 0.15f);
		object obj = 6603577472L;
		nint num3;
		object obj9;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r14_v2+462E0+v347 @ rdx_v26*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r14_v2+462E0+v347 @ rdx_v26*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r14_v2+462E0+v347 @ rdx_v26*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r14_v2+462E0+v347 @ rdx_v26*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r14_v2+462E0+v347 @ rdx_v26*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = delegate
					{
						if ((object)_OkButton != null)
						{
							_OkButton.SetActive(value: false);
							return;
						}
						throw new NullReferenceException();
					};
					tweenCallback2 = tweenCallback;
					num3 = 0;
					obj9 = 0;
					goto IL_0190;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			if ((object)_OkButton != null)
			{
				_OkButton.SetActive(value: false);
				return;
			}
			throw new NullReferenceException();
		};
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		num3 = 0;
		obj9 = 0;
		nint num4 = 0;
		object obj10 = 0;
		if (!flag2)
		{
			goto IL_0190;
		}
		goto IL_01df;
		IL_01df:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
		Transform target2 = _OkButton.transform;
		object obj11 = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj11), 0.15f, RotateMode.LocalAxisAdd);
		bool flag3 = tweenerCore2 == null;
		RotateMode rotateMode = RotateMode.LocalAxisAdd;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			bool flag4 = (nint)0 == 0;
			rotateMode = RotateMode.LocalAxisAdd;
			if (!flag4)
			{
				_ = 1;
				_ = 0;
				rotateMode = RotateMode.LocalAxisAdd;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
		RectTransform component = _ThankYouTextPanel.GetComponent<RectTransform>();
		float screenWidth = UIHelper.ScreenWidth;
		RectTransform component2 = _ThankYouTextPanel.GetComponent<RectTransform>();
		Vector2 sizeDelta = component2.sizeDelta;
		float num5 = screenWidth * 0.5f;
		float endValue = num5 + (float)sizeDelta;
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore3 = DOTweenModuleUI.DOAnchorPosX(component, endValue, 0.15f);
		bool flag5 = tweenerCore3 == null;
		bool flag6 = false;
		if (!flag5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			bool flag7 = (nint)0 == 0;
			flag6 = false;
			if (!flag7)
			{
				_ = 1;
				_ = 0;
				flag6 = false;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
		return;
		IL_0190:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		bool flag8 = (nint)0 == 0;
		num4 = num3;
		obj10 = obj9;
		if (!flag8)
		{
			num4 = num3;
			obj10 = obj9;
		}
		goto IL_01df;
	}

	private unsafe void SaveCharacterData(GameplaySignals.CharacterFoundSignal sig)
	{
		//IL_0037: Expected O, but got Ref
		//IL_00c4: Expected O, but got I
		//IL_00db: Expected O, but got I
		CharacterType characterType = default(CharacterType);
		object arg = characterType;
		object arg2 = characterType;
		System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Unlocking {0}, found by {1}", (System.ParamsArray)(&obj));
		Debug.Log(message);
		_unlockedCharacterType = sig.FoundCharacter;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)sig.FoundCharacter);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v17 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v17 (System.Object)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v18+20]");
			_unlockedCharacterData = (CharacterData)0;
			_currentCharacter = sig.ControllingCharacter;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private unsafe void PlayGhosts()
	{
		//IL_01ad: Expected O, but got Ref
		//IL_02b3: Expected O, but got I
		//IL_0330: Expected O, but got I
		//IL_0462: Expected O, but got I
		//IL_04dc: Expected O, but got I
		//IL_00bc->IL06c4: Incompatible stack heights: 2 vs 0
		//IL_0610->IL0998: Incompatible stack heights: 13 vs 0
		List<Image> ghosts = _ghosts;
		List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
		float optionalFloat = default(float);
		object optionalObj = default(object);
		object[] optionalArray = default(object[]);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rdi_v26 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rdi_v26 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
			GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			if ((object)gameObject != null)
			{
				int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)gameObject, false, optionalFloat, optionalObj, optionalArray);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rdi_v26 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rdi_v26 (System.Object)+10]");
			IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
			GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
			UnityEngine.Object.Destroy(obj2, 0f);
		}
		CharacterFoundPage characterFoundPage = default(CharacterFoundPage);
		List<Image> ghosts2 = characterFoundPage._ghosts;
		int version = ghosts2._version + 1;
		ghosts2._version = version;
		ghosts2._size = 0;
		if (ghosts2._size > 0)
		{
			Array.Clear(ghosts2._items, 0, ghosts2._size);
		}
		int num2 = 0;
		List<Image>.Enumerator ghosts3 = (List<Image>.Enumerator)_ghosts;
		CharacterFoundPage characterFoundPage2 = characterFoundPage;
		List<Image>.Enumerator value = default(List<Image>.Enumerator);
		while (true)
		{
			object icon = characterFoundPage2._Icon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdi_v17 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdi_v17 (System.Object)+10]");
			IntPtr gcHandlePtr3 = Component.get_gameObject_Injected((IntPtr)0);
			GameObject original = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
			object icon2 = characterFoundPage2._Icon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdi_v18 (System.Object)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdi_v18 (System.Object)+10]");
			IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v54 (UnityEngine.Transform)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v54 (UnityEngine.Transform)+10]");
			IntPtr parent_Injected = Transform.GetParent_Injected((IntPtr)0);
			Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
			GameObject gameObject2 = UnityEngine.Object.Instantiate(original, parent);
			Image component = gameObject2.GetComponent<Image>();
			component.color = (Color)(&ghosts);
			bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr5 = Component.get_transform_Injected(((UnityEngine.Object)component).m_CachedPtr);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
			bool flag7 = (object)transform2 == null;
			ghosts3 = (List<Image>.Enumerator)Vector3.oneVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1940 @ rax_v68 (UnityEngine.Transform)+10]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1940 @ rax_v68 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value));
			float delay = (float)num2 * 0.1f;
			float num3 = (float)num2 * 0.2f;
			float duration = num3 + 1f;
			object tweens = characterFoundPage._tweens;
			TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component, 0.1f, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2007 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2007 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2007 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2007 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			bool flag9 = characterFoundPage._tweens == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1787 @ rdi_v23 (System.Object)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1787 @ rdi_v23 (System.Object)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1787 @ rdi_v23 (System.Object)+10]");
			bool flag10 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1787 @ rdi_v23 (System.Object)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1811 @ rcx_v68+18]");
			if (num4 >= 0)
			{
				((List<object>)(object)characterFoundPage._tweens).AddWithResize((object)tweenerCore);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1787 @ rdi_v23 (System.Object)+18]");
				object obj4 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			object tweens2 = characterFoundPage._tweens;
			bool flag11 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr6 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
			TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target, 1.5f, duration);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, delay);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2207 @ rax_v86 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2207 @ rax_v86 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2207 @ rax_v86 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2207 @ rax_v86 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			bool flag12 = characterFoundPage._tweens == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdi_v24 (System.Object)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdi_v24 (System.Object)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdi_v24 (System.Object)+10]");
			bool flag13 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdi_v24 (System.Object)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1812 @ rcx_v77+18]");
			if (num5 >= 0)
			{
				((List<object>)(object)characterFoundPage._tweens).AddWithResize((object)tweenerCore2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdi_v24 (System.Object)+18]");
				object obj6 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			List<object> ghosts4 = (List<object>)(object)characterFoundPage._ghosts;
			bool flag14 = characterFoundPage._ghosts == null;
			int version2 = ghosts4._version + 1;
			ghosts4._version = version2;
			object[] items = ghosts4._items;
			bool flag15 = ghosts4._items == null;
			if (ghosts4._size >= items.Length)
			{
				((List<object>)(object)characterFoundPage._ghosts).AddWithResize((object)component);
			}
			else
			{
				int size = ghosts4._size + 1;
				ghosts4._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num2++;
			if (num2 < 4)
			{
				characterFoundPage2 = characterFoundPage;
				continue;
			}
			break;
		}
	}

	private void PlayFirework()
	{
		//IL_01e3: Expected O, but got I4
		//IL_023d: Expected O, but got I4
		_003C_003Ec__DisplayClass54_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass54_0();
		CS_0024_003C_003E8__locals17._003C_003E4__this = this;
		float particleScaleFactor = UICamera.ParticleScaleFactor;
		float num = particleScaleFactor * 0.3f;
		if (gravityWellCongfig == null)
		{
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			particleScaleFactor = num * 25f;
			gravityWellConfig._usePauseSystem = false;
			gravityWellConfig._power = num;
			float gravity = num * 150f;
			gravityWellConfig._epsilon = particleScaleFactor;
			gravityWellConfig._gravity = gravity;
			gravityWellCongfig = gravityWellConfig;
			RectTransform component = _Icon.GetComponent<RectTransform>();
			Vector2 viewportPosition = FireworksManager.GetViewportPosition(component);
			GravityWell gravityWell = FireworksManager.CreateGravityWell(viewportPosition, gravityWellCongfig);
		}
		float[] array = new float[7] { 0.1f, 0.3f, 0.5f, 0.7f, 0.9f, 1.2f, 1.4f };
		string[] frames = new string[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		CS_0024_003C_003E8__locals17.frames = frames;
		Sequence s = DOTween.Sequence();
		CS_0024_003C_003E8__locals17.count = 0;
		int num2 = 0;
		int num3 = 0;
		while (num2 < array.Length)
		{
			float interval = array[0];
			if (num3 != 0)
			{
				object obj = num3 - 1;
				interval = array[num3] - array[obj];
			}
			Sequence sequence = TweenSettingsExtensions.AppendInterval(s, interval);
			TweenCallback callback = CS_0024_003C_003E8__locals17._003C_003E9__0;
			if (CS_0024_003C_003E8__locals17._003C_003E9__0 == null)
			{
				TweenCallback tweenCallback = (CS_0024_003C_003E8__locals17._003C_003E9__0 = delegate
				{
					//IL_00cd: Expected O, but got I4
					//IL_010c: Expected O, but got I4
					//IL_0112: Expected O, but got I
					if (CS_0024_003C_003E8__locals17.frames != null)
					{
						List<object> frames2 = new List<object>(CS_0024_003C_003E8__locals17.frames);
						CharacterFoundPage characterFoundPage = CS_0024_003C_003E8__locals17._003C_003E4__this;
						RectTransform panel = characterFoundPage._Panel;
						ParticleSystem particleSystem = FireworksManager.CreateRandomFirework(CS_0024_003C_003E8__locals17.count, (List<string>)(object)frames2, characterFoundPage._Panel, 0.6f);
						CharacterFoundPage characterFoundPage2 = CS_0024_003C_003E8__locals17._003C_003E4__this;
						TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(characterFoundPage2._BGAdditiveOverlay, 0.4f, 0.03f);
						TweenCallback tweenCallback2 = CS_0024_003C_003E8__locals17._003C_003E9__1;
						bool flag = CS_0024_003C_003E8__locals17._003C_003E9__1 != null;
						object obj3 = 0;
						if (!flag)
						{
							tweenCallback2 = (CS_0024_003C_003E8__locals17._003C_003E9__1 = delegate
							{
								CharacterFoundPage characterFoundPage3 = CS_0024_003C_003E8__locals17._003C_003E4__this;
								TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(characterFoundPage3._BGAdditiveOverlay, 0f, 0.03f);
							});
							obj3 = 0;
							panel = (RectTransform)0;
						}
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
							if ((nint)0 == 0)
							{
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
						int count = CS_0024_003C_003E8__locals17.count + 1;
						CS_0024_003C_003E8__locals17.count = count;
						return;
					}
					Exception ex = System.Linq.Error.ArgumentNull("source");
					throw ex;
				});
				object obj2 = 0;
				callback = tweenCallback;
			}
			Sequence sequence2 = TweenSettingsExtensions.AppendCallback(s, callback);
			num3++;
			num2 = num3;
		}
	}

	private unsafe void AddRays()
	{
		//IL_00cb: Expected O, but got I4
		//IL_00d6: Expected O, but got I4
		//IL_0196: Expected O, but got Ref
		//IL_036f: Expected O, but got Ref
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Expected O, but got Unknown
		//IL_0125->IL04d7: Incompatible stack heights: 1 vs 0
		//IL_015c->IL04d7: Incompatible stack heights: 1 vs 0
		//IL_0655->IL04d7: Incompatible stack heights: 9 vs 0
		//IL_022b->IL04d7: Incompatible stack heights: 9 vs 0
		//IL_067e->IL04d7: Incompatible stack heights: 9 vs 0
		//IL_06a7->IL04d7: Incompatible stack heights: 9 vs 0
		//IL_045c->IL06ac: Incompatible stack heights: 9 vs 0
		List<GameObject> list = new List<GameObject>();
		GameObject gameObject = CreateRay("0xff0000");
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			GameObject gameObject2 = CreateRay("0x00ff00");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			GameObject gameObject3 = CreateRay("0x0000ff");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			GameObject gameObject4 = CreateRay("0xffff00");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			GameObject gameObject5 = CreateRay("0xff00ff");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			GameObject gameObject6 = CreateRay("0x00ffff");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			object obj = 0;
			object obj2 = 0;
			Vector3 value = default(Vector3);
			Vector3 value2 = default(Vector3);
			object obj4 = default(object);
			object obj5 = default(object);
			object obj6 = default(object);
			while (true)
			{
				if ((nint)obj2 < list._size)
				{
					bool flag = (nint)obj >= list._size;
					GameObject[] items = list._items;
					if (list._items == null)
					{
						break;
					}
					object obj3 = items[obj];
					if ((object)items[obj] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rbx_v17 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rbx_v17 (System.Object)+10]");
					IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					bool flag3 = (object)transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1409 @ rax_v64 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1409 @ rax_v64 (UnityEngine.Transform)+10]");
					Transform.set_localScale_Injected((IntPtr)0, ref value);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1409 @ rax_v64 (UnityEngine.Transform)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1409 @ rax_v64 (UnityEngine.Transform)+10]");
					IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
					Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
					bool flag6 = (object)transform2 == null;
					bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1409 @ rax_v64 (UnityEngine.Transform)+10]");
					bool flag8 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1409 @ rax_v64 (UnityEngine.Transform)+10]");
					IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
					Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
					bool flag9 = (object)transform3 == null;
					transform3.localEulerAngles = (Vector3)(&obj4);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186BA7251h\"");
					float endValue = ((obj != null) ? (-3f) : 3f);
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(transform, endValue, 1f);
					if (_tweens == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScaleY(transform, 3.5f, 1f);
					if (_tweens == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
					Image component = transform.GetComponent<Image>();
					float num = (float)obj * 0.075f;
					float duration = num + 0.5f;
					TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(component, 0.25f, duration);
					if (tweenerCore3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1661 @ rax_v93 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1661 @ rax_v93 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 4294967295L;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1661 @ rax_v93 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
								if ((nint)0 == 0)
								{
									_ = 2139095040;
								}
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
					if (_tweens == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
					float num2 = (float)obj * 0.15f;
					float duration2 = num2 + 3f;
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DOLocalRotate(transform, (Vector3)(&obj5), duration2);
					if (tweenerCore4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1724 @ rax_v96 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1724 @ rax_v96 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 4294967295L;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1724 @ rax_v96 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
								if ((nint)0 == 0)
								{
									_ = 2139095040;
								}
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
					if (_tweens == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
					obj++;
					obj5 = obj6;
					obj4 = obj6;
					obj2 = obj;
					continue;
				}
				object ray = _Ray;
				if ((object)_Ray == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rbx_v15 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_Ray);
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rbx_v15 (System.Object)+10]");
				GameObject.SetActive_Injected((IntPtr)0, false);
				List<object> rays = (List<object>)(object)_rays;
				if (_rays == null)
				{
					break;
				}
				((List<object>)(object)_rays).InsertRange(rays._size, (IEnumerable<object>)list);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe GameObject CreateRay(string color)
	{
		//IL_006e: Expected O, but got Ref
		Color color2 = hexToColor(color);
		GameObject gameObject = UnityEngine.Object.Instantiate(_Ray, _RayContainer);
		if ((object)gameObject != null)
		{
			Image component = gameObject.GetComponent<Image>();
			if ((object)component != null)
			{
				object obj = default(object);
				component.color = (Color)(&obj);
				gameObject.SetActive(value: true);
				if (_rays != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
					return gameObject;
				}
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private unsafe static Color hexToColor(string hex)
	{
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Expected O, but got Unknown
		//IL_0132: Expected O, but got I4
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_019b: Expected O, but got I4
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected O, but got Unknown
		//IL_0542: Expected native int or pointer, but got O
		//IL_0204: Expected O, but got I4
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Expected O, but got Unknown
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BAA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = hex.Replace("0x", "");
		string text2 = text.Replace("#", "");
		if (text2._stringLength >= 0)
		{
			bool flag = text2._stringLength < 2;
			bool flag2 = text2._stringLength == 2;
			if (!flag)
			{
				string text4;
				if (!flag2)
				{
					string text3 = text2.InternalSubString(0, 2);
					if (text3 == null)
					{
						goto IL_03a1;
					}
					text4 = text3;
				}
				else
				{
					text4 = text2;
				}
				object obj = text4 + 20;
				_ = text4._stringLength;
				_ = 0;
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				object obj2 = default(object);
				ReadOnlySpan<char> s = (ReadOnlySpan<char>)(obj2 - 32);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
				_ = 0;
				byte b = byte.Parse(s, NumberStyles.HexNumber, currentInfo);
				if (text2._stringLength >= 2)
				{
					object obj3 = text2._stringLength - 2;
					if ((nint)obj3 >= 2)
					{
						string text5 = text2.InternalSubString(2, 2);
						if (text5 != null)
						{
							object obj4 = text5 + 20;
							_ = 0;
							_ = text5._stringLength;
							NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
							ReadOnlySpan<char> s2 = (ReadOnlySpan<char>)(obj2 - 32);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
							_ = 0;
							byte b2 = byte.Parse(s2, NumberStyles.HexNumber, currentInfo2);
							if (text2._stringLength < 4)
							{
								ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than length of string.");
								ex._002Ector("startIndex", "startIndex cannot be larger than length of string.");
								throw ex;
							}
							object obj5 = text2._stringLength - 2;
							if ((nint)obj5 < 4)
							{
								ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
								ex2._002Ector("length", "Index and length must refer to a location within the string.");
								throw ex2;
							}
							string text6 = text2.InternalSubString(4, 2);
							if (text6 != null)
							{
								object obj6 = text6 + 20;
								_ = 0;
								_ = text6._stringLength;
								NumberFormatInfo currentInfo3 = NumberFormatInfo.CurrentInfo;
								ReadOnlySpan<char> s3 = (ReadOnlySpan<char>)(obj2 - 32);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
								_ = 0;
								byte b3 = byte.Parse(s3, NumberStyles.HexNumber, currentInfo3);
								bool flag3 = text2._stringLength != 8;
								byte b4 = 255;
								if (!flag3)
								{
									object obj7 = text2._stringLength - 2;
									if ((nint)obj7 < 6)
									{
										goto IL_054c;
									}
									string text7 = text2.InternalSubString(6, 2);
									if (text7 == null)
									{
										goto IL_03a1;
									}
									object obj8 = text7 + 20;
									_ = 0;
									_ = text7._stringLength;
									NumberFormatInfo currentInfo4 = NumberFormatInfo.CurrentInfo;
									ReadOnlySpan<char> s4 = (ReadOnlySpan<char>)(obj2 - 32);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
									_ = 0;
									byte b5 = byte.Parse(s4, NumberStyles.HexNumber, currentInfo4);
									b4 = b5;
								}
								_ = 0;
								Color color = default(Color);
								float r = default(float);
								((Color*)(nint)color)->r = r;
								return color;
							}
						}
						goto IL_03a1;
					}
					ArgumentOutOfRangeException ex3 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
					ex3._002Ector("length", "Index and length must refer to a location within the string.");
					throw ex3;
				}
				ArgumentOutOfRangeException ex4 = new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than length of string.");
				ex4._002Ector("startIndex", "startIndex cannot be larger than length of string.");
				throw ex4;
			}
			ArgumentOutOfRangeException ex5 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
			ex5._002Ector("length", "Index and length must refer to a location within the string.");
			throw ex5;
		}
		ArgumentOutOfRangeException ex6 = new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than length of string.");
		ex6._002Ector("startIndex", "startIndex cannot be larger than length of string.");
		throw ex6;
		IL_03a1:
		System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.s);
		goto IL_054c;
		IL_054c:
		ArgumentOutOfRangeException ex7 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
		ex7._002Ector("length", "Index and length must refer to a location within the string.");
		throw ex7;
	}

	public CharacterFoundPage()
	{
		List<Image> ghosts = new List<Image>();
		_ghosts = ghosts;
		_rays = new List<GameObject>();
		_tweens = new List<Tween>();
		_toCompleteOnSkip = new List<Tween>();
		base._002Ector();
	}

	private void _003CAnimateOut_003Eb__39_0()
	{
		View.Hide();
	}

	private void _003CPerformReveal_003Eb__41_0()
	{
		AddRays();
	}

	private void _003CPerformReveal_003Eb__41_1()
	{
		//IL_0104: Expected F4, but got I4
		//IL_00c7: Expected O, but got I4
		//IL_00f5: Expected F4, but got I4
		//IL_020b->IL0259: Incompatible stack heights: 3 vs 0
		if ((object)_darkParticles != null)
		{
			_darkParticles.Stop();
			MakeColorParticles();
			if ((object)_Name != null)
			{
				Transform target = _Name.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.5f);
				float endValue;
				if (_unlockedCharacterType == CharacterType.TP_DRACULA)
				{
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Rate = 1f;
					soundConfig.Volume = (float?)(object)1;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Coffin2, soundConfig, 0f, 10, time);
					endValue = 0f;
				}
				else
				{
					endValue = 0f;
				}
				if (_ghosts != null)
				{
					List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
					while (enumerator.MoveNext())
					{
						object obj = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v11 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v11 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
						GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						bool flag2 = (object)gameObject == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v38 (UnityEngine.GameObject)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v38 (UnityEngine.GameObject)+10]");
						GameObject.SetActive_Injected((IntPtr)0, false);
					}
					TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Icon, 1f, 0.5f);
					TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_darkIcon, endValue, 0.5f);
					TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleUI.DOFade(_PanelDarkOverlay, endValue, 0.5f);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CPerformReveal_003Eb__41_2()
	{
		EnableDoneButton();
	}

	private void _003COnShowStart_003Eb__42_0()
	{
		//IL_0038: Expected F4, but got I4
		if (_unlockedCharacterType == CharacterType.TP_DRACULA)
		{
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Coffin1, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		}
	}

	private void _003COnShowStart_003Eb__42_2()
	{
		EnableOkButton();
	}

	private void _003COnShowStart_003Eb__42_3()
	{
		PlayGhosts();
		VFX.SetActive(value: true);
	}

	private void _003CEnableDoneButton_003Eb__46_0()
	{
		Selectable component = _DoneButton.GetComponent<Selectable>();
		component.Select();
	}

	private void _003CEnableOkButton_003Eb__50_0()
	{
		Selectable component = _OkButton.GetComponent<Selectable>();
		component.Select();
	}

	private void _003CDisableOkButton_003Eb__51_0()
	{
		if ((object)_OkButton != null)
		{
			_OkButton.SetActive(value: false);
			return;
		}
		throw new NullReferenceException();
	}
}
