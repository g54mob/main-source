internal static class aEhfNBVLsnubZLaAKSdMAjbgjoov
{
	private class yFOldLzKGLQBiPnNafLYWWccwHvo
	{
		public readonly ushort DYbxAOBnJflgycQGgcmlLBqyAHXgA;

		public readonly ushort NfjCdsCmevIVhHASzHQLEpdixqix;

		public readonly string NnXRmWbWdrIRMgUIPVLKCgwtEpZf;

		public readonly bool jCXEsKFlTtbhIYJFkLJmWpUneyZm;

		public readonly int QqzRuUPQDCFKnUwIEWpIPbHVosqn;

		public readonly int fpDFLpDaPRmyLLrKBwQIgJJcYvNkA;

		public readonly int ZoOczqvvNoatXdlxMirPjDWNpGdkA;

		public readonly float IzzpZPUiufKDMrHlbThtVGXwVXyQ;

		public yFOldLzKGLQBiPnNafLYWWccwHvo(ushort P_0, ushort P_1, string P_2, bool P_3, int P_4, int P_5, int P_6, float P_7)
		{
			DYbxAOBnJflgycQGgcmlLBqyAHXgA = P_0;
			NfjCdsCmevIVhHASzHQLEpdixqix = P_1;
			if (string.IsNullOrEmpty(P_2))
			{
				P_2 = string.Empty;
			}
			NnXRmWbWdrIRMgUIPVLKCgwtEpZf = P_2;
			jCXEsKFlTtbhIYJFkLJmWpUneyZm = P_3;
			QqzRuUPQDCFKnUwIEWpIPbHVosqn = P_4;
			fpDFLpDaPRmyLLrKBwQIgJJcYvNkA = P_5;
			ZoOczqvvNoatXdlxMirPjDWNpGdkA = P_6;
			IzzpZPUiufKDMrHlbThtVGXwVXyQ = P_7;
		}

		public bool HuHHJjUvaYJAyVBqNvMLlNITopNm(ushort P_0, ushort P_1)
		{
			if (DYbxAOBnJflgycQGgcmlLBqyAHXgA == P_0)
			{
				return NfjCdsCmevIVhHASzHQLEpdixqix == P_1;
			}
			return false;
		}

		public bool KQpgLCmKdgBwezSettBBXMwWegMb(ushort P_0, ushort P_1, string P_2)
		{
			if (DYbxAOBnJflgycQGgcmlLBqyAHXgA != P_0 || NfjCdsCmevIVhHASzHQLEpdixqix != P_1)
			{
				if (!string.IsNullOrEmpty(P_2))
				{
					return NnXRmWbWdrIRMgUIPVLKCgwtEpZf == P_2;
				}
				return false;
			}
			return true;
		}

		public bool IeJkWiTeqjtWTfKmRCdKmdjfglZf(string P_0)
		{
			if (!string.IsNullOrEmpty(P_0))
			{
				return NnXRmWbWdrIRMgUIPVLKCgwtEpZf == P_0;
			}
			return false;
		}
	}

	private const float lsjgsRbOSdMnPYoiXYZPHYGrDDbjA = 0.034f;

	private static yFOldLzKGLQBiPnNafLYWWccwHvo[] bqgIcOISthcZfWwGUQIjImwwzcVf = new yFOldLzKGLQBiPnNafLYWWccwHvo[3]
	{
		new yFOldLzKGLQBiPnNafLYWWccwHvo(1133, 50726, "SpaceNavigator", true, -350, 350, 0, 0.034f),
		new yFOldLzKGLQBiPnNafLYWWccwHvo(1133, 50728, "SpaceNavigator for Notebooks", true, -350, 350, 0, 0.034f),
		new yFOldLzKGLQBiPnNafLYWWccwHvo(1133, 50727, "Space Explorer", true, -350, 350, 0, 0.034f)
	};

	public static bool iUBntGZYBmFqxLMnLiYxjPraJzHS(ushort P_0, ushort P_1, string P_2 = null)
	{
		return nXReMMbBChUCXqdvnRteNTqgAYMTA(P_0, P_1, P_2)?.jCXEsKFlTtbhIYJFkLJmWpUneyZm ?? false;
	}

	public static float LrMGGhsEoLoqZNbCAZRkWYXQZssc(ushort P_0, ushort P_1, string P_2 = null)
	{
		return nXReMMbBChUCXqdvnRteNTqgAYMTA(P_0, P_1, P_2)?.IzzpZPUiufKDMrHlbThtVGXwVXyQ ?? 0f;
	}

	public static bool bjAbYreehsvjEvSsCrbkGQxyDnReA(ushort P_0, ushort P_1, out int P_2, out int P_3, out int P_4)
	{
		return ySThzdqvXvUJPAjfzAPlxoozGHUJA(P_0, P_1, null, out P_2, out P_3, out P_4);
	}

	public static bool ySThzdqvXvUJPAjfzAPlxoozGHUJA(ushort P_0, ushort P_1, string P_2, out int P_3, out int P_4, out int P_5)
	{
		for (int i = 0; i < bqgIcOISthcZfWwGUQIjImwwzcVf.Length; i++)
		{
			if (bqgIcOISthcZfWwGUQIjImwwzcVf[i].HuHHJjUvaYJAyVBqNvMLlNITopNm(P_0, P_1) && bqgIcOISthcZfWwGUQIjImwwzcVf[i].jCXEsKFlTtbhIYJFkLJmWpUneyZm)
			{
				P_3 = bqgIcOISthcZfWwGUQIjImwwzcVf[i].QqzRuUPQDCFKnUwIEWpIPbHVosqn;
				P_4 = bqgIcOISthcZfWwGUQIjImwwzcVf[i].fpDFLpDaPRmyLLrKBwQIgJJcYvNkA;
				P_5 = bqgIcOISthcZfWwGUQIjImwwzcVf[i].ZoOczqvvNoatXdlxMirPjDWNpGdkA;
				return true;
			}
		}
		P_3 = 0;
		P_4 = 0;
		P_5 = 0;
		return false;
	}

	public static bool wZCsFCmMxbQxaboaGIJSXxrpvQMs(ushort P_0, ushort P_1, string P_2 = null)
	{
		return UVPuWPVVrktvReLVzfpOJZArZufi(P_0, P_1, P_2);
	}

	private static bool UVPuWPVVrktvReLVzfpOJZArZufi(ushort P_0, ushort P_1, string P_2 = null)
	{
		for (int i = 0; i < bqgIcOISthcZfWwGUQIjImwwzcVf.Length; i++)
		{
			if (bqgIcOISthcZfWwGUQIjImwwzcVf[i].KQpgLCmKdgBwezSettBBXMwWegMb(P_0, P_1, P_2))
			{
				return true;
			}
		}
		return false;
	}

	private static yFOldLzKGLQBiPnNafLYWWccwHvo nXReMMbBChUCXqdvnRteNTqgAYMTA(ushort P_0, ushort P_1, string P_2 = null)
	{
		for (int i = 0; i < bqgIcOISthcZfWwGUQIjImwwzcVf.Length; i++)
		{
			if (bqgIcOISthcZfWwGUQIjImwwzcVf[i].KQpgLCmKdgBwezSettBBXMwWegMb(P_0, P_1, P_2))
			{
				return bqgIcOISthcZfWwGUQIjImwwzcVf[i];
			}
		}
		return null;
	}
}
