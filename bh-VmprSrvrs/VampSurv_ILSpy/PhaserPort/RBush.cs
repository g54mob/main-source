using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;

public class RBush
{
	public class RectangularBox : IRectangular
	{
		public RectangularBox()
		{
			//IL_0015: Expected I, but got O
			nint num = (nint)typeof(IRectangular);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<RBush+IRectangular>)+E4]");
			if ((nint)0 != 0)
			{
			}
		}
	}

	public abstract class IRectangular
	{
		public static readonly Comparison<IRectangular> CompareMinX;

		public static readonly Comparison<IRectangular> CompareMinY;

		public float MinX;

		public float MinY;

		public float MaxX;

		public float MaxY;

		[MethodImpl((MethodImplOptions)256)]
		private static int compareNodeMinX(IRectangular a, IRectangular b)
		{
			float value = a.MinX - b.MinX;
			return Math.Sign(value);
		}

		[MethodImpl((MethodImplOptions)256)]
		private static int compareNodeMinY(IRectangular a, IRectangular b)
		{
			float value = a.MinY - b.MinY;
			return Math.Sign(value);
		}

		static IRectangular()
		{
			Comparison<IRectangular> compareMinX = compareNodeMinX;
			CompareMinX = compareMinX;
			Comparison<IRectangular> compareMinY = compareNodeMinY;
			CompareMinY = compareMinY;
		}
	}

	public class Node : IRectangular
	{
		public List<IRectangular> children;

		public int height;

		public bool leaf;

		public void Clear()
		{
			List<IRectangular> list = children;
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
			}
			height = 1;
			leaf = true;
			MinX = 1f / 0f;
			MinY = 1f / 0f;
			MaxX = -1f / 0f;
			MaxY = -1f / 0f;
		}

		public Node()
		{
			//IL_0015: Expected I, but got O
			nint num = (nint)typeof(IRectangular);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<RBush+IRectangular>)+E4]");
			if ((nint)0 != 0)
			{
			}
		}
	}

	private int _maxEntries;

	private int _minEntries;

	private Node data;

	private List<BaseBody> _searchResults;

	private Node[] _nodesToSearch;

	private int _nodesToSearchCount;

	private List<Node> _insertPath;

	private List<Node> _liveNodes;

	private List<Node> _spareNodes;

	private List<IRectangular> _convertedList;

	private static readonly ProfilerMarker s_searchMarker;

	private static readonly ProfilerMarker s_loadMarker;

	private List<IRectangular> _innerNodesToSearch;

	private Stack<int> _multiSelectStack;

	public RBush(int maxEntries = 9)
	{
		List<BaseBody> searchResults = new List<BaseBody>();
		_searchResults = searchResults;
		Node[] nodesToSearch = new Node[64];
		_nodesToSearch = nodesToSearch;
		List<Node> insertPath = new List<Node>();
		_insertPath = insertPath;
		List<Node> liveNodes = new List<Node>();
		_liveNodes = liveNodes;
		List<Node> spareNodes = new List<Node>();
		_spareNodes = spareNodes;
		List<IRectangular> convertedList = new List<IRectangular>();
		_convertedList = convertedList;
		List<IRectangular> innerNodesToSearch = new List<IRectangular>();
		_innerNodesToSearch = innerNodesToSearch;
		Stack<int> multiSelectStack = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4740");
		_multiSelectStack = multiSelectStack;
		bool flag = maxEntries <= 4;
		int num = 4;
		if (!flag)
		{
			num = maxEntries;
		}
		_maxEntries = num;
		float num2 = (float)num * 0.4f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		Node[] nodesToSearch2 = _nodesToSearch;
		int num3 = default(int);
		if (num3 <= 2)
		{
			num3 = 2;
		}
		_minEntries = num3;
		nodesToSearch2[0] = null;
		RBush rBush = clear();
	}

	public List<BaseBody> all()
	{
		List<BaseBody> result = new List<BaseBody>();
		return _all(data, result);
	}

	public List<BaseBody> search(IRectangular bbox)
	{
		//IL_0874: Expected I, but got O
		//IL_010e: Expected I, but got O
		//IL_019c: Expected O, but got I
		//IL_01a5: Expected O, but got I4
		//IL_07e1: Expected O, but got I4
		//IL_0814: Expected O, but got I
		//IL_029b: Expected O, but got I4
		//IL_0900: Unknown result type (might be due to invalid IL or missing references)
		//IL_0905: Expected O, but got Unknown
		//IL_0922: Expected I4, but got O
		//IL_02d4: Expected O, but got I4
		//IL_06e5: Expected I, but got O
		//IL_06ed: Expected I, but got O
		//IL_06fd: Expected O, but got I
		//IL_0735: Expected O, but got I
		//IL_0371: Invalid comparison between F4 and I4
		//IL_039a: Expected O, but got I4
		//IL_03d4: Invalid comparison between F4 and I4
		//IL_03fd: Expected O, but got I4
		//IL_040a: Expected I4, but got O
		//IL_077d: Expected O, but got I
		//IL_0975: Expected O, but got I4
		//IL_0604: Expected I, but got O
		//IL_060c: Expected I, but got O
		//IL_061c: Expected O, but got I
		//IL_0654: Expected O, but got I
		//IL_069a: Expected O, but got I4
		//IL_06a4: Expected I4, but got O
		//IL_0495: Expected I, but got O
		//IL_049d: Expected I, but got O
		//IL_04ad: Expected O, but got I
		//IL_04e5: Expected O, but got I
		//IL_0516: Expected I, but got O
		//IL_0547: Expected I, but got O
		//IL_054f: Expected I, but got O
		//IL_055f: Expected O, but got I
		//IL_0597: Expected O, but got I
		//IL_05e9: Expected I4, but got O
		//IL_0831->IL09cb: Incompatible stack heights: 3 vs 2
		//IL_0819->IL09ae: Incompatible stack heights: 6 vs 3
		//IL_06bc->IL0983: Incompatible stack heights: 5 vs 3
		//IL_0788->IL06a9: Incompatible stack heights: 8 vs 5
		//IL_06a9->IL06a9: Incompatible stack heights: 7 vs 5
		//IL_05f6->IL0983: Incompatible stack heights: 11 vs 3
		if ((object)s_searchMarker != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)s_searchMarker);
		}
		Node node = data;
		bool flag = data == null;
		bool flag2 = bbox == null;
		float maxX = bbox.MaxX;
		float maxX2 = node.MaxX;
		float maxY = node.MaxY;
		float maxY2 = bbox.MaxY;
		bool flag3 = node.MaxY < bbox.MinY;
		bool flag4 = !flag3;
		bool flag5 = node.MaxX < bbox.MinX;
		bool flag6 = !flag5;
		int num = ((flag4 & flag6) ? 1 : 0);
		bool flag7 = !(bbox.MaxY < node.MinY);
		int num2 = num;
		if (!flag7)
		{
			num2 = 0;
		}
		bool flag8 = maxX < node.MinX;
		bool flag9 = !flag8;
		List<BaseBody> result;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (((flag9 ? 1u : 0u) & (uint)num2) != 0)
		{
			nint num3 = (nint)_searchResults;
			bool flag10 = _searchResults == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v13 (Il2CppClass<RBush>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v13 (Il2CppClass<RBush>)+18]");
			int num4 = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v13 (Il2CppClass<RBush>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v13 (Il2CppClass<RBush>)+10]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v13 (Il2CppClass<RBush>)+18]");
				Array.Clear((Array)num5, 0, 0);
				object obj = 0;
				num2 = 0;
			}
			_nodesToSearchCount = 1;
			int num6 = 0;
			IRectangular rectangular = bbox;
			BaseBody baseBody = default(BaseBody);
			object obj8 = default(object);
			while (node != null)
			{
				int num7 = num6;
				while (true)
				{
					List<BaseBody> children = (List<BaseBody>)(object)node.children;
					bool flag11 = node.children == null;
					if (num7 >= children._size)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag12 = baseBody == null;
					maxX = rectangular.MaxX;
					maxX2 = baseBody.MaxX;
					maxY = baseBody.MaxY;
					maxY2 = rectangular.MaxY;
					bool flag13 = baseBody.MaxY < rectangular.MinY;
					bool flag14 = !flag13;
					bool flag15 = baseBody.MaxX < rectangular.MinX;
					bool flag16 = !flag15;
					Array array = (Array)(flag14 & flag16);
					bool flag17 = !(rectangular.MaxY < baseBody.MinY);
					Array array2 = array;
					if (!flag17)
					{
						array2 = (Array)num6;
					}
					bool flag18 = maxX < baseBody.MinX;
					bool flag19 = !flag18;
					object obj2 = flag19 & array2;
					bool flag20 = obj2 == null;
					num4 = (int)typeof(RBush);
					if (!flag20)
					{
						if (!node.leaf)
						{
							maxX = baseBody.MinX;
							maxX2 = rectangular.MaxX;
							maxY = rectangular.MaxY;
							maxY2 = baseBody.MinY;
							bool flag21 = rectangular.MaxY < baseBody.MaxY;
							float num8 = rectangular.MaxY - baseBody.MaxY;
							bool flag22 = num8 == 0f;
							bool flag23 = !flag21;
							bool flag24 = !flag22;
							object obj3 = flag24 & flag23;
							bool flag25 = rectangular.MaxX < baseBody.MaxX;
							float num9 = rectangular.MaxX - baseBody.MaxX;
							bool flag26 = num9 == 0f;
							bool flag27 = !flag25;
							bool flag28 = !flag26;
							object obj4 = flag28 & flag27;
							int num10 = obj3 & obj4;
							bool flag29 = !(baseBody.MinY < rectangular.MinY);
							int num11 = num10;
							if (!flag29)
							{
								num11 = num6;
							}
							bool flag30 = maxX < rectangular.MinX;
							bool flag31 = !flag30;
							int num12 = (flag31 ? 1 : 0) & num11;
							bool flag32 = num12 == 0;
							object obj5 = !flag32;
							if (obj5 == null)
							{
								Array nodesToSearch = _nodesToSearch;
								int nodesToSearchCount = _nodesToSearchCount + 1;
								_nodesToSearchCount = nodesToSearchCount;
								bool flag33 = _nodesToSearch == null;
								nint num13 = (nint)typeof(Node);
								nint num14 = (nint)baseBody;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rdx_v21 (Il2CppClass<RBush+Node>)+130]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ r8_v11 (Il2CppClass<BaseBody>)+130]");
								nint num15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rdx_v21 (Il2CppClass<RBush+Node>)+130]");
								bool flag34 = num15 < 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ r8_v11 (Il2CppClass<BaseBody>)+C8]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rax_v40+FFFFFFF8+v626 @ rax_v39*8]");
								bool flag35 = 0 != (nint)typeof(Node);
								nint num16 = (nint)nodesToSearch;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								bool flag36 = obj8 == null;
								nint num17 = (nint)typeof(Node);
								nint num18 = (nint)baseBody;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ r8_v12 (Il2CppClass<RBush+Node>)+130]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rcx_v33 (Il2CppClass<BaseBody>)+130]");
								nint num19 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ r8_v12 (Il2CppClass<RBush+Node>)+130]");
								bool flag37 = num19 < 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rcx_v33 (Il2CppClass<BaseBody>)+C8]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v44+FFFFFFF8+v557 @ rax_v43*8]");
								bool flag38 = 0 != (nint)typeof(Node);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								num7++;
								num6 = 0;
								num4 = (int)baseBody;
								rectangular = bbox;
								continue;
							}
							nint num20 = (nint)typeof(Node);
							nint num21 = (nint)baseBody;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v19 (Il2CppClass<RBush+Node>)+130]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ r9_v8 (Il2CppClass<BaseBody>)+130]");
							nint num22 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v19 (Il2CppClass<RBush+Node>)+130]");
							bool flag39 = num22 < 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ r9_v8 (Il2CppClass<BaseBody>)+C8]");
							object obj12 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ rax_v36+FFFFFFF8+v803 @ rax_v35*8]");
							bool flag40 = 0 != (nint)typeof(Node);
							List<BaseBody> list = _all((Node)(object)baseBody, _searchResults);
							object obj = 0;
							num4 = (int)_searchResults;
						}
						else
						{
							bool flag41 = _searchResults == null;
							nint num23 = (nint)typeof(BaseBody);
							nint num24 = (nint)baseBody;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rdx_v15 (Il2CppClass<BaseBody>)+130]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ r10_v5 (Il2CppClass<BaseBody>)+130]");
							nint num25 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rdx_v15 (Il2CppClass<BaseBody>)+130]");
							bool flag42 = num25 < 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ r10_v5 (Il2CppClass<BaseBody>)+C8]");
							object obj14 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ rax_v29+FFFFFFF8+v921 @ rax_v28*8]");
							bool flag43 = 0 != (nint)typeof(BaseBody);
							_searchResults.Add(baseBody);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rdx_v15 (Il2CppClass<BaseBody>)+130]");
							object obj = 0;
							num4 = 0;
						}
					}
					num7++;
				}
				Array nodesToSearch2 = _nodesToSearch;
				num2 = _nodesToSearchCount;
				int nodesToSearchCount2 = _nodesToSearchCount - 1;
				_nodesToSearchCount = nodesToSearchCount2;
				bool flag44 = _nodesToSearch == null;
				object obj15 = _nodesToSearchCount - 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rcx_v18 (System.Array)+18]");
				bool flag45 = (nint)obj15 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rcx_v18 (System.Array)+20+v1115 @ r12_v6*8]");
				node = (Node)0;
			}
			result = _searchResults;
			autoScope.Dispose();
		}
		else
		{
			List<BaseBody> list2 = new List<BaseBody>();
			autoScope.Dispose();
			result = list2;
		}
		return result;
	}

	public unsafe RBush load(HashSet<PhaserGameObject> data)
	{
		//IL_0091: Expected native int or pointer, but got O
		//IL_00ac: Expected native int or pointer, but got O
		//IL_00d0: Expected O, but got I4
		//IL_0648: Expected O, but got Ref
		//IL_03d5: Expected O, but got I
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected I4, but got Unknown
		if (data != null && data._count > 0)
		{
			HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
			if (data._count >= _minEntries)
			{
				HashSet<object>.Enumerator convertedList = (HashSet<object>.Enumerator)_convertedList;
				if (_convertedList != null)
				{
					int version = convertedList._version + 1;
					((HashSet<object>.Enumerator*)(nint)convertedList)->_version = version;
					int index = convertedList._index;
					((HashSet<object>.Enumerator*)(nint)convertedList)->_index = 0;
					bool flag = convertedList._index <= 0;
					bool flag2 = default(bool);
					string text = (string)flag2;
					if (!flag)
					{
						Array.Clear((Array)(object)convertedList._set, 0, convertedList._index);
						text = null;
					}
					while (enumerator.MoveNext())
					{
						Component component = null;
						Debug.LogError("RTree load has a null PhaserGameObject!");
					}
					List<IRectangular> convertedList2 = _convertedList;
					bool flag3 = _convertedList == null;
					convertedList = (HashSet<object>.Enumerator)(&enumerator);
					if (!flag3)
					{
						int right = convertedList2._size - 1;
						int? height = default(int?);
						Node node = _build(_convertedList, 0, right, height);
						Node node2 = this.data;
						bool flag4 = this.data == null;
						convertedList = (HashSet<object>.Enumerator)node;
						if (!flag4)
						{
							List<IRectangular> children = node2.children;
							bool flag5 = node2.children == null;
							convertedList = (HashSet<object>.Enumerator)node;
							if (!flag5)
							{
								if (children._size != 0)
								{
									Node node3 = this.data;
									bool flag6 = node == null;
									convertedList = (HashSet<object>.Enumerator)node;
									if (flag6)
									{
										goto IL_05ca;
									}
									int height2 = node3.height;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v57 (RBush+Node)+28]");
									if ((nint)height2 != 0)
									{
										int height3 = node3.height;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v57 (RBush+Node)+28]");
										bool flag7 = (nint)height3 >= (nint)0;
										convertedList = (HashSet<object>.Enumerator)node;
										if (!flag7)
										{
											this.data = node;
											convertedList = (HashSet<object>.Enumerator)this.data;
										}
										Node node4 = this.data;
										if (this.data == null)
										{
											goto IL_05ca;
										}
										int height4 = node4.height;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rcx_v29 (System.Collections.Generic.HashSet`1<System.Object>+Enumerator<System.Object>)+28]");
										object obj = (nint)height4 - (nint)0;
										int level = obj - 1;
										_insert((IRectangular)convertedList, level, isNode: true);
									}
									else
									{
										_splitRoot(node3, node);
									}
								}
								else
								{
									this.data = node;
								}
								goto IL_05c8;
							}
						}
					}
				}
				goto IL_05ca;
			}
			while (enumerator.MoveNext())
			{
				Component component2 = null;
				Debug.LogError("RTree load has a null PhaserGameObject!");
			}
		}
		goto IL_05c8;
		IL_05ca:
		throw new NullReferenceException();
		IL_05c8:
		return this;
	}

	public RBush insert(IRectangular item)
	{
		if (item != null)
		{
			Node node = data;
			if (data == null)
			{
				return (RBush)(object)new NullReferenceException();
			}
			int level = node.height - 1;
			_insert(item, level);
		}
		return this;
	}

	public RBush clear()
	{
		List<object> spareNodes = (List<object>)(object)_spareNodes;
		if (_spareNodes != null)
		{
			((List<object>)(object)_spareNodes).InsertRange(spareNodes._size, (IEnumerable<object>)_liveNodes);
			List<Node> liveNodes = _liveNodes;
			if (_liveNodes != null)
			{
				int version = liveNodes._version + 1;
				liveNodes._version = version;
				liveNodes._size = 0;
				if (liveNodes._size > 0)
				{
					Array.Clear(liveNodes._items, 0, liveNodes._size);
				}
				Node node = createNode();
				data = node;
				return this;
			}
		}
		return (RBush)(object)new NullReferenceException();
	}

	public RBush remove(IRectangular item, Func<IRectangular, IRectangular, bool> equalsFn = null)
	{
		//IL_083e: Expected O, but got I4
		//IL_081b: Expected I4, but got O
		//IL_0107: Expected O, but got I
		//IL_03d3: Expected I, but got O
		//IL_012f: Expected O, but got I
		//IL_015d: Expected O, but got I
		//IL_0165: Expected I, but got O
		//IL_06d3: Expected O, but got I
		//IL_04fc: Expected O, but got I
		//IL_0759: Expected O, but got I4
		//IL_076f: Expected I4, but got O
		//IL_00c3: Expected O, but got I4
		//IL_0588: Expected I, but got O
		//IL_01dc: Invalid comparison between I and F4
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_021b: Expected O, but got I
		//IL_0258: Expected O, but got I4
		//IL_026d: Invalid comparison between I and F4
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		//IL_02bf: Expected O, but got I4
		//IL_02cc: Expected I, but got O
		//IL_02e1: Invalid comparison between F4 and I
		//IL_060d: Expected O, but got I
		//IL_0789: Invalid comparison between F4 and I
		//IL_07a7: Expected O, but got I
		//IL_05e6: Expected I, but got O
		//IL_0305: Expected I, but got O
		//IL_0649: Expected O, but got I
		//IL_06ac: Expected I, but got O
		//IL_0341: Expected O, but got I
		//IL_034f: Expected I, but got O
		//IL_042a: Expected O, but got I
		//IL_0395: Expected O, but got I
		//IL_03bc: Expected I, but got O
		//IL_0466: Expected O, but got I
		//IL_04da: Expected I, but got O
		if (item != null)
		{
			Node node = data;
			List<Node> list = new List<Node>();
			List<int> list2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
			Func<IRectangular, IRectangular, bool> func = equalsFn;
			int num = 0;
			int num2 = 0;
			nint num3 = 0;
			Node node2 = null;
			float num5 = default(float);
			object obj3 = default(object);
			float num7 = default(float);
			Node node4 = default(Node);
			nint num9 = default(nint);
			Node node5 = default(Node);
			int num17 = default(int);
			Node node6 = default(Node);
			while (true)
			{
				object obj = 0;
				float num4;
				object obj2;
				float num6;
				Node node3;
				Func<IRectangular, IRectangular, bool> func2;
				nint num8;
				while (true)
				{
					bool flag = node != null;
					num4 = num5;
					obj2 = obj3;
					num6 = num7;
					node3 = node4;
					func2 = func;
					num8 = num9;
					nint num10 = num3;
					int num11 = (int)node;
					if (!flag)
					{
						goto IL_005c;
					}
					goto IL_00e8;
					IL_00e8:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+2C]");
					bool flag2 = (nint)0 == 0;
					IRectangular rectangular = (IRectangular)num10;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+20]");
						int num12 = findItem(item, (List<IRectangular>)0, equalsFn);
						bool flag3 = num12 != -1;
						node3 = node2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+20]");
						func2 = (Func<IRectangular, IRectangular, bool>)0;
						num8 = (nint)equalsFn;
						rectangular = item;
						if (flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+20]");
							((List<IRectangular>)0).RemoveAt(num12);
							((List<IRectangular>)(object)list).RemoveAt(num11);
							_condense(list);
							break;
						}
					}
					if (obj == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+2C]");
						if (0 == (nint)obj)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+1C]");
							bool flag4 = 0f < item.MaxY;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+1C]");
							object obj4 = 0 - item.MaxY;
							bool flag5 = obj4 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+18]");
							obj2 = 0;
							num4 = item.MinY;
							num6 = item.MinX;
							bool flag6 = !flag4;
							bool flag7 = !flag5;
							object obj5 = flag7 & flag6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+18]");
							bool flag8 = 0f < item.MaxX;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+18]");
							object obj6 = 0 - item.MaxX;
							bool flag9 = obj6 == null;
							bool flag10 = !flag8;
							bool flag11 = !flag9;
							object obj7 = flag11 & flag10;
							nint num13 = obj5 & obj7;
							float minY = item.MinY;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+14]");
							bool flag12 = !(minY < 0f);
							num3 = num13;
							if (!flag12)
							{
								num3 = unchecked((nint)null);
							}
							float num14 = num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+10]");
							bool flag13 = num14 < 0f;
							bool flag14 = !flag13;
							object obj8 = (flag14 ? 1 : 0) & num3;
							bool flag15 = obj8 == null;
							node2 = null;
							if (!flag15)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4820");
								list2.Add(num2);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v9 (System.Int32)+20]");
								((List<int>)0).Add(0);
								nint num15 = (nint)typeof(Node);
								if (node5 == null)
								{
									num5 = num4;
									obj3 = obj2;
									num7 = num6;
									node4 = node3;
									func = (Func<IRectangular, IRectangular, bool>)0;
									num9 = num8;
									num = num11;
									num2 = 0;
									num3 = (nint)typeof(Node);
									node = null;
									node2 = null;
									continue;
								}
								func = (Func<IRectangular, IRectangular, bool>)(object)node5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rdx_v19 (Il2CppClass<RBush+Node>)+130]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v15 (System.Func`3<RBush+IRectangular, RBush+IRectangular, System.Boolean>)+130]");
								nint num16 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rdx_v19 (Il2CppClass<RBush+Node>)+130]");
								if (num16 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v15 (System.Func`3<RBush+IRectangular, RBush+IRectangular, System.Boolean>)+C8]");
									object obj10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31+FFFFFFF8+v645 @ rax_v30*8]");
									if (0 == (nint)typeof(Node))
									{
										num5 = num4;
										obj3 = obj2;
										num7 = num6;
										node4 = node3;
										num9 = num8;
										num = num11;
										num2 = 0;
										num3 = (nint)typeof(Node);
										node = node5;
										node2 = null;
										continue;
									}
								}
								throw new InvalidCastException();
							}
							goto IL_0851;
						}
					}
					num3 = (nint)rectangular;
					node2 = null;
					goto IL_0851;
					IL_005c:
					if (list._size <= 0)
					{
						break;
					}
					object obj11 = ListExtensions.Pop((List<object>)(object)list);
					if (list._size != 0)
					{
						object obj12 = list._size - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						num = num17;
					}
					else
					{
						num = 0;
					}
					int num18 = ListExtensions.Pop(list2);
					num4 = num5;
					obj2 = obj3;
					num6 = num7;
					node3 = node4;
					func2 = func;
					num8 = num9;
					obj = 1;
					num2 = num18;
					num10 = 0;
					num11 = (int)obj11;
					node2 = null;
					goto IL_00e8;
					IL_0851:
					if (num == 0)
					{
						num5 = num4;
						obj3 = obj2;
						num7 = num6;
						node4 = node3;
						func = func2;
						num9 = num8;
						goto IL_005c;
					}
					goto IL_04ec;
				}
				break;
				IL_04ec:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rsi_v9 (System.Int32)+20]");
				object obj13 = 0;
				num2++;
				int num19 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v19+18]");
				if ((nint)num19 >= (nint)0)
				{
					num5 = num4;
					obj3 = obj2;
					num7 = num6;
					node4 = node3;
					func = func2;
					num9 = num8;
					node = node2;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				nint num20 = (nint)typeof(Node);
				if (node6 == null)
				{
					num5 = num4;
					obj3 = obj2;
					num7 = num6;
					node4 = node3;
					func = func2;
					num9 = num8;
					num3 = (nint)typeof(Node);
					node = null;
					node2 = null;
					continue;
				}
				func = (Func<IRectangular, IRectangular, bool>)(object)node6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v13 (Il2CppClass<RBush+Node>)+130]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v15 (System.Func`3<RBush+IRectangular, RBush+IRectangular, System.Boolean>)+130]");
				nint num21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v13 (Il2CppClass<RBush+Node>)+130]");
				if (num21 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v15 (System.Func`3<RBush+IRectangular, RBush+IRectangular, System.Boolean>)+C8]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v22+FFFFFFF8+v766 @ rax_v21*8]");
					if (0 == (nint)typeof(Node))
					{
						num5 = num4;
						obj3 = obj2;
						num7 = num6;
						node4 = node3;
						num9 = num8;
						num3 = (nint)typeof(Node);
						node = node6;
						node2 = null;
						continue;
					}
				}
				return (RBush)(object)new InvalidCastException();
			}
		}
		return this;
	}

	private List<BaseBody> _all(Node node, List<BaseBody> result)
	{
		//IL_0086: Expected I, but got O
		//IL_0241: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		//IL_028f: Expected I, but got O
		//IL_014e: Expected O, but got I4
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_018d: Expected I, but got O
		//IL_02b4: Expected I, but got O
		//IL_02c4: Expected O, but got I
		//IL_01b2: Expected I4, but got O
		//IL_01c2: Expected O, but got I
		//IL_0300: Expected O, but got I
		//IL_01fe: Expected O, but got I
		List<IRectangular> innerNodesToSearch = _innerNodesToSearch;
		int num = innerNodesToSearch._size;
		int version = innerNodesToSearch._version + 1;
		innerNodesToSearch._version = version;
		innerNodesToSearch._size = 0;
		if (innerNodesToSearch._size > 0)
		{
			Array.Clear(innerNodesToSearch._items, 0, innerNodesToSearch._size);
			nint num2 = unchecked((nint)null);
		}
		List<object> innerNodesToSearch2 = (List<object>)(object)_innerNodesToSearch;
		bool flag = node == null;
		Node node2 = node;
		if (!flag)
		{
			BaseBody baseBody = default(BaseBody);
			Node node3 = default(Node);
			while (true)
			{
				if (!node2.leaf)
				{
					IEnumerable<object> children = node2.children;
					((List<object>)(object)_innerNodesToSearch).InsertRange(innerNodesToSearch2._size, (IEnumerable<object>)node2.children);
					nint num2 = 0;
				}
				else
				{
					object obj = 0;
					while (true)
					{
						List<IRectangular> children2 = node2.children;
						bool flag2 = (nint)obj >= children2._size;
						IEnumerable<object> children = (IEnumerable<object>)num;
						if (flag2)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						nint num3 = (nint)typeof(BaseBody);
						if (baseBody == null)
						{
							goto IL_032d;
						}
						nint num2 = (nint)baseBody;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ r8_v8 (Il2CppClass<BaseBody>)+130]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ r9_v8 (Il2CppMethodInfo)+130]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ r8_v8 (Il2CppClass<BaseBody>)+130]");
						if (num4 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ r9_v8 (Il2CppMethodInfo)+C8]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rcx_v16+FFFFFFF8+v382 @ rcx_v15*8]");
							if (0 == (nint)typeof(BaseBody))
							{
								goto IL_032d;
							}
						}
						goto IL_0376;
						IL_032d:
						result.Add(baseBody);
						obj++;
						num = 0;
					}
				}
				if (innerNodesToSearch2._size == 0)
				{
					break;
				}
				object obj4 = innerNodesToSearch2._size - 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				int index = innerNodesToSearch2._size - 1;
				_innerNodesToSearch.RemoveAt(index);
				nint num5 = (nint)typeof(Node);
				if (node3 == null)
				{
					break;
				}
				num = (int)node3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rdx_v18 (Il2CppClass<RBush+Node>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r8_v7 (System.Int32)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rdx_v18 (Il2CppClass<RBush+Node>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r8_v7 (System.Int32)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v21+FFFFFFF8+v267 @ rax_v20*8]");
					if (0 == (nint)typeof(Node))
					{
						node2 = node3;
						continue;
					}
				}
				InvalidCastException ex = new InvalidCastException();
				goto IL_0376;
				IL_0376:
				return (List<BaseBody>)(object)new InvalidCastException();
			}
		}
		return result;
	}

	private Node _build(List<IRectangular> items, int left, int right, int? height = null)
	{
		//IL_05be: Expected O, but got I4
		//IL_05d8: Invalid comparison between F8 and I4
		//IL_0042: Expected F8, but got I4
		//IL_007b: Invalid comparison between F8 and I4
		//IL_0171: Expected I, but got O
		//IL_00ce: Expected O, but got I4
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected I4, but got Unknown
		//IL_00f8: Expected I4, but got F8
		//IL_0101: Expected O, but got I4
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Expected O, but got Unknown
		//IL_01e5: Expected F8, but got I4
		//IL_0615: Expected O, but got I4
		//IL_01d7: Expected F8, but got I4
		//IL_028e: Invalid comparison between F8 and I4
		//IL_029f: Expected I4, but got F8
		//IL_0657: Unknown result type (might be due to invalid IL or missing references)
		//IL_065c: Expected I4, but got Unknown
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected I4, but got Unknown
		//IL_02fd: Invalid comparison between F8 and I4
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected I4, but got Unknown
		int num = _maxEntries;
		object obj = right - left;
		double num2 = (double)obj + 1.0;
		Node node;
		int? num27 = default(int?);
		if (num2 > (double)_maxEntries)
		{
			object obj2 = default(object);
			int height2;
			object obj7;
			if (obj2 == null)
			{
				double a = Math.Log(num2);
				double num3 = Math.Log(_maxEntries);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm6,xmm0\"");
				double num4 = Math.Ceiling(a);
				double num5 = num4 - 1.0;
				bool flag = !(num5 > 0.0);
				int num6 = 1;
				int num7 = 1;
				int num8 = _maxEntries;
				if (!flag)
				{
					object obj4;
					do
					{
						object obj3 = 1 & num5;
						bool flag2 = obj3 == null;
						if (!flag2)
						{
							num7 *= num8;
						}
						num8 *= num8;
						num5 >>= 1;
						obj4 = !flag2;
						num6 = num7;
					}
					while (obj4 != null);
				}
				object obj5 = num - 1;
				object obj6 = obj5 + num6;
				int num9 = obj6 / num6;
				num = num9;
				height2 = (int)num4;
				obj7 = 1;
			}
			else
			{
				int num10 = default(int);
				height2 = num10;
				obj7 = obj2;
			}
			node = createNode();
			node.leaf = false;
			if (obj7 == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				throw new IndexOutOfRangeException();
			}
			node.height = height2;
			double num11 = num2 - 1.0;
			nint num12 = (nint)typeof(Math);
			double num13 = num11 + (double)num;
			double num14 = num13 / (double)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ rcx_v27 (Il2CppClass<System.Math>)+E4]");
			double a2;
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
				a2 = 0.0;
			}
			else
			{
				a2 = Math.Sqrt(num);
			}
			double num15 = Math.Ceiling(a2);
			double num16 = num15 * num14;
			if (items != null)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18310E630");
			bool flag3 = left > right;
			RBush rBush = this;
			if (!flag3)
			{
				double num17 = num16 - 1.0;
				RBush rBush2 = this;
				double num18 = num17;
				int num19 = left;
				int num20 = right;
				bool flag5;
				do
				{
					double num21 = num18 + (double)num19;
					double num22 = num18 + (double)num19;
					bool flag4 = !(num21 > (double)num20);
					int num23 = (int)num22;
					if (!flag4)
					{
						num23 = num20;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18310E630");
					if (num19 <= num23)
					{
						double num24 = num14 - 1.0;
						int num25 = num19;
						do
						{
							double num26 = num24 + (double)num25;
							int right2 = (int)(num24 + num25);
							if (num26 > (double)num23)
							{
								right2 = num23;
							}
							Node node2 = _build(items, num25, right2, num27);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B47C0");
							num25 = (int)(num25 + num14);
							num24 = num14 - 1.0;
						}
						while (num25 <= num23);
						num18 = num17;
						num20 = right;
					}
					num19 = (int)(num19 + num16);
					flag5 = num19 <= num20;
					rBush = this;
					rBush2 = this;
				}
				while (flag5);
			}
			List<IRectangular> children = node.children;
			Node node3 = rBush.distBBox(node, 0, children._size, (Node)num27);
		}
		else
		{
			node = createNode();
			int num28 = right + 1;
			List<IRectangular> children2 = node.children;
			if (node.children != null)
			{
				if (num28 == -1)
				{
					num28 = items._size;
				}
				if (left < num28)
				{
					int num29 = left;
					Node result = default(Node);
					do
					{
						if (num29 < items._size)
						{
							IRectangular[] items2 = items._items;
							IRectangular[] items3 = children2._items;
							int version = children2._version + 1;
							children2._version = version;
							if (children2._size >= items3.Length)
							{
								((List<object>)(object)node.children).AddWithResize((object)items2[num29]);
							}
							else
							{
								int size = children2._size + 1;
								children2._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							num29++;
							continue;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						return result;
					}
					while (num29 < num28);
				}
			}
			else
			{
				if (num28 == -1)
				{
					num28 = items._size;
				}
				int count = num28 - left;
				List<IRectangular> range = items.GetRange(left, count);
			}
			List<IRectangular> children3 = node.children;
			Node node4 = distBBox(node, 0, children3._size, (Node)num27);
		}
		return node;
	}

	private Node _chooseSubtree(IRectangular bbox, Node node, int level, List<Node> path)
	{
		//IL_00b3: Expected O, but got I4
		//IL_0113: Expected O, but got I4
		//IL_01a8: Expected I, but got O
		//IL_0523: Expected I, but got O
		//IL_01c6: Expected I, but got O
		//IL_01d6: Expected O, but got I
		//IL_0562: Expected I, but got O
		//IL_0572: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_05ae: Expected O, but got I
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected O, but got Unknown
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Expected O, but got Unknown
		Node node2 = null;
		Node node3 = node;
		List<object> list = default(List<object>);
		object obj4 = default(object);
		while (true)
		{
			int version = list._version + 1;
			list._version = version;
			object[] items = list._items;
			if (list._size >= items.Length)
			{
				list.AddWithResize((object)node3);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Node node4;
			object obj3;
			if (!node3.leaf)
			{
				object obj = list._size - 1;
				if ((nint)obj != level)
				{
					List<IRectangular> children = node3.children;
					bool flag = children._size <= 0;
					float num = 1f / 0f;
					float num2 = 1f / 0f;
					object obj2 = 0;
					node4 = node2;
					obj3 = obj4;
					if (flag)
					{
						goto IL_047a;
					}
					while (true)
					{
						List<IRectangular> children2 = node3.children;
						if ((nint)obj2 >= children2._size)
						{
							break;
						}
						IRectangular[] items2 = children2._items;
						Node node5;
						float num8;
						float maxX;
						if ((nint)obj2 < items2.Length)
						{
							nint num3 = (nint)typeof(Node);
							node5 = (Node)items2[obj2];
							nint num4 = (nint)node5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v12 (Il2CppClass<RBush+Node>)+130]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ r8_v11 (Il2CppClass<RBush+Node>)+130]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v12 (Il2CppClass<RBush+Node>)+130]");
							if (num5 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ r8_v11 (Il2CppClass<RBush+Node>)+C8]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rax_v28+FFFFFFF8+v398 @ rax_v27*8]");
								if (0 == (nint)typeof(Node))
								{
									float num6 = node5.MaxY - node5.MinY;
									float num7 = node5.MaxX - node5.MinX;
									num8 = num6 * num7;
									maxX = bbox.MaxX;
									if (!(node5.MaxX > bbox.MaxX))
									{
										object obj7 = node5.MaxX & -2147483649L;
										if ((nint)obj7 <= 2139095040)
										{
											goto IL_0643;
										}
									}
									maxX = node5.MaxX;
									goto IL_0643;
								}
							}
							throw new InvalidCastException();
						}
						goto IL_0629;
						IL_0643:
						float minX = bbox.MinX;
						if (!(bbox.MinX > node5.MinX))
						{
							object obj8 = node5.MinX & -2147483649L;
							if ((nint)obj8 <= 2139095040)
							{
								goto IL_0676;
							}
						}
						minX = node5.MinX;
						goto IL_0676;
						IL_0734:
						obj2++;
						bool flag2 = (nint)obj2 < children._size;
						node4 = node2;
						obj3 = obj4;
						if (flag2)
						{
							continue;
						}
						goto IL_047a;
						IL_0676:
						float maxY = bbox.MaxY;
						if (!(node5.MaxY > bbox.MaxY))
						{
							object obj9 = node5.MaxY & -2147483649L;
							if ((nint)obj9 <= 2139095040)
							{
								goto IL_06a9;
							}
						}
						maxY = node5.MaxY;
						goto IL_06a9;
						IL_0773:
						node2 = node5;
						goto IL_0734;
						IL_06a9:
						float minY = bbox.MinY;
						if (!(bbox.MinY > node5.MinY))
						{
							object obj10 = node5.MinY & -2147483649L;
							if ((nint)obj10 <= 2139095040)
							{
								goto IL_06dc;
							}
						}
						minY = node5.MinY;
						goto IL_06dc;
						IL_06dc:
						float num9 = maxY - minY;
						float num10 = maxX - minX;
						float num11 = num9 * num10;
						float num12 = num11 - num8;
						float num13;
						if (!(num2 > num12))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185010789h\"");
							if (num12 != num2 || !(num > num8))
							{
								goto IL_0734;
							}
							num13 = num2;
						}
						else
						{
							bool flag3 = !(num > num8);
							num13 = num12;
							num2 = num12;
							if (flag3)
							{
								goto IL_0773;
							}
						}
						num = num8;
						num2 = num13;
						goto IL_0773;
					}
					goto IL_0612;
				}
			}
			return node3;
			IL_047a:
			if (node4 == null)
			{
				List<IRectangular> children3 = node3.children;
				if (children3._size <= (nint)node4)
				{
					goto IL_0612;
				}
				IRectangular[] items3 = children3._items;
				if (items3.Length > (nint)node4)
				{
					node3 = (Node)items3[0];
					nint num14 = (nint)typeof(Node);
					bool flag4 = items3[0] == null;
					node2 = node4;
					obj4 = obj3;
					if (!flag4)
					{
						nint num15 = (nint)node3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rdx_v10 (Il2CppClass<RBush+Node>)+130]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ r8_v9 (Il2CppClass<RBush+Node>)+130]");
						nint num16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rdx_v10 (Il2CppClass<RBush+Node>)+130]");
						if (num16 < 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ r8_v9 (Il2CppClass<RBush+Node>)+C8]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v23+FFFFFFF8+v692 @ rax_v22*8]");
						if (0 != (nint)typeof(Node))
						{
							break;
						}
						node2 = node4;
						obj4 = obj3;
					}
					continue;
				}
				goto IL_0629;
			}
			node2 = node4;
			obj4 = obj3;
			node3 = node4;
			continue;
			IL_0629:
			return (Node)(object)new IndexOutOfRangeException();
			IL_0612:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			break;
		}
		throw new InvalidCastException();
	}

	private void _insert(IRectangular item, int level, bool isNode = false)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Expected O, but got Unknown
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Expected O, but got Unknown
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Expected O, but got Unknown
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected O, but got Unknown
		//IL_06d1: Expected O, but got I4
		//IL_03e0: Invalid comparison between F4 and I4
		List<Node> insertPath = _insertPath;
		int version = insertPath._version + 1;
		insertPath._version = version;
		insertPath._size = 0;
		if (insertPath._size > 0)
		{
			Array.Clear(insertPath._items, 0, insertPath._size);
		}
		List<Node> insertPath2 = _insertPath;
		List<Node> path = default(List<Node>);
		Node node = _chooseSubtree(item, data, level, path);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B47C0");
		float minX = item.MinX;
		object obj = item.MinX & -2147483649L;
		if ((nint)obj > 2139095040 || item.MinX > node.MinX)
		{
			minX = node.MinX;
		}
		node.MinX = minX;
		float minY = item.MinY;
		object obj2 = item.MinY & -2147483649L;
		if ((nint)obj2 > 2139095040 || item.MinY > node.MinY)
		{
			minY = node.MinY;
		}
		node.MinY = minY;
		float maxX = item.MaxX;
		object obj3 = item.MaxX & -2147483649L;
		if ((nint)obj3 > 2139095040 || node.MaxX > item.MaxX)
		{
			maxX = node.MaxX;
		}
		node.MaxX = maxX;
		float maxY = item.MaxY;
		object obj4 = item.MaxY & -2147483649L;
		if ((nint)obj4 > 2139095040 || node.MaxY > item.MaxY)
		{
			maxY = node.MaxY;
		}
		node.MaxY = maxY;
		bool flag = level < 0;
		int num = level;
		if (!flag)
		{
			int num2 = level;
			while (num2 < insertPath2._size)
			{
				Node[] items = insertPath2._items;
				Node node2 = items[num2];
				List<IRectangular> children = node2.children;
				bool flag2 = children._size <= _maxEntries;
				num = num2;
				if (!flag2)
				{
					_split(insertPath2, num2);
					num = num2 - 1;
					bool flag3 = children._size >= _maxEntries;
					num2 = num;
					if (flag3)
					{
						continue;
					}
				}
				goto IL_0587;
			}
			goto IL_055d;
		}
		goto IL_0587;
		IL_0587:
		if (num < 0)
		{
			return;
		}
		while (num < insertPath2._size)
		{
			Node[] items2 = insertPath2._items;
			Node node3 = items2[num];
			float minX2 = item.MinX;
			object obj5 = item.MinX & -2147483649L;
			if ((nint)obj5 > 2139095040 || item.MinX > node3.MinX)
			{
				minX2 = node3.MinX;
			}
			node3.MinX = minX2;
			float minY2 = item.MinY;
			object obj6 = item.MinY & -2147483649L;
			if ((nint)obj6 > 2139095040 || item.MinY > node3.MinY)
			{
				minY2 = node3.MinY;
			}
			node3.MinY = minY2;
			float maxX2 = item.MaxX;
			object obj7 = item.MaxX & -2147483649L;
			if ((nint)obj7 > 2139095040 || node3.MaxX > item.MaxX)
			{
				maxX2 = node3.MaxX;
			}
			node3.MaxX = maxX2;
			float maxY2 = item.MaxY;
			object obj8 = item.MaxY & -2147483649L;
			object obj9 = obj8 - 2139095040;
			bool flag4 = (nint)obj9 < 0;
			bool flag6;
			if ((nint)obj8 <= 2139095040)
			{
				float num3 = node3.MaxY - item.MaxY;
				flag4 = num3 < 0f;
				bool flag5 = !(node3.MaxY > item.MaxY);
				flag6 = flag4;
				if (flag5)
				{
					goto IL_06ab;
				}
			}
			maxY2 = node3.MaxY;
			flag6 = flag4;
			goto IL_06ab;
			IL_06ab:
			num--;
			node3.MaxY = maxY2;
			object obj10 = !flag6;
			if (obj10 == null)
			{
				return;
			}
		}
		goto IL_055d;
		IL_055d:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _split(List<Node> insertPath, int level)
	{
		//IL_060f: Expected O, but got I4
		//IL_0446: Expected O, but got I4
		//IL_048a: Expected O, but got I4
		Node node;
		Comparison<IRectangular> comparison = default(Comparison<IRectangular>);
		int num5;
		Node node4;
		List<IRectangular> children2;
		int num18;
		int count;
		if (level < insertPath._size)
		{
			Node[] items = insertPath._items;
			node = items[level];
			List<IRectangular> children = node.children;
			int num = _minEntries;
			float num2 = _allDistMargin(node, _minEntries, children._size, comparison);
			float num3 = _allDistMargin(node, _minEntries, children._size, comparison);
			bool flag = !(num3 > num2);
			int num4 = 0;
			if (!flag)
			{
				((List<object>)(object)node.children).Sort((Comparison<object>)IRectangular.CompareMinX);
				num4 = 0;
			}
			object obj = children._size - num;
			bool flag2 = num > (nint)obj;
			num5 = num4;
			float num6 = 1f / 0f;
			int num7 = num4;
			float num8 = 1f / 0f;
			if (!flag2)
			{
				bool flag4;
				do
				{
					Node node2 = distBBox(node, 0, num, (Node)(object)comparison);
					Node node3 = distBBox(node, num, children._size, (Node)(object)comparison);
					float num9 = intersectionArea(node2, node3);
					float num10 = node3.MaxY - node3.MinY;
					float num11 = node3.MaxX - node3.MinX;
					float num12 = node2.MaxY - node2.MinY;
					num3 = node2.MaxX - node2.MinX;
					float num13 = num10 * num11;
					float num14 = num12 * num3;
					float num15 = num13 + num14;
					float num16;
					int num17;
					if (!(num6 > num9))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185010EBCh\"");
						if (num9 == num6 && num8 > num15)
						{
							num16 = num6;
							num17 = num;
							goto IL_01f7;
						}
					}
					else
					{
						bool flag3 = !(num8 > num15);
						num16 = num9;
						num17 = num;
						num6 = num9;
						num7 = num;
						if (!flag3)
						{
							goto IL_01f7;
						}
					}
					goto IL_04dc;
					IL_04dc:
					num++;
					flag4 = num <= (nint)obj;
					num5 = num7;
					continue;
					IL_01f7:
					num6 = num16;
					num7 = num17;
					num8 = num15;
					goto IL_04dc;
				}
				while (flag4);
			}
			node4 = createNode();
			children2 = node.children;
			List<IRectangular> children3 = node4.children;
			num18 = children2._size - num5;
			if (node4.children == null)
			{
				List<IRectangular> range = children2.GetRange(num5, num18);
				count = num18;
				goto IL_0535;
			}
			if (num5 >= children2._size)
			{
				goto IL_038c;
			}
			int num19 = num5;
			while (num19 < children2._size)
			{
				IRectangular[] items2 = children2._items;
				IRectangular[] items3 = children3._items;
				int version = children3._version + 1;
				children3._version = version;
				if (children3._size >= items3.Length)
				{
					((List<object>)(object)node4.children).AddWithResize((object)items2[num19]);
				}
				else
				{
					int size = children3._size + 1;
					children3._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				num19++;
				if (num19 < children2._size)
				{
					continue;
				}
				goto IL_038c;
			}
		}
		goto IL_04b4;
		IL_038c:
		count = num18;
		goto IL_0535;
		IL_0535:
		children2.RemoveRange(num5, count);
		node4.height = node.height;
		node4.leaf = node.leaf;
		List<IRectangular> children4 = node.children;
		Node node5 = distBBox(node, 0, children4._size, (Node)(object)comparison);
		List<IRectangular> children5 = node4.children;
		Node node6 = distBBox(node4, 0, children5._size, (Node)(object)comparison);
		if (level <= 0)
		{
			_splitRoot(node, node4);
			return;
		}
		object obj2 = level - 1;
		if ((nint)obj2 < insertPath._size)
		{
			Node[] items4 = insertPath._items;
			object obj3 = level - 1;
			Node node7 = items4[obj3];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B47C0");
			return;
		}
		goto IL_04b4;
		IL_04b4:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private void _splitRoot(Node node, Node newNode)
	{
		Node node2 = createNode();
		data = node2;
		Node node3 = data;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B47C0");
		Node node4 = data;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B47C0");
		Node node5 = data;
		int height = node.height + 1;
		node5.height = height;
		Node node6 = data;
		node6.leaf = false;
		Node node7 = data;
		List<IRectangular> children = node7.children;
		Node destNode = default(Node);
		Node node8 = distBBox(node7, 0, children._size, destNode);
	}

	private int _chooseSplitIndex(Node node, int m, int M)
	{
		//IL_01d6: Expected O, but got I4
		//IL_01c9: Expected I4, but got O
		object obj = M - m;
		bool flag = m > (nint)obj;
		int result = 0;
		float num = 1f / 0f;
		float num2 = 1f / 0f;
		int num3 = 0;
		int num4 = m;
		if (!flag)
		{
			Node destNode = default(Node);
			bool flag3;
			do
			{
				Node node2 = distBBox(node, 0, num4, destNode);
				Node node3 = distBBox(node, num4, M, destNode);
				float num5 = intersectionArea(node2, node3);
				float num12;
				float num13;
				int num14;
				if (node2 != null && node3 != null)
				{
					float num6 = node3.MaxY - node3.MinY;
					float num7 = node3.MaxX - node3.MinX;
					float num8 = node2.MaxY - node2.MinY;
					float num9 = node2.MaxX - node2.MinX;
					float num10 = num6 * num7;
					float num11 = num8 * num9;
					num12 = num10 + num11;
					if (!(num2 > num5))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018501141Ah\"");
						if (num5 == num2 && num > num12)
						{
							num13 = num2;
							num14 = num4;
							goto IL_0199;
						}
					}
					else
					{
						bool flag2 = !(num > num12);
						num13 = num5;
						num14 = num4;
						num2 = num5;
						num3 = num4;
						if (!flag2)
						{
							goto IL_0199;
						}
					}
					goto IL_021e;
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
				IL_021e:
				num4++;
				flag3 = num4 <= (nint)obj;
				result = num3;
				continue;
				IL_0199:
				num = num12;
				num2 = num13;
				num3 = num14;
				goto IL_021e;
			}
			while (flag3);
		}
		return result;
	}

	private void _chooseSplitAxis(Node node, int m, int M)
	{
		Comparison<IRectangular> compare = default(Comparison<IRectangular>);
		float num = _allDistMargin(node, m, M, compare);
		float num2 = _allDistMargin(node, m, M, compare);
		if (num2 > num)
		{
			((List<object>)(object)node.children).Sort((Comparison<object>)IRectangular.CompareMinX);
		}
	}

	private float _allDistMargin(Node node, int m, int M, Comparison<IRectangular> compare)
	{
		//IL_00e0: Expected O, but got I4
		//IL_038f: Expected O, but got I4
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected O, but got Unknown
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Expected O, but got Unknown
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Expected O, but got Unknown
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected O, but got Unknown
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e4: Expected O, but got Unknown
		//IL_06c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Expected O, but got Unknown
		//IL_082d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0832: Expected O, but got Unknown
		//IL_0883: Unknown result type (might be due to invalid IL or missing references)
		//IL_0888: Expected O, but got Unknown
		Node node3;
		float num7;
		float num5;
		if (node != null && node.children != null)
		{
			Comparison<object> comparison = default(Comparison<object>);
			((List<object>)(object)node.children).Sort(comparison);
			Node destNode = default(Node);
			Node node2 = distBBox(node, 0, m, destNode);
			int k = M - m;
			node3 = distBBox(node, k, M, destNode);
			if (node2 != null && node3 != null)
			{
				float num = node3.MaxX - node3.MinX;
				object obj = M - m;
				float num2 = node3.MaxY - node3.MinY;
				float num3 = node2.MaxY - node2.MinY;
				float num4 = num2 + num;
				num5 = node2.MaxX - node2.MinX;
				float num6 = num3 + num5;
				num7 = num4 + num6;
				if (m >= (nint)obj)
				{
					goto IL_0382;
				}
				List<IRectangular> children = node.children;
				bool flag = node.children == null;
				float num8 = num5;
				int num9 = m;
				if (!flag)
				{
					while (true)
					{
						bool flag2 = num9 >= children._size;
						num5 = num8;
						if (flag2)
						{
							break;
						}
						IRectangular[] items = children._items;
						bool flag3 = children._items == null;
						num5 = num8;
						if (!flag3)
						{
							bool flag4 = num9 >= items.Length;
							num5 = num8;
							if (flag4)
							{
								goto IL_05f4;
							}
							num5 = node2.MinX;
							IRectangular rectangular = items[num9];
							if (items[num9] != null)
							{
								float num10 = rectangular.MinX;
								object obj2 = rectangular.MinX & -2147483649L;
								if ((nint)obj2 > 2139095040 || rectangular.MinX > node2.MinX)
								{
									num10 = num5;
								}
								node2.MinX = num10;
								float minY = rectangular.MinY;
								object obj3 = rectangular.MinY & -2147483649L;
								if ((nint)obj3 > 2139095040 || rectangular.MinY > node2.MinY)
								{
									minY = node2.MinY;
								}
								node2.MinY = minY;
								float maxX = rectangular.MaxX;
								object obj4 = rectangular.MaxX & -2147483649L;
								if ((nint)obj4 > 2139095040 || node2.MaxX > rectangular.MaxX)
								{
									maxX = node2.MaxX;
								}
								node2.MaxX = maxX;
								float maxY = rectangular.MaxY;
								object obj5 = rectangular.MaxY & -2147483649L;
								if ((nint)obj5 > 2139095040 || node2.MaxY > rectangular.MaxY)
								{
									maxY = node2.MaxY;
								}
								node2.MaxY = maxY;
								float num11 = maxX - num10;
								float num12 = maxY - minY;
								num9++;
								num5 = num12 + num11;
								num7 += num5;
								bool flag5 = num9 < (nint)obj;
								num8 = num5;
								if (flag5)
								{
									continue;
								}
								goto IL_0382;
							}
						}
						goto IL_05c1;
					}
					goto IL_05ea;
				}
			}
		}
		goto IL_05c1;
		IL_0382:
		object obj6 = M - m;
		object obj7 = obj6 - 1;
		if ((nint)obj7 < m)
		{
			goto IL_05bc;
		}
		List<IRectangular> children2 = node.children;
		bool flag6 = node.children == null;
		float num13 = num5;
		if (flag6)
		{
			goto IL_05c1;
		}
		while (true)
		{
			bool flag7 = (nint)obj7 >= children2._size;
			num5 = num13;
			if (flag7)
			{
				break;
			}
			IRectangular[] items2 = children2._items;
			bool flag8 = children2._items == null;
			num5 = num13;
			if (!flag8)
			{
				bool flag9 = (nint)obj7 >= items2.Length;
				num5 = num13;
				if (flag9)
				{
					goto IL_05f4;
				}
				num5 = node3.MinX;
				IRectangular rectangular2 = items2[obj7];
				if (items2[obj7] != null)
				{
					float num14 = rectangular2.MinX;
					object obj8 = rectangular2.MinX & -2147483649L;
					if ((nint)obj8 > 2139095040 || rectangular2.MinX > node3.MinX)
					{
						num14 = num5;
					}
					node3.MinX = num14;
					float minY2 = rectangular2.MinY;
					object obj9 = rectangular2.MinY & -2147483649L;
					if ((nint)obj9 > 2139095040 || rectangular2.MinY > node3.MinY)
					{
						minY2 = node3.MinY;
					}
					node3.MinY = minY2;
					float maxX2 = rectangular2.MaxX;
					object obj10 = rectangular2.MaxX & -2147483649L;
					if ((nint)obj10 > 2139095040 || node3.MaxX > rectangular2.MaxX)
					{
						maxX2 = node3.MaxX;
					}
					node3.MaxX = maxX2;
					float maxY2 = rectangular2.MaxY;
					object obj11 = rectangular2.MaxY & -2147483649L;
					if ((nint)obj11 > 2139095040 || node3.MaxY > rectangular2.MaxY)
					{
						maxY2 = node3.MaxY;
					}
					node3.MaxY = maxY2;
					float num15 = maxX2 - num14;
					float num16 = maxY2 - minY2;
					obj7--;
					num13 = num16 + num15;
					num7 += num13;
					if ((nint)obj7 >= m)
					{
						continue;
					}
					goto IL_05bc;
				}
			}
			goto IL_05c1;
		}
		goto IL_05ea;
		IL_05f4:
		throw new IndexOutOfRangeException();
		IL_05c1:
		throw new NullReferenceException();
		IL_05bc:
		return num7;
		IL_05ea:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return num5;
	}

	private void _adjustParentBBoxes(IRectangular bbox, List<Node> path, int level)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_02f0: Expected O, but got I4
		//IL_014e: Invalid comparison between F4 and I4
		if (level < 0)
		{
			return;
		}
		int num = level;
		while (num < path._size)
		{
			Node[] items = path._items;
			Node node = items[num];
			float minX = bbox.MinX;
			object obj = bbox.MinX & -2147483649L;
			if ((nint)obj > 2139095040 || bbox.MinX > node.MinX)
			{
				minX = node.MinX;
			}
			node.MinX = minX;
			float minY = bbox.MinY;
			object obj2 = bbox.MinY & -2147483649L;
			if ((nint)obj2 > 2139095040 || bbox.MinY > node.MinY)
			{
				minY = node.MinY;
			}
			node.MinY = minY;
			float maxX = bbox.MaxX;
			object obj3 = bbox.MaxX & -2147483649L;
			if ((nint)obj3 > 2139095040 || node.MaxX > bbox.MaxX)
			{
				maxX = node.MaxX;
			}
			node.MaxX = maxX;
			float maxY = bbox.MaxY;
			object obj4 = bbox.MaxY & -2147483649L;
			object obj5 = obj4 - 2139095040;
			bool flag = (nint)obj5 < 0;
			bool flag3;
			if ((nint)obj4 <= 2139095040)
			{
				float num2 = node.MaxY - bbox.MaxY;
				flag = num2 < 0f;
				bool flag2 = !(node.MaxY > bbox.MaxY);
				flag3 = flag;
				if (flag2)
				{
					goto IL_02ca;
				}
			}
			maxY = node.MaxY;
			flag3 = flag;
			goto IL_02ca;
			IL_02ca:
			num--;
			node.MaxY = maxY;
			object obj6 = !flag3;
			if (obj6 == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _condense(List<Node> path)
	{
		//IL_0018: Expected O, but got I4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_00d8: Expected I, but got O
		//IL_0170: Expected O, but got I
		//IL_0189: Expected O, but got I
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01ad: Expected O, but got I4
		bool flag = (nint)path < 0;
		object obj = path._size - 1;
		if (flag)
		{
			return;
		}
		Node node2 = default(Node);
		object item = default(object);
		while ((nint)obj < path._size)
		{
			Node[] items = path._items;
			Node node = items[obj];
			List<IRectangular> children = node.children;
			bool flag2 = children._size < 0;
			if (children._size != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				calcBBox(node2);
				nint num = unchecked((nint)null);
			}
			else
			{
				flag2 = (nint)obj < 0;
				if ((nint)obj <= 0)
				{
					RBush rBush = clear();
				}
				else
				{
					object obj2 = obj - 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v14+20]");
					flag2 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v14+20]");
					int index = ((List<object>)0).IndexOf(item);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v14+20]");
					((List<IRectangular>)0).RemoveAt(index);
					nint num = 0;
				}
			}
			obj--;
			object obj3 = !flag2;
			if (obj3 == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private int findItem(IRectangular item, List<IRectangular> items, Func<IRectangular, IRectangular, bool> equalsFn)
	{
		//IL_00d5: Expected I4, but got I8
		if (equalsFn != null)
		{
			int num = 0;
			int num2 = 0;
			object obj = default(object);
			while (true)
			{
				if (num2 < items._size)
				{
					if (num >= items._size)
					{
						break;
					}
					IRectangular[] items2 = items._items;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [equalsFn @ r9 (System.Func`3<RBush+IRectangular, RBush+IRectangular, System.Boolean>)+18] (should have been resolved before IL gen)");
					if (obj == null)
					{
						num++;
						num2 = num;
						continue;
					}
					return num;
				}
				return -1;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			int result = default(int);
			return result;
		}
		return Array.IndexOf((object[])items._items, (object)item, 0, items._size);
	}

	private void calcBBox(Node node)
	{
		List<IRectangular> children = node.children;
		Node destNode = default(Node);
		Node node2 = distBBox(node, 0, children._size, destNode);
	}

	private Node distBBox(Node node, int k, int p, Node destNode = null)
	{
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		Node node2 = default(Node);
		bool flag = node2 != null;
		Node node3 = node2;
		if (!flag)
		{
			Node node4 = createNode();
			node3 = node4;
		}
		node3.MinX = 1f / 0f;
		node3.MinY = 1f / 0f;
		node3.MaxX = -1f / 0f;
		node3.MaxY = -1f / 0f;
		if (k < p)
		{
			int num = k;
			do
			{
				List<IRectangular> children = node.children;
				if (num < children._size)
				{
					IRectangular[] items = children._items;
					if (num < items.Length)
					{
						IRectangular rectangular = items[num];
						float minX = rectangular.MinX;
						object obj = rectangular.MinX & -2147483649L;
						if ((nint)obj > 2139095040 || rectangular.MinX > node3.MinX)
						{
							minX = node3.MinX;
						}
						node3.MinX = minX;
						float minY = rectangular.MinY;
						object obj2 = rectangular.MinY & -2147483649L;
						if ((nint)obj2 > 2139095040 || rectangular.MinY > node3.MinY)
						{
							minY = node3.MinY;
						}
						node3.MinY = minY;
						float maxX = rectangular.MaxX;
						object obj3 = rectangular.MaxX & -2147483649L;
						if ((nint)obj3 > 2139095040 || node3.MaxX > rectangular.MaxX)
						{
							maxX = node3.MaxX;
						}
						node3.MaxX = maxX;
						float maxY = rectangular.MaxY;
						object obj4 = rectangular.MaxY & -2147483649L;
						if ((nint)obj4 > 2139095040 || node3.MaxY > rectangular.MaxY)
						{
							maxY = node3.MaxY;
						}
						num++;
						node3.MaxY = maxY;
						continue;
					}
					return (Node)(object)new IndexOutOfRangeException();
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			while (num < p);
		}
		return node3;
	}

	private Node extend(Node a, IRectangular b)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		if (a != null && b != null)
		{
			float minX = b.MinX;
			object obj = b.MinX & -2147483649L;
			if ((nint)obj > 2139095040 || b.MinX > a.MinX)
			{
				minX = a.MinX;
			}
			a.MinX = minX;
			float minY = b.MinY;
			object obj2 = b.MinY & -2147483649L;
			if ((nint)obj2 > 2139095040 || b.MinY > a.MinY)
			{
				minY = a.MinY;
			}
			a.MinY = minY;
			float maxX = b.MaxX;
			object obj3 = b.MaxX & -2147483649L;
			if ((nint)obj3 > 2139095040 || a.MaxX > b.MaxX)
			{
				maxX = a.MaxX;
			}
			a.MaxX = maxX;
			float maxY = b.MaxY;
			object obj4 = b.MaxY & -2147483649L;
			if ((nint)obj4 > 2139095040 || a.MaxY > b.MaxY)
			{
				maxY = a.MaxY;
			}
			a.MaxY = maxY;
			return a;
		}
		return (Node)(object)new NullReferenceException();
	}

	private float bboxArea(IRectangular a)
	{
		float num = a.MaxY - a.MinY;
		float num2 = a.MaxX - a.MinX;
		return num * num2;
	}

	private float bboxMargin(IRectangular a)
	{
		float num = a.MaxY - a.MinY;
		float num2 = a.MaxX - a.MinX;
		return num + num2;
	}

	private float enlargedArea(IRectangular a, IRectangular b)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		float maxX = a.MaxX;
		if (!(b.MaxX > a.MaxX))
		{
			object obj = b.MaxX & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				goto IL_0161;
			}
		}
		maxX = b.MaxX;
		goto IL_0161;
		IL_0194:
		float maxY = a.MaxY;
		if (!(b.MaxY > a.MaxY))
		{
			object obj2 = b.MaxY & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_01c7;
			}
		}
		maxY = b.MaxY;
		goto IL_01c7;
		IL_01fa:
		float minX;
		float num = maxX - minX;
		float minY;
		float num2 = maxY - minY;
		return num2 * num;
		IL_0161:
		minX = a.MinX;
		if (!(a.MinX > b.MinX))
		{
			object obj3 = b.MinX & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				goto IL_0194;
			}
		}
		minX = b.MinX;
		goto IL_0194;
		IL_01c7:
		minY = a.MinY;
		if (!(a.MinY > b.MinY))
		{
			object obj4 = b.MinY & -2147483649L;
			if ((nint)obj4 <= 2139095040)
			{
				goto IL_01fa;
			}
		}
		minY = b.MinY;
		goto IL_01fa;
	}

	public static float intersectionArea(Node a, Node b)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_0270: Invalid comparison between I4 and F4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_018b: Expected F4, but got I4
		//IL_029c: Invalid comparison between I4 and F4
		//IL_01ba: Expected F4, but got I4
		float minX = b.MinX;
		if (!(a.MinX > b.MinX))
		{
			object obj = a.MinX & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				goto IL_01bf;
			}
		}
		minX = a.MinX;
		goto IL_01bf;
		IL_01f2:
		float maxX = b.MaxX;
		if (!(b.MaxX > a.MaxX))
		{
			object obj2 = a.MaxX & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0225;
			}
		}
		maxX = a.MaxX;
		goto IL_0225;
		IL_0258:
		float num = maxX - minX;
		if (0f > num || 0 > 2139095040)
		{
			num = 0f;
		}
		float maxY;
		float minY;
		float num2 = maxY - minY;
		if (0f > num2 || 0 > 2139095040)
		{
			num2 = 0f;
		}
		return num2 * num;
		IL_01bf:
		minY = b.MinY;
		if (!(a.MinY > b.MinY))
		{
			object obj3 = a.MinY & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				goto IL_01f2;
			}
		}
		minY = a.MinY;
		goto IL_01f2;
		IL_0225:
		maxY = b.MaxY;
		if (!(b.MaxY > a.MaxY))
		{
			object obj4 = a.MaxY & -2147483649L;
			if ((nint)obj4 <= 2139095040)
			{
				goto IL_0258;
			}
		}
		maxY = a.MaxY;
		goto IL_0258;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static bool contains(IRectangular a, IRectangular b)
	{
		//IL_015a: Expected I4, but got O
		//IL_0074: Invalid comparison between F4 and I4
		//IL_009d: Expected O, but got I4
		//IL_00d7: Invalid comparison between F4 and I4
		//IL_0100: Expected O, but got I4
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected I4, but got Unknown
		//IL_0147: Expected O, but got I4
		if (a != null && b != null)
		{
			bool flag = a.MaxY < b.MaxY;
			float num = a.MaxY - b.MaxY;
			bool flag2 = num == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			object obj = flag4 & flag3;
			bool flag5 = a.MaxX < b.MaxX;
			float num2 = a.MaxX - b.MaxX;
			bool flag6 = num2 == 0f;
			bool flag7 = !flag5;
			bool flag8 = !flag6;
			object obj2 = flag8 & flag7;
			object obj3 = obj & obj2;
			bool flag9 = !(b.MinY < a.MinY);
			object obj4 = obj3;
			if (!flag9)
			{
				obj4 = 0;
			}
			bool flag10 = b.MinX < a.MinX;
			bool flag11 = !flag10;
			return (byte)((obj4 & flag11) ? 1 : 0) != 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static bool intersects(IRectangular a, IRectangular b)
	{
		//IL_00da: Expected I4, but got O
		//IL_008d: Expected O, but got I4
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected I4, but got Unknown
		//IL_00c7: Expected O, but got I4
		if (b != null && a != null)
		{
			bool flag = b.MaxY < a.MinY;
			bool flag2 = !flag;
			bool flag3 = b.MaxX < a.MinX;
			bool flag4 = !flag3;
			object obj = flag2 & flag4;
			bool flag5 = !(a.MaxY < b.MinY);
			object obj2 = obj;
			if (!flag5)
			{
				obj2 = 0;
			}
			bool flag6 = a.MaxX < b.MinX;
			bool flag7 = !flag6;
			return (byte)((obj2 & flag7) ? 1 : 0) != 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private Node createNode()
	{
		//IL_0196: Expected O, but got I
		//IL_0085: Expected O, but got I
		object obj = ListExtensions.Pop((List<object>)(object)_spareNodes);
		object result;
		if (obj == null)
		{
			Node node = new Node();
			List<IRectangular> children = new List<IRectangular>(_maxEntries);
			if (node != null)
			{
				node.children = children;
				int num = 0;
				result = node;
				goto IL_00f2;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Object)+20]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Object)+20]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v16+18]");
				int num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v16+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v16+18]");
				bool flag = (nint)0 <= (nint)0;
				result = obj;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v16+10]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v16+18]");
					Array.Clear((Array)num2, 0, 0);
					result = obj;
				}
				goto IL_00f2;
			}
		}
		goto IL_014c;
		IL_00f2:
		_ = 4286578688L;
		_ = 4286578688L;
		_ = 2139095040;
		_ = 2139095040;
		_ = 1;
		_ = 1;
		if (_liveNodes != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4820");
			return (Node)result;
		}
		goto IL_014c;
		IL_014c:
		return (Node)(object)new NullReferenceException();
	}

	public unsafe void drawDebug(Color colour)
	{
		//IL_0036: Expected O, but got I4
		//IL_003e: Expected O, but got Ref
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Node>.Enumerator enumerator2 = (List<Node>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void multiSelect<T>(ref ListAccessor<T> list, int left, int right, int n, Comparison<T> compare)
	{
		//IL_00a6: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_03dc: Expected O, but got I
		//IL_017a: Expected O, but got I
		//IL_01a7: Expected O, but got I
		//IL_01bd: Expected O, but got I
		//IL_01ff: Expected O, but got I
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected O, but got Unknown
		//IL_026c: Expected O, but got I4
		//IL_028c: Expected O, but got I
		//IL_02ae: Expected O, but got I
		//IL_02ea: Expected O, but got I
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected I4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_38+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_38+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Stack<int> multiSelectStack = _multiSelectStack;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v2 (System.Collections.Generic.Stack`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		Stack<int> multiSelectStack2 = _multiSelectStack;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rcx_v4+18]");
		if (num >= 0)
		{
			multiSelectStack2.PushWithResize(left);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v6+18]");
		if (num2 >= 0)
		{
			int item = default(int);
			multiSelectStack2.PushWithResize(item);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
		}
		object obj12 = default(object);
		object obj16 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
				object obj6 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9+18]");
				if ((nint)obj6 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
				object obj7 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+1C]");
				int item = (int)((nint)0 + (nint)1);
				object obj8 = obj6 - 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9+18]");
				if ((nint)obj8 < 0)
				{
					object obj9 = item + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v3 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
					object obj10 = -2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9+20+v367 @ rax_v13*4]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9+20+v415 @ rax_v18*4]");
					object obj11 = num3 - 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9+20+v367 @ rax_v13*4]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9+20+v415 @ rax_v18*4]");
						object obj13 = num4 - 0;
						object obj14 = obj13 / obj12;
						float num5 = (float)obj14 * 0.5f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
						object obj15 = obj16 * obj12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9+20+v415 @ rax_v18*4]");
						int item2 = obj15 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18310D3D0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9+20+v415 @ rax_v18*4]");
						multiSelectStack2.Push(0);
						multiSelectStack2.Push(item2);
						multiSelectStack2.Push(item2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9+20+v367 @ rax_v13*4]");
						multiSelectStack2.Push(0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9+20+v367 @ rax_v13*4]");
						item = 0;
					}
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D2420");
				break;
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D2420");
		throw new IndexOutOfRangeException();
	}

	static RBush()
	{
		//IL_002b: Expected O, but got I
		//IL_0051: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("RTree.Search", 5, MarkerFlags.Default, 0);
		s_searchMarker = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("RTree.Load", 5, MarkerFlags.Default, 0);
		s_loadMarker = (ProfilerMarker)(nint)intPtr2;
	}
}
