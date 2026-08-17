using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public static class Maze
{
	public static class Directions
	{
		public const int TOP = 1;

		public const int RIGHT = 2;

		public const int BOTTOM = 4;

		public const int LEFT = 8;
	}

	public static readonly Dictionary<int, int> Opposite;

	public static readonly (Vector2Int, int)[] DirectionsWithVectors;

	public unsafe static NodeTree Generate(int width, int height, int seed)
	{
		//IL_0502: Expected O, but got I4
		//IL_0059: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_012e: Expected O, but got I4
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_020a: Expected O, but got I
		//IL_0217: Expected I4, but got O
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_046f: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_02d9: Expected O, but got Ref
		//IL_02d4: Expected native int or pointer, but got O
		//IL_02e3: Expected O, but got I4
		//IL_02ee: Expected O, but got I4
		object obj = width * height;
		byte[] array = new byte[obj];
		System.Random random = new System.Random(seed);
		Stack<Vector2Int> stack = new Stack<Vector2Int>();
		Stack<NodeTree> stack2 = new Stack<NodeTree>();
		int num = random.Next(0, width);
		int num2 = random.Next(0, height);
		NodeTree nodeTree = new NodeTree((Vector2Int)num, null);
		stack.Push((Vector2Int)num);
		((Stack<object>)(object)stack2).Push((object)nodeTree);
		object obj2 = num * width;
		object obj3 = obj2 + num2;
		if ((nint)obj3 < array.Length)
		{
			Stack<NodeTree> stack3 = stack2;
			Stack<Vector2Int> stack4 = stack;
			(Vector2Int, int) tuple2 = default((Vector2Int, int));
			int num4 = default(int);
			Vector2Int vector2Int4 = default(Vector2Int);
			object obj19 = default(object);
			while (true)
			{
				_ = 1;
				Vector2Int vector2Int;
				object obj4;
				NodeTree nodeTree2;
				List<(Vector2Int, int)> list;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbp_v6 (System.Collections.Generic.Stack`1<UnityEngine.Vector2Int>)+18]");
					if ((nint)0 > (nint)0)
					{
						vector2Int = stack4.Peek();
						obj4 = (object)vector2Int >> 32;
						nodeTree2 = stack3.Peek();
						list = new List<(Vector2Int, int)>();
						(Vector2Int, int)[] directionsWithVectors = DirectionsWithVectors;
						object obj5 = 0;
						while ((nint)obj5 < directionsWithVectors.Length)
						{
							if ((nint)obj5 >= directionsWithVectors.Length)
							{
								goto end_IL_053b;
							}
							object obj6 = obj5 * 2;
							object obj7 = obj5 + obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r14_v8 (System.ValueTuple`2<UnityEngine.Vector2Int, System.Int32>[])+20+v743 @ rcx_v44*4]");
							Vector2Int vector2Int2 = 0 + vector2Int;
							if ((nint)vector2Int2 >= 0)
							{
								bool flag = (nint)vector2Int2 < width;
								if ((nint)vector2Int2 < width)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r14_v8 (System.ValueTuple`2<UnityEngine.Vector2Int, System.Int32>[])+20+v743 @ rcx_v44*4]");
									object obj8 = (nint)0 >> 32;
									int num3 = (int)(obj8 + obj4);
									if (!flag && num3 < height)
									{
										object obj9 = vector2Int2 * width;
										object obj10 = obj9 + num3;
										if ((nint)obj10 >= array.Length)
										{
											goto end_IL_053b;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rcx_v50+20+v50 @ rax_v2 (System.Byte[])]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r14_v8 (System.ValueTuple`2<UnityEngine.Vector2Int, System.Int32>[])+28+v743 @ rcx_v44*4]");
											(Vector2Int, int) tuple = (vector2Int2, 0);
											*((Vector2Int, int)*)(nint)list = ((Vector2Int)(&tuple2), 0);
											tuple2 = ((Vector2Int, int))0;
											tuple = ((Vector2Int, int))0;
										}
									}
								}
							}
							obj5++;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v29 (System.Collections.Generic.List`1<System.ValueTuple`2<UnityEngine.Vector2Int, System.Int32>>)+18]");
						if ((nint)0 != 0)
						{
							goto IL_0333;
						}
						Vector2Int vector2Int3 = stack.Pop();
						object obj11 = ((Stack<object>)(object)stack2).Pop();
						stack3 = stack2;
						stack4 = stack;
						continue;
					}
					return nodeTree;
					continue;
					end_IL_053b:
					break;
				}
				break;
				IL_0333:
				List<(Vector2Int, int)> list2 = Shuffle(list, random);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181158E50");
				object obj12 = vector2Int * width;
				object obj13 = obj4 + obj12;
				if ((nint)obj13 >= array.Length)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rax_v39+20+v50 @ rax_v2 (System.Byte[])]");
				_ = (nuint)0u | (nuint)num4;
				object obj14 = (object)vector2Int4 >> 32;
				object obj15 = vector2Int4 * width;
				object obj16 = obj15 + obj14;
				if ((nint)obj16 >= array.Length)
				{
					break;
				}
				int num5 = Opposite.get_Item(num4);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ r8_v17+20+v50 @ rax_v2 (System.Byte[])]");
				int num6 = (int)((nint)num5 | (nint)0);
				NodeTree item = new NodeTree(vector2Int4, nodeTree2);
				nodeTree2._003Cchildren_003Ek__BackingField.Add(item);
				stack.Push(vector2Int4);
				((Stack<object>)(object)stack2).Push((object)item);
				object obj17 = vector2Int4 * width;
				object obj18 = obj19 + obj17;
				if ((nint)obj18 >= array.Length)
				{
					break;
				}
				stack3 = stack2;
				stack4 = stack;
				obj3 = obj18;
			}
		}
		return (NodeTree)(object)new IndexOutOfRangeException();
	}

	private static int ToIndex(Vector2Int position, int width)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0028: Expected I4, but got O
		object obj = (object)position >> 32;
		object obj2 = position * width;
		return (int)(obj2 + obj);
	}

	private static Vector2Int ToPosition(int index, int width)
	{
		//IL_0012: Expected O, but got I4
		int num = index / width;
		return (Vector2Int)num;
	}

	private static bool IsValidPosition(Vector2Int position, int width, int height)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected I4, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected I4, but got Unknown
		if ((nint)position >= 0 && (nint)position < width)
		{
			object obj = (object)position >> 32;
			if ((nint)obj >= 0)
			{
				object obj2 = (object)position >> 32;
				object obj3 = obj2 - height;
				int num = obj2 ^ height;
				object obj4 = obj2 ^ obj3;
				int num2 = num & obj4;
				bool flag = num2 < 0;
				bool flag2 = (nint)obj3 < 0;
				return flag2 != flag;
			}
		}
		return false;
	}

	private unsafe static List<T> Shuffle<T>(List<T> list, System.Random rand)
	{
		//IL_009e: Expected O, but got Ref
		//IL_00af: Expected O, but got Ref
		if (list != null)
		{
			int num = list._size - 1;
			if (num <= 0)
			{
				goto IL_00ef;
			}
			object obj = default(object);
			object obj2 = default(object);
			object obj3 = default(object);
			object obj4 = default(object);
			while (rand != null)
			{
				int maxValue = num + 1;
				int index = rand.Next(maxValue);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181158E50");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181158E50");
				list.set_Item(num, (T)(&obj));
				list.set_Item(index, (T)(&obj2));
				num--;
				bool flag = num > 0;
				obj2 = obj3;
				obj = obj4;
				if (flag)
				{
					continue;
				}
				goto IL_00ef;
			}
		}
		return (List<T>)(object)new NullReferenceException();
		IL_00ef:
		return list;
	}

	static Maze()
	{
		//IL_008e: Expected O, but got I8
		//IL_00b2: Expected O, but got I4
		//IL_00d6: Expected O, but got I4
		//IL_00fa: Expected O, but got I4
		Opposite = new Dictionary<int, int>
		{
			{ 1, 4 },
			{ 2, 8 },
			{ 4, 1 },
			{ 8, 2 }
		};
		(Vector2Int, int)[] directionsWithVectors = new(Vector2Int, int)[4];
		(Vector2Int, int) tuple = ((Vector2Int)4294967295L, 1);
		_ = 0;
		_ = 0;
		(Vector2Int, int) tuple2 = ((Vector2Int)0, 2);
		_ = 0;
		_ = 0;
		(Vector2Int, int) tuple3 = ((Vector2Int)1, 4);
		_ = 0;
		_ = 0;
		(Vector2Int, int) tuple4 = ((Vector2Int)0, 8);
		_ = 0;
		_ = 0;
		DirectionsWithVectors = directionsWithVectors;
	}
}
