using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Lexone.UnityTwitchChat;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Tools;
using VampireSurvivors.App.UI.Twitch;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;

namespace VampireSurvivors.App.Scripts.Objects;

public class StageEventTwitchManager : StageEventManager
{
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public string eventType;

		public StageEventTwitchManager _003C_003E4__this;

		public StageEventType stageEventType;

		public float? chance;

		public float? duration;

		public int moreX;

		public object moreY;

		public TextMeshProUGUI text;

		public TextMeshProUGUI option;

		internal void _003CTriggerEvents_003Eb__1()
		{
			string message = "EventTriggered: " + eventType;
			Debug.Log(message);
			int num = default(int);
			object obj = default(object);
			float moreZ = default(float);
			bool fromTrisection = default(bool);
			bool flag = _003C_003E4__this.TriggerSwitchEvent(stageEventType, chance, duration, num, obj, moreZ, fromTrisection);
		}

		internal unsafe void _003CTriggerEvents_003Eb__0()
		{
			//IL_0023: Expected O, but got Ref
			//IL_0046: Expected O, but got Ref
			Color color = text.color;
			object obj = default(object);
			text.color = (Color)(&obj);
			Color color2 = option.color;
			option.color = (Color)(&obj);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
		}
	}

	private bool _active;

	private float _panelWidth;

	private float _panelHeight;

	private float _panelHideX;

	private float _panelX;

	private float _panelY;

	private int _twitchLimitCount;

	private Timer _twitchTimer;

	private List<int> _twitchOptionCounter;

	private List<VampireSurvivors.Data.Stage.Event> _mediaEvents;

	private List<TextMeshProUGUI> _twitchOptions;

	private readonly List<VampireSurvivors.Data.Stage.Event> _goodEvents;

	private readonly List<VampireSurvivors.Data.Stage.Event> _neutralEvents;

	private readonly List<VampireSurvivors.Data.Stage.Event> _badEvents;

	private TwitchStageEventsPanel EventsPanel
	{
		get
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				MainGamePage mainGamePage = core._003CMainUI_003Ek__BackingField;
				if ((object)core._003CMainUI_003Ek__BackingField != null)
				{
					return mainGamePage._TwitchStageEventsPanel;
				}
			}
			return (TwitchStageEventsPanel)(object)new NullReferenceException();
		}
	}

	public override void Init(Stage stage)
	{
		base.Init(stage);
	}

	public unsafe void ShowTwitchUI()
	{
		//IL_09bc: Expected O, but got F4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0082: Expected I4, but got O
		//IL_09d4: Expected O, but got F4
		//IL_09dd: Invalid comparison between F4 and O
		//IL_0a0b: Expected O, but got F4
		//IL_0126: Expected I4, but got O
		//IL_09fd: Expected O, but got F4
		//IL_00ae: Expected I4, but got O
		//IL_0186: Expected I4, but got O
		//IL_0a19: Expected O, but got F4
		//IL_01a4: Expected I4, but got O
		//IL_01f7: Expected I4, but got O
		//IL_0275: Expected I4, but got O
		//IL_0296: Expected I4, but got O
		//IL_02b7: Expected I4, but got O
		//IL_0a50: Expected I, but got O
		//IL_0334: Expected I4, but got O
		//IL_036f: Expected I4, but got O
		//IL_03aa: Expected I4, but got O
		//IL_04f9: Expected O, but got I4
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected O, but got Unknown
		//IL_06ed: Expected O, but got Ref
		//IL_073a: Expected O, but got Ref
		//IL_0787: Expected O, but got Ref
		//IL_07d4: Expected O, but got Ref
		//IL_0821: Expected O, but got Ref
		//IL_086e: Expected O, but got Ref
		//IL_0a55->IL0ba3: Incompatible stack heights: 1 vs 0
		object obj3 = default(object);
		List<VampireSurvivors.Data.Stage.Event> list2 = default(List<VampireSurvivors.Data.Stage.Event>);
		object obj6 = default(object);
		object obj9 = default(object);
		object obj11 = default(object);
		List<TextMeshProUGUI>.Enumerator enumerator = default(List<TextMeshProUGUI>.Enumerator);
		string text6 = default(string);
		Behaviour behaviour = default(Behaviour);
		Vector2 vector = default(Vector2);
		Vector2 endValue = default(Vector2);
		while (true)
		{
			List<VampireSurvivors.Data.Stage.Event> list = (_mediaEvents = new List<VampireSurvivors.Data.Stage.Event>());
			List<VampireSurvivors.Data.Stage.Event> goodEvents = _goodEvents;
			object obj = UnityEngine.Random.value;
			List<VampireSurvivors.Data.Stage.Event> goodEvents2 = _goodEvents;
			object obj2 = goodEvents2._size * obj3;
			list._002Ector();
			if ((nint)list2 < goodEvents._size)
			{
				VampireSurvivors.Data.Stage.Event[] items = goodEvents._items;
				((List<int>)(object)_mediaEvents).Add((int)items[(object)list2]);
				object obj4 = UnityEngine.Random.value;
				VampireSurvivors.Data.Stage.Event obj7;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					List<VampireSurvivors.Data.Stage.Event> neutralEvents = _neutralEvents;
					object obj5 = UnityEngine.Random.value;
					((List<int>)(object)_mediaEvents).Add((int)items[(object)list2]);
					if ((nint)obj6 >= neutralEvents._size)
					{
						goto IL_0994;
					}
					VampireSurvivors.Data.Stage.Event[] items2 = neutralEvents._items;
					obj7 = items2[obj6];
				}
				else
				{
					List<VampireSurvivors.Data.Stage.Event> badEvents = _badEvents;
					object obj8 = UnityEngine.Random.value;
					((List<int>)(object)_mediaEvents).Add((int)items[(object)list2]);
					if ((nint)obj9 >= badEvents._size)
					{
						goto IL_0994;
					}
					VampireSurvivors.Data.Stage.Event[] items3 = badEvents._items;
					obj7 = items3[obj9];
				}
				((List<int>)(object)_mediaEvents).Add((int)obj7);
				List<VampireSurvivors.Data.Stage.Event> badEvents2 = _badEvents;
				object obj10 = UnityEngine.Random.value;
				((List<int>)(object)_mediaEvents).Add((int)obj7);
				if ((nint)obj11 < badEvents2._size)
				{
					VampireSurvivors.Data.Stage.Event[] items4 = badEvents2._items;
					((List<int>)(object)_mediaEvents).Add((int)items4[obj11]);
					if (_mediaEvents == null)
					{
						break;
					}
					List<VampireSurvivors.Data.Stage.Event> mediaEvents = _mediaEvents;
					if (mediaEvents._size <= 0)
					{
						break;
					}
					List<TextMeshProUGUI> list3 = new List<TextMeshProUGUI>();
					TwitchStageEventsPanel eventsPanel = EventsPanel;
					((List<int>)(object)list3).Add((int)eventsPanel._Text1);
					TwitchStageEventsPanel eventsPanel2 = EventsPanel;
					((List<int>)(object)list3).Add((int)eventsPanel2._Text2);
					TwitchStageEventsPanel eventsPanel3 = EventsPanel;
					((List<int>)(object)list3).Add((int)eventsPanel3._Text3);
					_twitchOptions = list3;
					List<TextMeshProUGUI> twitchOptions = _twitchOptions;
					while (enumerator.MoveNext())
					{
						List<VampireSurvivors.Data.Stage.Event> list4 = null;
						bool flag = list4._items == null;
						Behaviour.set_enabled_Injected((IntPtr)list4._items, false);
					}
					List<int> twitchOptionCounter = new List<int>();
					_twitchOptionCounter = twitchOptionCounter;
					List<TextMeshProUGUI> list5 = new List<TextMeshProUGUI>();
					GameManager core = GM.Core;
					MainGamePage mainGamePage = core._003CMainUI_003Ek__BackingField;
					TwitchStageEventsPanel twitchStageEventsPanel = mainGamePage._TwitchStageEventsPanel;
					((List<int>)(object)list5).Add((int)twitchStageEventsPanel._Option1);
					GameManager core2 = GM.Core;
					MainGamePage mainGamePage2 = core2._003CMainUI_003Ek__BackingField;
					TwitchStageEventsPanel twitchStageEventsPanel2 = mainGamePage2._TwitchStageEventsPanel;
					((List<int>)(object)list5).Add((int)twitchStageEventsPanel2._Option2);
					GameManager core3 = GM.Core;
					MainGamePage mainGamePage3 = core3._003CMainUI_003Ek__BackingField;
					TwitchStageEventsPanel twitchStageEventsPanel3 = mainGamePage3._TwitchStageEventsPanel;
					((List<int>)(object)list5).Add((int)twitchStageEventsPanel3._Option3);
					List<VampireSurvivors.Data.Stage.Event> mediaEvents2 = _mediaEvents;
					List<VampireSurvivors.Data.Stage.Event> list6 = null;
					List<VampireSurvivors.Data.Stage.Event> list7 = null;
					StageEventTwitchManager stageEventTwitchManager = this;
					while (true)
					{
						if ((nint)list7 < mediaEvents2._size)
						{
							List<VampireSurvivors.Data.Stage.Event> mediaEvents3 = _mediaEvents;
							if ((nint)list6 >= mediaEvents3._size)
							{
								break;
							}
							VampireSurvivors.Data.Stage.Event[] items5 = mediaEvents3._items;
							VampireSurvivors.Data.Stage.Event obj12 = items5[(object)list6];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2EC3]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							string text = obj12._003CeventType_003Ek__BackingField.ToString();
							string text2 = text.Replace("_", " ");
							bool flag2 = obj12._003Crepeat_003Ek__BackingField <= 0;
							string text3 = text2;
							string text4 = " ";
							if (!flag2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
								string text5 = text2 + text6;
								text3 = text5;
								text4 = null;
								stageEventTwitchManager = (StageEventTwitchManager)obj12._003Crepeat_003Ek__BackingField;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							behaviour.enabled = true;
							_twitchOptionCounter.Add(0);
							list6 = (List<VampireSurvivors.Data.Stage.Event>)(list6 + 1);
							mediaEvents2 = _mediaEvents;
							list7 = list6;
							continue;
						}
						GameManager core4 = GM.Core;
						MainGamePage mainGamePage4 = core4._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel4 = mainGamePage4._TwitchStageEventsPanel;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
						GameManager core5 = GM.Core;
						MainGamePage mainGamePage5 = core5._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel5 = mainGamePage5._TwitchStageEventsPanel;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
						GameManager core6 = GM.Core;
						MainGamePage mainGamePage6 = core6._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel6 = mainGamePage6._TwitchStageEventsPanel;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
						GameManager core7 = GM.Core;
						MainGamePage mainGamePage7 = core7._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel7 = mainGamePage7._TwitchStageEventsPanel;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
						GameManager core8 = GM.Core;
						MainGamePage mainGamePage8 = core8._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel8 = mainGamePage8._TwitchStageEventsPanel;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
						GameManager core9 = GM.Core;
						MainGamePage mainGamePage9 = core9._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel9 = mainGamePage9._TwitchStageEventsPanel;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
						GameManager core10 = GM.Core;
						MainGamePage mainGamePage10 = core10._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel10 = mainGamePage10._TwitchStageEventsPanel;
						Color color = twitchStageEventsPanel10._Option1.color;
						twitchStageEventsPanel10._Option1.color = (Color)(&twitchOptions);
						GameManager core11 = GM.Core;
						MainGamePage mainGamePage11 = core11._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel11 = mainGamePage11._TwitchStageEventsPanel;
						Color color2 = twitchStageEventsPanel11._Option2.color;
						twitchStageEventsPanel11._Option2.color = (Color)(&twitchOptions);
						GameManager core12 = GM.Core;
						MainGamePage mainGamePage12 = core12._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel12 = mainGamePage12._TwitchStageEventsPanel;
						Color color3 = twitchStageEventsPanel12._Option3.color;
						twitchStageEventsPanel12._Option3.color = (Color)(&twitchOptions);
						GameManager core13 = GM.Core;
						MainGamePage mainGamePage13 = core13._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel13 = mainGamePage13._TwitchStageEventsPanel;
						Color color4 = twitchStageEventsPanel13._Text1.color;
						twitchStageEventsPanel13._Text1.color = (Color)(&twitchOptions);
						GameManager core14 = GM.Core;
						MainGamePage mainGamePage14 = core14._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel14 = mainGamePage14._TwitchStageEventsPanel;
						Color color5 = twitchStageEventsPanel14._Text2.color;
						twitchStageEventsPanel14._Text2.color = (Color)(&twitchOptions);
						GameManager core15 = GM.Core;
						MainGamePage mainGamePage15 = core15._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel15 = mainGamePage15._TwitchStageEventsPanel;
						Color color6 = twitchStageEventsPanel15._Text3.color;
						twitchStageEventsPanel15._Text3.color = (Color)(&vector);
						GameManager core16 = GM.Core;
						MainGamePage mainGamePage16 = core16._003CMainUI_003Ek__BackingField;
						TwitchStageEventsPanel twitchStageEventsPanel16 = mainGamePage16._TwitchStageEventsPanel;
						if ((object)twitchStageEventsPanel16._defaultAnchoredPos != null)
						{
							TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(twitchStageEventsPanel16._rectTransform, endValue, 0.15f);
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3171 @ rax_v171 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									_ = 0;
								}
							}
							TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTweenModuleUI.DOFade(twitchStageEventsPanel16._CanvasGroup, 0.65f, 0.15f);
							if (tweenerCore2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3182 @ rax_v173 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									_ = 0;
								}
							}
						}
						EnableTwitch();
						_active = true;
						return;
					}
				}
			}
			goto IL_0994;
			IL_0994:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void HideTwitchUI()
	{
		GameManager core = GM.Core;
		MainGamePage mainGamePage = core._003CMainUI_003Ek__BackingField;
		TwitchStageEventsPanel twitchStageEventsPanel = mainGamePage._TwitchStageEventsPanel;
		if ((object)twitchStageEventsPanel._hideAnchorPos != null)
		{
			Vector2 endValue = default(Vector2);
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(twitchStageEventsPanel._rectTransform, endValue, 0.15f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTweenModuleUI.DOFade(twitchStageEventsPanel._CanvasGroup, 0f, 0.15f);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
		}
		_active = false;
	}

	public void QuickShow()
	{
		GameManager core = GM.Core;
		MainGamePage mainGamePage = core._003CMainUI_003Ek__BackingField;
		TwitchStageEventsPanel twitchStageEventsPanel = mainGamePage._TwitchStageEventsPanel;
		twitchStageEventsPanel._CanvasGroup.alpha = 0.65f;
		twitchStageEventsPanel._UsernamesCanvasGroup.alpha = 1f;
	}

	public void QuickHide()
	{
		GameManager core = GM.Core;
		MainGamePage mainGamePage = core._003CMainUI_003Ek__BackingField;
		TwitchStageEventsPanel twitchStageEventsPanel = mainGamePage._TwitchStageEventsPanel;
		twitchStageEventsPanel._CanvasGroup.alpha = 0f;
		twitchStageEventsPanel._UsernamesCanvasGroup.alpha = 0f;
	}

	public unsafe bool TriggerEvents()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0118: Expected O, but got I4
		//IL_02ad: Expected O, but got Ref
		//IL_02fe: Expected O, but got Ref
		//IL_034f: Expected O, but got Ref
		//IL_03a0: Expected O, but got Ref
		//IL_03f1: Expected O, but got Ref
		//IL_0442: Expected O, but got Ref
		//IL_0489: Expected O, but got Ref
		//IL_04d0: Expected O, but got Ref
		//IL_0517: Expected O, but got Ref
		//IL_062c: Invalid comparison between F4 and I4
		//IL_0671: Expected F4, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals31 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals31._003C_003E4__this = this;
		IRC twitchClient = TwitchIntegration._sInstance.TwitchClient;
		Action<Chatter> value = ProcessMessage;
		twitchClient.OnChatMessage -= value;
		if (_twitchTimer != null)
		{
			_twitchTimer.Cancel();
		}
		TextMeshProUGUI option;
		VampireSurvivors.Data.Stage.Event obj4;
		if (_mediaEvents != null)
		{
			List<VampireSurvivors.Data.Stage.Event> mediaEvents = _mediaEvents;
			if (mediaEvents._size > 0)
			{
				CS_0024_003C_003E8__locals31.text = null;
				int num = CalculateChoice();
				bool flag = num == 0;
				if (flag)
				{
					goto IL_01ee;
				}
				object obj3 = num - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						goto IL_01ee;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					TwitchStageEventsPanel eventsPanel = EventsPanel;
					CS_0024_003C_003E8__locals31.text = eventsPanel._Text3;
					TwitchStageEventsPanel eventsPanel2 = EventsPanel;
					option = eventsPanel2._Option3;
					VampireSurvivors.Data.Stage.Event obj5 = default(VampireSurvivors.Data.Stage.Event);
					obj4 = obj5;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					TwitchStageEventsPanel eventsPanel3 = EventsPanel;
					CS_0024_003C_003E8__locals31.text = eventsPanel3._Text2;
					TwitchStageEventsPanel eventsPanel4 = EventsPanel;
					option = eventsPanel4._Option2;
					VampireSurvivors.Data.Stage.Event obj6 = default(VampireSurvivors.Data.Stage.Event);
					obj4 = obj6;
				}
				goto IL_076a;
			}
		}
		bool flag2 = false;
		goto IL_0790;
		IL_0790:
		return flag2;
		IL_01ee:
		List<VampireSurvivors.Data.Stage.Event> mediaEvents2 = _mediaEvents;
		if (mediaEvents2._size > 0)
		{
			VampireSurvivors.Data.Stage.Event[] items = mediaEvents2._items;
			obj4 = items[0];
			TwitchStageEventsPanel eventsPanel5 = EventsPanel;
			CS_0024_003C_003E8__locals31.text = eventsPanel5._Text1;
			TwitchStageEventsPanel eventsPanel6 = EventsPanel;
			option = eventsPanel6._Option1;
			goto IL_076a;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
		IL_076a:
		CS_0024_003C_003E8__locals31.option = option;
		TwitchStageEventsPanel eventsPanel7 = EventsPanel;
		Color color = eventsPanel7._Option1.color;
		Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 1056964608;
		eventsPanel7._Option1.color = color2;
		TwitchStageEventsPanel eventsPanel8 = EventsPanel;
		Color color3 = eventsPanel8._Option2.color;
		Color color4 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 1056964608;
		eventsPanel8._Option2.color = color4;
		TwitchStageEventsPanel eventsPanel9 = EventsPanel;
		Color color5 = eventsPanel9._Option3.color;
		Color color6 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 1056964608;
		eventsPanel9._Option3.color = color6;
		TwitchStageEventsPanel eventsPanel10 = EventsPanel;
		Color color7 = eventsPanel10._Text1.color;
		Color color8 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 1056964608;
		eventsPanel10._Text1.color = color8;
		TwitchStageEventsPanel eventsPanel11 = EventsPanel;
		Color color9 = eventsPanel11._Text2.color;
		Color color10 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 1056964608;
		eventsPanel11._Text2.color = color10;
		TwitchStageEventsPanel eventsPanel12 = EventsPanel;
		Color color11 = eventsPanel12._Text3.color;
		Color color12 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 1056964608;
		eventsPanel12._Text3.color = color12;
		Color color13 = CS_0024_003C_003E8__locals31.text.color;
		Color color14 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 1065353216;
		CS_0024_003C_003E8__locals31.text.color = color14;
		Color color15 = CS_0024_003C_003E8__locals31.option.color;
		Color color16 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 1065353216;
		CS_0024_003C_003E8__locals31.option.color = color16;
		Color color17 = CS_0024_003C_003E8__locals31.text.color;
		Color color18 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 1065353216;
		_ = 1065353216;
		CS_0024_003C_003E8__locals31.text.color = color18;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
		Action onComplete = HideTwitchUI;
		bool flag3 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num2 = default(int);
		TimerType timerType = default(TimerType);
		Timer timer = Timers.Register(5f, onComplete, null, isLooped: false, flag3, monoBehaviour, num2, timerType, isOnlineTimer: false, canPause: false);
		CS_0024_003C_003E8__locals31.eventType = obj4._003CeventType_003Ek__BackingField;
		StageEventType stageEventType = Enum.Parse<StageEventType>(CS_0024_003C_003E8__locals31.eventType);
		CS_0024_003C_003E8__locals31.stageEventType = stageEventType;
		CS_0024_003C_003E8__locals31.chance = obj4._003Cchance_003Ek__BackingField;
		CS_0024_003C_003E8__locals31.duration = obj4._003Cduration_003Ek__BackingField;
		CS_0024_003C_003E8__locals31.moreX = obj4._003CmoreX_003Ek__BackingField;
		CS_0024_003C_003E8__locals31.moreY = obj4._003CmoreY_003Ek__BackingField;
		if (!(obj4._003Cdelay_003Ek__BackingField > 0f))
		{
			flag2 = TriggerSwitchEvent(CS_0024_003C_003E8__locals31.stageEventType, CS_0024_003C_003E8__locals31.chance, CS_0024_003C_003E8__locals31.duration, flag3 ? 1 : 0, monoBehaviour, num2, (byte)timerType != 0);
			if (!flag2)
			{
				Action onComplete2 = delegate
				{
					//IL_0023: Expected O, but got Ref
					//IL_0046: Expected O, but got Ref
					Color color19 = CS_0024_003C_003E8__locals31.text.color;
					object obj7 = default(object);
					CS_0024_003C_003E8__locals31.text.color = (Color)(&obj7);
					Color color20 = CS_0024_003C_003E8__locals31.option.color;
					CS_0024_003C_003E8__locals31.option.color = (Color)(&obj7);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
				};
				Timer timer2 = Timers.Register(2.5f, onComplete2, null, isLooped: false, flag3, monoBehaviour, num2, timerType, isOnlineTimer: false, canPause: false);
				flag2 = false;
			}
		}
		else
		{
			Action onComplete3 = delegate
			{
				string message = "EventTriggered: " + CS_0024_003C_003E8__locals31.eventType;
				Debug.Log(message);
				int moreX = default(int);
				object moreY = default(object);
				float moreZ = default(float);
				bool fromTrisection = default(bool);
				bool flag4 = CS_0024_003C_003E8__locals31._003C_003E4__this.TriggerSwitchEvent(CS_0024_003C_003E8__locals31.stageEventType, CS_0024_003C_003E8__locals31.chance, CS_0024_003C_003E8__locals31.duration, moreX, moreY, moreZ, fromTrisection);
			};
			float duration = obj4._003Cdelay_003Ek__BackingField * 0.001f;
			Timer timer3 = Timers.Register(duration, onComplete3, null, isLooped: false, flag3, monoBehaviour, num2, timerType, isOnlineTimer: false, canPause: false);
			flag2 = false;
		}
		goto IL_0790;
	}

	private void EnableTwitch()
	{
		IRC twitchClient = TwitchIntegration._sInstance.TwitchClient;
		Action<Chatter> value = ProcessMessage;
		twitchClient.OnChatMessage += value;
		if (_twitchTimer != null)
		{
			_twitchTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_twitchLimitCount = 0;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer twitchTimer = Timers.Register(0.033f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_twitchTimer = twitchTimer;
	}

	private void DisableTwitch()
	{
		IRC twitchClient = TwitchIntegration._sInstance.TwitchClient;
		Action<Chatter> value = ProcessMessage;
		twitchClient.OnChatMessage -= value;
		if (_twitchTimer != null)
		{
			_twitchTimer.Cancel();
		}
	}

	private unsafe void ProcessMessage(Chatter chatter)
	{
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected Ref, but got Unknown
		//IL_013a: Expected I8, but got I4
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected Ref, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Ref, but got Unknown
		//IL_022d: Expected I8, but got I4
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected Ref, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected Ref, but got Unknown
		//IL_0320: Expected I8, but got I4
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2EC0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (chatter == null || _twitchLimitCount > 20)
		{
			return;
		}
		int twitchLimitCount = _twitchLimitCount + 1;
		_twitchLimitCount = twitchLimitCount;
		string message = chatter.message;
		object obj = "a";
		if ((object)chatter.message == "a")
		{
			goto IL_03b9;
		}
		if (chatter.message != null && "a" != null)
		{
			int stringLength = message._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v2+10]");
			if ((nint)stringLength == 0)
			{
				ref byte first = ref *(byte*)(chatter.message + 20);
				ulong length = (ulong)(message._stringLength + message._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("a" + 20), length))
				{
					goto IL_03b9;
				}
			}
		}
		object obj2 = "b";
		if ((object)chatter.message == "b")
		{
			goto IL_038b;
		}
		if (chatter.message != null && "b" != null)
		{
			int stringLength2 = message._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v9+10]");
			if ((nint)stringLength2 == 0)
			{
				ref byte first2 = ref *(byte*)(chatter.message + 20);
				ulong length2 = (ulong)(message._stringLength + message._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("b" + 20), length2))
				{
					goto IL_038b;
				}
			}
		}
		object obj3 = "c";
		if ((object)chatter.message != "c")
		{
			if (chatter.message == null || "c" == null)
			{
				return;
			}
			int stringLength3 = message._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rdx_v13+10]");
			if ((nint)stringLength3 != 0)
			{
				return;
			}
			ref byte first3 = ref *(byte*)(chatter.message + 20);
			ulong length3 = (ulong)(message._stringLength + message._stringLength);
			if (!System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("c" + 20), length3))
			{
				return;
			}
		}
		IRCTags tags = chatter.tags;
		string displayName = tags.displayName;
		int num = 2;
		goto IL_0405;
		IL_038b:
		IRCTags tags2 = chatter.tags;
		displayName = tags2.displayName;
		num = 1;
		goto IL_0405;
		IL_0405:
		IncreaseTwitchOption(num, displayName);
		return;
		IL_03b9:
		IRCTags tags3 = chatter.tags;
		displayName = tags3.displayName;
		num = 0;
		goto IL_0405;
	}

	private unsafe void IncreaseTwitchOption(int num, string username)
	{
		//IL_0077: Expected O, but got I
		//IL_0092: Expected O, but got I
		//IL_01a5: Expected O, but got Ref
		if (!_active || PauseSystem._paused)
		{
			return;
		}
		List<int> twitchOptionCounter = _twitchOptionCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)num >= (nint)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v5+20+num @ rdx (System.Int32)*4]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
			List<TextMeshProUGUI> twitchOptions = _twitchOptions;
			if (num < twitchOptions._size)
			{
				TextMeshProUGUI[] items = twitchOptions._items;
				TextMeshProUGUI textMeshProUGUI = RenderingExtensions.SetScale(items[num], 1.1f);
				Transform transform = items[num].transform;
				TweenerCore<Vector3, Vector3, VectorOptions> component = ShortcutExtensions.DOScale(transform, 1f, 0.1f);
				TextMeshProUGUI textMeshProUGUI2 = RenderingExtensions.SetScale((TextMeshProUGUI)(object)component, 1f);
				RectTransform component2 = items[num].GetComponent<RectTransform>();
				Rect worldRect = VampireSurvivors.App.Tools.Extensions.GetWorldRect(component2);
				TwitchStageEventsPanel eventsPanel = EventsPanel;
				object obj3 = default(object);
				eventsPanel.ShowUsernameAt((Vector3)(&obj3), username);
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private int CalculateChoice()
	{
		//IL_023f: Expected I, but got O
		//IL_024d: Expected I, but got O
		//IL_0252: Expected I, but got O
		//IL_0257: Expected I, but got O
		//IL_02f7: Expected O, but got I4
		//IL_011f: Expected I, but got O
		//IL_012d: Expected I, but got O
		//IL_004b: Expected O, but got I
		//IL_0169: Expected O, but got I
		//IL_00c9: Expected I, but got O
		//IL_00eb->IL02b9: Incompatible stack heights: 1 vs 0
		//IL_0218->IL0306: Incompatible stack heights: 1 vs 0
		//IL_0225->IL02e0: Incompatible stack heights: 1 vs 0
		//IL_01fd->IL0306: Incompatible stack heights: 1 vs 0
		List<int> twitchOptionCounter = _twitchOptionCounter;
		nint num = unchecked((nint)null);
		int num2 = 0;
		nint num3 = unchecked((nint)null);
		nint num4 = unchecked((nint)null);
		nint num5 = unchecked((nint)null);
		object obj2 = default(object);
		IntPtr intPtr4 = default(IntPtr);
		while (true)
		{
			nint intPtr = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v6 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if (intPtr < 0)
			{
				List<int> twitchOptionCounter2 = _twitchOptionCounter;
				nint intPtr2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v19 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if (intPtr2 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v19 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj = 0;
					nint intPtr3 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v9+18]");
					bool flag = intPtr3 >= 0;
					nint num6 = num3 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v9+20+v64 @ rbx_v3 (Il2CppMethodInfo)*4]");
					if (0 != num3)
					{
						num6 = num3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
					bool flag2 = (nint)obj2 <= num4;
					nint num7 = num2;
					num3 = num6;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
						num7 = num;
						num3 = unchecked((nint)null);
						num4 = intPtr4;
					}
					twitchOptionCounter = _twitchOptionCounter;
					num++;
					num2 = (int)num7;
					num5 = num;
					continue;
				}
				goto IL_0225;
			}
			if (num3 <= 0)
			{
				break;
			}
			object obj3 = UnityEngine.Random.RandomRangeInt(0, (int)num3);
			List<int> twitchOptionCounter3 = _twitchOptionCounter;
			List<int> twitchOptionCounter4 = _twitchOptionCounter;
			nint num8 = unchecked((nint)null);
			int num9 = 0;
			nint num10 = unchecked((nint)null);
			while (true)
			{
				nint intPtr5 = num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r10_v4 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if (intPtr5 >= 0)
				{
					break;
				}
				int num11 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v4 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)num11 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v4 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj4 = 0;
					int num12 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v8+18]");
					bool flag3 = (nint)num12 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v8+20+v99 @ rax_v15 (System.Int32)*4]");
					if (0 == num4)
					{
						if (num8 == (nint)obj3)
						{
							num2 = num9;
							break;
						}
						num8++;
						num9++;
						num10 = num9;
					}
					else
					{
						num9++;
						num10 = num9;
					}
					continue;
				}
				goto IL_0225;
			}
			break;
			IL_0225:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new NullReferenceException();
		}
		return num2;
	}

	private string GetEventName(VampireSurvivors.Data.Stage.Event stageEvent)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2EC3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (stageEvent != null && stageEvent._003CeventType_003Ek__BackingField != null)
		{
			string text = stageEvent._003CeventType_003Ek__BackingField.ToString();
			if (text != null)
			{
				return text.Replace("_", " ");
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public StageEventTwitchManager()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected O, but got Unknown
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Expected O, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Expected O, but got Unknown
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Expected O, but got Unknown
		//IL_065f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0664: Expected O, but got Unknown
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c5: Expected O, but got Unknown
		//IL_0721: Unknown result type (might be due to invalid IL or missing references)
		//IL_0726: Expected O, but got Unknown
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Expected O, but got Unknown
		//IL_07e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e8: Expected O, but got Unknown
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0862: Expected O, but got Unknown
		//IL_08be: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c3: Expected O, but got Unknown
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Expected O, but got Unknown
		//IL_0987: Unknown result type (might be due to invalid IL or missing references)
		//IL_098c: Expected O, but got Unknown
		//IL_099b: Expected I4, but got O
		//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e2: Expected O, but got Unknown
		//IL_0a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a51: Expected O, but got Unknown
		//IL_0abb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac0: Expected O, but got Unknown
		//IL_0b25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2a: Expected O, but got Unknown
		//IL_0b6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b71: Expected O, but got Unknown
		//IL_0b80: Expected I4, but got O
		//IL_0bc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc7: Expected O, but got Unknown
		//IL_0c2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c31: Expected O, but got Unknown
		//IL_0c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9b: Expected O, but got Unknown
		//IL_0ccf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd4: Expected O, but got Unknown
		//IL_0d36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3b: Expected O, but got Unknown
		//IL_0d9b: Expected O, but got I
		//IL_0dc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcc: Expected O, but got Unknown
		//IL_0e1e: Expected O, but got I
		//IL_0e4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4f: Expected O, but got Unknown
		//IL_0eb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb9: Expected O, but got Unknown
		//IL_0ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef8: Expected O, but got Unknown
		//IL_0f19: Expected O, but got I
		//IL_0f36: Expected I4, but got O
		//IL_0fa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa9: Expected O, but got Unknown
		//IL_1005: Unknown result type (might be due to invalid IL or missing references)
		//IL_100a: Expected O, but got Unknown
		//IL_1061: Unknown result type (might be due to invalid IL or missing references)
		//IL_1066: Expected O, but got Unknown
		//IL_10bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c2: Expected O, but got Unknown
		//IL_1119: Unknown result type (might be due to invalid IL or missing references)
		//IL_111e: Expected O, but got Unknown
		//IL_1170: Expected O, but got I
		//IL_119c: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a1: Expected O, but got Unknown
		//IL_11f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fd: Expected O, but got Unknown
		//IL_1270: Unknown result type (might be due to invalid IL or missing references)
		//IL_1275: Expected O, but got Unknown
		//IL_12e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ed: Expected O, but got Unknown
		//IL_132f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1334: Expected O, but got Unknown
		//IL_1343: Expected I4, but got O
		//IL_1393: Unknown result type (might be due to invalid IL or missing references)
		//IL_1398: Expected O, but got Unknown
		//IL_13fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1402: Expected O, but got Unknown
		//IL_1475: Unknown result type (might be due to invalid IL or missing references)
		//IL_147a: Expected O, but got Unknown
		//IL_14df: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e4: Expected O, but got Unknown
		//IL_1557: Unknown result type (might be due to invalid IL or missing references)
		//IL_155c: Expected O, but got Unknown
		//IL_15c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c6: Expected O, but got Unknown
		//IL_1639: Unknown result type (might be due to invalid IL or missing references)
		//IL_163e: Expected O, but got Unknown
		//IL_1690: Expected O, but got I
		//IL_16ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cf: Expected O, but got Unknown
		//IL_1721: Expected O, but got I
		//IL_174d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1752: Expected O, but got Unknown
		//IL_1794: Unknown result type (might be due to invalid IL or missing references)
		//IL_1799: Expected O, but got Unknown
		//IL_17a8: Expected I4, but got O
		//IL_17f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fd: Expected O, but got Unknown
		//IL_184f: Expected O, but got I
		//IL_1889: Unknown result type (might be due to invalid IL or missing references)
		//IL_188e: Expected O, but got Unknown
		//IL_18f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f8: Expected O, but got Unknown
		//IL_1932: Unknown result type (might be due to invalid IL or missing references)
		//IL_1937: Expected O, but got Unknown
		//IL_1958: Expected O, but got I
		//IL_1975: Expected I4, but got O
		//IL_19c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ca: Expected O, but got Unknown
		//IL_1a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a11: Expected O, but got Unknown
		//IL_1a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8e: Expected O, but got Unknown
		//IL_1ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad5: Expected O, but got Unknown
		//IL_1b31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b36: Expected O, but got Unknown
		//IL_1b78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7d: Expected O, but got Unknown
		//IL_1bf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfa: Expected O, but got Unknown
		//IL_1c4c: Expected O, but got I
		//IL_1c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c7d: Expected O, but got Unknown
		//IL_1cd4: Expected O, but got I
		List<VampireSurvivors.Data.Stage.Event> mediaEvents = new List<VampireSurvivors.Data.Stage.Event>();
		_mediaEvents = mediaEvents;
		_twitchOptions = new List<TextMeshProUGUI>();
		List<VampireSurvivors.Data.Stage.Event> goodEvents = new List<VampireSurvivors.Data.Stage.Event>();
		VampireSurvivors.Data.Stage.Event obj = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		object obj3 = default(object);
		Enum obj2 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 26;
		obj._003CeventType_003Ek__BackingField = obj2.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj4 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj5 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 27;
		obj4._003CeventType_003Ek__BackingField = obj5.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj6 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj7 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 28;
		obj6._003CeventType_003Ek__BackingField = obj7.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj8 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj9 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 29;
		obj8._003CeventType_003Ek__BackingField = obj9.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj10 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj11 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 30;
		obj10._003CeventType_003Ek__BackingField = obj11.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj12 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj13 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 32;
		obj12._003CeventType_003Ek__BackingField = obj13.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj14 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj15 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 33;
		obj14._003CeventType_003Ek__BackingField = obj15.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj16 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj17 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 31;
		obj16._003CeventType_003Ek__BackingField = obj17.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj18 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj19 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 31;
		obj18._003CeventType_003Ek__BackingField = obj19.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj20 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj21 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 31;
		obj20._003CeventType_003Ek__BackingField = obj21.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj22 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj23 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 26;
		obj22._003CeventType_003Ek__BackingField = obj23.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj24 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj25 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 27;
		obj24._003CeventType_003Ek__BackingField = obj25.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj26 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj27 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 28;
		obj26._003CeventType_003Ek__BackingField = obj27.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj28 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj29 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 29;
		obj28._003CeventType_003Ek__BackingField = obj29.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj30 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj31 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 30;
		obj30._003CeventType_003Ek__BackingField = obj31.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj32 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj33 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 32;
		obj32._003CeventType_003Ek__BackingField = obj33.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj34 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj35 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 33;
		obj34._003CeventType_003Ek__BackingField = obj35.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj36 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj37 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 31;
		obj36._003CeventType_003Ek__BackingField = obj37.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj38 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj39 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 31;
		obj38._003CeventType_003Ek__BackingField = obj39.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj40 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj41 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 31;
		obj40._003CeventType_003Ek__BackingField = obj41.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj42 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj43 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 40;
		obj42._003CeventType_003Ek__BackingField = obj43.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		_goodEvents = goodEvents;
		List<VampireSurvivors.Data.Stage.Event> neutralEvents = new List<VampireSurvivors.Data.Stage.Event>();
		VampireSurvivors.Data.Stage.Event obj44 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj45 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 2;
		obj44._003CeventType_003Ek__BackingField = obj45.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj46 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj47 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 3;
		obj46._003CeventType_003Ek__BackingField = obj47.ToString();
		obj46._003Crepeat_003Ek__BackingField = 10;
		obj46._003Cdelay_003Ek__BackingField = 2000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj48 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj49 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 5;
		obj48._003CeventType_003Ek__BackingField = obj49.ToString();
		obj48._003CmoreX_003Ek__BackingField = 12;
		object obj50 = obj3 + 32;
		_ = 28;
		obj48._003CmoreY_003Ek__BackingField = (EnemyType)obj50;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj51 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj52 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 7;
		obj51._003CeventType_003Ek__BackingField = obj52.ToString();
		obj51._003CmoreX_003Ek__BackingField = 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj53 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj54 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 13;
		obj53._003CeventType_003Ek__BackingField = obj54.ToString();
		obj53._003CmoreX_003Ek__BackingField = 50;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj55 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj56 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 14;
		obj55.eventType = obj56.ToString();
		obj55._003CmoreX_003Ek__BackingField = 200;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj57 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj58 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 15;
		obj57.eventType = obj58.ToString();
		obj57._003CmoreX_003Ek__BackingField = 12;
		object obj59 = obj3 + 32;
		_ = 91;
		obj57.moreY = (EnemyType)obj59;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj60 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj61 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 16;
		obj60.eventType = obj61.ToString();
		obj60._003CmoreX_003Ek__BackingField = 50;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj62 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj63 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 22;
		obj62.eventType = obj63.ToString();
		obj62._003CmoreX_003Ek__BackingField = 50;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj64 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj65 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 23;
		obj64.eventType = obj65.ToString();
		Enum obj66 = (Enum)(obj3 - 32);
		_ = typeof(EnemyType);
		_ = -1;
		_ = 79;
		obj64.moreY = obj66.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj67 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj68 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 1;
		obj67.eventType = obj68.ToString();
		obj67._003CmoreX_003Ek__BackingField = 80;
		_ = 0;
		_ = 1189765120;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+20]");
		obj67._003Cduration_003Ek__BackingField = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj69 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj70 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 0;
		obj69.eventType = obj70.ToString();
		_ = 0;
		_ = 1176256512;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+20]");
		obj69._003Cduration_003Ek__BackingField = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj71 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj72 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 18;
		obj71.eventType = obj72.ToString();
		obj71._003CmoreX_003Ek__BackingField = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj73 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj74 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 20;
		obj73.eventType = obj74.ToString();
		_ = 0;
		object obj75 = obj3 + 32;
		_ = 1;
		_ = 1189765120;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+20]");
		obj73._003Cduration_003Ek__BackingField = (float?)(object)0;
		obj73._003CmoreX_003Ek__BackingField = 50;
		_ = 85;
		obj73.moreY = (EnemyType)obj75;
		obj73._003CmoreZ_003Ek__BackingField = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		_neutralEvents = neutralEvents;
		List<VampireSurvivors.Data.Stage.Event> badEvents = new List<VampireSurvivors.Data.Stage.Event>();
		VampireSurvivors.Data.Stage.Event obj76 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj77 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 39;
		obj76.eventType = obj77.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj78 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj79 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 38;
		obj78.eventType = obj79.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj80 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj81 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 37;
		obj80.eventType = obj81.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj82 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj83 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 36;
		obj82.eventType = obj83.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj84 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj85 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 41;
		obj84.eventType = obj85.ToString();
		_ = 0;
		_ = 1188741120;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+20]");
		obj84._003Cduration_003Ek__BackingField = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj86 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj87 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 42;
		obj86.eventType = obj87.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj88 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj89 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 2;
		obj88.eventType = obj89.ToString();
		obj88._003Crepeat_003Ek__BackingField = 4;
		obj88._003Cdelay_003Ek__BackingField = 2000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj90 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj91 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 3;
		obj90.eventType = obj91.ToString();
		obj90._003Crepeat_003Ek__BackingField = 10;
		obj90._003Cdelay_003Ek__BackingField = 2000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj92 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj93 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 5;
		obj92.eventType = obj93.ToString();
		obj92._003CmoreX_003Ek__BackingField = 12;
		object obj94 = obj3 + 32;
		_ = 28;
		obj92.moreY = (EnemyType)obj94;
		obj92._003Crepeat_003Ek__BackingField = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj95 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj96 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 7;
		obj95.eventType = obj96.ToString();
		obj95._003CmoreX_003Ek__BackingField = 8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj97 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj98 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 13;
		obj97.eventType = obj98.ToString();
		obj97._003CmoreX_003Ek__BackingField = 50;
		obj97._003Crepeat_003Ek__BackingField = 2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj99 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj100 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 14;
		obj99.eventType = obj100.ToString();
		obj99._003CmoreX_003Ek__BackingField = 200;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj101 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj102 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 21;
		obj101.eventType = obj102.ToString();
		obj101._003CmoreX_003Ek__BackingField = 60;
		obj101._003Crepeat_003Ek__BackingField = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj103 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj104 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 22;
		obj103.eventType = obj104.ToString();
		obj103._003CmoreX_003Ek__BackingField = 40;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj105 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj106 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 23;
		obj105.eventType = obj106.ToString();
		obj105._003Crepeat_003Ek__BackingField = 1;
		obj105._003Cdelay_003Ek__BackingField = 10000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj107 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj108 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 1;
		obj107.eventType = obj108.ToString();
		_ = 0;
		_ = 1189765120;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+20]");
		obj107._003Cduration_003Ek__BackingField = (float?)(object)0;
		obj107._003CmoreX_003Ek__BackingField = 60;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj109 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj110 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 0;
		obj109.eventType = obj110.ToString();
		_ = 0;
		_ = 1193033728;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+20]");
		obj109._003Cduration_003Ek__BackingField = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj111 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj112 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 9;
		obj111.eventType = obj112.ToString();
		obj111._003CmoreX_003Ek__BackingField = 40;
		object obj113 = obj3 + 32;
		_ = 117;
		obj111.moreY = (EnemyType)obj113;
		obj111._003CmoreZ_003Ek__BackingField = 0.7f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj114 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj115 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 10;
		obj114.eventType = obj115.ToString();
		_ = 0;
		_ = 1181376512;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+20]");
		obj114._003Cduration_003Ek__BackingField = (float?)(object)0;
		obj114._003CmoreX_003Ek__BackingField = 40;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj116 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj117 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 18;
		obj116.eventType = obj117.ToString();
		obj116._003CmoreX_003Ek__BackingField = 3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj118 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj119 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 20;
		obj118.eventType = obj119.ToString();
		_ = 0;
		object obj120 = obj3 + 32;
		_ = 1;
		_ = 1189765120;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+20]");
		obj118._003Cduration_003Ek__BackingField = (float?)(object)0;
		obj118._003CmoreX_003Ek__BackingField = 75;
		_ = 85;
		obj118.moreY = (EnemyType)obj120;
		obj118._003CmoreZ_003Ek__BackingField = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj121 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj122 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 24;
		obj121.eventType = obj122.ToString();
		obj121._003CmoreX_003Ek__BackingField = 4;
		object obj123 = obj3 + 32;
		_ = 1000;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object moreY = default(object);
		obj121.moreY = moreY;
		obj121._003CmoreZ_003Ek__BackingField = 1f;
		obj121._003Crepeat_003Ek__BackingField = 1;
		obj121._003Cdelay_003Ek__BackingField = 10000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj124 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj125 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 24;
		obj124.eventType = obj125.ToString();
		obj124._003CmoreX_003Ek__BackingField = 25;
		object obj126 = obj3 + 32;
		_ = 100;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object moreY2 = default(object);
		obj124.moreY = moreY2;
		obj124._003CmoreZ_003Ek__BackingField = 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj127 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj128 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 24;
		obj127.eventType = obj128.ToString();
		obj127._003CmoreX_003Ek__BackingField = 3;
		object obj129 = obj3 + 32;
		_ = 500;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object moreY3 = default(object);
		obj127.moreY = moreY3;
		obj127._003CmoreZ_003Ek__BackingField = 1f;
		obj127._003Crepeat_003Ek__BackingField = 6;
		obj127._003Cdelay_003Ek__BackingField = 3000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj130 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj131 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 11;
		obj130.eventType = obj131.ToString();
		_ = 0;
		_ = 1198153728;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+20]");
		obj130._003Cduration_003Ek__BackingField = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		VampireSurvivors.Data.Stage.Event obj132 = new VampireSurvivors.Data.Stage.Event();
		_ = typeof(StageEventType);
		Enum obj133 = (Enum)(obj3 - 32);
		_ = -1;
		_ = 12;
		obj132._003CeventType_003Ek__BackingField = obj133.ToString();
		_ = 0;
		_ = 1198153728;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+20]");
		obj132._003Cduration_003Ek__BackingField = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC10");
		_badEvents = badEvents;
		base._002Ector();
	}

	private void _003CEnableTwitch_003Eb__22_0()
	{
		_twitchLimitCount = 0;
	}
}
