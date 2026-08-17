using System;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using Doozy.Engine.UI.Base;
using Doozy.Engine.UI.Settings;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Doozy.Engine.UI;

public class UICanvas : UIComponentBase<UICanvas>
{
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public string canvasName;

		internal unsafe bool _003CDatabaseContains_003Eb__0(UICanvas t)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if ((object)t != null)
			{
				string text = t.CanvasName;
				if (t.CanvasName != null)
				{
					string text2 = canvasName;
					if ((object)t.CanvasName != canvasName)
					{
						if (canvasName != null && text._stringLength == text2._stringLength)
						{
							ref byte second = ref *(byte*)(canvasName + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(t.CanvasName + 20), ref second, length);
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public string canvasName;

		internal unsafe bool _003CGetUICanvas_003Eb__0(UICanvas t)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if ((object)t != null)
			{
				string text = t.CanvasName;
				if (t.CanvasName != null)
				{
					string text2 = canvasName;
					if ((object)t.CanvasName != canvasName)
					{
						if (canvasName != null && text._stringLength == text2._stringLength)
						{
							ref byte second = ref *(byte*)(canvasName + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(t.CanvasName + 20), ref second, length);
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private static UICanvas _003CMasterCanvas_003Ek__BackingField;

	public string CanvasName;

	public bool CustomCanvasName;

	public bool DontDestroyCanvasOnLoad;

	private Canvas m_canvas;

	public static string DefaultCanvasCategory
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "General";
		}
	}

	public static string DefaultCanvasName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068B]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Unnamed";
		}
	}

	public static UICanvas MasterCanvas
	{
		get
		{
			return _003CMasterCanvas_003Ek__BackingField;
		}
		private set
		{
			_003CMasterCanvas_003Ek__BackingField = value;
		}
	}

	public static string MasterCanvasName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "MasterCanvas";
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
				object obj = this + 104;
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

	public unsafe bool IsMasterCanvas
	{
		get
		{
			//IL_0165: Expected I4, but got O
			//IL_01c4: Expected O, but got I4
			//IL_01de: Expected O, but got I4
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected Ref, but got Unknown
			//IL_00a0: Expected I8, but got I4
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected Ref, but got Unknown
			string canvasName = CanvasName;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			object obj = "MasterCanvas";
			if (CanvasName != null)
			{
				if ((object)CanvasName != "MasterCanvas")
				{
					if ("MasterCanvas" != null)
					{
						int stringLength = canvasName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v1+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(CanvasName + 20);
							ulong length = (ulong)(canvasName._stringLength + canvasName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("MasterCanvas" + 20), length))
							{
								goto IL_00d8;
							}
						}
					}
					return false;
				}
				goto IL_00d8;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_00d8:
			UICanvas masterCanvas = GetMasterCanvas();
			bool flag = (object)masterCanvas == null;
			bool flag2 = (object)this == null;
			object obj2 = flag2 & flag;
			bool flag3 = obj2 == null;
			object obj3 = !flag3;
			if (obj3 == null)
			{
				if ((object)masterCanvas != null)
				{
					object obj4 = (object)masterCanvas - (object)this;
					return obj4 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UICanvas)+10]");
				return (nint)0 == 0;
			}
			return true;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0069: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UICanvas)+20]");
			if ((nint)0 != 0)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugUICanvas;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected override void Reset()
	{
		UICanvasSettings instance = UICanvasSettings.Instance;
		DontDestroyCanvasOnLoad = instance.DontDestroyCanvasOnLoad;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CanvasName = "Unnamed";
	}

	public unsafe override void Awake()
	{
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected Ref, but got Unknown
		//IL_01b8: Expected I8, but got I4
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected Ref, but got Unknown
		string message;
		if (!DatabaseContains(CanvasName))
		{
			base.Awake();
			Canvas canvas = Canvas;
			string text;
			string text2;
			string text3;
			if ((object)canvas != null && ((UnityEngine.Object)canvas).m_CachedPtr != (IntPtr)0)
			{
				Canvas canvas2 = Canvas;
				if (canvas2.isRootCanvas)
				{
					bool flag = !DontDestroyCanvasOnLoad;
					UnityEngine.Object obj = canvas2;
					if (!flag)
					{
						GameObject gameObject = base.gameObject;
						UnityEngine.Object.DontDestroyOnLoad(gameObject);
						obj = gameObject;
					}
					string canvasName = CanvasName;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
					if ((nint)0 == 0)
					{
						_ = 1;
						obj = (UnityEngine.Object)(object)"MasterCanvas";
					}
					ref byte reference = ref *(byte*)"MasterCanvas";
					bool flag2 = (object)CanvasName == "MasterCanvas";
					ref byte reference2 = ref *(byte*)"MasterCanvas";
					ref byte reference3 = ref *(byte*)obj;
					if (!flag2)
					{
						if ("MasterCanvas" == null)
						{
							return;
						}
						int stringLength = canvasName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v25 (System.Byte&)+10]");
						if ((nint)stringLength != 0)
						{
							return;
						}
						reference3 = ref *(byte*)(CanvasName + 20);
						ulong length = (ulong)(canvasName._stringLength + canvasName._stringLength);
						if (!System.SpanHelpers.SequenceEqual(ref reference3, ref *(byte*)("MasterCanvas" + 20), length))
						{
							return;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB150");
					object obj2 = default(object);
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ rax_v35+10]");
						if ((nint)0 != 0)
						{
							return;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB190");
					return;
				}
				text = GetName();
				text2 = " gameObject, is to a root canvas. The UICanvas component must be attached to a top (root) canvas in the Hierarchy.";
				text3 = "The Canvas, attached to the ";
			}
			else
			{
				text = GetName();
				text2 = " gameObject, does not have a Canvas component attached. Fix this by adding a Canvas component.";
				text3 = "The UICanvas, attached to the ";
			}
			message = text3 + text + text2;
		}
		else
		{
			string[] array = new string[5];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string text4 = GetName();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			message = string.Concat(array);
		}
		DDebug.LogError(message, this);
		GameObject gameObject2 = base.gameObject;
		gameObject2.SetActive(value: false);
	}

	public unsafe static UICanvas CreateUICanvas(string canvasName)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_014e: Expected I, but got O
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_01d9: Expected I, but got O
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_026c: Expected I, but got O
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_02ff: Expected I, but got O
		//IL_05eb: Expected O, but got I4
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected Ref, but got Unknown
		//IL_0483: Expected I8, but got I4
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Expected Ref, but got Unknown
		//IL_056d->IL0513: Incompatible stack heights: 1 vs 0
		//IL_058f->IL0513: Incompatible stack heights: 1 vs 0
		//IL_0171->IL0171: Incompatible stack heights: 2 vs 1
		//IL_0209->IL0594: Incompatible stack heights: 2 vs 1
		//IL_029c->IL05a3: Incompatible stack heights: 2 vs 1
		//IL_0363->IL0513: Incompatible stack heights: 1 vs 0
		//IL_032a->IL032a: Incompatible stack heights: 2 vs 1
		//IL_038d->IL0513: Incompatible stack heights: 1 vs 0
		//IL_03ca->IL0513: Incompatible stack heights: 1 vs 0
		EventSystem unityEventSystem = UIComponentBase<UICanvas>.UnityEventSystem;
		UICanvas uICanvas;
		bool flag9;
		if ((object)unityEventSystem != null)
		{
			Transform transform = unityEventSystem.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
				if (canvasName != null)
				{
					string text = canvasName.TrimWhiteSpaceHelper(string.TrimType.Both);
					if (text != null && text._stringLength > 0)
					{
						if (!DatabaseContains(text))
						{
							Type[] array = new Type[4];
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
							object obj2 = default(object);
							object obj = obj2 + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
							Transform transform3 = default(Transform);
							Transform transform2 = transform3;
							if (array != null)
							{
								if ((object)transform2 != null)
								{
									nint num = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj3 = default(object);
									bool flag2 = obj3 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
								object obj5 = default(object);
								object obj4 = obj5 + 32;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
								Transform transform4 = default(Transform);
								bool flag3 = (object)transform4 == null;
								Transform transform5 = transform4;
								if (!flag3)
								{
									nint num2 = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj6 = default(object);
									bool flag4 = obj6 == null;
									transform5 = transform4;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
								object obj8 = default(object);
								object obj7 = obj8 + 32;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
								Transform transform6 = default(Transform);
								bool flag5 = (object)transform6 == null;
								Transform transform7 = transform6;
								if (!flag5)
								{
									nint num3 = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj9 = default(object);
									bool flag6 = obj9 == null;
									transform7 = transform6;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								Transform transform8 = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
								object obj11 = default(object);
								object obj10 = obj11 + 32;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
								Transform transform9 = default(Transform);
								bool flag7 = (object)transform9 == null;
								transform8 = transform9;
								if (!flag7)
								{
									nint num4 = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj12 = default(object);
									bool flag8 = obj12 == null;
									transform8 = transform9;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								GameObject gameObject = new GameObject(text, array);
								if ((object)gameObject != null)
								{
									Canvas component = gameObject.GetComponent<Canvas>();
									if ((object)component != null)
									{
										component.renderMode = RenderMode.ScreenSpaceOverlay;
										uICanvas = gameObject.AddComponent<UICanvas>();
										if ((object)uICanvas != null)
										{
											uICanvas.CanvasName = text;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											object obj13 = "MasterCanvas";
											if ((object)text != "MasterCanvas")
											{
												if ("MasterCanvas" != null)
												{
													int stringLength = text._stringLength;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v979 @ rdx_v38+10]");
													if ((nint)stringLength == 0)
													{
														ref byte first = ref *(byte*)(text + 20);
														ulong length = (ulong)(text._stringLength + text._stringLength);
														flag9 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("MasterCanvas" + 20), length);
														goto IL_05dd;
													}
												}
												flag9 = false;
											}
											else
											{
												flag9 = true;
											}
											goto IL_05dd;
										}
									}
								}
							}
							goto IL_0513;
						}
						string message = "Cannot create a new UICanvas with the '" + text + "' canvasName because another UICanvas with the same name already exists in the UICanvas.Database. Returned the existing UICanvas instead.";
						DDebug.Log(message);
						uICanvas = GetUICanvas(text);
					}
					else
					{
						DDebug.Log("You cannot create a new UICanvas without entering a 'canvasName'. The 'canvasName' you passed was an empty string. No UICanvas was created and returned null.");
						uICanvas = null;
					}
					goto IL_05f5;
				}
			}
		}
		goto IL_0513;
		IL_05f5:
		return uICanvas;
		IL_05dd:
		object obj14 = (flag9 ? 1 : 0) ^ 1;
		goto IL_05f5;
		IL_0513:
		throw new NullReferenceException();
	}

	public unsafe static bool DatabaseContains(string canvasName)
	{
		//IL_002f: Expected I4, but got O
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass23_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.canvasName = canvasName;
			Func<UICanvas, bool> predicate = delegate(UICanvas t)
			{
				//IL_012f: Expected I4, but got O
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d1: Expected Ref, but got Unknown
				//IL_00e8: Expected I8, but got I4
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Expected Ref, but got Unknown
				if ((object)t != null)
				{
					string canvasName2 = t.CanvasName;
					if (t.CanvasName != null)
					{
						string canvasName3 = CS_0024_003C_003E8__locals6.canvasName;
						if ((object)t.CanvasName != CS_0024_003C_003E8__locals6.canvasName)
						{
							if (CS_0024_003C_003E8__locals6.canvasName != null && canvasName2._stringLength == canvasName3._stringLength)
							{
								ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals6.canvasName + 20);
								ulong length = (ulong)(canvasName2._stringLength + canvasName2._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(t.CanvasName + 20), ref second, length);
							}
							return false;
						}
						return true;
					}
				}
				NullReferenceException ex2 = new NullReferenceException();
				return (byte)(int)ex2 != 0;
			};
			return Enumerable.Any(UIComponentBase<UICanvas>.Database, predicate);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static UICanvas GetMasterCanvas(bool createMasterCanvasIfNotFound = true)
	{
		UICanvas uICanvas = _003CMasterCanvas_003Ek__BackingField;
		if ((object)_003CMasterCanvas_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rbx_v1 (Doozy.Engine.UI.UICanvas)+10]");
			if ((nint)0 != 0)
			{
				goto IL_01bc;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = DatabaseContains("MasterCanvas");
		if (!flag)
		{
			if (createMasterCanvasIfNotFound)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
				if ((nint)0 == (flag ? 1 : 0))
				{
					_ = 1;
				}
				UICanvas uICanvas2 = CreateUICanvas("MasterCanvas");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB190");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB150");
				object obj = default(object);
				if (obj != null)
				{
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB150");
					UICanvas result = default(UICanvas);
					return result;
				}
				return (UICanvas)(object)new NullReferenceException();
			}
			return null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UICanvas uICanvas3 = GetUICanvas("MasterCanvas");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB190");
		goto IL_01bc;
		IL_01bc:
		return _003CMasterCanvas_003Ek__BackingField;
	}

	public unsafe static UICanvas GetUICanvas(string canvasName)
	{
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass25_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.canvasName = canvasName;
			Func<UICanvas, bool> predicate = delegate(UICanvas t)
			{
				//IL_012f: Expected I4, but got O
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d1: Expected Ref, but got Unknown
				//IL_00e8: Expected I8, but got I4
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Expected Ref, but got Unknown
				if ((object)t != null)
				{
					string canvasName2 = t.CanvasName;
					if (t.CanvasName != null)
					{
						string canvasName3 = CS_0024_003C_003E8__locals6.canvasName;
						if ((object)t.CanvasName != CS_0024_003C_003E8__locals6.canvasName)
						{
							if (CS_0024_003C_003E8__locals6.canvasName != null && canvasName2._stringLength == canvasName3._stringLength)
							{
								ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals6.canvasName + 20);
								ulong length = (ulong)(canvasName2._stringLength + canvasName2._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(t.CanvasName + 20), ref second, length);
							}
							return false;
						}
						return true;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			};
			return (UICanvas)Enumerable.FirstOrDefault(UIComponentBase<UICanvas>.Database, (Func<object, bool>)predicate);
		}
		return (UICanvas)(object)new NullReferenceException();
	}

	public static UICanvas GetUICanvas(string canvasName, bool createUICanvasIfNotFound, bool returnMasterCanvasIfUICanvasNotFound = true)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980697]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (canvasName != null)
		{
			string text = canvasName.TrimWhiteSpaceHelper(string.TrimType.Both);
			if (text != null && text._stringLength > 0)
			{
				if (DatabaseContains(text))
				{
					return GetUICanvas(text);
				}
				if (createUICanvasIfNotFound)
				{
					return CreateUICanvas(text);
				}
				if (returnMasterCanvasIfUICanvasNotFound)
				{
					return GetMasterCanvas();
				}
			}
			else
			{
				DDebug.Log("You cannot search for an UICanvas without entering a 'canvasName'. The 'canvasName' you passed was an empty string. Returned null.");
			}
			return null;
		}
		return (UICanvas)(object)new NullReferenceException();
	}

	public UICanvas()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CanvasName = "Unnamed";
		CustomCanvasName = true;
		base._002Ector();
	}
}
