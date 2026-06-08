using System.Collections.Generic;

public static class ElementGroupSegmentFitter
{
	private static readonly Dictionary<int, int> PrimaryVariantToSubVariantCount = new Dictionary<int, int>
	{
		{ 1, 1 },
		{ 2, 3 },
		{ 3, 4 },
		{ 4, 3 },
		{ 5, 1 },
		{ 6, 1 }
	};

	private static readonly Dictionary<int, int> PrefabIndexToSubVariant = new Dictionary<int, int>
	{
		{ 0, 0 },
		{ 1, 0 },
		{ 2, 1 },
		{ 3, 2 },
		{ 4, 0 },
		{ 5, 1 },
		{ 6, 2 },
		{ 7, 3 },
		{ 8, 0 },
		{ 9, 1 },
		{ 10, 2 },
		{ 11, 0 },
		{ 12, 0 }
	};

	private static readonly List<List<List<int>>> SubVariantEdgeConstellation = new List<List<List<int>>>
	{
		new List<List<int>>
		{
			new List<int> { 0 }
		},
		new List<List<int>>
		{
			new List<int> { 0, 1 },
			new List<int> { 0, 2 },
			new List<int> { 0, 3 }
		},
		new List<List<int>>
		{
			new List<int> { 0, 1, 2 },
			new List<int> { 0, 1, 3 },
			new List<int> { 0, 1, 4 },
			new List<int> { 0, 2, 4 }
		},
		new List<List<int>>
		{
			new List<int> { 0, 1, 2, 3 },
			new List<int> { 0, 1, 2, 4 },
			new List<int> { 0, 1, 3, 4 }
		},
		new List<List<int>>
		{
			new List<int> { 0, 1, 2, 3, 4 }
		},
		new List<List<int>>
		{
			new List<int> { 0, 1, 2, 3, 4, 5 }
		}
	};

	public static int SubVariantCount(int primaryVariant)
	{
		return PrimaryVariantToSubVariantCount[primaryVariant];
	}
}
