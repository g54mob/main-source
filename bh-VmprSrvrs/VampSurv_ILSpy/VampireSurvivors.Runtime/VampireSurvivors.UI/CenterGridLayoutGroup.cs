using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class CenterGridLayoutGroup : MonoBehaviour
{
	private bool _ForceXPosition;

	private float _XPosition;

	private bool _ForceYPosition;

	private float _YPosition;

	private float _MaxWidth;

	private GridLayoutGroup _grid;

	private LayoutElement _layout;

	private RectTransform _rTrans;

	private void Awake()
	{
		GridLayoutGroup component = GetComponent<GridLayoutGroup>();
		_grid = component;
		LayoutElement component2 = GetComponent<LayoutElement>();
		_layout = component2;
		RectTransform component3 = GetComponent<RectTransform>();
		_rTrans = component3;
	}

	private void Update()
	{
		//IL_01f3: Expected O, but got I4
		//IL_004a: Expected O, but got I
		//IL_0057: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_026e: Expected O, but got I4
		//IL_02ad: Expected I, but got O
		//IL_01b4->IL01b4: Incompatible stack heights: 9 vs 8
		//IL_030e->IL01a0: Incompatible stack heights: 10 vs 9
		Transform transform = base.transform;
		bool flag = (object)transform == null;
		while (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
		{
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		}
		object obj = Transform.get_childCount_Injected(((UnityEngine.Object)transform).m_CachedPtr);
		CenterGridLayoutGroup grid = (CenterGridLayoutGroup)(object)_grid;
		bool flag2 = (object)_grid == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v17 (VampireSurvivors.UI.CenterGridLayoutGroup)+68]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v17 (VampireSurvivors.UI.CenterGridLayoutGroup)+70]");
		object obj2 = num + 0;
		CenterGridLayoutGroup centerGridLayoutGroup = (CenterGridLayoutGroup)grid._ForceXPosition;
		object obj3 = obj2 * obj;
		bool flag3 = !grid._ForceXPosition;
		bool flag4 = ((UnityEngine.Object)centerGridLayoutGroup).m_CachedPtr == (IntPtr)0;
		object obj4 = RectOffset.get_left_Injected(((UnityEngine.Object)centerGridLayoutGroup).m_CachedPtr);
		CenterGridLayoutGroup grid2 = (CenterGridLayoutGroup)(object)_grid;
		object obj5 = obj4 + obj3;
		bool flag5 = (object)_grid == null;
		CenterGridLayoutGroup centerGridLayoutGroup2 = (CenterGridLayoutGroup)grid2._ForceXPosition;
		bool flag6 = !grid2._ForceXPosition;
		bool flag7 = ((UnityEngine.Object)centerGridLayoutGroup2).m_CachedPtr == (IntPtr)0;
		object obj6 = RectOffset.get_right_Injected(((UnityEngine.Object)centerGridLayoutGroup2).m_CachedPtr);
		CenterGridLayoutGroup layout = (CenterGridLayoutGroup)(object)_layout;
		float num2 = (float)obj6 + (float)obj5;
		bool num3;
		if (!(num2 > _MaxWidth))
		{
			bool flag8 = (object)_layout == null;
			num3 = flag8;
		}
		else
		{
			bool flag9 = (object)_layout == null;
			num3 = flag9;
			num2 = _MaxWidth;
		}
		nint num4 = (nint)layout;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v528 @ rax_v28 (Il2CppClass<VampireSurvivors.UI.CenterGridLayoutGroup>)+378] (should have been resolved before IL gen)");
		if (!_ForceXPosition && !_ForceYPosition)
		{
			return;
		}
		bool flag10 = (object)_rTrans == null;
		Vector2 anchoredPosition = _rTrans.anchoredPosition;
		if (!_ForceXPosition)
		{
			if (_ForceYPosition)
			{
			}
			bool flag11 = (object)_rTrans == null;
		}
		Vector2 anchoredPosition2 = default(Vector2);
		_rTrans.anchoredPosition = anchoredPosition2;
	}

	public void Refresh()
	{
		//IL_01f3: Expected O, but got I4
		//IL_004a: Expected O, but got I
		//IL_0057: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_026e: Expected O, but got I4
		//IL_02ad: Expected I, but got O
		//IL_01b4->IL01b4: Incompatible stack heights: 9 vs 8
		//IL_030e->IL01a0: Incompatible stack heights: 10 vs 9
		Transform transform = base.transform;
		bool flag = (object)transform == null;
		while (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
		{
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		}
		object obj = Transform.get_childCount_Injected(((UnityEngine.Object)transform).m_CachedPtr);
		CenterGridLayoutGroup grid = (CenterGridLayoutGroup)(object)_grid;
		bool flag2 = (object)_grid == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v17 (VampireSurvivors.UI.CenterGridLayoutGroup)+68]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v17 (VampireSurvivors.UI.CenterGridLayoutGroup)+70]");
		object obj2 = num + 0;
		CenterGridLayoutGroup centerGridLayoutGroup = (CenterGridLayoutGroup)grid._ForceXPosition;
		object obj3 = obj2 * obj;
		bool flag3 = !grid._ForceXPosition;
		bool flag4 = ((UnityEngine.Object)centerGridLayoutGroup).m_CachedPtr == (IntPtr)0;
		object obj4 = RectOffset.get_left_Injected(((UnityEngine.Object)centerGridLayoutGroup).m_CachedPtr);
		CenterGridLayoutGroup grid2 = (CenterGridLayoutGroup)(object)_grid;
		object obj5 = obj4 + obj3;
		bool flag5 = (object)_grid == null;
		CenterGridLayoutGroup centerGridLayoutGroup2 = (CenterGridLayoutGroup)grid2._ForceXPosition;
		bool flag6 = !grid2._ForceXPosition;
		bool flag7 = ((UnityEngine.Object)centerGridLayoutGroup2).m_CachedPtr == (IntPtr)0;
		object obj6 = RectOffset.get_right_Injected(((UnityEngine.Object)centerGridLayoutGroup2).m_CachedPtr);
		CenterGridLayoutGroup layout = (CenterGridLayoutGroup)(object)_layout;
		float num2 = (float)obj6 + (float)obj5;
		bool num3;
		if (!(num2 > _MaxWidth))
		{
			bool flag8 = (object)_layout == null;
			num3 = flag8;
		}
		else
		{
			bool flag9 = (object)_layout == null;
			num3 = flag9;
			num2 = _MaxWidth;
		}
		nint num4 = (nint)layout;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v528 @ rax_v28 (Il2CppClass<VampireSurvivors.UI.CenterGridLayoutGroup>)+378] (should have been resolved before IL gen)");
		if (!_ForceXPosition && !_ForceYPosition)
		{
			return;
		}
		bool flag10 = (object)_rTrans == null;
		Vector2 anchoredPosition = _rTrans.anchoredPosition;
		if (!_ForceXPosition)
		{
			if (_ForceYPosition)
			{
			}
			bool flag11 = (object)_rTrans == null;
		}
		Vector2 anchoredPosition2 = default(Vector2);
		_rTrans.anchoredPosition = anchoredPosition2;
	}

	public void SetMaxWidth(float width)
	{
		_MaxWidth = width;
	}

	public CenterGridLayoutGroup()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
