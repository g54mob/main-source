using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Beardy;

public class GridLayoutGroup : UnityEngine.UI.GridLayoutGroup
{
	public override void SetLayoutHorizontal()
	{
		SetCellsAlongAxis(0);
	}

	public override void SetLayoutVertical()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x181B92DD0\"");
	}

	private unsafe void SetCellsAlongAxis(int axis)
	{
		//IL_0806: Expected O, but got I4
		//IL_0841: Expected I4, but got O
		//IL_0988: Expected O, but got I4
		//IL_0998: Expected O, but got I4
		//IL_03f9: Expected O, but got I4
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected I4, but got Unknown
		//IL_0319: Expected O, but got I4
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Expected I4, but got Unknown
		//IL_0dcf: Expected O, but got I
		//IL_0a3a: Expected O, but got I4
		//IL_0a48: Expected O, but got I4
		//IL_0a52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a57: Expected O, but got Unknown
		//IL_0a85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8a: Expected O, but got Unknown
		//IL_0a9f: Expected O, but got I
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0d8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d91: Expected O, but got Unknown
		//IL_0b62: Expected O, but got I4
		//IL_0b70: Expected O, but got I4
		//IL_0b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7f: Expected O, but got Unknown
		//IL_0bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb2: Expected O, but got Unknown
		//IL_0bc7: Expected O, but got I
		//IL_01c5: Expected O, but got I
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_0631: Expected O, but got I4
		//IL_063a: Expected O, but got I4
		//IL_0cad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb2: Expected O, but got Unknown
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2e: Expected I4, but got Unknown
		//IL_0c36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3b: Expected I4, but got Unknown
		//IL_0698: Expected O, but got I4
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a6: Expected I4, but got Unknown
		//IL_06b8: Expected O, but got I4
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Expected I4, but got Unknown
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f3: Expected O, but got Unknown
		//IL_0764: Expected O, but got I
		//IL_07a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Expected O, but got Unknown
		//IL_07d7: Expected F4, but got I4
		//IL_085e->IL0891: Incompatible stack heights: 1 vs 0
		//IL_0919->IL0891: Incompatible stack heights: 1 vs 0
		//IL_0cf3->IL0891: Incompatible stack heights: 1 vs 0
		//IL_00c7->IL0891: Incompatible stack heights: 2 vs 0
		//IL_0194->IL0891: Incompatible stack heights: 2 vs 0
		//IL_0dad->IL0e6a: Incompatible stack heights: 4 vs 0
		//IL_0c1c->IL07e5: Incompatible stack heights: 2 vs 0
		//IL_0891->IL07e5: Incompatible stack heights: 4 vs 0
		//IL_0c9f->IL0891: Incompatible stack heights: 2 vs 0
		//IL_0738->IL0891: Incompatible stack heights: 2 vs 0
		//IL_07e5->IL07e5: Incompatible stack heights: 2 vs 0
		List<RectTransform> list = ((LayoutGroup)this).m_RectChildren;
		object obj12;
		object obj13;
		int num19;
		int num22;
		int num23;
		int num24 = default(int);
		if (((LayoutGroup)this).m_RectChildren != null)
		{
			Rect value = default(Rect);
			if (axis != 0)
			{
				RectTransform rectTransform = base.rectTransform;
				if ((object)rectTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v61 (UnityEngine.RectTransform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v61 (UnityEngine.RectTransform)+10]");
					RectTransform.get_rect_Injected((IntPtr)0, out value);
					RectTransform rectTransform2 = base.rectTransform;
					if ((object)rectTransform2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v66 (UnityEngine.RectTransform)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v66 (UnityEngine.RectTransform)+10]");
						RectTransform.get_rect_Injected((IntPtr)0, out Rect _);
						int num4;
						int num6;
						if (m_Constraint != Constraint.FixedColumnCount)
						{
							if (m_Constraint != Constraint.FixedRowCount)
							{
								object obj = m_CellSize + m_Spacing;
								if (0 < (nint)obj)
								{
									if (m_Padding == null)
									{
										goto IL_0891;
									}
									int horizontal = m_Padding.horizontal;
									object obj2 = m_CellSize + m_Spacing;
									object obj4 = default(object);
									object obj3 = obj4 - horizontal;
									object obj5 = obj3 + (object)m_Spacing;
									float num = (float)obj5 + 0.001f;
									float num2 = num / (float)obj2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
									int num3 = default(int);
									bool flag3 = num3 >= 1;
									num4 = num3;
									if (!flag3)
									{
										num4 = 1;
									}
								}
								else
								{
									num4 = 2147483647;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+6C]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+74]");
								object obj6 = num5 + 0;
								bool flag4 = 0 >= (nint)obj6;
								num6 = 2147483647;
								if (!flag4)
								{
									if (m_Padding == null)
									{
										goto IL_0891;
									}
									int vertical = m_Padding.vertical;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+6C]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+74]");
									object obj2 = num7 + 0;
									object obj8 = default(object);
									object obj7 = obj8 - vertical;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+74]");
									object obj9 = obj7 + 0;
									float num8 = (float)obj9 + 0.001f;
									float num9 = num8 / (float)obj2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
									int num10 = default(int);
									bool flag5 = num10 >= 1;
									num6 = num10;
									if (!flag5)
									{
										num6 = 1;
									}
								}
							}
							else
							{
								num6 = m_ConstraintCount;
								bool flag6 = list._size <= m_ConstraintCount;
								num4 = 1;
								if (!flag6)
								{
									int num11 = list._size / m_ConstraintCount;
									int num12 = list._size % m_ConstraintCount;
									int num13 = num12 ^ num12;
									int num14 = num12 & num13;
									bool flag7 = num14 < 0;
									bool flag8 = num12 < 0;
									bool flag9 = num12 == 0;
									bool flag10 = flag8 == flag7;
									bool flag11 = !flag9;
									object obj10 = flag11 & flag10;
									num4 = obj10 + num11;
								}
							}
						}
						else
						{
							num4 = m_ConstraintCount;
							bool flag12 = list._size <= m_ConstraintCount;
							num6 = 1;
							if (!flag12)
							{
								int num15 = list._size / m_ConstraintCount;
								int num16 = list._size % m_ConstraintCount;
								int num17 = num16 ^ num16;
								int num18 = num16 & num17;
								bool flag13 = num18 < 0;
								bool flag14 = num16 < 0;
								bool flag15 = num16 == 0;
								bool flag16 = flag14 == flag13;
								bool flag17 = !flag15;
								object obj11 = flag17 & flag16;
								num6 = obj11 + num15;
							}
						}
						obj12 = (int)m_StartCorner / 2;
						obj13 = (int)m_StartCorner % 2;
						if (m_StartAxis != Axis.Horizontal)
						{
							if (num6 >= 1)
							{
								bool flag18 = num6 <= list._size;
								num19 = num6;
								if (!flag18)
								{
									num19 = list._size;
								}
							}
							else
							{
								num19 = 1;
							}
							int num20 = list._size / num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
							int num25;
							if (num4 >= 1)
							{
								int num21 = default(int);
								if (num4 > num21)
								{
									num22 = num21;
									num23 = num6;
									num24 = num6;
									num25 = num6;
									goto IL_0a1a;
								}
							}
							else
							{
								num4 = 1;
							}
							num22 = num4;
							num23 = num6;
							num24 = num6;
							num25 = num6;
						}
						else
						{
							if (num4 >= 1)
							{
								bool flag19 = num4 <= list._size;
								num22 = num4;
								if (!flag19)
								{
									num22 = list._size;
								}
							}
							else
							{
								num22 = 1;
							}
							int num26 = list._size / num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
							if (num6 >= 1)
							{
								int num27 = default(int);
								bool flag20 = num6 <= num27;
								num19 = num6;
								num23 = num4;
								num24 = num4;
								int num25 = num4;
								if (!flag20)
								{
									num19 = num27;
									num23 = num4;
									num24 = num4;
									num25 = num4;
								}
							}
							else
							{
								num19 = 1;
								num23 = num4;
								num24 = num4;
								int num25 = num4;
							}
						}
						goto IL_0a1a;
					}
				}
			}
			else
			{
				bool flag21 = list._size <= 0;
				object obj14 = 0;
				if (flag21)
				{
					return;
				}
				Vector2 value2 = default(Vector2);
				while (true)
				{
					List<RectTransform> list2 = ((LayoutGroup)this).m_RectChildren;
					if (((LayoutGroup)this).m_RectChildren == null)
					{
						break;
					}
					bool flag22 = (nint)obj14 >= list2._size;
					int num28 = (int)list2._items;
					if (list2._items == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rbx_v16 (System.Int32)+20+v107 @ rsi_v15*8]");
					int num29 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rbx_v16 (System.Int32)+20+v107 @ rsi_v15*8]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rbx_v17 (System.Int32)+10]");
					bool flag23 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rbx_v17 (System.Int32)+10]");
					RectTransform.set_anchorMin_Injected((IntPtr)0, ref *(Vector2*)(&num24));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rbx_v17 (System.Int32)+10]");
					bool flag24 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rbx_v17 (System.Int32)+10]");
					RectTransform.set_anchorMax_Injected((IntPtr)0, ref value2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rbx_v17 (System.Int32)+10]");
					bool flag25 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rbx_v17 (System.Int32)+10]");
					RectTransform.set_sizeDelta_Injected((IntPtr)0, ref *(Vector2*)(&value));
					obj14++;
					if ((nint)obj14 >= list._size)
					{
						return;
					}
				}
			}
		}
		goto IL_0891;
		IL_0891:
		throw new NullReferenceException();
		IL_0a1a:
		int num30 = list._size % num23;
		object obj15 = num22 - 1;
		object obj16 = num19 - 1;
		object obj17 = num22 * m_CellSize;
		object obj18 = obj15 * (object)m_Spacing;
		float requiredSpaceWithoutPadding = (float)obj18 + (float)obj17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+74]");
		object obj19 = obj16 * 0;
		int num31 = num19;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+6C]");
		object obj20 = (nint)num31 * (nint)0;
		float requiredSpaceWithoutPadding2 = (float)obj19 + (float)obj20;
		float startOffset = GetStartOffset(0, requiredSpaceWithoutPadding);
		float startOffset2 = GetStartOffset(1, requiredSpaceWithoutPadding2);
		bool flag26 = num30 == 0;
		int num32 = num23;
		if (!flag26)
		{
			num32 = num30;
		}
		int num33;
		int num34;
		int num35;
		if (m_StartAxis == Axis.Horizontal)
		{
			num33 = num32;
		}
		else
		{
			bool flag27 = m_StartAxis == Axis.Vertical;
			num33 = num22;
			num34 = num32;
			num35 = num22;
			if (flag27)
			{
				goto IL_0b54;
			}
		}
		num34 = num19;
		num35 = num33;
		goto IL_0b54;
		IL_0b54:
		object obj21 = num35 - 1;
		object obj22 = num34 - 1;
		object obj23 = num35 * m_CellSize;
		object obj24 = obj21 * (object)m_Spacing;
		float requiredSpaceWithoutPadding3 = (float)obj24 + (float)obj23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+74]");
		object obj25 = obj22 * 0;
		int num36 = num34;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+6C]");
		object obj26 = (nint)num36 * (nint)0;
		float requiredSpaceWithoutPadding4 = (float)obj25 + (float)obj26;
		float startOffset3 = GetStartOffset(0, requiredSpaceWithoutPadding3);
		float startOffset4 = GetStartOffset(1, requiredSpaceWithoutPadding4);
		if (list._size <= 0)
		{
			return;
		}
		object obj27 = list._size - num32;
		object obj28 = 0;
		float num37 = startOffset4;
		RectTransform rect = default(RectTransform);
		float size = default(float);
		RectTransform rect2 = default(RectTransform);
		while (true)
		{
			object obj29 = obj28 + 1;
			float num38;
			float num39;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj29) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj27))
			{
				num38 = startOffset4;
				num39 = startOffset3;
			}
			else
			{
				num38 = startOffset2;
				num39 = startOffset;
			}
			int num40 = obj28 / num24;
			int num41 = obj28 % num24;
			bool flag28 = m_StartAxis != Axis.Horizontal;
			int num42 = num41;
			if (!flag28)
			{
				num42 = num40;
			}
			bool flag29 = m_StartAxis != Axis.Horizontal;
			int num43 = num40;
			if (!flag29)
			{
				num43 = num41;
			}
			if ((nint)obj13 == 1)
			{
				object obj30 = num22 - num43;
				num43 = obj30 - 1;
			}
			if ((nint)obj12 == 1)
			{
				object obj31 = num19 - num42;
				num42 = obj31 - 1;
			}
			if (((LayoutGroup)this).m_RectChildren == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			object obj32 = m_CellSize + m_Spacing;
			object obj33 = obj32 * num43;
			float pos = (float)obj33 + num39;
			SetChildAlongAxis(rect, 0, pos, size);
			if (((LayoutGroup)this).m_RectChildren == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+6C]");
			nint num44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+74]");
			object obj34 = num44 + 0;
			float num45 = (float)obj34 * (float)num42;
			float pos2 = num45 + num38;
			SetChildAlongAxis(rect2, 1, pos2, size);
			obj28++;
			bool flag30 = (nint)obj28 < list._size;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Beardy.GridLayoutGroup)+6C]");
			int num25 = 0;
			num37 = num42;
			if (!flag30)
			{
				return;
			}
		}
		goto IL_0891;
	}

	public GridLayoutGroup()
	{
		//IL_000b: Expected O, but got I4
		//IL_0024: Expected I, but got O
		m_CellSize = (Vector2)1120403456;
		_ = 1120403456;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		m_Spacing = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		m_ConstraintCount = 2;
		((LayoutGroup)this)._002Ector();
	}
}
