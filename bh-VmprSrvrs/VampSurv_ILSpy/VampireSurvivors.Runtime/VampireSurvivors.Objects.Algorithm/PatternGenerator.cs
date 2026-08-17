using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Objects.Algorithm;

public class PatternGenerator
{
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int leftPatternNum;

		public PatternGenerator _003C_003E4__this;

		internal bool _003CgeneratePatternGrid_003Eb__0(int patNum)
		{
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			PatternGenerator patternGenerator = _003C_003E4__this;
			List<PatternData> patternData = patternGenerator.patternData;
			int num = leftPatternNum;
			if (leftPatternNum < patternData._size)
			{
				PatternData[] items = patternData._items;
				PatternData patternData2 = items[num];
				List<int> neighboursRight = patternData2.neighboursRight;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)0 == 0)
				{
					return false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805893E0");
				object obj2 = default(object);
				object obj = obj2 - -1;
				bool flag = obj == null;
				return !flag;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public int topPatternNum;

		public PatternGenerator _003C_003E4__this;

		internal bool _003CgeneratePatternGrid_003Eb__1(int patNum)
		{
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			PatternGenerator patternGenerator = _003C_003E4__this;
			List<PatternData> patternData = patternGenerator.patternData;
			int num = topPatternNum;
			if (topPatternNum < patternData._size)
			{
				PatternData[] items = patternData._items;
				PatternData patternData2 = items[num];
				List<int> neighboursBottom = patternData2.neighboursBottom;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)0 == 0)
				{
					return false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805893E0");
				object obj2 = default(object);
				object obj = obj2 - -1;
				bool flag = obj == null;
				return !flag;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_2
	{
		public int rightPatternNum;

		public PatternGenerator _003C_003E4__this;

		internal bool _003CgeneratePatternGrid_003Eb__2(int patNum)
		{
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			PatternGenerator patternGenerator = _003C_003E4__this;
			List<PatternData> patternData = patternGenerator.patternData;
			int num = rightPatternNum;
			if (rightPatternNum < patternData._size)
			{
				PatternData[] items = patternData._items;
				PatternData patternData2 = items[num];
				List<int> neighboursLeft = patternData2.neighboursLeft;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)0 == 0)
				{
					return false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805893E0");
				object obj2 = default(object);
				object obj = obj2 - -1;
				bool flag = obj == null;
				return !flag;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_3
	{
		public int bottomPatternNum;

		public PatternGenerator _003C_003E4__this;

		internal bool _003CgeneratePatternGrid_003Eb__3(int patNum)
		{
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			PatternGenerator patternGenerator = _003C_003E4__this;
			List<PatternData> patternData = patternGenerator.patternData;
			int num = bottomPatternNum;
			if (bottomPatternNum < patternData._size)
			{
				PatternData[] items = patternData._items;
				PatternData patternData2 = items[num];
				List<int> neighboursTop = patternData2.neighboursTop;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)0 == 0)
				{
					return false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805893E0");
				object obj2 = default(object);
				object obj = obj2 - -1;
				bool flag = obj == null;
				return !flag;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}
	}

	private int[][][] patterns;

	private List<PatternData> patternData;

	public PatternGenerator()
	{
		//IL_0897: Expected O, but got I4
		//IL_0b9d: Expected O, but got I4
		//IL_0ba6: Expected O, but got I4
		//IL_0bb7: Expected O, but got I4
		//IL_0bc0: Expected O, but got I4
		//IL_0f69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6e: Expected O, but got Unknown
		//IL_0c02: Expected I, but got O
		//IL_0b04: Expected O, but got I4
		//IL_0a78: Expected O, but got I4
		//IL_0c17: Expected O, but got I4
		int[][][] array = new int[8][][];
		int[][] array2 = new int[6][];
		int[] array3 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array4 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array5 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array6 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array7 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array8 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[][] array9 = new int[6][];
		int[] array10 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array11 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array12 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array13 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array14 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array15 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[][] array16 = new int[6][];
		int[] array17 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array18 = new int[6] { 1, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array19 = new int[6] { 1, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array20 = new int[6] { 1, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array21 = new int[6] { 1, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array22 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[][] array23 = new int[6][];
		int[] array24 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array25 = new int[6] { 1, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array26 = new int[6] { 1, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array27 = new int[6] { 1, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array28 = new int[6] { 1, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array29 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[][] array30 = new int[6][];
		int[] array31 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array32 = new int[6] { 0, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array33 = new int[6] { 0, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array34 = new int[6] { 0, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array35 = new int[6] { 0, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array36 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[][] array37 = new int[6][];
		int[] array38 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array39 = new int[6] { 0, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array40 = new int[6] { 0, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array41 = new int[6] { 0, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array42 = new int[6] { 0, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array43 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[][] array44 = new int[6][];
		int[] array45 = new int[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array46 = new int[6] { 1, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array47 = new int[6] { 1, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array48 = new int[6] { 1, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array49 = new int[6] { 1, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array50 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[][] array51 = new int[6][];
		int[] array52 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array53 = new int[6] { 1, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array54 = new int[6] { 1, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array55 = new int[6] { 1, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array56 = new int[6] { 1, 1, 1, 1, 1, 1 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int[] array57 = new int[6] { 0, 1, 1, 1, 1, 0 };
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		((List<PatternData>)(object)array).Add((PatternData)7);
		patterns = array;
		List<PatternData> list = new List<PatternData>();
		patternData = list;
		int[][][] array58 = patterns;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		List<int> list7 = default(List<int>);
		List<int> neighboursRight = default(List<int>);
		List<int> neighboursBottom = default(List<int>);
		List<int> neighboursLeft = default(List<int>);
		for (int num4 = 0; num4 < array58.Length; num4 = num)
		{
			int[][][] array59 = patterns;
			int[][] array60 = array59[num];
			int[] array61 = array60[0];
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			List<int> list4 = new List<int>();
			List<int> list5 = new List<int>();
			int num5 = num3;
			nint num6 = 0;
			int[][][] array62;
			int[] array64;
			while (true)
			{
				array62 = patterns;
				if (num5 >= array62.Length)
				{
					break;
				}
				int[][] array63 = array62[num5];
				bool flag = array60.Length <= 0;
				int num7 = 1;
				int num8 = 1;
				nint num9 = num3;
				List<int> list6 = list7;
				int num10 = 1;
				int num11 = 1;
				nint num12 = num6;
				nint num13 = num3;
				if (!flag)
				{
					bool flag4;
					do
					{
						if (num10 != 0)
						{
							array64 = array60[0];
							int[] array65 = array63[num13];
							object obj = array65.Length - 1;
							list6 = (List<int>)(object)array63[obj];
							int num14 = array64[num13];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1708 @ r9_v8 (System.Collections.Generic.List`1<System.Int32>)+20+v275 @ rax_v181 (Il2CppMethodInfo)*4]");
							bool flag2 = (nint)num14 == 0;
							num12 = num13;
							if (!flag2)
							{
								num10 = num3;
								num12 = num13;
							}
						}
						if (num11 != 0)
						{
							int[] array66 = array60[num13];
							object obj2 = array66.Length - 1;
							array64 = array60[obj2];
							list6 = (List<int>)(object)array63[0];
							int num15 = array64[num13];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1708 @ r9_v8 (System.Collections.Generic.List`1<System.Int32>)+20+v275 @ rax_v181 (Il2CppMethodInfo)*4]");
							bool flag3 = (nint)num15 == 0;
							num12 = num13;
							if (!flag3)
							{
								num11 = num3;
								num12 = num13;
							}
						}
						num9 = num13 + 1;
						flag4 = num9 < array60.Length;
						list7 = list6;
						num7 = num10;
						num8 = num11;
						num6 = num12;
						num13 = num9;
					}
					while (flag4);
				}
				bool flag5 = array61.Length <= 0;
				int[] array67 = (int[])1;
				int[] array68 = (int[])1;
				List<int> list8 = list7;
				int[] array69 = (int[])1;
				int[] array70 = (int[])1;
				nint num16 = num6;
				int[] array71 = null;
				if (!flag5)
				{
					bool flag7;
					do
					{
						if (array70 != null)
						{
							list8 = (List<int>)(object)array60[(object)array71];
							num16 = (nint)array63[(object)array71];
							object obj3 = array63.Length - 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1784 @ rdx_v173 (Il2CppMethodInfo)+20+v1419 @ rax_v194*4]");
							num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1782 @ r9_v14 (System.Collections.Generic.List`1<System.Int32>)+20]");
							nint num17 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1784 @ rdx_v173 (Il2CppMethodInfo)+20+v1419 @ rax_v194*4]");
							if (num17 != 0)
							{
								array70 = null;
							}
						}
						if (array69 != null)
						{
							list8 = (List<int>)(object)array60[(object)array71];
							num16 = array60.Length - 1;
							int[] array72 = array63[(object)array71];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1782 @ r9_v14 (System.Collections.Generic.List`1<System.Int32>)+20+v1784 @ rdx_v173 (Il2CppMethodInfo)*4]");
							bool flag6 = (nint)0 == array72[0];
							num9 = array72[0];
							if (!flag6)
							{
								array69 = null;
								num9 = array72[0];
							}
						}
						array71 = (int[])(array71 + 1);
						flag7 = (nint)array71 < array61.Length;
						list7 = list8;
						array67 = array69;
						array68 = array70;
						num6 = num16;
					}
					while (flag7);
				}
				bool flag8 = num7 == 0;
				int num18 = (int)num6;
				if (!flag8)
				{
					list2.Add(num5);
					num18 = num5;
				}
				if (num8 != 0)
				{
					list4.Add(num5);
					num18 = num5;
				}
				if (array68 != null)
				{
					list5.Add(num5);
					num18 = num5;
				}
				bool flag9 = array67 == null;
				num6 = num18;
				if (!flag9)
				{
					list3.Add(num5);
					num6 = num5;
				}
				num5++;
				array64 = null;
				num3 = 0;
			}
			PatternData item = new PatternData(num2, array62[num2], list2, neighboursRight, neighboursBottom, neighboursLeft);
			((List<object>)(object)patternData).Add((object)item);
			array58 = patterns;
			num = num2 + 1;
			list7 = list2;
			array64 = null;
			num2 = num;
			num3 = 0;
		}
	}

	public List<List<int>> generatePatternGrid(int gridWidth, int gridHeight)
	{
		//IL_0197: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_0af2: Expected O, but got I4
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_0365: Expected F4, but got O
		//IL_0233: Expected O, but got I
		//IL_03ab: Expected O, but got I
		//IL_03fd: Expected F4, but got I4
		//IL_0406: Expected O, but got I4
		//IL_0297: Expected O, but got I
		//IL_045f: Expected O, but got I4
		//IL_0b25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2a: Expected O, but got Unknown
		//IL_0b59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5e: Expected O, but got Unknown
		//IL_0b83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b88: Expected O, but got Unknown
		//IL_0bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be2: Expected O, but got Unknown
		//IL_0c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1f: Expected O, but got Unknown
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0622: Expected O, but got Unknown
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Expected O, but got Unknown
		//IL_086d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0872: Expected O, but got Unknown
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Expected O, but got Unknown
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Expected O, but got Unknown
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_0578: Expected O, but got Unknown
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Expected O, but got Unknown
		//IL_07c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Expected O, but got Unknown
		//IL_05d1: Expected I4, but got O
		//IL_06f9: Expected I4, but got O
		//IL_0821: Expected I4, but got O
		//IL_0949: Expected I4, but got O
		int[][][] array = patterns;
		int[][] array2 = array[0];
		int[] array3 = array2[0];
		int num = gridWidth / array3.Length;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		int num3 = default(int);
		int num2 = num3 / array2.Length;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		List<List<int>> list = new List<List<int>>();
		IEnumerable<int> enumerable = default(IEnumerable<int>);
		object obj2 = default(object);
		if ((nint)enumerable > 0)
		{
			List<int> list2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
			List<int> list3 = list2;
			object obj = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADD70");
				bool flag = (nint)obj2 <= 0;
				object obj3 = 0;
				int num4 = num3;
				if (!flag)
				{
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003A50");
						obj3++;
						flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
						num3 = 0;
						num4 = 0;
					}
					while (flag2);
				}
				obj++;
				bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<IEnumerable<int>, UIntPtr>(ref enumerable);
				num3 = num4;
				if (flag3)
				{
					break;
				}
				List<int> list4 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
				num3 = num4;
				list3 = list4;
			}
		}
		List<int> list5 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		int[][][] array4 = patterns;
		object obj4 = 0;
		object obj5 = 0;
		object obj11 = default(object);
		object obj14 = default(object);
		IEnumerable<int> enumerable5 = default(IEnumerable<int>);
		object obj18 = default(object);
		int num13 = default(int);
		object obj22 = default(object);
		int num15 = default(int);
		object obj27 = default(object);
		int num17 = default(int);
		object obj32 = default(object);
		int num19 = default(int);
		List<int> list13 = default(List<int>);
		List<int> list14 = default(List<int>);
		int num20 = default(int);
		while (true)
		{
			if ((nint)obj4 < array4.Length)
			{
				List<PatternData> list6 = this.patternData;
				if ((nint)obj5 >= list6._size)
				{
					break;
				}
				PatternData[] items = list6._items;
				PatternData patternData = items[obj5];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v857 @ rax_v15 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v857 @ rax_v15 (System.Collections.Generic.List`1<System.Int32>)+10]");
				num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v857 @ rax_v15 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v857 @ rax_v15 (System.Collections.Generic.List`1<System.Int32>)+18]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ r8_v23 (System.Int32)+18]");
				if (num5 >= 0)
				{
					list5.AddWithResize(patternData.num);
					num3 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v857 @ rax_v15 (System.Collections.Generic.List`1<System.Int32>)+18]");
					object obj7 = (nint)0 + (nint)1;
					_ = patternData.num;
				}
				array4 = patterns;
				obj5++;
				obj4 = obj5;
				continue;
			}
			object obj8 = obj2 >> 31;
			object obj9 = obj2 - obj8;
			object obj10 = obj9 >> 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			if ((nint)obj11 >= list._size)
			{
				break;
			}
			List<int>[] items2 = list._items;
			List<int> list7 = items2[obj11];
			object obj12 = (object)enumerable >> 31;
			object obj13 = (object)enumerable - obj12;
			float num6 = obj13 >> 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1063 @ rbx_v27 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)obj14 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1063 @ rbx_v27 (System.Collections.Generic.List`1<System.Int32>)+10]");
			List<int> list8 = (List<int>)0;
			_ = 7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1063 @ rbx_v27 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
			bool flag4 = (nint)enumerable <= 0;
			List<int> list9 = list5;
			IEnumerable<int> enumerable2 = enumerable;
			float num7 = num6;
			float num8 = array2.Length;
			object obj15 = 0;
			if (!flag4)
			{
				do
				{
					bool flag5 = (nint)obj2 <= 0;
					List<int> list10 = list9;
					int num9 = num3;
					IEnumerable<int> enumerable3 = enumerable2;
					float num10 = num7;
					float num11 = num8;
					List<int> list11 = list7;
					object obj16 = 0;
					if (!flag5)
					{
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
							if ((nint)obj14 <= -1)
							{
								List<int> list12 = new List<int>();
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADDD0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A79210");
								bool flag6 = (nint)obj16 <= 0;
								nint num12 = num9;
								IEnumerable<int> enumerable4 = enumerable5;
								if (!flag6)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									object obj17 = obj16 - 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
									bool flag7 = (nint)obj18 <= -1;
									num12 = num9;
									enumerable4 = enumerable5;
									if (!flag7)
									{
										_003C_003Ec__DisplayClass3_0 obj19 = new _003C_003Ec__DisplayClass3_0();
										obj19._003C_003E4__this = this;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										object obj20 = obj16 - 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
										obj19.leftPatternNum = num13;
										bool flag8 = num13 <= -1;
										num12 = num9;
										enumerable4 = enumerable5;
										if (!flag8)
										{
											Func<int, bool> func = null;
											bool flag9 = ((_003C_003Ec__DisplayClass3_0)(object)func)._003CgeneratePatternGrid_003Eb__0((int)obj19);
											IEnumerable<int> source = Enumerable.Where(enumerable5, func);
											IEnumerable<int> enumerable6 = Enumerable.Where(source, func);
											num12 = 0;
											enumerable4 = enumerable6;
										}
									}
								}
								bool flag10 = (nint)obj15 <= 0;
								nint num14 = num12;
								IEnumerable<int> enumerable7 = enumerable4;
								if (!flag10)
								{
									object obj21 = obj15 - 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
									bool flag11 = (nint)obj22 <= -1;
									num14 = num12;
									enumerable7 = enumerable4;
									if (!flag11)
									{
										_003C_003Ec__DisplayClass3_1 obj23 = new _003C_003Ec__DisplayClass3_1();
										obj23._003C_003E4__this = this;
										object obj24 = obj15 - 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
										obj23.topPatternNum = num15;
										bool flag12 = num15 <= -1;
										num14 = num12;
										enumerable7 = enumerable4;
										if (!flag12)
										{
											Func<int, bool> func2 = null;
											bool flag13 = ((_003C_003Ec__DisplayClass3_1)(object)func2)._003CgeneratePatternGrid_003Eb__1((int)obj23);
											IEnumerable<int> source2 = Enumerable.Where(enumerable4, func2);
											IEnumerable<int> enumerable8 = Enumerable.Where(source2, func2);
											num14 = 0;
											enumerable7 = enumerable8;
										}
									}
								}
								object obj25 = obj2 - 2;
								bool flag14 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj25);
								nint num16 = num14;
								IEnumerable<int> enumerable9 = enumerable7;
								if (!flag14)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									object obj26 = obj16 + 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
									bool flag15 = (nint)obj27 <= -1;
									num16 = num14;
									enumerable9 = enumerable7;
									if (!flag15)
									{
										_003C_003Ec__DisplayClass3_2 obj28 = new _003C_003Ec__DisplayClass3_2();
										obj28._003C_003E4__this = this;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										object obj29 = obj16 + 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
										obj28.rightPatternNum = num17;
										bool flag16 = num17 <= -1;
										num16 = num14;
										enumerable9 = enumerable7;
										if (!flag16)
										{
											Func<int, bool> func3 = null;
											bool flag17 = ((_003C_003Ec__DisplayClass3_2)(object)func3)._003CgeneratePatternGrid_003Eb__2((int)obj28);
											IEnumerable<int> source3 = Enumerable.Where(enumerable7, func3);
											IEnumerable<int> enumerable10 = Enumerable.Where(source3, func3);
											num16 = 0;
											enumerable9 = enumerable10;
										}
									}
								}
								object obj30 = enumerable + -2;
								bool flag18 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj30);
								nint num18 = num16;
								enumerable3 = enumerable9;
								if (!flag18)
								{
									object obj31 = obj15 + 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
									bool flag19 = (nint)obj32 <= -1;
									num18 = num16;
									enumerable3 = enumerable9;
									if (!flag19)
									{
										_003C_003Ec__DisplayClass3_3 obj33 = new _003C_003Ec__DisplayClass3_3();
										obj33._003C_003E4__this = this;
										object obj34 = obj15 + 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
										obj33.bottomPatternNum = num19;
										bool flag20 = num19 <= -1;
										num18 = num16;
										enumerable3 = enumerable9;
										if (!flag20)
										{
											Func<int, bool> func4 = null;
											bool flag21 = ((_003C_003Ec__DisplayClass3_3)(object)func4)._003CgeneratePatternGrid_003Eb__3((int)obj33);
											IEnumerable<int> source4 = Enumerable.Where(enumerable9, func4);
											IEnumerable<int> enumerable11 = Enumerable.Where(source4, func4);
											num18 = 0;
											enumerable3 = enumerable11;
										}
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1147 @ r15_v9 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									float value = UnityEngine.Random.value;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1147 @ r15_v9 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]");
									num11 = 0f * value;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
									num10 = num11;
									list11 = list13;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									float value2 = UnityEngine.Random.value;
									int[][][] array5 = patterns;
									num10 = (float)array5.Length * value2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
									num11 = value2;
									list11 = list14;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805E9A20");
								list10 = list5;
								num9 = num20;
							}
							obj16++;
						}
						while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2));
						list9 = list10;
						num3 = num9;
						enumerable2 = enumerable;
						num7 = num10;
						num8 = num11;
						list7 = list11;
					}
					obj15++;
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) < System.Runtime.CompilerServices.Unsafe.As<IEnumerable<int>, UIntPtr>(ref enumerable2));
			}
			return list;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		List<List<int>> result = default(List<List<int>>);
		return result;
	}

	public List<List<int>> generateGrid(int gridWidth, int gridHeight)
	{
		//IL_004d: Expected O, but got I4
		//IL_0483: Expected O, but got I4
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_01a4: Expected O, but got I4
		//IL_01ad: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		//IL_01c7: Expected O, but got I4
		//IL_01d0: Expected O, but got I4
		//IL_01de: Expected O, but got I4
		//IL_01e7: Expected O, but got I4
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Expected O, but got Unknown
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected O, but got Unknown
		//IL_0250: Expected O, but got I
		//IL_0261: Expected O, but got I4
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_026f: Expected O, but got I4
		//IL_0284: Expected O, but got I
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Expected O, but got Unknown
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_0356: Expected O, but got I
		List<List<int>> list = generatePatternGrid(gridWidth, gridHeight);
		List<List<int>> result = new List<List<int>>();
		bool flag = gridHeight <= 0;
		int num = gridHeight;
		if (!flag)
		{
			List<int> list2 = new List<int>();
			int num2 = gridHeight;
			object obj = 0;
			List<int> list3 = list2;
			List<int> list4 = default(List<int>);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADD70");
				bool flag2 = gridWidth <= 0;
				object obj2 = 0;
				num = num2;
				if (!flag2)
				{
					bool flag3;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						list4.Add(0);
						obj2++;
						flag3 = (nint)obj2 < gridWidth;
						num2 = 0;
						num = 0;
					}
					while (flag3);
				}
				obj++;
				if ((nint)obj >= gridHeight)
				{
					break;
				}
				List<int> list5 = new List<int>();
				num2 = num;
				list3 = list5;
			}
		}
		int[][][] array = patterns;
		if (array.Length > 0)
		{
			int[][] array2 = array[0];
			int[][][] array3 = patterns;
			int[][] array4 = array3[0];
			if (array4.Length > 0)
			{
				int[] array5 = array4[0];
				object obj3 = 0;
				object obj4 = 0;
				object obj5 = 0;
				List<List<int>> list6 = list;
				object obj6 = 0;
				object obj7 = 0;
				object obj13 = default(object);
				while (true)
				{
					if ((nint)obj6 < list6._size)
					{
						object obj8 = 0;
						object obj9 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							object obj10 = obj9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rax_v20+18]");
							if ((nint)obj10 >= 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v24+18]");
							object obj11 = 0;
							object obj12 = obj13;
							object obj14 = 0;
							while (true)
							{
								object obj15 = obj14;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdi_v9+18]");
								if ((nint)obj15 >= 0)
								{
									break;
								}
								object obj16 = 0;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdi_v9+18]");
									if ((nint)0 <= (nint)0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdi_v9+20]");
									object obj17 = 0;
									object obj18 = obj16;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v27+18]");
									if ((nint)obj18 >= 0)
									{
										goto IL_03c1;
									}
									object obj19 = obj8 + obj16;
									if ((nint)obj19 < gridWidth)
									{
										object obj20 = obj14 + obj7;
										if ((nint)obj20 < gridHeight)
										{
											object obj21 = obj14 + obj7;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
											object obj22 = obj14;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdi_v9+18]");
											if ((nint)obj22 >= 0)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdi_v9+20+v198 @ rsi_v8*8]");
											obj3 = 0;
											object obj23 = obj16;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ r9_v8+18]");
											if ((nint)obj23 >= 0)
											{
												break;
											}
											obj12 = obj8 + obj16;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ r9_v8+20+v186 @ rbx_v12*4]");
											num = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805E9A20");
										}
									}
									obj16++;
								}
								goto end_IL_0505;
								IL_03c1:
								obj14++;
							}
							obj9++;
							obj8 += array5.Length;
							obj5 = obj4;
							list6 = list;
						}
						obj5++;
						obj7 += array2.Length;
						obj4 = obj5;
						obj6 = obj5;
						continue;
					}
					return result;
					continue;
					end_IL_0505:
					break;
				}
			}
		}
		return (List<List<int>>)(object)new IndexOutOfRangeException();
	}
}
