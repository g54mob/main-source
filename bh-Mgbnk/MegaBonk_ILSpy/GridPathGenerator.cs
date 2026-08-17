using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

public static class GridPathGenerator
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public HashSet<Vector2Int> visited;

		public Predicate<Vector2Int> _003C_003E9__0;

		internal bool _003CExtractRandomPathFromTree_003Eb__0(Vector2Int n)
		{
			//IL_002b: Expected I4, but got O
			if (visited != null)
			{
				return visited.Contains(n);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static List<Vector2Int> GenerateRandomPath(int size, int pathLength)
	{
		//IL_00d6: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_00bf: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172E64]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		List<Vector2Int> list;
		if (size > 1)
		{
			object obj = size * size;
			if (pathLength <= (nint)obj)
			{
				Dictionary<Vector2Int, Vector2Int?> tree = GenerateRandomSpanningTree(size);
				list = ExtractRandomPathFromTree(tree, pathLength);
				if (list != null)
				{
					goto IL_0104;
				}
				object obj2 = 0;
				object obj3 = "Failed to extract a path of the desired length from the spanning tree.";
			}
			else
			{
				object obj2 = 0;
				object obj3 = "Path length exceeds the number of available tiles in the grid.";
			}
		}
		else
		{
			object obj2 = 0;
			object obj3 = "Grid size must be at least 2.";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		list = null;
		goto IL_0104;
		IL_0104:
		return list;
	}

	private unsafe static Dictionary<Vector2Int, Vector2Int?> GenerateRandomSpanningTree(int size)
	{
		//IL_0038: Expected O, but got I4
		//IL_050e: Expected O, but got I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_0155: Expected O, but got Ref
		//IL_015f: Expected O, but got I4
		//IL_01a2: Expected O, but got I4
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_054c: Expected O, but got Unknown
		//IL_05c5: Expected O, but got I
		//IL_041c: Expected O, but got Ref
		//IL_0357: Expected O, but got I
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected I4, but got Unknown
		HashSet<Vector2Int> hashSet = new HashSet<Vector2Int>();
		Dictionary<Vector2Int, Vector2Int?> dictionary = new Dictionary<Vector2Int, Vector2Int?>();
		dictionary._002Ector();
		List<Vector2Int> list = new List<Vector2Int>();
		bool flag = size <= 0;
		object obj = 0;
		if (flag)
		{
			if (list != null)
			{
				goto IL_00c9;
			}
		}
		else
		{
			while (true)
			{
				Vector2Int vector2Int = (Vector2Int)0;
				while (list != null)
				{
					list.Add(vector2Int);
					vector2Int++;
					if ((nint)vector2Int < size)
					{
						continue;
					}
					goto IL_007d;
				}
				break;
				IL_007d:
				obj++;
				if ((nint)obj < size)
				{
					continue;
				}
				goto IL_00c9;
			}
		}
		goto IL_04c2;
		IL_04c2:
		return (Dictionary<Vector2Int, Vector2Int?>)(object)new NullReferenceException();
		IL_00c9:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
		int index = UnityEngine.Random.Range(0, 0);
		Vector2Int vector2Int2 = list.get_Item(index);
		if (hashSet != null)
		{
			bool flag2 = hashSet.Add(vector2Int2);
			if (dictionary != null)
			{
				Vector2Int? vector2Int3 = default(Vector2Int?);
				dictionary.set_Item(vector2Int2, (Vector2Int?)(object)(&vector2Int3));
				vector2Int3 = (Vector2Int?)(object)0;
				nint num = 0;
				Vector2Int? vector2Int6 = default(Vector2Int?);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (System.Collections.Generic.HashSet`1<UnityEngine.Vector2Int>)+20]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
					Vector2Int vector2Int4;
					if (num2 < 0)
					{
						object obj2 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
							int index2 = UnityEngine.Random.Range(0, 0);
							vector2Int4 = list.get_Item(index2);
							obj2++;
							if ((nint)obj2 > 1000)
							{
								break;
							}
							if (hashSet.Contains(vector2Int4))
							{
								continue;
							}
							goto IL_01c6;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					}
					return dictionary;
					IL_01c6:
					List<Vector2Int> list2 = new List<Vector2Int>();
					if (list2 == null)
					{
						break;
					}
					list2.Add(vector2Int4);
					HashSet<Vector2Int> hashSet2 = new HashSet<Vector2Int>();
					bool flag3 = hashSet2 == null;
					Vector2Int item = vector2Int4;
					if (flag3)
					{
						break;
					}
					while (true)
					{
						bool flag4 = hashSet2.Add(item);
						Vector2Int vector2Int5;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
							int index3 = (int)(-1);
							Vector2Int item2 = list2.get_Item(index3);
							if (hashSet.Contains(item2))
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
							int index4 = (int)(-1);
							Vector2Int pos = list2.get_Item(index4);
							List<Vector2Int> neighbors = GetNeighbors(pos, size);
							if (neighbors == null)
							{
								goto end_IL_016a;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v52 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v52 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
							int index5 = UnityEngine.Random.Range(0, 0);
							vector2Int5 = neighbors.get_Item(index5);
							if (!hashSet2.Contains(vector2Int5))
							{
								goto IL_0317;
							}
							int num3 = list2.IndexOf(vector2Int5);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
							object obj3 = -num3;
							int count = obj3 - 1;
							int index6 = num3 + 1;
							list2.RemoveRange(index6, count);
							num = 0;
						}
						break;
						IL_0317:
						list2.Add(vector2Int5);
						item = vector2Int5;
					}
					int num4 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
						object obj4 = -1;
						if (num4 >= (nint)obj4)
						{
							break;
						}
						Vector2Int item3 = list2.get_Item(num4);
						bool flag5 = hashSet.Add(item3);
						Vector2Int key = list2.get_Item(num4);
						int index7 = num4 + 1;
						Vector2Int value = list2.get_Item(index7);
						vector2Int3 = value;
						dictionary.set_Item(key, (Vector2Int?)(object)(&vector2Int6));
						num4++;
						vector2Int6 = vector2Int3;
						num = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
						int index8 = (int)(-1);
						Vector2Int item4 = list2.get_Item(index8);
						bool flag6 = hashSet.Add(item4);
					}
					continue;
					end_IL_016a:
					break;
				}
			}
		}
		goto IL_04c2;
	}

	private static List<Vector2Int> ExtractRandomPathFromTree(Dictionary<Vector2Int, Vector2Int?> tree, int pathLength)
	{
		//IL_002e: Expected O, but got I4
		//IL_0096: Expected O, but got I
		//IL_00ef: Expected O, but got I
		//IL_0330: Expected O, but got I
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02a1: Expected O, but got I
		Dictionary<Vector2Int, Vector2Int?>.KeyCollection keys = tree.Keys;
		List<Vector2Int> list = new List<Vector2Int>(keys);
		object obj = 0;
		List<Vector2Int> list2;
		while (true)
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass2_0();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v7 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
			int index = UnityEngine.Random.Range(0, 0);
			Vector2Int item = list.get_Item(index);
			list2 = new List<Vector2Int>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v14+18]");
			if (num >= 0)
			{
				list2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
				object obj3 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v14+18]");
				if (num2 >= 0)
				{
					return (List<Vector2Int>)(object)new IndexOutOfRangeException();
				}
			}
			HashSet<Vector2Int> hashSet = new HashSet<Vector2Int>();
			bool flag = hashSet.Add(item);
			CS_0024_003C_003E8__locals7.visited = hashSet;
			bool flag2;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
				object obj4 = -pathLength;
				flag2 = obj4 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
				if ((nint)0 >= (nint)pathLength)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
				int index2 = (int)(-1);
				Vector2Int node = list2.get_Item(index2);
				List<Vector2Int> treeNeighbors = GetTreeNeighbors(node, tree);
				Predicate<Vector2Int> match = CS_0024_003C_003E8__locals7._003C_003E9__0;
				if (CS_0024_003C_003E8__locals7._003C_003E9__0 == null)
				{
					match = (CS_0024_003C_003E8__locals7._003C_003E9__0 = delegate(Vector2Int n)
					{
						//IL_002b: Expected I4, but got O
						if (CS_0024_003C_003E8__locals7.visited == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						return CS_0024_003C_003E8__locals7.visited.Contains(n);
					});
				}
				int num3 = treeNeighbors.RemoveAll(match);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v27 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v27 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
					int index3 = UnityEngine.Random.Range(0, 0);
					Vector2Int item2 = treeNeighbors.get_Item(index3);
					list2.Add(item2);
					bool flag3 = CS_0024_003C_003E8__locals7.visited.Add(item2);
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)+18]");
				object obj5 = -pathLength;
				flag2 = obj5 == null;
				break;
			}
			if (!flag2)
			{
				obj++;
				if ((nint)obj >= 100)
				{
					list2 = null;
					break;
				}
				continue;
			}
			break;
		}
		return list2;
	}

	private static List<Vector2Int> GetNeighbors(Vector2Int pos, int size)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0147: Expected O, but got I
		List<Vector2Int> list = new List<Vector2Int>();
		Vector2Int[] array = new Vector2Int[4];
		if (array.Length > 0)
		{
			_ = 0;
			if (array.Length > 1)
			{
				_ = 1;
				if (array.Length > 2)
				{
					_ = 0;
					if (array.Length > 3)
					{
						_ = 4294967295L;
						List<Vector2Int> list2 = null;
						List<Vector2Int> list3 = null;
						List<Vector2Int> list4 = null;
						object obj2 = default(object);
						while (true)
						{
							if ((nint)list3 < array.Length)
							{
								if ((nint)list2 >= array.Length)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4 (UnityEngine.Vector2Int[])+20+v85 @ rsi_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)*8]");
								Vector2Int vector2Int = 0 + pos;
								if ((nint)vector2Int >= 0 && (nint)vector2Int < size)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4 (UnityEngine.Vector2Int[])+20+v85 @ rsi_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2Int>)*8]");
									object obj = (nint)0 >> 32;
									list4 = (List<Vector2Int>)(object)(obj + obj2);
									if ((nint)list4 >= 0 && (nint)list4 < size)
									{
										list.Add(vector2Int);
										list4 = list;
									}
								}
								list2 = (List<Vector2Int>)(list2 + 1);
								list3 = list2;
								continue;
							}
							return list;
						}
					}
				}
			}
		}
		return (List<Vector2Int>)(object)new IndexOutOfRangeException();
	}

	private unsafe static List<Vector2Int> GetTreeNeighbors(Vector2Int node, Dictionary<Vector2Int, Vector2Int?> tree)
	{
		//IL_00b2: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_010c: Expected O, but got I
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_0150: Expected O, but got Ref
		//IL_01dd: Expected O, but got Ref
		List<Vector2Int> list = new List<Vector2Int>();
		Vector2Int[] array = new Vector2Int[4];
		if (array.Length > 0)
		{
			_ = 0;
			if (array.Length > 1)
			{
				_ = 1;
				if (array.Length > 2)
				{
					_ = 0;
					if (array.Length > 3)
					{
						_ = 4294967295L;
						object obj = 0;
						object obj2 = 0;
						object obj5 = default(object);
						object obj6 = default(object);
						object obj7 = default(object);
						object obj10 = default(object);
						object obj11 = default(object);
						while (true)
						{
							Vector2Int vector2Int;
							if ((nint)obj2 < array.Length)
							{
								if ((nint)obj >= array.Length)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (UnityEngine.Vector2Int[])+20+v125 @ rsi_v4*8]");
								vector2Int = 0 + node;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (UnityEngine.Vector2Int[])+20+v125 @ rsi_v4*8]");
								object obj3 = (nint)0 >> 32;
								object obj4 = obj3 + obj5;
								if (!tree.ContainsKey(vector2Int))
								{
									goto IL_0270;
								}
								Vector2Int? vector2Int2 = ((Dictionary<Vector2Int, Vector2Int?>)(&obj6)).get_Item((Vector2Int)tree);
								if (obj6 != null)
								{
									bool flag = obj7 != (object)node;
									bool flag2 = false;
									if (!flag)
									{
										object obj8 = obj7 >> 32;
										object obj9 = obj8 - obj5;
										bool flag3 = obj9 == null;
										flag2 = flag3;
									}
									if (flag2)
									{
										goto IL_025e;
									}
								}
								Vector2Int? vector2Int3 = ((Dictionary<Vector2Int, Vector2Int?>)(&obj10)).get_Item((Vector2Int)tree);
								if (obj10 == null)
								{
									goto IL_0270;
								}
								bool flag4 = obj11 != (object)vector2Int;
								bool flag5 = false;
								if (!flag4)
								{
									object obj12 = obj11 >> 32;
									object obj13 = obj12 - obj4;
									bool flag6 = obj13 == null;
									flag5 = flag6;
								}
								if (!flag5)
								{
									goto IL_0270;
								}
								goto IL_025e;
							}
							return list;
							IL_025e:
							list.Add(vector2Int);
							goto IL_0270;
							IL_0270:
							obj++;
							obj2 = obj;
						}
					}
				}
			}
		}
		return (List<Vector2Int>)(object)new IndexOutOfRangeException();
	}
}
