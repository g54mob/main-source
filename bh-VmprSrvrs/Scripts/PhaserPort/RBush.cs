using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Unity.Profiling;
using UnityEngine;

public class RBush
{
	public class RectangularBox : IRectangular
	{
	}

	public abstract class IRectangular
	{
		public static readonly Comparison<IRectangular> CompareMinX;

		public static readonly Comparison<IRectangular> CompareMinY;

		public float MinX;

		public float MinY;

		public float MaxX;

		public float MaxY;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		private static int compareNodeMinX(IRectangular a, IRectangular b)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		private static int compareNodeMinY(IRectangular a, IRectangular b)
		{
			return 0;
		}
	}

	public class Node : IRectangular
	{
		public List<IRectangular> children;

		public int height;

		public bool leaf;

		public void Clear()
		{
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
	}

	public List<BaseBody> all()
	{
		return null;
	}

	public List<BaseBody> search(IRectangular bbox)
	{
		return null;
	}

	public RBush load(HashSet<PhaserGameObject> data)
	{
		return null;
	}

	public RBush insert(IRectangular item)
	{
		return null;
	}

	public RBush clear()
	{
		return null;
	}

	public RBush remove(IRectangular item, Func<IRectangular, IRectangular, bool> equalsFn = null)
	{
		return null;
	}

	private List<BaseBody> _all(Node node, List<BaseBody> result)
	{
		return null;
	}

	private Node _build(List<IRectangular> items, int left, int right, int? height = null)
	{
		return null;
	}

	private Node _chooseSubtree(IRectangular bbox, Node node, int level, List<Node> path)
	{
		return null;
	}

	private void _insert(IRectangular item, int level, bool isNode = false)
	{
	}

	private void _split(List<Node> insertPath, int level)
	{
	}

	private void _splitRoot(Node node, Node newNode)
	{
	}

	private int _chooseSplitIndex(Node node, int m, int M)
	{
		return 0;
	}

	private void _chooseSplitAxis(Node node, int m, int M)
	{
	}

	private float _allDistMargin(Node node, int m, int M, Comparison<IRectangular> compare)
	{
		return 0f;
	}

	private void _adjustParentBBoxes(IRectangular bbox, List<Node> path, int level)
	{
	}

	private void _condense(List<Node> path)
	{
	}

	private int findItem(IRectangular item, List<IRectangular> items, Func<IRectangular, IRectangular, bool> equalsFn)
	{
		return 0;
	}

	private void calcBBox(Node node)
	{
	}

	private Node distBBox(Node node, int k, int p, Node destNode = null)
	{
		return null;
	}

	private Node extend(Node a, IRectangular b)
	{
		return null;
	}

	private float bboxArea(IRectangular a)
	{
		return 0f;
	}

	private float bboxMargin(IRectangular a)
	{
		return 0f;
	}

	private float enlargedArea(IRectangular a, IRectangular b)
	{
		return 0f;
	}

	public static float intersectionArea(Node a, Node b)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool contains(IRectangular a, IRectangular b)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool intersects(IRectangular a, IRectangular b)
	{
		return false;
	}

	private Node createNode()
	{
		return null;
	}

	public void drawDebug(Color colour)
	{
	}

	private void multiSelect<T>(ref ListAccessor<T> list, int left, int right, int n, Comparison<T> compare)
	{
	}
}
