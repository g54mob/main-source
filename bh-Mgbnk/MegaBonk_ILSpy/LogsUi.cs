using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Menu.Windows;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class LogsUi : MonoBehaviour
{
	public RectTransform content;

	public RectTransform entryPrefab;

	private List<MyButtonLog> logEntries;

	private int page;

	private int maxPages;

	private int entriesPerPage;

	private List<EEnemy> enemies;

	public TextMeshProUGUI t_pages;

	public TextMeshProUGUI t_title;

	public TabsExplicitNavigation entryNavigation;

	private bool hasRefreshed;

	public LogsDisplayEnemy logDisplay;

	private void LateUpdate()
	{
		if (!hasRefreshed)
		{
			hasRefreshed = true;
			TryInit();
			OpenPage(0, force: true);
			MyButtonLog firstButton = logEntries.get_Item(0);
			ButtonManager.SetFirstButton(firstButton);
			MyButtonLog myButtonLog = logEntries.get_Item(0);
			logDisplay.SetEnemy(myButtonLog.eEnemy);
		}
	}

	private void OnDisable()
	{
		hasRefreshed = false;
	}

	private void TryInit()
	{
		//IL_00c7: Expected I4, but got F8
		//IL_00e0: Invalid comparison between F8 and I4
		//IL_00ee: Expected I, but got O
		//IL_00f3: Expected I, but got O
		//IL_00fc: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		//IL_019e: Expected O, but got I4
		//IL_025e: Expected I4, but got F8
		Transform root = base.transform;
		UiUtility.RebuildUi(root);
		List<MyButtonLog> list = logEntries;
		if (list._size <= 0)
		{
			MyButtonLog component = entryPrefab.GetComponent<MyButtonLog>();
			list.Add(component);
			MyButtonLog myButtonLog = logEntries.get_Item(0);
			myButtonLog.StopHover();
		}
		Rect rect = content.rect;
		Rect rect2 = entryPrefab.rect;
		float num = rect.m_Height / rect2.m_Height;
		double num2 = Math.Floor(num);
		entriesPerPage = (int)num2;
		double num3 = num2 - 1.0;
		bool flag = !(num3 > 0.0);
		nint num4 = unchecked((nint)null);
		nint num5 = unchecked((nint)null);
		object obj = 0;
		if (!flag)
		{
			bool flag2;
			do
			{
				List<MyButtonLog> list2 = logEntries;
				object obj2 = list2._size - 1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					RectTransform rectTransform = UnityEngine.Object.Instantiate(entryPrefab, content);
					MyButtonLog component2 = rectTransform.GetComponent<MyButtonLog>();
					logEntries.Add(component2);
					num5 = 0;
				}
				obj++;
				object obj3 = entriesPerPage - 1;
				flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
				num4 = num5;
			}
			while (flag2);
		}
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EEnemy));
		Array values = Enum.GetValues(typeFromHandle);
		IEnumerable<System.Int32Enum> source = Enumerable.Cast<System.Int32Enum>(values);
		List<System.Int32Enum> list3 = Enumerable.ToList(source);
		enemies = (List<EEnemy>)(object)list3;
		List<EEnemy> list4 = enemies;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v36 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
		double a = 0.0 / (double)entriesPerPage;
		double num6 = Math.Ceiling(a);
		maxPages = (int)num6;
		int numUnlockedEntries = LogUtility.GetNumUnlockedEntries();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		int numMaxEntries = LogUtility.GetNumMaxEntries();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text = $"Monster log [{arg}/{arg2}]";
		t_title.text = text;
	}

	private void Refresh()
	{
		TryInit();
		OpenPage(0, force: true);
		MyButtonLog firstButton = logEntries.get_Item(0);
		ButtonManager.SetFirstButton(firstButton);
		MyButtonLog myButtonLog = logEntries.get_Item(0);
		logDisplay.SetEnemy(myButtonLog.eEnemy);
	}

	private void OpenPage(int page, bool force = false)
	{
		//IL_0298: Expected O, but got I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected I4, but got Unknown
		//IL_011f: Expected I, but got O
		bool flag = default(bool);
		if (this.page == page && !flag)
		{
			return;
		}
		bool flag2 = page >= 0;
		int num = page;
		if (!flag2)
		{
			num = maxPages - 1;
		}
		bool flag3 = num >= maxPages;
		int num2 = 0;
		if (!flag3)
		{
			num2 = num;
		}
		this.page = num2;
		object obj = num2 * entriesPerPage;
		bool flag4 = entriesPerPage <= 0;
		IntPtr intPtr = default(IntPtr);
		nint num3 = intPtr;
		int num4 = 0;
		if (!flag4)
		{
			do
			{
				List<EEnemy> list = enemies;
				int num5 = num4 + obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v4 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
				if ((nint)num5 < (nint)0)
				{
					MyButtonLog myButtonLog = logEntries.get_Item(num4);
					GameObject gameObject = myButtonLog.gameObject;
					gameObject.SetActive(value: true);
					MyButtonLog myButtonLog2 = logEntries.get_Item(num4);
					EEnemy enemy = enemies.get_Item(num5);
					myButtonLog2.SetEnemy(enemy, num5);
					num3 = unchecked((nint)null);
					flag = (byte)num5 != 0;
				}
				else
				{
					MyButtonLog myButtonLog3 = logEntries.get_Item(num4);
					GameObject gameObject2 = myButtonLog3.gameObject;
					gameObject2.SetActive(value: false);
					flag = false;
				}
				num4++;
			}
			while (num4 < entriesPerPage);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831730D9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text = $"{arg}/{arg2}";
		t_pages.text = text;
		entryNavigation.Refresh();
	}

	public void FlipPage(int direction)
	{
		int num = direction + page;
		OpenPage(num);
	}

	private void UpdatePageText()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831730D9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text = $"{arg}/{arg2}";
		t_pages.text = text;
	}

	public LogsUi()
	{
		//IL_0014: Expected I4, but got I8
		List<MyButtonLog> list = new List<MyButtonLog>();
		logEntries = list;
		page = -1;
		maxPages = 99;
		base._002Ector();
	}
}
