using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class MaxRectsBinPack
	{
		public enum FreeRectChoiceHeuristic
		{
			RectBestShortSideFit = 0,
			RectBestLongSideFit = 1,
			RectBestAreaFit = 2,
			RectBottomLeftRule = 3,
			RectContactPointRule = 4
		}

		public int binWidth;

		public int binHeight;

		public bool allowRotations;

		public List<Rect> usedRectangles;

		public List<Rect> freeRectangles;

		public MaxRectsBinPack(int width, int height, bool rotations)
		{
		}

		public void Init(int width, int height, bool rotations)
		{
		}

		public Rect Insert(int width, int height, FreeRectChoiceHeuristic method)
		{
			return default(Rect);
		}

		public void Insert(List<Rect> rects, List<Rect> dst, FreeRectChoiceHeuristic method)
		{
		}

		private void PlaceRect(Rect node)
		{
		}

		private Rect ScoreRect(int width, int height, FreeRectChoiceHeuristic method, ref int score1, ref int score2)
		{
			return default(Rect);
		}

		public float Occupancy()
		{
			return 0f;
		}

		private Rect FindPositionForNewNodeBottomLeft(int width, int height, ref int bestY, ref int bestX)
		{
			return default(Rect);
		}

		private Rect FindPositionForNewNodeBestShortSideFit(int width, int height, ref int bestShortSideFit, ref int bestLongSideFit)
		{
			return default(Rect);
		}

		private Rect FindPositionForNewNodeBestLongSideFit(int width, int height, ref int bestShortSideFit, ref int bestLongSideFit)
		{
			return default(Rect);
		}

		private Rect FindPositionForNewNodeBestAreaFit(int width, int height, ref int bestAreaFit, ref int bestShortSideFit)
		{
			return default(Rect);
		}

		private int CommonIntervalLength(int i1start, int i1end, int i2start, int i2end)
		{
			return 0;
		}

		private int ContactPointScoreNode(int x, int y, int width, int height)
		{
			return 0;
		}

		private Rect FindPositionForNewNodeContactPoint(int width, int height, ref int bestContactScore)
		{
			return default(Rect);
		}

		private bool SplitFreeNode(Rect freeNode, ref Rect usedNode)
		{
			return false;
		}

		private void PruneFreeList()
		{
		}

		private bool IsContainedIn(Rect a, Rect b)
		{
			return false;
		}
	}
}
