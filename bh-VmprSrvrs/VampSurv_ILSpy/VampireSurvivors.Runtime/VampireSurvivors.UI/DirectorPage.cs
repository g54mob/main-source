using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class DirectorPage : GameWindowedUIPage
{
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public int repeatCount;

		public DirectorPage _003C_003E4__this;

		internal void _003COnShowStart_003Eb__0()
		{
			//IL_007a: Expected I, but got O
			//IL_01c6: Expected I, but got O
			//IL_01be->IL01be: Incompatible stack heights: 1 vs 0
			bool flag = repeatCount == 1;
			DirectorPage directorPage = _003C_003E4__this;
			Transform title;
			Vector3 value = default(Vector3);
			if (!flag)
			{
				if (repeatCount != 0)
				{
					if ((object)_003C_003E4__this != null)
					{
						title = (Transform)(object)directorPage._Title;
						if ((object)directorPage._Title != null)
						{
							nint num = (nint)title;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v137 @ rdx_v19 (Il2CppClass<UnityEngine.Transform>)+548] (should have been resolved before IL gen)");
							string str = default(string);
							string text = VampireSurvivors.App.Tools.Extensions.Shuffle(str);
							goto IL_01be;
						}
					}
				}
				else if ((object)_003C_003E4__this != null && (object)directorPage._Title != null)
				{
					Transform transform = directorPage._Title.transform;
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					int num2 = repeatCount - 1;
					repeatCount = num2;
					return;
				}
			}
			else if ((object)_003C_003E4__this != null && (object)directorPage._Title != null)
			{
				Transform transform2 = directorPage._Title.transform;
				bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				DirectorPage directorPage2 = _003C_003E4__this;
				DirectorPage directorPage3 = _003C_003E4__this;
				title = (Transform)(object)directorPage2._Title;
				string term = "lang/" + directorPage3.langKey;
				bool applyParameters = default(bool);
				GameObject localParametersRoot = default(GameObject);
				string overrideLanguage = default(string);
				bool allowLocalizedParameters = default(bool);
				string text = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				goto IL_01be;
			}
			throw new NullReferenceException();
			IL_01be:
			nint num3 = (nint)title;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v292 @ r9_v3 (Il2CppClass<UnityEngine.Transform>)+558] (should have been resolved before IL gen)");
			int num4 = repeatCount - 1;
			repeatCount = num4;
		}

		internal void _003COnShowStart_003Eb__1()
		{
			DirectorPage directorPage = _003C_003E4__this;
			string text = directorPage._Title.text;
			string text2 = VampireSurvivors.App.Tools.Extensions.Shuffle(text);
			directorPage._Title.text = text2;
			DirectorPage directorPage2 = _003C_003E4__this;
			if (!directorPage2._hasSwitched)
			{
				directorPage2._pfx1.Stop();
				DirectorPage directorPage3 = _003C_003E4__this;
				directorPage3._pfx2.Stop();
				DirectorPage directorPage4 = _003C_003E4__this;
				RenderingExtensions.Start(directorPage4._angryPfx1);
				DirectorPage directorPage5 = _003C_003E4__this;
				RenderingExtensions.Start(directorPage5._angryPfx2);
				DirectorPage directorPage6 = _003C_003E4__this;
				directorPage6._hasSwitched = true;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public RectTransform b;

		internal void _003CTweenButtonIn_003Eb__0()
		{
			Button component = b.GetComponent<Button>();
			component.interactable = true;
		}
	}

	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public DirectorPage _003C_003E4__this;

		public int repeatCount;

		internal unsafe void _003COnOkButtonClicked_003Eb__0()
		{
			//IL_0235: Expected I4, but got O
			//IL_00f4: Expected I4, but got O
			//IL_0050: Expected I4, but got O
			//IL_0598: Expected O, but got I
			//IL_01fb: Expected O, but got I
			//IL_046f: Expected I, but got O
			//IL_05ee: Expected O, but got I
			//IL_04fd: Expected O, but got I
			//IL_0528->IL05b9: Incompatible stack heights: 1 vs 2
			//IL_053f->IL053f: Incompatible stack heights: 2 vs 0
			bool flag = repeatCount == 1;
			DirectorPage directorPage = _003C_003E4__this;
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			if (!flag)
			{
				if (repeatCount != 0)
				{
					if ((object)_003C_003E4__this != null)
					{
						BgmType bgmType = (BgmType)directorPage._Title;
						if ((object)directorPage._Title != null)
						{
							int value__ = ((BgmType*)(int)bgmType)->value__;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v365 @ rdx_v31 (System.Int32)+548] (should have been resolved before IL gen)");
							string str = default(string);
							string text = VampireSurvivors.App.Tools.Extensions.Shuffle(str);
							int value__2 = ((BgmType*)(int)bgmType)->value__;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v443 @ r9_v15 (System.Int32)+558] (should have been resolved before IL gen)");
							int num = repeatCount - 1;
							repeatCount = num;
							return;
						}
					}
				}
				else if ((object)_003C_003E4__this != null)
				{
					BgmType bgmType2 = (BgmType)directorPage._Title;
					string term = "lang/" + directorPage.langKey;
					string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					if ((object)directorPage._Title != null)
					{
						int value__3 = ((BgmType*)(int)bgmType2)->value__;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ r9_v7 (System.Int32)+560]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ r9_v7 (System.Int32)+558] (should have been resolved before IL gen)");
						DirectorPage directorPage2 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null && (object)directorPage2._Title != null)
						{
							Transform transform = directorPage2._Title.transform;
							bool flag2 = (object)transform == null;
							Vector3 oneVector = Vector3.oneVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v54 (UnityEngine.Transform)+10]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v54 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							object obj2 = 0;
							Vector3 oneVector2 = Vector3.oneVector;
							goto IL_05b9;
						}
					}
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				BgmType bgmType3 = (BgmType)directorPage._Title;
				string term2 = "lang/" + directorPage.langKey;
				string translation2 = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				if ((object)directorPage._Title != null)
				{
					int value__4 = ((BgmType*)(int)bgmType3)->value__;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v137 @ r9_v11 (System.Int32)+558] (should have been resolved before IL gen)");
					DirectorPage directorPage3 = _003C_003E4__this;
					if ((object)_003C_003E4__this != null && directorPage3._playerOptions != null)
					{
						PlayerOptionsData config = directorPage3._playerOptions.Config;
						if (config != null)
						{
							SoundManager.FadeMusic(config._003CSelectedBGM_003Ek__BackingField, 0f, 4f);
							DirectorPage directorPage4 = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								if (directorPage4._okButtonOutSequence != null)
								{
									TweenExtensions.Kill(directorPage4._okButtonOutSequence);
								}
								DirectorPage directorPage5 = _003C_003E4__this;
								if ((object)_003C_003E4__this != null)
								{
									_003C_003E4__this.TweenButtonIn(directorPage5.OKButton);
									DirectorPage directorPage6 = _003C_003E4__this;
									if ((object)_003C_003E4__this != null && (object)directorPage6.OKButton != null)
									{
										Selectable component = directorPage6.OKButton.GetComponent<Selectable>();
										if ((object)component != null)
										{
											nint num2 = (nint)component;
											component.Select();
											Debug.Log("RPT = 0");
											DirectorPage directorPage7 = _003C_003E4__this;
											if ((object)_003C_003E4__this != null && (object)directorPage7._Title != null)
											{
												Transform transform2 = directorPage7._Title.transform;
												Vector3 oneVector = Vector3.oneVector;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ rax_v37 (UnityEngine.Transform)+10]");
												object obj = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ rax_v37 (UnityEngine.Transform)+10]");
												bool flag4 = (nint)0 == 0;
												object obj2 = 0;
												bool flag5 = (nint)0 != 0;
												Vector3 oneVector2 = Vector3.oneVector;
												int value__3 = 0;
												if (flag5)
												{
													goto IL_05b9;
												}
												bool flag6 = (nint)0 == 0;
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
			IL_05b9:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v823 @ rax_v17 (should have been resolved before IL gen)");
			int num3 = repeatCount - 1;
			repeatCount = num3;
		}
	}

	private RectTransform _MaskContainer;

	private List<RectTransform> _MaskIcons;

	private UISpriteAnimation _BurstVFX;

	private RectTransform EasyButton;

	private RectTransform HardButton;

	private RectTransform OKButton;

	private string langKey;

	private int sceneFlag;

	private bool _hasTrumpet;

	private bool _hasMirror;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private ParticleSystem _angryPfx1;

	private ParticleSystem _angryPfx2;

	private bool _angryPfxCreated;

	private bool _hasSwitched;

	private Sequence _shuffleSequence;

	private Sequence _okButtonOutSequence;

	private void Construct(SignalBus signal, PlayerOptions player)
	{
		//IL_009b: Expected O, but got I4
		//IL_009b: Expected O, but got I
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_0253: Expected O, but got I
		//IL_0147: Expected O, but got I4
		//IL_0147: Expected O, but got I
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_028e: Expected O, but got I
		//IL_01f3: Expected O, but got I4
		//IL_01f3: Expected O, but got I
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_02c9: Expected O, but got I
		_signalBus = signal;
		_playerOptions = player;
		Action action = OnRemoteOkButton;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.DirecterOkayButton>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.DirecterOkayButton>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v15 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = OnRemoteTooEasy;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.DirecterTooEasy>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.DirecterTooEasy>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v30 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Action action5 = OnRemoteTooHard;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rbx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj7 = null;
		Action<object> action6 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.DirecterTooHard>)obj7)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.DirecterTooHard>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v45 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus3.SubscribeInternal(signalType3, (object)null, (object)0, callback);
	}

	private void OnRemoteOkButton()
	{
		OnOkButtonClicked();
	}

	private void OnRemoteTooEasy()
	{
		OnSelectedTooEasy();
	}

	private void OnRemoteTooHard()
	{
		OnSelectedTooHard();
	}

	public void SelectTooEasy()
	{
		//IL_009e: Expected I8, but got O
		//IL_0082: Expected I8, but got O
		//IL_0057: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x186CAF4B0\"");
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).SelectDirecterTooEasy((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbx_v4 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private void OnSelectedTooEasy()
	{
		PlayerOptions playerOptions = _playerOptions;
		playerOptions._003CJustGotMirror_003Ek__BackingField = true;
		_playerOptions.Save();
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		GameManager core = GM.Core;
		core._003CCurrentFoundRelic_003Ek__BackingField = ItemType.RELIC_MIRROR;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E180");
	}

	public void SelectTooHard()
	{
		//IL_009e: Expected I8, but got O
		//IL_0082: Expected I8, but got O
		//IL_0057: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x186CAF750\"");
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).SelectDirecterTooHard((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbx_v4 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private void OnSelectedTooHard()
	{
		PlayerOptions playerOptions = _playerOptions;
		playerOptions._003CJustGotTrumpet_003Ek__BackingField = true;
		_playerOptions.Save();
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		GameManager core = GM.Core;
		core._003CCurrentFoundRelic_003Ek__BackingField = ItemType.RELIC_TRUMPET;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E180");
	}

	protected void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		Action token = OnRemoteOkButton;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = OnRemoteTooEasy;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		Action token3 = OnRemoteTooHard;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0fb5: Expected O, but got I
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_013b: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_1013: Expected O, but got I
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01e2: Expected O, but got I4
		//IL_1050: Expected O, but got Ref
		//IL_106f: Expected O, but got Ref
		//IL_108e: Expected O, but got Ref
		//IL_10a6: Expected native int or pointer, but got O
		//IL_01f5: Expected O, but got Ref
		//IL_0470: Expected I, but got O
		//IL_04ab: Expected I, but got O
		//IL_04ca: Expected I, but got O
		//IL_10ff: Expected O, but got Ref
		//IL_0574: Expected O, but got Ref
		//IL_113e: Expected I, but got O
		//IL_114c: Expected O, but got Ref
		//IL_05c0: Expected O, but got I
		//IL_05ef: Expected F4, but got I4
		//IL_0628: Expected O, but got I
		//IL_0660: Expected F4, but got I4
		//IL_0695: Expected I, but got O
		//IL_06b4: Expected I, but got O
		//IL_11eb: Expected O, but got Ref
		//IL_1254: Expected O, but got Ref
		//IL_12bd: Expected O, but got Ref
		//IL_12f7: Expected F4, but got I
		//IL_133c: Expected O, but got Ref
		//IL_142c: Expected I, but got O
		//IL_0c23: Expected I, but got O
		//IL_0c41: Expected F4, but got I
		//IL_0c5c: Expected F4, but got I
		//IL_0c65: Expected I, but got O
		//IL_1418: Expected I, but got O
		//IL_0ddd: Expected I4, but got I8
		//IL_0ef5: Expected I, but got O
		//IL_0f03: Expected O, but got Ref
		//IL_0f1b: Expected O, but got Ref
		//IL_0f23: Expected I, but got O
		//IL_0972: Expected I, but got O
		//IL_0990: Expected F4, but got I
		//IL_09ab: Expected F4, but got I
		//IL_09b4: Expected I, but got O
		//IL_0ad4: Expected I4, but got I8
		//IL_112b->IL0f6c: Incompatible stack heights: 1 vs 0
		//IL_055b->IL0f6c: Incompatible stack heights: 1 vs 0
		//IL_0688->IL0f9e: Incompatible stack heights: 1 vs 0
		//IL_06d8->IL0f9e: Incompatible stack heights: 1 vs 0
		//IL_0706->IL0f9e: Incompatible stack heights: 1 vs 0
		//IL_0732->IL0f9e: Incompatible stack heights: 1 vs 0
		//IL_1217->IL0f9e: Incompatible stack heights: 2 vs 0
		//IL_0768->IL0f9e: Incompatible stack heights: 2 vs 0
		//IL_1280->IL0f9e: Incompatible stack heights: 3 vs 0
		//IL_079e->IL0f9e: Incompatible stack heights: 3 vs 0
		//IL_136d->IL0f9e: Incompatible stack heights: 6 vs 0
		//IL_0e7b->IL0f9e: Incompatible stack heights: 6 vs 0
		//IL_0ea7->IL0f9e: Incompatible stack heights: 6 vs 0
		//IL_0ee8->IL0f9e: Incompatible stack heights: 6 vs 0
		//IL_0f51->IL0f9e: Incompatible stack heights: 6 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass27_0();
		if (CS_0024_003C_003E8__locals23 != null)
		{
			CS_0024_003C_003E8__locals23._003C_003E4__this = this;
			base.OnShowStart(g);
			DoMaskTween();
			if ((object)GM.Core != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = GM.Core.InteractingPlayer;
				EnterMultiplayerControl(interactingPlayer);
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v38 (VampireSurvivors.Data.PlayerOptionsData)+188]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v38 (VampireSurvivors.Data.PlayerOptionsData)+188]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rcx_v38+18]");
							bool hasMirror;
							if ((nint)0 == 0)
							{
								object obj4 = 0;
								hasMirror = false;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								object obj6 = default(object);
								object obj5 = obj6 - -1;
								bool flag = obj5 == null;
								hasMirror = !flag;
								object obj4 = 0;
							}
							_hasMirror = hasMirror;
							if (_playerOptions != null)
							{
								PlayerOptionsData config2 = _playerOptions.Config;
								if (config2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v41 (VampireSurvivors.Data.PlayerOptionsData)+188]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v41 (VampireSurvivors.Data.PlayerOptionsData)+188]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rcx_v42+18]");
										bool hasTrumpet;
										if ((nint)0 == 0)
										{
											hasTrumpet = false;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
											object obj9 = default(object);
											object obj8 = obj9 - -1;
											bool flag2 = obj8 == null;
											hasTrumpet = !flag2;
											object obj4 = 0;
										}
										_hasTrumpet = hasTrumpet;
										object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
										_ = _hasMirror;
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
										object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
										_ = _hasTrumpet;
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
										System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
										_ = 0;
										_ = 0;
										object arg = default(object);
										object arg2 = default(object);
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg, arg2));
										System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
										_ = 0;
										string message = string.FormatHelper((IFormatProvider)null, "<color=green>HAS MIRROR: {0} HAS TRUMPET: {1}", args);
										Debug.Log(message);
										if ((object)OKButton != null)
										{
											Button component = OKButton.GetComponent<Button>();
											if ((object)component != null)
											{
												component.interactable = false;
												if ((object)EasyButton != null)
												{
													Button component2 = EasyButton.GetComponent<Button>();
													if ((object)component2 != null)
													{
														component2.interactable = false;
														if ((object)HardButton != null)
														{
															Button component3 = HardButton.GetComponent<Button>();
															if ((object)component3 != null)
															{
																component3.interactable = false;
																if (_hasMirror)
																{
																	if (_hasTrumpet)
																	{
																		langKey = "directer_3";
																		sceneFlag = 3;
																		goto IL_10b0;
																	}
																	if (_hasMirror)
																	{
																		goto IL_03fd;
																	}
																}
																if (_hasTrumpet)
																{
																	goto IL_03fd;
																}
																langKey = "directer_1";
																sceneFlag = 1;
																goto IL_10b0;
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
		goto IL_0f9e;
		IL_0f9e:
		throw new NullReferenceException();
		IL_0cd0:
		Sequence shuffleSequence = _shuffleSequence;
		int num = CS_0024_003C_003E8__locals23.repeatCount;
		bool flag3 = _shuffleSequence == null;
		float num2 = 0.4f;
		float num4 = default(float);
		float num3 = num4;
		if (!flag3)
		{
			bool flag4 = !((Tween)shuffleSequence)._003Cactive_003Ek__BackingField;
			num2 = 0.4f;
			num3 = num4;
			if (!flag4)
			{
				bool flag5 = ((Tween)shuffleSequence).creationLocked;
				num2 = 0.4f;
				num3 = num4;
				if (!flag5)
				{
					if (CS_0024_003C_003E8__locals23.repeatCount >= -1)
					{
						if (num == 0)
						{
							num = 1;
						}
					}
					else
					{
						num = -1;
					}
					((Tween)shuffleSequence).loops = num;
					bool flag6 = ((ABSSequentiable)shuffleSequence).tweenType != TweenType.Tweener;
					num2 = 0.4f;
					num3 = num4;
					if (!flag6)
					{
						if (num <= -1)
						{
							((Tween)shuffleSequence).fullDuration = 1f / 0f;
							num2 = 0.4f;
							num3 = num4;
						}
						else
						{
							num3 = (float)num * ((Tween)shuffleSequence).duration;
							((Tween)shuffleSequence).fullDuration = num3;
							num2 = 0.4f;
						}
					}
				}
			}
		}
		goto IL_1353;
		IL_0a1f:
		Sequence shuffleSequence2 = _shuffleSequence;
		bool flag7 = _shuffleSequence == null;
		num2 = 0.2f;
		num3 = num4;
		if (!flag7)
		{
			bool flag8 = !((Tween)shuffleSequence2)._003Cactive_003Ek__BackingField;
			num2 = 0.2f;
			num3 = num4;
			if (!flag8)
			{
				bool flag9 = ((Tween)shuffleSequence2).creationLocked;
				num2 = 0.2f;
				num3 = num4;
				if (!flag9)
				{
					((Tween)shuffleSequence2).loops = -1;
					bool flag10 = ((ABSSequentiable)shuffleSequence2).tweenType != TweenType.Tweener;
					num2 = 0.2f;
					num3 = num4;
					if (!flag10)
					{
						((Tween)shuffleSequence2).fullDuration = 1f / 0f;
						num2 = 0.2f;
						num3 = num4;
					}
				}
			}
		}
		goto IL_1353;
		IL_1353:
		if ((object)_BurstVFX != null)
		{
			Image componentInParent = _BurstVFX.GetComponentInParent<Image>();
			if (_playerOptions != null)
			{
				PlayerOptionsData config3 = _playerOptions.Config;
				if (config3 != null)
				{
					bool flag11 = !config3._003CFlashingVFXEnabled_003Ek__BackingField;
					bool flag12 = !flag11;
					if ((object)componentInParent != null)
					{
						nint num5 = (nint)componentInParent;
						object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2642 @ r8_v32 (Il2CppClass<UnityEngine.GameObject>)+298] (should have been resolved before IL gen)");
						object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						nint num6 = (nint)componentInParent;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2651 @ rax_v123 (Il2CppClass<UnityEngine.GameObject>)+2A8] (should have been resolved before IL gen)");
						if ((object)_BurstVFX != null)
						{
							_BurstVFX.Play();
							return;
						}
					}
				}
			}
		}
		goto IL_0f9e;
		IL_10b0:
		GameObject title = (GameObject)(object)_Title;
		string term = "lang/" + langKey;
		bool flag13 = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, flag13, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		if ((object)_Title != null)
		{
			nint num7 = (nint)title;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1809 @ r9_v20 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
			GameObject title2 = (GameObject)(object)_Title;
			if ((object)_Title != null)
			{
				nint num8 = (nint)title2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1877 @ rdx_v48 (Il2CppClass<UnityEngine.GameObject>)+548] (should have been resolved before IL gen)");
				string str = default(string);
				string text = VampireSurvivors.App.Tools.Extensions.Shuffle(str);
				nint num9 = (nint)title2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v649 @ r9_v21 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
				if ((object)_TitlePanel != null)
				{
					Transform transform = _TitlePanel.transform;
					if ((object)transform != null)
					{
						_ = 0;
						bool flag14 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj14);
						if ((object)_TitlePanel != null)
						{
							Transform transform2 = _TitlePanel.transform;
							if ((object)transform2 != null)
							{
								_ = -180f;
								Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								transform2.localEulerAngles = localEulerAngles;
								nint num10 = (nint)typeof(Vector3);
								Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1952 @ rax_v76 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num11 = 0;
								_ = Vector3.zeroVector;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1958 @ rax_v77 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
								_ = 0;
								TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_TitlePanel, endValue, 0.15f);
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_TitlePanel, 1f, 0.15f);
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
								_ = 0;
								_ = 1065353216;
								_ = 1;
								soundConfig.Rate = 1f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7F]");
								soundConfig.Volume = (float?)(object)0;
								soundConfig.Detune = -1200f;
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, soundConfig, 0f, 10, flag13 ? 1 : 0);
								SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
								_ = 0;
								_ = 1056964608;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7F]");
								soundConfig2.Volume = (float?)(object)0;
								soundConfig2.Rate = 1f;
								soundConfig2.Detune = -1500f;
								PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig2, 0f, 10, flag13 ? 1 : 0);
								GameObject title3 = (GameObject)(object)_Title;
								if ((object)_Title != null)
								{
									nint num12 = (nint)title3;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1993 @ rdx_v60 (Il2CppClass<UnityEngine.GameObject>)+548] (should have been resolved before IL gen)");
									string str2 = default(string);
									string text2 = VampireSurvivors.App.Tools.Extensions.Shuffle(str2);
									nint num13 = (nint)title3;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v163 @ r9_v27 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
									if ((object)_Title != null)
									{
										Transform transform3 = _Title.transform;
										if ((object)_Title != null)
										{
											Transform transform4 = _Title.transform;
											if ((object)transform4 != null)
											{
												_ = 0;
												_ = 0;
												bool flag15 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
												object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
												Transform.get_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj15);
												if ((object)_Title != null)
												{
													Transform transform5 = _Title.transform;
													if ((object)transform5 != null)
													{
														_ = 0;
														_ = 0;
														bool flag16 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
														object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
														Transform.get_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj16);
														if ((object)_Title != null)
														{
															Transform transform6 = _Title.transform;
															if ((object)transform6 != null)
															{
																_ = 0;
																_ = 0;
																bool flag17 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
																object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																Transform.get_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out *(Vector3*)obj17);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-35]");
																num2 = 0f * -1f;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
																float num14 = 0f;
																bool flag18 = (object)transform3 == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
																_ = 0;
																bool flag19 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj18);
																Sequence shuffleSequence3 = DOTween.Sequence();
																_shuffleSequence = shuffleSequence3;
																ShowPanels();
																if (sceneFlag != 1 && sceneFlag != 2)
																{
																	bool flag20 = sceneFlag != 3;
																	num3 = num4;
																	if (!flag20)
																	{
																		Debug.Log("SCENE 3!");
																		if (!_angryPfxCreated)
																		{
																			CreateAngryParticles();
																		}
																		Sequence sequence = TweenSettingsExtensions.AppendInterval(_shuffleSequence, 0.2f);
																		GameObject shuffleSequence4 = (GameObject)(object)_shuffleSequence;
																		TweenCallback tweenCallback = delegate
																		{
																			DirectorPage directorPage = CS_0024_003C_003E8__locals23._003C_003E4__this;
																			string text3 = directorPage._Title.text;
																			string text4 = VampireSurvivors.App.Tools.Extensions.Shuffle(text3);
																			directorPage._Title.text = text4;
																			DirectorPage directorPage2 = CS_0024_003C_003E8__locals23._003C_003E4__this;
																			if (!directorPage2._hasSwitched)
																			{
																				directorPage2._pfx1.Stop();
																				DirectorPage directorPage3 = CS_0024_003C_003E8__locals23._003C_003E4__this;
																				directorPage3._pfx2.Stop();
																				DirectorPage directorPage4 = CS_0024_003C_003E8__locals23._003C_003E4__this;
																				RenderingExtensions.Start(directorPage4._angryPfx1);
																				DirectorPage directorPage5 = CS_0024_003C_003E8__locals23._003C_003E4__this;
																				RenderingExtensions.Start(directorPage5._angryPfx2);
																				DirectorPage directorPage6 = CS_0024_003C_003E8__locals23._003C_003E4__this;
																				directorPage6._hasSwitched = true;
																			}
																		};
																		object message2;
																		if (_shuffleSequence != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2325 @ rbx_v33 (UnityEngine.GameObject)+E8]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2325 @ rbx_v33 (UnityEngine.GameObject)+100]");
																				if ((nint)0 == 0)
																				{
																					bool flag21 = tweenCallback == null;
																					num13 = unchecked((nint)null);
																					if (!flag21)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2325 @ rbx_v33 (UnityEngine.GameObject)+A0]");
																						num14 = 0f;
																						Sequence shuffleSequence5 = _shuffleSequence;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2325 @ rbx_v33 (UnityEngine.GameObject)+A0]");
																						Sequence sequence2 = Sequence.DoInsertCallback(shuffleSequence5, tweenCallback, 0f);
																						num13 = unchecked((nint)null);
																					}
																					goto IL_0a1f;
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
																		num13 = unchecked((nint)null);
																		goto IL_0a1f;
																	}
																	goto IL_1353;
																}
																CS_0024_003C_003E8__locals23.repeatCount = 7;
																Sequence sequence3 = TweenSettingsExtensions.AppendInterval(_shuffleSequence, 0.4f);
																GameObject shuffleSequence6 = (GameObject)(object)_shuffleSequence;
																TweenCallback tweenCallback2 = delegate
																{
																	//IL_007a: Expected I, but got O
																	//IL_01c6: Expected I, but got O
																	//IL_01be->IL01be: Incompatible stack heights: 1 vs 0
																	bool flag23 = CS_0024_003C_003E8__locals23.repeatCount == 1;
																	DirectorPage directorPage = CS_0024_003C_003E8__locals23._003C_003E4__this;
																	Transform title4;
																	Vector3 value = default(Vector3);
																	if (!flag23)
																	{
																		if (CS_0024_003C_003E8__locals23.repeatCount != 0)
																		{
																			if ((object)CS_0024_003C_003E8__locals23._003C_003E4__this != null)
																			{
																				title4 = (Transform)(object)directorPage._Title;
																				if ((object)directorPage._Title != null)
																				{
																					nint num15 = (nint)title4;
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v137 @ rdx_v19 (Il2CppClass<UnityEngine.Transform>)+548] (should have been resolved before IL gen)");
																					string str3 = default(string);
																					string text3 = VampireSurvivors.App.Tools.Extensions.Shuffle(str3);
																					goto IL_01be;
																				}
																			}
																		}
																		else if ((object)CS_0024_003C_003E8__locals23._003C_003E4__this != null && (object)directorPage._Title != null)
																		{
																			Transform transform7 = directorPage._Title.transform;
																			bool flag24 = (object)transform7 == null;
																			bool flag25 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
																			Transform.set_localScale_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref value);
																			int repeatCount = CS_0024_003C_003E8__locals23.repeatCount - 1;
																			CS_0024_003C_003E8__locals23.repeatCount = repeatCount;
																			return;
																		}
																	}
																	else if ((object)CS_0024_003C_003E8__locals23._003C_003E4__this != null && (object)directorPage._Title != null)
																	{
																		Transform transform8 = directorPage._Title.transform;
																		bool flag26 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
																		Transform.set_localScale_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref value);
																		DirectorPage directorPage2 = CS_0024_003C_003E8__locals23._003C_003E4__this;
																		DirectorPage directorPage3 = CS_0024_003C_003E8__locals23._003C_003E4__this;
																		title4 = (Transform)(object)directorPage2._Title;
																		string term2 = "lang/" + directorPage3.langKey;
																		bool applyParameters = default(bool);
																		GameObject localParametersRoot2 = default(GameObject);
																		string overrideLanguage2 = default(string);
																		bool allowLocalizedParameters2 = default(bool);
																		string text3 = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot2, overrideLanguage2, allowLocalizedParameters2);
																		goto IL_01be;
																	}
																	throw new NullReferenceException();
																	IL_01be:
																	nint num16 = (nint)title4;
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v292 @ r9_v3 (Il2CppClass<UnityEngine.Transform>)+558] (should have been resolved before IL gen)");
																	int repeatCount2 = CS_0024_003C_003E8__locals23.repeatCount - 1;
																	CS_0024_003C_003E8__locals23.repeatCount = repeatCount2;
																};
																object message3;
																if (_shuffleSequence != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2283 @ rbx_v32 (UnityEngine.GameObject)+E8]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2283 @ rbx_v32 (UnityEngine.GameObject)+100]");
																		if ((nint)0 == 0)
																		{
																			bool flag22 = tweenCallback2 == null;
																			num13 = unchecked((nint)null);
																			if (!flag22)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2283 @ rbx_v32 (UnityEngine.GameObject)+A0]");
																				num14 = 0f;
																				Sequence shuffleSequence7 = _shuffleSequence;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2283 @ rbx_v32 (UnityEngine.GameObject)+A0]");
																				Sequence sequence4 = Sequence.DoInsertCallback(shuffleSequence7, tweenCallback2, 0f);
																				num13 = unchecked((nint)null);
																			}
																			goto IL_0cd0;
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
																num13 = unchecked((nint)null);
																goto IL_0cd0;
															}
														}
													}
												}
											}
										}
									}
								}
								goto IL_0f9e;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_03fd:
		langKey = "directer_2";
		sceneFlag = 2;
		goto IL_10b0;
	}

	private void ShowPanels()
	{
		bool active;
		GameObject gameObject4;
		if (sceneFlag != 1)
		{
			if ((object)EasyButton != null)
			{
				GameObject gameObject = EasyButton.gameObject;
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: false);
					if ((object)HardButton != null)
					{
						GameObject gameObject2 = HardButton.gameObject;
						if ((object)gameObject2 != null)
						{
							gameObject2.SetActive(value: false);
							if ((object)OKButton != null)
							{
								GameObject gameObject3 = OKButton.gameObject;
								active = IsLocalPlayerControllingUi();
								if ((object)gameObject3 != null)
								{
									gameObject4 = gameObject3;
									goto IL_0436;
								}
							}
						}
					}
				}
			}
		}
		else if ((object)EasyButton != null)
		{
			GameObject gameObject5 = EasyButton.gameObject;
			bool active2 = IsLocalPlayerControllingUi();
			if ((object)gameObject5 != null)
			{
				gameObject5.SetActive(active2);
				if ((object)HardButton != null)
				{
					GameObject gameObject6 = HardButton.gameObject;
					bool active3 = IsLocalPlayerControllingUi();
					if ((object)gameObject6 != null)
					{
						gameObject6.SetActive(active3);
						if ((object)OKButton != null)
						{
							GameObject gameObject7 = OKButton.gameObject;
							if ((object)gameObject7 != null)
							{
								gameObject4 = gameObject7;
								active = false;
								goto IL_0436;
							}
						}
					}
				}
			}
		}
		goto IL_042f;
		IL_0436:
		gameObject4.SetActive(active);
		if ((object)EasyButton != null)
		{
			Transform transform = EasyButton.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			Transform transform2 = HardButton.transform;
			bool flag2 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v731 @ rax_v33 (UnityEngine.Transform)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v731 @ rax_v33 (UnityEngine.Transform)+10]");
			Vector3 value2 = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value2);
			bool flag4 = (object)OKButton == null;
			Transform transform3 = OKButton.transform;
			bool flag5 = (object)transform3 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v856 @ rax_v41 (UnityEngine.Transform)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v856 @ rax_v41 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			Sequence sequence = DOTween.Sequence();
			Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 3f);
			TweenCallback tweenCallback = delegate
			{
				if (sceneFlag != 1)
				{
					TweenButtonIn(OKButton);
				}
				else
				{
					TweenButtonIn(EasyButton);
					TweenButtonIn(HardButton);
				}
			};
			Tween t;
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
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					t = null;
					message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					t = null;
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
				t = null;
				message = "You can't add elements to a NULL Sequence";
			}
			Debugger.LogWarning(message, t);
			return;
		}
		goto IL_042f;
		IL_042f:
		throw new NullReferenceException();
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		if ((object)GM.Core != null)
		{
			return GM.Core.InteractingPlayer;
		}
		return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
	}

	private unsafe void TweenButtonIn(RectTransform b)
	{
		//IL_003b: Expected O, but got Ref
		//IL_00ca: Expected O, but got Ref
		_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass30_0();
		CS_0024_003C_003E8__locals6.b = b;
		Transform transform = CS_0024_003C_003E8__locals6.b.transform;
		object obj = default(object);
		transform.eulerAngles = (Vector3)(&obj);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(CS_0024_003C_003E8__locals6.b, (Vector3)(&obj), 0.15f);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals6.b, 1f, 0.15f);
		TweenCallback tweenCallback = delegate
		{
			Button component = CS_0024_003C_003E8__locals6.b.GetComponent<Button>();
			component.interactable = true;
		};
		tweenCallback._002Ector(CS_0024_003C_003E8__locals6, (nint)__ldftn(_003C_003Ec__DisplayClass30_0._003CTweenButtonIn_003Eb__0));
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private unsafe Sequence TweenButtonOut(RectTransform b)
	{
		//IL_007a: Expected O, but got Ref
		Sequence sequence = DOTween.Sequence();
		if ((object)b != null)
		{
			Button component = b.GetComponent<Button>();
			if ((object)component != null)
			{
				component.interactable = false;
				object obj = default(object);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> t = ShortcutExtensions.DOLocalRotate(b, (Vector3)(&obj), 0.15f);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
				{
					if (sequence == null)
					{
						goto IL_017a;
					}
					Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, sequence.lastTweenInsertTime);
				}
				TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(b, 0f, 0.15f);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
				{
					if (sequence == null)
					{
						goto IL_017a;
					}
					Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, sequence.lastTweenInsertTime);
				}
				return sequence;
			}
		}
		goto IL_017a;
		IL_017a:
		return (Sequence)(object)new NullReferenceException();
	}

	private void DoMaskTween()
	{
		//IL_0162->IL0167: Incompatible stack heights: 1 vs 0
		//IL_009d->IL0167: Incompatible stack heights: 1 vs 0
		//IL_00b6->IL0167: Incompatible stack heights: 1 vs 0
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPosY(_MaskContainer, 0f, 2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		List<RectTransform>.Enumerator enumerator = default(List<RectTransform>.Enumerator);
		Vector3 value = default(Vector3);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rdi_v5 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rdi_v5 (System.Object)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(null, 1f, 2f);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
		}
	}

	public void OKButtonClicked()
	{
		//IL_009e: Expected I8, but got O
		//IL_0082: Expected I8, but got O
		//IL_0057: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x186CB1BF0\"");
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).SelectDirecterOkButton((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbx_v4 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private unsafe void OnOkButtonClicked()
	{
		//IL_036b: Expected I4, but got F4
		//IL_09cf: Expected O, but got I4
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_09ed: Expected O, but got I
		//IL_0b43: Expected I4, but got F4
		//IL_020c: Expected I, but got O
		//IL_0236: Expected I, but got O
		//IL_0246: Expected O, but got I
		//IL_0282: Expected O, but got I
		//IL_02e5: Expected O, but got I
		//IL_073a: Expected O, but got Ref
		//IL_0664: Expected I4, but got I8
		//IL_06e2->IL0aea: Incompatible stack heights: 1 vs 0
		//IL_070e->IL0aea: Incompatible stack heights: 1 vs 0
		//IL_078a->IL0aea: Incompatible stack heights: 1 vs 0
		//IL_085b->IL0aea: Incompatible stack heights: 1 vs 0
		//IL_0813->IL0aea: Incompatible stack heights: 1 vs 0
		//IL_0887->IL0aea: Incompatible stack heights: 1 vs 0
		//IL_08b4->IL0aea: Incompatible stack heights: 1 vs 0
		//IL_08e0->IL0aea: Incompatible stack heights: 1 vs 0
		//IL_08f3->IL0b28: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals28 = new _003C_003Ec__DisplayClass34_0();
		if (CS_0024_003C_003E8__locals28 != null)
		{
			CS_0024_003C_003E8__locals28._003C_003E4__this = this;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, num);
			if (_playerOptions != null)
			{
				_playerOptions.Save();
				if (sceneFlag == 1)
				{
					return;
				}
				if (sceneFlag != 2)
				{
					if (sceneFlag == 3)
					{
						Debug.Log("SETTING 4");
						sceneFlag = 4;
						TweenExtensions.Kill(_shuffleSequence);
						langKey = "directer_4";
						string term = "lang/" + langKey;
						GameObject localParametersRoot = default(GameObject);
						string overrideLanguage = default(string);
						bool allowLocalizedParameters = default(bool);
						string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
						if ((object)_Title != null)
						{
							_Title.text = translation;
							if ((object)_Title != null)
							{
								Transform transform = _Title.transform;
								if ((object)transform != null)
								{
									bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Vector3 value = default(Vector3);
									Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
									Sequence shuffleSequence = DOTween.Sequence();
									_shuffleSequence = shuffleSequence;
									CS_0024_003C_003E8__locals28.repeatCount = 7;
									Sequence sequence = TweenSettingsExtensions.AppendInterval(_shuffleSequence, 0.2f);
									Sequence shuffleSequence2 = _shuffleSequence;
									TweenCallback tweenCallback = delegate
									{
										//IL_0235: Expected I4, but got O
										//IL_00f4: Expected I4, but got O
										//IL_0050: Expected I4, but got O
										//IL_0598: Expected O, but got I
										//IL_01fb: Expected O, but got I
										//IL_046f: Expected I, but got O
										//IL_05ee: Expected O, but got I
										//IL_04fd: Expected O, but got I
										//IL_0528->IL05b9: Incompatible stack heights: 1 vs 2
										//IL_053f->IL053f: Incompatible stack heights: 2 vs 0
										bool flag3 = CS_0024_003C_003E8__locals28.repeatCount == 1;
										DirectorPage directorPage = CS_0024_003C_003E8__locals28._003C_003E4__this;
										bool applyParameters = default(bool);
										GameObject localParametersRoot2 = default(GameObject);
										string overrideLanguage2 = default(string);
										bool allowLocalizedParameters2 = default(bool);
										if (!flag3)
										{
											if (CS_0024_003C_003E8__locals28.repeatCount != 0)
											{
												if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
												{
													BgmType bgmType = (BgmType)directorPage._Title;
													if ((object)directorPage._Title != null)
													{
														int value__ = ((BgmType*)(int)bgmType)->value__;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v365 @ rdx_v31 (System.Int32)+548] (should have been resolved before IL gen)");
														string str = default(string);
														string text = VampireSurvivors.App.Tools.Extensions.Shuffle(str);
														int value__2 = ((BgmType*)(int)bgmType)->value__;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v443 @ r9_v15 (System.Int32)+558] (should have been resolved before IL gen)");
														int repeatCount = CS_0024_003C_003E8__locals28.repeatCount - 1;
														CS_0024_003C_003E8__locals28.repeatCount = repeatCount;
														return;
													}
												}
											}
											else if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
											{
												BgmType bgmType2 = (BgmType)directorPage._Title;
												string term2 = "lang/" + directorPage.langKey;
												string translation2 = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot2, overrideLanguage2, allowLocalizedParameters2);
												if ((object)directorPage._Title != null)
												{
													int value__3 = ((BgmType*)(int)bgmType2)->value__;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ r9_v7 (System.Int32)+560]");
													nint num8 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ r9_v7 (System.Int32)+558] (should have been resolved before IL gen)");
													DirectorPage directorPage2 = CS_0024_003C_003E8__locals28._003C_003E4__this;
													if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null && (object)directorPage2._Title != null)
													{
														Transform transform2 = directorPage2._Title.transform;
														bool flag4 = (object)transform2 == null;
														Vector3 oneVector = Vector3.oneVector;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v54 (UnityEngine.Transform)+10]");
														object obj8 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v54 (UnityEngine.Transform)+10]");
														bool flag5 = (nint)0 == 0;
														object obj9 = 0;
														Vector3 oneVector2 = Vector3.oneVector;
														goto IL_05b9;
													}
												}
											}
										}
										else if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
										{
											BgmType bgmType3 = (BgmType)directorPage._Title;
											string term3 = "lang/" + directorPage.langKey;
											string translation3 = LocalizationManager.GetTranslation(term3, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot2, overrideLanguage2, allowLocalizedParameters2);
											if ((object)directorPage._Title != null)
											{
												int value__4 = ((BgmType*)(int)bgmType3)->value__;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v137 @ r9_v11 (System.Int32)+558] (should have been resolved before IL gen)");
												DirectorPage directorPage3 = CS_0024_003C_003E8__locals28._003C_003E4__this;
												if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null && directorPage3._playerOptions != null)
												{
													PlayerOptionsData config2 = directorPage3._playerOptions.Config;
													if (config2 != null)
													{
														SoundManager.FadeMusic(config2._003CSelectedBGM_003Ek__BackingField, 0f, 4f);
														DirectorPage directorPage4 = CS_0024_003C_003E8__locals28._003C_003E4__this;
														if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
														{
															if (directorPage4._okButtonOutSequence != null)
															{
																TweenExtensions.Kill(directorPage4._okButtonOutSequence);
															}
															DirectorPage directorPage5 = CS_0024_003C_003E8__locals28._003C_003E4__this;
															if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
															{
																CS_0024_003C_003E8__locals28._003C_003E4__this.TweenButtonIn(directorPage5.OKButton);
																DirectorPage directorPage6 = CS_0024_003C_003E8__locals28._003C_003E4__this;
																if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null && (object)directorPage6.OKButton != null)
																{
																	Selectable component4 = directorPage6.OKButton.GetComponent<Selectable>();
																	if ((object)component4 != null)
																	{
																		nint num8 = (nint)component4;
																		component4.Select();
																		Debug.Log("RPT = 0");
																		DirectorPage directorPage7 = CS_0024_003C_003E8__locals28._003C_003E4__this;
																		if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null && (object)directorPage7._Title != null)
																		{
																			Transform transform3 = directorPage7._Title.transform;
																			Vector3 oneVector = Vector3.oneVector;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ rax_v37 (UnityEngine.Transform)+10]");
																			object obj8 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ rax_v37 (UnityEngine.Transform)+10]");
																			bool flag6 = (nint)0 == 0;
																			object obj9 = 0;
																			bool flag7 = (nint)0 != 0;
																			Vector3 oneVector2 = Vector3.oneVector;
																			int value__3 = 0;
																			if (flag7)
																			{
																				goto IL_05b9;
																			}
																			bool flag8 = (nint)0 == 0;
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
										IL_05b9:
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v823 @ rax_v17 (should have been resolved before IL gen)");
										int repeatCount2 = CS_0024_003C_003E8__locals28.repeatCount - 1;
										CS_0024_003C_003E8__locals28.repeatCount = repeatCount2;
									};
									object message;
									if (_shuffleSequence != null)
									{
										if (((Tween)shuffleSequence2)._003Cactive_003Ek__BackingField)
										{
											if (!((Tween)shuffleSequence2).creationLocked)
											{
												if (tweenCallback != null)
												{
													Sequence sequence2 = Sequence.DoInsertCallback(_shuffleSequence, tweenCallback, ((Tween)shuffleSequence2).duration);
												}
												goto IL_058a;
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
									goto IL_058a;
								}
							}
						}
						goto IL_0aea;
					}
					if (sceneFlag != 4)
					{
						return;
					}
					if (_signalBus != null)
					{
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ rbx_v8 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rbx_v9 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
						object obj2 = default(object);
						object obj = obj2 + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
						Type signalType = default(Type);
						_signalBus.InternalFire(signalType, (object)null, (object)null, (byte)(int)num != 0);
						GameManager core = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage = core._stage;
							if ((object)core._stage != null)
							{
								BackgroundManager fancyBg = stage._fancyBg;
								nint num4 = (nint)typeof(Background6);
								if ((object)stage._fancyBg != null)
								{
									nint num5 = (nint)fancyBg;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Stages.Background6>)+130]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ r9_v26 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+130]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Stages.Background6>)+130]");
									if (num6 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ r9_v26 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+C8]");
										object obj4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v105+FFFFFFF8+v494 @ rax_v104*8]");
										if (0 == (nint)typeof(Background6))
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r8_v31 (VampireSurvivors.Objects.Stages.BackgroundManager)+80]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r8_v31 (VampireSurvivors.Objects.Stages.BackgroundManager)+80]");
												((DirecterManager)0).StartPhase0();
												return;
											}
											goto IL_0b1c;
										}
									}
									throw new InvalidCastException();
								}
							}
						}
					}
				}
				else
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						core2._003CCurrentFoundRelic_003Ek__BackingField = ItemType.RELIC_TRUMPET;
						PlayerOptions playerOptions = _playerOptions;
						if (_playerOptions != null)
						{
							playerOptions._003CJustGotTrumpet_003Ek__BackingField = true;
							if (_playerOptions != null)
							{
								PlayerOptionsData config = _playerOptions.Config;
								if (config != null)
								{
									List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
									if (config._003CCollectedItems_003Ek__BackingField != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rcx_v19 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										bool flag2 = (nint)0 == 0;
										object obj5 = 0;
										if (!flag2)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rcx_v19 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
											obj5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
											object obj6 = default(object);
											if ((nint)obj6 != -1)
											{
												GameManager core3 = GM.Core;
												if ((object)GM.Core != null)
												{
													core3._003CCurrentFoundRelic_003Ek__BackingField = ItemType.RELIC_MIRROR;
													PlayerOptions playerOptions2 = _playerOptions;
													if (_playerOptions != null)
													{
														playerOptions2._003CJustGotMirror_003Ek__BackingField = true;
														PlayerOptions playerOptions3 = _playerOptions;
														if (_playerOptions != null)
														{
															playerOptions3._003CJustGotTrumpet_003Ek__BackingField = false;
															goto IL_0c36;
														}
													}
												}
												goto IL_0b1c;
											}
										}
										goto IL_0c36;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0b1c;
		IL_0c36:
		GameManager core4 = GM.Core;
		if ((object)GM.Core != null && _signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E180");
			return;
		}
		goto IL_0b1c;
		IL_0aea:
		throw new NullReferenceException();
		IL_058a:
		Sequence shuffleSequence3 = _shuffleSequence;
		int num7 = CS_0024_003C_003E8__locals28.repeatCount;
		if (_shuffleSequence != null && ((Tween)shuffleSequence3)._003Cactive_003Ek__BackingField && !((Tween)shuffleSequence3).creationLocked)
		{
			if (CS_0024_003C_003E8__locals28.repeatCount >= -1)
			{
				if (num7 == 0)
				{
					num7 = 1;
				}
			}
			else
			{
				num7 = -1;
			}
			((Tween)shuffleSequence3).loops = num7;
			if (((ABSSequentiable)shuffleSequence3).tweenType == TweenType.Tweener)
			{
				if (num7 <= -1)
				{
					((Tween)shuffleSequence3).fullDuration = 1f / 0f;
				}
				else
				{
					float fullDuration = (float)num7 * ((Tween)shuffleSequence3).duration;
					((Tween)shuffleSequence3).fullDuration = fullDuration;
				}
			}
		}
		Sequence sequence3 = DOTween.Sequence();
		if ((object)OKButton != null)
		{
			Button component = OKButton.GetComponent<Button>();
			if ((object)component != null)
			{
				component.interactable = false;
				object obj7 = default(object);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> t = ShortcutExtensions.DOLocalRotate(OKButton, (Vector3)(&obj7), 0.15f);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence3, (Tween)t, false))
				{
					if (sequence3 == null)
					{
						goto IL_0aea;
					}
					Sequence sequence4 = Sequence.DoInsert(sequence3, (Tween)t, sequence3.lastTweenInsertTime);
				}
				TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(OKButton, 0f, 0.15f);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence3, (Tween)t2, false))
				{
					if (sequence3 == null)
					{
						goto IL_0aea;
					}
					Sequence sequence5 = Sequence.DoInsert(sequence3, (Tween)t2, sequence3.lastTweenInsertTime);
				}
				_okButtonOutSequence = sequence3;
				if ((object)EasyButton != null)
				{
					Selectable component2 = EasyButton.GetComponent<Selectable>();
					if ((object)component2 != null)
					{
						component2.interactable = false;
						if ((object)EasyButton != null)
						{
							Selectable component3 = EasyButton.GetComponent<Selectable>();
							if ((object)component3 != null)
							{
								component3.Select();
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0aea;
		IL_0b1c:
		throw new NullReferenceException();
	}

	private unsafe void CreateAngryParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01ad: Expected O, but got I4
		//IL_01dd: Expected O, but got Ref
		//IL_01fb: Expected native int or pointer, but got O
		//IL_0215: Expected O, but got I
		//IL_0243: Expected O, but got I4
		//IL_025c: Expected O, but got Ref
		//IL_0276: Expected native int or pointer, but got O
		//IL_070a: Expected O, but got I4
		//IL_029b: Expected O, but got Ref
		//IL_02b5: Expected native int or pointer, but got O
		//IL_0744: Expected O, but got I
		//IL_02ed: Expected O, but got Ref
		//IL_0307: Expected native int or pointer, but got O
		//IL_077e: Expected O, but got I
		//IL_0358: Expected O, but got I
		//IL_0379: Expected O, but got I
		//IL_03ba: Expected O, but got I4
		//IL_0408: Expected O, but got Ref
		//IL_0426: Expected native int or pointer, but got O
		//IL_0440: Expected O, but got I
		//IL_046e: Expected O, but got I4
		//IL_0487: Expected O, but got Ref
		//IL_04a1: Expected native int or pointer, but got O
		//IL_04c9: Expected O, but got I
		//IL_07c6: Expected O, but got I
		//IL_04dc: Expected O, but got Ref
		//IL_04f6: Expected native int or pointer, but got O
		//IL_0800: Expected O, but got I
		//IL_052e: Expected O, but got Ref
		//IL_0548: Expected native int or pointer, but got O
		//IL_083a: Expected O, but got I
		//IL_059f: Expected O, but got I
		//IL_05c6: Expected O, but got I
		//IL_05e7: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float num = UIPositionHelper.ScreenHeight();
		float screenPosY = num + 672f;
		float yPositionFromScreenPosition = UIPositionHelper.GetYPositionFromScreenPosition(screenPosY);
		float num2 = UIPositionHelper.ScreenWidth();
		float screenPosX = num2 * 0.25f;
		float xPositionFromScreenPosition = UIPositionHelper.GetXPositionFromScreenPosition(screenPosX);
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"colours7");
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
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"colours8");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("shop");
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(yPositionFromScreenPosition);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, renderer.width));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(10000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-100f, -300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
		_ = 0;
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.8f, 0.9f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
		particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("shop");
		particleSystemConfig2._frame = list;
		minMaxCurve = new ParticleSystem.MinMaxCurve(yPositionFromScreenPosition);
		particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, renderer2.width));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
			particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(10000f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(-100f, -300f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
			obj = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
			particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(2f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
			particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
			particleSystemConfig2._quantity = (int?)(object)0;
			_ = 1133903872;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
			particleSystemConfig2._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
			particleSystemConfig2._blendMode = (BlendMode?)(object)0;
			Transform transform = _PfxEmitter.transform;
			Transform parent = default(Transform);
			string psName = default(string);
			bool isAdditive = default(bool);
			bool requiresMasking = default(bool);
			ParticleSystem angryPfx = _PfxEmitter.CreateUIEmitter(particleSystemConfig, "UI", 3, parent, psName, isAdditive, requiresMasking);
			_angryPfx1 = angryPfx;
			Transform transform2 = _PfxEmitter.transform;
			ParticleSystem angryPfx2 = _PfxEmitter.CreateUIEmitter(particleSystemConfig2, "UI", 3, parent, psName, isAdditive, requiresMasking);
			_angryPfx2 = angryPfx2;
			_angryPfx1.Stop();
			_angryPfx2.Stop();
			_angryPfxCreated = true;
			return;
		}
		throw new NullReferenceException();
	}

	public DirectorPage()
	{
		List<RectTransform> maskIcons = new List<RectTransform>();
		_MaskIcons = maskIcons;
		base._002Ector();
	}

	private void _003CShowPanels_003Eb__28_0()
	{
		if (sceneFlag != 1)
		{
			TweenButtonIn(OKButton);
			return;
		}
		TweenButtonIn(EasyButton);
		TweenButtonIn(HardButton);
	}
}
