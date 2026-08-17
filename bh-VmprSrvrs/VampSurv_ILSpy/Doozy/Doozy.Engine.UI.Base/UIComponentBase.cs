using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using Doozy.Engine.Soundy;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Doozy.Engine.UI.Base;

public abstract class UIComponentBase<T> : MonoBehaviour
{
	public static readonly List<T> Database;

	private static int s_uiInteractionsDisableLevel;

	private static EventSystem s_unityEventSystem;

	public bool DebugMode;

	public Vector3 StartPosition;

	public Vector3 StartRotation;

	public Vector3 StartScale;

	public float StartAlpha;

	private RectTransform m_rectTransform;

	protected static DoozySettings Settings => DoozySettings.Instance;

	public static bool UIInteractionsDisabled
	{
		get
		{
			//IL_002a: Expected O, but got I
			//IL_003f: Expected O, but got I
			//IL_00d6: Expected O, but got I
			//IL_00eb: Expected O, but got I
			//IL_0091: Expected O, but got I
			//IL_00a6: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v9 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v11+B8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v12+8]");
			if ((nint)0 < (nint)0)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v41 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v43+B8]");
				object obj4 = 0;
				_ = 0;
			}
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v22 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v24+B8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v25+8]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v25+8]");
			bool flag2 = (nint)0 == 0;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
	}

	public static EventSystem UnityEventSystem
	{
		get
		{
			//IL_002a: Expected O, but got I
			//IL_003f: Expected O, but got I
			//IL_004f: Expected O, but got I
			//IL_010c: Expected O, but got I
			//IL_0121: Expected O, but got I
			//IL_00b2: Expected O, but got I
			//IL_00c7: Expected O, but got I
			//IL_00d4: Expected O, but got I
			//IL_0150: Expected O, but got I
			//IL_0165: Expected O, but got I
			//IL_0175: Expected O, but got I
			//IL_01f5: Expected O, but got I
			//IL_020a: Expected O, but got I
			//IL_0417: Expected O, but got I
			//IL_042c: Expected O, but got I
			//IL_0439: Expected O, but got I
			//IL_0239: Expected O, but got I
			//IL_024e: Expected O, but got I
			//IL_025e: Expected O, but got I
			//IL_02e5: Expected I, but got O
			//IL_0353: Expected I, but got O
			//IL_03d8: Expected O, but got I
			//IL_03ed: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v10 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v12+B8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v13+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v13+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rbx_v1+10]");
				if ((nint)0 != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rax_v198 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rax_v200+B8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rax_v201+10]");
					return (EventSystem)0;
				}
			}
			EventSystem current = EventSystem.current;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rax_v29 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v31+B8]");
			object obj7 = 0;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rax_v41 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rax_v43+B8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ rax_v44+10]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ rax_v44+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rbx_v3+10]");
				if ((nint)0 != 0)
				{
					goto IL_0401;
				}
			}
			EventSystem eventSystem = UnityEngine.Object.FindObjectOfType<EventSystem>();
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v904 @ rax_v70 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v921 @ rax_v72+B8]");
			object obj12 = 0;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v82 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1045 @ rax_v84+B8]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rax_v85+10]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rax_v85+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v729 @ rbx_v7+10]");
				if ((nint)0 != 0)
				{
					goto IL_0401;
				}
			}
			Type[] array = new Type[2];
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EventSystem));
			if ((object)typeFromHandle != null)
			{
				nint num7 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj16 = default(object);
				if (obj16 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(StandaloneInputModule));
			if ((object)typeFromHandle2 != null)
			{
				nint num8 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj17 = default(object);
				if (obj17 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			GameObject gameObject = new GameObject("EventSystem", array);
			EventSystem component = gameObject.GetComponent<EventSystem>();
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1361 @ rax_v117 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1374 @ rax_v119+B8]");
			object obj19 = 0;
			goto IL_0401;
			IL_0401:
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v897 @ rax_v52 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v917 @ rax_v54+B8]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v918 @ rax_v55+10]");
			return (EventSystem)0;
		}
	}

	public RectTransform RectTransform
	{
		get
		{
			//IL_010a: Expected O, but got I
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Expected O, but got Unknown
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			//IL_016b: Expected O, but got I4
			//IL_00f5: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Base.UIComponentBase`1<T>)+50]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Base.UIComponentBase`1<T>)+50]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1+10]");
				if ((nint)0 != 0)
				{
					goto IL_00e5;
				}
			}
			RectTransform result = GetComponent<RectTransform>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			if ((nint)0 != 0)
			{
				object obj2 = this + 80;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				object obj7 = obj5 * 8;
				object obj8 = 6603864928L + obj7;
				do
				{
					object obj9 = 1 << (int)obj6;
					object obj10 = obj8 | obj9;
					if (obj8 == obj8)
					{
						obj8 = obj10;
					}
				}
				while (obj8 != obj8);
				goto IL_00e5;
			}
			goto IL_0139;
			IL_00e5:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Base.UIComponentBase`1<T>)+50]");
			result = (RectTransform)0;
			goto IL_0139;
			IL_0139:
			return result;
		}
	}

	protected virtual void Reset()
	{
	}

	public virtual void Awake()
	{
		//IL_002f: Expected O, but got I
		//IL_0044: Expected O, but got I
		BackButton.Init();
		SoundyManager.Init();
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v5 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v9+B8]");
		object obj2 = 0;
		List<object> list = (List<object>)obj2;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F81CF0");
		object[] items = list._items;
		int version = list._version + 1;
		list._version = version;
		if (list._size >= items.Length)
		{
			object item = default(object);
			list.AddWithResize(item);
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		((UIComponentBase<>)(object)this).UpdateStartValues();
	}

	public virtual void Start()
	{
	}

	public virtual void OnEnable()
	{
	}

	public virtual void OnDisable()
	{
	}

	public virtual void OnDestroy()
	{
		//IL_0020: Expected O, but got I
		//IL_0035: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v7+B8]");
		object obj2 = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F81CF0");
		object item = default(object);
		bool flag = ((List<object>)obj2).Remove(item);
	}

	public virtual bool IsActive()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Base.UIComponentBase`1<T>)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	public bool IsDestroyed()
	{
		if ((object)this != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Base.UIComponentBase`1<T>)+10]");
			return (nint)0 == 0;
		}
		return true;
	}

	public virtual void ResetToStartValues()
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
		RectTransform target = default(RectTransform);
		UIAnimator.ResetCanvasGroup(target);
		((UIComponentBase<>)(object)this).ResetPosition();
		((UIComponentBase<>)(object)this).ResetRotation();
		((UIComponentBase<>)(object)this).ResetScale();
		((UIComponentBase<>)(object)this).ResetAlpha();
	}

	public unsafe virtual void ResetPosition()
	{
		//IL_0022: Expected O, but got Ref
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
		RectTransform rectTransform = default(RectTransform);
		object obj = default(object);
		rectTransform.anchoredPosition3D = (Vector3)(&obj);
	}

	public unsafe virtual void ResetRotation()
	{
		//IL_0022: Expected O, but got Ref
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
		Transform transform = default(Transform);
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	public virtual void ResetScale()
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v2 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected((IntPtr)0, ref value);
	}

	public virtual void ResetAlpha()
	{
		//IL_0084: Expected F4, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
		Component component2 = default(Component);
		CanvasGroup component = component2.GetComponent<CanvasGroup>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
			Component component4 = default(Component);
			CanvasGroup component3 = component4.GetComponent<CanvasGroup>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Base.UIComponentBase`1<T>)+48]");
			component3.alpha = 0f;
		}
	}

	public virtual void UpdateStartValues()
	{
		((UIComponentBase<>)(object)this).UpdateStartPosition();
		((UIComponentBase<>)(object)this).UpdateStartRotation();
		((UIComponentBase<>)(object)this).UpdateStartScale();
		((UIComponentBase<>)(object)this).UpdateStartAlpha();
	}

	public virtual void UpdateStartPosition()
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
		RectTransform rectTransform = default(RectTransform);
		Vector3 anchoredPosition3D = rectTransform.anchoredPosition3D;
		_ = anchoredPosition3D.x;
		_ = anchoredPosition3D.z;
	}

	public virtual void UpdateStartRotation()
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
		Transform transform = default(Transform);
		Vector3 localEulerAngles = transform.localEulerAngles;
		_ = localEulerAngles.x;
		_ = localEulerAngles.z;
	}

	public virtual void UpdateStartScale()
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v2 (System.Object)+10]");
		Transform.get_localScale_Injected((IntPtr)0, out Vector3 _);
		_ = 1f;
	}

	public virtual void UpdateStartAlpha()
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
		Component component2 = default(Component);
		CanvasGroup component = component2.GetComponent<CanvasGroup>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF18D0");
			Component component4 = default(Component);
			CanvasGroup component3 = component4.GetComponent<CanvasGroup>();
			float alpha = component3.alpha;
		}
		else
		{
			float alpha = 1f;
		}
	}

	protected static void RemoveAnyNullReferencesFromTheDatabase()
	{
		//IL_002a: Expected O, but got I
		//IL_003f: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_0092: Expected O, but got I
		//IL_00c5: Expected O, but got I
		//IL_00da: Expected O, but got I
		//IL_0123: Expected O, but got I
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_0209: Expected O, but got I4
		//IL_0191: Expected O, but got I
		//IL_01a6: Expected O, but got I
		//IL_01c7: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v9 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v11+B8]");
		object obj2 = 0;
		object obj3 = obj2;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v10 (Il2CppClass<Doozy.Engine.UI.Base.UIComponentBase`1>)+135]");
		object obj4 = (nint)0 & (nint)1;
		bool flag = (nint)obj4 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v1+18]");
		object obj5 = -1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rax_v29 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v31+B8]");
			object obj7 = 0;
			object obj8 = obj7;
			object obj9 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rsi_v5+18]");
			if ((nint)obj9 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rsi_v5+10]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v18+20+v118 @ rbx_v7*8]");
			bool flag2 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v18+20+v118 @ rbx_v7*8]");
			if ((nint)0 == 0)
			{
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v44 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v46+B8]");
				object obj12 = 0;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rax_v48 (Il2CppClass<Doozy.Engine.UI.Base.UIComponentBase`1>)+135]");
				object obj13 = (nint)0 & (nint)1;
				flag2 = (nint)obj13 < 0;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1838145F0");
			}
			obj5--;
			object obj14 = !flag2;
			if (obj14 != null)
			{
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public static void EnableUIInteractions()
	{
		//IL_002a: Expected O, but got I
		//IL_003f: Expected O, but got I
		//IL_0055: Expected O, but got I
		//IL_0070: Expected O, but got I
		//IL_0085: Expected O, but got I
		//IL_00a5: Expected O, but got I
		//IL_00ba: Expected O, but got I
		//IL_010c: Expected O, but got I
		//IL_0121: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v9 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v11+B8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v12+8]");
		object obj3 = -1;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v15 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v17+B8]");
		object obj5 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v21 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v23+B8]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v24+8]");
		if ((nint)0 < (nint)0)
		{
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v34 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v36+B8]");
			object obj9 = 0;
			_ = 0;
		}
	}

	public static void EnableUIInteractionsByForce()
	{
		//IL_002a: Expected O, but got I
		//IL_0040: Expected O, but got I
		//IL_008e: Expected O, but got I
		//IL_006d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v9 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v5+135]");
		object obj2 = (nint)0 & (nint)1;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v5+B8]");
			object obj3 = 0;
			_ = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10+B8]");
			object obj4 = 0;
			_ = 0;
		}
	}

	public static void DisableUIInteractions()
	{
		//IL_002a: Expected O, but got I
		//IL_003f: Expected O, but got I
		//IL_0055: Expected O, but got I
		//IL_0070: Expected O, but got I
		//IL_0086: Expected O, but got I
		//IL_00d3: Expected O, but got I
		//IL_00b3: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v9 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v11+B8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v12+8]");
		object obj3 = (nint)0 + (nint)1;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v15 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v7+135]");
		object obj5 = (nint)0 & (nint)1;
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v7+B8]");
			object obj6 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v16+B8]");
			object obj7 = 0;
		}
	}

	protected UIComponentBase()
	{
		//IL_0015: Expected I, but got O
		//IL_0081: Expected I, but got O
		//IL_00b2: Expected I, but got O
		//IL_0028: Expected I, but got O
		nint num = (nint)typeof(UIAnimator);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
		nint num2 = 0;
		_ = UIAnimator.DEFAULT_START_POSITION;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(UIAnimator);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v5 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
		nint num4 = 0;
		_ = UIAnimator.DEFAULT_START_ROTATION;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v4 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+14]");
		_ = 0;
		nint num5 = (nint)typeof(UIAnimator);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
		nint num6 = 0;
		_ = UIAnimator.DEFAULT_START_SCALE;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v5 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+20]");
		_ = 0;
		_ = 1065353216;
		nint num7 = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v7 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static UIComponentBase()
	{
		//IL_0045: Expected O, but got I
		//IL_005a: Expected O, but got I
		nint num = 0;
		object obj = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183731620");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v12 (Il2CppRgctx<Doozy.Engine.UI.Base.UIComponentBase`1>)+8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v14+B8]");
		object obj3 = 0;
		obj3 = obj;
	}
}
