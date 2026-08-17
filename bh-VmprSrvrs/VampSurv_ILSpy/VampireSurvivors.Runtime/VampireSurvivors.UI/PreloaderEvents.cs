using System;
using Cpp2ILInjected;

namespace VampireSurvivors.UI;

public static class PreloaderEvents
{
	private static Action<string> m_UpdateText;

	private static Action<string> m_UpdateExtraText;

	public static event Action<string> UpdateText
	{
		add
		{
			Delegate obj = PreloaderEvents.m_UpdateText;
			Action<string> action = default(Action<string>);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				Action<string> updateText;
				if ((object)obj2 == null)
				{
					updateText = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = action == null;
					updateText = action;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = (object)obj == PreloaderEvents.m_UpdateText;
				Delegate obj3;
				if ((object)obj == PreloaderEvents.m_UpdateText)
				{
					PreloaderEvents.m_UpdateText = updateText;
					obj3 = obj;
				}
				else
				{
					obj3 = PreloaderEvents.m_UpdateText;
				}
				Delegate obj4 = obj;
				if (!flag2)
				{
					obj4 = obj3;
				}
				bool flag3 = (object)obj4 != obj;
				obj = obj4;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			Delegate obj = PreloaderEvents.m_UpdateText;
			Action<string> action = default(Action<string>);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				Action<string> updateText;
				if ((object)obj2 == null)
				{
					updateText = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = action == null;
					updateText = action;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = (object)obj == PreloaderEvents.m_UpdateText;
				Delegate obj3;
				if ((object)obj == PreloaderEvents.m_UpdateText)
				{
					PreloaderEvents.m_UpdateText = updateText;
					obj3 = obj;
				}
				else
				{
					obj3 = PreloaderEvents.m_UpdateText;
				}
				Delegate obj4 = obj;
				if (!flag2)
				{
					obj4 = obj3;
				}
				bool flag3 = (object)obj4 != obj;
				obj = obj4;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public static event Action<string> UpdateExtraText
	{
		add
		{
			//IL_000e: Expected O, but got I4
			//IL_0050: Expected I, but got O
			//IL_0066: Expected O, but got I
			Delegate obj = PreloaderEvents.m_UpdateExtraText;
			object obj4 = default(object);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				object obj3;
				if ((object)obj2 == null)
				{
					obj3 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj4 == null;
					obj3 = obj4;
					if (flag)
					{
						break;
					}
				}
				nint num = (nint)typeof(PreloaderEvents);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v6 (Il2CppClass<VampireSurvivors.UI.PreloaderEvents>)+B8]");
				object obj5 = (nint)0 + (nint)8;
				bool flag2 = obj == obj5;
				Delegate obj6;
				if (obj == obj5)
				{
					obj5 = obj3;
					obj6 = obj;
				}
				else
				{
					obj6 = (Delegate)obj5;
				}
				Delegate obj7 = obj;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj;
				obj = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_000e: Expected O, but got I4
			//IL_0050: Expected I, but got O
			//IL_0066: Expected O, but got I
			Delegate obj = PreloaderEvents.m_UpdateExtraText;
			object obj4 = default(object);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				object obj3;
				if ((object)obj2 == null)
				{
					obj3 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj4 == null;
					obj3 = obj4;
					if (flag)
					{
						break;
					}
				}
				nint num = (nint)typeof(PreloaderEvents);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v6 (Il2CppClass<VampireSurvivors.UI.PreloaderEvents>)+B8]");
				object obj5 = (nint)0 + (nint)8;
				bool flag2 = obj == obj5;
				Delegate obj6;
				if (obj == obj5)
				{
					obj5 = obj3;
					obj6 = obj;
				}
				else
				{
					obj6 = (Delegate)obj5;
				}
				Delegate obj7 = obj;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj;
				obj = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public static void FireUpdateText(string text)
	{
		if (PreloaderEvents.m_UpdateText != null)
		{
			Action<string> updateText = PreloaderEvents.m_UpdateText;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v42 @ r9_v1 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		}
	}

	public static void FireUpdateExtraText(string text)
	{
		if (PreloaderEvents.m_UpdateExtraText != null)
		{
			Action<string> updateExtraText = PreloaderEvents.m_UpdateExtraText;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v42 @ r9_v1 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		}
	}
}
