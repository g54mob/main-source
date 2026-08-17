using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI;

public class SpinningRingOfCards : MonoBehaviour
{
	private int _Amount;

	private float _Radius;

	private float _Scale;

	private float _Speed;

	private float _Duration;

	private GameObject _ArcanaCard;

	private int _arcanaIndexMin;

	private int _arcanaIndexMax;

	private string _backFrameName;

	private bool _ignoreDarkana;

	public float _X;

	public float _Y;

	private SignalBus _signalBus;

	private DataManager _data;

	private Dictionary<ArcanaType, ArcanaData> _arcanaData;

	private List<ArcanaType> _arcanaList;

	private List<GameObject> _spawned;

	private Sequence _flushSeq;

	private void Construct(SignalBus signalBus, DataManager data, PlayerOptions player)
	{
		_signalBus = signalBus;
		_data = data;
	}

	private void Start()
	{
	}

	public void DefaultInit()
	{
		float scale = default(float);
		float duration = default(float);
		Initialize(_Amount, _Radius, _Speed, scale, duration);
	}

	private unsafe void Update()
	{
		//IL_002b: Expected O, but got F4
		//IL_0021: Expected O, but got Ref
		Transform transform = base.transform;
		object obj = Time.deltaTime;
		object obj2 = default(object);
		transform.Rotate((Vector3)(&obj2), Space.Self);
	}

	private void OnDisable()
	{
		Tween flushSeq = _flushSeq;
		if (_flushSeq != null && flushSeq._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_flushSeq);
		}
	}

	private void OnDestroy()
	{
		Tween flushSeq = _flushSeq;
		if (_flushSeq != null && flushSeq._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_flushSeq);
		}
	}

	private unsafe void Initialize(int amount, float radius, float speed, float scale, float duration)
	{
		//IL_00ac: Expected I4, but got O
		//IL_01d6: Expected O, but got I4
		//IL_0107: Expected I4, but got O
		//IL_0114: Expected I4, but got O
		//IL_018b: Expected I4, but got O
		//IL_0198: Expected I4, but got O
		//IL_09dc: Expected O, but got I4
		//IL_0232: Expected O, but got I
		//IL_06b8: Expected I, but got O
		//IL_06ce: Expected O, but got I
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Expected O, but got Unknown
		//IL_0752: Expected I, but got O
		//IL_0bc9: Expected O, but got I4
		//IL_0be0: Expected I, but got I8
		//IL_072e: Expected I, but got I8
		//IL_08d7: Expected I4, but got I8
		//IL_03b9: Expected O, but got Ref
		//IL_0403: Expected O, but got Ref
		//IL_0440: Expected I4, but got O
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_046b: Expected F4, but got I4
		//IL_047f: Expected I4, but got O
		//IL_09bd->IL0956: Incompatible stack heights: 1 vs 0
		//IL_0a00->IL0956: Incompatible stack heights: 1 vs 0
		//IL_0252->IL0956: Incompatible stack heights: 2 vs 0
		//IL_0294->IL0956: Incompatible stack heights: 3 vs 0
		//IL_02cc->IL0956: Incompatible stack heights: 3 vs 0
		//IL_02f6->IL0956: Incompatible stack heights: 3 vs 0
		//IL_037d->IL0956: Incompatible stack heights: 6 vs 0
		//IL_03a7->IL0956: Incompatible stack heights: 6 vs 0
		//IL_03e3->IL0956: Incompatible stack heights: 6 vs 0
		//IL_042c->IL0956: Incompatible stack heights: 6 vs 0
		//IL_0489->IL0aad: Incompatible stack heights: 6 vs 0
		//IL_048e->IL048e: Incompatible stack heights: 6 vs 0
		DataManager data = _data;
		if (_data != null)
		{
			_arcanaData = data._003CAllArcanas_003Ek__BackingField;
			if (_arcanaData != null)
			{
				Dictionary<ArcanaType, ArcanaData>.KeyCollection keys = _arcanaData.Keys;
				if (keys == null)
				{
					Exception ex = System.Linq.Error.ArgumentNull("source");
					throw ex;
				}
				List<System.Int32Enum> list = (List<System.Int32Enum>)(object)(_arcanaList = (List<ArcanaType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)(object)keys));
				bool flag = _arcanaIndexMin <= -1;
				ArcanaType a = (ArcanaType)keys;
				SpinningRingOfCards spinningRingOfCards = (SpinningRingOfCards)(object)list;
				if (!flag)
				{
					Predicate<ArcanaType> predicate = delegate(ArcanaType arcanaType)
					{
						//IL_000f: Expected O, but got I4
						//IL_0026: Unknown result type (might be due to invalid IL or missing references)
						//IL_002b: Expected O, but got Unknown
						//IL_0033: Unknown result type (might be due to invalid IL or missing references)
						//IL_0038: Expected I4, but got Unknown
						object obj7 = arcanaType - _arcanaIndexMin;
						int num6 = (int)arcanaType ^ _arcanaIndexMin;
						object obj8 = arcanaType ^ obj7;
						int num7 = num6 & obj8;
						bool flag17 = num7 < 0;
						bool flag18 = (nint)obj7 < 0;
						return flag18 != flag17;
					};
					if (_arcanaList == null)
					{
						goto IL_0956;
					}
					bool flag2 = ((SpinningRingOfCards)(object)_arcanaList)._003CInitialize_003Eb__24_0((ArcanaType)predicate);
					a = (ArcanaType)predicate;
					spinningRingOfCards = (SpinningRingOfCards)(object)_arcanaList;
				}
				if (_arcanaIndexMax > -1)
				{
					Predicate<ArcanaType> predicate2 = delegate(ArcanaType arcanaType)
					{
						//IL_000f: Expected O, but got I4
						//IL_0026: Unknown result type (might be due to invalid IL or missing references)
						//IL_002b: Expected O, but got Unknown
						//IL_0033: Unknown result type (might be due to invalid IL or missing references)
						//IL_0038: Expected I4, but got Unknown
						object obj7 = arcanaType - _arcanaIndexMax;
						int num6 = (int)arcanaType ^ _arcanaIndexMax;
						object obj8 = arcanaType ^ obj7;
						int num7 = num6 & obj8;
						bool flag17 = num7 < 0;
						bool flag18 = (nint)obj7 < 0;
						bool flag19 = obj7 == null;
						bool flag20 = flag18 == flag17;
						bool flag21 = !flag19;
						return flag21 & flag20;
					};
					if (_arcanaList == null)
					{
						goto IL_0956;
					}
					bool flag3 = ((SpinningRingOfCards)(object)_arcanaList)._003CInitialize_003Eb__24_1((ArcanaType)predicate2);
					a = (ArcanaType)predicate2;
					spinningRingOfCards = (SpinningRingOfCards)(object)_arcanaList;
				}
				if (amount <= 0)
				{
					goto IL_048e;
				}
				object obj = 0;
				bool isInteractable = default(bool);
				int value = default(int);
				int num = default(int);
				float num2 = default(float);
				int num3 = default(int);
				while (true)
				{
					bool flag4 = spinningRingOfCards._003CInitialize_003Eb__24_1(a);
					bool flag5 = spinningRingOfCards._003CInitialize_003Eb__24_1(a);
					bool flag6 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
					GameObject gameObject = UnityEngine.Object.Instantiate(parent: UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr), original: _ArcanaCard);
					List<ArcanaType> arcanaList = _arcanaList;
					if (_arcanaList == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v140 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
					object obj2 = UnityEngine.Random.RandomRangeInt(0, 0);
					List<ArcanaType> arcanaList2 = _arcanaList;
					if (_arcanaList == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rcx_v124 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
					bool flag7 = (nint)obj2 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rcx_v124 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rcx_v124 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdx_v55+18]");
					bool flag8 = (nint)obj2 >= 0;
					if (_arcanaData == null)
					{
						break;
					}
					Dictionary<ArcanaType, ArcanaData> arcanaData = _arcanaData;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdx_v55+20+v268 @ rax_v143*4]");
					object data2 = ((Dictionary<System.Int32Enum, object>)(object)arcanaData).get_Item((System.Int32Enum)0);
					if ((object)gameObject == null)
					{
						break;
					}
					ArcanaCardUI component = gameObject.GetComponent<ArcanaCardUI>();
					if ((object)component == null)
					{
						break;
					}
					component.OverrideBackFrameName(_backFrameName);
					if (_ignoreDarkana)
					{
						component._ignoreDarkana = true;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdx_v55+20+v268 @ rax_v143*4]");
					component.SetData((ArcanaData)data2, ArcanaType.T00_KILLER, isOpen: false, isInteractable);
					Transform transform = gameObject.transform;
					bool flag9 = (object)transform == null;
					bool flag10 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
					RectTransform component2 = gameObject.GetComponent<RectTransform>();
					Transform transform2 = base.transform;
					bool flag11 = (object)transform2 == null;
					Vector3 position = transform2.position;
					Transform transform3 = gameObject.transform;
					if ((object)transform3 == null)
					{
						break;
					}
					Vector3 position2 = transform3.position;
					if ((object)component2 == null)
					{
						break;
					}
					component2.up = (Vector3)(&num);
					Transform transform4 = gameObject.transform;
					if ((object)transform4 == null)
					{
						break;
					}
					Vector3 eulerAngles = transform4.eulerAngles;
					transform4.eulerAngles = (Vector3)(&num2);
					spinningRingOfCards = (SpinningRingOfCards)(object)_spawned;
					if (_spawned == null)
					{
						break;
					}
					bool flag12 = ((SpinningRingOfCards)(object)_spawned)._003CInitialize_003Eb__24_1((ArcanaType)gameObject);
					obj++;
					bool flag13 = (nint)obj < amount;
					num2 = num3;
					num = num3;
					a = (ArcanaType)gameObject;
					if (flag13)
					{
						continue;
					}
					goto IL_048e;
				}
			}
		}
		goto IL_0956;
		IL_0855:
		Sequence flushSeq = _flushSeq;
		if (_flushSeq != null && ((Tween)flushSeq)._003Cactive_003Ek__BackingField && !((Tween)flushSeq).creationLocked)
		{
			((Tween)flushSeq).loops = -1;
			if (((ABSSequentiable)flushSeq).tweenType == TweenType.Tweener)
			{
				((Tween)flushSeq).fullDuration = 1f / 0f;
			}
		}
		return;
		IL_0bc0:
		object obj4 = 24;
		TweenCallback tweenCallback;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		Sequence flushSeq2;
		object message;
		if (_flushSeq != null)
		{
			if (((Tween)flushSeq2)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)flushSeq2).creationLocked)
				{
					Sequence sequence = Sequence.DoInsertCallback(_flushSeq, tweenCallback, ((Tween)flushSeq2).duration);
					goto IL_0855;
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
		goto IL_0855;
		IL_0956:
		throw new NullReferenceException();
		IL_0663:
		flushSeq2 = _flushSeq;
		tweenCallback = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1432 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback).method = (nint)__ldftn(SpinningRingOfCards.Flush);
		((Delegate)tweenCallback).m_target = this;
		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1432 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj5 = (nint)0 >> 4;
		object obj6 = obj5 & 1;
		nint num5;
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1432 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num5 = unchecked((nint)6447293664L);
				goto IL_0bc0;
			}
		}
		num5 = ((Delegate)tweenCallback).method_ptr;
		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
		goto IL_0bc0;
		IL_048e:
		if (_spawned != null)
		{
			((List<object>)(object)_spawned).Reverse();
			bool flag14 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
			Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			bool flag15 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value2);
			bool flag16 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.3f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2052 @ rax_v72 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			Sequence flushSeq3 = DOTween.Sequence();
			_flushSeq = flushSeq3;
			Sequence flushSeq4 = _flushSeq;
			object message2;
			if (_flushSeq != null)
			{
				if (((Tween)flushSeq4)._003Cactive_003Ek__BackingField)
				{
					if (!((Tween)flushSeq4).creationLocked)
					{
						float duration2 = ((Tween)flushSeq4).duration + 10f;
						flushSeq4.lastTweenInsertTime = ((Tween)flushSeq4).duration;
						((Tween)flushSeq4).duration = duration2;
						goto IL_0663;
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
			goto IL_0663;
		}
		goto IL_0956;
	}

	private ArcanaType GetRandomArcana()
	{
		//IL_0078: Expected O, but got I4
		//IL_003d: Expected O, but got I
		List<ArcanaType> arcanaList = _arcanaList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj = UnityEngine.Random.RandomRangeInt(0, 0);
		List<ArcanaType> arcanaList2 = _arcanaList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		bool flag = (nint)obj >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v12+20+v63 @ rax_v14*4]");
		return ArcanaType.T00_KILLER;
	}

	private void Flush()
	{
		//IL_0026: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		Sequence sequence = DOTween.Sequence();
		List<GameObject> spawned = _spawned;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj < spawned._size)
			{
				List<GameObject> spawned2 = _spawned;
				if ((nint)obj2 >= spawned2._size)
				{
					break;
				}
				GameObject[] items = spawned2._items;
				ArcanaCardUI component = items[obj2].GetComponent<ArcanaCardUI>();
				component._spinTimes = 1;
				Tween t = component.GenerateFlipTween(0f);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, t, false))
				{
					float num = (float)obj2 * 0.1f;
					float atPosition = num + 0.1f;
					Sequence sequence2 = Sequence.DoInsert(sequence, t, atPosition);
				}
				spawned = _spawned;
				obj2++;
				obj = obj2;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public SpinningRingOfCards()
	{
		//IL_0038: Expected I4, but got I8
		_arcanaIndexMin = -1;
		_arcanaIndexMax = 100;
		_backFrameName = "back";
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
	}

	private bool _003CInitialize_003Eb__24_0(ArcanaType a)
	{
		//IL_000f: Expected O, but got I4
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected I4, but got Unknown
		object obj = a - _arcanaIndexMin;
		int num = (int)a ^ _arcanaIndexMin;
		object obj2 = a ^ obj;
		int num2 = num & obj2;
		bool flag = num2 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 != flag;
	}

	private bool _003CInitialize_003Eb__24_1(ArcanaType a)
	{
		//IL_000f: Expected O, but got I4
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected I4, but got Unknown
		object obj = a - _arcanaIndexMax;
		int num = (int)a ^ _arcanaIndexMax;
		object obj2 = a ^ obj;
		int num2 = num & obj2;
		bool flag = num2 < 0;
		bool flag2 = (nint)obj < 0;
		bool flag3 = obj == null;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		return flag5 & flag4;
	}
}
