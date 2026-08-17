using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.App.Scripts.Framework;

public class PixelFontManager : GameTickable, IInitializable, IDisposable
{
	private sealed class _003CDelayedForce_003Ed__20(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				ForceApply();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private static Material _defaultMaterial;

	private static int _fontSizePropId;

	private static int _alphaCutoffBoostPropId;

	private static readonly ProfilerMarker MarkerOnTextChanged;

	private static List<int> _ignoreOnce;

	private static Dictionary<TextMeshProUGUI, TextCache> _textCache;

	private static bool _dirty;

	private static List<TextMeshProUGUI> _cacheToRemove;

	private static int _tickCount;

	private static PlayerOptions _playerOptions;

	private void Construct(PlayerOptions playerOptions)
	{
		_playerOptions = playerOptions;
	}

	public void Initialize()
	{
		int fontSizePropId = Shader.PropertyToID("_FontSize");
		_fontSizePropId = fontSizePropId;
		Material defaultMaterial = Resources.Load<Material>("VSPixelFont");
		_defaultMaterial = defaultMaterial;
		PlayerOptions.OnInitialized value = TriggerListener;
		_playerOptions.PlayerOptionsInitialized += value;
	}

	public void Dispose()
	{
		TurnOff();
	}

	protected unsafe override void OnTick()
	{
		//IL_0027: Expected I, but got O
		//IL_016c: Expected O, but got Ref
		//IL_0517: Expected I, but got O
		//IL_02e1: Expected O, but got I
		//IL_01b2: Expected O, but got I
		//IL_020c: Expected O, but got I4
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_0239: Expected O, but got I
		//IL_00e2: Expected I, but got O
		//IL_0414: Expected I, but got O
		int tickCount = _tickCount + 1;
		_tickCount = tickCount;
		if (_tickCount <= 60)
		{
			return;
		}
		nint num = (nint)typeof(PixelFontManager);
		if (_textCache != null)
		{
			Dictionary<TextMeshProUGUI, TextCache>.Enumerator enumerator = default(Dictionary<TextMeshProUGUI, TextCache>.Enumerator);
			while (enumerator.MoveNext())
			{
				Component component = null;
				if (_cacheToRemove != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC70");
					Component component2 = null;
					if ((object)component2 == null || ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0)
					{
						continue;
					}
					bool flag = (object)component2 == null;
					nint num2 = (nint)typeof(UnityEngine.Object);
					if (!flag)
					{
						GameObject gameObject = component2.gameObject;
						GameObject gameObject2;
						if ((object)gameObject != null)
						{
							bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0;
							gameObject2 = gameObject;
							if (flag2)
							{
								continue;
							}
						}
						num = (nint)_cacheToRemove;
						bool flag3 = _cacheToRemove == null;
						gameObject2 = gameObject;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BC70");
							gameObject2 = gameObject;
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			num = (nint)(&enumerator);
			if (_cacheToRemove != null)
			{
				List<TextMeshProUGUI>.Enumerator enumerator2 = default(List<TextMeshProUGUI>.Enumerator);
				while (enumerator2.MoveNext())
				{
					object obj = (object)(&enumerator2);
					Dictionary<TextMeshProUGUI, TextCache> textCache = _textCache;
					if (_textCache != null)
					{
						int num3 = _textCache.FindEntry((TextMeshProUGUI)null);
						bool flag4 = num3 < 0;
						object key = null;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rbx_v14 (System.Collections.Generic.Dictionary`2<TMPro.TextMeshProUGUI, VampireSurvivors.App.Scripts.Framework.TextCache>)+18]");
							obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rbx_v14 (System.Collections.Generic.Dictionary`2<TMPro.TextMeshProUGUI, VampireSurvivors.App.Scripts.Framework.TextCache>)+18]");
							if ((nint)0 == 0)
							{
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rcx_v12 (System.Object)+18]");
							if ((nint)num3 < (nint)0)
							{
								object obj2 = num3 * 4;
								object obj3 = num3 + obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rcx_v12 (System.Object)+40+v1353 @ rax_v57*8]");
								UnityEngine.Object.Destroy((UnityEngine.Object)0, 0f);
								bool flag5 = _textCache == null;
								obj = _textCache;
								if (!flag5)
								{
									bool flag6 = _textCache.Remove(null);
									GameObject gameObject2 = null;
									continue;
								}
								throw new NullReferenceException();
							}
						}
						else
						{
							System.ThrowHelper.ThrowKeyNotFoundException(key);
						}
						throw new IndexOutOfRangeException();
					}
					throw new NullReferenceException();
				}
				num = (nint)_cacheToRemove;
				if (_cacheToRemove != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rcx_v8 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.PixelFontManager>)+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rcx_v8 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.PixelFontManager>)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rcx_v8 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.PixelFontManager>)+10]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rcx_v8 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.PixelFontManager>)+18]");
						Array.Clear((Array)num4, 0, 0);
					}
					_tickCount = 0;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private static void TriggerListener()
	{
		PlayerOptions.OnInitialized value = TriggerListener;
		_playerOptions.PlayerOptionsInitialized -= value;
		PlayerOptionsData config = _playerOptions.Config;
		if (!config._003CPixelFont_003Ek__BackingField)
		{
			TurnOff();
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 145 Invalid \"Jump target not found in method: 0x186C51B20\"");
		throw new NullReferenceException();
	}

	public static void SetDirty(bool value)
	{
		_dirty = value;
	}

	public static void TurnOn()
	{
		Action<UnityEngine.Object> action = ON_TEXT_CHANGED;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A50480");
		ClearCache();
		ForceApply();
	}

	public static void TurnOff()
	{
		Action<UnityEngine.Object> rhs = ON_TEXT_CHANGED;
		TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(rhs);
		ClearCache();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 94 Invalid \"Jump target not found in method: 0x186C51D30\"");
		throw new NullReferenceException();
	}

	private static void ForceApply()
	{
		//IL_001c: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		TextMeshProUGUI[] array = UnityEngine.Object.FindObjectsOfType<TextMeshProUGUI>();
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			ON_TEXT_CHANGED(array[obj]);
			obj++;
			obj2 = obj;
		}
	}

	public static void ClearCache()
	{
		//IL_003d: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009c: Expected O, but got I
		Dictionary<TextMeshProUGUI, TextCache> textCache = _textCache;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v1 (System.Collections.Generic.Dictionary`2<TMPro.TextMeshProUGUI, VampireSurvivors.App.Scripts.Framework.TextCache>)+20]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v1 (System.Collections.Generic.Dictionary`2<TMPro.TextMeshProUGUI, VampireSurvivors.App.Scripts.Framework.TextCache>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v1 (System.Collections.Generic.Dictionary`2<TMPro.TextMeshProUGUI, VampireSurvivors.App.Scripts.Framework.TextCache>)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v5+18]");
			Array.Clear((Array)num, 0, 0);
			_ = 0;
			_ = 4294967295L;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v1 (System.Collections.Generic.Dictionary`2<TMPro.TextMeshProUGUI, VampireSurvivors.App.Scripts.Framework.TextCache>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v1 (System.Collections.Generic.Dictionary`2<TMPro.TextMeshProUGUI, VampireSurvivors.App.Scripts.Framework.TextCache>)+20]");
			Array.Clear((Array)num2, 0, 0);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v1 (System.Collections.Generic.Dictionary`2<TMPro.TextMeshProUGUI, VampireSurvivors.App.Scripts.Framework.TextCache>)+2C]");
		_ = (nint)0 + (nint)1;
		List<int> ignoreOnce = _ignoreOnce;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v3 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		if (_dirty)
		{
			_003CDelayedForce_003Ed__20 obj2 = null;
			obj2._003C_003E1__state = 0;
			Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(obj2);
		}
	}

	private static IEnumerator DelayedForce()
	{
		_003CDelayedForce_003Ed__20 obj = null;
		obj._003C_003E1__state = 0;
		return obj;
	}

	private unsafe static void ON_TEXT_CHANGED(UnityEngine.Object obj)
	{
		//IL_0592: Expected I, but got O
		//IL_0058: Expected I, but got O
		//IL_0060: Expected I, but got O
		//IL_0070: Expected O, but got I
		//IL_00a8: Expected O, but got I
		//IL_00ee: Expected F4, but got I
		//IL_00f6: Expected I, but got O
		//IL_01dd: Expected O, but got I
		//IL_01f0: Expected O, but got I4
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_024c: Invalid comparison between F4 and O
		//IL_0175: Expected I, but got O
		//IL_019b: Expected O, but got Ref
		//IL_03b8: Expected O, but got Ref
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected Ref, but got Unknown
		//IL_0349: Expected I8, but got I
		//IL_048e: Expected O, but got I
		//IL_04ee: Expected O, but got I
		//IL_0512: Expected O, but got I
		//IL_051f: Expected I, but got O
		//IL_056f->IL057d: Incompatible stack heights: 2 vs 0
		//IL_0385->IL057d: Incompatible stack heights: 2 vs 0
		//IL_0561->IL057d: Incompatible stack heights: 2 vs 0
		//IL_0537->IL057d: Incompatible stack heights: 2 vs 0
		if ((object)MarkerOnTextChanged != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerOnTextChanged);
		}
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if ((object)obj != null && obj.m_CachedPtr != (IntPtr)0)
		{
			nint num = (nint)typeof(TextMeshProUGUI);
			nint num2 = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rdx_v4 (Il2CppClass<TMPro.TextMeshProUGUI>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ r8_v4 (Il2CppClass<UnityEngine.Object>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rdx_v4 (Il2CppClass<TMPro.TextMeshProUGUI>)+130]");
			bool flag = num3 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ r8_v4 (Il2CppClass<UnityEngine.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v718 @ rax_v22+FFFFFFF8+v511 @ rax_v21*8]");
			bool flag2 = 0 != (nint)typeof(TextMeshProUGUI);
			int instanceID = obj.GetInstanceID();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rcx (UnityEngine.Object)+214]");
			float num4 = 0f;
			nint num5 = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1028 @ rdx_v6 (Il2CppClass<UnityEngine.Object>)+548] (should have been resolved before IL gen)");
			if (obj.m_CachedPtr != (IntPtr)0)
			{
				Dictionary<TextMeshProUGUI, TextCache> textCache = _textCache;
				int num6 = _textCache.FindEntry((TextMeshProUGUI)obj);
				float num8 = default(float);
				UnityEngine.Object obj4;
				float num10 = default(float);
				if (num6 < 0)
				{
					nint num7 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1862 @ r8_v35 (Il2CppClass<UnityEngine.Object>)+6E8] (should have been resolved before IL gen)");
					bool flag3 = ((Dictionary<object, TextCache>)(object)_textCache).TryInsert((object)obj, (TextCache)(&num8), System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					obj4 = obj;
					System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
					float num9 = num10;
					float num11 = num10;
					object obj6 = default(object);
					object obj5 = obj6;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rbx_v6 (System.Collections.Generic.Dictionary`2<TMPro.TextMeshProUGUI, VampireSurvivors.App.Scripts.Framework.TextCache>)+18]");
					object obj7 = 0;
					object obj8 = num6 * 4;
					object obj9 = num6 + obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rcx_v54+30+v1881 @ rax_v77*8]");
					ref byte reference = ref *(byte*)null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rcx (UnityEngine.Object)+214]");
					object obj10 = default(object);
					float num12 = 0f - (float)obj10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj11 = num12 & 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-45f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rcx_v54+30+v1881 @ rax_v77*8]");
						object obj12 = default(object);
						bool flag4 = obj12 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rcx_v54+30+v1881 @ rax_v77*8]");
						ref byte reference2 = ref *(byte*)null;
						if (flag4)
						{
							goto IL_0377;
						}
						if (obj12 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rcx_v54+30+v1881 @ rax_v77*8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v25+10]");
								nint num13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1882 @ xmm0_v6 (System.Byte&)+10]");
								if (num13 == 0)
								{
									ref byte first = ref *(byte*)(obj12 + 20);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rcx_v54+30+v1881 @ rax_v77*8]");
									reference2 = ref *(byte*)((nint)0 + (nint)20);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v25+10]");
									nint num14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v25+10]");
									ulong length = (ulong)(num14 + 0);
									if (System.SpanHelpers.SequenceEqual(ref first, ref reference2, length))
									{
										goto IL_0377;
									}
								}
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BE90");
					float num9 = num4;
					bool flag5 = ((Dictionary<object, TextCache>)(object)_textCache).TryInsert((object)obj, (TextCache)(&num8), System.Collections.Generic.InsertionBehavior.OverwriteExisting);
					obj4 = obj;
					System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
					float num11 = num10;
					object obj13 = default(object);
					object obj5 = obj13;
				}
				if (!_ignoreOnce.Contains(instanceID))
				{
					_ignoreOnce.Add(instanceID);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BE90");
					PlayerOptionsData config = _playerOptions.Config;
					if (!config._003CPixelFont_003Ek__BackingField)
					{
						num4 = 1f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2360 @ rax_v53+10]");
					((Material)0).SetFloatImpl(_fontSizePropId, num4);
					CanvasRenderer canvasRenderer = ((TextMeshProUGUI)obj4).canvasRenderer;
					canvasRenderer.materialCount = 1;
					CanvasRenderer canvasRenderer2 = ((TextMeshProUGUI)obj4).canvasRenderer;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BE90");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v715 @ rax_v63+10]");
					canvasRenderer2.SetMaterial((Material)0, 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BE90");
					UnityEngine.Object obj14 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2397 @ rax_v66+10]");
					((TMP_Text)obj14).fontMaterial = (Material)0;
					nint num15 = (nint)obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2401 @ r9_v5 (Il2CppClass<UnityEngine.Object>)+7D8] (should have been resolved before IL gen)");
					autoScope.Dispose();
				}
				else
				{
					bool flag6 = _ignoreOnce.Remove(instanceID);
					autoScope.Dispose();
				}
			}
			else
			{
				autoScope.Dispose();
			}
		}
		else
		{
			autoScope.Dispose();
		}
		return;
		IL_0377:
		autoScope.Dispose();
	}

	static PixelFontManager()
	{
		//IL_00a9: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("TextUtils.ON_TEXT_CHANGED", 1, MarkerFlags.Default, 0);
		MarkerOnTextChanged = (ProfilerMarker)(nint)intPtr;
		List<int> ignoreOnce = new List<int>();
		_ignoreOnce = ignoreOnce;
		Dictionary<TextMeshProUGUI, TextCache> textCache = null;
		EqualityComparer<object> equalityComparer = EqualityComparer<object>.Default;
		if (equalityComparer != null)
		{
			_ = 0;
		}
		_textCache = textCache;
		_dirty = false;
		List<TextMeshProUGUI> cacheToRemove = new List<TextMeshProUGUI>();
		_cacheToRemove = cacheToRemove;
		_tickCount = 0;
	}
}
