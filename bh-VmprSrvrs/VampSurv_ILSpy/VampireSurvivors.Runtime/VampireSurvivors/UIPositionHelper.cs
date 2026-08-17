using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class UIPositionHelper : MonoBehaviour
{
	private bool _ShowDebug;

	private RectTransform _PositionHelperTarget;

	private GameObject UITarget;

	private GameObject WorldTarget;

	private Canvas _canvas;

	private static UIPositionHelper Instance;

	private RectTransform rTrans;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		//IL_017c->IL0181: Incompatible stack heights: 1 vs 0
		if (_ShowDebug)
		{
			GameObject worldTarget = GameObject.CreatePrimitive(PrimitiveType.Cube);
			WorldTarget = worldTarget;
			if ((object)WorldTarget != null)
			{
				((UnityEngine.Object)WorldTarget).SetName("UI Helper Box");
				if ((object)WorldTarget != null)
				{
					Transform transform = WorldTarget.transform;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					goto IL_0181;
				}
			}
			goto IL_011a;
		}
		goto IL_0181;
		IL_011a:
		throw new NullReferenceException();
		IL_0181:
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		if ((object)gameObject != null)
		{
			Transform transform2 = gameObject.transform;
			Transform parent = base.transform;
			if ((object)transform2 != null)
			{
				transform2.parent = parent;
				Canvas componentInParent = GetComponentInParent<Canvas>();
				_canvas = componentInParent;
				return;
			}
		}
		goto IL_011a;
	}

	private unsafe void Update()
	{
		//IL_0082->IL004c: Incompatible stack heights: 1 vs 0
		if (_ShowDebug)
		{
			Transform transform = WorldTarget.transform;
			Vector3 worldPositionFromUIElement = GetWorldPositionFromUIElement(rTrans);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		}
	}

	public unsafe static Vector3 GetWorldPosition(Vector2 pos)
	{
		//IL_0059: Expected native int or pointer, but got O
		//IL_0067: Expected native int or pointer, but got O
		Camera main = Camera.main;
		bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
		Vector3 position = default(Vector3);
		float ret;
		Camera.ScreenToWorldPoint_Injected(((UnityEngine.Object)main).m_CachedPtr, ref position, Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)(&ret));
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = ret;
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public unsafe static Vector3 GetWorldPositionFromUIElement(RectTransform rTransform)
	{
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected O, but got Unknown
		//IL_0322: Expected O, but got I
		//IL_033f: Expected O, but got I
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected O, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Expected O, but got Unknown
		//IL_03fd: Expected F4, but got I
		//IL_03f8: Expected native int or pointer, but got O
		//IL_0412: Expected F4, but got I
		//IL_040d: Expected native int or pointer, but got O
		//IL_01a4->IL0115: Incompatible stack heights: 1 vs 0
		//IL_0246->IL0115: Incompatible stack heights: 2 vs 0
		//IL_007a->IL0115: Incompatible stack heights: 2 vs 0
		//IL_00a9->IL0115: Incompatible stack heights: 2 vs 0
		//IL_02b6->IL0115: Incompatible stack heights: 3 vs 0
		//IL_00dd->IL0115: Incompatible stack heights: 3 vs 0
		//IL_0382->IL0115: Incompatible stack heights: 4 vs 0
		Camera main = Camera.main;
		if ((object)rTransform != null)
		{
			Transform transform = rTransform.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 64;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
				if ((object)main != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
					_ = 0;
					_ = 0;
					_ = 0;
					bool flag2 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
					object obj3 = obj2 - 80;
					object obj4 = obj2 - 48;
					Camera.WorldToScreenPoint_Injected(((UnityEngine.Object)main).m_CachedPtr, ref *(Vector3*)obj4, Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)obj3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-48]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-50]");
					_ = 0;
					UIPositionHelper instance = Instance;
					if ((object)Instance != null && (object)instance._canvas != null)
					{
						Transform transform2 = instance._canvas.transform;
						if ((object)transform2 != null)
						{
							_ = 0;
							_ = 0;
							bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							object obj5 = obj2 - 80;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj5);
							Camera main2 = Camera.main;
							if ((object)main2 != null)
							{
								Transform transform3 = main2.transform;
								if ((object)transform3 != null)
								{
									_ = 0;
									_ = 0;
									bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									object obj6 = obj2 - 64;
									Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj6);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-4C]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-3C]");
									object obj7 = num - 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-48]");
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
									object obj8 = num2 - 0;
									object obj9 = obj2 - 48;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A8670");
									Camera main3 = Camera.main;
									if ((object)main3 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
										_ = 0;
										_ = 0;
										_ = 0;
										bool flag5 = ((UnityEngine.Object)main3).m_CachedPtr == (IntPtr)0;
										object obj10 = obj2 - 64;
										object obj11 = obj2 - 32;
										Camera.ScreenToWorldPoint_Injected(((UnityEngine.Object)main3).m_CachedPtr, ref *(Vector3*)obj11, Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)obj10);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
										Vector3 vector = default(Vector3);
										((Vector3*)(nint)vector)->x = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
										((Vector3*)(nint)vector)->z = 0f;
										return vector;
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

	public static float GetYPositionFromScreenPosition(float screenPosY)
	{
		//IL_004b: Expected O, but got F4
		//IL_0087: Expected O, but got I
		UIPositionHelper instance = Instance;
		if ((object)Instance != null && (object)instance._PositionHelperTarget != null)
		{
			Vector2 anchoredPosition = instance._PositionHelperTarget.anchoredPosition;
			float num = default(float);
			instance._PositionHelperTarget.anchoredPosition = (Vector2)num;
			RectTransform instance2 = (RectTransform)(object)Instance;
			if ((object)Instance != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v5 (UnityEngine.RectTransform)+28]");
				RectTransform rectTransform = (RectTransform)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v5 (UnityEngine.RectTransform)+28]");
				if ((nint)0 != 0)
				{
					bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Vector3 _);
					float result = default(float);
					return result;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static float GetXPositionFromScreenPosition(float screenPosX)
	{
		//IL_0087: Expected O, but got I
		UIPositionHelper instance = Instance;
		if ((object)Instance != null && (object)instance._PositionHelperTarget != null)
		{
			Vector2 anchoredPosition = instance._PositionHelperTarget.anchoredPosition;
			Vector2 anchoredPosition2 = default(Vector2);
			instance._PositionHelperTarget.anchoredPosition = anchoredPosition2;
			RectTransform instance2 = (RectTransform)(object)Instance;
			if ((object)Instance != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v5 (UnityEngine.RectTransform)+28]");
				RectTransform rectTransform = (RectTransform)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v5 (UnityEngine.RectTransform)+28]");
				if ((nint)0 != 0)
				{
					bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					float ret;
					Transform.get_position_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out *(Vector3*)(&ret));
					return ret;
				}
			}
		}
		throw new NullReferenceException();
	}

	public static float ScreenWidth()
	{
		//IL_002e: Expected F4, but got O
		UIPositionHelper instance = Instance;
		RectTransform component = instance._canvas.GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		return (float)sizeDelta;
	}

	public static float ScreenHeight()
	{
		UIPositionHelper instance = Instance;
		RectTransform component = instance._canvas.GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		float result = default(float);
		return result;
	}

	public UIPositionHelper()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
