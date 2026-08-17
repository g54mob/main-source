using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public class MazeHeightGenerator
{
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public NodeTree nextNodeTree;

		internal bool _003CGenerateHeightHein_003Eb__0(NodeTree x)
		{
			object obj = (object)x - (object)nextNodeTree;
			return obj == null;
		}
	}

	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public NodeTree nextNodeTree;

		internal bool _003CGenerateHeightMe_003Eb__0(NodeTree x)
		{
			object obj = (object)x - (object)nextNodeTree;
			return obj == null;
		}
	}

	public static void GenerateHeight(ProceduralTileGeneration tileGeneration, NodeTree startNode, int seed, MapParameters mapParameters)
	{
		if (mapParameters.heightGenerationStrategy != EHeightGenerationStrategy.Me)
		{
			if (mapParameters.heightGenerationStrategy == EHeightGenerationStrategy.Hein)
			{
				GenerateHeightHein(tileGeneration, startNode, seed, mapParameters);
			}
		}
		else
		{
			GenerateHeightMe(tileGeneration, startNode, seed, mapParameters);
		}
	}

	public static void GenerateHeightHein(ProceduralTileGeneration tileGeneration, NodeTree startNode, int seed, MapParameters mapParameters)
	{
		//IL_00a2: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_01c0: Expected I4, but got O
		//IL_013b: Expected O, but got I4
		//IL_01e4: Expected O, but got I4
		//IL_0184: Expected O, but got I4
		//IL_01b3: Expected I4, but got O
		//IL_0322: Expected O, but got I4
		//IL_09a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ad: Expected O, but got Unknown
		//IL_09c5: Expected I4, but got O
		//IL_07d0: Expected O, but got I4
		//IL_07e0: Expected I4, but got O
		//IL_0abb: Expected I4, but got O
		//IL_0353: Expected I4, but got O
		//IL_048e: Expected O, but got I4
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected O, but got Unknown
		//IL_037c: Expected I, but got O
		//IL_03e7: Expected O, but got I4
		//IL_074c: Expected O, but got I4
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Expected O, but got Unknown
		//IL_0761: Expected I4, but got O
		//IL_076a: Expected O, but got I4
		//IL_0777: Expected O, but got I8
		//IL_04d0: Expected O, but got I
		//IL_04dd: Expected I4, but got O
		//IL_03a1: Expected I4, but got O
		//IL_0a29: Expected O, but got I4
		//IL_06d9: Expected O, but got I4
		//IL_09f9: Expected I4, but got O
		//IL_0a13: Expected O, but got I4
		//IL_078d: Expected I4, but got O
		//IL_0796: Expected O, but got I4
		//IL_079f: Expected O, but got I4
		//IL_061a: Expected O, but got I4
		//IL_070f: Expected O, but got I4
		//IL_052d: Expected O, but got I4
		//IL_07ba: Expected O, but got I4
		//IL_07c2: Expected I4, but got O
		//IL_05d6: Expected O, but got I4
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Expected O, but got Unknown
		//IL_0910: Expected O, but got I4
		GaussianHeightBias gaussianHeightBias = new GaussianHeightBias();
		MapParameters mapParameters2 = default(MapParameters);
		bool flag = mapParameters2.biasStrategy != EBiasStrategy.Linear;
		LinearHeightBias linearHeightBias = (LinearHeightBias)(object)gaussianHeightBias;
		if (!flag)
		{
			LinearHeightBias linearHeightBias2 = new LinearHeightBias();
			linearHeightBias = linearHeightBias2;
		}
		List<NodeTree> list = new List<NodeTree>();
		System.Random random = new System.Random(seed);
		List<object>.Enumerator enumerator = (List<object>.Enumerator)0;
		List<object>.Enumerator enumerator2 = (List<object>.Enumerator)0;
		NodeTree nodeTree = null;
		NodeTree nodeTree2 = null;
		NodeTree nodeTree3 = startNode;
		List<NodeTree> list2 = list;
		NodeTree nodeTree8 = default(NodeTree);
		List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
		ProceduralTileGeneration proceduralTileGeneration = default(ProceduralTileGeneration);
		Vector2Int direction = default(Vector2Int);
		while (nodeTree3 != null)
		{
			_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass1_0();
			CS_0024_003C_003E8__locals8.nextNodeTree = nodeTree2;
			List<NodeTree> list3 = nodeTree3._003Cchildren_003Ek__BackingField;
			object obj;
			if (list3._size <= 0)
			{
				bool flag2 = list2._size <= 0;
				obj = 0;
				if (!flag2)
				{
					NodeTree nextNodeTree = list2.get_Item(0);
					CS_0024_003C_003E8__locals8.nextNodeTree = nextNodeTree;
					((List<object>)(object)list2).RemoveAt(0);
					obj = 1;
				}
			}
			else
			{
				int num = (int)nodeTree2;
				while (true)
				{
					List<NodeTree> list4 = nodeTree3._003Cchildren_003Ek__BackingField;
					bool flag3 = num >= list4._size;
					obj = 0;
					if (flag3)
					{
						break;
					}
					if (num != 0)
					{
						NodeTree item = list4.get_Item(num);
						list2.Add(item);
						num++;
					}
					else
					{
						NodeTree nextNodeTree2 = list4.get_Item(0);
						CS_0024_003C_003E8__locals8.nextNodeTree = nextNodeTree2;
						num++;
					}
				}
			}
			List<NodeTree> list5 = nodeTree3._003Cchildren_003Ek__BackingField;
			bool flag4;
			if (list5._size != 1)
			{
				flag4 = (byte)(int)nodeTree2 != 0;
			}
			else
			{
				NodeTree nodeTree4 = list5.get_Item(0);
				object obj2 = (object)nodeTree4 - (object)CS_0024_003C_003E8__locals8.nextNodeTree;
				bool flag5 = obj2 == null;
				flag4 = flag5;
			}
			Func<NodeTree, bool> predicate = delegate(NodeTree x)
			{
				object obj17 = (object)x - (object)CS_0024_003C_003E8__locals8.nextNodeTree;
				return obj17 == null;
			};
			bool flag6 = Enumerable.Any(nodeTree3._003Cchildren_003Ek__BackingField, (Func<object, bool>)predicate);
			NodeTree nodeTree5;
			if (!flag4)
			{
				nodeTree5 = nodeTree2;
			}
			else
			{
				bool flag7 = (nint)nodeTree3._003Cparent_003Ek__BackingField < 0;
				bool flag8 = nodeTree3._003Cparent_003Ek__BackingField == null;
				bool flag9 = !flag7;
				bool flag10 = !flag8;
				nodeTree5 = (NodeTree)(flag10 & flag9);
			}
			bool flag11 = Enumerable.Any(null, predicate);
			object obj3 = flag6 & nodeTree5;
			bool flag12 = obj3 == null;
			bool flag13 = (byte)(int)nodeTree5 != 0;
			if (!flag12)
			{
				NodeTree nextNodeTree3 = CS_0024_003C_003E8__locals8.nextNodeTree;
				bool flag14 = (byte)(int)(nextNodeTree3._003Cposition_003Ek__BackingField - nodeTree3._003Cposition_003Ek__BackingField) != 0;
				NodeTree nodeTree6 = nodeTree3._003Cparent_003Ek__BackingField;
				nint num2 = (nint)(nodeTree3._003Cposition_003Ek__BackingField - nodeTree6._003Cposition_003Ek__BackingField);
				if ((flag14 ? 1 : 0) != num2)
				{
					flag13 = (byte)(int)nodeTree2 != 0;
				}
				else
				{
					object obj4 = (object)nodeTree3._003Cposition_003Ek__BackingField >> 32;
					object obj5 = (object)nodeTree6._003Cposition_003Ek__BackingField >> 32;
					object obj6 = obj4 - obj5;
					object obj7 = (flag14 ? 1 : 0) >> 32;
					object obj8 = obj7 - obj6;
					bool flag15 = obj8 == null;
					flag13 = flag15;
				}
			}
			NodeTree nodeTree7;
			Vector2Int vector2Int;
			if (flag13)
			{
				object obj9 = (object)random ^ (object)random;
				object obj10 = (object)random & obj9;
				bool flag16 = (nint)obj10 < 0;
				bool flag17 = (nint)random < 0;
				bool flag18 = random == null;
				double num3 = random.NextDouble();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
				bool flag19 = flag17 == flag16;
				object obj11 = !flag18;
				object obj12 = flag19 & obj11;
				int num8;
				if (obj12 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004D00");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ stack_20+20]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ stack_20+24]");
					object obj13 = num4 + 0;
					int num5 = obj13 - (object)nodeTree;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C50");
					if (num5 <= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C50");
						bool flag20 = 0 <= num5;
						enumerator2 = (List<object>.Enumerator)num5;
						vector2Int = nodeTree3._003Cposition_003Ek__BackingField;
						nodeTree7 = nodeTree2;
						if (flag20)
						{
							goto IL_09ec;
						}
						int num6 = nodeTree3.yDir ^ nodeTree3.yDir;
						int num7 = nodeTree3.yDir & num6;
						bool flag21 = num7 < 0;
						bool flag22 = nodeTree3.yDir < 0;
						bool flag23 = nodeTree3.yDir == 0;
						bool flag24 = flag22 == flag21;
						bool flag25 = !flag23;
						object obj14 = flag25 & flag24;
						nodeTree7 = (NodeTree)(obj14 - 1);
						num8 = num5;
						vector2Int = nodeTree3._003Cposition_003Ek__BackingField;
					}
					else
					{
						int num9 = ~nodeTree3.yDir;
						nodeTree7 = (NodeTree)(num9 >> 31);
						num8 = num5;
						vector2Int = nodeTree3._003Cposition_003Ek__BackingField;
					}
				}
				else
				{
					int num10 = nodeTree3.yDir ^ nodeTree3.yDir;
					int num11 = nodeTree3.yDir & num10;
					bool flag26 = num11 < 0;
					bool flag27 = nodeTree3.yDir < 0;
					bool flag28 = nodeTree3.yDir == 0;
					if (!flag28)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r14d,xmm8\"");
						bool flag29 = nodeTree3.yDir >= 0;
						num8 = nodeTree3.yDir;
						vector2Int = (Vector2Int)0;
						nodeTree7 = nodeTree2;
						if (!flag29)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r14d,xmm9\"");
							num8 = nodeTree3.yDir;
							vector2Int = (Vector2Int)0;
							nodeTree7 = nodeTree2;
						}
					}
					else
					{
						double num12 = random.NextDouble();
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm10,xmm0\"");
						bool flag30 = flag27 == flag26;
						object obj15 = !flag30;
						object obj16 = obj15 | flag28;
						num8 = (int)enumerator2;
						vector2Int = (Vector2Int)0;
						nodeTree7 = (NodeTree)4294967295L;
						if (obj16 == null)
						{
							num8 = (int)enumerator2;
							vector2Int = (Vector2Int)0;
							nodeTree7 = (NodeTree)1;
						}
					}
				}
				enumerator2 = (List<object>.Enumerator)num8;
				goto IL_09ec;
			}
			vector2Int = (Vector2Int)0;
			nodeTree7 = nodeTree2;
			int num13 = (int)nodeTree;
			goto IL_0aab;
			IL_0a2e:
			nodeTree3.height = num13;
			List<NodeTree> list6 = nodeTree3._003Cchildren_003Ek__BackingField;
			int num14;
			if (list6._size > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				while (enumerator.MoveNext())
				{
					if (nodeTree8 != null)
					{
						nodeTree8.yDir = num14;
						continue;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				enumerator = enumerator3;
				enumerator2 = enumerator3;
				list2 = list;
			}
			else
			{
				list2 = list;
			}
			if (num14 < 0)
			{
			}
			int height;
			GameObject gameObject = proceduralTileGeneration.InstantiateTile(nodeTree3._003Cposition_003Ek__BackingField, height, num14, direction);
			Vector3 vector = proceduralTileGeneration.TilePositionToWorldPosition(nodeTree3._003Cposition_003Ek__BackingField);
			if (obj != null)
			{
				NodeTree nextNodeTree4 = CS_0024_003C_003E8__locals8.nextNodeTree;
				NodeTree nodeTree9 = nextNodeTree4._003Cparent_003Ek__BackingField;
				nodeTree = (NodeTree)nodeTree9.height;
			}
			nodeTree3 = CS_0024_003C_003E8__locals8.nextNodeTree;
			nodeTree2 = null;
			continue;
			IL_09ec:
			num13 = (int)((object)nodeTree + (object)nodeTree7);
			bool flag31 = (nint)nodeTree7 <= 0;
			nodeTree = (NodeTree)num13;
			if (!flag31)
			{
				height = num13 - 1;
				nodeTree = (NodeTree)num13;
				num14 = (int)nodeTree7;
				goto IL_0a2e;
			}
			goto IL_0aab;
			IL_0aab:
			height = num13;
			num14 = (int)nodeTree7;
			goto IL_0a2e;
		}
	}

	public static void GenerateHeightMe(ProceduralTileGeneration proceduralTileGeneration, NodeTree startNode, int seed, MapParameters mapParameters)
	{
		//IL_0040: Expected O, but got I4
		//IL_017c: Expected I4, but got O
		//IL_00de: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_01a8: Expected I4, but got O
		//IL_0131: Expected O, but got I4
		//IL_016a: Expected I4, but got O
		//IL_02ab: Expected O, but got I4
		//IL_0304: Expected O, but got I4
		//IL_0312: Expected O, but got I4
		//IL_0343: Expected O, but got I4
		//IL_03e0: Expected I, but got O
		//IL_04e2: Expected O, but got I4
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Expected O, but got Unknown
		//IL_065a: Expected O, but got I4
		//IL_066a: Expected O, but got I4
		//IL_06ad: Expected O, but got I4
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ba: Expected O, but got Unknown
		//IL_0a68: Expected O, but got I4
		//IL_06f8: Expected O, but got I4
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Expected O, but got Unknown
		//IL_0712: Expected O, but got I8
		//IL_064b: Expected O, but got I4
		//IL_0a24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a29: Expected I4, but got Unknown
		//IL_0729: Expected O, but got I4
		//IL_0609: Expected O, but got I8
		System.Random random = new System.Random(seed);
		List<NodeTree> list = new List<NodeTree>();
		list._002Ector();
		List<object>.Enumerator enumerator = (List<object>.Enumerator)0;
		int num = 0;
		int num2 = 0;
		List<NodeTree> list2 = list;
		NodeTree nodeTree = null;
		NodeTree nodeTree2 = startNode;
		object obj13 = default(object);
		object obj21 = default(object);
		List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
		ProceduralTileGeneration proceduralTileGeneration2 = default(ProceduralTileGeneration);
		Vector3 direction = default(Vector3);
		Vector3 parentDir = default(Vector3);
		while (true)
		{
			if (nodeTree2 == null)
			{
				return;
			}
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass2_0();
			CS_0024_003C_003E8__locals8.nextNodeTree = nodeTree;
			List<NodeTree> list3 = nodeTree2._003Cchildren_003Ek__BackingField;
			object obj;
			int index;
			if (list3._size <= 0)
			{
				bool flag = list2._size <= 0;
				obj = 0;
				index = 0;
				if (!flag)
				{
					NodeTree nextNodeTree = list2.get_Item(0);
					CS_0024_003C_003E8__locals8.nextNodeTree = nextNodeTree;
					((List<object>)(object)list2).RemoveAt(0);
					obj = 1;
					index = 0;
				}
			}
			else
			{
				NodeTree nodeTree3 = null;
				int num3 = (int)nodeTree;
				while (true)
				{
					List<NodeTree> list4 = nodeTree2._003Cchildren_003Ek__BackingField;
					bool flag2 = num3 >= list4._size;
					obj = 0;
					index = (int)nodeTree3;
					if (flag2)
					{
						break;
					}
					if (num3 != 0)
					{
						NodeTree nodeTree4 = list4.get_Item(num3);
						list2.Add(nodeTree4);
						num3++;
						nodeTree3 = nodeTree4;
					}
					else
					{
						NodeTree nodeTree5 = (CS_0024_003C_003E8__locals8.nextNodeTree = list4.get_Item(0));
						num3++;
						nodeTree3 = nodeTree5;
					}
				}
			}
			((List<NodeTree>)null).RemoveAt(index);
			List<NodeTree> list5 = nodeTree2._003Cchildren_003Ek__BackingField;
			bool flag3;
			if (list5._size != 1)
			{
				flag3 = (byte)(int)nodeTree != 0;
			}
			else
			{
				NodeTree nodeTree6 = list5.get_Item(0);
				object obj2 = (object)nodeTree6 - (object)CS_0024_003C_003E8__locals8.nextNodeTree;
				bool flag4 = obj2 == null;
				flag3 = flag4;
			}
			Func<NodeTree, bool> predicate = delegate(NodeTree x)
			{
				object obj22 = (object)x - (object)CS_0024_003C_003E8__locals8.nextNodeTree;
				return obj22 == null;
			};
			bool flag5 = Enumerable.Any(nodeTree2._003Cchildren_003Ek__BackingField, (Func<object, bool>)predicate);
			bool flag6 = !flag3;
			object obj3 = 0;
			if (!flag6)
			{
				bool flag7 = (nint)nodeTree2._003Cparent_003Ek__BackingField < 0;
				bool flag8 = nodeTree2._003Cparent_003Ek__BackingField == null;
				bool flag9 = !flag7;
				bool flag10 = !flag8;
				obj3 = flag10 & flag9;
			}
			int height;
			int num4;
			IEnumerable<NodeTree> enumerable;
			object obj5;
			IEnumerable<NodeTree> enumerable2;
			object obj4;
			if (obj3 == null)
			{
				obj4 = 0;
				height = num;
				num4 = num;
				enumerable = null;
			}
			else
			{
				int num5;
				if (!flag5)
				{
					obj5 = 0;
					num5 = num2;
					enumerable2 = null;
					nint num6 = 0;
				}
				else
				{
					NodeTree nextNodeTree2 = CS_0024_003C_003E8__locals8.nextNodeTree;
					NodeTree nodeTree7 = nodeTree2._003Cparent_003Ek__BackingField;
					object obj6 = (object)nextNodeTree2._003Cposition_003Ek__BackingField >> 32;
					object obj7 = (object)nodeTree2._003Cposition_003Ek__BackingField >> 32;
					obj5 = obj6 - obj7;
					List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(nextNodeTree2._003Cposition_003Ek__BackingField - nodeTree2._003Cposition_003Ek__BackingField);
					nint num6 = (nint)(nodeTree2._003Cposition_003Ek__BackingField - nodeTree7._003Cposition_003Ek__BackingField);
					bool flag11;
					if ((nint)enumerator2 != num6)
					{
						flag11 = false;
					}
					else
					{
						object obj8 = (object)nodeTree2._003Cposition_003Ek__BackingField >> 32;
						object obj9 = (object)nodeTree7._003Cposition_003Ek__BackingField >> 32;
						object obj10 = obj8 - obj9;
						object obj11 = obj5 - obj10;
						bool flag12 = obj11 == null;
						flag11 = flag12;
					}
					bool flag13 = !flag11;
					num5 = num2;
					enumerable2 = null;
					obj4 = obj5;
					height = num2;
					enumerable = null;
					if (flag13)
					{
						goto IL_0783;
					}
				}
				double num7 = random.NextDouble();
				object obj12 = obj13 ^ obj13;
				object obj14 = obj13 & obj12;
				bool flag14 = (nint)obj14 < 0;
				bool flag15 = (nint)obj13 < 0;
				bool flag16 = obj13 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
				bool flag17 = flag15 == flag14;
				object obj15 = !flag17;
				object obj16 = obj15 | flag16;
				obj4 = obj5;
				height = num5;
				enumerable = enumerable2;
				if (obj16 != null)
				{
					goto IL_0783;
				}
				int num8 = nodeTree2.yDir ^ nodeTree2.yDir;
				int num9 = nodeTree2.yDir & num8;
				bool flag18 = num9 < 0;
				bool flag19 = nodeTree2.yDir < 0;
				bool flag20 = nodeTree2.yDir == 0;
				if (!flag20)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm7\"");
					if (nodeTree2.yDir < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm8\"");
					}
					if (nodeTree2.yDir > 0)
					{
						num4 = num + 1;
						int num10 = num4 - 1;
						obj4 = obj5;
						height = num10;
						num = num4;
						enumerable = (IEnumerable<NodeTree>)1;
						goto IL_09a0;
					}
					if (nodeTree2.yDir < 0)
					{
						num4 = num - 1;
						num = num4;
						enumerable2 = (IEnumerable<NodeTree>)4294967295L;
						goto IL_0af8;
					}
				}
				else
				{
					bool flag21 = Enumerable.Any((IEnumerable<NodeTree>)num, null);
					bool flag22 = Enumerable.Any((IEnumerable<NodeTree>)num, null);
					double num11 = random.NextDouble();
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
					bool flag23 = flag19 == flag18;
					object obj17 = !flag20;
					object obj18 = flag23 & obj17;
					if (obj18 == null)
					{
						double num12 = random.NextDouble();
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm11,xmm0\"");
						bool flag24 = flag19 == flag18;
						object obj19 = !flag24;
						object obj20 = obj19 | flag20;
						enumerable2 = (IEnumerable<NodeTree>)4294967295L;
						if (obj20 == null)
						{
							enumerable2 = (IEnumerable<NodeTree>)1;
						}
					}
					else
					{
						if (num >= 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r12d,xmm0\"");
						enumerable2 = (IEnumerable<NodeTree>)num;
					}
					obj5 = obj13;
				}
				num4 = num + enumerable2;
				bool flag25 = (nint)enumerable2 <= 0;
				num = num4;
				if (flag25)
				{
					goto IL_0af8;
				}
				int num13 = num4 - 1;
				obj4 = obj5;
				height = num13;
				num = num4;
				enumerable = enumerable2;
			}
			goto IL_09a0;
			IL_0af8:
			obj4 = obj5;
			height = num4;
			enumerable = enumerable2;
			goto IL_09a0;
			IL_0783:
			num4 = num;
			goto IL_09a0;
			IL_09a0:
			nodeTree2.height = num4;
			List<NodeTree> list6 = nodeTree2._003Cchildren_003Ek__BackingField;
			if (list6._size > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				while (enumerator.MoveNext())
				{
					if (obj21 != null)
					{
						continue;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				enumerator = enumerator3;
			}
			GameObject gameObject;
			if (enumerable != null)
			{
				gameObject = proceduralTileGeneration2.slopeTile;
				if ((nint)enumerable >= 0)
				{
					goto IL_0b22;
				}
			}
			gameObject = proceduralTileGeneration2.flatTile;
			goto IL_0b22;
			IL_0b22:
			if (nodeTree2._003Cparent_003Ek__BackingField != null)
			{
				break;
			}
			GameObject gameObject2 = proceduralTileGeneration2.InstantiateTile(nodeTree2._003Cposition_003Ek__BackingField, height, gameObject, direction, parentDir);
			if (obj != null)
			{
				NodeTree nextNodeTree3 = CS_0024_003C_003E8__locals8.nextNodeTree;
				NodeTree nodeTree8 = nextNodeTree3._003Cparent_003Ek__BackingField;
				num2 = nodeTree8.height;
				MapParameters mapParameters2 = (MapParameters)(object)gameObject;
				num = nodeTree8.height;
				list2 = list;
				nodeTree = null;
				nodeTree2 = nextNodeTree3;
			}
			else
			{
				nodeTree2 = CS_0024_003C_003E8__locals8.nextNodeTree;
				MapParameters mapParameters2 = (MapParameters)(object)gameObject;
				num2 = num;
				list2 = list;
				nodeTree = null;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-1A8), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}
}
