using System;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.Orientation;

public class OrientationDetector : MonoBehaviour
{
	private static OrientationDetector s_instance;

	private static bool _003CApplicationIsQuitting_003Ek__BackingField;

	public bool DebugMode;

	public OrientationEvent OnOrientationEvent;

	private DetectedOrientation m_currentOrientation;

	private RectTransform m_rectTransform;

	private Canvas m_canvas;

	private int m_deviceOrientationCheckCount;

	public static OrientationDetector Instance
	{
		get
		{
			OrientationDetector orientationDetector = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)orientationDetector).m_CachedPtr == (IntPtr)0)
			{
				if (_003CApplicationIsQuitting_003Ek__BackingField)
				{
					return null;
				}
				OrientationDetector orientationDetector2 = UnityEngine.Object.FindObjectOfType<OrientationDetector>();
				s_instance = orientationDetector2;
				OrientationDetector orientationDetector3 = s_instance;
				if ((object)s_instance == null || ((UnityEngine.Object)orientationDetector3).m_CachedPtr == (IntPtr)0)
				{
					OrientationDetector orientationDetector4 = DoozyUtils.AddToScene<OrientationDetector>("Orientation Detector", isSingleton: true);
					if ((object)orientationDetector4 == null)
					{
						return (OrientationDetector)(object)new NullReferenceException();
					}
					GameObject target = orientationDetector4.gameObject;
					UnityEngine.Object.DontDestroyOnLoad(target);
				}
			}
			return s_instance;
		}
	}

	public static bool ApplicationIsQuitting
	{
		get
		{
			return _003CApplicationIsQuitting_003Ek__BackingField;
		}
		private set
		{
			_003CApplicationIsQuitting_003Ek__BackingField = value;
		}
	}

	public RectTransform RectTransform
	{
		get
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_015b: Expected O, but got I4
			RectTransform rectTransform = m_rectTransform;
			RectTransform rectTransform2;
			if ((object)m_rectTransform == null || ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0)
			{
				rectTransform2 = GetComponent<RectTransform>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				m_rectTransform = rectTransform2;
				if (flag)
				{
					goto IL_0129;
				}
				object obj = this + 56;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			rectTransform2 = m_rectTransform;
			goto IL_0129;
			IL_0129:
			return rectTransform2;
		}
	}

	public Canvas Canvas
	{
		get
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_015b: Expected O, but got I4
			Canvas canvas = m_canvas;
			Canvas canvas2;
			if ((object)m_canvas == null || ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0)
			{
				canvas2 = GetComponent<Canvas>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				m_canvas = canvas2;
				if (flag)
				{
					goto IL_0129;
				}
				object obj = this + 64;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			canvas2 = m_canvas;
			goto IL_0129;
			IL_0129:
			return canvas2;
		}
	}

	public DetectedOrientation CurrentOrientation => m_currentOrientation;

	private bool DebugComponent
	{
		get
		{
			//IL_0063: Expected I4, but got O
			if (DebugMode)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugOrientationDetector;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected OrientationDetector()
	{
		OrientationEvent orientationEvent = (OrientationEvent)new UnityEventBase();
		_ = 0;
		((UnityEventBase)orientationEvent)._002Ector();
		OnOrientationEvent = orientationEvent;
	}

	private static void RunOnStart()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = false;
	}

	private void Reset()
	{
		Canvas canvas = Canvas;
		bool flag = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 45 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	private void OnValidate()
	{
		Canvas canvas = Canvas;
		bool flag = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 45 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	private void Awake()
	{
		//IL_02f4: Expected O, but got I4
		//IL_030e: Expected O, but got I4
		//IL_0392: Expected O, but got I4
		//IL_03c0: Expected I, but got O
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_03e8->IL028e: Incompatible stack heights: 1 vs 0
		//IL_027b->IL028e: Incompatible stack heights: 1 vs 0
		//IL_019a->IL019a: Incompatible stack heights: 0 vs 1
		OrientationDetector orientationDetector = s_instance;
		if ((object)s_instance != null && ((UnityEngine.Object)orientationDetector).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = (GameObject)(object)s_instance;
			bool flag = (object)s_instance == null;
			bool flag2 = (object)this == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				bool flag4;
				if ((object)this != null)
				{
					if ((object)s_instance != null)
					{
						object obj3 = (object)s_instance - (object)this;
						flag4 = obj3 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					if ((object)s_instance == null)
					{
						goto IL_028e;
					}
					flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj5 = default(object);
					object obj4 = obj5 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					object obj6 = default(object);
					string text;
					string text2 = default(string);
					if (obj6 != null)
					{
						object obj7 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v890 @ rdx_v26+168] (should have been resolved before IL gen)");
						text = "There cannot be two ";
					}
					else
					{
						text = "There cannot be two ";
						text2 = null;
					}
					string message = text + text2 + "' active at the same time. Destroying this one!";
					DDebug.Log(message);
					GameObject obj8 = base.gameObject;
					UnityEngine.Object.Destroy(obj8, 0f);
					return;
				}
			}
		}
		s_instance = this;
		GameObject target = base.gameObject;
		UnityEngine.Object.DontDestroyOnLoad(target);
		Canvas canvas = Canvas;
		if ((object)canvas != null)
		{
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			Canvas canvas2 = Canvas;
			if ((object)canvas2 != null)
			{
				bool flag5 = ((UnityEngine.Object)canvas2).m_CachedPtr == (IntPtr)0;
				object obj9 = Canvas.get_isRootCanvas_Injected(((UnityEngine.Object)canvas2).m_CachedPtr);
				if (obj9 != null)
				{
					return;
				}
				RectTransform rectTransform = RectTransform;
				nint num = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rcx_v27 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num2 = 0;
				if ((object)rectTransform != null)
				{
					Vector2 anchorMin = default(Vector2);
					rectTransform.anchorMin = anchorMin;
					RectTransform rectTransform2 = RectTransform;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B80A30");
					if ((object)rectTransform2 != null)
					{
						Vector2 anchorMax = default(Vector2);
						rectTransform2.anchorMax = anchorMax;
						return;
					}
				}
			}
		}
		goto IL_028e;
		IL_028e:
		throw new NullReferenceException();
	}

	private void OnEnable()
	{
		CheckDeviceOrientation();
	}

	private void Update()
	{
		if (m_currentOrientation == DetectedOrientation.Unknown)
		{
			CheckDeviceOrientation();
		}
	}

	private void OnRectTransformDimensionsChange()
	{
		CheckDeviceOrientation();
	}

	private void OnApplicationQuit()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = true;
	}

	public void CheckDeviceOrientation(bool forceUpdate = false)
	{
		//IL_0100: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		object obj = Screen.GetScreenOrientation();
		bool forceUpdate2;
		DetectedOrientation newOrientation;
		if ((nint)obj != 3)
		{
			object obj2 = Screen.GetScreenOrientation();
			if ((nint)obj2 != 3)
			{
				object obj3 = Screen.GetScreenOrientation();
				if ((nint)obj3 != 4)
				{
					ScreenOrientation screenOrientation = Screen.GetScreenOrientation();
					if (screenOrientation != ScreenOrientation.Portrait)
					{
						ScreenOrientation screenOrientation2 = Screen.GetScreenOrientation();
						if (screenOrientation2 != ScreenOrientation.PortraitUpsideDown)
						{
							forceUpdate2 = false;
							goto IL_0169;
						}
					}
					bool flag = m_currentOrientation == DetectedOrientation.Portrait;
					bool flag2 = forceUpdate;
					if (!flag)
					{
						flag2 = true;
					}
					if (flag2)
					{
						newOrientation = DetectedOrientation.Portrait;
						forceUpdate2 = forceUpdate;
						goto IL_0190;
					}
					return;
				}
			}
		}
		bool flag3 = m_currentOrientation == DetectedOrientation.Landscape;
		bool flag4 = forceUpdate;
		if (!flag3)
		{
			flag4 = true;
		}
		if (flag4)
		{
			forceUpdate2 = forceUpdate;
			goto IL_0169;
		}
		return;
		IL_0169:
		newOrientation = DetectedOrientation.Landscape;
		goto IL_0190;
		IL_0190:
		ChangeOrientation(newOrientation, forceUpdate2);
	}

	public unsafe void ChangeOrientation(DetectedOrientation newOrientation, bool forceUpdate = false)
	{
		//IL_001d: Expected O, but got Ref
		//IL_00c1: Expected O, but got Ref
		m_currentOrientation = newOrientation;
		((UnityEvent<System.Int32Enum>)(object)OnOrientationEvent).Invoke((System.Int32Enum)newOrientation);
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		string text2 = "DetectedOrientation." + text;
		string messageName = "typeless " + text2;
		Message.SendMessage<Message>(messageName, (Message)null);
		int deviceOrientationCheckCount = m_deviceOrientationCheckCount + 1;
		m_deviceOrientationCheckCount = deviceOrientationCheckCount;
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugOrientationDetector)
			{
				return;
			}
		}
		string text3 = ((Enum)(&intPtr)).ToString();
		string message = "Current device orientation: " + text3;
		DDebug.Log(message, this);
	}

	private static OrientationDetector AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<OrientationDetector>("Orientation Detector", isSingleton: true, selectGameObjectAfterCreation);
	}
}
