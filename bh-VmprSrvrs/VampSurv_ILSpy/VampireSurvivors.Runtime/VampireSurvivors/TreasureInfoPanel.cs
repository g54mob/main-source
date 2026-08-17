using System;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class TreasureInfoPanel : MonoBehaviour
{
	private TextMeshProUGUI Name;

	private TextMeshProUGUI Description;

	private TextMeshProUGUI Page;

	private TextMeshProUGUI Level;

	private TextMeshProUGUI AdditionalInfo;

	private Image Icon;

	private Image _Background;

	private List<TreasurePrizeTypePair> _rewards;

	private int _prizeIndex;

	private DataManager _data;

	private GameSessionData _session;

	private Sequence _tween;

	private float _baseScale;

	private void Construct(DataManager data, GameSessionData session)
	{
		_data = data;
		_session = session;
	}

	private void Start()
	{
	}

	public unsafe void Initialize(List<TreasurePrizeTypePair> prizes)
	{
		//IL_0065: Expected O, but got I
		//IL_0072: Expected O, but got I
		//IL_02a5: Expected O, but got Ref
		//IL_00b1: Expected O, but got Ref
		//IL_02e5: Expected I, but got O
		//IL_02ea->IL02b3: Incompatible stack heights: 1 vs 0
		Component rewards = (Component)(object)_rewards;
		if (_rewards != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rcx_v10 (UnityEngine.Component)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rcx_v10 (UnityEngine.Component)+18]");
			if ((nint)0 > (nint)0)
			{
				IntPtr cachedPtr = ((UnityEngine.Object)rewards).m_CachedPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rcx_v10 (UnityEngine.Component)+18]");
				Array.Clear((Array)(nint)cachedPtr, 0, 0);
				rewards = (Component)(nint)((UnityEngine.Object)rewards).m_CachedPtr;
			}
			_prizeIndex = 0;
			if (prizes != null)
			{
				List<TreasurePrizeTypePair>.Enumerator enumerator = default(List<TreasurePrizeTypePair>.Enumerator);
				if (enumerator.MoveNext())
				{
					List<TreasurePrizeTypePair> list = null;
					rewards = (Component)(&enumerator);
					throw new NullReferenceException();
				}
				List<TreasurePrizeTypePair> rewards2 = _rewards;
				bool flag = _rewards == null;
				rewards = (Component)(&enumerator);
				if (!flag)
				{
					if (rewards2._size <= 0)
					{
						return;
					}
					StartCycle();
					GameObject gameObject = base.gameObject;
					if ((object)gameObject != null)
					{
						bool flag2 = ((List<TreasurePrizeTypePair>)(object)gameObject)._items == null;
						GameObject.SetActive_Injected((IntPtr)((List<TreasurePrizeTypePair>)(object)gameObject)._items, true);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Reset()
	{
		Tween tween = _tween;
		if (_tween != null && tween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_tween);
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = base.gameObject;
		CanvasGroup component = gameObject2.GetComponent<CanvasGroup>();
		component.alpha = 0f;
	}

	private void StartCycle()
	{
		//IL_06d9: Invalid comparison between I4 and F4
		//IL_0125: Expected F4, but got I
		//IL_0220: Expected F4, but got I
		//IL_03c8: Expected F4, but got I
		//IL_031a: Expected F4, but got I
		//IL_04e4: Expected F4, but got I
		//IL_0652: Expected I4, but got I8
		//IL_0694: Expected O, but got I
		//IL_0736->IL083b: Incompatible stack heights: 1 vs 0
		Vector3 ret = default(Vector3);
		if (0f > _baseScale)
		{
			Transform transform = base.transform;
			if ((object)transform == null)
			{
				goto IL_06f0;
			}
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
			float baseScale = default(float);
			_baseScale = baseScale;
		}
		TweenExtensions.Kill(_tween);
		Sequence sequence = DOTween.Sequence();
		TweenCallback tweenCallback = delegate
		{
			Transform transform3 = base.transform;
			bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
		};
		object message;
		if (sequence != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+100]");
				if ((nint)0 == 0)
				{
					if (tweenCallback != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+A0]");
						Sequence sequence2 = Sequence.DoInsertCallback(sequence, tweenCallback, 0f);
					}
					goto IL_0194;
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
		goto IL_0194;
		IL_06f0:
		throw new NullReferenceException();
		IL_0194:
		Transform target = base.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScaleY(target, _baseScale, 0.5f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			if (sequence == null)
			{
				goto IL_06f0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+A0]");
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t, 0f);
		}
		List<TreasurePrizeTypePair> rewards = _rewards;
		if (_rewards == null)
		{
			goto IL_06f0;
		}
		if (rewards._size <= 1)
		{
			Sequence sequence4 = TweenSettingsExtensions.AppendInterval(sequence, 9f);
			Transform target2 = base.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScaleY(target2, 0f, 0.5f);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
			{
				if (sequence == null)
				{
					goto IL_06f0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+A0]");
				Sequence sequence5 = Sequence.DoInsert(sequence, (Tween)t2, 0f);
			}
			goto IL_0760;
		}
		Sequence sequence6 = TweenSettingsExtensions.AppendInterval(sequence, 4.5f);
		Transform target3 = base.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t3 = ShortcutExtensions.DOScaleY(target3, 0f, 0.5f);
		TweenCallback tweenCallback3;
		object message2;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t3, false))
		{
			if (sequence == null)
			{
				goto IL_06f0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+A0]");
			Sequence sequence7 = Sequence.DoInsert(sequence, (Tween)t3, 0f);
			TweenCallback tweenCallback2 = delegate
			{
				List<TreasurePrizeTypePair> rewards3 = _rewards;
				if (++_prizeIndex >= rewards3._size)
				{
					_prizeIndex = 0;
				}
				SetData();
			};
			tweenCallback3 = tweenCallback2;
		}
		else
		{
			TweenCallback tweenCallback4 = delegate
			{
				List<TreasurePrizeTypePair> rewards3 = _rewards;
				if (++_prizeIndex >= rewards3._size)
				{
					_prizeIndex = 0;
				}
				SetData();
			};
			bool flag2 = sequence == null;
			tweenCallback3 = tweenCallback4;
			if (flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "You can't add elements to a NULL Sequence";
				goto IL_085f;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+100]");
			if ((nint)0 == 0)
			{
				if (tweenCallback3 != null)
				{
					TweenCallback callback = tweenCallback3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+A0]");
					Sequence sequence8 = Sequence.DoInsertCallback(sequence, callback, 0f);
				}
				goto IL_0555;
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
		goto IL_085f;
		IL_0760:
		_tween = sequence;
		SetData();
		Transform transform2 = base.transform;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
		Transform target4 = base.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleY(target4, _baseScale, 0.5f);
		GameObject gameObject = base.gameObject;
		CanvasGroup component = gameObject.GetComponent<CanvasGroup>();
		component.alpha = 1f;
		return;
		IL_0555:
		List<TreasurePrizeTypePair> rewards2 = _rewards;
		if (_rewards == null)
		{
			goto IL_06f0;
		}
		int num = rewards2._size;
		if (sequence != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+100]");
				if ((nint)0 == 0)
				{
					if (rewards2._size >= -1)
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
					if (((UnityEngine.Object)(object)sequence).m_CachedPtr == (IntPtr)0)
					{
						if (num <= -1)
						{
							_ = 2139095040;
						}
						else
						{
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v9 (DG.Tweening.Sequence)+A0]");
							object obj = (nint)num2 * (nint)0;
						}
					}
				}
			}
		}
		goto IL_0760;
		IL_085f:
		Debugger.LogWarning(message2);
		goto IL_0555;
	}

	private void ShowFirst()
	{
		SetData();
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform target = base.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleY(target, _baseScale, 0.5f);
		GameObject gameObject = base.gameObject;
		CanvasGroup component = gameObject.GetComponent<CanvasGroup>();
		component.alpha = 1f;
	}

	private unsafe void SetData()
	{
		//IL_14cb: Expected O, but got I4
		//IL_01ad: Expected O, but got I
		//IL_01e2: Expected O, but got I
		//IL_0296: Expected O, but got I
		//IL_02d3: Expected O, but got I
		//IL_04ee: Expected I, but got O
		//IL_051f: Expected O, but got I
		//IL_0549: Expected O, but got I
		//IL_043a: Expected O, but got I4
		//IL_0578: Expected O, but got I
		//IL_1651: Expected O, but got I
		//IL_05af: Expected O, but got Ref
		//IL_0609: Expected I, but got O
		//IL_063a: Expected O, but got I
		//IL_0664: Expected O, but got I
		//IL_0acf: Expected I, but got O
		//IL_1585: Expected O, but got I
		//IL_0b0a: Expected I, but got O
		//IL_0b87: Expected I, but got O
		//IL_1704: Expected O, but got I
		//IL_0bb7: Expected O, but got I
		//IL_0bdc: Expected O, but got I
		//IL_0698: Expected O, but got Ref
		//IL_0bf2: Expected I, but got O
		//IL_1c86: Expected O, but got I
		//IL_0cc5: Expected I, but got O
		//IL_0f03: Expected I, but got O
		//IL_0d00: Expected I, but got O
		//IL_0d7d: Expected I, but got O
		//IL_0f35: Expected O, but got Ref
		//IL_1768: Expected O, but got I
		//IL_0763: Expected O, but got Ref
		//IL_0e90: Expected I4, but got O
		//IL_0e90: Expected O, but got I4
		//IL_07bd: Expected I, but got O
		//IL_07ee: Expected O, but got I
		//IL_0ec3: Expected I, but got O
		//IL_0818: Expected O, but got I
		//IL_0f82: Expected O, but got Ref
		//IL_0847: Expected O, but got I
		//IL_0876: Expected O, but got Ref
		//IL_0987: Expected O, but got I
		//IL_1096: Expected O, but got Ref
		//IL_09bc: Expected O, but got I
		//IL_119d: Expected O, but got I
		//IL_182c: Expected O, but got I
		//IL_11e6: Expected O, but got I
		//IL_120d: Expected O, but got I
		//IL_1890: Expected O, but got I
		//IL_18ff: Expected O, but got I
		//IL_1967: Expected O, but got I
		//IL_19cf: Expected O, but got I
		//IL_1292: Expected O, but got I
		//IL_1a23: Expected O, but got I
		//IL_1a4a: Expected O, but got I
		//IL_1aae: Expected O, but got I
		//IL_1b14: Expected O, but got I
		//IL_1b88: Expected O, but got I
		//IL_12fe: Expected O, but got I
		//IL_1324: Expected O, but got I4
		//IL_1344: Unknown result type (might be due to invalid IL or missing references)
		//IL_1349: Expected I4, but got Unknown
		//IL_13a9: Expected O, but got I4
		//IL_1bc6: Expected I4, but got O
		//IL_13e3: Expected O, but got I
		//IL_1418: Expected O, but got I
		//IL_1c1f: Expected O, but got Ref
		//IL_14b0: Expected O, but got Ref
		//IL_01cd->IL14b5: Incompatible stack heights: 1 vs 0
		//IL_0202->IL14b5: Incompatible stack heights: 1 vs 0
		//IL_021f->IL14b5: Incompatible stack heights: 1 vs 0
		//IL_025d->IL14b5: Incompatible stack heights: 1 vs 0
		//IL_02be->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_02f7->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0333->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_04a4->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_03a6->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0528->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0416->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0552->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0a06->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0581->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0643->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_1693->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_066d->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0afd->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_1c46->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0b7a->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0be5->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_070e->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0738->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_1746->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0ef6->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0cf3->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_1c64->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0d70->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0f5d->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0eb6->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_07f7->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0821->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0850->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_0fc3->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_08fb->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_094f->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_09a7->IL14b5: Incompatible stack heights: 3 vs 0
		//IL_09dc->IL09dc: Incompatible stack heights: 3 vs 2
		//IL_10d2->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_1132->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_17c6->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_1188->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_11c7->IL14b5: Incompatible stack heights: 2 vs 0
		//IL_1835->IL14b5: Incompatible stack heights: 3 vs 0
		//IL_1216->IL14b5: Incompatible stack heights: 3 vs 0
		//IL_1899->IL14b5: Incompatible stack heights: 4 vs 0
		//IL_1908->IL14b5: Incompatible stack heights: 5 vs 0
		//IL_1970->IL14b5: Incompatible stack heights: 6 vs 0
		//IL_19d8->IL14b5: Incompatible stack heights: 7 vs 0
		//IL_1270->IL14b5: Incompatible stack heights: 7 vs 0
		//IL_12ba->IL14b5: Incompatible stack heights: 7 vs 0
		//IL_1a53->IL14b5: Incompatible stack heights: 8 vs 0
		//IL_1ab7->IL14b5: Incompatible stack heights: 9 vs 0
		//IL_1b1d->IL14b5: Incompatible stack heights: 10 vs 0
		//IL_1b91->IL14b5: Incompatible stack heights: 11 vs 0
		//IL_1307->IL14b5: Incompatible stack heights: 11 vs 0
		//IL_1bf4->IL14b5: Incompatible stack heights: 12 vs 0
		//IL_1403->IL14b5: Incompatible stack heights: 13 vs 0
		//IL_1438->IL14b5: Incompatible stack heights: 13 vs 0
		//IL_1c28->IL14b5: Incompatible stack heights: 13 vs 0
		//IL_14b5->IL14f4: Incompatible stack heights: 13 vs 0
		Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)_prizeIndex;
		List<TreasurePrizeTypePair> rewards = _rewards;
		if (_rewards != null)
		{
			if (_prizeIndex >= rewards._size)
			{
				return;
			}
			dictionary = (Dictionary<System.Int32Enum, object>)(object)Description;
			if ((object)Description != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+29C]");
				if ((nint)0 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+2A0]");
					if ((nint)0 == 2048)
					{
						goto IL_14f5;
					}
				}
				_ = 1;
				_ = 2048;
				_ = 1;
				bool flag = ((Dictionary<TKey, TValue>)(object)dictionary).System_002ECollections_002EIDictionary_002EIsReadOnly;
				goto IL_14f5;
			}
		}
		goto IL_14b5;
		IL_1671:
		bool flag2 = (object)Name == null;
		string text;
		dictionary = (Dictionary<System.Int32Enum, object>)(object)text;
		object obj;
		if (!flag2)
		{
			nint num = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2753 @ rax_v78 (Il2CppClass<System.Object>)+558] (should have been resolved before IL gen)");
			dictionary = (Dictionary<System.Int32Enum, object>)(object)Name;
			if ((object)Name != null)
			{
				nint num2 = (nint)dictionary;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2826 @ rdx_v58 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+548] (should have been resolved before IL gen)");
				object obj2 = default(object);
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v81+10]");
					if ((nint)0 > (nint)0)
					{
						goto IL_1698;
					}
				}
				dictionary = (Dictionary<System.Int32Enum, object>)(object)Name;
				if ((object)Name != null)
				{
					nint num3 = (nint)dictionary;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2957 @ rax_v251 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+558] (should have been resolved before IL gen)");
					goto IL_1698;
				}
			}
		}
		goto IL_14b5;
		IL_16bf:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C63]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v68+20]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
		string prefix = ((WeaponData)num4).GetPrefix(WeaponType.VOID);
		string term = prefix + "tips";
		bool flag4 = default(bool);
		bool flag5 = default(bool);
		GameObject gameObject = default(GameObject);
		string text2 = default(string);
		bool flag3 = LocalizationManager.TryGetTranslation(term, out var Translation, FixForRTL: true, 0, flag4, flag5, gameObject, text2);
		WeaponData weaponData;
		if (weaponData._003CisEvolution_003Ek__BackingField && Translation != null && Translation._stringLength > 0)
		{
			object additionalInfo = AdditionalInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C63]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v68+20]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
			string prefix2 = ((WeaponData)num5).GetPrefix(WeaponType.VOID);
			string text3 = prefix2 + "tips";
			string translation = LocalizationManager.GetTranslation(text3, FixForRTL: true, 0, ignoreRTLnumbers: true, flag4, (GameObject)flag5, (string)(object)gameObject, (byte)(int)text2 != 0);
			bool flag6 = (object)AdditionalInfo == null;
			dictionary = (Dictionary<System.Int32Enum, object>)(object)text3;
			if (!flag6)
			{
				nint num6 = (nint)additionalInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3722 @ r9_v40 (Il2CppClass<System.Object>)+558] (should have been resolved before IL gen)");
				goto IL_0f17;
			}
		}
		else
		{
			dictionary = (Dictionary<System.Int32Enum, object>)(object)AdditionalInfo;
			if ((object)AdditionalInfo != null)
			{
				nint num7 = (nint)dictionary;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3637 @ rax_v219 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+558] (should have been resolved before IL gen)");
				goto IL_0f17;
			}
		}
		goto IL_14b5;
		IL_0f17:
		int value = _prizeIndex + 1;
		float ret = default(float);
		string text4 = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&ret), null);
		dictionary = (Dictionary<System.Int32Enum, object>)(object)_rewards;
		string Translation2;
		string text7;
		if (_rewards != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+18]");
			string text5 = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&ret), null);
			string text6 = text4 + "/" + text5;
			bool flag7 = (object)Page == null;
			dictionary = (Dictionary<System.Int32Enum, object>)(object)text4;
			if (!flag7)
			{
				Page.text = text6;
				bool flag8 = LocalizationManager.TryGetTranslation("lang/weapon_level_", out Translation2, FixForRTL: true, 0, flag4, flag5, gameObject, text2);
				if (Translation2 != null)
				{
					bool flag9 = Translation2._stringLength > 0;
					text7 = Translation2;
					if (flag9)
					{
						goto IL_1076;
					}
				}
				text7 = "lang/weapon_level_";
				goto IL_1076;
			}
		}
		goto IL_14b5;
		IL_1bf9:
		string hex;
		Color color = ColourHelper.HexToColor(hex);
		bool flag10 = (object)_Background == null;
		dictionary = (Dictionary<System.Int32Enum, object>)(&ret);
		if (!flag10)
		{
			_Background.color = (Color)(&ret);
			return;
		}
		goto IL_14b5;
		IL_14b5:
		throw new NullReferenceException();
		IL_14f5:
		dictionary = (Dictionary<System.Int32Enum, object>)(object)AdditionalInfo;
		if ((object)AdditionalInfo == null)
		{
			goto IL_14b5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+29C]");
		if ((nint)0 == 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+2A0]");
			if ((nint)0 == 2048)
			{
				goto IL_151e;
			}
		}
		_ = 1;
		_ = 2048;
		_ = 1;
		bool flag11 = ((Dictionary<TKey, TValue>)(object)dictionary).System_002ECollections_002EIDictionary_002EIsReadOnly;
		goto IL_151e;
		IL_1076:
		int num8;
		int value2 = num8 + 1;
		string text8 = System.Number.FormatInt32(value2, (ReadOnlySpan<char>)(&ret), CultureInfo.invariant_culture_info);
		string text9 = text7 + text8;
		bool flag12 = (object)Level == null;
		dictionary = (Dictionary<System.Int32Enum, object>)(object)text7;
		if (!flag12)
		{
			Level.text = text9;
			Sprite sprite = SpriteManager.GetSprite(weaponData._003CframeName_003Ek__BackingField, weaponData._003Ctexture_003Ek__BackingField);
			bool flag13 = (object)Icon == null;
			dictionary = (Dictionary<System.Int32Enum, object>)(object)weaponData._003CframeName_003Ek__BackingField;
			if (!flag13)
			{
				Icon.sprite = sprite;
				bool flag14 = (object)Icon == null;
				dictionary = (Dictionary<System.Int32Enum, object>)(object)Icon;
				if (!flag14)
				{
					RectTransform rectTransform = Icon.rectTransform;
					object icon = Icon;
					bool flag15 = (object)Icon == null;
					dictionary = (Dictionary<System.Int32Enum, object>)(object)Icon;
					if (!flag15)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rdi_v36 (System.Object)+E0]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rdi_v36 (System.Object)+E0]");
						bool flag16 = (nint)0 == 0;
						dictionary = (Dictionary<System.Int32Enum, object>)(object)Icon;
						if (!flag16)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdi_v37 (System.Object)+10]");
							bool flag17 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdi_v37 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
							object icon2 = Icon;
							bool flag18 = (object)Icon == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdi_v37 (System.Object)+10]");
							dictionary = (Dictionary<System.Int32Enum, object>)0;
							if (!flag18)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdi_v38 (System.Object)+E0]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdi_v38 (System.Object)+E0]");
								bool flag19 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdi_v37 (System.Object)+10]");
								dictionary = (Dictionary<System.Int32Enum, object>)0;
								if (!flag19)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdi_v39 (System.Object)+10]");
									bool flag20 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdi_v39 (System.Object)+10]");
									Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
									bool flag21 = (object)rectTransform == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdi_v39 (System.Object)+10]");
									dictionary = (Dictionary<System.Int32Enum, object>)0;
									if (!flag21)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rax_v124 (UnityEngine.RectTransform)+10]");
										bool flag22 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rax_v124 (UnityEngine.RectTransform)+10]");
										RectTransform.set_sizeDelta_Injected((IntPtr)0, ref *(Vector2*)(&Translation2));
										object icon3 = Icon;
										bool flag23 = (object)Icon == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rax_v124 (UnityEngine.RectTransform)+10]");
										dictionary = (Dictionary<System.Int32Enum, object>)0;
										if (!flag23)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rdi_v41 (System.Object)+10]");
											bool flag24 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rdi_v41 (System.Object)+10]");
											IntPtr intPtr = Component.get_transform_Injected((IntPtr)0);
											Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr);
											bool flag25 = (object)transform == null;
											dictionary = (Dictionary<System.Int32Enum, object>)(nint)intPtr;
											if (!flag25)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rax_v141 (UnityEngine.Transform)+10]");
												bool flag26 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rax_v141 (UnityEngine.Transform)+10]");
												IntPtr parent_Injected = Transform.GetParent_Injected((IntPtr)0);
												Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
												bool flag27 = (object)transform2 == null;
												dictionary = (Dictionary<System.Int32Enum, object>)(nint)parent_Injected;
												if (!flag27)
												{
													Image component = transform2.GetComponent<Image>();
													bool flag28 = (object)component == null;
													dictionary = (Dictionary<System.Int32Enum, object>)(object)transform2;
													if (!flag28)
													{
														RectTransform rectTransform2 = component.rectTransform;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v147 (UnityEngine.UI.Image)+E0]");
														IFormatProvider formatProvider = (IFormatProvider)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v147 (UnityEngine.UI.Image)+E0]");
														bool flag29 = (nint)0 == 0;
														dictionary = (Dictionary<System.Int32Enum, object>)(object)component;
														if (!flag29)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rsi_v32 (System.IFormatProvider)+10]");
															bool flag30 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rsi_v32 (System.IFormatProvider)+10]");
															Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v147 (UnityEngine.UI.Image)+E0]");
															object obj5 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v147 (UnityEngine.UI.Image)+E0]");
															bool flag31 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rsi_v32 (System.IFormatProvider)+10]");
															dictionary = (Dictionary<System.Int32Enum, object>)0;
															if (!flag31)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdi_v44 (System.Object)+10]");
																bool flag32 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdi_v44 (System.Object)+10]");
																Sprite.get_rect_Injected((IntPtr)0, out ret2);
																bool flag33 = (object)rectTransform2 == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdi_v44 (System.Object)+10]");
																dictionary = (Dictionary<System.Int32Enum, object>)0;
																if (!flag33)
																{
																	bool flag34 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
																	RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)rectTransform2).m_CachedPtr, ref *(Vector2*)(&Translation2));
																	object page = Page;
																	bool flag35 = (object)Page == null;
																	dictionary = (Dictionary<System.Int32Enum, object>)(nint)((UnityEngine.Object)rectTransform2).m_CachedPtr;
																	if (!flag35)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdi_v46 (System.Object)+10]");
																		bool flag36 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdi_v46 (System.Object)+10]");
																		IntPtr intPtr2 = Component.get_gameObject_Injected((IntPtr)0);
																		GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(intPtr2);
																		List<TreasurePrizeTypePair> rewards2 = _rewards;
																		bool flag37 = _rewards == null;
																		dictionary = (Dictionary<System.Int32Enum, object>)(nint)intPtr2;
																		if (!flag37)
																		{
																			bool flag38 = (object)gameObject2 == null;
																			dictionary = (Dictionary<System.Int32Enum, object>)(nint)intPtr2;
																			if (!flag38)
																			{
																				bool flag39 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
																				object obj6 = rewards2._size - 1;
																				int num9 = rewards2._size ^ 1;
																				int num10 = rewards2._size ^ obj6;
																				int num11 = num9 & num10;
																				bool flag40 = num11 < 0;
																				bool flag41 = (nint)obj6 < 0;
																				bool flag42 = obj6 == null;
																				bool flag43 = flag41 == flag40;
																				bool flag44 = !flag42;
																				object obj7 = flag44 & flag43;
																				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, (byte)(int)obj7 != 0);
																				dictionary = (Dictionary<System.Int32Enum, object>)(object)_rewards;
																				int prizeIndex = _prizeIndex;
																				if (_rewards != null)
																				{
																					int prizeIndex2 = _prizeIndex;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+18]");
																					bool flag45 = (nint)prizeIndex2 >= (nint)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+10]");
																					dictionary = (Dictionary<System.Int32Enum, object>)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+10]");
																					if ((nint)0 != 0)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+20+v445 @ rax_v171 (System.Int32)*8]");
																						object obj8 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+20+v445 @ rax_v171 (System.Int32)*8]");
																						if ((nint)0 != 0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rdx_v90+18]");
																							if ((nint)0 > (nint)0)
																							{
																								bool flag46 = weaponData._003CisEvolution_003Ek__BackingField;
																								hex = "0xffff00";
																								if (flag46)
																								{
																									goto IL_1bf9;
																								}
																							}
																							hex = "0xffffff";
																							goto IL_1bf9;
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
		goto IL_14b5;
		IL_1698:
		object description = Description;
		List<WeaponData> list;
		if (num8 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v68+20]");
			nint num12 = 0;
			List<WeaponData> levelData = list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
			string localizedDescriptionForLevel = ((WeaponData)num12).GetLocalizedDescriptionForLevel((WeaponData)(object)levelData, WeaponType.VOID);
			bool flag47 = (object)Description == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v68+20]");
			dictionary = (Dictionary<System.Int32Enum, object>)0;
			if (flag47)
			{
				goto IL_14b5;
			}
			nint num13 = (nint)description;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3077 @ r9_v43 (Il2CppClass<System.Object>)+558] (should have been resolved before IL gen)");
			goto IL_16bf;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C62]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v68+20]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
		string prefix3 = ((WeaponData)num14).GetPrefix(WeaponType.VOID);
		string text10 = prefix3 + "description";
		bool flag48 = LocalizationManager.TryGetTranslation(text10, out Translation2, FixForRTL: true, 0, flag4, flag5, gameObject, text2);
		string text11;
		if (Translation2 != null)
		{
			bool flag49 = Translation2._stringLength > 0;
			text11 = Translation2;
			if (flag49)
			{
				goto IL_1724;
			}
		}
		text11 = text10;
		goto IL_1724;
		IL_1724:
		bool flag50 = (object)Description == null;
		dictionary = (Dictionary<System.Int32Enum, object>)(object)text10;
		if (!flag50)
		{
			nint num15 = (nint)description;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3641 @ rax_v239 (Il2CppClass<System.Object>)+558] (should have been resolved before IL gen)");
			dictionary = (Dictionary<System.Int32Enum, object>)(object)Description;
			if ((object)Description != null)
			{
				nint num16 = (nint)dictionary;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3756 @ rdx_v106 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+548] (should have been resolved before IL gen)");
				object obj9 = default(object);
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rax_v242+10]");
					if ((nint)0 > (nint)0)
					{
						goto IL_16bf;
					}
				}
				dictionary = (Dictionary<System.Int32Enum, object>)(object)Description;
				if ((object)Description != null)
				{
					nint num17 = (nint)dictionary;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3869 @ rax_v243 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+558] (should have been resolved before IL gen)");
					goto IL_16bf;
				}
			}
		}
		goto IL_14b5;
		IL_151e:
		bool flag51 = _data == null;
		dictionary = (Dictionary<System.Int32Enum, object>)(object)_data;
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons;
		if (!flag51)
		{
			convertedWeapons = _data.GetConvertedWeapons();
			dictionary = (Dictionary<System.Int32Enum, object>)(object)_rewards;
			int prizeIndex3 = _prizeIndex;
			if (_rewards != null)
			{
				int prizeIndex4 = _prizeIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+18]");
				bool flag52 = (nint)prizeIndex4 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+10]");
				dictionary = (Dictionary<System.Int32Enum, object>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+20+v342 @ rdx_v48 (System.Int32)*8]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+20+v342 @ rdx_v48 (System.Int32)*8]");
					if ((nint)0 != 0 && convertedWeapons != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
						object obj11 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
						bool flag53 = obj11 == null;
						dictionary = (Dictionary<System.Int32Enum, object>)(object)convertedWeapons;
						if (!flag53)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v67 (System.Object)+18]");
							bool flag54 = (nint)0 <= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v67 (System.Object)+10]");
							object obj12 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v67 (System.Object)+10]");
							bool flag55 = (nint)0 == 0;
							dictionary = (Dictionary<System.Int32Enum, object>)(object)convertedWeapons;
							if (!flag55)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v68+20]");
								weaponData = (WeaponData)0;
								bool flag56 = _rewards == null;
								dictionary = (Dictionary<System.Int32Enum, object>)(object)_rewards;
								if (!flag56)
								{
									List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)(object)_rewards).get_Item((WeaponType)_prizeIndex);
									bool flag57 = list2 == null;
									dictionary = (Dictionary<System.Int32Enum, object>)(object)_rewards;
									if (!flag57)
									{
										num8 = list2._version;
										bool flag58 = list2._version < 0;
										nint num18 = 0;
										if (flag58)
										{
											goto IL_044f;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
										object obj13 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
										bool flag59 = obj13 == null;
										dictionary = (Dictionary<System.Int32Enum, object>)(object)convertedWeapons;
										if (!flag59)
										{
											int version = list2._version;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v342 (System.Object)+18]");
											bool flag60 = (nint)version >= (nint)0;
											num18 = 0;
											if (flag60)
											{
												goto IL_044f;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
											object obj14 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
											bool flag61 = obj14 == null;
											dictionary = (Dictionary<System.Int32Enum, object>)(object)convertedWeapons;
											if (!flag61)
											{
												List<WeaponData> list3 = ((Dictionary<WeaponType, List<WeaponData>>)obj14).get_Item((WeaponType)list2._version);
												LinkedList<WeaponType>.Enumerator enumerator = (LinkedList<WeaponType>.Enumerator)0;
												list = list3;
												dictionary = (Dictionary<System.Int32Enum, object>)obj14;
												goto IL_09dc;
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
		goto IL_14b5;
		IL_09dc:
		obj = Name;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v68+20]");
		if ((nint)0 == 0)
		{
			goto IL_14b5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v68+20]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
		string prefix4 = ((WeaponData)num19).GetPrefix(WeaponType.VOID);
		text = prefix4 + "name";
		bool flag62 = LocalizationManager.TryGetTranslation(text, out Translation2, FixForRTL: true, 0, flag4, flag5, gameObject, text2);
		string text12;
		if (Translation2 != null)
		{
			bool flag63 = Translation2._stringLength > 0;
			text12 = Translation2;
			if (flag63)
			{
				goto IL_1671;
			}
		}
		text12 = text;
		goto IL_1671;
		IL_044f:
		System.Int32Enum int32Enum = default(System.Int32Enum);
		object arg = (WeaponType)int32Enum;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
		object obj15 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
		bool flag64 = obj15 == null;
		dictionary = (Dictionary<System.Int32Enum, object>)(object)convertedWeapons;
		if (!flag64)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj16 = default(object);
			object arg2 = default(object);
			string message = $"Trying to get level data for {arg} at level {obj16}. Data contains {arg2} levels.";
			Debug.LogError(message);
			nint num20 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2371 @ rax_v265 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num21 = 0;
			GameManager core = GM.Core;
			bool flag65 = (object)GM.Core == null;
			dictionary = (Dictionary<System.Int32Enum, object>)num21;
			if (!flag65)
			{
				bool flag66 = core._levelUpFactory == null;
				dictionary = (Dictionary<System.Int32Enum, object>)num21;
				if (!flag66)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BB90");
					object obj17 = default(object);
					bool flag67 = obj17 == null;
					dictionary = (Dictionary<System.Int32Enum, object>)num21;
					if (!flag67)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BD880");
						string text13 = "Current Weapon Store:\n";
						object obj18 = obj16;
						LinkedList<WeaponType>.Enumerator enumerator2 = default(LinkedList<WeaponType>.Enumerator);
						IntPtr intPtr3 = default(IntPtr);
						while (enumerator2.MoveNext())
						{
							string text14 = ((Enum)(&intPtr3)).ToString();
							string text15 = text13 + text14;
							string text16 = text15 + "\n";
							text13 = text16;
							obj18 = null;
						}
						Debug.LogWarning(text13);
						nint num22 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2838 @ rax_v274 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num23 = 0;
						GameManager core2 = GM.Core;
						bool flag68 = (object)GM.Core == null;
						dictionary = (Dictionary<System.Int32Enum, object>)num23;
						if (!flag68)
						{
							bool flag69 = core2._levelUpFactory == null;
							dictionary = (Dictionary<System.Int32Enum, object>)num23;
							if (!flag69)
							{
								dictionary = (Dictionary<System.Int32Enum, object>)num23;
								if (LevelUpFactory._excludedWeapons != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BD880");
									string text17 = "Current Excluded Weapons:\n";
									LinkedList<WeaponType>.Enumerator enumerator3 = default(LinkedList<WeaponType>.Enumerator);
									IntPtr intPtr4 = default(IntPtr);
									while (enumerator3.MoveNext())
									{
										string text18 = ((Enum)(&intPtr4)).ToString();
										string text19 = text17 + text18;
										string text20 = text19 + "\n";
										text17 = text20;
										obj18 = null;
									}
									Debug.LogWarning(text17);
									GameManager core3 = GM.Core;
									bool flag70 = (object)GM.Core == null;
									dictionary = (Dictionary<System.Int32Enum, object>)(object)text17;
									if (!flag70)
									{
										bool flag71 = core3._levelUpFactory == null;
										dictionary = (Dictionary<System.Int32Enum, object>)(object)text17;
										if (!flag71)
										{
											dictionary = (Dictionary<System.Int32Enum, object>)(object)text17;
											if (LevelUpFactory._banishedWeapons != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BD880");
												string text21 = "Current Banished Weapons:\n";
												LinkedList<WeaponType>.Enumerator enumerator4 = default(LinkedList<WeaponType>.Enumerator);
												IntPtr intPtr5 = default(IntPtr);
												while (enumerator4.MoveNext())
												{
													string text22 = ((Enum)(&intPtr5)).ToString();
													string text23 = text21 + text22;
													string text24 = text23 + "\n";
													text21 = text24;
													obj18 = null;
												}
												Debug.LogWarning(text21);
												nint num24 = (nint)typeof(GM);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4006 @ rax_v298 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
												nint num25 = 0;
												GameManager core4 = GM.Core;
												bool flag72 = (object)GM.Core == null;
												dictionary = (Dictionary<System.Int32Enum, object>)num25;
												if (!flag72)
												{
													bool flag73 = core4._levelUpFactory == null;
													dictionary = (Dictionary<System.Int32Enum, object>)num25;
													if (!flag73)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BBF0");
														object obj19 = default(object);
														bool flag74 = obj19 == null;
														dictionary = (Dictionary<System.Int32Enum, object>)num25;
														if (!flag74)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BD880");
															string text25 = "Current Special Weapons:\n";
															LinkedList<WeaponType>.Enumerator enumerator5 = default(LinkedList<WeaponType>.Enumerator);
															IntPtr intPtr6 = default(IntPtr);
															while (enumerator5.MoveNext())
															{
																string text26 = ((Enum)(&intPtr6)).ToString();
																string text27 = text25 + text26;
																string text28 = text27 + "\n";
																text25 = text28;
															}
															Debug.LogWarning(text25);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
															object obj20 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
															bool flag75 = obj20 == null;
															dictionary = (Dictionary<System.Int32Enum, object>)(object)convertedWeapons;
															if (!flag75)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v307 (System.Object)+18]");
																num8 = (int)(-1);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v49+18]");
																object obj21 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
																bool flag76 = obj21 == null;
																dictionary = (Dictionary<System.Int32Enum, object>)(object)convertedWeapons;
																if (!flag76)
																{
																	int num26 = num8;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rax_v308 (System.Object)+18]");
																	bool flag77 = (nint)num26 >= (nint)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rax_v308 (System.Object)+10]");
																	dictionary = (Dictionary<System.Int32Enum, object>)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rax_v308 (System.Object)+10]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v56 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+20+v281 @ r14_v27 (System.Int32)*8]");
																		list = (List<WeaponData>)0;
																		Debug.LogWarning("Using last level's data as a fallback");
																		LinkedList<WeaponType>.Enumerator enumerator6 = default(LinkedList<WeaponType>.Enumerator);
																		LinkedList<WeaponType>.Enumerator enumerator = enumerator6;
																		dictionary = (Dictionary<System.Int32Enum, object>)(object)"Using last level's data as a fallback";
																		goto IL_09dc;
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
		goto IL_14b5;
	}

	public TreasureInfoPanel()
	{
		List<TreasurePrizeTypePair> rewards = new List<TreasurePrizeTypePair>();
		_rewards = rewards;
		_baseScale = -1f;
	}

	private void _003CStartCycle_003Eb__17_0()
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void _003CStartCycle_003Eb__17_1()
	{
		List<TreasurePrizeTypePair> rewards = _rewards;
		if (++_prizeIndex >= rewards._size)
		{
			_prizeIndex = 0;
		}
		SetData();
	}
}
