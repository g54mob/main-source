using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using I2.Loc;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.UI;

namespace VampireSurvivors.Objects;

public class StageEventTrisectionManager : StageEventManager
{
	[Serializable]
	public class WeightedTrisectionEventData
	{
		public int weight;

		public TrisectionEvent ev;
	}

	public enum ChoiceType
	{
		GOOD,
		NEUTRAL,
		BAD
	}

	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public StageEventTrisectionManager _003C_003E4__this;

		public float tweenCounterValue;

		public TrisectionEvent forcedEvent;

		internal void _003CSpinnn_003Eb__0()
		{
			_003C_003E4__this.HideCircles();
		}

		internal void _003CSpinnn_003Eb__1()
		{
			StageEventTrisectionManager stageEventTrisectionManager = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			bool flag = tweenCounterValue == stageEventTrisectionManager._tweenCounterTargetValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E91E15h\"");
			if (flag)
			{
				return;
			}
			StageEventTrisectionManager stageEventTrisectionManager2 = _003C_003E4__this;
			tweenCounterValue = stageEventTrisectionManager._tweenCounterTargetValue;
			if (stageEventTrisectionManager._tweenCounterTargetValue < 12f)
			{
				_003C_003E4__this.RotateEventNames();
				return;
			}
			if (forcedEvent != null)
			{
				WeightedTrisectionEventData weightedTrisectionEventData = new WeightedTrisectionEventData();
				weightedTrisectionEventData.weight = 0;
				weightedTrisectionEventData.ev = forcedEvent;
				stageEventTrisectionManager2._nextChosenEvent = weightedTrisectionEventData;
			}
			else
			{
				_003C_003E4__this.CalculateMainChances();
				_003C_003E4__this.ChooseEvent();
			}
			_003C_003E4__this.HighlightEventName();
		}
	}

	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public float r;

		internal bool _003CChooseEvent_003Eb__0(WeightedTrisectionEventData x)
		{
			//IL_0050: Expected I4, but got O
			//IL_002c: Invalid comparison between I4 and F4
			if (x != null)
			{
				bool flag = (float)x.weight < r;
				return !flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass44_1
	{
		public float r;

		internal bool _003CChooseEvent_003Eb__1(WeightedTrisectionEventData x)
		{
			//IL_0050: Expected I4, but got O
			//IL_002c: Invalid comparison between I4 and F4
			if (x != null)
			{
				bool flag = (float)x.weight < r;
				return !flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass44_2
	{
		public float r;

		internal bool _003CChooseEvent_003Eb__2(WeightedTrisectionEventData x)
		{
			//IL_0050: Expected I4, but got O
			//IL_002c: Invalid comparison between I4 and F4
			if (x != null)
			{
				bool flag = (float)x.weight < r;
				return !flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public StageEventTrisectionManager _003C_003E4__this;

		public Action onTextHighlighted;

		internal void _003CHighlightEventName_003Eb__0()
		{
			StageEventTrisectionManager stageEventTrisectionManager = _003C_003E4__this;
			WeightedTrisectionEventData nextChosenEvent = stageEventTrisectionManager._nextChosenEvent;
			string eventName = stageEventTrisectionManager.GetEventName(nextChosenEvent.ev);
			PhaserText phaserText = stageEventTrisectionManager._nextEventText.SetText(eventName);
			StageEventTrisectionManager stageEventTrisectionManager2 = _003C_003E4__this;
			PhaserText phaserText2 = stageEventTrisectionManager2._nextEventText.SetTint(16776960u);
		}

		internal void _003CHighlightEventName_003Eb__1()
		{
			Action action = onTextHighlighted;
			if (onTextHighlighted != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public float _tweenCounterTargetValue;

	protected PhaserText _nextEventText;

	protected Vector3 _nextEventTextDefaultLocalPosition;

	protected Vector3 _nextEventTextGoldFeverLocalPosition;

	protected List<TrisectionEvent> _goodEvents;

	protected List<TrisectionEvent> _neutralEvents;

	protected List<TrisectionEvent> _badEvents;

	protected List<TrisectionEvent> _triggeredEvents;

	protected bool _dontRepeatEvents;

	protected MultiTargetTween _tweenHideCircles;

	protected MultiTargetTween _tweenShowCircles;

	protected MultiTargetTween _tweenCounter;

	private PhaserSprite _sCenter;

	private PhaserSprite _sWorld;

	private PhaserSprite _sMoon;

	private PhaserSprite _sSun;

	private MultiTargetTween _tweenWorld;

	private MultiTargetTween _tweenMoon;

	private MultiTargetTween _tweenSun;

	private MultiTargetTween _tweenRotateName;

	private MultiTargetTween _tweenHighlightName;

	protected int _totalWeightGood;

	protected int _totalWeightNeutral;

	protected int _totalWeightBad;

	private List<string> _eventNames;

	protected List<WeightedTrisectionEventData> _weightedGood;

	protected List<WeightedTrisectionEventData> _weightedNeutral;

	protected List<WeightedTrisectionEventData> _weightedBad;

	private ChoiceType _nextChoice;

	protected WeightedTrisectionEventData _nextChosenEvent;

	protected Unity.Mathematics.Random _eventsRng;

	public override void Init(Stage stage)
	{
		//IL_0414: Expected O, but got I4
		//IL_0069: Expected O, but got I
		//IL_04b0: Invalid comparison between I4 and F4
		//IL_0054: Expected O, but got I4
		//IL_00ca: Expected O, but got I8
		base.Init(stage);
		_eventsRng = (Unity.Mathematics.Random)0;
		GameManager core = GM.Core;
		MultiplayerManager multiplayerManager = core._multiplayer;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				multiplayerManager = (MultiplayerManager)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v285 @ rax_v84 (should have been resolved before IL gen)");
			if (0f > 1f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rcx,xmm0\"");
			}
		}
		else
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			multiplayerManager = (MultiplayerManager)instance._003CRandomEventsSeed_003Ek__BackingField;
		}
		object obj2 = (object)multiplayerManager << 13;
		object obj3 = obj2 ^ (object)multiplayerManager;
		object obj4 = obj3 >> 17;
		object obj5 = obj4 ^ obj3;
		object obj6 = obj5 << 5;
		Unity.Mathematics.Random eventsRng = (Unity.Mathematics.Random)(obj6 ^ obj5);
		_eventsRng = eventsRng;
		PopulateEvents();
		CreateUI();
		List<TrisectionEvent>.Enumerator enumerator = default(List<TrisectionEvent>.Enumerator);
		while (enumerator.MoveNext())
		{
			List<object> eventNames = (List<object>)(object)_eventNames;
			string eventName = GetEventName(null);
			bool flag = _eventNames == null;
			StageEventTrisectionManager stageEventTrisectionManager = this;
			if (!flag)
			{
				int version = eventNames._version + 1;
				eventNames._version = version;
				MissingMethodException items = (MissingMethodException)(object)eventNames._items;
				if (eventNames._items != null)
				{
					if (eventNames._size >= (nint)((Exception)items)._message)
					{
						((List<object>)(object)_eventNames).AddWithResize((object)eventName);
						continue;
					}
					int size = eventNames._size + 1;
					eventNames._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		List<TrisectionEvent>.Enumerator enumerator2 = default(List<TrisectionEvent>.Enumerator);
		while (enumerator2.MoveNext())
		{
			List<object> eventNames2 = (List<object>)(object)_eventNames;
			string eventName2 = GetEventName(null);
			bool flag2 = _eventNames == null;
			StageEventTrisectionManager stageEventTrisectionManager = this;
			if (!flag2)
			{
				int version2 = eventNames2._version + 1;
				eventNames2._version = version2;
				stageEventTrisectionManager = (StageEventTrisectionManager)(object)eventNames2._items;
				if (eventNames2._items != null)
				{
					if (eventNames2._size >= (nint)((StageEventManager)stageEventTrisectionManager)._playerOptions)
					{
						((List<object>)(object)_eventNames).AddWithResize((object)eventName2);
						continue;
					}
					int size2 = eventNames2._size + 1;
					eventNames2._size = size2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		List<TrisectionEvent>.Enumerator enumerator3 = default(List<TrisectionEvent>.Enumerator);
		while (enumerator3.MoveNext())
		{
			List<object> eventNames3 = (List<object>)(object)_eventNames;
			string eventName3 = GetEventName(null);
			bool flag3 = _eventNames == null;
			StageEventTrisectionManager stageEventTrisectionManager = this;
			if (!flag3)
			{
				int version3 = eventNames3._version + 1;
				eventNames3._version = version3;
				stageEventTrisectionManager = (StageEventTrisectionManager)(object)eventNames3._items;
				if (eventNames3._items != null)
				{
					if (eventNames3._size >= (nint)((StageEventManager)stageEventTrisectionManager)._playerOptions)
					{
						((List<object>)(object)_eventNames).AddWithResize((object)eventName3);
						continue;
					}
					int size3 = eventNames3._size + 1;
					eventNames3._size = size3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		CalculateWeights();
	}

	public void SetSeed(uint seed)
	{
		//IL_005b: Expected O, but got I4
		int num = (int)(seed << 13);
		int num2 = num ^ (int)seed;
		int num3 = num2 >> 17;
		int num4 = num2 ^ num3;
		int num5 = num4 << 5;
		int num6 = num5 ^ num4;
		_eventsRng = (Unity.Mathematics.Random)num6;
	}

	public void ShowUI()
	{
		ShowCircles();
	}

	public void HideUI()
	{
		if (_tweenCounter != null)
		{
			_tweenCounter.Kill();
		}
		if (_tweenRotateName != null)
		{
			_tweenRotateName.Kill();
		}
		if (_tweenHighlightName != null)
		{
			_tweenHighlightName.Kill();
		}
		PhaserText phaserText = _nextEventText.SetAlpha(0f);
		HideCircles();
	}

	public virtual void Spinnn(float duration = 10000f, TrisectionEvent forcedEvent = null, Action onEventSelected = null)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00c8: Expected O, but got I
		//IL_0151: Expected O, but got I
		//IL_088d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0892: Expected O, but got Unknown
		//IL_0915: Expected O, but got I
		//IL_01b9: Expected O, but got I
		//IL_0969: Unknown result type (might be due to invalid IL or missing references)
		//IL_096e: Expected O, but got Unknown
		//IL_09f1: Expected O, but got I
		//IL_0221: Expected O, but got I
		//IL_0355: Expected I, but got O
		//IL_0412: Expected O, but got I4
		//IL_0489: Expected I, but got O
		//IL_0546: Expected O, but got I4
		//IL_05b8: Expected I, but got O
		//IL_0659: Expected O, but got I
		//IL_06b3: Expected O, but got I4
		//IL_073d: Expected I, but got O
		_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass35_0();
		CS_0024_003C_003E8__locals14._003C_003E4__this = this;
		CS_0024_003C_003E8__locals14.forcedEvent = forcedEvent;
		List<float> list = new List<float>();
		object obj = (object)_eventsRng << 13;
		object obj2 = obj ^ (object)_eventsRng;
		object obj3 = (object)_eventsRng >> 9;
		object obj4 = obj3 | 0x3F800000;
		object obj5 = obj2 >> 17;
		object obj6 = obj2 ^ obj5;
		object obj7 = obj6 << 5;
		Unity.Mathematics.Random eventsRng = (Unity.Mathematics.Random)(obj7 ^ obj6);
		_eventsRng = eventsRng;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj8 = 0;
		float num = (float)obj4 - 1f;
		float num2 = num * 7f;
		float item = num2 + 7f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v21+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(item);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj9 = (nint)0 + (nint)1;
		}
		object obj10 = (object)_eventsRng << 13;
		object obj11 = obj10 ^ (object)_eventsRng;
		object obj12 = (object)_eventsRng >> 9;
		object obj13 = obj12 | 0x3F800000;
		object obj14 = obj11 >> 17;
		object obj15 = obj11 ^ obj14;
		float num4 = (float)obj13 - 1f;
		object obj16 = obj15 << 5;
		Unity.Mathematics.Random eventsRng2 = (Unity.Mathematics.Random)(obj16 ^ obj15);
		_eventsRng = eventsRng2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		float num5 = num4 * 14f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj17 = 0;
		float item2 = num5 + 14f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v25+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(item2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj18 = (nint)0 + (nint)1;
		}
		object obj19 = (object)_eventsRng << 13;
		object obj20 = obj19 ^ (object)_eventsRng;
		object obj21 = (object)_eventsRng >> 9;
		object obj22 = obj21 | 0x3F800000;
		object obj23 = obj20 >> 17;
		object obj24 = obj20 ^ obj23;
		float num7 = (float)obj22 - 1f;
		object obj25 = obj24 << 5;
		Unity.Mathematics.Random eventsRng3 = (Unity.Mathematics.Random)(obj25 ^ obj24);
		_eventsRng = eventsRng3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		float num8 = num7 * 21f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj26 = 0;
		float item3 = num8 + 21f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v29+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(item3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj27 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)0 >= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)0 > (nint)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D99C0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			if (_tweenWorld != null)
			{
				_tweenWorld.Kill();
			}
			if (_tweenMoon != null)
			{
				_tweenMoon.Kill();
			}
			if (_tweenSun != null)
			{
				_tweenSun.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_sWorld != null)
			{
				nint num10 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj28 = default(object);
				if (obj28 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Transform transform = _sWorld.transform;
			Vector3 localEulerAngles = transform.localEulerAngles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)0 > (nint)2)
			{
				tweenConfig.ease = Ease.OutBounce;
				float duration2 = duration * 0.8f;
				tweenConfig.angle = (float?)(object)1;
				tweenConfig.duration = duration2;
				MultiTargetTween tweenWorld = Tweens.Add(tweenConfig);
				_tweenWorld = tweenWorld;
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				if ((object)_sMoon != null)
				{
					nint num11 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj29 = default(object);
					if (obj29 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				Transform transform2 = _sMoon.transform;
				Vector3 localEulerAngles2 = transform2.localEulerAngles;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)0 > (nint)1)
				{
					tweenConfig2.ease = Ease.OutBounce;
					float duration3 = duration * 0.9f;
					tweenConfig2.angle = (float?)(object)1;
					tweenConfig2.duration = duration3;
					MultiTargetTween tweenMoon = Tweens.Add(tweenConfig2);
					_tweenMoon = tweenMoon;
					TweenConfig tweenConfig3 = new TweenConfig();
					object[] array3 = new object[1];
					if ((object)_sSun != null)
					{
						nint num12 = (nint)array3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj30 = default(object);
						if (obj30 == null)
						{
							ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
							throw ex3;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig3.targets = array3;
					Transform transform3 = _sSun.transform;
					Vector3 localEulerAngles3 = transform3.localEulerAngles;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+10]");
						object obj31 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rcx_v76+20]");
						float num13 = 0f * 360f;
						float num14 = num13 + localEulerAngles3.z;
						tweenConfig3.duration = duration;
						tweenConfig3.ease = Ease.OutBounce;
						tweenConfig3.angle = (float?)(object)1;
						TweenCallback onComplete = delegate
						{
							CS_0024_003C_003E8__locals14._003C_003E4__this.HideCircles();
						};
						tweenConfig3.onComplete = onComplete;
						MultiTargetTween tweenSun = Tweens.Add(tweenConfig3);
						_tweenSun = tweenSun;
						_tweenCounterTargetValue = 1f;
						CS_0024_003C_003E8__locals14.tweenCounterValue = 0f;
						TweenConfig tweenConfig4 = new TweenConfig();
						object[] array4 = new object[1];
						nint num15 = (nint)array4;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj32 = default(object);
						if (obj32 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							tweenConfig4.targets = array4;
							Dictionary<string, object> dictionary = new Dictionary<string, object>();
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							object value = default(object);
							bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_tweenCounterTargetValue", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							tweenConfig4.custom = dictionary;
							float duration4 = duration * 0.95f;
							tweenConfig4.duration = duration4;
							TweenCallback onUpdate = delegate
							{
								StageEventTrisectionManager stageEventTrisectionManager = CS_0024_003C_003E8__locals14._003C_003E4__this;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
								bool flag2 = CS_0024_003C_003E8__locals14.tweenCounterValue == stageEventTrisectionManager._tweenCounterTargetValue;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E91E15h\"");
								if (!flag2)
								{
									StageEventTrisectionManager stageEventTrisectionManager2 = CS_0024_003C_003E8__locals14._003C_003E4__this;
									CS_0024_003C_003E8__locals14.tweenCounterValue = stageEventTrisectionManager._tweenCounterTargetValue;
									if (stageEventTrisectionManager._tweenCounterTargetValue < 12f)
									{
										CS_0024_003C_003E8__locals14._003C_003E4__this.RotateEventNames();
									}
									else
									{
										if (CS_0024_003C_003E8__locals14.forcedEvent != null)
										{
											WeightedTrisectionEventData weightedTrisectionEventData = new WeightedTrisectionEventData();
											weightedTrisectionEventData.weight = 0;
											weightedTrisectionEventData.ev = CS_0024_003C_003E8__locals14.forcedEvent;
											stageEventTrisectionManager2._nextChosenEvent = weightedTrisectionEventData;
										}
										else
										{
											CS_0024_003C_003E8__locals14._003C_003E4__this.CalculateMainChances();
											CS_0024_003C_003E8__locals14._003C_003E4__this.ChooseEvent();
										}
										CS_0024_003C_003E8__locals14._003C_003E4__this.HighlightEventName();
									}
								}
							};
							tweenConfig4.onUpdate = onUpdate;
							MultiTargetTween tweenCounter = Tweens.Add(tweenConfig4);
							_tweenCounter = tweenCounter;
							return;
						}
						ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
						throw ex4;
					}
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument.count, System.ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		throw new IndexOutOfRangeException();
	}

	public void TriggerTrisectionEvent()
	{
		//IL_009d: Expected I, but got O
		//IL_0101: Expected O, but got I4
		if (_nextChosenEvent == null)
		{
			return;
		}
		GameManager core = GM.Core;
		Stage stage = core._stage;
		WeightedTrisectionEventData nextChosenEvent = _nextChosenEvent;
		bool flag = stage._stageEventManager.TriggerEvent(nextChosenEvent.ev, fromTrisection: true);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_nextEventText != null)
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
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public List<TrisectionEvent> GetAllEvents()
	{
		List<TrisectionEvent> list = new List<TrisectionEvent>();
		if (list != null)
		{
			((List<object>)(object)list).InsertRange(list._size, (IEnumerable<object>)_goodEvents);
			((List<object>)(object)list).InsertRange(list._size, (IEnumerable<object>)_neutralEvents);
			((List<object>)(object)list).InsertRange(list._size, (IEnumerable<object>)_badEvents);
			return list;
		}
		return (List<TrisectionEvent>)(object)new NullReferenceException();
	}

	public void TrisectionUpdate()
	{
		//IL_00de: Expected O, but got I
		//IL_00a6: Expected O, but got I
		//IL_0118->IL0118: Incompatible stack heights: 2 vs 0
		//IL_00b5->IL0151: Incompatible stack heights: 3 vs 1
		while (true)
		{
			GameManager core = GM.Core;
			MainGamePage mainGamePage = core._003CMainUI_003Ek__BackingField;
			GoldFeverUIManager goldFever = mainGamePage._GoldFever;
			Vector3 nextEventTextDefaultLocalPosition;
			IntPtr cachedPtr;
			object obj;
			Vector3 nextEventTextDefaultLocalPosition2;
			if (!goldFever._003CIsGoldFeverShowing_003Ek__BackingField)
			{
				bool flag = (object)_nextEventText == null;
				Transform transform = _nextEventText.transform;
				bool flag2 = (object)transform == null;
				nextEventTextDefaultLocalPosition = _nextEventTextDefaultLocalPosition;
				cachedPtr = ((UnityEngine.Object)transform).m_CachedPtr;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				obj = 0;
				nextEventTextDefaultLocalPosition2 = _nextEventTextDefaultLocalPosition;
				break;
			}
			Transform transform2 = _nextEventText.transform;
			nextEventTextDefaultLocalPosition = _nextEventTextGoldFeverLocalPosition;
			cachedPtr = ((UnityEngine.Object)transform2).m_CachedPtr;
			bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			obj = 0;
			bool flag5 = (nint)0 != 0;
			nextEventTextDefaultLocalPosition2 = _nextEventTextGoldFeverLocalPosition;
			if (flag5)
			{
				break;
			}
			bool flag6 = (nint)0 == 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v446 @ rax_v21 (should have been resolved before IL gen)");
	}

	protected virtual void PopulateEvents()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected O, but got Unknown
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected O, but got Unknown
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Expected O, but got Unknown
		//IL_0575: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Expected O, but got Unknown
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Expected O, but got Unknown
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_0656: Expected I4, but got O
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Expected O, but got Unknown
		//IL_071e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0723: Expected O, but got Unknown
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Expected O, but got Unknown
		//IL_080e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0813: Expected O, but got Unknown
		//IL_0855: Unknown result type (might be due to invalid IL or missing references)
		//IL_085a: Expected O, but got Unknown
		//IL_0869: Expected I4, but got O
		//IL_08b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08be: Expected O, but got Unknown
		//IL_093f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0944: Expected O, but got Unknown
		//IL_0986: Unknown result type (might be due to invalid IL or missing references)
		//IL_098b: Expected O, but got Unknown
		//IL_099a: Expected I4, but got O
		//IL_09f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fd: Expected O, but got Unknown
		//IL_0a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3c: Expected O, but got Unknown
		//IL_0a5d: Expected O, but got I
		//IL_0a7a: Expected I4, but got O
		//IL_0b04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b09: Expected O, but got Unknown
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b81: Expected O, but got Unknown
		//IL_0bf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf9: Expected O, but got Unknown
		//IL_0c6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c71: Expected O, but got Unknown
		//IL_0ce4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce9: Expected O, but got Unknown
		//IL_0d4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d53: Expected O, but got Unknown
		//IL_0da5: Expected O, but got I
		//IL_0ded: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df2: Expected O, but got Unknown
		//IL_0e44: Expected O, but got I
		//IL_0e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e83: Expected O, but got Unknown
		//IL_0ec5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eca: Expected O, but got Unknown
		//IL_0ed9: Expected I4, but got O
		//IL_0f45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4a: Expected O, but got Unknown
		//IL_0f9c: Expected O, but got I
		//IL_0ff2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff7: Expected O, but got Unknown
		//IL_1078: Unknown result type (might be due to invalid IL or missing references)
		//IL_107d: Expected O, but got Unknown
		//IL_10b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bc: Expected O, but got Unknown
		//IL_10dd: Expected O, but got I
		//IL_10fa: Expected I4, but got O
		//IL_1158: Unknown result type (might be due to invalid IL or missing references)
		//IL_115d: Expected O, but got Unknown
		//IL_119f: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a4: Expected O, but got Unknown
		//IL_121c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1221: Expected O, but got Unknown
		//IL_1273: Expected O, but got I
		//IL_12bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c0: Expected O, but got Unknown
		//IL_1312: Expected O, but got I
		List<TrisectionEvent> goodEvents = new List<TrisectionEvent>();
		TrisectionEvent trisectionEvent = new TrisectionEvent();
		trisectionEvent.weight = 2;
		_ = typeof(StageEventType);
		object obj2 = default(object);
		Enum obj = (Enum)(obj2 - 32);
		_ = -1;
		_ = 26;
		string text = obj.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent)._003CeventType_003Ek__BackingField = text;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent2 = new TrisectionEvent();
		trisectionEvent2.weight = 3;
		_ = typeof(StageEventType);
		Enum obj3 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 27;
		string text2 = obj3.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent2)._003CeventType_003Ek__BackingField = text2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent3 = new TrisectionEvent();
		trisectionEvent3.weight = 5;
		_ = typeof(StageEventType);
		Enum obj4 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 28;
		string text3 = obj4.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent3)._003CeventType_003Ek__BackingField = text3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent4 = new TrisectionEvent();
		trisectionEvent4.weight = 1;
		_ = typeof(StageEventType);
		Enum obj5 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 29;
		string text4 = obj5.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent4)._003CeventType_003Ek__BackingField = text4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent5 = new TrisectionEvent();
		trisectionEvent5.weight = 1;
		trisectionEvent5.minLevel = 20;
		_ = typeof(StageEventType);
		Enum obj6 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 30;
		string text5 = obj6.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent5)._003CeventType_003Ek__BackingField = text5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent6 = new TrisectionEvent();
		trisectionEvent6.weight = 1;
		trisectionEvent6.minLevel = 100;
		_ = typeof(StageEventType);
		Enum obj7 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 30;
		string text6 = obj7.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent6)._003CeventType_003Ek__BackingField = text6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent7 = new TrisectionEvent();
		trisectionEvent7.weight = 5;
		_ = typeof(StageEventType);
		Enum obj8 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 32;
		string text7 = obj8.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent7)._003CeventType_003Ek__BackingField = text7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent8 = new TrisectionEvent();
		trisectionEvent8.weight = 1;
		_ = typeof(StageEventType);
		Enum obj9 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 33;
		string text8 = obj9.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent8)._003CeventType_003Ek__BackingField = text8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent9 = new TrisectionEvent();
		trisectionEvent9.weight = 10;
		_ = typeof(StageEventType);
		Enum obj10 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 31;
		string text9 = obj10.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent9)._003CeventType_003Ek__BackingField = text9;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent10 = new TrisectionEvent();
		trisectionEvent10.weight = 1;
		trisectionEvent10.minLevel = 30;
		_ = typeof(StageEventType);
		Enum obj11 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 40;
		string text10 = obj11.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent10)._003CeventType_003Ek__BackingField = text10;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent11 = new TrisectionEvent();
		trisectionEvent11.weight = 1;
		trisectionEvent11.minLevel = 100;
		_ = typeof(StageEventType);
		Enum obj12 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 40;
		string text11 = obj12.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent11)._003CeventType_003Ek__BackingField = text11;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		_goodEvents = goodEvents;
		List<TrisectionEvent> neutralEvents = new List<TrisectionEvent>();
		TrisectionEvent trisectionEvent12 = new TrisectionEvent();
		trisectionEvent12.weight = 1;
		_ = typeof(StageEventType);
		Enum obj13 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 2;
		string text12 = obj13.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent12)._003CeventType_003Ek__BackingField = text12;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent13 = new TrisectionEvent();
		trisectionEvent13.weight = 1;
		_ = typeof(StageEventType);
		Enum obj14 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 3;
		string text13 = obj14.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent13)._003CeventType_003Ek__BackingField = text13;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent13)._003Crepeat_003Ek__BackingField = 10;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent13)._003Cdelay_003Ek__BackingField = 2000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent14 = new TrisectionEvent();
		trisectionEvent14.weight = 1;
		_ = typeof(StageEventType);
		Enum obj15 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 5;
		string text14 = obj15.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent14)._003CeventType_003Ek__BackingField = text14;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent14)._003CmoreX_003Ek__BackingField = 12;
		object obj16 = obj2 + 48;
		_ = 28;
		object obj17 = (EnemyType)obj16;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent14)._003CmoreY_003Ek__BackingField = obj17;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent15 = new TrisectionEvent();
		trisectionEvent15.weight = 1;
		_ = typeof(StageEventType);
		Enum obj18 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 7;
		string text15 = obj18.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent15)._003CeventType_003Ek__BackingField = text15;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent15)._003CmoreX_003Ek__BackingField = 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent16 = new TrisectionEvent();
		trisectionEvent16.weight = 1;
		_ = typeof(StageEventType);
		Enum obj19 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 13;
		string text16 = obj19.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent16)._003CeventType_003Ek__BackingField = text16;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent16)._003CmoreX_003Ek__BackingField = 50;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent17 = new TrisectionEvent();
		trisectionEvent17.weight = 1;
		_ = typeof(StageEventType);
		Enum obj20 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 14;
		string text17 = obj20.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent17)._003CeventType_003Ek__BackingField = text17;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent17)._003CmoreX_003Ek__BackingField = 200;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent18 = new TrisectionEvent();
		trisectionEvent18.weight = 1;
		_ = typeof(StageEventType);
		Enum obj21 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 15;
		string text18 = obj21.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent18)._003CeventType_003Ek__BackingField = text18;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent18)._003CmoreX_003Ek__BackingField = 12;
		object obj22 = obj2 + 48;
		_ = 91;
		object obj23 = (EnemyType)obj22;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent18)._003CmoreY_003Ek__BackingField = obj23;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent19 = new TrisectionEvent();
		trisectionEvent19.weight = 1;
		_ = typeof(StageEventType);
		Enum obj24 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 22;
		string text19 = obj24.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent19)._003CeventType_003Ek__BackingField = text19;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent19)._003CmoreX_003Ek__BackingField = 50;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent20 = new TrisectionEvent();
		trisectionEvent20.weight = 1;
		trisectionEvent20.minLevel = 10;
		_ = typeof(StageEventType);
		Enum obj25 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 23;
		string text20 = obj25.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent20)._003CeventType_003Ek__BackingField = text20;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent20)._003CmoreX_003Ek__BackingField = 50;
		object obj26 = obj2 + 48;
		_ = 79;
		object obj27 = (EnemyType)obj26;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent20)._003CmoreY_003Ek__BackingField = obj27;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent21 = new TrisectionEvent();
		trisectionEvent21.weight = 1;
		trisectionEvent21.minLevel = 10;
		_ = typeof(StageEventType);
		Enum obj28 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 20;
		string text21 = obj28.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent21)._003CeventType_003Ek__BackingField = text21;
		_ = 0;
		object obj29 = obj2 + 48;
		_ = 1;
		_ = 1189765120;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
		((VampireSurvivors.Data.Stage.Event)trisectionEvent21)._003Cduration_003Ek__BackingField = (float?)(object)0;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent21)._003CmoreX_003Ek__BackingField = 50;
		_ = 85;
		object obj30 = (EnemyType)obj29;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent21)._003CmoreY_003Ek__BackingField = obj30;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent21)._003CmoreZ_003Ek__BackingField = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		_neutralEvents = neutralEvents;
		List<TrisectionEvent> badEvents = new List<TrisectionEvent>();
		TrisectionEvent trisectionEvent22 = new TrisectionEvent();
		trisectionEvent22.weight = 1;
		trisectionEvent22.minLevel = 60;
		_ = typeof(StageEventType);
		Enum obj31 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 39;
		string text22 = obj31.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent22)._003CeventType_003Ek__BackingField = text22;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent23 = new TrisectionEvent();
		trisectionEvent23.weight = 1;
		trisectionEvent23.minLevel = 40;
		_ = typeof(StageEventType);
		Enum obj32 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 38;
		string text23 = obj32.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent23)._003CeventType_003Ek__BackingField = text23;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent24 = new TrisectionEvent();
		trisectionEvent24.weight = 1;
		trisectionEvent24.minLevel = 10;
		_ = typeof(StageEventType);
		Enum obj33 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 37;
		string text24 = obj33.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent24)._003CeventType_003Ek__BackingField = text24;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent25 = new TrisectionEvent();
		trisectionEvent25.weight = 1;
		trisectionEvent25.minLevel = 20;
		_ = typeof(StageEventType);
		Enum obj34 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 36;
		string text25 = obj34.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent25)._003CeventType_003Ek__BackingField = text25;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent26 = new TrisectionEvent();
		trisectionEvent26.weight = 1;
		trisectionEvent26.minLevel = 30;
		_ = typeof(StageEventType);
		Enum obj35 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 42;
		string eventType = obj35.ToString();
		trisectionEvent26.eventType = eventType;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent27 = new TrisectionEvent();
		trisectionEvent27.weight = 1;
		_ = typeof(StageEventType);
		Enum obj36 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 1;
		string eventType2 = obj36.ToString();
		trisectionEvent27.eventType = eventType2;
		_ = 0;
		_ = 1189765120;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
		((VampireSurvivors.Data.Stage.Event)trisectionEvent27)._003Cduration_003Ek__BackingField = (float?)(object)0;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent27)._003CmoreX_003Ek__BackingField = 60;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent28 = new TrisectionEvent();
		trisectionEvent28.weight = 1;
		_ = typeof(StageEventType);
		Enum obj37 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 0;
		string eventType3 = obj37.ToString();
		trisectionEvent28.eventType = eventType3;
		_ = 0;
		_ = 1193033728;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
		((VampireSurvivors.Data.Stage.Event)trisectionEvent28)._003Cduration_003Ek__BackingField = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent29 = new TrisectionEvent();
		trisectionEvent29.weight = 1;
		_ = typeof(StageEventType);
		Enum obj38 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 9;
		string eventType4 = obj38.ToString();
		trisectionEvent29.eventType = eventType4;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent29)._003CmoreX_003Ek__BackingField = 40;
		object obj39 = obj2 + 48;
		_ = 117;
		object moreY = (EnemyType)obj39;
		trisectionEvent29.moreY = moreY;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent29)._003CmoreZ_003Ek__BackingField = 0.7f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent30 = new TrisectionEvent();
		trisectionEvent30.weight = 1;
		trisectionEvent30.minLevel = 10;
		_ = typeof(StageEventType);
		Enum obj40 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 10;
		string eventType5 = obj40.ToString();
		trisectionEvent30.eventType = eventType5;
		_ = 0;
		_ = 1181376512;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
		((VampireSurvivors.Data.Stage.Event)trisectionEvent30)._003Cduration_003Ek__BackingField = (float?)(object)0;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent30)._003CmoreX_003Ek__BackingField = 40;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent31 = new TrisectionEvent();
		trisectionEvent31.weight = 1;
		trisectionEvent31.minLevel = 15;
		_ = typeof(StageEventType);
		Enum obj41 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 18;
		string eventType6 = obj41.ToString();
		trisectionEvent31.eventType = eventType6;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent31)._003CmoreX_003Ek__BackingField = 3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent32 = new TrisectionEvent();
		trisectionEvent32.weight = 1;
		trisectionEvent32.minLevel = 10;
		_ = typeof(StageEventType);
		Enum obj42 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 20;
		string eventType7 = obj42.ToString();
		trisectionEvent32.eventType = eventType7;
		_ = 0;
		object obj43 = obj2 + 48;
		_ = 1;
		_ = 1189765120;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
		((VampireSurvivors.Data.Stage.Event)trisectionEvent32)._003Cduration_003Ek__BackingField = (float?)(object)0;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent32)._003CmoreX_003Ek__BackingField = 75;
		_ = 85;
		object moreY2 = (EnemyType)obj43;
		trisectionEvent32.moreY = moreY2;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent32)._003CmoreZ_003Ek__BackingField = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent33 = new TrisectionEvent();
		trisectionEvent33.weight = 1;
		_ = typeof(StageEventType);
		Enum obj44 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 24;
		string eventType8 = obj44.ToString();
		trisectionEvent33.eventType = eventType8;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent33)._003CmoreX_003Ek__BackingField = 25;
		object obj45 = obj2 + 48;
		_ = 100;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object moreY3 = default(object);
		trisectionEvent33.moreY = moreY3;
		((VampireSurvivors.Data.Stage.Event)trisectionEvent33)._003CmoreZ_003Ek__BackingField = 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent34 = new TrisectionEvent();
		trisectionEvent34.weight = 1;
		trisectionEvent34.minLevel = 30;
		_ = typeof(StageEventType);
		Enum obj46 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 11;
		string eventType9 = obj46.ToString();
		trisectionEvent34.eventType = eventType9;
		_ = 0;
		_ = 1198153728;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
		((VampireSurvivors.Data.Stage.Event)trisectionEvent34)._003Cduration_003Ek__BackingField = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		TrisectionEvent trisectionEvent35 = new TrisectionEvent();
		trisectionEvent35.weight = 1;
		trisectionEvent35.minLevel = 30;
		_ = typeof(StageEventType);
		Enum obj47 = (Enum)(obj2 - 32);
		_ = -1;
		_ = 12;
		string text26 = obj47.ToString();
		((VampireSurvivors.Data.Stage.Event)trisectionEvent35)._003CeventType_003Ek__BackingField = text26;
		_ = 0;
		_ = 1198153728;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
		((VampireSurvivors.Data.Stage.Event)trisectionEvent35)._003Cduration_003Ek__BackingField = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
		_badEvents = badEvents;
	}

	protected unsafe virtual void CreateUI()
	{
		//IL_0111: Expected O, but got I4
		//IL_020f: Expected O, but got I4
		//IL_030d: Expected O, but got I4
		//IL_040b: Expected O, but got I4
		//IL_04ab: Expected O, but got Ref
		//IL_052a: Expected O, but got I4
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
				{
					PhaserWorld instance = PhaserWorld.Instance;
					if ((object)instance != null)
					{
						Vector2 vector = default(Vector2);
						PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "UI", "Circle1");
						if ((object)phaserSprite != null)
						{
							PhaserSprite phaserSprite2 = phaserSprite.setDepth(31757);
							if ((object)phaserSprite2 != null)
							{
								PhaserSprite phaserSprite3 = phaserSprite2.setScale(4f, (float?)(object)0);
								if ((object)phaserSprite3 != null)
								{
									PhaserSprite component = phaserSprite3.setAlpha(0f);
									PhaserSprite sCenter = RenderingExtensions.SetScrollFactor(component, 0f);
									_sCenter = sCenter;
									PhaserWorld instance2 = PhaserWorld.Instance;
									if ((object)instance2 != null)
									{
										PhaserSprite phaserSprite4 = instance2.AddPhaserSprite(vector, "UI", "Circle2");
										if ((object)phaserSprite4 != null)
										{
											PhaserSprite phaserSprite5 = phaserSprite4.setDepth(31757);
											if ((object)phaserSprite5 != null)
											{
												PhaserSprite phaserSprite6 = phaserSprite5.setScale(4f, (float?)(object)0);
												if ((object)phaserSprite6 != null)
												{
													PhaserSprite component2 = phaserSprite6.setAlpha(0f);
													PhaserSprite sWorld = RenderingExtensions.SetScrollFactor(component2, 0f);
													_sWorld = sWorld;
													PhaserWorld instance3 = PhaserWorld.Instance;
													if ((object)instance3 != null)
													{
														PhaserSprite phaserSprite7 = instance3.AddPhaserSprite(vector, "UI", "Circle3");
														if ((object)phaserSprite7 != null)
														{
															PhaserSprite phaserSprite8 = phaserSprite7.setDepth(31757);
															if ((object)phaserSprite8 != null)
															{
																PhaserSprite phaserSprite9 = phaserSprite8.setScale(4f, (float?)(object)0);
																if ((object)phaserSprite9 != null)
																{
																	PhaserSprite component3 = phaserSprite9.setAlpha(0f);
																	PhaserSprite sMoon = RenderingExtensions.SetScrollFactor(component3, 0f);
																	_sMoon = sMoon;
																	PhaserWorld instance4 = PhaserWorld.Instance;
																	if ((object)instance4 != null)
																	{
																		PhaserSprite phaserSprite10 = instance4.AddPhaserSprite(vector, "UI", "Circle4");
																		if ((object)phaserSprite10 != null)
																		{
																			PhaserSprite phaserSprite11 = phaserSprite10.setDepth(31757);
																			if ((object)phaserSprite11 != null)
																			{
																				PhaserSprite phaserSprite12 = phaserSprite11.setScale(4f, (float?)(object)0);
																				if ((object)phaserSprite12 != null)
																				{
																					PhaserSprite component4 = phaserSprite12.setAlpha(0f);
																					PhaserSprite sSun = RenderingExtensions.SetScrollFactor(component4, 0f);
																					_sSun = sSun;
																					if ((object)GM.Core != null)
																					{
																						PhaserScene s_scene3 = ArcadePhysics.s_scene;
																						if (ArcadePhysics.s_scene != null)
																						{
																							Vector3 ret = default(Vector3);
																							float fontSize = default(float);
																							PhaserText component5 = RenderingExtensions.text(s_scene3.add, vector, "", (Color)(&ret), fontSize);
																							PhaserText phaserText = RenderingExtensions.SetScrollFactor(component5, 0f);
																							if ((object)phaserText != null)
																							{
																								PhaserText phaserText2 = phaserText.SetDepth(31758);
																								if ((object)phaserText2 != null)
																								{
																									PhaserText nextEventText = phaserText2.setOrigin(1f, (float?)(object)1);
																									_nextEventText = nextEventText;
																									if ((object)_nextEventText != null)
																									{
																										Transform transform = _nextEventText.transform;
																										if ((object)transform != null)
																										{
																											bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																											Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
																											_nextEventTextDefaultLocalPosition = ret;
																											_ = 0;
																											_nextEventTextGoldFeverLocalPosition = vector;
																											_ = 0;
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

	private void CalculateWeights()
	{
		//IL_00c3: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		//IL_0205: Expected O, but got I4
		//IL_024e: Expected O, but got I4
		//IL_0350: Expected O, but got I4
		//IL_0399: Expected O, but got I4
		_totalWeightGood = 0;
		_totalWeightBad = 0;
		List<WeightedTrisectionEventData> weightedGood = BuildWeightedList(_goodEvents, _dontRepeatEvents);
		_weightedGood = weightedGood;
		List<WeightedTrisectionEventData> weightedGood2 = _weightedGood;
		if (weightedGood2._size == 0 && _dontRepeatEvents)
		{
			List<WeightedTrisectionEventData> weightedGood3 = BuildWeightedList(_goodEvents, dontRepeatEvents: false);
			_weightedGood = weightedGood3;
		}
		List<WeightedTrisectionEventData> weightedGood4 = _weightedGood;
		int totalWeightGood;
		if (weightedGood4._size > 0)
		{
			object obj = weightedGood4._size - 1;
			if ((nint)obj >= weightedGood4._size)
			{
				goto IL_0401;
			}
			WeightedTrisectionEventData[] items = weightedGood4._items;
			object obj2 = weightedGood4._size - 1;
			WeightedTrisectionEventData weightedTrisectionEventData = items[obj2];
			totalWeightGood = weightedTrisectionEventData.weight;
		}
		else
		{
			totalWeightGood = 0;
		}
		_totalWeightGood = totalWeightGood;
		List<WeightedTrisectionEventData> weightedNeutral = BuildWeightedList(_neutralEvents, _dontRepeatEvents);
		_weightedNeutral = weightedNeutral;
		List<WeightedTrisectionEventData> weightedNeutral2 = _weightedNeutral;
		if (weightedNeutral2._size == 0 && _dontRepeatEvents)
		{
			List<WeightedTrisectionEventData> weightedNeutral3 = BuildWeightedList(_neutralEvents, dontRepeatEvents: false);
			_weightedNeutral = weightedNeutral3;
		}
		List<WeightedTrisectionEventData> weightedNeutral4 = _weightedNeutral;
		int totalWeightNeutral;
		if (weightedNeutral4._size > 0)
		{
			object obj3 = weightedNeutral4._size - 1;
			if ((nint)obj3 >= weightedNeutral4._size)
			{
				goto IL_0401;
			}
			WeightedTrisectionEventData[] items2 = weightedNeutral4._items;
			object obj4 = weightedNeutral4._size - 1;
			WeightedTrisectionEventData weightedTrisectionEventData2 = items2[obj4];
			totalWeightNeutral = weightedTrisectionEventData2.weight;
		}
		else
		{
			totalWeightNeutral = 0;
		}
		_totalWeightNeutral = totalWeightNeutral;
		List<WeightedTrisectionEventData> weightedBad = BuildWeightedList(_badEvents, _dontRepeatEvents);
		_weightedBad = weightedBad;
		List<WeightedTrisectionEventData> weightedBad2 = _weightedBad;
		if (weightedBad2._size == 0 && _dontRepeatEvents)
		{
			List<WeightedTrisectionEventData> weightedBad3 = BuildWeightedList(_badEvents, dontRepeatEvents: false);
			_weightedBad = weightedBad3;
		}
		List<WeightedTrisectionEventData> weightedBad4 = _weightedBad;
		bool flag = weightedBad4._size <= 0;
		int totalWeightBad = 0;
		if (!flag)
		{
			object obj5 = weightedBad4._size - 1;
			if ((nint)obj5 >= weightedBad4._size)
			{
				goto IL_0401;
			}
			WeightedTrisectionEventData[] items3 = weightedBad4._items;
			object obj6 = weightedBad4._size - 1;
			WeightedTrisectionEventData weightedTrisectionEventData3 = items3[obj6];
			totalWeightBad = weightedTrisectionEventData3.weight;
		}
		_totalWeightBad = totalWeightBad;
		return;
		IL_0401:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private List<WeightedTrisectionEventData> BuildWeightedList(List<TrisectionEvent> events, bool dontRepeatEvents)
	{
		//IL_01d6: Expected O, but got I4
		//IL_01e0: Expected O, but got I4
		//IL_004c: Expected I, but got O
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_014f: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected I4, but got Unknown
		//IL_0176: Expected O, but got I
		//IL_0141: Expected O, but got I
		List<WeightedTrisectionEventData> list = new List<WeightedTrisectionEventData>();
		bool flag = dontRepeatEvents;
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while (true)
		{
			if ((nint)obj2 < events._size)
			{
				if ((nint)obj >= events._size)
				{
					break;
				}
				TrisectionEvent[] items = events._items;
				nint num = (nint)items[obj];
				GameManager core = GM.Core;
				GameSessionData gameSessionData = core._gameSessionData;
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
				int level = activeCharacter._level;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdi_v3 (Il2CppMethodInfo)+4C]");
				if ((nint)level >= (nint)0)
				{
					if (dontRepeatEvents)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B60");
						if (obj3 != null)
						{
							goto IL_019b;
						}
					}
					object obj5;
					if (list._size > 0)
					{
						object obj4 = list._size - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v19+10]");
						obj5 = 0;
					}
					else
					{
						obj5 = 0;
					}
					WeightedTrisectionEventData weightedTrisectionEventData = new WeightedTrisectionEventData();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdi_v3 (Il2CppMethodInfo)+48]");
					int weight = 0 + obj5;
					weightedTrisectionEventData.ev = (TrisectionEvent)num;
					weightedTrisectionEventData.weight = weight;
					((List<object>)(object)list).Add((object)weightedTrisectionEventData);
					flag = false;
				}
				goto IL_019b;
			}
			return list;
			IL_019b:
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		List<WeightedTrisectionEventData> result = default(List<WeightedTrisectionEventData>);
		return result;
	}

	protected void CalculateMainChances()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		CalculateWeights();
		object obj = (object)_eventsRng << 13;
		object obj2 = obj ^ (object)_eventsRng;
		object obj3 = obj2 >> 17;
		object obj4 = obj2 ^ obj3;
		object obj5 = obj4 << 5;
		Unity.Mathematics.Random random = (_eventsRng = (Unity.Mathematics.Random)(obj5 ^ obj4));
		_nextChoice = ChoiceType.GOOD;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A396E]");
		if ((nint)0 > (nint)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A396E]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A396E]");
			if ((nint)0 <= (nint)0)
			{
				object obj6 = (object)random << 13;
				object obj7 = obj6 ^ (object)random;
				object obj8 = (object)random >> 9;
				object obj9 = obj8 | 0x3F800000;
				object obj10 = obj7 >> 17;
				object obj11 = obj7 ^ obj10;
				object obj12 = obj11 << 5;
				Unity.Mathematics.Random eventsRng = (Unity.Mathematics.Random)(obj12 ^ obj11);
				_eventsRng = eventsRng;
				GameManager core = GM.Core;
				GameSessionData gameSessionData = core._gameSessionData;
				float num = (float)obj9 - 1f;
				float num2 = num + 0.3f;
				float num3 = gameSessionData._activeCharacter.PLuck();
				double num4 = 0.45 * 0.5;
				bool flag = num4 > (double)num2;
				ChoiceType nextChoice = ChoiceType.GOOD;
				if (!flag)
				{
					nextChoice = ChoiceType.BAD;
				}
				_nextChoice = nextChoice;
			}
			else
			{
				_nextChoice = ChoiceType.BAD;
			}
		}
		else
		{
			_nextChoice = ChoiceType.NEUTRAL;
		}
	}

	protected virtual void ChooseEvent()
	{
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		object obj = (object)_eventsRng << 13;
		object obj2 = obj ^ (object)_eventsRng;
		object obj3 = (object)_eventsRng >> 9;
		object obj4 = obj2 >> 17;
		object obj5 = obj3 | 0x3F800000;
		object obj6 = obj2 ^ obj4;
		object obj7 = obj6 << 5;
		Unity.Mathematics.Random eventsRng = (Unity.Mathematics.Random)(obj7 ^ obj6);
		float num = (float)obj5 - 1f;
		_eventsRng = eventsRng;
		if (_nextChoice == ChoiceType.GOOD)
		{
			_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass44_0();
			float r = (float)_totalWeightGood * num;
			CS_0024_003C_003E8__locals6.r = r;
			Predicate<WeightedTrisectionEventData> match = delegate(WeightedTrisectionEventData x)
			{
				//IL_0050: Expected I4, but got O
				//IL_002c: Invalid comparison between I4 and F4
				if (x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				bool flag = (float)x.weight < CS_0024_003C_003E8__locals6.r;
				return !flag;
			};
			WeightedTrisectionEventData nextChosenEvent = _weightedGood.Find(match);
			_nextChosenEvent = nextChosenEvent;
		}
		if (_nextChoice == ChoiceType.NEUTRAL)
		{
			_003C_003Ec__DisplayClass44_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass44_1();
			float r2 = (float)_totalWeightNeutral * num;
			CS_0024_003C_003E8__locals7.r = r2;
			Predicate<WeightedTrisectionEventData> match2 = delegate(WeightedTrisectionEventData x)
			{
				//IL_0050: Expected I4, but got O
				//IL_002c: Invalid comparison between I4 and F4
				if (x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				bool flag = (float)x.weight < CS_0024_003C_003E8__locals7.r;
				return !flag;
			};
			WeightedTrisectionEventData nextChosenEvent2 = _weightedNeutral.Find(match2);
			_nextChosenEvent = nextChosenEvent2;
		}
		if (_nextChoice != ChoiceType.BAD)
		{
			return;
		}
		_003C_003Ec__DisplayClass44_2 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass44_2();
		float r3 = (float)_totalWeightBad * num;
		CS_0024_003C_003E8__locals8.r = r3;
		Predicate<WeightedTrisectionEventData> match3 = delegate(WeightedTrisectionEventData x)
		{
			//IL_0050: Expected I4, but got O
			//IL_002c: Invalid comparison between I4 and F4
			if (x == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = (float)x.weight < CS_0024_003C_003E8__locals8.r;
			return !flag;
		};
		WeightedTrisectionEventData nextChosenEvent3 = _weightedBad.Find(match3);
		_nextChosenEvent = nextChosenEvent3;
	}

	protected virtual void ShowCircles()
	{
		//IL_005e: Expected I, but got O
		//IL_00b6: Expected I, but got O
		//IL_010e: Expected I, but got O
		//IL_0166: Expected I, but got O
		//IL_01ca: Expected O, but got I4
		//IL_01d8: Expected O, but got I4
		if (_tweenShowCircles != null)
		{
			_tweenShowCircles.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[4];
		if ((object)_sCenter != null)
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
		if ((object)_sWorld != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sMoon != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sSun != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.scale = (float?)(object)1;
		StaggerConfig staggerConfig = new StaggerConfig();
		staggerConfig.ease = Ease.Linear;
		staggerConfig.start = 500f;
		Func<int, float> staggerDelay = Tweens.Stagger(100f, staggerConfig);
		tweenConfig.staggerDelay = staggerDelay;
		MultiTargetTween tweenShowCircles = Tweens.Add(tweenConfig);
		_tweenShowCircles = tweenShowCircles;
	}

	protected virtual void HideCircles()
	{
		//IL_005e: Expected I, but got O
		//IL_00b6: Expected I, but got O
		//IL_010e: Expected I, but got O
		//IL_0166: Expected I, but got O
		//IL_01ca: Expected O, but got I4
		//IL_01d8: Expected O, but got I4
		if (_tweenHideCircles != null)
		{
			_tweenHideCircles.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[4];
		if ((object)_sCenter != null)
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
		if ((object)_sWorld != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sMoon != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sSun != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.scale = (float?)(object)1;
		StaggerConfig staggerConfig = new StaggerConfig();
		staggerConfig.ease = Ease.Linear;
		staggerConfig.start = 500f;
		Func<int, float> staggerDelay = Tweens.Stagger(100f, staggerConfig);
		tweenConfig.staggerDelay = staggerDelay;
		MultiTargetTween tweenHideCircles = Tweens.Add(tweenConfig);
		_tweenHideCircles = tweenHideCircles;
	}

	protected void RotateEventNames()
	{
		//IL_0090: Expected I, but got O
		//IL_00f4: Expected O, but got I4
		//IL_0110: Expected O, but got I4
		string text = Extensions.PickRnd(_eventNames);
		PhaserText phaserText = _nextEventText.SetText(text);
		if (_tweenRotateName != null)
		{
			_tweenRotateName.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_nextEventText != null)
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
		tweenConfig.duration = 250f;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.yoyo = true;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserText phaserText2 = _nextEventText.SetTint(16777215u);
			PhaserText phaserText3 = RenderingExtensions.SetScale(_nextEventText, 1f);
			PhaserText phaserText4 = _nextEventText.SetAlpha(0.65f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween tweenRotateName = Tweens.Add(tweenConfig);
		_tweenRotateName = tweenRotateName;
	}

	protected void HighlightEventName(Action onTextHighlighted = null)
	{
		//IL_00ab: Expected I, but got O
		//IL_011d: Expected O, but got I4
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.onTextHighlighted = onTextHighlighted;
		if (_nextChosenEvent != null)
		{
			if (_tweenHighlightName != null)
			{
				_tweenHighlightName.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_nextEventText != null)
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
			tweenConfig.duration = 250f;
			tweenConfig.delay = 250f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				StageEventTrisectionManager stageEventTrisectionManager = CS_0024_003C_003E8__locals6._003C_003E4__this;
				WeightedTrisectionEventData nextChosenEvent = stageEventTrisectionManager._nextChosenEvent;
				string eventName = stageEventTrisectionManager.GetEventName(nextChosenEvent.ev);
				PhaserText phaserText2 = stageEventTrisectionManager._nextEventText.SetText(eventName);
				StageEventTrisectionManager stageEventTrisectionManager2 = CS_0024_003C_003E8__locals6._003C_003E4__this;
				PhaserText phaserText3 = stageEventTrisectionManager2._nextEventText.SetTint(16776960u);
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				Action onTextHighlighted2 = CS_0024_003C_003E8__locals6.onTextHighlighted;
				if (CS_0024_003C_003E8__locals6.onTextHighlighted != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tweenHighlightName = Tweens.Add(tweenConfig);
			_tweenHighlightName = tweenHighlightName;
		}
		else
		{
			PhaserText phaserText = _nextEventText.SetAlpha(0f);
		}
	}

	private string GetEventName(TrisectionEvent trisectionEvent)
	{
		if (trisectionEvent != null)
		{
			string term;
			if (trisectionEvent._003ClocalisationString_003Ek__BackingField == null)
			{
				string text = "eventLang/{" + ((VampireSurvivors.Data.Stage.Event)trisectionEvent)._003CeventType_003Ek__BackingField + "}displayName";
				term = text;
			}
			else
			{
				term = trisectionEvent._003ClocalisationString_003Ek__BackingField;
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			return LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		}
		return (string)(object)new NullReferenceException();
	}

	public StageEventTrisectionManager()
	{
		List<TrisectionEvent> triggeredEvents = new List<TrisectionEvent>();
		_triggeredEvents = triggeredEvents;
		_eventNames = new List<string>();
		_weightedGood = new List<WeightedTrisectionEventData>();
		_weightedNeutral = new List<WeightedTrisectionEventData>();
		_weightedBad = new List<WeightedTrisectionEventData>();
		base._002Ector();
	}

	private void _003CRotateEventNames_003Eb__47_0()
	{
		PhaserText phaserText = _nextEventText.SetTint(16777215u);
		PhaserText phaserText2 = RenderingExtensions.SetScale(_nextEventText, 1f);
		PhaserText phaserText3 = _nextEventText.SetAlpha(0.65f);
	}
}
