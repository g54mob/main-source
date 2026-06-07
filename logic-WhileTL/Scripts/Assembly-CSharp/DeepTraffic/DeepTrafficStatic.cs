using System;
using ConvNetSharp;
using ReinforcementLearning.Environment;
using UnityEngine;

namespace DeepTraffic
{
	public static class DeepTrafficStatic
	{
		public const float brakeTrackScaleMean = 5f;

		public const float brakeTrackScaleStd = 2f;

		public const float brakeTrackXScale = 5f;

		public const float brakeTrackHeightLowerBound = 10f;

		public const float brakeTrackHeightScale = 360f;

		public static readonly int cellObjectSize = Enum.GetNames(typeof(CellObjects)).Length;

		private static readonly DeepTrafficAction[] possibleActions = new DeepTrafficAction[5]
		{
			DeepTrafficAction.acelerate,
			DeepTrafficAction.decelerate,
			DeepTrafficAction.goLeft,
			DeepTrafficAction.goRight,
			DeepTrafficAction.noAction
		};

		private static readonly int[] intPossibleActions = new int[5] { 0, 1, 2, 3, 4 };

		public static int GetMoneyByScore(float score)
		{
			return Mathf.RoundToInt((float)Math.Max(0.0, (double)score * Math.PI * 100.0 + Math.E));
		}

		public static int GetMoneyBySpeed(float speed)
		{
			return GetMoneyByScore(speed - 50f);
		}

		public static int InputSize(int patchesAhead, int lanesSide, int patchesBehind, int carHeight)
		{
			return patchesAhead * (2 * lanesSide + 1) + patchesBehind * (2 * lanesSide + 1) - Mathf.Min(carHeight, patchesBehind);
		}

		public static int InputSize(DeepTrafficEnvPresets envPresets)
		{
			return InputSize(envPresets.PatchesAhead, envPresets.LanesSide, envPresets.PatchesBehind, envPresets.carHeight);
		}

		public static int GetMoneySpend(float moneyPerSecond, int iterationToEvalueate)
		{
			return Mathf.RoundToInt(moneyPerSecond * Time.fixedDeltaTime * (float)iterationToEvalueate / 2f);
		}

		public static int BehindLedarBound(int patchesAhead, int lanesSide, int patchesBehind, int carHeight)
		{
			return Mathf.Max(0, (patchesBehind - carHeight) * (2 * lanesSide + 1));
		}

		public static int BehindLidarBound(DeepTrafficEnvPresets envPresets)
		{
			return BehindLedarBound(envPresets.PatchesAhead, envPresets.LanesSide, envPresets.PatchesBehind, envPresets.carHeight);
		}

		public static int FrontLedarBound(int patchesAhead, int lanesSide, int patchesBehind, int carHeight)
		{
			return BehindLedarBound(patchesAhead, lanesSide, patchesBehind, carHeight) + 2 * lanesSide * carHeight;
		}

		public static int FrontLidarBound(DeepTrafficEnvPresets envPresets)
		{
			return FrontLedarBound(envPresets.PatchesAhead, envPresets.LanesSide, envPresets.PatchesBehind, envPresets.carHeight);
		}

		public static bool IsFront(int id, int patchesAhead, int lanesSide, int patchesBehind, int carHeight)
		{
			id -= FrontLedarBound(patchesAhead, lanesSide, patchesBehind, carHeight);
			if (id < 0)
			{
				return false;
			}
			return id % (2 * lanesSide + 1) == lanesSide;
		}

		public static bool IsFront(int id, DeepTrafficEnvPresets envPresets)
		{
			return IsFront(id, envPresets.PatchesAhead, envPresets.LanesSide, envPresets.PatchesBehind, envPresets.carHeight);
		}

		public static bool IsLeft(int id, int patchesAhead, int lanesSide, int patchesBehind, int carHeight)
		{
			if (lanesSide <= 0)
			{
				return false;
			}
			int num = FrontLedarBound(patchesAhead, lanesSide, patchesBehind, carHeight);
			if (num <= id)
			{
				return (id - num) % (2 * lanesSide + 1) < lanesSide;
			}
			id -= BehindLedarBound(patchesAhead, lanesSide, patchesBehind, carHeight);
			if (id < 0)
			{
				return false;
			}
			return id % (2 * lanesSide) < lanesSide;
		}

		public static bool IsLeft(int id, DeepTrafficEnvPresets envPresets)
		{
			return IsLeft(id, envPresets.PatchesAhead, envPresets.LanesSide, envPresets.PatchesBehind, envPresets.carHeight);
		}

		public static bool IsRight(int id, int patchesAhead, int lanesSide, int patchesBehind, int carHeight)
		{
			if (lanesSide <= 0)
			{
				return false;
			}
			int num = FrontLedarBound(patchesAhead, lanesSide, patchesBehind, carHeight);
			if (num <= id)
			{
				return (id - num) % (2 * lanesSide + 1) > lanesSide;
			}
			id -= BehindLedarBound(patchesAhead, lanesSide, patchesBehind, carHeight);
			if (id < 0)
			{
				return false;
			}
			return id % (2 * lanesSide) >= lanesSide;
		}

		public static bool IsRight(int id, DeepTrafficEnvPresets envPresets)
		{
			return IsRight(id, envPresets.PatchesAhead, envPresets.LanesSide, envPresets.PatchesBehind, envPresets.carHeight);
		}

		public static DeepTrafficAction[] GetPossibleActions(CellObjects[] state = null)
		{
			return possibleActions;
		}

		public static int[] GetIntPossibleActions(Volume state = null)
		{
			return intPossibleActions;
		}
	}
}
