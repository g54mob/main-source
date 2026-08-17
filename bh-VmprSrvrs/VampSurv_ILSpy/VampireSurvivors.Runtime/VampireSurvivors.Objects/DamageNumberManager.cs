using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects;

public class DamageNumberManager : MonoBehaviour
{
	private List<Sprite> _numberSprites;

	private int _MaxAmount;

	private int SpawnSpam;

	private Blitter _blitter;

	private bool _blittersMade;

	private List<float> RANDOMS;

	private List<float> RANDOMSY;

	private int INDEX;

	private List<Bob> _bobs;

	private List<BobGroup> _groups;

	private GameSessionData _session;

	private SignalBus _signalBus;

	private Bounds _bobMaxBounds;

	private Color32 _white;

	public int Count;

	public Color32 ColorMax;

	public Color32 Color010;

	public Color32 Color006;

	public Color32 Color003;

	public Color32 Color000;

	public Color32 ColorNeg;

	private ProfilerMarker updateBobMarker;

	private ProfilerMarker deleteBobsMarker;

	private static int[] digitsArray;

	private void Construct(GameSessionData session, SignalBus signalBus)
	{
		_session = session;
		_signalBus = signalBus;
	}

	private void Awake()
	{
		//IL_01df: Expected O, but got I8
		//IL_01ee: Expected O, but got I8
		//IL_01fd: Expected O, but got I8
		//IL_020c: Expected O, but got I8
		//IL_021b: Expected O, but got I8
		//IL_022a: Expected O, but got I8
		//IL_0036: Expected O, but got I4
		//IL_0243: Expected O, but got F4
		//IL_0073: Expected O, but got I
		//IL_0083: Expected O, but got I
		//IL_00e4: Expected O, but got I
		//IL_028b: Expected O, but got F4
		//IL_012b: Expected O, but got I
		//IL_01bc: Expected O, but got I
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		List<float> rANDOMS = RANDOMS;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)0 == 0)
		{
			object obj = 0;
			DamageNumberManager damageNumberManager = this;
			float num2 = default(float);
			do
			{
				List<float> rANDOMS2 = RANDOMS;
				object obj2 = UnityEngine.Random.value;
				float num = num2 - 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
				List<float> list = (List<float>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v9+18]");
				if (num3 >= 0)
				{
					rANDOMS2.AddWithResize(num);
					list = rANDOMS2;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj4 = (nint)0 + (nint)1;
				}
				List<float> rANDOMSY = RANDOMSY;
				object obj5 = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rbx_v9 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rbx_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rbx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				damageNumberManager = (DamageNumberManager)0;
				float num5 = num * 12f;
				float num6 = num5 * 0.01f;
				num2 = num6 + 0.1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rbx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v10 (Il2CppMethodInfo)+18]");
				if (num7 >= 0)
				{
					rANDOMSY.AddWithResize(num2);
					damageNumberManager = (DamageNumberManager)(object)rANDOMSY;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rbx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj6 = (nint)0 + (nint)1;
				}
				obj++;
			}
			while ((nint)obj < 500);
		}
		ColorMax = (Color32)4294954188L;
		Color010 = (Color32)4278255615L;
		Color006 = (Color32)4286618111L;
		Color003 = (Color32)4282404095L;
		Color000 = (Color32)4294967295L;
		ColorNeg = (Color32)4278255360L;
	}

	private void Start()
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_01cb: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_0145: Expected O, but got I
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0204: Expected O, but got I
		MakeBlitters();
		GameManager.DamageNumberManager = this;
		Action<UISignals.CreateDamageNumberSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2210");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.CreateDamageNumberSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.CreateDamageNumberSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rax_v17 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action<UISignals.CreateSpecialDamageNumberSignal> action3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA22F0");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.CreateSpecialDamageNumberSignal>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.CreateSpecialDamageNumberSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v32 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Bounds bobMaxBounds = default(Bounds);
		_bobMaxBounds = bobMaxBounds;
	}

	private void OnDestroy()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		GameManager.DamageNumberManager = null;
		Action<UISignals.CreateDamageNumberSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2210");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action<UISignals.CreateSpecialDamageNumberSignal> token2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA22F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
	}

	private void LateUpdate()
	{
		//IL_00d4: Expected O, but got I
		//IL_0252: Expected O, but got I
		//IL_046d: Expected F4, but got I4
		//IL_028c: Expected O, but got I
		//IL_02c8: Expected O, but got I
		//IL_02d9: Expected O, but got I
		//IL_041c->IL0338: Incompatible stack heights: 1 vs 0
		//IL_023d->IL0338: Incompatible stack heights: 1 vs 0
		//IL_0272->IL0338: Incompatible stack heights: 1 vs 0
		//IL_0494->IL0499: Incompatible stack heights: 2 vs 0
		//IL_0499->IL010d: Incompatible stack heights: 2 vs 0
		//IL_04f7->IL0338: Incompatible stack heights: 1 vs 0
		//IL_0338->IL01a6: Incompatible stack heights: 1 vs 0
		//IL_02f8->IL0338: Incompatible stack heights: 1 vs 0
		if (!_blittersMade)
		{
			return;
		}
		GameSessionData session = _session;
		if (_session != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = session._activeCharacter;
			if ((object)session._activeCharacter == null || ((UnityEngine.Object)activeCharacter).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			if (Count >= _MaxAmount || SpawnSpam <= 0)
			{
				goto IL_010d;
			}
			int num = 0;
			Vector3 worldPos = default(Vector3);
			float growth = default(float);
			while (true)
			{
				int num2 = UnityEngine.Random.RandomRangeInt(0, 992);
				object session2 = _session;
				if (_session == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rsi_v17 (System.Object)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rsi_v17 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rsi_v18 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rsi_v18 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				if ((object)transform == null)
				{
					break;
				}
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				AddBob(_blitter, num2, num2, worldPos, growth);
				num++;
				if (num >= SpawnSpam)
				{
					goto IL_010d;
				}
			}
		}
		goto IL_0338;
		IL_010d:
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
			{
				Bounds bobMaxBounds = default(Bounds);
				_bobMaxBounds = bobMaxBounds;
				_ = 0;
				float deltaTime = PauseSystem.DeltaTime;
				List<BobGroup> groups = _groups;
				bool flag3 = _groups == null;
				int num3 = 0;
				int num4 = 0;
				if (!flag3)
				{
					while (true)
					{
						if (num4 >= groups._size)
						{
							return;
						}
						List<BobGroup> groups2 = _groups;
						if (_groups == null)
						{
							break;
						}
						bool flag4 = num3 >= groups2._size;
						object items = groups2._items;
						if (groups2._items == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rsi_v14 (System.Object)+20+v270 @ rdi_v14 (System.Int32)*8]");
						BobGroup bobGroup = (BobGroup)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rsi_v14 (System.Object)+20+v270 @ rdi_v14 (System.Int32)*8]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rsi_v14 (System.Object)+20+v270 @ rdi_v14 (System.Int32)*8]");
						((BobGroup)0).Update(deltaTime);
						if (bobGroup.tweenState == BobGroup.TweenState.Completed)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rsi_v14 (System.Object)+20+v270 @ rdi_v14 (System.Int32)*8]");
							((BobGroup)0).RemoveBobs(_blitter);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rsi_v14 (System.Object)+20+v270 @ rdi_v14 (System.Int32)*8]");
							((BobGroup)0).Dispose();
							if (_groups == null)
							{
								break;
							}
							_groups.RemoveAt(num3);
							int count = Count - 1;
							Count = count;
						}
						groups = _groups;
						num3++;
						if (_groups == null)
						{
							break;
						}
						num4 = num3;
					}
				}
			}
		}
		goto IL_0338;
		IL_0338:
		throw new NullReferenceException();
	}

	private void MakeBlitters()
	{
		//IL_0079->IL0166: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL0166: Incompatible stack heights: 1 vs 0
		//IL_0128->IL0166: Incompatible stack heights: 1 vs 0
		//IL_0157->IL0166: Incompatible stack heights: 1 vs 0
		//IL_01e2->IL01e2: Incompatible stack heights: 2 vs 0
		if (_blittersMade)
		{
			return;
		}
		List<Sprite> numberSprites = _numberSprites;
		if (_numberSprites != null)
		{
			bool flag = numberSprites._size <= 0;
			Sprite[] items = numberSprites._items;
			if (numberSprites._items != null)
			{
				if (items.Length <= 0)
				{
					throw new IndexOutOfRangeException();
				}
				if ((object)items[0] != null)
				{
					Texture2D texture = items[0].texture;
					Blitter blitter = Blitter.CreateBlitter(BlendMode.Normal, texture);
					_blitter = blitter;
					Blitter blitter2 = _blitter;
					if ((object)_blitter != null)
					{
						object meshRenderer = blitter2._meshRenderer;
						if ((object)blitter2._meshRenderer != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdi_v9 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdi_v9 (System.Object)+10]");
							Renderer.set_sortingOrder_Injected((IntPtr)0, 22767);
							_blittersMade = true;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Spawn(UISignals.CreateDamageNumberSignal sig)
	{
		//IL_0034: Expected F4, but got I4
		int damageValue = GetDamageValue(sig.Damage);
		Vector3 worldPos = default(Vector3);
		float growth = default(float);
		AddBob(_blitter, damageValue, sig.Damage, worldPos, growth);
	}

	private unsafe void AddBob(Blitter blitter, int num, float rawDamage, Vector3 worldPos, float growth = 2f)
	{
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_035e: Expected O, but got I4
		//IL_0055: Invalid comparison between I4 and F4
		//IL_0145: Invalid comparison between F4 and I4
		//IL_0190: Invalid comparison between F4 and I4
		//IL_00e8: Invalid comparison between F4 and I4
		//IL_00f7: Invalid comparison between I4 and F4
		//IL_03b4: Expected O, but got I4
		//IL_030e: Expected O, but got F4
		//IL_0257: Expected O, but got F4
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		//IL_02ed->IL01d1: Incompatible stack heights: 1 vs 0
		//IL_02f2->IL02f2: Incompatible stack heights: 1 vs 0
		Blitter blitter2 = _blitter;
		List<Bob> bobs = blitter2._bobs;
		if (bobs._size > 16000)
		{
			return;
		}
		object obj = this + 120;
		Vector3 point = default(Vector3);
		object obj2 = Bounds.Contains_Injected(ref *(Bounds*)obj, ref point);
		if (obj2 == null)
		{
			return;
		}
		BobGroup bobGroup = BobGroup.Create();
		bool flag = !(0f > rawDamage);
		int number = num;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm6\"");
			number = -num;
		}
		int[] array = SplitIntByDigitsReversed(number, out var numDigits);
		bobGroup._intCount = numDigits;
		bool flag2;
		if (rawDamage < 3f)
		{
			float num2 = 0f - rawDamage;
			flag2 = num2 < 0f;
			if (0f > rawDamage)
			{
				Color32 colorNeg = ColorNeg;
			}
			else
			{
				Color32 colorNeg = Color000;
			}
		}
		else
		{
			float num3 = rawDamage - 10f;
			flag2 = num3 < 0f;
			if (!(rawDamage < 10f))
			{
				Color32 colorNeg = Color010;
			}
			else
			{
				float num4 = rawDamage - 6f;
				flag2 = num4 < 0f;
				if (!(rawDamage < 6f))
				{
					Color32 colorNeg = Color006;
				}
				else
				{
					Color32 colorNeg = Color003;
				}
			}
		}
		float num5 = UnityEngine.Random.Range(-0.15f, 0.15f);
		float num6 = UnityEngine.Random.Range(0f, 0.3f);
		object obj3 = numDigits - 1;
		Sprite sprite = null;
		float num8 = default(float);
		if (!flag2)
		{
			bool flag4;
			do
			{
				List<Sprite> numberSprites = _numberSprites;
				int num7 = array[obj3];
				bool flag3 = array[obj3] >= numberSprites._size;
				Sprite[] items = numberSprites._items;
				sprite = items[num7];
				Bob bob = blitter.CreateBob((Vector2)num8, items[num7]);
				BobVertexData[] vertexData = bob.vertexData;
				BobVertexData[] vertexData2 = bob.vertexData;
				BobVertexData[] vertexData3 = bob.vertexData;
				BobVertexData[] vertexData4 = bob.vertexData;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA20D0");
				obj3--;
				flag4 = (nint)bobGroup._bobs >= 0;
				num6 = num8;
			}
			while (flag4);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA23D0");
		bobGroup.Start((Vector2)num8);
		int count = Count + 1;
		Count = count;
	}

	private unsafe void AddBobSpecial(UISignals.CreateSpecialDamageNumberSignal sig)
	{
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_0333: Expected O, but got I4
		//IL_00e8: Expected O, but got I
		//IL_014c: Expected O, but got F4
		//IL_018f: Expected F4, but got I4
		//IL_038e: Expected O, but got I4
		//IL_02e3: Expected O, but got F4
		//IL_0228: Expected O, but got F4
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_02be->IL01a0: Incompatible stack heights: 1 vs 0
		//IL_02c3->IL02c3: Incompatible stack heights: 1 vs 0
		Blitter blitter = _blitter;
		List<Bob> bobs = blitter._bobs;
		if (bobs._size > 16000)
		{
			return;
		}
		object obj = this + 120;
		Vector3 point = default(Vector3);
		object obj2 = Bounds.Contains_Injected(ref *(Bounds*)obj, ref point);
		if (obj2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sig @ rdx (VampireSurvivors.Signals.UISignals+CreateSpecialDamageNumberSignal)+8]");
		int num = (int)((nint)0 >> 32);
		int number;
		if (sig.Randomize)
		{
			int damageValue = GetDamageValue(num);
			number = damageValue;
		}
		else
		{
			bool flag = num > 1;
			number = num;
			if (!flag)
			{
				number = 1;
			}
		}
		BobGroup bobGroup = BobGroup.Create();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sig @ rdx (VampireSurvivors.Signals.UISignals+CreateSpecialDamageNumberSignal)+8]");
		object obj3 = (nint)0 >> 32;
		if ((nint)obj3 < 0)
		{
			number = -num;
		}
		int[] array = SplitIntByDigitsReversed(number, out var numDigits);
		bobGroup._intCount = numDigits;
		object obj4 = sig.Size >> 32;
		bool flag2 = (nint)obj4 < 0;
		if (obj4 != null)
		{
			Color32 color2 = default(Color32);
			Color32 color = color2;
		}
		else
		{
			Color32 damageColour = GetDamageColour(num);
			Color32 color = damageColour;
		}
		float num2 = UnityEngine.Random.Range(-0.15f, 0.15f);
		float num3 = UnityEngine.Random.Range(0f, 0.3f);
		object obj5 = numDigits - 1;
		Sprite sprite = null;
		float num5 = default(float);
		if (!flag2)
		{
			bool flag4;
			do
			{
				List<Sprite> numberSprites = _numberSprites;
				int num4 = array[obj5];
				bool flag3 = array[obj5] >= numberSprites._size;
				Sprite[] items = numberSprites._items;
				sprite = items[num4];
				Bob bob = _blitter.CreateBob((Vector2)num5, items[num4]);
				BobVertexData[] vertexData = bob.vertexData;
				BobVertexData[] vertexData2 = bob.vertexData;
				BobVertexData[] vertexData3 = bob.vertexData;
				BobVertexData[] vertexData4 = bob.vertexData;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA20D0");
				obj5--;
				flag4 = (nint)bobGroup._bobs >= 0;
				num3 = num5;
			}
			while (flag4);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA23D0");
		bobGroup.Start((Vector2)num5, sig.Size);
		int count = Count + 1;
		Count = count;
	}

	public unsafe void AddBob_Number1(Vector3 worldPos)
	{
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_01c2: Expected O, but got I4
		//IL_0196->IL01a5: Incompatible stack heights: 1 vs 0
		Blitter blitter = _blitter;
		List<Bob> bobs = blitter._bobs;
		if (bobs._size <= 16000)
		{
			object obj = this + 120;
			float point = default(float);
			object obj2 = Bounds.Contains_Injected(ref *(Bounds*)obj, ref *(Vector3*)(&point));
			if (obj2 != null)
			{
				BobGroup bobGroup = BobGroup.Create();
				bobGroup._intCount = 1;
				float num = UnityEngine.Random.Range(-0.15f, 0.15f);
				float num2 = UnityEngine.Random.Range(0f, 0.3f);
				List<Sprite> numberSprites = _numberSprites;
				bool flag = numberSprites._size <= 1;
				Sprite[] items = numberSprites._items;
				Vector2 vector = default(Vector2);
				Bob bob = _blitter.CreateBob(vector, items[1]);
				BobVertexData[] vertexData = bob.vertexData;
				_ = Color000;
				BobVertexData[] vertexData2 = bob.vertexData;
				_ = Color000;
				BobVertexData[] vertexData3 = bob.vertexData;
				_ = Color000;
				BobVertexData[] vertexData4 = bob.vertexData;
				_ = Color000;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA20D0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA23D0");
				bobGroup.Start(vector, 1f);
				int count = Count + 1;
				Count = count;
			}
		}
	}

	private unsafe static int[] SplitIntByDigitsReversed(int number, out int numDigits)
	{
		//IL_0180: Expected O, but got I4
		//IL_0051: Expected O, but got I
		//IL_005e: Expected O, but got Ref
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0093: Expected I4, but got O
		ref int reference = ref *(int*)null;
		bool flag = number <= 0;
		ref int reference2 = ref numDigits;
		int num = number;
		if (flag)
		{
			goto IL_01a5;
		}
		object obj6 = default(object);
		while (true)
		{
			int[] array = digitsArray;
			object obj = numDigits + 1;
			reference = ref *(int*)obj;
			if (numDigits >= array.Length)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mul edi\"");
			reference2 = ref *(int*)((nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference2) >> 3);
			object obj2 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference2) * (nint)4;
			object obj3 = (ref System.Runtime.CompilerServices.Unsafe.As<int, _003F>(ref reference2)) + (ref *(_003F*)obj2);
			object obj4 = obj3 + obj3;
			object obj5 = num - obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mul edi\"");
			array[obj6] = (int)obj5;
			num = (int)((nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference2) >> 3);
			if (num <= 0)
			{
				goto IL_00be;
			}
		}
		goto IL_018d;
		IL_018d:
		return (int[])(object)new IndexOutOfRangeException();
		IL_01b3:
		return digitsArray;
		IL_00be:
		if (numDigits == 0)
		{
			goto IL_01a5;
		}
		goto IL_01b3;
		IL_01a5:
		int[] array2 = digitsArray;
		if (array2.Length <= 0)
		{
			goto IL_018d;
		}
		array2[0] = 0;
		reference = ref *(int*)1;
		goto IL_01b3;
	}

	private Color32 GetDamageColour(float rawDamage)
	{
		//IL_0029: Invalid comparison between I4 and F4
		if (rawDamage < 3f)
		{
			if (0f > rawDamage)
			{
				return ColorNeg;
			}
			return Color000;
		}
		if (!(rawDamage < 10f))
		{
			return Color010;
		}
		if (!(rawDamage < 6f))
		{
			return Color006;
		}
		return Color003;
	}

	private int GetDamageValue(int rawDamage)
	{
		//IL_0038: Expected O, but got I4
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		List<float> rANDOMS = RANDOMS;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		int num = rawDamage >> 5;
		int num2 = num >> 31;
		object obj = num + num2;
		object obj2 = obj * 500;
		object obj3 = INDEX - obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)obj3 < 0)
		{
			int iNDEX = INDEX + 1;
			INDEX = iNDEX;
			bool flag = rawDamage <= 1;
			int result = 1;
			if (!flag)
			{
				result = rawDamage;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			return result;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result2 = default(int);
		return result2;
	}

	public DamageNumberManager()
	{
		//IL_00a2: Expected O, but got I8
		//IL_00c9: Expected O, but got I
		//IL_00f5: Expected O, but got I
		List<Sprite> numberSprites = new List<Sprite>();
		_numberSprites = numberSprites;
		_MaxAmount = 1000;
		SpawnSpam = 10;
		List<float> rANDOMS = new List<float>();
		RANDOMS = rANDOMS;
		List<float> rANDOMSY = new List<float>();
		RANDOMSY = rANDOMSY;
		List<Bob> bobs = new List<Bob>();
		_bobs = bobs;
		List<BobGroup> groups = new List<BobGroup>();
		_groups = groups;
		_white = (Color32)4294967295L;
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("UpdateGroup", 1, MarkerFlags.Default, 0);
		updateBobMarker = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("DeleteBobs", 1, MarkerFlags.Default, 0);
		deleteBobsMarker = (ProfilerMarker)(nint)intPtr2;
	}

	static DamageNumberManager()
	{
		int[] array = new int[16];
		digitsArray = array;
	}
}
