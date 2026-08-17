using System;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using UnityEngine;

public class DebugGUIExamples : MonoBehaviour
{
	private float SinField;

	private float mouseX;

	private float mouseY;

	private float CosProperty
	{
		get
		{
			//IL_000e: Expected O, but got F4
			object obj = Time.time;
			float num = default(float);
			float result = num * 6f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			return result;
		}
	}

	private float SinProperty
	{
		get
		{
			//IL_000e: Expected O, but got F4
			object obj = Time.time;
			float num2 = default(float);
			float num = num2 + (float)Math.PI / 2f;
			float result = num * 6f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			return result;
		}
	}

	private void Awake()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1A2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = "Hello! I will disappear in five seconds!";
		if (DebugGUI.LogsEnabled)
		{
			DebugGUI instance = DebugGUI.Instance;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v127 @ rdx_v6+168] (should have been resolved before IL gen)");
			string str = default(string);
			instance.InstanceLog(str);
		}
		int num = default(int);
		Color color = default(Color);
		bool autoScale = default(bool);
		DebugGUI.SetGraphProperties("smoothFrameRate", "SmoothFPS", 0f, 200f, num, color, autoScale);
		DebugGUI.SetGraphProperties("frameRate", "FPS", 0f, 200f, num, color, autoScale);
		DebugGUI.SetGraphProperties("fixedFrameRateSin", "FixedSin", -1f, 1f, num, color, autoScale);
	}

	private unsafe void Update()
	{
		//IL_0312: Expected O, but got F4
		//IL_0344: Expected O, but got I4
		//IL_036b: Expected F4, but got I4
		//IL_01ec: Expected O, but got I4
		//IL_021b: Expected O, but got F4
		//IL_005c: Expected Ref, but got F4
		//IL_007b: Expected Ref, but got F4
		//IL_00a4: Expected O, but got Ref
		//IL_00ca: Expected F4, but got I4
		//IL_00d3: Expected F4, but got I4
		//IL_0239: Expected O, but got F4
		//IL_0118: Expected F4, but got I4
		//IL_0121: Expected F4, but got I4
		//IL_0257: Expected O, but got F4
		//IL_0260: Invalid comparison between F4 and I4
		//IL_02b6: Expected O, but got F4
		//IL_02bf: Invalid comparison between F4 and I4
		//IL_0288: Expected O, but got F4
		//IL_02e6: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1A3]");
		bool flag = (nint)0 != 0;
		DebugGUIExamples debugGUIExamples = this;
		if (!flag)
		{
			_ = 1;
			debugGUIExamples = (DebugGUIExamples)(object)"FPS: ";
		}
		object obj = Time.time;
		object obj2 = default(object);
		float sinField = (float)obj2 * 6f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		SinField = sinField;
		Input.get_mousePosition_Injected(out Vector3 ret);
		object obj3 = Screen.width;
		float num = (float)ret / (float)obj3;
		mouseX = num;
		Input.get_mousePosition_Injected(out ret);
		float num2 = Screen.height;
		object obj4 = default(object);
		float num3 = (float)obj4 / num2;
		mouseY = num3;
		object obj5 = Input.GetMouseButtonDown(0);
		bool flag2 = obj5 == null;
		float num4 = num2;
		if (!flag2)
		{
			float num5 = (float)this + 36f;
			string arg = ((float*)num5)->ToString("F3");
			float num6 = (float)this + 40f;
			string arg2 = ((float*)num6)->ToString("F3");
			System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
			object obj6 = default(object);
			string text = string.FormatHelper((IFormatProvider)null, "Mouse clicked! ({0}, {1})", (System.ParamsArray)(&obj6));
			bool logsEnabled = DebugGUI.LogsEnabled;
			bool flag3 = !logsEnabled;
			num3 = 0f;
			num4 = 0f;
			if (!flag3)
			{
				DebugGUI instance = DebugGUI.Instance;
				string str = text.ToString();
				instance.InstanceLog(str);
				num3 = 0f;
				num4 = 0f;
			}
		}
		object obj7 = Time.deltaTime;
		float num7 = 1f / num4;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text2 = System.Number.FormatSingle(num7, "F3", currentInfo);
		string message = "SmoothFPS: " + text2;
		DebugGUI.LogPersistent("smoothFrameRate", message);
		object obj8 = Time.smoothDeltaTime;
		float num8 = 1f / num7;
		NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
		string text3 = System.Number.FormatSingle(num8, "F3", currentInfo2);
		string message2 = "FPS: " + text3;
		DebugGUI.LogPersistent("frameRate", message2);
		object obj9 = Time.smoothDeltaTime;
		bool flag4 = num8 == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694C706h\"");
		if (!flag4)
		{
			object obj10 = Time.smoothDeltaTime;
			num3 = 1f / num8;
			DebugGUI.Graph("smoothFrameRate", num3);
		}
		object obj11 = Time.deltaTime;
		bool flag5 = num8 == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694C777h\"");
		if (!flag5)
		{
			object obj12 = Time.deltaTime;
			float val = 1f / num8;
			DebugGUI.Graph("frameRate", val);
		}
	}

	private void FixedUpdate()
	{
		//IL_0041: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1A4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = Time.time;
		object obj2 = default(object);
		float val = (float)obj2 * 6f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		DebugGUI.Graph("fixedFrameRateSin", val);
	}

	private void OnDestroy()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1A5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance = DebugGUI.Instance;
			instance.InstanceRemoveGraph((object)"frameRate");
		}
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance2 = DebugGUI.Instance;
			instance2.InstanceRemoveGraph((object)"fixedFrameRateSin");
		}
		if (DebugGUI.LogsEnabled)
		{
			DebugGUI instance3 = DebugGUI.Instance;
			int num = instance3.persistentLogs.FindEntry((object)"frameRate");
			if (num >= 0)
			{
				bool flag = ((Dictionary<object, object>)(object)instance3.persistentLogs).Remove((object)"frameRate");
			}
		}
	}

	public DebugGUIExamples()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
