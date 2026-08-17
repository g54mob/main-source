using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.UI;

public class PageManager : MonoBehaviour
{
	private List<GameObject> _Pages;

	private TextMeshProUGUI _PageCount;

	private Button _LeftArrow;

	private Button _RightArrow;

	private int pageIndex;

	protected Rewired.Player Player;

	private unsafe void Awake()
	{
		//IL_0043: Expected O, but got Ref
		//IL_0057: Expected O, but got Ref
		ReInput.PlayerHelper players = ReInput.players;
		Rewired.Player player = players.GetPlayer(0);
		Player = player;
		object obj = default(object);
		_LeftArrow.navigation = (Navigation)(&obj);
		_RightArrow.navigation = (Navigation)(&obj);
		Extensions.SetNavigationLeft(_LeftArrow, _RightArrow);
		Extensions.SetNavigationRight(_LeftArrow, _RightArrow);
		Extensions.SetNavigationLeft(_RightArrow, _LeftArrow);
		Extensions.SetNavigationRight(_RightArrow, _LeftArrow);
	}

	private unsafe void OnEnable()
	{
		//IL_02e6: Expected O, but got I4
		//IL_02ef: Expected O, but got I4
		//IL_021f: Expected O, but got Ref
		//IL_00d3: Expected I4, but got O
		//IL_01dc: Expected O, but got I
		//IL_0269: Expected O, but got Ref
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_00f4->IL02fd: Incompatible stack heights: 1 vs 0
		//IL_01fc->IL02fd: Incompatible stack heights: 1 vs 0
		//IL_036d->IL02fd: Incompatible stack heights: 2 vs 0
		//IL_03be->IL0372: Incompatible stack heights: 2 vs 0
		//IL_0110->IL0005: Incompatible stack heights: 2 vs 0
		List<GameObject> pages = _Pages;
		bool flag = _Pages == null;
		object obj = 1;
		object obj2 = 1;
		if (!flag)
		{
			object obj4 = default(object);
			while (true)
			{
				List<GameObject> pages2 = _Pages;
				if ((nint)obj < pages._size)
				{
					if (_Pages == null)
					{
						break;
					}
					if ((nint)obj2 < pages2._size)
					{
						GameObject[] items = pages2._items;
						if (pages2._items == null)
						{
							break;
						}
						bool flag2 = (nint)obj2 >= items.Length;
						int num = (int)items[obj2];
						if ((object)items[obj2] == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdi_v12 (System.Int32)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdi_v12 (System.Int32)+10]");
						GameObject.SetActive_Injected((IntPtr)0, false);
						pages = _Pages;
						obj2++;
						if (_Pages == null)
						{
							break;
						}
						obj = obj2;
						continue;
					}
					goto IL_02b7;
				}
				if (_Pages == null)
				{
					break;
				}
				if (pages2._size > 0)
				{
					if (pages2._size <= 0)
					{
						goto IL_02b7;
					}
					object items2 = pages2._items;
					if (pages2._items == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v12 (System.Object)+18]");
					bool flag4 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v12 (System.Object)+20]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v12 (System.Object)+20]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rbx_v13 (System.Object)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rbx_v13 (System.Object)+10]");
					GameObject.SetActive_Injected((IntPtr)0, true);
				}
				pageIndex = 0;
				string text = System.Number.FormatInt32(1, (ReadOnlySpan<char>)(&obj4), null);
				List<GameObject> pages3 = _Pages;
				if (_Pages == null)
				{
					break;
				}
				string text2 = System.Number.FormatInt32(pages3._size, (ReadOnlySpan<char>)(&obj4), null);
				string text3 = text + " / " + text2;
				if ((object)_PageCount == null)
				{
					break;
				}
				_PageCount.text = text3;
				return;
				IL_02b7:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				break;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void NextPage()
	{
		//IL_0125: Expected O, but got Ref
		//IL_0155: Expected O, but got Ref
		List<GameObject> pages = _Pages;
		int num = pageIndex;
		if (pageIndex < pages._size)
		{
			GameObject[] items = pages._items;
			items[num].SetActive(value: false);
			List<GameObject> pages2 = _Pages;
			if (++pageIndex >= pages2._size)
			{
				pageIndex = 0;
			}
			int num2 = pageIndex;
			if (pageIndex < pages2._size)
			{
				GameObject[] items2 = pages2._items;
				items2[num2].SetActive(value: true);
				int value = pageIndex + 1;
				object obj = default(object);
				string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
				List<GameObject> pages3 = _Pages;
				string text2 = System.Number.FormatInt32(pages3._size, (ReadOnlySpan<char>)(&obj), null);
				string text3 = text + " / " + text2;
				_PageCount.text = text3;
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void ClearAllPages()
	{
		//IL_0087: Expected I4, but got O
		//IL_0087: Expected O, but got I
		bool flag = _Pages == null;
		PageManager pageManager = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			pageManager = (PageManager)(object)_Pages;
			if (_Pages != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v2 (VampireSurvivors.UI.PageManager)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)pageManager).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)pageManager).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)pageManager).m_CachedPtr, 0, (int)((MonoBehaviour)pageManager).m_CancellationTokenSource);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void PreviousPage()
	{
		//IL_013f: Expected O, but got Ref
		//IL_016f: Expected O, but got Ref
		List<GameObject> pages = _Pages;
		int num = pageIndex;
		if (pageIndex < pages._size)
		{
			GameObject[] items = pages._items;
			items[num].SetActive(value: false);
			int num2 = pageIndex - 1;
			pageIndex = num2;
			if ((nint)items[num] < 0)
			{
				List<GameObject> pages2 = _Pages;
				int num3 = pages2._size - 1;
				pageIndex = num3;
			}
			List<GameObject> pages3 = _Pages;
			int num4 = pageIndex;
			if (pageIndex < pages3._size)
			{
				GameObject[] items2 = pages3._items;
				items2[num4].SetActive(value: true);
				int value = pageIndex + 1;
				object obj = default(object);
				string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
				List<GameObject> pages4 = _Pages;
				string text2 = System.Number.FormatInt32(pages4._size, (ReadOnlySpan<char>)(&obj), null);
				string text3 = text + " / " + text2;
				_PageCount.text = text3;
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe void RemovePage(GameObject g)
	{
		//IL_006c: Expected O, but got Ref
		//IL_009c: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809957D0");
		object obj = default(object);
		if (obj != null)
		{
			bool flag = ((List<object>)(object)_Pages).Remove((object)g);
		}
		int value = pageIndex + 1;
		object obj2 = default(object);
		string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj2), null);
		List<GameObject> pages = _Pages;
		string text2 = System.Number.FormatInt32(pages._size, (ReadOnlySpan<char>)(&obj2), null);
		string text3 = text + " / " + text2;
		_PageCount.text = text3;
	}

	public unsafe void AddPage(GameObject g)
	{
		//IL_0061: Expected O, but got Ref
		//IL_0091: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809957D0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			int value = pageIndex + 1;
			object obj2 = default(object);
			string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj2), null);
			List<GameObject> pages = _Pages;
			string text2 = System.Number.FormatInt32(pages._size, (ReadOnlySpan<char>)(&obj2), null);
			string text3 = text + " / " + text2;
			_PageCount.text = text3;
			List<GameObject> pages2 = _Pages;
			if (pages2._size == 1)
			{
				g.SetActive(value: true);
			}
		}
		else
		{
			Debug.Log("Page already exists, skipping");
		}
	}

	public int GetPageCount()
	{
		//IL_001d: Expected I4, but got O
		List<GameObject> pages = _Pages;
		if (_Pages != null)
		{
			return pages._size;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public void SetDownNavigation(Selectable s)
	{
		Extensions.SetNavigationDown(_LeftArrow, s);
		Extensions.SetNavigationDown(_RightArrow, s);
	}

	public void SetUpNavigation(Selectable s)
	{
		Extensions.SetNavigationUp(_LeftArrow, s);
		Extensions.SetNavigationUp(_RightArrow, s);
	}

	public Selectable GetSelectable()
	{
		return _RightArrow;
	}

	public PageManager()
	{
		List<GameObject> pages = new List<GameObject>();
		_Pages = pages;
	}
}
