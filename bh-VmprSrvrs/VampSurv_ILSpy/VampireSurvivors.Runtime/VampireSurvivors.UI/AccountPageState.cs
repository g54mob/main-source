using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;

namespace VampireSurvivors.UI;

public class AccountPageState
{
	private LoginType loginState;

	private LinkedList<UIState> stateHistory;

	private Dictionary<string, bool> flags;

	public LoginType LoginState => loginState;

	public void SetFlag(string key, bool value)
	{
		bool flag = ((Dictionary<object, bool>)(object)flags).TryInsert((object)key, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
	}

	public bool GetFlag(string key)
	{
		//IL_0045: Expected O, but got I
		//IL_00ca: Expected I4, but got O
		//IL_007f: Expected O, but got I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		Dictionary<string, bool> dictionary = flags;
		int num = flags.FindEntry(key);
		if (num >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v2 (System.Collections.Generic.Dictionary`2<System.String, System.Boolean>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v6+18]");
			if ((nint)num < (nint)0)
			{
				object obj2 = num + 2;
				object obj3 = obj2 * 2;
				object obj4 = obj2 + obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v6+v140 @ rax_v11*8]");
				return false;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public UIState GetState()
	{
		return Enumerable.First(stateHistory);
	}

	public void ClearHistory()
	{
		stateHistory.Clear();
	}

	public unsafe void ChangeStateTo(UIState uiState)
	{
		//IL_011f: Expected O, but got Ref
		//IL_006a: Expected O, but got I
		//IL_007f: Expected O, but got I
		//IL_0145: Expected I, but got O
		//IL_00ca: Expected O, but got Ref
		//IL_00e3: Expected I, but got O
		LinkedList<UIState> linkedList = stateHistory;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+18]");
		bool flag = (nint)0 == 0;
		LinkedList<UIState> linkedList2 = linkedList;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+18]");
			UIState uIState = default(UIState);
			nint num2;
			if ((nint)0 > (nint)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v11+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v11+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v12+10]");
				if (num == 0)
				{
					throw new NullReferenceException();
				}
				object o = uIState;
				IntPtr intPtr = default(IntPtr);
				bool flag2 = ValueType.DefaultEquals((object)(&intPtr), o);
				bool flag3 = !flag2;
				num2 = unchecked((nint)null);
				uIState = uiState;
				if (!flag3)
				{
					GoBack();
					return;
				}
			}
			object o2 = uIState;
			IntPtr intPtr2 = default(IntPtr);
			if (ValueType.DefaultEquals((object)(&intPtr2), o2))
			{
				return;
			}
			linkedList2 = stateHistory;
			num2 = unchecked((nint)null);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB31B0");
	}

	public bool CanGoBack()
	{
		//IL_00b9: Expected I4, but got O
		//IL_001b: Expected O, but got I
		//IL_0031: Expected O, but got I
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		LinkedList<UIState> linkedList = stateHistory;
		if (stateHistory != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+18]");
			object obj = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+18]");
			object obj2 = (nint)0 ^ (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+18]");
			object obj3 = 0 ^ obj;
			object obj4 = obj2 & obj3;
			bool flag = (nint)obj4 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = obj == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void GoBack()
	{
		//IL_0067: Expected O, but got I
		LinkedList<UIState> linkedList = stateHistory;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+10]");
			if ((nint)0 == 0)
			{
				object obj = new InvalidOperationException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
				throw obj;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+10]");
			linkedList.InternalRemoveNode((LinkedListNode<UIState>)0);
		}
	}

	public void GoHome()
	{
		//IL_002f: Expected O, but got I4
		bool flag = loginState == LoginType.LOGGED_OUT;
		if (!flag)
		{
			object obj = loginState - 1;
			if (flag)
			{
				ChangeStateTo(UIState.LOGGED_IN_HOME);
				return;
			}
			if ((nint)obj == 1)
			{
				ChangeStateTo(UIState.UNVERIFIED_HOME);
				return;
			}
		}
		ChangeStateTo(UIState.NOT_LOGGED_IN_HOME);
	}

	public void SetLoginState(LoginType newState)
	{
		loginState = newState;
	}

	private unsafe string StringifyHistory()
	{
		//IL_0068: Expected O, but got I
		//IL_0078: Expected O, but got I
		//IL_00b8: Expected O, but got Ref
		//IL_0200: Expected I, but got O
		//IL_010f: Expected O, but got I
		LinkedList<UIState> linkedList = stateHistory;
		string text;
		if (stateHistory != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+10]");
				bool flag = (nint)0 == 0;
				text = "[";
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v6+20]");
					LinkedListNode<UIState> linkedListNode = (LinkedListNode<UIState>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v6+20]");
					bool flag2 = (nint)0 == 0;
					string text2 = "[";
					text = "[";
					if (!flag2)
					{
						nint num = default(nint);
						while (true)
						{
							string text3 = ((Enum)(&num)).ToString();
							string text4 = text2 + text3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v8 (System.Collections.Generic.LinkedListNode`1<VampireSurvivors.UI.UIState>)+20]");
							bool flag3 = (nint)0 == 0;
							text2 = text4;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v8 (System.Collections.Generic.LinkedListNode`1<VampireSurvivors.UI.UIState>)+10]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v8 (System.Collections.Generic.LinkedListNode`1<VampireSurvivors.UI.UIState>)+10]");
								if ((nint)0 == 0)
								{
									break;
								}
								LinkedListNode<UIState> linkedListNode2 = linkedListNode;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v15+10]");
								bool flag4 = linkedListNode2 == null;
								text2 = text4;
								if (!flag4)
								{
									string text5 = text4 + " -> ";
									text2 = text5;
								}
							}
							LinkedListNode<UIState> previous = linkedListNode.Previous;
							bool flag5 = previous != null;
							num = (nint)typeof(UIState);
							linkedListNode = previous;
							text = text2;
							if (flag5)
							{
								continue;
							}
							goto IL_017f;
						}
						goto IL_019c;
					}
				}
				goto IL_017f;
			}
			return "[]";
		}
		goto IL_019c;
		IL_017f:
		return text + "]";
		IL_019c:
		return (string)(object)new NullReferenceException();
	}

	public AccountPageState()
	{
		LinkedList<UIState> linkedList = null;
		stateHistory = linkedList;
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		flags = dictionary;
	}
}
