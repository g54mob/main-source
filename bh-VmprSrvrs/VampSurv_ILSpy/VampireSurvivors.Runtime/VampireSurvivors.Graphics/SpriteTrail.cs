using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;

namespace VampireSurvivors.Graphics;

public class SpriteTrail : GameMonoBehaviour
{
	public SpriteRenderer _MainSprite;

	private int _MaxHistory;

	private List<string> _Tints;

	public float _DefaultGhostAlpha;

	public float _AlphaDecayPerGhost;

	private Vector2 _ScaleModifier;

	private Material _MaterialOverride;

	private bool _MatchTargetAngle;

	private bool _UsePauseSystem;

	private bool _AutoUpdateDepth;

	public static GameObject TrailContainer;

	private List<Vector3> _positionHistory;

	private List<Vector3> _angleHistory;

	private List<Vector3> _scaleHistory;

	private List<SpriteRenderer> _ghosts;

	private int _historyIndex;

	private bool _skipOne;

	private int _knownHistory;

	private static int _fps;

	private static double _frameTime;

	private double _frameTimeMS;

	private double _elapsed;

	private static ProfilerMarker _markerOnEnableBase;

	private static ProfilerMarker _markerOnEnableGhosts;

	private static ProfilerMarker _markerOnDisableBase;

	private static ProfilerMarker _markerOnDisableGhosts;

	public bool AutoUpdateDepth
	{
		get
		{
			return _AutoUpdateDepth;
		}
		set
		{
			_AutoUpdateDepth = value;
		}
	}

	protected override void OnEnable()
	{
		//IL_00e6->IL011e: Incompatible stack heights: 4 vs 0
		base.OnEnable();
		List<SpriteRenderer>.Enumerator enumerator = default(List<SpriteRenderer>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rsi_v11 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rsi_v11 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
			GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			bool flag2 = (object)gameObject == null;
			bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rsi_v11 (System.Object)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rsi_v11 (System.Object)+10]");
			Renderer.set_enabled_Injected((IntPtr)0, false);
		}
		_knownHistory = 0;
		_historyIndex = 0;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		List<SpriteRenderer>.Enumerator enumerator = default(List<SpriteRenderer>.Enumerator);
		while (enumerator.MoveNext())
		{
			Component component = null;
		}
	}

	protected override void OnDestroy()
	{
		List<SpriteRenderer> ghosts = _ghosts;
		int version = ghosts._version + 1;
		ghosts._version = version;
		ghosts._size = 0;
		if (ghosts._size > 0)
		{
			Array.Clear(ghosts._items, 0, ghosts._size);
		}
		List<Vector3> positionHistory = _positionHistory;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<Vector3> angleHistory = _angleHistory;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<Vector3> scaleHistory = _scaleHistory;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v7 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
	}

	public void Start()
	{
		GameObject trailContainer = TrailContainer;
		if ((object)TrailContainer == null || ((UnityEngine.Object)trailContainer).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, (string)null);
			TrailContainer = gameObject;
			((UnityEngine.Object)TrailContainer).SetName("SpriteTrails");
		}
		InitialiseGhosts();
		_knownHistory = 0;
		_historyIndex = 0;
	}

	private void ResetHistory()
	{
		_knownHistory = 0;
		_historyIndex = 0;
	}

	public int GetMaxHistory()
	{
		return _MaxHistory;
	}

	public void SetMaxHistory(int max)
	{
		_MaxHistory = max;
		InitialiseGhosts(expandExisting: true);
	}

	public void SetMaskInteraction(SpriteMaskInteraction interaction)
	{
		//IL_005b->IL005b: Incompatible stack heights: 1 vs 0
		List<SpriteRenderer>.Enumerator enumerator = default(List<SpriteRenderer>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v5 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v5 (System.Object)+10]");
			SpriteRenderer.set_maskInteraction_Injected((IntPtr)0, interaction);
		}
	}

	public unsafe void InitialiseGhosts(bool expandExisting = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00ee: Expected O, but got Ref
		//IL_0177: Expected O, but got Ref
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_0229: Expected O, but got Ref
		//IL_03b3: Expected O, but got I
		//IL_03e6: Expected O, but got I4
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Expected O, but got Unknown
		//IL_07ea: Expected O, but got Ref
		//IL_044f: Expected O, but got I
		//IL_0482: Expected O, but got I4
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Expected O, but got Unknown
		//IL_04ba: Expected O, but got Ref
		//IL_054f: Expected O, but got I
		//IL_0582: Expected O, but got I4
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Expected O, but got Unknown
		//IL_0844: Expected O, but got Ref
		//IL_063f: Expected O, but got I4
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Expected I4, but got Unknown
		//IL_0691: Expected I, but got O
		//IL_06b3: Expected I, but got O
		//IL_088d: Expected O, but got I4
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_089b: Expected O, but got Unknown
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08aa: Expected O, but got Unknown
		//IL_08fe: Expected O, but got Ref
		//IL_0915: Expected I, but got O
		//IL_03d3->IL078b: Incompatible stack heights: 1 vs 0
		//IL_046f->IL078b: Incompatible stack heights: 3 vs 0
		//IL_04a7->IL078b: Incompatible stack heights: 3 vs 0
		//IL_0517->IL078b: Incompatible stack heights: 3 vs 0
		//IL_056f->IL078b: Incompatible stack heights: 4 vs 0
		//IL_06d2->IL078b: Incompatible stack heights: 9 vs 0
		//IL_0705->IL078b: Incompatible stack heights: 9 vs 0
		//IL_08d2->IL075e: Incompatible stack heights: 9 vs 0
		//IL_091a->IL087e: Incompatible stack heights: 10 vs 9
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = default(bool);
		if (!flag)
		{
			List<SpriteRenderer> ghosts = _ghosts;
			if (_ghosts == null)
			{
				goto IL_078b;
			}
			if (ghosts._size > 0)
			{
				return;
			}
		}
		if (_MaxHistory <= 0)
		{
			return;
		}
		int num = 0;
		object obj4 = default(object);
		string hex = default(string);
		while (true)
		{
			List<Vector3> positionHistory = _positionHistory;
			if (_positionHistory == null)
			{
				break;
			}
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v30 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			if ((nint)num2 >= (nint)0)
			{
				Transform transform = base.transform;
				if ((object)transform == null)
				{
					break;
				}
				Vector3 position = transform.position;
				Vector3 item = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				_ = position.x;
				_ = position.z;
				_positionHistory.Add(item);
				Transform transform2 = base.transform;
				if ((object)transform2 == null)
				{
					break;
				}
				Vector3 eulerAngles = transform2.eulerAngles;
				if (_angleHistory == null)
				{
					break;
				}
				Vector3 item2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
				_ = eulerAngles.x;
				_ = eulerAngles.z;
				_angleHistory.Add(item2);
				Transform transform3 = base.transform;
				if ((object)transform3 == null)
				{
					break;
				}
				Vector3 lossyScale = transform3.lossyScale;
				_ = lossyScale.z;
				_ = lossyScale.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rcx_v1 (VampireSurvivors.Graphics.SpriteTrail)+4C]");
				object obj3 = obj4 * 0;
				if (_scaleHistory == null)
				{
					break;
				}
				Vector3 item3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				_ = 0;
				_scaleHistory.Add(item3);
				GameObject gameObject = new GameObject();
				Transform transform4 = base.transform;
				if ((object)transform4 == null)
				{
					break;
				}
				Transform parent = transform4.parent;
				if ((object)parent == null)
				{
					break;
				}
				string text = ((UnityEngine.Object)parent).GetName();
				string text2 = "Trail - " + text;
				if ((object)gameObject == null)
				{
					break;
				}
				((UnityEngine.Object)gameObject).SetName(text2);
				Transform transform5 = gameObject.transform;
				if ((object)TrailContainer == null)
				{
					break;
				}
				Transform parent2 = TrailContainer.transform;
				if ((object)transform5 == null)
				{
					break;
				}
				transform5.parent = parent2;
				Transform transform6 = gameObject.transform;
				List<Vector3> positionHistory2 = _positionHistory;
				if (_positionHistory == null)
				{
					break;
				}
				int num3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v49 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				bool flag2 = (nint)num3 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v49 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v49 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj6 = num * 2;
				object obj7 = num + obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v50+20+v1064 @ rax_v57*4]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v50+28+v1064 @ rax_v57*4]");
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Transform.set_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj8);
				Transform transform7 = gameObject.transform;
				List<Vector3> angleHistory = _angleHistory;
				int num4 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1066 @ rcx_v55 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				bool flag4 = (nint)num4 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1066 @ rcx_v55 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1066 @ rcx_v55 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj10 = num * 2;
				object obj11 = num + obj10;
				if ((object)transform7 == null)
				{
					break;
				}
				Vector3 eulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v56+20+v217 @ rax_v65*4]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v56+28+v217 @ rax_v65*4]");
				_ = 0;
				transform7.eulerAngles = eulerAngles2;
				Transform transform8 = gameObject.transform;
				List<Vector3> scaleHistory = _scaleHistory;
				if (_scaleHistory == null)
				{
					break;
				}
				int num5 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v59 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				bool flag5 = (nint)num5 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v59 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v59 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj13 = num * 2;
				object obj14 = num + obj13;
				bool flag6 = (object)transform8 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v60+20+v927 @ rax_v70*4]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v60+28+v927 @ rax_v70*4]");
				_ = 0;
				bool flag7 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
				object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Transform.set_localScale_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref *(Vector3*)obj15);
				SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
				bool flag8 = (object)_MainSprite == null;
				Sprite sprite = _MainSprite.sprite;
				bool flag9 = (object)spriteRenderer == null;
				spriteRenderer.sprite = sprite;
				bool flag10 = (object)_MainSprite == null;
				int sortingOrder = _MainSprite.sortingOrder;
				object obj16 = sortingOrder - _MaxHistory;
				int sortingOrder2 = num + obj16;
				spriteRenderer.sortingOrder = sortingOrder2;
				spriteRenderer.enabled = false;
				bool flag11 = _MaterialOverride;
				bool flag12 = !flag11;
				nint num6 = unchecked((nint)null);
				if (!flag12)
				{
					((Renderer)spriteRenderer).SetMaterial(_MaterialOverride);
					num6 = unchecked((nint)null);
				}
				if (_ghosts == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
				List<string> tints = _Tints;
				if (_Tints == null)
				{
					break;
				}
				if (num < tints._size)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					_ = ColourHelper.HexToColor(hex).r;
					bool flag13 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
					object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref *(Color*)obj17);
					num6 = unchecked((nint)null);
				}
				object obj18 = _MaxHistory - num;
				object obj19 = obj18 - 1;
				object obj20 = obj19 * _AlphaDecayPerGhost;
				float a = _DefaultGhostAlpha - (float)obj20;
				SpriteTrail spriteTrail = SetAlpha(num, a);
			}
			num++;
			if (num >= _MaxHistory)
			{
				return;
			}
		}
		goto IL_078b;
		IL_078b:
		throw new NullReferenceException();
	}

	public void ResetGhostValues()
	{
		//IL_00ce: Expected O, but got I4
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		List<Vector3> positionHistory = _positionHistory;
		_MaxHistory = 3;
		_DefaultGhostAlpha = 0.65f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rbx_v1 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		int num = (int)(-1);
		if (num <= 0)
		{
			return;
		}
		Component component = default(Component);
		do
		{
			if (num >= _MaxHistory)
			{
				((List<SpriteRenderer>)(object)_positionHistory).RemoveAt(num);
				((List<SpriteRenderer>)(object)_angleHistory).RemoveAt(num);
				((List<SpriteRenderer>)(object)_scaleHistory).RemoveAt(num);
				_ghosts.RemoveAt(num);
				GameObject obj = component.gameObject;
				UnityEngine.Object.Destroy(obj);
				_ghosts.RemoveAt(num);
			}
			else
			{
				object obj2 = _MaxHistory - num;
				object obj3 = obj2 - 1;
				object obj4 = obj3 * _AlphaDecayPerGhost;
				float a = _DefaultGhostAlpha - (float)obj4;
				SpriteTrail spriteTrail = SetAlpha(num, a);
			}
			num--;
		}
		while (num > 0);
	}

	private unsafe void LateUpdate()
	{
		//IL_000e: Expected O, but got I
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_09b1: Expected O, but got F4
		//IL_0a02: Expected O, but got I4
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Expected O, but got Unknown
		//IL_00e4: Expected O, but got I4
		//IL_0c12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c17: Expected O, but got Unknown
		//IL_0743: Expected O, but got I
		//IL_077d: Expected O, but got I4
		//IL_0787: Unknown result type (might be due to invalid IL or missing references)
		//IL_078c: Expected O, but got Unknown
		//IL_01f0: Expected O, but got I
		//IL_0226: Expected O, but got I4
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_0aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aef: Expected O, but got Unknown
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca2: Expected O, but got Unknown
		//IL_0cc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc5: Expected O, but got Unknown
		//IL_080c: Expected O, but got I
		//IL_03d0: Expected O, but got I
		//IL_0846: Expected O, but got I4
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_0855: Expected O, but got Unknown
		//IL_0406: Expected O, but got I4
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected O, but got Unknown
		//IL_0311: Expected O, but got I
		//IL_0347: Expected O, but got I4
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_04e5: Expected O, but got I
		//IL_051b: Expected O, but got I4
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Expected O, but got Unknown
		//IL_0d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5b: Expected O, but got Unknown
		//IL_08cf: Expected O, but got I
		//IL_0b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b61: Expected O, but got Unknown
		//IL_0909: Expected O, but got I4
		//IL_0913: Unknown result type (might be due to invalid IL or missing references)
		//IL_0918: Expected O, but got Unknown
		//IL_060e: Expected O, but got I4
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Expected I4, but got Unknown
		//IL_068a: Expected O, but got I4
		//IL_068f: Expected I, but got O
		//IL_06b3: Expected O, but got I4
		//IL_0380->IL0d76: Incompatible stack heights: 9 vs 7
		//IL_096a->IL0d75: Incompatible stack heights: 12 vs 0
		//IL_097a->IL0d75: Incompatible stack heights: 12 vs 0
		//IL_06eb->IL0b91: Incompatible stack heights: 16 vs 0
		//IL_06f0->IL06f0: Incompatible stack heights: 16 vs 0
		if (_MaxHistory <= 0)
		{
			return;
		}
		object obj = (nint)0 ^ (nint)0;
		object obj2 = 0 & obj;
		bool flag = (nint)obj2 < 0;
		bool flag2 = (nint)0 < (nint)0;
		bool flag3 = (nint)0 == 0;
		object obj3 = Time.deltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [188A109F8h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		_elapsed = 0.0;
		bool flag4 = flag2 == flag;
		object obj4 = !flag3;
		object obj5 = flag4 & obj4;
		if (obj5 != null)
		{
			return;
		}
		bool flag5 = !_UsePauseSystem;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,xmm0\"");
		_elapsed = 0.0;
		if (!flag5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B91540");
			object obj6 = default(object);
			if (obj6 != null)
			{
				_skipOne = true;
				return;
			}
		}
		if (!_skipOne)
		{
			object obj7 = _MaxHistory - 1;
			if (_historyIndex >= (nint)obj7)
			{
				_historyIndex = 0;
			}
			else
			{
				int historyIndex = _historyIndex + 1;
				_historyIndex = historyIndex;
			}
			bool flag6 = _MaxHistory <= 0;
			int num = 0;
			object obj12 = default(object);
			if (!flag6)
			{
				do
				{
					List<SpriteRenderer> ghosts = _ghosts;
					bool flag7 = num >= ghosts._size;
					SpriteRenderer[] items = ghosts._items;
					bool flag8 = num >= items.Length;
					Component component = items[num];
					bool flag9 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)component).m_CachedPtr);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					List<Vector3> positionHistory = _positionHistory;
					int num2 = _historyIndex + num;
					if (num2 >= _MaxHistory)
					{
						int num3 = num2 % _MaxHistory;
						num2 = num3;
					}
					int num4 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v25 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag10 = (nint)num4 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v25 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj8 = 0;
					int num5 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rcx_v58+18]");
					bool flag11 = (nint)num5 >= (nint)0;
					object obj9 = num2 * 2;
					object obj10 = num2 + obj9;
					bool flag12 = (object)transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rcx_v58+20+v1801 @ rax_v71*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rcx_v58+28+v1801 @ rax_v71*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1537 @ rax_v68 (UnityEngine.Transform)+10]");
					bool flag13 = (nint)0 == 0;
					object obj11 = obj12 - 88;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1537 @ rax_v68 (UnityEngine.Transform)+10]");
					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj11);
					if (_MatchTargetAngle)
					{
						object angleHistory = _angleHistory;
						int num6 = _historyIndex + num;
						bool flag14 = num6 < _MaxHistory;
						int num7 = num6;
						if (!flag14)
						{
							int num8 = num6 % _MaxHistory;
							num7 = num8;
						}
						Transform transform2 = base.transform;
						Vector3 eulerAngles = transform2.eulerAngles;
						int num9 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rsi_v28 (System.Object)+18]");
						bool flag15 = (nint)num9 >= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rsi_v28 (System.Object)+10]");
						object obj13 = 0;
						int num10 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ rdx_v73+18]");
						bool flag16 = (nint)num10 >= (nint)0;
						object obj14 = num7 * 2;
						object obj15 = num7 + obj14;
						_ = eulerAngles.x;
						_ = eulerAngles.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rsi_v28 (System.Object)+1C]");
						_ = (nint)0 + (nint)1;
					}
					Transform transform3 = component.transform;
					List<Vector3> angleHistory2 = _angleHistory;
					int num11 = _historyIndex + num;
					if (num11 >= _MaxHistory)
					{
						int num12 = num11 % _MaxHistory;
						num11 = num12;
					}
					int num13 = num11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ r8_v27 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag17 = (nint)num13 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ r8_v27 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj16 = 0;
					int num14 = num11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rcx_v64+18]");
					bool flag18 = (nint)num14 >= (nint)0;
					object obj17 = num11 * 2;
					object obj18 = num11 + obj17;
					Vector3 eulerAngles2 = (Vector3)(obj12 - 72);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rcx_v64+20+v634 @ rax_v81*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rcx_v64+28+v634 @ rax_v81*4]");
					_ = 0;
					transform3.eulerAngles = eulerAngles2;
					Transform transform4 = component.transform;
					List<Vector3> scaleHistory = _scaleHistory;
					int num15 = _historyIndex + num;
					if (num15 >= _MaxHistory)
					{
						int num16 = num15 % _MaxHistory;
						num15 = num16;
					}
					int num17 = num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ r8_v29 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag19 = (nint)num17 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ r8_v29 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj19 = 0;
					int num18 = num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rcx_v67+18]");
					bool flag20 = (nint)num18 >= (nint)0;
					object obj20 = num15 * 2;
					object obj21 = num15 + obj20;
					bool flag21 = (object)transform4 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rcx_v67+20+v1718 @ rax_v87*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rcx_v67+28+v1718 @ rax_v87*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2262 @ rax_v84 (UnityEngine.Transform)+10]");
					bool flag22 = (nint)0 == 0;
					object obj22 = obj12 - 56;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2262 @ rax_v84 (UnityEngine.Transform)+10]");
					Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj22);
					bool flag23 = (object)_MainSprite == null;
					bool flipX = _MainSprite.flipX;
					((SpriteRenderer)component).flipX = flipX;
					bool flag24 = (object)_MainSprite == null;
					bool flipY = _MainSprite.flipY;
					((SpriteRenderer)component).flipY = flipY;
					bool flag25 = (object)_MainSprite == null;
					Sprite sprite = _MainSprite.sprite;
					((SpriteRenderer)component).sprite = sprite;
					object obj23 = num - _knownHistory;
					int num19 = num ^ _knownHistory;
					int num20 = num ^ obj23;
					int num21 = num19 & num20;
					bool flag26 = num21 < 0;
					bool flag27 = (nint)obj23 < 0;
					bool flag28 = flag27 != flag26;
					bool flag29 = ((Renderer)component).enabled;
					bool flag30 = flag29 == flag28;
					object obj24 = 0;
					nint num22 = unchecked((nint)null);
					if (!flag30)
					{
						((Renderer)component).enabled = flag28;
						obj24 = 0;
						num22 = (flag28 ? 1 : 0);
					}
					num++;
				}
				while (num < _MaxHistory);
			}
			List<Vector3> positionHistory2 = _positionHistory;
			bool flag31 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
			Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rax_v127 (UnityEngine.Transform)+10]");
			bool flag32 = (nint)0 == 0;
			object obj25 = obj12 - 88;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rax_v127 (UnityEngine.Transform)+10]");
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj25);
			int historyIndex2 = _historyIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdi_v35 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			bool flag33 = (nint)historyIndex2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdi_v35 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj26 = 0;
			int historyIndex3 = _historyIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rdx_v81+18]");
			bool flag34 = (nint)historyIndex3 >= (nint)0;
			object obj27 = _historyIndex * 2;
			object obj28 = _historyIndex + obj27;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdi_v35 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			List<Vector3> angleHistory3 = _angleHistory;
			bool flag35 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
			Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rax_v138 (UnityEngine.Transform)+10]");
			bool flag36 = (nint)0 == 0;
			object obj29 = obj12 - 40;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rax_v138 (UnityEngine.Transform)+10]");
			Transform.get_rotation_Injected((IntPtr)0, out *(Quaternion*)obj29);
			Quaternion quaternion = (Quaternion)(obj12 - 56);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			Vector3 eulerAngles3 = ((Quaternion*)quaternion)->eulerAngles;
			int historyIndex4 = _historyIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rdi_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			bool flag37 = (nint)historyIndex4 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rdi_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj30 = 0;
			int historyIndex5 = _historyIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ r8_v38+18]");
			bool flag38 = (nint)historyIndex5 >= (nint)0;
			object obj31 = _historyIndex * 2;
			object obj32 = _historyIndex + obj31;
			_ = eulerAngles3.x;
			_ = eulerAngles3.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rdi_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			List<Vector3> scaleHistory2 = _scaleHistory;
			bool flag39 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr4 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
			Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v149 (UnityEngine.Transform)+10]");
			bool flag40 = (nint)0 == 0;
			object obj33 = obj12 - 88;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v149 (UnityEngine.Transform)+10]");
			Transform.get_lossyScale_Injected((IntPtr)0, out *(Vector3*)obj33);
			int historyIndex6 = _historyIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rdi_v37 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			bool flag41 = (nint)historyIndex6 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rdi_v37 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj34 = 0;
			int historyIndex7 = _historyIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rdx_v88+18]");
			bool flag42 = (nint)historyIndex7 >= (nint)0;
			object obj35 = _historyIndex * 2;
			object obj36 = _historyIndex + obj35;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rdi_v37 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			int knownHistory = _knownHistory + 1;
			_knownHistory = knownHistory;
			if (_AutoUpdateDepth)
			{
				UpdateDepth();
			}
		}
		else
		{
			_skipOne = false;
		}
	}

	public unsafe void Reset()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0016: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected I, but got Unknown
		//IL_07d6: Expected O, but got Ref
		//IL_017e: Expected O, but got I
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected I4, but got Unknown
		//IL_0877: Expected O, but got Ref
		//IL_0897: Expected O, but got Ref
		//IL_0291: Expected O, but got I4
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected I4, but got Unknown
		//IL_0946: Expected O, but got Ref
		//IL_0363: Expected O, but got I
		//IL_0396: Expected O, but got I4
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected O, but got Unknown
		//IL_09cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d4: Expected I4, but got Unknown
		//IL_0449: Expected O, but got I
		//IL_047c: Expected O, but got I4
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		//IL_0a40: Expected O, but got Ref
		//IL_0a90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a95: Expected I4, but got Unknown
		//IL_0523: Expected O, but got I
		//IL_0556: Expected O, but got I4
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected O, but got Unknown
		//IL_058e: Expected O, but got Ref
		//IL_0b25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2a: Expected I4, but got Unknown
		//IL_0616: Expected O, but got I
		//IL_0649: Expected O, but got I4
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_0656: Expected O, but got Unknown
		//IL_0b96: Expected O, but got Ref
		//IL_0c06: Expected O, but got I4
		//IL_0c20: Expected I4, but got O
		//IL_0c7b: Expected O, but got I4
		//IL_0c95: Expected I4, but got O
		//IL_0e83: Expected I, but got O
		//IL_06f5: Expected O, but got I
		//IL_0d72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d77: Expected O, but got Unknown
		//IL_070c: Expected I, but got O
		//IL_0097->IL0730: Incompatible stack heights: 1 vs 0
		//IL_0799->IL0730: Incompatible stack heights: 2 vs 0
		//IL_0802->IL0730: Incompatible stack heights: 3 vs 0
		//IL_016b->IL0730: Incompatible stack heights: 4 vs 0
		//IL_0840->IL0730: Incompatible stack heights: 5 vs 0
		//IL_08cb->IL0730: Incompatible stack heights: 6 vs 0
		//IL_027e->IL0730: Incompatible stack heights: 7 vs 0
		//IL_0909->IL0730: Incompatible stack heights: 8 vs 0
		//IL_0973->IL0730: Incompatible stack heights: 9 vs 0
		//IL_0383->IL0730: Incompatible stack heights: 10 vs 0
		//IL_03e2->IL0730: Incompatible stack heights: 10 vs 0
		//IL_0a0c->IL0730: Incompatible stack heights: 11 vs 0
		//IL_0469->IL0730: Incompatible stack heights: 12 vs 0
		//IL_0543->IL0730: Incompatible stack heights: 17 vs 0
		//IL_057b->IL0730: Incompatible stack heights: 17 vs 0
		//IL_0b62->IL0730: Incompatible stack heights: 18 vs 0
		//IL_0636->IL0730: Incompatible stack heights: 19 vs 0
		//IL_0d91->IL0730: Incompatible stack heights: 31 vs 0
		//IL_0719->IL0d96: Incompatible stack heights: 31 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		List<SpriteRenderer> ghosts = _ghosts;
		if (_ghosts != null)
		{
			object obj3 = 0;
			object obj4 = 0;
			nint num3 = default(nint);
			while (true)
			{
				if ((nint)obj4 < ghosts._size)
				{
					List<SpriteRenderer> ghosts2 = _ghosts;
					if (_ghosts == null)
					{
						break;
					}
					bool flag = (nint)obj3 >= ghosts2._size;
					SpriteRenderer[] items = ghosts2._items;
					if (ghosts2._items == null)
					{
						break;
					}
					List<Vector3> positionHistory = _positionHistory;
					nint num = (nint)(_historyIndex + obj3);
					object obj5 = items[obj3];
					nint num2;
					if (num >= _MaxHistory)
					{
						num2 = num % _MaxHistory;
						num3 = num;
						num = num2;
					}
					bool flag2 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					_ = 0;
					_ = 0;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj6);
					if (_positionHistory == null)
					{
						break;
					}
					nint intPtr = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ r14_v38 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag4 = intPtr >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ r14_v38 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					int num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ r14_v38 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					object obj7 = num * 2;
					object obj8 = num + obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ r14_v38 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
					_ = (nint)0 + (nint)1;
					List<Vector3> angleHistory = _angleHistory;
					int num5 = _historyIndex + obj3;
					bool flag5 = num5 < _MaxHistory;
					int num6 = (int)num3;
					if (!flag5)
					{
						num4 = num5 % _MaxHistory;
						num6 = num5;
						num5 = num4;
					}
					bool flag6 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
					Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
					if ((object)transform2 == null)
					{
						break;
					}
					_ = 0;
					bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
					Transform.get_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Quaternion*)obj9);
					Quaternion quaternion = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
					_ = 0;
					Vector3 eulerAngles = ((Quaternion*)quaternion)->eulerAngles;
					if (_angleHistory == null)
					{
						break;
					}
					int num7 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r14_v39 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag8 = (nint)num7 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r14_v39 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					int num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r14_v39 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					object obj10 = num5 * 2;
					object obj11 = num5 + obj10;
					_ = eulerAngles.x;
					_ = eulerAngles.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r14_v39 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
					_ = (nint)0 + (nint)1;
					List<Vector3> scaleHistory = _scaleHistory;
					int num9 = _historyIndex + obj3;
					if (num9 >= _MaxHistory)
					{
						num8 = num9 % _MaxHistory;
						num6 = num9;
						num9 = num8;
					}
					bool flag9 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
					Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
					if ((object)transform3 == null)
					{
						break;
					}
					_ = 0;
					_ = 0;
					bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
					Transform.get_lossyScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj12);
					if (_scaleHistory == null)
					{
						break;
					}
					int num10 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r14_v40 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag11 = (nint)num10 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r14_v40 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r14_v40 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					object obj14 = num9 * 2;
					object obj15 = num9 + obj14;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r14_v40 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
					_ = (nint)0 + (nint)1;
					if ((object)items[obj3] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					bool flag12 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
					Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
					List<Vector3> positionHistory2 = _positionHistory;
					int num11 = _historyIndex + obj3;
					if (num11 >= _MaxHistory)
					{
						int num12 = num11 % _MaxHistory;
						num6 = num11;
						num11 = num12;
					}
					if (_positionHistory == null)
					{
						break;
					}
					int num13 = num11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v38 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag13 = (nint)num13 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v38 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v38 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					object obj17 = num11 * 2;
					object obj18 = num11 + obj17;
					bool flag14 = (object)transform4 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v118+20+v2342 @ rax_v140*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v118+28+v2342 @ rax_v140*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2217 @ rax_v137 (UnityEngine.Transform)+10]");
					bool flag15 = (nint)0 == 0;
					object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2217 @ rax_v137 (UnityEngine.Transform)+10]");
					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj19);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					bool flag16 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					IntPtr gcHandlePtr5 = Component.get_transform_Injected((IntPtr)0);
					Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
					List<Vector3> angleHistory2 = _angleHistory;
					int num14 = _historyIndex + obj3;
					if (num14 >= _MaxHistory)
					{
						int num15 = num14 % _MaxHistory;
						num6 = num14;
						num14 = num15;
					}
					bool flag17 = _angleHistory == null;
					int num16 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v39 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag18 = (nint)num16 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v39 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v39 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					object obj21 = num14 * 2;
					object obj22 = num14 + obj21;
					if ((object)transform5 == null)
					{
						break;
					}
					Vector3 eulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v126+20+v196 @ rax_v153*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v126+28+v196 @ rax_v153*4]");
					_ = 0;
					transform5.eulerAngles = eulerAngles2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					bool flag19 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					IntPtr gcHandlePtr6 = Component.get_transform_Injected((IntPtr)0);
					Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
					List<Vector3> scaleHistory2 = _scaleHistory;
					int num17 = _historyIndex + obj3;
					if (num17 >= _MaxHistory)
					{
						int num18 = num17 % _MaxHistory;
						num6 = num17;
						num17 = num18;
					}
					if (_scaleHistory == null)
					{
						break;
					}
					int num19 = num17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r8_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag20 = (nint)num19 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r8_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r8_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					object obj24 = num17 * 2;
					object obj25 = num17 + obj24;
					bool flag21 = (object)transform6 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v132+20+v2875 @ rax_v163*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v132+28+v2875 @ rax_v163*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2969 @ rax_v160 (UnityEngine.Transform)+10]");
					bool flag22 = (nint)0 == 0;
					object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2969 @ rax_v160 (UnityEngine.Transform)+10]");
					Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj26);
					object mainSprite = _MainSprite;
					bool flag23 = (object)_MainSprite == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1737 @ rbx_v49 (System.Object)+10]");
					bool flag24 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1737 @ rbx_v49 (System.Object)+10]");
					object obj27 = SpriteRenderer.get_flipX_Injected((IntPtr)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					bool flag25 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					SpriteRenderer.set_flipX_Injected((IntPtr)0, (byte)(int)obj27 != 0);
					object mainSprite2 = _MainSprite;
					bool flag26 = (object)_MainSprite == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1943 @ rbx_v51 (System.Object)+10]");
					bool flag27 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1943 @ rbx_v51 (System.Object)+10]");
					object obj28 = SpriteRenderer.get_flipY_Injected((IntPtr)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					bool flag28 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					SpriteRenderer.set_flipY_Injected((IntPtr)0, (byte)(int)obj28 != 0);
					object mainSprite3 = _MainSprite;
					bool flag29 = (object)_MainSprite == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2080 @ rbx_v53 (System.Object)+10]");
					bool flag30 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2080 @ rbx_v53 (System.Object)+10]");
					IntPtr gcHandlePtr7 = SpriteRenderer.get_sprite_Injected((IntPtr)0);
					Sprite sprite = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>(gcHandlePtr7);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					bool flag31 = (nint)0 == 0;
					bool flag32 = (object)sprite == null;
					object obj29 = sprite;
					if (!flag32)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3217 @ rax_v189 (UnityEngine.Sprite)+10]");
						obj29 = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					SpriteRenderer.set_sprite_Injected((IntPtr)0, (IntPtr)obj29);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					bool flag33 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r13_v38 (System.Object)+10]");
					Renderer.set_enabled_Injected((IntPtr)0, false);
					ghosts = _ghosts;
					obj3++;
					if (_ghosts == null)
					{
						break;
					}
					num3 = num6;
					num2 = unchecked((nint)null);
					obj4 = obj3;
					continue;
				}
				_knownHistory = 0;
				_historyIndex = 0;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public SpriteTrail SetSprite(int index, Sprite s)
	{
		List<SpriteRenderer> ghosts = _ghosts;
		if (index < ghosts._size)
		{
			SpriteRenderer[] items = ghosts._items;
			items[index].sprite = s;
			return this;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		SpriteTrail result = default(SpriteTrail);
		return result;
	}

	public unsafe SpriteTrail SetTint(int index, Color c)
	{
		//IL_008b: Expected O, but got I
		//IL_004f->IL00ba: Incompatible stack heights: 1 vs 0
		//IL_00ab->IL00ba: Incompatible stack heights: 1 vs 0
		List<SpriteRenderer> ghosts = _ghosts;
		if (_ghosts != null)
		{
			bool flag = index >= ghosts._size;
			object items = ghosts._items;
			if (ghosts._items != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v6 (System.Object)+18]");
				if ((nint)index >= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v6 (System.Object)+20+index @ rdx (System.Int32)*8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v6 (System.Object)+20+index @ rdx (System.Int32)*8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v7 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v7 (System.Object)+10]");
					float value = default(float);
					SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
					return this;
				}
			}
		}
		throw new NullReferenceException();
	}

	public SpriteTrail SetAlpha(int index, float a)
	{
		//IL_008b: Expected O, but got I
		//IL_004f->IL00c9: Incompatible stack heights: 1 vs 0
		//IL_00ab->IL00c9: Incompatible stack heights: 1 vs 0
		List<SpriteRenderer> ghosts = _ghosts;
		if (_ghosts != null)
		{
			bool flag = index >= ghosts._size;
			object items = ghosts._items;
			if (ghosts._items != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v12 (System.Object)+18]");
				if ((nint)index >= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v12 (System.Object)+20+index @ rdx (System.Int32)*8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v12 (System.Object)+20+index @ rdx (System.Int32)*8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v13 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v13 (System.Object)+10]");
					SpriteRenderer.get_color_Injected((IntPtr)0, out Color ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v13 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v13 (System.Object)+10]");
					SpriteRenderer.get_color_Injected((IntPtr)0, out Color _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v13 (System.Object)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v13 (System.Object)+10]");
					SpriteRenderer.get_color_Injected((IntPtr)0, out Color _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v13 (System.Object)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v13 (System.Object)+10]");
					SpriteRenderer.set_color_Injected((IntPtr)0, ref ret);
					return this;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe SpriteTrail SetTint(int index, string c)
	{
		List<SpriteRenderer> ghosts = _ghosts;
		bool flag = index >= ghosts._size;
		SpriteRenderer[] items = ghosts._items;
		object obj = items[index];
		Color color = ColourHelper.HexToColor(c);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdi_v5 (System.Object)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdi_v5 (System.Object)+10]");
		float value = default(float);
		SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
		return this;
	}

	public unsafe Vector3 GetPosition(int index)
	{
		//IL_003c: Expected O, but got I
		//IL_004f: Expected O, but got I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0071: Expected F4, but got I
		//IL_006c: Expected native int or pointer, but got O
		//IL_0086: Expected F4, but got I
		//IL_0081: Expected native int or pointer, but got O
		List<Vector3> positionHistory = _positionHistory;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		if ((nint)index < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj = 0;
			object obj2 = index * 2;
			object obj3 = index + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+20+v124 @ rcx_v3*4]");
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+28+v124 @ rcx_v3*4]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Vector3 result = default(Vector3);
		return result;
	}

	public SpriteTrail SetPosition(int index, Vector3 position)
	{
		//IL_003c: Expected O, but got I
		//IL_004f: Expected O, but got I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		List<Vector3> positionHistory = _positionHistory;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ r9_v1 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		if ((nint)index < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ r9_v1 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj = 0;
			object obj2 = index * 2;
			object obj3 = index + obj2;
			_ = position.x;
			_ = position.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ r9_v1 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			return this;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		SpriteTrail result = default(SpriteTrail);
		return result;
	}

	public unsafe SpriteTrail SetColors(List<string> colors)
	{
		//IL_0018: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		//IL_00bf: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_00d1->IL020a: Incompatible stack heights: 1 vs 0
		//IL_00fa->IL020a: Incompatible stack heights: 1 vs 0
		//IL_011e->IL01e2: Incompatible stack heights: 1 vs 0
		//IL_014d->IL020a: Incompatible stack heights: 1 vs 0
		//IL_028b->IL020a: Incompatible stack heights: 3 vs 0
		//IL_01e0->IL0290: Incompatible stack heights: 3 vs 1
		if (colors != null)
		{
			object obj = colors._size - 1;
			if ((nint)obj >= colors._size)
			{
				goto IL_01e2;
			}
			string[] items = colors._items;
			if (colors._items != null)
			{
				object obj2 = colors._size - 1;
				bool flag = (nint)obj2 >= items.Length;
				List<SpriteRenderer> ghosts = _ghosts;
				bool flag2 = _ghosts == null;
				object obj3 = 0;
				object obj4 = 0;
				if (!flag2)
				{
					string hex = default(string);
					float value = default(float);
					while (true)
					{
						if ((nint)obj4 < ghosts._size)
						{
							List<SpriteRenderer> ghosts2 = _ghosts;
							if (_ghosts == null)
							{
								break;
							}
							if ((nint)obj3 < ghosts2._size)
							{
								SpriteRenderer[] items2 = ghosts2._items;
								if (ghosts2._items == null)
								{
									break;
								}
								bool flag3 = (nint)obj3 >= items2.Length;
								object obj5 = items2[obj3];
								if ((nint)obj3 < colors._size)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								}
								else
								{
									hex = items[obj2];
								}
								Color color = ColourHelper.HexToColor(hex);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v9 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v9 (System.Object)+10]");
								SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
								ghosts = _ghosts;
								obj3++;
								if (_ghosts == null)
								{
									break;
								}
								obj4 = obj3;
								continue;
							}
							goto IL_01e2;
						}
						return this;
					}
				}
			}
		}
		goto IL_020a;
		IL_020a:
		throw new NullReferenceException();
		IL_01e2:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_020a;
	}

	public unsafe SpriteTrail SetAlphas(List<float> alphas)
	{
		//IL_001b: Expected O, but got I
		//IL_0052: Expected O, but got I
		//IL_008d: Expected O, but got I
		//IL_00d4: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_00e6->IL0277: Incompatible stack heights: 1 vs 0
		//IL_0133->IL0277: Incompatible stack heights: 1 vs 0
		//IL_0157->IL024f: Incompatible stack heights: 1 vs 0
		//IL_0186->IL0277: Incompatible stack heights: 1 vs 0
		//IL_029f->IL0277: Incompatible stack heights: 2 vs 0
		//IL_0306->IL0277: Incompatible stack heights: 3 vs 0
		//IL_024d->IL00eb: Incompatible stack heights: 3 vs 1
		if (alphas != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [alphas @ rdx (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [alphas @ rdx (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)obj >= 0)
			{
				goto IL_024f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [alphas @ rdx (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [alphas @ rdx (System.Collections.Generic.List`1<System.Single>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [alphas @ rdx (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj3 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v11+18]");
				bool flag = (nint)obj3 >= 0;
				List<SpriteRenderer> ghosts = _ghosts;
				bool flag2 = _ghosts == null;
				object obj4 = 0;
				object obj5 = 0;
				if (!flag2)
				{
					float value = default(float);
					while (true)
					{
						if ((nint)obj5 < ghosts._size)
						{
							List<SpriteRenderer> ghosts2 = _ghosts;
							if (_ghosts == null)
							{
								break;
							}
							if ((nint)obj4 < ghosts2._size)
							{
								SpriteRenderer[] items = ghosts2._items;
								if (ghosts2._items == null)
								{
									break;
								}
								bool flag3 = (nint)obj4 >= items.Length;
								SpriteRenderer spriteRenderer = items[obj4];
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [alphas @ rdx (System.Collections.Generic.List`1<System.Single>)+18]");
								if (0 < (nint)obj4)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD20");
								}
								if ((object)items[obj4] == null)
								{
									break;
								}
								Color color = items[obj4].color;
								Color color2 = items[obj4].color;
								Color color3 = items[obj4].color;
								bool flag4 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
								SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref *(Color*)(&value));
								ghosts = _ghosts;
								obj4++;
								if (_ghosts == null)
								{
									break;
								}
								obj5 = obj4;
								continue;
							}
							goto IL_024f;
						}
						return this;
					}
				}
			}
		}
		goto IL_0277;
		IL_0277:
		throw new NullReferenceException();
		IL_024f:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0277;
	}

	public SpriteTrail setVisible(bool b)
	{
		List<SpriteRenderer> ghosts = _ghosts;
		bool flag = _ghosts == null;
		bool flag2 = false;
		bool flag3 = false;
		if (!flag)
		{
			Component component = default(Component);
			while (true)
			{
				if ((flag3 ? 1 : 0) < ghosts._size)
				{
					if ((flag2 ? 1 : 0) < _MaxHistory)
					{
						if (_ghosts == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
						{
							GameObject gameObject = component.gameObject;
							if ((object)gameObject == null)
							{
								break;
							}
							gameObject.SetActive(b);
							((Renderer)component).enabled = b;
						}
					}
					ghosts = _ghosts;
					flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
					if (_ghosts == null)
					{
						break;
					}
					flag3 = flag2;
					continue;
				}
				if (b)
				{
					_knownHistory = 0;
					_historyIndex = 0;
				}
				return this;
			}
		}
		return (SpriteTrail)(object)new NullReferenceException();
	}

	public void UpdateDepth()
	{
		//IL_0022: Expected O, but got I4
		//IL_01ea: Expected O, but got I4
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0141: Expected I4, but got O
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_00c7->IL0184: Incompatible stack heights: 1 vs 0
		//IL_00f0->IL0184: Incompatible stack heights: 1 vs 0
		//IL_0120->IL0184: Incompatible stack heights: 2 vs 0
		//IL_017e->IL0030: Incompatible stack heights: 2 vs 0
		//IL_0183->IL0183: Incompatible stack heights: 2 vs 0
		List<SpriteRenderer> ghosts = _ghosts;
		if (_ghosts != null)
		{
			bool flag = _MaxHistory <= 0;
			object obj = 0;
			if (flag)
			{
				return;
			}
			while (true)
			{
				if ((nint)obj < ghosts._size)
				{
					List<SpriteRenderer> ghosts2 = _ghosts;
					if (_ghosts == null)
					{
						break;
					}
					bool flag2 = (nint)obj >= ghosts2._size;
					SpriteRenderer[] items = ghosts2._items;
					if (ghosts2._items == null)
					{
						break;
					}
					object mainSprite = _MainSprite;
					if ((object)_MainSprite == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v9 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v9 (System.Object)+10]");
					object obj2 = Renderer.get_sortingOrder_Injected((IntPtr)0);
					if ((object)items[obj] == null)
					{
						break;
					}
					object obj3 = obj2 - _MaxHistory;
					int sortingOrder = (int)(obj + obj3);
					items[obj].sortingOrder = sortingOrder;
					obj++;
					if ((nint)obj >= _MaxHistory)
					{
						return;
					}
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public SpriteRenderer GetTrailSprite(int index)
	{
		List<SpriteRenderer> ghosts = _ghosts;
		if (index < ghosts._size)
		{
			SpriteRenderer[] items = ghosts._items;
			return items[index];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		SpriteRenderer result = default(SpriteRenderer);
		return result;
	}

	public int GetGhostCount()
	{
		if (_ghosts == null)
		{
			return 0;
		}
		List<SpriteRenderer> ghosts = _ghosts;
		return ghosts._size;
	}

	private int GetHistoryIndex(int index)
	{
		int num = _historyIndex + index;
		if (num >= _MaxHistory)
		{
			int num2 = num % _MaxHistory;
			num = num2;
		}
		return num;
	}

	public SpriteTrail()
	{
		//IL_009c: Expected I, but got O
		List<string> tints = new List<string>();
		_Tints = tints;
		_DefaultGhostAlpha = 1f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v6 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_ScaleModifier = Vector2.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+C]");
		_ = 0;
		_UsePauseSystem = true;
		List<Vector3> positionHistory = new List<Vector3>();
		_positionHistory = positionHistory;
		List<Vector3> angleHistory = new List<Vector3>();
		_angleHistory = angleHistory;
		List<Vector3> scaleHistory = new List<Vector3>();
		_scaleHistory = scaleHistory;
		List<SpriteRenderer> ghosts = new List<SpriteRenderer>();
		_ghosts = ghosts;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A109F8h]\"");
		base._onResumeSent = true;
		_frameTimeMS = _frameTime;
	}

	static SpriteTrail()
	{
		//IL_007d: Expected O, but got I
		//IL_00a3: Expected O, but got I
		//IL_000e: Expected O, but got I
		//IL_0034: Expected O, but got I
		_fps = 60;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
		_frameTime = 1.0;
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("OnEnable_Base", 1, MarkerFlags.Default, 0);
		_markerOnEnableBase = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("OnEnable_Ghosts", 1, MarkerFlags.Default, 0);
		_markerOnEnableGhosts = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("OnDisable_Base", 1, MarkerFlags.Default, 0);
		_markerOnDisableBase = (ProfilerMarker)(nint)intPtr3;
		IntPtr intPtr4 = ProfilerUnsafeUtility.CreateMarker("OnDisable_Ghosts", 1, MarkerFlags.Default, 0);
		_markerOnDisableGhosts = (ProfilerMarker)(nint)intPtr4;
	}
}
