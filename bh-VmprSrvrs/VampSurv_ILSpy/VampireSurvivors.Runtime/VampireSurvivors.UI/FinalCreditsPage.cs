using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class FinalCreditsPage : BaseUIPage
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__30_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnShowStart_003Eb__30_0()
		{
		}
	}

	private RectTransform _Container;

	private GameObject _TextPrefab;

	private TextMeshProUGUI _Title;

	private RectTransform _CongaContainer;

	private GameObject _CongaItem;

	private RectTransform _BackButton;

	private PlayerOptions _playerOptions;

	private DataManager _data;

	private int switchCount;

	private List<WiggleTween> _movementTweens;

	private List<EnemyType> _enemyList;

	private List<CharacterType> _characterList;

	private Dictionary<EnemyType, List<EnemyData>> _enemyData;

	private Dictionary<CharacterType, List<CharacterData>> _characterData;

	private List<float> _switchTimes;

	private float _chickenTime;

	private List<UISpriteAnimation> _anims;

	private int _moveTweenIndex;

	private float _congaSpeed;

	private bool _carrySkip;

	private int _congaLength;

	private float _widthCounter;

	private int _enemyCount;

	private int _characterCount;

	private Vector2 _JSDefaultScreenSize;

	private List<RectTransform> _spawnedConga;

	private PlaySoundResult _soundResult;

	private void Construct(PlayerOptions player, DataManager data)
	{
		_playerOptions = player;
		_data = data;
	}

	public void Back()
	{
		//IL_0130: Invalid comparison between F4 and I4
		//IL_001e: Invalid comparison between I4 and F4
		bool flag = switchCount == 2;
		if (switchCount >= 2)
		{
			if (flag)
			{
				_BackButton.SetParent(_CongaContainer, worldPositionStays: true);
				if (_congaSpeed > 0f)
				{
				}
				Vector2 anchoredPosition = default(Vector2);
				_BackButton.anchoredPosition = anchoredPosition;
				int num = switchCount + 1;
				switchCount = num;
				_carrySkip = true;
				return;
			}
			if ((float)switchCount > 2f)
			{
				GameObject gameObject = _CongaContainer.gameObject;
				gameObject.SetActive(value: false);
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
				GameManager core = GM.Core;
				core._playerOptions.Save();
				int num2 = DG.Tweening.Core.TweenManager.DespawnAll();
				GameManager core2 = GM.Core;
				PlayerOptionsData config = core2._playerOptions.Config;
				SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
				GM.Core.ResetGameToMenu();
				int num3 = switchCount + 1;
				switchCount = num3;
				return;
			}
		}
		else
		{
			CongaSwitch();
		}
		int num4 = switchCount + 1;
		switchCount = num4;
	}

	protected unsafe void FixedUpdate()
	{
		//IL_012b: Expected O, but got Ref
		//IL_02cf: Expected O, but got Ref
		//IL_04e0: Invalid comparison between F4 and I4
		//IL_0174: Expected O, but got F4
		//IL_019b: Invalid comparison between F4 and O
		//IL_0644: Expected O, but got F4
		//IL_0256->IL046e: Incompatible stack heights: 1 vs 0
		//IL_029c->IL046e: Incompatible stack heights: 2 vs 0
		//IL_02bb->IL046e: Incompatible stack heights: 2 vs 0
		//IL_02f3->IL046e: Incompatible stack heights: 2 vs 0
		//IL_04f3->IL04f8: Incompatible stack heights: 6 vs 0
		//IL_01ae->IL04f8: Incompatible stack heights: 6 vs 0
		//IL_01d2->IL04f8: Incompatible stack heights: 6 vs 0
		//IL_05b1->IL046e: Incompatible stack heights: 4 vs 0
		//IL_033e->IL046e: Incompatible stack heights: 5 vs 0
		//IL_07f8->IL046e: Incompatible stack heights: 6 vs 0
		//IL_0371->IL046e: Incompatible stack heights: 6 vs 0
		//IL_039f->IL046e: Incompatible stack heights: 6 vs 0
		//IL_06fc->IL046e: Incompatible stack heights: 7 vs 0
		//IL_06a2->IL07d4: Incompatible stack heights: 7 vs 6
		//IL_0751->IL07b2: Incompatible stack heights: 8 vs 0
		//IL_0403->IL046e: Incompatible stack heights: 8 vs 0
		//IL_0431->IL046e: Incompatible stack heights: 8 vs 0
		//IL_045f->IL046e: Incompatible stack heights: 8 vs 0
		//IL_0791->IL07b2: Incompatible stack heights: 9 vs 0
		float screenWidth = UIHelper.ScreenWidth;
		Vector2 ret;
		Vector2 ret2;
		if (_spawnedConga != null)
		{
			List<RectTransform>.Enumerator enumerator = default(List<RectTransform>.Enumerator);
			Vector2 vector = default(Vector2);
			Vector2 value = default(Vector2);
			Vector2 value2 = default(Vector2);
			Vector2 anchoredPosition2 = default(Vector2);
			while (enumerator.MoveNext())
			{
				object obj = null;
				List<WiggleTween> movementTweens = _movementTweens;
				int moveTweenIndex = _moveTweenIndex;
				bool flag = _movementTweens == null;
				bool flag2 = _moveTweenIndex >= movementTweens._size;
				WiggleTween[] items = movementTweens._items;
				bool flag3 = movementTweens._items == null;
				if (_moveTweenIndex < items.Length)
				{
					bool flag4 = items[moveTweenIndex] == null;
					((Transform)null).localEulerAngles = (Vector3)(&vector);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rbx_v42 (System.Object)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rbx_v42 (System.Object)+10]");
					RectTransform.get_anchoredPosition_Injected((IntPtr)0, out value);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rbx_v42 (System.Object)+10]");
					bool flag6 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rbx_v42 (System.Object)+10]");
					RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref value2);
					if (_congaSpeed > 0f)
					{
						Vector2 anchoredPosition = ((RectTransform)null).anchoredPosition;
						Vector2 sizeDelta = ((RectTransform)null).sizeDelta;
						float num = (float)sizeDelta * 0.5f;
						object obj2 = _widthCounter ^ -0f;
						float num2 = (float)obj2 + 3840f;
						float num3 = num2 + num;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref anchoredPosition))
						{
							Vector2 sizeDelta2 = ((RectTransform)null).sizeDelta;
							((RectTransform)null).anchoredPosition = anchoredPosition2;
						}
					}
					continue;
				}
				throw new IndexOutOfRangeException();
			}
			if (!_carrySkip)
			{
				return;
			}
			List<WiggleTween> movementTweens2 = _movementTweens;
			int moveTweenIndex2 = _moveTweenIndex;
			if (_movementTweens != null)
			{
				bool flag7 = _moveTweenIndex >= movementTweens2._size;
				WiggleTween[] items2 = movementTweens2._items;
				if (movementTweens2._items != null)
				{
					bool flag8 = _moveTweenIndex >= items2.Length;
					if (items2[moveTweenIndex2] != null && (object)_BackButton != null)
					{
						_BackButton.localEulerAngles = (Vector3)(&vector);
						object backButton = _BackButton;
						if ((object)_BackButton != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v34 (System.Object)+10]");
							bool flag9 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v34 (System.Object)+10]");
							RectTransform.get_anchoredPosition_Injected((IntPtr)0, out ret);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v34 (System.Object)+10]");
							bool flag10 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v34 (System.Object)+10]");
							RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref value);
							object backButton2 = _BackButton;
							if ((object)_BackButton != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rbx_v35 (System.Object)+10]");
								bool flag11 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rbx_v35 (System.Object)+10]");
								RectTransform.get_anchoredPosition_Injected((IntPtr)0, out ret2);
								float screenWidth2 = UIHelper.ScreenWidth;
								object backButton3 = _BackButton;
								if ((object)_BackButton != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v36 (System.Object)+10]");
									bool flag12 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v36 (System.Object)+10]");
									RectTransform.get_sizeDelta_Injected((IntPtr)0, out ret);
									float num4 = (float)ret + screenWidth2;
									object obj3 = num4 ^ -0f;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref ret2))
									{
										goto IL_07d4;
									}
									RectTransform backButton4 = _BackButton;
									if ((object)_BackButton != null)
									{
										Vector2 sizeDelta3 = _BackButton.sizeDelta;
										if ((object)_BackButton != null)
										{
											Vector2 anchoredPosition3 = _BackButton.anchoredPosition;
											bool flag13 = ((UnityEngine.Object)backButton4).m_CachedPtr == (IntPtr)0;
											RectTransform.set_anchoredPosition_Injected(((UnityEngine.Object)backButton4).m_CachedPtr, ref value);
											object obj4 = default(object);
											obj3 = obj4;
											goto IL_07d4;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_046e;
		IL_046e:
		throw new NullReferenceException();
		IL_07d4:
		object backButton5 = _BackButton;
		if ((object)_BackButton != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rbx_v38 (System.Object)+10]");
			bool flag14 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rbx_v38 (System.Object)+10]");
			RectTransform.get_anchoredPosition_Injected((IntPtr)0, out ret2);
			object backButton6 = _BackButton;
			if ((object)_BackButton != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rbx_v39 (System.Object)+10]");
				bool flag15 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rbx_v39 (System.Object)+10]");
				RectTransform.get_sizeDelta_Injected((IntPtr)0, out ret);
				if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref ret2) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref ret))
				{
					return;
				}
				object backButton7 = _BackButton;
				float screenWidth3 = UIHelper.ScreenWidth;
				if ((object)_BackButton != null)
				{
					Vector2 sizeDelta4 = _BackButton.sizeDelta;
					if ((object)_BackButton != null)
					{
						Vector2 anchoredPosition4 = _BackButton.anchoredPosition;
						if ((object)_BackButton != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rbx_v40 (System.Object)+10]");
							bool flag16 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rbx_v40 (System.Object)+10]");
							RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref ret);
							return;
						}
					}
				}
			}
		}
		goto IL_046e;
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_001e: Expected F4, but got O
		//IL_01ef: Expected O, but got I4
		//IL_023a: Expected O, but got I4
		//IL_02a8: Expected O, but got I
		//IL_03fc: Expected I, but got O
		//IL_0412: Expected O, but got I
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_051c: Expected I, but got O
		//IL_0532: Expected O, but got I
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_02f8: Expected I, but got O
		//IL_030e: Expected O, but got I
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_05ae: Expected I, but got O
		//IL_0385: Expected I, but got O
		//IL_0793: Expected I, but got I8
		//IL_0581: Expected I, but got I8
		//IL_04a7: Expected I, but got O
		//IL_066a: Expected O, but got I4
		//IL_0681: Expected I, but got I8
		//IL_0722: Expected O, but got I4
		//IL_0739: Expected I, but got I8
		//IL_0472: Expected I, but got I8
		//IL_036e: Expected I, but got I8
		//IL_03d8: Expected O, but got F4
		base.OnShowStart(g);
		Vector2 sizeDelta = _CongaContainer.sizeDelta;
		_widthCounter = (float)sizeDelta;
		TextMeshProUGUI component = _TextPrefab.GetComponent<TextMeshProUGUI>();
		string creditsText = Credits.GetCreditsText();
		component.text = creditsText;
		FadeInText();
		int num = 0;
		do
		{
			WiggleTween wiggleTween = new WiggleTween();
			wiggleTween.Start(num);
			List<object> movementTweens = (List<object>)(object)_movementTweens;
			int version = movementTweens._version + 1;
			movementTweens._version = version;
			object[] items = movementTweens._items;
			if (movementTweens._size >= items.Length)
			{
				movementTweens.AddWithResize((object)wiggleTween);
			}
			else
			{
				int size = movementTweens._size + 1;
				movementTweens._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
		}
		while (num < 10);
		CreateEnemyList();
		CreateCharacterList();
		bool flag = _congaLength <= 0;
		int num2 = 0;
		if (!flag)
		{
			do
			{
				GetNextCharacter();
				num2++;
			}
			while (num2 < _congaLength);
		}
		PlayerOptionsData config = _playerOptions.Config;
		SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
		PlayerOptionsData config2 = _playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Pizza;
		SoundManager._003CCurrentBgm_003Ek__BackingField = BgmType.BGM_Pizza;
		PlayerOptionsData config3 = _playerOptions.Config;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Loop = true;
		soundConfig.Rate = 1f;
		SoundManager.PlayMusic(config3._003CSelectedBGM_003Ek__BackingField, soundConfig);
		List<float> switchTimes = _switchTimes;
		object obj = 24;
		int num3 = 0;
		bool flag2 = false;
		Vector2 vector = sizeDelta;
		int num4 = 0;
		while (true)
		{
			int num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ rax_v38 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num5 >= (nint)0)
			{
				break;
			}
			List<float> switchTimes2 = _switchTimes;
			int num6 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v99 (System.Collections.Generic.List`1<System.Single>)+18]");
			TweenCallback tweenCallback;
			if ((nint)num6 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v99 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj2 = 0;
				tweenCallback = null;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ r9_v13 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(FinalCreditsPage._003COnShowStart_003Eb__30_2);
				((Delegate)tweenCallback).m_target = this;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ r9_v13 (Il2CppMethodInfo)+4C]");
				object obj3 = (nint)0 >> 4;
				object obj4 = obj3 & 1;
				nint num8;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ r9_v13 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num8 = unchecked((nint)6447293664L);
						goto IL_0661;
					}
				}
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				num8 = ((Delegate)tweenCallback).method_ptr;
				goto IL_0661;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
			IL_0661:
			object obj5 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v78+20+v74 @ rbp_v5 (System.Int32)*4]");
			float num9 = 0f * 0.001f;
			Tween tween = DOVirtual.DelayedCall(num9, tweenCallback);
			tween.stringId = "UI_CUSTOM_TIMER";
			switchTimes = _switchTimes;
			num3++;
			vector = (Vector2)num9;
			num4 = num3;
		}
		TweenCallback callback = _003C_003Ec._003C_003E9__30_0;
		TweenCallback tweenCallback2;
		if (_003C_003Ec._003C_003E9__30_0 == null)
		{
			tweenCallback2 = null;
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v12 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec._003COnShowStart_003Eb__30_0);
			((Delegate)tweenCallback2).m_target = _003C_003Ec._003C_003E9;
			((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v12 (Il2CppMethodInfo)+4C]");
			object obj6 = (nint)0 >> 4;
			object obj7 = obj6 & 1;
			nint num11;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v12 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num11 = unchecked((nint)6447293664L);
					goto IL_0719;
				}
			}
			else if (_003C_003Ec._003C_003E9 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
				object obj8 = default(object);
				throw obj8;
			}
			((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
			num11 = ((Delegate)tweenCallback2).method_ptr;
			goto IL_0719;
		}
		goto IL_074f;
		IL_074f:
		float delay = _chickenTime * 0.001f;
		Tween tween2 = DOVirtual.DelayedCall(delay, callback);
		tween2.stringId = "UI_CUSTOM_TIMER";
		TweenCallback tweenCallback3 = null;
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ r9_v10 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback3).method = (nint)__ldftn(FinalCreditsPage._003COnShowStart_003Eb__30_1);
		((Delegate)tweenCallback3).m_target = this;
		((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ r9_v10 (Il2CppMethodInfo)+4C]");
		object obj9 = (nint)0 >> 4;
		object obj10 = obj9 & 1;
		nint num13;
		if (obj10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ r9_v10 (Il2CppMethodInfo)+52]");
			bool flag3 = (nint)0 == 0;
			num13 = unchecked((nint)6447293664L);
			if (flag3)
			{
				goto IL_077c;
			}
		}
		num13 = ((Delegate)tweenCallback3).method_ptr;
		((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
		goto IL_077c;
		IL_0719:
		object obj11 = 24;
		((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
		_003C_003Ec._003C_003E9__30_0 = tweenCallback2;
		callback = tweenCallback2;
		goto IL_074f;
		IL_077c:
		((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
		float delay2 = _chickenTime * 0.001f;
		Tween tween3 = DOVirtual.DelayedCall(delay2, tweenCallback3);
		tween3.stringId = "UI_CUSTOM_TIMER";
	}

	private unsafe void FadeInText()
	{
		//IL_00c8: Expected O, but got Ref
		CanvasGroup component = _Container.GetComponent<CanvasGroup>();
		component.alpha = 0f;
		CanvasGroup component2 = _Container.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(component2, 1f, 1f);
		TweenCallback tweenCallback = delegate
		{
			Transform child = _Container.GetChild(0);
			RectTransform component3 = child.GetComponent<RectTransform>();
			Vector2 sizeDelta = component3.sizeDelta;
			float endValue = default(float);
			TweenerCore<Vector2, Vector2, VectorOptions> t = DOTweenModuleUI.DOAnchorPosY(_Container, endValue, 90f);
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay(t, 1f);
			TweenCallback tweenCallback2 = delegate
			{
				CanvasGroup component4 = _Container.GetComponent<CanvasGroup>();
				TweenerCore<float, float, FloatOptions> t2 = DOTweenModuleUI.DOFade(component4, 0f, 1f);
				TweenerCore<float, float, FloatOptions> tweenerCore4 = TweenSettingsExtensions.SetDelay(t2, 60f);
				TweenerCore<Color, Color, ColorOptions> t3 = DOTweenModuleUI.DOFade(_Title, 0f, 1f);
				TweenerCore<Color, Color, ColorOptions> tweenerCore5 = TweenSettingsExtensions.SetDelay(t3, 60f);
			};
			if (tweenerCore3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		object obj = default(object);
		_Title.color = (Color)(&obj);
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Title, 1f, 1f);
	}

	private void ScrollText()
	{
		Transform child = _Container.GetChild(0);
		RectTransform component = child.GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		float endValue = default(float);
		TweenerCore<Vector2, Vector2, VectorOptions> t = DOTweenModuleUI.DOAnchorPosY(_Container, endValue, 90f);
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 1f);
		TweenCallback tweenCallback = delegate
		{
			CanvasGroup component2 = _Container.GetComponent<CanvasGroup>();
			TweenerCore<float, float, FloatOptions> t2 = DOTweenModuleUI.DOFade(component2, 0f, 1f);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, 60f);
			TweenerCore<Color, Color, ColorOptions> t3 = DOTweenModuleUI.DOFade(_Title, 0f, 1f);
			TweenerCore<Color, Color, ColorOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay(t3, 60f);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void FadeOutText()
	{
		CanvasGroup component = _Container.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> t = DOTweenModuleUI.DOFade(component, 0f, 1f);
		TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 60f);
		TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleUI.DOFade(_Title, 0f, 1f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, 60f);
	}

	private void CreateConga()
	{
		int num = 0;
		do
		{
			WiggleTween wiggleTween = new WiggleTween();
			wiggleTween.Start(num);
			List<object> movementTweens = (List<object>)(object)_movementTweens;
			int version = movementTweens._version + 1;
			movementTweens._version = version;
			object[] items = movementTweens._items;
			if (movementTweens._size >= items.Length)
			{
				movementTweens.AddWithResize((object)wiggleTween);
			}
			else
			{
				int size = movementTweens._size + 1;
				movementTweens._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
		}
		while (num < 10);
		CreateEnemyList();
		CreateCharacterList();
		bool flag = _congaLength <= 0;
		int num2 = 0;
		if (!flag)
		{
			do
			{
				GetNextCharacter();
				num2++;
			}
			while (num2 < _congaLength);
		}
	}

	private unsafe void CongaSwitch()
	{
		//IL_0145: Expected O, but got I4
		//IL_0224->IL028d: Incompatible stack heights: 2 vs 0
		//IL_01e9->IL028d: Incompatible stack heights: 2 vs 0
		float congaSpeed = _congaSpeed * -1.25f;
		_congaSpeed = congaSpeed;
		List<RectTransform>.Enumerator enumerator = default(List<RectTransform>.Enumerator);
		List<RectTransform>.Enumerator value = default(List<RectTransform>.Enumerator);
		Vector3 value2 = default(Vector3);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v9 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v9 (System.Object)+10]");
			Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret);
			if (0 <= (nint)ret)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v9 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v9 (System.Object)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value));
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v9 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v9 (System.Object)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref value2);
			}
		}
		if (SoundManager._003CCurrentBgm_003Ek__BackingField == BgmType.BGM_Pizza)
		{
			SoundManager.SoundConfig soundConfig = SoundManager._003CCurrentMusicSoundConfig_003Ek__BackingField;
			float num = (float)switchCount + 1f;
			float num2 = num * 0.1f;
			float rate = num2 + 1f;
			soundConfig.Rate = rate;
			SoundManager.UpdateCurrentMusicWithConfig(soundConfig);
			SoundManager.SoundConfig soundConfig2 = SoundManager._003CCurrentMusicSoundConfig_003Ek__BackingField;
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			string text = System.Number.FormatSingle(soundConfig2.Rate, null, currentInfo);
			string message = "Ratye : " + text;
			Debug.Log(message);
		}
		List<UISpriteAnimation>.Enumerator enumerator2 = default(List<UISpriteAnimation>.Enumerator);
		while (enumerator2.MoveNext())
		{
			object obj2 = null;
			object obj3 = switchCount + 8;
		}
	}

	private void CarryButton()
	{
		//IL_0021: Invalid comparison between F4 and I4
		_BackButton.SetParent(_CongaContainer, worldPositionStays: true);
		if (_congaSpeed > 0f)
		{
		}
		Vector2 anchoredPosition = default(Vector2);
		_BackButton.anchoredPosition = anchoredPosition;
		_carrySkip = true;
	}

	private void CreateWiggleTweens()
	{
		int num = 0;
		do
		{
			WiggleTween wiggleTween = new WiggleTween();
			wiggleTween.Start(num);
			List<object> movementTweens = (List<object>)(object)_movementTweens;
			int version = movementTweens._version + 1;
			movementTweens._version = version;
			object[] items = movementTweens._items;
			if (movementTweens._size >= items.Length)
			{
				movementTweens.AddWithResize((object)wiggleTween);
			}
			else
			{
				int size = movementTweens._size + 1;
				movementTweens._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
		}
		while (num < 10);
	}

	private unsafe void CreateEnemyList()
	{
		//IL_0066: Expected O, but got I
		//IL_00c0: Expected O, but got I
		//IL_0a15: Expected O, but got I
		//IL_012a: Expected O, but got I
		//IL_0a44: Expected O, but got I
		//IL_0194: Expected O, but got I
		//IL_0a6c: Expected O, but got I
		//IL_01fe: Expected O, but got I
		//IL_0a94: Expected O, but got I
		//IL_0268: Expected O, but got I
		//IL_0abc: Expected O, but got I
		//IL_02d2: Expected O, but got I
		//IL_0ae4: Expected O, but got I
		//IL_033c: Expected O, but got I
		//IL_0b0c: Expected O, but got I
		//IL_03a6: Expected O, but got I
		//IL_0b34: Expected O, but got I
		//IL_0410: Expected O, but got I
		//IL_0b5c: Expected O, but got I
		//IL_047a: Expected O, but got I
		//IL_0b84: Expected O, but got I
		//IL_04e4: Expected O, but got I
		//IL_0527: Expected O, but got Ref
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _data.GetConvertedEnemyData();
		_enemyData = convertedEnemyData;
		List<EnemyType> list = new List<EnemyType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v24+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)410);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 410;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v26+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)411);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 411;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v28+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)412);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 412;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v30+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)429);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 429;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rcx_v32+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)441);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 441;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v34+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)407);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 407;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v36+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)410);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 410;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v38+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)453);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 453;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v40+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)535);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 535;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v42+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)536);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 536;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v44+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)534);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 534;
		}
		Dictionary<EnemyType, List<EnemyData>> enemyData = _enemyData;
		EnemyType enemyType = EnemyType.BAT3;
		Dictionary<EnemyType, List<EnemyData>>.Enumerator enumerator = default(Dictionary<EnemyType, List<EnemyData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			EnemyType enemyType2 = EnemyType.BAT1;
			Dictionary<EnemyType, List<EnemyData>>.Enumerator enumerator2 = (Dictionary<EnemyType, List<EnemyData>>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		VampireSurvivors.App.Tools.Extensions.Shuffle(_enemyList);
		List<EnemyType> enemyList = _enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v50 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj23 = default(object);
			if ((nint)obj23 != -1)
			{
				bool flag = ((List<System.Int32Enum>)(object)_enemyList).Remove((System.Int32Enum)246);
			}
		}
	}

	private void GetNextCharacter()
	{
		//IL_03ac: Expected O, but got I
		//IL_0501: Invalid comparison between F4 and I4
		//IL_02b8: Expected O, but got I
		//IL_003e: Expected O, but got I8
		//IL_0091: Expected O, but got I
		//IL_0311: Expected O, but got I
		//IL_0326: Expected O, but got I
		//IL_033b: Expected O, but got I
		//IL_04a7: Expected O, but got I
		//IL_04b5: Expected I4, but got O
		//IL_0355: Expected O, but got I4
		//IL_013f: Expected O, but got I
		//IL_0154: Expected O, but got I
		//IL_0225: Expected O, but got I4
		//IL_01d2: Expected O, but got I
		//IL_01e7: Expected O, but got I
		//IL_01fc: Expected O, but got I
		//IL_044f->IL0515: Incompatible stack heights: 3 vs 2
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		FinalCreditsPage finalCreditsPage = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			finalCreditsPage = (FinalCreditsPage)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v56 @ rax_v3 (should have been resolved before IL gen)");
		if (!(0.5f > 0f))
		{
			List<CharacterType> characterList = _characterList;
			int characterCount = _characterCount;
			int characterCount2 = _characterCount;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			bool flag2 = (nint)characterCount2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v4+20+v99 @ rcx_v13 (System.Int32)*4]");
			List<string> texturesForCharacterType = CharacterLoader.GetTexturesForCharacterType(CharacterType.VOID, _playerOptions, _data);
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v4+20+v99 @ rcx_v13 (System.Int32)*4]");
				CharacterLoader.LoadCharacterTexture(null, CharacterType.VOID, _data);
			}
			Dictionary<CharacterType, List<CharacterData>> characterData = _characterData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v4+20+v99 @ rcx_v13 (System.Int32)*4]");
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)characterData).get_Item((System.Int32Enum)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v23 (System.Object)+18]");
			bool flag3 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v23 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v24+20]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rcx_v19+78]");
			int maxExclusive2;
			if ((nint)0 != 0)
			{
				Dictionary<CharacterType, List<CharacterData>> characterData2 = _characterData;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v4+20+v99 @ rcx_v13 (System.Int32)*4]");
				object obj6 = ((Dictionary<System.Int32Enum, object>)(object)characterData2).get_Item((System.Int32Enum)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v31 (System.Object)+18]");
				bool flag4 = (nint)0 <= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v31 (System.Object)+10]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v32+20]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rcx_v28+78]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ r14_v6+18]");
				System.Int32Enum maxExclusive = (System.Int32Enum)(-1);
				int num = UnityEngine.Random.RandomRangeInt(0, (int)maxExclusive);
				maxExclusive2 = num;
			}
			else
			{
				maxExclusive2 = 0;
			}
			int frameIndex = UnityEngine.Random.RandomRangeInt(0, maxExclusive2);
			List<CharacterType> characterList2 = _characterList;
			object obj10 = _characterCount + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			bool flag5 = (nint)obj10 >= 0;
			int characterCount3 = 0;
			if (!flag5)
			{
				characterCount3 = _characterCount + 1;
			}
			_characterCount = characterCount3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v4+20+v99 @ rcx_v13 (System.Int32)*4]");
			CreateCharacterAnimation(CharacterType.VOID, frameIndex);
		}
		else
		{
			List<EnemyType> enemyList = _enemyList;
			int enemyCount = _enemyCount;
			int enemyCount2 = _enemyCount;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			bool flag6 = (nint)enemyCount2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
			object obj11 = 0;
			Dictionary<EnemyType, List<EnemyData>> enemyData = _enemyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdx_v2+20+v111 @ rcx_v4 (System.Int32)*4]");
			object obj12 = ((Dictionary<System.Int32Enum, object>)(object)enemyData).get_Item((System.Int32Enum)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v8 (System.Object)+18]");
			bool flag7 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v8 (System.Object)+10]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v9+20]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rcx_v6+D8]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rdi_v2+18]");
			object obj16 = -1;
			int frameIndex2 = UnityEngine.Random.RandomRangeInt(0, (int)obj16);
			List<EnemyType> enemyList2 = _enemyList;
			object obj17 = _enemyCount + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rdx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			int enemyCount3 = (((nint)obj17 < 0) ? (_enemyCount + 1) : 0);
			_enemyCount = enemyCount3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdx_v2+20+v111 @ rcx_v4 (System.Int32)*4]");
			GameObject gameObject = CreateEnemyAnimation(EnemyType.BAT1, frameIndex2);
		}
	}

	private unsafe GameObject CreateEnemyAnimation(EnemyType type, int frameIndex = 0)
	{
		//IL_0055: Expected O, but got I
		//IL_006a: Expected O, but got I
		//IL_007f: Expected O, but got I
		//IL_0189: Expected O, but got I
		//IL_010b: Expected O, but got I
		//IL_012f: Expected O, but got I
		//IL_0154: Expected O, but got Ref
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_enemyData).get_Item((System.Int32Enum)type);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v9+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v10+C8]");
			string text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v10+C8]");
			if ((nint)0 == 0 || text._stringLength <= 0)
			{
				text = "enemies";
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v10+168]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v11+18]");
			if ((nint)frameIndex < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v11+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v7+20+frameIndex @ r8 (System.Int32)*8]");
				List<Sprite> animationFramesFast = SpriteManager.GetAnimationFramesFast((List<string>)0, text);
				GameObject gameObject = CreatePawn(animationFramesFast);
				IntPtr intPtr = default(IntPtr);
				string text2 = ((Enum)(&intPtr)).ToString();
				((UnityEngine.Object)gameObject).SetName(text2);
				return gameObject;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	private unsafe void CreateCharacterAnimation(CharacterType type, int frameIndex = 0)
	{
		//IL_0055: Expected O, but got I
		//IL_006a: Expected O, but got I
		//IL_007f: Expected O, but got I
		//IL_008f: Expected O, but got I
		//IL_016c: Expected O, but got I
		//IL_02d2: Expected O, but got Ref
		//IL_01a3: Expected O, but got I
		//IL_01b8: Expected O, but got I
		//IL_01cd: Expected O, but got I
		//IL_01dd: Expected O, but got I
		//IL_01ed: Expected O, but got I
		//IL_0202: Expected O, but got I
		//IL_0249: Expected O, but got I
		//IL_025e: Expected O, but got I
		//IL_0273: Expected O, but got I
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_characterData).get_Item((System.Int32Enum)type);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v10 (System.Object)+18]");
		string text;
		string text2;
		int start;
		int end;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v10 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v6+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+40]");
			text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+48]");
			text2 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+40]");
			if ((nint)0 == 0 || text._stringLength <= 0)
			{
				text = "characters";
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+108]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+108]");
				if ((nint)0 == 0)
				{
					goto IL_0320;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+108]");
				start = (int)((nint)0 >> 32);
			}
			else
			{
				start = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+110]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+68]");
			end = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+110]");
				if ((nint)0 == 0)
				{
					goto IL_0320;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+78]");
			if ((nint)0 == 0)
			{
				goto IL_0278;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+78]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v17+18]");
			if ((nint)frameIndex < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v17+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v18+20+frameIndex @ r8 (System.Int32)*8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbp_v9+38]");
				text = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+78]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v19+10]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rcx_v19+20+frameIndex @ r8 (System.Int32)*8]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rcx_v20+58]");
				end = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v19+18]");
				if ((nint)frameIndex < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v19+10]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v21+20+frameIndex @ r8 (System.Int32)*8]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v22+40]");
					text2 = (string)0;
					goto IL_0278;
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0320:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		throw new IndexOutOfRangeException();
		IL_0278:
		string animName = text2.Replace("01.png", "");
		int zeroPad = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, start, end, text, zeroPad);
		GameObject gameObject = CreatePawn(animationFrames, flip: true);
		IntPtr intPtr = default(IntPtr);
		string text3 = ((Enum)(&intPtr)).ToString();
		((UnityEngine.Object)gameObject).SetName(text3);
	}

	private unsafe GameObject CreatePawn(List<Sprite> sprites, bool flip = false)
	{
		//IL_02ef: Expected I, but got O
		//IL_0398->IL0258: Incompatible stack heights: 11 vs 0
		//IL_03da->IL037e: Incompatible stack heights: 12 vs 11
		GameObject gameObject = UnityEngine.Object.Instantiate(_CongaItem, _CongaContainer);
		if ((object)gameObject != null)
		{
			Transform componentInChildren = (Transform)(object)gameObject.GetComponentInChildren<UISpriteAnimation>(includeInactive: false);
			if ((object)componentInChildren != null)
			{
				RectTransform component = gameObject.GetComponent<RectTransform>();
				if (_anims != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E360");
					bool flag = sprites == null;
					bool flag2 = sprites._size <= 0;
					Sprite[] items = sprites._items;
					bool flag3 = sprites._items == null;
					if (items.Length <= 0)
					{
						throw new IndexOutOfRangeException();
					}
					Transform transform = (Transform)(object)items[0];
					bool flag4 = (object)items[0] == null;
					bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Rect _);
					bool flag6 = sprites._size <= 0;
					List<Sprite> items2 = (List<Sprite>)(object)sprites._items;
					bool flag7 = sprites._items == null;
					bool flag8 = items2._size <= 0;
					List<Sprite> syncRoot = (List<Sprite>)items2._syncRoot;
					bool flag9 = items2._syncRoot == null;
					bool flag10 = syncRoot._items == null;
					Sprite.get_rect_Injected((IntPtr)syncRoot._items, out Rect _);
					object obj = default(object);
					float num = (float)obj * 1.6f;
					float num2 = num * 2.5f;
					bool flag11 = (object)component == null;
					Vector2 vector = default(Vector2);
					component.sizeDelta = vector;
					float screenWidth = UIHelper.ScreenWidth;
					component.anchoredPosition = vector;
					Vector2 sizeDelta = component.sizeDelta;
					float widthCounter = (float)sizeDelta + _widthCounter;
					_widthCounter = widthCounter;
					VampireSurvivors.App.Tools.Extensions.SetPivot(component, vector);
					bool flag12 = !flip;
					Vector2 vector2 = vector;
					if (!flag12)
					{
						bool flag13 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						Vector2 value = default(Vector2);
						Transform.set_localScale_Injected(((UnityEngine.Object)component).m_CachedPtr, ref *(Vector3*)(&value));
						vector2 = vector;
					}
					if (_spawnedConga != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D750");
						return gameObject;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void CreateCharacterList()
	{
		//IL_0043: Expected O, but got Ref
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
		_characterData = convertedCharacterData;
		Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator = default(Dictionary<CharacterType, List<CharacterData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			CharacterType characterType = CharacterType.VOID;
			Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator2 = (Dictionary<CharacterType, List<CharacterData>>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		VampireSurvivors.App.Tools.Extensions.Shuffle(_characterList);
		List<CharacterType> characterList = _characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdi_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		int num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdi_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 >= (nint)20)
		{
			num = 20;
		}
		List<CharacterType> characterList2 = _characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		int count = (int)(-num);
		_characterList.RemoveRange(num, count);
	}

	private void BuildCredits()
	{
		TextMeshProUGUI component = _TextPrefab.GetComponent<TextMeshProUGUI>();
		string creditsText = Credits.GetCreditsText();
		component.text = creditsText;
	}

	public FinalCreditsPage()
	{
		//IL_00af: Expected O, but got I
		//IL_0109: Expected O, but got I
		//IL_0312: Expected O, but got I
		//IL_0173: Expected O, but got I
		//IL_033a: Expected O, but got I
		//IL_01dd: Expected O, but got I
		//IL_0362: Expected O, but got I
		//IL_0247: Expected O, but got I
		//IL_02a6: Expected O, but got I4
		List<WiggleTween> movementTweens = new List<WiggleTween>();
		_movementTweens = movementTweens;
		_enemyList = new List<EnemyType>();
		_characterList = new List<CharacterType>();
		_enemyData = new Dictionary<EnemyType, List<EnemyData>>();
		_characterData = new Dictionary<CharacterType, List<CharacterData>>();
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rdx_v14+18]");
		if (num >= 0)
		{
			list.AddWithResize(150000f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1209170944;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rdx_v15+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(180000f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1211090944;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rdx_v16+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(210000f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1213010944;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ rdx_v17+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(240000f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1214930944;
		}
		_switchTimes = list;
		_chickenTime = 270000f;
		_anims = new List<UISpriteAnimation>();
		_congaSpeed = 1f;
		_congaLength = 300;
		_JSDefaultScreenSize = (Vector2)1135280128;
		_ = 1139015680;
		_spawnedConga = new List<RectTransform>();
		base._002Ector();
	}

	private void _003COnShowStart_003Eb__30_2()
	{
		CongaSwitch();
	}

	private void _003COnShowStart_003Eb__30_1()
	{
		Transform transform = _BackButton.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void _003CFadeInText_003Eb__31_0()
	{
		Transform child = _Container.GetChild(0);
		RectTransform component = child.GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		float endValue = default(float);
		TweenerCore<Vector2, Vector2, VectorOptions> t = DOTweenModuleUI.DOAnchorPosY(_Container, endValue, 90f);
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 1f);
		TweenCallback tweenCallback = delegate
		{
			CanvasGroup component2 = _Container.GetComponent<CanvasGroup>();
			TweenerCore<float, float, FloatOptions> t2 = DOTweenModuleUI.DOFade(component2, 0f, 1f);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, 60f);
			TweenerCore<Color, Color, ColorOptions> t3 = DOTweenModuleUI.DOFade(_Title, 0f, 1f);
			TweenerCore<Color, Color, ColorOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay(t3, 60f);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void _003CScrollText_003Eb__32_0()
	{
		CanvasGroup component = _Container.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> t = DOTweenModuleUI.DOFade(component, 0f, 1f);
		TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 60f);
		TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleUI.DOFade(_Title, 0f, 1f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, 60f);
	}
}
