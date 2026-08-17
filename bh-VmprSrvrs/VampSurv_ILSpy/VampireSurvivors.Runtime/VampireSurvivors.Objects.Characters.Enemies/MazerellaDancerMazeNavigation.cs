using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class MazerellaDancerMazeNavigation : MonoBehaviour
{
	public enum MazerellaNavigationNodeDirection
	{
		North,
		South,
		East,
		West
	}

	[Serializable]
	public class NavigationNode
	{
		public Vector2 Position;

		public int LeftDancerWeight;

		public int RightDancerWeight;

		public NavigationNode NorthNode;

		public NavigationNode SouthNode;

		public NavigationNode EastNode;

		public NavigationNode WestNode;
	}

	[StructLayout((LayoutKind)3)]
	private struct _003C_003Ec__DisplayClass22_0
	{
		public MazerellaDancerMazeNavigation _003C_003E4__this;

		public EnemyMazerellaDancer.DancerSide dancerSide;

		public float lowestWeight;

		public NavigationNode lowestWeightNode;
	}

	private const float DistanceBetweenNodes = 5.12f;

	private const float HalfDistanceBetweenNodes = 2.56f;

	private const float FirstNodeX = 12.16f;

	private const float FirstNodeY = 12.16f;

	private const float InverseFirstNodeX = 74.88f;

	private const float InverseFirstNodeY = 74.88f;

	private const int PlayerStartNavigationNodeIndex = 84;

	private const int LeftDancerDestinationNavigationNodeIndex = 6;

	private const int RightDancerDestinationNavigationNodeIndex = 162;

	private readonly List<NavigationNode> _003CNavigationNodes_003Ek__BackingField;

	private readonly List<PathLineSegment> _lineSegmentsBetweenDanceFloors;

	private float _003CCurrentTotalNormalizedPosition_003Ek__BackingField;

	public List<NavigationNode> NavigationNodes => _003CNavigationNodes_003Ek__BackingField;

	public float CurrentTotalNormalizedPosition
	{
		get
		{
			return _003CCurrentTotalNormalizedPosition_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentTotalNormalizedPosition_003Ek__BackingField = value;
		}
	}

	private unsafe void PrecalculateNavigationWeights()
	{
		//IL_045a: Expected O, but got Ref
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0084: Expected O, but got Ref
		//IL_00c5: Expected O, but got Ref
		//IL_00f2: Expected O, but got Ref
		if (_003CNavigationNodes_003Ek__BackingField != null)
		{
			List<NavigationNode>.Enumerator enumerator = default(List<NavigationNode>.Enumerator);
			List<NavigationNode>.Enumerator enumerator2;
			if (enumerator.MoveNext())
			{
				object obj = 0;
				enumerator2 = (List<NavigationNode>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			List<NavigationNode> list = _003CNavigationNodes_003Ek__BackingField;
			bool flag = _003CNavigationNodes_003Ek__BackingField == null;
			enumerator2 = (List<NavigationNode>.Enumerator)(&enumerator);
			if (!flag)
			{
				if (list._size <= 6)
				{
					goto IL_0468;
				}
				NavigationNode[] items = list._items;
				bool flag2 = list._items == null;
				enumerator2 = (List<NavigationNode>.Enumerator)(&enumerator);
				if (!flag2)
				{
					NavigationNode navigationNode = items[6];
					bool flag3 = items[6] == null;
					enumerator2 = (List<NavigationNode>.Enumerator)(&enumerator);
					if (!flag3)
					{
						bool flag4 = navigationNode.LeftDancerWeight <= 0;
						enumerator2 = (List<NavigationNode>.Enumerator)(&enumerator);
						if (!flag4)
						{
							navigationNode.LeftDancerWeight = 0;
							if (navigationNode.NorthNode != null)
							{
								SetLeftDancerWeight(navigationNode.NorthNode, 1);
							}
							if (navigationNode.SouthNode != null)
							{
								SetLeftDancerWeight(navigationNode.SouthNode, 1);
							}
							if (navigationNode.EastNode != null)
							{
								SetLeftDancerWeight(navigationNode.EastNode, 1);
							}
							if (navigationNode.WestNode != null)
							{
								SetLeftDancerWeight(navigationNode.WestNode, 1);
							}
						}
						List<NavigationNode> list2 = _003CNavigationNodes_003Ek__BackingField;
						if (_003CNavigationNodes_003Ek__BackingField != null)
						{
							if (list2._size <= 162)
							{
								goto IL_0468;
							}
							NavigationNode[] items2 = list2._items;
							if (list2._items != null)
							{
								NavigationNode navigationNode2 = items2[162];
								if (items2[162] != null)
								{
									if (navigationNode2.RightDancerWeight > 0)
									{
										navigationNode2.RightDancerWeight = 0;
										if (navigationNode2.NorthNode != null)
										{
											SetRightDancerWeight(navigationNode2.NorthNode, 1);
										}
										if (navigationNode2.SouthNode != null)
										{
											SetRightDancerWeight(navigationNode2.SouthNode, 1);
										}
										if (navigationNode2.EastNode != null)
										{
											SetRightDancerWeight(navigationNode2.EastNode, 1);
										}
										if (navigationNode2.WestNode != null)
										{
											SetRightDancerWeight(navigationNode2.WestNode, 1);
										}
									}
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0468:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void CachePathBetweenDanceFloors()
	{
		//IL_0167: Expected O, but got I4
		//IL_017f: Expected O, but got I4
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_0240: Expected O, but got I4
		//IL_0268: Expected O, but got I
		//IL_02cf: Expected O, but got I
		//IL_02ef: Expected O, but got I
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_02a6: Expected O, but got Ref
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		List<NavigationNode> list = _003CNavigationNodes_003Ek__BackingField;
		if (list._size > 84)
		{
			NavigationNode[] items = list._items;
			if (list._size > 6)
			{
				List<NavigationNode> pathToDanceFloor = GetPathToDanceFloor(items[84], items[6], EnemyMazerellaDancer.DancerSide.Left);
				List<NavigationNode> list2 = _003CNavigationNodes_003Ek__BackingField;
				if (list2._size > 162)
				{
					NavigationNode[] items2 = list2._items;
					List<NavigationNode> pathToDanceFloor2 = GetPathToDanceFloor(items[84], items2[162], EnemyMazerellaDancer.DancerSide.Right);
					((List<object>)(object)pathToDanceFloor).Reverse();
					List<NavigationNode> list3 = new List<NavigationNode>();
					((List<object>)(object)list3).InsertRange(list3._size, (IEnumerable<object>)pathToDanceFloor);
					pathToDanceFloor2.RemoveAt(0);
					((List<object>)(object)list3).InsertRange(list3._size, (IEnumerable<object>)pathToDanceFloor2);
					object obj = 0;
					int num = default(int);
					object obj5 = default(object);
					while (true)
					{
						object obj2 = list3._size - 1;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
						{
							if ((nint)obj >= list3._size)
							{
								break;
							}
							NavigationNode[] items3 = list3._items;
							object obj3 = obj + 1;
							if ((nint)obj3 >= list3._size)
							{
								break;
							}
							List<PathLineSegment> lineSegmentsBetweenDanceFloors = _lineSegmentsBetweenDanceFloors;
							IEnumerable<NavigationNode> enumerable = (IEnumerable<NavigationNode>)items3[obj];
							((List<NavigationNode>)num).InsertRange(num, (IEnumerable<NavigationNode>)items3[obj]);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+10]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v15+18]");
							if (num2 >= 0)
							{
								lineSegmentsBetweenDanceFloors.AddWithResize((PathLineSegment)(&obj5));
								obj++;
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
							object obj6 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
							object obj7 = (nint)0 * (nint)4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
							object obj8 = 0 + obj7;
							obj++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r8_v12 (System.Collections.Generic.IEnumerable`1<VampireSurvivors.Objects.Characters.Enemies.MazerellaDancerMazeNavigation+NavigationNode>)+10]");
							_ = 0;
							continue;
						}
						return;
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private List<NavigationNode> GetPathToDanceFloor(NavigationNode startNode, NavigationNode targetNode, EnemyMazerellaDancer.DancerSide dancerSide)
	{
		List<NavigationNode> list = new List<NavigationNode>();
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB35A0");
			bool flag = startNode == targetNode;
			NavigationNode navigationNode = startNode;
			if (flag)
			{
				goto IL_011f;
			}
			while (true)
			{
				NavigationNode lowestWeightNode = GetLowestWeightNode(navigationNode, dancerSide);
				NavigationNode[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				if (list._items == null)
				{
					break;
				}
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)lowestWeightNode);
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				bool flag2 = lowestWeightNode != targetNode;
				navigationNode = lowestWeightNode;
				if (flag2)
				{
					continue;
				}
				goto IL_011f;
			}
		}
		return (List<NavigationNode>)(object)new NullReferenceException();
		IL_011f:
		return list;
	}

	private NavigationNode GetLowestWeightNode(NavigationNode navigationNode, EnemyMazerellaDancer.DancerSide dancerSide)
	{
		//IL_007b: Expected F4, but got I4
		//IL_01c1: Expected O, but got I
		//IL_00db: Expected F4, but got I4
		//IL_0069: Expected F4, but got I4
		//IL_013b: Expected F4, but got I4
		//IL_00c9: Expected F4, but got I4
		//IL_0129: Expected F4, but got I4
		//IL_02e0: Invalid comparison between F4 and I4
		_ = 0;
		_ = 1f / 0f;
		_ = 0;
		float num = 1f / 0f;
		if (navigationNode != null)
		{
			NavigationNode northNode = navigationNode.NorthNode;
			EnemyMazerellaDancer.DancerSide dancerSide2 = default(EnemyMazerellaDancer.DancerSide);
			if (navigationNode.NorthNode != null)
			{
				float num2 = ((dancerSide2 != EnemyMazerellaDancer.DancerSide.Left) ? ((float)northNode.RightDancerWeight) : ((float)northNode.LeftDancerWeight));
				if (num > num2)
				{
					_ = navigationNode.NorthNode;
					num = num2;
				}
			}
			NavigationNode southNode = navigationNode.SouthNode;
			if (navigationNode.SouthNode != null)
			{
				float num3 = ((dancerSide2 != EnemyMazerellaDancer.DancerSide.Left) ? ((float)southNode.RightDancerWeight) : ((float)southNode.LeftDancerWeight));
				if (num > num3)
				{
					_ = navigationNode.SouthNode;
					num = num3;
				}
			}
			NavigationNode eastNode = navigationNode.EastNode;
			if (navigationNode.EastNode != null)
			{
				float num4 = ((dancerSide2 != EnemyMazerellaDancer.DancerSide.Left) ? ((float)eastNode.RightDancerWeight) : ((float)eastNode.LeftDancerWeight));
				if (num > num4)
				{
					_ = navigationNode.EastNode;
					num = num4;
				}
			}
			NavigationNode westNode = navigationNode.WestNode;
			if (navigationNode.WestNode != null)
			{
				int num5 = ((dancerSide2 != EnemyMazerellaDancer.DancerSide.Left) ? westNode.RightDancerWeight : westNode.LeftDancerWeight);
				if (num > (float)num5)
				{
					_ = navigationNode.WestNode;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rsp-10]");
			return (NavigationNode)0;
		}
		return (NavigationNode)(object)new NullReferenceException();
	}

	private int GetNodeWeight(NavigationNode nodeToCheck, EnemyMazerellaDancer.DancerSide dancerSide)
	{
		//IL_005f: Expected I4, but got O
		if (nodeToCheck != null)
		{
			if (dancerSide == EnemyMazerellaDancer.DancerSide.Left)
			{
				return nodeToCheck.LeftDancerWeight;
			}
			return nodeToCheck.RightDancerWeight;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private unsafe Vector3 GetNearestPositionOnPathBetweenDanceFloors(Vector3 position, out int lineSegmentIndex, out float normalizedDistanceOnLineSegment)
	{
		//IL_02da: Expected native int or pointer, but got O
		//IL_02e8: Expected native int or pointer, but got O
		//IL_03e2: Expected I, but got O
		//IL_040d: Expected F4, but got O
		//IL_0408: Expected native int or pointer, but got O
		//IL_0422: Expected F4, but got I
		//IL_041d: Expected native int or pointer, but got O
		//IL_0435: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_006b: Expected O, but got I
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c2: Expected F4, but got I
		//IL_01a9: Invalid comparison between I4 and F4
		//IL_01d1: Expected F4, but got I4
		//IL_0207: Expected F4, but got I4
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_028d: Expected native int or pointer, but got O
		//IL_029a: Expected native int or pointer, but got O
		//IL_02a7: Expected O, but got F4
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		ref int reference = ref *(int*)4294967295L;
		((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		((Vector3*)(nint)vector)->z = 0f;
		List<PathLineSegment> lineSegmentsBetweenDanceFloors = _lineSegmentsBetweenDanceFloors;
		object obj = 0;
		float num3 = 1f / 0f;
		object obj2 = 0;
		object obj3 = 0;
		float num6 = default(float);
		while (true)
		{
			object obj4 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
			if ((nint)obj4 < 0)
			{
				List<PathLineSegment> lineSegmentsBetweenDanceFloors2 = _lineSegmentsBetweenDanceFloors;
				object obj5 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
				if ((nint)obj5 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+10]");
					object obj6 = 0;
					object obj7 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdx_v5+18]");
					if ((nint)obj7 >= 0)
					{
						break;
					}
					object obj8 = obj3 * 4;
					object obj9 = obj3 + obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdx_v5+20+v328 @ rax_v17*4]");
					float num4 = 0f;
					float num5 = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdx_v5+20+v328 @ rax_v17*4]");
					float num7 = num5 - 0f;
					float num8 = num6 - num6;
					float num9 = position.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdx_v5+20+v328 @ rax_v17*4]");
					float num10 = num9 - 0f;
					float num11 = num6 - num6;
					float num12 = num10 * num7;
					float num13 = num11 * num8;
					float num14 = position.z * 0f;
					float num15 = num13 + num12;
					float num16 = num8 * num8;
					float num17 = num15 + num14;
					float num18 = num7 * num7;
					float num19 = num16 + num18;
					float num20 = num17 / num19;
					float num21;
					float num22;
					if (0f > num20)
					{
						num21 = num6;
						num22 = 0f;
					}
					else if (num20 > 1f)
					{
						num21 = num6;
						num22 = 0f;
						num4 = num6;
					}
					else
					{
						float num23 = num7 * num20;
						num22 = num20 * 0f;
						float num24 = num8 * num20;
						float num25 = num23;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdx_v5+20+v328 @ rax_v17*4]");
						float num26 = num25 + 0f;
						float num27 = num24 + num6;
						num21 = num27;
						num4 = num26;
					}
					float num28 = position.x - num4;
					float num29 = position.z - num22;
					float num30 = num6 - num21;
					float num31 = num30 * num30;
					float num32 = num28 * num28;
					float num33 = num29 * num29;
					float num34 = num31 + num32;
					float num35 = num34 + num33;
					if (num3 > num35)
					{
						reference = ref *(int*)obj3;
						((Vector3*)(nint)vector)->x = num6;
						((Vector3*)(nint)vector)->z = num22;
						obj = num20;
						num3 = num35;
					}
					lineSegmentsBetweenDanceFloors = _lineSegmentsBetweenDanceFloors;
					obj3++;
					obj2 = obj3;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			return vector;
		}
		return (Vector3)new IndexOutOfRangeException();
	}

	public unsafe Vector3 GetPositionOnLineSegmentWithOffset(int lineSegmentIndex, float startPointNormalizedPosition, float offsetDistanceInWorldSpace)
	{
		//IL_00a9: Expected O, but got I
		//IL_00bc: Expected O, but got I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_01d1: Invalid comparison between I4 and F4
		//IL_02df: Expected native int or pointer, but got O
		//IL_02ed: Expected native int or pointer, but got O
		//IL_0132: Expected O, but got I
		//IL_01a1: Expected O, but got I
		//IL_0220: Expected O, but got I4
		//IL_015f: Expected O, but got I4
		//IL_02bf: Expected native int or pointer, but got O
		//IL_02cd: Expected native int or pointer, but got O
		int num;
		float num2;
		List<PathLineSegment> lineSegmentsBetweenDanceFloors;
		if (lineSegmentIndex >= 0)
		{
			lineSegmentsBetweenDanceFloors = _lineSegmentsBetweenDanceFloors;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
			bool flag = (nint)lineSegmentIndex < (nint)0;
			num = lineSegmentIndex;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
				num = (int)(-1);
				num2 = 1f;
				goto IL_0072;
			}
		}
		else
		{
			num = 0;
		}
		lineSegmentsBetweenDanceFloors = _lineSegmentsBetweenDanceFloors;
		num2 = startPointNormalizedPosition;
		goto IL_0072;
		IL_0072:
		int num3 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
		if ((nint)num3 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+10]");
			object obj = 0;
			object obj2 = num * 4;
			object obj3 = num + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v4+30+v105 @ rcx_v6*4]");
			object obj5 = default(object);
			object obj4 = obj5 / 0;
			float num4 = (float)obj4 + num2;
			Vector3 vector = default(Vector3);
			float x = default(float);
			if (num4 > 1f)
			{
				List<PathLineSegment> lineSegmentsBetweenDanceFloors2 = _lineSegmentsBetweenDanceFloors;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
				object obj6 = -1;
				if (num < (nint)obj6)
				{
					object obj7 = num + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
					if ((nint)obj7 >= 0)
					{
						goto IL_02ad;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
					object obj8 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
					if ((nint)obj8 >= 0)
					{
						goto IL_02ad;
					}
				}
				((Vector3*)(nint)vector)->x = x;
				((Vector3*)(nint)vector)->z = 0f;
			}
			else
			{
				if (0f > num4)
				{
					List<PathLineSegment> lineSegmentsBetweenDanceFloors3 = _lineSegmentsBetweenDanceFloors;
					if (num > 0)
					{
						object obj9 = num - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
						if ((nint)obj9 >= 0)
						{
							goto IL_02ad;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
						if ((nint)0 <= (nint)0)
						{
							goto IL_02ad;
						}
					}
				}
				((Vector3*)(nint)vector)->x = x;
				((Vector3*)(nint)vector)->z = 0f;
			}
			return vector;
		}
		goto IL_02ad;
		IL_02ad:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Vector3 result = default(Vector3);
		return result;
	}

	private unsafe Vector3 GetClosestPointOnLineToPoint(PathLineSegment lineSegment, Vector3 point, out float normalizedDistance)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_00e8: Expected O, but got F4
		//IL_00f1: Invalid comparison between I4 and F4
		//IL_0111: Expected F4, but got I4
		//IL_0181: Expected native int or pointer, but got O
		//IL_018e: Expected native int or pointer, but got O
		//IL_0147: Expected F4, but got I4
		object obj = lineSegment._003CEnd_003Ek__BackingField - lineSegment._003CStart_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lineSegment @ r8 (VampireSurvivors.Objects.Characters.Enemies.PathLineSegment)+C]");
		object obj3 = default(object);
		object obj2 = 0 - obj3;
		float num = point.x - (float)lineSegment._003CStart_003Ek__BackingField;
		float num2 = point.y - (float)obj3;
		float num3 = num * (float)obj;
		float num4 = num2 * (float)obj2;
		float num5 = point.z * 0f;
		float num6 = num4 + num3;
		object obj4 = obj2 * obj2;
		float num7 = num6 + num5;
		object obj5 = obj * obj;
		object obj6 = obj4 + obj5;
		float num8 = num7 / (float)obj6;
		object obj7 = num8;
		float z;
		float x;
		float num9 = default(float);
		if (0f > num8)
		{
			z = 0f;
			x = num9;
		}
		else if (num8 > 1f)
		{
			z = 0f;
			x = num9;
		}
		else
		{
			float num10 = num8 * 0f;
			z = num10;
			x = num9;
		}
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	private unsafe Vector3 GetClosestPointOnLineToPoint(Vector3 lineStart, Vector3 lineEnd, Vector3 point, out float normalizedDistance)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_012b: Expected O, but got F4
		//IL_0134: Invalid comparison between I4 and F4
		//IL_01e8: Expected native int or pointer, but got O
		//IL_01f5: Expected native int or pointer, but got O
		//IL_0158: Expected native int or pointer, but got O
		//IL_016a: Expected native int or pointer, but got O
		//IL_01a1: Expected native int or pointer, but got O
		//IL_01b3: Expected native int or pointer, but got O
		float num = lineEnd.x - lineStart.x;
		float num2 = lineEnd.z - lineStart.z;
		float num4 = default(float);
		float num3 = num4 - num4;
		object obj = default(object);
		float num5 = (float)obj - lineStart.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ stack_28+8]");
		object obj2 = 0 - lineStart.z;
		float num6 = num4 - num4;
		float num7 = num5 * num;
		float num8 = num6 * num3;
		float num9 = (float)obj2 * num2;
		float num10 = num8 + num7;
		float num11 = num * num;
		float num12 = num3 * num3;
		float num13 = num10 + num9;
		float num14 = num2 * num2;
		float num15 = num12 + num11;
		float num16 = num15 + num14;
		float num17 = num13 / num16;
		object obj3 = num17;
		Vector3 vector = default(Vector3);
		if (0f > num17)
		{
			((Vector3*)(nint)vector)->x = lineStart.x;
			((Vector3*)(nint)vector)->z = lineStart.z;
			return vector;
		}
		if (num17 > 1f)
		{
			((Vector3*)(nint)vector)->x = lineEnd.x;
			((Vector3*)(nint)vector)->z = lineEnd.z;
			return vector;
		}
		float num18 = num17 * num2;
		float z = num18 + lineStart.z;
		((Vector3*)(nint)vector)->x = num4;
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	private void SetLeftDancerWeight(NavigationNode currentNode, int weightToSet)
	{
		NavigationNode navigationNode2 = default(NavigationNode);
		NavigationNode navigationNode = navigationNode2;
		int num2 = default(int);
		int num = num2;
		while (navigationNode.LeftDancerWeight > num)
		{
			navigationNode.LeftDancerWeight = num;
			num++;
			if (navigationNode.NorthNode != null)
			{
				navigationNode2 = navigationNode.NorthNode;
				SetLeftDancerWeight(navigationNode.NorthNode, num);
			}
			if (navigationNode.SouthNode != null)
			{
				navigationNode2 = navigationNode.SouthNode;
				SetLeftDancerWeight(navigationNode.SouthNode, num);
			}
			if (navigationNode.EastNode != null)
			{
				SetLeftDancerWeight(navigationNode.EastNode, num);
			}
			if (navigationNode.WestNode != null)
			{
				navigationNode = navigationNode.WestNode;
				continue;
			}
			break;
		}
	}

	private void SetRightDancerWeight(NavigationNode currentNode, int weightToSet)
	{
		NavigationNode navigationNode2 = default(NavigationNode);
		NavigationNode navigationNode = navigationNode2;
		int num2 = default(int);
		int num = num2;
		while (navigationNode.RightDancerWeight > num)
		{
			navigationNode.RightDancerWeight = num;
			num++;
			if (navigationNode.NorthNode != null)
			{
				navigationNode2 = navigationNode.NorthNode;
				SetRightDancerWeight(navigationNode.NorthNode, num);
			}
			if (navigationNode.SouthNode != null)
			{
				navigationNode2 = navigationNode.SouthNode;
				SetRightDancerWeight(navigationNode.SouthNode, num);
			}
			if (navigationNode.EastNode != null)
			{
				SetRightDancerWeight(navigationNode.EastNode, num);
			}
			if (navigationNode.WestNode != null)
			{
				navigationNode = navigationNode.WestNode;
				continue;
			}
			break;
		}
	}

	public unsafe void UpdateNearestPositionToPlayer(Transform playerTransform)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0176: Expected O, but got Ref
		//IL_01a4: Expected O, but got Ref
		//IL_01e4: Expected F4, but got I
		//IL_01f5: Invalid comparison between I and F4
		//IL_0064: Expected O, but got I4
		//IL_006d: Expected F4, but got I4
		//IL_0076: Expected O, but got I4
		//IL_0056: Expected F4, but got I4
		//IL_025f: Expected O, but got Ref
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_028e: Expected O, but got Ref
		//IL_029c: Expected O, but got Ref
		//IL_02aa: Expected O, but got Ref
		//IL_02cb: Expected F4, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		bool flag = ((UnityEngine.Object)playerTransform).m_CachedPtr == (IntPtr)0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Transform.get_position_Injected(((UnityEngine.Object)playerTransform).m_CachedPtr, out *(Vector3*)obj3);
		ref int reference = ref System.Runtime.CompilerServices.Unsafe.As<object, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		ref float normalizedDistanceOnLineSegment = default(ref float);
		Vector3 nearestPositionOnPathBetweenDanceFloors = GetNearestPositionOnPathBetweenDanceFloors(position, out reference, out normalizedDistanceOnLineSegment);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
		float num = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
		if (0f > 1f)
		{
			num = 1f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
			if ((nint)0 > (nint)0)
			{
				num = 0f;
			}
		}
		List<PathLineSegment> lineSegmentsBetweenDanceFloors = _lineSegmentsBetweenDanceFloors;
		object obj4 = 0;
		float num2 = 0f;
		object obj5 = 0;
		while (true)
		{
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+18]");
			if ((nint)obj6 >= 0)
			{
				break;
			}
			object obj7 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7F]");
			if (obj7 != null)
			{
				num2++;
				obj4++;
				obj5 = obj4;
				continue;
			}
			num2 += num;
			break;
		}
		_003CCurrentTotalNormalizedPosition_003Ek__BackingField = num2;
		_ = 0;
		_ = 0;
		bool flag2 = ((UnityEngine.Object)playerTransform).m_CachedPtr == (IntPtr)0;
		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Transform.get_position_Injected(((UnityEngine.Object)playerTransform).m_CachedPtr, out *(Vector3*)obj8);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FC0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		_ = nearestPositionOnPathBetweenDanceFloors.x;
		_ = nearestPositionOnPathBetweenDanceFloors.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
		_ = 0;
		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		Debug.DrawLine_Injected(ref *(Vector3*)obj11, ref *(Vector3*)obj10, ref *(Color*)obj9, (float)(nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference), false);
	}

	public unsafe bool TryGetNodeInDirection(MazerellaNavigationNodeDirection direction, NavigationNode currentNode, out NavigationNode navigationNode)
	{
		//IL_01e2: Expected I4, but got O
		//IL_0039: Expected O, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		ref NavigationNode reference = ref *(NavigationNode*)null;
		bool flag = direction == MazerellaNavigationNodeDirection.North;
		if (!flag)
		{
			object obj = direction - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						if (currentNode == null)
						{
							goto IL_01d4;
						}
						if (currentNode.WestNode != null)
						{
							reference = ref *(NavigationNode*)currentNode.WestNode;
							return true;
						}
					}
				}
				else
				{
					if (currentNode == null)
					{
						goto IL_01d4;
					}
					if (currentNode.EastNode != null)
					{
						reference = ref *(NavigationNode*)currentNode.EastNode;
						return true;
					}
				}
			}
			else
			{
				if (currentNode == null)
				{
					goto IL_01d4;
				}
				if (currentNode.SouthNode != null)
				{
					reference = ref *(NavigationNode*)currentNode.SouthNode;
					return true;
				}
			}
		}
		else
		{
			if (currentNode == null)
			{
				goto IL_01d4;
			}
			if (currentNode.NorthNode != null)
			{
				reference = ref *(NavigationNode*)currentNode.NorthNode;
				return true;
			}
		}
		return false;
		IL_01d4:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void ConfigureNavigationNodes(Tilemap walls)
	{
		CreateNodes();
		ProcessNavigationNodes(walls);
		PrecalculateNavigationWeights();
		CachePathBetweenDanceFloors();
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		Transform playerTransform = gameSessionData._activeCharacter.transform;
		UpdateNearestPositionToPlayer(playerTransform);
	}

	private void CreateNodes()
	{
		//IL_01c2: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_013f: Expected O, but got F4
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		List<NavigationNode> list = _003CNavigationNodes_003Ek__BackingField;
		int version = list._version + 1;
		list._version = version;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
		}
		float num = ((!GM.Core.IsStageVisuallyInverted()) ? 12.16f : 74.88f);
		bool flag = GM.Core.IsStageVisuallyInverted();
		float num2 = 74.88f;
		if (!flag)
		{
			num2 = 12.16f;
		}
		float num3 = ((!GM.Core.IsStageVisuallyInverted()) ? 5.12f : (-5.12f));
		object obj = 0;
		do
		{
			float num4 = (float)obj * num3;
			float num5 = num4 + num;
			object obj2 = 0;
			do
			{
				float num6 = (float)obj2 * num3;
				float num7 = num6 + num2;
				float num8 = num7 * -1f;
				NavigationNode navigationNode = new NavigationNode();
				navigationNode.Position = (Vector2)num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB35A0");
				obj2++;
			}
			while ((nint)obj2 < 13);
			obj++;
		}
		while ((nint)obj < 13);
	}

	private void ProcessNavigationNodes(Tilemap walls)
	{
		//IL_032b: Expected O, but got I4
		//IL_0339: Expected O, but got I4
		//IL_0279: Expected I, but got O
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02be: Expected I, but got O
		//IL_024d: Expected I, but got O
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		float num = ((!GM.Core.IsStageVisuallyInverted()) ? 2.56f : (-2.56f));
		object obj = 0;
		object obj4 = default(object);
		object obj5 = default(object);
		object obj6 = default(object);
		Vector2 vector = default(Vector2);
		do
		{
			object obj2 = 0;
			do
			{
				object obj3 = obj + obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93710");
				float num2 = (float)obj4 * num;
				float num3 = (float)obj5 * num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186135850");
				float num4 = (float)obj6 * num;
				float num5 = (float)obj5 * num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CAC1B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186863D20");
				float num6 = (float)obj5 * num;
				float num7 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v8+14]");
				float num8 = num7 + 0f;
				if (obj != null)
				{
					if (!_003CProcessNavigationNodes_003Eg__IsTileWallTile_007C34_0(vector, walls))
					{
						object obj7 = obj2 - 13;
						object obj8 = obj7 + obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					}
					if ((nint)obj == 156)
					{
						goto IL_01ce;
					}
				}
				if (!_003CProcessNavigationNodes_003Eg__IsTileWallTile_007C34_0(vector, walls))
				{
					object obj9 = obj2 + 13;
					object obj10 = obj9 + obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				}
				goto IL_01ce;
				IL_02cb:
				obj2++;
				continue;
				IL_01ce:
				nint num9;
				Vector2 vector2;
				if (obj2 != null)
				{
					if (!_003CProcessNavigationNodes_003Eg__IsTileWallTile_007C34_0(vector, walls))
					{
						object obj11 = obj2 - 1;
						object obj12 = obj11 + obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					}
					bool flag = (nint)obj2 == 12;
					num9 = unchecked((nint)null);
					vector2 = vector;
					if (flag)
					{
						goto IL_02cb;
					}
				}
				bool flag2 = _003CProcessNavigationNodes_003Eg__IsTileWallTile_007C34_0(vector, walls);
				num9 = unchecked((nint)null);
				vector2 = vector;
				if (!flag2)
				{
					object obj13 = obj2 + 1;
					object obj14 = obj13 + obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					num9 = unchecked((nint)null);
					vector2 = vector;
				}
				goto IL_02cb;
			}
			while ((nint)obj2 < 13);
			obj += 13;
		}
		while ((nint)obj < 169);
	}

	public MazerellaDancerMazeNavigation()
	{
		List<NavigationNode> list = new List<NavigationNode>();
		_003CNavigationNodes_003Ek__BackingField = list;
		List<PathLineSegment> lineSegmentsBetweenDanceFloors = new List<PathLineSegment>();
		_lineSegmentsBetweenDanceFloors = lineSegmentsBetweenDanceFloors;
	}

	private void _003CGetLowestWeightNode_003Eg__CheckIfNodeIsLowestWeight_007C22_0(NavigationNode node, ref _003C_003Ec__DisplayClass22_0 P_1)
	{
		if (node != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [ @ r8 (<>c__DisplayClass22_0&)+8]");
			int num = (((nint)0 != 0) ? node.RightDancerWeight : node.LeftDancerWeight);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [ @ r8 (<>c__DisplayClass22_0&)+C]");
			if ((nint)0 <= (nint)num)
			{
			}
		}
	}

	internal unsafe static bool _003CProcessNavigationNodes_003Eg__IsTileWallTile_007C34_0(Vector2 positionToCheck, Tilemap walls)
	{
		//IL_0089: Expected O, but got Ref
		bool flag = ((UnityEngine.Object)walls).m_CachedPtr == (IntPtr)0;
		Vector3 worldPosition = default(Vector3);
		GridLayout.WorldToCell_Injected(((UnityEngine.Object)walls).m_CachedPtr, ref worldPosition, out Vector3Int _);
		TileBase tile = walls.GetTile((Vector3Int)(&worldPosition));
		if ((object)tile != null)
		{
			bool flag2 = ((UnityEngine.Object)tile).m_CachedPtr == (IntPtr)0;
			return !flag2;
		}
		return false;
	}
}
